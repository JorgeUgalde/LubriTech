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
using System.Runtime.InteropServices;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_Vehicle : Form
    {

        private List<Client> clients;
        private List<CarModel> models;
        private List<Make> makes;
        private List<Engine> engines;
        private List<Transmission> transmissions;
        private Client selectedClient = null;

        public frmInsertUpdate_Vehicle()
        {
            clients = new List<Client>();
            makes = new Make_Controller().getAll();
            models = new CarModel_Controller().getAll();
            engines = new Engine_Controller().getAll();
            transmissions = new Transmission_Controller().getAll();
            InitializeComponent();
            setComboBoxMake();
            setComboBoxes();
            cbState.SelectedIndex = 0;
            tbClientName.Enabled = false;
        }

        public frmInsertUpdate_Vehicle(Client client)
        {
            makes = new Make_Controller().getAll();
            models = new CarModel_Controller().getAll();
            engines = new Engine_Controller().getAll();
            transmissions = new Transmission_Controller().getAll();
            InitializeComponent();
            setComboBoxMake();
            setComboBoxes();
            tbClientName.Text = client.FullName;
            tbClientId.Text = client.Id;
            cbState.SelectedIndex = 0;
            tbClientName.Enabled = false;
        }

        public frmInsertUpdate_Vehicle(Vehicle vehicle)
        {
            clients = new List<Client>();
            makes = new Make_Controller().getAll();
            models = new CarModel_Controller().getAll();
            engines = new Engine_Controller().getAll();
            transmissions = new Transmission_Controller().getAll();
            InitializeComponent();
            setComboBoxMake();
            setComboBoxes();

            tbLicensePlate.Enabled = false;
            tbClientName.Text = vehicle.Client.FullName;
            tbClientId.Text = vehicle.Client.Id;
            cbMake.Text = vehicle.Model.Make.Name;
            cbModel.Text = vehicle.Model.Name;
            tbLicensePlate.Text = vehicle.LicensePlate;
            tbYear.Text = vehicle.Year.ToString();
            tbMileage.Text = vehicle.Mileage.ToString();
            cbEngine.Text = vehicle.EngineType.EngineType;
            cbTransmission.Text = vehicle.TransmissionType.TransmissionType;
            tbClientName.Enabled = false;
            cbState.Text = vehicle.State;
        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }
        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            makes = new Make_Controller().getAll();
            models = new CarModel_Controller().getAll();
            setComboBoxMake();
            setComboBoxes();
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cbMake.Text.Trim() == ""
                || cbModel.Text.Trim() == ""
                || tbLicensePlate.Text.Trim() == ""
                || tbYear.Text.Trim() == ""
                || tbMileage.Text.Trim() == ""
                || cbEngine.Text.Trim() == ""
                || cbTransmission.Text.Trim() == "")
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
            else if (tbClientName.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un cliente");
            }
            else
            {
                Vehicle_Controller vehicleController = new Vehicle_Controller();
                
                Vehicle vehicle = new Vehicle();
                tbClientId.Text = selectedClient.Id;
                vehicle.Client = new Clients_Controller().getClient(tbClientId.Text.Trim());
                vehicle.Model = new CarModel_Controller().getModel(Convert.ToInt32(cbModel.SelectedValue.ToString()));
                vehicle.Model.Make = new Make_Controller().getMake(Convert.ToInt32(cbMake.SelectedValue.ToString()));
                vehicle.LicensePlate = tbLicensePlate.Text.Trim().ToUpper();
                vehicle.Year = Convert.ToInt32(tbYear.Text.Trim());
                vehicle.Mileage = Convert.ToInt32(tbMileage.Text.Trim());
                vehicle.EngineType = new Engine_Controller().getEngine(Convert.ToInt32(cbEngine.SelectedValue.ToString()));
                vehicle.TransmissionType = new Transmission_Controller().getTransmission(Convert.ToInt32(cbTransmission.SelectedValue.ToString()));
                vehicle.State = this.cbState.Text.Trim();

                if (vehicleController.upsert(vehicle))
                {
                    OnDataChanged(EventArgs.Empty);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Vehículo no agregado");
                }
            }
        }

        private void tbNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void setComboBoxes()
        {
            cbEngine.DataSource = engines;
            cbEngine.ValueMember = "Id";
            cbEngine.DisplayMember = "EngineType";
            cbEngine.SelectedIndex = -1;

            cbTransmission.DataSource = transmissions;
            cbTransmission.ValueMember = "Id";
            cbTransmission.DisplayMember = "TransmissionType";
            cbTransmission.SelectedIndex = -1;

            cbState.SelectedIndex = -1;
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

        private void btnSelectClient_Click(object sender, EventArgs e)
        {
            frmClients frmClients = new frmClients(this);
            frmClients.ClientSelected += HandleClientSelected;
            frmClients.MdiParent = this.MdiParent;
            frmClients.Show();
        }

        private void HandleClientSelected(Client selectedClient)
        {
            ShowClientInUpsertVehicle(selectedClient);
        }

        public void ShowClientInUpsertVehicle(Client client)
        {
            if (client != null)
            {
                tbClientName.Text = client.FullName;
                tbClientId.Text = client.Id;
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
            this.Dispose();
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

        private void tbClientId_TextChanged(object sender, EventArgs e)
        {
            string id = tbClientId.Text;

            if (id.Length >= 3)
            {
                Client client = new Clients_Controller().getClient(id);

                if (client != null)
                {
                    SelectClient(client);
                }
            }
        }

        public void SelectClient(Client client)
        {
            if (client != null)
            {
                tbClientId.Text = client.Id;
            }
            selectedClient = client;
            tbClientName.Text = client.FullName;
        }
    }
}
