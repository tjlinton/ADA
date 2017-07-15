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

namespace adaOrderingSys
{
    public partial class newOrder : Form
    {

        private static string SELECT_ALL_ITEMS = "SELECT [itemName],[itemID] FROM [dbo].[item]";
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public newOrder()
        {
            InitializeComponent();
            this.pnlAddOrder.Show();
            this.dgv_Order.Columns["clmn_ID"].Width = 100;
            this.dgv_Order.Columns["clmn_ItemName"].Width = 150;
            this.dgv_Order.Columns["clmn_CustName"].Width = 150;
            this.dgv_Order.Columns["clmn_UnitPrice"].Width = 50;
            this.dgv_Order.Columns["clmn_TotalCost"].Width = 50;

        }
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("There was an error adding a new row. Please try again");
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClearGV_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSubmitGV_Click(object sender, EventArgs e)
        { 
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            main mainForm = new main();
            mainForm.Show();        
        }

        private void newOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDADataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.aDADataSet.customer);
        }

        private List<string> bindItemList()
        {
            return new List<string>();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.ddl_Customer.SelectedIndex = 0;
            th
        }
    }
}
