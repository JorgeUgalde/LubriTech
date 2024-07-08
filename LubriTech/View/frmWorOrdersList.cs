using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmWorOrdersList : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        List<WorkOrder> workorders;

        public frmWorOrdersList()
        {
            InitializeComponent();
            workorders = new List<WorkOrder>();
            LoadWorkOrders(null);
        }

        private void LoadWorkOrders(List<WorkOrder> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvWorkOrders.DataSource = workorders;

                }
                else
                {
                    dgvWorkOrders.DataSource = filteredList;
                }
            }
            else
            {
                workorders = new Work_Order_Controller().loadWorkOrders();
                if (workorders.Count == 0)
                {
                    MessageBox.Show("No hay ordenes de trabajo registradas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvWorkOrders.DataSource = workorders;
            }
            SetColumns();

            typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            dgvWorkOrders,
            new object[] { true });
        }

        private void SetColumns()
        {
            dgvWorkOrders.Columns["Branch"].Visible = false;
            dgvWorkOrders.Columns["CurrentMileage"].Visible = false;
            dgvWorkOrders.Columns["Amount"].Visible = false;
            dgvWorkOrders.Columns["Id"].Visible = false;
            dgvWorkOrders.Columns["Date"].HeaderText = "Fecha";
            dgvWorkOrders.Columns["Client"].HeaderText = "Cliente";
            dgvWorkOrders.Columns["Vehicle"].HeaderText = "Placa Vehículo";
            dgvWorkOrders.Columns["Vehicle"].DefaultCellStyle.NullValue = "No asignado";
            dgvWorkOrders.Columns["State"].HeaderText = "Estado";
        }

        private void frmWorOrdersList_Load(object sender, EventArgs e)
        {
            
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            LoadWorkOrders(null);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            var filteredList = workorders.Where(c =>
                c.Client.FullName.ToLower().Contains(filterValue)
            ).ToList();

            LoadWorkOrders(filteredList);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmWorkOrder frmWorkOrder = new frmWorkOrder(null);
            this.WindowState = FormWindowState.Normal;
            frmWorkOrder.MdiParent = this.MdiParent;
            frmWorkOrder.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvWorkOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvWorkOrders.Columns[e.ColumnIndex].HeaderText == "Estado" && e.Value != null)
            {
                int valorOriginal;
                // Intentar convertir el valor de la celda a entero
                if (int.TryParse(e.Value.ToString(), out valorOriginal))
                {
                    // Cambiar el valor mostrado según el valor original
                    switch (valorOriginal)
                    {
                        case 0:
                            e.Value = "Inactiva";
                            break;
                        case 1:
                            e.Value = "Activa";
                            break;
                        case 2:
                            e.Value = "En proceso";
                            break;
                        case 3:
                            e.Value = "Terminada";
                            break;
                        default:
                            // Si hay algún otro valor que no se espera, se deja como está
                            break;
                    }
                }
            }
        }

        private void dgvWorkOrders_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvWorkOrders.Rows[e.RowIndex];
                WorkOrder workOrder = (WorkOrder)row.DataBoundItem;
                frmWorkOrder frmWorkOrderDetails = new frmWorkOrder(workOrder.Id);
                this.WindowState = FormWindowState.Normal;
                frmWorkOrderDetails.MdiParent = this.MdiParent;
                frmWorkOrderDetails.Show();
            }
        }
    }
}
