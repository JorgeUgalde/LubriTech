using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Product_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmClients : Form
    {
        public frmClients()
        {
            InitializeComponent();
            load_Clients();
            SetupDataGridView();
            
            
        }

        

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            // Refresh DataGridView here
            // For example:
            load_Clients();
        }

        private void SetupDataGridView()
        {
            // Modify button column
            DataGridViewButtonColumn modifyButtonColumn = new DataGridViewButtonColumn();
            modifyButtonColumn.Name = "ModifyButtonColumn";
            modifyButtonColumn.HeaderText = "Ver Detalles";
            modifyButtonColumn.Text = "Detalles - Modificar";
            modifyButtonColumn.UseColumnTextForButtonValue = true;
            dgvClients.Columns.Add(modifyButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.HeaderText = "Eliminar ";
            deleteButtonColumn.Text = "Eliminar";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dgvClients.Columns.Add(deleteButtonColumn);
        }

        private void load_Clients()
        {
            dgvClients.DataSource = new Clients_Controller().getAll();
        }

        private void frmClients_Load(object sender, EventArgs e)
        {
            load_Clients();
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvClients.Columns["ModifyButtonColumn"].Index && e.RowIndex >= 0)
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
                load_Clients();
                return;
            }

            if (e.ColumnIndex == dgvClients.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Estás seguro de eliminar al cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string idToDelete = dgvClients.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    Clients_Controller cc = new Clients_Controller();
                    cc.remove(idToDelete);
                    load_Clients();
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
        }
    }
}
