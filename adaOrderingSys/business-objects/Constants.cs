using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //Stored Procedures


        //Loading Sheet
        public static int LOADING_SHEET_MAX = 100; //maximum number of lines in one loading sheet
        public static int MAX_LOADING_SHEET_COLUMN = 47;
        public static string LOADING_SHEET_HEADER = "LOADING SHEET";
        public static string LOADING_SHEET_SPACER = "   ";

        //Messages
        public static string OUT_OF_STOCK_MSG = "Out of stock";
        public static string GENERIC_ERROR = "An error occured. Please try again";
    }
}
