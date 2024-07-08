using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.User_Information
{
    /// <summary>
    /// Clase que maneja las operaciones de la base de datos relacionadas con la entidad <see cref="User"/>.
    /// </summary>
    class User_Model
    {
        // Conexión a la base de datos utilizando la cadena de conexión predeterminada.
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

        /// <summary>
        /// Obtiene un usuario específico de la base de datos según el correo electrónico y la contraseña.
        /// </summary>
        /// <param name="user">El objeto <see cref="User"/> que contiene el correo electrónico y la contraseña del usuario a buscar.</param>
        /// <returns>Un objeto <see cref="User"/> que representa el usuario encontrado, o null si no se encuentra.</returns>
        /// <exception cref="Exception">Lanzada cuando ocurre un error al obtener el usuario.</exception>
        public User GetUser(User user)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                string query = "SELECT * FROM Usuario WHERE CorreoElectronico = @Email AND Contrasena = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", user.email);
                cmd.Parameters.AddWithValue("@Password",user.password); // Hashear la contraseña
                SqlDataReader reader = cmd.ExecuteReader();

                User u = null;
                if (reader.Read())
                {
                    u = new User(
                        reader["CorreoElectronico"].ToString(), 
                        reader["Contrasena"].ToString(), Convert.ToInt32(
                        reader["IdentificacionSucursal"]));
                }
                return u;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario", ex);
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public User EmailValidation(User user)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                string query = "SELECT * FROM Usuario WHERE CorreoElectronico = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", user.email);
                SqlDataReader reader = cmd.ExecuteReader();

                User u = null;
                if (reader.Read())
                {
                    u = new User(
                        reader["CorreoElectronico"].ToString(),
                        reader["Contrasena"].ToString(), Convert.ToInt32(
                        reader["IdentificacionSucursal"]));
                }
                return u;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario", ex);
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public bool UpdatePassword(User user, string code)
        {
            try
            {
                string query = "";

                query = "update Usuario set Contrasena = @password where CorreoElectronico = @email";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@password", code);
                cmd.Parameters.AddWithValue("@email", user.email);


                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
                return true;
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



        public bool Upsert(User user, string newPassword)
        {
            try
            {
                string query = "";

                var existingUser = GetUser(user);

                if (GetUser(user) == null)
                {
                    query = "INSERT INTO Usuario (CorreoElectronico, Contrasena, IdentificacionSucursal) VALUES (@email, @password, @branchId)";
                }
                else
                {
                    
                    query = "UPDATE Usuario SET Contrasena = @password, IdentificacionSucursal = @branchId WHERE CorreoElectronico = @email";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                if (newPassword != null)
                {
                    cmd.Parameters.AddWithValue("@password", newPassword);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@password", user.password);

                }
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@branchId", user.branchID);


                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
                return true;
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
        /// Hashea una contraseña utilizando el algoritmo BCrypt.
        /// </summary>
        /// <param name="password">La contraseña a hashear.</param>
        /// <returns>La contraseña hasheada.</returns>
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
