using LubriTech.Controller;
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

namespace LubriTech.View
{
    public partial class frmInsertUpdate_Schedule : Form
    {
        Schedule schedule;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public frmInsertUpdate_Schedule()
        {
            InitializeComponent();
            this.schedule = new Schedule();
            cbState.SelectedIndex = 0;
            load_Branches();
        }

        public frmInsertUpdate_Schedule(Branch branch)
        {
            InitializeComponent();
            this.schedule = new Schedule();
            load_Branches();
            cbState.Text = branch.State;
            cbBranch.Text = branch.ToString();
        }


        public frmInsertUpdate_Schedule(Schedule schedule)
        {
            InitializeComponent();

            this.schedule = schedule;
            load_Branches();

            cbBranch.Text = schedule.Branch.Name;
            txtTitle.Text = schedule.Title;
            cbStartHour.Text = schedule.StartHour.ToString(@"hh");
            cbStartMinute.Text = schedule.StartHour.ToString(@"mm");
            cbEndHour.Text = schedule.EndHour.ToString(@"hh");
            cbEndMinute.Text = schedule.EndHour.ToString(@"mm");
            cbState.Text = schedule.State;

            int hours = schedule.appointmentDuration;
            int durationHours = hours / 60;
            int durationMinutes = hours % 60;

            cbDurationHours.Text = durationHours == 0 ? "00" : durationHours.ToString();
            cbDurationMinuts.Text = durationMinutes == 0 ? "00" : durationMinutes.ToString();
        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void load_Branches()
        {
            cbBranch.Items.Clear();
            cbBranch.DataSource = new Branch_Controller().getAll();
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
            if (cbBranch.Text == "")
                cbBranch.SelectedIndex = 0;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnConfirm_Click(object sender, EventArgs e)
            {
            try
            {
                string startHour = cbStartHour.Text;
                string startMinute = cbStartMinute.Text;
                string endHour = cbEndHour.Text;
                string endMinute = cbEndMinute.Text;
                string durationMinutes = cbDurationMinuts.Text;
                string durationHours = cbDurationHours.Text;


                schedule.Branch = (Branch)cbBranch.SelectedItem;
                schedule.Title = txtTitle.Text;
                if (cbStartHour.Text == "")
                    startHour = "00";
                if (cbStartMinute.Text == "")
                    startMinute = "00";
                if (cbEndHour.Text == "")
                    endHour = "00";
                if (cbEndMinute.Text == "")
                    endMinute = "00";
                if (cbDurationMinuts.Text == "")
                    durationMinutes = "00";
                if (cbDurationHours.Text == "")
                    durationHours = "00";

                schedule.StartHour = TimeSpan.Parse(startHour + ":" + startMinute);
                schedule.EndHour = TimeSpan.Parse(endHour + ":" + endMinute);
                schedule.appointmentDuration = Convert.ToInt32(durationHours) * 60 + Convert.ToInt32(durationMinutes);
                schedule.State = cbState.Text;


                if (new Schedule_Controller().UpSert(schedule))
                {
                    OnDataChanged(EventArgs.Empty);
                    MessageBox.Show("Horario guardado exitosamente", "Horario Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar el horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
