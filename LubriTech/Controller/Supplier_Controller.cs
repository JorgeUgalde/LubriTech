using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class Supplier_Controller
    {
        public List<Supplier> getAll()
        {
            return new Supplier_Model().loadAllSuppliers();
        }

        public Supplier GetSupplier(string id)
        {
            return new Supplier_Model().getSupplier(id);
        }

        public Boolean Upsert(Supplier supplier)
        {
            return new Supplier_Model().upsertSupplier(supplier);
        }

        public void Delete(string supplierId)
        {
            new Supplier_Model().deleteSupplier(supplierId);
        }
    }
}
