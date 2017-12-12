using adaOrderingSys.business_objects;
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
    public partial class changePassword : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private string userName { get; set; }
        public changePassword()
        {
            InitializeComponent();
        }

        public changePassword(string username)
        {
            this.userName = username;
            InitializeComponent();
        }

        private void btn_Change_Click(object sender, EventArgs e)
        {
            doChangePassword();
        }

        private bool isPasswordValid(string password)
        {
            Regex passwordRegex = new Regex(Constants.STRONG_PASSWORD);
            if (passwordRegex.IsMatch(password))
                return true; //Password is a strong password. 

            return false; //Password isn't strong enough
        }

        

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            passwordToolTip.SetToolTip(txtPassword, Constants.PASSWORD_RQMNTS);
        }

        private void txtConfirmPassword_MouseHover(object sender, EventArgs e)
        {
            passwordToolTip.SetToolTip(txtConfirmPassword, "Passwords must match");
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                doChangePassword();
            }
        }

        private void doChangePassword()
        {
            try
            {
                ep_ChangePassword.Clear();

                if (!isPasswordValid(txtPassword.Text))
                {
                    ep_ChangePassword.SetError(txtPassword, Constants.PASSWORD_RQMNTS);
                    txtPassword.SelectAll();
                    txtConfirmPassword.Text = "";
                    txtPassword.Focus();
                    return;
                }

                if (!txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    ep_ChangePassword.SetError(txtConfirmPassword, "Passwords do not match");
                    txtConfirmPassword.SelectAll();
                    return;
                }

                int result = new User().changePassword(this.userName, txtPassword.Text);

                switch (result)
                {
                    case 1:
                        MessageBox.Show("Password successfully changed");
                        this.Hide();
                        new loginForm().Show();
                        break;

                    case 0:
                    case -1:
                        MessageBox.Show("An error occured. Could not change password");
                        this.Hide();
                        new loginForm().Show();
                        break;

                    default:
                        MessageBox.Show(Constants.CONTACT_SYSTEMADMIN);
                        this.Close();
                        break;
                }
            }

            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("There was an error trying to change your password");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                doChangePassword();
            }
        }

        private void changePassword_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();

        }
    }
}
