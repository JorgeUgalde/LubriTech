using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.Model.Vehicle_Information
{
    public class Vehicle_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        public List<Vehicle> loadAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM Vehiculo";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                //while (reader.Read())
                //{
                //    vehicles.Add(new Vehicle(reader["Placa"].ToString(), reader["TipoMotor"].ToString(), Convert.ToDouble(reader["Kilometraje"]), reader["Marca"].ToString(), reader["Modelo"].ToString(), Convert.ToInt32(reader["Anio"]), reader["Transmision"].ToString(), reader["IdentificacionCliente"].ToString()));
                //}
                return vehicles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
