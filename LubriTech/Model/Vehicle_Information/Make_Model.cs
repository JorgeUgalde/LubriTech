using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Vehicle_Information
{
    /// <summary>
    /// Clase que maneja las operaciones de la base de datos relacionadas con la entidad <see cref="Make"/>.
    /// </summary>
    public class Make_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        /// <summary>
        /// Carga todas las marcas de vehículos de la base de datos.
        /// </summary>
        /// <returns>Una lista de todas las marcas de vehículos.</returns>
        /// <exception cref="Exception">Se produce cuando ocurre un error al cargar las marcas.</exception>
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

        /// <summary>
        /// Obtiene una marca de vehículo de la base de datos por su Identificador.
        /// </summary>
        /// <param name="id">El Identificador de la marca.</param>
        /// <returns>La marca correspondiente al Identificador proporcionado.</returns>
        /// <exception cref="Exception">Se produce cuando ocurre un error al obtener la marca.</exception>
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

        /// <summary>
        /// Inserta o actualiza una marca de vehículo en la base de datos.
        /// </summary>
        /// <param name="make">La marca de vehículo a insertar o actualizar.</param>
        /// <returns>true si la operación tuvo éxito; de lo contrario, false.</returns>
        /// <exception cref="Exception">Se produce cuando ocurre un error al insertar o actualizar la marca.</exception>
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
                cmd.Parameters.AddWithValue("@state", (make.State.Equals("Activo")) ? 1 : 0);

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
