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

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(34, 137);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Location = new System.Drawing.Point(179, 137);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(31, 37);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(57, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "UserName";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(31, 82);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.AcceptsTab = true;
            this.txtUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUserName.Location = new System.Drawing.Point(154, 34);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.WordWrap = false;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(154, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = 'x';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            // 
            // loginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(284, 176);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADA Ordering System";
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            doLogin();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = null;
            txtPassword.Text = null;
        }

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                doLogin();
            }
            
        }

        private void doLogin() {
            try {
                if (txtUserName.Text == "" || txtPassword.Text == "") {
                    MessageBox.Show("Enter username and password!");
                }
                else {
                    string responseMessage = "";
                    SqlConnection con = new SqlConnection(@"Data Source=LINTON-PC\TAJAYLINTON;Initial Catalog=ADA;User ID=adauser;Password=ADAUser1234");
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@pLoginName", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@pPassword", txtPassword.Text);
                    cmd.Parameters.Add("@responseMessage ", SqlDbType.NVarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandText = "[dbo].[uspLogin]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    con.Open();

                    responseMessage = Convert.ToString(cmd.ExecuteScalar());

                    con.Close();

                    logger.Info("respone message - " + responseMessage);

                    if (responseMessage == "Login successful") {
                        this.Hide();
                        main objFormMain = new main();
                        objFormMain.Show();
                    }
                    else {
                        MessageBox.Show("Incorrect credentials. Try Again");
                    }
                }
            }

            catch (Exception ex) {
                logger.Error(ex);
                MessageBox.Show("ERROR:" + "Please contact system admin");

            }

        }

    }
}
