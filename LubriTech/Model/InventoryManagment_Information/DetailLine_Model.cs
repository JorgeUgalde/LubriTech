﻿using System;
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
    /// Class that manages the operations in the database related to <see cref="DetailLine"/>.
    /// </summary>
    public class DetailLine_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        /// <summary>
        /// Gets all the detail lines from the database.
        /// </summary>
        /// <returns>A detail line list.</returns>
        public List<DetailLine> loadAllDetailLines()
        {
            List<DetailLine> detailLines = new List<DetailLine>();

            try
            {
                conn.Open();
                String selectQuery = "SELECT * FROM LineaDetalle";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable tblDetailLines = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(tblDetailLines);

                foreach (DataRow dr in tblDetailLines.Rows)
                {
                    detailLines.Add(new DetailLine((new Item_Controller().get((dr["CodigoArticulo"].ToString()))),
                                                (new InventoryManagment_Controller().getInventoryManagment(Convert.ToInt32(dr["IdentificacionGestionInventario"]))),
                                                Convert.ToInt32(dr["Cantidad"]),
                                                Convert.ToDouble(dr["Monto"])));
                }
                return detailLines;
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
        /// Inserts or updates a detail line in the datebase.
        /// </summary>
        /// <param name="detailLine">The detail line object to insert or update.</param>
        /// <returns>True if the operation was succeful, otherwise, false.</returns>
        public Boolean upsertDetailLine(DetailLine detailLine)
        {
            try
            {
                if (getDetailLine(detailLine.Item.code, detailLine.InventoryManagment.Id) != null)
                {
                    return updateDetailLine(detailLine);
                }
                else
                {
                    return addDetailLine(detailLine);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a detail line from the database by its item and inventory managment.
        /// </summary>
        /// <param name="itemCode">The code of the item related to the detail line.</param>
        /// <param name="inventoryManagmentId">The id of the inventory managment document related to the detail line.</param>
        /// <returns>The detail line object.</returns>
        public DetailLine getDetailLine(string itemCode, int inventoryManagmentId)
        {
            try
            {
                string selectQuery = "SELECT * FROM LineaDetalle WHERE CodigoArticulo = @itemCode AND IdentificacionGestionInventario = @inventoryManagmentId";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@itemCode", itemCode);
                cmd.Parameters.AddWithValue("@inventoryManagmentId", inventoryManagmentId);

                DataTable tblDetailLines = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;

                adp.Fill(tblDetailLines);
                DataRow dr = tblDetailLines.Rows[0];

                DetailLine detailLine = new DetailLine((new Item_Controller().get((dr["CodigoArticulo"].ToString()))),
                                                (new InventoryManagment_Controller().getInventoryManagment(Convert.ToInt32(dr["IdentificacionGestionInventario"]))),
                                                Convert.ToInt32(dr["Cantidad"]),
                                                Convert.ToDouble(dr["Monto"]));

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return detailLine;
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
        /// Updates a detail line in the databse.
        /// </summary>
        /// <param name="detailLine">The detail line to update.</param>
        /// <returns>True if the operation was succeful, otherwise, false.</returns>
        public Boolean updateDetailLine(DetailLine detailLine)
        {
            try
            {
                string updateQuery = "UPDATE LineaDetalle SET Cantidad = @quantity, MontoTotal = @totalAmount WHERE CodigoArticulo = @itemCode AND IdentificacionGestionInventario = @inventoryManagmentId";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@itemCode", detailLine.getItemCode());
                cmd.Parameters.AddWithValue("@inventoryManagmentId", detailLine.getInventoryManagmentId());
                cmd.Parameters.AddWithValue("@quantity", detailLine.Quantity);
                cmd.Parameters.AddWithValue("@totalAmount", detailLine.TotalAmount);

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
        /// Add a new detail line to the database.
        /// </summary>
        /// <param name="detailLine">Detail line object to insert.</param>
        /// <returns>True if the operation was succeful, otherwise, false..</returns>
        public Boolean addDetailLine(DetailLine detailLine)
        {
            try
            {
                string query = "INSERT INTO LineaDetalle (CodigoArticulo, IdentificacionGestionInventario, Cantidad, MontoTotal) VALUES (@itemCode, @inventoryManagmentId, @quantity, @totalAmount)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemCode", detailLine.getItemCode());
                cmd.Parameters.AddWithValue("@inventoryManagmentId", detailLine.getInventoryManagmentId());
                cmd.Parameters.AddWithValue("@quantity", detailLine.Quantity);
                cmd.Parameters.AddWithValue("@totalAmount", detailLine.TotalAmount);


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

