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
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnViewCustomers = new System.Windows.Forms.Button();
            this.btn_ViewOrders = new System.Windows.Forms.Button();
            this.btnCreateSummary = new System.Windows.Forms.Button();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.btnViewInventory = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.pnlMainII = new System.Windows.Forms.Panel();
            this.pnlCustInfo = new System.Windows.Forms.Panel();
            this.btnClearCustomer = new System.Windows.Forms.Button();
            this.btnSubmitCust = new System.Windows.Forms.Button();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.txtTelephoneNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBusinessName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlProductInfo = new System.Windows.Forms.Panel();
            this.lblDollar = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.btnClearProduct = new System.Windows.Forms.Button();
            this.btnSubmitProduct = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtProductDescription = new System.Windows.Forms.RichTextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.pnl_ViewInventory = new System.Windows.Forms.Panel();
            this.btn_SubmitItemChanges = new System.Windows.Forms.Button();
            this.dgv_Items = new System.Windows.Forms.DataGridView();
            this.clmn_ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aDAItemDataSet = new adaOrderingSys.ADAItemDataSet();
            this.btnBack = new System.Windows.Forms.Button();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aDADataSet = new adaOrderingSys.ADADataSet();
            this.errorProviderBusninessName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderTelephone = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderTxtProductID = new System.Windows.Forms.ErrorProvider(this.components);
            this.customerTableAdapter = new adaOrderingSys.ADADataSetTableAdapters.customerTableAdapter();
            this.errorProviderUnitPrice = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderProductName = new System.Windows.Forms.ErrorProvider(this.components);
            this.itemTableAdapter = new adaOrderingSys.ADAItemDataSetTableAdapters.itemTableAdapter();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlMainII.SuspendLayout();
            this.pnlCustInfo.SuspendLayout();
            this.pnlProductInfo.SuspendLayout();
            this.pnl_ViewInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDAItemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBusninessName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTxtProductID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProductName)).BeginInit();
            this.SuspendLayout();
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
            this.btnNewOrder.Location = new System.Drawing.Point(446, 224);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(212, 72);
            this.btnNewOrder.TabIndex = 4;
            this.btnNewOrder.Text = "New order";
            this.btnNewOrder.UseVisualStyleBackColor = false;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnViewCustomers);
            this.pnlMain.Controls.Add(this.btn_ViewOrders);
            this.pnlMain.Controls.Add(this.btnCreateSummary);
            this.pnlMain.Controls.Add(this.btnNewProduct);
            this.pnlMain.Controls.Add(this.btnViewInventory);
            this.pnlMain.Controls.Add(this.btnAddCustomer);
            this.pnlMain.Controls.Add(this.btnNewOrder);
            this.pnlMain.Location = new System.Drawing.Point(97, 50);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(928, 416);
            this.pnlMain.TabIndex = 7;
            // 
            // btnViewCustomers
            // 
            this.btnViewCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnViewCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewCustomers.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnViewCustomers.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnViewCustomers.FlatAppearance.BorderSize = 10;
            this.btnViewCustomers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnViewCustomers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnViewCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewCustomers.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnViewCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnViewCustomers.Location = new System.Drawing.Point(172, 315);
            this.btnViewCustomers.Name = "btnViewCustomers";
            this.btnViewCustomers.Size = new System.Drawing.Size(212, 72);
            this.btnViewCustomers.TabIndex = 12;
            this.btnViewCustomers.Text = "View Customers";
            this.btnViewCustomers.UseVisualStyleBackColor = false;
            this.btnViewCustomers.Click += new System.EventHandler(this.btnViewCustomers_Click);
            // 
            // btn_ViewOrders
            // 
            this.btn_ViewOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_ViewOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ViewOrders.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ViewOrders.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btn_ViewOrders.FlatAppearance.BorderSize = 10;
            this.btn_ViewOrders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btn_ViewOrders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btn_ViewOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ViewOrders.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btn_ViewOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_ViewOrders.Location = new System.Drawing.Point(172, 29);
            this.btn_ViewOrders.Name = "btn_ViewOrders";
            this.btn_ViewOrders.Size = new System.Drawing.Size(212, 72);
            this.btn_ViewOrders.TabIndex = 11;
            this.btn_ViewOrders.Text = "View Orders";
            this.btn_ViewOrders.UseVisualStyleBackColor = false;
            this.btn_ViewOrders.Click += new System.EventHandler(this.btn_ViewOrders_Click);
            // 
            // btnCreateSummary
            // 
            this.btnCreateSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCreateSummary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateSummary.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCreateSummary.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnCreateSummary.FlatAppearance.BorderSize = 10;
            this.btnCreateSummary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnCreateSummary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnCreateSummary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateSummary.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnCreateSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCreateSummary.Location = new System.Drawing.Point(172, 224);
            this.btnCreateSummary.Name = "btnCreateSummary";
            this.btnCreateSummary.Size = new System.Drawing.Size(212, 72);
            this.btnCreateSummary.TabIndex = 10;
            this.btnCreateSummary.Text = "Create Loading Sheet";
            this.btnCreateSummary.UseVisualStyleBackColor = false;
            this.btnCreateSummary.Click += new System.EventHandler(this.btnCreateSummary_Click);
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
            this.btnNewProduct.Location = new System.Drawing.Point(446, 130);
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
            this.btnViewInventory.Location = new System.Drawing.Point(172, 124);
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
            this.btnAddCustomer.Location = new System.Drawing.Point(446, 29);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(212, 72);
            this.btnAddCustomer.TabIndex = 7;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // pnlMainII
            // 
            this.pnlMainII.Controls.Add(this.pnlCustInfo);
            this.pnlMainII.Controls.Add(this.pnlProductInfo);
            this.pnlMainII.Controls.Add(this.pnl_ViewInventory);
            this.pnlMainII.Controls.Add(this.btnBack);
            this.pnlMainII.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainII.Location = new System.Drawing.Point(0, 0);
            this.pnlMainII.Name = "pnlMainII";
            this.pnlMainII.Size = new System.Drawing.Size(1074, 493);
            this.pnlMainII.TabIndex = 10;
            this.pnlMainII.Visible = false;
            // 
            // pnlCustInfo
            // 
            this.pnlCustInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCustInfo.Controls.Add(this.btnClearCustomer);
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
            this.pnlCustInfo.Location = new System.Drawing.Point(204, 69);
            this.pnlCustInfo.Name = "pnlCustInfo";
            this.pnlCustInfo.Size = new System.Drawing.Size(727, 384);
            this.pnlCustInfo.TabIndex = 1;
            // 
            // btnClearCustomer
            // 
            this.btnClearCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClearCustomer.CausesValidation = false;
            this.btnClearCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCustomer.ForeColor = System.Drawing.Color.Gold;
            this.btnClearCustomer.Location = new System.Drawing.Point(261, 323);
            this.btnClearCustomer.Name = "btnClearCustomer";
            this.btnClearCustomer.Size = new System.Drawing.Size(101, 45);
            this.btnClearCustomer.TabIndex = 24;
            this.btnClearCustomer.Text = "Clear";
            this.btnClearCustomer.UseVisualStyleBackColor = false;
            this.btnClearCustomer.Click += new System.EventHandler(this.btnClearCustomer_Click);
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
            this.label2.Location = new System.Drawing.Point(30, 207);
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
            this.label1.Location = new System.Drawing.Point(30, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Business Name";
            // 
            // pnlProductInfo
            // 
            this.pnlProductInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlProductInfo.Controls.Add(this.lblDollar);
            this.pnlProductInfo.Controls.Add(this.txtUnitPrice);
            this.pnlProductInfo.Controls.Add(this.lblUnitPrice);
            this.pnlProductInfo.Controls.Add(this.btnClearProduct);
            this.pnlProductInfo.Controls.Add(this.btnSubmitProduct);
            this.pnlProductInfo.Controls.Add(this.txtQuantity);
            this.pnlProductInfo.Controls.Add(this.lblQuantity);
            this.pnlProductInfo.Controls.Add(this.txtProductDescription);
            this.pnlProductInfo.Controls.Add(this.txtProductName);
            this.pnlProductInfo.Controls.Add(this.lblProductName);
            this.pnlProductInfo.Controls.Add(this.lblDescription);
            this.pnlProductInfo.Controls.Add(this.txtProductID);
            this.pnlProductInfo.Controls.Add(this.lblProductID);
            this.pnlProductInfo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlProductInfo.Location = new System.Drawing.Point(201, 75);
            this.pnlProductInfo.Name = "pnlProductInfo";
            this.pnlProductInfo.Size = new System.Drawing.Size(730, 381);
            this.pnlProductInfo.TabIndex = 2;
            // 
            // lblDollar
            // 
            this.lblDollar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDollar.AutoSize = true;
            this.lblDollar.Location = new System.Drawing.Point(221, 267);
            this.lblDollar.Name = "lblDollar";
            this.lblDollar.Size = new System.Drawing.Size(22, 23);
            this.lblDollar.TabIndex = 26;
            this.lblDollar.Text = "$";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(223, 260);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUnitPrice.Size = new System.Drawing.Size(75, 30);
            this.txtUnitPrice.TabIndex = 21;
            this.txtUnitPrice.Text = "0.00";
            this.txtUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitPrice_KeyPress);
            this.txtUnitPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnitPrice_Validating);
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(104, 267);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(102, 23);
            this.lblUnitPrice.TabIndex = 24;
            this.lblUnitPrice.Text = "Unit Price";
            // 
            // btnClearProduct
            // 
            this.btnClearProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClearProduct.CausesValidation = false;
            this.btnClearProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearProduct.ForeColor = System.Drawing.Color.Gold;
            this.btnClearProduct.Location = new System.Drawing.Point(261, 323);
            this.btnClearProduct.Name = "btnClearProduct";
            this.btnClearProduct.Size = new System.Drawing.Size(101, 45);
            this.btnClearProduct.TabIndex = 23;
            this.btnClearProduct.Text = "Clear";
            this.btnClearProduct.UseVisualStyleBackColor = false;
            this.btnClearProduct.Click += new System.EventHandler(this.btnClearProduct_Click);
            // 
            // btnSubmitProduct
            // 
            this.btnSubmitProduct.BackColor = System.Drawing.Color.Green;
            this.btnSubmitProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitProduct.ForeColor = System.Drawing.Color.Gold;
            this.btnSubmitProduct.Location = new System.Drawing.Point(125, 323);
            this.btnSubmitProduct.Name = "btnSubmitProduct";
            this.btnSubmitProduct.Size = new System.Drawing.Size(101, 45);
            this.btnSubmitProduct.TabIndex = 22;
            this.btnSubmitProduct.Text = "Submit";
            this.btnSubmitProduct.UseVisualStyleBackColor = false;
            this.btnSubmitProduct.Click += new System.EventHandler(this.btnSubmitProduct_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(223, 209);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtQuantity.Size = new System.Drawing.Size(75, 30);
            this.txtQuantity.TabIndex = 20;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(104, 216);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(91, 23);
            this.lblQuantity.TabIndex = 19;
            this.lblQuantity.Text = "Quantity";
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.Location = new System.Drawing.Point(223, 94);
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtProductDescription.Size = new System.Drawing.Size(290, 96);
            this.txtProductDescription.TabIndex = 18;
            this.txtProductDescription.Text = "";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(223, 53);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(216, 30);
            this.txtProductName.TabIndex = 17;
            this.txtProductName.Validating += new System.ComponentModel.CancelEventHandler(this.txtProductName_Validating);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(74, 57);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(143, 23);
            this.lblProductName.TabIndex = 16;
            this.lblProductName.Text = "Product Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(78, 146);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(119, 23);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Description";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(223, 14);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(216, 30);
            this.txtProductID.TabIndex = 1;
            this.txtProductID.Validating += new System.ComponentModel.CancelEventHandler(this.txtProductID_Validating);
            // 
            // lblProductID
            // 
            this.lblProductID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(104, 8);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(112, 23);
            this.lblProductID.TabIndex = 0;
            this.lblProductID.Text = "Product ID";
            // 
            // pnl_ViewInventory
            // 
            this.pnl_ViewInventory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnl_ViewInventory.Controls.Add(this.btn_SubmitItemChanges);
            this.pnl_ViewInventory.Controls.Add(this.dgv_Items);
            this.pnl_ViewInventory.Location = new System.Drawing.Point(211, 72);
            this.pnl_ViewInventory.Name = "pnl_ViewInventory";
            this.pnl_ViewInventory.Size = new System.Drawing.Size(720, 394);
            this.pnl_ViewInventory.TabIndex = 27;
            // 
            // btn_SubmitItemChanges
            // 
            this.btn_SubmitItemChanges.BackColor = System.Drawing.Color.Green;
            this.btn_SubmitItemChanges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SubmitItemChanges.ForeColor = System.Drawing.Color.Gold;
            this.btn_SubmitItemChanges.Location = new System.Drawing.Point(281, 339);
            this.btn_SubmitItemChanges.Name = "btn_SubmitItemChanges";
            this.btn_SubmitItemChanges.Size = new System.Drawing.Size(101, 45);
            this.btn_SubmitItemChanges.TabIndex = 23;
            this.btn_SubmitItemChanges.Text = "Submit";
            this.btn_SubmitItemChanges.UseVisualStyleBackColor = false;
            this.btn_SubmitItemChanges.Click += new System.EventHandler(this.btn_SubmitItemChanges_Click);
            // 
            // dgv_Items
            // 
            this.dgv_Items.AutoGenerateColumns = false;
            this.dgv_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmn_ItemID,
            this.clmn_ItemName,
            this.clmn_Quantity,
            this.clmn_Price,
            this.clmn_Description});
            this.dgv_Items.DataSource = this.itemBindingSource;
            this.dgv_Items.Location = new System.Drawing.Point(0, 0);
            this.dgv_Items.Name = "dgv_Items";
            this.dgv_Items.Size = new System.Drawing.Size(720, 332);
            this.dgv_Items.TabIndex = 0;
            // 
            // clmn_ItemID
            // 
            this.clmn_ItemID.DataPropertyName = "itemID";
            this.clmn_ItemID.HeaderText = "itemID";
            this.clmn_ItemID.Name = "clmn_ItemID";
            // 
            // clmn_ItemName
            // 
            this.clmn_ItemName.DataPropertyName = "itemName";
            this.clmn_ItemName.HeaderText = "itemName";
            this.clmn_ItemName.Name = "clmn_ItemName";
            // 
            // clmn_Quantity
            // 
            this.clmn_Quantity.DataPropertyName = "quantity";
            this.clmn_Quantity.HeaderText = "quantity";
            this.clmn_Quantity.Name = "clmn_Quantity";
            this.clmn_Quantity.Width = 75;
            // 
            // clmn_Price
            // 
            this.clmn_Price.DataPropertyName = "price";
            this.clmn_Price.HeaderText = "price";
            this.clmn_Price.Name = "clmn_Price";
            // 
            // clmn_Description
            // 
            this.clmn_Description.DataPropertyName = "description";
            this.clmn_Description.HeaderText = "description";
            this.clmn_Description.Name = "clmn_Description";
            this.clmn_Description.Width = 300;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataMember = "item";
            this.itemBindingSource.DataSource = this.aDAItemDataSet;
            // 
            // aDAItemDataSet
            // 
            this.aDAItemDataSet.DataSetName = "ADAItemDataSet";
            this.aDAItemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // errorProviderBusninessName
            // 
            this.errorProviderBusninessName.ContainerControl = this;
            // 
            // errorProviderTelephone
            // 
            this.errorProviderTelephone.BlinkRate = 1;
            this.errorProviderTelephone.ContainerControl = this;
            // 
            // errorProviderTxtProductID
            // 
            this.errorProviderTxtProductID.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderTxtProductID.ContainerControl = this;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // errorProviderUnitPrice
            // 
            this.errorProviderUnitPrice.ContainerControl = this;
            // 
            // errorProviderProductName
            // 
            this.errorProviderProductName.BlinkRate = 4;
            this.errorProviderProductName.ContainerControl = this;
            // 
            // itemTableAdapter
            // 
            this.itemTableAdapter.ClearBeforeFill = true;
            // 
            // btn_Logout
            // 
            this.btn_Logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Logout.ForeColor = System.Drawing.Color.Gold;
            this.btn_Logout.Location = new System.Drawing.Point(16, 12);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(74, 32);
            this.btn_Logout.TabIndex = 11;
            this.btn_Logout.Text = "Logout";
            this.btn_Logout.UseVisualStyleBackColor = false;
            this.btn_Logout.Click += new System.EventHandler(this.button1_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1074, 493);
            this.Controls.Add(this.btn_Logout);
            this.Controls.Add(this.pnlMainII);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "- Inventory Management";
            this.Load += new System.EventHandler(this.main_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMainII.ResumeLayout(false);
            this.pnlCustInfo.ResumeLayout(false);
            this.pnlCustInfo.PerformLayout();
            this.pnlProductInfo.ResumeLayout(false);
            this.pnlProductInfo.PerformLayout();
            this.pnl_ViewInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDAItemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBusninessName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTxtProductID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProductName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.Button btnViewInventory;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Panel pnlMainII;
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
        private System.Windows.Forms.Button btnSubmitCust;
        private System.Windows.Forms.ErrorProvider errorProviderBusninessName;
        private System.Windows.Forms.ErrorProvider errorProviderTelephone;
        private System.Windows.Forms.Panel pnlProductInfo;
        private System.Windows.Forms.Button btnClearProduct;
        private System.Windows.Forms.Button btnSubmitProduct;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.RichTextBox txtProductDescription;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblDollar;
        private System.Windows.Forms.ErrorProvider errorProviderTxtProductID;
        private System.Windows.Forms.Button btnClearCustomer;
        private ADADataSet aDADataSet;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private ADADataSetTableAdapters.customerTableAdapter customerTableAdapter;
        private System.Windows.Forms.ErrorProvider errorProviderUnitPrice;
        private System.Windows.Forms.ErrorProvider errorProviderProductName;
        private System.Windows.Forms.Panel pnl_ViewInventory;
        private System.Windows.Forms.DataGridView dgv_Items;
        private ADAItemDataSet aDAItemDataSet;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private ADAItemDataSetTableAdapters.itemTableAdapter itemTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_Description;
        private System.Windows.Forms.Button btnCreateSummary;
        private System.Windows.Forms.Button btn_ViewOrders;
        private System.Windows.Forms.Button btn_SubmitItemChanges;
        private System.Windows.Forms.Button btn_Logout;
        private System.Windows.Forms.Button btnViewCustomers;
    }
}