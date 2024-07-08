using iTextSharp.text;
using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Item_Information;
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
    public partial class frmItemType : Form
    {

        private int currentPage = 1;
        private int pageSize = 20; // Puedes ajustar este valor según sea necesario
        private int totalRecords = 0;
        private int totalPages = 0;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private List<ItemType> ItemTypes;
        public frmItemType()
        {
            InitializeComponent();
            load_ItemTypes(null);
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_ItemTypes(null);
        }

        public void load_ItemTypes(List<ItemType> filteredList)
        {
            if (filteredList != null)
            {

                ItemTypes = filteredList;              
            }
            else
            {
                ItemTypes = new ItemType_Controller().loadAllItemTypes();
            }

            if (ItemTypes.Count == 0)
            {
                MessageBox.Show("No hay tipos de item registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            totalRecords = ItemTypes.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);


            
            LoadPage();
            SetColumOrder();
            dgvItemTypes.Columns["Id"].Visible = false;
            dgvItemTypes.Columns["Name"].HeaderText = "Nombre";
            dgvItemTypes.Columns["State"].HeaderText = "Estado";
        }

        private void LoadPage()
        {
            int startRecord = (currentPage - 1) * pageSize;
            int endRecord = Math.Min(currentPage * pageSize, totalRecords);

            var pageClients = ItemTypes.Skip(startRecord).Take(endRecord - startRecord).ToList();
            dgvItemTypes.DataSource = pageClients;

            lblPageNumber.Text = $"Página {currentPage} de {totalPages}";
        }

        private void SetColumOrder()
        {
            dgvItemTypes.Columns["Name"].DisplayIndex = 0;
            dgvItemTypes.Columns["State"].DisplayIndex = 1;
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
                load_ItemTypes(null);
                return;
            }

            var filteredList = ItemTypes.Where(c =>
            c.Name.ToLower().Contains(filterValue) ||
            c.State.ToLower().Contains(filterValue)
            ).ToList();

            currentPage = 1;
            totalRecords = filteredList.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (filteredList.Count == 0)
            {
                load_ItemTypes(null);
                return;
            }



            load_ItemTypes(filteredList);
        }



        private void pbMaximize_Click(object sender, EventArgs e)
        {
            // check if the form is already maximized
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void lblForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddTipe_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_ItemType frmUpsertItemType = new frmInsertUpdate_ItemType();
            frmUpsertItemType.MdiParent = this.MdiParent;
            this.WindowState = FormWindowState.Normal;
            frmUpsertItemType.DataChanged += ChildFormDataChangedHandler;
            frmUpsertItemType.Show();
        }

        private void dgvItemTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ItemType itemType = ItemTypes[e.RowIndex];
                frmInsertUpdate_ItemType frmUpsertItemType = new frmInsertUpdate_ItemType(itemType);
                frmUpsertItemType.MdiParent = this.MdiParent;
                this.WindowState = FormWindowState.Normal;
                frmUpsertItemType.DataChanged += ChildFormDataChangedHandler;
                frmUpsertItemType.Show();
            }

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
