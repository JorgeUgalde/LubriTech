using LubriTech.Model.Appointment_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class Appointment_Controller
    {
        public List<Appointment> loadDayAppointments(DateTime date)
        {
            return new Appointment_Model().loadDayAppointments(date);
        }
    }
}
