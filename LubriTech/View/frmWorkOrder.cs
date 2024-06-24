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

namespace LubriTech.View
{
    public partial class frmWorkOrder : Form
    {
        Work_Order_Controller workOrderController = new Work_Order_Controller();
        public frmWorkOrder()
        {
            InitializeComponent();
            dataGridView1.DataSource = workOrderController.loadWorkOrders();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
