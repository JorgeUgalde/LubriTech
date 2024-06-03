﻿using System;
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
        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();

        public MDI_View()
        {
            InitializeComponent();
            InitializeMenu();
            this.Resize += new EventHandler(OnFormResize);
            OnFormResize(this, EventArgs.Empty); // Ajustar el tamaño inicial
        }

        private void InitializeMenu()
        {
            // Crear el TableLayoutPanel
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.BackColor = Color.FromArgb(156, 29, 29);
            tableLayoutPanel.Dock = DockStyle.Left;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Crear el panel para los botones del menú
            this.panel1.Dock = DockStyle.Top;
            tableLayoutPanel.Controls.Add(panel1, 0, 0);
            panel1.Controls.Add(btnMenu);

            this.panelBtns.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(panelBtns, 0, 1);

            // Crear y agregar botones al panel del menú
            btnClients.Size = new Size(200, 50);
            btnClients.Dock = DockStyle.Top;
            panelBtns.Controls.Add(btnClients);
            btnWorkOrders.Size = new Size(200, 50);
            btnWorkOrders.Dock = DockStyle.Top;
            panelBtns.Controls.Add(btnWorkOrders);
            btnAppointments.Size = new Size(200, 50);
            btnAppointments.Dock = DockStyle.Top;
            panelBtns.Controls.Add(btnAppointments);
            btnInventory.Size = new Size(200, 50);
            btnInventory.Dock = DockStyle.Top;
            panelBtns.Controls.Add(btnInventory);
            btnProducts.Size = new Size(200, 50);
            btnProducts.Dock = DockStyle.Top;
            panelBtns.Controls.Add(btnProducts);
            btnServices.Size = new Size(200, 50);
            btnServices.Dock = DockStyle.Top;
            panelBtns.Controls.Add(btnServices);
            btnSuppliers.Size = new Size(200, 50);
            btnSuppliers.Dock = DockStyle.Top;
            panelBtns.Controls.Add(btnSuppliers);
            btnVehicles.Size = new Size(200, 50);
            btnVehicles.Dock = DockStyle.Top;
            panelBtns.Controls.Add(btnVehicles);

            // Crear el botón de cerrar sesión
            btnLogout.Size = new Size(200, 50);
            btnLogout.Dock = DockStyle.Bottom;
            tableLayoutPanel.Controls.Add(btnLogout, 0, 2);

            // Agregar el TableLayoutPanel al formulario
            this.Controls.Add(tableLayoutPanel);
            panel1.Size = new Size(200, 50);
            panelBtns.Size = new Size(200, 500);
            tableLayoutPanel.MinimumSize = new Size(42, 500);
            tableLayoutPanel.MaximumSize = new Size(200, this.ClientSize.Height);
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
            //this.Visible = false;
            //frmLogin frmLogin = new frmLogin();
            //frmLogin.ShowDialog();
            //this.Visible = true;
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
                tableLayoutPanel.Width -= 10;
                if (tableLayoutPanel.Width == tableLayoutPanel.MinimumSize.Width)
                {
                    sideBarExpanded = false;
                    sideBarTimer.Stop();
                }
            }
            else
            {
                tableLayoutPanel.Width += 10;
                if (tableLayoutPanel.Width == tableLayoutPanel.MaximumSize.Width)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            // Iniciar el temporizador
            sideBarTimer.Start();

        }

        private void OnFormResize(object sender, EventArgs e)
        {
            tableLayoutPanel.MaximumSize = new Size(200, this.ClientSize.Height);
        }
    }
}
