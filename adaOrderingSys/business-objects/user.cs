using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adaOrderingSys.business_objects
{
    class User
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private int userID { get; set; }
        private string userName { get; set; }
        private string password { get; set; }
        private string userRole { get; set; }

        public User() { }

        public int loginUser(string uName, string pword)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            int returnVal;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@pLoginName", uName);
                cmd.Parameters.AddWithValue("@pPassword", pword);
                cmd.Parameters.Add("@returnVal ", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandText = "[dbo].[uspLogin]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                con.Open();

                returnVal = (int)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                logger.Error(e);
                returnVal = 1;
            }

            finally
            {
                con.Close();
                con.Dispose();
            }
            return returnVal;
        }
    }
}

