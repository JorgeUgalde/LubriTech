using LubriTech.Controller;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmTransmissions : Form
    {
        private List<Transmission> transmissions;

        public frmTransmissions()
        {
            transmissions = new List<Transmission>();
            InitializeComponent();
            SetupDataGridView();
            load_Transmissions(null);
        }

        private void frmTransmissions_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        private void load_Transmissions(List<Transmission> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvTransmissions.DataSource = transmissions;

                }
                else
                {
                    dgvTransmissions.DataSource = filteredList;
                }
            }
            else
            {
                transmissions = new Transmission_Controller().getAll();
                if (transmissions == null)
                {
                    MessageBox.Show("No hay tipos de transmisión registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvTransmissions.DataSource = transmissions;
            }
            dgvTransmissions.Columns["Id"].Visible = false;
            dgvTransmissions.Columns["TransmissionType"].HeaderText = "Tipo Transmisión";
            dgvTransmissions.Columns["State"].HeaderText = "Estado";
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
            var filteredList = transmissions.Where(p =>
                p.Id.ToString().Contains(filterValue) ||
                p.TransmissionType.ToLower().Contains(filterValue) ||
                p.State.ToLower().Contains(filterValue)
            ).ToList();

            // Refrescar el DataGridView
            dgvTransmissions.DataSource = null;
            load_Transmissions(filteredList);
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Transmissions(null);
        }

        private void SetupDataGridView()
        {
            DataGridViewImageColumn modifyImageColumn = new DataGridViewImageColumn();
            modifyImageColumn.Name = "ModifyImageColumn";
            modifyImageColumn.HeaderText = "Modificar";
            modifyImageColumn.Image = Properties.Resources.edit;
            dgvTransmissions.Columns.Add(modifyImageColumn);

            DataGridViewImageColumn detailImageColumn = new DataGridViewImageColumn();
            detailImageColumn.Name = "DetailImageColumn";
            detailImageColumn.HeaderText = "Detalles";
            detailImageColumn.Image = Properties.Resources.detail;
            dgvTransmissions.Columns.Add(detailImageColumn);
        }

        private void SetColumnOrder()
        {
            dgvTransmissions.Columns["Id"].DisplayIndex = 0;
            dgvTransmissions.Columns["TransmissionType"].DisplayIndex = 1;
            dgvTransmissions.Columns["State"].DisplayIndex = 2;
            dgvTransmissions.Columns["DetailImageColumn"].DisplayIndex = 3;
            dgvTransmissions.Columns["ModifyImageColumn"].DisplayIndex = 4;
        }

        private void btnAddTransmission_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Transmission frmUpsertTransmission = new frmInsertUpdate_Transmission();
            frmUpsertTransmission.MdiParent = this.MdiParent;
            frmUpsertTransmission.DataChanged += ChildFormDataChangedHandler;
            frmUpsertTransmission.Show();
        }

        private void dgvTransmission_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTransmissions.Columns["ModifyImageColumn"].Index && e.RowIndex >= 0)
            {
                int selectedTransmissionId = Convert.ToInt32(dgvTransmissions.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                List<Transmission> transmissions = new Transmission_Controller().getAll();
                Transmission selectedTransmission = null;
                foreach (Transmission transmission in transmissions)
                {
                    if (transmission.Id == selectedTransmissionId)
                    {
                        selectedTransmission = transmission;
                        break;
                    }
                }

                string action = "Modify";
                frmInsertUpdate_Transmission frmInsertTransmission = new frmInsertUpdate_Transmission(selectedTransmission, action);
                frmInsertTransmission.MdiParent = this.MdiParent;
                frmInsertTransmission.DataChanged += ChildFormDataChangedHandler;
                frmInsertTransmission.Show();
                return;
            }

            if (e.ColumnIndex == dgvTransmissions.Columns["DetailImageColumn"].Index && e.RowIndex >= 0)
            {
                int selectedTransmissionId = Convert.ToInt32(dgvTransmissions.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                List<Transmission> transmissions = new Transmission_Controller().getAll();
                Transmission selectedTransmission = null;
                foreach (Transmission transmission in transmissions)
                {
                    if (transmission.Id == selectedTransmissionId)
                    {
                        selectedTransmission = transmission;
                        break;
                    }
                }
                string action = "Details";
                frmInsertUpdate_Transmission frmInsertTransmission = new frmInsertUpdate_Transmission(selectedTransmission, action);
                frmInsertTransmission.MdiParent = this.MdiParent;
                frmInsertTransmission.DataChanged += ChildFormDataChangedHandler;
                frmInsertTransmission.Show();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
