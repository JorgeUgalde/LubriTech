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
                loadPrices(new PriceList());
            }
        }

        private void loadPrices(PriceList priceList)
        {
            txtDescription.Text = priceList.description;
            cbState.SelectedIndex = priceList.state;
            dataGridView1.DataSource = new PriceList_Controller().getPricesByPriceListDT(priceList.id);
            dataGridView1.Columns["Identificacion"].Visible = false;
            dataGridView1.Columns["IdentificacionListaPrecios"].Visible = false;
            dataGridView1.Columns["CodigoArticulo"].ReadOnly = true;
            dataGridView1.Columns["CodigoArticulo"].HeaderText = "Código Artículo";
            dataGridView1.Columns["PrecioVenta"].ReadOnly = true;
            dataGridView1.Columns["PrecioVenta"].HeaderText = "Precio Venta";
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
                            //update the PrecioVenta to be the result of the Factor * PrecioCompra of the item
                            Item item = new Item_Controller().get(rowView["CodigoArticulo"].ToString());
                            if (item != null)
                            {
                                rowView["PrecioVenta"] = Convert.ToDouble(item.purchasePrice) * Convert.ToDouble(rowView["Factor"]);
                            }

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


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PriceList priceList = new PriceList()
            {
                id = priceListId ?? 0,
                description = txtDescription.Text.ToString(),
                state = ((KeyValuePair<int, string>)cbState.SelectedItem).Key
            };

            bool success = new PriceList_Controller().upsertPriceList(priceList);
            if (success)
            {
                OnDataChanged(EventArgs.Empty);
                MessageBox.Show("Cambios guardados exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Error al guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //show Activa for 1 and Inactiva for 0
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Estado" && e.Value != null)
            {
                int originalValue;
                // Try to convert the cell value to an integer
                if (int.TryParse(e.Value.ToString(), out originalValue))
                {
                    // Change the displayed value according to the original value
                    switch (originalValue)
                    {
                        case 0:
                            e.Value = "Inactiva";
                            break;
                        case 1:
                            e.Value = "Activa";
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
