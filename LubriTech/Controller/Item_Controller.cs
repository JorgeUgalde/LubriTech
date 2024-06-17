using LubriTech.Model.Item_Information;
using LubriTech.Model.items_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class Item_Controller
    {
        public List<Item> getAll()
        {
            return new Item_Model().loadAllitems();
        }

        public Item get(string code)
        {
            return new Item_Model().getItem(code);
        }

        public bool UpSert(Item item)
        {
            return new Item_Model().UpSertItem(item);
        }
    
    }
}
