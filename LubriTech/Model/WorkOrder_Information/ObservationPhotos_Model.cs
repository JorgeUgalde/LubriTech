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
            string selectQuery = "SELECT Identificacion, CodigoObservacion, Fotografia FROM FotosObservacion WHERE CodigoObservacion = @observationId";

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
                                Photo = reader.IsDBNull(reader.GetOrdinal("Fotografia")) ? null : (byte[])reader["Fotografia"]
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

        public void UpsertObservationPhoto(int observationId, byte[] imageBytes)
        {
            

            if (imageBytes == null)
            {
                Console.WriteLine("Image conversion failed. Upsert operation aborted.");
                return;
            }

            string query = "INSERT INTO FotosObservacion (CodigoObservacion ,Fotografia) VALUES (@ObservationId ,@Photo)";


            SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ObservationId", 6);
                    cmd.Parameters.AddWithValue("@Photo", imageBytes);

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

        public void DeleteObservationPhoto(int Id)
        {
            string deleteQuery = "DELETE FROM FotosObservacion WHERE Identificacion = @Id";

            SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

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
