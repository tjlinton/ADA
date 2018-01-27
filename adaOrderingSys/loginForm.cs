using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using adaOrderingSys.business_objects;

namespace adaOrderingSys
{
    
    public partial class loginForm : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public loginForm()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            //Once the form is loaded set the cursor to the username textbox
            this.txtUserName.Select(); 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            doLogin();
            //MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = null;
            txtPassword.Text = null;
        }

        //private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)13)
        //    {
        //        doLogin();
        //    }
        //}

        private void doLogin() {
            try
            {
                if (txtUserName.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Enter username and password!");
                }
                else
                {
                    User user = new User();
                    string response = user.loginUser(txtUserName.Text, txtPassword.Text);

                    switch (response)
                    {
                        case "-1":
                            logger.Warn("Unable to log in user " + txtUserName.Text + ". Incorrect credentials enterred");
                            MessageBox.Show("Incorrect credentials. Try Again");
                            txtPassword.SelectAll();
                            txtPassword.Focus();
                            break;
                        case "1":
                            MessageBox.Show(Constants.CONTACT_SYSTEMADMIN);
                            txtPassword.SelectAll();
                            txtPassword.Focus();
                            break;

                        default:
                            logger.Info("User: " + txtUserName.Text + " successfully logged in");
                            this.Hide();
                            if (!changePasswordDialog(txtUserName.Text)) {
                                main objFormMain = new main();
                                objFormMain.Show();
                            }
                            
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show(Constants.CONTACT_SYSTEMADMIN);
            }
        }

        private bool changePasswordDialog(string userName)
        {
            try
            {
                if (txtPassword.Text.Equals(Constants.DEFAULT_PASSWORD))
                {
                    changePassword passwordForm = new changePassword(userName);
                    passwordForm.Show();
                    return true;
                }

                return false;
            }

            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                return false;
            }
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
