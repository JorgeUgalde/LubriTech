using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.Model.Appointment_Information
{
    /// <summary>
    /// This class control the appointments data access.
    /// </summary>
    public class Appointment_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);


        /// <summary>
        /// Load all the appointments from the database.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>List of Appointment objects of the date specified</returns>
        public List<Appointment> loadDayAppointments(DateTime date)
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM Cita WHERE CAST(FechaHora AS DATE) = @date and Estado = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@date", date);
                DataTable tblAppointments = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(tblAppointments);

                foreach (DataRow row in tblAppointments.Rows)
                {
                    appointments.Add(new Appointment
                    (
                        Convert.ToInt32(row["Identificacion"]),
                        new Client_Model().getClient(row["IdentificacionCliente"].ToString()),
                        Convert.ToDateTime(row["FechaHora"]),
                        Convert.ToInt16(row["Estado"]),
                        new Branch_Model().GetBranch(Convert.ToInt32(row["IdentificacionSucursal"].ToString())))
                    );            
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las citas");
                throw ex;
            }
            finally { conn.Close(); }
            return appointments;

        }

        /// <summary>
        /// Search for an specific appointment in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> return an appointment  </returns>
        public Appointment GetAppointment(int id)
        {
            Appointment appointment = null;
            try
            {
                conn.Open();

                string query = "SELECT * FROM Cita WHERE Identificacion = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                DataTable tblAppointments = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(tblAppointments);

                foreach (DataRow row in tblAppointments.Rows)
                {
                    new Appointment
                    (
                        Convert.ToInt32(row["Identificacion"]),
                        new Client_Model().getClient(row["IdentificacionCliente"].ToString()),
                        Convert.ToDateTime(row["FechaHora"]),
                        Convert.ToInt16(row["Estado"]),
                        new Branch_Model().GetBranch(Convert.ToInt32(row["IdentificacionSucursal"].ToString()))
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la cita");
                throw ex;
            }
            finally { conn.Close(); }
            return appointment;
        }


        /// <summary>
        ///  insert or update an appointment in the database.
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns> returns true if the action executed succesfully, or false if the action was unsuccessfull </returns>
        public bool UpSertAppointment(Appointment appointment)
        {
            try
            {
                string query = "INSERT INTO Cita (IdentificacionCliente, FechaHora, Estado, IdentificacionSucursal) VALUES ( @client, @date, @state, @branch)";
                if (GetAppointment(appointment.AppointmentID) != null)
                {
                    query = "UPDATE Cita SET IdentificacionCliente = @client, FechaHora = @date, Estado = @state, IdentificacionSucursal = @branch WHERE Identificacion = @id";
                }

                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", appointment.AppointmentID);
                cmd.Parameters.AddWithValue("@client", appointment.client.Id);
                cmd.Parameters.AddWithValue("@date", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@state", appointment.State);
                cmd.Parameters.AddWithValue("@branch", appointment.branch.Id);

                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la cita");
                throw ex;
            }
            finally { conn.Close(); }
        }


        /// <summary>
        /// Cancel an appointment in the database.
        /// </summary>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        public bool CancelAppointment(int appointmentID)
        {
            try
            {
                conn.Open();
                string query = "UPDATE Cita SET Estado = 0 WHERE Identificacion = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", appointmentID);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar la cita");
                throw ex;
            }
            finally { conn.Close(); }
        }
    }

}
