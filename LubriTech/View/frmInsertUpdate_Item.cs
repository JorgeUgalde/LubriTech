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
    public partial class frmInsertUpdate_Item : Form
    {
        Item globalItem;
        public frmInsertUpdate_Item()
        {
            InitializeComponent();
            cbMeasureUnit.SelectedIndex = 0;
            cbState.SelectedIndex = 0;
            cbType.SelectedIndex = 0;

            globalItem = new Item();
        }

        public frmInsertUpdate_Item(Item item)
        {
            
            InitializeComponent();

            this.globalItem = item;
            txtCode.Enabled = false;

            txtCode.Text = item.code;
            txtName.Text = item.name;
            cbMeasureUnit.Text = item.measureUnit;
            cbState.Text = item.state;
            tbStock.Text = item.stock.ToString();
            tbPurchasePrice.Text = item.purchasePrice.ToString();
            cbType.Text = item.type;
            txtRecommended.Text = item.recommendedServiceInterval.ToString();

        }
        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }


        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

            // chek any input is empty, if is empty set a background color to red
            if (txtCode.Text.Trim() == "")
            {
                lblCode2.Text = "Campo obligatorio";
                lblCode2.Visible = true;

            }
            else
            {
                lblCode2.Visible = false;
                txtCode.BackColor = Color.White;
                lblCode.FlatStyle = FlatStyle.Standard;
                lblCode.ForeColor = Color.Black;
            }




            if (txtCode.Text.Trim() == "" ||
               txtName.Text.Trim() == "" ||
               txtSellPrice.Text.Trim() == "" ||
               cbMeasureUnit.Text.Trim() == "" ||
               cbState.Text.Trim() == "" ||
               tbStock.Text.Trim() == "" ||
               tbPurchasePrice.Text.Trim() == "" ||
               cbType.Text.Trim() == "" )

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
            globalItem.stock = Convert.ToDouble(tbStock.Text);
            globalItem.purchasePrice = Convert.ToDouble(tbPurchasePrice.Text);
            globalItem.type = cbType.Text;
            globalItem.state = cbState.Text;

            if (new Item_Controller().UpSert(globalItem))
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
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;            
        }

        private void tbStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
        }

        private void tbPurchasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            lblCode2.Visible = false;
        }

        private void txtRecommended_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 ;
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
