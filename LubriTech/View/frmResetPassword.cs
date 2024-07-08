using LubriTech.Controller;
using LubriTech.Model.User_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmResetPassword : Form
    {
        User user;
        private string verificationCode;
        public frmResetPassword()
        {
            InitializeComponent();
            user = new User();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("Por favor llene todos los campos", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (verificationCode == null)
                {

                    if (user == null)
                    {
                        user = new User();
                    }

                    user.email = txtEmail.Text;


                    if (new User_Controller().Validation(user) != null)
                    {
                        verificationCode = GenerateVerificationCode();
                        
                        SendVerificationEmail(user.email, verificationCode);
                        new User_Controller().Reset(user, verificationCode);

                        MessageBox.Show("Por favor revise su correo", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No existe ningun : " + user.email, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {


                throw;
            }
        }

        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void SendVerificationEmail(string email, string code)
        {
            try
            {
                MailAddress addressFrom = new MailAddress("soportelubritech@gmail.com", "LubriTech");
                MailAddress addressTo = new MailAddress(email);
                MailMessage message = new MailMessage(addressFrom, addressTo)
                {
                    IsBodyHtml = true,
                    Body = @"
                    <html>
                        <head>
                            <style>
                                body {
                                    font-family: Arial, sans-serif;
                                    background-color: #f5f5f5;
                                    margin: 0;
                                    padding: 0;
                                }
                                .container {
                                    max-width: 600px;
                                    margin: auto;
                                    padding: 20px;
                                    background-color: #ffffff;
                                    border-radius: 8px;
                                    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                                }
                                .header {
                                    background-color: #03264D;
                                    color: #ffffff;
                                    text-align: center;
                                    padding: 10px;
                                    border-radius: 8px 8px 0 0;
                                }
                                .content {
                                    padding: 20px;
                                }
                                .footer {
                                    text-align: center;
                                    margin-top: 20px;
                                    color: #777777;
                                }
                            </style>
                        </head>
                        <body>
                            <div class='container'>
                                <div class='header'>
                                    <h2>Restablecimiento de contraseña - LubriTech</h2>
                                </div>
                                <div class='content'>
                                    <p>Hola,</p>
                                    <p>Recientemente solicitaste restablecer la contraseña de tu cuenta en LubriTech. A continuación, te proporcionamos tu nueva contraseña temporal:</p>
                                    <p style='font-size: 18px; font-weight: bold;'>Nueva contraseña: <span style='color: #000000;'>" + code + @"</span></p>
                                    <p>Te recomendamos cambiar esta contraseña temporal por una nueva tan pronto como sea posible.</p>
                                    <p>Gracias por confiar en LubriTech.</p>
                                </div>
                                <div class='footer'>
                                    <p>Atentamente,</p>
                                    <p>El equipo de LubriTech</p>
                                </div>
                            </div>
                        </body>
                      </html>"
                };
                message.Subject = "Restablecer Contraseña";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("soportelubritech@gmail.com", "puux hwyd enia dmrr")
                };
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
