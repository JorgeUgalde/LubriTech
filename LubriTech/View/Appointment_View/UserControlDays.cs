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
        public event EventHandler DayClicked;

        public UserControlDays()
        {
            InitializeComponent();
            this.Click += UserControlDays_Click;
            lblDay.Click += UserControlDays_Click; // Asegurarse de capturar el clic en la etiqueta también
        }

        public void days(int numDay)
        {
            lblDay.Text = numDay.ToString();
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            day = lblDay.Text;
            DayClicked?.Invoke(this, e); // Raise the event
        }

    }
}
