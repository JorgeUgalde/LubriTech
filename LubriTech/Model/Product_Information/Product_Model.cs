using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.Model.Product_Information
{
    public class Product_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.conn);

        public List<Product> loadAllProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                    conn.Open();
          

                String selectQuery = "select * from Producto";

                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product(reader["Codigo"].ToString(), reader["Nombre"].ToString(), 
                        Convert.ToDouble(reader["Precio"]), reader["UnidadMedida"].ToString(),
                        reader["Estado"].ToString(), getSuppliers(reader["Codigo"].ToString())));
                }
                return products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        private List<Supplier> getSuppliers(string productCode)
        {

            List<Supplier> suppliers = new List<Supplier>();
            string selectQuery = "select IdentificacionProveedor from Provee where Provee.CodigoProducto = @productCode";
            SqlCommand cmd = new SqlCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@productCode", productCode);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
               // suppliers.Add(new Supplier_Model().getSupplier(reader["IdentificacionProveedor"].ToString()));
            }

            return null;

        }
    }
}
