using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.Model.Supplier
{
    public class Supplier_Model
    {
            SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

            public List<Supplier> loadAllSuppliers()
            {
                List<Supplier> suppliers = new List<Supplier>();

                try
                {
                    String selectQuery = "select * from Proveedor";

                    DataTable tblSupplier = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.SelectCommand = new SqlCommand(selectQuery);

                    foreach (DataRow dr in tblSupplier.Rows)
                    {
                        suppliers.Add(new Supplier(dr["Identificacion"].ToString(), dr["Nombre"].ToString(), dr["CorreoElectronico"].ToString(), (int)dr["NumeroTelefono"]));
                    }
                    return suppliers;
                }
                catch (Exception ex)
                {
                    throw (ex);
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
                    //Guardar los datos del error en un log
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

            public Boolean updateSupplier(Supplier supplier)
            {
                try
                {
                    string updateQuery = "update Proveedor set Nombre= @name, CorreoElectronico = @email, NumeroTelefono = @phone where @id = Supplier.id";
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

            public void deleteSupplier(int supplierId)
            {
                try
                {
                    string deleteQuery = "delete from Proveedor where @id = Supplier.id";
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
