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
            this.lblItem = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.btnClearGV = new System.Windows.Forms.Button();
            this.btnSubmitGV = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aDADataSet = new adaOrderingSys.ADADataSet();
            this.btnBack = new System.Windows.Forms.Button();
            this.customerTableAdapter = new adaOrderingSys.ADADataSetTableAdapters.customerTableAdapter();
            this.pnlAddOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAddOrder
            // 
            this.pnlAddOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlAddOrder.Controls.Add(this.lblItem);
            this.pnlAddOrder.Controls.Add(this.comboBox3);
            this.pnlAddOrder.Controls.Add(this.btnClearGV);
            this.pnlAddOrder.Controls.Add(this.btnSubmitGV);
            this.pnlAddOrder.Controls.Add(this.btnDelete);
            this.pnlAddOrder.Controls.Add(this.btnAddRow);
            this.pnlAddOrder.Controls.Add(this.lblCustomer);
            this.pnlAddOrder.Controls.Add(this.comboBox1);
            this.pnlAddOrder.Location = new System.Drawing.Point(138, 50);
            this.pnlAddOrder.Name = "pnlAddOrder";
            this.pnlAddOrder.Size = new System.Drawing.Size(766, 426);
            this.pnlAddOrder.TabIndex = 4;
            this.pnlAddOrder.Visible = false;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(62, 92);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(45, 24);
            this.lblItem.TabIndex = 10;
            this.lblItem.Text = "Item";
            this.lblItem.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.DisplayMember = "custName";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(159, 92);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(325, 21);
            this.comboBox3.TabIndex = 9;
            this.comboBox3.ValueMember = "custID";
            // 
            // btnClearGV
            // 
            this.btnClearGV.Location = new System.Drawing.Point(506, 351);
            this.btnClearGV.Name = "btnClearGV";
            this.btnClearGV.Size = new System.Drawing.Size(89, 37);
            this.btnClearGV.TabIndex = 8;
            this.btnClearGV.Text = "Clear";
            this.btnClearGV.UseVisualStyleBackColor = true;
            this.btnClearGV.Click += new System.EventHandler(this.btnClearGV_Click);
            // 
            // btnSubmitGV
            // 
            this.btnSubmitGV.Location = new System.Drawing.Point(307, 351);
            this.btnSubmitGV.Name = "btnSubmitGV";
            this.btnSubmitGV.Size = new System.Drawing.Size(98, 37);
            this.btnSubmitGV.TabIndex = 7;
            this.btnSubmitGV.Text = "Submit";
            this.btnSubmitGV.UseVisualStyleBackColor = true;
            this.btnSubmitGV.Click += new System.EventHandler(this.btnSubmitGV_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(411, 351);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 37);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(212, 351);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(92, 37);
            this.btnAddRow.TabIndex = 5;
            this.btnAddRow.Text = "Add";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(62, 37);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(91, 24);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Customer";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.customerBindingSource;
            this.comboBox1.DisplayMember = "custName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(159, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(325, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "custID";
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
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
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
            this.pnlAddOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDADataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAddOrder;
        private System.Windows.Forms.Button btnClearGV;
        private System.Windows.Forms.Button btnSubmitGV;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnBack;
        private ADADataSet aDADataSet;
        private BindingSource customerBindingSource;
        private ADADataSetTableAdapters.customerTableAdapter customerTableAdapter;
        private Label lblItem;
        private ComboBox comboBox3;
    }
}