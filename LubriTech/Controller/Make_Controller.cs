using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controlador que maneja la lógica de negocio relacionada con las marcas de vehículos. Utiliza el modelo <see cref="Make_Model"/> para obtener la información
    /// </summary>
    public class Make_Controller
    {
        /// <summary>
        /// Obtiene todas las marcas de vehículos.
        /// </summary>
        /// <returns>Lista de todas las marcas de vehículos.</returns>
        public List<Make> getAll()
        {
         return new Make_Model().loadAllMakes();
        }

        /// <summary>
        /// Obtiene una marca de vehículo por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la marca de vehículo a obtener.</param>
        /// <returns>Marca de vehículo encontrada, o null si no se encuentra.</returns>
        public Make getMake(int id)
        {
            return new Make_Model().getMake(id);
        }

        /// <summary>
        /// Actualiza o inserta una marca de vehículo.
        /// </summary>
        /// <param name="make">Objeto Make que representa la marca de vehículo a actualizar o insertar.</param>
        /// <returns>true si la operación se realizó con éxito, false si falló.</returns>
        public bool upsertMake(Make make)
        {
            return new Make_Model().Upsert(make);
        }
    }
}
