using LubriTech.Controller;
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
using LubriTech.View.Appointment_View;
using LubriTech.Model.InventoryManagment_Information;
using System.Reflection;
using LubriTech.Model.Branch_Information;

namespace LubriTech.View
{
    public partial class frmItems : Form
    {

        private List<Item> items;
        private Form parentForm;
        public event Action<Item> ItemSelected;

        public frmItems()
        {
            items = new List<Item>();
            InitializeComponent();
            load_Items(null);
            load_Branches();
        }

        public frmItems(Form parentForm)
        {
            items = new List<Item>();
            this.parentForm = parentForm;
            InitializeComponent();
            load_Items(null);
            load_Branches();
        }

        private void load_Branches()
        {
            List<Branch> branches = new Branch_Controller().getAll();
            cbBranch.DataSource = branches;
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
            cbBranch.SelectedValue = frmLogin.branch;
        }
      
        private void frmItems_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        private void load_Items(List<Item> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvItems.DataSource = items;

                }
                else
                {
                    dgvItems.DataSource = filteredList;
                }
            }
            else
            {
                items = new Item_Controller().getAll();
                if (items.Count == 0)
                {
                    MessageBox.Show("No hay artículos resgistrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvItems.DataSource = items;
            }
            dgvItems.Columns["code"].HeaderText = "Código";
            dgvItems.Columns["name"].HeaderText = "Nombre";
            dgvItems.Columns["purchasePrice"].HeaderText = "Precio Compra";
            dgvItems.Columns["measureUnit"].HeaderText = "Unidad Medida";
            dgvItems.Columns["state"].HeaderText = "Estado";
            dgvItems.Columns["itemType"].HeaderText = "Tipo";
            dgvItems.Columns["recommendedServiceInterval"].Visible = false;

            SetColumnOrder();

            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgvItems,
                new object[] { true });
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            
            load_Items(null);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Item frmInsertUpdateItem = new frmInsertUpdate_Item();
            frmInsertUpdateItem.MdiParent = this.MdiParent;
            frmInsertUpdateItem.DataChanged += ChildFormDataChangedHandler;
            frmInsertUpdateItem.Show();
        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            // Filtrar la lista de artículos
            var filteredList = items.Where(p =>
                p.code.ToString().ToLower().Contains(filterValue) ||
                p.name.ToString().ToLower().Contains(filterValue) ||
                p.measureUnit.ToString().ToLower().Contains(filterValue) ||
                p.state.ToString().ToLower().Contains(filterValue) ||
                p.itemType.ToString().ToLower().Contains(filterValue)
            ).ToList();

            // Refrescar el DataGridView
            dgvItems.DataSource = null;
            load_Items(filteredList);
        }

        private void SetColumnOrder()
        {

            dgvItems.Columns["code"].DisplayIndex = 0;
            dgvItems.Columns["name"].DisplayIndex = 1;
            dgvItems.Columns["measureUnit"].DisplayIndex = 2;
            dgvItems.Columns["itemType"].DisplayIndex = 3;
            dgvItems.Columns["purchasePrice"].DisplayIndex = 4;
            dgvItems.Columns["state"].DisplayIndex = 5;

        }


        private void dgvItems_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedCode = dgvItems.Rows[e.RowIndex].Cells["code"].Value.ToString();
                List<Item> items = new Item_Controller().getAll();
                Item selectedItem = items.FirstOrDefault(item => item.code == selectedCode);

                if (selectedItem != null)
                {
                    if (parentForm is frmInsertUpdate_InventoryManagment)
                    {
                        ((frmInsertUpdate_InventoryManagment)parentForm).ShowItemInDetailLine(selectedItem);
                        this.Close();
                    }else if (parentForm is frmWorkOrder)
                    {
                        ((frmWorkOrder)parentForm).ShowItemInWorkOrder(selectedItem);
                        this.Close();
                    }
                    else
                    {
                        frmInsertUpdate_Item frmInsertUpdateItem = new frmInsertUpdate_Item(selectedItem, (int)cbBranch.SelectedValue);
                        frmInsertUpdateItem.MdiParent = this.MdiParent;
                        frmInsertUpdateItem.DataChanged += ChildFormDataChangedHandler;
                        frmInsertUpdateItem.Show();
                        load_Items(null);
                    }
                }
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

    }
}
