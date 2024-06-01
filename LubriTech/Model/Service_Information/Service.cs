using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Service_Information
{
    public class Service
    {
        public int ID { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public Service(int ID, string name, double price)
        {
            this.ID = ID;
            this.name = name;
            this.price = price;
        }

        public Service() {}

        public override string ToString()
        {
            return name;
        }
    }
}
