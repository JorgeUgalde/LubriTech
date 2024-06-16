﻿using LubriTech.Model.Item_Information;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.Model.items_Information
{
    public class Item_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        public List<Item> loadAllitems()
        {
            List<Item> items = new List<Item>();

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
                    items.Add(new Item(
                        dr["Codigo"].ToString(),
                        dr["Nombre"].ToString(),
                        Convert.ToDouble(dr["PrecioVenta"]), 
                        dr["UnidadMedida"].ToString(),
                        dr["Estado"].ToString(),
                        Convert.ToDouble(dr["CantidadAlmacen"]),
                        Convert.ToDouble(dr["PrecioCompra"]),
                        dr["Tipo"].ToString()
                        ));
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
                DataRow dr = tblitems.Rows[0];

                Item items = new Item(
                        dr["Codigo"].ToString(),
                        dr["Nombre"].ToString(),
                        Convert.ToDouble(dr["PrecioVenta"]),
                        dr["UnidadMedida"].ToString(),
                        dr["Estado"].ToString(),
                        Convert.ToDouble(dr["CantidadAlmacen"]),
                        Convert.ToDouble(dr["PrecioCompra"]),
                        dr["Tipo"].ToString()
                        );

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();

                return items;
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

        public Boolean UpSertItem(Item items)
        {
            try
            {
                if(getItem(items.code) != null)
                {
                    return updateitems(items);
                }
                else
                {
                    return addItem(items);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Boolean updateitems(Item items)
        {
            try
            {
                string updateQuery = "update Articulo set " +
                    "Nombre = @name, " +
                    "PrecioVenta = @sellPrice, " +
                    "UnidadMedida = @measureUnit," +
                    "Estado = @state, " +
                    "CantidadAlmacen = @stock," +
                    "PrecioCompra = @purchasePrice, " +
                    "Tipo = @type " +
                    "where Codigo = @code";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@code", items.code);
                cmd.Parameters.AddWithValue("@name", items.name);
                cmd.Parameters.AddWithValue("@sellPrice", items.sellPrice);
                cmd.Parameters.AddWithValue("@measureUnit", items.measureUnit);
                cmd.Parameters.AddWithValue("@state", items.state);
                cmd.Parameters.AddWithValue("@stock", items.stock);
                cmd.Parameters.AddWithValue("@purchasePrice", items.purchasePrice);
                cmd.Parameters.AddWithValue("@type", items.type);


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
        public Boolean addItem(Item items)
        {
            try
            {
                string insertQuery = "Insert into Articulo " +
                    "(Codigo, Nombre, PrecioVenta, UnidadMedida, Estado, CantidadAlmacen, PrecioCompra, Tipo)" +
                    " values " +
                    "(@code," +
                    "@name, " +
                    "@sellPrice, " +
                    "@measureUnit," +
                    "@state, " +
                    "@stock, " +
                    "@purchasePrice, " +
                    "@type )";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);


                cmd.Parameters.AddWithValue("@code", items.code);
                cmd.Parameters.AddWithValue("@name", items.name);
                cmd.Parameters.AddWithValue("@sellPrice", items.sellPrice);
                cmd.Parameters.AddWithValue("@measureUnit", items.measureUnit);
                cmd.Parameters.AddWithValue("@state", items.state);
                cmd.Parameters.AddWithValue("@stock", items.stock);
                cmd.Parameters.AddWithValue("@purchasePrice", items.purchasePrice);
                cmd.Parameters.AddWithValue("@type", items.type);

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



    }
}
