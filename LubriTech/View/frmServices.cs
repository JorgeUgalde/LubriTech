using LubriTech.Controller;
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
        public frmServices()
        {
            InitializeComponent();
            load_Services();
            SetupDataGridView();
        }

        private void load_Services()
        {
            dgvServices.DataSource = new Service_Controller().loadAllServices();
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
                    load_Services();
                }
            }

        }
        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Services();
        }

        private void dgvServices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dgvServices.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
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
    }
}
