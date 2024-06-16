using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Product_Information;
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
            dgvClients.Columns["FullName"].HeaderText = "Nombre Completo";
            dgvClients.Columns["MainPhoneNum"].HeaderText = "Teléfono Principal";
            dgvClients.Columns["AdditionalPhoneNum"].HeaderText = "Teléfono Adicional";
            dgvClients.Columns["Email"].HeaderText = "Correo Electrónico";
            dgvClients.Columns["Address"].HeaderText = "Direccion";
            dgvClients.Columns["State"].HeaderText = "Estado";
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

                frmUpsert_Client frmInsertClient = new frmUpsert_Client(clientSelected);
                frmInsertClient.Owner = this;
                frmInsertClient.DataChanged += ChildFormDataChangedHandler;
                frmInsertClient.Show();
                load_Clients(null);
                return;
            }

            if (e.ColumnIndex == dgvClients.Columns["DeleteImageColumn"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Estás seguro de eliminar al cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string idToDelete = dgvClients.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    Clients_Controller cc = new Clients_Controller();
                    cc.remove(idToDelete);
                    load_Clients(null);
                    return;
                }
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            frmUpsert_Client frmInsert_Client = new frmUpsert_Client();
            frmInsert_Client.Owner = this;
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
            DataGridViewImageColumn modifyImageColumn = new DataGridViewImageColumn();
            modifyImageColumn.Name = "ModifyImageColumn";
            modifyImageColumn.HeaderText = "Modificar";
            modifyImageColumn.Image = Properties.Resources.EditIco1; 
            dgvClients.Columns.Add(modifyImageColumn);

            DataGridViewImageColumn deleteImageColumn = new DataGridViewImageColumn();
            deleteImageColumn.Name = "DeleteImageColumn";
            deleteImageColumn.HeaderText = "Eliminar";
            deleteImageColumn.Image = Properties.Resources.DeleteIco1;
            dgvClients.Columns.Add(deleteImageColumn);

            DataGridViewImageColumn detailImageColumn = new DataGridViewImageColumn();
            detailImageColumn.Name = "DetailImageColumn";
            detailImageColumn.HeaderText = "Detalles";
            detailImageColumn.Image = Properties.Resources.DetailIco;
            dgvClients.Columns.Add(detailImageColumn);
        }

        private void SetColumnOrder()
        {
            dgvClients.Columns["Id"].DisplayIndex = 0;
            dgvClients.Columns["FullName"].DisplayIndex = 1;
            dgvClients.Columns["MainPhoneNum"].DisplayIndex = 2;
            dgvClients.Columns["AdditionalPhoneNum"].DisplayIndex = 3;
            dgvClients.Columns["Email"].DisplayIndex = 4;
            dgvClients.Columns["Address"].DisplayIndex = 5;
            dgvClients.Columns["State"].DisplayIndex = 6;
            dgvClients.Columns["DetailImageColumn"].DisplayIndex = 7;
            dgvClients.Columns["ModifyImageColumn"].DisplayIndex = 8;
            dgvClients.Columns["DeleteImageColumn"].DisplayIndex = 9;
        }

        private void dgvClients_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvClients.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                dgvClients.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            this.dgvClients.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);
            this.dgvClients.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 10, 10, 10);
            this.dgvClients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvClients.RowHeadersVisible = false;

            // Celdas
            this.dgvClients.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
            this.dgvClients.Rows[e.RowIndex].DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
        }
    }
}
