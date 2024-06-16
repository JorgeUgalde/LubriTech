using LubriTech.Controller;
using LubriTech.Model.Product_Information;
using LubriTech.Model.Service_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmServices : Form
    {
        private List<Service> services;
        public frmServices()
        {
            InitializeComponent();
            SetupDataGridView();
            load_Services(null);
        }

        private void load_Services(List<Service> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvServices.DataSource = services;

                }
                else
                {
                    dgvServices.DataSource = filteredList;
                }
            }
            else
            {
                services = new Service_Controller().loadAllServices();
                dgvServices.DataSource = services;

            }
            dgvServices.Columns["ID"].Visible = false;
            dgvServices.Columns["name"].HeaderText = "Nombre";
            dgvServices.Columns["price"].HeaderText = "Precio";
            SetColumnOrder();
        }

        private void SetColumnOrder()
        {
            dgvServices.Columns["name"].DisplayIndex = 0;
            dgvServices.Columns["price"].DisplayIndex = 1;
            dgvServices.Columns["ModifyButtonColumn"].DisplayIndex = 2;
            dgvServices.Columns["DeleteButtonColumn"].DisplayIndex = 3;
        }
            
        private void SetupDataGridView()
        {
            // Modify button column
            DataGridViewButtonColumn modifyButtonColumn = new DataGridViewButtonColumn();
            modifyButtonColumn.Name = "ModifyButtonColumn";
            modifyButtonColumn.HeaderText = "Ver Detalles";
            modifyButtonColumn.Text = "Detalles - Modificar";
            modifyButtonColumn.UseColumnTextForButtonValue = true;
            dgvServices.Columns.Add(modifyButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.HeaderText = "Eliminar ";
            deleteButtonColumn.Text = "Eliminar";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dgvServices.Columns.Add(deleteButtonColumn);
        }

        private void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvServices.Columns["ModifyButtonColumn"].Index)
            {
                Service service = (Service)dgvServices.Rows[e.RowIndex].DataBoundItem;
                frmInsertUpdate_Service frmInsertService = new frmInsertUpdate_Service(service);
                frmInsertService.Owner = this;
                frmInsertService.DataChanged += ChildFormDataChangedHandler;
                frmInsertService.Show();
            }
            else if (e.ColumnIndex == dgvServices.Columns["DeleteButtonColumn"].Index)
            {
                Service service = (Service)dgvServices.Rows[e.RowIndex].DataBoundItem;
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el servicio " + service.name + "?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    new Service_Controller().Delete(service.ID);
                    load_Services(null);
                }
            }

        }
        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Services(null);
        }

        private void dgvServices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dgvServices.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            // Estilo de las celdas
            // Headers de columnas
            this.dgvServices.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);
            this.dgvServices.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 10, 10, 10);
            this.dgvServices.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvServices.RowHeadersVisible = false;

            // Celdas
            this.dgvServices.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
            this.dgvServices.Rows[e.RowIndex].DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
        }

        private void dgvServices_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvServices.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                dgvServices.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Service frmInsertService = new frmInsertUpdate_Service();
            frmInsertService.Owner = this;
            frmInsertService.DataChanged += ChildFormDataChangedHandler;
            frmInsertService.Show();

        }

        private void frmServices_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();

        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            // Filtrar la lista de productos
            var filteredList = services.Where(s =>
                s.name.ToLower().Contains(filterValue) ||
                s.price.ToString().Contains(filterValue)               
            ).ToList();

            // Refrescar el DataGridView
            dgvServices.DataSource = null;
            load_Services(filteredList);
        }
    }
}
