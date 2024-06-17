using LubriTech.Model;
using LubriTech.Model.Vehicle_Information;
using LubriTech.Model.Client_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controlador que maneja la lógica de negocio relacionada con los vehículos. Utiliza el modelo <see cref="Vehicle_Model"/> para obtener la información
    /// </summary>
    public class Vehicle_Controller
    {

        Vehicle_Model vehicleModel = new Vehicle_Model();

        /// <summary>
        /// Obtiene todos los vehículos almacenados.
        /// </summary>
        /// <returns>Lista de todos los vehículos.</returns>
        public List<Vehicle> getAll()
        {
            return vehicleModel.loadAllVehicles();
        }

        /// <summary>
        /// Inserta o actualiza un vehículo.
        /// </summary>
        /// <param name="vehicle">El vehículo a insertar o actualizar.</param>
        /// <returns>True si la operación fue exitosa, False si falló.</returns>
        public Boolean upsert(Vehicle vehicle)
        {
            return vehicleModel.upsertVehicle(vehicle);
        }

        /// <summary>
        /// Obtiene un cliente basado en su identificación.
        /// </summary>
        /// <param name="clientId">Identificación del cliente.</param>
        /// <returns>Cliente encontrado, o null si no se encuentra.</returns>
        public Client getClient(string clientId)
        {
            return vehicleModel.getClient(clientId);
        }

        /// <summary>
        /// Obtiene un modelo de vehículo basado en su identificación.
        /// </summary>
        /// <param name="modelId">Identificación del modelo de vehículo.</param>
        /// <returns>Modelo de vehículo encontrado, o null si no se encuentra.</returns>
        public CarModel getModel(int modelId)
        {
            return vehicleModel.getModel(modelId);
        }

        /// <summary>
        /// Obtiene una marca de vehículo basada en su identificación.
        /// </summary>
        /// <param name="makeId">Identificación de la marca de vehículo.</param>
        /// <returns>Marca de vehículo encontrada, o null si no se encuentra.</returns>
        public Make getMake(int makeId)
        {
            return vehicleModel.getMake(makeId);
        }
    }
}
