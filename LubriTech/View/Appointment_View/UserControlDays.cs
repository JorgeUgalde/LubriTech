using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View.Appointment_View
{
    public partial class UserControlDays : UserControl
    {
        public static string day;

        public UserControlDays()
        {
            InitializeComponent();
        }

        public void days(int numday)
        {
            lblDay.Text = numday + "";
        }

        public void appointments(int numAppointments)
        {
            lblAppointmentQuantity.Text = numAppointments + " Citas";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            day = lblDay.Text;
            frmDayAppointments frm = new frmDayAppointments();
            frm.Show();
        }
    }
}
