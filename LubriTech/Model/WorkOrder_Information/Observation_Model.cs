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

        //load all observations from a work order
        public List<Observation> LoadObservations(int workOrderId)
        {
            List<Observation> observations = new List<Observation>();
            string selectQuery = "SELECT CodigoObservacion, IdentificacionOrdenTrabajo, Descripcion FROM Observacion WHERE IdentificacionOrdenTrabajo = @workOrderId";

            SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@workOrderId", workOrderId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Observation observation = new Observation
                            {
                                Code = reader.GetInt32(reader.GetOrdinal("CodigoObservacion")),
                                WorkOrderId = reader.GetInt32(reader.GetOrdinal("IdentificacionOrdenTrabajo")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString(reader.GetOrdinal("Descripcion")),
                                Photos = new ObservationPhotos_Model().LoadObservationPhotos(reader.GetInt32(reader.GetOrdinal("CodigoObservacion")))
                            };

                            observations.Add(observation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error loading observations: {ex.Message}");
                // Optionally rethrow or handle it as needed
                // throw;
                return null;
            }
            finally
            {
                conn.Close();
            }

            return observations;
        }


        
        public Observation upsertObservation(Observation observation)
        {
            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM Observacion WHERE CodigoObservacion = @id";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", observation.Code);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    conn.Close();
                    conn.Open();
                    String updateQuery = "UPDATE Observacion SET Descripcion = @description WHERE CodigoObservacion = @id";
                    SqlCommand cmd2 = new SqlCommand(updateQuery, conn);
                    cmd2.Parameters.AddWithValue("@description", observation.Description);
                    cmd2.Parameters.AddWithValue("@id", observation.Code);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    String insertQuery = "INSERT INTO Observacion (IdentificacionOrdenTrabajo, Descripcion) OUTPUT INSERTED.CodigoObservacion VALUES (@workOrderId, @description)";
                    SqlCommand cmd2 = new SqlCommand(insertQuery, conn);
                    cmd2.Parameters.AddWithValue("@description", observation.Description);
                    cmd2.Parameters.AddWithValue("@workOrderId", observation.WorkOrderId);

                    // Retrieve the new CodigoObservacion (primary key)
                    observation.Code = (int)cmd2.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading observations: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return observation;

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

                // Crear una transacción para asegurar la atomicidad de las operaciones
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Eliminar las fotos asociadas a la observación
                        String deletePhotosQuery = "DELETE FROM FotosObservacion WHERE CodigoObservacion = @id";
                        SqlCommand cmdDeletePhotos = new SqlCommand(deletePhotosQuery, conn, transaction);
                        cmdDeletePhotos.Parameters.AddWithValue("@id", observationId);
                        cmdDeletePhotos.ExecuteNonQuery();

                        // Eliminar la observación
                        String deleteObservationQuery = "DELETE FROM Observacion WHERE CodigoObservacion = @id";
                        SqlCommand cmdDeleteObservation = new SqlCommand(deleteObservationQuery, conn, transaction);
                        cmdDeleteObservation.Parameters.AddWithValue("@id", observationId);
                        cmdDeleteObservation.ExecuteNonQuery();

                        // Confirmar la transacción
                        transaction.Commit();

                        return true;
                    }
                    catch (Exception)
                    {
                        // Revertir la transacción en caso de error
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            catch (Exception)
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
