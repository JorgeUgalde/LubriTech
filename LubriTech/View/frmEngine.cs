using iTextSharp.text;
using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Vehicle_Information;
using LubriTech.View.Appointment_View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmEngine : Form
    {
        private List<Engine> engine;
        private Form parentForm;

        private int currentPage = 1;
        private int pageSize = 20; // Puedes ajustar este valor según sea necesario
        private int totalRecords = 0;
        private int totalPages = 0;


        public frmEngine()
        {
            engine = new List<Engine>();
            InitializeComponent();
            load_Engines(null);
        }

        private void frmEngine_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        private void load_Engines(List<Engine> filteredList)
        {
            if (filteredList != null)
            {
                engine = filteredList;
            }
            else
            {
                engine = new Engine_Controller().getAll();
            }

            if (engine.Count == 0)
            {
                MessageBox.Show("No hay motores registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            totalRecords = engine.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            LoadPage();
            SetColumnOrder();
        }

        private void LoadPage()
        {
            int startRecord = (currentPage - 1) * pageSize;
            int endRecord = Math.Min(currentPage * pageSize, totalRecords);

            var pageClients = engine.Skip(startRecord).Take(endRecord - startRecord).ToList();
            dgvEngines.DataSource = pageClients;

            lblPageNumber.Text = $"Página {currentPage} de {totalPages}";
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
                load_Engines(null);
                return;
            }

            // Filtrar la lista de tipos de motor
            var filteredList = engine.Where(p =>
                p.Id.ToString().Contains(filterValue) ||
                p.EngineType.ToLower().Contains(filterValue) ||
                p.State.ToLower().Contains(filterValue)
            ).ToList();

            currentPage = 1;
            totalRecords = filteredList.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            
            if (filteredList.Count == 0)
            {
                load_Engines(null);
                return;
            }
            load_Engines(filteredList);
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Engines(null);
        }

        private void SetColumnOrder()
        {
            dgvEngines.Columns["Id"].Visible = false;
            dgvEngines.Columns["EngineType"].HeaderText = "Tipo Motor";
            dgvEngines.Columns["State"].HeaderText = "Estado";

            dgvEngines.Columns["Id"].DisplayIndex = 0;
            dgvEngines.Columns["EngineType"].DisplayIndex = 1;
            dgvEngines.Columns["State"].DisplayIndex = 2;
        }

        private void btnAddEngine_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Engine frmUpsertEngine = new frmInsertUpdate_Engine();
            this.WindowState = FormWindowState.Normal;
            frmUpsertEngine.MdiParent = this.MdiParent;
            frmUpsertEngine.DataChanged += ChildFormDataChangedHandler;
            frmUpsertEngine.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void dgvEngines_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int engineId = Convert.ToInt32(dgvEngines.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                List<Engine> engines = new Engine_Controller().getAll();
                Engine selectedEngine = engines.FirstOrDefault(engine => engine.Id == engineId);

                if (selectedEngine != null)
                {
                    frmInsertUpdate_Engine frmInsertEngine = new frmInsertUpdate_Engine(selectedEngine);
                    this.WindowState = FormWindowState.Normal;
                    frmInsertEngine.MdiParent = this.MdiParent;
                    frmInsertEngine.DataChanged += ChildFormDataChangedHandler;
                    frmInsertEngine.Show();

                }
            }
        }

    

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPage();
            }
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage();
            }
        }
    }
}
