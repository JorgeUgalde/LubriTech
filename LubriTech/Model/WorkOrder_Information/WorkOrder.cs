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
        /// Kilometraje recomendado para el próximo cambio de aceite.
        /// </summary>
        public int RecommendedMileage { get; set; }

        /// <summary>
        /// Kilometraje estimado para el próximo cambio.
        /// </summary>
        public int NextChange { get; set; }

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
        public string State { get; set; }

        /// <summary>
        /// Constructor de la clase WorkOrder.
        /// </summary>
        /// <param name="id">Identificador de la orden de trabajo.</param>
        /// <param name="date">Fecha en que se creó la orden de trabajo.</param>
        /// <param name="branch">Sucursal asociada a la orden de trabajo.</param>
        /// <param name="client">Cliente para quien se realiza la orden de trabajo.</param>
        /// <param name="vehicle">Vehículo asociado a la orden de trabajo.</param>
        /// <param name="currentMileage">Kilometraje actual del vehículo al momento de la orden de trabajo.</param>
        /// <param name="recommendedMileage">Kilometraje recomendado para el próximo cambio de aceite.</param>
        /// <param name="nextChange">Kilometraje estimado para el próximo cambio.</param>
        /// <param name="observation">Lista de observaciones realizadas durante la orden de trabajo.</param>
        /// <param name="amount">Monto total a pagar por la orden de trabajo.</param>
        /// <param name="state">Estado actual de la orden de trabajo.</param>
        public WorkOrder(int id, DateTime date, Branch branch, Client client, Vehicle vehicle, int currentMileage, int recommendedMileage, int nextChange, List<Observation> observation, decimal amount, string state)
        {
            Id = id;
            Date = date;
            Branch = branch;
            Client = client;
            Vehicle = vehicle;
            CurrentMileage = currentMileage;
            RecommendedMileage = recommendedMileage;
            NextChange = nextChange;
            Observations = observation;
            Amount = amount;
            State = state;
        }


        /// <summary>
        /// Constructor alternativo para el caso donde solo se pasa una observación (observación singular).
        /// </summary>
        /// <param name="date">Fecha en que se creó la orden de trabajo.</param>
        /// <param name="branch">Sucursal asociada a la orden de trabajo.</param>
        /// <param name="client">Cliente para quien se realiza la orden de trabajo.</param>
        /// <param name="vehicle">Vehículo asociado a la orden de trabajo.</param>
        /// <param name="currentMileage">Kilometraje actual del vehículo al momento de la orden de trabajo.</param>
        /// <param name="recommendedMileage">Kilometraje recomendado para el próximo cambio de aceite.</param>
        /// <param name="nextChange">Kilometraje estimado para el próximo cambio.</param>
        /// <param name="observation">Observación realizada durante la orden de trabajo.</param>
        /// <param name="amount">Monto total a pagar por la orden de trabajo.</param>
        /// <param name="state">Estado actual de la orden de trabajo.</param>
        public WorkOrder(DateTime date, Branch branch, Client client, Vehicle vehicle, int currentMileage, int recommendedMileage, int nextChange, Observation observation, decimal amount, string state)
        {
            Date = date;
            Branch = branch;
            Client = client;
            Vehicle = vehicle;
            CurrentMileage = currentMileage;
            RecommendedMileage = recommendedMileage;
            NextChange = nextChange;
            Observations = new List<Observation>() { observation };
            Amount = amount;
            State = state;
        }

        /// <summary>
        /// Sobrescritura del método ToString para representar la información de la orden de trabajo.
        /// </summary>
        /// <returns>Representación en cadena de la orden de trabajo.</returns>
        public override string ToString()
        {
            return Id + " " + Date + " " + Branch + " " + Client + " " + Vehicle + " " + CurrentMileage + " " + RecommendedMileage + " " + NextChange + " " + Observations + " " + Amount + " " + State;
        }
    }
}
