using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    internal class ObservationPhotos_Controller
    {
        public void Upsert(int observationId, byte[] imagePath)
        {
            new ObservationPhotos_Model().UpsertObservationPhoto(observationId,imagePath);
        }

        public List<ObservationPhotos> GetAll(int observationId)
        {
            return new ObservationPhotos_Model().LoadObservationPhotos(observationId);
        }

        public void Delete(int Id)
        {
            new ObservationPhotos_Model().DeleteObservationPhoto(Id);
        }
    }
}
