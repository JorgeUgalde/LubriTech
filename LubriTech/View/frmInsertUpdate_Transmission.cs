using LubriTech.Controller;
using LubriTech.Model.Vehicle_Information;
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
    public partial class frmInsertUpdate_Transmission : Form
    {
        private Transmission transmissions = null;
        public frmInsertUpdate_Transmission()
        {
            InitializeComponent();
        }

        public frmInsertUpdate_Transmission(Transmission transmission, string action)
        {
            InitializeComponent();
            this.transmissions = transmission;
            txtTransmissionType.Text = transmission.TransmissionType;
            cbState.SelectedIndex = cbState.FindStringExact(transmission.State);

            if (action == "Details")
            {
                txtTransmissionType.Enabled = false;
                cbState.Enabled = false;

                txtTransmissionType.BackColor = Color.FromArgb(249, 252, 255);
                cbState.BackColor = Color.FromArgb(249, 252, 255);

                btnConfirm.Hide();
            }
        }

        // Define a custom event
        public event EventHandler DataChanged;

        // Method to raise the event
        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void frmInsertUpdate_Transmission_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtTransmissionType.Text == "")
            {
                MessageBox.Show("Debe ingresar un tipo de transmisión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbState.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (transmissions == null)
            {
                transmissions = new Transmission();
            }

            transmissions.TransmissionType = txtTransmissionType.Text;
            transmissions.State = cbState.Text;

            if (new Transmission_Controller().upsert(transmissions))
            {
                MessageBox.Show("Tipo de transmisión registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDataChanged(EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el tipo de transmisión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
