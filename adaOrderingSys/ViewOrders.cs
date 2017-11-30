using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using adaOrderingSys.business_objects;
using NLog;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace adaOrderingSys
{
    public partial class ViewOrders : Form
    {
        private SqlDataAdapter adapter { get; set; }
        private DataSet ds { get; set; }
        private DataTable dt { get; set; }
        private SqlCommandBuilder cmbdbldr;

        private static string connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        //Constructor
        public ViewOrders()
        {
            adapter = new SqlDataAdapter();
            dt = new DataTable();
            ds = new DataSet();
            InitializeComponent();
            this.dateTimePicker1.Value = DateTime.Now;
            setItems();
        }

        /*******************************************************************
         *                  CLICK EVENTS
         *********************************************************************/

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to go back?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                main mainForm = new main();
                mainForm.Show();
            }
            
        }
        private void list_Orders_DoubleClick(object sender, EventArgs e)
        {
            if (this.list_Orders.SelectedIndex != -1)
            {
                try
                {
                    string[] order = this.list_Orders.SelectedItem.ToString().Split('|'); // Split id from customer name
                    int orderID = Convert.ToInt32(order[0]);
                    string customer = order[1].ToString().Trim();
                    string location = new Order().getOrderLocation(orderID);
                    List<string> customers = new Customer().getCustomerNames(); // Get all customers to bind combobox to
                    double grandTotal = 0.0;

                    //Set the orderID on the form
                    lbl_OrderID.Text = orderID.ToString();

                    //validate customers and location
                    if (customers == null || !customers.Any() || location == null)
                    {
                        MessageBox.Show("Something went wrong. Please contact system admin.");
                        return;
                    }

                    // Customer Combobox binding
                    this.cb_Customer.DataSource = null;
                    this.cb_Customer.Items.Clear();
                    BindingSource bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = customers;
                    this.cb_Customer.DataSource = bindingSource1.DataSource;
                    this.cb_Customer.DisplayMember = bindingSource1.DataMember;
                    this.cb_Customer.ValueMember = bindingSource1.DataMember;
                    this.cb_Customer.SelectedIndex = this.cb_Customer.Items.IndexOf(customer);

                    this.rtxtLocation.Text = location;

                    // Clear grandtotals
                    this.txtGrandTotal.Text = "";

                    dgvItemsOrdered.DataSource = null;

                    populateDataTable(orderID);

                    dgvItemsOrdered.DataSource = dt;

                    foreach (DataGridViewRow row in dgvItemsOrdered.Rows)
                    {
                        grandTotal += Convert.ToDouble(row.Cells[Constants.TOTALCOST_COLUMN].Value);
                    }

                    this.dgvItemsOrdered.Columns[Constants.TOTALCOST_COLUMN].ReadOnly = true;

                    txtGrandTotal.Text = grandTotal.ToString();
                    ViewOrdersToolTip.RemoveAll();
                }

                catch (Exception ex)
                {
                    this.logger.Error(ex);
                    MessageBox.Show("An error occured displaying the items for the selected order.");
                    return;
                }
            }
        }

        private void btn_UpdateOrder_Click(object sender, EventArgs e)
        {
            if (adapter.DeleteCommand == null && adapter.UpdateCommand == null && adapter.InsertCommand == null) {
                if (lbl_OrderID.Text != null)
                {
                    if (dgvItemsOrdered.Rows.Count > 1)
                    {
                        try
                        {
                            if (adapter != null)
                            {
                                cmbdbldr = new SqlCommandBuilder(adapter);
                                adapter.Update(dt);
                            }

                            logger.Info("Updated order " + lbl_OrderID.Text);
                            MessageBox.Show("Update successful");

                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex);
                            MessageBox.Show("Something went wrong, we could not update this order");
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Table is empty, do you wish to delete this order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            deleteOrder();
                        }

                        return;
                    }
                }
            }
        }

        private void btn_DeleteOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this order?", 
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                deleteOrder();
            }
        }

        /***********************************************************************
         *                      Other Control EVENTS
         ***********************************************************************/

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            clearControls(); //Empty previous values
            setItems(); //Set the new ones based on date picked
            ViewOrdersToolTip.RemoveAll();
        }
        private void dgvItemsOrdered_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
            setGrandTotal();
        }

        private void dgvItemsOrdered_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            String column = "";
            try
            {
                string changedValue;
                int totalQuantity=0, quantity;
                string itemID = dgvItemsOrdered.Rows[e.RowIndex].Cells[Constants.ITEMID_COLUMN].Value.ToString();

                if (e.ColumnIndex == dgvItemsOrdered.Columns[Constants.QUANTITY_COLUMN].Index)
                {
                    column = Constants.QUANTITY_COLUMN;
                    changedValue = dgvItemsOrdered.Rows[e.RowIndex].Cells[Constants.QUANTITY_COLUMN].Value.ToString();
                    totalQuantity = Convert.ToInt32(changedValue);
                }
                else if (e.ColumnIndex == this.dgvItemsOrdered.Columns[Constants.ADDITIONALS_COLUMN].Index)
                {
                    column = Constants.ADDITIONALS_COLUMN;
                    changedValue = dgvItemsOrdered.Rows[e.RowIndex].Cells[Constants.ADDITIONALS_COLUMN].Value.ToString();
                    int  cellValue = Convert.ToInt32(changedValue);
                    totalQuantity = cellValue +  Convert.ToInt32(dgvItemsOrdered.Rows[e.RowIndex].Cells[Constants.QUANTITY_COLUMN].Value);
                }

                if (column != "")
                {
                    quantity = new Item().compareQuantity(totalQuantity, dgvItemsOrdered.Rows[e.RowIndex].Cells[Constants.ITEMID_COLUMN].Value.ToString(), lbl_OrderID.Text);

                    //Check if the amount entered is enough. If a number less than zero is returned then that indicates the amount exceeded
                    if (quantity < 0)
                    {
                        // Add the exceeded amount (which will be a negative number) to the quantity entered.
                        // This gives you the amount remaining
                        dgvItemsOrdered.Rows[e.RowIndex].Cells[column].ErrorText = "Only " + (quantity + totalQuantity) + " remaining.";
                        return;
                    }

                    dgvItemsOrdered.Rows[e.RowIndex].Cells[column].ErrorText = "";
                    setUpdateCmd(e, column, itemID);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("An unexpected error occured.");
            }
        }

        private void btn_UpdateOrder_MouseHover(object sender, EventArgs e)
        {
            ViewOrdersToolTip.Show("Update order with your changes", btn_UpdateOrder);
        }

        private void dgvItemsOrdered_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Console.Write("Got here");
        }

        private void dgvItemsOrdered_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        /// ------------------------------------------------------------------------------------------
        /// Custom Functions
        /// ------------------------------------------------------------------------------------------
        private void setItems()
        {
            List<KeyValuePair<int, string>> listItems = new Order().getCustNameBasedOnOrderDate(dateTimePicker1.Value);

            list_Orders.Items.Clear();
            if (listItems != null && listItems.Count != 0)
            {
                foreach (KeyValuePair<int, string> item in listItems)
                {
                    string value = item.Key + " | " + item.Value;
                    list_Orders.Items.Add(value);
                }
            }
        }

        private void setUpdateCmd(DataGridViewCellEventArgs e, String column, string itemID)
        {
            try
            {
                if (e.ColumnIndex == this.dgvItemsOrdered.Columns[column].Index)
                {
                    string cellValue = dgvItemsOrdered.Rows[e.RowIndex].Cells[column].Value.ToString();

                    string pattern = @"\d+";
                    Regex r = new Regex(pattern, RegexOptions.IgnoreCase);

                    Match m = r.Match(cellValue);

                    if (!m.Success)
                    {
                        this.dgvItemsOrdered.Rows[e.RowIndex].Cells[column].Value = "";
                        this.dgvItemsOrdered.Rows[e.RowIndex].Cells[column].Selected = true;
                        MessageBox.Show("Value must be a number");
                        return;
                    }

                    if (column.Equals(Constants.QUANTITY_COLUMN))
                    {
                        if (Convert.ToInt32(cellValue) <= 0)
                        {
                            this.dgvItemsOrdered.Rows[e.ColumnIndex].Cells[Constants.QUANTITY_COLUMN].Selected = true;
                            MessageBox.Show("quantity cannot be less than or equal to zero.");
                            return;
                        }

                        decimal unitPrice = Convert.ToDecimal(dgvItemsOrdered.Rows[e.RowIndex].Cells[Constants.UNITPRICE_COLUMN].Value);
                        decimal totalPrice = unitPrice * Convert.ToInt32(dgvItemsOrdered.Rows[e.RowIndex].Cells[Constants.QUANTITY_COLUMN].Value);

                        //Open column for editing
                        dgvItemsOrdered.Columns[Constants.TOTALCOST_COLUMN].ReadOnly = false;
                        dgvItemsOrdered.Rows[e.RowIndex].Cells[Constants.TOTALCOST_COLUMN].Value = totalPrice;
                        dgvItemsOrdered.Columns[Constants.TOTALCOST_COLUMN].ReadOnly = true; // Close it, we don't want users to input values
                    }

                    decimal totalCost = Convert.ToDecimal(dgvItemsOrdered.Rows[e.RowIndex].Cells[Constants.TOTALCOST_COLUMN].Value);

                    SqlCommand cmd = new SqlCommand(@"UPDATE ordered_Items SET " + column + " = @" + column + ", totalCost = @totalCost WHERE orderID = @orderID AND itemID = @itemID", conn);
                    cmd.Parameters.AddWithValue("@itemID", itemID);
                    cmd.Parameters.AddWithValue("@" + column, cellValue);
                    cmd.Parameters.AddWithValue("@totalCost", totalCost);
                    cmd.Parameters.AddWithValue("@orderID", lbl_OrderID.Text);

                    adapter.UpdateCommand = cmd;

                    setGrandTotal();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(Constants.GENERIC_ERROR);
            }
        }

        private void setDeleteCmd(string itemID, int orderID)
        { 
            try
            {
                SqlCommand cmd = new SqlCommand(@"DELETE FROM ordered_Items WHERE orderID = @orderID and itemID = @itemID",conn);
                cmd.Parameters.AddWithValue("orderID", orderID);
                cmd.Parameters.AddWithValue("itemID", itemID);

                adapter.DeleteCommand = cmd;

                dt.AcceptChanges();
                adapter.Fill(dt);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.GENERIC_ERROR);
                logger.Error(ex);
            }
        } 

        private DataTable populateDataTable(int orderID)
        {
            try
            {
                dt = new DataTable();
                //Create the datable columns in accordance to what is in the table in the db
                dt.Columns.Add(Constants.ITEMID_COLUMN, typeof(string)).ReadOnly = true;
                dt.Columns.Add(Constants.ITEMNAME_COLUMN, typeof(string)).ReadOnly = true;
                dt.Columns.Add(Constants.QUANTITY_COLUMN, typeof(int));
                dt.Columns.Add(Constants.UNITPRICE_COLUMN, typeof(decimal)).ReadOnly = true;
                dt.Columns.Add(Constants.TOTALCOST_COLUMN, typeof(decimal));
                dt.Columns.Add(Constants.ADDITIONALS_COLUMN, typeof(int));

                dt.PrimaryKey = new DataColumn[] { dt.Columns[Constants.ITEMID_COLUMN] };

                SqlCommand cmd = new SqlCommand("[dbo].[usp_GetOrderedItemsWithUPFromOrderID]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderID", orderID);
                adapter.SelectCommand = cmd;

                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        private void deleteOrder()
        {
            if (!lbl_OrderID.Text.Equals(""))
            {
                try
                {
                    int orderID = Convert.ToInt32(lbl_OrderID.Text);

                    //Call the delete stored procedure from the order business class
                    int deleteResult = new Order().deleteOrder(orderID);

                    switch (deleteResult)
                    {
                        case 0: //If zero was returned, then order wasnt found
                            MessageBox.Show("Order could not be found. try again");
                            break;

                        case -1: //Sql Error occured while deleteing. rollback was successful
                            MessageBox.Show("Could not delete order. Try again");
                            break;

                        case -2: //Error occured and rollback was unsuccessful
                            MessageBox.Show("A critical error occured. Please contact system admin.");
                            break;

                        default: //Rowcount will be returned if order was successful. This could be any positive integer
                            logger.Info("Order successfully deleted");
                            clearControls(); // Empty out all relevant controls
                            setItems(); //Reset listbox items for order selection
                            MessageBox.Show("Order successfully deleted");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    MessageBox.Show("An error occured. Please Try again");
                }
            }
            else
            {
                MessageBox.Show("Please select an order to delete by double clicking an order");
            }
        }

        private void setGrandTotal()
        {
            double grandTotal = 0;
            foreach (DataGridViewRow row in dgvItemsOrdered.Rows)
            {
                grandTotal += Convert.ToDouble(row.Cells["totalCost"].Value);
            }

            txtGrandTotal.Text = grandTotal == 0 ? "" : grandTotal.ToString();
        }

        void clearControls()
        {
            cb_Customer.DataSource = null; ;
            rtxtLocation.Text = "";
            dgvItemsOrdered.DataSource = null;
            lbl_OrderID.Text = null;
            txtGrandTotal.Text = null;
        }

        private bool HasErrorText()
        {
            bool hasErrorText = false;
            foreach (DataGridViewRow row in this.dgvItemsOrdered.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ErrorText.Length > 0)
                    {
                        hasErrorText = true;
                        break;
                    }
                }
                if (hasErrorText)
                    break;
            }

            return hasErrorText;
        }

        private void dgvItemsOrdered_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string column;
            if (e.ColumnIndex == dgvItemsOrdered.Columns[Constants.QUANTITY_COLUMN].Index)
            {
                column = Constants.QUANTITY_COLUMN;
            }
            else if (e.ColumnIndex == dgvItemsOrdered.Columns[Constants.ADDITIONALS_COLUMN].Index)
            {
                column = Constants.ADDITIONALS_COLUMN;
            }
            else { return; }

            dgvItemsOrdered.Rows[e.RowIndex].Cells[column].Selected = true;
            //dgvItemsOrdered.Rows[e.RowIndex].Cells[column].ErrorText = "Value must be a number";
            MessageBox.Show("Value must be a whole number");
            //e.Cancel = true;
            return;
        }

        private void dgvItemsOrdered_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void dgvItemsOrdered_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvItemsOrdered.Rows.Count > 1)
            {
                try
                {
                    string itemID = dgvItemsOrdered.Rows[e.Row.Index].Cells[Constants.ITEMID_COLUMN].Value.ToString();
                    int orderID = Convert.ToInt32(lbl_OrderID.Text);
                    setDeleteCmd(itemID, orderID);

                    logger.Info("Successfully deleted " + itemID);
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            else
            {
                if (MessageBox.Show("Table is empty, do you wish to delete this order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    deleteOrder();
                }

                return;
            }
        }

        private void cb_Customer_MouseHover(object sender, EventArgs e)
        {
            if (cb_Customer.Items.Count == 0)
            {
                ViewOrdersToolTip.SetToolTip(cb_Customer, "Double click an order on the left first");
            }
        }

        private void list_Orders_MouseHover(object sender, EventArgs e)
        {
            if (list_Orders.Items.Count == 0)
            {
                ViewOrdersToolTip.SetToolTip(list_Orders, "No orders found on this date, change date to see orders");
            }
        }

        private void list_Orders_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = list_Orders.SelectedIndex;
            ViewOrdersToolTip.SetToolTip(list_Orders, "Double click to view");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemsOrdered.Rows.Count > 0)
                {
                    List<string> addedItems = new List<string>();

                    for (int i=0; i < dgvItemsOrdered.Rows.Count -1; i++)
                    {
                        addedItems.Add(dgvItemsOrdered.Rows[i].Cells[Constants.ITEMID_COLUMN].Value.ToString());
                    }

                    using (AddNewItem newItem = new AddNewItem(addedItems))
                    {
                        if (newItem.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("An error occured. Please try again");
            }
        }

        private void btn_NewOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            newOrder order = new newOrder();
            order.Show();
        }
    }
}
