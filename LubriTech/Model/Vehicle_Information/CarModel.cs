using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Vehicle_Information
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public Make Make { get; set; }


        public CarModel(string name, Make make, int id, string state)
        {
            this.Name = name;
            this.Make = make;
            this.Id = id;
            this.State = state;
        }

        public override string ToString()
        {
            return Id + "  " +  Name + "  " + State + "  " + Make.ToString();
        }
    }
}
