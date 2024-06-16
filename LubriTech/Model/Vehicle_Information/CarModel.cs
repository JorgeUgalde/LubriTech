using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Vehicle_Information
{
    public class CarModel
    {
        public string Name { get; set; }
        public Make make { get; set; }


        public CarModel(string name, Make make)
        {
            this.Name = name;
            this.make = make;
        }

        public override string ToString()
        {
            return Name + "  " +  make;
        }
    }
}
