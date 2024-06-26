using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.WorkOrder_Information
{
    public class ObservationPhotos_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        public List<ObservationPhotos> LoadObservationPhotos(int observationId)
        {
            List<ObservationPhotos> photos = new List<ObservationPhotos>();
            string selectQuery = "SELECT Identificacion, CodigoObservacion, Fotografia FROM ObservationPhotos WHERE CodigoObservacion = @observationId";

            SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@observationId", observationId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ObservationPhotos photo = new ObservationPhotos
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Identificacion")),
                                ObservationId = reader.GetInt32(reader.GetOrdinal("CodigoObservacion")),
                                Photo = reader.IsDBNull(reader.GetOrdinal("Fotografia")) ? null : (byte[])reader["Photo"]
                            };

                            photos.Add(photo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error loading observation photos: {ex.Message}");
                // Optionally rethrow or handle it as needed
                // throw;
                return null;
            }
            finally
            {
                conn.Close();
            }

            return photos;
        }

        public byte[] ConvertImageToByteArray(string imagePath)
        {
            byte[] imageArray = null;
            try
            {
                imageArray = System.IO.File.ReadAllBytes(imagePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting image to byte array: {ex.Message}");
            }
            return imageArray;
        }

        public void UpsertObservationPhoto(int observationId, string imagePath)
        {
            byte[] imageBytes = ConvertImageToByteArray(imagePath);

            if (imageBytes == null)
            {
                Console.WriteLine("Image conversion failed. Upsert operation aborted.");
                return;
            }

            string upsertQuery = @"
            MERGE INTO FotosObservacion AS target
            USING (SELECT @ObservationId AS ObservationId, @Foto AS Foto) AS source
            ON (target.ObservationId = source.ObservationId)
            WHEN MATCHED THEN 
                UPDATE SET Foto = source.Foto
            WHEN NOT MATCHED THEN
                INSERT (ObservationId, Foto)
                VALUES (source.ObservationId, source.Foto);";

            SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(upsertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ObservationId", observationId);
                    cmd.Parameters.AddWithValue("@Foto", imageBytes);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Image upserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Upsert operation failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error upserting image into database: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteObservationPhoto(int observationId)
        {
            string deleteQuery = "DELETE FROM FotosObservacion WHERE ObservationId = @ObservationId";

            SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ObservationId", observationId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Image deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Delete operation failed. No image found with the given ObservationId.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting image from database: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
