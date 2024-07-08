using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Vehicle_Information;
using LubriTech.View.Appointment_View;

namespace LubriTech.View
{
    public partial class frmVehicles : Form
    {
        private List<Vehicle> vehicles;
        private Form parentForm;
        public event Action<Vehicle> VehicleSelected;
        string clientId = "";

        private int currentPage = 1;
        private int pageSize = 20; // Puedes ajustar este valor según sea necesario
        private int totalRecords = 0;
        private int totalPages = 0;


        public frmVehicles()
        {
            vehicles = new List<Vehicle>();
            InitializeComponent();
            load_Vehicles(null);
        }

        public frmVehicles(Form parentForm, string clientId)
        {
            if (clientId != "")
            {
                this.clientId = clientId;
            }
            vehicles = new List<Vehicle>();
            this.parentForm = parentForm;
            InitializeComponent();
            load_Vehicles(null);
        }

        private void frmVehicles_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        private void load_Vehicles(List<Vehicle> filteredList)
        {
            if (filteredList != null)
            {
                vehicles = filteredList;  
            }
            else
            {
                if (this.clientId == "")
                {
                    vehicles = new Vehicle_Controller().getAll();
                }
                else
                {
                    vehicles = new Vehicle_Controller().getVehiclesByClient(this.clientId);
                }
            }

            if (vehicles == null)
            {
                MessageBox.Show("No hay vehículos registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            totalRecords = vehicles.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            LoadPage();


            dgvVehicles.Columns["LicensePlate"].HeaderText = "Placa";
            dgvVehicles.Columns["Model"].HeaderText = "Modelo";
            dgvVehicles.Columns["Year"].HeaderText = "Año";
            dgvVehicles.Columns["TransmissionType"].HeaderText = "Transmisión";
            dgvVehicles.Columns["State"].HeaderText = "Estado";
            dgvVehicles.Columns["Client"].HeaderText = "Cliente";


            
            foreach (DataGridViewColumn column in dgvVehicles.Columns)
            {
                if (this.clientId == "")
                {
                    if (column.Name != "LicensePlate" && column.Name != "Year" && column.Name != "State" &&
                    column.Name != "Client" && column.Name != "Model")
                    {
                        column.Visible = false;
                    }
                }
                else
                {
                    if (column.Name != "LicensePlate" && column.Name != "Year" && column.Name != "State" 
                       && column.Name != "Model" )
                    {
                        column.Visible = false;
                    }
                }
            }
            SetColumnOrder();
        }

        private void LoadPage()
        {
            int startRecord = (currentPage - 1) * pageSize;
            int endRecord = Math.Min(currentPage * pageSize, totalRecords);

            var pageClients = vehicles.Skip(startRecord).Take(endRecord - startRecord).ToList();
            dgvVehicles.DataSource = pageClients;

            lblPageNumber.Text = $"Página {currentPage} de {totalPages}";
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();
            if (filterValue == "")
            {
                load_Vehicles(null);
                return;
            }

            // Filtrar la lista de vehiculos
            var filteredList = vehicles.Where(p =>
                p.LicensePlate.ToLower().Contains(filterValue) ||
                p.Mileage.ToString().ToLower().Contains(filterValue) ||
                p.Model.Make.Name.ToLower().Contains(filterValue) ||
                p.Model.Name.ToLower().Contains(filterValue) ||
                p.Year.ToString().ToLower().Contains(filterValue) ||
                p.TransmissionType.TransmissionType.ToLower().Contains(filterValue) ||
                p.Client.FullName.ToLower().Contains(filterValue)
            ).ToList();

            if (filteredList.Count == 0 ) {
                load_Vehicles(null);
                return;
            }

            load_Vehicles(filteredList);
        }

        private void btnNewVehicle_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Vehicle frmUpsertVehicle = new frmInsertUpdate_Vehicle();
            this.WindowState = FormWindowState.Normal;
            frmUpsertVehicle.MdiParent = this.MdiParent;
            frmUpsertVehicle.DataChanged += ChildFormDataChangedHandler;
            frmUpsertVehicle.Show();
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Vehicles(null);
        }

        private void SetColumnOrder()
        {
            dgvVehicles.Columns["LicensePlate"].DisplayIndex = 0;
            dgvVehicles.Columns["EngineType"].DisplayIndex = 1;
            dgvVehicles.Columns["Mileage"].DisplayIndex = 2;
            dgvVehicles.Columns["Model"].DisplayIndex = 3;
            dgvVehicles.Columns["Year"].DisplayIndex = 4;
            dgvVehicles.Columns["TransmissionType"].DisplayIndex = 5;
            dgvVehicles.Columns["Client"].DisplayIndex = 6;
            dgvVehicles.Columns["State"].DisplayIndex = 7;
        }

        private void txtFilter_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvVehicles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedLicensePlate = dgvVehicles.Rows[e.RowIndex].Cells["LicensePlate"].Value.ToString();
                List<Vehicle> vehicles = new Vehicle_Controller().getAll();
                Vehicle selectedVehicle = vehicles.FirstOrDefault(vehicle => vehicle.LicensePlate == selectedLicensePlate);
                if(selectedVehicle != null)
                {
                    if(parentForm is frmWorkOrder)
                    {
                        ((frmWorkOrder)parentForm).SelectVehicleWorkOrder(selectedVehicle);
                        this.Close();
                        return;
                    }
                    if(parentForm is frmAppointment)
                    {
                        ((frmAppointment)parentForm).SelectVehicle(selectedVehicle);
                        this.Close();
                        return;
                    }
                }

                //string action = "Modify";
                frmInsertUpdate_Vehicle frmInsertVehicle = new frmInsertUpdate_Vehicle(selectedVehicle);
                this.WindowState = FormWindowState.Normal;
                frmInsertVehicle.MdiParent = this.MdiParent;
                frmInsertVehicle.DataChanged += ChildFormDataChangedHandler;
                frmInsertVehicle.Show();
                return;
            }
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPage();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage();
            }
        }

    }
}
