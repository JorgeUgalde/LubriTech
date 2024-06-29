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

        public Int64 phone { get; set; }

        public string state { get; set; }

        public Supplier(string id, string name, string email, Int64 phone, string state)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.state = state;
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
            return name;
        }
    }
}
