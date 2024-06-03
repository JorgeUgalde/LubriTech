using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.User_Information
{
    class User_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);

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
                    u = new User(reader["CorreoElectronico"].ToString(), reader["Contrasena"].ToString());
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

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
