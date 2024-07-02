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
                
                String selectQuery = "SELECT * FROM HorarioSucursal";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable ScheduleDataTable = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                adp.SelectCommand = cmd;

                adp.Fill(ScheduleDataTable);

                foreach (DataRow row in ScheduleDataTable.Rows)
                {
                    schedules.Add(
                        new Schedule(
                    Convert.ToInt32(row["Identificacion"]),
                    new Branch_Controller().get(Convert.ToInt32(row["IdentificacionSucursal"])),
                    row["Titulo"].ToString(),
                    TimeSpan.Parse( row["HorarioInicio"].ToString()),
                    TimeSpan.Parse(row["HorarioSalida"].ToString()),
                    Convert.ToInt32(row["TiempoCita"])
                   )) ;
                }
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
                String selectQuery = "SELECT * FROM HorarioSucursal WHERE Identificacion = @id";
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
                    TimeSpan.Parse(row["HorarioInicio"].ToString()),
                    TimeSpan.Parse(row["HorarioSalida"].ToString()),
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
                    query = "INSERT INTO HorarioSucursal (IdentificacionSucursal, Titulo, HorarioInicio, HorarioSalida, TiempoCita) VALUES (@branchID, @title, @start, @end, @appointmentTime)";
                }
                else
                {
                    query = "UPDATE HorarioSucursal SET IdentificacionSucursal = @branchID, Titulo = @title, HorarioInicio = @start, HorarioSalida = @end, TiempoCita = @appointmentTime WHERE Identificacion = @Id";
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
