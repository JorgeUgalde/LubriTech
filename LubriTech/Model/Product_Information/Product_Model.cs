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
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

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
                    products.Add(new Product(reader["Codigo"].ToString(), reader["Nombre"].ToString(), Convert.ToDouble(reader["Precio"]), reader["UnidadMedida"].ToString(), reader["Estado"].ToString()));
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
    }
}
