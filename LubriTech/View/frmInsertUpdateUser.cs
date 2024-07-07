using LubriTech.Controller;
using System;
using System.Windows.Forms;
using LubriTech.Model.User_Information;
using System.Collections.Generic;
using LubriTech.Model.Branch_Information;
using System.Drawing;

namespace LubriTech.View
{
    public partial class frmInsertUpdateUser : Form
    {
        private List<Branch> branches;

        private User user;
        public frmInsertUpdateUser()
        {
            InitializeComponent();
            LoadBranches();
            user = new User();

        }
        public frmInsertUpdateUser(int mode)
        {
            InitializeComponent();
            LoadBranches();

            if (mode == 0)
            {
                panelBorder.BackColor = Color.FromArgb(27, 27, 27);
                btnAdd.BackColor = Color.FromArgb(27, 27, 27);
                btnClose.BackColor = Color.FromArgb(27, 27, 27);
                btnConfirm.BackColor = Color.FromArgb(27, 27, 27);
                btnAdd.Visible = false;
                txtNewPass.Visible = false;
                lblNewPass.Visible=false;
            }
            

        }

        private void LoadBranches()
        {
            branches = new Branch_Controller().getAll();
            setComboBoxBranch();
            user = new User(); 

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

                //bool isNewUser = new User_Controller().GetUser(user) == null;
                User existingUser = new User_Controller().GetUser(user);

                if (existingUser == null && string.IsNullOrEmpty(txtNewPass.Text))
                {
                    new User_Controller().Upsert(user, newPassword);
                    MessageBox.Show("Usuario creado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
 
                }
                else
                {
                    if (existingUser == null)
                    {
                        MessageBox.Show("Revise que los datos sean correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtNewPass.Text))
                        {
                            new User_Controller().Upsert(user, newPassword);
                            MessageBox.Show("La contraseña se cambió con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
