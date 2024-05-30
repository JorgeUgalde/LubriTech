using LubriTech.Controller;
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
    public partial class frmClients : Form
    {
        public frmClients()
        {
            InitializeComponent();
        }

        private void frmClients_Load(object sender, EventArgs e)
        {
            Clients_Controller clients_Controller = new Clients_Controller();
            dgvClients.DataSource = clients_Controller.getAll();
        }

       
    }
}
