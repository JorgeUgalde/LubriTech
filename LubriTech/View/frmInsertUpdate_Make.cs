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
    public partial class frmInsertUpdate_Make : Form
    {
        private Make make = null;
        public frmInsertUpdate_Make()
        {
            InitializeComponent();
        }

        public frmInsertUpdate_Make(Make make)
        {
            InitializeComponent();
            this.make = make;
            txtName.Text = make.Name;
            cbState.SelectedIndex = cbState.FindStringExact(make.State);
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
            if (make == null)
            {
                make = new Make();
            }

            make.Name = txtName.Text;
            make.State = cbState.Text;

            if (new Make_Controller().upsertMake(make))
            {
                MessageBox.Show("Marca registrada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDataChanged(EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar la marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmInsertUpdate_Make_Load(object sender, EventArgs e)
        {

        }
    }
}
