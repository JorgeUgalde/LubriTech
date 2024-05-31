using LubriTech.Controller;
using LubriTech.Model.Supplier_Information;
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
    public partial class frmSuppliers : Form
    {
        Supplier_Controller sc = new Supplier_Controller();
        public frmSuppliers()
        {
            InitializeComponent();
            LoadSuppliers();
            SetupDataGridView();
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        //click event for each row in the DataGridView to open the frmInsertUpdateSupplier form
        private void dgvSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != dgvSuppliers.Columns["DeleteButtonColumn"].Index)
            {
                DataGridViewRow row = this.dgvSuppliers.Rows[e.RowIndex];
                string supplierId = row.Cells["id"].Value.ToString();
                frmInsertUpdateSupplier frm = new frmInsertUpdateSupplier(supplierId);
                frm.DataChanged += ChildFormDataChangedHandler;
                frm.Owner = this;
                frm.Show();
            }
        }

        private void LoadSuppliers()
        {
            dgvSuppliers.DataSource = new Supplier_Controller().getAll();
            dgvSuppliers.Columns["id"].HeaderText = "Codigo";
            dgvSuppliers.Columns["name"].HeaderText = "Name";
            dgvSuppliers.Columns["email"].HeaderText = "Correo electrónico";
            dgvSuppliers.Columns["phone"].HeaderText = "Teléfono";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frmInsertUpdateSupplier is the child form that will be opened
            frmInsertUpdateSupplier frm = new frmInsertUpdateSupplier();
            frm.DataChanged += ChildFormDataChangedHandler;
            frm.Owner = this;
            frm.Show();
            
        }

        // Event handler to refresh DataGridView when the event is raised
        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            // Refresh DataGridView here
            // For example:
            LoadSuppliers();
        }

        private void SetupDataGridView()
        {
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.HeaderText = "Acción";
            deleteButtonColumn.Text = "Eliminar";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dgvSuppliers.Columns.Add(deleteButtonColumn);

            // Handle CellContentClick event
            dgvSuppliers.CellContentClick += DataGridView_CellContentClick;
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on the delete button column
            if (e.ColumnIndex == dgvSuppliers.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
            {
                // Prompt confirmation dialog
                DialogResult result = MessageBox.Show("Estás seguro de eliminar al proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Get the value of the id column in the current row
                    string idToDelete = dgvSuppliers.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    //string idToDelete = dgvSuppliers.Rows[e.RowIndex].Cells["id"].ToString();

                    // Call your delete function
                    // Assuming your delete function is named DeleteFromDatabase
                    sc.Delete(idToDelete);

                    // Refresh DataGridView
                    LoadSuppliers();
                }
            }
        }

        private void dgvSuppliers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dgvSuppliers.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvSuppliers_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvSuppliers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                dgvSuppliers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}
