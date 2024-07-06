using LubriTech.Controller;
using LubriTech.Model.Item_Information;
using LubriTech.Model.PricesList_Information;
using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View.Appointment_View
{
    public partial class frmUpsert_PriceList : Form
    {
        private int? priceListId;

        public event EventHandler DataChanged;

        public frmUpsert_PriceList(int? priceListId)
        {
            InitializeComponent();
            this.priceListId = priceListId;

            cbState.DataSource = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0, "Inactiva"),
                new KeyValuePair<int, string>(1, "Activa")
            };
            cbState.DisplayMember = "Value";
            cbState.ValueMember = "Key";

            if (priceListId.HasValue)
            {
                PriceList priceList = new PriceList_Controller().getPriceList(priceListId.Value);
                loadPrices(priceList);
            }
            else
            {
                dataGridView1.DataSource = new DataTable();
            }
        }

        private void loadPrices(PriceList priceList)
        {
            txtDescription.Text = priceList.description;
            cbState.SelectedIndex = priceList.state;
            dataGridView1.DataSource = new PriceList_Controller().getPricesByPriceListDT(priceList.id);
        }

        /// <summary>
        /// Invoca el evento DataChanged para notificar a los suscriptores de que los datos han cambiado.
        /// </summary>
        /// <param name="e">Argumentos del evento.</param>
        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["IdentificacionListaPrecios"].Value = priceListId;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataRowView rowView = e.Row.DataBoundItem as DataRowView;
            if (rowView != null)
            {
                bool success = new PriceList_Controller().deletePrice((int)rowView["Identificacion"]);
                if (!success)
                {
                    MessageBox.Show("Failed to delete row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true; // Cancel the deletion if the delete operation failed
                }
            }
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
                                          rowView["Factor"] != DBNull.Value &&
                                          rowView["PrecioVenta"] != DBNull.Value;

                        if (hasValidValues)
                        {
                            // Hacer el upsert solo si es una fila nueva y tiene todos los valores requeridos
                            bool success = new PriceList_Controller().upsertPrice(rowView.Row);
                            if (!success)
                            {
                                MessageBox.Show("Failed to save changes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string errorMessage = e.Exception.Message;
            errorMessage = errorMessage.Replace("nulls", "vacíos");
            MessageBox.Show("Error: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                e.Graphics.FillRectangle(Brushes.AntiqueWhite, x, y, buttonWidth, buttonHeight);
                e.Graphics.DrawRectangle(Pens.Black, x, y, buttonWidth, buttonHeight);
                TextRenderer.DrawText(e.Graphics, "...", btn.Font, new Rectangle(x, y, buttonWidth, buttonHeight), btn.ForeColor);

                e.Handled = true;
            }
        }

        private void HandleItemSelected(Item item)
        {
            ShowItemInPriceList(item);
        }

        public void ShowItemInPriceList(Item item)
        {
            if (item != null)
            {
                //validate if the cell in the new row is selected
                int newRowIndex = dataGridView1.NewRowIndex;
                // Obtener la fila actualmente seleccionada
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                if(rowIndex + 1 == newRowIndex)
                {
                    DataGridViewRow row = dataGridView1.Rows[newRowIndex];
                    // Asignar los valores del artículo seleccionado a la fila actual
                    row.Cells["CodigoArticulo"].Value = item.code;
                }
                else
                {
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];
                    // Asignar los valores del artículo seleccionado a la fila actual
                    row.Cells["CodigoArticulo"].Value = item.code;
                }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["CodigoArticulo"].Index)
            {
                // Forzar la validación de la fila para guardar los cambios
                dataGridView1.NotifyCurrentCellDirty(true);
            }
        }

        private void pbMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

    }
}
