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
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public Client Client { get; set; }

        public Vehicle() { }

        public Vehicle(string licensePlate, string engine, int mileage, string brand, string model, int year, string transmission, Client client)
        {
            this.LicensePlate = licensePlate;
            this.Engine = engine;
            this.Mileage = mileage;
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.Transmission = transmission;
            this.Client = client;
        }

        public string getClientId()
        {
            return this.Client.Id;
        }

        override
        public string ToString()
        {
            return "Placa: " + LicensePlate + "\nMotor: " + Engine + "\nKilometraje: " + Mileage + "\nMarca: " + Brand + "\nModelo: " + Model + "\nAño: " + Year + "\nTransimisión: " + Transmission + "\nIdentificación cliente: " + Client.Id;
        }

    }
}
