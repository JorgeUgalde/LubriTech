using LubriTech.Controller;
using LubriTech.Model.Appointment_Information;
using LubriTech.Model.Client_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LubriTech.View.Appointment_View
{

    /// <summary>
    /// Class that handles the appointment form
    /// </summary>
    public partial class frmAppointment : Form
    {
        /// <summary>
        /// Variables to handle the month, year and day of the appointment
        /// </summary>      

        private int month, year, day;

        /// <summary>
        /// Variables to handle the next and previous month
        /// </summary>
        private string next = "next";
        private string previous = "previous";
        /// <summary>
        /// Variables to handle the start and end hour of work schedule, and the duration of the appointment
        /// </summary>
        private int startHour = 8;
        private int endHour = 17;
        private int appointmentDuration = 30;



        /// <summary>
        /// Variables to handle the selected button and the list of appointments
        /// </summary>

        private Button selectedButton = null;

        /// <summary>
        /// List of appointments of the day
        /// </summary>

        private List<Appointment> appointments;

        /// <summary>
        /// client to assign the appointment
        /// </summary>

        private Client newAppointmentClient;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        public frmAppointment()
        {
            InitializeComponent();
            appointments  = new List<Appointment>();
        }

        /// <summary>
        /// Load the form and call the function to display the days of the actual month
        /// </summary>
        /// <param name="sender"> Event sender</param>
        /// <param name="e"> event arguments </param>
        private void frmAppointment_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        /// <summary>
        /// Event handler for the next button, call a funtion to display the next month
        /// </summary>
        /// <param name="sender"> Event sender</param>
        /// <param name="e"> event arguments </param>
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            setMonthInfo(next);

        }
        /// <summary>
        ///  Event handler for the previous button, call a funtion to display the previous month
        /// </summary>
        /// <param name="sender"> Event sender</param>
        /// <param name="e"> event arguments </param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            setMonthInfo(previous);
        }

        /// <summary>
        /// Event handler for the today button, call a funtion to display the actual month
        /// </summary>
        private void displayDays()
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
            day = DateTime.Now.Day;
            DateTime now = DateTime.Now;

            setMonthInfo("");
            DisplayAppointments(day);
        }


        /// <summary>
        /// Create the days of the month in the form and set information of the month, set information of the day in spanish
        /// </summary>
        /// <param name="type"> it specifies if is a previus motnh, next month or actual month </param>
        /// <param name="selectedMonth"></param>
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

            /// Use the spanish culture to set the date information in spanish
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

                // if is the actual day, set a border to identify it
                if (i == day && month == DateTime.Now.Month && year == DateTime.Now.Year)
                {
                    userControlDays.BackColor = Color.FromArgb(70, 125, 185);
                }

            }
        }

        /// <summary>
        /// Event handler for the day clicked, call a function to display the appointments of the day
        /// </summary>
        /// <param name="sender"> Event sender </param>
        /// <param name="e"> Event arguments</param>
        private void UserControlDays_DayClicked(object sender, EventArgs e)
        {
            UserControlDays userControlDays = sender as UserControlDays;


            if (userControlDays != null)
            {
                DisplayAppointments(-1);

            }
        }


        /// <summary>
        /// Use the selected day to display the appointments of the day
        /// </summary>
        /// <param name="day"> Day selected </param>
        private void DisplayAppointments(int day)
        {
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

                    // create a panel to hold the appointment button and label
                    Panel simpleAppointmentPanel = new Panel
                    {
                        Size = new Size( Convert.ToInt32(pnlAppointments.Width *0.7f), 50),
                        Dock = DockStyle.Top,
                        Padding = new Padding(0, 3, 0, 0),
                    };

                    // Create a label to show the time of the appointment
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

                    // Create a button to assign the appointment
                    Button appointmentButton = new Button
                    {
                        Text = "Asignar Cita",
                        TextAlign = ContentAlignment.MiddleLeft,
                        BackColor = Color.White,
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

                    // Create a tooltip to show the time of the appointment
                    simpleAppointmentPanel.Controls.Add(appointmentButton);
                    simpleAppointmentPanel.Controls.Add(appointmentLabel);

                    pnlAppointments.Controls.Add(simpleAppointmentPanel);

                }
            }
            // Get the appointments of the selected day
            GetAppointments(selectedDate);
        }


        /// <summary>
        /// Get the appointments of the selected day
        /// </summary>
        /// <param name="selectedDate">Day selected to see the appointments </param>
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
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for the appointment button, assign or cancel an appointment
        /// </summary>
        /// <param name="sender"> Sender of the event</param>
        /// <param name="e"> Event arguments</param>
        private void AppointmentButton_Click(object sender, EventArgs e)
        {

            selectedButton = sender as Button;

            // If the button is already assigned, ask if the user wants to cancel the appointment
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
                            selectedButton.BackColor = Color.White;
                            selectedButton.Text = "Asignar Cita";
                            selectedButton = null;
                            appointments.Remove(appointment);
                        }
                        else
                        {
                            MessageBox.Show("Error al cancelar la cita");
                        }
                    }

                }
            }

            // Check if the client is selected, if so, assign the appointment
            if (newAppointmentClient != null)
            {
                if (selectedButton != null)
                {
                    DateTime date = (DateTime)selectedButton.Tag;
                    Appointment newAppointment = new Appointment
                    {
                        AppointmentDate = date,
                        client = newAppointmentClient,
                        State = 1,
                        branch = new Branch_Controller().get(1)
                    };

                    if (new Appointment_Controller().UpsertAppointment(newAppointment))
                    {
                        selectedButton.Text = newAppointmentClient.FullName;
                        selectedButton.BackColor = Color.LightBlue;
                        selectedButton = null;
                        newAppointmentClient = null;
                        txtId.Text = "";
                        txtName.Text = "";
                        appointments.Add(newAppointment);
                        MessageBox.Show("Cita guardada con éxito", "Cita Agendada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la cita");
                        newAppointment = null;
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for the search button, open the client form to search a client
        /// </summary>
        /// <param name="selectedClient"> Gets the selected client for the appointment</param>
        private void HandleClientSelected(Client selectedClient)
        {
            SelectClientAppointment(selectedClient);
        }

        /// <summary>
        /// Use the identification of the client to search it in the database and use it for the appointment
        /// </summary>
        /// <param name="sender"> Event sender</param>
        /// <param name="e"> event arguments </param>
        /// 
        private async void txtId_TextChanged(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if (id.Length > 4)
            {
                Client client = await new Clients_Controller().get(id);

                if (client != null)
                {
                    SelectClientAppointment(client);
                }
            }
        }

        /// <summary>
        /// Open the client form to search a client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            frmClients frmClients = new frmClients(this);
            frmClients.ClientSelected += HandleClientSelected;
            frmClients.MdiParent = this.MdiParent;
            frmClients.Show();
        }

        /// <summary>
        /// Get the selected client and assign it to the appointment
        /// </summary>
        /// <param name="client"></param>
        public void SelectClientAppointment(Client client)
        {
            if (client != null)
            {
                this.newAppointmentClient = client;
                txtName.Text = client.FullName;
                txtId.Text = client.Id;
            }


        }
    }
}
