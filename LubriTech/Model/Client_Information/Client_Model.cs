using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LubriTech.Model.Vehicle_Information;
using System.Windows.Forms;

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
                    clients.Add(new Client(dr["Identificacion"].ToString(), dr["NombreCompleto"].ToString(), Convert.ToInt32(dr["NumeroTelefonoPrincipal"]), Convert.ToInt32(dr["NumeroTelefonoAdicional"]), dr["CorreoElectronico"].ToString(), dr["CorreoElectronico"].ToString(), (GetVehicle((string)dr["Identificacion"]))));
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

        private Vehicle GetVehicle(string ClientId)
        {
            String selectQueryClients = "SELECT * FROM Vehiculo WHERE Vehiculo.IdentificacionCliente = @identificacion;";
            SqlCommand select = new SqlCommand(selectQueryClients, conn);
            select.Parameters.AddWithValue("@identificacion", ClientId);

            DataTable tblVehicles = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();

            adp.SelectCommand = select;

            adp.Fill(tblVehicles);
            Vehicle vehicles = null;

            foreach (DataRow dr in tblVehicles.Rows)
            {
                vehicles = new Vehicle(dr["Placa"].ToString(), dr["TipoMotor"].ToString(), Convert.ToDouble(dr["Kilometraje"]), dr["Marca"].ToString(), dr["Modelo"].ToString(), Convert.ToInt32(dr["Anio"]), dr["Transmision"].ToString());
            }

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();

            }

            select.ExecuteNonQuery();

            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }

            return vehicles;
        }
    }
}
