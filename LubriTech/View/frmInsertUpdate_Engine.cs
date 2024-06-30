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
using System.Xml.Linq;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_Engine : Form
    {
        private Engine engine = null;
        public frmInsertUpdate_Engine()
        {
            InitializeComponent();
        }

        public frmInsertUpdate_Engine(Engine engine, string action)
        {
            InitializeComponent();
            this.engine = engine;
            txtEngineType.Text = engine.EngineType;
            cbState.SelectedIndex = cbState.FindStringExact(engine.State);

            if (action == "Details")
            {
                txtEngineType.Enabled = false;
                cbState.Enabled = false;

                txtEngineType.BackColor = Color.FromArgb(249, 252, 255);
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

        private void frmInsertUpdate_Engine_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            if (txtEngineType.Text == "")
            {
                MessageBox.Show("Debe ingresar un tipo de motor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbState.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (engine == null)
            {
                engine = new Engine();
            }

            engine.EngineType = txtEngineType.Text;
            engine.State = cbState.Text;

            if (new Engine_Controller().upsert(engine))
            {
                MessageBox.Show("Tipo de motor registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDataChanged(EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el tipo de motor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void pbMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
