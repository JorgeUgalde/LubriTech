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
            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM OrdenTrabajo";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WorkOrder workOrder = new WorkOrder();
                    workOrder.Id = reader.GetInt32(0);
                    workOrder.Date = reader.GetDateTime(1);
                    workOrder.Branch = new Branch_Model().GetBranch(reader.GetInt32(2));
                    workOrder.Client = new Client_Model().getClient(reader.GetString(3));
                    workOrder.Vehicle = new Vehicle_Model().getVehicle(reader.GetString(4));
                    workOrder.CurrentMileage = reader.GetInt32(5);
                    workOrder.Amount = reader.GetDecimal(6);
                    workOrder.State = reader.GetInt16(7);
                    workOrders.Add(workOrder);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return workOrders;
        }


        //load all work orders from a client
        public List<WorkOrder> loadWorkOrdersFromClient(string clientId)
        {
            List<WorkOrder> workOrders = new List<WorkOrder>();
            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM OrdenTrabajo WHERE IdentificacionCliente = @clientId";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@clientId", clientId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WorkOrder workOrder = new WorkOrder();
                    workOrder.Id = reader.GetInt32(0);
                    workOrder.Date = reader.GetDateTime(1);
                    workOrder.Branch = new Branch_Model().GetBranch(reader.GetInt32(2));
                    workOrder.Client = new Client_Model().getClient(reader.GetString(3));
                    workOrder.Vehicle = new Vehicle_Model().getVehicle(reader.GetString(4));
                    workOrder.CurrentMileage = reader.GetInt32(5);
                    workOrder.Amount = reader.GetDecimal(6);
                    workOrder.State = reader.GetInt16(7);
                    workOrders.Add(workOrder);
                }
            }
            catch (Exception ex)
            {
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
