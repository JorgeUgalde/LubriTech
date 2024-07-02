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
    /// <summary>
    /// Clase que maneja la lógica de acceso a datos para las órdenes de trabajo.
    /// </summary>
    public class WorkOrder_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        //load all work orders 
        public List<WorkOrder> loadWorkOrders()
        {
            List<WorkOrder> workOrders = new List<WorkOrder>();
            string selectQuery = @"
            SELECT ot.Identificacion, ot.Fecha, ot.IdentificacionSucursal, ot.IdentificacionCliente, 
                   ot.PlacaVehiculo, ot.KilometrajeActual, ot.Monto, ot.Estado
            FROM OrdenTrabajo ot";

            SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WorkOrder workOrder = new WorkOrder
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Identificacion")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                                Branch = new Branch_Model().GetBranch(reader.GetInt32(reader.GetOrdinal("IdentificacionSucursal"))),
                                Client = new Client_Model().getClient(reader.GetString(reader.GetOrdinal("IdentificacionCliente"))),
                                Vehicle = new Vehicle_Model().getVehicle(reader.GetString(reader.GetOrdinal("PlacaVehiculo"))),
                                CurrentMileage = reader.GetInt32(reader.GetOrdinal("KilometrajeActual")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Monto")),
                                State = reader.GetInt16(reader.GetOrdinal("Estado")),
                                workOrderLines = new WorkOrderLine_Model().LoadWorkOrderLines(reader.GetInt32(reader.GetOrdinal("Identificacion"))),
                                Observations = new Observation_Model().LoadObservations(reader.GetInt32(reader.GetOrdinal("Identificacion")))
                            };

                            workOrders.Add(workOrder);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error loading work orders: {ex.Message}");
                // Optionally rethrow or handle it as needed
                // throw;
                return null;
            }
            finally
            {
                conn.Close();
            }

            return workOrders;
        }

        //Carga una orden de trabajo
        public WorkOrder loadWorkOrder(int workOrderId)
        {
            string query = "SELECT * FROM OrdenTrabajo WHERE Identificacion = @workOrderId";

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@workOrderId", workOrderId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            WorkOrder workOrder = new WorkOrder
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Identificacion")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                                Branch = new Branch_Model().GetBranch(reader.GetInt32(reader.GetOrdinal("IdentificacionSucursal"))),
                                Client = new Client_Model().getClient(reader.GetString(reader.GetOrdinal("IdentificacionCliente"))),
                                Vehicle = new Vehicle_Model().getVehicle(reader.GetString(reader.GetOrdinal("PlacaVehiculo"))),
                                CurrentMileage = reader.GetInt32(reader.GetOrdinal("KilometrajeActual")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Monto")),
                                State = reader.GetInt16(reader.GetOrdinal("Estado")),
                                workOrderLines = new WorkOrderLine_Model().LoadWorkOrderLines(reader.GetInt32(reader.GetOrdinal("Identificacion"))),
                                Observations = new Observation_Model().LoadObservations(reader.GetInt32(reader.GetOrdinal("Identificacion")))
                            };
                            return workOrder;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error loading work order: {ex.Message}");
                // Optionally rethrow or handle it as needed
                // throw;
                return null;
            }
            finally
            {
                conn.Close();
            }
        }


        //load all work orders from a client
        public List<WorkOrder> loadWorkOrdersFromClient(string clientId)
        {
            List<WorkOrder> workOrders = new List<WorkOrder>();
            string selectQuery = @"
        SELECT ot.Identificacion, ot.Fecha, ot.IdentificacionSucursal, ot.IdentificacionCliente, 
               ot.PlacaVehiculo, ot.KilometrajeActual, ot.Monto, ot.Estado
        FROM OrdenTrabajo ot
        WHERE ot.IdentificacionCliente = @clientId";

            SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@clientId", clientId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WorkOrder workOrder = new WorkOrder
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Identificacion")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                                Branch = new Branch_Model().GetBranch(reader.GetInt32(reader.GetOrdinal("IdentificacionSucursal"))),
                                Client = new Client_Model().getClient(reader.GetString(reader.GetOrdinal("IdentificacionCliente"))),
                                Vehicle = new Vehicle_Model().getVehicle(reader.GetString(reader.GetOrdinal("PlacaVehiculo"))),
                                CurrentMileage = reader.GetInt32(reader.GetOrdinal("KilometrajeActual")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Monto")),
                                State = reader.GetInt16(reader.GetOrdinal("Estado")),
                                workOrderLines = new WorkOrderLine_Model().LoadWorkOrderLines(reader.GetInt32(reader.GetOrdinal("Identificacion"))),
                                Observations = new Observation_Model().LoadObservations(reader.GetInt32(reader.GetOrdinal("Identificacion")))
                            };

                            workOrders.Add(workOrder);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error loading work orders: {ex.Message}");
                // Optionally rethrow or handle it as needed
                // throw;
                return null;
            }
            finally
            {
                conn.Close();
            }

            return workOrders;
        }
    }
}
