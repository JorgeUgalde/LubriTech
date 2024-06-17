using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Supplier_Information
{
    /// <summary>
    /// Representa un proveedor dentro del sistema.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Identificador único del proveedor.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Nombre del proveedor.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Correo electrónico del proveedor.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Número de teléfono del proveedor.
        /// </summary>
        public int phone { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Supplier"/> con los valores especificados.
        /// </summary>
        /// <param name="id">El identificador del proveedor.</param>
        /// <param name="name">El nombre del proveedor.</param>
        /// <param name="email">El correo electrónico del proveedor.</param>
        /// <param name="phone">El número de teléfono del proveedor.</param>
        public Supplier(string id, string name, string email, int phone)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Supplier"/> de forma predeterminada.
        /// </summary>
        public Supplier() { }

        /// <summary>
        /// Cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa la información del proveedor.</returns>
        public override string ToString()
        {
            return "Id: " + id + "\nName: " + name + "\nEmail: " + email + "\nPhone number: " + phone;
        }
    }
}
