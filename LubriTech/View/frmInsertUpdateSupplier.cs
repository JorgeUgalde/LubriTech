using LubriTech.Controller;
using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmInsertUpdateSupplier : Form
    {
        Supplier_Controller sc = new Supplier_Controller();
        Supplier supplier;
        public frmInsertUpdateSupplier(Supplier supplier)
        {
            InitializeComponent();

            txtId.Enabled = false;

            this.supplier = supplier;
            txtEmail.Text = supplier.email;
            txtId.Text = supplier.id;
            txtName.Text = supplier.name;
            txtPhone.Text = supplier.phone.ToString();


        }

        public frmInsertUpdateSupplier()
        {
            InitializeComponent();
        }

        //method to load the supplier data into the form
        

        // Define a custom event
        public event EventHandler DataChanged;

        // Method to raise the event
        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

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
            if (!long.TryParse(txtPhone.Text, out long phone) || txtPhone.Text.Length < 8)
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
                    phone = phone,
                    state = "Activo"
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;

        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            ValidateAndSubmit();
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
