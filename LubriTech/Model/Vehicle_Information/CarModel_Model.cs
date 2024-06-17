using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.Model.Vehicle_Information
{
    public class CarModel_Model
    {
        SqlConnection conn = new SqlConnection(LubriTech.Properties.Settings.Default.connString);
        public List<CarModel> loadAllCarModels()
        {
            List<CarModel> carModels = new List<CarModel>();
            try
            {
                string selectQuery = "select * from CatalogoModelo";
                DataTable tblCarModel = new DataTable();
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(tblCarModel);
                foreach (DataRow row in tblCarModel.Rows)
                {
                    carModels.Add(new CarModel(Convert.ToInt32(row["Identificacion"]), row["Nombre"].ToString(), getMake((Convert.ToInt32(row["IdentificacionMarca"]))), row["Estado"].ToString()));
                }
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                return carModels;
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

        public List<CarModel> loadModelsByMake(int makeId)
        {
            List<CarModel> carModels = new List<CarModel>();
            try
            {
                string selectQuery = "select * from CatalogoModelo where IdentificacionMarca = @id";
                DataTable tblCarModel = new DataTable();
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", makeId);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(tblCarModel);

                foreach (DataRow row in tblCarModel.Rows)
                {
                    carModels.Add(new CarModel(Convert.ToInt32(row["Identificacion"]), row["Nombre"].ToString(), getMake((Convert.ToInt32(row["IdentificacionMarca"]))), row["Estado"].ToString()));
                }
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                return carModels;
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

        public Make getMake(int id)
        {
            Make make = null;
            try
            {
                string selectQuery = "select * from CatalogoMarca where Identificacion = @id";
                DataTable tblMake = new DataTable();
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(tblMake);

                foreach (DataRow row in tblMake.Rows)
                {
                    make = new Make(Convert.ToInt32(row["Identificacion"]), row["Nombre"].ToString(), row["Estado"].ToString());
                }
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                return make;
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

        public CarModel getModel(int ModelId)
        {
            try
            {
                String selectQueryModels = "SELECT * FROM CatalogoModelo WHERE CatalogoModelo.Identificacion = @identificacion;";
                SqlCommand select = new SqlCommand(selectQueryModels, conn);
                select.Parameters.AddWithValue("@identificacion", ModelId);

                DataTable tblModelCatalog = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();

                adp.SelectCommand = select;

                adp.Fill(tblModelCatalog);
                CarModel model = null;

                foreach (DataRow dr in tblModelCatalog.Rows)
                {
                    model = new CarModel(Convert.ToInt32(dr["Identificacion"]),
                                        dr["Nombre"].ToString(),
                                        (getMake(Convert.ToInt32(dr["IdentificacionMarca"]))),
                                        dr["Estado"].ToString());
                }

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();

                }

                select.ExecuteNonQuery();

                return model;
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

        // update or Insert a make
        public Boolean Upsert(CarModel carModel)
        {
            try
            {
                string query = "";
                if (getModel(carModel.Id) == null)
                {
                    query = "insert into CatalogoModelo (Nombre, Estado, IdentificacionMarca) values (@name, @state, @makeId)";
                }
                else
                {
                    query = "update CatalogoModelo set Nombre = @name, Estado = @state, IdentificacionMarca = @makeId where Identificacion = @Id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", carModel.Name);
                cmd.Parameters.AddWithValue("@Id", carModel.Id);
                cmd.Parameters.AddWithValue("@state", carModel.State);
                cmd.Parameters.AddWithValue("@makeId", carModel.Make.Id);


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
    }
}
