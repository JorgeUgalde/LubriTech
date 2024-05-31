using LubriTech.Model.Client_Information;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        public Boolean saveClient(Client client)
        {
            return new Client_Model().SaveClient(client);
        }
    }
}
