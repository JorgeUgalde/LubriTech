using LubriTech.Model.Product_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class Product_Controller
    {
        public List<Product> getAll()
        {
            return new Product_Model().loadAllProducts();
        }
    }
}
