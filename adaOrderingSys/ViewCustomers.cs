using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adaOrderingSys
{
    public partial class ViewCustomers : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public ViewCustomers()
        {
            InitializeComponent();
        }

        private void ViewCustomers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDADataSet2.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.aDADataSet2.customer);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                main mainForm = new main();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
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
    }
}
