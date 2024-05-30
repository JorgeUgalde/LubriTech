using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.Data;
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
                string selectQuery = "select * from Producto";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);

                DataTable tblProducts = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(tblProducts);

                foreach (DataRow dr in tblProducts.Rows)
                {
                    products.Add(new Product(dr["Codigo"].ToString(), dr["Nombre"].ToString(),
                        Convert.ToDouble(dr["Precio"]), dr["UnidadMedida"].ToString(),
                        dr["Estado"].ToString(), getSuppliers(dr["Codigo"].ToString())));
                }


                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();

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
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        private List<Supplier> getSuppliers(string productCode)
        {

            try
            {

                List<Supplier> suppliers = new List<Supplier>();
                string selectQuery = "select IdentificacionProveedor from Provee where [Provee].CodigoProducto = @productCode";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@productCode", productCode);

                DataTable tblSuppliers = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;

                adp.Fill(tblSuppliers);
                Supplier supplier = null;


                foreach (DataRow dr in tblSuppliers.Rows)
                {
                    suppliers.Add( new Supplier_Model().getSupplier(dr["IdentificacionProveedor"].ToString()) );
                }


                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                
                cmd.ExecuteNonQuery();

                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }

                return suppliers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }

            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }


        }
    }
}
