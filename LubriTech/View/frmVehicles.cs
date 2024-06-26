using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Vehicle_Information;

namespace LubriTech.View
{
    public partial class frmVehicles : Form
    {
        private List<Vehicle> vehicles;

        public frmVehicles()
        {
            vehicles = new List<Vehicle>();
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
                if (filteredList.Count == 0)
                {
                    dgvVehicles.DataSource = vehicles;

                }
                else
                {
                    dgvVehicles.DataSource = filteredList;
                }
            }
            else
            {
                vehicles = new Vehicle_Controller().getAll();
                if (vehicles == null)
                {
                    MessageBox.Show("No hay vehículos registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvVehicles.DataSource = vehicles;
            }
            dgvVehicles.Columns["LicensePlate"].HeaderText = "Placa";
            dgvVehicles.Columns["Model"].HeaderText = "Modelo";
            dgvVehicles.Columns["Year"].HeaderText = "Año";
            dgvVehicles.Columns["TransmissionType"].HeaderText = "Transmisión";
            dgvVehicles.Columns["State"].HeaderText = "Estado";
            dgvVehicles.Columns["Client"].HeaderText = "Cliente";
            
            foreach (DataGridViewColumn column in dgvVehicles.Columns)
            {
                if (column.Name != "LicensePlate" && column.Name != "Year" && column.Name != "State" &&
                    column.Name != "Client" && column.Name != "Model" && column.Name != "ModifyImageColumn" && column.Name != "DetailImageColumn")
                {
                    column.Visible = false;
                }
            }
            SetColumnOrder();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            // Filtrar la lista de vehiculos
            var filteredList = vehicles.Where(p =>
                p.LicensePlate.ToLower().Contains(filterValue) ||
                p.EngineType.EngineType.ToLower().Contains(filterValue) ||
                p.Mileage.ToString().ToLower().Contains(filterValue) ||
                p.Model.Make.Name.ToLower().Contains(filterValue) ||
                p.Model.Name.ToLower().Contains(filterValue) ||
                p.Year.ToString().ToLower().Contains(filterValue) ||
                p.TransmissionType.TransmissionType.ToLower().Contains(filterValue) ||
                p.Client.FullName.ToLower().Contains(filterValue)
            ).ToList();

            // Refrescar el DataGridView
            dgvVehicles.DataSource = null;
            load_Vehicles(filteredList);
        }

        private void btnNewVehicle_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Vehicle frmUpsertVehicle = new frmInsertUpdate_Vehicle();
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
                Vehicle selectedVehicle = null;
                foreach (Vehicle vehicle in vehicles)
                {
                    if (vehicle.LicensePlate == selectedLicensePlate)
                    {
                        selectedVehicle = vehicle;
                        break;
                    }
                }

                string action = "Modify";
                frmInsertUpdate_Vehicle frmInsertVehicle = new frmInsertUpdate_Vehicle(selectedVehicle);
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
    }
}
