using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Product_Information;
using LubriTech.Model.Supplier_Information;

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
                    vehicles.Add(new Vehicle(dr["Placa"].ToString(),
                                                dr["TipoMotor"].ToString(),
                                                Convert.ToInt32(dr["Kilometraje"]),
                                                dr["Marca"].ToString(),
                                                dr["Modelo"].ToString(),
                                                Convert.ToInt32(dr["Anio"]),
                                                dr["Transmision"].ToString(),
                                                (getClient((string)dr["IdentificacionCliente"]))));
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

        public Client getClient(string ClientId)
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
                    client = new Client(dr["Identificacion"].ToString(),
                                        dr["NombreCompleto"].ToString(),
                                        Convert.ToInt32(dr["NumeroTelefonoPrincipal"]),
                                        Convert.ToInt32(dr["NumeroTelefonoAdicional"]),
                                        dr["CorreoElectronico"].ToString(),
                                        dr["Direccion"].ToString());
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

        public Boolean upsertVehicle(Vehicle vehicle)
        {
            try
            {
                if (getVehicle(vehicle.LicensePlate) != null)
                {
                    return updateVehicle(vehicle);
                }
                else
                {
                    return addVehicle(vehicle);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Vehicle getVehicle(string licensePlate)
        {
            try
            {
                string selectQuery = "SELECT * FROM Vehiculo WHERE Placa = @licensePlate";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@licensePlate", licensePlate);

                DataTable tblVehicles = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;

                adp.Fill(tblVehicles);
                DataRow dr = tblVehicles.Rows[0];

                Vehicle vehicle = new Vehicle(dr["Placa"].ToString(),
                                                dr["TipoMotor"].ToString(),
                                                Convert.ToInt32(dr["Kilometraje"].ToString()),
                                                dr["Marca"].ToString(),
                                                dr["Modelo"].ToString(),
                                                Convert.ToInt32(dr["Anio"].ToString()),
                                                dr["Transmision"].ToString(),
                                                (getClient((string)dr["IdentificacionCliente"])));

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return vehicle;
            }
            catch (Exception ex)
            {
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

        public Boolean updateVehicle(Vehicle vehicle)
        {
            try
            {
                string updateQuery = "UPDATE Vehiculo SET Placa = @licensePlate, TipoMotor = @engine, Kilometraje = @mileage, Marca = @brand, Modelo = @model, Anio = @year, Transmision = @transmission, IdentificacionCliente = @clientId WHERE Placa = @licensePlate";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@licensePlate", vehicle.LicensePlate);
                cmd.Parameters.AddWithValue("@engine", vehicle.Engine);
                cmd.Parameters.AddWithValue("@mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@brand", vehicle.Brand);
                cmd.Parameters.AddWithValue("@model", vehicle.Model);
                cmd.Parameters.AddWithValue("@year", vehicle.Year);
                cmd.Parameters.AddWithValue("@transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@clientId", vehicle.getClientId());

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
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

        public Boolean addVehicle(Vehicle vehicle)
        {
            try
            {
                string query = "INSERT INTO Vehiculo VALUES (@licensePlate, @engine, @mileage, @brand, @model, @year, @transmission, @clientId)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@licensePlate", vehicle.LicensePlate);
                cmd.Parameters.AddWithValue("@engine", vehicle.Engine);
                cmd.Parameters.AddWithValue("@mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@brand", vehicle.Brand);
                cmd.Parameters.AddWithValue("@model", vehicle.Model);
                cmd.Parameters.AddWithValue("@year", vehicle.Year);
                cmd.Parameters.AddWithValue("@transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@clientId", vehicle.getClientId());


                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

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

        public Boolean deleteVehicle(string licensePlate)
        {
            try
            {
                string deleteQuery = "DELETE FROM Vehiculo WHERE Placa = @licensePlate";
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@licensePlate", licensePlate);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
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

