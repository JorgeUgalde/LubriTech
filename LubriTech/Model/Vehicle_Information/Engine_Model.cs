using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.Model.Vehicle_Information
{
    public class Engine_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);
        public List<Engine> loadAllEngines()
        {
            List<Engine> engines = new List<Engine>();
            try
            {
                string selectQuery = "SELECT * FROM CatalogoMotor";
                DataTable tblEngine = new DataTable();
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(tblEngine);
                foreach (DataRow row in tblEngine.Rows)
                {
                    engines.Add(new Engine(Convert.ToInt32(row["Identificacion"]), row["TipoMotor"].ToString(), (Convert.ToInt32(row["Estado"]) == 1) ? "Activo" : "Inactivo"));
                }
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                return engines;
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

        public Engine getEngine(int engineId)
        {
            try
            {
                String selectQueryModels = "SELECT * FROM CatalogoMotor WHERE CatalogoMotor.Identificacion = @identificacion;";
                SqlCommand select = new SqlCommand(selectQueryModels, conn);
                select.Parameters.AddWithValue("@identificacion", engineId);

                DataTable tblEngineCatalog = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = select;

                adp.Fill(tblEngineCatalog);
                Engine engine = null;

                foreach (DataRow dr in tblEngineCatalog.Rows)
                {
                    engine = new Engine(Convert.ToInt32(dr["Identificacion"]),
                                        dr["TipoMotor"].ToString(),
                                        (Convert.ToInt32(dr["Estado"]) == 1) ? "Activo" : "Inactivo");
                }

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();

                }

                select.ExecuteNonQuery();

                return engine;
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

        // update or Insert a engine type
        public Boolean Upsert(Engine engine)
        {
            try
            {
                string query = "";
                if (getEngine(engine.Id) == null)
                {
                    query = "insert into CatalogoMotor (TipoMotor, Estado) values (@engineType, @state)";
                }
                else
                {
                    query = "update CatalogoMotor set TipoMotor = @engineType, Estado = @state where Identificacion = @Id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@engineType", engine.EngineType);
                cmd.Parameters.AddWithValue("@Id", engine.Id);
                cmd.Parameters.AddWithValue("@state", (engine.State.Equals("Activo")) ? 1 : 0);


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
