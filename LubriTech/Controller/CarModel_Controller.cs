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
    /// Controller class that manages business logic regarding models of vehicles.
    /// It uses the class model <see cref="CarModel_Model"/> to obtain useful methods.
    /// </summary>
    public class CarModel_Controller
    {
        CarModel_Model carModelModel = new CarModel_Model();

        /// <summary>
        /// Retrieves all car models.
        /// </summary>
        /// <returns>A list of all car models.</returns>
        public List<CarModel> getAll()
        {
            return carModelModel.loadAllCarModels();
        }

        /// <summary>
        /// Retrieves car models related to a car make.
        /// </summary>
        /// <param name="makeId">Identification of the car make</param>
        /// <returns>A list of car models belonging to the specified make.</returns>
        public List<CarModel> getModelsByMake(int makeId)
        {
            return carModelModel.loadModelsByMake(makeId);
        }

        /// <summary>
        /// Inserts or updates a car model.
        /// </summary>
        /// <param name="carModel">Car model object to upsert.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public Boolean upsert(CarModel carModel)
        {
            return carModelModel.Upsert(carModel);
        }

        /// <summary>
        /// Retrieves a car model by its identification.
        /// </summary>
        /// <param name="modelId">Identification of the car model.</param>
        /// <returns>The car model object.</returns>
        public CarModel getModel(int modelId)
        {
            return carModelModel.getModel(modelId);
        }

        /// <summary>
        /// Retrieves the make information by its ID.
        /// </summary>
        /// <param name="makeId">The ID of the make.</param>
        /// <returns>The make object.</returns>
        public Make getMake(int makeId)
        {
            return carModelModel.getMake(makeId);
        }
    }
}
