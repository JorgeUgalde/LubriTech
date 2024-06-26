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
    /// <summary>
    /// Controller class that manages business logic regarding clients. It uses the class model <see cref="Client_Model"/> to obtain useful methods.
    /// </summary>
    public class Clients_Controller
    {
        /// <summary>
        /// Retrieves all clients.
        /// </summary>
        /// <returns>List of clients.</returns>
        public List<Client> getAll()
        {
            return new Client_Model().loadAllClients();
        }

        /// <summary>
        /// Updates or inserts a client in the database.
        /// </summary>
        /// <param name="client">Client object</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public bool upsert(Client client)
        {
            return new Client_Model().UpSertClient(client);
        }

        /// <summary>
        /// Retrieves a client by his identification.
        /// </summary>
        /// <param name="Id">Client identification.</param>
        /// <returns>Client object, or null in case it failed.</returns>
        public async Task<Client> get(string Id)
        {
            await Task.Delay(100);
            return new Client_Model().getClient(Id);
        }

        /// <summary>
        /// Retrieves all vehicles belonging to a client.
        /// </summary>
        /// <param name="Id">Client identification</param>
        /// <returns>List of vehicles.</returns>
        public List<Vehicle> getVehicle(String Id) 
        {
            return new Client_Model().getVehicle(Id);

        }
    }
}
