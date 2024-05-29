using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace LubriTech.Model
{
    public class Vehicle
    {
        public string LicensePlate { get; set; }

        public string Engine { get; set; }

        public double Mileage { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Transmission { get; set; }

        public string CustomerId { get; set; }

        public Vehicle(string licensePlate, string engine, double mileage, string brand, string model, int year, string transmission, string customerId)
        {
            LicensePlate = licensePlate;
            Engine = engine;
            Mileage = mileage;
            Brand = brand;
            Model = model;
            Year = year;
            Transmission = transmission;
            CustomerId = customerId;
        }

        public string ToString()
        {
            return "License Plate: " + LicensePlate +
                "\nEngine: " + Engine +
                "\nMileage: " + Mileage +
                "\nBrand: " + Brand +
                "\nModel: " + Model +
                "\nYear: " + Year +
                "\nTransmission: " + Transmission +
                "\nCustomer ID: " + CustomerId;
        }

    }
}
