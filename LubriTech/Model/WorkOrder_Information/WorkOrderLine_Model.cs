using LubriTech.Model.items_Information;
using System;
using System.Collections.Generic;
using System.Data;
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
        public List<WorkOrderLine> LoadWorkOrderLines(int? workOrderId)
        {
            List<WorkOrderLine> workOrderLines = new List<WorkOrderLine>();
            string selectQuery = "SELECT * FROM LineaOrdenTrabajo WHERE IdentificacionOrdenTrabajo = @workOrderId";

            try
            {
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@workOrderId", workOrderId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WorkOrderLine workOrderLine = new WorkOrderLine
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Identificacion")),
                                WorkOrderId = reader.GetInt32(reader.GetOrdinal("IdentificacionOrdenTrabajo")),
                                item = new Item_Model().getItem(reader.GetString(reader.GetOrdinal("CodigoArticulo"))),
                                Quantity = reader.GetDecimal(reader.GetOrdinal("Cantidad")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Monto"))
                            };
                            workOrderLines.Add(workOrderLine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework or your own logging mechanism)
                Console.WriteLine($"Error loading work order lines: {ex.Message}");
                // Optionally, you might want to throw the exception again or handle it as needed
                // throw;
            }

            return workOrderLines;
        }

        public DataTable LoadWorkOrderLinesDT(int workOrderId)
        {
            DataTable workOrderLinesTable = new DataTable();
            string selectQuery = "SELECT * FROM LineaOrdenTrabajo WHERE IdentificacionOrdenTrabajo = @workOrderId";

            try
            {
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@workOrderId", workOrderId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Llenar el DataTable con los datos del SqlDataReader
                        workOrderLinesTable.Load(reader);
                        //workOrderLinesTable.Columns.Add("IsNewRow", typeof(bool));
                        //workOrderLinesTable.Columns["IsNewRow"].DefaultValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework or your own logging mechanism)
                Console.WriteLine($"Error loading work order lines: {ex.Message}");
                // Optionally, you might want to throw the exception again or handle it as needed
                throw;
            }

            return workOrderLinesTable;
        }

        //upsert a work order line
        public bool UpsertWorkOrderLine(DataRow row)
        {
            string upsertQuery = @"
            MERGE INTO LineaOrdenTrabajo AS target
            USING (SELECT @Id AS Id, @IdentificacionOrdenTrabajo AS IdentificacionOrdenTrabajo, @CodigoArticulo AS CodigoArticulo, @Cantidad AS Cantidad, @Monto AS Monto) AS source
            ON (target.Identificacion = source.Id)
            WHEN MATCHED THEN 
                UPDATE SET IdentificacionOrdenTrabajo = source.IdentificacionOrdenTrabajo, CodigoArticulo = source.CodigoArticulo, Cantidad = source.Cantidad, Monto = source.Monto
            WHEN NOT MATCHED THEN
                INSERT (IdentificacionOrdenTrabajo, CodigoArticulo, Cantidad, Monto)
                VALUES (source.IdentificacionOrdenTrabajo, source.CodigoArticulo, source.Cantidad, source.Monto);";

            using (SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(upsertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", row["Identificacion"]);
                        cmd.Parameters.AddWithValue("@IdentificacionOrdenTrabajo", row["IdentificacionOrdenTrabajo"]);
                        cmd.Parameters.AddWithValue("@CodigoArticulo", row["CodigoArticulo"]);
                        cmd.Parameters.AddWithValue("@Cantidad", row["Cantidad"]);
                        cmd.Parameters.AddWithValue("@Monto", row["Monto"]);

                        cmd.ExecuteNonQuery();
                        return true; // Operation was successful
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error upserting WorkOrderLine: {ex.Message}");
                    return false; // Operation failed
                }
            }
        }

        public bool DeleteWorkOrderLine(int workOrderLineId)
        {
            string deleteQuery = "DELETE FROM LineaOrdenTrabajo WHERE Identificacion = @Id";

            using (SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", workOrderLineId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if rows were deleted, otherwise false
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting WorkOrderLine: {ex.Message}");
                    return false; // Return false if an exception occurred
                }
            }
        }
    }
}
