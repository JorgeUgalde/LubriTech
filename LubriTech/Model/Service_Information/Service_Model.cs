using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Service_Information
{
    public class Service_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        public List<Service> loadAllServices()
        {
            List<Service> services = new List<Service>();

            try
            {


                string selectQuery = "select * from Servicio";

                DataTable tblService = new DataTable();
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = cmd;
                adp.Fill(tblService);

                foreach (DataRow row in tblService.Rows)
                {
                    services.Add(new Service(Convert.ToInt32(row["CodigoServicio"]), 
                                row["Nombre"].ToString(), Convert.ToDouble(row["Precio"])));
                    
                }
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
                return services;
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

        public Service getService(int id)
        {
            try
            {
                string query = "select * from Servicio where CodigoServicio = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Service(Convert.ToInt32(reader["CodigoServicio"]),
                                               reader["Nombre"].ToString(),
                                               Convert.ToDouble(reader["Precio"]));                   
                }
                return null;
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

        public Boolean Upsert(Service service)
        {
            try
            {
                string query = "";
                if (getService(service.ID) == null)
                {
                    query = "insert into Servicio (Nombre, Precio) values (@name, @price)";
                }
                else
                {
                    query = "update Servicio set Nombre = @name, Precio = @price where CodigoServicio = @code";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", service.name);
                cmd.Parameters.AddWithValue("@price", service.price);
                cmd.Parameters.AddWithValue("@code", service.ID);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
                return true;
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

        public bool Delete(int id)
        {
            try
            {
                string query = "delete from Servicio where CodigoServicio = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
                return true;
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


    }




}
