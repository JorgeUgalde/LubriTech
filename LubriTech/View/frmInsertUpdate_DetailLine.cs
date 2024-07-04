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
        private DetailLine detailLine = new DetailLine();
        private Item selectedItem = null;

        public frmInsertUpdate_DetailLine()
        {
            InitializeComponent();
        }

        public frmInsertUpdate_DetailLine(int inventoryManagmentId, string itemCode)
        {
            InitializeComponent();
            if (itemCode != "")
            {
                detailLine = new DetailLine_Controller().getDetailLine(itemCode, inventoryManagmentId);
                tbAmount.Text = detailLine.Amount.ToString();
                tbQuantity.Text = detailLine.Quantity.ToString();
                selectedItem = new Item_Controller().get(itemCode);
                tbItemName.Text = selectedItem.name;
                tbItemCode.Text = selectedItem.code;
                tbItemName.Enabled = false;
                tbItemCode.Enabled = false;
                btnSelectItem.Enabled = false;
                tbAmount.Enabled = false;
                checkInventoryState(detailLine);
            }
            else
            {
                detailLine.InventoryManagment = new InventoryManagment_Controller().getInventoryManagment(inventoryManagmentId);
                tbItemName.Enabled = false;
                tbAmount.Enabled = false;
            }
        }

        private void checkInventoryState(DetailLine detail)
        {
            if (detail.InventoryManagment.State.Equals("Finalizado"))
            {
                tbItemCode.Enabled = false;
                tbQuantity.Enabled = false;
                btnSelectItem.Enabled = false;
            }
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
                tbItemName.Text = item.name;
                tbItemCode.Text = item.code;
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbItemCode.Text.Trim() == ""
                || tbQuantity.Text.Trim() == "")
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
            else if (tbItemName.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un artículo");
            }
            else
            {
                DetailLine_Controller detailLineController = new DetailLine_Controller();

                detailLine.Item = selectedItem;
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
            if (tbQuantity.Text.Trim() != "" && tbItemName.Text.Trim() != "")
            {
                double calc = (Convert.ToDouble(tbQuantity.Text.ToString().Trim()) * (new Item_Controller().get(tbItemCode.Text.Trim()).purchasePrice));
                tbAmount.Text = calc.ToString();
            }
            if (tbQuantity.Text.Trim() == "")
            {
                tbAmount.Text = "";
            }
        }

        private void tbItemId_TextChanged(object sender, EventArgs e)
        {
            string code = tbItemCode.Text;

            if (code.Length >= 3)
            {
                Item item = new Item_Controller().get(code);

                if (item != null)
                {
                    SelectItem(item);
                }
            }
        }

        public void SelectItem(Item item)
        {
            if (item != null)
            {
                selectedItem = item;
                tbItemName.Text = item.name;
                tbItemCode.Text = item.code;
            }
        }
    }
}
