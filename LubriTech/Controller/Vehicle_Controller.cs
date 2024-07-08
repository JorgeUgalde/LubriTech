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
        /// Search a vehicle by the identification.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Return a vehicle if exist, if not, return null</returns>
        public Vehicle getVehicle(string Id)
        {
            return vehicleModel.getVehicle(Id);
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

        public List<Vehicle> getVehiclesByClient(string clientId)
        {
            return vehicleModel.getVehiclesByClient(clientId);
        }

        public Vehicle getVehicleByClientId(string plate, string clientId)
        {
            return vehicleModel.getVehicleByClientId(plate, clientId);
        }
    }
}
