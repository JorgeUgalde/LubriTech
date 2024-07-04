using LubriTech.Model.Item_Information;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public PriceList getPriceList(int id, string description)
        {
            PriceList priceList = new PriceList();
            try
            {
                string query = "SELECT * FROM ListaPrecios WHERE Identificacion = @id";
                if (description.Length > 0)
                {
                    query = "SELECT * FROM ListaPrecios WHERE Descripcion = @description";
                }
                
                SqlCommand cmd = new SqlCommand(query, conn);

                if (description.Length > 0)
                {
                    cmd.Parameters.AddWithValue("@description", description);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id", id);
                }

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
        public bool upsertPriceList(PriceList priceList)
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
                    cmd = new SqlCommand("INSERT INTO ListaPrecios(Descripcion, Estado) VALUES (@description, @state)", conn);
                    cmd.Parameters.AddWithValue("@description", priceList.description);
                    cmd.Parameters.AddWithValue("@state", priceList.state);
                }
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        //delete a price list by id
        public bool deletePriceList(int id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM ListaPrecios WHERE Identificacion = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool insertInLists(Item item, double fact)
        {
            try
            {
                PriceList generalList = getPriceList(0, "General");

                if (generalList == null )
                {
                    return false;
                }

                //check if the item is already in the general list
                Prices prices = generalList.prices.Find(x => x.Item.code == item.code);

                string query = "INSERT INTO EstablecePrecio" +
                    " (IdentificacionListaPrecios, CodigoArticulo, Factor,  PrecioVenta) " +
                    "VALUES (@id, @code, @fact,  @price)";

                if (prices != null)
                {
                    query = "UPDATE EstablecePrecio SET Factor = @fact, PrecioVenta = @price " +
                        "WHERE IdentificacionListaPrecios = @id AND CodigoArticulo = @code";
                }

                
                   
                SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", generalList.id);
                    cmd.Parameters.AddWithValue("@code", item.code);
                    cmd.Parameters.AddWithValue("@fact", fact);
                    cmd.Parameters.AddWithValue("@price", item.purchasePrice + (fact * item.purchasePrice));

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();

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


    }
}
