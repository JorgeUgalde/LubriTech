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
        public decimal factor { get; set; }
        public decimal price { get; set; }

        public Prices()
        {

        }

        public Prices(int id, int priceList, Item item, decimal factor, decimal price)
        {
            this.id = id;
            this.priceList = priceList;
            Item = item;
            this.factor = factor;
            this.price = price;
        }

        public Prices(int priceList, Item item, decimal factor, decimal price)
        {
            this.priceList = priceList;
            Item = item;
            this.factor = factor;
            this.price = price;
        }

        public override string ToString()
        {
            return Item.name;
        }
    }
}
