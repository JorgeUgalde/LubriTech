using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Branch_Information
{
    /// <summary>
    /// Clase que representa una sucursal en el sistema.
    /// </summary>
    public class Branch
    {
        /// <summary>
        /// Identificador único de la sucursal.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la sucursal.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Dirección física de la sucursal.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Número de teléfono de la sucursal.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Correo electrónico de contacto de la sucursal.
        /// </summary>
        public string Email { get; set; }

        public short State { get; set; }

        /// <summary>
        /// Constructor por defecto de la clase Branch.
        /// </summary>
        public Branch() { }

        /// <summary>
        /// Constructor de la clase Branch que inicializa todos los atributos.
        /// </summary>
        /// <param name="id">Identificador único de la sucursal.</param>
        /// <param name="name">Nombre de la sucursal.</param>
        /// <param name="address">Dirección física de la sucursal.</param>
        /// <param name="phone">Número de teléfono de la sucursal.</param>
        /// <param name="email">Correo electrónico de contacto de la sucursal.</param>
        public Branch(int id, string name, string address, string phone, string email, short state)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.State = state;
        }

        /// <summary>
        /// Constructor alternativo de la clase Branch que inicializa solo la identificación y nombre.
        /// </summary>
        /// <param name="id">Identificador único de la sucursal.</param>
        /// <param name="name">Nombre de la sucursal.</param>
        public Branch(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Sobrescribe el método ToString para mostrar información detallada de la sucursal.
        /// </summary>
        /// <returns>Cadena que representa la información de la sucursal.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
