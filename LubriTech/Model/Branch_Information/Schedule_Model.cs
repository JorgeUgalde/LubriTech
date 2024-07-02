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

        public List<Schedule> loadAllSchedules(int? branch)
        {
            try
            {
                String selectQuery = "SELECT * FROM HorarioSucursal";

                if (branch != null) { 
                selectQuery = "SELECT * FROM HorarioSucursal WHERE IdentificacionSucursal = @branch";
                }

                List<Schedule> schedules = new List<Schedule>();
                
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                if (branch != null)
                {
                    cmd.Parameters.AddWithValue("@branch", branch);

                }

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
                    Convert.ToInt32(row["TiempoCita"]),
                    row["Estado"].ToString() == "1" ? "Activo" : "Inactivo"
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

        public Schedule getSchedule(int id, int? branchID)
        {
            try
            {
                string selectQuery = "SELECT * FROM HorarioSucursal WHERE Identificacion = @id";

                if (branchID != null)
                {
                    selectQuery = "SELECT * FROM HorarioSucursal WHERE IdentificacionSucursal = @branchID and Estado = @state";
                }



                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable scheduleDataTable = new DataTable();


                if (branchID != null)
                {
                    cmd.Parameters.AddWithValue("@state", 1);
                    cmd.Parameters.AddWithValue("@branchID", branchID);
                }
                else
                    cmd.Parameters.AddWithValue("@id", id);


                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
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
                    Convert.ToInt32(row["TiempoCita"]),
                    row["Estado"].ToString() == "1" ? "Activo" : "Inactivo"
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
                if (getSchedule(schedule.ScheduleID, null) == null)
                {
                    query = "INSERT INTO HorarioSucursal (IdentificacionSucursal, Titulo, HorarioInicio, HorarioSalida, TiempoCita, Estado) VALUES (@branchID, @title, @start, @end, @appointmentTime, @state)";
                }
                else
                {
                    query = "UPDATE HorarioSucursal SET IdentificacionSucursal = @branchID, Titulo = @title, HorarioInicio = @start, HorarioSalida = @end, TiempoCita = @appointmentTime, Estado = @state WHERE Identificacion = @Id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", schedule.ScheduleID);
                cmd.Parameters.AddWithValue("@branchID", schedule.Branch.Id);
                cmd.Parameters.AddWithValue("@title", schedule.Title);
                cmd.Parameters.AddWithValue("@start", schedule.StartHour);
                cmd.Parameters.AddWithValue("@end", schedule.EndHour);
                cmd.Parameters.AddWithValue("@appointmentTime", schedule.appointmentDuration);
                cmd.Parameters.AddWithValue("@state", schedule.State == "Activo" ? 1 : 0);

                // change all the schedules to inactive before inserting the new one, only if the schedule is active
                if (schedule.State == "Activo")
                {
                    setScheduleInactive(schedule.Branch.Id);
                }


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

        public void setScheduleInactive(int branchId)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("UPDATE HorarioSucursal SET Estado = 0 WHERE IdentificacionSucursal = @branchID", conn);
                cmd.Parameters.AddWithValue("@branchID", branchId);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
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
