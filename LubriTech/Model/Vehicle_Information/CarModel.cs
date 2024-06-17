using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Vehicle_Information
{
    /// <summary>
    /// Representa un modelo de carro.
    /// </summary>
    public class CarModel
    {
        /// <summary>
        /// Identificador único del modelo de coche.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del modelo de carro.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Estado del modelo de carro (activo o inactivo).
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Marca del modelo de carro.
        /// </summary>
        public Make Make { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CarModel"/> con los valores especificados.
        /// </summary>
        /// <param name="id">El Identificador del modelo de carro.</param>
        /// <param name="name">El nombre del modelo de carro.</param>
        /// <param name="make">La marca del modelo de carro.</param>
        /// <param name="state">El estado del modelo de carro.</param>
        public CarModel(int id, string name, Make make, string state)
        {
            this.Name = name;
            this.Make = make;
            this.Id = id;
            this.State = state;
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa el modelo de coche.</returns>
        public override string ToString()
        {
            return Make.Name + " " +Name;
        }
    }
}
