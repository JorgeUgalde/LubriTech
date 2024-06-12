using LubriTech.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using LubriTech.Model.Vehicle_Information;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Supplier_Information;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_Vehicle : Form
    {

        List<Client> clients;

        public frmInsertUpdate_Vehicle()
        {
            clients = new List<Client>();
            InitializeComponent();
            load_Clients(null);
            SetupClientsDGV();
        }

        public frmInsertUpdate_Vehicle(Vehicle vehicle)
        {
            clients = new List<Client>();
            InitializeComponent();
            load_Clients(null);
            SetupClientsDGV();
            tbClientName.Text = vehicle.Client.FullName;
            tbClientId.Text = vehicle.Client.Id;
            tbBrand.Text = vehicle.Brand;
            tbModel.Text = vehicle.Model;
            tbLicensePlate.Text = vehicle.LicensePlate;
            tbYear.Text = vehicle.Year.ToString();
            tbMileage.Text = vehicle.Mileage.ToString();
            tbEngine.Text = vehicle.Engine;
            cbTransmission.Text = vehicle.Transmission;
        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbClientName.Text.Trim() == ""
                || tbBrand.Text.Trim() == ""
                || tbModel.Text.Trim() == ""
                || tbLicensePlate.Text.Trim() == ""
                || tbYear.Text.Trim() == ""
                || tbMileage.Text.Trim() == ""
                || tbEngine.Text.Trim() == ""
                || cbTransmission.Text.Trim() == "")
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
            else if(tbClientId.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un cliente");
            }
            else
            {
                Vehicle_Controller vehicleController = new Vehicle_Controller();
                Vehicle vehicle = new Vehicle();
                vehicle.Client = vehicleController.getClient(tbClientId.Text.Trim());
                vehicle.Brand = tbBrand.Text.Trim();
                vehicle.Model = tbModel.Text.Trim();
                vehicle.LicensePlate = tbLicensePlate.Text.Trim();
                vehicle.Year = Convert.ToInt32(tbYear.Text.Trim());
                vehicle.Mileage = Convert.ToInt32(tbMileage.Text.Trim());
                vehicle.Engine = tbEngine.Text.Trim();
                vehicle.Transmission = cbTransmission.Text.Trim();

                if (vehicleController.upsert(vehicle))
                {
                    OnDataChanged(EventArgs.Empty);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Product not inserted");
                }
            }
        }

        private void txtClientInfo_TextChanged(object sender, EventArgs e)
        {
            List<Client> clients = new Client_Model().loadAllClients();
            string clientName = tbClientName.Text.Trim();
            if (clientName != "")
            {
                var filteredClients = clients.Where(c => c.FullName.IndexOf(clientName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                load_Clients(filteredClients);
            }
            else
            {
                load_Clients(null);
            }
        }

        private void load_Clients(List<Client> filteredClients)
        {
            try
            {
                if (filteredClients != null)
                {
                    dgvClients.DataSource = filteredClients;
                    dgvClients.Columns["Id"].HeaderText = "Identificación";
                    dgvClients.Columns["FullName"].HeaderText = "Nombre";
                    dgvClients.Columns["MainPhoneNum"].Visible = false;
                    dgvClients.Columns["AdditionalPhoneNum"].Visible = false;
                    dgvClients.Columns["Email"].Visible = false;
                    dgvClients.Columns["Address"].Visible = false;
                }

                else
                {
                    clients = new Client_Model().loadAllClients();
                    dgvClients.DataSource = clients;
                    dgvClients.Columns["Id"].HeaderText = "Identificación";
                    dgvClients.Columns["FullName"].HeaderText = "Nombre";
                    dgvClients.Columns["MainPhoneNum"].Visible = false;
                    dgvClients.Columns["AdditionalPhoneNum"].Visible = false;
                    dgvClients.Columns["Email"].Visible = false;
                    dgvClients.Columns["Address"].Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void SetupClientsDGV()
        {
            DataGridViewButtonColumn selectButtonColumn = new DataGridViewButtonColumn();
            selectButtonColumn.Name = "selectButtonColumn";
            selectButtonColumn.HeaderText = "";
            selectButtonColumn.Text = "Seleccionar";
            selectButtonColumn.UseColumnTextForButtonValue = true;
            dgvClients.Columns.Add(selectButtonColumn);


        }

        private void dgvClients_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvClients.Columns["selectButtonColumn"].Index && e.RowIndex >= 0)
            {
                string idToSelect = dgvClients.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                foreach (Client client in clients)
                {
                    if (client.Id == idToSelect)
                    {
                        tbClientName.Text = client.FullName;
                        tbClientId.Text = client.Id;
                        MessageBox.Show(client.FullName + " seleccionado correctamente");
                        break;
                    }
                }
            }

        }

        private void dgvClients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dgvClients.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
