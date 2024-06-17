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
    public class WorkOrder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Branch Branch { get; set; }
        public Client Client { get; set; }
        public Vehicle Vehicle { get; set; }
        public int CurrentMileage { get; set; }
        public int RecommendedMileage { get; set; }
        public int NextChange { get; set; }
        public List<Observation> Observations { get; set; }
        public decimal Amount { get; set; }
        public string State { get; set; }

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


        public WorkOrder(DateTime date, Branch branch, Client client, Vehicle vehicle, int currentMileage, int recommendedMileage, int nextChange, Observation observation, decimal amount, string state)
        {
        }

        override
        public string ToString()
        {
            return Id + " " + Date + " " + Branch + " " + Client + " " + Vehicle + " " + CurrentMileage + " " + RecommendedMileage + " " + NextChange + " " + Observations + " " + Amount + " " + State;
        }
    }
}
