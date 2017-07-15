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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Order = new System.Windows.Forms.DataGridView();
            this.clmn_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_CustName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Quantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.ddl_Item = new System.Windows.Forms.ComboBox();
            this.btnClearGV = new System.Windows.Forms.Button();
            this.btnSubmitGV = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.ddl_Customer = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aDADataSet = new adaOrderingSys.ADADataSet();
            this.customerTableAdapter = new adaOrderingSys.ADADataSetTableAdapters.customerTableAdapter();
            this.aDADataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlAddOrder.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAddOrder
            // 
            this.pnlAddOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlAddOrder.Controls.Add(this.groupBox3);
            this.pnlAddOrder.Controls.Add(this.groupBox2);
            this.pnlAddOrder.Controls.Add(this.groupBox1);
            this.pnlAddOrder.Controls.Add(this.btnClearGV);
            this.pnlAddOrder.Controls.Add(this.btnSubmitGV);
            this.pnlAddOrder.Controls.Add(this.btnDelete);
            this.pnlAddOrder.Location = new System.Drawing.Point(138, 50);
            this.pnlAddOrder.Name = "pnlAddOrder";
            this.pnlAddOrder.Size = new System.Drawing.Size(766, 426);
            this.pnlAddOrder.TabIndex = 4;
            this.pnlAddOrder.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Clear);
            this.groupBox2.Controls.Add(this.btn_Add);
            this.groupBox2.Location = new System.Drawing.Point(502, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 139);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(22, 54);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 30);
            this.btn_Clear.TabIndex = 17;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(22, 19);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 29);
            this.btn_Add.TabIndex = 16;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Order);
            this.groupBox1.Location = new System.Drawing.Point(76, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 193);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dgv_Order
            // 
            this.dgv_Order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmn_ID,
            this.clmn_ItemName,
            this.clmn_CustName,
            this.clmn_UnitPrice,
            this.clmn_TotalCost});
            this.dgv_Order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Order.Location = new System.Drawing.Point(3, 16);
            this.dgv_Order.Name = "dgv_Order";
            this.dgv_Order.Size = new System.Drawing.Size(548, 174);
            this.dgv_Order.TabIndex = 0;
            // 
            // clmn_ID
            // 
            this.clmn_ID.HeaderText = "ID";
            this.clmn_ID.Name = "clmn_ID";
            this.clmn_ID.ReadOnly = true;
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
            // 
            // clmn_UnitPrice
            // 
            this.clmn_UnitPrice.HeaderText = "Unit Price";
            this.clmn_UnitPrice.Name = "clmn_UnitPrice";
            this.clmn_UnitPrice.ReadOnly = true;
            // 
            // clmn_TotalCost
            // 
            this.clmn_TotalCost.HeaderText = "Total Cost";
            this.clmn_TotalCost.Name = "clmn_TotalCost";
            this.clmn_TotalCost.ReadOnly = true;
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Location = new System.Drawing.Point(103, 112);
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.Size = new System.Drawing.Size(68, 20);
            this.txt_Quantity.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Quantity";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(6, 69);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(45, 24);
            this.lblItem.TabIndex = 10;
            this.lblItem.Text = "Item";
            // 
            // ddl_Item
            // 
            this.ddl_Item.FormattingEnabled = true;
            this.ddl_Item.Location = new System.Drawing.Point(103, 69);
            this.ddl_Item.Name = "ddl_Item";
            this.ddl_Item.Size = new System.Drawing.Size(212, 21);
            this.ddl_Item.TabIndex = 9;
            // 
            // btnClearGV
            // 
            this.btnClearGV.Location = new System.Drawing.Point(421, 372);
            this.btnClearGV.Name = "btnClearGV";
            this.btnClearGV.Size = new System.Drawing.Size(89, 37);
            this.btnClearGV.TabIndex = 8;
            this.btnClearGV.Text = "Clear";
            this.btnClearGV.UseVisualStyleBackColor = true;
            this.btnClearGV.Click += new System.EventHandler(this.btnClearGV_Click);
            // 
            // btnSubmitGV
            // 
            this.btnSubmitGV.Location = new System.Drawing.Point(222, 372);
            this.btnSubmitGV.Name = "btnSubmitGV";
            this.btnSubmitGV.Size = new System.Drawing.Size(98, 37);
            this.btnSubmitGV.TabIndex = 7;
            this.btnSubmitGV.Text = "Confirm";
            this.btnSubmitGV.UseVisualStyleBackColor = true;
            this.btnSubmitGV.Click += new System.EventHandler(this.btnSubmitGV_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(326, 372);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 37);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(6, 29);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(91, 24);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Customer";
            // 
            // ddl_Customer
            // 
            this.ddl_Customer.DataSource = this.customerBindingSource;
            this.ddl_Customer.DisplayMember = "custName";
            this.ddl_Customer.FormattingEnabled = true;
            this.ddl_Customer.Location = new System.Drawing.Point(103, 34);
            this.ddl_Customer.Name = "ddl_Customer";
            this.ddl_Customer.Size = new System.Drawing.Size(212, 21);
            this.ddl_Customer.TabIndex = 0;
            this.ddl_Customer.ValueMember = "custID";
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
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // aDADataSetBindingSource
            // 
            this.aDADataSetBindingSource.DataSource = this.aDADataSet;
            this.aDADataSetBindingSource.Position = 0;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(adaOrderingSys.item);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCustomer);
            this.groupBox3.Controls.Add(this.ddl_Customer);
            this.groupBox3.Controls.Add(this.txt_Quantity);
            this.groupBox3.Controls.Add(this.lblItem);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.ddl_Item);
            this.groupBox3.Location = new System.Drawing.Point(118, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 139);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // newOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 488);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlAddOrder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "newOrder";
            this.Text = "newOrder";
            this.Load += new System.EventHandler(this.newOrder_Load);
            this.pnlAddOrder.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private GroupBox groupBox2;
        private Button btn_Clear;
        private Button btn_Add;
        private DataGridViewTextBoxColumn clmn_ID;
        private DataGridViewTextBoxColumn clmn_ItemName;
        private DataGridViewTextBoxColumn clmn_CustName;
        private DataGridViewTextBoxColumn clmn_UnitPrice;
        private DataGridViewTextBoxColumn clmn_TotalCost;
        private GroupBox groupBox3;
        private Button btnBack;
    }
}