using LubriTech.Model;
using LubriTech.Model.Vehicle_Information;
using LubriTech.Model.Client_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controller class that manages business logic regarding transmission type of vehicles.
    /// It uses the class model <see cref="Transmission_Model"/> to obtain useful methods.
    /// </summary>
    public class Transmission_Controller
    {
        Transmission_Model transmissionModel = new Transmission_Model();

        /// <summary>
        /// Retrieves all transmission types.
        /// </summary>
        /// <returns>A list of all transmission types.</returns>
        public List<Transmission> getAll()
        {
            return transmissionModel.loadAllTransmissions();
        }

        /// <summary>
        /// Inserts or updates a transmission type.
        /// </summary>
        /// <param name="transmission">transmission object to upsert.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public Boolean upsert(Transmission transmission)
        {
            return transmissionModel.Upsert(transmission);
        }

        /// <summary>
        /// Retrieves a transmission type by its identification.
        /// </summary>
        /// <param name="transmissionId">Identification of the transmission type.</param>
        /// <returns>The transmission object.</returns>
        public Transmission getTransmission(int transmissionId)
        {
            return transmissionModel.getTransmission(transmissionId);
        }
    }
}
