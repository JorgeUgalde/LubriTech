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
    public partial class frmEngine : Form
    {
        private List<Engine> engine;

        public frmEngine()
        {
            engine = new List<Engine>();
            InitializeComponent();
            SetupDataGridView();
            load_Engines(null);
        }

        private void frmEngine_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        private void load_Engines(List<Engine> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvEngines.DataSource = engine;

                }
                else
                {
                    dgvEngines.DataSource = filteredList;
                }
            }
            else
            {
                engine = new Engine_Controller().getAll();
                if (engine == null)
                {
                    MessageBox.Show("No hay tipos de motor registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvEngines.DataSource = engine;
            }
            dgvEngines.Columns["Id"].Visible = false;
            dgvEngines.Columns["EngineType"].HeaderText = "Tipo Motor";
            dgvEngines.Columns["State"].HeaderText = "Estado";
            SetColumnOrder();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            // Filtrar la lista de tipos de motor
            var filteredList = engine.Where(p =>
                p.Id.ToString().Contains(filterValue) ||
                p.EngineType.ToLower().Contains(filterValue) ||
                p.State.ToLower().Contains(filterValue)
            ).ToList();

            // Refrescar el DataGridView
            dgvEngines.DataSource = null;
            load_Engines(filteredList);
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Engines(null);
        }

        private void SetupDataGridView()
        {
            DataGridViewImageColumn modifyImageColumn = new DataGridViewImageColumn();
            modifyImageColumn.Name = "ModifyImageColumn";
            modifyImageColumn.HeaderText = "Modificar";
            modifyImageColumn.Image = Properties.Resources.edit;
            dgvEngines.Columns.Add(modifyImageColumn);

            DataGridViewImageColumn detailImageColumn = new DataGridViewImageColumn();
            detailImageColumn.Name = "DetailImageColumn";
            detailImageColumn.HeaderText = "Detalles";
            detailImageColumn.Image = Properties.Resources.detail;
            dgvEngines.Columns.Add(detailImageColumn);
        }

        private void SetColumnOrder()
        {
            dgvEngines.Columns["Id"].DisplayIndex = 0;
            dgvEngines.Columns["EngineType"].DisplayIndex = 1;
            dgvEngines.Columns["State"].DisplayIndex = 2;
            dgvEngines.Columns["DetailImageColumn"].DisplayIndex = 3;
            dgvEngines.Columns["ModifyImageColumn"].DisplayIndex = 4;
        }

        private void btnAddEngine_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Engine frmUpsertEngine = new frmInsertUpdate_Engine();
            frmUpsertEngine.MdiParent = this.MdiParent;
            frmUpsertEngine.DataChanged += ChildFormDataChangedHandler;
            frmUpsertEngine.Show();
        }

        private void dgvEngines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvEngines.Columns["ModifyImageColumn"].Index && e.RowIndex >= 0)
            {
                int selectedEngineId = Convert.ToInt32(dgvEngines.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                List<Engine> engines = new Engine_Controller().getAll();
                Engine selectedEngine = null;
                foreach (Engine engine in engines)
                {
                    if (engine.Id == selectedEngineId)
                    {
                        selectedEngine = engine;
                        break;
                    }
                }

                string action = "Modify";
                frmInsertUpdate_Engine frmInsertEngine = new frmInsertUpdate_Engine(selectedEngine, action);
                frmInsertEngine.MdiParent = this.MdiParent;
                frmInsertEngine.DataChanged += ChildFormDataChangedHandler;
                frmInsertEngine.Show();
                return;
            }

            if (e.ColumnIndex == dgvEngines.Columns["DetailImageColumn"].Index && e.RowIndex >= 0)
            {
                int selectedEngineId = Convert.ToInt32(dgvEngines.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                List<Engine> engines = new Engine_Controller().getAll();
                Engine selectedEngine = null;
                foreach (Engine engine in engines)
                {
                    if (engine.Id == selectedEngineId)
                    {
                        selectedEngine = engine;
                        break;
                    }
                }
                string action = "Details";
                frmInsertUpdate_Engine frmInsertEngine = new frmInsertUpdate_Engine(selectedEngine, action);
                frmInsertEngine.MdiParent = this.MdiParent;
                frmInsertEngine.DataChanged += ChildFormDataChangedHandler;
                frmInsertEngine.Show();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
