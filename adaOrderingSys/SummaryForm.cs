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
using System.Drawing.Printing;
using static System.Windows.Forms.CheckedListBox;
//using Microsoft.Office.Interop.Word;

namespace adaOrderingSys
{
    public partial class SummaryForm : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<string> checkedItems = new List<string>();
        private bool lastPage;
        private int pageNo;
        List<KeyValuePair<int, string>> summaryList = null;
        public SummaryForm()
        {
            InitializeComponent();
            setItems();
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
            main mainForm = new main();
            mainForm.Show();
        }

        private void btnSubmitCust_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbl_Orders.CheckedItems.Count != 0)
                {
                    PrintDialog printDialog = new PrintDialog();
                    PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
                    PrintDocument printDocument = new PrintDocument();

                    for (int i = cbl_Orders.CheckedItems.Count-1;  i >= 0; i--)
                    {
                        checkedItems.Add(cbl_Orders.CheckedItems[i].ToString());
                    }
                    pageNo = 1;
                    lastPage = false;
                    summaryList = new List<KeyValuePair<int, string>>();
                    printDialog.Document = printDocument;
                    printPrvDlg.Document = printDocument;
                    //add an event handler that will do the printing
                    printDocument.PrintPage += new PrintPageEventHandler(createLoadingSheet);
                    if (MessageBox.Show("Show preview?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        printPrvDlg.PrintPreviewControl.Zoom = 100 / 100f; //Zoom is calculated as a ratio
                        ((Form)printPrvDlg).WindowState = FormWindowState.Maximized;
                        printPrvDlg.ShowDialog();
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
                            int submitResponse = summary.fulfillOrders(orderIDList, txtLicenseNo.Text, txtDriver.Text, datetime);
                            if (submitResponse < 0)
                            {
                                throw new Exception("Error submitting Loading sheet");
                            }

                            printDocument.Print(); //Go ahead and print the doc

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
            catch (Exception)
            {
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
                Font topFont = new Font("Courier New", 11); //Font for first line of loading sheet
                Font font = new Font("Courier New", 9); //Font for the body of the loading sheet
                Font headerFont = new Font("Courier New", 24, FontStyle.Bold);
                Font boldFont = new Font("Courier New", 10, FontStyle.Bold);
                float fontHeight = topFont.GetHeight();

                int startX = 5, middleX = 300, endX = 580,
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
                    offset = offset + (int)headerFont.GetHeight() + 10; //make the spacing consistent

                }
                middleOffset = offset;
                endOffset = offset;

                int initalOffset = offset;

                int count = 0;

                if (!lastPage)
                {
                    for (int l = checkedItems.Count - 1; l >= 0; l--)
                    {
                        string order = checkedItems[l];
                        checkedItems.RemoveAt(l);
                        //Add each customer's order to the List
                        string[] details = order.Split('|');
                        int id = Convert.ToInt32(details[0].Trim());
                        List<ItemsOrdered> itemQuantityAndAdditionals = new ItemsOrdered().getOrderedItemsQuantityAndAdditionals(id);
                        string location = new Order().getOrderLocation(id);
                        if (location != null && location != "")
                        {
                            location = " - " + location;
                            if (location.Length > 12)
                            {
                                location = location.Substring(0, 12).Trim();
                                location += "...";
                            }
                        }

                        //TODO: think about making this less repetitive
                        if (count <= Constants.MAX_LOADING_SHEET_COLUMN)
                        {
                            graphic.DrawString(details[0].Trim() + " " + details[1].Trim() + location, boldFont, new SolidBrush(Color.Black), startX, startY + offset);
                            offset += (int)fontHeight;
                            int length = itemQuantityAndAdditionals.Count;
                            for (int i = 0; i < length; i++)
                            {
                                string quantity = itemQuantityAndAdditionals[i].qtyOrdered.ToString();
                                string item = itemQuantityAndAdditionals[i].itemName;
                                int additionals = itemQuantityAndAdditionals[i].additionals;
                                string drawItem = additionals == 0 ? "  " + quantity + " " + item :
                                    "  " + quantity + "+" + additionals + " " + item;
                                graphic.DrawString(drawItem, font, new SolidBrush(Color.Black), startX, startY + offset);
                                count++;
                                offset += (int)fontHeight;
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
                            offset += 15;
                            count++;
                        }
                        else if (count <= (Constants.MAX_LOADING_SHEET_COLUMN * 2)) //Move over to middle of the page
                        {
                            graphic.DrawString(details[0].Trim() + " " + details[1].Trim() + location, boldFont, new SolidBrush(Color.Black), middleX, startY + middleOffset);
                            middleOffset += (int)fontHeight;
                            int length = itemQuantityAndAdditionals.Count;
                            for (int i = 0; i < length; i++)
                            {
                                string quantity = itemQuantityAndAdditionals[i].qtyOrdered.ToString();
                                string item = itemQuantityAndAdditionals[i].itemName;
                                int additionals = itemQuantityAndAdditionals[i].additionals;
                                string drawItem = additionals == 0 ? "  " + quantity + " " + item :
                                    "  " + quantity + "+" + additionals + " " + item;
                                graphic.DrawString(drawItem, font,
                                    new SolidBrush(Color.Black), middleX, startY + middleOffset);
                                count++;
                                middleOffset += (int)fontHeight;

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
                            middleOffset += 15;
                            count++;
                        }
                        else if (count <= Constants.MAX_LOADING_SHEET_COLUMN * 3) //Move over to last column of the page
                        {

                            graphic.DrawString(details[0].Trim() + " " +details[1].Trim() + location, boldFont, new SolidBrush(Color.Black), endX, startY + endOffset);
                            endOffset += (int)fontHeight;
                            int length = itemQuantityAndAdditionals.Count;
                            for (int i = 0; i < length; i++)
                            {
                                string quantity = itemQuantityAndAdditionals[i].qtyOrdered.ToString();
                                string item = itemQuantityAndAdditionals[i].itemName;
                                int additionals = itemQuantityAndAdditionals[i].additionals;
                                string drawItem = additionals == 0 ? "  " + quantity + " " + item :
                                    "  " + quantity + "+" + additionals + " " + item;
                                graphic.DrawString(drawItem, font, new SolidBrush(Color.Black), endX, startY + endOffset);
                                count++;
                                endOffset += (int)fontHeight;

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
                            endOffset += 15;
                            count++;
                        }
                        else
                        {
                            e.HasMorePages = true;
                            pageNo++;
                            return;
                        }
                    }
                }

                //Summary statement.
                if ((count +summaryList.Count) > (Constants.MAX_LOADING_SHEET_COLUMN * 3))
                {
                    e.HasMorePages = true;
                    pageNo++;
                    lastPage = true;
                    return;
                }
                int currentX = lastPage ? startX : endX; 
                graphic.DrawString("Summary", boldFont, new SolidBrush(Color.Black), currentX, startY + endOffset);
                endOffset += (int)fontHeight;

                for (int j = 0; j < summaryList.Count; j++)
                {
                    string summaryItem = summaryList[j].Key + " " + summaryList[j].Value;
                    graphic.DrawString(summaryItem, topFont, new SolidBrush(Color.Black), currentX, startY + endOffset);
                    endOffset += (int)fontHeight;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("There was an error creating loading sheet please contact system administrator");
                return;
            }
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
                logger.Error(ex);
                MessageBox.Show("An error occured. Please contact system administrator.");
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
                logger.Error(ex);
                MessageBox.Show("An error occured. Please contact system administrator.");
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
            catch ( Exception ex)
            {
                logger.Error(ex);
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
                logger.Error(ex);
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
    }
}
