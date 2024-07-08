using iTextSharp.text;
using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        private int currentPage = 1;
        private int pageSize = 20; // Puedes ajustar este valor según sea necesario
        private int totalRecords = 0;
        private int totalPages = 0;

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
                schedules = filteredList;
            }
            else
            {
                schedules = new Schedule_Controller().loadAll(null);
                if (schedules == null)
                {
                    MessageBox.Show("No hay horarios registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            totalRecords = schedules.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            LoadPage();

            dgvSchedules.Columns["ScheduleID"].Visible = false;
            dgvSchedules.Columns["AppointmentDuration"].Visible = false;
            dgvSchedules.Columns["Branch"].HeaderText = "Sucursal";
            dgvSchedules.Columns["Title"].HeaderText = "Titulo";
            dgvSchedules.Columns["StartHour"].HeaderText = "Hora de Inicio";
            dgvSchedules.Columns["EndHour"].HeaderText = "Hora de Salida";
            dgvSchedules.Columns["State"].HeaderText = "Estado";
        }

        private void LoadPage()
        {
            int startRecord = (currentPage - 1) * pageSize;
            int endRecord = Math.Min(currentPage * pageSize, totalRecords);

            var pageClients = schedules.Skip(startRecord).Take(endRecord - startRecord).ToList();
            dgvSchedules.DataSource = pageClients;

            lblPageNumber.Text = $"Página {currentPage} de {totalPages}";
        }

        private void SetColumnOrder()
        {
            dgvSchedules.Columns["Branch"].DisplayIndex = 0;
            dgvSchedules.Columns["Title"].DisplayIndex = 1;
            dgvSchedules.Columns["StartHour"].DisplayIndex = 2;
            dgvSchedules.Columns["EndHour"].DisplayIndex = 3;
            dgvSchedules.Columns["State"].DisplayIndex = 4;
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
            if (filterValue == "")
            {
                load_Schedules(null);
                return;
            }
            var filteredList = schedules.Where(p =>
                           p.Branch.Name.ToLower().Contains(filterValue) ||
                           p.Title.ToLower().Contains(filterValue)
                           ).ToList();

            currentPage = 1;
            totalRecords = filteredList.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (filteredList.Count == 0)
            {
                load_Schedules(null);
                return;
            }


            load_Schedules(filteredList);
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
            this.WindowState = FormWindowState.Normal;
            frmUpsert_Schedule.MdiParent = this.MdiParent;
            frmUpsert_Schedule.DataChanged += ChildFormDataChangedHandler;
            frmUpsert_Schedule.Show();
        }

        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void dgvSchedules_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int scheduleID = Convert.ToInt32(dgvSchedules.Rows[e.RowIndex].Cells["ScheduleID"].Value);

                Schedule schedule = schedules.Where(p => p.ScheduleID == scheduleID).FirstOrDefault();
                frmInsertUpdate_Schedule frmUpsert_Schedule = new frmInsertUpdate_Schedule(schedule);
                this.WindowState = FormWindowState.Normal;
                frmUpsert_Schedule.MdiParent = this.MdiParent;
                frmUpsert_Schedule.DataChanged += ChildFormDataChangedHandler;
                frmUpsert_Schedule.Show();
            }
        }

        private void dgvSchedules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPage();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage();
            }
        }
    }
}
