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

        public Product get(string code)
        {
            return new Product_Model().getProduct(code);
        }

        public bool UpSert(Product product)
        {
            return new Product_Model().UpSertProduct(product);
        }
        public bool remove(string code) {
            return new Product_Model().removeProduct(code);
        }
    }
}
