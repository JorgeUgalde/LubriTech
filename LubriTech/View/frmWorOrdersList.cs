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
        }

        private void frmWorOrdersList_Load(object sender, EventArgs e)
        {

        }
    }
}
