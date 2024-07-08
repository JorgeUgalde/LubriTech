using iTextSharp.text;
using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.InventoryManagment_Information;
using LubriTech.Model.PricesList_Information;
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
    public partial class frmPricesList : Form
    {
        private Form parentForm;
        public event Action<PriceList> PriceListSelected;
        private List<PriceList> priceLists;
        private int currentPage = 1;
        private int pageSize = 20; // Puedes ajustar este valor según sea necesario
        private int totalRecords = 0;
        private int totalPages = 0;

        public frmPricesList()
        {
            InitializeComponent();
            priceLists = new PriceList_Controller().getPriceLists();
        }

        public frmPricesList(Form parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        public void LoadPricesList(List<PriceList> filteredList)
        {
            if (filteredList != null)
            {
                    priceLists = filteredList;

            }
            else
            {
                priceLists = new PriceList_Controller().getPriceLists();
                if (priceLists == null)
                {
                    MessageBox.Show("No hay listas de precios registradas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            totalRecords = priceLists.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            LoadPage();
            dgvPricesList.Columns["id"].HeaderText = "Identificación";
            dgvPricesList.Columns["description"].HeaderText = "Descripción";
            dgvPricesList.Columns["state"].HeaderText = "Estado";
            //dgvPricesList.Columns["prices"].Visible = false;

            SetColumnOrder();
        }


        private void LoadPage()
        {
            int startRecord = (currentPage - 1) * pageSize;
            int endRecord = Math.Min(currentPage * pageSize, totalRecords);

            var pageClients = priceLists.Skip(startRecord).Take(endRecord - startRecord).ToList();
            dgvPricesList.DataSource = pageClients;

            lblPageNumber.Text = $"Página {currentPage} de {totalPages}";
        }

        private void SetColumnOrder()
        {
            dgvPricesList.Columns["id"].DisplayIndex = 0;
            dgvPricesList.Columns["description"].DisplayIndex = 1;
            dgvPricesList.Columns["state"].DisplayIndex = 2;
            //dgvPricesList.Columns["prices"].DisplayIndex = 3;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            LoadPricesList(null);
        }

        private void btnAddPricesList_Click(object sender, EventArgs e)
        {
            frmUpsert_PriceList frmUpsert_PriceList = new frmUpsert_PriceList(null);
            this.WindowState = FormWindowState.Normal;
            frmUpsert_PriceList.MdiParent = this.MdiParent;
            frmUpsert_PriceList.DataChanged += ChildFormDataChangedHandler;
            frmUpsert_PriceList.Show();
        }

        private void frmPricesList_Load(object sender, EventArgs e)
        {
            LoadPricesList(null);
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

        private void dgvPricesList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int priceListId = (int)dgvPricesList.Rows[e.RowIndex].Cells["id"].Value;
                PriceList selectedPriceList = new PriceList_Controller().getPriceList(priceListId);

                if (parentForm is frmUpsert_Client)
                {
                    ((frmUpsert_Client)parentForm).PriceListSelected(selectedPriceList);
                }
                else
                {
                    frmUpsert_PriceList frmUpsert_PriceList = new frmUpsert_PriceList(priceListId);
                    this.WindowState = FormWindowState.Normal;
                    frmUpsert_PriceList.MdiParent = this.MdiParent;
                    frmUpsert_PriceList.DataChanged += ChildFormDataChangedHandler;
                    frmUpsert_PriceList.Show();

                }
            }
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
                LoadPricesList(null);
                return;
            }
            // Filtrar la lista de precios
            var filteredList = priceLists.Where(p =>
                p.description.ToLower().Contains(filterValue) ||
                p.state.ToString().ToLower().Contains(filterValue)
            ).ToList();

            if (filteredList.Count == 0)
            {
                LoadPricesList(null);
                return;
            }
            
            LoadPricesList(filteredList);
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
