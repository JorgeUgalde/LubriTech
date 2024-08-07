﻿using LubriTech.Controller;
using LubriTech.Model.InventoryManagment_Information;
using LubriTech.Model.Item_Information;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LubriTech.Model.PricesList_Information
{
    public class PriceList_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        //get all price lists
        public List<PriceList> getPriceLists()
        {
            List<PriceList> priceLists = new List<PriceList>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ListaPrecios", conn);
                DataTable plsTable = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(plsTable);

                foreach (DataRow dr in plsTable.Rows)
                {
                    PriceList priceList = new PriceList();
                    priceList.id = Convert.ToInt32(dr["Identificacion"]);
                    priceList.description = dr["Descripcion"].ToString();
                    priceList.state = Convert.ToInt32(dr["Estado"]);
                    priceList.prices = new Prices_Model().getPricesByPriceList(Convert.ToInt32(dr["Identificacion"]));
                    priceLists.Add(priceList);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return priceLists;
        }

        //get a price list by id
        public PriceList getPriceList(int id)
        {
            PriceList priceList = new PriceList();
            try
            {
                string query = "SELECT * FROM ListaPrecios WHERE Identificacion = @id";


                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);


                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                DataTable plTable = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(plTable);

                foreach (DataRow dr in plTable.Rows)
                {
                    priceList.id = Convert.ToInt32(dr["Identificacion"]);
                    priceList.description = dr["Descripcion"].ToString();
                    priceList.state = Convert.ToInt32(dr["Estado"]);
                    priceList.prices = new Prices_Model().getPricesByPriceList(Convert.ToInt32(dr["Identificacion"]));
                }

                return priceList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

        }

        //upsert a price list
        public int upsertPriceList(PriceList priceList)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ListaPrecios WHERE Identificacion = @id", conn);
                cmd.Parameters.AddWithValue("@id", priceList.id);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd = new SqlCommand("UPDATE ListaPrecios SET Descripcion = @description, Estado = @state WHERE Identificacion = @id", conn);
                    cmd.Parameters.AddWithValue("@id", priceList.id);
                    cmd.Parameters.AddWithValue("@description", priceList.description);
                    cmd.Parameters.AddWithValue("@state", priceList.state);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO ListaPrecios(Descripcion, Estado) VALUES (@description, @state);" +
                        "SELECT SCOPE_IDENTITY();", conn);
                    cmd.Parameters.AddWithValue("@description", priceList.description);
                    cmd.Parameters.AddWithValue("@state", priceList.state);
                }
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if(id >= 0)
                {
                    return id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            return -1;
        }


        public bool insertInLists(Item item, double fact)
        {
            try
            {
                // add item to all price lists 
                List<PriceList> priceLists = getPriceLists();
                foreach (PriceList priceList in priceLists)
                {
                    Prices prices = priceList.prices.Find(x => x.Item.code == item.code);
                    double price = ItemAverageCost(item.code);
                    string query = "INSERT INTO EstablecePrecio" +
                       " (IdentificacionListaPrecios, CodigoArticulo, Factor,  PrecioVenta) " +
                       "VALUES (@id, @code, @fact,  @price)";
                    if (prices == null)
                    {
                        prices = new Prices();
                        prices.Item = item;
                        prices.factor = fact;
                        prices.price = price + (fact * price);
                        priceList.prices.Add(prices);
                    }
                    else
                    {
                        prices.price = price + (fact * price);
                        query = "UPDATE EstablecePrecio SET Factor = @fact, PrecioVenta = @price " +
                           "WHERE IdentificacionListaPrecios = @id AND CodigoArticulo = @code";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", priceList.id);
                    cmd.Parameters.AddWithValue("@code", item.code);
                    cmd.Parameters.AddWithValue("@fact", fact);
                    cmd.Parameters.AddWithValue("@price",price + (fact * price));

                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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

        public double ItemAverageCost(string itemCode)
        {
            string query = "SELECT Monto FROM LineaDetalle WHERE CodigoArticulo = @ItemCode";

            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ItemCode", itemCode);
                DataTable dataTable = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(dataTable);

                if(dataTable.Rows.Count == 0)
                {
                    return 0;
                }

                Double amount = 0;

                foreach (DataRow dr in dataTable.Rows)
                {
                    amount += Convert.ToDouble(dr["Monto"]);
                }
                double inventoryQuantity = new Item_Controller().getItemStock(itemCode, frmLogin.branch);
                if(inventoryQuantity == 0)
                {
                    return 0;
                }
                double sellingPrice = amount / inventoryQuantity;

                return sellingPrice;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return 0;
        }


    }
}
