using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controller class that manages business logic regarding work orders.
    /// It uses the class model <see cref="WorkOrder_Model"/> to obtain useful methods.
    /// </summary>
    public class Work_Order_Controller
    {
        /// <summary>
        /// Retrieves all work orders.
        /// </summary>
        /// <returns>A list of all the work orders.</returns>
        public List<WorkOrder> loadWorkOrders()
        {
            return new WorkOrder_Model().loadWorkOrders();
        }

        /// <summary>
        /// Retrieves all work orders related to an specific client.
        /// </summary>
        /// <param name="clientId">Client identification.</param>
        /// <returns>A list of all work orders related to the specified client.</returns>
        public List<WorkOrder> loadWorkOrdersFromClient(string clientId)
        {
            return new WorkOrder_Model().loadWorkOrdersFromClient(clientId);
        }

        public List<WorkOrderLine> loadWorkOrderLines(int? workOrderId, int clientPriceListId)
        {
            return new WorkOrderLine_Model().LoadWorkOrderLines(workOrderId, clientPriceListId);
        }

        /// <summary>
        /// Retrieves all the observations related to an specific work order.
        /// </summary>
        /// <param name="workOrderId">Work order identification.</param>
        /// <returns>A list of all observations related to the specified work order.</returns>
        public List<Observation> loadObservationsFromWorkOrder(int workOrderId)
        {
            return new Observation_Model().LoadObservations(workOrderId);
        }

        public bool upsertWorkOrderLine(WorkOrderLine workOrderLine)
        {
            return new WorkOrderLine_Model().UpsertWorkOrderLine(workOrderLine);
        }

        public WorkOrder LoadWorkOrder(int workOrderId)
        {
            return new WorkOrder_Model().loadWorkOrder(workOrderId);
        }

        public int UpsertWorkOrder(WorkOrder workOrder)
        {
            return new WorkOrder_Model().UpsertWorkOrder(workOrder);
        }

        public bool UpdateWorkOrder(WorkOrder workOrder)
        {
            return new WorkOrder_Model().updateWorkOrder(workOrder);
        }

        public bool WorkOrderLineExists(int workOrderId)
        {
            return new WorkOrderLine_Model().WorkOrderLineExists(workOrderId);
        }
    }
}
