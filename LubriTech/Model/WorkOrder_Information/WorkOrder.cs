using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.WorkOrder_Information
{
    /// <summary>
    /// Representa una orden de trabajo en el sistema.
    /// </summary>
    public class WorkOrder
    {
        /// <summary>
        /// Identificador único de la orden de trabajo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha en que se creó la orden de trabajo.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Sucursal asociada a la orden de trabajo.
        /// </summary>
        public Branch Branch { get; set; }

        /// <summary>
        /// Cliente para quien se realiza la orden de trabajo.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Vehículo asociado a la orden de trabajo.
        /// </summary>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Kilometraje actual del vehículo al momento de la orden de trabajo.
        /// </summary>
        public int CurrentMileage { get; set; }


        /// <summary>
        /// Lista de observaciones realizadas durante la orden de trabajo.
        /// </summary>
        public List<Observation> Observations { get; set; }

        /// <summary>
        /// Monto total a pagar por la orden de trabajo.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Estado actual de la orden de trabajo (En progreso, Completada, Cancelada).
        /// </summary>
        public short State { get; set; }

        public List<WorkOrderLine> workOrderLines { get; set; }

        /// <summary>
        /// Constructor de la clase WorkOrder.
        /// </summary>
        /// <param name="id">Identificador de la orden de trabajo.</param>
        /// <param name="date">Fecha en que se creó la orden de trabajo.</param>
        /// <param name="branch">Sucursal asociada a la orden de trabajo.</param>
        /// <param name="client">Cliente para quien se realiza la orden de trabajo.</param>
        /// <param name="vehicle">Vehículo asociado a la orden de trabajo.</param>
        /// <param name="currentMileage">Kilometraje actual del vehículo al momento de la orden de trabajo.</param>
        /// <param name="observation">Lista de observaciones realizadas durante la orden de trabajo.</param>
        /// <param name="amount">Monto total a pagar por la orden de trabajo.</param>
        /// <param name="state">Estado actual de la orden de trabajo.</param>
        public WorkOrder(int id, DateTime date, Branch branch, Client client, Vehicle vehicle, int currentMileage, List<Observation> observation, decimal amount, short state, List<WorkOrderLine> workOrderLines)
        {
            Id = id;
            Date = date;
            Branch = branch;
            Client = client;
            Vehicle = vehicle;
            CurrentMileage = currentMileage;
            Observations = observation;
            Amount = amount;
            State = state;
            this.workOrderLines = workOrderLines;
        }

        public WorkOrder()
        {
        }

        /// <summary>
        /// Sobrescritura del método ToString para representar la información de la orden de trabajo.
        /// </summary>
        /// <returns>Representación en cadena de la orden de trabajo.</returns>
        public override string ToString()
        {
            return Id + " " + Date + " " + Branch.Name + " " + Client.FullName + " " + Vehicle.Model + " " + CurrentMileage + " " + Observations + " " + Amount + " " + State + " " + workOrderLines;
        }
    }
}
