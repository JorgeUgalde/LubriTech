using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.WorkOrder_Information
{
    /// <summary>
    /// Clase que gestiona las operaciones CRUD para las observaciones relacionadas con órdenes de trabajo en la base de datos.
    /// </summary>
    public class Observation_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        /// <summary>
        /// Carga todas las observaciones asociadas a una orden de trabajo específica desde la base de datos.
        /// </summary>
        /// <param name="workOrderId">Identificador de la orden de trabajo.</param>
        /// <returns>Lista de objetos Observation.</returns>
        public List<Observation> loadObservationsFromWorkOrder(int workOrderId)
        {
            try
            {
                List<Observation> observations = new List<Observation>();

                conn.Open();
                String selectQuery = "SELECT * FROM Observacion where IdentificacionOrdenTrabajo = @id";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", workOrderId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    observations.Add(new Observation((int)reader["Id"], reader["Descripcion"].ToString(), reader["Fotografia"].ToString()));
                }
                return observations;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Carga una observación específica desde la base de datos.
        /// </summary>
        /// <param name="observationId">Identificador de la observación.</param>
        /// <returns>Objeto Observation si se encuentra, de lo contrario null.</returns>
        public Observation loadObservation(int observationId)
        {
            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM Observacion where CodigoObservacion = @id";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", observationId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Observation((int)reader["Id"], reader["Descripcion"].ToString(), reader["Fotografia"].ToString());
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Inserta o actualiza una observación en la base de datos.
        /// </summary>
        /// <param name="observation">Objeto Observation a insertar o actualizar.</param>
        /// <returns>true si la operación fue exitosa, false si hubo algún error.</returns>
        public bool upsertObservation(Observation observation)
        {
            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM Observacion where CodigoObservacion = @id";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", observation.Codigo);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    conn.Close();
                    conn.Open();
                    String updateQuery = "UPDATE Observacion SET Descripcion = @description, Fotografia = @photos WHERE Id = @id";
                    SqlCommand cmd2 = new SqlCommand(updateQuery, conn);
                    cmd2.Parameters.AddWithValue("@description", observation.Description);
                    cmd2.Parameters.AddWithValue("@photos", observation.Photos);
                    cmd2.Parameters.AddWithValue("@id", observation.Codigo);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    String insertQuery = "INSERT INTO Observacion (Descripcion, Fotografia, IdentificacionOrdenTrabajo) VALUES (@description, @photos, @workOrderId)";
                    SqlCommand cmd2 = new SqlCommand(insertQuery, conn);
                    cmd2.Parameters.AddWithValue("@description", observation.Description);
                    cmd2.Parameters.AddWithValue("@photos", observation.Photos);
                    cmd2.Parameters.AddWithValue("@workOrderId", observation.WorkOrderId);
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
                conn.Close();
            }
        }

        /// <summary>
        /// Elimina una observación de la base de datos.
        /// </summary>
        /// <param name="observationId">Identificador de la observación a eliminar.</param>
        /// <returns>true si la eliminación fue exitosa, false si hubo algún error.</returns>
        public bool deleteObservation(int observationId)
        {
            try
            {
                conn.Open();
                String deleteQuery = "DELETE FROM Observacion WHERE CodigoObservacion = @id";
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@id", observationId);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
