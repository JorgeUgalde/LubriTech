using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
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
using System.Windows.Forms.VisualStyles;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_Item : Form
    {
        Item globalItem;
        public frmInsertUpdate_Item()
        {
            InitializeComponent();
            load_ItemTypes();
            cbState.SelectedIndex = 0;
            tbStock.Visible = false;
            lblStock.Visible = false;

            globalItem = new Item();
        }

        public frmInsertUpdate_Item(Item item, int branchId)
        {

            InitializeComponent();
            load_ItemTypes();

            tbStock.Text = new Item_Controller().getItemStock(item.code, branchId).ToString();

            tbStock.Enabled = false;
            txtFact.Visible = false;
            lblSellPrice.Visible = false;
            lblPercentage.Visible = false;

            this.globalItem = item;
            txtCode.Enabled = false;

            txtCode.Text = item.code;
            txtName.Text = item.name;
            cbMeasureUnit.Text = item.measureUnit.ToString();
            cbState.Text = item.state;
            cbType.Text = item.itemType.ToString();
            txtRecommended.Text = item.recommendedServiceInterval.ToString();

        }
        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void load_ItemTypes()
        {
            // load from ItemTypes_Controller 
            cbType.DataSource = new ItemType_Controller().loadAllItemTypes();
            cbType.DisplayMember = "name";
            cbType.ValueMember = "id";
        }


        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            if (txtFact.Visible == true && txtFact.Text.Trim() == "" )
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (txtCode.Text.Trim() == "" ||
               txtName.Text.Trim() == "" ||
               cbMeasureUnit.Text.Trim() == "" ||
               cbState.Text.Trim() == "" ||
               cbType.Text.Trim() == "")

            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (globalItem == null)
            {
                globalItem = new Item();
            }

            if (txtRecommended.Text == "")
            {
                globalItem.recommendedServiceInterval = 0;
            }
            else
            {
                globalItem.recommendedServiceInterval = Convert.ToDouble(txtRecommended.Text);
            }

            globalItem.code = txtCode.Text;
            globalItem.name = txtName.Text;
            globalItem.measureUnit = cbMeasureUnit.Text;
            globalItem.state = cbState.Text;
            globalItem.state = cbState.Text;
            globalItem.itemType = (ItemType)cbType.SelectedItem;

            Double fact = -1;

            if (txtFact.Visible == true)
            {
                fact = Convert.ToDouble(txtFact.Text) / 100;
            }


            if (new Item_Controller().UpSert(globalItem, fact))
            {
                MessageBox.Show("Producto registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDataChanged(EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSellPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8;
        }

        private void tbStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
        }

        private void txtRecommended_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8;
        }

        private void txtRecommended_TextChanged(object sender, EventArgs e)
        {

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

    }
    }
