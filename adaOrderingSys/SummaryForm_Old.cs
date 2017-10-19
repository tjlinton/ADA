using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using adaOrderingSys.business_objects;
using NLog;
//using System.Drawing.Printing;
using Microsoft.Office.Interop.Word;

namespace adaOrderingSys
{
    public partial class SummaryForm : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public SummaryForm()
        {
            InitializeComponent();
            setItems();
        }

        private void setItems()
        {
            Summary summary = new Summary();
            List<KeyValuePair<int, string>> listItems = summary.getCustNameBasedOnOrderDate();

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

        private void cbl_Orders_DoubleClick(object sender, EventArgs e)
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            main mainForm = new main();
            mainForm.Show();
        }

        //private void btnSubmitCust_Click(object sender, EventArgs e)
        //{
        //    if (cbl_Orders.CheckedItems.Count != 0)
        //    {
        //        PrintDialog printDialog = new PrintDialog();
        //        PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
        //        PrintDocument printDocument = new PrintDocument();

        //        printDialog.Document = printDocument;
        //        printPrvDlg.Document = printDocument;
        //        //add an event handler that will do the printing
        //        printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(createLoadingSheet);
        //        if (MessageBox.Show("Show preview?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            printPrvDlg.ShowDialog();
        //            return;
        //        }
        //        else
        //        {
        //            //Ask user where to print
        //            DialogResult result = printDialog.ShowDialog();

        //            if (result == DialogResult.OK)
        //            {
        //                Summary summary = new Summary();

        //                List<int> orderIDList = new List<int>();

        //                int selectedItems = this.cbl_Orders.CheckedItems.Count;

        //                for (int i = 0; i < selectedItems; i++)
        //                {
        //                    string[] item = this.cbl_Orders.CheckedItems[i].ToString().Split('|');

        //                    orderIDList.Add(Int32.Parse(item[0]));
        //                }

        //                int submitResponse = summary.fulfillOrders(orderIDList);

        //                if (submitResponse < 0)
        //                {
        //                    throw new Exception("Error submitting Loading sheet");
        //                }

        //                printDocument.Print();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select items to add to loading sheet");
        //        return;
        //    }
        //}


        private void btnSubmitCust_Click(object sender, EventArgs e)
        {
           if (cbl_Orders.CheckedItems.Count != 0)
           {

           }
           else
           {
               MessageBox.Show("Please select items to add to loading sheet");
               return;
           }
        }
        //public void createLoadingSheet(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    //this prints the loading sheet
        //    try
        //    {
        //        int selectedItems = this.cbl_Orders.CheckedItems.Count;

        //        if (selectedItems == 0)
        //        {
        //            MessageBox.Show("Please check the items to be added to summary sheet");
        //            return;
        //        }

        //        Graphics graphic = e.Graphics;

        //        Font font = new Font("Courier New", 11); //must use a mono spaced font as the spaces need to line up
        //        Font headerFont = new Font("Courier New", 24, FontStyle.Bold);
        //        Font boldFont = new Font("Courier New", 11,FontStyle.Bold);
        //        float fontHeight = font.GetHeight();

        //        int startX = 10;
        //        int middleX = 260;
        //        int endX = 560;
        //        int startY = 10;
        //        int offset = 40;
        //        int middleOffset; ;
        //        int endOffset; ;

        //        StringFormat sf = new StringFormat();
        //        sf.LineAlignment = StringAlignment.Center;
        //        sf.Alignment = StringAlignment.Center;
        //        graphic.DrawString("LOADING SHEET".PadLeft(25), headerFont, new SolidBrush(Color.Black), startX, startY);
        //        string top =
        //            "Lic #:_____   " +
        //            "Date: " + DateTime.Today.ToString("dd/MM/yyyy") + "   " +
        //            "Driver:_____________     " +
        //            "Location:_____________    ";

        //        graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + (offset+10));
        //        //offset = offset + (int)fontHeight; //make the spacing 
        //        offset = offset + (int)headerFont.GetHeight() + 10; //make the spacing consistent
        //        middleOffset = offset;
        //        endOffset = offset;

        //        int count = 0;

        //        graphic.DrawString("Summary", boldFont, new SolidBrush(Color.Black), endX, startY + endOffset);
        //        endOffset += (int)fontHeight;

        //        List<KeyValuePair<int, string>> summaryList = new List<KeyValuePair<int, string>>();

        //        foreach (var order in cbl_Orders.CheckedItems)
        //        {

        //            //Add each customer order to the List
        //            String[] details = order.ToString().Split('|');
        //            int ID = Convert.ToInt32(details[0].Trim());
        //            List<KeyValuePair<int,string>> itemAndQuantity = new ItemsOrdered().getOrderedItemNameAndQuantity(ID);

        //            if (count <= 45)
        //            {
        //                graphic.DrawString(details[1].Trim(), new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
        //                offset += (int)fontHeight;
        //                int length = itemAndQuantity.Count;
        //                for (int i = 0; i < length; i++)
        //                {
        //                    string quantity = itemAndQuantity[i].Key.ToString();
        //                    string item = itemAndQuantity[i].Value;
        //                    graphic.DrawString("  " + quantity + " " + item, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
        //                    count++;
        //                    offset += (int)fontHeight;
        //                    int index = isItemInList(summaryList, itemAndQuantity[i].Value);
        //                    Console.WriteLine(index);
        //                    if (summaryList.Count > 0 && index >=0)
        //                    {
        //                        int thisQuantity = itemAndQuantity[i].Key + summaryList[index].Key;
        //                        string thisItem = itemAndQuantity[i].Value;

        //                        summaryList[index] = new KeyValuePair<int, string>(thisQuantity, thisItem);
                                                                
        //                    }
        //                    else
        //                    {
        //                        summaryList.Add(itemAndQuantity[i]);
        //                    }

        //                    //string summaryItem = summaryList[index].Key + " " + summaryList[index].Value;
        //                }
        //                offset += 15;
        //                count++;
        //            }
        //            else //Move over to middle of the page
        //            {
        //                graphic.DrawString(details[1].Trim(), new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), middleX, startY + middleOffset);
        //                middleOffset += (int)fontHeight;
        //                int length = itemAndQuantity.Count;
        //                for (int i = 0; i < length; i++)
        //                {
        //                    string quantity = itemAndQuantity[i].Key.ToString();
        //                    string item = itemAndQuantity[i].Value;
        //                    graphic.DrawString("  " + quantity + " " + item, new Font("Courier New", 10), new SolidBrush(Color.Black), middleX, startY + middleOffset);
        //                    count++;
        //                    middleOffset += (int)fontHeight;
        //                    int index = isItemInList(summaryList, itemAndQuantity[i].Value);
        //                    Console.WriteLine(index);
        //                    if (summaryList.Count > 0 && index >= 0)
        //                    {
        //                        int thisQuantity = itemAndQuantity[i].Key + summaryList[index].Key;
        //                        string thisItem = itemAndQuantity[i].Value;

        //                        summaryList[index] = new KeyValuePair<int, string>(thisQuantity, thisItem);
        //                    }
        //                    else
        //                    {
        //                        summaryList.Add(itemAndQuantity[i]);   
        //                    }
        //                }
        //                middleOffset += 15;
        //                count++;
        //            }
        //        }

        //        for (int j = 0; j < summaryList.Count; j++)
        //        {
        //            string summaryItem = summaryList[j].Key + " " + summaryList[j].Value;
        //            graphic.DrawString("  " + summaryItem, font, new SolidBrush(Color.Black), endX, startY + endOffset);
        //            endOffset += (int)fontHeight;
        //        }
                    
        //        offset = offset + 30; //make some room so that the total stands out.
                
        //        //string bottom = "Bottom line1";
        //        //Font courier = new Font("Courier New", 12, FontStyle.Regular);
        //        //Size sz = TextRenderer.MeasureText(bottom,courier);
        //        //graphic.DrawString(bottom, courier, Brushes.Black,
        //        //e.MarginBounds.Right, e.MarginBounds.Bottom - sz.Height);
                
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex);
        //        MessageBox.Show("There was an error creating loading sheet please contact system administrator");
        //        return;
        //    }
        //}

        //private void createWordDoc()
        //{
        //    Microsoft.Office.Interop.Word.Application adaWordApp;
        //    Microsoft.Office.Interop.Word.Document loadingSheet;

        //    adaWordApp = new Microsoft.Office.Interop.Word.Application();
        //    adaWordApp.Visible = true;
        //    loadingSheet = adaWordApp.Documents.Add()
        //}

        private int isItemInList(List<KeyValuePair<int,string>> list, string comparedItem)
        {
            for (int i=0; i < list.Count; i++)
            {
                if (list[i].Value.Equals(comparedItem))
                    return i;
            }

            return -1;
        }
    }
}
