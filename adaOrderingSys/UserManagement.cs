using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using adaOrderingSys.business_objects;
using System.Data.SqlClient;

namespace adaOrderingSys
{
    public partial class UserManagement : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private DataTable dt;

        private string username { get; set; }
        public UserManagement()
        {
            InitializeComponent();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> users = new User().getUsers();
            ArrayList roles = new ArrayList();
            roles.Add(Constants.USER_ROLE_ADMIN);
            roles.Add(Constants.USER_ROLE_STAFF);
            roles.Add("");

            clmn_Role.Items.AddRange(roles.ToArray());
            for (int i = 0; i < users.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["clmn_userName"].Value = users[i].Key;
                dataGridView1.Rows[i].Cells["clmn_Role"].Value = users[i].Value;
            }
        }

        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                int result = new User().changePassword(this.username);

                switch (result) {
                    case 1:
                        MessageBox.Show("Password successfully reset for " + username);
                        break;

                    case -1:
                    case 0:
                        MessageBox.Show("Could'nt reset password please try again");
                        break;
                    default:
                        MessageBox.Show("A fatal error occured. Please contact system admin");
                        break;
                }

            }

            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                    this.username = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new main().Show();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("An unexpected error occured");
            logger.Error(e.Exception);
        }
    }
}
