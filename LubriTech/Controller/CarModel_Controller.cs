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
    public class CarModel_Controller
    {
        CarModel_Model carModelModel = new CarModel_Model();
        public List<CarModel> getAll()
        {
            return carModelModel.loadAllCarModels();
        }

        public List<CarModel> getModelsByMake(int makeId)
        {
            return carModelModel.loadModelsByMake(makeId);
        }

        public Boolean upsert(CarModel carModel)
        {
            return carModelModel.Upsert(carModel);
        }

        public CarModel getModel(int modelId)
        {
            return carModelModel.getModel(modelId);
        }

        public Make getMake(int makeId)
        {
            return carModelModel.getMake(makeId);
        }
    }
}
