using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using adaOrderingSys.business_objects;
using NLog;

namespace adaOrderingSys
{
    public partial class AddNewItem : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public List<string> addedItems = new List<string>();
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[Constants.CONNECTIONSTRINGNAME].ConnectionString;
        public static string itemID;
        public ViewOrders viewOrders { get; set; }

        public AddNewItem(ViewOrders viewOrders, List<string> addedItems)
        {
            this.viewOrders = viewOrders;
            InitializeComponent();
            this.addedItems = addedItems;

            //Bind the Drop Down List to a Datasource
            //ddlItemName.DataSource = null;
            ddlItemName.DisplayMember = "Value";
            ddlItemName.ValueMember = "Key";
            ddlItemName.DataSource = new BindingSource(getDDLItems(addedItems), null);
            ddlItemName.SelectedIndex = -1;
            enableItems(false);

        }

        public AddNewItem()
        {
            InitializeComponent();
        }

        public List<KeyValuePair<string, string>> getDDLItems(List<string> items)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
                {

                    conn.Open();
                    string selectProcedure = "SELECT itemID, itemName from item where ";

                    foreach (string itemID in items)
                    {
                        selectProcedure += "itemID != '" + itemID + "' AND ";
                    }

                    selectProcedure = selectProcedure.Substring(0, selectProcedure.Length - 4);
                    List<KeyValuePair<string, string>> newItems = new List<KeyValuePair<string, string>>();

                    SqlCommand cmd = new SqlCommand(selectProcedure, conn);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            newItems.Add(
                                new KeyValuePair<string, string>(dr.GetString(0), dr.GetString(1))
                                );
                        }
                    }

                    return newItems;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.ToString);
                return null;
            }

        }

        private void num_Quantity_ValueChanged(object sender, EventArgs e)
        {
            validateQuantity(num_Quantity);
        }

        public void validateQuantity(Control control)
        {
            if (num_Quantity.Value != 0)
            {
                int quantity = Convert.ToInt32(num_Quantity.Value) + Convert.ToInt32(num_Additionals.Value);
                errorProvider1.SetError(control, "");
                int result = compareQuantity(Convert.ToInt32(quantity));

                if (quantity == -2)
                {
                    MessageBox.Show("Error occured. Quantity can't be changed");
                    return;
                }

                if (result > -1)
                {
                    errorProvider1.SetError(control, "Only " + result + " remaining");
                    return;
                }

                if (quantity == result)
                {
                    errorProvider1.SetError(num_Quantity, "Out of stock");
                }
            }
            else
            {
                errorProvider1.SetError(num_Quantity, "Quantity can't be zero");
            }
        }

        public int compareQuantity(int quantity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING))
                {
                    conn.Open();

                    string query = "[dbo].[usp_CompareItemQuantity]";

                    string itemID = ddlItemName.SelectedValue.ToString();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@itemID", itemID);

                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.ToString);
                return -2;
            }
        }

        private void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlItemName.SelectedIndex != -1 && ddlItemName.DataSource != null)
            {
                lbl_UnitPrice.Text = new Item().getUnitPriceOfItem(ddlItemName.SelectedValue.ToString()).ToString();
                enableItems(true);
            }
        }

        private void enableItems(bool enabled)
        {
            num_Additionals.Enabled = enabled;
            num_Quantity.Enabled = enabled;
            num_SalesNo.Enabled = enabled;
        }

        private void num_Additionals_ValueChanged(object sender, EventArgs e)
        {
            validateQuantity(num_Additionals);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string itemID = ddlItemName.SelectedValue.ToString(),
                        itemName = ddlItemName.Text.ToString();

                int quantity = Convert.ToInt32(num_Quantity.Value),
                        additions = Convert.ToInt32(num_Additionals.Value);
                decimal unitPrice = Convert.ToDecimal(lbl_UnitPrice.Text),
                        totalCost = quantity * unitPrice;

                this.viewOrders.dt.Rows.Add(itemID, itemName, quantity, unitPrice, totalCost, additions);
                this.viewOrders.setInsertCmd(itemID, quantity, additions, totalCost);
                this.Close();
            }

            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show(Constants.GENERIC_ERROR);
            }
        }

        private void AddNewItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
