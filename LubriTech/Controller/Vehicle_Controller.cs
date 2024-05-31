using LubriTech.Model;
using LubriTech.Model.Vehicle_Information;
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

        public Boolean addVehicle(string LicensePlate, string Engine, double Mileage, string Brand, string Model, int Year, string Transmission, string ClientId)
        {
            return vehicleModel.addVehicle(LicensePlate, Engine, Mileage, Brand, Model, Year, Transmission, ClientId);
        }
    }
}
