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
    public partial class SummaryFormCopy : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<string> checkedItems = new List<string>();
        private bool lastPage;
        private int pageNo;
        private bool summaryPrinted;
        List<KeyValuePair<int, string>> summaryList = null;
        private Summary summary { get; set; }

        public SummaryFormCopy()
        {
            InitializeComponent();
            setItems();
        }

        public SummaryFormCopy(Summary summ)
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
                Font font = new Font("Courier New", 8); //Font for the body of the loading sheet
                Font headerFont = new Font("Courier New", 24, FontStyle.Bold);
                Font boldFont = new Font("Courier New", 10, FontStyle.Bold);
                float fontHeight = topFont.GetHeight();

                int startX = 5, middleX = 300, endX = 620,
                    startY = 10, offset = 40, middleOffset, endOffset;

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

                    graphic.DrawString(top, topFont, new SolidBrush(Color.Black), startX, startY + (offset + 10));
                    offset = offset + (int)topFont.Height * 2; //make the spacing consistent

                }
                middleOffset = offset;
                endOffset = offset;

                int initalOffset = offset;

                int count = 0;
                int linesInSecondCol=0, lineInLastCol=0;
                bool in2ndCol = false, in3rdCol = false;

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
                        // Apply appropriate line breaks to location
                        if (location != null && !location.Equals(""))
                        {
                            location = " - " + location.Trim().TrimEnd('\n', '\r');
                            if (location.Length > 25 && location.IndexOf("\n") == -1)
                            {
                                string locationA = location.Substring(0, 25);
                                string locationB = location.Substring(25, location.Length - 25);

                                if (locationB.IndexOf(" ") == 0)
                                {
                                    location = locationA + "\n" + locationB;
                                }
                                else
                                {
                                    int spaceIndex = locationA.LastIndexOf(" ");
                                    locationB = locationA.Substring(spaceIndex, locationA.Length - spaceIndex) + locationB;
                                    locationA = locationA.Substring(0, locationA.LastIndexOf(" "));
                                    location = locationA + '\n' + locationB;
                                }
                            }
                        }
                        int numLines = location.Split('\n').Length;
                        int tempCount = itemQuantityAndAdditionals.Count + 1 + numLines;
                        count += tempCount;
                        //TODO: think about making this less repetitive

                        /**********************************************************************************************************************
                         *                                                  COLUMN 1
                         ***********************************************************************************************************************/
                        if (count <= Constants.MAX_LINES)
                        {
                            graphic.DrawString(details[1].Trim() + salesNum, boldFont, new SolidBrush(Color.Black), startX, startY + offset);
                            offset += (int)topFont.Height;

                            graphic.DrawString(location, boldFont, new SolidBrush(Color.Black), startX, startY + offset);
                            offset += numLines == 0 ? topFont.Height : topFont.Height * numLines;

                            for (int i = 0; i < itemQuantityAndAdditionals.Count; i++)
                            {
                                string quantity = itemQuantityAndAdditionals[i].qtyOrdered.ToString();
                                string item = itemQuantityAndAdditionals[i].itemName;
                                int additionals = itemQuantityAndAdditionals[i].additionals;
                                string drawItem = additionals == 0 ? "  " + quantity + " " + item :
                                    "  " + quantity + "+" + additionals + " " + item;
                                graphic.DrawString(drawItem, font, new SolidBrush(Color.Black), startX, startY + offset);
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
                        /***********************************************************************************************************************
                         *                                              COLUMN 2
                         ***********************************************************************************************************************/
                        else if (count <= (Constants.MAX_LINES * 2) ) //Move over to middle of the page
                        {
                            in2ndCol = true;
                            linesInSecondCol += tempCount;
                            graphic.DrawString(details[1].Trim() + salesNum, boldFont, new SolidBrush(Color.Black), middleX, startY + middleOffset);
                            middleOffset += (int)topFont.Height;
                            
                            graphic.DrawString(location, boldFont, new SolidBrush(Color.Black), middleX, startY + middleOffset);
                            middleOffset += numLines == 0 ? (int)topFont.Height : (int)topFont.Height * numLines;

                            for (int i = 0; i < itemQuantityAndAdditionals.Count; i++)
                            {
                                string quantity = itemQuantityAndAdditionals[i].qtyOrdered.ToString();
                                string item = itemQuantityAndAdditionals[i].itemName;
                                int additionals = itemQuantityAndAdditionals[i].additionals;
                                string drawItem = additionals == 0 ? "  " + quantity + " " + item :
                                    "  " + quantity + "+" + additionals + " " + item;
                                graphic.DrawString(drawItem, font,
                                    new SolidBrush(Color.Black), middleX, startY + middleOffset);
                                middleOffset += (int)topFont.Height;

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
                            middleOffset += 5;
                            checkedItems.RemoveAt(l);
                        }
                        /***************************************************************************************************************************
                         *                                                  COLUMN 3
                         ***************************************************************************************************************************/
                        else if (count <= Constants.MAX_LINES * 3)  //Move over to last column of the page
                        {
                           // count = (Constants.MAX_LINES * 2) + tempCount;
                            graphic.DrawString(details[1].Trim() + salesNum, boldFont, new SolidBrush(Color.Black), endX, startY + endOffset);
                            endOffset += (int)topFont.Height;
                            
                            graphic.DrawString(location, boldFont, new SolidBrush(Color.Black), endX, startY + endOffset);
                            endOffset += numLines == 0 ? (int)topFont.Height : (int)topFont.Height * numLines;

                            for (int i = 0; i < itemQuantityAndAdditionals.Count; i++)
                            {
                                string quantity = itemQuantityAndAdditionals[i].qtyOrdered.ToString();
                                string item = itemQuantityAndAdditionals[i].itemName;
                                int additionals = itemQuantityAndAdditionals[i].additionals;
                                string drawItem = additionals == 0 ? "  " + quantity + " " + item :
                                    "  " + quantity + "+" + additionals + " " + item;
                                graphic.DrawString(drawItem, font, new SolidBrush(Color.Black), endX, startY + endOffset);
                                endOffset += (int)topFont.Height;

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
                            endOffset += 5;
                            checkedItems.RemoveAt(l);
                        }
                        else
                        {
                            e.HasMorePages = true;
                            pageNo++;
                            return;
                        }
                    }
                }
                if (!summaryPrinted)
                {
                    //Summary statement.
                    if ((count + summaryList.Count) > (Constants.MAX_LOADING_SHEET_COLUMN * 3) && !summaryPrinted)
                    {
                        e.HasMorePages = true;
                        pageNo++;
                        lastPage = true;
                        return;
                    }

                    int currentX = lastPage ? startX : endX;


                    graphic.DrawString("Summary", boldFont, new SolidBrush(Color.Black), currentX, startY + endOffset);

                    endOffset += (int)topFont.Height;

                    summaryList = summaryList.OrderBy(kvp => kvp.Value).ToList(); //Sort the list in alphabetical order

                    for (int j = 0; j < summaryList.Count; j++)
                    {
                        string summaryItem = summaryList[j].Key + " " + summaryList[j].Value;
                        graphic.DrawString(summaryItem, font, new SolidBrush(Color.Black), currentX, startY + endOffset);
                        endOffset += (int)topFont.Height;
                    }

                    endOffset += (int)topFont.Height * 2;
                    summaryPrinted = true;

                    if (summaryList.Count >= Constants.MAX_LOADING_SHEET_COLUMN)
                    {
                        if (currentX == startX)
                        {
                            currentX = endX;
                            endOffset = middleOffset;
                        }
                        else
                        {
                            e.HasMorePages = true;
                            lastPage = true;
                        }
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
                    int currentX = endX;
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
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show("There was an error creating loading sheet please contact system administrator");
                return;
            }
        }

        private void drawSignatures() { }

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
