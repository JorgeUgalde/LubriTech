using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace LubriTech.Model.Supplier_Information
{

    /// <summary>
    /// Clase que maneja las operaciones de la base de datos relacionadas con la entidad <see cref="Supplier"/>.
    /// </summary>
    public class Supplier_Model
    {
        // Conexión a la base de datos utilizando la cadena de conexión predeterminada.
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        /// <summary>
        /// Carga todos los proveedores desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Supplier"/> que representan todos los proveedores.</returns>
        public List<Supplier> loadAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            try
            {

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                string selectQuery = "select * from Proveedor";

                DataTable tblSupplier = new DataTable();
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();



                while (reader.Read())
                    {
                        suppliers.Add(new Supplier(
                            reader["Identificacion"].ToString(), 
                            reader["Nombre"].ToString(), 
                            reader["CorreoElectronico"].ToString(), 
                            Convert.ToInt64(reader["NumeroTelefono"]),
                            (Convert.ToInt32(reader["Estado"]) == 1) ? "Activo" : "Inactivo"));
                }
                    return suppliers;
                }
                catch (Exception ex)
                {
                    throw (ex);
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
        /// Obtiene un proveedor específico de la base de datos según su identificación.
        /// </summary>
        /// <param name="id">La identificación del proveedor.</param>
        /// <returns>Un objeto <see cref="Supplier"/> que representa el proveedor.</returns>
        public Supplier getSupplier(string id)
        {

            Supplier supplier = null;
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                string query = "Select * from Proveedor where [Proveedor].Identificacion = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    supplier = new Supplier(
                            reader["Identificacion"].ToString(),
                            reader["Nombre"].ToString(),
                            reader["CorreoElectronico"].ToString(),
                            Convert.ToInt64(reader["NumeroTelefono"]),
                            Convert.ToInt32(reader["Estado"]) == 1 ? "Activo" : "Inactivo");
                }
                return supplier;
            }
            catch (Exception ex)
            {
                throw (ex);
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
        /// Guarda un nuevo proveedor en la base de datos.
        /// </summary>
        /// <param name="supplier">El objeto <see cref="Supplier"/> que representa el proveedor a guardar.</param>
        /// <returns>Verdadero si la operación fue exitosa, de lo contrario falso.</returns>
        public Boolean SaveSupplier(Supplier supplier)
        {
            try
            {
                String insertQuery = "insert into Proveedor(Identificacion, Nombre, CorreoElectronico, NumeroTelefono, Estado) values (@id,@name,@email,@phone, @state)";

                SqlCommand insert = new SqlCommand(insertQuery, conn);

                insert.Parameters.AddWithValue("@id", supplier.id);
                insert.Parameters.AddWithValue("@name", supplier.name);
                insert.Parameters.AddWithValue("@email", supplier.email);
                insert.Parameters.AddWithValue("@phone", supplier.phone);
                insert.Parameters.AddWithValue("@state", (supplier.state.Equals("Activo")) ? 1 : 0);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                insert.ExecuteNonQuery();

                return true;

            }
            catch (SqlException ex)
            {
                return false;
                throw ex;

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
        /// Inserta o actualiza un proveedor en la base de datos.
        /// </summary>
        /// <param name="supplier">El objeto <see cref="Supplier"/> que representa el proveedor a insertar o actualizar.</param>
        /// <returns>Verdadero si la operación fue exitosa, de lo contrario falso.</returns>
        public Boolean upsertSupplier(Supplier supplier)
        {
            try
            {
                if (getSupplier(supplier.id) == null)
                {
                    return SaveSupplier(supplier);
                }
                else
                {
                    return updateSupplier(supplier);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actualiza un proveedor existente en la base de datos.
        /// </summary>
        /// <param name="supplier">El objeto <see cref="Supplier"/> que representa el proveedor a actualizar.</param>
        /// <returns>Verdadero si la operación fue exitosa, de lo contrario falso.</returns>
        public Boolean updateSupplier(Supplier supplier)
        {
            try
            {
                string updateQuery = "update Proveedor set Nombre= @name, CorreoElectronico = @email, NumeroTelefono = @phone where [Proveedor].Identificacion = @id";
                SqlCommand update = new SqlCommand(updateQuery, conn);

                update.Parameters.AddWithValue("@name", supplier.name);
                update.Parameters.AddWithValue("@email", supplier.email);
                update.Parameters.AddWithValue("@phone", supplier.phone);
                update.Parameters.AddWithValue("@id", supplier.id);
                update.Parameters.AddWithValue("@state", (supplier.state.Equals("Activo")) ? 1 : 0);



                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                update.ExecuteNonQuery();

                return true;

            }
            catch (SqlException ex)
            {
                return false;
                throw ex;
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
