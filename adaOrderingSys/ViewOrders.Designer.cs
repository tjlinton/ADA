namespace adaOrderingSys
{
    partial class ViewOrders
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewOrders));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_NewOrder = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.list_Orders = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_OrderID = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.rtxtLocation = new System.Windows.Forms.RichTextBox();
            this.cb_Customer = new System.Windows.Forms.ComboBox();
            this.lbl_Location = new System.Windows.Forms.Label();
            this.lbl_Customer = new System.Windows.Forms.Label();
            this.dgvItemsOrdered = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_DeleteOrder = new System.Windows.Forms.Button();
            this.btn_UpdateOrder = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ViewOrdersToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsOrdered)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_NewOrder);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.list_Orders);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_DeleteOrder);
            this.panel1.Controls.Add(this.btn_UpdateOrder);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 554);
            this.panel1.TabIndex = 0;
            // 
            // btn_NewOrder
            // 
            this.btn_NewOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_NewOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NewOrder.ForeColor = System.Drawing.Color.Yellow;
            this.btn_NewOrder.Location = new System.Drawing.Point(796, 12);
            this.btn_NewOrder.Name = "btn_NewOrder";
            this.btn_NewOrder.Size = new System.Drawing.Size(113, 39);
            this.btn_NewOrder.TabIndex = 15;
            this.btn_NewOrder.Text = "New Order";
            this.btn_NewOrder.UseVisualStyleBackColor = false;
            this.btn_NewOrder.Click += new System.EventHandler(this.btn_NewOrder_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(539, 494);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 37);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // list_Orders
            // 
            this.list_Orders.FormattingEnabled = true;
            this.list_Orders.Location = new System.Drawing.Point(16, 132);
            this.list_Orders.Name = "list_Orders";
            this.list_Orders.Size = new System.Drawing.Size(168, 355);
            this.list_Orders.TabIndex = 13;
            this.list_Orders.SelectedIndexChanged += new System.EventHandler(this.list_Orders_SelectedIndexChanged);
            this.list_Orders.DoubleClick += new System.EventHandler(this.list_Orders_DoubleClick);
            this.list_Orders.MouseHover += new System.EventHandler(this.list_Orders_MouseHover);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_OrderID);
            this.groupBox1.Controls.Add(this.txtGrandTotal);
            this.groupBox1.Controls.Add(this.lblGrandTotal);
            this.groupBox1.Controls.Add(this.rtxtLocation);
            this.groupBox1.Controls.Add(this.cb_Customer);
            this.groupBox1.Controls.Add(this.lbl_Location);
            this.groupBox1.Controls.Add(this.lbl_Customer);
            this.groupBox1.Controls.Add(this.dgvItemsOrdered);
            this.groupBox1.Location = new System.Drawing.Point(218, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 379);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // lbl_OrderID
            // 
            this.lbl_OrderID.AutoSize = true;
            this.lbl_OrderID.Location = new System.Drawing.Point(25, 27);
            this.lbl_OrderID.Name = "lbl_OrderID";
            this.lbl_OrderID.Size = new System.Drawing.Size(0, 13);
            this.lbl_OrderID.TabIndex = 22;
            this.lbl_OrderID.Visible = false;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.Location = new System.Drawing.Point(595, 61);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(76, 26);
            this.txtGrandTotal.TabIndex = 21;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(577, 23);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(108, 24);
            this.lblGrandTotal.TabIndex = 20;
            this.lblGrandTotal.Text = "Grand Total";
            // 
            // rtxtLocation
            // 
            this.rtxtLocation.Location = new System.Drawing.Point(176, 61);
            this.rtxtLocation.Name = "rtxtLocation";
            this.rtxtLocation.Size = new System.Drawing.Size(179, 49);
            this.rtxtLocation.TabIndex = 16;
            this.rtxtLocation.Text = "";
            // 
            // cb_Customer
            // 
            this.cb_Customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Customer.FormattingEnabled = true;
            this.cb_Customer.Location = new System.Drawing.Point(176, 24);
            this.cb_Customer.Name = "cb_Customer";
            this.cb_Customer.Size = new System.Drawing.Size(179, 21);
            this.cb_Customer.TabIndex = 15;
            this.cb_Customer.MouseHover += new System.EventHandler(this.cb_Customer_MouseHover);
            // 
            // lbl_Location
            // 
            this.lbl_Location.AutoSize = true;
            this.lbl_Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Location.Location = new System.Drawing.Point(87, 74);
            this.lbl_Location.Name = "lbl_Location";
            this.lbl_Location.Size = new System.Drawing.Size(62, 17);
            this.lbl_Location.TabIndex = 14;
            this.lbl_Location.Text = "Location";
            // 
            // lbl_Customer
            // 
            this.lbl_Customer.AutoSize = true;
            this.lbl_Customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Customer.Location = new System.Drawing.Point(84, 27);
            this.lbl_Customer.Name = "lbl_Customer";
            this.lbl_Customer.Size = new System.Drawing.Size(68, 17);
            this.lbl_Customer.TabIndex = 12;
            this.lbl_Customer.Text = "Customer";
            // 
            // dgvItemsOrdered
            // 
            this.dgvItemsOrdered.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemsOrdered.Location = new System.Drawing.Point(26, 127);
            this.dgvItemsOrdered.Name = "dgvItemsOrdered";
            this.dgvItemsOrdered.Size = new System.Drawing.Size(643, 235);
            this.dgvItemsOrdered.TabIndex = 4;
            this.dgvItemsOrdered.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvItemsOrdered_CellValidating);
            this.dgvItemsOrdered.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemsOrdered_CellValueChanged);
            this.dgvItemsOrdered.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvItemsOrdered_DataError);
            this.dgvItemsOrdered.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvItemsOrdered_RowsRemoved);
            this.dgvItemsOrdered.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvItemsOrdered_UserDeletedRow);
            this.dgvItemsOrdered.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvItemsOrdered_UserDeletingRow);
            this.dgvItemsOrdered.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvItemsOrdered_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select Order: ";
            // 
            // btn_DeleteOrder
            // 
            this.btn_DeleteOrder.Location = new System.Drawing.Point(458, 494);
            this.btn_DeleteOrder.Name = "btn_DeleteOrder";
            this.btn_DeleteOrder.Size = new System.Drawing.Size(75, 37);
            this.btn_DeleteOrder.TabIndex = 9;
            this.btn_DeleteOrder.Text = "Delete Order";
            this.btn_DeleteOrder.UseVisualStyleBackColor = true;
            this.btn_DeleteOrder.Click += new System.EventHandler(this.btn_DeleteOrder_Click);
            // 
            // btn_UpdateOrder
            // 
            this.btn_UpdateOrder.Location = new System.Drawing.Point(377, 494);
            this.btn_UpdateOrder.Name = "btn_UpdateOrder";
            this.btn_UpdateOrder.Size = new System.Drawing.Size(75, 37);
            this.btn_UpdateOrder.TabIndex = 5;
            this.btn_UpdateOrder.Text = "Update";
            this.btn_UpdateOrder.UseVisualStyleBackColor = true;
            this.btn_UpdateOrder.Click += new System.EventHandler(this.btn_UpdateOrder_Click);
            this.btn_UpdateOrder.MouseHover += new System.EventHandler(this.btn_UpdateOrder_MouseHover);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Yellow;
            this.btnBack.Location = new System.Drawing.Point(16, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(113, 39);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "◀ Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 75);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(188, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2017, 8, 28, 18, 14, 5, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // ViewOrdersToolTip
            // 
            this.ViewOrdersToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // ViewOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 554);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ViewOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewOrders";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewOrders_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsOrdered)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_DeleteOrder;
        private System.Windows.Forms.Button btn_UpdateOrder;
        public System.Windows.Forms.DataGridView dgvItemsOrdered;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtxtLocation;
        private System.Windows.Forms.ComboBox cb_Customer;
        private System.Windows.Forms.Label lbl_Location;
        private System.Windows.Forms.Label lbl_Customer;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.ListBox list_Orders;
        private System.Windows.Forms.ToolTip ViewOrdersToolTip;
        private System.Windows.Forms.Label lbl_OrderID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btn_NewOrder;
    }
}