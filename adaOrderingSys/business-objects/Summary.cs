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
    class Summary
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public int summaryID { get; private set; }
        private List<Order> orders { get; set; }
        private DateTime date { get; set; }

        public int fulfillOrders(List<int> orderID, string licNo, string driver, DateTime date)
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

                    createSummaryCmd.Parameters.AddWithValue("@licenseNo", licNo);
                    createSummaryCmd.Parameters.AddWithValue("@driver", driver);
                    createSummaryCmd.Parameters.AddWithValue("@summaryDate", date);
                    

                    int summaryID = (int)createSummaryCmd.ExecuteScalar();

                    if (summaryID <= 0) //Once a summary is created in the db, the ID is more than 0
                    {
                        throw new Exception(Constants.CONTACT_SYSTEMADMIN);
                    }

                    int updateReturnedVal = 0;
                    int listSize = orderID.Count;
                    for (int i = 0; i < listSize; i++)
                    {
                        updateCmd.Parameters.AddWithValue("@orderID", orderID[i]);
                        updateCmd.Parameters.AddWithValue("@summaryID", summaryID);
                        updateReturnedVal = (Int32)updateCmd.ExecuteScalar();

                        if (updateReturnedVal <= 0)
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
                    logger.Error(ex);
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
    }
}
