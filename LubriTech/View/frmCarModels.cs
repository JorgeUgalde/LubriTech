using iTextSharp.text;
using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmCarModels : Form
    {
        int currentPage = 1;
        int pageSize = 20; // Puedes ajustar este valor según sea necesario
        int totalRecords = 0;
        int totalPages = 0;


        private List<CarModel> models;
        public frmCarModels()
        {
            InitializeComponent();
            load_CarModels(null);            
        }


        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_CarModels(null);
        }

        private void load_CarModels(List<CarModel> filteredList)
        {

            if (filteredList != null)
            {
                models = filteredList;

            }
            else
            {
                models = new CarModel_Controller().getAll();
            }
            if (models.Count == 0)
            {
                MessageBox.Show("No hay modelos registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            totalRecords = models.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            LoadPage();
            dgvCarModels.Columns["Id"].Visible = false;
            dgvCarModels.Columns["Make"].HeaderText = "Marca";
            dgvCarModels.Columns["Name"].HeaderText = "Nombre";
            dgvCarModels.Columns["State"].HeaderText = "Estado";
            SetColumnOrder();


        }

        private void LoadPage()
        {
            int startRecord = (currentPage - 1) * pageSize;
            int endRecord = Math.Min(currentPage * pageSize, totalRecords);

            var pageClients = models.Skip(startRecord).Take(endRecord - startRecord).ToList();
            dgvCarModels.DataSource = pageClients;

            lblPageNumber.Text = $"Página {currentPage} de {totalPages}";
        }

        private void SetColumnOrder()
        {
            
            dgvCarModels.Columns["Name"].DisplayIndex = 0;
            dgvCarModels.Columns["Make"].DisplayIndex = 1;
            dgvCarModels.Columns["State"].DisplayIndex = 2;
        }

        

        private void btnAddCarModel_Click(object sender, EventArgs e)
        {
            frmUpsert_Make_Model frmUpsertCarModel = new frmUpsert_Make_Model("Insert", "Model");
            frmUpsertCarModel.MdiParent = this.MdiParent;
            this.WindowState = FormWindowState.Normal;
            frmUpsertCarModel.DataChanged += ChildFormDataChangedHandler;
            frmUpsertCarModel.Show();

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
                load_CarModels(null);
                return;
            }

            var filteredList = models.Where(p =>
                           p.Name.ToLower().Contains(filterValue) ||
                           p.Make.Name.ToLower().Contains(filterValue) ||
                           p.State.ToLower().Contains(filterValue)
                           ).ToList();


            if (filteredList.Count == 0)
            {
                load_CarModels(null);
                return;
            }
            load_CarModels(filteredList);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmCarModels_Load(object sender, EventArgs e)
        {
            SetColumnOrder();
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

        private void dgvCarModels_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CarModel model = models[e.RowIndex];

            frmUpsert_Make_Model frmUpsertCarModel = new frmUpsert_Make_Model(model, "Modify");
            frmUpsertCarModel.MdiParent = this.MdiParent;
            this.WindowState = FormWindowState.Normal;
            frmUpsertCarModel.DataChanged += ChildFormDataChangedHandler;
            frmUpsertCarModel.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
