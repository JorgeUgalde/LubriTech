using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmSchedule : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        List <Schedule> schedules = new List<Schedule>();
        public frmSchedule()
        {
            InitializeComponent();
            load_Schedules(null);
        }

        private void load_Schedules(List<Schedule> filteredList)
        {
            if (filteredList != null)
            {
                if(filteredList.Count > 0)
                {
                    dgvSchedules.DataSource = filteredList;
                }
                else
                {
                    dgvSchedules.DataSource = schedules;
                }
            }
            else
            {
                schedules = new Schedule_Controller().loadAll();
                if (schedules == null)
                {
                    MessageBox.Show("No hay horarios registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvSchedules.DataSource = schedules;
            }

            dgvSchedules.Columns["ScheduleID"].Visible = false;
            dgvSchedules.Columns["AppointmentDuration"].Visible = false;
            dgvSchedules.Columns["Branch"].HeaderText = "Sucursal";
            dgvSchedules.Columns["Title"].HeaderText = "Titulo";
            dgvSchedules.Columns["StartHour"].HeaderText = "Hora de Inicio";
            dgvSchedules.Columns["EndHour"].HeaderText = "Hora de Salida";

            SetColumnOrder();
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgvSchedules,
                new object[] { true });
        }

        private void SetColumnOrder()
        {
            dgvSchedules.Columns["Branch"].DisplayIndex = 0;
            dgvSchedules.Columns["Title"].DisplayIndex = 1;
            dgvSchedules.Columns["StartHour"].DisplayIndex = 2;
            dgvSchedules.Columns["EndHour"].DisplayIndex = 3;
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Schedules(null);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            var filteredList = schedules.Where(p =>
                           p.Branch.Name.ToLower().Contains(filterValue) ||
                           p.Title.ToLower().Contains(filterValue)
                           ).ToList();

            dgvSchedules.DataSource = null;
            load_Schedules(filteredList);
        }

        private void dgvSchedules_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int scheduleID = Convert.ToInt32(dgvSchedules.Rows[e.RowIndex].Cells["ScheduleID"].Value);

                Schedule schedule = schedules.Where(p => p.ScheduleID == scheduleID).FirstOrDefault();
                frmInsertUpdate_Schedule frmUpsert_Schedule = new frmInsertUpdate_Schedule(schedule);

                frmUpsert_Schedule.MdiParent = this.MdiParent;
                frmUpsert_Schedule.DataChanged += ChildFormDataChangedHandler;
                frmUpsert_Schedule.Show();
            }

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Schedule frmUpsert_Schedule = new frmInsertUpdate_Schedule();
            frmUpsert_Schedule.MdiParent = this.MdiParent;
            frmUpsert_Schedule.DataChanged += ChildFormDataChangedHandler;
            frmUpsert_Schedule.Show();
        }

        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
