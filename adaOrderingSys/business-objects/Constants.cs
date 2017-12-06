﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adaOrderingSys.business_objects
{
    public static class Constants
    {
        // Column Names
        public static string QUANTITY_COLUMN = "quantity";
        public static string ITEMID_COLUMN = "itemID";
        public static string ITEMNAME_COLUMN = "itemName";
        public static string UNITPRICE_COLUMN = "unitPrice";
        public static string TOTALCOST_COLUMN = "totalCost";
        public static string ADDITIONALS_COLUMN = "additionals";

        // Connection Strings
        public static string CONNECTIONSTRINGNAME = "ADAConnectionString";
        public static string CONNECTIONSTRING = System.Configuration.ConfigurationManager.ConnectionStrings[CONNECTIONSTRINGNAME].ConnectionString;


        //Stored Procedures

        //Loading Sheet
        public static int LOADING_SHEET_MAX = 100; //maximum number of lines in one loading sheet
        public static int MAX_LOADING_SHEET_COLUMN = 47;
        public static string LOADING_SHEET_HEADER = "LOADING SHEET";
        public static string LOADING_SHEET_SPACER = "   ";

        //Messages
        public static string OUT_OF_STOCK_MSG = "Out of stock";
        public static string GENERIC_ERROR = "An error occured. Please try again";

        //Users
        public static string USER_ROLE_ADMIN = "Admin";
        public static string USER_ROLE_STAFF = "Staff";
        public static string DEFAULT_PASSWORD = "123456";

        //Password regex
        public static string STRONG_PASSWORD = (@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d-_$#@!*^%]{6,}$");
        public static string PASSWORD_RQMNTS = "Password must contain atleast six letters, a number and an upper case letter\n eg: Adatest1";


    }
}
