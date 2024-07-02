using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.PricesList_Information
{
    public class PriceList
    {
        public int id { get; set; }
        public string description { get; set; }
        public int state { get; set; }
        public List<Prices> prices { get; set; }

        public PriceList()
        {

        }

        public PriceList(int id, string description, int state, List<Prices> prices)
        {
            this.id = id;
            this.description = description;
            this.state = state;
            this.prices = prices;
        }

        public PriceList(string description, int state, List<Prices> prices)
        {
            this.description = description;
            this.state = state;
            this.prices = prices;
        }

        public override string ToString()
        {
            return description;
        }
    }
}
