using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using LubriTech.Model.InventoryManagment_Information;
using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_InventoryManagment : Form
    {
        private List<Supplier> suppliers;
        private List<Branch> branches;
        private Supplier selectedSupplier = null;

        public frmInsertUpdate_InventoryManagment()
        {
            suppliers = new List<Supplier>();
            branches = new Branch_Controller().getAll();
            InitializeComponent();
            setComboBox();
            tbSupplierId.Visible = false;
        }

        public frmInsertUpdate_InventoryManagment(Supplier supplier)
        {
            branches = new Branch_Controller().getAll();
            InitializeComponent();
            setComboBox();
            tbSupplierName.Text = supplier.name;
            tbSupplierId.Text = supplier.id;
            tbSupplierId.Visible = false;

        }

        public frmInsertUpdate_InventoryManagment(InventoryManagment inventoryManagment)
        {
            suppliers = new List<Supplier>();
            branches = new Branch_Controller().getAll();
            InitializeComponent();
            setComboBox();

            tbSupplierName.Text = inventoryManagment.Supplier.name;
            tbSupplierId.Text = inventoryManagment.Supplier.id;
            cbBranch.Text = inventoryManagment.Branch.Name;
            tbDate.Text = inventoryManagment.DocumentDate.ToString();
            cbDocumentType.Text = inventoryManagment.DocumentType;
            tbTotalAmount.Text = inventoryManagment.TotalAmount.ToString();
        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            branches = new Branch_Controller().getAll();
            setComboBox();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbSupplierName.Text.Trim() == ""
                || cbBranch.Text.Trim() == ""
                || tbDate.Text.Trim() == ""
                || cbDocumentType.Text.Trim() == ""
                || tbTotalAmount.Text.Trim() == "")
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
            else if (tbSupplierId.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un proveedor");
            }
            else
            {
                InventoryManagment_Controller inventoryManagmentController = new InventoryManagment_Controller();

                InventoryManagment inventoryManagment = new InventoryManagment();
                inventoryManagment.Supplier = new Supplier_Controller().GetSupplier(tbSupplierId.Text.Trim());
                inventoryManagment.Branch = new Branch_Controller().get(Convert.ToInt32(cbBranch.SelectedValue.ToString()));
                inventoryManagment.DocumentDate = Convert.ToDateTime(tbDate.Text.Trim());
                inventoryManagment.DocumentType = cbDocumentType.Text;
                inventoryManagment.TotalAmount = Convert.ToDouble(tbTotalAmount.Text.Trim());
                inventoryManagment.State = cbDocumentType.Text;

                if (inventoryManagmentController.upsert(inventoryManagment))
                {
                    OnDataChanged(EventArgs.Empty);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Manejo de inventario no insertado");
                }
            }
        }

        private void tbNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setComboBox()
        {
            cbBranch.DataSource = branches;
            cbBranch.ValueMember = "Id";
            cbBranch.DisplayMember = "Name";
            cbBranch.SelectedIndex = -1;
        }

        private void btnSelectSupplier_Click(object sender, EventArgs e)
        {
            frmSuppliers frmSupplier = new frmSuppliers(this);
            frmSupplier.SupplierSelected += HandleSupplierSelected;
            frmSupplier.MdiParent = this.MdiParent;
            frmSupplier.Show();
        }

        private void HandleSupplierSelected(Supplier selectedSupplier)
        {
            ShowSupplierInUpsertInventoryManagment(selectedSupplier);
        }

        public void ShowSupplierInUpsertInventoryManagment(Supplier supplier)
        {
            if (supplier != null)
            {
                tbSupplierName.Text = supplier.name;
                tbSupplierId.Text = supplier.id;
            }


        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelControlBox_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
    }
}
