﻿using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using LubriTech.Model.InventoryManagment_Information;
using LubriTech.Model.Item_Information;
using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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

        public frmInsertUpdate_InventoryManagment()
        {
            suppliers = new List<Supplier>();
            branches = new Branch_Controller().getAll();
            detailLines = new List<DetailLine>();
            InitializeComponent();
            SetupDetailLinesDGV();
            setComboBox();
            tbSupplierName.Enabled = false;
            tbTotalAmount.Enabled = false;
            tbItemName.Enabled = false;
            tbQuantity.Enabled = false;
            tbAmount.Enabled = false;
        }

        public frmInsertUpdate_InventoryManagment(InventoryManagment inventoryManagment)
        {
            suppliers = new List<Supplier>();
            branches = new Branch_Controller().getAll();
            detailLines = new DetailLine_Controller().getDetailLines(inventoryManagment.Id);
            existingInventoryManagment = inventoryManagment;
            InitializeComponent();
            setComboBox();

            tbSupplierName.Enabled = false;
            tbItemName.Enabled = false;
            tbAmount.Enabled = false;
            tbSupplierName.Text = inventoryManagment.Supplier.name;
            tbSupplierId.Text = inventoryManagment.Supplier.id;
            cbBranch.Text = inventoryManagment.Branch.Name;
            dtpDate.Value = inventoryManagment.DocumentDate;
            cbDocumentType.Text = inventoryManagment.DocumentType;
            cbState.Text = inventoryManagment.State;
            tbQuantity.Enabled = false;
            tbTotalAmount.Enabled = false;

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
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvDetailLines.DataSource = detailLines;

                }
                else
                {
                    dgvDetailLines.DataSource = filteredList;
                }
            }
            dgvDetailLines.Columns["InventoryManagment"].Visible = false;
            dgvDetailLines.Columns["Item"].HeaderText = "Artículo";
            dgvDetailLines.Columns["Quantity"].HeaderText = "Cantidad";
            dgvDetailLines.Columns["Amount"].HeaderText = "Monto";
            tbTotalAmount.Text = calculateTotalAmount().ToString();
            SetColumnOrder();
        }

        private void SetColumnOrder()
        {
            dgvDetailLines.Columns["Item"].DisplayIndex = 0;
            dgvDetailLines.Columns["Quantity"].DisplayIndex = 1;
            dgvDetailLines.Columns["Amount"].DisplayIndex = 2;
            dgvDetailLines.Columns["deleteImageColumn"].DisplayIndex = 3;
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
            else if (tbSupplierName.Text.Trim() == "")
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
                    tbSupplierId.Text = selectedSupplier.id;
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
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
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
            cbBranch.SelectedIndex = -1;

            //List<int> years = new List<int>();
            //int currentYear = DateTime.Now.Year - 10;

            //for (int i = 0; i <= 10; i++)
            //{
            //    years.Add(currentYear);
            //    currentYear += 1;
            //}

            //cbYear.DataSource = years;
            //cbYear.SelectedIndex = -1;
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

        private void panelControlBox_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            if (clickedAddDetail)
            {
                new InventoryManagment_Controller().delete(existingInventoryManagment.Id);
            }
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
                else if (tbSupplierName.Text.Trim() == "")
                {
                    MessageBox.Show("Debe seleccionar un proveedor");
                }
                else
                {
                    InventoryManagment_Controller inventoryManagmentController = new InventoryManagment_Controller();
                    InventoryManagment inventoryManagment = new InventoryManagment();

                    tbSupplierId.Text = selectedSupplier.id;
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
                        clickedAddDetail = true;
                        existingInventoryManagment.Id = insertedId;
                        if (tbQuantity.Text.Trim() == "")
                        {
                            MessageBox.Show("Por favor llene todos los campos");
                        }
                        else if (tbQuantity.Text.Trim() == "0")
                        {
                            MessageBox.Show("La cantidad de artículos debe ser mayor a 0");
                        }
                        else if (tbItemName.Text.Trim() == "")
                        {
                            MessageBox.Show("Debe seleccionar un artículo");
                        }
                        else if (cbDocumentType.Text.Trim() == "Salida" && !validateItemStock(selectedItem.code, frmLogin.branch, Convert.ToDouble(tbQuantity.Text.Trim())))
                        {
                            MessageBox.Show("La cantidad de artículos ingresada excede la cantidad disponible en la sucursal");
                        }
                        else
                        {
                            DetailLine_Controller detailLineController = new DetailLine_Controller();

                            tbItemCode.Text = selectedItem.code;

                            detailLine.InventoryManagment = existingInventoryManagment;
                            detailLine.Item = selectedItem;
                            detailLine.Quantity = Convert.ToInt32(tbQuantity.Text.Trim());
                            detailLine.Amount = Convert.ToDouble(tbAmount.Text.Trim());

                            if (detailLineController.upsert(detailLine))
                            {
                                detailLines = new DetailLine_Controller().getDetailLines(existingInventoryManagment.Id);
                                load_DetailLines(detailLines);
                                tbItemCode.Text = "";
                                tbItemName.Text = "";
                                tbQuantity.Text = "";
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
                tbSupplierId.Text = selectedSupplier.id;

                if (tbQuantity.Text.Trim() == "")
                {
                    MessageBox.Show("Por favor llene todos los campos");
                }
                else if (tbQuantity.Text.Trim() == "0")
                {
                    MessageBox.Show("La cantidad de artículos debe ser mayor a 0");
                }
                else if (tbItemName.Text.Trim() == "")
                {
                    MessageBox.Show("Debe seleccionar un artículo");
                }
                else if (cbDocumentType.Text.Trim() == "Salida" && !validateItemStock(selectedItem.code, frmLogin.branch, Convert.ToDouble(tbQuantity.Text.Trim())))
                {
                    MessageBox.Show("La cantidad de artículos ingresada excede la cantidad disponible en la sucursal");
                }
                else
                {
                    DetailLine_Controller detailLineController = new DetailLine_Controller();

                    tbItemCode.Text = selectedItem.code;

                    detailLine.InventoryManagment = existingInventoryManagment;
                    detailLine.Item = selectedItem;
                    detailLine.Quantity = Convert.ToInt32(tbQuantity.Text.Trim());
                    detailLine.Amount = Convert.ToDouble(tbAmount.Text.Trim());

                    if (detailLineController.upsert(detailLine))
                    {
                        detailLines = new DetailLine_Controller().getDetailLines(existingInventoryManagment.Id);
                        load_DetailLines(detailLines);
                        tbItemCode.Text = "";
                        tbItemName.Text = "";
                        tbQuantity.Text = "";
                        tbAmount.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Línea de detalle no insertada");
                    }
                }
            }
        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            if (tbQuantity.Text.Trim() != "" && tbItemName.Text.Trim() != "")
            {
                tbItemCode.Text = selectedItem.code;
                double calc = (Convert.ToDouble(tbQuantity.Text.ToString().Trim()) * (new Item_Controller().get(tbItemCode.Text.Trim()).purchasePrice));
                tbAmount.Text = calc.ToString();
            }
            if (tbQuantity.Text.Trim() == "")
            {
                tbAmount.Text = "";
            }
        }

        private void tbItemCode_TextChanged(object sender, EventArgs e)
        {
            string code = tbItemCode.Text;

            if (code.Length >= 3)
            {
                Item item = new Item_Controller().get(code);

                if (item != null)
                {
                    SelectItem(item);
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
                tbAmount.Text = selectedDetailLine.Amount.ToString();

                if (!cbState.Text.Equals("Finalizado"))
                {
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
                                tbAmount.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Línea de detalle no se eliminó");
                            }
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
            deleteImageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //deleteImageColumn.Width = Properties.Resources.DeleteIco1.Width * 2;
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
                        newQuantity = ((new Item_Controller().getItemStock(detailLine.Item.code, frmLogin.branch)) + detailLine.Quantity);
                        if (!new Item_Controller().updateQuantity(detailLine.Item.code, frmLogin.branch, newQuantity))
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
                        newQuantity = ((new Item_Controller().getItemStock(detailLine.Item.code, frmLogin.branch)) + detailLine.Quantity);
                        if (!new Item_Controller().updateQuantity(detailLine.Item.code, frmLogin.branch, newQuantity))
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
                        if (!validateItemStock(detailLine.Item.code, frmLogin.branch, Convert.ToDouble(detailLine.Quantity)))
                        {
                            return "No hay suficientes artículos de: " + detailLine.Item.name + " - Código: " + detailLine.Item.code + " disponibles en la sucursal";
                        }
                    }
                    foreach (var detailLine in detailLines)
                    {
                        newQuantity = ((new Item_Controller().getItemStock(detailLine.Item.code, frmLogin.branch)) - detailLine.Quantity);
                        if (!new Item_Controller().updateQuantity(detailLine.Item.code, frmLogin.branch, newQuantity))
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
            if(tbItemName.Text.Trim().Equals("") || cbState.Text.Trim().Equals("Finalizado"))
            {
                tbQuantity.Enabled = false;
            }
            else
            {
                tbQuantity.Enabled = true;
            }
        }
    }
}
