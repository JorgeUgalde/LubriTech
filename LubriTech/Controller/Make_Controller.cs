using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class Make_Controller
    {
        public List<Make> getAll()
        {
         return new Make_Model().loadAllMakes();
        }

        public Make getMake(int id)
        {
            return new Make_Model().getMake(id);
        }

        public bool upsertMake(Make make)
        {
            return new Make_Model().Upsert(make);
        }
    }
}
