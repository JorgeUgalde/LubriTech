using LubriTech.Controller;
using LubriTech.Model.Item_Information;
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
    public partial class frmItemType : Form
    {

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
                if (filteredList.Count == 0)
                {
                    dgvItemTypes.DataSource = ItemTypes;
                }
                else
                {
                    dgvItemTypes.DataSource = filteredList;
                }
            }
            else
            {
                ItemTypes = new ItemType_Controller().loadAllItemTypes();
                if (ItemTypes.Count == 0)
                {
                    MessageBox.Show("No hay tipos de item registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvItemTypes.DataSource = ItemTypes;
            }

            dgvItemTypes.Columns["Id"].Visible = false;
            dgvItemTypes.Columns["Name"].HeaderText = "Nombre";
            dgvItemTypes.Columns["State"].HeaderText = "Estado";
            SetColumOrder();
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
            List<ItemType> filtered = ItemTypes.Where(x => x.Name.ToLower().Contains(txtFilter.Text.ToLower())).ToList();
            load_ItemTypes(filtered);
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
    }
}
