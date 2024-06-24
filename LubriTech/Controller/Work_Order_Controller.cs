using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class Work_Order_Controller
    {
        public List<WorkOrder> loadWorkOrders()
        {
            return new WorkOrder_Model().loadWorkOrders();
        }

        public List<WorkOrder> loadWorkOrdersFromClient(string clientId)
        {
            return new WorkOrder_Model().loadWorkOrdersFromClient(clientId);
        }

        public List<WorkOrderLine> loadWorkOrderLines(int workOrderId)
        {
            return new WorkOrderLine_Model().loadWorkOrderLines(workOrderId);
        }

        public List<Observation> loadObservationsFromWorkOrder(int workOrderId)
        {
            return new Observation_Model().loadObservations(workOrderId);
        }

        public bool upsertWorkOrderLine(WorkOrderLine workOrderLine)
        {
            return new WorkOrderLine_Model().upsertWorkOrderLine(workOrderLine);
        }
    }
}
