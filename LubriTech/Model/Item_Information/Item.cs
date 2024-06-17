using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Item_Information
{
    public class Item
    {
        public string code { set; get; }
        public string name { set; get; }
        public double sellPrice { set; get; }
        public string measureUnit { set; get; }
        public string state { set; get; }
        public double stock { set; get; }
        public double purchasePrice { set; get; }
        public string type { set; get; }

        public Item()
        {
        }

       public Item(string code, string name, double sellPrice, string measureUnit, string state, double stock, double purchasePrice, string type)
        {
            this.code = code;
            this.name = name;
            this.sellPrice = sellPrice;
            this.measureUnit = measureUnit;
            this.state = state;
            this.stock = stock;
            this.purchasePrice = purchasePrice;
            this.type = type;
        }


        override
        public string ToString()
        {
            return name;
        }
    }
}
