using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LubriTech.Model.Client_Information;

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
                DataTable tblVehicles = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(tblVehicles);

                foreach (DataRow dr in tblVehicles.Rows)
                {
                    vehicles.Add(new Vehicle(dr["Placa"].ToString(), dr["TipoMotor"].ToString(), Convert.ToDouble(dr["Kilometraje"]), dr["Marca"].ToString(), dr["Modelo"].ToString(), Convert.ToInt32(dr["Anio"]), dr["Transmision"].ToString(), (getClient((string)dr["IdentificacionCliente"]))));
                }
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

        private Client getClient(string ClientId)
        {
            try
            {
                String selectQueryClients = "SELECT * FROM Cliente WHERE Cliente.Identificacion = @identificacion;";
                SqlCommand select = new SqlCommand(selectQueryClients, conn);
                select.Parameters.AddWithValue("@identificacion", ClientId);

                DataTable tblClients = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = select;

                adp.Fill(tblClients);
                Client client = null;

                foreach (DataRow dr in tblClients.Rows)
                {
                    client = new Client(dr["Identificacion"].ToString(), dr["NombreCompleto"].ToString(), Convert.ToInt32(dr["NumeroTelefonoPrincipal"]), Convert.ToInt32(dr["NumeroTelefonoAdicional"]), dr["CorreoElectronico"].ToString(), dr["Direccion"].ToString());
                }

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();

                }

                select.ExecuteNonQuery();

                return client;
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

        public Boolean addVehicle(string LicensePlate, string Engine, double Mileage, string Brand, string Model, int Year, string Transmission, string ClientId)
        {
            try
            {
                string query = "INSERT INTO Vehiculo VALUES (@licensePlate, @engine, @mileage, @brand, @model, @year, @transmission, @clientId)";
                SqlCommand insert = new SqlCommand(query, conn);

                insert.Parameters.AddWithValue("@licensePlate", LicensePlate);
                insert.Parameters.AddWithValue("@engine", Engine);
                insert.Parameters.AddWithValue("@mileage", Mileage);
                insert.Parameters.AddWithValue("@brand", Brand);
                insert.Parameters.AddWithValue("@model", Model);
                insert.Parameters.AddWithValue("@year", Year);
                insert.Parameters.AddWithValue("@transmission", Transmission);
                insert.Parameters.AddWithValue("@clientId", ClientId);


                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                insert.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
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
