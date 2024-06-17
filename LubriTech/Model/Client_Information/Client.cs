using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Client_Information
{
    /// <summary>
    /// Clase que representa un cliente en el sistema.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Identificador único del cliente.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nombre completo del cliente.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Número de teléfono principal del cliente.
        /// </summary>
        public int? MainPhoneNum { get; set; }

        /// <summary>
        /// Número de teléfono adicional del cliente.
        /// </summary>
        public int? AdditionalPhoneNum { get; set; }

        /// <summary>
        /// Correo electrónico del cliente.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Dirección del cliente.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Estado del cliente (activo o inactivo).
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Lista de vehículos asociados al cliente.
        /// </summary>
        public List<Vehicle> Vehicle { get; set; }

        /// <summary>
        /// Constructor completo de la clase Client.
        /// </summary>
        /// <param name="id">Identificador único del cliente.</param>
        /// <param name="fullName">Nombre completo del cliente.</param>
        /// <param name="mainPhoneNum">Número de teléfono principal del cliente.</param>
        /// <param name="additionalPhoneNum">Número de teléfono adicional del cliente.</param>
        /// <param name="email">Correo electrónico del cliente.</param>
        /// <param name="address">Dirección del cliente.</param>
        /// <param name="vehicle">Lista de vehículos asociados al cliente.</param>
        /// <param name="state">Estado del cliente (activo o inactivo).</param>
        public Client(string id, string fullName, int? mainPhoneNum, int? additionalPhoneNum, string email, string address, List<Vehicle> vehicle, string state)
        {
            Id = id;
            FullName = fullName;
            MainPhoneNum = mainPhoneNum;
            AdditionalPhoneNum = additionalPhoneNum;
            Email = email;
            Address = address;
            this.Vehicle = vehicle;
            State = state;
        }

        /// <summary>
        /// Constructor alternativo de la clase Client sin lista de vehículos.
        /// </summary>
        /// <param name="id">ID único del cliente.</param>
        /// <param name="fullName">Nombre completo del cliente.</param>
        /// <param name="mainPhoneNum">Número de teléfono principal del cliente.</param>
        /// <param name="additionalPhoneNum">Número de teléfono adicional del cliente.</param>
        /// <param name="email">Correo electrónico del cliente.</param>
        /// <param name="address">Dirección del cliente.</param>
        /// <param name="state">Estado del cliente (activo o inactivo).</param>
        public Client(string id, string fullName, int? mainPhoneNum, int? additionalPhoneNum, string email, string address, string state)
        {
            Id = id;
            FullName = fullName;
            MainPhoneNum = mainPhoneNum;
            AdditionalPhoneNum = additionalPhoneNum;
            Email = email;
            Address = address;
            State = state;
        }

        /// <summary>
        /// Constructor vacío de la clase Client.
        /// </summary>
        public Client()
        {
        }

        /// <summary>
        /// Sobrescribe el método ToString para mostrar el nombre completo del cliente.
        /// </summary>
        /// <returns>Nombre completo del cliente.</returns>
        public override string ToString()
        {
            return FullName;
        }
    }
}
