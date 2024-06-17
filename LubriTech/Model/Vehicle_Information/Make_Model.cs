using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Vehicle_Information
{
    public class Make_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);
        public List<Make> loadAllMakes()
        {
            List<Make> makes = new List<Make>();
            try
            {
                string selectQuery = "select * from CatalogoMarca";
                DataTable tblMake = new DataTable();
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(tblMake);
                foreach (DataRow row in tblMake.Rows)
                {
                    makes.Add(new Make(Convert.ToInt32(row["Identificacion"]), row["Nombre"].ToString(), row["Estado"].ToString()));
                }
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                return makes;
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

        public Make getMake(int id)
        {
            Make make = null;
            try
            {
                string selectQuery = "select * from CatalogoMarca where Identificacion = @id";
                DataTable tblMake = new DataTable();
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(tblMake);

                foreach (DataRow row in tblMake.Rows)
                {
                    make = new Make(Convert.ToInt32(row["Identificacion"]), row["Nombre"].ToString(), row["Estado"].ToString());
                }
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                return make;
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

        // update or Insert a make
        public Boolean Upsert(Make make)
        {
            try
            {
                string query = "";
                if (getMake(make.Id) == null)
                {
                    query = "insert into CatalogoMarca ( Nombre, Estado) values ( @name, @state)";
                }
                else
                {
                    query = "update CatalogoMarca set Nombre = @name, Estado = @state where Identificacion = @Id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", make.Name);
                cmd.Parameters.AddWithValue("@Id", make.Id);
                cmd.Parameters.AddWithValue("@state", make.State);

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
