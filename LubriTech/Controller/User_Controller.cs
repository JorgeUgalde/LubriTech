using LubriTech.Model.User_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controlador que maneja la lógica de negocio relacionada con los usuarios. Utiliza el modelo <see cref="User_Model"/> para obtener la información
    /// </summary>
    public class User_Controller
    {
        /// <summary>
        /// Obtiene un usuario basado en el objeto User proporcionado.
        /// </summary>
        /// <param name="user">Objeto User que contiene los detalles del usuario a obtener.</param>
        /// <returns>Usuario encontrado, o null si no se encuentra.</returns>
        public User GetUser(User user)
        {
            return new User_Model().GetUser(user);
        }


    }
}
