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
    /// Controller class that manages business logic regarding vehicles.
    /// It uses the class model <see cref="Vehicle_Model"/> to obtain useful methods.
    /// </summary>
    public class Vehicle_Controller
    {

        Vehicle_Model vehicleModel = new Vehicle_Model();

        /// <summary>
        /// Retrieves all vehicles.
        /// </summary>
        /// <returns>A list of all the vehicles.</returns>
        public List<Vehicle> getAll()
        {
            return vehicleModel.loadAllVehicles();
        }

        /// <summary>
        /// Inserts or updates a vehicle in the database.
        /// </summary>
        /// <param name="vehicle">Vehicle object to insert or update.</param>
        /// <returns>True if the operation was succesful, otherwise, false.</returns>
        public Boolean upsert(Vehicle vehicle)
        {
            return vehicleModel.upsertVehicle(vehicle);
        }

        /// <summary>
        /// Retrieves a client by its identification.
        /// </summary>
        /// <param name="clientId">Client identification.</param>
        /// <returns>Client object, or null if the client was not found.</returns>
        public Client getClient(string clientId)
        {
            return vehicleModel.getClient(clientId);
        }

        /// <summary>
        /// Retrieves a car model by its identification.
        /// </summary>
        /// <param name="modelId">Car model identification.</param>
        /// <returns>CarModel object, or null if the car model was not found.</returns>
        public CarModel getModel(int modelId)
        {
            return vehicleModel.getModel(modelId);
        }

        /// <summary>
        /// Retrieves a make by its identification.
        /// </summary>
        /// <param name="makeId">Make identification.</param>
        /// <returns>Make object, or null if the make was not found.</returns>
        public Make getMake(int makeId)
        {
            return vehicleModel.getMake(makeId);
        }

        /// <summary>
        /// Retrieves a engine type by its identification.
        /// </summary>
        /// <param name="engineId">Engine type identification.</param>
        /// <returns>Engine object, or null if the engine type was not found.</returns>
        public Engine getEngine(int engineId)
        {
            return vehicleModel.getEngine(engineId);
        }

        /// <summary>
        /// Retrieves a transmission type by its identification.
        /// </summary>
        /// <param name="transmissionId">Transmission type identification.</param>
        /// <returns>Transmission object, or null if the transmission type was not found.</returns>
        public Transmission getTransmission(int transmissionId)
        {
            return vehicleModel.getTransmission(transmissionId);
        }
    }
}
