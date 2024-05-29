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
        public List<Vehicle> getAll()
        {
            return new Vehicle_Model().loadAllVehicles();
        }
    }
}
