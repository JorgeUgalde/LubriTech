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
using LubriTech.Model.Supplier_Information;
using LubriTech.Model.Item_Information;

namespace LubriTech.View
{
    public partial class frmItems : Form
    {
        private List<Item> items;

        public frmItems()
        {
            InitializeComponent();
            items = new List<Item>();
            SetupDataGridView();
            load_Items(null);
        }

        // **************************************** Filtrado inicio  ***************************************************//
         
        // ************************* crear lista de lo que hacen, en mi caso la linea 18 tiene la lista de productos global
        private void frmItems_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        private void load_Items(List<Item> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvItems.DataSource = items;
                    
                }else
                {
                    dgvItems.DataSource = filteredList;
                }
            }
            else
            {
                items = new Item_Controller().getAll();

                // dont show all the columns, only show the columns that are needed
                dgvItems.DataSource = items.Select(p => new
                {
                    code = p.code,
                    name = p.name,
                    sellPrice = p.sellPrice,
                    measureUnit = p.measureUnit,
                    state = p.state,
                    type = p.type
                }).ToList();


            }
            dgvItems.Columns["code"].HeaderText = "Código";
            dgvItems.Columns["name"].HeaderText = "Nombre";
            dgvItems.Columns["sellPrice"].HeaderText = "Precio de Venta";
            dgvItems.Columns["measureUnit"].HeaderText = "Unidad de Medida";
            dgvItems.Columns["state"].HeaderText = "Estado";
            dgvItems.Columns["type"].HeaderText = "Tipo";
            SetColumnOrder();
        }

        private void SetColumnOrder()
        {
            dgvItems.Columns["code"].DisplayIndex = 0;
            dgvItems.Columns["name"].DisplayIndex = 1;
            dgvItems.Columns["sellPrice"].DisplayIndex = 2;
            dgvItems.Columns["measureUnit"].DisplayIndex = 3;
            dgvItems.Columns["state"].DisplayIndex = 4;
            dgvItems.Columns["type"].DisplayIndex = 5;
            dgvItems.Columns["ModifyButtonColumn"].DisplayIndex = 6;
            dgvItems.Columns["DeleteButtonColumn"].DisplayIndex = 7;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            // Filtrar la lista de productos
            var filteredList = items.Where(p =>
                p.code.ToLower().Contains(filterValue) ||
                p.name.ToLower().Contains(filterValue) ||
                p.sellPrice.ToString().ToLower().Contains(filterValue) ||
                p.measureUnit.ToLower().Contains(filterValue) ||
                p.state.ToLower().Contains(filterValue)
            ).ToList();

            // Refrescar el DataGridView
            dgvItems.DataSource = null;
            load_Items(filteredList);
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
            dgvItems.Columns.Add(modifyButtonColumn);


            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.HeaderText = "Eliminar ";
            deleteButtonColumn.Text = "Eliminar";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dgvItems.Columns.Add(deleteButtonColumn);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Item frmInsertProduct = new frmInsertUpdate_Item();
            frmInsertProduct.MdiParent = this.MdiParent;
            frmInsertProduct.DataChanged += ChildFormDataChangedHandler;
            frmInsertProduct.Show();
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Items(null);
        }

        private void dgvItems_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvItems.Columns["ModifyButtonColumn"].Index && e.RowIndex >= 0)
            {
                string idToModify = dgvItems.Rows[e.RowIndex].Cells["code"].Value.ToString();
                List<Item> items = new Item_Controller().getAll();
                Item itemselected = null;
                foreach (Item product in items)
                {
                    if (product.code == idToModify)
                    {
                        itemselected = product;
                        break;
                    }
                }

                frmInsertUpdate_Item frmInsertProduct = new frmInsertUpdate_Item(itemselected);
                frmInsertProduct.Owner = this;
                frmInsertProduct.DataChanged += ChildFormDataChangedHandler;
                frmInsertProduct.Show();
                return;
            }

            if (e.ColumnIndex == dgvItems.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Estás seguro de eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string idToDelete = dgvItems.Rows[e.RowIndex].Cells["code"].Value.ToString();
                    Item_Controller pc = new Item_Controller();
                    load_Items(null);
                    return;
                }
            }
        }
    }
}
