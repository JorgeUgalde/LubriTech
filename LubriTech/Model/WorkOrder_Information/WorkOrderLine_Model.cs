using LubriTech.Model.items_Information;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.WorkOrder_Information
{
    public class WorkOrderLine_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        //load all work order lines from a work order
        public List<WorkOrderLine> loadWorkOrderLines(int workOrderId)
        {
            List<WorkOrderLine> workOrderLines = new List<WorkOrderLine>();
            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM LineaOrdenTrabajo WHERE IdentificacionOrdenTrabajo = @workOrderId";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@workOrderId", workOrderId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WorkOrderLine workOrderLine = new WorkOrderLine();
                    workOrderLine.Id = reader.GetInt32(0);
                    workOrderLine.WorkOrderId = reader.GetInt32(1);
                    workOrderLine.item = new Item_Model().getItem(reader.GetString(2));
                    workOrderLine.Quantity = reader.GetInt32(3);
                    workOrderLine.Amount = reader.GetDecimal(4);
                    workOrderLines.Add(workOrderLine);
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
            return workOrderLines;
        }

        //upsert a work order line
        public bool upsertWorkOrderLine(WorkOrderLine workOrderLine)
        {
            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM LineaOrdenTrabajo where IdLineaOrdenTrabajo = @id";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", workOrderLine.Id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    //update
                    reader.Close();
                    String updateQuery = "UPDATE LineaOrdenTrabajo SET IdentificacionOrdenTrabajo = @workOrderId, CodigoItem = @itemCode, Cantidad = @quantity, Monto = @amount WHERE IdLineaOrdenTrabajo = @id";
                    cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@workOrderId", workOrderLine.WorkOrderId);
                    cmd.Parameters.AddWithValue("@itemCode", workOrderLine.item.code);
                    cmd.Parameters.AddWithValue("@quantity", workOrderLine.Quantity);
                    cmd.Parameters.AddWithValue("@amount", workOrderLine.Amount);
                    cmd.Parameters.AddWithValue("@id", workOrderLine.Id);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    //insert
                    reader.Close();
                    String insertQuery = "INSERT INTO LineaOrdenTrabajo (IdentificacionOrdenTrabajo, CodigoItem, Cantidad, Monto) VALUES (@workOrderId, @itemCode, @quantity, @amount)";
                    cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@workOrderId", workOrderLine.WorkOrderId);
                    cmd.Parameters.AddWithValue("@itemCode", workOrderLine.item.code);
                    cmd.Parameters.AddWithValue("@quantity", workOrderLine.Quantity);
                    cmd.Parameters.AddWithValue("@amount", workOrderLine.Amount);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    }
}
