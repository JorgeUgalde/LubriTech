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
        private List<Product> products;

        public frmProducts()
        {
            InitializeComponent();
            products = new List<Product>();
            SetupDataGridView();
            load_Products(null);
        }

        // **************************************** Filtrado inicio  ***************************************************//
         
        // ************************* crear lista de lo que hacen, en mi caso la linea 18 tiene la lista de productos global
        private void frmProducts_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);

        }

        private void load_Products(List<Product> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvProducts.DataSource = products;
                    
                }else
                {
                    dgvProducts.DataSource = filteredList;
                }
            }
            else
            {
                products = new Product_Controller().getAll();
                dgvProducts.DataSource = products;
                
            }
            dgvProducts.Columns["code"].HeaderText = "Código";
            dgvProducts.Columns["name"].HeaderText = "Nombre";
            dgvProducts.Columns["price"].HeaderText = "Precio";
            dgvProducts.Columns["measureUnit"].HeaderText = "Unidad de Medida";
            dgvProducts.Columns["state"].HeaderText = "Estado";
            SetColumnOrder();
        }

        private void SetColumnOrder()
        {
            dgvProducts.Columns["code"].DisplayIndex = 0;
            dgvProducts.Columns["name"].DisplayIndex = 1;
            dgvProducts.Columns["price"].DisplayIndex = 2;
            dgvProducts.Columns["measureUnit"].DisplayIndex = 3;
            dgvProducts.Columns["state"].DisplayIndex = 4;
            dgvProducts.Columns["ModifyButtonColumn"].DisplayIndex = 5;
            dgvProducts.Columns["DeleteButtonColumn"].DisplayIndex = 6;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            // Filtrar la lista de productos
            var filteredList = products.Where(p =>
                p.code.ToLower().Contains(filterValue) ||
                p.name.ToLower().Contains(filterValue) ||
                p.price.ToString().ToLower().Contains(filterValue) ||
                p.measureUnit.ToLower().Contains(filterValue) ||
                p.state.ToLower().Contains(filterValue)
            ).ToList();

            // Refrescar el DataGridView
            dgvProducts.DataSource = null;
            load_Products(filteredList);
        }
        //**************************************** Filtrado final ***************************************************//

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
            load_Products(null);
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
                    load_Products(null);
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

            // Estilo de las celdas
            // Headers de columnas
            this.dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);
            this.dgvProducts.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 10, 10, 10);
            this.dgvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProducts.RowHeadersVisible = false;

            // Celdas
            this.dgvProducts.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
            this.dgvProducts.Rows[e.RowIndex].DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
