using LubriTech.Model.User_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controller class that manages business logic regarding users.
    /// It uses the class model <see cref="User_Model"/> to obtain useful methods.
    /// </summary>
    public class User_Controller
    {
        /// <summary>
        /// Retrives an user by the user object from parameters.
        /// </summary>
        /// <param name="user">User object to retrieve.</param>
        /// <returns>User object, or null if the user was not found.</returns>
        public User GetUser(User user)
        {
            return new User_Model().GetUser(user);
        }

        public bool Upsert(User user, string newPassword)
        {
            return new User_Model().Upsert(user, newPassword);
        }

        public User Validation(User user)
        {
            return new User_Model().EmailValidation(user);

        }

        public bool Reset(User user, string code)
        {
            return new User_Model().UpdatePassword(user, code);

        }
    }
}
