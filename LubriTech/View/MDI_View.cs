using LubriTech.View.Appointment_View;
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

    public partial class MDI_View : Form
    {
        private int childFormNumber = 0;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        public event EventHandler DataChanged;

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public MDI_View()
        {
            DoubleBuffered = true;
            InitializeComponent();
            customizesubMenuDesign();
        }

        private void customizesubMenuDesign()
        {
            panelMenu.MaximumSize = new Size(418, 1055);
            panelMenu.MinimumSize = new Size(0, 0);

            panelParametersSubmenu.Visible = false;

        }

        private void hideSubMenu()
        {
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
            foreach (Control control in this.Controls)
            {
                // #2
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    // #3
                    client.BackColor = Color.FromArgb(237,237,237);
                    // 4#
                    break;
                }
            }
            this.MinimumSize = WindowState == FormWindowState.Maximized ? Size : new Size(800, 600);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //sideBarTimer.Start();
            if (panelMenu.Visible)
            {
                panelMenu.Visible = false;
                //relocate the picture box to the right
                btnMenu.Location = new Point(8, 53);
            }
            else
            {
                panelMenu.Visible = true;
                int width = panelMenu.Width;
                //relocate the picture box to the left
                btnMenu.Location = new Point(326, 53);
            }

        }

        public void OpenChildForm(Form childForm)
        {
            // Configurar y mostrar el nuevo formulario hijo
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Normal;
            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.TopMost = true;
            childForm.Show();

        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            frmClients frmClients = new frmClients();
            OpenChildForm(frmClients);
            frmClients.BringToFront();
            frmClients.Focus();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            frmInventoryManagment frmInventoryManagment = new frmInventoryManagment();
            OpenChildForm(frmInventoryManagment);
            frmInventoryManagment.BringToFront();
        }

        private void btnParamConfig_Click(object sender, EventArgs e)
        {
            showSubMenu(panelParametersSubmenu);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmManage_Branch frmManage_Branch = new frmManage_Branch();
            OpenChildForm(frmManage_Branch);
            frmManage_Branch.BringToFront();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            frmAppointment frmAppointment = new frmAppointment();
            OpenChildForm(frmAppointment);
            frmAppointment.BringToFront();

           
        }

        private void btnWorkOrders_Click(object sender, EventArgs e)
        {
            frmWorOrdersList frmWorOrdersList = new frmWorOrdersList();
            OpenChildForm(frmWorOrdersList);
            frmWorOrdersList.BringToFront();
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

        private void button13_Click(object sender, EventArgs e)
        {
            frmPricesList frmPricesList = new frmPricesList();
            OpenChildForm(frmPricesList);
            frmPricesList.BringToFront();
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            frmSchedule frmSchedule = new frmSchedule();
            OpenChildForm(frmSchedule);
            frmSchedule.BringToFront();
        }

        private void btnItemTypes_Click(object sender, EventArgs e)
        {
            frmItemType frmItemType = new frmItemType();
            OpenChildForm(frmItemType);
            frmItemType.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmEngine frmEngine = new frmEngine();
            OpenChildForm(frmEngine);
            frmEngine.BringToFront();

        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            frmVehicles frmVehicles = new frmVehicles();
            OpenChildForm(frmVehicles);
            frmVehicles.BringToFront();
            frmVehicles.Focus();
        }

        private void btnSuppliers_Click_1(object sender, EventArgs e)
        {
            frmSuppliers frmSuppliers = new frmSuppliers();
            OpenChildForm(frmSuppliers);
            frmSuppliers.BringToFront();
            frmSuppliers.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmTransmissions frmTransmissions = new frmTransmissions();
            OpenChildForm(frmTransmissions);
            frmTransmissions.BringToFront();
            frmTransmissions.Focus();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmItemType frmItemType = new frmItemType();
            OpenChildForm(frmItemType);
            frmItemType.BringToFront();
            frmItemType.Focus();
        }

        private void pbMaximize_Click_1(object sender, EventArgs e)
        {
            //minimize the form
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            //confirm if the user wants to close the application
            DialogResult dialogResult = MessageBox.Show("Va a cerrar su sesión, desea continuar?", "Confirmar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            frmInsertUpdateUser frmInsertUpdateUser = new frmInsertUpdateUser(frmLogin.user);
            OpenChildForm(frmInsertUpdateUser);
            frmInsertUpdateUser.BringToFront();
            frmInsertUpdateUser.Focus();
        }

        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
