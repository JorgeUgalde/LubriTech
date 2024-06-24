using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Vehicle_Information
{
    /// <summary>
    /// Representa el tipo de motor del carro.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Identificador único del tipo de motor.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del tipo de motor.
        /// </summary>
        public string EngineType { get; set; }

        /// <summary>
        /// Estado del tipo de motor (activo o inactivo).
        /// </summary>
        public string State { get; set; }

        public Engine() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Engine"/> con los valores especificados.
        /// </summary>
        /// <param name="id">El Identificador del tipo de motor.</param>
        /// <param name="name">El nombre del tipo de motor.</param>
        /// <param name="state">El estado del tipo de motor.</param>
        public Engine(int id, string engineType, string state)
        {
            this.EngineType = engineType;
            this.Id = id;
            this.State = state;
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa el tipo de motor.</returns>
        public override string ToString()
        {
            return EngineType;
        }
    }
}
