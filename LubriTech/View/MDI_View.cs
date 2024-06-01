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
    public partial class MDI_View : Form
    {
        private int childFormNumber = 0;
        private bool sideBarExpanded = true;

        public MDI_View()
        {
            InitializeComponent();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDI_View_Load(object sender, EventArgs e)
        {

        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            frmClients frmClients = new frmClients();
            OpenChildForm(frmClients);

        }



        private void sideBarTimer_Tick(object sender, EventArgs e)
        {
            if(sideBarExpanded)
            {
                sideBarContainer.Width -= 10;
                if (sideBarContainer.Width == sideBarContainer.MinimumSize.Width)
                {
                    sideBarExpanded = false;
                    sideBarTimer.Stop();
                }
            }
            else
            {
                sideBarContainer.Width += 10;
                if (sideBarContainer.Width == sideBarContainer.MaximumSize.Width)
                {
                    sideBarExpanded = true;
                    sideBarTimer.Stop();
                }
            }
        }


           
        private void btnServices_Click(object sender, EventArgs e)
        {
            frmServices frmServices = new frmServices();
            OpenChildForm(frmServices);
        }

        private void OpenChildForm(Form childForm)
        {
            // Recorrer todos los formularios hijos abiertos
            foreach (Form form in this.MdiChildren)
            {
                // Cerrar el formulario hijo si está abierto
                form.Close();
            }

            // Configurar y mostrar el nuevo formulario hijo
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Dock = DockStyle.Fill; // Esto asegura que el formulario ocupe todo el espacio disponible
            childForm.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmProducts frmProducts = new frmProducts();
            OpenChildForm(frmProducts);
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            frmSuppliers frmSuppliers = new frmSuppliers();
            OpenChildForm(frmSuppliers);
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            frmVehicles frmVehicles = new frmVehicles();
            OpenChildForm(frmVehicles);
        }
    }
}
