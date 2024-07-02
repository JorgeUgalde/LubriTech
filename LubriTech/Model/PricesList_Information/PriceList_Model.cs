using System;
using System.Collections.Generic;
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
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PriceList priceList = new PriceList();
                    priceList.id = reader.GetInt32(reader.GetOrdinal("Identificacion"));
                    priceList.description = reader.GetString(reader.GetOrdinal("Descripcion"));
                    priceList.state = reader.GetInt32(reader.GetOrdinal("Estado"));
                    priceList.prices = new Prices_Model().getPricesByPriceList(reader.GetInt32(reader.GetOrdinal("Identificacion")));
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
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ListaPrecios WHERE Identificacion = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    priceList.id = reader.GetInt32(reader.GetOrdinal("Identificacion"));
                    priceList.description = reader.GetString(reader.GetOrdinal("Descripcion"));
                    priceList.state = reader.GetInt32(reader.GetOrdinal("Estado"));
                    priceList.prices = new Prices_Model().getPricesByPriceList(reader.GetInt32(reader.GetOrdinal("Identificacion")));
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return priceList;
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
    }
}
