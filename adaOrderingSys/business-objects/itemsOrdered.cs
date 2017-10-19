﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adaOrderingSys.Properties;
using NLog;

namespace adaOrderingSys.business_objects
{
    public class ItemsOrdered
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private string _itemID;
        public string itemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }

        private string _itemName;
        public string itemName
        {
            get { return _itemName; }
            set { itemName = value; }
        }

        private int _qtyOrdered;
        public int qtyOrdered
        {
            get { return _qtyOrdered; }
            set { _qtyOrdered = value; }
        }

        private int _orderID;
        public int orderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        private int _additionals;
        public int additionals
        {
            get { return _additionals; } 
            set { _additionals = value;} 
        }

        private decimal _totalPrice;
        public decimal totalPrice
        {
            get { return _totalPrice;}
            set { _totalPrice = value; }
        }

        public ItemsOrdered() { }

        public ItemsOrdered(string itemID, int orderID, int qtyOrdered, int additionals)
        {
            this._orderID = orderID;
            this._qtyOrdered = qtyOrdered;
            this._itemID = itemID;
            this._additionals = additionals;
        }

        public ItemsOrdered(string itemID, string itemName, int quantity, decimal totalPrice, int additionals) {
            this._itemID = itemID;
            this._itemName = itemName;
            this._totalPrice = totalPrice;
            this._qtyOrdered = quantity;
            this._additionals = additionals;
        }
            
        // public int insertItemsOrdered(int orderID, List<string> itemID)
        //{
        //    var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();

        //            string insertQuery = "INSERT INTO [dbo].[ordered_Items]  ([orderID], [itemID]) VALUES";
        //            string values = "";

        //            foreach (var i in itemID) {
        //                values += String.Format("({0},{1}),", orderID, i); 
        //            }
        //            // Trim Trailing comma from query
        //            values.TrimEnd(',');
        //            insertQuery += values;

        //            SqlCommand cmd = new SqlCommand(insertQuery, conn);

        //            cmd.CommandType = CommandType.Text;

        //            int returnVal = (Int32)cmd.ExecuteNonQuery();

        //            return returnVal;
        //        }
        //        catch (Exception e)
        //        {
        //            logger.Error(e);
        //            return -1;
        //        }
        //    }
        //}

        //public List<item> getItemsOrdered(int orderID)
        //{
        //    var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();

        //            string selectQuery = "SELECT * FROM [dbo].[ordered_Items] WHERE [orderID] = " + orderID;
        //            string values = "";

        //            foreach (var i in itemID) {
        //                values += String.Format("({0},{1}),", orderID, i); 
        //            }
        //            // Trim Trailing comma from query
        //            values.TrimEnd(',');
        //            insertQuery += values;

        //            SqlCommand cmd = new SqlCommand(selectQuery, conn);

        //            cmd.CommandType = CommandType.Text;

        //            int returnVal = (Int32)cmd.ExecuteNonQuery();

        //            return returnVal;
        //        }
        //        catch (Exception e)
        //        {
        //            logger.Error(e);
        //            return -1;
        //        }
        //    }
        //    return new List<item>();
        //}

        public int insertItemsOrdered(int custID, List<string>itemID, List<int>quantity, List<decimal>totalItemCost, Decimal totalCost, string location, List<int> additionals, int salesNo, int rowCount)
        {
            int orderID;
            var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                logger.Info("Attempting to create new order.");
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    
                    string createOrderProc = "[dbo].[usp_createOrder]";
                    string insertProcedure = "[dbo].[usp_addItemsOnOrder]";
                    string updateQuery = "[dbo].[usp_UpdateItemQuantity]";

                    SqlCommand insertCmd = new SqlCommand(insertProcedure, conn, transaction);
                    SqlCommand createOrderCmd = new SqlCommand(createOrderProc, conn, transaction);
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);

                    insertCmd.CommandType = CommandType.StoredProcedure;
                    createOrderCmd.CommandType = CommandType.StoredProcedure;
                    updateCmd.CommandType = CommandType.StoredProcedure;

                    createOrderCmd.Parameters.AddWithValue("@custID", custID);
                    createOrderCmd.Parameters.AddWithValue("@totalPrice", totalCost);
                    createOrderCmd.Parameters.AddWithValue("@location", location);
                    if (salesNo > 0)
                    {
                        createOrderCmd.Parameters.AddWithValue("@salesNo", salesNo);
                    }

                    orderID = (int)createOrderCmd.ExecuteScalar();

                    if (orderID < 0)
                    {
                        throw new Exception("Error occured. Oder could not be created.");
                    }

                    logger.Info("Created order: " + orderID);

                    int insertReturnedVal = 0, updateReturnedVal = 0, insertedRowCount = 0;

                    for (int i = 0; i < rowCount; i++)
                    {
                        insertCmd.Parameters.AddWithValue("@itemID", itemID[i]);
                        insertCmd.Parameters.AddWithValue("@orderID", orderID);
                        insertCmd.Parameters.AddWithValue("@quantity", quantity[i]);
                        insertCmd.Parameters.AddWithValue("@totalCost", totalItemCost[i]);
                        insertCmd.Parameters.AddWithValue("@additionals",additionals[i]);


                        updateCmd.Parameters.AddWithValue("@quantity", quantity[i]);
                        updateCmd.Parameters.AddWithValue("@itemID", itemID[i]);

                        insertReturnedVal = (Int32)insertCmd.ExecuteScalar(); //If insert was successful, 1 should be returned
                        updateReturnedVal = (Int32)updateCmd.ExecuteScalar();

                        if (insertReturnedVal < 0 || updateReturnedVal < 0)
                        {
                            throw new Exception("An error occured inside database. Please try again.");
                        }

                        insertedRowCount += insertReturnedVal; // Count the rows that were inserted

                        insertCmd.Parameters.Clear();
                        updateCmd.Parameters.Clear();

                    }
                    
                    //The rows we expected to insert and the rows actually inserted should be the same
                    if (rowCount != insertedRowCount)
                    {
                        throw new Exception("Not all rows were inserted in database. Please try again.");
                    }

                    transaction.Commit();
                    logger.Info("New orderd created successfully with ID " + orderID);
                    return 0; 
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    try
                    {
                        transaction.Rollback();
                        return -1;
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.

                        logger.Info("Rollback Exception Type: {0}", ex2.GetType());
                        logger.Error("  Message: {0}", ex2.Message);

                        return -2;
                    }
                }
            }
        }

        public List<KeyValuePair<int, string>> getOrderedItemNameAndQuantity(int orderID)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string selectProcedure = "[dbo].[usp_OrderedItemsAndQuantity]";
                    List<KeyValuePair<int, string>> orderDetails = new List<KeyValuePair<int, string>>();

                    SqlCommand cmd = new SqlCommand(selectProcedure, conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@orderID", orderID);

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
                    logger.Error(e);
                    return null;
                }
            }
        }

        public List<ItemsOrdered> getItemsOrderedBasedonOrderID(int orderID)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string selectProcedure = "[dbo].[usp_GetOrderedItemsFromOrderID]";
                   List<ItemsOrdered> itemsOrdered = new List<ItemsOrdered>();

                    SqlCommand cmd = new SqlCommand(selectProcedure, conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@orderID", orderID);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            itemsOrdered.Add(new ItemsOrdered(
                                dr.GetString(0), 
                                dr.GetString(1),
                                dr.GetInt32(2),
                                dr.GetDecimal(3),
                                dr.GetInt32(4)
                                ));
                        }
                    }
                    return itemsOrdered;
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    return null;
                }
            } 
        }
    }
}
