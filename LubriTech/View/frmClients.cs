using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.View.Appointment_View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmClients : Form
    {
        private int currentPage = 1;
        private int pageSize = 20; // Puedes ajustar este valor según sea necesario
        private int totalRecords = 0;
        private int totalPages = 0;


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private List<Client> clients;
        private Form parentForm;
        public event Action<Client> ClientSelected;

        public frmClients()
        {
            clients = new List<Client>();
            InitializeComponent();
            load_Clients(null);
        }

        //Para manejar el cliente seleccionado
        public frmClients(Form parentForm)
        {
            clients = new List<Client>();
            this.parentForm = parentForm;
            InitializeComponent();
            load_Clients(null);
            
        }

        private void load_Clients(List<Client> filteredList)
        {
            if (filteredList != null)
            {
                clients = filteredList;
            }
            else
            {
                clients = new Clients_Controller().getAll();
            }

            if (clients.Count == 0)
            {
                MessageBox.Show("No hay clientes registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            totalRecords = clients.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            LoadPage();
            SetColumnOrder();
        }

        private void LoadPage()
        {
            int startRecord = (currentPage - 1) * pageSize;
            int endRecord = Math.Min(currentPage * pageSize, totalRecords);

            var pageClients = clients.Skip(startRecord).Take(endRecord - startRecord).ToList();
            dgvClients.DataSource = pageClients;

            lblPageNumber.Text = $"Página {currentPage} de {totalPages}";
        }


        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Clients(null);
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
                load_Clients(null);
                return;
            }

            var filteredList = clients.Where(c =>
                c.Id.ToLower().Contains(filterValue) ||
                c.FullName.ToLower().Contains(filterValue)
            ).ToList();

            currentPage = 1;
            totalRecords = filteredList.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (filteredList.Count == 0)
            {
                load_Clients(null);
                return;
            }
               load_Clients(filteredList);       

        }

        private void SetColumnOrder()
        {
            dgvClients.Columns["Id"].HeaderText = "Identificación";
            dgvClients.Columns["FullName"].HeaderText = "Nombre Completo";
            dgvClients.Columns["State"].HeaderText = "  Estado";
            dgvClients.Columns["PriceList"].HeaderText = " Lista de precios";
            dgvClients.Columns["MainPhoneNum"].Visible = false;
            dgvClients.Columns["AdditionalPhoneNum"].Visible = false;
            dgvClients.Columns["Email"].Visible = false;
            dgvClients.Columns["Address"].Visible = false;

            dgvClients.Columns["Id"].DisplayIndex = 0;
            dgvClients.Columns["FullName"].DisplayIndex = 1;
            dgvClients.Columns["State"].DisplayIndex = 2;
            dgvClients.Columns["PriceList"].DisplayIndex = 3;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvClients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string clientId = dgvClients.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                List<Client> clients = new Clients_Controller().getAll();
                Client selectedClient = clients.FirstOrDefault(client => client.Id == clientId);

                if (selectedClient != null)
                {
                    if (parentForm is frmInsertUpdate_Vehicle)
                    {
                        ((frmInsertUpdate_Vehicle)parentForm).ShowClientInUpsertVehicle(selectedClient);
                        this.Close();
                    }
                    else if (parentForm is frmAppointment)
                    {
                        ((frmAppointment)parentForm).SelectClientAppointment(selectedClient);
                        this.Close();
                    }
                    else if (parentForm is frmWorkOrder)
                    {
                        ((frmWorkOrder)parentForm).SelectClientWorkOrder(selectedClient);
                        this.Close();
                    }
                    else
                    {
                        frmUpsert_Client frmInsertClient = new frmUpsert_Client(selectedClient);
                        this.WindowState = FormWindowState.Normal;
                        frmInsertClient.MdiParent = this.MdiParent;
                        frmInsertClient.DataChanged += ChildFormDataChangedHandler;
                        frmInsertClient.Show();
                        load_Clients(null);
                    }
                }
            }
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

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAddClient_Click_1(object sender, EventArgs e)
        {
            frmUpsert_Client frmInsert_Client = new frmUpsert_Client();
            this.WindowState = FormWindowState.Normal;
            frmInsert_Client.MdiParent = this.MdiParent;
            frmInsert_Client.DataChanged += ChildFormDataChangedHandler;
            frmInsert_Client.Show();
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPage();
            }
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage();
            }
        }
    }
}
