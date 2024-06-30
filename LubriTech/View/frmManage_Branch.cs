using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using LubriTech.View.Appointment_View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmManage_Branch : Form
    {
        List <Branch> branches;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public frmManage_Branch()
        {
            InitializeComponent();
            load_Branches(null);
        }

        private void load_Branches(List<Branch> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvBranch.DataSource = branches;
                }
                else
                {
                    dgvBranch.DataSource = filteredList;
                }
            }
            else
            {
                branches = new Branch_Controller().getAll();
                if (branches.Count == 0 )
                {
                    MessageBox.Show("No hay Sucursales registradas", "Sin sucursales registradas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dgvBranch.DataSource = branches;
            }
            dgvBranch.Columns["Id"].HeaderText = "Identificacion";
            dgvBranch.Columns["Name"].HeaderText = "Nombre";
            dgvBranch.Columns["Address"].HeaderText = "Dirección";
            dgvBranch.Columns["Phone"].HeaderText = "Teléfono";
            dgvBranch.Columns["Email"].HeaderText = "Correo";
            dgvBranch.Columns["State"].HeaderText = "Estado";

            SetColumnOrder();

            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgvBranch,
                new object[] { true });

        }

        private void SetColumnOrder()
        {
            dgvBranch.Columns["Id"].Visible = false;
            dgvBranch.Columns["Name"].DisplayIndex = 0;
            dgvBranch.Columns["Address"].DisplayIndex = 1;
            dgvBranch.Columns["Phone"].DisplayIndex = 2;
            dgvBranch.Columns["Email"].DisplayIndex = 3;
            dgvBranch.Columns["State"].DisplayIndex = 4;
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Branches(null);
        }

        private void dgvBranch_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int branchId = Convert.ToInt32(dgvBranch.Rows[e.RowIndex].Cells["Id"].Value);
                Branch selectedBranch = branches.FirstOrDefault(branch => branch.Id == branchId);

                if (selectedBranch != null)
                {
                    frmInsertUpdate_Branch frmupsertBranch = new frmInsertUpdate_Branch(selectedBranch);
                    frmupsertBranch.MdiParent = this.MdiParent;
                    frmupsertBranch.DataChanged += ChildFormDataChangedHandler;
                    frmupsertBranch.Show();
                    load_Branches(null);
                }
            }
        }

        private void pbMaximize_Click_1(object sender, EventArgs e)
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
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filter = txtFilter.Text;
            List<Branch> filteredList = branches.Where(branch => branch.Name.ToLower().Contains(filter.ToLower())).ToList();
            load_Branches(filteredList);

        }


        private void btnAddClient_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Branch frmUpsert_Branch = new frmInsertUpdate_Branch();
            frmUpsert_Branch.MdiParent = this.MdiParent;
            frmUpsert_Branch.DataChanged += ChildFormDataChangedHandler;
            this.WindowState = FormWindowState.Normal;
            frmUpsert_Branch.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
