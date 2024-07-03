using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.User_Information
{
    /// <summary>
    /// Representa un Uusario para el inicio de sesion en la aplicacion.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        ///  Identificador de la sucursal a la que pertenece el usuario.
        /// </summary>
        public int branchID { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="User"/> con los valores especificados.
        /// </summary>
        /// <param name="email">El correo electrónico del usuario.</param>
        /// <param name="password">La contraseña del usuario.</param>
        /// <param name="branchID">Identificacion de la sucrusal.</param>
        public User(string email, string password, int branchID)
        {
            this.email = email;
            this.password = password;
            this.branchID = branchID;
        }
        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public User()
        {
        }



        /// <summary>
        /// Cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa el correo electrónico del usuario.</returns>
        public override string ToString()
        {
            return email;
        }
    }
}
