using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            SetupDataGridView();
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
            dgvVehicles.Columns["Transmission"].HeaderText = "Transmisión";
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
                p.Engine.ToLower().Contains(filterValue) ||
                p.Mileage.ToString().ToLower().Contains(filterValue) ||
                p.Model.Make.Name.ToLower().Contains(filterValue) ||
                p.Model.Name.ToLower().Contains(filterValue) ||
                p.Year.ToString().ToLower().Contains(filterValue) ||
                p.Transmission.ToLower().Contains(filterValue) ||
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

        private void dgvVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvVehicles.Columns["ModifyImageColumn"].Index && e.RowIndex >= 0)
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
                frmInsertUpdate_Vehicle frmInsertVehicle = new frmInsertUpdate_Vehicle(selectedVehicle, action);
                frmInsertVehicle.MdiParent = this.MdiParent;
                frmInsertVehicle.DataChanged += ChildFormDataChangedHandler;
                frmInsertVehicle.Show();
                return;
            }

            if (e.ColumnIndex == dgvVehicles.Columns["DetailImageColumn"].Index && e.RowIndex >= 0)
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
                string action = "Details";
                frmInsertUpdate_Vehicle frmInsertVehicle = new frmInsertUpdate_Vehicle(selectedVehicle, action);
                frmInsertVehicle.MdiParent = this.MdiParent;
                frmInsertVehicle.DataChanged += ChildFormDataChangedHandler;
                frmInsertVehicle.Show();
                return;
            }
        }

        private void SetupDataGridView()
        {
            DataGridViewImageColumn modifyImageColumn = new DataGridViewImageColumn();
            modifyImageColumn.Name = "ModifyImageColumn";
            modifyImageColumn.HeaderText = "Modificar";
            modifyImageColumn.Image = Properties.Resources.edit;
            dgvVehicles.Columns.Add(modifyImageColumn);

            DataGridViewImageColumn detailImageColumn = new DataGridViewImageColumn();
            detailImageColumn.Name = "DetailImageColumn";
            detailImageColumn.HeaderText = "Detalles";
            detailImageColumn.Image = Properties.Resources.detail;
            dgvVehicles.Columns.Add(detailImageColumn);
        }

        private void SetColumnOrder()
        {
            dgvVehicles.Columns["LicensePlate"].DisplayIndex = 0;
            dgvVehicles.Columns["Engine"].DisplayIndex = 1;
            dgvVehicles.Columns["Mileage"].DisplayIndex = 2;
            dgvVehicles.Columns["Model"].DisplayIndex = 3;
            dgvVehicles.Columns["Year"].DisplayIndex = 4;
            dgvVehicles.Columns["Transmission"].DisplayIndex = 5;
            dgvVehicles.Columns["Client"].DisplayIndex = 6;
            dgvVehicles.Columns["State"].DisplayIndex = 7;
            dgvVehicles.Columns["ModifyImageColumn"].DisplayIndex = 8;
            dgvVehicles.Columns["DetailImageColumn"].DisplayIndex = 9;
        }

        private void txtFilter_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
