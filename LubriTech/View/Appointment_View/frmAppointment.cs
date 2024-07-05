using LubriTech.Controller;
using LubriTech.Model.Appointment_Information;
using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
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
        /// 
        Schedule scheduleBranch;

        private TimeSpan startHour; 
        private TimeSpan endHour;
        private int appointmentDuration;

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
        /// 
        private Vehicle clientVehicle;

        Branch branch;

        Appointment appointment;

        /// <summary>
        ///  Class constructor to initialize the form
        /// </summary>
        public frmAppointment()
        {
            InitializeComponent();
            branch = new Branch_Controller().get(frmLogin.branch);
            appointments  = new List<Appointment>();
            scheduleBranch = new Schedule_Controller().get(0 , frmLogin.branch);
            startHour = scheduleBranch.StartHour;
            endHour = scheduleBranch.EndHour;
            appointmentDuration = scheduleBranch.appointmentDuration;
        }

        /// <summary>
        /// Load the form and call the function to display the days of the actual month
        /// </summary>
        /// <param name="sender"> Event sender</param>
        /// <param name="e"> event arguments </param>
        private void frmAppointment_Load(object sender, EventArgs e)
        {
            displayDays();
            loadBranches();
        }

        private void loadBranches()
        {
            List<Branch> branches = new Branch_Controller().getAll();
            cbBranch.DataSource = branches;
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
            cbBranch.SelectedValue = frmLogin.branch;
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            SaveAppointment();
        }

        private void SaveAppointment()
        {
            if (appointment.State == "Activo")
            {
                selectedButton.BackColor = Color.LightBlue;
                selectedButton.Text = appointment.client.ToString();
                // if appointment is not in the list, add it
                if (!appointments.Contains(appointment))
                {
                    appointments.Add(appointment);
                }
                cleanFields();
                return;
            }
            cleanFields();
            selectedButton.BackColor = Color.White;
            selectedButton.Text = "";
            appointments.Remove(appointment);
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
            appointments.Clear();


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

            TimeSpan currentTime = endHour;

            while (currentTime >= startHour)
            {
                TimeSpan appointmentTime = currentTime - TimeSpan.FromMinutes(appointmentDuration);

                if (appointmentTime < startHour)
                {
                    break;
                }

                DateTime appointmentDateTime = selectedDate.Add(appointmentTime);

                // create a panel to hold the appointment button and label
                Panel simpleAppointmentPanel = new Panel
                {
                    Size = new Size(Convert.ToInt32(pnlAppointments.Width * 0.7f), 50),
                    Dock = DockStyle.Top,
                    Padding = new Padding(0, 3, 0, 0),
                };

                // Create a label to show the time of the appointment
                Label appointmentLabel = new Label
                {
                    Text = appointmentDateTime.ToString("hh:mm tt"),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(Convert.ToInt32(pnlAppointments.Width * 0.3f), 50),
                    MaximumSize = new Size(Convert.ToInt32(pnlAppointments.Width * 0.3f), 50),
                    Padding = new Padding(5, 5, 5, 5),
                    Margin = new Padding(5),
                    BackColor = Color.LightGray,
                    Dock = DockStyle.Left,
                    Font = new Font("Segoe UI", 12)
                };

                // Create a button to assign the appointment
                Button appointmentButton = new Button
                {
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.White,
                    Tag = appointmentDateTime,
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

                currentTime -= TimeSpan.FromMinutes(appointmentDuration);
            }
            // Get the appointments of the selected day
            GetAppointments(selectedDate);
        }

        private void GetAppointments(DateTime selectedDate)
        {
            appointments = new Appointment_Controller().loadDayAppointments(selectedDate, branch.Id);
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
            appointment = new Appointment();

            //search in the list of appointments the selected appointment
            appointment = appointments.Find(a => a.AppointmentDate == (DateTime)selectedButton.Tag);
            DateTime appointmentDayTime = (DateTime)selectedButton.Tag;
            // check if the current time is greater than the appointment time

            DateTime actualDate = DateTime.Now;
            // set the same format to compare the dates
            actualDate = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, actualDate.Hour, actualDate.Minute, actualDate.Second);

            if (actualDate > appointmentDayTime && selectedButton.Text.Trim() == "")
            {
                MessageBox.Show("No se puede asignar una cita en un horario pasado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (appointment == null)
            {
                if( newAppointmentClient == null )
                {
                    MessageBox.Show("Debe seleccionar un cliente para asignar una cita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                appointment = new Appointment();
                appointment.AppointmentDate = appointmentDayTime;
                appointment.client = newAppointmentClient;
                appointment.Vehicle = clientVehicle;
                appointment.branch = scheduleBranch.Branch;
                appointment.State = "Activo";
            }
            frmInsertUpdate_Appointment frmAppointmentDetails = new frmInsertUpdate_Appointment(appointment);
            frmAppointmentDetails.DataChanged += ChildFormDataChangedHandler;
            frmAppointmentDetails.MdiParent = this.MdiParent;
            frmAppointmentDetails.Show();
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

            if (id.Length >= 3)
            {
                Client client = await new Clients_Controller().get(id);

                if (client != null)
                {
                    SelectClientAppointment(client);
                }
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();

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

        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Open the client form to search a client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            cleanFields();
            frmClients frmClients = new frmClients(this);
            frmClients.ClientSelected += HandleClientSelected;
            frmClients.MdiParent = this.MdiParent;
            frmClients.Show();
        }

        private void HandleVehicleSelected(Vehicle vehicle)
        {
            SelectVehicle(vehicle);
        }

        public void SelectVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                cbPLate.SelectedValue = vehicle.LicensePlate;
                clientVehicle = vehicle;
                newAppointmentClient = vehicle.Client;

                txtId.Text = newAppointmentClient.Id;
                txtName.Text = newAppointmentClient.FullName;
                txtModel.Text = vehicle.Model.ToString();
                load_Client_Vehicles();


                cbPLate.SelectedValue = vehicle.LicensePlate;
            }
        }

        private void btnSearchVehicle_Click(object sender, EventArgs e)
        {
            cleanFields();

            frmVehicles frmVehicles;
            if (newAppointmentClient == null)
                 frmVehicles = new frmVehicles(this, "");
            else
                 frmVehicles = new frmVehicles(this, newAppointmentClient.Id);
            
            frmVehicles.VehicleSelected += HandleVehicleSelected;
            frmVehicles.MdiParent = this.MdiParent;
            frmVehicles.Show();

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
                load_Client_Vehicles();
                if (clientVehicle!= null)
                {
                    cbPLate.SelectedValue = clientVehicle.LicensePlate;
                }
            }
        }

        private void cbPLate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPLate.SelectedItem != null)
            {
                clientVehicle = (Vehicle)cbPLate.SelectedItem;
                txtModel.Text = clientVehicle.Model.ToString();
            }

        }

        private void cbPLate_TextUpdate(object sender, EventArgs e)
        {
            if (cbPLate.Text.Length == 6 )
            {
                clientVehicle = new Vehicle_Controller().getVehicle(cbPLate.Text);
            }
            if (clientVehicle != null)
            {
                txtModel.Text = clientVehicle.Model.ToString();
                newAppointmentClient = clientVehicle.Client;
                txtId.Text = newAppointmentClient.Id;
                txtName.Text = newAppointmentClient.FullName;
                load_Client_Vehicles();
                cbPLate.SelectedValue = clientVehicle.LicensePlate;
            }

        }

        private void cbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBranch.SelectedItem != null)
            {
                branch = (Branch)cbBranch.SelectedItem;
                scheduleBranch = new Schedule_Controller().get(0, branch.Id);
                startHour = scheduleBranch.StartHour;
                endHour = scheduleBranch.EndHour;
                appointmentDuration = scheduleBranch.appointmentDuration;
                DisplayAppointments(day);
            }
            
        }


        private void load_Client_Vehicles()
        {
            List<Vehicle> vehicles = new Vehicle_Controller().getVehiclesByClient(newAppointmentClient.Id);
            if (vehicles.Count > 0)
            {
                cbPLate.DataSource = vehicles;
                cbPLate.DisplayMember = "LicensePlate";
                cbPLate.ValueMember = "LicensePlate";
                txtModel.Text = vehicles[0].Model.ToString();
            }
        }

        private void cleanFields()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtModel.Text = "";
            cbPLate.DataSource = null;
            cbPLate.Items.Clear();
            cbPLate.Text = "";
            clientVehicle = null;
            newAppointmentClient = null;
        }
    }
}
