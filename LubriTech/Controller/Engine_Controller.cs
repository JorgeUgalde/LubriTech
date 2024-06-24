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
    /// Controller class that manages business logic regarding engine type of vehicles.
    /// It uses the class model <see cref="Engine_Model"/> to obtain useful methods.
    /// </summary>
    public class Engine_Controller
    {
        Engine_Model engineModel = new Engine_Model();

        /// <summary>
        /// Retrieves all engine types.
        /// </summary>
        /// <returns>A list of all engine types.</returns>
        public List<Engine> getAll()
        {
            return engineModel.loadAllEngines();
        }

        /// <summary>
        /// Inserts or updates a engine type.
        /// </summary>
        /// <param name="engine">engine object to upsert.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public Boolean upsert(Engine engine)
        {
            return engineModel.Upsert(engine);
        }

        /// <summary>
        /// Retrieves a engine type by its identification.
        /// </summary>
        /// <param name="engineId">Identification of the engine type.</param>
        /// <returns>The engine object.</returns>
        public Engine getEngine(int engineId)
        {
            return engineModel.getEngine(engineId);
        }
    }
}
