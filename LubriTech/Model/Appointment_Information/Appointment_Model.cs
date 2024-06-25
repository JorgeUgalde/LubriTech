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
    /// Clase que maneja las operaciones relacionadas con la entidad <see cref="Appointment"/> en la base de datos.
    /// </summary>
    public class Appointment_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);


        /// <summary>
        /// Carga todas las citas de un día específico.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Lista de objetos Cita cargados desde la base de datos</returns>
        public List<Appointment> loadDayAppointments(DateTime date)
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM Cita WHERE CAST(FechaHora AS DATE) = @date and Estado = 1";

                //string query = "SELECT * FROM Cita WHERE FechaHora = @date";
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
                        new Branch_Model().GetBranch(Convert.ToInt32(row["IdentificacionSucursal"].ToString())) )
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
        /// Busca una cita en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retorna una cita  </returns>
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
        ///  Inserta o actualiza una cita en la base de datos
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns> Retorna un verdadero si la accion se completo con exito, o falso si no se completo con exito</returns>
        public bool UpSert(Appointment appointment)
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
