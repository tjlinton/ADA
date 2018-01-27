using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adaOrderingSys.business_objects;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace adaOrderingSys.business_objects
{
    public class Summary
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public int summaryID { get; private set; }
        private List<Order> orders { get; set; }
        private DateTime date { get; set; }
        private string driver { get; set; }
        private string createdBy { get; set; }

        private string licenseNo { get; set; }
        private string location { get; set; }

        public Summary() { }

        public Summary(int id, DateTime date, string driver, string createdBy, string licenseNo, string location)
        {
            this.summaryID = id;
            this.date = date;
            this.driver = driver;
            this.location = location;
            this.createdBy = createdBy;
            this.licenseNo = licenseNo;
        }
        public int fulfillOrders(List<int> orderID, string licNo, string driver, DateTime date, string location, string createdBy)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
                {
                    conn.Open();

                    SqlTransaction transaction = conn.BeginTransaction(); //Start the transaction
                    try
                    {
                        string createSummaryQuery = "[dbo].[usp_createSummary]";
                        string updateQuery = "[dbo].[usp_fulfillOrders]";

                        SqlCommand createSummaryCmd = new SqlCommand(createSummaryQuery, conn, transaction);
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);

                        createSummaryCmd.CommandType = CommandType.StoredProcedure;
                        updateCmd.CommandType = CommandType.StoredProcedure;

                        // Specify all stored procedure parameters - createSummary
                        createSummaryCmd.Parameters.AddWithValue("@licenseNo", licNo);
                        createSummaryCmd.Parameters.AddWithValue("@driver", driver);
                        createSummaryCmd.Parameters.AddWithValue("@summaryDate", date);
                        createSummaryCmd.Parameters.AddWithValue("@createdBy", createdBy);
                        createSummaryCmd.Parameters.AddWithValue("@location", location);


                        int summaryID = (int)createSummaryCmd.ExecuteScalar();

                        if (summaryID <= 0) //Once a summary is created in the db, the ID is more than 0
                        {
                            throw new Exception(Constants.CONTACT_SYSTEMADMIN);
                        }

                        int updateReturnedVal = 0;
                        int listSize = orderID.Count;
                        for (int i = 0; i < listSize; i++)
                        {
                            // Specify all stored procedure parameters - Fullfill orders
                            updateCmd.Parameters.AddWithValue("@orderID", orderID[i]);
                            updateCmd.Parameters.AddWithValue("@summaryID", summaryID);
                            updateReturnedVal = (Int32)updateCmd.ExecuteScalar();

                            if (updateReturnedVal <= 0) // Number of rows affected should be returned. Can't be equal or less than zero
                            {
                                throw new Exception("An error occured inside database");
                            }
                            updateCmd.Parameters.Clear();

                        }

                        transaction.Commit();

                        return 0;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString);
                        try
                        {
                            transaction.Rollback(); //Rollback the transaction
                            logger.Info("Rollback successful");
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
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                return -2;
            }
        }

        public int fulfillOrders(int summaryID, List<int> orderID, string licNo, string driver, DateTime date, string location, string createdBy)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
                {
                    conn.Open();

                    SqlTransaction transaction = conn.BeginTransaction(); //Start the transaction
                    try
                    {
                        string updateQuery = "[dbo].[usp_fulfillOrders]";

                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);

                        updateCmd.CommandType = CommandType.StoredProcedure;

                        if (summaryID <= 0) //Once a summary is created in the db, the ID is more than 0
                        {
                            throw new Exception("Summary ID can't be zero or less");
                        }

                        int updateReturnedVal = 0;
                        int listSize = orderID.Count;
                        for (int i = 0; i < listSize; i++)
                        {
                            // Specify all stored procedure parameters - Fullfill orders
                            updateCmd.Parameters.AddWithValue("@orderID", orderID[i]);
                            updateCmd.Parameters.AddWithValue("@summaryID", summaryID);
                            updateReturnedVal = (Int32)updateCmd.ExecuteScalar();

                            if (updateReturnedVal <= 0) // Number of rows affected should be returned. Can't be equal or less than zero
                            {
                                throw new Exception("An error occured inside database");
                            }
                            updateCmd.Parameters.Clear();

                        }

                        transaction.Commit();

                        return 0;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString);
                        try
                        {
                            transaction.Rollback(); //Rollback the transaction
                            logger.Info("Rollback successful");
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
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                return -2;
            }
        }

        public int unfulfillOrders(List<int> orderIDs)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
                {
                    conn.Open();

                    string updateQuery = "Update [dbo].[order] SET summaryID = NULL, isFullFilled = 0 WHERE";

                    foreach (int id in orderIDs)
                    {
                        updateQuery += " orderID = " + id + " AND";
                    }

                    updateQuery = updateQuery.Substring(0, updateQuery.Length - 4); //Remove trailing " AND" 

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.CommandType = CommandType.Text;

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                return -1;
            }

        }
    }
}
