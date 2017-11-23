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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.lbl_OrderList = new System.Windows.Forms.Label();
            this.lbl_Driver = new System.Windows.Forms.Label();
            this.btnSubmitCust = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.lbl_LicenseNo = new System.Windows.Forms.Label();
            this.txtLicenseNo = new System.Windows.Forms.TextBox();
            this.pnl_Step1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbl_Orders
            // 
            this.cbl_Orders.FormattingEnabled = true;
            this.cbl_Orders.Location = new System.Drawing.Point(17, 45);
            this.cbl_Orders.Name = "cbl_Orders";
            this.cbl_Orders.Size = new System.Drawing.Size(199, 289);
            this.cbl_Orders.TabIndex = 3;
            this.cbl_Orders.ThreeDCheckBoxes = true;
            this.cbl_Orders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbl_Orders_MouseClick);
            this.cbl_Orders.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cbl_Orders_MouseUp);
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
            this.pnl_Step1.Controls.Add(this.groupBox1);
            this.pnl_Step1.Controls.Add(this.btnBack);
            this.pnl_Step1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Step1.Location = new System.Drawing.Point(0, 0);
            this.pnl_Step1.Name = "pnl_Step1";
            this.pnl_Step1.Size = new System.Drawing.Size(695, 518);
            this.pnl_Step1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.txtLocation);
            this.groupBox1.Controls.Add(this.btnSelectAll);
            this.groupBox1.Controls.Add(this.lbl_OrderList);
            this.groupBox1.Controls.Add(this.lbl_Driver);
            this.groupBox1.Controls.Add(this.btnSubmitCust);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtDriver);
            this.groupBox1.Controls.Add(this.lbl_LicenseNo);
            this.groupBox1.Controls.Add(this.txtLicenseNo);
            this.groupBox1.Controls.Add(this.cbl_Orders);
            this.groupBox1.Location = new System.Drawing.Point(80, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 441);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(222, 183);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(34, 23);
            this.btnDown.TabIndex = 30;
            this.btnDown.Text = "▼";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(222, 153);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(34, 23);
            this.btnUp.TabIndex = 29;
            this.btnUp.Text = "▲";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(336, 238);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 28;
            this.lblLocation.Text = "Location:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(393, 235);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(130, 20);
            this.txtLocation.TabIndex = 27;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(75, 340);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 26;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // lbl_OrderList
            // 
            this.lbl_OrderList.AutoSize = true;
            this.lbl_OrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OrderList.Location = new System.Drawing.Point(23, 16);
            this.lbl_OrderList.Name = "lbl_OrderList";
            this.lbl_OrderList.Size = new System.Drawing.Size(78, 20);
            this.lbl_OrderList.TabIndex = 25;
            this.lbl_OrderList.Text = "Order List";
            // 
            // lbl_Driver
            // 
            this.lbl_Driver.AutoSize = true;
            this.lbl_Driver.Location = new System.Drawing.Point(336, 195);
            this.lbl_Driver.Name = "lbl_Driver";
            this.lbl_Driver.Size = new System.Drawing.Size(41, 13);
            this.lbl_Driver.TabIndex = 7;
            this.lbl_Driver.Text = "Driver: ";
            // 
            // btnSubmitCust
            // 
            this.btnSubmitCust.BackColor = System.Drawing.Color.Green;
            this.btnSubmitCust.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitCust.ForeColor = System.Drawing.Color.Gold;
            this.btnSubmitCust.Location = new System.Drawing.Point(393, 277);
            this.btnSubmitCust.Name = "btnSubmitCust";
            this.btnSubmitCust.Size = new System.Drawing.Size(92, 45);
            this.btnSubmitCust.TabIndex = 23;
            this.btnSubmitCust.Text = "Submit";
            this.btnSubmitCust.UseVisualStyleBackColor = false;
            this.btnSubmitCust.Click += new System.EventHandler(this.btnSubmitCust_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(339, 109);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 24;
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(393, 195);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(130, 20);
            this.txtDriver.TabIndex = 6;
            // 
            // lbl_LicenseNo
            // 
            this.lbl_LicenseNo.AutoSize = true;
            this.lbl_LicenseNo.Location = new System.Drawing.Point(339, 154);
            this.lbl_LicenseNo.Name = "lbl_LicenseNo";
            this.lbl_LicenseNo.Size = new System.Drawing.Size(34, 17);
            this.lbl_LicenseNo.TabIndex = 5;
            this.lbl_LicenseNo.Text = "Lic #: ";
            this.lbl_LicenseNo.UseCompatibleTextRendering = true;
            // 
            // txtLicenseNo
            // 
            this.txtLicenseNo.Location = new System.Drawing.Point(393, 154);
            this.txtLicenseNo.MaxLength = 6;
            this.txtLicenseNo.Name = "txtLicenseNo";
            this.txtLicenseNo.Size = new System.Drawing.Size(76, 20);
            this.txtLicenseNo.TabIndex = 4;
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 518);
            this.Controls.Add(this.pnl_Step1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SummaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summary";
            this.pnl_Step1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cbl_Orders;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnl_Step1;
        private System.Windows.Forms.Button btnSubmitCust;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Driver;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label lbl_LicenseNo;
        private System.Windows.Forms.TextBox txtLicenseNo;
        private System.Windows.Forms.Label lbl_OrderList;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
    }
}