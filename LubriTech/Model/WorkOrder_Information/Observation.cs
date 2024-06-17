using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.WorkOrder_Information
{
    /// <summary>
    /// Representa una observación relacionada con una orden de trabajo.
    /// </summary>
    public class Observation
    {
        /// <summary>
        /// Identificador único de la observación.
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Identificador de la orden de trabajo asociada con la observación.
        /// </summary>
        public int WorkOrderId { get; set; }

        /// <summary>
        /// Descripción de la observación.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Fotos asociada con la observación.
        /// </summary>
        public string Photos { get; set; }

        /// <summary>
        /// Constructor por defecto de la clase Observation.
        /// </summary>
        public Observation() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Observation con parámetros especificados.
        /// </summary>
        /// <param name="codigo">El identificador de la observación.</param>
        /// <param name="workOrderId">El identificador de la orden de trabajo asociada con la observación.</param>
        /// <param name="description">La descripción de la observación.</param>
        /// <param name="photos">Las fotos asociadas con la observación.</param>
        public Observation(int codigo, int workOrderId, string description, string photos)
        {
            this.Codigo = codigo;
            this.WorkOrderId = workOrderId;
            this.Description = description;
            this.Photos = photos;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Observation con parámetros especificados.
        /// </summary>
        /// <param name="codigo">El identificador único de la observación.</param>
        /// <param name="description">La descripción de la observación.</param>
        /// <param name="photos">Las fotos asociadas con la observación.</param>
        public Observation(int codigo, string description, string photos)
        {
            this.Codigo = codigo;
            this.Description = description;
            this.Photos = photos;
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa el objeto actual.</returns>
        public override string ToString()
        {
        return "Código: " + Codigo + "\nId de la orden de trabajo: " + WorkOrderId + "\nDescripción: " + Description + "\nFotos: " + Photos;
        }
    }
}
