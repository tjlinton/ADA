namespace adaOrderingSys
{
    partial class AddNewItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewItem));
            this.ddlItemName = new System.Windows.Forms.ComboBox();
            this.num_Quantity = new System.Windows.Forms.NumericUpDown();
            this.num_SalesNo = new System.Windows.Forms.NumericUpDown();
            this.num_Additionals = new System.Windows.Forms.NumericUpDown();
            this.lbl_Item = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.lbl_SalesNo = new System.Windows.Forms.Label();
            this.lbl_Additionals = new System.Windows.Forms.Label();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbl_UnitPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_SalesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Additionals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlItemName
            // 
            this.ddlItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlItemName.FormattingEnabled = true;
            this.ddlItemName.Location = new System.Drawing.Point(100, 17);
            this.ddlItemName.Name = "ddlItemName";
            this.ddlItemName.Size = new System.Drawing.Size(158, 21);
            this.ddlItemName.TabIndex = 0;
            this.ddlItemName.SelectedIndexChanged += new System.EventHandler(this.ddlItemName_SelectedIndexChanged);
            // 
            // num_Quantity
            // 
            this.num_Quantity.Enabled = false;
            this.num_Quantity.Location = new System.Drawing.Point(100, 53);
            this.num_Quantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_Quantity.Name = "num_Quantity";
            this.num_Quantity.Size = new System.Drawing.Size(52, 20);
            this.num_Quantity.TabIndex = 1;
            this.num_Quantity.ValueChanged += new System.EventHandler(this.num_Quantity_ValueChanged);
            // 
            // num_SalesNo
            // 
            this.num_SalesNo.Enabled = false;
            this.num_SalesNo.Location = new System.Drawing.Point(100, 136);
            this.num_SalesNo.Name = "num_SalesNo";
            this.num_SalesNo.Size = new System.Drawing.Size(52, 20);
            this.num_SalesNo.TabIndex = 2;
            // 
            // num_Additionals
            // 
            this.num_Additionals.Enabled = false;
            this.num_Additionals.Location = new System.Drawing.Point(100, 93);
            this.num_Additionals.Name = "num_Additionals";
            this.num_Additionals.Size = new System.Drawing.Size(52, 20);
            this.num_Additionals.TabIndex = 3;
            this.num_Additionals.ValueChanged += new System.EventHandler(this.num_Additionals_ValueChanged);
            // 
            // lbl_Item
            // 
            this.lbl_Item.AutoSize = true;
            this.lbl_Item.Location = new System.Drawing.Point(17, 20);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(58, 13);
            this.lbl_Item.TabIndex = 4;
            this.lbl_Item.Text = "Item Name";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(88, 203);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 33);
            this.btn_Submit.TabIndex = 5;
            this.btn_Submit.Text = "Done";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // lbl_SalesNo
            // 
            this.lbl_SalesNo.AutoSize = true;
            this.lbl_SalesNo.Location = new System.Drawing.Point(17, 138);
            this.lbl_SalesNo.Name = "lbl_SalesNo";
            this.lbl_SalesNo.Size = new System.Drawing.Size(50, 13);
            this.lbl_SalesNo.TabIndex = 6;
            this.lbl_SalesNo.Text = "Sales No";
            // 
            // lbl_Additionals
            // 
            this.lbl_Additionals.AutoSize = true;
            this.lbl_Additionals.Location = new System.Drawing.Point(17, 93);
            this.lbl_Additionals.Name = "lbl_Additionals";
            this.lbl_Additionals.Size = new System.Drawing.Size(58, 13);
            this.lbl_Additionals.TabIndex = 7;
            this.lbl_Additionals.Text = "Additionals";
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.AutoSize = true;
            this.lbl_Quantity.Location = new System.Drawing.Point(17, 60);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(46, 13);
            this.lbl_Quantity.TabIndex = 8;
            this.lbl_Quantity.Text = "Quantity";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbl_UnitPrice
            // 
            this.lbl_UnitPrice.AutoSize = true;
            this.lbl_UnitPrice.Location = new System.Drawing.Point(211, 213);
            this.lbl_UnitPrice.Name = "lbl_UnitPrice";
            this.lbl_UnitPrice.Size = new System.Drawing.Size(0, 13);
            this.lbl_UnitPrice.TabIndex = 9;
            this.lbl_UnitPrice.Visible = false;
            // 
            // AddNewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(278, 248);
            this.Controls.Add(this.lbl_UnitPrice);
            this.Controls.Add(this.lbl_Quantity);
            this.Controls.Add(this.lbl_Additionals);
            this.Controls.Add(this.lbl_SalesNo);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lbl_Item);
            this.Controls.Add(this.num_Additionals);
            this.Controls.Add(this.num_SalesNo);
            this.Controls.Add(this.num_Quantity);
            this.Controls.Add(this.ddlItemName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNewItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewItem";
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_SalesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Additionals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlItemName;
        private System.Windows.Forms.NumericUpDown num_Quantity;
        private System.Windows.Forms.NumericUpDown num_SalesNo;
        private System.Windows.Forms.NumericUpDown num_Additionals;
        private System.Windows.Forms.Label lbl_Item;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Label lbl_SalesNo;
        private System.Windows.Forms.Label lbl_Additionals;
        private System.Windows.Forms.Label lbl_Quantity;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbl_UnitPrice;
    }
}