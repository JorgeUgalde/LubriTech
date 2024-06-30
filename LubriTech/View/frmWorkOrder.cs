using LubriTech.Controller;
using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmWorkOrder : Form
    {
        private int? workOrderId; // Nullable int to store the work order ID
        Work_Order_Controller workOrderController = new Work_Order_Controller();
        public frmWorkOrder(int? workOrderId)
        {
            InitializeComponent();
            this.workOrderId = workOrderId;

            if (workOrderId.HasValue)
            {
                // Load the existing work order
                WorkOrder workOrder = workOrderController.LoadWorkOrder(workOrderId.Value);
                LoadWorkOrderData(workOrder);
                DataTable workOrderLinesTable = new WorkOrderLine_Model().LoadWorkOrderLinesDT(workOrderId.Value);
                dataGridView1.DataSource = workOrderLinesTable;
            }
            else
            {
                // Initialize a new work order
                //InitializeNewWorkOrder();
            }
        }

        private void LoadWorkOrderData(WorkOrder workOrder)
        {
            txtBranch.Text = workOrder.Branch.ToString();
            txtDate.Text = workOrder.Date.ToString();
            txtState.Text = workOrder.State.ToString();
            txtTotalAmount.Text = workOrder.Amount.ToString();
            txtClientId.Text = workOrder.Client.Id.ToString();
            txtClientName.Text = workOrder.Client.FullName.ToString();
            txtCellphone.Text = workOrder.Client.MainPhoneNum.ToString();
            txtCellphone2.Text = workOrder.Client.AdditionalPhoneNum.ToString();
            txtEmail.Text = workOrder.Client.Email.ToString();
            txtMake.Text = workOrder.Vehicle.Model.Make.ToString();
            txtModel.Text = workOrder.Vehicle.Model.ToString();
            txtMileage.Text = workOrder.Vehicle.Mileage.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmWorkOrder_Load(object sender, EventArgs e)
        {
            //ConfigureDataGridView();
            loadWorkOrderLines(3);
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.UserAddedRow += dataGridView1_UserAddedRow;
            dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow;
        }

        private void loadWorkOrderLines(int workOrderId)
        {
            dataGridView1.DataSource = new WorkOrderLine_Model().LoadWorkOrderLinesDT(workOrderId);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridView1.Columns["CodigoArticulo"].Index ||
                                    e.ColumnIndex == dataGridView1.Columns["Cantidad"].Index ||
                                    e.ColumnIndex == dataGridView1.Columns["Monto"].Index))
            {
                DataRowView rowView = dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    bool success = new WorkOrderLine_Model().UpsertWorkOrderLine(rowView.Row);
                    if (!success)
                    {
                        MessageBox.Show("Failed to save changes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            DataRowView rowView = e.Row.DataBoundItem as DataRowView;
            if (rowView != null)
            {
                rowView["IdentificacionOrdenTrabajo"] = workOrderId; // Set the work order ID for new rows
                bool success = new WorkOrderLine_Model().UpsertWorkOrderLine(rowView.Row);
                if (!success)
                {
                    MessageBox.Show("Failed to add new row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataRowView rowView = e.Row.DataBoundItem as DataRowView;
            if (rowView != null)
            {
                bool success = new WorkOrderLine_Model().DeleteWorkOrderLine((int)rowView["Identificacion"]);
                if (!success)
                {
                    MessageBox.Show("Failed to delete row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true; // Cancel the deletion if the delete operation failed
                }
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.Columns["Identificacion"].Visible = false; // Make Id column read-only
            dataGridView1.Columns["IdentificacionOrdenTrabajo"].Visible = false; // Make WorkOrderId column read-only
            dataGridView1.Columns["CodigoArticulo"].ReadOnly = false; // Make item column editable
            dataGridView1.Columns["Cantidad"].ReadOnly = false; // Make Quantity column editable
            dataGridView1.Columns["Monto"].ReadOnly = false; // Make Amount column editable

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.UserAddedRow += dataGridView1_UserAddedRow;
            dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }
    }
}
