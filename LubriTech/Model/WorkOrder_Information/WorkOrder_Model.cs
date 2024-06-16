using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.WorkOrder_Information
{
    public class WorkOrder_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        public List<WorkOrder> loadAllWorkOrders()
        {
            List<WorkOrder> workOrders = new List<WorkOrder>();

            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM OrdenTrabajo AS ot INNER JOIN Observacion AS o ON ot.Identificacion = o.IdentificacionOrdenTrabajo";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int workOrderId = (int)reader["Identificacion"];

                        //Cargar todas las observaciones de una orden de trabajo
                        List<Observation> observations = new List<Observation>
                {
                    new Observation_Model().loadObservation((int)reader["IdObservacion"])
                };

                        WorkOrder workOrder = new WorkOrder(
                            workOrderId,
                            (DateTime)reader["Fecha"],
                            new Branch_Model().GetBranch((int)reader["IdentificacionSucursal"]),
                            new Client_Model().getClient(reader["IdentificacionCliente"].ToString()),
                            new Vehicle_Model().getVehicle(reader["PlacaVehiculo"].ToString()),
                            (int)reader["KilometrajeActual"],
                            (int)reader["RecorridoRecomendado"],
                            (int)reader["ProximoCambio"],
                            observations,
                            (decimal)reader["Monto"],
                            reader["Estado"].ToString()
                        );

                        workOrders.Add(workOrder);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (this is a simple console log, consider using a proper logging framework)
                Console.WriteLine(ex.Message);
                throw; // Optionally rethrow the exception or handle it accordingly
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return workOrders;
        }
    }
}
