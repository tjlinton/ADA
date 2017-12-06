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
using System.Data.SqlClient;
using System.Configuration;

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
            // TODO: This line of code loads data into the 'aDAItemDataSet.item' table. You can move, or remove it, as needed.
            this.itemTableAdapter.Fill(this.aDAItemDataSet.item);
            // TODO: This line of code loads data into the 'aDADataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.aDADataSet.customer);
            this.pnlMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMainII.Hide();
            this.btn_Logout.Show();

            if (User.userRole != Constants.USER_ROLE_ADMIN)
            {
                this.btnNewProduct.Hide();
                this.pictureBox_UM.Hide();
                this.btnViewInventory.Hide();
            }
        }

        //--------------------------------------------------------------------------
        //  Validating Events
        //--------------------------------------------------------------------------

        private void txtProductID_Validating(object sender, CancelEventArgs e)
        {
            string text = txtProductID.Text.Trim();
            if (text == null || text == "")
            {
                errorProviderTxtProductID.SetError(txtProductID, "Please enter a product ID");
            }
            else
            {
                errorProviderTxtProductID.SetError(txtProductID, "");
            }
        }

        void txtTelephoneNo_Validating(object sender, CancelEventArgs e)
        {
            string text = txtTelephoneNo.Text.Replace("-", "").Replace(" ", "");
            Regex reg = new Regex(@"^\b(\d{7}|\d{10})\b");

            //text entered must be a phone number
            if (!reg.IsMatch(text))
            {
                errorProviderTelephone.SetError(txtTelephoneNo, "Must be a phone number");
                txtTelephoneNo.ForeColor = ColorTranslator.FromHtml("#B4010A");
                //e.Cancel = true;
                return;
            }
            //Phone number is valid
            errorProviderTelephone.SetError(txtTelephoneNo, "");
            txtTelephoneNo.ForeColor = ColorTranslator.FromHtml("#080808");
        }

        private void txtUnitPrice_Validating(object sender, CancelEventArgs e)
        {
            Regex priceReg = new Regex(@"^((\d+)|(\d+\.\d{2}))$");
            if (!priceReg.IsMatch(txtUnitPrice.Text))
            {
                errorProviderUnitPrice.SetError(txtUnitPrice, "Must be a real price. eg: 100.50");
                txtUnitPrice.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4010A");
            }
            else
            {
                double price = Convert.ToDouble(txtUnitPrice.Text);
                if (price <= 0)
                {
                    errorProviderUnitPrice.SetError(txtUnitPrice, "Price can't be zero !");
                }
                errorProviderUnitPrice.SetError(txtUnitPrice, "");
                txtUnitPrice.ForeColor = System.Drawing.ColorTranslator.FromHtml("#080808");
            }

        }

        private void txtProductName_Validating(object sender, CancelEventArgs e)
        {
            string text = txtProductName.Text.Trim();
            if (text == null || text == "")
            {
                errorProviderTxtProductID.SetError(txtProductName, "Please enter a product Name");
            }
            else
            {
                errorProviderTxtProductID.SetError(txtProductName, "");
            }
        }

        //---------------------------------------------------------------------------
        //  Key Press Events
        //---------------------------------------------------------------------------

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && !Char.IsControl(ch))
            {
                e.Handled = true;
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(ch) && !char.IsDigit(ch) && (ch != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((ch == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }


        //-------------------------------------------------------------------------------
        //  Button Click Events
        //-------------------------------------------------------------------------------

        private void btnClearProduct_Click(object sender, EventArgs e)
        {
            clearForms(this.pnlProductInfo.Controls);
        }

        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            clearForms(this.pnlCustInfo.Controls);
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

        // ---------------------------------------------------------------------------------------
        //                          EVENTS TO RETURN VIEWS
        // ---------------------------------------------------------------------------------------
        private void btnViewInventory_Click(object sender, EventArgs e)
        {
            this.pnlMain.Hide();
            this.pnlMainII.Show();
            this.pnlProductInfo.Hide();
            this.pnlCustInfo.Hide();
            this.pnl_ViewInventory.Show();
            this.btn_Logout.Hide();
            this.pictureBox_UM.Hide();

        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            newOrder new_order = new newOrder();
            new_order.Show();
            this.Hide();

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            this.pnlMain.Hide();
            this.pnlMainII.Show();
            this.pnlProductInfo.Hide();
            this.pnl_ViewInventory.Hide();
            this.pnlCustInfo.Show();
            this.btn_Logout.Hide();
            this.pictureBox_UM.Hide();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            this.pnlMain.Hide();
            this.pnlMainII.Show();
            this.pnlProductInfo.Show();
            this.pnl_ViewInventory.Hide();
            this.pnlCustInfo.Hide();
            this.btn_Logout.Hide();
            this.pictureBox_UM.Hide();
        }

        private void btn_ViewOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewOrders viewOrders = new ViewOrders();
            viewOrders.Show();

        }

        private void btnCreateSummary_Click(object sender, EventArgs e)
        {
            this.Hide();
            SummaryForm summary = new SummaryForm();
            summary.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.pnlMainII.Hide();
            this.pnlMain.Show();
            this.btn_Logout.Show();
            this.pictureBox_UM.Show();
        }


        // -------------------------------------------------------------------------
        //                      Submit Events
        // --------------------------------------------------------------------------
        private void btnSubmitCust_Click(object sender, EventArgs e)
        {
            try
            {
                //bool isEmpty = areFieldsEmpty(this.pnlCustInfo.Controls); //Check if any textboxes on form are empty
                string name, address, telephone, contactPerson;
                Customer cust = new Customer();

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
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("An error occured. Please try again");
            }
        }

        private void btnSubmitProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Item newProduct = new Item();

                bool isEmpty = areFieldsEmpty(this.pnlProductInfo.Controls); //Check if any textbox fields are empty

                string ep_txtProductID = errorProviderTxtProductID.GetError(txtProductID);
                string ep_txtUnitPrice = errorProviderUnitPrice.GetError(txtUnitPrice);

                if (ep_txtProductID != "" || ep_txtUnitPrice != "")
                {
                    return;
                }

                if (!isEmpty)
                {
                    string pID, pName, pDescription;
                    int pQuantity;
                    Decimal pPrice;

                    //Assign text box values to variables
                    pID = txtProductID.Text;
                    pName = txtProductName.Text;
                    pDescription = txtProductDescription.Text;
                    pQuantity = Convert.ToInt32(txtQuantity.Text);
                    pPrice = Convert.ToDecimal(txtUnitPrice.Text);

                    if (pPrice <= 0)
                    {
                        errorProviderUnitPrice.SetError(txtUnitPrice, "Price cannot be zero or less");
                        return;
                    }

                    int result = newProduct.createItem(pID, pName, pPrice, pDescription, pQuantity);
                    switch (result)
                    {
                        case 0:
                            MessageBox.Show("Product already exists!");
                            break;

                        case 1:
                            MessageBox.Show("Product added successfully.");
                            clearForms(this.pnlProductInfo.Controls);
                            break;

                        case -1:
                            MessageBox.Show("An error occured while trying to add product. Please try again");
                            break;

                        default:
                            MessageBox.Show("A fatal error occured. Please contact system administrator");
                            break;
                    }
                }
                else //one or more fields are empty
                {
                    MessageBox.Show("Please fill in all product information before submitting");
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("An error occured. Please try again.");
            }
        }

        //--------------------------------------------------------------------
        //  Custom methods
        //--------------------------------------------------------------------
        private bool areFieldsEmpty(Control.ControlCollection controls)
        {
            foreach (var c in controls)
            {
                if (c is TextBox)
                {
                    if (((TextBox)c).Text == null || ((TextBox)c).Text == "")
                        return true;
                }
                else if (c is RichTextBox)
                {
                    if (((RichTextBox)c).Text == null || ((RichTextBox)c).Text == "")
                        return true;
                }
            }
            return false;
        }

        private void btn_SubmitItemChanges_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.itemBindingSource.EndEdit();
                this.itemTableAdapter.Update(this.aDAItemDataSet.item);
                MessageBox.Show("Updates successful");
            }

            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("There has been an error updating items. Please try again.");
            }
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "main")
                    Application.OpenForms[i].Hide();
            }

            this.Hide();
            loginForm login = new loginForm();
            login.Show();

        }

        private void btnViewCustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCustomer viewCust = new ViewCustomer();
            viewCust.Show();
        }

        private void btn_ViewLoadingSheet_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewLoadingSheets viewSheets = new ViewLoadingSheets();
            viewSheets.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserManagement umForm = new UserManagement();
            umForm.Show();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox_UM.Cursor = Cursors.Hand;
        }
    }
}
