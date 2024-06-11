using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View.Appointment_View
{
    public partial class frmDayAppointments : Form
    {
        public frmDayAppointments()
        {
            InitializeComponent();
        }

        private void frmDayAppointments_Load(object sender, EventArgs e)
        {
            string day = UserControlDays.day;
            string dayName = new DateTime(frmAppointment.year, frmAppointment.month, Convert.ToInt32(day)).ToString("dddd", new CultureInfo("es-ES"));
            dayName = dayName.ToCharArray()[0].ToString().ToUpper() + dayName.Substring(1);

            lblDay.Text = dayName + " " + day;

            string monthName = new DateTime(frmAppointment.year, frmAppointment.month, Convert.ToInt32(day)).ToString("MMMM", new CultureInfo("es-ES"));
            monthName = monthName.ToCharArray()[0].ToString().ToUpper() + monthName.Substring(1);


            lblMonthYear.Text = monthName + " " + frmAppointment.year;
        }
    }
}
