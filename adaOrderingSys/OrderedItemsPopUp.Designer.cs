namespace adaOrderingSys
{
    partial class OrderedItemsPopUp
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
            this.dgv_ItemsOrdered = new System.Windows.Forms.DataGridView();
            this.clmn_itemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_Additionals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ItemsOrdered)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ItemsOrdered
            // 
            this.dgv_ItemsOrdered.AllowUserToAddRows = false;
            this.dgv_ItemsOrdered.AllowUserToDeleteRows = false;
            this.dgv_ItemsOrdered.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ItemsOrdered.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmn_itemID,
            this.clmn_ItemName,
            this.clmn_Quantity,
            this.clmn_TotalCost,
            this.clmn_Additionals});
            this.dgv_ItemsOrdered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ItemsOrdered.Location = new System.Drawing.Point(0, 0);
            this.dgv_ItemsOrdered.Name = "dgv_ItemsOrdered";
            this.dgv_ItemsOrdered.ReadOnly = true;
            this.dgv_ItemsOrdered.Size = new System.Drawing.Size(543, 333);
            this.dgv_ItemsOrdered.TabIndex = 0;
            // 
            // clmn_itemID
            // 
            this.clmn_itemID.HeaderText = "itemID";
            this.clmn_itemID.Name = "clmn_itemID";
            this.clmn_itemID.ReadOnly = true;
            // 
            // clmn_ItemName
            // 
            this.clmn_ItemName.HeaderText = "Item Name";
            this.clmn_ItemName.Name = "clmn_ItemName";
            this.clmn_ItemName.ReadOnly = true;
            // 
            // clmn_Quantity
            // 
            this.clmn_Quantity.HeaderText = "Quantity";
            this.clmn_Quantity.Name = "clmn_Quantity";
            this.clmn_Quantity.ReadOnly = true;
            // 
            // clmn_TotalCost
            // 
            this.clmn_TotalCost.HeaderText = "Total Cost";
            this.clmn_TotalCost.Name = "clmn_TotalCost";
            this.clmn_TotalCost.ReadOnly = true;
            // 
            // clmn_Additionals
            // 
            this.clmn_Additionals.HeaderText = "Additionals";
            this.clmn_Additionals.Name = "clmn_Additionals";
            this.clmn_Additionals.ReadOnly = true;
            // 
            // OrderedItemsPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 333);
            this.Controls.Add(this.dgv_ItemsOrdered);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderedItemsPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrderedItemsPopUp";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ItemsOrdered)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ItemsOrdered;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_itemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_Additionals;
    }
}