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
using System.Net.Mail;
using System.Net;

namespace LubriTech.View
{
    public partial class frmWorkOrder : Form
    {
        int imageId;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private int? workOrderId; // Nullable int to store the work order ID
        Work_Order_Controller workOrderController = new Work_Order_Controller();
        Client client = new Client();
        Vehicle vehicle = new Vehicle();
        WorkOrder workOrderTemplate = new WorkOrder();
        List<Observation> observations;
        decimal totalA;

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

            txtCurrentMileage.Text = "";

            dgvWorkOrderDetails.DataSource = new List<WorkOrderLine>();
            dgvWorkOrderDetails.Columns["Id"].Visible = false;
            dgvWorkOrderDetails.Columns["WorkOrderId"].Visible = false;
            dgvWorkOrderDetails.Columns["item"].Visible = false;
            dgvWorkOrderDetails.Columns["ItemName"].HeaderText = "Descripción";
            dgvWorkOrderDetails.Columns["Quantity"].HeaderText = "Cantidad";
            dgvWorkOrderDetails.Columns["UnitPrice"].HeaderText = "Precio Unitario";
            dgvWorkOrderDetails.Columns["Amount"].HeaderText = "Monto";

            SetColumnOrder();
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
            dgvWorkOrderDetails.Columns["ItemName"].HeaderText = "Descripción";
            dgvWorkOrderDetails.Columns["UnitPrice"].HeaderText = "Precio Unitario";
            dgvWorkOrderDetails.Columns["Quantity"].HeaderText = "Cantidad";
            dgvWorkOrderDetails.Columns["Amount"].HeaderText = "Monto";

            SetColumnOrder();
        }

        private void SetColumnOrder()
        {
            dgvWorkOrderDetails.Columns["Id"].DisplayIndex = 0;
            dgvWorkOrderDetails.Columns["WorkOrderId"].DisplayIndex = 1;
            dgvWorkOrderDetails.Columns["item"].DisplayIndex = 2;
            dgvWorkOrderDetails.Columns["ItemName"].DisplayIndex = 3;
            dgvWorkOrderDetails.Columns["UnitPrice"].DisplayIndex = 4;
            dgvWorkOrderDetails.Columns["Quantity"].DisplayIndex = 5;
            dgvWorkOrderDetails.Columns["Amount"].DisplayIndex = 6;
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

            totalA = totalAmount;
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
            if (!dgvObservation.Columns.Contains("btnDelete"))
            {
                // Agregar columna de botón de eliminar
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.HeaderText = "Eliminar";
                btnDelete.Name = "btnDelete";
                btnDelete.Text = "Eliminar";
                btnDelete.UseColumnTextForButtonValue = true;

                dgvObservation.Columns.Add(btnDelete);
            }
            dgvObservation.Columns["Code"].DisplayIndex = 0;
            dgvObservation.Columns["Description"].DisplayIndex = 1;
            dgvObservation.Columns["btnDelete"].DisplayIndex = 2;
        }

        private void FrmInsertObservation_ObservationChanged(object sender, EventArgs e)
        {
            load_Observation();
        }

        private void dgvObservation_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvObservation.Columns["btnDelete"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID de la observación a eliminar
                var observationId = (int)dgvObservation.Rows[e.RowIndex].Cells["Code"].Value;

                // Lógica para eliminar la observación
                if (new Observation_Controller().Delete(observationId))
                {
                    MessageBox.Show("Observación eliminada correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al eliminar la observación.");
                }

                // Recargar las observaciones
                load_Observation();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex != dgvObservation.Columns["btnDelete"].Index)
            {
                // Obtener el código de la observación seleccionada
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
            string mode = "";
            Observation newObservation = new Observation();
            newObservation.Description = "";
            newObservation.WorkOrderId = workOrderTemplate.Id;
            frmInsertUpsert_Observation frmInsertUpsertObservation = new frmInsertUpsert_Observation(newObservation, mode);
            frmInsertUpsertObservation.ObservationChanged += FrmInsertObservation_ObservationChanged;
            frmInsertUpsertObservation.MdiParent = this.MdiParent;
            frmInsertUpsertObservation.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Archivos de Pdf|*.pdf";
            savefile.FileName = string.Format(DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.Template.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@BRANCH", workOrderTemplate?.Branch?.Name ?? "N/A");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DATE", workOrderTemplate?.Date.ToString() ?? "N/A");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@STATE", cbState.Text ?? "N/A");

            if (client != null)
            {
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ID", client.Id);
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NAME", client.FullName);
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MAINPHONE", client.MainPhoneNum?.ToString() ?? "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ADDITIONALPHONE", client.AdditionalPhoneNum?.ToString() ?? "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EMAIL", client.Email ?? "N/A");
            }
            else
            {
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ID", "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NAME", "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MAINPHONE", "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ADDITIONALPHONE", "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EMAIL", "N/A");
            }

            if (vehicle != null)
            {
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@LICENSEPLATE", vehicle.LicensePlate ?? "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MAKE", workOrderTemplate?.Vehicle?.Model?.Make?.ToString() ?? "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MODEL", vehicle.Model + " " + vehicle.Year ?? "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MILEAGE", vehicle.Mileage.ToString() ?? "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CURRENTMILEAGE", workOrderTemplate?.CurrentMileage.ToString() ?? "N/A");
            }
            else
            {
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@LICENSEPLATE", "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MAKE", "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MODEL", "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MILEAGE", "N/A");
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CURRENTMILEAGE", "N/A");
            }

            if (dgvWorkOrderDetails.Columns.Count > 0)
            {
                DataGridView dgvWorkOrderLine;
                dgvWorkOrderLine = dgvWorkOrderDetails;
                dgvWorkOrderLine.Columns["ItemName"].HeaderText = "Articulo";
                dgvWorkOrderLine.Columns["Quantity"].HeaderText = "Cantidad";
                dgvWorkOrderLine.Columns["UnitPrice"].HeaderText = "Precio Unitario";
                dgvWorkOrderLine.Columns["Amount"].HeaderText = "Monto";

                dgvWorkOrderLine.Columns.Remove("Id");
                dgvWorkOrderLine.Columns.Remove("WorkOrderId");
                dgvWorkOrderLine.Columns.Remove("Item");
            }

            string htmlTable = "<table class='work-order-table' style='border-collapse: collapse; width: 100%;'>";

            htmlTable += "<tr>";
            foreach (DataGridViewColumn column in dgvWorkOrderDetails.Columns)
            {
                htmlTable += "<th>" + column.HeaderText + "</th>";
            }
            htmlTable += "</tr>";

            foreach (DataGridViewRow row in dgvWorkOrderDetails.Rows)
            {
                htmlTable += "<tr>";
                foreach (DataGridViewCell cell in row.Cells)
                {
                    htmlTable += "<td>" + (cell.Value?.ToString() ?? "N/A") + "</td>";
                }
                htmlTable += "</tr>";
            }

            htmlTable += "<tr>";
            htmlTable += "<td colspan='" + (dgvWorkOrderDetails.Columns.Count - 1) + "' style='text-align: right; font-weight: bold;'>MontoTotal:</td>";
            htmlTable += "<td>" + totalA.ToString() + "</td>";
            htmlTable += "</tr>";

            htmlTable += "</table>";

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@WORKORDERLINE", htmlTable);

            string observacionesHTML = "<ul class='observations-list'>";
            foreach (var observation in workOrderTemplate.Observations ?? Enumerable.Empty<Observation>())
            {
                observacionesHTML += $"<li>{observation.Description ?? "N/A"}";

                // Obtener las imágenes asociadas a la observación desde el controlador
                var observationPhotos = new ObservationPhotos_Controller().GetAll(observation.Code);

                if (observationPhotos != null && observationPhotos.Any())
                {
                    observacionesHTML += "<br/><div class='observation-images'>";

                    foreach (var photo in observationPhotos)
                    {
                        if (photo.Photo != null && photo.Photo.Length > 0)
                        {
                            string base64Image = Convert.ToBase64String(photo.Photo);
                            observacionesHTML += $"<img src=\"data:image/png;base64,{base64Image}\" alt=\"Observation Photo\" style=\"width:200px;height:150px;\" />";
                        }
                    }

                    observacionesHTML += "</div>";
                }

                observacionesHTML += "</li>";
            }
            observacionesHTML += "</ul>";

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@OBSERVATIONS", observacionesHTML);

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

                if (!string.IsNullOrEmpty(client?.Email))
                {
                    SendEmail(client.Email, filePath);
                }
                else
                {
                    MessageBox.Show("El cliente no tiene una dirección de correo electrónico válida.");
                }
            }
        }



        private void SendEmail(string email, string pdfFilePath)
        {
            try
            {
                MailAddress addressFrom = new MailAddress("soportelubritech@gmail.com", "LubriTech");
                MailAddress addressTo = new MailAddress(email);
                MailMessage message = new MailMessage(addressFrom, addressTo);

                message.Subject = "Orden de Trabajo";
                message.Body = "Estimado cliente,\n\nAdjunto encontrará la Orden de Trabajo en formato PDF.\n\nAtentamente,\nLubricentro Santa Teresita";


                Attachment pdfAttachment = new Attachment(pdfFilePath);
                message.Attachments.Add(pdfAttachment);

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("soportelubritech@gmail.com", "puux hwyd enia dmrr")
                };

                smtpClient.Send(message);

                pdfAttachment.Dispose();
                message.Dispose();

                MessageBox.Show("Correo enviado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}