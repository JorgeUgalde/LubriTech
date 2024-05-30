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

        public Supplier GetSupplier(int id)
        {
            return new Supplier_Model().getSupplier(id);
        }

        public Boolean Save(Supplier supplier)
        {
            Supplier_Model sm = new Supplier_Model();
            return sm.SaveSupplier(supplier);
        }

        public Boolean Update(Supplier supplier)
        {
            return new Supplier_Model().updateSupplier(supplier);
        }

        public void Delete(int supplierId)
        {
            new Supplier_Model().deleteSupplier(supplierId);
        }
    }
}
