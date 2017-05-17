using adaOrderingSys.business_objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using System.Text.RegularExpressions;

namespace adaOrderingSys
{
    public partial class main : Form
    {

        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDADataSet.customer' table. You can move, or remove it, as needed.
            this.pnlMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlAddCustomer.Visible = false;
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            
        }

        private void btnViewInventory_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            this.pnlMain.Visible = false;
            this.pnlAddCustomer.Visible = true;
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.pnlAddCustomer.Visible = false;
            this.pnlMain.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForms(this.pnlCustInfo.Controls);
         }
        private void btnSubmitCust_Click(object sender, EventArgs e)
        {
            string name, address, telephone, contactPerson;
            customer cust = new customer();

            name = txtBusinessName.Text;
            address = txtAddress.Text;
            telephone = txtTelephoneNo.Text;
            contactPerson = txtContactPerson.Text;

            int result = cust.createCustomer(name, address, telephone, contactPerson);

            switch (result)
            {
                case 0:
                    MessageBox.Show("Customer added successfully.");
                    clearForms(this.pnlCustInfo.Controls);
                    break;

                case 1:
                    MessageBox.Show("Customer already Exists!");
                    break;

                case -1:
                    MessageBox.Show("An error occured while trying to add customer. Please try again");
                    break;

                default:
                    MessageBox.Show("A fatal error occured. Please contact system administrator");
                    break;

            }
        }

        private void clearForms(Control.ControlCollection controls)
        {
            foreach (var c in controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Text = String.Empty;
                else if (c is RichTextBox)
                    ((RichTextBox)c).Text = String.Empty;
            }
        }

        private void txtTelephoneNo_TextChanged(object sender, EventArgs e)
        {

        }

        void txtTelephoneNo_Validating(object sender, CancelEventArgs e)
        {
            string text = txtTelephoneNo.Text.Replace("-", "").Replace(" ", "");
            Regex reg = new Regex(@"^\b(\d{7}|\d{10})\b");
            //Phone number must be a phone number
            if (!reg.IsMatch(text))
            {
                errorProviderTelephone.SetError(txtTelephoneNo, "Must be a phone number");
                txtTelephoneNo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4010A");
                //e.Cancel = true;
                return;
            }
            //Phone number is valid
            errorProviderTelephone.SetError(txtTelephoneNo, "");
            txtTelephoneNo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#080808");
        }
    }
}
