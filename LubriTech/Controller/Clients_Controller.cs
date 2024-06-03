using LubriTech.Model.Client_Information;
using LubriTech.Model.Product_Information;
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

        public bool upsert(Client client)
        {
            return new Client_Model().UpSertClient(client);
        }

        public bool remove(String Id)
        {
            return new Client_Model().removeClient(Id);
        }

        public Client get(string Id)
        {
            return new Client_Model().getClient(Id);
        }

        public List<Vehicle> getVehicle(String Id) 
        {
            return new Client_Model().getVehicle(Id);

        }
    }
}
