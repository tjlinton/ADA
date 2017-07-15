using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adaOrderingSys
{
    class item
    {
        private byte id { get; set; }
        private string name { get; set; }
        private int quantity { get; set; }
        private double price { get; set; }

        public item() { }

        public int createItem(string pID, string pName, Decimal pPrice, string pDescription, int quantity) 
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string insertProcedure = "[dbo].[usp_createItem]";
                int returnVal;

                SqlCommand cmd = new SqlCommand(insertProcedure, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@itemID", pID);
                cmd.Parameters.AddWithValue("@itemName", pName);
                cmd.Parameters.AddWithValue("@price", pPrice);
                cmd.Parameters.AddWithValue("@desc", pDescription);
                cmd.Parameters.AddWithValue("@quantity", quantity);

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

        public string getItemName(int itemID)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string selectQuery = "SELECT itemName from item where itemID = " + itemID;
                string returnVal;

                SqlCommand cmd = new SqlCommand(selectQuery, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                
                returnVal = (string)cmd.ExecuteScalar();

                return returnVal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "-1";
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

        public string getItemID(String itemName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string selectQuery = "SELECT TOP 1 itemID from item where itemName = " + itemName;
                string returnVal;

                SqlCommand cmd = new SqlCommand(selectQuery, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                returnVal = (string)cmd.ExecuteScalar();

                return returnVal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "-1";
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
    }
}
