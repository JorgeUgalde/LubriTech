using LubriTech.Model.Appointment_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controller class that manages business logic regarding appointments. It uses the class model <see cref="Appointment_Model"/> to obtain useful methods.
    /// </summary>
    public class Appointment_Controller
    {
        /// <summary>
        /// Gets all the appointments for an specific day in a List object.
        /// </summary>
        /// /// <param name="date">DateTime object, the day.</param>
        /// <returns>List of the appointmens belonging to the specified day.</returns>
        public List<Appointment> loadDayAppointments(DateTime date, int branchID)
        {
            return new Appointment_Model().loadDayAppointments(date, branchID);
        }

        public bool CancelAppointment(int appointmentID)
        {
            return new Appointment_Model().CancelAppointment(appointmentID);
        }

        public bool UpsertAppointment(Appointment appointment)
        {
            return new Appointment_Model().UpSertAppointment(appointment);
        }
    }
}
