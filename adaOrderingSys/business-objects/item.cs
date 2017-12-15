using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adaOrderingSys.business_objects;

namespace adaOrderingSys
{
    class Item
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private string id { get; set; }
        private string name { get; set; }
        private int quantity { get; set; }
        private double price { get; set; }

        public Item() { }

        public Item(int ID)
        {

        }

        public int createItem(string pID, string pName, Decimal pPrice, string pDescription, int quantity)
        {
           
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {
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

                    returnVal = (int)cmd.ExecuteScalar();
                    //returnVal = cmd.ExecuteNonQuery();

                    return returnVal;
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    return -1;
                }
            }
        }

        public string getItemName(int itemID)
        {
           
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING)) {

                try
                {
                    conn.Open();

                    string selectQuery = "SELECT itemName from item where itemID = " + itemID;
                    string returnVal;

                    SqlCommand cmd = new SqlCommand(selectQuery, conn);

                    cmd.CommandType = CommandType.Text;

                    returnVal = (string)cmd.ExecuteScalar();

                    return returnVal;
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    return "-1";
                }
            }
        }

        public string getItemID(string itemName)
        {
           
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {

                try
                {
                    conn.Open();

                    string selectQuery = "SELECT itemID from item where itemName = @itemName";
                    string returnVal;

                    SqlCommand cmd = new SqlCommand(selectQuery, conn);
                    cmd.Parameters.AddWithValue("@itemName", itemName);
                    cmd.CommandType = CommandType.Text;

                    returnVal = (string)cmd.ExecuteScalar();

                    return returnVal;
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    return "-1";
                }
            }
        }

        public double getUnitPrice(string itemID)
        {
           
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {

                try
                {
                    conn.Open();

                    string selectQuery = "SELECT price from item where itemID = @itemID";
                    Decimal returnVal;
                    double price;

                    SqlCommand cmd = new SqlCommand(selectQuery, conn);
                    cmd.Parameters.AddWithValue("@itemID", itemID);
                    cmd.CommandType = CommandType.Text;

                    returnVal = (Decimal)cmd.ExecuteScalar();

                    price = Convert.ToDouble(returnVal);

                    return price;
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    return -1;
                }
            }
        }

        public int compareQuantity(int quantity, string itemID)
        {
            try
            {
               
                using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
                {
                    conn.Open();

                    string query = "[dbo].[usp_CompareItemQuantity]";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@itemID", itemID);

                    return (Int32)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                return -2;
            }
        }

        public int compareQuantity(int quantity, string itemID, string orderID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
                {
                    conn.Open();

                    string query = "[dbo].[usp_CompareItemQuantityFromOrder]";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@itemID", itemID);
                    cmd.Parameters.AddWithValue("@orderID", Convert.ToInt32(orderID));

                    return (Int32)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                return 1;
            }
        }

        public decimal getUnitPriceOfItem(string itemID)
        {
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {

                try
                {
                    conn.Open();

                    string selectQuery = "SELECT price from item where itemID = @itemID";
                    decimal returnVal;

                    SqlCommand cmd = new SqlCommand(selectQuery, conn);
                    cmd.Parameters.AddWithValue("@itemID", itemID);
                    cmd.CommandType = CommandType.Text;

                    returnVal = (decimal)cmd.ExecuteScalar();

                    return returnVal;
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    return -1;
                }
            }
        }
    }
}
