using LubriTech.Controller;
using LubriTech.Model.Vehicle_Information;
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
    public partial class frmMakes : Form
    {
        private List<Make> makes;
        public frmMakes()
        {
            InitializeComponent();
            SetupDataGridView();
            load_Makes(null);
        }

        private void frmMakes_Load(object sender, EventArgs e)
        {

        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Makes(null);
        }

        private void load_Makes(List<Make> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvMakes.DataSource = makes;

                }
                else
                {
                    dgvMakes.DataSource = filteredList;
                }
            }
            else
            {
                makes = new Make_Controller().getAll();
                if (makes.Count == 0)
                {
                    MessageBox.Show("No hay marcas registradas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvMakes.DataSource = makes;

            }
            dgvMakes.Columns["Id"].Visible = false;
            dgvMakes.Columns["Name"].HeaderText = "Nombre";
            dgvMakes.Columns["State"].HeaderText = "Estado";
            SetColumnOrder();
        }

        private void SetColumnOrder()
        {
            dgvMakes.Columns["Name"].DisplayIndex = 0;
            dgvMakes.Columns["State"].DisplayIndex = 1;
            dgvMakes.Columns["ModifyImageColumn"].DisplayIndex = 2;
            dgvMakes.Columns["DetailImageColumn"].DisplayIndex = 3;


            this.dgvMakes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);
            this.dgvMakes.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 10, 10, 10);
            this.dgvMakes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvMakes.RowHeadersVisible = false;
            this.dgvMakes.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
            this.dgvMakes.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            // add an alternative color to the rows
            this.dgvMakes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

        }


        private void SetupDataGridView()
        {
            DataGridViewImageColumn modifyImageColumn = new DataGridViewImageColumn();
            modifyImageColumn.Name = "ModifyImageColumn";
            modifyImageColumn.HeaderText = "Modificar";

            Image image = Properties.Resources.EditIco1;
            image = new Bitmap(image, new Size(50, 50));
            modifyImageColumn.Image = image;
            dgvMakes.Columns.Add(modifyImageColumn);

            DataGridViewImageColumn detailImageColumn = new DataGridViewImageColumn();
            detailImageColumn.Name = "DetailImageColumn";
            detailImageColumn.HeaderText = "Detalles";
            Image image1 = Properties.Resources.DetailIco;
            image1 = new Bitmap(image1, new Size(50, 50));
            detailImageColumn.Image = image1;

            dgvMakes.Columns.Add(detailImageColumn);
        }


        private void btnAddMake_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Make frmUpsertMake = new frmInsertUpdate_Make();
            frmUpsertMake.Owner = this;
            frmUpsertMake.DataChanged += ChildFormDataChangedHandler;
            frmUpsertMake.Show();

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();

            

        }
        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            var filteredList = makes.Where(p =>
                           p.Name.ToLower().Contains(filterValue) ||
                           p.State.ToLower().Contains(filterValue)
                           ).ToList();

            dgvMakes.DataSource = null;
            load_Makes(filteredList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddMake_Click_1(object sender, EventArgs e)
        {
            frmInsertUpdate_Make frmUpsertMake = new frmInsertUpdate_Make();
            frmUpsertMake.MdiParent = this.MdiParent;
            frmUpsertMake.DataChanged += ChildFormDataChangedHandler;
            frmUpsertMake.Show();
        }

        private void dgvMakes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvMakes.Columns["ModifyImageColumn"].Index)
                {
                    Make make = makes[e.RowIndex];
                    frmInsertUpdate_Make frmUpsertMake = new frmInsertUpdate_Make(make);
                    frmUpsertMake.MdiParent = this.MdiParent;
                    frmUpsertMake.DataChanged += ChildFormDataChangedHandler;
                    frmUpsertMake.Show();
                }
                if (e.ColumnIndex == dgvMakes.Columns["DetailImageColumn"].Index)
                {
                    Make make = makes[e.RowIndex];
                    frmInsertUpdate_Make frmUpsertMake = new frmInsertUpdate_Make(make);
                    frmUpsertMake.MdiParent = this.MdiParent;
                    frmUpsertMake.Show();
                }
            }
        }
    }
}
