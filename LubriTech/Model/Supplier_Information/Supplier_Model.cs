using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace LubriTech.Model.Supplier_Information
{
    public class Supplier_Model
    {
            SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

            public List<Supplier> loadAllSuppliers()
            {
                List<Supplier> suppliers = new List<Supplier>();

                try
                {

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                string selectQuery = "select * from Proveedor";

                DataTable tblSupplier = new DataTable();
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

               

                while (reader.Read())
                    {
                        suppliers.Add(new Supplier(reader["Identificacion"].ToString(), reader["Nombre"].ToString(), reader["CorreoElectronico"].ToString(), Convert.ToInt64(reader["NumeroTelefono"])));
                    }
                    return suppliers;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

            public Supplier getSupplier(string id)
            {

            Supplier supplier = null;
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                string query = "Select * from Proveedor where [Proveedor].Identificacion = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    supplier = new Supplier(reader["Identificacion"].ToString(), reader["Nombre"].ToString(), reader["CorreoElectronico"].ToString(), Convert.ToInt64(reader["NumeroTelefono"]));
                }
                return supplier;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

            public Boolean SaveSupplier(Supplier supplier)
            {
                try
                {
                    String insertQuery = "insert into Proveedor(Identificacion, Nombre, CorreoElectronico, NumeroTelefono) values (@id,@name,@email,@phone)";

                    SqlCommand insert = new SqlCommand(insertQuery, conn);

                    insert.Parameters.AddWithValue("@id", supplier.id);
                    insert.Parameters.AddWithValue("@name", supplier.name);
                    insert.Parameters.AddWithValue("@email", supplier.email);
                    insert.Parameters.AddWithValue("@phone", supplier.phone);

                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    insert.ExecuteNonQuery();

                    return true;

                }
                catch (SqlException ex)
                {
                return false;
                    throw ex;

                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }


            }

        public Boolean upsertSupplier(Supplier supplier)
        {
            try
            {
                if (getSupplier(supplier.id) == null)
                {
                    return SaveSupplier(supplier);
                }
                else
                {
                    return updateSupplier(supplier);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }   

        public Boolean updateSupplier(Supplier supplier)
            {
                try
                {
                    string updateQuery = "update Proveedor set Nombre= @name, CorreoElectronico = @email, NumeroTelefono = @phone where [Proveedor].Identificacion = @id";
                    SqlCommand update = new SqlCommand(updateQuery, conn);

                    update.Parameters.AddWithValue("@name", supplier.name);
                    update.Parameters.AddWithValue("@email", supplier.email);
                    update.Parameters.AddWithValue("@phone", supplier.phone);
                    update.Parameters.AddWithValue("@id", supplier.id);


                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    update.ExecuteNonQuery();

                    return true;

                }
                catch (SqlException ex)
                {
                return false;
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }

            public void deleteSupplier(string supplierId)
            {
                try
                {
                    string deleteQuery = "delete from Proveedor where [Proveedor].Identificacion = @id";
                    SqlCommand delete = new SqlCommand(deleteQuery, conn);

                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    delete.Parameters.AddWithValue("@id", supplierId);
                    delete.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
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
