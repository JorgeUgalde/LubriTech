using LubriTech.Controller;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_CarModel : Form
    {
        private CarModel model = null;
        public frmInsertUpdate_CarModel()
        {
            InitializeComponent();
        }

        public frmInsertUpdate_CarModel(CarModel model)
        {
            InitializeComponent();
            this.model = model;
            txtName.Text = model.Name;
            cbState.SelectedIndex = cbState.FindStringExact(model.State);
        }

        // Define a custom event
        public event EventHandler DataChanged;

        // Method to raise the event
        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbState.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (model == null)
            {
                model = new CarModel();
            }

            model.Name = txtName.Text;
            model.State = cbState.Text;

            if (new CarModel_Controller().upsert(model))
            {
                MessageBox.Show("Modelo registrad0", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDataChanged(EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el modelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmInsertUpdate_CarModel_Load(object sender, EventArgs e)
        {

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblForm_Click(object sender, EventArgs e)
        {

        }
    }
}
