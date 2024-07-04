using LubriTech.Controller;
using LubriTech.Model.Appointment_Information;
using LubriTech.Model.Branch_Information;
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

namespace LubriTech.View.Appointment_View
{
    public partial class frmInsertUpdate_Appointment : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Appointment appointment = new Appointment();
        public frmInsertUpdate_Appointment(Appointment appointment)
        {
            InitializeComponent();
            try
            {
                this.appointment = appointment;

                txtDateTime.Text = appointment.AppointmentDate.ToString();
                cbState.Text = appointment.State;
                loadBranches(appointment.branch);

                txtName.Text = appointment.client.FullName;
                txtClientID.Text = appointment.client.Id;

                if (appointment.client.MainPhoneNum != null )                
                    txtPhone.Text = appointment.client.MainPhoneNum.ToString();

                if (appointment.Vehicle != null)
                {
                    txtPlate.Text = appointment.Vehicle.LicensePlate;
                    txtModel.Text = appointment.Vehicle.Model.ToString();
                    txtEngine.Text = appointment.Vehicle.EngineType.ToString();
                }
                if (appointment.Description != null)
                    txtDescription.Text = appointment.Description;                
            }
            catch (Exception)
            {

                throw;
            }          

        }

        private void loadBranches(Branch branch )
        {
            cbBranch.DataSource = new Branch_Controller().getAll();
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
            cbBranch.SelectedValue = branch.Id;
        }

        public event EventHandler DataChanged;

        /// <summary>
        /// Invoca el evento DataChanged para notificar a los suscriptores de que los datos han cambiado.
        /// </summary>
        /// <param name="e">Argumentos del evento.</param>
        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }


        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            appointment.State = cbState.Text;
            appointment.Description = txtDescription.Text;
            if (new Appointment_Controller().UpsertAppointment(appointment))
            {
                MessageBox.Show("Appointment saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDataChanged(EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error saving appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
