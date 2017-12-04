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
    public partial class ViewLoadingSheets : Form
    {
        public ViewLoadingSheets()
        {
            InitializeComponent();
        }

        private void ViewLoadingSheets_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new main().Show();
        }
    }
}
