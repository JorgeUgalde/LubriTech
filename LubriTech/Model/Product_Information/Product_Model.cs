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

        public Product getProduct(string code)
        {
            try
            {
                string selectQuery = "select * from Producto where [Producto].Codigo = @code";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@code", code);

                DataTable tblProducts = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;

                adp.Fill(tblProducts);
                DataRow dr = tblProducts.Rows[0];

                Product product = new Product(dr["Codigo"].ToString(), dr["Nombre"].ToString(),
                                           Convert.ToDouble(dr["Precio"]), dr["UnidadMedida"].ToString(),
                                           dr["Estado"].ToString(), getSuppliers(dr["Codigo"].ToString()));

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return product;
            }
            catch (Exception ex)
            {
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

        public Boolean UpSertProduct(Product product)
        {
            try
            {
                if(getProduct(product.code) != null)
                {
                    return updateProduct(product);
                }
                else
                {
                    return addProduct(product);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Boolean updateProduct(Product product)
        {
            try
            {
                string updateQuery = "update Producto set Nombre = @name, Precio = @price, UnidadMedida = @measureUnit, Estado = @state where Codigo = @code";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@code", product.code);
                cmd.Parameters.AddWithValue("@name", product.name);
                cmd.Parameters.AddWithValue("@price", product.price);
                cmd.Parameters.AddWithValue("@measureUnit", product.measureUnit);
                cmd.Parameters.AddWithValue("@state", product.state);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                string deleteQuery = "delete from Provee where CodigoProducto = @productCode";
                SqlCommand cmd2 = new SqlCommand(deleteQuery, conn);
                cmd2.Parameters.AddWithValue("@productCode", product.code);

                cmd2.ExecuteNonQuery();

                foreach (Supplier supplier in product.suppliers)
                {
                    string insertQuery = "insert into Provee values(@productCode, @supplierId)";
                    SqlCommand cmd3 = new SqlCommand(insertQuery, conn);
                    cmd3.Parameters.AddWithValue("@productCode", product.code);
                    cmd3.Parameters.AddWithValue("@supplierId", supplier.id);

                    cmd3.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
        public Boolean addProduct(Product product)
        {
            try
            {
                string insertQuery = "insert into Producto (Codigo, Nombre, Precio, UnidadMedida, Estado) values(@code, @name, @price, @measureUnit, @state)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@code", product.code);
                cmd.Parameters.AddWithValue("@name", product.name);
                cmd.Parameters.AddWithValue("@price", product.price);
                cmd.Parameters.AddWithValue("@measureUnit", product.measureUnit);
                cmd.Parameters.AddWithValue("@state", product.state);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                foreach (Supplier supplier in product.suppliers)
                {
                    string insertQuery2 = "insert into Provee (CodigoProducto, IdentificacionProveedor) values(@productCode, @supplierId)";
                    SqlCommand cmd2 = new SqlCommand(insertQuery2, conn);
                    cmd2.Parameters.AddWithValue("@productCode", product.code);
                    cmd2.Parameters.AddWithValue("@supplierId", supplier.id);

                    cmd2.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public Boolean removeProduct(string code)
        {
            try
            {
                string deleteQuery = "delete from Producto where [Producto].Codigo = @code";
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@code", code);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
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

                return suppliers;
            }
            catch (Exception ex)
            {
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
