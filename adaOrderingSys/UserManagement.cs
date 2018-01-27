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
using System.Text.RegularExpressions;

namespace adaOrderingSys
{
    public partial class UserManagement : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private DataTable dt { get; set; }
        private SqlDataAdapter adapter { get; set; }

        private SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING);

        private bool newRow = false;

        private string username { get; set; }

        private bool initialLoad { get; set; }
        public UserManagement()
        {
            adapter = new SqlDataAdapter();
            dt = new DataTable();
            InitializeComponent();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            List<User> users = new User().getUsers();
            ArrayList roles = new ArrayList();
            roles.Add(Constants.USER_ROLE_ADMIN);
            roles.Add(Constants.USER_ROLE_STAFF);
            roles.Add("");

            populateDataTable();

            initialLoad = true;

            clmn_Role.Items.AddRange(roles.ToArray());
            for (int i = 0; i < users.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["clmn_userID"].Value = users[i].userID;
                dataGridView1.Rows[i].Cells["clmn_userName"].Value = users[i].loginName;
                dataGridView1.Rows[i].Cells["clmn_Role"].Value = users[i].role;
            }

            initialLoad = false;
        }

        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int result = new User().changePassword(this.username);

                switch (result)
                {
                    case 1:
                        MessageBox.Show("Password successfully reset for " + username);
                        break;

                    case -1:
                    case 0:
                        MessageBox.Show("Couldn't reset password please try again");
                        break;
                    default:
                        MessageBox.Show(Constants.CONTACT_SYSTEMADMIN);
                        break;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(Constants.GENERIC_ERROR);
                logger.Error(ex.ToString);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex == dataGridView1.Columns["clmn_Username"].Index)
            {
                try
                {
                    contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                    this.username = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                catch (Exception ex)
                {
                    logger.Error(ex.ToString);
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
            logger.Error(e.Exception);
            MessageBox.Show("An unexpected error occured");
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hasErrors())
                {
                    MessageBox.Show("Clear all errors before submitting");
                    return;
                }

                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (adapter != null && adapter.UpdateCommand != null || adapter.DeleteCommand != null || adapter.InsertCommand != null)
                    {
                        //dt.AcceptChanges();

                        //adapter.Fill(dt);
                        adapter.Update(dt);

                        logger.Info("Updates have been performed on users table");
                        MessageBox.Show("Updates succesful.");
                    }
                    else
                    {
                        MessageBox.Show("Nothinng to update");
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show(Constants.GENERIC_ERROR);
            }
        }

        private bool hasErrors()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.Cells["clmn_Username"].ErrorText.Equals(""))
                    return true;
            }

            return false;
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (!initialLoad)
                {
                    newRow = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
            }
        }

        private void setInsertCmd(string username, string role)
        {
            try
            {
                string query = "[dbo].[usp_AddUser]";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@puserRole", role);

                adapter.InsertCommand = cmd;

                logger.Info("Insert set for user: " + username);

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show(Constants.GENERIC_ERROR);

            }
        }

        private void setDeleteCmd(string username)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[user] WHERE userName = @userName", conn);
                cmd.Parameters.AddWithValue("@userName", username);
                adapter.DeleteCommand = cmd;

                //dt.AcceptChanges();
                //adapter.Fill(dt);

                logger.Info("Delete command issued for: " + username);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show(Constants.GENERIC_ERROR);
            }
        }

        private void setUpdateCmd(int userID, string username, string role)
        {
            try
            {
                string updateQuery = "UPDATE [dbo].[user] SET userName = @username, userRole = @role WHERE userID = @userID";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@userID", userID);
                adapter.UpdateCommand = cmd;
                //dt.AcceptChanges();
                //adapter.Fill(dt);

                logger.Info("Update command set for: " + username);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show("An error occured. Could not update");
            }
        }

        private DataTable populateDataTable()
        {
            try
            {
                dt = new DataTable();
                //Create the datable columns in accordance to what is in the table in the db
                dt.Columns.Add("userName", typeof(string));
                dt.Columns.Add("userRole", typeof(string));

                SqlCommand cmd = new SqlCommand("SELECT userName, userRole from [dbo].[user]", conn);
                cmd.CommandType = CommandType.Text;
                adapter.SelectCommand = cmd;

                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                return null;
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                dt.Rows[e.Row.Index].Delete();

                string username = dataGridView1.Rows[e.Row.Index].Cells["clmn_Username"].Value.ToString();
                setDeleteCmd(username);

                logger.Info("set to delete user: " + username);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView1.RowCount > 1 && !initialLoad)
                {

                    int userID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmn_userID"].Value);

                    string username = dataGridView1.Rows[e.RowIndex].Cells["clmn_Username"].Value == null ? "" :
                        dataGridView1.Rows[e.RowIndex].Cells["clmn_Username"].Value.ToString();

                    string role = dataGridView1.Rows[e.RowIndex].Cells["clmn_Role"].Value == null ? "" :
                       dataGridView1.Rows[e.RowIndex].Cells["clmn_Role"].Value.ToString();

                    Regex userRegex = new Regex(@"^[a-zA-Z0-9]+([_-]?[a-zA-Z0-9])*$");

                    if (!userRegex.IsMatch(username))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["clmn_Username"].ErrorText = "Incorrect username format";
                        return;
                    }

                    if (!newRow)
                    {
                        dt.Rows[e.RowIndex][e.ColumnIndex-1] = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        setUpdateCmd(userID, username, role);

                    }
                    else
                    {
                        dt.Rows.Add();
                        dt.Rows[e.RowIndex][e.ColumnIndex] = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        newRow = false;
                        setInsertCmd(username, role);
                    }

                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                MessageBox.Show(Constants.GENERIC_ERROR);
            }
        }

        private void UserManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
