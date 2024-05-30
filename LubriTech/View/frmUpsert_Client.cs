using LubriTech.Model.Client_Information;
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
    public partial class frmUpsert_Client : Form
    {
        public frmUpsert_Client()
        {
            InitializeComponent();
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            try
            {

                //if (!string.IsNullOrEmpty(this.txtFullName.Text) ||
                //    !string.IsNullOrEmpty(this.txtMainPhone.Text) ||
                //    !string.IsNullOrEmpty(this.txtAdditionalPhone.Text) ||
                //    !string.IsNullOrEmpty(this.txtEmail.Text) ||
                //    !string.IsNullOrEmpty(this.txtAddresse.Text))
                //{
                    
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
    }
}
