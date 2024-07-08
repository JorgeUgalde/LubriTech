using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Supplier_Information;
using LubriTech.View.Appointment_View;
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

namespace LubriTech.View
{
    public partial class frmSuppliers : Form
    {
        private List<Supplier> suppliers;
        private Form parentForm;
        public event Action<Supplier> SupplierSelected;

        public frmSuppliers()
        {
            suppliers = new List<Supplier>();
            InitializeComponent();
            load_Suppliers(null);

        }

        //Para manejar el proveedor seleccionado
        public frmSuppliers(Form parentForm)
        {
            suppliers = new List<Supplier>();
            this.parentForm = parentForm;
            InitializeComponent();
            load_Suppliers(null);

        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        private void load_Suppliers(List<Supplier> filteredList)
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
                if (suppliers.Count == 0)
                {
                    MessageBox.Show("No hay proveedores registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvSuppliers.DataSource = suppliers;

            }
            dgvSuppliers.Columns["id"].HeaderText = "Codigo";
            dgvSuppliers.Columns["name"].HeaderText = "Nombre";
            dgvSuppliers.Columns["email"].HeaderText = "Correo electrónico";
            dgvSuppliers.Columns["phone"].HeaderText = "Teléfono";
            SetColumnOrder();

            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgvSuppliers,
                new object[] { true });
        }


        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Suppliers(null);
        }


        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }


        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            frmInsertUpdateSupplier frmInsertUpdateSupplier = new frmInsertUpdateSupplier();
            this.WindowState = FormWindowState.Normal;
            frmInsertUpdateSupplier.MdiParent = this.MdiParent;
            frmInsertUpdateSupplier.DataChanged += ChildFormDataChangedHandler;
            frmInsertUpdateSupplier.Show();
        }


        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            // Filtrar la lista de proveedores
            var filteredList = suppliers.Where(p =>
            p.id.ToLower().Contains(filterValue) ||
            p.name.ToLower().Contains(filterValue) ||
            p.email.ToLower().Contains(filterValue) ||
            p.phone.ToString().Contains(filterValue)
            ).ToList();

            // Refrescar el DataGridView
            dgvSuppliers.DataSource = null;
            load_Suppliers(filteredList);
        }


        private void SetColumnOrder()
        {
            dgvSuppliers.Columns["id"].DisplayIndex = 0;
            dgvSuppliers.Columns["name"].DisplayIndex = 1;
            dgvSuppliers.Columns["email"].DisplayIndex = 2;
            dgvSuppliers.Columns["phone"].DisplayIndex = 3;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvSuppliers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string supplierId = dgvSuppliers.Rows[e.RowIndex].Cells["id"].Value.ToString();
                List<Supplier> suppliers = new Supplier_Controller().getAll();
                Supplier selectedSupplier = suppliers.FirstOrDefault(supplier => supplier.id == supplierId);

                if (selectedSupplier != null)
                {
                    if (parentForm is frmInsertUpdate_InventoryManagment)
                    {
                        ((frmInsertUpdate_InventoryManagment)parentForm).ShowSupplierInUpsertInventoryManagment(selectedSupplier);
                        this.Close();
                    }
                    else
                    {
                        frmInsertUpdateSupplier frmInsertUpdateSupplier = new frmInsertUpdateSupplier(selectedSupplier);
                        this.WindowState = FormWindowState.Normal;
                        frmInsertUpdateSupplier.MdiParent = this.MdiParent;
                        frmInsertUpdateSupplier.DataChanged += ChildFormDataChangedHandler;
                        frmInsertUpdateSupplier.Show();
                        load_Suppliers(null);
                    }
                }
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

        }

        private void pbMaximize_Click_1(object sender, EventArgs e)
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

        private void pbClose_Click_1(object sender, EventArgs e)
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
