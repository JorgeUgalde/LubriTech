using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controller class that manages business logic regarding makes.
    /// It uses the class model <see cref="Make_Model"/> to obtain useful methods.
    /// </summary>
    public class Make_Controller
    {
        /// <summary>
        /// Retrieves all vehicle makes.
        /// </summary>
        /// <returns>A list of all makes.</returns>
        public List<Make> getAll()
        {
         return new Make_Model().loadAllMakes();
        }

        /// <summary>
        /// Retrives a make by its identification.
        /// </summary>
        /// <param name="id">Make identification.</param>
        /// <returns>Make object, or null if the make was not found.</returns>
        public Make getMake(int id)
        {
            return new Make_Model().getMake(id);
        }

        /// <summary>
        /// Inserts or updates a make in the database.
        /// </summary>
        /// <param name="make">Make object to insert or update.</param>
        /// <returns>True if the operation was succesful, otherwise false.</returns>
        public bool upsertMake(Make make)
        {
            return new Make_Model().Upsert(make);
        }
    }
}
