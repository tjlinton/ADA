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

namespace adaOrderingSys
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
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
            this.txtUserName.Location = new System.Drawing.Point(154, 34);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.WordWrap = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(154, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // login
            // 
            this.ClientSize = new System.Drawing.Size(284, 178);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLogin);
            this.Name = "login";
            this.Text = "ADA Ordering System";
            this.Load += new System.EventHandler(this.login_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void login_Load_1(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LINTON-PC\TAJAYLINTON;Initial Catalog=ADA;User ID=adauser;Password=ADAUser1234");
                //          SqlConnection con = new SqlConnection(@"Data Source=LINTON-PC\TAJAYLINTON;Initial Catalog=ADA;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "Select count(*)  from user where userName = " + txtUserName.Text + " AND password = " + txtPassword.Text;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();

                int res = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();
                if (res == 1)
                {
                    this.Hide();
                    main objFormMain = new main();
                    objFormMain.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect credentials. Try Again");
                }
            }

            catch(Exception ex) {
                Console.WriteLine("ERROR:" + ex);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = null;
            txtPassword.Text = null;
        }
    }
}
