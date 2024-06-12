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
using static System.Net.Mime.MediaTypeNames;

namespace LubriTech.View.Appointment_View
{
    public partial class frmAppointment : Form
    {

        public static int month, year;
        private string next = "next";
        private string previous = "previous";

        public frmAppointment()
        {
            InitializeComponent();
        }

        private void frmAppointment_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        private void displayDays()
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;

            setMonthInfo("");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            setMonthInfo(next);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            setMonthInfo(previous);
        }

        private void setMonthInfo(string type)
        {
            dayContainer.Controls.Clear();

            if (type == previous)
            {
                month--;
                if (month < 1)
                {
                    month = 12;
                    year--;
                }
            }
            else if (type == next)
            {
                month++;
                if (month > 12)
                {
                    month = 1;
                    year++;
                }
            }

            CultureInfo spanishCulture = new CultureInfo("es-ES");
            DateTime startOfMonth = new DateTime(year, month, 1);
            string monthName = startOfMonth.ToString("MMMM", spanishCulture);
            monthName = char.ToUpper(monthName[0]) + monthName.Substring(1);

            // Asignar el nombre del mes al control lblDate
            lblDate.Text = $"{monthName} {year}";

            int days = DateTime.DaysInMonth(year, month);
            int dayOfTheWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayOfTheWeek; i++)
            {
                UserControlBlank userControlBlank = new UserControlBlank();
                dayContainer.Controls.Add(userControlBlank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays userControlDays = new UserControlDays();
                userControlDays.days(i);
                dayContainer.Controls.Add(userControlDays);
            }
        }
    }
}
