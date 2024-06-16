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
using LubriTech.Model.Product_Information;

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
                        dr["CorreoElectronico"].ToString(), dr["CorreoElectronico"].ToString(), (getVehicle((string)dr["Identificacion"])),
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
                    vehicles.Add(new Vehicle(dr["Placa"].ToString(), dr["TipoMotor"].ToString(), Convert.ToInt32(dr["Kilometraje"]), dr["Marca"].ToString(), dr["Modelo"].ToString(), Convert.ToInt32(dr["Anio"]), dr["Transmision"].ToString(), (getClient((string)dr["IdentificacionCliente"]))));
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
                    MessageBox.Show("El Cliente se ha agregado correctamente");
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
                insert.Parameters.AddWithValue("@mainphone", client.FullName);
                insert.Parameters.AddWithValue("@additionalphone", client.FullName);
                insert.Parameters.AddWithValue("@email", client.FullName);
                insert.Parameters.AddWithValue("@addresse", client.FullName);
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
                String updateQuery = "update Cliente set NombreCompleto = @fullname, NumeroTelefonoPrincipal = @mainphone, NumeroTelefonoAdicional = @additionalphone, CorreoElectronico = @email, Direccion = @addresse where [Cliente].Identificacion = @id";

                SqlCommand update = new SqlCommand(updateQuery, conn);

                update.Parameters.AddWithValue("@id", client.Id);
                update.Parameters.AddWithValue("@fullname", client.FullName);
                update.Parameters.AddWithValue("@mainphone", client.MainPhoneNum);
                update.Parameters.AddWithValue("@additionalphone", client.AdditionalPhoneNum);
                update.Parameters.AddWithValue("@email", client.Email);
                update.Parameters.AddWithValue("@addresse", client.Address);

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
                string deleteQuery = "delete from Cliente where [Cliente].Identificacion = @id";
                SqlCommand delete = new SqlCommand(deleteQuery, conn);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                delete.Parameters.AddWithValue("@id", clientId);
                delete.ExecuteNonQuery();
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
        }//End of DeleteClient
    }
}
