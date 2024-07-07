using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    internal class Observation_Controller
    {
        public List<Observation> GetObservation(int workOrderId)
        {
            return new Observation_Model().LoadObservations(workOrderId);
        }

        public Observation Upsert(Observation observation)
        {
            return new Observation_Model().upsertObservation(observation);
        }

        public bool Delete(int observationId) 
        { 
            return new Observation_Model().deleteObservation(observationId);
        
        }
    }
}
