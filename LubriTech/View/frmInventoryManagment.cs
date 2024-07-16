using iTextSharp.text;
using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.InventoryManagment_Information;
using LubriTech.Model.Vehicle_Information;
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
    public partial class frmInventoryManagment : Form
    {
        private List<InventoryManagment> inventoryManagments;
        private int currentPage = 1;
        private int pageSize = 20; // Puedes ajustar este valor según sea necesario
        private int totalRecords = 0;
        private int totalPages = 0;
        public frmInventoryManagment()
        {
            inventoryManagments = new List<InventoryManagment>();
            InitializeComponent();
            load_InventoryManagments(null);
        }

        private void frmInventoryManagment_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        private void load_InventoryManagments(List<InventoryManagment> filteredList)
        {
            if (filteredList != null)
            {
                inventoryManagments = filteredList;
            }
            else
            {
                inventoryManagments = new InventoryManagment_Controller().getAll();
            }

            if (inventoryManagments.Count == 0)
            {
                MessageBox.Show("No hay clientes registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            totalRecords = inventoryManagments.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            LoadPage();
            SetColumnOrder();

           
            dgvInventoryManagments.Columns["Id"].Visible = false;
            dgvInventoryManagments.Columns["TotalAmount"].Visible = false;
            dgvInventoryManagments.Columns["DocumentDate"].HeaderText = "Fecha";
            dgvInventoryManagments.Columns["Supplier"].HeaderText = "Proveedor";
            dgvInventoryManagments.Columns["State"].HeaderText = "Estado";
            dgvInventoryManagments.Columns["Branch"].HeaderText = "Sucursal";
            dgvInventoryManagments.Columns["DocumentType"].HeaderText = "Tipo de documento";

            SetColumnOrder();
        }

        private void LoadPage()
        {
            int startRecord = (currentPage - 1) * pageSize;
            int endRecord = Math.Min(currentPage * pageSize, totalRecords);

            var pageClients = inventoryManagments.Skip(startRecord).Take(endRecord - startRecord).ToList();
            dgvInventoryManagments.DataSource = pageClients;

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
                load_InventoryManagments(null);
                return;
            }
            // Filtrar la lista de gestiones de inventario
            var filteredList = inventoryManagments.Where(p =>
                p.DocumentDate.ToString().ToLower().Contains(filterValue) ||
                p.Supplier != null && p.Supplier.name.ToLower().Contains(filterValue) ||
                p.State.ToLower().Contains(filterValue) ||
                p.Branch.Name.ToLower().Contains(filterValue) ||
                p.DocumentType.ToLower().Contains(filterValue)
            ).ToList();

            currentPage = 1;
            totalRecords = filteredList.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (filteredList.Count == 0)
            {
                load_InventoryManagments(null);
                return;
            }
            load_InventoryManagments(filteredList);
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_InventoryManagments(null);
        }

        private void SetColumnOrder()
        {
            dgvInventoryManagments.Columns["DocumentDate"].DisplayIndex = 0;
            dgvInventoryManagments.Columns["DocumentType"].DisplayIndex = 1;
            dgvInventoryManagments.Columns["Supplier"].DisplayIndex = 2;
            dgvInventoryManagments.Columns["Branch"].DisplayIndex = 3;
            dgvInventoryManagments.Columns["State"].DisplayIndex = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvInventoryManagments_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedId = Convert.ToInt32(dgvInventoryManagments.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                List<InventoryManagment> inventoryManagments = new InventoryManagment_Controller().getAll();
                InventoryManagment selectedInventoryManagment = null;
                foreach (InventoryManagment inventoryManagment in inventoryManagments)
                {
                    if (inventoryManagment.Id == selectedId)
                    {
                        selectedInventoryManagment = inventoryManagment;
                        break;
                    }
                }

                string action = "Modify";
                frmInsertUpdate_InventoryManagment frmInsertInventoryManagment = new frmInsertUpdate_InventoryManagment(selectedInventoryManagment);
                this.WindowState = FormWindowState.Normal;
                frmInsertInventoryManagment.MdiParent = this.MdiParent;
                frmInsertInventoryManagment.DataChanged += ChildFormDataChangedHandler;
                frmInsertInventoryManagment.Show();
                return;
            }
        }

        private void btnAddInventoryManagment_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_InventoryManagment frmUpsert_InventoryManagment = new frmInsertUpdate_InventoryManagment();
            this.WindowState = FormWindowState.Normal;
            frmUpsert_InventoryManagment.MdiParent = this.MdiParent;
            frmUpsert_InventoryManagment.DataChanged += ChildFormDataChangedHandler;
            frmUpsert_InventoryManagment.Show();
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
