using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Supplier_Information;

namespace LubriTech.Model.Vehicle_Information
{
    /// <summary>
    /// Clase que maneja las operaciones de la base de datos relacionadas con la entidad <see cref="Vehicle"/>.
    /// </summary>
    public class Vehicle_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        /// <summary>
        /// Carga todos los vehículos desde la base de datos.
        /// </summary>
        /// <returns>Una lista de vehículos.</returns>

        public List<Vehicle> loadAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            Dictionary<int, Engine> engines = new Engine_Controller().getAll().ToDictionary(e => e.Id, e => e);

            Dictionary<int, CarModel> carModels = new CarModel_Controller().getAll().ToDictionary(m => m.Id, m => m);

            Dictionary<int, Transmission> transmissions = new Transmission_Controller().getAll().ToDictionary(t => t.Id, t => t);

            Dictionary<string, Client> clients = new Clients_Controller().getAll().ToDictionary(c => c.Id, c => c);

            try
            {

                // Cargar todos los vehículos
                string selectQuery = "SELECT * FROM Vehiculo";
                DataTable tblVehicles = new DataTable();
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(tblVehicles);
                }

                // Procesar los datos de vehículos
                foreach (DataRow dr in tblVehicles.Rows)
                {
                    int engineId = Convert.ToInt32(dr["IdentificacionMotor"]);
                    int modelId = Convert.ToInt32(dr["IdentificacionModelo"]);
                    int transmissionId = Convert.ToInt32(dr["IdentificacionTransmision"]);
                    string clientId = dr["IdentificacionCliente"].ToString();

                    vehicles.Add(new Vehicle(
                        dr["Placa"].ToString(),
                        engines.ContainsKey(engineId) ? engines[engineId] : null,
                        Convert.ToInt32(dr["Kilometraje"]),
                        carModels.ContainsKey(modelId) ? carModels[modelId] : null,
                        Convert.ToInt32(dr["Anio"]),
                        transmissions.ContainsKey(transmissionId) ? transmissions[transmissionId] : null,
                        clients.ContainsKey(clientId) ? clients[clientId] : null,
                        (Convert.ToInt32(dr["Estado"]) == 1) ? "Activo" : "Inactivo"));
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
                //verify if conn is close
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }




        /// <summary>
        /// Actualiza o inserta un vehículo en la base de datos.
        /// </summary>
        /// <param name="vehicle">El vehículo a actualizar o insertar.</param>
        /// <returns>true si la operación fue exitosa; false en caso contrario.</returns>
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

        /// <summary>
        /// Obtiene un vehículo de la base de datos por su placa.
        /// </summary>
        /// <param name="licensePlate">La placa del vehículo.</param>
        /// <returns>El vehículo correspondiente.</returns>
        public Vehicle getVehicle(string licensePlate)
        {
            try
            {
                if(licensePlate is null)
                {
                    return null;
                }
                string selectQuery = "SELECT * FROM Vehiculo WHERE Placa = @licensePlate";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@licensePlate", licensePlate);

                DataTable tblVehicles = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;

                adp.Fill(tblVehicles);
                DataRow dr = tblVehicles.Rows[0];

                Vehicle vehicle = new Vehicle(dr["Placa"].ToString(),
                                                (new Engine_Controller().getEngine(Convert.ToInt32(dr["IdentificacionMotor"].ToString()))),
                                                Convert.ToInt32(dr["Kilometraje"]),
                                                (new CarModel_Controller().getModel (Convert.ToInt32(dr["IdentificacionModelo"]))),
                                                Convert.ToInt32(dr["Anio"]),
                                                (new Transmission_Controller().getTransmission(Convert.ToInt32(dr["IdentificacionTransmision"].ToString()))),
                                                (new Clients_Controller().getClient((string)dr["IdentificacionCliente"])),
                                                (Convert.ToInt32(dr["Estado"]) == 1) ? "Activo" : "Inactivo");

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

        /// <summary>
        /// Actualiza un vehículo en la base de datos.
        /// </summary>
        /// <param name="vehicle">El vehículo a actualizar.</param>
        /// <returns>true si la operación fue exitosa; false en caso contrario.</returns>
        public Boolean updateVehicle(Vehicle vehicle)
        {
            try
            {
                string updateQuery = "UPDATE Vehiculo SET Placa = @licensePlate, IdentificacionMotor = @engineId, Kilometraje = @mileage, IdentificacionModelo = @modelId, Anio = @year, IdentificacionTransmision = @transmissionId, IdentificacionCliente = @clientId, Estado = @state WHERE Placa = @licensePlate";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@licensePlate", vehicle.LicensePlate);
                cmd.Parameters.AddWithValue("@engineId", vehicle.getEnginelId());
                cmd.Parameters.AddWithValue("@mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@modelId", vehicle.getModelId());
                cmd.Parameters.AddWithValue("@year", vehicle.Year);
                cmd.Parameters.AddWithValue("@transmissionId", vehicle.getTransmissionId());
                cmd.Parameters.AddWithValue("@clientId", vehicle.getClientId());
                cmd.Parameters.AddWithValue("@state", (vehicle.State.Equals("Activo")) ? 1 : 0);

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

        /// <summary>
        /// Agrega un vehículo a la base de datos.
        /// </summary>
        /// <param name="vehicle">Objeto Vehicle a agregar.</param>
        /// <returns>true si la operación fue exitosa, false si hubo un error.</returns>
        public Boolean addVehicle(Vehicle vehicle)
        {
            try
            {
                string query = "INSERT INTO Vehiculo (Placa, IdentificacionMotor, Kilometraje, IdentificacionModelo, Anio, IdentificacionTransmision, IdentificacionCliente, Estado) VALUES (@licensePlate, @engineId, @mileage, @modelId, @year, @transmissionId, @clientId, @state)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@licensePlate", vehicle.LicensePlate);
                cmd.Parameters.AddWithValue("@engineId", vehicle.getEnginelId());
                cmd.Parameters.AddWithValue("@mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@modelId", vehicle.getModelId());
                cmd.Parameters.AddWithValue("@year", vehicle.Year);
                cmd.Parameters.AddWithValue("@transmissionId", vehicle.getTransmissionId());
                cmd.Parameters.AddWithValue("@clientId", vehicle.getClientId());
                cmd.Parameters.AddWithValue("@state", (vehicle.State.Equals("Activo")) ? 1 : 0);


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

        public List<Vehicle> getVehiclesByClient(string clientId)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM Vehiculo where IdentificacionCliente = @clientId";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable tblVehicles = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                cmd.Parameters.AddWithValue("@clientId",clientId);

                adp.SelectCommand = cmd;

                adp.Fill(tblVehicles);

                foreach (DataRow dr in tblVehicles.Rows)
                {
                    vehicles.Add(new Vehicle(dr["Placa"].ToString(),
                                                (new Engine_Controller().getEngine(Convert.ToInt32(dr["IdentificacionMotor"].ToString()))),
                                                Convert.ToInt32(dr["Kilometraje"]),
                                                (new CarModel_Controller().getModel(Convert.ToInt32(dr["IdentificacionModelo"]))),
                                                Convert.ToInt32(dr["Anio"]),
                                                (new Transmission_Controller().getTransmission(Convert.ToInt32(dr["IdentificacionTransmision"].ToString()))),
                                                (new Clients_Controller().getClient((string)dr["IdentificacionCliente"])),
                                                (Convert.ToInt32(dr["Estado"]) == 1) ? "Activo" : "Inactivo"));
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

        public Vehicle getVehicleByClientId(string licensePlate, string clientId)
        {
            Vehicle vehicle = null;

            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM Vehiculo where Placa = @licensePlate and IdentificacionCliente = @clientId";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable tblVehicles = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                cmd.Parameters.AddWithValue("@licensePlate", licensePlate);
                cmd.Parameters.AddWithValue("@clientId", clientId);

                adp.SelectCommand = cmd;

                adp.Fill(tblVehicles);

                if(tblVehicles.Rows.Count == 0)
                {
                    return null;
                }

                DataRow dr = tblVehicles.Rows[0];

                vehicle = new Vehicle(dr["Placa"].ToString(),
                (new Engine_Controller().getEngine(Convert.ToInt32(dr["IdentificacionMotor"].ToString()))),
                Convert.ToInt32(dr["Kilometraje"]),
                (new CarModel_Controller().getModel(Convert.ToInt32(dr["IdentificacionModelo"]))),
                Convert.ToInt32(dr["Anio"]),
                (new Transmission_Controller().getTransmission(Convert.ToInt32(dr["IdentificacionTransmision"].ToString()))),
                (new Clients_Controller().getClient((string)dr["IdentificacionCliente"])),
                (Convert.ToInt32(dr["Estado"]) == 1) ? "Activo" : "Inactivo");

                return vehicle;
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

