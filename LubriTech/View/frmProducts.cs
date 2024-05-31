using LubriTech.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LubriTech.Model.Product_Information;
using LubriTech.Model.Supplier_Information;

namespace LubriTech.View
{
    public partial class frmProducts : Form
    {

        public frmProducts()
        {
            InitializeComponent();
            load_Products();
            SetupDataGridView();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            
        }

        private void load_Products()
        {
            dgvProducts.DataSource = new Product_Controller().getAll();
        }

        private void SetupDataGridView()
        {
            // Modify button column
            DataGridViewButtonColumn modifyButtonColumn = new DataGridViewButtonColumn();
            modifyButtonColumn.Name = "ModifyButtonColumn";
            modifyButtonColumn.HeaderText = "Ver Detalles";
            modifyButtonColumn.Text = "Detalles - Modificar";
            modifyButtonColumn.UseColumnTextForButtonValue = true;
            dgvProducts.Columns.Add(modifyButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.HeaderText = "Eliminar ";
            deleteButtonColumn.Text = "Eliminar";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dgvProducts.Columns.Add(deleteButtonColumn);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Product frmInsertProduct = new frmInsertUpdate_Product();
            frmInsertProduct.Owner = this;
            frmInsertProduct.DataChanged += ChildFormDataChangedHandler;
            frmInsertProduct.Show();
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Products();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProducts.Columns["ModifyButtonColumn"].Index && e.RowIndex >= 0)
            {
                string idToModify = dgvProducts.Rows[e.RowIndex].Cells["code"].Value.ToString();
                List<Product> products = new Product_Controller().getAll();
                Product productSelected = null;
                foreach (Product product in products)
                {
                    if (product.code == idToModify)
                    {
                        productSelected = product;
                        break;
                    }
                }

                frmInsertUpdate_Product frmInsertProduct = new frmInsertUpdate_Product(productSelected);
                frmInsertProduct.Owner = this;
                frmInsertProduct.DataChanged += ChildFormDataChangedHandler;
                frmInsertProduct.Show();
                return;
            }

            if (e.ColumnIndex == dgvProducts.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Estás seguro de eliminar al proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string idToDelete = dgvProducts.Rows[e.RowIndex].Cells["code"].Value.ToString();
                    Product_Controller pc = new Product_Controller();
                    pc.remove(idToDelete);
                    return;
                }
            }
        }


        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dgvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }



        private void dgvProducts_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                dgvProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}
