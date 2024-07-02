using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LubriTech.View
{

    public partial class frmInsertUpdate_Branch : Form
    {


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Branch branch;


        public frmInsertUpdate_Branch()
        {
            InitializeComponent();

            branch = new Branch();
        }

        public frmInsertUpdate_Branch(Branch branch)
        {
            InitializeComponent();
            this.branch = branch;
            txtName.Text = branch.Name;
            txtAddress.Text = branch.Address;
            txtPhone.Text = branch.Phone.ToString();
            txtEmail.Text = branch.Email;
            cbState.Text = branch.State;
        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }



        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text)
                || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPhone.Text)
                || string.IsNullOrEmpty(cbState.Text))

                {
                    MessageBox.Show("Por favor llene todos los campos", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                branch.Name = txtName.Text;
                branch.Address = txtAddress.Text;
                branch.Phone = Convert.ToInt64(txtPhone.Text);
                branch.Email = txtEmail.Text;
                branch.State = cbState.Text;

                if (new Branch_Controller().Upsert(branch))
                {
                    MessageBox.Show("Sucursal registrada con exito", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnDataChanged(EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar la sucursal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                
                throw;
            }
            

        }
    }
}
