using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Vehicle_Information
{
    /// <summary>
    /// Representa una marca de vehículo.
    /// </summary>
    public class Make
    {
        /// <summary>
        /// Identificador único de la marca.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la marca.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Estado de la marca (activo o inactivo).
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Make"/> con los valores especificados.
        /// </summary>
        /// <param name="Id">El Identificador de la marca.</param>
        /// <param name="name">El nombre de la marca.</param>
        /// <param name="state">El estado de la marca.</param>
        public Make(int Id, string name, string state)
        {
            this.Id = Id;
            this.Name = name;
            this.State = state;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Make"/>.
        /// </summary>
        public Make()
        {
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa el nombre de la marca.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
