using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Item_Information;
using LubriTech.Model.items_Information;
using LubriTech.Model.Vehicle_Information;
using LubriTech.Model.WorkOrder_Information;
using LubriTech.View.Appointment_View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using Rectangle = System.Drawing.Rectangle;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LubriTech.Model.InventoryManagment_Information;

namespace LubriTech.View
{
    public partial class frmWorkOrder : Form
    {
        int imageId;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        public event EventHandler DataChanged;

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private int? workOrderId; // Nullable int to store the work order ID
        Work_Order_Controller workOrderController = new Work_Order_Controller();
        Client client = new Client();
        Vehicle vehicle = new Vehicle();
        WorkOrder workOrderTemplate = new WorkOrder();
        List<Observation> observations;

        private int previousSelectedStateValue;

        public frmWorkOrder(int? workOrderId)
        {

            InitializeComponent();
            this.workOrderId = workOrderId;
            //InitializeTabControl();

            if (workOrderId.HasValue)
            {
                // Load the existing work order
                WorkOrder workOrder = workOrderController.LoadWorkOrder(workOrderId.Value);
                workOrderTemplate = workOrder;
                LoadWorkOrderData(workOrder);
                UpdateTotalAmount();
            }
            else
            {
                // Initialize a new work order
                InitializeNewWorkOrder();
            }
            load_Observation();
        }

        private void LoadWorkOrderData(WorkOrder workOrder)
        {
            //Set the data source of the combo box, State can be 0 for Inactiva 1 for Activa, 2 for En proceso, 3 for Terminada
            cbState.DataSource = new List<KeyValuePair<short, string>>()
            {
                new KeyValuePair<short, string>(0, "Inactiva"),
                new KeyValuePair<short, string>(1, "Activa"),
                new KeyValuePair<short, string>(2, "En proceso"),
                new KeyValuePair<short, string>(3, "Finalizado")
            };
            cbState.DisplayMember = "Value";
            cbState.ValueMember = "Key";
            cbState.SelectedIndex = workOrder.State;
            this.previousSelectedStateValue = workOrder.State;

            cbBranch.DataSource = new Branch_Model().loadAllBranches();
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
            cbBranch.SelectedValue = workOrder.Branch.Id;
            cbBranch.Enabled = false;

            dateTimePicker.Value = workOrder.Date;
            txtTotalAmount.Text = workOrder.Amount.ToString();

            client = workOrder.Client;
            txtClientId.Enabled = false;
            txtClientId.Text = workOrder.Client.Id.ToString();
            txtClientName.Enabled = false;
            txtClientName.Text = workOrder.Client.FullName.ToString();
            txtCellphone.Enabled = false;
            txtCellphone.Text = workOrder.Client.MainPhoneNum.ToString();
            txtCellphone2.Enabled = false;
            txtCellphone2.Text = workOrder.Client.AdditionalPhoneNum.ToString();
            txtEmail.Enabled = false;
            txtEmail.Text = workOrder.Client.Email.ToString();

            if (workOrder.Vehicle != null)
            {
                vehicle = workOrder.Vehicle;
                txtLicensePlate.Enabled = false;
                txtLicensePlate.Text = workOrder.Vehicle.LicensePlate.ToString();
                txtMake.Enabled = false;
                txtMake.Text = workOrder.Vehicle.Model.Make.ToString();
                txtModel.Enabled = false;
                txtModel.Text = workOrder.Vehicle.Model.ToString() + " " + workOrder.Vehicle.Year;
                txtMileage.Enabled = false;
                txtMileage.Text = workOrder.Vehicle.Mileage.ToString();
                txtCurrentMileage.Text = workOrder.Vehicle.Mileage.ToString();
            }
            setDeleteColumnDGV();
            loadWorkOrderLines(workOrder.Id);
        }

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        //Initialize a new work order
        private void InitializeNewWorkOrder()
        {
            //Set the data source of the combo box, State can be 0 for Inactiva 1 for Activa, 2 for En proceso, 3 for Terminada
            cbState.DataSource = new List<KeyValuePair<short, string>>()
            {
                new KeyValuePair<short, string>(0, "Inactiva"),
                new KeyValuePair<short, string>(1, "Activa"),
                new KeyValuePair<short, string>(2, "En proceso"),
                new KeyValuePair<short, string>(3, "Terminada")
            };
            cbState.DisplayMember = "Value";
            cbState.ValueMember = "Key";
            cbState.SelectedIndex = 1;
            this.previousSelectedStateValue = 1;

            cbBranch.DataSource = new Branch_Model().loadAllBranches();
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
            cbBranch.SelectedValue = frmLogin.branch;
            cbBranch.Enabled = false;

            dateTimePicker.Value = DateTime.Now;
            //txtDate.Text = DateTime.Now.ToString();
            txtTotalAmount.Text = "0";
            txtClientId.Enabled = true;
            txtClientId.Text = "";
            txtClientName.Enabled = true;
            txtClientName.Text = "";
            txtCellphone.Enabled = true;
            txtCellphone.Text = "";
            txtCellphone2.Enabled = true;
            txtCellphone2.Text = "";
            txtEmail.Enabled = true;
            txtEmail.Text = "";
            txtMake.Enabled = true;
            txtMake.Text = "";
            txtModel.Enabled = true;
            txtModel.Text = "";
            txtMileage.Enabled = true;
            txtMileage.Text = "";

            txtCurrentMileage.Text = "";

            setDeleteColumnDGV();
            dgvWorkOrderDetails.DataSource = new List<WorkOrderLine>();
            dgvWorkOrderDetails.Columns["Id"].Visible = false;
            dgvWorkOrderDetails.Columns["WorkOrderId"].Visible = false;
            dgvWorkOrderDetails.Columns["ItemCode"].Visible = false;
            dgvWorkOrderDetails.Columns["item"].HeaderText = "Descripción";
            dgvWorkOrderDetails.Columns["Quantity"].HeaderText = "Cantidad";
            dgvWorkOrderDetails.Columns["UnitPrice"].HeaderText = "Precio Unitario";
            dgvWorkOrderDetails.Columns["Amount"].HeaderText = "Monto";

            SetColumnOrder();
        }

        private void frmWorkOrder_Load(object sender, EventArgs e)
        {
            SetColumnOrder();
        }

        private void loadWorkOrderLines(int workOrderId)
        {
            dgvWorkOrderDetails.DataSource = new WorkOrderLine_Model().LoadWorkOrderLines(workOrderId, client.PriceList.id);

            dgvWorkOrderDetails.Columns["Id"].Visible = false;
            dgvWorkOrderDetails.Columns["WorkOrderId"].Visible = false;
            dgvWorkOrderDetails.Columns["item"].HeaderText = "Descripción";
            dgvWorkOrderDetails.Columns["ItemCode"].Visible = false;
            dgvWorkOrderDetails.Columns["UnitPrice"].HeaderText = "Precio Unitario";
            dgvWorkOrderDetails.Columns["Quantity"].HeaderText = "Cantidad";
            dgvWorkOrderDetails.Columns["Amount"].HeaderText = "Monto";

            SetColumnOrder();
        }

        public void setDeleteColumnDGV()
        {
            DataGridViewImageColumn deleteImageColumn = new DataGridViewImageColumn();
            deleteImageColumn.Name = "deleteImageColumn";
            deleteImageColumn.HeaderText = "";
            deleteImageColumn.Image = Properties.Resources.DeleteIco1;
            deleteImageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //deleteImageColumn.Width = Properties.Resources.DeleteIco1.Width * 2;
            dgvWorkOrderDetails.Columns.Add(deleteImageColumn);
        }

        private void SetColumnOrder()
        {

            dgvWorkOrderDetails.Columns["Id"].DisplayIndex = 0;
            dgvWorkOrderDetails.Columns["WorkOrderId"].DisplayIndex = 1;
            dgvWorkOrderDetails.Columns["ItemCode"].DisplayIndex = 2;
            dgvWorkOrderDetails.Columns["item"].DisplayIndex = 3;
            dgvWorkOrderDetails.Columns["UnitPrice"].DisplayIndex = 4;
            dgvWorkOrderDetails.Columns["Quantity"].DisplayIndex = 5;
            dgvWorkOrderDetails.Columns["Amount"].DisplayIndex = 6;
            dgvWorkOrderDetails.Columns["deleteImageColumn"].DisplayIndex = 7;
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;

            // Sum the amount of each work order line
            foreach (DataGridViewRow row in dgvWorkOrderDetails.Rows)
            {
                totalAmount += Convert.ToDecimal(row.Cells["Amount"].Value);
            }

            txtTotalAmount.Text = totalAmount.ToString("N2"); // Formatear el número como decimal
        }

        private void HandleItemSelected(Item item)
        {
            ShowItemInWorkOrder(item);
        }

        public void ShowItemInWorkOrder(Item item)
        {
            if (item != null)
            {
                txtItemCode.Text = item.code;
                txtItemName.Text = item.name;
            }
        }

        private void HandleClientSelected(Client selectedClient)
        {
            SelectClientWorkOrder(selectedClient);
        }

        public void SelectClientWorkOrder(Client selectedClient)
        {
            if (selectedClient != null)
            {
                this.client = selectedClient;
                txtClientId.Text = selectedClient.Id.ToString();
                txtClientName.Text = selectedClient.FullName;
                txtCellphone.Text = selectedClient.MainPhoneNum == null ? "No asignado" : selectedClient.MainPhoneNum.ToString();
                txtCellphone2.Text = selectedClient.AdditionalPhoneNum == null ? "No asignado" : selectedClient.AdditionalPhoneNum.ToString();
                txtEmail.Text = selectedClient.Email == null ? "No asignado" : selectedClient.Email;
                txtLicensePlate.Text = "";
                txtMake.Text = "";
                txtModel.Text = "";
                txtMileage.Text = "";
            }

            if (client.Id is null)
            {
                return;
            }
            if (workOrderId.HasValue)
            {
                WorkOrder existingWorkOrder = new WorkOrder();
                existingWorkOrder.Id = (int)workOrderId;
                existingWorkOrder.Branch = cbBranch.SelectedItem as Branch;
                existingWorkOrder.Date = dateTimePicker.Value;
                existingWorkOrder.State = (short)cbState.SelectedIndex;
                existingWorkOrder.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                existingWorkOrder.Client = client;
                workOrderController.UpsertWorkOrder(existingWorkOrder);
            }
            else
            {
                WorkOrder workOrder = new WorkOrder();
                workOrder.Id = 0;
                workOrder.Branch = cbBranch.SelectedItem as Branch;
                workOrder.Date = dateTimePicker.Value;
                workOrder.State = (short)cbState.SelectedValue;
                workOrder.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                workOrder.Client = client;

                this.workOrderId = workOrderController.UpsertWorkOrder(workOrder);
                loadWorkOrderLines(workOrderId.Value);
                dgvWorkOrderDetails.Refresh();
            }
        }

        private void btnSelectClient_Click(object sender, EventArgs e)
        {
            frmClients frmClients = new frmClients(this);
            frmClients.ClientSelected += HandleClientSelected;
            frmClients.MdiParent = this.MdiParent;
            frmClients.Show();

        }

        private void HandleVehicleSelected(Vehicle vehicle)
        {
            SelectVehicleWorkOrder(vehicle);
        }


        public void SelectVehicleWorkOrder(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                txtLicensePlate.Text = vehicle.LicensePlate.ToString();
                txtMake.Text = vehicle.Model.Make.Name.ToString();
                txtModel.Text = vehicle.Model.ToString() + " " + vehicle.Year;
                txtMileage.Text = vehicle.Mileage.ToString();
            }

            if (client != null)
            {
                WorkOrder existingWorkOrder = new WorkOrder();
                existingWorkOrder.Id = (int)workOrderId;
                existingWorkOrder.Branch = cbBranch.SelectedItem as Branch;
                existingWorkOrder.Date = dateTimePicker.Value;
                existingWorkOrder.State = (short)cbState.SelectedIndex;
                existingWorkOrder.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                existingWorkOrder.Client = client;
                existingWorkOrder.Vehicle = vehicle;
                workOrderController.UpsertWorkOrder(existingWorkOrder);
            }
            else
            {
                WorkOrder workOrder = new WorkOrder();
                workOrder.Id = 0;
                workOrder.Branch = cbBranch.SelectedItem as Branch;
                workOrder.Date = dateTimePicker.Value;
                workOrder.State = (short)cbState.SelectedValue;
                workOrder.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                workOrder.Client = client;
                workOrder.Vehicle = vehicle;

                this.workOrderId = workOrderController.UpsertWorkOrder(workOrder);
                loadWorkOrderLines(workOrderId.Value);
                dgvWorkOrderDetails.Refresh();
            }
        }
        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            if(client == null)
            {
                MessageBox.Show("Por favor seleccione un cliente primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmVehicles frmVehicles = new frmVehicles(this,this.client.Id);
            frmVehicles.VehicleSelected += HandleVehicleSelected;
            frmVehicles.MdiParent = this.MdiParent;
            frmVehicles.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (this.workOrderId.HasValue && this.client != null)
            {
                WorkOrder workOrder = new Work_Order_Controller().LoadWorkOrder(workOrderId.Value);
                workOrder.Branch = cbBranch.SelectedItem as Branch;
                workOrder.Date = dateTimePicker.Value;
                workOrder.State = (short)cbState.SelectedIndex;
                workOrder.Amount = Convert.ToDecimal(txtTotalAmount.Text);

                if(this.vehicle != null && txtCurrentMileage.Text != "")
                {

                    workOrder.CurrentMileage = Convert.ToInt32(txtCurrentMileage.Text);
                    this.vehicle.Mileage = Convert.ToInt32(txtCurrentMileage.Text);
                    new Vehicle_Controller().upsert(this.vehicle);
                }

                string errorMessage = AdjustInventory((short)cbState.SelectedIndex, this.previousSelectedStateValue);
                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbState.SelectedIndex = this.previousSelectedStateValue;
                    return;
                }

                if (new Work_Order_Controller().UpdateWorkOrder(workOrder))
                {
                    OnDataChanged(EventArgs.Empty);
                    this.Dispose();
                    MessageBox.Show("Cambios guardados exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un cliente primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string AdjustInventory(short currentState, int previousState)
        {
            double lineQuantity;
            double currentStock;
            double newQuantity;

            if (previousState == 0 && (currentState == 2 || currentState == 3))
            {
                foreach (DataGridViewRow row in dgvWorkOrderDetails.Rows)
                {
                    if (!new Item_Controller().IsItemService(row.Cells["ItemCode"].Value.ToString()))
                    {
                        lineQuantity = Convert.ToDouble(row.Cells["Quantity"].Value);
                        if (!validateItemStock(row.Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue, lineQuantity))
                        {
                            return "No hay suficientes artículos de: " + row.Cells["item"].Value + " - Código: " + row.Cells["ItemCode"].Value + " disponibles en la sucursal." +
                                "\nCantidad disponible en inventario: " + new Item_Controller().getItemStock(row.Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue) + "." +
                                "\nNo se puede la orden a estado " + cbState.Text.ToString() + ".";
                        }
                    }
                }

                foreach (DataGridViewRow row in dgvWorkOrderDetails.Rows)
                {
                    if (!new Item_Controller().IsItemService(row.Cells["ItemCode"].Value.ToString()))
                    {
                        lineQuantity = Convert.ToDouble(row.Cells["Quantity"].Value);
                        currentStock = new Item_Controller().getItemStock(row.Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue);
                        newQuantity = currentStock - lineQuantity;

                        // Actualizar la cantidad en la base de datos
                        if (!new Item_Controller().updateQuantity(row.Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue, newQuantity))
                        {
                            return "No se pudo actualizar la cantidad del artículo: " + row.Cells["item"].Value + " - Código: " + row.Cells["ItemCode"].Value;
                        }
                    }
                }
                return "";
            }
            else if (previousState == 1 && (currentState == 3 || currentState == 2))
            {
                foreach (DataGridViewRow row in dgvWorkOrderDetails.Rows)
                {
                    if (!new Item_Controller().IsItemService(row.Cells["ItemCode"].Value.ToString()))
                    {
                        lineQuantity = Convert.ToDouble(row.Cells["Quantity"].Value);
                        if (!validateItemStock(row.Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue, lineQuantity))
                        {
                            return "No hay suficientes artículos de: " + row.Cells["item"].Value + " - Código: " + row.Cells["ItemCode"].Value + " disponibles en la sucursal." +
                                "\nCantidad disponible: " + new Item_Controller().getItemStock(row.Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue) + "." +
                                "\nNo se puede la orden a estado " + cbState.Text.ToString() + ".";
                        }
                    }
                }

                foreach (DataGridViewRow row in dgvWorkOrderDetails.Rows)
                {
                    if (!new Item_Controller().IsItemService(row.Cells["ItemCode"].Value.ToString()))
                    {
                        lineQuantity = Convert.ToDouble(row.Cells["Quantity"].Value);
                        currentStock = new Item_Controller().getItemStock(row.Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue);
                        newQuantity = currentStock - lineQuantity;

                        // Actualizar la cantidad en la base de datos
                        if (!new Item_Controller().updateQuantity(row.Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue, newQuantity))
                        {
                            return "No se pudo actualizar la cantidad del artículo: " + row.Cells["item"].Value + " - Código: " + row.Cells["ItemCode"].Value;
                        }
                    }
                }
                return "";
            }
            else if (previousState == 2 && (currentState == 0 || currentState == 1))
            {

                foreach (DataGridViewRow row in dgvWorkOrderDetails.Rows)
                {
                    if (!new Item_Controller().IsItemService(row.Cells["ItemCode"].Value.ToString()))
                    {
                        lineQuantity = Convert.ToDouble(row.Cells["Quantity"].Value);
                        currentStock = new Item_Controller().getItemStock(row.Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue);
                        newQuantity = currentStock + lineQuantity;

                        // Actualizar la cantidad en la base de datos
                        if (!new Item_Controller().updateQuantity(row.Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue, newQuantity))
                        {
                            return "No se pudo actualizar la cantidad del artículo: " + row.Cells["item"].Value + " - Código: " + row.Cells["ItemCode"].Value;
                        }
                    }
                }
                return "";
            }
            else if ((previousState == 0 && currentState == 1) || previousState == 1 && currentState == 0)
            {
                return "";
            }
            return "";
        }

        private void btnSelectItem_Click(object sender, EventArgs e)
        {
            frmItems frmItems = new frmItems(this);
            frmItems.ItemSelected += HandleItemSelected;
            frmItems.MdiParent = this.MdiParent;
            frmItems.Show();
        }

        private void btnAddWorkOrderLine_Click(object sender, EventArgs e)
        {
            try
            {
                bool hasValidValues = txtItemCode.Text.ToString() != "" &&
                                          txtItemName.Text.ToString() != "" &&
                                          txtQuantity.Text.ToString() != "" &&
                                          txtLineAmount.Text.ToString() != "";

                if (hasValidValues)
                {
                    if(workOrderId.HasValue)
                    {
                        WorkOrderLine workOrderLine = new WorkOrderLine();
                        workOrderLine.WorkOrderId = (int)workOrderId.Value;
                        workOrderLine.item = new Item_Controller().get(txtItemCode.Text.ToString());
                        decimal quantity = Convert.ToDecimal(txtQuantity.Text);
                        workOrderLine.Quantity = quantity;
                        decimal amount = Convert.ToDecimal(txtLineAmount.Text);
                        workOrderLine.Amount = amount;

                        WorkOrder workOrder = new Work_Order_Controller().LoadWorkOrder(workOrderId.Value);

                        if (workOrder.State == 2)
                        {
                            double newQuantity;
                            if (!new Item_Controller().IsItemService(txtItemCode.Text.ToString()))
                            {
                                //!validateItemStock(detailLine.Item.code, frmLogin.branch, Convert.ToDouble(detailLine.Quantity))
                                if (!validateItemStock(txtItemCode.Text.ToString(), (int)cbBranch.SelectedValue, (double)workOrderLine.Quantity))
                                {
                                    MessageBox.Show("No hay suficientes artículos de: " + workOrderLine.item + " - Código: " + workOrderLine.item.code + " disponibles en la sucursal");
                                    return;
                                }


                                double lineQuantity = Convert.ToDouble(workOrderLine.Quantity);
                                double currentStock = new Item_Controller().getItemStock(txtItemCode.Text.ToString(), (int)cbBranch.SelectedValue);
                                newQuantity = currentStock - lineQuantity;

                                // Actualizar la cantidad en la base de datos
                                if (!new Item_Controller().updateQuantity(txtItemCode.Text.ToString(), (int)cbBranch.SelectedValue, newQuantity))
                                {
                                    MessageBox.Show("No se pudo actualizar la cantidad del artículo: " + txtItemName.Text.ToString() + " - Código: " + txtItemCode.Text.ToString());
                                    return;
                                }
                            }

                            if (new WorkOrderLine_Model().UpsertWorkOrderLine(workOrderLine))
                            {

                                txtItemCode.Text = "";
                                txtItemName.Text = "";
                                txtQuantity.Text = "";
                                txtLineAmount.Text = "";
                                loadWorkOrderLines(workOrderId.Value);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo agregar la línea a la orden de trabajo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if(workOrder.State == 0 || workOrder.State == 1)
                        {
                            if (new WorkOrderLine_Model().UpsertWorkOrderLine(workOrderLine))
                            {

                                txtItemCode.Text = "";
                                txtItemName.Text = "";
                                txtQuantity.Text = "";
                                txtLineAmount.Text = "";
                                loadWorkOrderLines(workOrderId.Value);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo agregar la línea a la orden de trabajo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione un cliente primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Por favor llene todos los campos de la línea.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateTotalAmount();
            }
        }

        private bool ValidateWorkOrderLine()
        {
            if (txtItemCode.Text == "")
            {
                MessageBox.Show("Por favor seleccione un artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Text = "";
                return false;
            }
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Por favor ingrese una cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            double quantity;
            double sellingPrice;

            bool isQuantityValid = double.TryParse(txtQuantity.Text.Trim(), out quantity);

            if (!string.IsNullOrEmpty(txtQuantity.Text.Trim()) &&
                !string.IsNullOrEmpty(txtItemName.Text.Trim()) &&
                isQuantityValid)
            {
                sellingPrice = new PriceList_Controller().getPriceByItem(txtItemCode.Text.ToString(), client.PriceList.id);
                double calc = quantity * sellingPrice;

                txtLineAmount.Text = calc.ToString();
            }
            else
            {
                txtLineAmount.Text = "";
            }
        }

        private void txtItemCode_Leave(object sender, EventArgs e)
        {
            if (txtItemCode.Text != "")
            {
                Item item = new Item_Controller().get(txtItemCode.Text.ToString());
                if (item != null)
                {
                    txtItemName.Text = item.name;
                }
                else
                {
                    MessageBox.Show("El artículo no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtItemCode.Text = "";
                    txtItemName.Text = "";
                }
            }
        }

        private void tbNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && textBox.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void load_Observation()
        {
            observations = new Observation_Controller().GetObservation(workOrderTemplate.Id);
            dgvObservation.DataSource = observations;

            dgvObservation.Columns["Code"].HeaderText = "Codigo";
            dgvObservation.Columns["Description"].HeaderText = "Descripcion";
            dgvObservation.Columns["WorkOrderId"].Visible = false;

            SetColumnOrderObservation();
        }
        private void SetColumnOrderObservation()
        {
            dgvObservation.Columns["Code"].DisplayIndex = 0;
            dgvObservation.Columns["Description"].DisplayIndex = 1;
        }

        private void FrmInsertObservation_ObservationChanged(object sender, EventArgs e)
        {
            load_Observation();
        }

        private void dgvObservation_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string observationCode = dgvObservation.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                List<Observation> observations = new Observation_Controller().GetObservation(workOrderTemplate.Id);
                Observation selectedObservation = observations.FirstOrDefault(observation => observation.Code.ToString() == observationCode);

                if (selectedObservation != null)
                {
                    frmInsertUpsert_Observation frmInsertObservation = new frmInsertUpsert_Observation(selectedObservation);
                    frmInsertObservation.ObservationChanged += FrmInsertObservation_ObservationChanged;
                    frmInsertObservation.MdiParent = this.MdiParent;
                    frmInsertObservation.Show();
                    load_Observation();
                }
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (client != null)
            {
                string mode = "";
                Observation newObservation = new Observation();
                newObservation.Description = "";
                newObservation.WorkOrderId = workOrderTemplate.Id;
                frmInsertUpsert_Observation frmInsertUpsertObservation = new frmInsertUpsert_Observation(newObservation, mode);
                frmInsertUpsertObservation.ObservationChanged += FrmInsertObservation_ObservationChanged;
                frmInsertUpsertObservation.MdiParent = this.MdiParent;
                frmInsertUpsertObservation.Show();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un cliente primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvWorkOrderDetails_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            WorkOrder workOrder = new Work_Order_Controller().LoadWorkOrder(this.workOrderId.Value);

            if (e.RowIndex >= 0)
            {
                if (new Item_Controller().IsItemService(dgvWorkOrderDetails.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString()))
                {
                    DialogResult result = MessageBox.Show("¿Desea eliminar la linea de detalle?", "Confirmar selección", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (new WorkOrderLine_Model().DeleteWorkOrderLine(Convert.ToInt32(dgvWorkOrderDetails.Rows[e.RowIndex].Cells["Id"].Value)))
                        {
                            loadWorkOrderLines(workOrderId.Value);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la línea de detalle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (e.ColumnIndex == dgvWorkOrderDetails.Columns["deleteImageColumn"].Index && workOrder.State == 2)
                {
                    DialogResult result = MessageBox.Show("La orden se encuentra en proceso. Si elimina esta línea se restablecerán " + dgvWorkOrderDetails.Rows[e.RowIndex].Cells["Quantity"].Value.ToString() +
                        " unidades de " + dgvWorkOrderDetails.Rows[e.RowIndex].Cells["item"].Value.ToString() + " al inventario. \n¿Desea eliminar esta línea de detalle?", "Confirmar selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        double lineQuantity = Convert.ToDouble(dgvWorkOrderDetails.Rows[e.RowIndex].Cells["Quantity"].Value);
                        double currentStock = new Item_Controller().getItemStock(dgvWorkOrderDetails.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue);
                        double newQuantity = currentStock + lineQuantity;

                        // Actualizar la cantidad en la base de datos
                        if (!new Item_Controller().updateQuantity(dgvWorkOrderDetails.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString(), (int)cbBranch.SelectedValue, newQuantity))
                        {
                            MessageBox.Show("No se pudo actualizar la cantidad del artículo: " + txtItemName.Text.ToString() + " - Código: " + txtItemCode.Text.ToString());
                            return;
                        }
                        if (new WorkOrderLine_Model().DeleteWorkOrderLine(Convert.ToInt32(dgvWorkOrderDetails.Rows[e.RowIndex].Cells["Id"].Value)))
                        {
                            loadWorkOrderLines(workOrderId.Value);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la línea de detalle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (e.ColumnIndex == dgvWorkOrderDetails.Columns["deleteImageColumn"].Index && workOrder.State != 2)
                {
                    DialogResult result = MessageBox.Show("Eliminar esta línea no actualizará ninguna entrada o salida de inventario ya que la orden no se encuentra en proceso." +
                        "\n¿Desea eliminar esta línea de detalle?", "Confirmar selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (new WorkOrderLine_Model().DeleteWorkOrderLine(Convert.ToInt32(dgvWorkOrderDetails.Rows[e.RowIndex].Cells["Id"].Value)))
                        {
                            loadWorkOrderLines(workOrderId.Value);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la línea de detalle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog savefile = new SaveFileDialog();
        //    savefile.Filter = "Archivos de Pdf|*.pdf";
        //    savefile.FileName = string.Format(DateTime.Now.ToString("ddMMyyyyHHmmss"));

        //    string PaginaHTML_Texto = Properties.Resources.Template.ToString();
        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@BRANCH", workOrderTemplate.Branch.Name);
        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DATE", workOrderTemplate.Date.ToString());

        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ID", client.Id);
        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NAME", client.FullName);
        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MAINPHONE", client.MainPhoneNum.ToString());
        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ADDITIONALPHONE", client.AdditionalPhoneNum.ToString());
        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EMAIL", client.Email);

        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@LICENSEPLATE", vehicle.LicensePlate);
        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MAKE", workOrderTemplate.Vehicle.Model.Make.ToString());
        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MODEL", vehicle.Model + " " + vehicle.Year);
        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MILEAGE", vehicle.Mileage.ToString());
        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CURRENTMILEAGE", workOrderTemplate.CurrentMileage.ToString());

        //    string htmlTable = "<table border='1'><tr>";

        //    // Agrega las cabeceras de las columnas
        //    foreach (DataGridViewColumn column in dataGridView1.Columns)
        //    {
        //        htmlTable += "<th>" + column.HeaderText + "</th>";
        //    }
        //    htmlTable += "</tr>";

        //    // Agrega las filas y celdas de datos
        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        htmlTable += "<tr>";
        //        foreach (DataGridViewCell cell in row.Cells)
        //        {
        //            htmlTable += "<td>" + cell.Value?.ToString() + "</td>"; // Agrega el valor de la celda como contenido de <td>
        //        }
        //        htmlTable += "</tr>";
        //    }

        //    // Cierra la tabla HTML
        //    htmlTable += "</table>";

        //    // Reemplaza @TABLA_PRODUCTOS en PaginaHTML_Texto con la tabla HTML generada
        //    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TABLA_PRODUCTOS", htmlTable);




        //string imagenesHTML = string.Empty;

        //foreach (var photo in observationPhotos2)
        //{
        //    string base64Image = Convert.ToBase64String(photo.Photo);
        //    imagenesHTML += $"<img src=\"data:image/png;base64,{base64Image}\" alt=\"Observation Photo\" />";
        //}

        //// Ahora reemplazamos @IMAGENES en PaginaHTML_Texto con imagenesHTML
        //PaginaHTML_Texto = PaginaHTML_Texto.Replace("@IMAGENES", imagenesHTML);

        //< img src = "data:image/png;base64,@image" alt = "Observation Photo" />



        //    if (savefile.ShowDialog() == DialogResult.OK)
        //    {
        //        using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
        //        {
        //            //Creamos un nuevo documento y lo definimos como PDF
        //            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

        //            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
        //            pdfDoc.Open();
        //            pdfDoc.Add(new Phrase(""));

        //            //pdfDoc.Add(new Phrase("Hola Mundo"));
        //            using (StringReader sr = new StringReader(PaginaHTML_Texto))
        //            {
        //                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //            }

        //            pdfDoc.Close();
        //            stream.Close();
        //        }


        //    }
        //}
    }
}