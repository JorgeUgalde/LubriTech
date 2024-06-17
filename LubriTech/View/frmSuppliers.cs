﻿using LubriTech.Controller;
using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmSuppliers : Form
    {
        private List<Supplier> suppliers;
        public frmSuppliers()
        {
            InitializeComponent();
            SetupDataGridView();
            suppliers = new List<Supplier>();
            LoadSuppliers(null);
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        //click event for each row in the DataGridView to open the frmInsertUpdateSupplier form

        private void LoadSuppliers(List<Supplier> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvSuppliers.DataSource = suppliers;

                }
                else
                {
                    dgvSuppliers.DataSource = filteredList;
                }
            }
            else
            {
                suppliers = new Supplier_Controller().getAll();
                dgvSuppliers.DataSource = suppliers;

            }
            dgvSuppliers.Columns["id"].HeaderText = "Codigo";
            dgvSuppliers.Columns["name"].HeaderText = "Nombre";
            dgvSuppliers.Columns["email"].HeaderText = "Correo electrónico";
            dgvSuppliers.Columns["phone"].HeaderText = "Teléfono";
            SetColumnOrder();
        }
        private void SetColumnOrder()
        {
            dgvSuppliers.Columns["id"].DisplayIndex = 0;
            dgvSuppliers.Columns["name"].DisplayIndex = 1;
            dgvSuppliers.Columns["email"].DisplayIndex = 2;
            dgvSuppliers.Columns["phone"].DisplayIndex = 3;
            dgvSuppliers.Columns["ModifyImageColumn"].DisplayIndex = 4;
            dgvSuppliers.Columns["DetailImageColumn"].DisplayIndex = 5;
        }

        // Event handler to refresh DataGridView when the event is raised
        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            // Refresh DataGridView here
            // For example:
            LoadSuppliers(null);
        }

        private void SetupDataGridView()
        {
            // Modify button column
            DataGridViewImageColumn modifyImageColumn = new DataGridViewImageColumn();
            modifyImageColumn.Name = "ModifyImageColumn";
            modifyImageColumn.HeaderText = "Modificar";
            modifyImageColumn.Image = Properties.Resources.edit;
            dgvSuppliers.Columns.Add(modifyImageColumn);

            DataGridViewImageColumn detailImageColumn = new DataGridViewImageColumn();
            detailImageColumn.Name = "DetailImageColumn";
            detailImageColumn.HeaderText = "Detalles";
            detailImageColumn.Image = Properties.Resources.detail;
            dgvSuppliers.Columns.Add(detailImageColumn);

            // Handle CellContentClick event
            //dgvSuppliers.CellContentClick += DataGridView_CellContentClick;
        }

       
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            //frmInsertUpdateSupplier is the child form that will be opened
            frmInsertUpdateSupplier frm = new frmInsertUpdateSupplier();
            frm.DataChanged += ChildFormDataChangedHandler;
            frm.MdiParent = this.MdiParent;
            this.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSuppliers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSuppliers.Columns["ModifyImageColumn"].Index && e.RowIndex >= 0)
            {
                string idToModify = dgvSuppliers.Rows[e.RowIndex].Cells["id"].Value.ToString();
                Supplier itemSelected = new Supplier_Controller().GetSupplier(idToModify);

                frmInsertUpdateSupplier frmUpsert = new frmInsertUpdateSupplier(itemSelected, 1);
                frmUpsert.MdiParent = this.MdiParent;
                this.WindowState = FormWindowState.Normal;
                frmUpsert.DataChanged += ChildFormDataChangedHandler;
                frmUpsert.Show();
                return;
            }

            if (e.ColumnIndex == dgvSuppliers.Columns["DetailImageColumn"].Index && e.RowIndex >= 0)
            {
                string idOfDetails = dgvSuppliers.Rows[e.RowIndex].Cells["id"].Value.ToString();
                Supplier itemSelected = new Supplier_Controller().GetSupplier(idOfDetails);

                frmInsertUpdateSupplier frmUpsert = new frmInsertUpdateSupplier(itemSelected, 0);
                frmUpsert.MdiParent = this.MdiParent;
                this.WindowState = FormWindowState.Normal;
                frmUpsert.DataChanged += ChildFormDataChangedHandler;
                frmUpsert.Show();

                return;

            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();

        }
        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            // Filtrar la lista de productos
            var filteredList = suppliers.Where(p =>
                p.id.ToLower().Contains(filterValue) ||
                p.name.ToLower().Contains(filterValue) ||
                p.email.ToLower().Contains(filterValue)
            ).ToList();

            // Refrescar el DataGridView
            dgvSuppliers.DataSource = null;
            LoadSuppliers(filteredList);
        }
    }
}
