﻿using LubriTech.Controller;
using LubriTech.Model.Item_Information;
using LubriTech.Model.PricesList_Information;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace LubriTech.Model.items_Information
{
    /// <summary>
    /// Clase que maneja las operaciones de la base de datos relacionadas con la entidad <see cref="Item"/>.
    /// </summary>
    public class Item_Model
    {
        // Conexión a la base de datos utilizando la cadena de conexión predeterminada.
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        /// <summary>
        /// Carga todos los artículos desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Item"/> que representan todos los artículos.</returns>
        public List<Item> loadAllitems()
        {
            List<Item> items = new List<Item>();

            Dictionary<int, ItemType> itemTypes = new ItemType_Model().loadAllItemTypes().ToDictionary(e => e.Id, e => e);

            try
            {
                string selectQuery = "select * from Articulo";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);

                DataTable tblitems = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(tblitems);
                

                foreach (DataRow dr in tblitems.Rows)
                {
                    int idType = Convert.ToInt32(dr["IdentificacionTipoArticulo"]);
                    items.Add(new Item(
                        dr["Codigo"].ToString(),
                        dr["Nombre"].ToString(),
                        dr["UnidadMedida"].ToString(),
                        Convert.ToInt32(dr["Estado"]) == 1 ? "Activo" : "Inactivo",
                        (dr["RecorridoRecomendado"] != DBNull.Value ? Convert.ToDouble(dr["RecorridoRecomendado"]) : 0),
                        itemTypes.ContainsKey(idType) ? itemTypes[idType] : null
                        )) ;
                }

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
                return items;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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


        public double getItemStock(string itemCode,  int branch)
        {
            try
            {
                string selectQuery = "select CantidadAlmacen from SeAlmacena where CodigoArticulo = @item and IdentificacionSucursal = @branch";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@item", itemCode);
                cmd.Parameters.AddWithValue("@branch", branch);
                conn.Open();
                DataTable tblitems = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;

                adp.Fill(tblitems);
                // verify if there is a row
                if (tblitems.Rows.Count == 0)
                {
                    conn.Close();
                    return 0;
                }
                DataRow dr = tblitems.Rows[0];

                conn.Close();
                return Convert.ToDouble(dr["CantidadAlmacen"]);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Boolean updateItemQuantity(string item, int branch, double quantity)
        {
            try
            {
                string query = "MERGE INTO SeAlmacena AS target\r\n" +
                                    "USING (SELECT @itemCode AS CodigoArticulo, @branchId AS IdentificacionSucursal, @quantity AS CantidadAlmacen) AS source\r\n" +
                                    "ON (target.CodigoArticulo = source.CodigoArticulo AND target.IdentificacionSucursal = source.IdentificacionSucursal)\r\n" +
                                    "WHEN MATCHED THEN \r\n" +
                                    "    UPDATE SET CantidadAlmacen = source.CantidadAlmacen\r\n" +
                                    "WHEN NOT MATCHED THEN \r\n" +
                                    "    INSERT (CodigoArticulo, IdentificacionSucursal, CantidadAlmacen)\r\n" +
                                    "    VALUES (source.CodigoArticulo, source.IdentificacionSucursal, source.CantidadAlmacen);";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemCode", item);
                cmd.Parameters.AddWithValue("@branchId", branch);
                cmd.Parameters.AddWithValue("@quantity", quantity);

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
        /// Obtiene un artículo específico de la base de datos según su código.
        /// </summary>
        /// <param name="code">El código del artículo.</param>
        /// <returns>Un objeto <see cref="Item"/> que representa el artículo.</returns>
        public Item getItem(string code)
        {
            try
            {
                string selectQuery = "select * from Articulo where [Articulo].Codigo = @code";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@code", code);

                DataTable tblitems = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;

                adp.Fill(tblitems);
                Item item = null;
                foreach (DataRow dr in tblitems.Rows)
                {
                    item =  new Item(
                        dr["Codigo"].ToString(),
                        dr["Nombre"].ToString(),
                        dr["UnidadMedida"].ToString(),
                        Convert.ToInt32(dr["Estado"]) == 1 ? "Activo" : "Inactivo",
                        (dr["RecorridoRecomendado"] != DBNull.Value ? Convert.ToDouble(dr["RecorridoRecomendado"]) : 0),
                        new ItemType_Model().getItemType(Convert.ToInt32(dr["IdentificacionTipoArticulo"]))
                        );
                }




                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return item;
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
        /// Actualiza un artículo existente en la base de datos.
        /// </summary>
        /// <param name="items">El objeto <see cref="Item"/> que representa el artículo a actualizar.</param>
        /// <returns>Verdadero si la operación fue exitosa, de lo contrario falso.</returns>
        public Boolean UpSertItem(Item items, double fact)
        {
            try
            {
                string query = "update Articulo set  Nombre = @name, UnidadMedida = @measureUnit, Estado = @state, " +
                    " IdentificacionTipoArticulo = @type, RecorridoRecomendado = @recommended " +
                    "where Codigo = @code";
                if (getItem(items.code) == null)
                {
                    query = "Insert into Articulo " +
                        "(Codigo, Nombre, UnidadMedida, Estado, RecorridoRecomendado, IdentificacionTipoArticulo)" +
                        " values (@code, @name, @measureUnit, @state, @recommended, @type)";

                }
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@code", items.code);
                cmd.Parameters.AddWithValue("@name", items.name);
                cmd.Parameters.AddWithValue("@measureUnit", items.measureUnit);
                cmd.Parameters.AddWithValue("@state", (items.state.Equals("Activo")) ? 1 : 0  );

                if(items.recommendedServiceInterval == 0)
                {
                    cmd.Parameters.AddWithValue("@recommended", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@recommended", items.recommendedServiceInterval);
                }
                cmd.Parameters.AddWithValue("@type", items.itemType.Id);


                // if sell price is not null, we need to include this item in all List of prices


                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
                new PriceList_Model().insertInLists(items, fact);
                
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

        public bool IsItemService(string code)
        {
            try
            {
                string query = "SELECT TipoArticulo FROM Articulo" +
                    "\r\nINNER JOIN CatalogoTipoArticulo ON Articulo.IdentificacionTipoArticulo = CatalogoTipoArticulo.Identificacion" +
                    "\r\nWHERE Codigo = @itemCode";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemCode", code);

                DataTable tblitems = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;

                adp.Fill(tblitems);

                if (tblitems.Rows.Count == 0)
                {
                    return false;
                }
                DataRow dr = tblitems.Rows[0];
                return dr["TipoArticulo"].ToString() == "Servicio";
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //insert all items to a price list
        public bool insertItemsInPriceList(int priceListId, List<Item> items, double factor, double impuesto)
        {
            try
            {
                foreach (Item item in items)
                {
                    string query = "MERGE INTO EstablecePrecio AS target\r\n" +
                                    "USING (SELECT @priceListId AS IdentificacionListaPrecios, @itemCode AS CodigoArticulo, @factor AS Factor, @price AS PrecioVenta, @IVA as IVA) AS source\r\n" +
                                    "ON (target.CodigoArticulo = source.CodigoArticulo AND target.IdentificacionListaPrecios = source.IdentificacionListaPrecios)\r\n" +
                                    "WHEN MATCHED THEN \r\n" +
                                    "    UPDATE SET PrecioVenta = source.PrecioVenta\r\n" +
                                    "WHEN NOT MATCHED THEN \r\n" +
                                    "    INSERT (IdentificacionListaPrecios, CodigoArticulo, Factor, PrecioVenta, IVA)\r\n" +
                                    "    VALUES (source.IdentificacionListaPrecios, source.CodigoArticulo, source.Factor, source.PrecioVenta, source.IVA);";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@priceListId", priceListId);
                    cmd.Parameters.AddWithValue("@itemCode", item.code);
                    cmd.Parameters.AddWithValue("@factor", factor);
                    double AvgCosts = new PriceList_Controller().ItemAverageCost(item.code);
                    double price = AvgCosts + (AvgCosts * factor);
                    double finalPrice = price + (price * impuesto);
                    // final price round to 2 decimals
                    finalPrice = Math.Round(finalPrice, 2);
                    cmd.Parameters.AddWithValue("@price", finalPrice);
                    cmd.Parameters.AddWithValue("@IVA", impuesto);

                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    cmd.ExecuteNonQuery();
                }

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
    }
}
