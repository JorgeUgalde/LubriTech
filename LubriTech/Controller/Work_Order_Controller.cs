using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<WorkOrderLine> loadWorkOrderLines(int? workOrderId)
        {
            return new WorkOrderLine_Model().LoadWorkOrderLines(workOrderId);
        }

        public List<Observation> loadObservationsFromWorkOrder(int workOrderId)
        {
            return new Observation_Model().LoadObservations(workOrderId);
        }

        public bool upsertWorkOrderLine(DataRow row)
        {
            return new WorkOrderLine_Model().UpsertWorkOrderLine(row);
        }

        public WorkOrder LoadWorkOrder(int workOrderId)
        {
            return new WorkOrder_Model().loadWorkOrder(workOrderId);
        }
    }
}
