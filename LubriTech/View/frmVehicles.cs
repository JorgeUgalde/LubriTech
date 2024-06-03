using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LubriTech.Controller;
using LubriTech.Model.Product_Information;
using LubriTech.Model.Vehicle_Information;

namespace LubriTech.View
{
    public partial class frmVehicles : Form
    {
        public frmVehicles()
        {
            InitializeComponent();
            load_Vehicles();
            SetupDataGridView();
        }

        private void load_Vehicles()
        {
            dgvVehicles.DataSource = new Vehicle_Controller().getAll();
        }

        private void frmVehicles_Load(object sender, EventArgs e)
        {

        }

        private void SetupDataGridView()
        {
            DataGridViewButtonColumn modifyButtonColumn = new DataGridViewButtonColumn();
            modifyButtonColumn.Name = "ModifyButtonColumn";
            modifyButtonColumn.HeaderText = "Ver Detalles";
            modifyButtonColumn.Text = "Detalles - Modificar";
            modifyButtonColumn.UseColumnTextForButtonValue = true;
            dgvVehicles.Columns.Add(modifyButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.HeaderText = "Eliminar ";
            deleteButtonColumn.Text = "Eliminar";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dgvVehicles.Columns.Add(deleteButtonColumn);
        }

        private void btnNewVehicle_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Vehicle frmUpsertVehicle = new frmInsertUpdate_Vehicle();
            frmUpsertVehicle.Owner = this;
            frmUpsertVehicle.DataChanged += ChildFormDataChangedHandler;
            frmUpsertVehicle.ShowDialog();
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Vehicles();
        }

        private void dgvVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvVehicles.Columns["ModifyButtonColumn"].Index && e.RowIndex >= 0)
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
                frmInsertVehicle.Owner = this;
                frmInsertVehicle.DataChanged += ChildFormDataChangedHandler;
                frmInsertVehicle.Show();
                return;
            }

            if (e.ColumnIndex == dgvVehicles.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Estás seguro de eliminar este vehículo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string selectedLicensePlate = dgvVehicles.Rows[e.RowIndex].Cells["LicensePlate"].Value.ToString();
                    Vehicle_Controller vehicleController = new Vehicle_Controller();
                    vehicleController.delete(selectedLicensePlate);
                    load_Vehicles();
                    return;
                }
            }
        }

        private void dgvVehicles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dgvVehicles.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvVehicles_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvVehicles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                dgvVehicles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}
