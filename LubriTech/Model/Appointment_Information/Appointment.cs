using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Appointment_Information
{

    /// <summary>
    /// Class that represents an appointment in the system.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Identifies the appointment.
        /// </summary>
        public int AppointmentID { get; set; }

        /// <summary>
        ///  Client of the appointment.
        /// </summary>
        public Client client { get; set; }

        /// <summary>
        /// Date and time of the appointment.
        /// </summary>
        /// 
        public Vehicle Vehicle { get; set; }
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// Appointment state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Branch of the appointment.
        /// </summary>
        public Branch branch { get; set; }

        /// <summary>
        /// Description of the appointment.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Constructor of the class Appointment
        /// <summary>
        /// <param name="appointmentDate"/>Date and time of the appointment.</param>
        /// <param name="appointmentID">Identifier.</param>
        /// <param name="Vehicle">Vehicle of the Appointment.</param>
        /// <param name="client"/>   Client .</param>
        /// <param name="state">State.</param>
        /// <param name="branch">Branch of the appointment.</param>
        /// <param name="Description">Description of the appointment</param>
        public Appointment (int appointmentID, Client client, Vehicle vehicle, DateTime appointmentDate, string state, Branch branch, string Description)
        {
           this.AppointmentID = appointmentID;
            this.client = client;
            this.Vehicle = vehicle;
            this.AppointmentDate = appointmentDate;
            this.State = state;
            this.branch = branch;
            this.Description = Description;
        }


        /// <summary>
        /// Empty constructor of the class Appointment
        /// </summary>
        public Appointment()
        {
        }


        /// <summary>
        /// ToString method of the class Appointment
        /// </summary>
        /// <returns>Full client name.</returns>
        public override string ToString()
        {
            return client.ToString();
        }
    }
}
