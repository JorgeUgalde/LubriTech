using LubriTech.Controller;
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
    public partial class frmInsertUpdateSupplier : Form
    {
        Supplier_Controller sc = new Supplier_Controller();
        String supplierId;
        public frmInsertUpdateSupplier(string supplierId)
        {
            InitializeComponent();
            this.supplierId = supplierId;
        }

        public frmInsertUpdateSupplier()
        {
            InitializeComponent();
        }

        //method to load the supplier data into the form
        private void LoadSupplier()
        {
            Supplier supplier = sc.GetSupplier(supplierId);
            txtId.Text = supplier.id;
            txtName.Text = supplier.name;
            txtEmail.Text = supplier.email;
            txtPhone.Text = supplier.phone.ToString();
        }

        private void frmInsertUpdateSupplier_Load(object sender, EventArgs e)
        {
            if (supplierId != null)
            {
                LoadSupplier();
            }
        }

        // Define a custom event
        public event EventHandler DataChanged;

        // Method to raise the event
        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void btUpsert_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.id = txtId.Text;
            supplier.name = txtName.Text;
            supplier.email = txtEmail.Text;
            supplier.phone = Convert.ToInt32(txtPhone.Text);
            sc.Upsert(supplier);
            OnDataChanged(EventArgs.Empty);
            this.Close();
        }
    }
}
