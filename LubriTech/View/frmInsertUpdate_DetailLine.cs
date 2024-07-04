using LubriTech.Controller;
using LubriTech.Model.InventoryManagment_Information;
using LubriTech.Model.Item_Information;
using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_DetailLine : Form
    {
        DetailLine detailLine = new DetailLine();

        public frmInsertUpdate_DetailLine()
        {
            InitializeComponent();
        }

        public frmInsertUpdate_DetailLine(int inventoryManagmentId)
        {
            InitializeComponent();
            detailLine.InventoryManagment = new InventoryManagment_Controller().getInventoryManagment(inventoryManagmentId);
            tbItem.Enabled = false;
            tbAmount.Enabled = false;
        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {

        }

        private void btnSelectItem_Click(object sender, EventArgs e)
        {
            frmItems frmItems = new frmItems(this);
            frmItems.ItemSelected += HandleItemSelected;
            frmItems.MdiParent = this.MdiParent;
            frmItems.Show();
        }

        private void HandleItemSelected(Item itemSelected)
        {
            ShowItemInDetailLine(itemSelected);
        }

        public void ShowItemInDetailLine(Item item)
        {
            if (item != null)
            {
                tbItem.Text = item.name;
                tbItemId.Text = item.code;
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbItemId.Text.Trim() == ""
                || tbQuantity.Text.Trim() == "")
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
            else if (tbItem.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un artículo");
            }
            else
            {
                DetailLine_Controller detailLineController = new DetailLine_Controller();

                detailLine.Item = new Item_Controller().get(tbItemId.Text.Trim());
                detailLine.Quantity = Convert.ToInt32(tbQuantity.Text.Trim());
                detailLine.Amount = Convert.ToDouble(tbAmount.Text.Trim());

                if (detailLineController.upsert(detailLine))
                {
                    OnDataChanged(EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Línea de detalle no insertada");
                }
            }
        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            if (tbQuantity.Text.Trim() != "" && tbItem.Text.Trim() != "")
            {
                double calc = (Convert.ToDouble(tbQuantity.Text.ToString().Trim()) * (new Item_Controller().get(tbItemId.Text.Trim()).purchasePrice));
                tbAmount.Text = calc.ToString();
            }
            if (tbQuantity.Text.Trim() == "")
            {
                tbAmount.Text = "";
            }
        }
    }
}
