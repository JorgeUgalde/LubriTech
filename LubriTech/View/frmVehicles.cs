using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LubriTech.Controller;

namespace LubriTech.View
{
    public partial class frmVehicles : Form
    {
        public frmVehicles()
        {
            InitializeComponent();
        }

        private void frmVehicles_Load(object sender, EventArgs e)
        {
            Vehicle_Controller vehicleController = new Vehicle_Controller();
            dgvVehicles.DataSource = vehicleController.getAll();


        }

        private void btnNewVehicle_Click(object sender, EventArgs e)
        {
            frmNewVehicle frmNewVehicle = new frmNewVehicle();
            frmNewVehicle.ShowDialog();
        }
    }
}
