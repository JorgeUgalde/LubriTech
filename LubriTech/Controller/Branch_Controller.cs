using LubriTech.Model.Branch_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controller class that manages business logic regarding branches. It uses the class model <see cref="Branch_Model"/> to obtain useful methods.
    /// </summary>
    public class Branch_Controller
    {
        /// <summary>
        /// Gets all the branches in a List object.
        /// </summary>
        /// <returns>List of all branch objects.</returns>
        public List<Branch> getAll()
        {
            return new Branch_Model().loadAllBranches();
        }

        /// <summary>
        /// Gets a branch by their identification.
        /// </summary>
        /// <param name="Id">branch identification.</param>
        /// <returns>Branch object, or null in case that the branch was not found.</returns>
        public Branch get(int Id)
        {
            return new Branch_Model().GetBranch(Id);
        }

        /// <summary>
        /// Updates or inserts a branch.
        /// </summary>
        /// <param name="branch">Branch object.</param>
        /// <returns>True if the operation completed successfully of false in case of an error.</returns>
        public bool Upsert(Branch branch)
        {
            return new Branch_Model().UpsertBranch(branch);
        }
    }
}
