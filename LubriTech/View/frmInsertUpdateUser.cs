using LubriTech.Controller;
using System;
using System.Windows.Forms;
using LubriTech.Model.User_Information;
using System.Collections.Generic;
using LubriTech.Model.Branch_Information;
using System.Drawing;
using System.Runtime.InteropServices;

namespace LubriTech.View
{
    public partial class frmInsertUpdateUser : Form
    {
        private List<Branch> branches;

        private User existingUser;
        private User user;
        public frmInsertUpdateUser(User paramUser)
        {
            InitializeComponent();
            LoadBranches();
            this.user = new User();
            existingUser = paramUser;
            txtEmail.Text = existingUser.email;
            setComboBoxBranch();
            cbBranch.SelectedValue = existingUser.branchID;
        }
        public frmInsertUpdateUser(int mode)
        {
            InitializeComponent();
            LoadBranches();
            user = new User();

            if (mode == 0)
            {
                btnAdd.Visible = false;
                txtNewPass.Visible = false;
                lblNewPass.Visible=false;
            }
            

        }

        private void LoadBranches()
        {

            branches = new Branch_Controller().getAll();
            setComboBoxBranch();
            existingUser = new User();

        }

        private void setComboBoxBranch()
        {
            cbBranch.DataSource = null;
            cbBranch.DataSource = branches;
            cbBranch.ValueMember = "Id";
            cbBranch.DisplayMember = "Name";
            cbBranch.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(cbBranch.Text))
                {
                    MessageBox.Show("Por favor llene todos los campos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newPassword = null;
                if (!string.IsNullOrEmpty(txtNewPass.Text))
                {
                    newPassword = txtNewPass.Text;
                }

                user.email = txtEmail.Text;
                user.password = txtPassword.Text;

                Branch selectedBranch = (Branch)cbBranch.SelectedItem;
                user.branchID = selectedBranch.Id;

                User isNewUser = new User_Controller().GetUser(user);

                if (user == null && string.IsNullOrEmpty(txtNewPass.Text))
                {
                    new User_Controller().Upsert(user, newPassword);
                    MessageBox.Show("Usuario creado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
 
                }
                else
                {
                    if (user == null)
                    {
                        MessageBox.Show("Revise que los datos sean correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtNewPass.Text))
                        {
                            new User_Controller().Upsert(user, newPassword);
                            existingUser.email = user.email;
                            existingUser.branchID = user.branchID;
                            MessageBox.Show("Los datos se actualizaron con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("El usuario que intenta crear ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                }
            }
            catch (Exception)
            {


                throw;
            }


        }


        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            LoadBranches();
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            frmInsertUpdate_Branch frmInsertUpdate_Branch = new frmInsertUpdate_Branch();
            frmInsertUpdate_Branch.MdiParent = this.MdiParent;
            frmInsertUpdate_Branch.DataChanged += ChildFormDataChangedHandler;
            frmInsertUpdate_Branch.Show();
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
