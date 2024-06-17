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

            /// <summary>
            /// Establece los valores de los campos de texto con los datos del cliente.
            /// </summary>
            txtID.Text = client.Id;
            txtFullName.Text = client.FullName;
            txtMainPhone.Text = client.MainPhoneNum.ToString();
            txtAdditionalPhone.Text = client.AdditionalPhoneNum.ToString();
            txtEmail.Text = client.Email;
            txtAddresse.Text = client.Address;
            cbState.Text = client.State;

            /// <summary>
            /// Desactiva los campos de texto si la acción es "Details".
            /// </summary>
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

        /// <summary>
        /// Invoca el evento DataChanged para notificar a los suscriptores de que los datos han cambiado.
        /// </summary>
        /// <param name="e">Argumentos del evento.</param>
        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }


        /// <summary>
        /// Carga los vehículos del cliente en el DataGridView.
        /// </summary>
        /// <param name="sender">Objeto que envió el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
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

        /// <summary>
        /// Establece el orden de las columnas del DataGridView.
        /// </summary>
        private void SetColumnOrder()
        {
            dgvVehicles.Columns["LicensePlate"].DisplayIndex = 0;
            dgvVehicles.Columns["Model"].DisplayIndex = 1;
            dgvVehicles.Columns["Client"].DisplayIndex = 2;
            dgvVehicles.Columns["State"].DisplayIndex = 3;
            
        }

        /// <summary>
        /// Agrega un nuevo cliente a la base de datos.
        /// </summary>
        /// <param name="sender">Objeto que envió el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                /// <summary>
                /// Verifica si los campos de nombre y ID están llenos.
                /// </summary>
                if (!string.IsNullOrEmpty(this.txtFullName.Text) || !string.IsNullOrEmpty(this.txtID.Text)) 
                {
                    Clients_Controller clientsController = new Clients_Controller();

                    /// <summary>
                    /// Obtiene los valores de los campos de texto.
                    /// </summary>
                    string id = this.txtID.Text.Trim();
                    string fullname = this.txtFullName.Text.Trim();
                    int? mainPhone = Int32.TryParse(this.txtMainPhone.Text.Trim(), out int mainPhoneValue) ? mainPhoneValue : (int?)null;
                    int? additionalPhone = Int32.TryParse(this.txtAdditionalPhone.Text.Trim(), out int additionalPhoneValue) ? additionalPhoneValue : (int?)null;
                    string email = this.txtEmail.Text.Trim();
                    string address = this.txtAddresse.Text.Trim();
                    string state = this.cbState.Text.Trim();

                    Client client = new Client(id, fullname, mainPhone, additionalPhone, email, address, state);

                    /// <summary>
                    /// Intenta agregar el cliente a la base de datos.
                    /// </summary>
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

        /// <summary>
        /// Abre el formulario de Dato Maestro de vehículos.
        /// </summary>
        /// <param name="sender">Objeto que envió el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Vehicle frmNewVehicle = new frmInsertUpdate_Vehicle();
            frmNewVehicle.MdiParent = this.MdiParent;
            frmNewVehicle.Show();
        }

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Verifica si el carácter ingresado es un dígito o un carácter especial.
        /// </summary>
        private void txtMainPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
        }

        /// <summary>
        /// Verifica si el carácter ingresado es un dígito o un carácter especial.
        /// </summary>
        private void txtAdditionalPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
        }
    }
}