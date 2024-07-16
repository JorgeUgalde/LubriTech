using iTextSharp.text;
using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        private int currentPage = 1;
        private int pageSize = 20; // Puedes ajustar este valor según sea necesario
        private int totalRecords = 0;
        private int totalPages = 0;

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
               workorders = filteredList;
                
            }
            else
            {
                workorders = new Work_Order_Controller().loadWorkOrders();
               
            }
            if (workorders.Count == 0)
            {
                MessageBox.Show("No hay ordenes de trabajo registradas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            totalRecords = workorders.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            LoadPage();
            SetColumns();

        }
        private void LoadPage()
        {
            int startRecord = (currentPage - 1) * pageSize;
            int endRecord = Math.Min(currentPage * pageSize, totalRecords);

            var pageClients = workorders.Skip(startRecord).Take(endRecord - startRecord).ToList();
            dgvWorkOrders.DataSource = pageClients;

            lblPageNumber.Text = $"Página {currentPage} de {totalPages}";
        }

        private void SetColumns()
        {
            dgvWorkOrders.Columns["Branch"].Visible = false;
            dgvWorkOrders.Columns["CurrentMileage"].Visible = false;
            dgvWorkOrders.Columns["Amount"].Visible = false;
            dgvWorkOrders.Columns["Id"].HeaderText = "No Orden";
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
            if (filterValue == "")
            {
                LoadWorkOrders(null);
                return;
            }

            var filteredList = workorders.Where(c =>
                c.Client.FullName.ToLower().Contains(filterValue) ||
                //if vehicle exist filter by vehicle
                (c.Vehicle != null && c.Vehicle.LicensePlate.ToLower().Contains(filterValue)
                || c.State.ToString().ToLower().Contains(filterValue))
            ).ToList();

            if (filteredList.Count == 0)
            {
                LoadWorkOrders(null);
                return;
            }

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
            frmWorkOrder.DataChanged += ChildFormDataChangedHandler;
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
                            e.Value = "Finalizado";
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
                frmWorkOrderDetails.DataChanged += ChildFormDataChangedHandler;
                frmWorkOrderDetails.Show();
            }
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPage();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage();
            }
        }
    }
}
