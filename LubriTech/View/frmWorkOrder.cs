using LubriTech.Controller;
using LubriTech.Model.Item_Information;
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
                UpdateTotalAmount();
                //dataGridView1.Columns["Identificacion"].Visible = false;
                //dataGridView1.Columns["IdentificacionOrdenTrabajo"].Visible = false;
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
            txtClientId.Enabled = false;
            txtClientId.Text = workOrder.Client.Id.ToString();
            txtClientName.Enabled = false;
            txtClientName.Text = workOrder.Client.FullName.ToString();
            txtCellphone.Enabled = false;
            txtCellphone.Text = workOrder.Client.MainPhoneNum.ToString();
            txtCellphone2.Enabled = false;
            txtCellphone2.Text = workOrder.Client.AdditionalPhoneNum.ToString();
            txtEmail.Enabled = false;
            txtEmail.Text = workOrder.Client.Email.ToString();
            txtMake.Enabled = false;
            txtMake.Text = workOrder.Vehicle.Model.Make.ToString();
            txtModel.Enabled = false;
            txtModel.Text = workOrder.Vehicle.Model.ToString() + " " + workOrder.Vehicle.Year;
            txtMileage.Enabled = false;
            txtMileage.Text = workOrder.Vehicle.Mileage.ToString();
            loadWorkOrderLines(workOrder.Id);
            UpdateTotalAmount();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmWorkOrder_Load(object sender, EventArgs e)
        {

        }

        private void loadWorkOrderLines(int workOrderId)
        {
            dataGridView1.DataSource = new WorkOrderLine_Model().LoadWorkOrderLinesDT(workOrderId);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    DataRowView rowView = row.DataBoundItem as DataRowView;

                    if (rowView != null)
                    {
                        // Verificar si los valores requeridos no son DBNull
                        bool hasValidValues = rowView["CodigoArticulo"] != DBNull.Value &&
                                          rowView["Cantidad"] != DBNull.Value &&
                                          rowView["Monto"] != DBNull.Value;

                        if (hasValidValues)
                        {
                            // Hacer el upsert solo si es una fila nueva y tiene todos los valores requeridos
                            bool success = new WorkOrderLine_Model().UpsertWorkOrderLine(rowView.Row);
                            if (!success)
                            {
                                MessageBox.Show("Failed to save changes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        UpdateTotalAmount();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (DataRow row in ((DataTable)dataGridView1.DataSource).Rows)
            {
                if (row["Monto"] != DBNull.Value)
                {
                    totalAmount += Convert.ToDecimal(row["Monto"]);
                }
            }

            txtTotalAmount.Text = totalAmount.ToString("N2"); // Formatear el número como decimal
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

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["IdentificacionOrdenTrabajo"].Value = workOrderId;
            //e.Row.Cells["IsNewRow"].Value = true;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            string errorMessage = e.Exception.Message;
            errorMessage = errorMessage.Replace("nulls", "vacíos");
            MessageBox.Show("Error: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void HandleItemSelected(Item item)
        {
            ShowItemInWorkOrder(item);
        }

        public void ShowItemInWorkOrder(Item item)
        {
            if (item != null)
            {
                // Obtener la fila actualmente seleccionada
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                // Asignar los valores del artículo seleccionado a la fila actual
                row.Cells["CodigoArticulo"].Value = item.code;
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["CodigoArticulo"].Index && e.RowIndex >= 0)
            {
                //Validate if the cell already has a button
                if (e.Value != null && e.Value.ToString() == "...")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.Handled = true;
                    return;
                }
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Crear el botón
                Button btn = new Button();
                btn.Text = "...";
                btn.Size = new Size(13, e.CellBounds.Height - 8);

                // Calcular la posición del botón
                var buttonWidth = btn.Width;
                var buttonHeight = btn.Height;
                var x = e.CellBounds.Left + e.CellBounds.Width - buttonWidth - 5;
                var y = e.CellBounds.Top + (e.CellBounds.Height - buttonHeight) / 2;


                // Dibujar el botón en la celda
                e.Graphics.FillRectangle(Brushes.White, x, y, buttonWidth, buttonHeight);
                e.Graphics.DrawRectangle(Pens.Black, x, y, buttonWidth, buttonHeight);
                TextRenderer.DrawText(e.Graphics, "...", btn.Font, new Rectangle(x, y, buttonWidth, buttonHeight), btn.ForeColor);

                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["CodigoArticulo"].Index && e.RowIndex >= 0)
            {
                // Verificar si el clic ocurrió en el botón
                var rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                var buttonWidth = 20;
                var x = rect.Right - buttonWidth - 2;

                if (dataGridView1.PointToClient(Cursor.Position).X >= x)
                {
                    dataGridView1.EndEdit(); // Finalizar la edición de la celda actual

                    frmItems frmItems = new frmItems(this);
                    frmItems.ItemSelected += HandleItemSelected;
                    frmItems.MdiParent = this.MdiParent;
                    frmItems.Show();
                }
            }
        }

       
    }
}