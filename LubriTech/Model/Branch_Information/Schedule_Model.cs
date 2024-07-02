using LubriTech.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Branch_Information
{
    public class Schedule_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        public List<Schedule> loadAllSchedules()
        {
            try
            {
                List<Schedule> schedules = new List<Schedule>();
                
                String selectQuery = "SELECT * FROM Schedule";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable ScheduleDataTable = new DataTable();
                SqlDataAdapter ScheduleDataAdapter = new SqlDataAdapter(cmd);

                ScheduleDataAdapter.Fill(ScheduleDataTable);

                foreach (DataRow row in ScheduleDataTable.Rows)
                {
                    schedules.Add(
                        new Schedule(
                    Convert.ToInt32(row["Identificacion"]),
                    new Branch_Controller().get(Convert.ToInt32(row["IdentificacionSucursal"])),
                    row["Titulo"].ToString(),
                    Convert.ToInt32(row["HoraInicio"]),
                    Convert.ToInt32(row["HoraSalida"]),
                    Convert.ToInt32(row["TiempoCita"])
                   ));
                }
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();


                return schedules;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public Schedule getSchedule(int id)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                String selectQuery = "SELECT * FROM Schedule WHERE Identificacion = @id";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                DataTable scheduleDataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(scheduleDataTable);

                if (scheduleDataTable.Rows.Count == 0)
                {
                    return null;
                }
                DataRow row = scheduleDataTable.Rows[0];
                return new Schedule(
                    Convert.ToInt32(row["Identificacion"]),
                    new Branch_Controller().get(Convert.ToInt32(row["IdentificacionSucursal"])),
                    row["Titulo"].ToString(),
                    Convert.ToInt32(row["HoraInicio"]),
                    Convert.ToInt32(row["HoraSalida"]),
                    Convert.ToInt32(row["TiempoCita"])
                    );

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }            
        }

        // Update or insert a schedule
        public bool Upsert(Schedule schedule)
        {
            try
            {
                string query = "";
                if (getSchedule(schedule.ScheduleID) == null)
                {
                    query = "INSERT INTO Schedule (IdentificacionSucursal, Titulo, HoraInicio, HoraSalida, TiempoCita) VALUES (@branchID, @title, @start, @end, @appointmentTime)";
                }
                else
                {
                    query = "UPDATE Schedule SET IdentificacionSucursal = @branchID, Titulo = @title, HoraInicio = @start, HoraSalida = @end, TiempoCita = @appointmentTime WHERE Identificacion = @Id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", schedule.ScheduleID);
                cmd.Parameters.AddWithValue("@branchID", schedule.Branch.Id);
                cmd.Parameters.AddWithValue("@title", schedule.Title);
                cmd.Parameters.AddWithValue("@start", schedule.StartHour);
                cmd.Parameters.AddWithValue("@end", schedule.EndHour);
                cmd.Parameters.AddWithValue("@appointmentTime", schedule.appointmentDuration);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
