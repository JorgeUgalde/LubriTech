using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Item_Information
{
    public class ItemType_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        // to load the item types, use a datatable to store the data

        public List <ItemType> loadAllItemTypes()
        {

            try
            {
                List<ItemType> itemTypes = new List<ItemType>();


                string query = "SELECT * FROM CatalogoTipoArticulo";

                // check if the connection is open
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable itemsTypeDT = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(itemsTypeDT);

                foreach (DataRow row in itemsTypeDT.Rows)
                {
                    itemTypes.Add(new ItemType(
                        Convert.ToInt32(row["Identificacion"]), 
                        row["TipoArticulo"].ToString(), 
                        Convert.ToInt32(row["Estado"]) == 1 ? "Activo" : "Inactivo"));
                }
                return itemTypes;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public ItemType getItemType(int id)
        {
            try
            {
                ItemType itemType = new ItemType();
                string query = "SELECT * FROM CatalogoTipoArticulo WHERE Identificacion = @id";

                // check if the connection is open
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                DataTable itemsTypeDT = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(itemsTypeDT);

                foreach (DataRow row in itemsTypeDT.Rows)
                {
                    itemType = new ItemType(
                                Convert.ToInt32(row["Identificacion"]),
                                row["TipoArticulo"].ToString(),
                                Convert.ToInt32(row["Estado"]) == 1 ? "Activo" : "Inactivo");
                }
                return itemType;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

        }


        public bool UpSert(ItemType itemType)
        {
            try
            {
                string query = "";
                if (itemType.Id == 0)
                {
                    query = "INSERT INTO CatalogoTipoArticulo (TipoArticulo, Estado) VALUES (@name, @state)";
                }
                else
                {
                    query = "UPDATE CatalogoTipoArticulo SET TipoArticulo = @name, Estado = @state WHERE Identificacion = @id";
                }

                // check if the connection is open
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", itemType.Name);
                cmd.Parameters.AddWithValue("@state", itemType.State == "Activo" ? 1 : 0);
                if (itemType.Id != 0)
                {
                    cmd.Parameters.AddWithValue("@id", itemType.Id);
                }
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
