using LubriTech.Model.Service_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class Service_Controller
    {
        public List<Service> loadAllServices()
        {
            return new Service_Model().loadAllServices();
        }

        public Boolean Upsert(Service service)
        {
            return new Service_Model().Upsert(service);
        }
        public bool Delete(int id)
        {
            return new Service_Model().Delete(id);
        }
    }
}
