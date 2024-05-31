using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Product_Information
{
    public class Product
    {
        public string code { set; get; }
        public string name { set; get; }
        public double price { set; get; }
        public string measureUnit { set; get; }
        public string state { set; get; }
        public List<Supplier> suppliers { set; get; }

        public Product()
        {
        }

        public Product(string code, string name, double price, string measureUnit, string state, List<Supplier> suppliers)
        {
            this.code = code;
            this.name = name;
            this.price = price;
            this.measureUnit = measureUnit;
            this.state = state;
            this.suppliers = suppliers;
        }


        override
        public string ToString()
        {
            return "Code: " + code + "\nName: " + name + "\nPrice: " + price + "\nMeasure unit: " + measureUnit + "\nState: " + state;
        }
    }
}
