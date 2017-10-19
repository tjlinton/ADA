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

        void clearControls()
        {
            cb_Customer.DataSource = null; ;
            rtxtLocation.Text = "";
            dgvItemsOrdered.DataSource = null;
            lbl_OrderID.Text = null;
            txtGrandTotal.Text = null;
        }

        /*******************************************************************
         *                  CLICK EVENTS
         *********************************************************************/

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            main mainForm = new main();
            mainForm.Show();
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

                    this.dgvItemsOrdered.DataSource = null;

                    populateDataTable(orderID);

                    this.dgvItemsOrdered.DataSource = dt;

                    foreach (DataGridViewRow row in dgvItemsOrdered.Rows)
                    {
                        grandTotal += Convert.ToDouble(row.Cells["totalCost"].Value);
                    }

                    txtGrandTotal.Text = grandTotal.ToString();

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
        }

        private void btn_DeleteOrder_Click(object sender, EventArgs e)
        {
            deleteOrder();
        }

        /***********************************************************************
         *                      VALUE CHANGED EVENTS
         ***********************************************************************/

        private void cb_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            clearControls();
            setItems();
        }
        private void dgvItemsOrdered_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            setGrandTotal();
        }

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

        private void btn_UpdateOrder_MouseHover(object sender, EventArgs e)
        {
            ViewOrdersToolTip.Show("Update order with your changes", btn_UpdateOrder);
        }

        private DataTable populateDataTable(int orderID)
        {
            try
            {
                dt = new DataTable();
                //Create the datable columns in accordance to what is in the table in the db
                dt.Columns.Add("itemID", typeof(string)).ReadOnly = true;
                dt.Columns.Add("itemName", typeof(string)).ReadOnly = true;
                dt.Columns.Add("quantity", typeof(int));
                dt.Columns.Add("totalCost", typeof(decimal)).ReadOnly = true;
                dt.Columns.Add("additionals", typeof(int));

                dt.PrimaryKey = new DataColumn[] { dt.Columns["itemID"] };

                SqlCommand cmd = new SqlCommand("[dbo].[usp_GetOrderedItemsFromOrderID]", conn);
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
                            MessageBox.Show("Order successfully deleted");
                            break;
                    }

                    clearControls(); // Empty out all relevant controls
                    setItems(); //Reset listbox items for order selection
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

        private void dgvItemsOrdered_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItemsOrdered.Rows.Count > 1) {
                if (e.ColumnIndex == this.dgvItemsOrdered.Columns["quantity"].Index)
                {
                    string cellValue = dgvItemsOrdered.Rows[e.RowIndex].Cells["quantity"].Value.ToString();

                    if (Convert.ToInt32(cellValue) <= 0)
                    {
                        this.dgvItemsOrdered.Rows[e.ColumnIndex].Cells["quantity"].Selected = true;
                        MessageBox.Show("quantity cannot be less than or equal to zero.");
                        return;
                    }

                    SqlCommand cmd = new SqlCommand(@"UPDATE ordered_items
                                                    SET quantity = @quantity
                                                    WHERE orderID = @orderID 
                                                    AND itemID = @itemID", conn);

                    string itemID = dgvItemsOrdered.Rows[e.RowIndex].Cells["itemID"].Value.ToString();
                    cmd.Parameters.AddWithValue("@itemID", itemID);

                    adapter.UpdateCommand = cmd;
                }
            }
        }
    }
}
