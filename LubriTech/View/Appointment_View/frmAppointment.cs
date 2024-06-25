using LubriTech.Controller;
using LubriTech.Model.Appointment_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LubriTech.View.Appointment_View
{
    public partial class frmAppointment : Form
    {

       
        public static int month, year, day;
        private string next = "next";
        private string previous = "previous";
        private int startHour = 8;
        private int endHour = 17;
        private int appointmentDuration = 30;
        private Button selectedButton = null;
        private List<Appointment> appointments;

        public frmAppointment()
        {
            InitializeComponent();
            appointments  = new List<Appointment>();
        }
       
        private void frmAppointment_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            setMonthInfo(next, -1);

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            setMonthInfo(previous, -1);
        }

        private void displayDays()
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
            day = DateTime.Now.Day;
            setMonthInfo("", -1);
            DisplayAppointments(day);

        }



        private void setMonthInfo(string type, int? selectedMonth)
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
            else if (selectedMonth != -1)
            {
                month = selectedMonth.Value;
            }

            CultureInfo spanishCulture = new CultureInfo("es-ES");
            DateTime startOfMonth = new DateTime(year, month, 1);
            string monthName = startOfMonth.ToString("MMMM", spanishCulture);
            monthName = char.ToUpper(monthName[0]) + monthName.Substring(1);
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
                userControlDays.DayClicked += new EventHandler(UserControlDays_DayClicked);
                dayContainer.Controls.Add(userControlDays);
            }
        }

        private void UserControlDays_DayClicked(object sender, EventArgs e)
        {
            UserControlDays userControlDays = sender as UserControlDays;


            if (userControlDays != null)
            {
                DisplayAppointments(-1);

            }
        }



        private void DisplayAppointments(int day)
        {
            // Limpiamos los controles existentes en el TableLayoutPanel
            pnlAppointments.Controls.Clear();
            int selectedDay;

            if (day > 0)
            {
                selectedDay = day;
            }
            else
            {
                int.TryParse(UserControlDays.day, out selectedDay);
            }

            CultureInfo spanishCulture = new CultureInfo("es-ES");
            DateTime startOfMonth = new DateTime(year, month, 1);
            string monthName = startOfMonth.ToString("MMMM", spanishCulture);
            monthName = char.ToUpper(monthName[0]) + monthName.Substring(1);
            lblDaySelected.Text = $"{selectedDay} de {monthName} del {year}";

            DateTime selectedDate = new DateTime(year, month, selectedDay);

            for (int hour = endHour - 1; hour >= startHour; hour--)
            {
                for (int minute = 60 - appointmentDuration; minute >= 0; minute -= appointmentDuration)
                {
                    DateTime appointmentTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, hour, minute, 0);

                    Panel simpleAppointmentPanel = new Panel
                    {
                        Size = new Size( Convert.ToInt32(pnlAppointments.Width *0.7f), 50),
                        Dock = DockStyle.Top,
                        Padding = new Padding(0, 3, 0, 0),
                    };

                    // Crear etiqueta para mostrar la hora de la cita
                    Label appointmentLabel = new Label
                    {
                        Text = appointmentTime.ToString("hh:mm tt"),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(Convert.ToInt32(pnlAppointments.Width * 0.3f), 50),
                        Padding = new Padding(5, 5, 5, 5),
                        Margin = new Padding(5),
                        BackColor = Color.LightGray,
                        Dock = DockStyle.Left,
                        Font = new Font("Segoe UI", 12)
                    };

                    // Crear botón para asignar la cita
                    Button appointmentButton = new Button
                    {
                        Text = "Asignar Cita",
                        TextAlign = ContentAlignment.MiddleLeft,
                        Tag = appointmentTime,
                        Size = new Size(Convert.ToInt32(pnlAppointments.Width * 0.7f), 50),
                        FlatStyle = FlatStyle.Popup,
                        Cursor = Cursors.Hand,
                        Padding = new Padding(5, 5, 5, 5),
                        Margin = new Padding(5),
                        Dock = DockStyle.Fill,
                        Font = new Font("Segoe UI", 12)
                    };
                    appointmentButton.Click += new EventHandler(AppointmentButton_Click);

                    // Crear un panel y poner la etiqueta a la izquierda y el botón a la derecha
                    simpleAppointmentPanel.Controls.Add(appointmentButton);
                    simpleAppointmentPanel.Controls.Add(appointmentLabel);

                    pnlAppointments.Controls.Add(simpleAppointmentPanel);

                }
            }

            GetAppointments(selectedDate);

        }


        // from DB, get the appointments for the selected day
        private void GetAppointments(DateTime selectedDate)
        {
            appointments = new Appointment_Controller().loadDayAppointments(selectedDate);

            foreach (Appointment appointment in appointments)
            {
                string appointmentTime = appointment.AppointmentDate.ToString("hh:mm tt");
                var controls = pnlAppointments.Controls.Cast<Control>();

                foreach (var panel in controls.OfType<Panel>())
                {
                    Button appointmentButton = panel.Controls.OfType<Button>()
                        .FirstOrDefault(btn => btn.Tag != null && ((DateTime)btn.Tag).ToString("hh:mm tt") == appointmentTime);

                    if (appointmentButton != null)
                    {
                        appointmentButton.BackColor = Color.LightBlue;
                        appointmentButton.Text = appointment.client.ToString();
                        //appointmentButton.Enabled = false;
                    }
                }
            }
        }







        private void AppointmentButton_Click(object sender, EventArgs e)
        {
            if (true)
            {
                selectedButton = sender as Button;
                // selectedButton has a client, show a confirm message to cancel date
                if (selectedButton != null && selectedButton.Text != "Asignar Cita")
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea cancelar la cita?", "Cancelar Cita", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string name = selectedButton.Text;
                        DateTime dateTime = (DateTime)selectedButton.Tag;

                        Appointment appointment = appointments.Find(a => a.client.ToString() == name && a.AppointmentDate == dateTime);
                        if (appointment != null)
                        {
                            if (new Appointment_Controller().CancelAppointment(appointment.AppointmentID))
                            {
                                MessageBox.Show("Cita cancelada exitosamente", "Cita Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                selectedButton.BackColor = Color.White;
                                selectedButton.Text = "Asignar Cita";
                                selectedButton.Enabled = true;
                                selectedButton = null;
                            }
                            else
                            {
                                MessageBox.Show("Error al cancelar la cita");
                            }
                        }

                    }
                }

            }

            //selectedButton = sender as Button;
            //selectedButton.BackColor = Color.Red;
            //DateTime appointmentTime = (DateTime)selectedButton.Tag;
            //MessageBox.Show("Cita programada a las " + appointmentTime.ToString("hh:mm tt"));
        }

        private void HandleClientSelected(Client selectedClient)
        {
            SelectClientAppointment(selectedClient);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmClients frmClients = new frmClients(this);
            frmClients.ClientSelected += HandleClientSelected;
            frmClients.MdiParent = this.MdiParent;
            frmClients.Show();
        }

        public void SelectClientAppointment(Client client)
        {
            if (client != null)
            {
                txtName.Text = client.FullName;
                txtId.Text = client.Id;
            }


        }
    }
}
