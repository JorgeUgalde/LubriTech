using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.Model.Client_Information
{
    public class Client_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);
        public List<Client> loadAllClients()
        {
            List<Client> client = new List<Client>();

            try
            {
                conn.Open();
                String selectQuery = "select * from Cliente";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    client.Add(new Client(reader["Identificacion"].ToString(), reader["NombreCompleto"].ToString(), (int)reader["NumeroTelefonoPrincipal"], (int)reader["NumeroTelefonoAdicional"], reader["CorreoElectronico"].ToString(), reader["Direccion"].ToString()));
                }

                return client;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }

            finally { conn.Close(); }

        }//End of loadAllClients

    }
}
