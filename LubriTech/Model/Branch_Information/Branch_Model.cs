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

                conn.Open();
                String selectQuery = "SELECT * FROM Sucursal";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    branches.Add(new Branch((int)reader["Identificacion"], reader["NombreSucursal"].ToString(), reader["Direccion"].ToString(),
                                               reader["Correo"].ToString(), reader["Telefono"].ToString(), (short)reader["Estado"]));
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
                conn.Open();
                String selectQuery = "SELECT * FROM Sucursal WHERE Identificacion = @id";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Branch((int)reader["Identificacion"], reader["NombreSucursal"].ToString(), reader["Direccion"].ToString(),
                                                             reader["Correo"].ToString(), reader["NumeroTelefono"].ToString(), (short)reader["Estado"]);
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
                conn.Open();
                String query = "INSERT INTO Sucursal (Nombre, Direccion, Telefono, Correo) VALUES (@name, @address, @phone, @email)";
                if (branch.Id != 0)
                {
                    query = "UPDATE Sucursal SET Nombre = @name, Direccion = @address, Telefono = @phone, Correo = @email WHERE Identificacion = @id";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", branch.Name);
                cmd.Parameters.AddWithValue("@address", branch.Address);
                cmd.Parameters.AddWithValue("@phone", branch.Phone);
                cmd.Parameters.AddWithValue("@email", branch.Email);
                if (branch.Id != 0)
                {
                    cmd.Parameters.AddWithValue("@id", branch.Id);
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
