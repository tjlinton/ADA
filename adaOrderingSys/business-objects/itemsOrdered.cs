using System;
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
    class ItemsOrdered
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private int itemID { get; set; }
        private int orderID { get; set; }

        public ItemsOrdered() { }

        public int insertItemsOrdered(int orderID, List<int> itemID)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO [dbo].[ordered_Items]  ([orderID], [itemID]) VALUES";
                    string values = "";

                    foreach (var i in itemID) {
                        values += String.Format("({0},{1}),", orderID, i); 
                    }
                    // Trim Trailing comma from query
                    values.TrimEnd(',');
                    insertQuery += values;
 
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);

                    cmd.CommandType = CommandType.Text;

                    int returnVal = (Int32)cmd.ExecuteNonQuery();

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
