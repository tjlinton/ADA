﻿using NLog;
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
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private int orderID { get; set; }
        private int custID { get; set; }
        private string custName { get; set; }
        public DateTime orderDate { get; private set; }
        private bool isFullfilled { get; set; }
        private decimal totalPrice { get; set; }
        public ItemsOrdered itemsOrdered { get; private set; }
        private int summaryID { get; set; }
        private string location { get; set; }
        private int additionals { get; set; }

        public List<KeyValuePair<int, string>> getOrdersBasedOnSummaryID(int summaryID)
        {
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    conn.Open();

                    string selectProcedure = "[dbo].[usp_CustNameBasedOnSummaryID]";
                    List<KeyValuePair<int, string>> orderDetails = new List<KeyValuePair<int, string>>();

                    SqlCommand cmd = new SqlCommand(selectProcedure, conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@summaryID", summaryID);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            orderDetails.Add(
                                new KeyValuePair<int, string>(dr.GetInt32(0), dr.GetString(1))
                                );
                        }
                    }

                    return orderDetails;
                }
                catch (Exception e)
                {
                    logger.Error(e.ToString);
                    return null;
                }
            }
        }

        public List<KeyValuePair<int, string>> getCustNameBasedOnOrderDate(DateTime orderDate)
        {
           
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    conn.Open();

                    string selectProcedure = "[dbo].[usp_CustNameBasedOnOrderDate]";
                    List<KeyValuePair<int, string>> orderDetails = new List<KeyValuePair<int, string>>();

                    SqlCommand cmd = new SqlCommand(selectProcedure, conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@year", orderDate.Year);
                    cmd.Parameters.AddWithValue("@month", orderDate.Month);
                    cmd.Parameters.AddWithValue("@day", orderDate.Day);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            orderDetails.Add(
                                new KeyValuePair<int, string>(dr.GetInt32(0), dr.GetString(1))
                                );
                        }
                    }

                    return orderDetails;
                }
                catch (Exception e)
                {
                    logger.Error(e.ToString);
                    return null;
                }
            }
        }

        public List<KeyValuePair<int, string>> getCustNameBasedOnOrderDate()
        {
           
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    conn.Open();

                    string selectProcedure = "[dbo].[usp_getUnfulfilledOrders]";
                    List<KeyValuePair<int, string>> orderDetails = new List<KeyValuePair<int, string>>();

                    SqlCommand cmd = new SqlCommand(selectProcedure, conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            orderDetails.Add(
                                new KeyValuePair<int, string>(dr.GetInt32(0), dr.GetString(1))
                                );
                        }
                    }

                    return orderDetails;
                }
                catch (Exception e)
                {
                    logger.Error(e.ToString);
                    return null;
                }
            }
        }

        public string getOrderLocation(int orderID)
        {
           
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    logger.Info("Retrieving order location");
                    conn.Open();

                    string selectProcedure = "[dbo].[usp_GetCustLocationFromOrderID]";
                    string location;

                    SqlCommand cmd = new SqlCommand(selectProcedure, conn);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    cmd.CommandType = CommandType.StoredProcedure;

                    location = Convert.ToString(cmd.ExecuteScalar());
                    logger.Info("Location successfully retrieved");
                    return location;
                }
                catch (Exception e)
                {
                    logger.Error("Could not retrieve order location: " + e);
                    return null;
                }
            }
        }

        public int getOrderSalesNo(int orderID)
        {

            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    logger.Info("Retrieving order SalesNo");
                    conn.Open();

                    string selectProcedure = "[dbo].[usp_GetSalesNumFromOrderID]";
                    int salesNo;

                    SqlCommand cmd = new SqlCommand(selectProcedure, conn);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    cmd.CommandType = CommandType.StoredProcedure;

                    salesNo = Convert.ToInt32(cmd.ExecuteScalar());
                    logger.Info("Sales Number successfully retrieved");
                    return salesNo;
                }
                catch (Exception e)
                {
                    logger.Error("Could not retrieve order location: " + e);
                    return -1;
                }
            }
        }

        public int deleteOrder(int orderID)
        {
            int returnVal;
           
            using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    logger.Info("attempting to delete order " + orderID + ".");
                    conn.Open();
                    string deleteProcedure = "[dbo].[usp_DeleteOrder]";
                    SqlCommand cmd = new SqlCommand(deleteProcedure, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@orderID", orderID);

                    returnVal = (int)cmd.ExecuteScalar();

                }
                catch (Exception e)
                {
                    returnVal = -1;
                    logger.Error(e.ToString);
                }
            }
            return returnVal;
        }



    }
}
