using LubriTech.Controller;
using LubriTech.Model.WorkOrder_Information;
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
    public partial class frmWorOrdersList : Form
    {
        public frmWorOrdersList()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void LoadWorkOrders()
        {
            // Load all work orders
            List<WorkOrder> workOrders = new Work_Order_Controller().loadWorkOrders();
            dataGridView1.DataSource = workOrders;
            //dataGridView1.Columns["Branch"].Visible = false;
            //dataGridView1.Columns["CurrentMileage"].Visible = false;
            //dataGridView1.Columns["Amount"].Visible = false;
            ////change the value of the column State to show Active, Inactive, or Finished
            //dataGridView1.Columns["State"].DisplayIndex = 7;
            //dataGridView1.Columns["Id"].HeaderText = "Identificación";
            //dataGridView1.Columns["Date"].HeaderText = "Fecha";
            //dataGridView1.Columns["Client"].HeaderText = "Cliente";
            //dataGridView1.Columns["Vehicle"].HeaderText = " Placa Vehículo";
            //dataGridView1.Columns["Vehicle"].DefaultCellStyle.NullValue = "No asignado";
            //dataGridView1.Columns["State"].HeaderText = "Estado";
            //dataGridView1.Columns["State"].DefaultCellStyle.NullValue = "Activa";
            //dataGridView1.Columns["State"].DefaultCellStyle.Format = "Activa";
        }

        private void frmWorOrdersList_Load(object sender, EventArgs e)
        {
            LoadWorkOrders();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                WorkOrder workOrder = (WorkOrder)row.DataBoundItem;
                frmWorkOrder frmWorkOrderDetails = new frmWorkOrder(workOrder.Id);
                frmWorkOrderDetails.MdiParent = this.MdiParent;
                frmWorkOrderDetails.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmWorkOrder frmWorkOrder = new frmWorkOrder(null);
            frmWorkOrder.MdiParent = this.MdiParent;
            frmWorkOrder.Show();
        }
    }
}
