using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using LubriTech.Model.InventoryManagment_Information;
using LubriTech.Model.Item_Information;
using LubriTech.Model.Supplier_Information;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_InventoryManagment : Form
    {
        private List<Supplier> suppliers;
        private List<Branch> branches;
        private Supplier selectedSupplier = null;
        private Item selectedItem = null;
        private DetailLine detailLine = new DetailLine();
        private List<DetailLine> detailLines;
        private InventoryManagment existingInventoryManagment = null;
        private Boolean clickedAddDetail = false;
        decimal TotalAmount;

        public frmInsertUpdate_InventoryManagment()
        {
            suppliers = new List<Supplier>();
            branches = new Branch_Controller().getAll();
            detailLines = new List<DetailLine>();
            InitializeComponent();
            SetupDetailLinesDGV();
            txtCode.Enabled = false;
            setComboBox();
            tbSupplierName.Enabled = false;
            tbTotalAmount.Enabled = false;
            tbItemName.Enabled = false;
            tbQuantity.Enabled = false;
            tbAmount.Enabled = false;
            tbSupplierId.Enabled = false;
            btnSelectSupplier.Enabled = false;
        }

        public frmInsertUpdate_InventoryManagment(InventoryManagment inventoryManagment)
        {
            InitializeComponent();
            txtCode.Enabled = false;
            txtCode.Text = inventoryManagment.Id.ToString();
            suppliers = new List<Supplier>();
            branches = new Branch_Controller().getAll();
            detailLines = new DetailLine_Controller().getDetailLines(inventoryManagment.Id);
            existingInventoryManagment = inventoryManagment;
            setComboBox();

            tbSupplierName.Enabled = false;
            tbItemName.Enabled = false;
            tbAmount.Enabled = false;
            if (inventoryManagment.Supplier != null)
            {
                tbSupplierName.Text = inventoryManagment.Supplier.name;
                tbSupplierId.Text = inventoryManagment.Supplier.id;
            }
            cbBranch.SelectedValue = inventoryManagment.Branch.Id;
            dtpDate.Value = inventoryManagment.DocumentDate;
            cbDocumentType.Text = inventoryManagment.DocumentType;
            cbState.Text = inventoryManagment.State;
            tbQuantity.Enabled = false;
            tbTotalAmount.Enabled = false;
            if (!cbDocumentType.Text.Equals("Compra"))
            {
                tbSupplierId.Enabled = false;
                btnSelectSupplier.Enabled = false;
            }

            SetupDetailLinesDGV();
            load_DetailLines(detailLines);
            checkState(inventoryManagment.State);

        }

        private void frmInsertUpdateInventoryManagment_Load(object sender, EventArgs e)
        {
            if (existingInventoryManagment != null)
            {
                DetailLine_Controller detailLine_Controller = new DetailLine_Controller();
                detailLines = detailLine_Controller.getDetailLines(existingInventoryManagment.Id);
            }
            load_DetailLines(detailLines);
        }

        private void load_DetailLines(List<DetailLine> filteredList)
        {

            dgvDetailLines.DataSource = filteredList;
            dgvDetailLines.Columns["InventoryManagment"].Visible = false;
            dgvDetailLines.Columns["UnitCost"].HeaderText = "Costo unitario";
            dgvDetailLines.Columns["Item"].HeaderText = "Artículo";
            dgvDetailLines.Columns["Quantity"].HeaderText = "Cantidad";
            dgvDetailLines.Columns["Amount"].HeaderText = "Monto";
            tbTotalAmount.Text = calculateTotalAmount().ToString();
            SetColumnOrder();
        }

        private void SetColumnOrder()
        {
            dgvDetailLines.Columns["Item"].DisplayIndex = 0;
            dgvDetailLines.Columns["Quantity"].DisplayIndex = 2;
            dgvDetailLines.Columns["Amount"].DisplayIndex = 3;
            dgvDetailLines.Columns["UnitCost"].DisplayIndex = 1;
            dgvDetailLines.Columns["deleteImageColumn"].DisplayIndex = 4;
        }

        private void checkState(string state)
        {
            if (state.Equals("Finalizado"))
            {
                tbSupplierId.Enabled = false;
                tbItemCode.Enabled = false;
                cbBranch.Enabled = false;
                dtpDate.Enabled = false;
                cbDocumentType.Enabled = false;
                cbState.Enabled = false;
                tbQuantity.Enabled = false;
                btnAddDetailLine.Enabled = false;
                btnSelectSupplier.Enabled = false;
                btnSelectItem.Enabled = false;
            }
        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            InventoryManagment_Controller inventoryManagmentController = new InventoryManagment_Controller();

            if (cbBranch.Text.Trim() == ""
            || cbDocumentType.Text.Trim() == ""
            || cbState.Text.Trim() == "")
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
            else if (tbSupplierName.Text.Trim() == "" && cbDocumentType.Text.Equals("Compra"))
            {
                MessageBox.Show("Debe seleccionar un proveedor");
            }
            else
            {
                InventoryManagment inventoryManagment = new InventoryManagment();
                inventoryManagment.Supplier = selectedSupplier;
                inventoryManagment.Branch = new Branch_Controller().get(Convert.ToInt32(cbBranch.SelectedValue.ToString()));
                inventoryManagment.DocumentDate = dtpDate.Value;
                inventoryManagment.DocumentType = cbDocumentType.Text;
                inventoryManagment.State = cbState.Text;
                if (tbTotalAmount.Text.Trim() != "")
                {
                    inventoryManagment.TotalAmount = Convert.ToDouble(tbTotalAmount.Text.Trim());
                }
                else
                {
                    inventoryManagment.TotalAmount = 0;
                }

                if (existingInventoryManagment != null)
                {
                    inventoryManagment.Id = existingInventoryManagment.Id;
                }

                int insertedId = inventoryManagmentController.upsert(inventoryManagment);
                existingInventoryManagment = inventoryManagment;
                string quantityUpdated = updateItemsQuantity();

                if (insertedId != -1 && quantityUpdated.Equals(""))
                {
                    if (selectedSupplier != null)
                    {
                        tbSupplierId.Text = selectedSupplier.id;
                    }
                    existingInventoryManagment.Id = insertedId;

                    OnDataChanged(EventArgs.Empty);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("El manejo de inventario no se ha agregado correctamente\n" + quantityUpdated);
                }
            }

        }

        private double calculateTotalAmount()
        {
            double totalAmount = 0;
            if (dgvDetailLines.Rows.Count > 0 && !dgvDetailLines.Rows[0].IsNewRow)
            {
                foreach (DataGridViewRow row in dgvDetailLines.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        double amount = Convert.ToDouble(row.Cells["Amount"].Value);

                        totalAmount += amount;
                    }
                }
                return totalAmount;
            }
            return totalAmount;
        }

        private void tbNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (e.KeyChar != 8)
            {


                string input = textBox.Text.Insert(textBox.SelectionStart, e.KeyChar.ToString());
                Regex regex = new Regex(@"^\d*(\,\d{0,2})?$");
                if (char.IsControl(e.KeyChar))
                {
                    return;
                }

                if (!regex.IsMatch(input))
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar == ',' && textBox.Text.Length == 0) return;

            double quantity = 0;
            double unitCost = 0;

            if (double.TryParse(txtUnitCost.Text, out unitCost))
            {
                string text = textBox.Text;

                if (e.KeyChar == 8) // Backspace
                {
                    text = text.Length > 0 ? text.Remove(text.Length - 1) : "0";
                    text = text.Length > 0 ? text : "0";
                }
                else
                {
                    text += e.KeyChar;
                }

                quantity = Convert.ToDouble(text);
                {
                    tbAmount.Text = (quantity * unitCost).ToString();
                }
            }


          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (clickedAddDetail)
            {
                new InventoryManagment_Controller().delete(existingInventoryManagment.Id);
            }
            this.Close();
        }

        private void setComboBox()
        {
            cbBranch.DataSource = branches;
            cbBranch.ValueMember = "Id";
            cbBranch.DisplayMember = "Name";
            cbBranch.SelectedValue = frmLogin.branch;
        }

        private void btnSelectSupplier_Click(object sender, EventArgs e)
        {
            frmSuppliers frmSupplier = new frmSuppliers(this);
            frmSupplier.SupplierSelected += HandleSupplierSelected;
            frmSupplier.MdiParent = this.MdiParent;
            frmSupplier.Show();
        }

        private void HandleSupplierSelected(Supplier selectedSupplier)
        {
            ShowSupplierInUpsertInventoryManagment(selectedSupplier);
        }

        public void ShowSupplierInUpsertInventoryManagment(Supplier supplier)
        {
            if (supplier != null)
            {
                tbSupplierName.Text = supplier.name;
                tbSupplierId.Text = supplier.id;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnAddDetailLine_Click(object sender, EventArgs e)
        {
            if (existingInventoryManagment == null)
            {
                if (cbBranch.Text.Trim() == ""
                || cbDocumentType.Text.Trim() == ""
                || cbState.Text.Trim() == "")
                {
                    MessageBox.Show("Por favor llene los campos anteriores");
                }
                else if (tbSupplierName.Text.Trim() == "" && cbDocumentType.Text.Equals("Compra"))
                {
                    MessageBox.Show("Debe seleccionar un proveedor");
                }
                else
                {
                    InventoryManagment_Controller inventoryManagmentController = new InventoryManagment_Controller();
                    InventoryManagment inventoryManagment = new InventoryManagment();
                    if (selectedSupplier != null)
                    {
                        tbSupplierId.Text = selectedSupplier.id;
                    }

                    inventoryManagment.Supplier = selectedSupplier;
                    inventoryManagment.Branch = new Branch_Controller().get(Convert.ToInt32(cbBranch.SelectedValue.ToString()));
                    inventoryManagment.DocumentDate = dtpDate.Value;
                    inventoryManagment.DocumentType = cbDocumentType.Text;
                    inventoryManagment.State = cbState.Text;
                    if (tbTotalAmount.Text.Trim() != "")
                    {
                        inventoryManagment.TotalAmount = Convert.ToDouble(tbTotalAmount.Text.Trim());
                    }
                    else
                    {
                        inventoryManagment.TotalAmount = 0;
                    }

                    existingInventoryManagment = inventoryManagment;
                    int insertedId = inventoryManagmentController.upsert(inventoryManagment);
                    if (insertedId != -1)
                    {
                        txtCode.Text = insertedId.ToString();
                        clickedAddDetail = true;
                        existingInventoryManagment.Id = insertedId;
                        if (tbQuantity.Text.Trim() == "")
                        {
                            MessageBox.Show("Por favor llene todos los campos");
                        }
                        else if (tbQuantity.Text.Trim() == "0" )
                        {
                            MessageBox.Show("La cantidad de artículos debe ser mayor a 0");
                        }
                        else if (txtUnitCost.Text.Trim() == "0" || txtUnitCost.Text.Trim() == "")
                        {
                            MessageBox.Show("El costo unitario debe ser mayor a 0");
                        }
                        else if (tbItemName.Text.Trim() == "")
                        {
                            MessageBox.Show("Debe seleccionar un artículo");
                        }
                        else if (cbDocumentType.Text.Trim() == "Salida" && !validateItemStock(selectedItem.code, Convert.ToInt32(cbBranch.SelectedValue.ToString()), Convert.ToDouble(tbQuantity.Text.Trim())))
                        {
                            MessageBox.Show("La cantidad de artículos ingresada excede la cantidad disponible en la sucursal");
                        }
                        else
                        {
                            DetailLine_Controller detailLineController = new DetailLine_Controller();

                            tbItemCode.Text = selectedItem.code;

                            detailLine.InventoryManagment = existingInventoryManagment;
                            detailLine.Item = selectedItem;
                            detailLine.Quantity = Convert.ToDouble(tbQuantity.Text.Trim());
                            detailLine.UnitCost = Convert.ToDouble(txtUnitCost.Text.Trim());
                            detailLine.Amount = Convert.ToDouble(tbAmount.Text.Trim());

                            if (detailLineController.upsert(detailLine))
                            {
                                detailLines = new DetailLine_Controller().getDetailLines(existingInventoryManagment.Id);
                                load_DetailLines(detailLines);
                                tbItemCode.Text = "";
                                tbItemName.Text = "";
                                tbQuantity.Text = "";
                                txtUnitCost.Text = "";
                                tbAmount.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Línea de detalle no insertada");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error con el manejo de inventario");
                    }

                }
            }
            else
            {
                if (selectedSupplier != null)
                {
                    tbSupplierId.Text = selectedSupplier.id;
                }

                if (tbQuantity.Text.Trim() == "")
                {
                    MessageBox.Show("Por favor llene todos los campos");
                }
                else if (tbQuantity.Text.Trim() == "0")
                {
                    MessageBox.Show("La cantidad de artículos debe ser mayor a 0");
                }
                else if (txtUnitCost.Text.Trim() == "0" || txtUnitCost.Text.Trim() == "")
                {
                    MessageBox.Show("El costo unitario debe ser mayor a 0");
                }
                else if (tbItemName.Text.Trim() == "")
                {
                    MessageBox.Show("Debe seleccionar un artículo");
                }
                else if (cbDocumentType.Text.Trim() == "Salida" && !validateItemStock(selectedItem.code, Convert.ToInt32(cbBranch.SelectedValue.ToString()), Convert.ToDouble(tbQuantity.Text.Trim())))
                {
                    MessageBox.Show("La cantidad de artículos ingresada excede la cantidad disponible en la sucursal");
                }
                else
                {
                    DetailLine_Controller detailLineController = new DetailLine_Controller();

                    tbItemCode.Text = selectedItem.code;

                    detailLine.InventoryManagment = existingInventoryManagment;
                    detailLine.Item = selectedItem;
                    detailLine.Quantity = Convert.ToDouble(tbQuantity.Text.Trim());
                    detailLine.UnitCost = Convert.ToDouble(txtUnitCost.Text.Trim());
                    detailLine.Amount = Convert.ToDouble(tbAmount.Text.Trim());

                    if (detailLineController.upsert(detailLine))
                    {
                        detailLines = new DetailLine_Controller().getDetailLines(existingInventoryManagment.Id);
                        load_DetailLines(detailLines);
                        tbItemCode.Text = "";
                        tbItemName.Text = "";
                        tbQuantity.Text = "";
                        txtUnitCost.Text = "";
                        tbAmount.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Línea de detalle no insertada");
                    }
                }
            }

        }


        private void tbItemCode_TextChanged(object sender, EventArgs e)
        {
            string code = tbItemCode.Text;

            if (code.Length >= 3)
            {
                Item item = new Item_Controller().get(code);

                ItemType_Controller itemTypeController = new ItemType_Controller();
                List<ItemType> itemTypes = itemTypeController.loadAllItemTypes();
                if (itemTypes.Count != 0)
                {
                    int itemTypeId = -1;
                    foreach (ItemType itemType in itemTypes)
                    {
                        if (itemType.Name.Equals("Servicio"))
                        {
                            itemTypeId = itemType.Id;
                        }
                    }

                    if (item != null && item.itemType.Id != itemTypeId)
                    {
                        SelectItem(item);
                    }
                }
            }
        }

        public void SelectItem(Item item)
        {
            if (item != null)
            {
                selectedItem = item;
                tbItemName.Text = item.name;
                tbItemCode.Text = item.code;
            }
        }

        private void tbSupplierId_TextChanged(object sender, EventArgs e)
        {
            string id = tbSupplierId.Text;

            if (id.Length >= 3)
            {
                Supplier supplier = new Supplier_Controller().GetSupplier(id);

                if (supplier != null)
                {
                    SelectSupplier(supplier);
                }
            }
        }

        public void SelectSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                tbSupplierId.Text = supplier.id;
            }
            selectedSupplier = supplier;
            tbSupplierName.Text = supplier.name;
        }

        private void dgvDetailLines_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Item selectedItem = (Item)dgvDetailLines.Rows[e.RowIndex].Cells["Item"].Value;
                List<DetailLine> detailLines = new DetailLine_Controller().getDetailLines(existingInventoryManagment.Id);
                DetailLine selectedDetailLine = null;

                foreach (DetailLine detailLine in detailLines)
                {
                    if (detailLine.Item.code == selectedItem.code)
                    {
                        selectedDetailLine = detailLine;
                        break;
                    }
                }

                tbItemCode.Text = selectedDetailLine.Item.code;
                tbItemName.Text = selectedDetailLine.Item.name;
                tbQuantity.Text = selectedDetailLine.Quantity.ToString();
                txtUnitCost.Text = selectedDetailLine.UnitCost.ToString();
                tbAmount.Text = selectedDetailLine.Amount.ToString();


                if (e.ColumnIndex == dgvDetailLines.Columns["deleteImageColumn"].Index)
                {
                    DialogResult result = MessageBox.Show("¿Desea eliminar esta línea de detalle?", "Confirmar selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (new DetailLine_Controller().delete(selectedDetailLine))
                        {
                            detailLines = new DetailLine_Controller().getDetailLines(existingInventoryManagment.Id);
                            load_DetailLines(detailLines);
                            tbItemCode.Text = "";
                            tbItemName.Text = "";
                            tbQuantity.Text = "";
                            txtUnitCost.Text = "";
                            tbAmount.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Línea de detalle no se eliminó");
                        }
                    }
                }

                return;
            }
        }

        private void btnSelectItem_Click(object sender, EventArgs e)
        {
            frmItems frmItems = new frmItems(this);
            frmItems.ItemSelected += HandleItemSelected;
            frmItems.MdiParent = this.MdiParent;
            frmItems.Show();
        }

        private void HandleItemSelected(Item itemSelected)
        {
            ShowItemInDetailLine(itemSelected);
        }

        public void ShowItemInDetailLine(Item item)
        {
            if (item != null)
            {
                tbItemName.Text = item.name;
                tbItemCode.Text = item.code;
            }


        }

        private void SetupDetailLinesDGV()
        {
            DataGridViewImageColumn deleteImageColumn = new DataGridViewImageColumn();
            deleteImageColumn.Name = "deleteImageColumn";
            deleteImageColumn.HeaderText = "";
            deleteImageColumn.Image = Properties.Resources.DeleteIco1;
            //set the color of the background of the image
            deleteImageColumn.DefaultCellStyle.BackColor = Color.FromArgb(4, 55, 111);
            deleteImageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetailLines.Columns.Add(deleteImageColumn);
        }

        private Boolean validateItemStock(string itemCode, int branchId, double quantity)
        {
            if (new Item_Controller().getItemStock(itemCode, branchId) < quantity)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string updateItemsQuantity()
        {
            double newQuantity;
            if (cbDocumentType.Text.Equals("Entrada"))
            {
                if (cbState.Text.Equals("Finalizado"))
                {
                    foreach (var detailLine in detailLines)
                    {
                        newQuantity = ((new Item_Controller().getItemStock(detailLine.Item.code, Convert.ToInt32(cbBranch.SelectedValue.ToString()))) + detailLine.Quantity);
                        if (!new Item_Controller().updateQuantity(detailLine.Item.code, Convert.ToInt32(cbBranch.SelectedValue.ToString()), newQuantity))
                        {
                            return "No se pudo actualizar la cantidad del artículo: " + detailLine.Item.name + " - Código: " + detailLine.Item.code;
                        }
                    }
                    return "";
                }
                return "";
            }
            else if (cbDocumentType.Text.Equals("Compra"))
            {
                if (cbState.Text.Equals("Finalizado"))
                {
                    foreach (var detailLine in detailLines)
                    {
                        newQuantity = ((new Item_Controller().getItemStock(detailLine.Item.code, Convert.ToInt32(cbBranch.SelectedValue.ToString()))) + detailLine.Quantity);
                        if (!new Item_Controller().updateQuantity(detailLine.Item.code, Convert.ToInt32(cbBranch.SelectedValue.ToString()), newQuantity))
                        {
                            return "No se pudo actualizar la cantidad del artículo: " + detailLine.Item.name + " - Código: " + detailLine.Item.code;
                        }
                    }
                    return "";
                }
                return "";
            }
            else
            {
                if (cbState.Text.Equals("Finalizado"))
                {
                    foreach (var detailLine in detailLines)
                    {
                        if (!validateItemStock(detailLine.Item.code, Convert.ToInt32(cbBranch.SelectedValue.ToString()), Convert.ToDouble(detailLine.Quantity)))
                        {
                            return "No hay suficientes artículos de: " + detailLine.Item.name + " - Código: " + detailLine.Item.code + " disponibles en la sucursal";
                        }
                    }
                    foreach (var detailLine in detailLines)
                    {
                        newQuantity = ((new Item_Controller().getItemStock(detailLine.Item.code, Convert.ToInt32(cbBranch.SelectedValue.ToString()))) - detailLine.Quantity);
                        if (!new Item_Controller().updateQuantity(detailLine.Item.code, Convert.ToInt32(cbBranch.SelectedValue.ToString()), newQuantity))
                        {
                            return "No se pudo actualizar la cantidad del artículo: " + detailLine.Item.name + " - Código: " + detailLine.Item.code;
                        }
                    }
                    return "";
                }
                return "";
            }
        }

        private void tbItemName_TextChanged(object sender, EventArgs e)
        {
            if (tbItemName.Text.Trim().Equals("") || cbState.Text.Trim().Equals("Finalizado"))
            {
                tbQuantity.Enabled = false;
            }
            else
            {
                tbQuantity.Enabled = true;
            }
        }

        private void cbDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDocumentType.Text.Equals("Compra"))
            {
                tbSupplierId.Enabled = true;
                btnSelectSupplier.Enabled = true;
            }
            else
            {
                tbSupplierId.Enabled = false;
                btnSelectSupplier.Enabled = false;
                tbSupplierId.Text = "";
                tbSupplierName.Text = "";
                selectedSupplier = null;
            }
        }

        private void cbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbState.Text.Equals("Finalizado"))
            {
                tbSupplierId.Enabled = false;
                tbItemCode.Enabled = false;
                cbBranch.Enabled = false;
                dtpDate.Enabled = false;
                cbDocumentType.Enabled = false;
                tbQuantity.Enabled = false;
                btnAddDetailLine.Enabled = false;
                btnSelectSupplier.Enabled = false;
                btnSelectItem.Enabled = false;
            }
            else
            {
                if (cbDocumentType.Text.Equals("Compra"))
                {
                    tbSupplierId.Enabled = true;
                    btnSelectSupplier.Enabled = true;
                }
                tbItemCode.Enabled = true;
                cbBranch.Enabled = true;
                dtpDate.Enabled = true;
                cbDocumentType.Enabled = true;
                tbQuantity.Enabled = true;
                btnAddDetailLine.Enabled = true;
                btnSelectItem.Enabled = true;
            }
        }

        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void generatePdf()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Archivos de Pdf|*.pdf";
            savefile.FileName = string.Format(DateTime.Now.ToString("ddMMyyyyHHmmss"));

            CultureInfo spanishCulture = new CultureInfo("es-ES");
            DateTime selectedDate = dtpDate.Value;
            string formattedDate = selectedDate.ToString("dddd, d 'de' MMMM 'de' yyyy", spanishCulture);
            formattedDate = char.ToUpper(formattedDate[0]) + formattedDate.Substring(1);

            string PaginaHTML_Texto = Properties.Resources.Template2.ToString();

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@INVENTORYID", existingInventoryManagment.Id.ToString());
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@BRANCH", cbBranch.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DATE", formattedDate);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TYPE", cbDocumentType.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@STATE", cbState.Text);

            if (selectedSupplier != null)
            {
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ID", selectedSupplier.id);
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NAME", selectedSupplier.name);
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MAINPHONE", selectedSupplier.phone.ToString());
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EMAIL", selectedSupplier.email);
            }
            else
            {
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ID", "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NAME", "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MAINPHONE", "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EMAIL", "N/A");
            }


            string htmlTable = "<table class='inventory-managment-table' style='border-collapse: collapse; width: 100%;'>";

            DataGridView dgvDetails;
            if (dgvDetailLines.Columns.Count > 0)
            {
                dgvDetails = dgvDetailLines;
                dgvDetails.Columns["Item"].HeaderText = "Articulo";
                dgvDetails.Columns["Quantity"].HeaderText = "Cantidad";
                dgvDetails.Columns["Amount"].HeaderText = "Monto";

                dgvDetails.Columns.Remove("deleteImageColumn");
                dgvDetails.Columns.Remove("InventoryManagment");

                htmlTable += "<tr>";
                foreach (DataGridViewColumn column in dgvDetails.Columns)
                {
                    htmlTable += "<th>" + column.HeaderText + "</th>";
                }
                htmlTable += "</tr>";

                foreach (DataGridViewRow row in dgvDetails.Rows)
                {
                    htmlTable += "<tr>";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        htmlTable += "<td>" + cell.Value?.ToString() + "</td>";
                    }

                    htmlTable += "</tr>";
                }
            }

            htmlTable += "<tr>";
            htmlTable += "<td colspan='" + ((dgvDetailLines.Columns.Count > 0) ? (dgvDetailLines.Columns.Count - 1) : 0) + "' style='text-align: center; font-weight: bold; font-size: 15px; padding-left: 105px;'>MontoTotal:</td>";
            htmlTable += "<td>" + ((tbTotalAmount.Text.Trim().Equals("")) ? "0" : tbTotalAmount.Text) + "</td>";
            htmlTable += "</tr>";

            htmlTable += "</table>";

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@INVENTORYMANAGEMENT", htmlTable);

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string filePath = savefile.FileName;

                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            InventoryManagment_Controller inventoryManagmentController = new InventoryManagment_Controller();

            if (cbBranch.Text.Trim() == ""
            || cbDocumentType.Text.Trim() == ""
            || cbState.Text.Trim() == "")
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
            else if (tbSupplierName.Text.Trim() == "" && cbDocumentType.Text.Equals("Compra"))
            {
                MessageBox.Show("Al ser una compra debe seleccionar un proveedor");
            }
            else
            {
                generatePdf();
            }
        }

        private void txtUnitCost_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBox textBox = sender as TextBox;
            if (e.KeyChar != 8)
            {

                string input = textBox.Text.Insert(textBox.SelectionStart, e.KeyChar.ToString());

                Regex regex = new Regex(@"^\d*(\,\d{0,2})?$");

                if (char.IsControl(e.KeyChar))
                {
                    return;
                }

                if (!regex.IsMatch(input))
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar == ',' && textBox.Text.Length == 0) return;

            double quantity = 0;
            double unitCost = 0;

            if (double.TryParse(tbQuantity.Text.Trim(), out quantity))
            {
                string text = textBox.Text;

                if (e.KeyChar == 8) // Backspace
                {
                    text = text.Length > 0 ? text.Remove(text.Length - 1) : "0";
                    text = text.Length > 0 ? text : "0";
                }
                else
                {
                    text += e.KeyChar;
                }

                unitCost = Convert.ToDouble(text);
                {
                    tbAmount.Text = (quantity * unitCost).ToString();
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
