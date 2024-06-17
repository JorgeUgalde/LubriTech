﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                                                (getModel(Convert.ToInt32(dr["IdentificacionModelo"]))),
                                                Convert.ToInt32(dr["Anio"]),
                                                dr["Transmision"].ToString(),
                                                (getClient((string)dr["IdentificacionCliente"])),
                                                dr["Estado"].ToString()));
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

        /// <summary>
        /// Obtiene un cliente de la base de datos.
        /// </summary>
        /// <param name="ClientId">Identificación del cliente.</param>
        /// <returns>El cliente correspondiente.</returns>
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
                                        dr["Direccion"].ToString(),
                                        dr["Estado"].ToString());
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

        /// <summary>
        /// Obtiene un modelo de vehículo de la base de datos.
        /// </summary>
        /// <param name="ModelId">Identificación del modelo.</param>
        /// <returns>El modelo de vehículo correspondiente.</returns>
        public CarModel getModel(int ModelId)
        {
            try
            {
                String selectQueryModels = "SELECT * FROM CatalogoModelo WHERE CatalogoModelo.Identificacion = @identificacion;";
                SqlCommand select = new SqlCommand(selectQueryModels, conn);
                select.Parameters.AddWithValue("@identificacion", ModelId);

                DataTable tblModelCatalog = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = select;

                adp.Fill(tblModelCatalog);
                CarModel model = null;

                foreach (DataRow dr in tblModelCatalog.Rows)
                {
                    model = new CarModel(Convert.ToInt32(dr["Identificacion"]),
                                        dr["Nombre"].ToString(),
                                        (getMake(Convert.ToInt32(dr["IdentificacionMarca"]))),
                                        dr["Estado"].ToString());
                }

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();

                }

                select.ExecuteNonQuery();

                return model;
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

        /// <summary>
        /// Obtiene una marca de vehículo de la base de datos.
        /// </summary>
        /// <param name="MakeId">Identificación de la marca.</param>
        /// <returns>La marca de vehículo correspondiente.</returns>
        public Make getMake(int MakeId)
        {
            try
            {
                String selectQueryMakes = "SELECT * FROM CatalogoMarca WHERE CatalogoMarca.Identificacion = @identificacion;";
                SqlCommand select = new SqlCommand(selectQueryMakes, conn);
                select.Parameters.AddWithValue("@identificacion", MakeId);

                DataTable tblMakeCatalog = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = select;

                adp.Fill(tblMakeCatalog);
                Make make = null;

                foreach (DataRow dr in tblMakeCatalog.Rows)
                {
                    make = new Make(Convert.ToInt32(dr["Identificacion"]),
                                        dr["Nombre"].ToString(),
                                        dr["Estado"].ToString());
                }

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();

                }

                select.ExecuteNonQuery();

                return make;
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
                                                Convert.ToInt32(dr["Kilometraje"]),
                                                (getModel(Convert.ToInt32(dr["IdentificacionModelo"]))),
                                                Convert.ToInt32(dr["Anio"]),
                                                dr["Transmision"].ToString(),
                                                (getClient((string)dr["IdentificacionCliente"])),
                                                dr["Estado"].ToString());

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
                string updateQuery = "UPDATE Vehiculo SET Placa = @licensePlate, TipoMotor = @engine, Kilometraje = @mileage, IdentificacionModelo = @modelId, Anio = @year, Transmision = @transmission, IdentificacionCliente = @clientId WHERE Placa = @licensePlate";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@licensePlate", vehicle.LicensePlate);
                cmd.Parameters.AddWithValue("@engine", vehicle.Engine);
                cmd.Parameters.AddWithValue("@mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@modelId", vehicle.getModelId());
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

        /// <summary>
        /// Agrega un vehículo a la base de datos.
        /// </summary>
        /// <param name="vehicle">Objeto Vehicle a agregar.</param>
        /// <returns>true si la operación fue exitosa, false si hubo un error.</returns>
        public Boolean addVehicle(Vehicle vehicle)
        {
            try
            {
                string query = "INSERT INTO Vehiculo VALUES (@licensePlate, @engine, @mileage, @model, @year, @transmission, @clientId)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@licensePlate", vehicle.LicensePlate);
                cmd.Parameters.AddWithValue("@engine", vehicle.Engine);
                cmd.Parameters.AddWithValue("@mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@modelId", vehicle.getModelId());
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
    }
}

