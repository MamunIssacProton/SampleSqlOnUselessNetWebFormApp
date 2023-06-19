using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LabTask3.Utils
{
    public class DbContext
    {
        public string ConnectionString { get; set; } = "Data Source=Proton\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";
        public DbContext()
        {


        }


        public DataTable FetchTable(string query)
        {
           
            DataTable dataTable;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, Connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            dataTable = new DataTable();
                            adapter.Fill(dataTable);
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public QueryResponse InsertDataIntoTable(string query)
        {

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(query, Connection))
                    {
                        Connection.Open();
                         cmd.ExecuteNonQuery();

                    }
                }


                return new QueryResponse { IsSuccess = true, Message = "Sucessfully inserted data" };

            }
            catch (Exception ex)
            {

                return new QueryResponse { IsSuccess = false, Message = ex.Message };
            }
        }


        public QueryResponse DeleteDataFromTable(string qury)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(qury, Connection))
                    {
                        Connection.Open();
                         cmd.ExecuteNonQuery();
                    }
                }
                return new QueryResponse { IsSuccess = true, Message = "Successfully deleted" };
            }
            catch (Exception ex)
            {

                return new QueryResponse { IsSuccess = false, Message = ex.Message };
            }
        }

        public QueryResponse UpdateDataInTable(string query)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, Connection))
                    {
                        Connection.Open();
                        cmd.ExecuteNonQuery ();

                    }
                }
                return new QueryResponse { IsSuccess = true, Message = string.Empty };
            }
            catch (Exception ex)
            {

                return new QueryResponse() { IsSuccess = false, Message = ex.Message };
            }

        }

    }
}