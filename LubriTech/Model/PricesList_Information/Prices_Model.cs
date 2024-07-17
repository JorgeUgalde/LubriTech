using LubriTech.Model.items_Information;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.PricesList_Information
{
    public class Prices_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        //get all prices from a price list and return a datatable
        public DataTable getPricesByPriceListDT(int priceListId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM EstablecePrecio WHERE IdentificacionListaPrecios = @priceListId", conn))
                {
                    cmd.Parameters.AddWithValue("@priceListId", priceListId);
                    conn.Open();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return dt;
        }

        public double getPriceByItem(string itemCode, int priceListId)
        {
            double price;
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM EstablecePrecio WHERE CodigoArticulo = @itemCode AND IdentificacionListaPrecios = @priceListId", conn))
                {
                    cmd.Parameters.AddWithValue("@itemCode", itemCode);
                    cmd.Parameters.AddWithValue("@priceListId", priceListId);
                    conn.Open();
                    price = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return price;
        }

        //get all prices from a price list and return a list
        public List<Prices> getPricesByPriceList(int priceListId)
        {
            List<Prices> prices = new List<Prices>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM EstablecePrecio WHERE IdentificacionListaPrecios = @priceListId", conn);
                cmd.Parameters.AddWithValue("@priceListId", priceListId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Prices price = new Prices();
                    price.id = reader.GetInt32(reader.GetOrdinal("Identificacion"));
                    price.priceList = reader.GetInt32(reader.GetOrdinal("IdentificacionListaPrecios"));
                    price.Item = new Item_Model().getItem(reader.GetString(reader.GetOrdinal("CodigoArticulo")));
                    price.factor = Convert.ToDouble(reader["Factor"]);
                    price.price = Convert.ToDouble(reader["PrecioVenta"]); ;
                    prices.Add(price);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return prices;
        }

        //upsert a price by a datarow
        public bool upsertPrice(DataRow row)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM EstablecePrecio WHERE Identificacion = @id", conn);
                cmd.Parameters.AddWithValue("@id", row["Identificacion"]);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd = new SqlCommand("UPDATE EstablecePrecio SET IdentificacionListaPrecios = @priceList, CodigoArticulo = @item, Factor = @factor, PrecioVenta = @price WHERE Identificacion = @id", conn);
                    cmd.Parameters.AddWithValue("@id", row["Identificacion"]);
                    cmd.Parameters.AddWithValue("@priceList", row["IdentificacionListaPrecios"]);
                    cmd.Parameters.AddWithValue("@item", row["CodigoArticulo"]);
                    cmd.Parameters.AddWithValue("@factor", row["Factor"]);
                    cmd.Parameters.AddWithValue("@price", row["PrecioVenta"]);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO EstablecePrecio (IdentificacionListaPrecios, CodigoArticulo, Factor, PrecioVenta) VALUES (@priceList, @item, @factor, @price)", conn);
                    cmd.Parameters.AddWithValue("@priceList", row["IdentificacionListaPrecios"]);
                    cmd.Parameters.AddWithValue("@item", row["CodigoArticulo"]);
                    cmd.Parameters.AddWithValue("@factor", row["Factor"]);
                    cmd.Parameters.AddWithValue("@price", row["PrecioVenta"]);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool deletePrice(int id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM EstablecePrecio WHERE Identificacion = @id", conn);
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

        public bool updateSellPrice(string itemID)
        {
            try
            {
                List<PriceList> priceLists = new PriceList_Model().getPriceLists();
                foreach (PriceList priceList in priceLists)
                {
                    List<Prices> prices = getPricesByPriceList(priceList.id);
                    double cost = new PriceList_Model().ItemAverageCost(new Item_Model().getItem(itemID).code);
                    Prices price = prices.Find(p => p.Item.code == itemID);

                    if (price != null)
                    {
                        price.price = cost + (cost * price.factor);
                        string query = "UPDATE EstablecePrecio SET PrecioVenta = @price WHERE Identificacion = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@price", price.price);
                        cmd.Parameters.AddWithValue("@id", price.id);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }                    
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
