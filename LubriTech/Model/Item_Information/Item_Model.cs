using LubriTech.Model.Item_Information;
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
                        dr["UnidadMedida"].ToString(),
                        Convert.ToInt32(dr["Estado"]) == 1 ? "Activo": "Inactivo" ,
                        dr["Tipo"].ToString().Equals("Producto") ? getItemStock(dr["Codigo"].ToString(), 1) : 0 ,
                        Convert.ToDouble(dr["PrecioCompra"]),
                        dr["Tipo"].ToString(),
                        Convert.ToDouble(dr["RecorridoRecomendado"])
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

        private double getItemStock(string itemCode,  int branch)
        {
            try
            {
                string selectQuery = "select CantidadAlmacen from SeAlmacena where CodigoArticulo = @item and IdentificacionSucursal = @branch";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@item", itemCode);
                cmd.Parameters.AddWithValue("@branch", 1);

                DataTable tblitems = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;

                adp.Fill(tblitems);
                DataRow dr = tblitems.Rows[0];

                return Convert.ToDouble(dr["CantidadAlmacen"]);
            }
            catch (Exception ex)
            {
                return 0;
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
                DataRow dr = tblitems.Rows[0];

                Item items = new Item(
                        dr["Codigo"].ToString(),
                        dr["Nombre"].ToString(),
                        dr["UnidadMedida"].ToString(),
                        Convert.ToInt32(dr["Estado"]) == 1 ? "Activo" : "Inactivo",
                        dr["Tipo"].ToString().Equals("Producto") ? getItemStock(dr["Codigo"].ToString(), 1) : 0,
                        Convert.ToDouble(dr["PrecioCompra"]),
                        dr["Tipo"].ToString(),
                        Convert.ToDouble(dr["RecorridoRecomendado"])
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

        /// <summary>
        /// Inserta o actualiza un artículo en la base de datos.
        /// </summary>
        /// <param name="items">El objeto <see cref="Item"/> que representa el artículo a insertar o actualizar.</param>
        /// <returns>Verdadero si la operación fue exitosa, de lo contrario falso.</returns>
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

        /// <summary>
        /// Actualiza un artículo existente en la base de datos.
        /// </summary>
        /// <param name="items">El objeto <see cref="Item"/> que representa el artículo a actualizar.</param>
        /// <returns>Verdadero si la operación fue exitosa, de lo contrario falso.</returns>
        public Boolean updateitems(Item items)
        {
            try
            {
                string updateQuery = "update Articulo set " +
                    "Nombre = @name, " +
                    "UnidadMedida = @measureUnit," +
                    "Estado = @state, " +
                    "PrecioCompra = @purchasePrice, " +
                    "Tipo = @type, " +
                    "RecorridoRecomendado = @recommended " +
                    "where Codigo = @code";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);

                cmd.Parameters.AddWithValue("@code", items.code);
                cmd.Parameters.AddWithValue("@name", items.name);
                cmd.Parameters.AddWithValue("@measureUnit", items.measureUnit);
                cmd.Parameters.AddWithValue("@state", (items.state.Equals("Activo")) ? 1 : 0  );
                cmd.Parameters.AddWithValue("@purchasePrice", items.purchasePrice);
                cmd.Parameters.AddWithValue("@type", items.type);
                cmd.Parameters.AddWithValue("@recommended", items.recommendedServiceInterval);

                string updateStockQuery = "update SeAlmacena set CantidadAlmacen = @stock " +
                                          "where CodigoArticulo = @code and IdentificacionSucursal = @branch";

                SqlCommand cmdStock = new SqlCommand(updateStockQuery, conn);
                cmdStock.Parameters.AddWithValue("@stock", items.stock);
                cmdStock.Parameters.AddWithValue("@code", items.code);
                cmdStock.Parameters.AddWithValue("@branch", 1);




                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
                cmdStock.ExecuteNonQuery();

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
        /// Agrega un nuevo artículo a la base de datos.
        /// </summary>
        /// <param name="items">El objeto <see cref="Item"/> que representa el artículo a agregar.</param>
        /// <returns>Verdadero si la operación fue exitosa, de lo contrario falso.</returns>
        public Boolean addItem(Item items)
        {
            try
            {
                string insertQuery = "Insert into Articulo " +
                    "(Codigo, Nombre, UnidadMedida, Estado, PrecioCompra, Tipo, RecorridoRecomendado)" +
                    " values " +
                    "(@code," +
                    "@name, " +
                    "@measureUnit," +
                    "@state, " +
                    "@purchasePrice, " +
                    "@type, " +
                    "@recommended )";

SqlCommand cmd = new SqlCommand(insertQuery, conn);


                cmd.Parameters.AddWithValue("@code", items.code);
                cmd.Parameters.AddWithValue("@name", items.name);
                cmd.Parameters.AddWithValue("@measureUnit", items.measureUnit);
                cmd.Parameters.AddWithValue("@state", (items.state.Equals("Activo")) ? 1 : 0);
                cmd.Parameters.AddWithValue("@purchasePrice", items.purchasePrice);
                cmd.Parameters.AddWithValue("@type", items.type);
                cmd.Parameters.AddWithValue("@recommended", items.recommendedServiceInterval);

                string insertStockQuery = "Insert into SeAlmacena " +
                                          "(CodigoArticulo, IdentificacionSucursal, CantidadAlmacen)" +
                                          " values " +
                                          "(@code, @branch, @stock)";

                SqlCommand cmdStock = new SqlCommand(insertStockQuery, conn);
                cmdStock.Parameters.AddWithValue("@stock", items.stock);
                cmdStock.Parameters.AddWithValue("@code", items.code);
                cmdStock.Parameters.AddWithValue("@branch", 1);



                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
                cmdStock.ExecuteNonQuery();

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
