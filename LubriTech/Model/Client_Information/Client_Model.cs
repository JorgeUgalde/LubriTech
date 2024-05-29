using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Client_Information
{
    public class Client_Model
    {
        public List<Client> loadAllClients()
        {
            List<Client> client = new List<Client>();

            try
            {
                String selectQuery = "select * from Cliente";

                DataTable tblCliente = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand(selectQuery);

                foreach (DataRow dr in tblCliente.Rows)
                {
                    //client.Add(new Client((string)dr[""]);
                }
                return client;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
