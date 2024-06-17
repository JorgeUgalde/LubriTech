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

        /// <summary>
        /// Carga la lista de clientes en el DataGridView.
        /// </summary>
        /// <param name="filteredList">Lista de clientes filtrada (opcional).</param>
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

        /// <summary>
        /// Maneja el evento de cambio de datos en un formulario hijo.
        /// </summary>
        /// <param name="sender">Objeto que envió el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Clients(null);
        }

        /// <summary>
        /// Maneja el evento de cambio de texto en el cuadro de filtro.
        /// </summary>
        /// <param name="sender">Objeto que envió el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        /// <summary>
        /// Maneja el evento de clic en las celdas del DataGridView.
        /// </summary>
        /// <param name="sender">Objeto que envió el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
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
                frmInsertClient.MdiParent = this.MdiParent;
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
                frmInsertClient.MdiParent = this.MdiParent;
                frmInsertClient.DataChanged += ChildFormDataChangedHandler;
                frmInsertClient.Show();
                load_Clients(null);
                return;
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de agregar cliente.
        /// </summary>
        /// <param name="sender">Objeto que envió el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private async void btnAddClient_Click(object sender, EventArgs e)
        {
            frmUpsert_Client frmInsert_Client = new frmUpsert_Client();
            frmInsert_Client.MdiParent = this.MdiParent;
            frmInsert_Client.DataChanged += ChildFormDataChangedHandler;
            frmInsert_Client.Show();
        }

        /// <summary>
        /// Aplica el filtro a la lista de clientes.
        /// </summary>
        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            var filteredList = clients.Where(c =>
                c.Id.ToLower().Contains(filterValue) ||
                c.FullName.ToLower().Contains(filterValue) 
            ).ToList();

            load_Clients(filteredList);
        }

        /// <summary>
        /// Configura el DataGridView con las columnas de modificar y detalles.
        /// </summary>
        private void SetupDataGridView()
        {
            DataGridViewImageColumn modifyImageColumn = new DataGridViewImageColumn();
            modifyImageColumn.Name = "ModifyImageColumn";
            modifyImageColumn.HeaderText = "Modificar";
            modifyImageColumn.Image = Properties.Resources.edit;
            dgvClients.Columns.Add(modifyImageColumn);

            DataGridViewImageColumn detailImageColumn = new DataGridViewImageColumn();
            detailImageColumn.Name = "DetailImageColumn";
            detailImageColumn.HeaderText = "Detalles";
            detailImageColumn.Image = Properties.Resources.detail;
            dgvClients.Columns.Add(detailImageColumn);
        }

        /// <summary>
        /// Establece el orden de las columnas en el DataGridView.
        /// </summary>
        private void SetColumnOrder()
        {
            dgvClients.Columns["Id"].DisplayIndex = 0;
            dgvClients.Columns["FullName"].DisplayIndex = 1;
            dgvClients.Columns["State"].DisplayIndex = 2;
            dgvClients.Columns["DetailImageColumn"].DisplayIndex = 3;
            dgvClients.Columns["ModifyImageColumn"].DisplayIndex = 4;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de cerrar.
        /// </summary>
        /// <param name="sender">Objeto que envió el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
    }
}
