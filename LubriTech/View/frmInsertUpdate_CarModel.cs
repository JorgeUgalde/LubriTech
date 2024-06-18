﻿using LubriTech.Controller;
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

        private void frmInsertUpdate_Make_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}