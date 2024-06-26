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
    public partial class frmManage_Branch : Form
    {
        public frmManage_Branch()
        {
            InitializeComponent();
        }

        private void frmManage_Branch_Load(object sender, EventArgs e)
        {

        }

        Point cursor;
        bool dragging = false;

        //move the form by clicking and dragging the mouse on the panel header (panelHeader)
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true; // Enable dragging
            cursor = new Point(e.X, e.Y);// Get cursor's position according to form's area
        }



        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false; // Disable dragging
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
            this.Close();
        }
    }
}
