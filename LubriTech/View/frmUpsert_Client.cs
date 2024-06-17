using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using System;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using LubriTech.Model.Vehicle_Information;
using System.Collections.Generic;
using System.Drawing;

namespace LubriTech.View
{
    public partial class frmUpsert_Client : Form
    {
        private Client existingClient;
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
            cbState.Text = client.State;

            if (action == "Details")
            {
                txtID.Enabled = false;
                txtFullName.Enabled = false;
                txtMainPhone.Enabled = false;
                txtAdditionalPhone.Enabled = false;
                txtEmail.Enabled = false;
                txtAddresse.Enabled = false;
                cbState.Enabled = false;

                txtID.BackColor = Color.FromArgb(249, 252, 255);
                txtFullName.BackColor = Color.FromArgb(249, 252, 255);
                txtMainPhone.BackColor = Color.FromArgb(249, 252, 255);
                txtAdditionalPhone.BackColor = Color.FromArgb(249, 252, 255);
                txtEmail.BackColor = Color.FromArgb(249, 252, 255);
                txtAddresse.BackColor = Color.FromArgb(249, 252, 255);
                cbState.BackColor = Color.FromArgb(249, 252, 255);


                btnClose.Location = new Point(47, 525);
                btnAddClient.Hide();
                btnAddVehicle.Hide();
            }
            existingClient = client;
        }
            

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        

        private void frmUpsert_Client_Load(object sender, EventArgs e)
        {
            if (existingClient == null)
            {
                Vehicle_Controller vehicle_Controller = new Vehicle_Controller();
                dgvVehiclesClients.DataSource = vehicle_Controller.getAll();
            }
            else
            {
                Clients_Controller clients_Controller = new Clients_Controller();
                List<Vehicle> vehicles = clients_Controller.getVehicle(existingClient.Id);
                dgvVehiclesClients.DataSource = vehicles;
            }

        }

       

        private void dgvVehiclesClients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dgvVehiclesClients.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                        int? mainPhone = Int32.TryParse(this.txtMainPhone.Text.Trim(), out int mainPhoneValue) ? mainPhoneValue : (int?)null;
                        int? additionalPhone = Int32.TryParse(this.txtAdditionalPhone.Text.Trim(), out int additionalPhoneValue) ? additionalPhoneValue : (int?)null;
                        string email = this.txtEmail.Text.Trim();
                        string address = this.txtAddresse.Text.Trim();
                        string state = this.cbState.Text.Trim();

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
            frmNewVehicle.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtMainPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
        }

        private void txtAdditionalPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
        }
    }
}