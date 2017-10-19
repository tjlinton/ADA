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

namespace adaOrderingSys
{
    public partial class OrderedItemsPopUp : Form 
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public OrderedItemsPopUp()
        {
            InitializeComponent();
        }

        public OrderedItemsPopUp(List<ItemsOrdered> itemsOrdered)
        {
            InitializeComponent();
            populateDataGridView(itemsOrdered);
        }

        public void populateDataGridView(List<ItemsOrdered>itemsOrdered)
        {
            try
            {
                for (int i = 0; i < itemsOrdered.Count(); i++)
                {
                    this.dgv_ItemsOrdered.Rows.Add();
                    this.dgv_ItemsOrdered.Rows[i].Cells["clmn_ItemId"].Value = itemsOrdered[i].itemID;
                    this.dgv_ItemsOrdered.Rows[i].Cells["clmn_ItemName"].Value = itemsOrdered[i].itemName;
                    this.dgv_ItemsOrdered.Rows[i].Cells["clmn_Quantity"].Value = itemsOrdered[i].qtyOrdered;
                    this.dgv_ItemsOrdered.Rows[i].Cells["clmn_TotalCost"].Value = itemsOrdered[i].totalPrice;
                    this.dgv_ItemsOrdered.Rows[i].Cells["clmn_Additionals"].Value = itemsOrdered[i].additionals;

                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                MessageBox.Show("An error occured retrieving ordered items");
            }
        }
    }
}
