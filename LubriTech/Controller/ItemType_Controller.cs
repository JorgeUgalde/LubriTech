using LubriTech.Model.Item_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class ItemType_Controller
    {

        public List<ItemType> loadAllItemTypes()
        {
            return new ItemType_Model().loadAllItemTypes();
        }

        public ItemType getItemType(int id)
        {
            return new ItemType_Model().getItemType(id);
        }

        public bool UpsertItemType(ItemType itemType)
        {
            return new ItemType_Model().UpSert(itemType);
        }
    }
}
