﻿using adaOrderingSys.business_objects;
using NLog;
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
    public partial class ViewLoadingSheets : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private DataTable dt { get; set; }
        private DataSet ds { get; set; }
        private SqlDataAdapter adapter { get; set; }

        private SqlConnection conn = new SqlConnection(Constants.CONNECTIONSTRING);

        public ViewLoadingSheets()
        {
            adapter = new SqlDataAdapter();
            dt = new DataTable();
            ds = new DataSet();
            InitializeComponent();
        }

        private void ViewLoadingSheets_Load(object sender, EventArgs e)
        {
            populateDataTable();
        }

        private void populateDataTable()
        {
            try
            {
                dt.Columns.Add(Constants.SUMMARYID, typeof(int)).ReadOnly = true;
                dt.Columns.Add(Constants.SUMMARYDATE, typeof(DateTime)).ReadOnly = true;
                dt.Columns.Add(Constants.CREATEDBY, typeof(string)).ReadOnly = false;
                dt.Columns.Add(Constants.LICENSENO, typeof(string)).ReadOnly = false;
                dt.Columns.Add(Constants.DRIVER, typeof(string)).ReadOnly = false;

                dt.PrimaryKey = new DataColumn[] { dt.Columns[Constants.SUMMARYID] };

                SqlCommand cmd = new SqlCommand("[dbo].[usp_GetSummaries]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand = cmd;

                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new main().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (adapter.DeleteCommand != null || adapter.UpdateCommand != null)
                {
                    adapter.Update(dt);
                    logger.Info("Updates made to summary by " + User.userName);
                    MessageBox.Show("Successfully updated");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not make changes");
                logger.Error(ex);
            } 
        }

        private void btn_CreateNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new SummaryForm().Show();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Error occured. Can't display new Summary Form");
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                e.Cancel = MessageBox.Show("Do you want really to delete the selected row", "Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK;
                if (e.Cancel) { return; }

                int summaryID = Convert.ToInt32(dataGridView1.Rows[e.Row.Index].Cells[Constants.SUMMARYID].Value);

                SqlCommand cmd = new SqlCommand("[dbo].[usp_RemoveSummary]",conn);
                cmd.Parameters.AddWithValue("@summaryID", summaryID);
                adapter.DeleteCommand = cmd;

                dt.AcceptChanges();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        //private void setDeleteCmd(int summaryID)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(@"DELETE FROM summary WHERE summaryID = @summaryID", conn);
        //        cmd.Parameters.AddWithValue("@summaryID", summaryID);

        //        adapter.DeleteCommand = cmd;

        //        dt.AcceptChanges();
        //        adapter.Fill(dt);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(Constants.GENERIC_ERROR);
        //        logger.Error(ex);
        //    }
        //}

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int summaryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[Constants.SUMMARYID].Value);

                SqlCommand cmd = new SqlCommand();

                if (e.ColumnIndex == dataGridView1.Columns[Constants.CREATEDBY].Index)
                {
                    string createdBy = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    cmd.CommandText = "UPDATE [dbo].[summary] SET createdBy = @createdBy WHERE summaryID = @summaryID";
                    cmd.Parameters.AddWithValue("@createdBy", createdBy);
                }

                if (e.ColumnIndex == dataGridView1.Columns[Constants.DRIVER].Index)
                {
                    string driver = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    cmd.CommandText = "UPDATE [dbo].[summar] SET driver = @driver WHERE summaryID = @summaryID";
                    cmd.Parameters.AddWithValue("@driver", driver);
                }

                if (e.ColumnIndex == dataGridView1.Columns[Constants.LICENSENO].Index)
                {
                    string licenseNo = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    cmd.CommandText = "UPDATE [dbo].[summar] SET licenseNo = @dlicenseNo WHERE summaryID = @summaryID";
                    cmd.Parameters.AddWithValue("@licenseNo", licenseNo);
                }


                cmd.Parameters.AddWithValue("@summaryID", summaryID);
                cmd.Connection = conn;
                adapter.UpdateCommand = cmd;
                dt.AcceptChanges();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("There was an error updating the cell: " + ex.Message);
            }
        }
        
    }
}
