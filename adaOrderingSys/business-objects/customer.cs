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
    class Customer
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private byte custID { get; set; }
        private string name { get; set; }
        private string address { get; set; }
        private string telephone { get; set; }
        private string contactPerson { get; set; }

        public Customer() { }

        public int createCustomer(string n, string a, string t, string cP)
        {
           
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    conn.Open();

                    string insertProcedure = "[dbo].[usp_AddCustomer]";
                    int returnVal;

                    SqlCommand cmd = new SqlCommand(insertProcedure, conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", n);
                    cmd.Parameters.AddWithValue("@address", a);
                    cmd.Parameters.AddWithValue("@telephone", t);
                    cmd.Parameters.AddWithValue("@contactPerson", cP);

                    returnVal = (Int32)cmd.ExecuteScalar();

                    return returnVal;
                }
                catch (Exception e)
                {
                    logger.Error(e.ToString);

                    return -1;
                }

            }
        }

        public List<string> getCustomerNames()
        {
           
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    logger.Info("Getting customer names");
                    conn.Open();

                    string selectProcedure = "SELECT custName FROM [dbo].[customer] ORDER BY [custName] asc";
                    List<string> customers = new List<string>();

                    SqlCommand cmd = new SqlCommand(selectProcedure, conn);

                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            customers.Add(dr.GetString(0));
                        }
                    }
                    logger.Info("Names successfully receieved");
                    return customers;
                }
                catch (Exception e)
                {
                    logger.Error(e.ToString);
                    return null;
                }
            }
        }

        public string editCustInfo()
        {
            return "";
        }

        public string getCustomerLocation(int custID)
        {
           
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    conn.Open();

                    string insertProcedure = "SELECT [custAddress] from customer where custID = @custID";

                    SqlCommand cmd = new SqlCommand(insertProcedure, conn);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@custID", custID);

                    string location = cmd.ExecuteScalar().ToString();
                    return location;
                }
                catch (Exception e)
                {
                    logger.Error(e.ToString);

                    return "";
                }
            }
        }
    }
}
