using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Retrieves all the lines related to an specific work order.
        /// </summary>
        /// <param name="workOrderId">Work order identification.</param>
        /// <returns>A list of all lines related to the specified work order.</returns>
        public List<WorkOrderLine> loadWorkOrderLines(int workOrderId)
        {
            return new WorkOrderLine_Model().loadWorkOrderLines(workOrderId);
        }

        /// <summary>
        /// Retrieves all the observations related to an specific work order.
        /// </summary>
        /// <param name="workOrderId">Work order identification.</param>
        /// <returns>A list of all observations related to the specified work order.</returns>
        public List<Observation> loadObservationsFromWorkOrder(int workOrderId)
        {
            return new Observation_Model().loadObservations(workOrderId);
        }

        /// <summary>
        /// Inserts or updates a work order line in the database.
        /// </summary>
        /// <param name="workOrderLine">Work order line identification.</param>
        /// <returns>True if the operation was succesful, otherwise, false.</returns>
        public bool upsertWorkOrderLine(WorkOrderLine workOrderLine)
        {
            return new WorkOrderLine_Model().upsertWorkOrderLine(workOrderLine);
        }
    }
}
