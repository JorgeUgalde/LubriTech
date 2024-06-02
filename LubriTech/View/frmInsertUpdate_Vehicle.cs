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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using LubriTech.Model.Product_Information;
using LubriTech.Model.Supplier_Information;
using LubriTech.Model.Vehicle_Information;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_Vehicle : Form
    {
        public frmInsertUpdate_Vehicle()
        {
            InitializeComponent();
        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        public frmInsertUpdate_Vehicle(Vehicle vehicle)
        {
            InitializeComponent();

            tbClientId.Text = vehicle.Client.Id;
            tbBrand.Text = vehicle.Brand;
            tbModel.Text = vehicle.Model;
            tbLicensePlate.Text = vehicle.LicensePlate;
            tbYear.Text = vehicle.Year.ToString();
            tbMileage.Text = vehicle.Mileage.ToString();
            tbEngine.Text = vehicle.Engine;
            cbTransmission.Text = vehicle.Transmission;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbClientId.Text.Trim() == ""
                || tbBrand.Text.Trim() == ""
                || tbModel.Text.Trim() == ""
                || tbLicensePlate.Text.Trim() == ""
                || tbYear.Text.Trim() == ""
                || tbMileage.Text.Trim() == ""
                || tbEngine.Text.Trim() == ""
                || cbTransmission.Text.Trim() == "")
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
            else
            {
                Vehicle_Controller vehicleController = new Vehicle_Controller();
                Vehicle vehicle = new Vehicle();
                vehicle.Client = vehicleController.getClient(tbClientId.Text.Trim());
                vehicle.Brand = tbBrand.Text.Trim();
                vehicle.Model = tbModel.Text.Trim();
                vehicle.LicensePlate = tbLicensePlate.Text.Trim();
                vehicle.Year = Convert.ToInt32(tbYear.Text.Trim());
                vehicle.Mileage = Convert.ToInt32(tbMileage.Text.Trim());
                vehicle.Engine = tbEngine.Text.Trim();
                vehicle.Transmission = cbTransmission.Text.Trim();

                if (vehicleController.upsert(vehicle))
                {
                    OnDataChanged(EventArgs.Empty);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Product not inserted");
                }

                MessageBox.Show("Se realizó la acción satisfactoriamente");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
