using LubriTech.Model.PricesList_Information;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class PriceList_Controller
    {

        public List<PriceList> getPriceLists()
        {
            return new PriceList_Model().getPriceLists();
        }

        public PriceList getPriceList(int id)
        {
            return new PriceList_Model().getPriceList(id);
        }

        public bool upsertPriceList(PriceList priceList)
        {
            return new PriceList_Model().upsertPriceList(priceList);
        }

        public bool deletePriceList(int id)
        {
            return new PriceList_Model().deletePriceList(id);
        }

        public DataTable getPricesByPriceListDT(int id)
        {
            return new Prices_Model().getPricesByPriceListDT(id);
        }

        public bool upsertPrice(DataRow row)
        {
            return new Prices_Model().upsertPrice(row);
        }

        public bool deletePrice(int id)
        {
            return new Prices_Model().deletePrice(id);
        }
    }
}
