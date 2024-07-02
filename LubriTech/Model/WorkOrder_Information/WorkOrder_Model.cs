using LubriTech.Controller;
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
                                CurrentMileage = reader.GetInt32(reader.GetOrdinal("KilometrajeActual")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Monto")),
                                State = reader.GetInt16(reader.GetOrdinal("Estado")),
                                workOrderLines = new WorkOrderLine_Model().LoadWorkOrderLines(reader.GetInt32(reader.GetOrdinal("Identificacion"))),
                                Observations = new Observation_Model().LoadObservations(reader.GetInt32(reader.GetOrdinal("Identificacion")))
                            };

                            // Validar si "PlacaVehiculo" es nulo
                            if (!reader.IsDBNull(reader.GetOrdinal("PlacaVehiculo")))
                            {
                                workOrder.Vehicle = new Vehicle_Model().getVehicle(reader.GetString(reader.GetOrdinal("PlacaVehiculo")));
                            }
                            else
                            {
                                workOrder.Vehicle = null; // Manejar el caso cuando "PlacaVehiculo" es nulo
                            }

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
                                CurrentMileage = reader.GetInt32(reader.GetOrdinal("KilometrajeActual")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Monto")),
                                State = reader.GetInt16(reader.GetOrdinal("Estado")),
                                workOrderLines = new WorkOrderLine_Model().LoadWorkOrderLines(reader.GetInt32(reader.GetOrdinal("Identificacion"))),
                                Observations = new Observation_Model().LoadObservations(reader.GetInt32(reader.GetOrdinal("Identificacion")))
                            };

                            // Validar si "PlacaVehiculo" es nulo
                            if (!reader.IsDBNull(reader.GetOrdinal("PlacaVehiculo")))
                            {
                                workOrder.Vehicle = new Vehicle_Model().getVehicle(reader.GetString(reader.GetOrdinal("PlacaVehiculo")));
                            }
                            else
                            {
                                workOrder.Vehicle = null; // Manejar el caso cuando "PlacaVehiculo" es nulo
                            }

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

        //update a work order without IdentificacionCliente and PlacaVehiculo, return boolean
        public bool updateWorkOrder(WorkOrder workOrder)
        {
            string query = @"
            UPDATE OrdenTrabajo
            SET Fecha = @date,
                IdentificacionSucursal = @branchId,
                KilometrajeActual = @currentMileage,
                Monto = @amount,
                Estado = @state
            WHERE Identificacion = @id;";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", workOrder.Id);
                cmd.Parameters.AddWithValue("@date", workOrder.Date);
                cmd.Parameters.AddWithValue("@branchId", workOrder.Branch.Id);
                cmd.Parameters.AddWithValue("@currentMileage", (object)workOrder.CurrentMileage ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@amount", workOrder.Amount);
                cmd.Parameters.AddWithValue("@state", workOrder.State);

                conn.Open();

                // Ejecutar el comando
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public int UpsertWorkOrder(WorkOrder workOrder)
        {
            string query;

            if (workOrder.Id > 0)
            {
                // Query para actualizar una orden existente
                query = @"
            UPDATE OrdenTrabajo
            SET Fecha = @Fecha,
                IdentificacionSucursal = @IdentificacionSucursal,
                IdentificacionCliente = @IdentificacionCliente,
                PlacaVehiculo = @PlacaVehiculo,
                KilometrajeActual = @KilometrajeActual,
                Monto = @Monto,
                Estado = @Estado
            WHERE Identificacion = @Identificacion;

            SELECT @Identificacion;"; // Devuelve el ID de la orden actualizada
            }
            else
            {
                // Query para insertar una nueva orden
                query = @"
            INSERT INTO OrdenTrabajo (Fecha, IdentificacionSucursal, IdentificacionCliente, PlacaVehiculo, KilometrajeActual, Monto, Estado)
            VALUES (@Fecha, @IdentificacionSucursal, @IdentificacionCliente, @PlacaVehiculo, @KilometrajeActual, @Monto, @Estado);

            SELECT SCOPE_IDENTITY();"; // Devuelve el ID de la nueva orden
            }

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (workOrder.Id > 0)
                {
                    cmd.Parameters.AddWithValue("@Identificacion", workOrder.Id);
                }

                cmd.Parameters.AddWithValue("@Fecha", workOrder.Date);
                cmd.Parameters.AddWithValue("@IdentificacionSucursal", workOrder.Branch.Id);
                cmd.Parameters.AddWithValue("@IdentificacionCliente", workOrder.Client.Id);

                // Verificar si workOrder.Vehicle es null y asignar DBNull.Value en ese caso
                if (workOrder.Vehicle == null)
                {
                    cmd.Parameters.AddWithValue("@PlacaVehiculo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PlacaVehiculo", workOrder.Vehicle.LicensePlate);
                }

                cmd.Parameters.AddWithValue("@KilometrajeActual", (object)workOrder.CurrentMileage ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Monto", workOrder.Amount);
                cmd.Parameters.AddWithValue("@Estado", workOrder.State);

                conn.Open();

                // Ejecutar el comando y obtener el ID de la orden
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                return newId;
            }
        }
    }
}
