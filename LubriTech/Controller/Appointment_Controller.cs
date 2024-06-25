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
        public List<Appointment> loadDayAppointments(DateTime date)
        {
            return new Appointment_Model().loadDayAppointments(date);
        }
    }
}
