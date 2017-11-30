using System.Windows.Forms;
namespace adaOrderingSys
{
    partial class newOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newOrder));
            this.pnlAddOrder = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_SalesNo = new System.Windows.Forms.NumericUpDown();
            this.lbl_SalesNo = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.rtxt_Location = new System.Windows.Forms.RichTextBox();
            this.ddl_Customer = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aDADataSet = new adaOrderingSys.ADADataSet();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.numeric_Additionals = new System.Windows.Forms.NumericUpDown();
            this.lbl_Additionals = new System.Windows.Forms.Label();
            this.txt_Quantity = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddl_Item = new System.Windows.Forms.ComboBox();
            this.itemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.aDADataSet1 = new adaOrderingSys.ADADataSet1();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Order = new System.Windows.Forms.DataGridView();
            this.clmn_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_CustName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_SalesNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_Additionals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClearGV = new System.Windows.Forms.Button();
            this.btnSubmitGV = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.customerTableAdapter = new adaOrderingSys.ADADataSetTableAdapters.customerTableAdapter();
            this.aDADataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemTableAdapter = new adaOrderingSys.ADADataSet1TableAdapters.itemTableAdapter();
            this.ep_Quantity = new System.Windows.Forms.ErrorProvider(this.components);
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ep_Item = new System.Windows.Forms.ErrorProvider(this.components);
            this.ep_Customer = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlAddOrder.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_SalesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Additionals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Customer)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAddOrder
            // 
            this.pnlAddOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlAddOrder.Controls.Add(this.groupBox4);
            this.pnlAddOrder.Controls.Add(this.txtGrandTotal);
            this.pnlAddOrder.Controls.Add(this.groupBox3);
            this.pnlAddOrder.Controls.Add(this.lblGrandTotal);
            this.pnlAddOrder.Controls.Add(this.groupBox1);
            this.pnlAddOrder.Controls.Add(this.btnClearGV);
            this.pnlAddOrder.Controls.Add(this.btnSubmitGV);
            this.pnlAddOrder.Controls.Add(this.btnDelete);
            this.pnlAddOrder.Location = new System.Drawing.Point(-23, 31);
            this.pnlAddOrder.Name = "pnlAddOrder";
            this.pnlAddOrder.Size = new System.Drawing.Size(929, 493);
            this.pnlAddOrder.TabIndex = 4;
            this.pnlAddOrder.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.numeric_SalesNo);
            this.groupBox4.Controls.Add(this.lbl_SalesNo);
            this.groupBox4.Controls.Add(this.lblCustomer);
            this.groupBox4.Controls.Add(this.rtxt_Location);
            this.groupBox4.Controls.Add(this.ddl_Customer);
            this.groupBox4.Location = new System.Drawing.Point(90, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(357, 177);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Location";
            // 
            // numeric_SalesNo
            // 
            this.numeric_SalesNo.Location = new System.Drawing.Point(103, 141);
            this.numeric_SalesNo.Name = "numeric_SalesNo";
            this.numeric_SalesNo.Size = new System.Drawing.Size(48, 20);
            this.numeric_SalesNo.TabIndex = 2;
            // 
            // lbl_SalesNo
            // 
            this.lbl_SalesNo.AutoSize = true;
            this.lbl_SalesNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SalesNo.Location = new System.Drawing.Point(6, 135);
            this.lbl_SalesNo.Name = "lbl_SalesNo";
            this.lbl_SalesNo.Size = new System.Drawing.Size(71, 24);
            this.lbl_SalesNo.TabIndex = 18;
            this.lbl_SalesNo.Text = "Sales #";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(6, 16);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(91, 24);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Customer";
            // 
            // rtxt_Location
            // 
            this.rtxt_Location.Location = new System.Drawing.Point(103, 62);
            this.rtxt_Location.MaxLength = 100;
            this.rtxt_Location.Name = "rtxt_Location";
            this.rtxt_Location.Size = new System.Drawing.Size(220, 56);
            this.rtxt_Location.TabIndex = 1;
            this.rtxt_Location.Text = "";
            // 
            // ddl_Customer
            // 
            this.ddl_Customer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddl_Customer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddl_Customer.DataSource = this.customerBindingSource;
            this.ddl_Customer.DisplayMember = "custName";
            this.ddl_Customer.FormattingEnabled = true;
            this.ddl_Customer.Location = new System.Drawing.Point(103, 19);
            this.ddl_Customer.Name = "ddl_Customer";
            this.ddl_Customer.Size = new System.Drawing.Size(173, 21);
            this.ddl_Customer.TabIndex = 0;
            this.ddl_Customer.ValueMember = "custID";
            this.ddl_Customer.SelectedIndexChanged += new System.EventHandler(this.ddl_Customer_SelectedIndexChanged);
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "customer";
            this.customerBindingSource.DataSource = this.aDADataSet;
            // 
            // aDADataSet
            // 
            this.aDADataSet.DataSetName = "ADADataSet";
            this.aDADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.Location = new System.Drawing.Point(810, 416);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(76, 26);
            this.txtGrandTotal.TabIndex = 19;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Clear);
            this.groupBox3.Controls.Add(this.btn_Add);
            this.groupBox3.Controls.Add(this.numeric_Additionals);
            this.groupBox3.Controls.Add(this.lbl_Additionals);
            this.groupBox3.Controls.Add(this.txt_Quantity);
            this.groupBox3.Controls.Add(this.lblItem);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.ddl_Item);
            this.groupBox3.Location = new System.Drawing.Point(469, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 196);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(175, 153);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 30);
            this.btn_Clear.TabIndex = 18;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(81, 153);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 29);
            this.btn_Add.TabIndex = 17;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // numeric_Additionals
            // 
            this.numeric_Additionals.Location = new System.Drawing.Point(129, 100);
            this.numeric_Additionals.Name = "numeric_Additionals";
            this.numeric_Additionals.Size = new System.Drawing.Size(48, 20);
            this.numeric_Additionals.TabIndex = 5;
            // 
            // lbl_Additionals
            // 
            this.lbl_Additionals.AutoSize = true;
            this.lbl_Additionals.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Additionals.Location = new System.Drawing.Point(6, 94);
            this.lbl_Additionals.Name = "lbl_Additionals";
            this.lbl_Additionals.Size = new System.Drawing.Size(102, 24);
            this.lbl_Additionals.TabIndex = 16;
            this.lbl_Additionals.Text = "Additionals";
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Location = new System.Drawing.Point(129, 57);
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.Size = new System.Drawing.Size(48, 20);
            this.txt_Quantity.TabIndex = 4;
            this.txt_Quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Quantity_KeyPress);
            this.txt_Quantity.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Quantity_Validating);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(9, 16);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(45, 24);
            this.lblItem.TabIndex = 10;
            this.lblItem.Text = "Item";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Quantity";
            // 
            // ddl_Item
            // 
            this.ddl_Item.DataSource = this.itemBindingSource1;
            this.ddl_Item.DisplayMember = "itemName";
            this.ddl_Item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Item.FormattingEnabled = true;
            this.ddl_Item.Location = new System.Drawing.Point(129, 19);
            this.ddl_Item.Name = "ddl_Item";
            this.ddl_Item.Size = new System.Drawing.Size(173, 21);
            this.ddl_Item.TabIndex = 3;
            this.ddl_Item.ValueMember = "itemID";
            this.ddl_Item.SelectedIndexChanged += new System.EventHandler(this.ddl_Item_SelectedIndexChanged);
            // 
            // itemBindingSource1
            // 
            this.itemBindingSource1.DataMember = "item";
            this.itemBindingSource1.DataSource = this.aDADataSet1;
            // 
            // aDADataSet1
            // 
            this.aDADataSet1.DataSetName = "ADADataSet1";
            this.aDADataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(793, 374);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(108, 24);
            this.lblGrandTotal.TabIndex = 18;
            this.lblGrandTotal.Text = "Grand Total";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Order);
            this.groupBox1.Location = new System.Drawing.Point(87, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 193);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // dgv_Order
            // 
            this.dgv_Order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmn_ID,
            this.clmn_ItemName,
            this.clmn_CustName,
            this.clmn_Location,
            this.clmn_SalesNo,
            this.clmn_Quantity,
            this.clmn_Additionals,
            this.clmn_UnitPrice,
            this.clmn_TotalCost});
            this.dgv_Order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Order.Location = new System.Drawing.Point(3, 16);
            this.dgv_Order.Name = "dgv_Order";
            this.dgv_Order.Size = new System.Drawing.Size(694, 174);
            this.dgv_Order.TabIndex = 8;
            this.dgv_Order.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Order_CellValueChanged);
            this.dgv_Order.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_Order_RowsRemoved);
            // 
            // clmn_ID
            // 
            this.clmn_ID.HeaderText = "ID";
            this.clmn_ID.Name = "clmn_ID";
            this.clmn_ID.ReadOnly = true;
            this.clmn_ID.Width = 60;
            // 
            // clmn_ItemName
            // 
            this.clmn_ItemName.HeaderText = "Item Name";
            this.clmn_ItemName.Name = "clmn_ItemName";
            this.clmn_ItemName.ReadOnly = true;
            // 
            // clmn_CustName
            // 
            this.clmn_CustName.HeaderText = "Customer Name";
            this.clmn_CustName.Name = "clmn_CustName";
            this.clmn_CustName.ReadOnly = true;
            this.clmn_CustName.Width = 120;
            // 
            // clmn_Location
            // 
            this.clmn_Location.HeaderText = "Location";
            this.clmn_Location.Name = "clmn_Location";
            // 
            // clmn_SalesNo
            // 
            this.clmn_SalesNo.HeaderText = "Sales #";
            this.clmn_SalesNo.Name = "clmn_SalesNo";
            this.clmn_SalesNo.Width = 45;
            // 
            // clmn_Quantity
            // 
            this.clmn_Quantity.HeaderText = "Quantity";
            this.clmn_Quantity.Name = "clmn_Quantity";
            this.clmn_Quantity.Width = 50;
            // 
            // clmn_Additionals
            // 
            this.clmn_Additionals.HeaderText = "Additionals";
            this.clmn_Additionals.Name = "clmn_Additionals";
            this.clmn_Additionals.Width = 60;
            // 
            // clmn_UnitPrice
            // 
            this.clmn_UnitPrice.HeaderText = "Unit Price";
            this.clmn_UnitPrice.Name = "clmn_UnitPrice";
            this.clmn_UnitPrice.ReadOnly = true;
            this.clmn_UnitPrice.Width = 52;
            // 
            // clmn_TotalCost
            // 
            this.clmn_TotalCost.HeaderText = "Total Cost";
            this.clmn_TotalCost.Name = "clmn_TotalCost";
            this.clmn_TotalCost.ReadOnly = true;
            this.clmn_TotalCost.Width = 60;
            // 
            // btnClearGV
            // 
            this.btnClearGV.Location = new System.Drawing.Point(478, 448);
            this.btnClearGV.Name = "btnClearGV";
            this.btnClearGV.Size = new System.Drawing.Size(89, 37);
            this.btnClearGV.TabIndex = 11;
            this.btnClearGV.Text = "Clear";
            this.btnClearGV.UseVisualStyleBackColor = true;
            this.btnClearGV.Click += new System.EventHandler(this.btnClearGV_Click);
            // 
            // btnSubmitGV
            // 
            this.btnSubmitGV.Location = new System.Drawing.Point(279, 448);
            this.btnSubmitGV.Name = "btnSubmitGV";
            this.btnSubmitGV.Size = new System.Drawing.Size(98, 37);
            this.btnSubmitGV.TabIndex = 9;
            this.btnSubmitGV.Text = "Confirm";
            this.btnSubmitGV.UseVisualStyleBackColor = true;
            this.btnSubmitGV.Click += new System.EventHandler(this.btnSubmitGV_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(383, 448);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 37);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // aDADataSetBindingSource
            // 
            this.aDADataSetBindingSource.DataSource = this.aDADataSet;
            this.aDADataSetBindingSource.Position = 0;
            // 
            // itemTableAdapter
            // 
            this.itemTableAdapter.ClearBeforeFill = true;
            // 
            // ep_Quantity
            // 
            this.ep_Quantity.BlinkRate = 4;
            this.ep_Quantity.ContainerControl = this;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(adaOrderingSys.Item);
            // 
            // ep_Item
            // 
            this.ep_Item.BlinkRate = 4;
            this.ep_Item.ContainerControl = this;
            // 
            // ep_Customer
            // 
            this.ep_Customer.ContainerControl = this;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Yellow;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(113, 39);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "◀ Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // newOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 536);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlAddOrder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "newOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "newOrder";
            this.Load += new System.EventHandler(this.newOrder_Load);
            this.pnlAddOrder.ResumeLayout(false);
            this.pnlAddOrder.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_SalesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Additionals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Customer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAddOrder;
        private System.Windows.Forms.Button btnClearGV;
        private System.Windows.Forms.Button btnSubmitGV;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox ddl_Customer;
        private ADADataSet aDADataSet;
        private BindingSource customerBindingSource;
        private ADADataSetTableAdapters.customerTableAdapter customerTableAdapter;
        private Label lblItem;
        private ComboBox ddl_Item;
        private BindingSource aDADataSetBindingSource;
        private BindingSource itemBindingSource;
        private GroupBox groupBox1;
        private DataGridView dgv_Order;
        private TextBox txt_Quantity;
        private Label label1;
        private GroupBox groupBox3;
        private ADADataSet1 aDADataSet1;
        private BindingSource itemBindingSource1;
        private ADADataSet1TableAdapters.itemTableAdapter itemTableAdapter;
        private ErrorProvider ep_Quantity;
        private ErrorProvider ep_Item;
        private ErrorProvider ep_Customer;
        private Label lblGrandTotal;
        private TextBox txtGrandTotal;
        private Label lbl_SalesNo;
        private NumericUpDown numeric_SalesNo;
        private Label lbl_Additionals;
        private Label label2;
        private RichTextBox rtxt_Location;
        private GroupBox groupBox4;
        private NumericUpDown numeric_Additionals;
        private DataGridViewTextBoxColumn clmn_ID;
        private DataGridViewTextBoxColumn clmn_ItemName;
        private DataGridViewTextBoxColumn clmn_CustName;
        private DataGridViewTextBoxColumn clmn_Location;
        private DataGridViewTextBoxColumn clmn_SalesNo;
        private DataGridViewTextBoxColumn clmn_Quantity;
        private DataGridViewTextBoxColumn clmn_Additionals;
        private DataGridViewTextBoxColumn clmn_UnitPrice;
        private DataGridViewTextBoxColumn clmn_TotalCost;
        private Button btn_Clear;
        private Button btn_Add;
        private Button btnBack;
    }
}