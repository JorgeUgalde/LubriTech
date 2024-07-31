using LubriTech.Model.Item_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.PricesList_Information
{
    public class Prices
    {
        public int id { get; set; }
        public int priceList { get; set; }
        public Item Item { get; set; }
        public double factor { get; set; }
        public double price { get; set; }

        public double IVA { get; set; }

        public Prices()
        {

        }

        public Prices(int id, int priceList, Item item, double factor, double price, double IVA)
        {
            this.id = id;
            this.priceList = priceList;
            Item = item;
            this.factor = factor;
            this.price = price;
            this.IVA = IVA;
        }

        public Prices(int priceList, Item item, double factor, double price, double IVA)
        {
            this.priceList = priceList;
            this.Item = item;
            this.factor = factor;
            this.price = price;
            this.IVA = IVA;
        }

        public override string ToString()
        {
            return Item.name;
        }
    }
}
