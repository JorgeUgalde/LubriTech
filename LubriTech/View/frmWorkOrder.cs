using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Item_Information;
using LubriTech.Model.items_Information;
using LubriTech.Model.Vehicle_Information;
using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LubriTech.View
{
    public partial class frmWorkOrder : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private int? workOrderId; // Nullable int to store the work order ID
        Work_Order_Controller workOrderController = new Work_Order_Controller();
        Client client = new Client();
        Vehicle vehicle = new Vehicle();
        public frmWorkOrder(int? workOrderId)
        {
            InitializeComponent();
            this.workOrderId = workOrderId;
            //InitializeTabControl();

            if (workOrderId.HasValue)
            {
                // Load the existing work order
                WorkOrder workOrder = workOrderController.LoadWorkOrder(workOrderId.Value);
                LoadWorkOrderData(workOrder);
                UpdateTotalAmount();
            }
            else
            {
                // Initialize a new work order
                InitializeNewWorkOrder();
            }
        }

        private void LoadWorkOrderData(WorkOrder workOrder)
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
            cbState.SelectedIndex = workOrder.State;
            
            cbBranch.DataSource = new Branch_Model().loadAllBranches();
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
            cbBranch.SelectedValue = workOrder.Branch.Id;

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
                txtCurrentMileage.Text = workOrder.CurrentMileage.ToString();
            }
            loadWorkOrderLines(workOrder.Id);
            UpdateTotalAmount();
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

            cbBranch.DataSource = new Branch_Model().loadAllBranches();
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
            cbBranch.SelectedIndex = 0;

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
        }

        private void frmWorkOrder_Load(object sender, EventArgs e)
        {

        }

        private void loadWorkOrderLines(int workOrderId)
        {
            dgvWorkOrderDetails.DataSource = new WorkOrderLine_Model().LoadWorkOrderLines(workOrderId, client.PriceList.id);
            dgvWorkOrderDetails.Columns["Id"].Visible = false;
            dgvWorkOrderDetails.Columns["WorkOrderId"].Visible = false;
            dgvWorkOrderDetails.Columns["item"].Visible = false;
            dgvWorkOrderDetails.Columns["ItemName"].Visible = false;

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
                if(new Work_Order_Controller().UpdateWorkOrder(workOrder))
                {
                    this.Dispose();
                    MessageBox.Show("Cambios guardados exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un cliente primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                bool hasValidValues = txtItemCode.ToString() != "" &&
                                          txtItemName.ToString() != "" &&
                                          txtQuantity.ToString() != "" &&
                                          txtLineAmount.ToString() != "";

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
                        if (new WorkOrderLine_Model().UpsertWorkOrderLine(workOrderLine))
                        {
                            txtItemCode.Text = "";
                            txtItemName.Text = "";
                            txtQuantity.Text = "";
                            txtLineAmount.Text = "";
                            loadWorkOrderLines(workOrderId.Value);
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

        private void txtQuantity_Enter(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "0")
            {
                txtQuantity.Text = "";
            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (ValidateWorkOrderLine() == true && client != null)
            {
                decimal quantity = Convert.ToDecimal(txtQuantity.Text);
                decimal unitPrice = new PriceList_Controller().getPriceByItem(txtItemCode.Text.ToString(), client.PriceList.id);
                txtQuantity.Text = quantity.ToString("N2");
                txtLineAmount.Text = (Convert.ToDecimal(txtQuantity.Text) * unitPrice).ToString();
            }
        }
    }
}