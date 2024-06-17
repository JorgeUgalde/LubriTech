using LubriTech.Model.Client_Information;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;

namespace LubriTech.Model.Vehicle_Information
{
    public class Vehicle
    {
        public string LicensePlate { get; set; }
        public string Engine { get; set; }
        public int Mileage { get; set; }
        public CarModel Model { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public Client Client { get; set; }
        public string State { get; set; }

        public Vehicle() { }

        public Vehicle(string licensePlate, string engine, int mileage, CarModel model, int year, string transmission, Client client, string state)
        {
            this.LicensePlate = licensePlate;
            this.Engine = engine;
            this.Mileage = mileage;
            this.Model = model;
            this.Year = year;
            this.Transmission = transmission;
            this.Client = client;
            this.State = state;
        }

        public string getClientId()
        {
            return this.Client.Id;
        }

        public int getModelId()
        {
            return this.Model.Id;
        }

        override
        public string ToString()
        {
            return "Placa: " + LicensePlate + "\nMotor: " + Engine + "\nKilometraje: " + Mileage + "\nMarca: " + Model.Make.Name + "\nModelo: " + Model.Name + "\nAño: " + Year + "\nTransimisión: " + Transmission + "\nIdentificación cliente: " + Client.Id + "\nEstado: " + State;
        }

    }
}
