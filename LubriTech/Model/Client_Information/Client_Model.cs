using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LubriTech.Model.Vehicle_Information;
using System.Windows.Forms;
using System.IO;

namespace LubriTech.Model.Client_Information
{
    /// <summary>
    /// Clase que maneja las operaciones relacionadas con la entidad <see cref="Client"/> en la base de datos.
    /// </summary>
    public class Client_Model
    {

        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        /// <summary>
        /// Carga todos los clientes desde la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Cliente cargados desde la base de datos.</returns>
        public List<Client> loadAllClients()
        {
            

            try
            {
                List<Client> clients = new List<Client>();

                conn.Open();
                String selectQuery = "SELECT * FROM Cliente";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable tblClients = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(tblClients);

                foreach (DataRow dr in tblClients.Rows)
                {
                    clients.Add(new Client(
                dr["Identificacion"].ToString(),
                dr["NombreCompleto"].ToString(),
                dr["NumeroTelefonoPrincipal"] != DBNull.Value ? Convert.ToInt32(dr["NumeroTelefonoPrincipal"]) : (int?)null,
                dr["NumeroTelefonoAdicional"] != DBNull.Value ? Convert.ToInt32(dr["NumeroTelefonoAdicional"]) : (int?)null,
                dr["CorreoElectronico"].ToString(),
                dr["Direccion"].ToString(),
                getVehicle(dr["Identificacion"].ToString()),
                dr["Estado"].ToString()));
                }
                return clients;
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
        /// Obtiene todos los vehículos asociados a un cliente específico.
        /// </summary>
        /// <param name="ClientId">Identificador único del cliente.</param>
        /// <returns>Lista de vehículos asociados al cliente.</returns>
        public List<Vehicle> getVehicle(string ClientId)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            try
            {

                String selectQuery = "SELECT * FROM Vehiculo WHERE Vehiculo.IdentificacionCliente = @identificacion;";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@identificacion", ClientId);

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
        /// Obtiene un modelo de vehículo específico por su identificador.
        /// </summary>
        /// <param name="ModelId">Identificador del modelo de vehículo.</param>
        /// <returns>Objeto CarModel que representa el modelo de vehículo.</returns>
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
        /// Obtiene una marca de vehículo específica por su identificador.
        /// </summary>
        /// <param name="MakeId">Identificador de la marca de vehículo.</param>
        /// <returns>Objeto Make que representa la marca de vehículo.</returns>
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
        /// Obtiene un cliente específico por su identificador.
        /// </summary>
        /// <param name="Id">Identificador único del cliente.</param>
        /// <returns>Objeto Cliente correspondiente al identificador proporcionado.</returns>
        public Client getClient(string Id)
        {
            try
            {
                string selectQuery = "select * from Cliente where [Cliente].Identificacion = @Id";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@Id", Id);

                DataTable tblClients = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;

                adp.Fill(tblClients);
                DataRow dr = tblClients.Rows[0];

                Client client = new Client(
                dr["Identificacion"].ToString(),
                dr["NombreCompleto"].ToString(),
                dr["NumeroTelefonoPrincipal"] != DBNull.Value ? Convert.ToInt32(dr["NumeroTelefonoPrincipal"]) : (int?)null,
                dr["NumeroTelefonoAdicional"] != DBNull.Value ? Convert.ToInt32(dr["NumeroTelefonoAdicional"]) : (int?)null,
                dr["CorreoElectronico"].ToString(),
                dr["Direccion"].ToString(),
                getVehicle(dr["Identificacion"].ToString()),
                dr["Estado"].ToString());

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return client;
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
        /// Inserta o actualiza un cliente en la base de datos dependiendo de si ya existe o no.
        /// </summary>
        /// <param name="client">Objeto Cliente que se va a insertar o actualizar.</param>
        /// <returns>True si la operación de inserción o actualización fue exitosa, False si falló.</returns>
        public Boolean UpSertClient(Client client)
        {
            try
            {
                Client existingClient = new Client();
                 existingClient = getClient(client.Id);

                if (existingClient != null)
                {
                    bool updateResult = updateClient(client);

                    if (updateResult)
                    {
                        MessageBox.Show("El Cliente se ha modificado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el Cliente.");
                    }

                    return updateResult;
                }
                else
                {
                    bool addResult = addClient(client);

                    if (addResult)
                    {
                        MessageBox.Show("El Cliente se ha creado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear el Cliente.");
                    }

                    return addResult;
                }
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar el error para propósitos de depuración, por ejemplo:
                Console.WriteLine($"Error en UpSertClient: {ex.Message}");
                MessageBox.Show("Ocurrió un error durante la operación.");
                return false;
            }
        }

        /// <summary>
        /// Inserta un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="client">Objeto Cliente que se va a insertar.</param>
        /// <returns>True si la operación de inserción fue exitosa, False si falló.</returns>
        public Boolean addClient(Client client)
        {
            try
            {
                String insertQuery = "insert into Cliente(Identificacion, NombreCompleto, NumeroTelefonoPrincipal, NumeroTelefonoAdicional, CorreoElectronico, Direccion, Estado) values (@id, @fullname, @mainphone, @additionalphone, @email, @addresse, @state)";

                SqlCommand insert = new SqlCommand(insertQuery, conn);

                insert.Parameters.AddWithValue("@id", client.Id);
                insert.Parameters.AddWithValue("@fullname", client.FullName);
                insert.Parameters.AddWithValue("@mainphone", (object)client.MainPhoneNum ?? DBNull.Value);
                insert.Parameters.AddWithValue("@additionalphone", (object)client.AdditionalPhoneNum ?? DBNull.Value);
                insert.Parameters.AddWithValue("@email", client.Email);
                insert.Parameters.AddWithValue("@addresse", client.Address);
                insert.Parameters.AddWithValue("@state", client.State);


                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                insert.ExecuteNonQuery();
                return true;

            }
            catch (SqlException ex)
            {

                throw ex;
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
        /// Actualiza la información de un cliente existente en la base de datos.
        /// </summary>
        /// <param name="client">Objeto Cliente con la información actualizada.</param>
        /// <returns>True si la operación de actualización fue exitosa, False si falló.</returns>
        public Boolean updateClient(Client client)
        {
            try
            {
                String updateQuery = "update Cliente set NombreCompleto = @fullname, NumeroTelefonoPrincipal = @mainphone, NumeroTelefonoAdicional = @additionalphone, CorreoElectronico = @email, Direccion = @address, Estado = @state where [Cliente].Identificacion = @id";

                SqlCommand update = new SqlCommand(updateQuery, conn);

                update.Parameters.AddWithValue("@id", client.Id);
                update.Parameters.AddWithValue("@fullname", client.FullName);
                update.Parameters.AddWithValue("@mainphone", (object)client.MainPhoneNum ?? DBNull.Value);
                update.Parameters.AddWithValue("@additionalphone", (object)client.AdditionalPhoneNum ?? DBNull.Value);
                update.Parameters.AddWithValue("@email", client.Email);
                update.Parameters.AddWithValue("@address", client.Address);
                update.Parameters.AddWithValue("@state", client.State);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                update.ExecuteNonQuery();
                return true;

            }
            catch (SqlException ex)
            {

                throw ex;
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
        /// Cambia el estado de activo a inactivo o viceversa de un cliente en la base de datos.
        /// </summary>
        /// <param name="clientId">Identificador único del cliente.</param>
        /// <returns>True si se cambió el estado correctamente, False si falló.</returns>
        public Boolean removeClient(string clientId)
        {
            try
            {
                
                string selectQuery = "select Estado from Cliente where Identificacion = @id";
                SqlCommand select = new SqlCommand(selectQuery, conn);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                select.Parameters.AddWithValue("@id", clientId);
                string currentState = select.ExecuteScalar()?.ToString();

                
                string newStatus = (currentState == "Activo") ? "Inactivo" : "Activo";

                
                string updateQuery = "update Cliente set Estado = @newStatus where Identificacion = @id";
                SqlCommand update = new SqlCommand(updateQuery, conn);

                update.Parameters.AddWithValue("@id", clientId);
                update.Parameters.AddWithValue("@newStatus", newStatus);
                update.ExecuteNonQuery(); 

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
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
