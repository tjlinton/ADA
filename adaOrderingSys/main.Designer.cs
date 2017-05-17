namespace adaOrderingSys
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aDADataSet = new adaOrderingSys.ADADataSet();
            this.customerTableAdapter = new adaOrderingSys.ADADataSetTableAdapters.customerTableAdapter();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.btnViewInventory = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.pnlAddCustomer = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlCustInfo = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmitCust = new System.Windows.Forms.Button();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.txtTelephoneNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBusinessName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProviderBusninessName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderTelephone = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlAddCustomer.SuspendLayout();
            this.pnlCustInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBusninessName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTelephone)).BeginInit();
            this.SuspendLayout();
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
            // btnNewOrder
            // 
            this.btnNewOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNewOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewOrder.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNewOrder.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnNewOrder.FlatAppearance.BorderSize = 10;
            this.btnNewOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnNewOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewOrder.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnNewOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNewOrder.Location = new System.Drawing.Point(172, 83);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(212, 72);
            this.btnNewOrder.TabIndex = 4;
            this.btnNewOrder.Text = "New order";
            this.btnNewOrder.UseVisualStyleBackColor = false;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnNewProduct);
            this.pnlMain.Controls.Add(this.btnViewInventory);
            this.pnlMain.Controls.Add(this.btnAddCustomer);
            this.pnlMain.Controls.Add(this.btnNewOrder);
            this.pnlMain.Location = new System.Drawing.Point(97, 50);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(928, 345);
            this.pnlMain.TabIndex = 7;
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNewProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewProduct.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNewProduct.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnNewProduct.FlatAppearance.BorderSize = 10;
            this.btnNewProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnNewProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnNewProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewProduct.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnNewProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNewProduct.Location = new System.Drawing.Point(527, 214);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(212, 72);
            this.btnNewProduct.TabIndex = 9;
            this.btnNewProduct.Text = "New Product";
            this.btnNewProduct.UseVisualStyleBackColor = false;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // btnViewInventory
            // 
            this.btnViewInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnViewInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewInventory.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnViewInventory.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnViewInventory.FlatAppearance.BorderSize = 10;
            this.btnViewInventory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnViewInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnViewInventory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewInventory.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnViewInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnViewInventory.Location = new System.Drawing.Point(172, 214);
            this.btnViewInventory.Name = "btnViewInventory";
            this.btnViewInventory.Size = new System.Drawing.Size(212, 72);
            this.btnViewInventory.TabIndex = 8;
            this.btnViewInventory.Text = "View Inventory";
            this.btnViewInventory.UseVisualStyleBackColor = false;
            this.btnViewInventory.Click += new System.EventHandler(this.btnViewInventory_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddCustomer.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnAddCustomer.FlatAppearance.BorderSize = 10;
            this.btnAddCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnAddCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddCustomer.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnAddCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAddCustomer.Location = new System.Drawing.Point(527, 83);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(212, 72);
            this.btnAddCustomer.TabIndex = 7;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // pnlAddCustomer
            // 
            this.pnlAddCustomer.Controls.Add(this.btnBack);
            this.pnlAddCustomer.Controls.Add(this.pnlCustInfo);
            this.pnlAddCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddCustomer.Location = new System.Drawing.Point(0, 0);
            this.pnlAddCustomer.Name = "pnlAddCustomer";
            this.pnlAddCustomer.Size = new System.Drawing.Size(1102, 446);
            this.pnlAddCustomer.TabIndex = 10;
            this.pnlAddCustomer.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Yellow;
            this.btnBack.Location = new System.Drawing.Point(12, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(113, 39);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "◀ Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlCustInfo
            // 
            this.pnlCustInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCustInfo.Controls.Add(this.btnClear);
            this.pnlCustInfo.Controls.Add(this.btnSubmitCust);
            this.pnlCustInfo.Controls.Add(this.txtContactPerson);
            this.pnlCustInfo.Controls.Add(this.label2);
            this.pnlCustInfo.Controls.Add(this.txtAddress);
            this.pnlCustInfo.Controls.Add(this.txtTelephoneNo);
            this.pnlCustInfo.Controls.Add(this.label9);
            this.pnlCustInfo.Controls.Add(this.label8);
            this.pnlCustInfo.Controls.Add(this.txtBusinessName);
            this.pnlCustInfo.Controls.Add(this.label1);
            this.pnlCustInfo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCustInfo.Location = new System.Drawing.Point(278, 39);
            this.pnlCustInfo.Name = "pnlCustInfo";
            this.pnlCustInfo.Size = new System.Drawing.Size(558, 395);
            this.pnlCustInfo.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClear.CausesValidation = false;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.ForeColor = System.Drawing.Color.Gold;
            this.btnClear.Location = new System.Drawing.Point(261, 323);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(101, 45);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmitCust
            // 
            this.btnSubmitCust.BackColor = System.Drawing.Color.Green;
            this.btnSubmitCust.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitCust.ForeColor = System.Drawing.Color.Gold;
            this.btnSubmitCust.Location = new System.Drawing.Point(125, 323);
            this.btnSubmitCust.Name = "btnSubmitCust";
            this.btnSubmitCust.Size = new System.Drawing.Size(101, 45);
            this.btnSubmitCust.TabIndex = 22;
            this.btnSubmitCust.Text = "Submit";
            this.btnSubmitCust.UseVisualStyleBackColor = false;
            this.btnSubmitCust.Click += new System.EventHandler(this.btnSubmitCust_Click);
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(223, 209);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtContactPerson.Size = new System.Drawing.Size(216, 30);
            this.txtContactPerson.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "Contact Person";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(223, 94);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(290, 96);
            this.txtAddress.TabIndex = 18;
            this.txtAddress.Text = "";
            // 
            // txtTelephoneNo
            // 
            this.txtTelephoneNo.Location = new System.Drawing.Point(223, 53);
            this.txtTelephoneNo.Name = "txtTelephoneNo";
            this.txtTelephoneNo.Size = new System.Drawing.Size(216, 30);
            this.txtTelephoneNo.TabIndex = 17;
            this.txtTelephoneNo.TextChanged += new System.EventHandler(this.txtTelephoneNo_TextChanged);
            this.txtTelephoneNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelephoneNo_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "Telephone No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Address";
            // 
            // txtBusinessName
            // 
            this.txtBusinessName.Location = new System.Drawing.Point(223, 14);
            this.txtBusinessName.Name = "txtBusinessName";
            this.txtBusinessName.Size = new System.Drawing.Size(216, 30);
            this.txtBusinessName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Business Name";
            // 
            // errorProviderBusninessName
            // 
            this.errorProviderBusninessName.ContainerControl = this;
            // 
            // errorProviderTelephone
            // 
            this.errorProviderTelephone.BlinkRate = 1;
            this.errorProviderTelephone.ContainerControl = this;
            this.errorProviderTelephone.RightToLeftChanged += new System.EventHandler(this.txtTelephoneNo_TextChanged);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1102, 446);
            this.Controls.Add(this.pnlAddCustomer);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "- Inventory Management";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlAddCustomer.ResumeLayout(false);
            this.pnlCustInfo.ResumeLayout(false);
            this.pnlCustInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBusninessName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTelephone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADADataSet aDADataSet;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private ADADataSetTableAdapters.customerTableAdapter customerTableAdapter;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.Button btnViewInventory;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Panel pnlAddCustomer;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlCustInfo;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.TextBox txtTelephoneNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBusinessName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmitCust;
        private System.Windows.Forms.ErrorProvider errorProviderBusninessName;
        private System.Windows.Forms.ErrorProvider errorProviderTelephone;

    }
}