using LubriTech.Model.Client_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class Clients_Controller
    {
        public List<Client> getAll()
        {
            return new Client_Model().loadAllClients();
        }
    }
}
