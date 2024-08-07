﻿using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.User_Information;
using LubriTech.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech
{
    public partial class frmLogin : Form
    {
        private bool isLogged = false;
        public static int branch = -1;
        public static User user;
        public frmLogin()
        {
            InitializeComponent();
            user = new User();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            isLogged = ValidateAndLogin();
        }

        public bool IsLogged()
        {
            return isLogged;
        }
        private bool ValidateAndLogin()
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

                u = uc.GetUser(u);
                if (u == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                    return false;
                }
                user.email = u.email;
                user.branchID = u.branchID;
                branch = u.branchID;
                this.Close();
                return true;                
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                return false;
            }
        }


        private bool IsValidEmail(string email)
        {
            // Regular expression to match a complete email or just the username part
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_MouseEnter(object sender, EventArgs e)
        {
            //change background color to focus the textbox
            txtEmail.BackColor = Color.FromArgb(225, 225, 225);
        }

        private void txtEmail_MouseLeave(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.FromArgb(237, 237, 237);
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.FromArgb(225, 225, 225);
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.FromArgb(237, 237, 237);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            int mode = 0;
            frmInsertUpdateUser frmInsert_User = new frmInsertUpdateUser(mode);
            frmInsert_User.Show();
        }

        private void lblRecoverPassword_Click(object sender, EventArgs e)
        {
            frmResetPassword frmResetPassword = new frmResetPassword();
            frmResetPassword.Show();
        }
    }
}
