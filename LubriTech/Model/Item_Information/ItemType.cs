using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Item_Information
{
    public class ItemType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public ItemType(int id, string name, string state)
        {
            Id = id;
            Name = name;
            State = state;
        }

        public ItemType()
        {
        }
        public override string ToString()
        {
            return Name;
        }


    }
}
