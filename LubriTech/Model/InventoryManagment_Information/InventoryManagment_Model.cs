using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LubriTech.Controller;

namespace LubriTech.Model.InventoryManagment_Information
{
    /// <summary>
    /// Class that manages the operations in the database related to <see cref="InventoryManagment"/>.
    /// </summary>
    public class InventoryManagment_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        /// <summary>
        /// Gets all the inventory managment documents from the database.
        /// </summary>
        /// <returns>An inventory managment list.</returns>
        public List<InventoryManagment> loadAllInventoryManagments()
        {
            List<InventoryManagment> inventoryManagments = new List<InventoryManagment>();

            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM GestionInventario";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable tblInventoryManagments = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(tblInventoryManagments);

                foreach (DataRow dr in tblInventoryManagments.Rows)
                {
                    inventoryManagments.Add(new InventoryManagment(Convert.ToInt32(dr["Identificacion"]),
                                                Convert.ToDateTime(dr["FechaDocumento"].ToString()),
                                                (new Supplier_Controller().GetSupplier(dr["IdentificacionProveedor"].ToString())),
                                                ((Convert.ToInt32(dr["Estado"]) == 1) ? "Activo" : "Inactivo"),
                                                Convert.ToDouble(dr["MontoTotal"]),
                                                (new Branch_Controller().get(Convert.ToInt32(dr["IdentificacionSucursal"]))),
                                                dr["TipoDocumento"].ToString()));
                }
                return inventoryManagments;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }



        /// <summary>
        /// Inserts or updates an inventory managment in the datebase.
        /// </summary>
        /// <param name="inventoryManagment">The inventory managment object to insert or update.</param>
        /// <returns>True if the operation was succeful, otherwise, false.</returns>
        public Boolean upsertInventoryManagment(InventoryManagment inventoryManagment)
        {
            try
            {
                if (getInventoryManagment(inventoryManagment.Id) != null)
                {
                    return updateInventoryManagment(inventoryManagment);
                }
                else
                {
                    return addInventoryManagment(inventoryManagment);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets an inventory managment from the database by its id.
        /// </summary>
        /// <param name="id">The id of the inventory managment.</param>
        /// <returns>The inventory managment object.</returns>
        public InventoryManagment getInventoryManagment(int id)
        {
            try
            {
                string selectQuery = "SELECT * FROM GestionInventario WHERE Identificacion = @id";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);

                DataTable tblInventoryManagments = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;

                adp.Fill(tblInventoryManagments);
                DataRow dr = tblInventoryManagments.Rows[0];

                InventoryManagment inventoryManagment = new InventoryManagment(Convert.ToInt32(dr["Identificacion"]),
                                                Convert.ToDateTime(dr["FechaDocumento"].ToString()),
                                                (new Supplier_Controller().GetSupplier(dr["IdentificacionProveedor"].ToString())),
                                                ((Convert.ToInt32(dr["Estado"]) == 1) ? "Activo" : "Inactivo"),
                                                Convert.ToDouble(dr["MontoTotal"]),
                                                (new Branch_Controller().get(Convert.ToInt32(dr["IdentificacionSucursal"]))),
                                                dr["TipoDocumento"].ToString());

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return inventoryManagment;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Updates an inventory managment in the databse.
        /// </summary>
        /// <param name="inventoryManagment">The inventory managment document to update.</param>
        /// <returns>True if the operation was succeful, otherwise, false.</returns>
        public Boolean updateInventoryManagment(InventoryManagment inventoryManagment)
        {
            try
            {
                string updateQuery = "UPDATE GestionInventario SET FechaDocumento = @documentDate, IdentificacionProveedor = @supplierId, Estado = @state, MontoTotal = @totalAmount, IdentificacionSucursal = @branchId, TipoDocumento = @documentType WHERE Identificacion = @id";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@id", inventoryManagment.Id);
                cmd.Parameters.AddWithValue("@documentDate", inventoryManagment.DocumentDate);
                cmd.Parameters.AddWithValue("@supplierId", inventoryManagment.getSupplierId());
                cmd.Parameters.AddWithValue("@state", (inventoryManagment.State.Equals("Activo")) ? 1 : 0);
                cmd.Parameters.AddWithValue("@totalAmount", inventoryManagment.TotalAmount);
                cmd.Parameters.AddWithValue("@branchId", inventoryManagment.getBranchId());
                cmd.Parameters.AddWithValue("@documentType", inventoryManagment.DocumentType);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Add a new inventory managment to the database.
        /// </summary>
        /// <param name="inventoryManagment">Inventory managment object to insert.</param>
        /// <returns>True if the operation was succeful, otherwise, false..</returns>
        public Boolean addInventoryManagment(InventoryManagment inventoryManagment)
        {
            try
            {
                string query = "INSERT INTO GestionInventario (FechaDocuento, IdentificacionProveedor, Estado, MontoTotal, IdentificacionSucursal, TipoDocumento) VALUES (@documentDate, @supplierId, @state, @totalAmount, @branchId, @documentType)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@documentDate", inventoryManagment.DocumentDate);
                cmd.Parameters.AddWithValue("@supplierId", inventoryManagment.getSupplierId());
                cmd.Parameters.AddWithValue("@state", (inventoryManagment.State.Equals("Activo")) ? 1 : 0);
                cmd.Parameters.AddWithValue("@totalAmount", inventoryManagment.TotalAmount);
                cmd.Parameters.AddWithValue("@branchId", inventoryManagment.getBranchId());
                cmd.Parameters.AddWithValue("@documentType", inventoryManagment.DocumentType);


                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
    }
}

