﻿using LubriTech.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LubriTech.Model.Supplier_Information;
using LubriTech.Model.Item_Information;
using System.Runtime.InteropServices;

namespace LubriTech.View
{
    public partial class frmItems : Form
    {
        private List<Item> items;
        private Form parentForm;

        public event Action<Item> ItemSelected;

        public frmItems()
        {
            InitializeComponent();
            items = new List<Item>();
            SetupDataGridView();
            load_Items(null);
        }

        public frmItems(Form parentForm)
        {
            items = new List<Item>();
            this.parentForm = parentForm;
            InitializeComponent();
            SetupDataGridView();
            load_Items(null);
        }

        // **************************************** Filtrado inicio  ***************************************************//

        // ************************* crear lista de lo que hacen, en mi caso la linea 18 tiene la lista de productos global


        private void load_Items(List<Item> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvItems.DataSource = items.Select(p => new
                    {
                        code = p.code,
                        name = p.name,
                        measureUnit = p.measureUnit,
                        state = p.state,
                        type = p.type
                    }).ToList();

                }
                else
                {
                    dgvItems.DataSource = filteredList.Select(p => new
                    {
                        code = p.code,
                        name = p.name,
                        measureUnit = p.measureUnit,
                        state = p.state,
                        type = p.type
                    }).ToList();
                }
            }
            else
            {
                items = new Item_Controller().getAll();

                // dont show all the columns, only show the columns that are needed
                dgvItems.DataSource = items.Select(p => new
                {
                    code = p.code,
                    name = p.name,
                    measureUnit = p.measureUnit,
                    state = p.state,
                    type = p.type
                }).ToList();


            }
            dgvItems.Columns["code"].HeaderText = "Código";
            dgvItems.Columns["name"].HeaderText = "Nombre";
            //dgvItems.Columns["sellPrice"].HeaderText = "Precio Venta";
            dgvItems.Columns["measureUnit"].HeaderText = "Unidad Medida";
            dgvItems.Columns["state"].HeaderText = "Estado";
            dgvItems.Columns["type"].HeaderText = "Tipo";
            SetColumnOrder();
        }

        private void SetColumnOrder()
        {
            dgvItems.Columns["code"].DisplayIndex = 0;
            dgvItems.Columns["name"].DisplayIndex = 1;
            //dgvItems.Columns["sellPrice"].DisplayIndex = 2;
            dgvItems.Columns["measureUnit"].DisplayIndex = 2;
            dgvItems.Columns["state"].DisplayIndex = 3;
            dgvItems.Columns["type"].DisplayIndex = 4;
            dgvItems.Columns["ModifyImageColumn"].DisplayIndex = 5;
            dgvItems.Columns["DetailImageColumn"].DisplayIndex = 6;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            // Filtrar la lista de productos
            var filteredList = items.Where(p =>
                p.code.ToLower().Contains(filterValue) ||
                p.name.ToLower().Contains(filterValue) ||
                p.measureUnit.ToLower().Contains(filterValue) 
            ).ToList();

            // Refrescar el DataGridView
            dgvItems.DataSource = null;
            load_Items(filteredList);
        }
        //**************************************** Filtrado final ***************************************************//

        private void SetupDataGridView()
        {
            // Modify button column
            DataGridViewImageColumn modifyImageColumn = new DataGridViewImageColumn();
            modifyImageColumn.Name = "ModifyImageColumn";
            modifyImageColumn.HeaderText = "Modificar";
            modifyImageColumn.Image = Properties.Resources.edit;
            dgvItems.Columns.Add(modifyImageColumn);

            DataGridViewImageColumn detailImageColumn = new DataGridViewImageColumn();
            detailImageColumn.Name = "DetailImageColumn";
            detailImageColumn.HeaderText = "Detalles";
            detailImageColumn.Image = Properties.Resources.detail;
            dgvItems.Columns.Add(detailImageColumn);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Item frmInsertProduct = new frmInsertUpdate_Item();
            frmInsertProduct.MdiParent = this.MdiParent;
            frmInsertProduct.DataChanged += ChildFormDataChangedHandler;
            this.WindowState = FormWindowState.Normal;
            frmInsertProduct.Show();
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Items(null);
        }

        private void dgvItems_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvItems.Columns["ModifyImageColumn"].Index && e.RowIndex >= 0)
            {
                string idToModify = dgvItems.Rows[e.RowIndex].Cells["code"].Value.ToString();
                Item itemSelected = new Item_Controller().get(idToModify);                            

                frmInsertUpdate_Item frmUpsert = new frmInsertUpdate_Item(itemSelected, 1);
                frmUpsert.MdiParent = this.MdiParent;
                this.WindowState = FormWindowState.Normal;
                frmUpsert.DataChanged += ChildFormDataChangedHandler;
                frmUpsert.Show();
                return;
            }

            if (e.ColumnIndex == dgvItems.Columns["DetailImageColumn"].Index && e.RowIndex >= 0)
            {
                string idOfDetails = dgvItems.Rows[e.RowIndex].Cells["code"].Value.ToString();
                Item itemSelected = new Item_Controller().get(idOfDetails);

                frmInsertUpdate_Item frmUpsert = new frmInsertUpdate_Item(itemSelected, 0);
                frmUpsert.MdiParent = this.MdiParent;
                this.WindowState = FormWindowState.Normal;
                frmUpsert.DataChanged += ChildFormDataChangedHandler;
                frmUpsert.Show();

                return;

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
