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
using System.Net;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_Vehicle : Form
    {

        private List<Client> clients;
        private List<CarModel> models;
        private List<Make> makes;

        public frmInsertUpdate_Vehicle()
        {
            clients = new List<Client>();
            makes = new Make_Controller().getAll();
            models = new CarModel_Controller().getAll();
            InitializeComponent();
            setComboBoxMake();
            load_Clients(null);
            SetupClientsDGV();
        }

        public frmInsertUpdate_Vehicle(Vehicle vehicle, string action)
        {
            clients = new List<Client>();
            makes = new Make_Controller().getAll();
            models = new CarModel_Controller().getAll();
            InitializeComponent();
            setComboBoxMake();

            tbClientName.Text = vehicle.Client.FullName;
            tbClientId.Text = vehicle.Client.Id;
            cbMake.Text = vehicle.Model.Make.Name;
            cbModel.Text = vehicle.Model.Name;
            tbLicensePlate.Text = vehicle.LicensePlate;
            tbYear.Text = vehicle.Year.ToString();
            tbMileage.Text = vehicle.Mileage.ToString();
            tbEngine.Text = vehicle.Engine;
            cbTransmission.Text = vehicle.Transmission;

            SetupClientsDGV();

            if (action == "Details")
            {
                tbLicensePlate.Enabled = false;
                tbEngine.Enabled = false;
                tbClientName.Enabled = false;
                tbMileage.Enabled = false;
                tbYear.Enabled = false;
                cbMake.Enabled = false;
                cbModel.Enabled = false;
                cbTransmission.Enabled = false;
                dgvClients.Enabled = false;

                tbLicensePlate.BackColor = Color.FromArgb(249, 252, 255);
                tbEngine.BackColor = Color.FromArgb(249, 252, 255);
                tbClientName.BackColor = Color.FromArgb(249, 252, 255);
                tbMileage.BackColor = Color.FromArgb(249, 252, 255);
                tbYear.BackColor = Color.FromArgb(249, 252, 255);
                cbMake.BackColor = Color.FromArgb(249, 252, 255);
                cbModel.BackColor = Color.FromArgb(249, 252, 255);
                cbTransmission.BackColor = Color.FromArgb(249, 252, 255);

                btnConfirm.Hide();
            }
        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbClientName.Text.Trim() == ""
                || cbMake.Text.Trim() == ""
                || cbModel.Text.Trim() == ""
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
                vehicle.Model = vehicleController.getModel(Convert.ToInt32(cbModel.SelectedValue.ToString()));
                vehicle.Model.Make = vehicleController.getMake(Convert.ToInt32(cbMake.SelectedValue.ToString()));
                vehicle.LicensePlate = tbLicensePlate.Text.Trim();
                vehicle.Year = Convert.ToInt32(tbYear.Text.Trim());
                vehicle.Mileage = Convert.ToInt32(tbMileage.Text.Trim());
                vehicle.Engine = tbEngine.Text.Trim();
                vehicle.Transmission = cbTransmission.Text.Trim();
                vehicle.State = "Activo";

                if (vehicleController.upsert(vehicle))
                {
                    OnDataChanged(EventArgs.Empty);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Vehículo no insertado");
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
                    dgvClients.Columns["State"].HeaderText = "Estado";
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
                    dgvClients.Columns["State"].HeaderText = "Estado";
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

        private void tbNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvClients.Columns["selectButtonColumn"].Index && e.RowIndex >= 0)
            {
                string selectedId = dgvClients.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                List<Client> clients = new Clients_Controller().getAll();
                Client selectedClient = null;
                foreach (Client client in clients)
                {
                    if (client.Id == selectedId)
                    {
                        selectedClient = client;
                        break;
                    }
                }
                tbClientId.Text = selectedClient.Id;
                tbClientName.Text = selectedClient.FullName;
                MessageBox.Show("Cliente seleccionado correctamente");
            }
        }

        private List<CarModel> getMakeIdByName(string name)
        {
            List<CarModel> makeModels = new List<CarModel>();
            foreach (var model in models)
            {
                if (model.Make.Name == name)
                {
                    makeModels.Add(model);
                }
            }
            return makeModels;
        }

        // Método para configurar los ComboBoxes inicialmente
        private void setComboBoxMake()
        {
            cbMake.DataSource = makes;
            cbMake.ValueMember = "Id";
            cbMake.DisplayMember = "Name";
            cbMake.SelectedIndex = -1;

            cbModel.DataSource = null;  // Inicialmente sin datos
            cbModel.ValueMember = "Id";
            cbModel.DisplayMember = "Name";
            cbModel.SelectedIndex = -1;
            cbModel.Enabled = false;  // Inicialmente deshabilitado

            // Conectar el evento
            cbMake.SelectedValueChanged += cbMake_SelectedValueChanged;
        }

        // Método que se llama cuando cambia el valor seleccionado en cbMake
        private void cbMake_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbMake.SelectedIndex == -1)
            {
                cbModel.Enabled = false;
                cbModel.DataSource = null;  // Limpiar el DataSource
            }
            else
            {
                cbModel.Enabled = true;

                // Obtener el nombre de la marca seleccionada
                string selectedMakeName = cbMake.Text;

                // Obtener modelos basados en la marca seleccionada
                cbModel.DataSource = getMakeIdByName(selectedMakeName);

                cbModel.ValueMember = "Id";
                cbModel.DisplayMember = "Name";
                cbModel.SelectedIndex = -1; // No seleccionar ningún elemento por defecto

                cbModel.Refresh(); // Refrescar el ComboBox para asegurarse de que se actualice visualmente
            }
        }
    }
}
