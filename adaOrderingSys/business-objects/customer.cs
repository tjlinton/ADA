using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NLog;

namespace adaOrderingSys.business_objects
{
    class customer
    {
 
        private byte custID { get; set; }
        private string name  { get; set; }
        private string address  { get; set; }
        private string telephone  { get; set; } 
        private string contactPerson  { get; set; }

        public customer() { }

        public int createCustomer(string n, string a, string t, string cP)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string insertProcedure = "[dbo].[usp_AddCustomer]";
                int returnVal;

                SqlCommand cmd = new SqlCommand(insertProcedure, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", n);
                cmd.Parameters.AddWithValue("@address", a);
                cmd.Parameters.AddWithValue("@telephone",t);
                cmd.Parameters.AddWithValue("@contactPerson", cP);

                returnVal = (Int32)cmd.ExecuteScalar();

                return returnVal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return -1;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public string editCustInfo() 
        {
            return "";
        }
    }
}
