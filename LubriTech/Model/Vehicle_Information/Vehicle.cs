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
    /// <summary>
    /// Representa un vehículo.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Placa del vehículo que funciona como un identificador único.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Tipo de motor del vehículo.
        /// </summary>
        public Engine EngineType { get; set; }

        /// <summary>
        /// Kilometraje del vehículo.
        /// </summary>
        public int Mileage { get; set; }

        /// <summary>
        /// Modelo del vehículo.
        /// </summary>
        public CarModel Model { get; set; }

        /// <summary>
        /// Año del vehículo.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Tipo de transmisión del vehículo.
        /// </summary>
        public Transmission TransmissionType { get; set; }

        /// <summary>
        /// Cliente asociado al vehículo.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Estado del vehículo (activo o inactivo).
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Constructor por defecto de la clase Vehicle.
        /// </summary>
        public Vehicle() { }

        /// <summary>
        /// Constructor que inicializa las propiedades del vehículo con los valores proporcionados.
        /// </summary>
        /// <param name="licensePlate">La placa del vehículo.</param>
        /// <param name="engine">El motor del vehículo.</param>
        /// <param name="mileage">El kilometraje del vehículo.</param>
        /// <param name="model">El modelo del vehículo.</param>
        /// <param name="year">El año del vehículo.</param>
        /// <param name="transmission">El tipo de transmisión del vehículo.</param>
        /// <param name="client">El cliente asociado al vehículo.</param>
        /// <param name="state">El estado del vehículo.</param>
        public Vehicle(string licensePlate, Engine engine, int mileage, CarModel model, int year, Transmission transmission, Client client, string state)
        {
            this.LicensePlate = licensePlate;
            this.EngineType = engine;
            this.Mileage = mileage;
            this.Model = model;
            this.Year = year;
            this.TransmissionType = transmission;
            this.Client = client;
            this.State = state;
        }

        /// <summary>
        /// Obtiene el Identificador del cliente asociado al vehículo.
        /// </summary>
        /// <returns>El Identificador del cliente.</returns>
        public string getClientId()
        {
            return this.Client.Id;
        }

        /// <summary>
        /// Obtiene el Identificador del modelo de vehículo.
        /// </summary>
        /// <returns>El Identificador del modelo.</returns>
        public int getModelId()
        {
            return this.Model.Id;
        }

        /// <summary>
        /// Obtiene el Identificador del tipo de transmisión de vehículo.
        /// </summary>
        /// <returns>El Identificador del tipo de transmisión.</returns>
        public int getTransmissionId()
        {
            return this.TransmissionType.Id;
        }

        /// <summary>
        /// Obtiene el Identificador del tipo de motor de vehículo.
        /// </summary>
        /// <returns>El Identificador del tipo de motor.</returns>
        public int getEnginelId()
        {
            return this.EngineType.Id;
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa los detalles del vehículo.</returns>
        public override string ToString()
        {
            return Model.Make.Name + " " + Model.Name;
        }

    }
}
