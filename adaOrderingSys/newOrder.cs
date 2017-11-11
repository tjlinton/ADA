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
using NLog;
using adaOrderingSys.business_objects;

namespace adaOrderingSys
{
    public partial class newOrder : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public newOrder()
        {
            InitializeComponent();
            this.pnlAddOrder.Show();
        }

        /// ===========================================================================
        ///                      Click Events
        /// ===========================================================================
        private void newOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDADataSet1.item' table. You can move, or remove it, as needed.
            this.itemTableAdapter.Fill(this.aDADataSet1.item);
            // TODO: This line of code loads data into the 'aDADataSet1.item' table. You can move, or remove it, as needed.
            this.itemTableAdapter.Fill(this.aDADataSet1.item);
            // TODO: This line of code loads data into the 'aDADataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.aDADataSet.customer);

            // Set dropdownlist items to blank object
            this.ddl_Customer.SelectedIndex = -1;
            this.ddl_Item.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgv_Order.SelectedRows)
            {
                dgv_Order.Rows.RemoveAt(item.Index);
            }
        }

        private void btnClearGV_Click(object sender, EventArgs e)
        {
            this.dgv_Order.Rows.Clear();
        }

        private void btnSubmitGV_Click(object sender, EventArgs e)
        {
            ep_Quantity.SetError(txt_Quantity, "");

            if (this.dgv_Order.RowCount == 1) //Compare to 1 because there is always an empty column
            {
                MessageBox.Show("Please fill in order details before submitting");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // user clicked yes

                // Initialize variables to be used
                ItemsOrdered items = new ItemsOrdered();
                int custID = (Int32)this.ddl_Customer.SelectedValue;
                List<string> itemID = new List<string>();
                List<int> quantity = new List<int>();
                List<int> additionals = new List<int>();
                List<decimal> totalItemCost = new List<decimal>();
                int salesNo = Convert.ToInt32(numeric_SalesNo.Value);

                Decimal totalCost = Convert.ToDecimal(this.txtGrandTotal.Text);
                int rowCount = this.dgv_Order.RowCount - 1;
                for (int k = 0; k < rowCount; k++)
                {
                    itemID.Add(this.dgv_Order.Rows[k].Cells["clmn_ID"].Value.ToString());
                    quantity.Add(int.Parse(this.dgv_Order.Rows[k].Cells["clmn_Quantity"].Value.ToString()));
                    additionals.Add(int.Parse(this.dgv_Order.Rows[k].Cells["clmn_Additionals"].Value.ToString()));
                    totalItemCost.Add(decimal.Parse(this.dgv_Order.Rows[k].Cells["clmn_TotalCost"].Value.ToString()));
                    //count++;
                }

                //execute insert items ordered
                int insertResult = items.insertItemsOrdered(custID, itemID, quantity, totalItemCost, totalCost, rtxt_Location.Text, additionals, salesNo, rowCount);
                switch (insertResult)
                {
                    case 0:
                        MessageBox.Show("Order added successfully.");
                        clearAll();
                        break;
                    case -1:
                        MessageBox.Show("There was an error adding this order. Please try again.");
                        break;
                    case -2:
                        MessageBox.Show("A critical error occured. please contact system administrator");
                        break;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            main mainForm = new main();
            mainForm.Show();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            clearInput();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (ddl_Customer.SelectedIndex == -1)
            {
                // Customer combobox is empty
                ep_Customer.SetError(this.ddl_Customer, "Please select a customer");
                return;
            }


            if (ddl_Item.SelectedIndex == -1)
            {
                // Item combobox is empty
                ep_Item.SetError(this.ddl_Item, "Please select an item");
                return;
            }


            string qText = txt_Quantity.Text; // Store quantity text val to variable

            if (qText == "" || (Int32.Parse(qText) <= 0))
            {
                ep_Quantity.SetError(txt_Quantity, "Quantity can't be zero");
                return;
            }

            if (ep_Quantity.GetError(txt_Quantity) == "" && qText != null && qText.CompareTo("") != 0)
            {
                try
                {
                    int rowCount = this.dgv_Order.RowCount;
                    if (rowCount > 1)
                    {
                        int itemIndex = getItemIndexIfAlreadyAdded(this.ddl_Item.SelectedValue.ToString(), rowCount);

                        if (itemIndex >= 0)
                        {
                            //Item was already added to GridView 
                            this.dgv_Order.Rows[itemIndex].Selected = true;
                            MessageBox.Show("Item already added.");
                            return;
                        }
                    }

                    ep_Quantity.SetError(txt_Quantity, "");

                    Item item = new Item();
                    string customer = this.ddl_Customer.Text;
                    string itemID = (string)this.ddl_Item.SelectedValue;
                    double unitPrice = item.getUnitPrice(itemID);
                    string itemName = this.ddl_Item.Text;
                    int quantity = Convert.ToInt32(this.txt_Quantity.Text);
                    double totalCost = quantity * unitPrice;
                    string salesNo = numeric_SalesNo.Value == 0 ? "" : numeric_SalesNo.Value.ToString();
                    int additionals = Convert.ToInt32(numeric_Additionals.Value);
                    string location = rtxt_Location.Text;

                    string[] row = { itemID, itemName, customer, location, salesNo, quantity.ToString(), additionals.ToString(), unitPrice.ToString(), totalCost.ToString() };

                    if (!isQuantityEnough(quantity, itemID))
                    {
                        return;
                    }
                    else
                    {
                        this.dgv_Order.Rows.Add(row);
                        //Clear controls
                        clearAfterAdd();
                        //Populate grand total text box
                        setGrandTotal();
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("Error occured adding row: " + ex);
                    MessageBox.Show("Error occured while adding row. Please contact admin");
                }
            }
            else
            {
                ep_Quantity.SetError(txt_Quantity, "Please enter a quantity");
                return;
            }
        }

        /// ===========================================================================
        ///                      Clear  Functions
        /// ===========================================================================

        private void clearAll()
        {
            this.ddl_Customer.SelectedIndex = -1;
            this.ddl_Item.SelectedIndex = -1;
            this.txt_Quantity.Text = "";
            this.dgv_Order.Rows.Clear();
            this.numeric_SalesNo.Value = 0;
            this.rtxt_Location.Text = "";
        }

        private void clearInput()
        {
            this.ddl_Customer.SelectedIndex = -1;
            this.ddl_Item.SelectedIndex = -1;
            this.txt_Quantity.Text = "";
        }
        private void clearAfterAdd()
        {
            this.ddl_Item.SelectedIndex = -1;
            this.txt_Quantity.Text = "";
            this.numeric_Additionals.Value = 0;
        }

        /// ===========================================================================
        ///                      Combobox Selected Index Changed
        /// ===========================================================================

        private void ddl_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Customer.SelectedIndex != -1)
            {
                ep_Customer.SetError(ddl_Customer, "");
                if (dgv_Order.RowCount > 1)
                {
                    int rowCount = this.dgv_Order.RowCount - 1;
                    for (int i = 0; i < rowCount; i++)
                    {
                        dgv_Order.Rows[i].Cells["clmn_CustName"].Value = this.ddl_Customer.Text;
                    }
                }

                int custID = Convert.ToInt32(ddl_Customer.SelectedValue);
                rtxt_Location.Text = new Customer().getCustomerLocation(custID);
            }
        }

        private void ddl_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Customer.SelectedIndex != -1)
            {
                txt_Quantity.Clear();
                ep_Quantity.SetError(txt_Quantity, "");
                numeric_Additionals.Value = 0;
                ep_Item.SetError(ddl_Item, "");
            }
        }

        private void setGrandTotal()
        {
            double grandTotal = 0;
            if (txtGrandTotal.Text == "") grandTotal = 0;
            //int cellIndex = this.dgv_Order.Columns["ClmnTotalCost"].Index;

            foreach (DataGridViewRow row in this.dgv_Order.Rows)
            {
                grandTotal = grandTotal + Convert.ToDouble(row.Cells["clmn_TotalCost"].Value);
            }

            txtGrandTotal.Text = grandTotal.ToString();
        }

        private bool isQuantityEnough(int quantity, string itemID)
        {
            try
            {
                int returnValue = new Item().compareQuantity(quantity, itemID);

                switch (returnValue)
                {
                    case -1:
                        return true;

                    case -2: //SQL Statement returned -2 which suggests an error occured when executing
                        throw new Exception("SQL error occured");

                    default:
                        ep_Quantity.SetError(txt_Quantity, "Only " + returnValue + " items remaining");
                        return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                MessageBox.Show("An error orccured. Please contact system admin");
                clearInput();
                return false;
            }
        }
        private void dgv_Order_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            setGrandTotal();
        }

        private void txt_Quantity_Validating(object sender, CancelEventArgs e)
        {
            string text = txt_Quantity.Text;
            if (text == null || text == "")
            {
                ep_Quantity.SetError(txt_Quantity, "Please enter a quantity");
            }
            else
            {
                ep_Quantity.SetError(txt_Quantity, "");
            }
        }

        private void txt_Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && !Char.IsControl(ch))
            {
                e.Handled = true;
                ep_Quantity.SetError(txt_Quantity, "Please enter a number");
                return;
            }
            ep_Quantity.SetError(txt_Quantity, "");
        }

        private int getItemIndexIfAlreadyAdded(string itemID, int rowCount)
        {
            for (int i = 0; i < rowCount - 1; i++)
            {
                string cellValue = this.dgv_Order.Rows[i].Cells["clmn_ID"].Value.ToString();
                if (cellValue != null && itemID.Equals(cellValue))
                {
                    return i;
                }
            }
            return -1;
        }

        private void dgv_Order_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //char ch = e.KeyChar;
            //if (!Char.IsDigit(ch) && !Char.IsControl(ch))
            //{
            //    e.Handled = true;
            //    ep_Quantity.SetError(txt_Quantity, "Please enter a number");
            //    return;
            //}
            //ep_Quantity.SetError(txt_Quantity, "");
        }

        private void dgv_Order_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgv_Order.RowCount < 2)
                return;

            if (e.RowIndex < 0)
            {
                return;
            }


            if (e.ColumnIndex == this.dgv_Order.Columns["clmn_Quantity"].Index)
            {
                int column = e.ColumnIndex;
                int row = e.RowIndex;
                int j;

                string cellValue = this.dgv_Order.Rows[row].Cells["clmn_Quantity"].Value.ToString();
                if (!Int32.TryParse(cellValue, out j))
                {
                    this.dgv_Order.Rows[row].Cells["clmn_Quantity"].Selected = true;
                    MessageBox.Show("quantity must be a number.");
                    return;
                }
                else
                {
                    if (Convert.ToInt32(cellValue) <= 0)
                    {
                        this.dgv_Order.Rows[row].Cells["clmn_Quantity"].Selected = true;
                        MessageBox.Show("quantity cannot be less than or equal to zero.");
                        return;
                    }

                    int totalCost = Convert.ToInt32(cellValue) * Convert.ToInt32(this.dgv_Order.Rows[row].Cells["clmn_UnitPrice"].Value);
                    this.dgv_Order.Rows[row].Cells["clmn_TotalCost"].Value = totalCost;
                    setGrandTotal();
                }
            }
        }
    }
}
