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
    public class Transmission_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);
        public List<Transmission> loadAllTransmissions()
        {
            List<Transmission> transmissions = new List<Transmission>();
            try
            {
                string selectQuery = "SELECT * FROM CatalogoTransmision";
                DataTable tblTransmission = new DataTable();
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(tblTransmission);
                foreach (DataRow row in tblTransmission.Rows)
                {
                    transmissions.Add(new Transmission(Convert.ToInt32(row["Identificacion"]), row["TipoTransmision"].ToString(), (Convert.ToInt32(row["Estado"]) == 1) ? "Activo" : "Inactivo"));
                }
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                return transmissions;
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

        public Transmission getTransmission(int transmissionId)
        {
            try
            {
                String selectQueryModels = "SELECT * FROM CatalogoTransmision WHERE CatalogoTransmision.Identificacion = @identificacion;";
                SqlCommand select = new SqlCommand(selectQueryModels, conn);
                select.Parameters.AddWithValue("@identificacion", transmissionId);

                DataTable tblTransmissionCatalog = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = select;

                adp.Fill(tblTransmissionCatalog);
                Transmission transmission = null;

                foreach (DataRow dr in tblTransmissionCatalog.Rows)
                {
                    transmission = new Transmission(Convert.ToInt32(dr["Identificacion"]),
                                        dr["TipoTransmision"].ToString(),
                                        (Convert.ToInt32(dr["Estado"]) == 1) ? "Activo" : "Inactivo");
                }

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();

                }

                select.ExecuteNonQuery();

                return transmission;
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

        // update or Insert a transmission type
        public Boolean Upsert(Transmission transmission)
        {
            try
            {
                string query = "";
                if (getTransmission(transmission.Id) == null)
                {
                    query = "insert into CatalogoTransmision (TipoTransmision, Estado) values (@transmissionType, @state)";
                }
                else
                {
                    query = "update CatalogoTransmision set TipoTransmision = @transmissionType, Estado = @state where Identificacion = @Id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@transmissionType", transmission.TransmissionType);
                cmd.Parameters.AddWithValue("@Id", transmission.Id);
                cmd.Parameters.AddWithValue("@state", (transmission.State.Equals("Activo")) ? 1 : 0);


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
