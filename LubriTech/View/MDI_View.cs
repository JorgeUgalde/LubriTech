using LubriTech.View.Appointment_View;
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
        private bool sideBarExpanded = false;

        public MDI_View()
        {
            DoubleBuffered = true;
            InitializeComponent();
            customizesubMenuDesign();
        }

        private void customizesubMenuDesign()
        {
            panelMenu.MaximumSize = new Size(250, 0);
            panelMenu.MinimumSize = new Size(0, 0);
            panelClientsSubmenu.Visible = false;
            panelInventorySubmenu.Visible = false;
            panelParametersSubmenu.Visible = false;

        }

        private void hideSubMenu()
        {
            if (panelClientsSubmenu.Visible == true)
                panelClientsSubmenu.Visible = false;
            if (panelInventorySubmenu.Visible == true)
                panelInventorySubmenu.Visible = false;
            if (panelParametersSubmenu.Visible == true)
                panelParametersSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void MDI_View_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //this.Visible = false;
            //frmLogin frmLogin = new frmLogin();
            //frmLogin.ShowDialog();
            //this.Visible = true;
        }





        private void sideBarTimer_Tick(object sender, EventArgs e)
        {
        //    if (sideBarExpanded)
        //    {
        //        panelMenu.Width -= 15;
        //        if (panelMenu.Width == panelMenu.MinimumSize.Width)
        //        {
        //            sideBarExpanded = false;
        //            sideBarTimer.Stop();
        //        }
        //    }
        //    else
        //    {
        //        panelMenu.Width += 15;
        //        if (panelMenu.Width == panelMenu.MaximumSize.Width)
        //        {
        //            sideBarExpanded = true;
        //            sideBarTimer.Stop();
        //        }
        //    }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //sideBarTimer.Start();
            if (panelMenu.Visible)
            {
                panelMenu.Visible = false;
                //relocate the picture box to the right
                pictureBox1.Location = new Point(5, 10);
            }
            else
            {
                panelMenu.Visible = true;
                //relocate the picture box to the left
                pictureBox1.Location = new Point(260, 10);
            }

        }

        public void OpenChildForm(Form childForm)
        {
            // Configurar y mostrar el nuevo formulario hijo
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Normal;
            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.Show();


        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            showSubMenu(panelClientsSubmenu);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            showSubMenu(panelInventorySubmenu);
        }

        private void btnParamConfig_Click(object sender, EventArgs e)
        {
            showSubMenu(panelParametersSubmenu);
        }

        private void btnClientMasterData_Click(object sender, EventArgs e)
        {
            frmClients frmClients = new frmClients();
            OpenChildForm(frmClients);
            frmClients.BringToFront();
            frmClients.Focus();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmManage_Branch frmManage_Branch = new frmManage_Branch();
            OpenChildForm(frmManage_Branch);
            frmManage_Branch.BringToFront();
        }

        private void btnVehicleMasterData_Click(object sender, EventArgs e)
        {
            frmVehicles frmVehicles = new frmVehicles();
            OpenChildForm(frmVehicles);
            frmVehicles.BringToFront();
            frmVehicles.Focus();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            frmAppointment frmAppointment = new frmAppointment();
            OpenChildForm(frmAppointment);
            frmAppointment.BringToFront();

           
        }

        private void btnWorkOrders_Click(object sender, EventArgs e)
        {
            frmWorkOrder frmWorkOrder = new frmWorkOrder();
            OpenChildForm(frmWorkOrder);
            frmWorkOrder.BringToFront();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            frmSuppliers frmSuppliers = new frmSuppliers();
            OpenChildForm(frmSuppliers);
            frmSuppliers.BringToFront();
            frmSuppliers.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnArticles_Click(object sender, EventArgs e)
        {
            frmItems frmItems = new frmItems();
            OpenChildForm(frmItems);
            frmItems.BringToFront();
            frmItems.Focus();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmMakes frmMakes = new frmMakes();
            OpenChildForm(frmMakes);
            frmMakes.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCarModels frmCarModels = new frmCarModels();
            OpenChildForm(frmCarModels);
            frmCarModels.BringToFront();
        }
    }
}
