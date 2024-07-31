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

        public int upsertPriceList(PriceList priceList)
        {
            return new PriceList_Model().upsertPriceList(priceList);
        }

        public DataTable getPricesByPriceListDT(int id)
        {
            return new Prices_Model().getPricesByPriceListDT(id);
        }

        public bool upsertPrice(DataRow row)
        {
            return new Prices_Model().upsertPrice(row);
        }



        public double getPriceByItem(string itemCode, int priceListId)
        {
            return new Prices_Model().getPriceByItem(itemCode, priceListId);
        }

        public double ItemAverageCost(string itemCode)
        {
            return new PriceList_Model().ItemAverageCost(itemCode);
        }

        public bool updateSellPrice(string itemCode)
        {
            return new Prices_Model().updateSellPrice(itemCode);
        }
    }
}
