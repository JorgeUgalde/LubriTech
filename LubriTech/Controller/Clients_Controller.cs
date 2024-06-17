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
    /// Controlador que maneja la lógica de negocio relacionada con los clientes. Utiliza el modelo <see cref="Client_Model"/> para obtener la información.
    /// </summary>
    public class Clients_Controller
    {
        /// <summary>
        /// Obtiene todos los clientes.
        /// </summary>
        /// <returns>Lista de todos los clientes.</returns>
        public List<Client> getAll()
        {
            return new Client_Model().loadAllClients();
        }

        /// <summary>
        /// Actualiza o inserta un cliente en la base de datos.
        /// </summary>
        /// <param name="client">Objeto Client que representa al cliente a actualizar o insertar.</param>
        /// <returns>true si la operación se realizó con éxito, false si falló.</returns>
        public bool upsert(Client client)
        {
            return new Client_Model().UpSertClient(client);
        }

        /// <summary>
        /// Elimina un cliente.
        /// </summary>
        /// <param name="Id">Identificación del cliente a eliminar.</param>
        /// <returns>true si la operación se realizó con éxito, false si falló.</returns>
        public bool remove(String Id)
        {
            return new Client_Model().removeClient(Id);
        }

        /// <summary>
        /// Obtiene un cliente por su identificación.
        /// </summary>
        /// <param name="Id">Identificación del cliente a obtener.</param>
        /// <returns>Cliente encontrado, o null si no se encuentra.</returns>
        public Client get(string Id)
        {
            return new Client_Model().getClient(Id);
        }

        /// <summary>
        /// Obtiene todos los vehículos asociados a un cliente por su identificación.
        /// </summary>
        /// <param name="Id">Identificación del cliente.</param>
        /// <returns>Lista de vehículos asociados al cliente.</returns>
        public List<Vehicle> getVehicle(String Id) 
        {
            return new Client_Model().getVehicle(Id);

        }
    }
}
