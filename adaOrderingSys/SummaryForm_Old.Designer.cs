namespace adaOrderingSys
{
    partial class SummaryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryForm));
            this.cbl_Orders = new System.Windows.Forms.CheckedListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnl_Step1 = new System.Windows.Forms.Panel();
            this.btnSubmitCust = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pnl_Step1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbl_Orders
            // 
            this.cbl_Orders.CheckOnClick = true;
            this.cbl_Orders.FormattingEnabled = true;
            this.cbl_Orders.Location = new System.Drawing.Point(164, 95);
            this.cbl_Orders.Name = "cbl_Orders";
            this.cbl_Orders.Size = new System.Drawing.Size(199, 304);
            this.cbl_Orders.TabIndex = 3;
            this.cbl_Orders.DoubleClick += new System.EventHandler(this.cbl_Orders_DoubleClick);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Yellow;
            this.btnBack.Location = new System.Drawing.Point(3, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(113, 39);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "◀ Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnl_Step1
            // 
            this.pnl_Step1.Controls.Add(this.dateTimePicker1);
            this.pnl_Step1.Controls.Add(this.btnSubmitCust);
            this.pnl_Step1.Controls.Add(this.btnBack);
            this.pnl_Step1.Controls.Add(this.cbl_Orders);
            this.pnl_Step1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Step1.Location = new System.Drawing.Point(0, 0);
            this.pnl_Step1.Name = "pnl_Step1";
            this.pnl_Step1.Size = new System.Drawing.Size(744, 487);
            this.pnl_Step1.TabIndex = 8;
            // 
            // btnSubmitCust
            // 
            this.btnSubmitCust.BackColor = System.Drawing.Color.Green;
            this.btnSubmitCust.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitCust.ForeColor = System.Drawing.Color.Gold;
            this.btnSubmitCust.Location = new System.Drawing.Point(221, 416);
            this.btnSubmitCust.Name = "btnSubmitCust";
            this.btnSubmitCust.Size = new System.Drawing.Size(75, 32);
            this.btnSubmitCust.TabIndex = 23;
            this.btnSubmitCust.Text = "Submit";
            this.btnSubmitCust.UseVisualStyleBackColor = false;
            this.btnSubmitCust.Click += new System.EventHandler(this.btnSubmitCust_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(163, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 24;
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 487);
            this.Controls.Add(this.pnl_Step1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SummaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summary";
            this.pnl_Step1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cbl_Orders;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnl_Step1;
        private System.Windows.Forms.Button btnSubmitCust;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}