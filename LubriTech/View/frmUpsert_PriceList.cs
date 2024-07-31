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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View.Appointment_View
{
    public partial class frmUpsert_PriceList : Form
    {
        private int? priceListId;
        private PriceList globalList;

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
                globalList = priceList;
                loadPrices(priceList, null);
                lblFactor.Visible = false;
                txtFactor.Visible = false;
                dgvPrices.Size = new Size(701, 303);
                dgvPrices.Location = new Point(37, 136);
            }
            else
            {
                this.priceListId = 0;
                dgvPrices.DataSource = new DataTable();
                globalList = new PriceList();
                loadPrices(globalList, null);
                cbState.SelectedIndex = 1;
                lblFactor.Visible = true;
                txtFactor.Visible = true;
                dgvPrices.Size = new Size(701, 271);
                dgvPrices.Location = new Point(37, 170);
            }
        }

        private void loadPrices(PriceList priceList, DataTable prices)
        {
            if (prices != null)
            {
                // Invertir el orden de las filas
                prices = prices.AsEnumerable().Reverse().CopyToDataTable();
                dgvPrices.DataSource = prices;
            }
            else
            {
                txtDescription.Text = priceList.description;
                cbState.SelectedIndex = priceList.state;
                DataTable dtPrices = new PriceList_Controller().getPricesByPriceListDT(priceList.id);

                // Invertir el orden de las filas
                dgvPrices.DataSource = dtPrices;
            }

            dgvPrices.Columns["Identificacion"].Visible = false;
            dgvPrices.Columns["IdentificacionListaPrecios"].Visible = false;
            dgvPrices.Columns["CodigoArticulo"].ReadOnly = true;
            dgvPrices.Columns["CodigoArticulo"].HeaderText = "Código Artículo";
            dgvPrices.Columns["PrecioVenta"].ReadOnly = true;
            dgvPrices.Columns["PrecioVenta"].HeaderText = "Precio Venta";
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

        

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvPrices.Rows[e.RowIndex];
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
                                double price = new PriceList_Controller().ItemAverageCost(item.code);
                                //calculate the new price using only 2 decimals
                                rowView["PrecioVenta"] = Math.Round(price + (price * Convert.ToDouble(rowView["Factor"])), 2);
                            }
                            // Hacer el upsert solo si es una fila nueva y tiene todos los valores requeridos
                            bool success = new PriceList_Controller().upsertPrice(rowView.Row);
                            if (!success)
                            {
                                MessageBox.Show("Error al realizar la acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            int id = new PriceList_Controller().upsertPriceList(priceList);
            if (id >= 0)
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
            if (e.ColumnIndex == dgvPrices.Columns["CodigoArticulo"].Index)
            {
                // Forzar la validación de la fila para guardar los cambios
                dgvPrices.NotifyCurrentCellDirty(true);
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
            if (dgvPrices.Columns[e.ColumnIndex].HeaderText == "Estado" && e.Value != null)
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

        private void txtDescription_Leave(object sender, EventArgs e)
        {
        }

       
        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();
            // if dgvPrices is empty return
            if (dgvPrices.Rows.Count == 0)
            {
                return;
            }

            if (filterValue == "" )
            {
                loadPrices(globalList, null);
            }
            else
            {
                DataTable dt = new PriceList_Controller().getPricesByPriceListDT(priceListId.Value);
                dt.DefaultView.RowFilter = $"CodigoArticulo LIKE '%{filterValue}%'";
                loadPrices(null, dt);

            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();

        }

        private void txtFactor_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (e.KeyChar != 8)
            {


                string input = textBox.Text.Insert(textBox.SelectionStart, e.KeyChar.ToString());
                Regex regex = new Regex(@"^\d*(\,\d{0,2})?$");
                if (char.IsControl(e.KeyChar))
                {
                    return;
                }

                if (!regex.IsMatch(input))
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar == ',' && textBox.Text.Length == 0) return;
        }

        private void txtFactor_Leave(object sender, EventArgs e)
        {
            if (!txtDescription.Text.ToString().Equals("") && priceListId == 0)
            {
                PriceList priceList = new PriceList()
                {
                    id = priceListId ?? 0,
                    description = txtDescription.Text.ToString(),
                    state = ((KeyValuePair<int, string>)cbState.SelectedItem).Key
                };

                int id = new PriceList_Controller().upsertPriceList(priceList);
                if (id > 0)
                {
                    if (!txtFactor.Text.ToString().Equals(""))
                    {
                        this.priceListId = id;
                        double factor = Convert.ToDouble(txtFactor.Text);

                        if (new Item_Controller().insertItemsInPriceList(id, new Item_Controller().getAll(), factor))
                        {
                            DataChanged?.Invoke(this, EventArgs.Empty);
                            loadPrices(new PriceList_Controller().getPriceList(id), null);
                            dgvPrices.Refresh();
                            txtFactor.Enabled = false;
                            MessageBox.Show("Acción realizada con exito.", "LubriTech Informa:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al realizar la acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Error al realizar la acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
