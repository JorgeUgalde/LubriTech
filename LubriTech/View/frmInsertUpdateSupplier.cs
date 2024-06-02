using LubriTech.Controller;
using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            //Supplier supplier = new Supplier();
            //supplier.id = txtId.Text;
            //supplier.name = txtName.Text;
            //supplier.email = txtEmail.Text;
            //supplier.phone = Convert.ToInt32(txtPhone.Text);
            //sc.Upsert(supplier);
            //OnDataChanged(EventArgs.Empty);
            //this.Close();
            ValidateAndSubmit();
        }

        private void ValidateAndSubmit()
        {
            bool isValid = true;

            // Clear previous errors
            ClearErrorBorders();

            // Validate ID (not empty)
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                SetErrorBorder(panelId);
                isValid = false;
            }

            // Validate Name (not empty)
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                SetErrorBorder(panelName);
                isValid = false;
            }

            // Validate Email (simple format check)
            if (!IsValidEmail(txtEmail.Text))
            {
                SetErrorBorder(panelEmail);
                isValid = false;
            }

            // Validate Phone (only numbers and minimum length)
            if (!int.TryParse(txtPhone.Text, out int phone) || txtPhone.Text.Length < 8)
            {
                SetErrorBorder(panelPhone);
                isValid = false;
            }

            if (isValid)
            {
                Supplier supplier = new Supplier
                {
                    id = txtId.Text,
                    name = txtName.Text,
                    email = txtEmail.Text,
                    phone = phone
                };

                // Assuming sc is an instance of a class that handles database operations
                sc.Upsert(supplier);
                OnDataChanged(EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, corrija los campos en rojo.");
            }
        }

        private void ClearErrorBorders()
        {
            panelId.BackColor = SystemColors.Control;
            panelName.BackColor = SystemColors.Control;
            panelEmail.BackColor = SystemColors.Control;
            panelPhone.BackColor = SystemColors.Control;
        }

        private void SetErrorBorder(Panel panel)
        {
            panel.BackColor = Color.Red;
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
