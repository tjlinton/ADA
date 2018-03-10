using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using adaOrderingSys.business_objects;
using NLog;
using System.Drawing.Printing;
using System.Linq;

namespace adaOrderingSys
{
    public partial class SummaryForm : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<string> checkedItems = new List<string>();
        private bool lastPage;
        private int pageNo;
        private bool summaryPrinted;
        List<KeyValuePair<int, string>> summaryList = null;
        private Summary summary { get; set; }

        public SummaryForm()
        {
            InitializeComponent();
            setItems();
        }

        public SummaryForm(Summary summ)
        {
            this.summary = summ;
            InitializeComponent();
            setItems(this.summary);
        }

        private void setItems(Summary summ)
        {
            try
            {
                List<KeyValuePair<int, string>> listItems = new Order().getOrdersBasedOnSummaryID(summ.summaryID);
                List<KeyValuePair<int, string>> uncheckedItems = new Order().getCustNameBasedOnOrderDate();
                cbl_Orders.Items.Clear();

                if (listItems != null)
                {
                    foreach (KeyValuePair<int, string> item in listItems)
                    {
                        string value = item.Key + " | " + item.Value;
                        cbl_Orders.Items.Add(value);
                        cbl_Orders.SetItemChecked(cbl_Orders.Items.Count - 1, true);
                    }

                    foreach (KeyValuePair<int, string> item in uncheckedItems)
                    {
                        string value = item.Key + " | " + item.Value;
                        cbl_Orders.Items.Add(value);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show(Constants.GENERIC_ERROR);
            }
        }

        private void setItems()
        {
            List<KeyValuePair<int, string>> listItems = new Order().getCustNameBasedOnOrderDate();

            cbl_Orders.Items.Clear();
            if (listItems != null)
            {
                foreach (KeyValuePair<int, string> item in listItems)
                {
                    string value = item.Key + " | " + item.Value;
                    cbl_Orders.Items.Add(value);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (this.summary == null)
            {
                new main().Show();
            }
            else
            {
                new ViewLoadingSheets().Show();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.summaryPrinted = false;
                this.lastPage = false;
                this.pageNo = 0;
                if (cbl_Orders.CheckedItems.Count != 0)
                {
                    PrintDialog printDialog = new PrintDialog();
                    PrintDocument printDocument = new PrintDocument();

                    checkedItems = new List<string>();

                    for (int i = cbl_Orders.CheckedItems.Count - 1; i >= 0; i--)
                    {
                        checkedItems.Add(cbl_Orders.CheckedItems[i].ToString());
                    }
                    pageNo = 1;
                    lastPage = false;
                    summaryList = new List<KeyValuePair<int, string>>();
                    printDialog.Document = printDocument;
                    //add an event handler that will do the printing
                    printDocument.PrintPage += new PrintPageEventHandler(createLoadingSheet);
                    if (MessageBox.Show("Are you sure you want to print?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        //Ask user where to print
                        DialogResult result = printDialog.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            Summary summary = new Summary();

                            List<int> orderIDList = new List<int>();

                            int selectedItems = this.cbl_Orders.CheckedItems.Count;

                            for (int i = 0; i < selectedItems; i++)
                            {
                                string[] item = this.cbl_Orders.CheckedItems[i].ToString().Split('|');

                                orderIDList.Add(int.Parse(item[0]));
                            }

                            DateTime datetime = dateTimePicker1.Value;

                            int submitResponse = -1;
                            if (this.summary == null)
                            {
                                submitResponse = summary.fulfillOrders(orderIDList, txtLicenseNo.Text, txtDriver.Text, datetime, txtLocation.Text, User.userName);
                            }
                            else if (this.summary.summaryID != 0)
                            {
                                List<int> uncheckedOrderIDs = new List<int>();
                                submitResponse = summary.fulfillOrders(this.summary.summaryID, orderIDList, txtLicenseNo.Text, txtDriver.Text, datetime, txtLocation.Text, User.userName);
                                for (int i = cbl_Orders.Items.Count - 1; i >= 0; i--)
                                {
                                    if (!cbl_Orders.GetItemChecked(i))
                                    {
                                        string[] order = (cbl_Orders.Items[i].ToString().Split('|'));
                                        int id = Convert.ToInt32(order[0].Trim());
                                        uncheckedOrderIDs.Add(id);
                                    }
                                }

                                int numUnfullfills = uncheckedOrderIDs.Count == 0 ? 0 : new Summary().unfulfillOrders(uncheckedOrderIDs);
                                if (numUnfullfills < 0)
                                {
                                    MessageBox.Show("An error occured.");
                                    return;
                                }
                            }

                            if (submitResponse < 0)
                            {
                                throw new Exception("Error submitting Loading sheet");
                            }

                            printDocument.Print(); //Go ahead and print the doc

                            if (this.WindowState == FormWindowState.Minimized)
                            {
                                this.WindowState = FormWindowState.Normal;
                            }

                            MessageBox.Show("Success");

                            setItems();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select items to add to loading sheet");
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show("ERROR: Could not create loading sheet. try again");
            }
        }

        private void createLoadingSheet(object sender, PrintPageEventArgs e)
        {
            //this prints the loading sheet
            try
            {
                Graphics graphic = e.Graphics;
                //must use a mono spaced font as the spaces need to line up
                Font topFont = new Font("Courier New", 10); //Font for first line of loading sheet
                Font font = new Font("Courier New", 9); //Font for the body of the loading sheet
                Font headerFont = new Font("Courier New", 20, FontStyle.Bold);
                Font summaryFont = new Font("Courier New", 9, FontStyle.Bold);
                Font boldFont = new Font("Courier New", 10, FontStyle.Bold);
                float fontHeight = topFont.GetHeight();

                bool firstInColumn1 = true,
                     firstInColumn2 = true,
                     firstInColumn3 = true;

                int x = 0, startX = 5, middleX = 300, endX = 620;
                int startY = 10, offset, initialOffset = 40, middleOffset, endOffset;

                bool isLastColumn = false ;

                if (pageNo == 1)
                {
                    graphic.DrawString(Constants.LOADING_SHEET_HEADER.PadLeft(25), headerFont, new SolidBrush(Color.Black), startX, startY);
                    //Sub heading of loading sheet
                    string top = txtLicenseNo.Text == "" ? "Lic #:_____" + Constants.LOADING_SHEET_SPACER :
                        "Lic #:" + txtLicenseNo.Text + Constants.LOADING_SHEET_SPACER; //License number
                    top += "Date: " + dateTimePicker1.Value.ToShortDateString() + Constants.LOADING_SHEET_SPACER; //Date for the 
                    top += txtDriver.Text == "" ? "Driver:_____________" + Constants.LOADING_SHEET_SPACER :
                        "Driver:" + txtDriver.Text + Constants.LOADING_SHEET_SPACER; //Driver for the loading sheet
                    top += txtLocation.Text == "" ? "Location:_____________" + Constants.LOADING_SHEET_SPACER :
                        "Location:" + txtLocation.Text + Constants.LOADING_SHEET_SPACER; //Location to be delivered to 

                    graphic.DrawString(top, topFont, new SolidBrush(Color.Black), startX, startY + (initialOffset + 10));
                    initialOffset = initialOffset + (int)topFont.Height * 2; //make the spacing consistent

                }
                offset = initialOffset;
                middleOffset = initialOffset;
                endOffset = initialOffset;

                int initalOffset = initialOffset;

                int count = 0;

                if (!lastPage)
                {
                    for (int l = checkedItems.Count - 1; l >= 0; l--)
                    {
                        string order = checkedItems[l];
                        //Add each customer's order to the List
                        string[] details = order.Split('|');
                        int id = Convert.ToInt32(details[0].Trim());
                        List<ItemsOrdered> itemQuantityAndAdditionals = new ItemsOrdered().getOrderedItemsQuantityAndAdditionals(id);
                        string location = new Order().getOrderLocation(id);
                        int salesNo = new Order().getOrderSalesNo(id);
                        string salesNum = salesNo > 0 ? " #" + salesNo.ToString() : "";

                        if (details[1].Length >= 23)
                        {
                            details[1] = createNewLines(details[1]);
                        }

                        int detailLines = details[1].IndexOf('\n') == -1? 1: details[1].Split('\n').Length;

                        // Apply appropriate line breaks to location
                        if (location != null && !location.Equals(""))
                        {
                            location = " - " + location.Trim().TrimEnd('\n', '\r');
                            location = location.Replace("\n", " ");
                            if (location.Length > 22)
                            {
                                location = createNewLines(location);
                            }
                        }
                        int numLines = location.Split('\n').Length;
                        int tempCount = itemQuantityAndAdditionals.Count + detailLines + numLines;
                        
                        //This prevents overflowing in the column
                        if ((count + tempCount) > Constants.MAX_LINES && count < Constants.MAX_LINES)
                        {
                            //Set count to max lines figure to prevent overflowing in second column
                            count = Constants.MAX_LINES;
                        }


                        int doubleMaxLines = Constants.MAX_LINES * 2;
                        if ((count + tempCount) > doubleMaxLines && count < doubleMaxLines)
                        {
                            //Set count to double the max lines figure to prevent overflowing in the second column
                            count = doubleMaxLines;
                        }

                        //Increment count
                        count += tempCount;

                        //Determine which column the item should be printed in. 1st, 2nd or 3rd
                        if (count <= Constants.MAX_LINES)
                        {
                            x = startX;
                            if (firstInColumn1)
                            {
                                //Reset the offset figure
                                offset = initalOffset;
                                firstInColumn1 = false; //The next time this if statement is hit, firstInColumn should be false
                            }
                        }
                        else if (count <= Constants.MAX_LINES * 2)
                        {
                            x = middleX;
                            if (firstInColumn2)
                            {
                                offset = middleOffset;
                                firstInColumn2 = false;
                            }
                        }
                        else if (count <= Constants.MAX_LINES * 3)
                        {
                            x = endX;
                            if (firstInColumn3)
                            {
                                offset = endOffset;
                                firstInColumn3 = false;
                            }
                            isLastColumn = true;
                        }
                        else
                        {
                            e.HasMorePages = true;
                            pageNo++;
                            return;
                        }

                        //Customer details
                        graphic.DrawString(details[1].Trim() + salesNum, boldFont, new SolidBrush(Color.Black), x, startY + offset);
                        offset += (int)topFont.Height * detailLines;

                        //location
                        if (!location.Equals("") && location != null)
                        {
                            graphic.DrawString(location, boldFont, new SolidBrush(Color.Black), x, startY + offset);
                            offset += numLines == 0 ? topFont.Height : topFont.Height * numLines;
                        }

                        //Print each item
                        for (int i = 0; i < itemQuantityAndAdditionals.Count; i++)
                        {
                            string quantity = itemQuantityAndAdditionals[i].qtyOrdered.ToString();
                            string item = itemQuantityAndAdditionals[i].itemName;
                            int additionals = itemQuantityAndAdditionals[i].additionals;
                            string drawItem = additionals == 0 ? "  " + quantity + " " + item :
                                "  " + quantity + "+" + additionals + " " + item;
                            graphic.DrawString(drawItem, font, new SolidBrush(Color.Black), x, startY + offset);
                            offset += (int)topFont.Height;
                            int index = isItemInList(summaryList, itemQuantityAndAdditionals[i].itemName);
                            //Add to the summary list
                            if (summaryList.Count > 0 && index >= 0)
                            {
                                int thisQuantity = itemQuantityAndAdditionals[i].qtyOrdered +
                                                    itemQuantityAndAdditionals[i].additionals +
                                                    summaryList[index].Key;

                                string thisItem = itemQuantityAndAdditionals[i].itemName;
                                summaryList[index] = new KeyValuePair<int, string>(thisQuantity, thisItem);

                            }
                            else
                            {
                                int thisQuantity = itemQuantityAndAdditionals[i].qtyOrdered + itemQuantityAndAdditionals[i].additionals;
                                summaryList.Add(new KeyValuePair<int, string>(thisQuantity, itemQuantityAndAdditionals[i].itemName));
                            }
                        }
                        offset += 5;
                        checkedItems.RemoveAt(l);
                    }
                }
                if (!summaryPrinted)
                {
                    int linesAvailable = isLastColumn ? (Constants.MAX_LINES * 3) - count : Constants.MAX_LINES;
                    //Summary statement.
                    if ((summaryList.Count) > (linesAvailable) && !lastPage)
                    {
                        e.HasMorePages = true;
                        pageNo++;
                        lastPage = true;
                        return;
                    }

                    int currentX = lastPage ? startX : endX;
                    if (currentX == endX && endOffset!=offset && isLastColumn)
                        endOffset = offset;

                    graphic.DrawString("Summary", boldFont, new SolidBrush(Color.Black), currentX, startY + endOffset);

                    endOffset += (int)topFont.Height;

                    summaryList = summaryList.OrderBy(kvp => kvp.Value).ToList(); //Sort the list in alphabetical order

                    for (int j = 0; j < summaryList.Count; j++)
                    {
                        if (j == Constants.MAX_LINES)
                        {
                            endOffset = middleOffset;
                            currentX = middleX;
                        }

                        string summaryItem = summaryList[j].Key + " " + summaryList[j].Value;
                        graphic.DrawString(summaryItem, summaryFont, new SolidBrush(Color.Black), currentX, startY + endOffset);
                        endOffset += (int)topFont.Height;
                    }

                    endOffset += (int)topFont.Height * 2;
                    summaryPrinted = true;

                    if (summaryList.Count + 9 > Constants.MAX_LINES && currentX == endX)
                    {
                        e.HasMorePages = true;
                        lastPage = true;
                        return;
                    }
                    else if (currentX == startX && (summaryList.Count + 9) > Constants.MAX_LINES )
                    {
                        currentX = endX;
                        endOffset = middleOffset;
                    }

                    graphic.DrawString(Constants.PACKER_NAME, font, new SolidBrush(Color.Black), currentX, startY + endOffset);
                    endOffset += (int)topFont.Height + 10;
                    graphic.DrawString(Constants.PACKER_SIG, font, new SolidBrush(Color.Black), currentX, startY + endOffset);
                    endOffset += ((int)topFont.Height * 2) + 10;
                    graphic.DrawString(Constants.WS_SUP_SIG, font, new SolidBrush(Color.Black), currentX, startY + endOffset);
                    endOffset += ((int)topFont.Height * 2) + 10;
                    graphic.DrawString(Constants.MGMT_SIG, font, new SolidBrush(Color.Black), currentX, startY + endOffset);
                    endOffset += ((int)topFont.Height * 2) + 10;
                    graphic.DrawString(Constants.ASSIGNEE, font, new SolidBrush(Color.Black), currentX, startY + endOffset);
                }
                else
                {
                    int currentX = startX;
                    endOffset = startY;
                    graphic.DrawString(Constants.PACKER_NAME, font, new SolidBrush(Color.Black), currentX, startY);
                    endOffset += (int)topFont.Height + 10;
                    graphic.DrawString(Constants.PACKER_SIG, font, new SolidBrush(Color.Black), currentX, startY + endOffset);
                    endOffset += ((int)topFont.Height * 2) + 10;
                    graphic.DrawString(Constants.WS_SUP_SIG, font, new SolidBrush(Color.Black), currentX, startY + endOffset);
                    endOffset += ((int)topFont.Height * 2) + 10;
                    graphic.DrawString(Constants.MGMT_SIG, font, new SolidBrush(Color.Black), currentX, startY + endOffset);
                    endOffset += ((int)topFont.Height * 2) + 10;
                    graphic.DrawString(Constants.ASSIGNEE, font, new SolidBrush(Color.Black), currentX, startY + endOffset);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show("There was an error creating loading sheet please contact system administrator");
                return;
            }
        }

        private string createNewLines(string sourceString) {
            string string1 = sourceString.Substring(0, 23);
            string string2 = sourceString.Substring(23, sourceString.Length - 23);

            if (string2.IndexOf(" ") == 0)
            {
                sourceString = string1 + "\n" + string2;
            }
            else
            {
                int spaceIndex = string1.LastIndexOf(" ");
                string2 = string1.Substring(spaceIndex, string1.Length - spaceIndex) + string2;
                string1 = string1.Substring(0, string1.LastIndexOf(" "));
                sourceString = string1 + '\n' + string2;
            }

            return sourceString;
        }

        private int isItemInList(List<KeyValuePair<int, string>> list, string comparedItem)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Value.Equals(comparedItem))
                    return i;
            }

            return -1;
        }

        private void getItemNameandQuantity()
        {
            try
            {
                if (cbl_Orders.SelectedItems != null)
                    if (cbl_Orders.SelectedItem.ToString().Length != 0)
                    {
                        string[] orderID = cbl_Orders.SelectedItem.ToString().Split('|'); //Split list item value by pipe char to get order ID
                        orderID[0] = orderID[0].Trim(); // Remove white spaces from order ID
                        int id = Convert.ToInt32(orderID[0]); //Change to integer

                        List<KeyValuePair<int, string>> details = new ItemsOrdered().getOrderedItemNameAndQuantity(id);

                        string itemsAndQuantity = "";

                        foreach (KeyValuePair<int, string> detail in details)
                        {
                            itemsAndQuantity += "\n" + detail.Key + " \t\t " + detail.Value.Trim();
                        }

                        MessageBox.Show("Quantity \t\t Items" + itemsAndQuantity);
                    }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show(Constants.CONTACT_SYSTEMADMIN);
            }
        }

        private void showPopUp()
        {
            try
            {
                if (cbl_Orders.SelectedItems.Count != 0)
                    if (cbl_Orders.SelectedItem.ToString().Length != 0)
                    {
                        string[] orderID = cbl_Orders.SelectedItem.ToString().Split('|'); //Split list item value by pipe char to get order ID
                        orderID[0] = orderID[0].Trim(); // Remove white spaces from order ID
                        int id = Convert.ToInt32(orderID[0]); //Change to integer

                        List<ItemsOrdered> orderedItems = new ItemsOrdered().getItemsOrderedBasedonOrderID(id);
                        if (orderedItems == null)
                        {
                            throw new NullReferenceException();
                        }
                        OrderedItemsPopUp popUp = new OrderedItemsPopUp(orderedItems);
                        popUp.ShowDialog();
                    }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show(Constants.CONTACT_SYSTEMADMIN);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbl_Orders.Items.Count; i++)
            {
                cbl_Orders.SetItemChecked(i, true);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                int index = cbl_Orders.SelectedIndex;
                if (index == -1 || index == 0)
                    return;
                int prevIndex = index - 1;
                bool isChecked = cbl_Orders.GetItemChecked(index);
                string temp = cbl_Orders.Items[index].ToString();
                cbl_Orders.Items.RemoveAt(index);

                //cbl_Orders.Items[prevIndex] = cbl_Orders.Items[index];
                cbl_Orders.Items.Insert(prevIndex, temp);
                cbl_Orders.SelectedIndex = prevIndex;
                if (isChecked)
                {
                    cbl_Orders.SetItemChecked(prevIndex, true);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                int index = cbl_Orders.SelectedIndex;

                if (index == cbl_Orders.Items.Count - 1 || index == -1)
                    return;

                int nextIndex = index + 1;

                bool isChecked = cbl_Orders.GetItemChecked(index);
                string temp = cbl_Orders.Items[index].ToString();
                cbl_Orders.Items.RemoveAt(index);
                cbl_Orders.Items.Insert(nextIndex, temp);
                cbl_Orders.SelectedIndex = nextIndex;
                if (isChecked)
                {
                    cbl_Orders.SetItemChecked(nextIndex, true);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
            }
        }

        private void cbl_Orders_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cbl_Orders_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cbl_Orders.SelectedIndex = cbl_Orders.IndexFromPoint(e.X, e.Y);
                this.showPopUp();
            }
        }

        private void btnUp_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnUp, "Move selected item up in the list");
        }

        private void btnDown_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnDown, "Move selected item down in the list");
        }

        private void SummaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            summaryPrinted = false;
            lastPage = false;
            pageNo = 0;
            PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
            PrintDocument printDocument = new PrintDocument();

            checkedItems = new List<string>();

            for (int i = cbl_Orders.CheckedItems.Count - 1; i >= 0; i--)
            {
                checkedItems.Add(cbl_Orders.CheckedItems[i].ToString());
            }
            pageNo = 1;
            lastPage = false;
            summaryList = new List<KeyValuePair<int, string>>();

            printPrvDlg.Document = printDocument;
            printDocument.PrintPage += new PrintPageEventHandler(createLoadingSheet);

            printPrvDlg.PrintPreviewControl.Zoom = 100 / 100f; //Zoom is calculated as a ratio
            ((Form)printPrvDlg).WindowState = FormWindowState.Maximized;
            printPrvDlg.ShowDialog();

            return;
        }
    }
}
