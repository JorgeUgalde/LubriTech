using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Branch_Information
{

    /// <summary>
    /// Clase que gestiona la interacción con la base de datos para la entidad <see cref="Branch"/>.
    /// </summary>
    public class Branch_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        /// <summary>
        /// Carga todas las sucursales almacenadas en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Branch que representan todas las sucursales.</returns>
        public List<Branch> loadAllBranches()
        {
            try
            {
                List<Branch> branches = new List<Branch>();

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                String selectQuery = "SELECT * FROM Sucursal";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    //public Branch(int id, string name, string address, int phone, string email, string state)

                    {
                    branches.Add(new Branch(
                        Convert.ToInt32(reader["Identificacion"]),
                        reader["NombreSucursal"].ToString(),
                        reader["Direccion"].ToString(),
                        Convert.ToInt64(reader["NumeroTelefono"]),
                        reader["Correo"].ToString(),
                        Convert.ToInt32(reader ["Estado"]) == 1 ? "Activo" : "Inactivo"));
                }
                return branches;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene una sucursal específica basada en su Identificación.
        /// </summary>
        /// <param name="id">Identificador único de la sucursal a obtener.</param>
        /// <returns>Objeto Branch que representa la sucursal encontrada, o null si no se encuentra.</returns>
        public Branch GetBranch(int id)
        {
            try
            {
                String selectQuery = "SELECT * FROM Sucursal WHERE Identificacion = @id";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);


                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();              

                if (reader.Read())
                {
                    return new Branch(
                        Convert.ToInt32(reader["Identificacion"]),
                        reader["NombreSucursal"].ToString(),
                        reader["Direccion"].ToString(),
                        Convert.ToInt64(reader["NumeroTelefono"]),
                        reader["Correo"].ToString(),
                        Convert.ToInt32(reader ["Estado"]) == 1 ? "Activo" : "Inactivo");
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Inserta o actualiza una sucursal en la base de datos.
        /// </summary>
        /// <param name="branch">Objeto Branch que representa la sucursal a insertar o actualizar.</param>
        /// <returns>true si la operación fue exitosa, false si ocurrió un error.</returns>
        public bool UpsertBranch(Branch branch)
        {
            try
            {
               
                String query = "INSERT INTO Sucursal (NombreSucursal, Direccion, NumeroTelefono, Correo, Estado) VALUES (@name, @address, @phone, @email, @state)";
                
                if (GetBranch(branch.Id) != null)
                {
                    query = "UPDATE Sucursal SET NombreSucursal = @name, Direccion = @address, NumeroTelefono = @phone, Correo = @email , Estado = @state WHERE Identificacion = @id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", branch.Id);
                cmd.Parameters.AddWithValue("@name", branch.Name);
                cmd.Parameters.AddWithValue("@address", branch.Address);
                cmd.Parameters.AddWithValue("@phone", branch.Phone);
                cmd.Parameters.AddWithValue("@email", branch.Email);
                cmd.Parameters.AddWithValue("@state", branch.State.Equals("Activo") ? 1: 0 );

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
                conn.Close();
            }
        }
    }
}
