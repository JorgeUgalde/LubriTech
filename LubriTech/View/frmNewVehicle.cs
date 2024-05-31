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
    public partial class frmNewVehicle : Form
    {
        public frmNewVehicle()
        {
            InitializeComponent();
            List<string> options = new List<string>()
            {
                "Automático",
                "Manual"
            };

            cbTransmission.DataSource = options;
        }

        private void btnNewVehicle_Click(object sender, EventArgs e)
        {
            Vehicle_Controller vehicleController = new Vehicle_Controller();
            string clientId = tbClientId.Text.Trim();
            string brand = tbBrand.Text.Trim();
            string model = tbModel.Text.Trim();
            string licensePlate = tbLicensePlate.Text.Trim();
            int year = Convert.ToInt32(tbYear.Text.Trim());
            double mileage = Convert.ToDouble(tbMileage.Text.Trim());
            string engine = tbEngine.Text.Trim();
            string transmission = cbTransmission.ValueMember;
            vehicleController.addVehicle(licensePlate, engine, mileage, brand, model, year, transmission, clientId);
            tbClientId.Text = "";
            tbBrand.Text = "";
            tbModel.Text = "";
            tbLicensePlate.Text = "";
            tbYear.Text = "";
            tbMileage.Text = "";
            tbEngine.Text = "";
            cbTransmission.ValueMember = default;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
