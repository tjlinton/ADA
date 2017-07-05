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
        }
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataTable dt = getAllItems();
                Console.WriteLine(dt.Select());
                //for (int i = 0; i < this.gv_itemsOrdered.Rows.Count; i++)
                //{
                //    DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)this.gv_itemsOrdered.Columns["Item Name"];
                //    foreach (DataRow row in dt.Rows)
                //    {
                //        column.Items.Add(row);
                //    }
                //}
                // this.gv_itemsOrdered.Columns["gv_ColumnItemName"].DataPropertyName = dt.column
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("There was an error adding a new row. Please try again");
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int selectedRows = this.gv_itemsOrdered.SelectedRows.Count;
            //    while (selectedRows > 0)
            //    {
            //        this.gv_itemsOrdered.Rows.RemoveAt(this.gv_itemsOrdered.SelectedRows[0].Index);
            //        selectedRows --;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex);
            //    MessageBox.Show("There was an error deleting the selected row(s). Please try again");
            //}
        }

        private void btnClearGV_Click(object sender, EventArgs e)
        {
            //this.gv_itemsOrdered.Rows.Clear();
        }

        private void btnSubmitGV_Click(object sender, EventArgs e)
        { 
        }

        private DataTable getAllItems()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            var connectionString = ConfigurationManager.ConnectionStrings["ADAConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(SELECT_ALL_ITEMS, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds);

                        dt = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return dt;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
