using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmClients : Form
    {
        private List<Client> clients;

        public frmClients()
        {
            clients = new List<Client>();
            InitializeComponent();
            SetupDataGridView();
            load_Clients(null);
        }

        private void frmClients_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        
        private void load_Clients(List<Client> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvClients.DataSource = clients;

                }
                else
                {
                    dgvClients.DataSource = filteredList;
                }
            }
            else
            {
                clients = new Clients_Controller().getAll();
                if (clients.Count == 0)
                {
                    MessageBox.Show("No hay clientes registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvClients.DataSource = clients;

            }
            dgvClients.Columns["Id"].HeaderText = "Identificación";
            dgvClients.Columns["FullName"].HeaderText = "  Nombre Completo";
            dgvClients.Columns["State"].HeaderText = "  Estado";
            foreach (DataGridViewColumn column in dgvClients.Columns)
            {
                if (column.Name != "Id" && column.Name != "FullName" && column.Name != "State" &&
                    column.Name != "ModifyImageColumn" && column.Name != "DetailImageColumn")
                {
                    column.Visible = false;
                }
            }
            dgvClients.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            SetColumnOrder();

            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgvClients,
                new object[] { true });
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Clients(null);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvClients.Columns["ModifyImageColumn"].Index && e.RowIndex >= 0)
            {
                string idToModify = dgvClients.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                List<Client> clients = new Clients_Controller().getAll();
                Client clientSelected = null;

                foreach (Client client in clients)
                {
                    if (client.Id == idToModify)
                    {
                        clientSelected = client;
                        break;
                    }
                }
                string action = "Modify";
                frmUpsert_Client frmInsertClient = new frmUpsert_Client(clientSelected, action);
                frmInsertClient.Owner = this;
                frmInsertClient.DataChanged += ChildFormDataChangedHandler;
                frmInsertClient.Show();
                load_Clients(null);
                return;
            }

            if (e.ColumnIndex == dgvClients.Columns["DetailImageColumn"].Index && e.RowIndex >= 0)
            {
                string idToConsult = dgvClients.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                List<Client> clients = new Clients_Controller().getAll();
                Client clientSelected = null;

                foreach (Client client in clients)
                {
                    if (client.Id == idToConsult)
                    {
                        clientSelected = client;
                        break;
                    }
                }
                string action = "Details";
                frmUpsert_Client frmInsertClient = new frmUpsert_Client(clientSelected, action);
                frmInsertClient.Owner = this;
                frmInsertClient.DataChanged += ChildFormDataChangedHandler;
                frmInsertClient.Show();
                load_Clients(null);
                return;
            }

        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            frmUpsert_Client frmInsert_Client = new frmUpsert_Client();
            frmInsert_Client.MdiParent = this.MdiParent;  // Establecer el formulario principal como el contenedor MDI
            frmInsert_Client.DataChanged += ChildFormDataChangedHandler;
            frmInsert_Client.Show();
        }

        private void ApplyFilter()
        {
            //dgvClients.SuspendLayout();
            string filterValue = txtFilter.Text.ToLower();

            // Filtrar la lista de productos
            var filteredList = clients.Where(c =>
                c.Id.ToLower().Contains(filterValue) ||
                c.FullName.ToLower().Contains(filterValue) 
            ).ToList();

            // Refrescar el DataGridView
            //dgvClients.DataSource = null;
            load_Clients(filteredList);
        }

        private void SetupDataGridView()
        {

            // Crear y configurar la columna para modificar
            DataGridViewImageColumn modifyImageColumn = new DataGridViewImageColumn();
            modifyImageColumn.Name = "ModifyImageColumn";
            modifyImageColumn.HeaderText = "Acciones";
            modifyImageColumn.Image = Properties.Resources.edit;
            dgvClients.Columns.Add(modifyImageColumn);

            // Crear y configurar la columna para detalles
            DataGridViewImageColumn detailImageColumn = new DataGridViewImageColumn();
            detailImageColumn.Name = "DetailImageColumn";
            detailImageColumn.HeaderText = "Detalles";
            detailImageColumn.Image = Properties.Resources.detail;
            dgvClients.Columns.Add(detailImageColumn);

           

        }

        private void SetColumnOrder()
        {
            dgvClients.Columns["Id"].DisplayIndex = 0;
            dgvClients.Columns["FullName"].DisplayIndex = 1;
            dgvClients.Columns["State"].DisplayIndex = 2;
            dgvClients.Columns["DetailImageColumn"].DisplayIndex = 3;
            dgvClients.Columns["ModifyImageColumn"].DisplayIndex = 4;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
    }
}
