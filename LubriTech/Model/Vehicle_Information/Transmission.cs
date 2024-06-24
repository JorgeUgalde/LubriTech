using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Vehicle_Information
{
    /// <summary>
    /// Representa el tipo de transmisión del carro.
    /// </summary>
    public class Transmission
    {
        /// <summary>
        /// Identificador único del tipo de transmisión.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del tipo de transmisión.
        /// </summary>
        public string TransmissionType { get; set; }

        /// <summary>
        /// Estado del tipo de transmisión (activo o inactivo).
        /// </summary>
        public string State { get; set; }

        public Transmission() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Transmission"/> con los valores especificados.
        /// </summary>
        /// <param name="id">El Identificador del tipo de transmisión.</param>
        /// <param name="name">El nombre del tipo de transmisión.</param>
        /// <param name="state">El estado del tipo de transmisión.</param>
        public Transmission(int id, string transmissionType, string state)
        {
            this.TransmissionType = transmissionType;
            this.Id = id;
            this.State = state;
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa el tipo de transmisión.</returns>
        public override string ToString()
        {
            return TransmissionType;
        }
    }
}
