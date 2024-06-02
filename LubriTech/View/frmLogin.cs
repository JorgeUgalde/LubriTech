using LubriTech.Controller;
using LubriTech.Model.User_Information;
using LubriTech.View;
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

namespace LubriTech
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            ValidateAndLogin();
        }
        private void ValidateAndLogin()
        {
            bool isValid = true;

            // Validate Email (simple format check)
            if (!IsValidEmail(txtEmail.Text))
            {
                isValid = false;
            }

            // Validate Password (not empty and minimum length)
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                isValid = false;
            }

            if (isValid)
            {
                User_Controller uc = new User_Controller();
                User u = new User(txtEmail.Text, txtPassword.Text);

                if (uc.GetUser(u) == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                    return;
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }


        private bool IsValidEmail(string email)
        {
            // Regular expression to match a complete email or just the username part
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

    }
}
