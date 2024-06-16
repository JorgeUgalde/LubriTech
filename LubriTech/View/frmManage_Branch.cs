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

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
                // Get the current mouse position relative to the screen
                if (dragging)
                {
                Point currentScreenPos = panelHeader.PointToScreen(e.Location);

                // Convert the screen coordinates to MDI parent client coordinates
                Point mdiClientPoint = this.MdiParent.PointToClient(currentScreenPos);

                // Calculate the new location of the form
                Point newLocation = new Point(mdiClientPoint.X - cursor.X, mdiClientPoint.Y - cursor.Y);

                // Move the form to the new location
                this.Location = newLocation;
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false; // Disable dragging
        }
    }
}
