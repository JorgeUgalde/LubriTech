using LubriTech.Controller;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmCarModels : Form
    {

        private List<CarModel> models;
        public frmCarModels()
        {
            InitializeComponent();
            SetupDataGridView();
            load_CarModels(null);
        }


        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_CarModels(null);
        }

        private void load_CarModels(List<CarModel> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvCarModels.DataSource = models;
                }
                else
                {
                    dgvCarModels.DataSource = filteredList;
                }
                SetColumnOrder();
            }
            else
            {
                models = new CarModel_Controller().getAll();
                if (models.Count == 0)
                {
                    MessageBox.Show("No hay modelos registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvCarModels.DataSource = models;


            }
            dgvCarModels.Columns["Id"].Visible = false;
            dgvCarModels.Columns["Make"].HeaderText = "Marca";
            dgvCarModels.Columns["Name"].HeaderText = "Nombre";
            dgvCarModels.Columns["State"].HeaderText = "Estado";
            SetColumnOrder();

        }

        private void SetupDataGridView()
        {
            DataGridViewImageColumn modifyImageColumn = new DataGridViewImageColumn();
            modifyImageColumn.Name = "ModifyImageColumn";
            modifyImageColumn.HeaderText = "Modificar";

            Image image = Properties.Resources.edit;
            modifyImageColumn.Image = image;
            dgvCarModels.Columns.Add(modifyImageColumn);

            DataGridViewImageColumn detailImageColumn = new DataGridViewImageColumn();
            detailImageColumn.Name = "DetailImageColumn";
            detailImageColumn.HeaderText = "Detalles";
            Image image1 = Properties.Resources.detail;
            detailImageColumn.Image = image1;

            dgvCarModels.Columns.Add(detailImageColumn);
        }

        private void SetColumnOrder()
        {
            dgvCarModels.Columns["State"].DisplayIndex = 0;
            dgvCarModels.Columns["Name"].DisplayIndex = 1;
            dgvCarModels.Columns["Make"].DisplayIndex = 2;
            dgvCarModels.Columns["ModifyImageColumn"].DisplayIndex = 3;
            dgvCarModels.Columns["DetailImageColumn"].DisplayIndex = 4;
        }

        private void dgvCarModels_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvCarModels.Columns["ModifyImageColumn"].Index)
                {
                    CarModel model = models[e.RowIndex];
                    //frmInsertUpdate_CarModel frmUpsertCarModel = new frmInsertUpdate_CarModel(model);
                    //frmUpsertCarModel.MdiParent = this.MdiParent;
                    //frmUpsertCarModel.DataChanged += ChildFormDataChangedHandler;
                    //frmUpsertCarModel.Show();

                    frmUpsert_Make_Model frmUpsertCarModel = new frmUpsert_Make_Model(model, "Modify");
                    frmUpsertCarModel.MdiParent = this.MdiParent;
                    this.WindowState = FormWindowState.Normal;
                    frmUpsertCarModel.DataChanged += ChildFormDataChangedHandler;
                    frmUpsertCarModel.Show();

                }
                if (e.ColumnIndex == dgvCarModels.Columns["DetailImageColumn"].Index)
                {
                    CarModel model = models[e.RowIndex];
                    frmUpsert_Make_Model frmUpsertCarModel = new frmUpsert_Make_Model(model, "Details");
                    frmUpsertCarModel.MdiParent = this.MdiParent;
                    this.WindowState = FormWindowState.Normal;
                    frmUpsertCarModel.DataChanged += ChildFormDataChangedHandler;
                    frmUpsertCarModel.Show();
                }
            }
        }

        private void btnAddCarModel_Click(object sender, EventArgs e)
        {
            //frmInsertUpdate_CarModel frmUpsertCarModel = new frmInsertUpdate_CarModel();
            //frmUpsertCarModel.MdiParent = this.MdiParent;
            //frmUpsertCarModel.DataChanged += ChildFormDataChangedHandler;
            //frmUpsertCarModel.Show();

            frmUpsert_Make_Model frmUpsertCarModel = new frmUpsert_Make_Model("Insert", "Model");
            frmUpsertCarModel.MdiParent = this.MdiParent;
            this.WindowState = FormWindowState.Normal;
            frmUpsertCarModel.DataChanged += ChildFormDataChangedHandler;
            frmUpsertCarModel.Show();

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            var filteredList = models.Where(p =>
                           p.Name.ToLower().Contains(filterValue) ||
                           p.Make.Name.ToLower().Contains(filterValue) ||
                           p.State.ToLower().Contains(filterValue)
                           ).ToList();

            dgvCarModels.DataSource = null;
            load_CarModels(filteredList);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmCarModels_Load(object sender, EventArgs e)
        {
            SetColumnOrder();
        }
    }
}
