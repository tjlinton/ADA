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
        public static string userName { get; set; }
        private string password { get; set; }
        public static string userRole { get; set; }

        public User() { }

        
        public string loginUser(string uName, string pword)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[Constants.CONNECTIONSTRINGNAME].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string returnVal;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@pLoginName", uName);
                    cmd.Parameters.AddWithValue("@pPassword", pword);
                    cmd.Parameters.Add("@returnVal ", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandText = "[dbo].[uspLogin]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    con.Open();

                    returnVal = (string)cmd.ExecuteScalar();

                    if (returnVal.Equals(Constants.USER_ROLE_ADMIN)) {
                        userRole = Constants.USER_ROLE_ADMIN;
                    }
                    else
                    {
                        userRole = Constants.USER_ROLE_STAFF;
                    }

                    return returnVal;
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    return "1";
                }
            }
        }

        private string addUser(string userName, string password, string userRole)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[Constants.CONNECTIONSTRINGNAME].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string returnVal;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@pLoginName", userName);
                    cmd.Parameters.AddWithValue("@pPassword", password);
                    cmd.Parameters.AddWithValue("@puserRole", userRole);
                    cmd.Parameters.Add("@responseMessage ", SqlDbType.VarChar).Direction = ParameterDirection.Output;
                    cmd.CommandText = "[dbo].[uspLogin]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    con.Open();

                    returnVal = (string)cmd.ExecuteScalar();

                    return returnVal;
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    return "1";
                }
            }
        }
        
        private int changePassword(string uName, string newPassword)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[Constants.CONNECTIONSTRINGNAME].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    int returnVal;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@newPassword", newPassword);
                    cmd.Parameters.Add("@returnVal ", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandText = "[dbo].[usp_changeUserPassword]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    con.Open();

                    returnVal = (int)cmd.ExecuteScalar();

                    return returnVal;
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    return -1;
                }
            }
        } 

        public List<KeyValuePair<string, string>> getUsers()
        {
            List<KeyValuePair<string, string>> users = new List<KeyValuePair<string, string>>();
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[Constants.CONNECTIONSTRINGNAME].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string selectQuery = "SELECT userName, userRole from [dbo].[user]";
                    SqlCommand cmd = new SqlCommand(selectQuery,con);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            users.Add(
                                new KeyValuePair<string, string>(dr.GetString(0), dr.GetString(1))
                                );
                        }
                    }

                    return users;
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

