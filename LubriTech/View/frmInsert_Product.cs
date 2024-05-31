using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LubriTech.Controller;
using LubriTech.Model.Product_Information;
using System.Windows.Forms;
using LubriTech.Model.Supplier_Information;

namespace LubriTech.View
{
    public partial class frmInsert_Product : Form
    {
        List<Supplier> addedSuppliers;
        List<Supplier> suppliers;


        public frmInsert_Product()
        {
            addedSuppliers = new List<Supplier>();
            suppliers = new List<Supplier>();
            InitializeComponent();
            load_Suppliers(null);
            SetupSuppliersDGV();
        }

        public frmInsert_Product(Product product)
        {
            suppliers = new List<Supplier>();

            InitializeComponent();
            load_Suppliers(null);
            SetupSuppliersDGV();
            addedSuppliers = product.suppliers;

            load_Selected_Suppliers();


            txtCode.Text = product.code;
            txtCode.Enabled = false;
            txtName.Text = product.name;
            txtPrice.Text = product.price.ToString();
            cbMeasureUnit.Text = product.measureUnit;
            cbState.Text = product.state;
        }


        // Define a custom event
        public event EventHandler DataChanged;

        // Method to raise the event
        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void frmInsert_Product_Load(object sender, EventArgs e)
        {
            load_Suppliers(null);
        }

        private void load_Selected_Suppliers()
        {

            dgvSelectedSuppliers.DataSource = null;
            dgvSelectedSuppliers.Rows.Clear();
            dgvSelectedSuppliers.Columns.Clear();
            dgvSelectedSuppliers.Refresh(); 

            dgvSelectedSuppliers.DataSource = addedSuppliers;
            dgvSelectedSuppliers.Columns["id"].Visible = true;
            dgvSelectedSuppliers.Columns["name"].HeaderText = "Nombre";
            dgvSelectedSuppliers.Columns["phone"].Visible = false;
            dgvSelectedSuppliers.Columns["email"].Visible = false;

            SetupSelectedSuppliersDGV();


        }


        private void load_Suppliers(List<Supplier> filteredSuppliers)
      {
            try
            {
                
                if (filteredSuppliers != null)
                {
                    dgvSuppliers.DataSource = filteredSuppliers;
                    dgvSuppliers.Columns["id"].Visible = false;
                    dgvSuppliers.Columns["name"].HeaderText = "Nombre";
                    dgvSuppliers.Columns["phone"].Visible = false;
                    dgvSuppliers.Columns["email"].Visible = false;                    
                }

                else
                {
                    suppliers = new Supplier_Model().loadAllSuppliers();
                    dgvSuppliers.DataSource = suppliers;
                    dgvSuppliers.Columns["id"].Visible = false;
                    dgvSuppliers.Columns["name"].HeaderText = "Nombre";
                    dgvSuppliers.Columns["phone"].Visible = false;
                    dgvSuppliers.Columns["email"].Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }           

        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void txtSupplierInfo_TextChanged(object sender, EventArgs e)
       {
            List < Supplier > suppliers = new Supplier_Model().loadAllSuppliers();
            string supplierName = txtSupplierInfo.Text.Trim();
            if (supplierName != "")
            {
                var filteredSuppliers = suppliers.Where(c => c.name.IndexOf(supplierName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                load_Suppliers(filteredSuppliers);
            }
            else
            {
                load_Suppliers(null);
            }
        }

        private void SetupSuppliersDGV()
        {
            DataGridViewButtonColumn addButtonColumn = new DataGridViewButtonColumn();
            addButtonColumn.Name = "addButtonColumn";
            addButtonColumn.HeaderText = "Añadir ";
            addButtonColumn.Text = "Añadir";
            addButtonColumn.UseColumnTextForButtonValue = true;
            dgvSuppliers.Columns.Add(addButtonColumn);

           
        }
        private void SetupSelectedSuppliersDGV()
        {
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.HeaderText = "Eliminar ";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dgvSelectedSuppliers.Columns.Add(deleteButtonColumn);

        }


        private void dgvSuppliers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSuppliers.Columns["addButtonColumn"].Index && e.RowIndex >= 0)
            {
                string idToAdd = dgvSuppliers.Rows[e.RowIndex].Cells["id"].Value.ToString();
                foreach (Supplier supplier in suppliers)
                {
                    if (supplier.id == idToAdd && !addedSuppliers.Contains(supplier))
                    {
                        addedSuppliers.Add(supplier);
                        break;
                    }
                }
            }
            load_Selected_Suppliers();
           
        }

        private void dgvSelectedSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSelectedSuppliers.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
            {
                string idToDelete = dgvSelectedSuppliers.Rows[e.RowIndex].Cells["id"].Value.ToString();
                foreach (Supplier supplier in addedSuppliers)
                {
                    if (supplier.id == idToDelete )
                    {
                        addedSuppliers.Remove(supplier);
                        break;
                    }
                }
            }
            load_Selected_Suppliers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "" || txtName.Text.Trim() == "" || txtPrice.Text.Trim() == ""

                || cbMeasureUnit.Text.Trim() == "Seleccione la unidad de medida"
                || cbState.Text.Trim() == "Seleccione el estado del producto"
                || cbMeasureUnit.Text.Trim() == ""
                || cbState.Text.Trim() == ""

                || addedSuppliers.Count() == 0
                ||cbMeasureUnit.SelectedIndex == -1
                ||cbState.SelectedIndex == -1
                )
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                Product product = new Product();
                product.code = txtCode.Text;
                product.name = txtName.Text;
                product.price = Convert.ToDouble(txtPrice.Text);
                product.measureUnit = cbMeasureUnit.Text.Trim();
                product.state = cbState.Text.Trim();
                product.suppliers = addedSuppliers;
                Product_Controller productController = new Product_Controller();
                if (productController.UpSert(product))
                {
                    OnDataChanged(EventArgs.Empty);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Product not inserted");
                }
            }
        }

        private void dgvSuppliers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dgvSuppliers.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        private void dgvSuppliers_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvSuppliers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                dgvSuppliers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void dgvSelectedSuppliers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dgvSelectedSuppliers.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

        }

        private void dgvSelectedSuppliers_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
 
            if (e.RowIndex % 2 == 0)
            {
                dgvSelectedSuppliers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                dgvSelectedSuppliers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            //frm frmSuppliers = new frmSuppliers();
            //frmSuppliers.DataChanged += new EventHandler(frmInsert_Product_Load);
            //frmSuppliers.ShowDialog();
        }
    }
}
