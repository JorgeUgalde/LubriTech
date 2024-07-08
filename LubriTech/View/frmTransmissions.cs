using iTextSharp.text;
using LubriTech.Controller;
using LubriTech.Model.Client_Information;
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
        private int currentPage = 1;
        private int pageSize = 20; // Puedes ajustar este valor según sea necesario
        private int totalRecords = 0;
        private int totalPages = 0;

        public frmTransmissions()
        {
            transmissions = new List<Transmission>();
            InitializeComponent();
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
               transmissions = filteredList;               
            }
            else
            {
                transmissions = new Transmission_Controller().getAll();
            }
            if (transmissions == null)
            {
                MessageBox.Show("No hay tipos de transmisión registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            totalRecords = transmissions.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            currentPage = 1;
            LoadPage();

            dgvTransmissions.Columns["Id"].Visible = false;
            dgvTransmissions.Columns["TransmissionType"].HeaderText = "Tipo Transmisión";
            dgvTransmissions.Columns["State"].HeaderText = "Estado";
            SetColumnOrder();
        }

        private void LoadPage()
        {
            int startRecord = (currentPage - 1) * pageSize;
            int endRecord = Math.Min(currentPage * pageSize, totalRecords);

            var pageClients = transmissions.Skip(startRecord).Take(endRecord - startRecord).ToList();
            dgvTransmissions.DataSource = pageClients;

            lblPageNumber.Text = $"Página {currentPage} de {totalPages}";
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
                load_Transmissions(null);
                return;
            }
            // Filtrar la lista de tipos de motor
            var filteredList = transmissions.Where(p =>
                p.TransmissionType.ToLower().Contains(filterValue) ||
                p.State.ToLower().Contains(filterValue)
            ).ToList();
            if( filteredList.Count == 0)
            {
                load_Transmissions(null);
                return;
            }
            load_Transmissions(filteredList);
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Transmissions(null);
        }


        private void SetColumnOrder()
        {
            dgvTransmissions.Columns["Id"].DisplayIndex = 0;
            dgvTransmissions.Columns["TransmissionType"].DisplayIndex = 1;
            dgvTransmissions.Columns["State"].DisplayIndex = 2;
        }

        private void btnAddTransmission_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Transmission frmUpsertTransmission = new frmInsertUpdate_Transmission();
            frmUpsertTransmission.MdiParent = this.MdiParent;
            frmUpsertTransmission.DataChanged += ChildFormDataChangedHandler;
            frmUpsertTransmission.Show();
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPage();
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage();
            }
        }

        private void dgvTransmissions_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int transmissionId = Convert.ToInt32(dgvTransmissions.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                List<Transmission> transmissions = new Transmission_Controller().getAll();
                Transmission selectedTransmission = transmissions.FirstOrDefault(transmission => transmission.Id == transmissionId);
                if (selectedTransmission != null)
                {
                    frmInsertUpdate_Transmission frmUpsert = new frmInsertUpdate_Transmission(selectedTransmission);
                    this.WindowState = FormWindowState.Normal;
                    frmUpsert.MdiParent = this.MdiParent;
                    frmUpsert.DataChanged += ChildFormDataChangedHandler;
                    frmUpsert.Show();


                }
            }

        }
    }
}
