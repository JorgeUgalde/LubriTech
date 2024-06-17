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
    public class Client_Model
    {

        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

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
                    clients.Add(new Client(dr["Identificacion"].ToString(), dr["NombreCompleto"].ToString(), 
                        Convert.ToInt32(dr["NumeroTelefonoPrincipal"]), Convert.ToInt32(dr["NumeroTelefonoAdicional"]), 
                        dr["CorreoElectronico"].ToString(), dr["Direccion"].ToString(), (getVehicle((string)dr["Identificacion"])),
                        dr["Estado"].ToString() ));
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
        }//End of loadAllClients

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
        }//End of GetVehicle

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

                Client client = new Client(dr["Identificacion"].ToString(), dr["NombreCompleto"].ToString(),
                                           Convert.ToInt32(dr["NumeroTelefonoPrincipal"]), Convert.ToInt32(dr["NumeroTelefonoAdicional"]),
                                           dr["CorreoElectronico"].ToString(), dr["Direccion"].ToString(), dr["Estado"].ToString());

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

        public Boolean UpSertClient(Client client)
        {
            try
            {
                var existingClient = getClient(client.Id);
                if (existingClient != null)
                {
                    MessageBox.Show("El Cliente se ha modificado correctamente");

                    return updateClient(client);


                }
                else
                {
                    MessageBox.Show("El Cliente se ha modificado correctamente");

                    return addClient(client);

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean addClient(Client client)
        {
            try
            {
                String insertQuery = "insert into Cliente(Identificacion, NombreCompleto, NumeroTelefonoPrincipal, NumeroTelefonoAdicional, CorreoElectronico, Direccion, Estado) values (@id, @fullname, @mainphone, @additionalphone, @email, @addresse, @state)";

                SqlCommand insert = new SqlCommand(insertQuery, conn);

                insert.Parameters.AddWithValue("@id", client.Id);
                insert.Parameters.AddWithValue("@fullname", client.FullName);
                insert.Parameters.AddWithValue("@mainphone", client.MainPhoneNum);
                insert.Parameters.AddWithValue("@additionalphone", client.AdditionalPhoneNum);
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
        }//End of SaveClient

        public Boolean updateClient(Client client)
        {
            try
            {
                String updateQuery = "update Cliente set NombreCompleto = @fullname, NumeroTelefonoPrincipal = @mainphone, NumeroTelefonoAdicional = @additionalphone, CorreoElectronico = @email, Direccion = @address where [Cliente].Identificacion = @id";

                SqlCommand update = new SqlCommand(updateQuery, conn);

                update.Parameters.AddWithValue("@id", client.Id);
                update.Parameters.AddWithValue("@fullname", client.FullName);
                update.Parameters.AddWithValue("@mainphone", client.MainPhoneNum);
                update.Parameters.AddWithValue("@additionalphone", client.AdditionalPhoneNum);
                update.Parameters.AddWithValue("@email", client.Email);
                update.Parameters.AddWithValue("@address", client.Address);

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
        }//End of UpdateClient

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
