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
    public class Vehicle_Controller
    {
        Vehicle_Model vehicleModel = new Vehicle_Model();
        public List<Vehicle> getAll()
        {
            return vehicleModel.loadAllVehicles();
        }

        public Boolean upsert(Vehicle vehicle)
        {
            return vehicleModel.upsertVehicle(vehicle);
        }

        public Boolean delete(string licensePlate)
        {
            return vehicleModel.deleteVehicle(licensePlate);
        }

        public Client getClient(string clientId)
        {
            return vehicleModel.getClient(clientId);
        }
    }
}
