using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using System;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using LubriTech.Model.Vehicle_Information;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using LubriTech.Model.PricesList_Information;

namespace LubriTech.View
{

    public partial class frmUpsert_Client : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Client existingClient;
        public frmUpsert_Client()
        {
            InitializeComponent();
            cbPriceList.DataSource = new PriceList_Controller().getPriceLists();
            cbPriceList.DisplayMember = "Description";
            cbPriceList.ValueMember = "Id";
            cbPriceList.SelectedValue = 1;
            cbState.SelectedIndex = 0;


        }

        public frmUpsert_Client(Client client)
        {
            InitializeComponent();

            /// <summary>
            /// Establece los valores de los campos de texto con los datos del cliente.
            /// </summary>
            existingClient = client;
            txtID.Text = client.Id;
            txtFullName.Text = client.FullName;
            txtMainPhone.Text = client.MainPhoneNum.ToString();
            txtAdditionalPhone.Text = client.AdditionalPhoneNum.ToString();
            txtEmail.Text = client.Email;
            txtAddresse.Text = client.Address;
            cbState.Text = client.State;
            cbPriceList.DataSource = new PriceList_Controller().getPriceLists();
            cbPriceList.DisplayMember = "Description";
            cbPriceList.ValueMember = "Id";
            cbPriceList.SelectedValue = client.PriceList.id;

            /// <summary>
            /// Desactiva los campos de texto si la acción es "Details".
            /// </summary>

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

            List<Vehicle> vehicles = new List<Vehicle>();

            if (existingClient != null)
            {
                Clients_Controller clients_Controller = new Clients_Controller();
                vehicles = clients_Controller.getVehicle(existingClient.Id);
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
                    PriceList priceList = new PriceList_Controller().getPriceList((int)cbPriceList.SelectedValue);

                    Client client = new Client(id, fullname, mainPhone, additionalPhone, email, address, state, priceList);

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
            if (existingClient != null)
            {
                frmInsertUpdate_Vehicle frmInsertVehicle = new frmInsertUpdate_Vehicle(existingClient);
                frmInsertVehicle.MdiParent = this.MdiParent;
                frmInsertVehicle.Show();
            }
            else
            {
                frmInsertUpdate_Vehicle frmNewVehicle = new frmInsertUpdate_Vehicle();
                frmNewVehicle.MdiParent = this.MdiParent;
                frmNewVehicle.Show();
            }
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

        private void dgvVehicles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string selectedLicensePlate = dgvVehicles.Rows[e.RowIndex].Cells["LicensePlate"].Value.ToString();
                List<Vehicle> vehicles = new Vehicle_Controller().getAll();
                Vehicle selectedVehicle = null;
                foreach (Vehicle vehicle in vehicles)
                {
                    if (vehicle.LicensePlate == selectedLicensePlate)
                    {
                        selectedVehicle = vehicle;
                        break;
                    }
                }

                frmInsertUpdate_Vehicle frmInsertVehicle = new frmInsertUpdate_Vehicle(selectedVehicle);
                frmInsertVehicle.MdiParent = this.MdiParent;
                frmInsertVehicle.Show();
                return;
            }
        }

        public void PriceListSelected(PriceList priceList)
        {
            throw new NotImplementedException();
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

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

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}