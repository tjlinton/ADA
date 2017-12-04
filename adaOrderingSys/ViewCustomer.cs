using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adaOrderingSys
{
    public partial class ViewCustomer : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public ViewCustomer()
        {
            InitializeComponent();
        }

        private void ViewCustomer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDADataSet2.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.aDADataSet2.customer);

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //foreach ()
                this.Validate();
                this.customerBindingSource.EndEdit();
                this.customerTableAdapter.Update(this.aDADataSet2.customer);
                MessageBox.Show("Updates successful");
            }

            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("There has been an error updating items. Please try again.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            main mainForm = new main();
            mainForm.Show();
        }

        private void dgv_Customers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgv_Customers.Columns[telephoneDataGridViewTextBoxColumn.Name].Index)
                {
                    dgv_Customers.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Must be a phone number";
                }
            }

            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void dgv_Customers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.btn_Submit.Enabled = true;
                dgv_Customers.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
                if (e.ColumnIndex == dgv_Customers.Columns[telephoneDataGridViewTextBoxColumn.Name].Index)
                {
                    string text = dgv_Customers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                   
                    //text entered must be a phone number
                    if (!isNumberValid(text))
                    {
                        //e.Cancel = true;
                        dgv_Customers.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Must be a phone number";
                        dgv_Customers.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        this.btn_Submit.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private bool isNumberValid(string text)
        {
            text = text.Replace("-", "").Replace(" ", "");
            Regex reg = new Regex(@"^\b(\d{7}|\d{10})\b");

            //text entered must be a phone number
            if (!reg.IsMatch(text) && !text.Equals(""))
            {
                return false;
            }

            return true;
        }
    }
}
