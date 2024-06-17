using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using System;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using LubriTech.Model.Vehicle_Information;
using System.Collections.Generic;

namespace LubriTech.View
{
    public partial class frmUpsert_Client : Form
    {
        private Client newClient;
        public frmUpsert_Client()
        {
            InitializeComponent();
            


        }

        public frmUpsert_Client(Client client, string action)
        {
            InitializeComponent();

            txtID.Text = client.Id;
            txtFullName.Text = client.FullName;
            txtMainPhone.Text = client.MainPhoneNum.ToString();
            txtAdditionalPhone.Text = client.AdditionalPhoneNum.ToString();
            txtEmail.Text = client.Email;
            txtAddresse.Text = client.Address;

            if (action == "Modify")
            {
                btnAddClient.Text = "Modificar";
            }
            else
            {
                btnAddClient.Hide();
                btnAddVehicle.Hide();

                newClient = client;
            }
        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        

        private void frmUpsert_Client_Load(object sender, EventArgs e)
        {
            List<Vehicle> vehicles;
            
            if (existingClient == null)
            {
                Vehicle_Controller vehicle_Controller = new Vehicle_Controller();
                vehicles = vehicle_Controller.getAll();
            }
            else
            {
                Clients_Controller clients_Controller = new Clients_Controller();
                vehicles = clients_Controller.getVehicle(existingClient.Id);

                if (vehicles == null || vehicles.Count == 0)
                {
                    Vehicle_Controller vehicle_Controller = new Vehicle_Controller();
                    vehicles = vehicle_Controller.getAll();
                }
            }

            dgvVehicles.DataSource = vehicles;
            dgvVehicles.Columns["LicensePlate"].HeaderText = "Placa";
            dgvVehicles.Columns["Model"].HeaderText = "Modelo";
            dgvVehicles.Columns["Client"].HeaderText = "Cliente";
            dgvVehicles.Columns["State"].HeaderText = "Estado";

            foreach (DataGridViewColumn column in dgvVehicles.Columns)
            {
                if (column.Name != "LicensePlate" && column.Name != "Model" && column.Name != "Client" && column.Name != "State")
                {
                    column.Visible = false;
                }
            }

            dgvVehicles.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            SetColumnOrder();
        }

        private void SetColumnOrder()
        {
            dgvVehicles.Columns["LicensePlate"].DisplayIndex = 0;
            dgvVehicles.Columns["Model"].DisplayIndex = 1;
            dgvVehicles.Columns["Client"].DisplayIndex = 2;
            dgvVehicles.Columns["State"].DisplayIndex = 3;
            
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(this.txtFullName.Text) ||
                    !string.IsNullOrEmpty(this.txtID.Text))
                    
                {

                    Clients_Controller clientsController = new Clients_Controller();

                  
                    string id = this.txtID.Text.Trim();
                    string fullname = this.txtFullName.Text.Trim();
                    int? mainPhone = Convert.ToInt32(this.txtMainPhone.Text.Trim());
                    int? additionalPhone = Convert.ToInt32(this.txtAdditionalPhone.Text.Trim());
                    string email = this.txtEmail.Text.Trim();
                    string address = this.txtAddresse.Text.Trim();
                    string state = "Activo";

                    Client client = new Client(id, fullname, mainPhone, additionalPhone, email, address, state);

                    if (clientsController.upsert(client))
                    {
                        OnDataChanged(EventArgs.Empty);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("El Cliente no se ha agregado correctamente");
                    }

                }
                else
                {
                    MessageBox.Show("Ingrese todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Vehicle frmNewVehicle = new frmInsertUpdate_Vehicle();
            frmNewVehicle.MdiParent = this.MdiParent;
            frmNewVehicle.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
