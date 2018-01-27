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

        public int userID { get; set; }
        public static string userName { get; set; }
        public string loginName { get; set; }
        private string password { get; set; }
        public string role { get; set; }
        public static string userRole { get; set; }

        public User() { }

        public User(int userID, string username, string role)
        {
            this.userID = userID;
            this.loginName = username;
            this.role = role;
        }

        public string loginUser(string uName, string pword)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.CONNECTIONSTRING))
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

                    if (returnVal.Equals(Constants.USER_ROLE_ADMIN))
                    {
                        userRole = Constants.USER_ROLE_ADMIN;
                    }
                    else
                    {
                        userRole = Constants.USER_ROLE_STAFF;
                    }

                    return returnVal;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.ToString);
                return "1";
            }
        }

        public string addUser(string userName, string password, string userRole)
        {
            using (SqlConnection con = new SqlConnection(Constants.CONNECTIONSTRING))
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
                    logger.Error(e.ToString);
                    return "1";
                }
            }
        }
        
        public int changePassword(string uName, string newPassword)
        {
            using (SqlConnection con = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    int returnVal;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@userName", uName);
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
                    logger.Error(e.ToString);
                    return -1;
                }
            }
        }

        public int changePassword(string uName)
        {
            using (SqlConnection con = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    int returnVal;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@userName", uName);
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
                    logger.Error(e.ToString);
                    return -1;
                }
            }
        }

        public List<User> getUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(Constants.CONNECTIONSTRING))
            {
                try
                {
                    con.Open();
                    string selectQuery = "SELECT userID, userName, userRole from [dbo].[user]";
                    SqlCommand cmd = new SqlCommand(selectQuery,con);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            users.Add(new User(dr.GetInt32(0), dr.GetString(1), dr.GetString(2))
                                );
                        }
                    }

                    return users;
                }
                catch (Exception e)
                {
                    logger.Error(e.ToString);
                    return null;
                }
            }
        }
    }
}

