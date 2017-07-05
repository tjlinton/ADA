using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adaOrderingSys.business_objects
{
    class Order
    {
        private int orderID { get; set; }
        private int custID { get; set; }
        private string truckNo { get; set; }
        private bool isFulfilled {get; set;}

        public Order() { }

        public int insertOrder(int custID, string tNo, bool isFulfilled )
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string insertProcedure = "[dbo].[usp_createOrder]";
                int returnVal;

                SqlCommand cmd = new SqlCommand(insertProcedure, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@custID", custID);
                cmd.Parameters.AddWithValue("@truckNo", tNo);
                cmd.Parameters.AddWithValue("@isFulFilled", isFulfilled);

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
                    // cleanup
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}
