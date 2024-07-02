using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LubriTech.View
{

    public partial class frmInsertUpdate_Branch : Form
    {


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Branch branch;



        public frmInsertUpdate_Branch()
        {
            InitializeComponent();
            branch = new Branch();
            cbState.SelectedIndex = 0;
            load_Schedules();
        }

        public frmInsertUpdate_Branch(Branch branch)
        {

            InitializeComponent();
            this.branch = branch;

            load_Schedules();

            txtName.Text = branch.Name;
            txtAddress.Text = branch.Address;
            txtPhone.Text = branch.Phone.ToString();
            txtEmail.Text = branch.Email;
            cbState.Text = branch.State;
        }

        private void load_Schedules()
        {
            cbSchedule.DataSource = null;
            List <Schedule> schedules = new Schedule_Controller().loadAll(branch.Id);
            cbSchedule.DataSource = schedules;
            cbSchedule.DisplayMember = "Title";
            cbSchedule.ValueMember = "ScheduleID";

            // select the schedule with the state "Activo"
            Schedule activeSchedule = schedules.Find(schedule => schedule.State == "Activo");
            if (activeSchedule != null)
            {
                cbSchedule.SelectedValue = activeSchedule.ScheduleID;
            }
        }



        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }



        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text)
                || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPhone.Text)
                || string.IsNullOrEmpty(cbState.Text))

                {
                    MessageBox.Show("Por favor llene todos los campos", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                branch.Name = txtName.Text;
                branch.Address = txtAddress.Text;
                branch.Phone = Convert.ToInt64(txtPhone.Text);
                branch.Email = txtEmail.Text;
                branch.State = cbState.Text;



                Schedule schedule = (Schedule)cbSchedule.SelectedItem;
                if (schedule != null)
                {
                    schedule.State = "Activo";
                    new Schedule_Controller().UpSert(schedule);
                }
                
                if (new Branch_Controller().Upsert(branch) != -1 )
                {
                    MessageBox.Show("Sucursal registrada con exito", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnDataChanged(EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar la sucursal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                throw;
            }
            

        }

        private void btnAddSchedulle_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Debe indicar el nombre de la sucrusal primero", "Atención!" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (branch.Id <= 0 )
            {
                branch.Name = txtName.Text;

                branch.State = cbState.Text;

                branch.Id = new Branch_Controller().Upsert(branch);
            }

           


            frmInsertUpdate_Schedule upsertSchedule = new frmInsertUpdate_Schedule(branch);
            upsertSchedule.MdiParent = this.MdiParent;
            upsertSchedule.DataChanged += (s, ev) => load_Schedules();
            upsertSchedule.Show();
        }
    }
}
