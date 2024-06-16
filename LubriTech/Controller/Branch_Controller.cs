using LubriTech.Model.Branch_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class Branch_Controller
    {
        public List<Branch> getAll()
        {
            return new Branch_Model().loadAllBranches();
        }

        public Branch get(int Id)
        {
            return new Branch_Model().GetBranch(Id);
        }

        public bool Upsert(Branch branch)
        {
            return new Branch_Model().UpsertBranch(branch);
        }
    }
}
