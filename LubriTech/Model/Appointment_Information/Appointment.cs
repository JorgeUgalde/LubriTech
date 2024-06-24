using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Appointment_Information
{

    /// <summary>
    /// Clase que representa las citas del sistema
    /// </summary>
    public  class Appointment
    {
        /// <summary>
        /// Identificador único de la cita.
        /// </summary>
        public int AppointmentID { get; set; }

        /// <summary>
        ///  Objeto cliente al que pertenece la cita.
        /// </summary>
        public Client client { get; set; }

        /// <summary>
        /// Fecha y hora de la cita
        /// </summary>
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// Estado de la cita
        /// </summary>
        public short State { get; set; }

        /// <summary>
        /// Sucursal de la cita
        /// </summary>
        public Branch branch { get; set; }

        /// <summary>
        /// Constructor completo de la clase Appointment.
        /// <summary>
        /// <param name="appointmentDate"/>Fecha de la cita.</param>
        /// <param name="appointmentID">Identificador único de la cita.</param>
        /// <param name="client"/>   Cliente de la cita.</param>
        /// <param name="state">Estado de la cita.</param>
        /// <param name="branch">Sucursal de la cita.</param>


        public Appointment (int appointmentID, Client client, DateTime appointmentDate, short state, Branch branch)
        {
           this.AppointmentID = appointmentID;
            this.client = client;
            this.AppointmentDate = appointmentDate;
            this.State = state;
            this.branch = branch;
        }


        /// <summary>
        /// Constructor vacio de la clase Appointment.
        /// </summary>
        public Appointment()
        {
        }


        /// <summary>
        /// Sobrescribe el método ToString para mostrar al cliente de la cita.
        /// </summary>
        /// <returns>Nombre completo del cliente.</returns>
        public override string ToString()
        {
            return client.ToString();
        }
    }
}
