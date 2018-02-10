using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adaOrderingSys.business_objects
{
    public static class Constants
    {
        // View Items Column Names
        public static string QUANTITY_COLUMN = "quantity";
        public static string ITEMID_COLUMN = "itemID";
        public static string ITEMNAME_COLUMN = "itemName";
        public static string UNITPRICE_COLUMN = "unitPrice";
        public static string TOTALCOST_COLUMN = "totalCost";
        public static string ADDITIONALS_COLUMN = "additionals";

        // Summary Form Column Names
        public static string SUMMARYID = "summaryID";
        public static string SUMMARYDATE = "summaryDate";
        public static string CREATEDBY = "createdBy";
        public static string LICENSENO = "licenseNo";
        public static string DRIVER = "driver";
        public static string LOCATION = "location";


        // Connection Strings
        public static string CONNECTIONSTRINGNAME = "ADAConnectionString";
        public static string CONNECTIONSTRING = System.Configuration.ConfigurationManager.ConnectionStrings[CONNECTIONSTRINGNAME].ConnectionString;


        //Stored Procedures

        //Loading Sheet
        public static int MAX_LOADING_SHEET_COLUMN = 40;
        public static int MAX_LINES = 60;
        public static string LOADING_SHEET_HEADER = "LOADING SHEET";
        public static string LOADING_SHEET_SPACER = "   ";
        public static string PACKER_NAME = "Packer Name: ______________";
        public static string PACKER_SIG = "Packer" + System.Environment.NewLine + "Singature: ________________";
        public static string WS_SUP_SIG = "Supervisor" + System.Environment.NewLine + "Signature: ________________";
        public static string MGMT_SIG = "Management Personnel" + System.Environment.NewLine + "Signature: ________________";
        public static string ASSIGNEE = "Assignees: ________________";

        //Messages
        public static string OUT_OF_STOCK_MSG = "Out of stock";
        public static string GENERIC_ERROR = "An error occured. Please try again";
        public static string CONTACT_SYSTEMADMIN = "An error occured. Please contact system admin";
        public static string CONFIRM_GOBACK = "Unsubmitted changes won't be saved, go back?";

        //Users
        public static string USER_ROLE_ADMIN = "Admin";
        public static string USER_ROLE_STAFF = "Staff";
        public static string DEFAULT_PASSWORD = "123456";

        //Password regex
        public static string STRONG_PASSWORD = (@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d-_$#@!*^%]{6,}$");
        public static string PASSWORD_RQMNTS = "Password must contain atleast six letters, a number and an upper case letter\n eg: Adatest1";
    }
}
