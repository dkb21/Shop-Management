namespace ShopManagement
{
    partial class Form4
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labAmount = new System.Windows.Forms.Label();
            this.labDate = new System.Windows.Forms.Label();
            this.labID = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.labAddress = new System.Windows.Forms.Label();
            this.labPhone = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labAmount);
            this.groupBox3.Controls.Add(this.labDate);
            this.groupBox3.Controls.Add(this.labID);
            this.groupBox3.Controls.Add(this.dgvDetail);
            this.groupBox3.Controls.Add(this.labAddress);
            this.groupBox3.Controls.Add(this.labPhone);
            this.groupBox3.Controls.Add(this.labName);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 349);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order information";
            // 
            // labAmount
            // 
            this.labAmount.AutoSize = true;
            this.labAmount.Location = new System.Drawing.Point(435, 327);
            this.labAmount.Name = "labAmount";
            this.labAmount.Size = new System.Drawing.Size(99, 13);
            this.labAmount.TabIndex = 6;
            this.labAmount.Text = "Total: 500000 VND";
            // 
            // labDate
            // 
            this.labDate.AutoSize = true;
            this.labDate.Location = new System.Drawing.Point(10, 40);
            this.labDate.Name = "labDate";
            this.labDate.Size = new System.Drawing.Size(90, 13);
            this.labDate.TabIndex = 5;
            this.labDate.Text = "Date: 2023-04-12";
            // 
            // labID
            // 
            this.labID.AutoSize = true;
            this.labID.Location = new System.Drawing.Point(11, 22);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(85, 13);
            this.labID.TabIndex = 4;
            this.labID.Text = "Order ID: O0001";
            // 
            // dgvDetail
            // 
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(6, 86);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.Size = new System.Drawing.Size(538, 233);
            this.dgvDetail.TabIndex = 3;
            // 
            // labAddress
            // 
            this.labAddress.AutoSize = true;
            this.labAddress.Location = new System.Drawing.Point(262, 58);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(89, 13);
            this.labAddress.TabIndex = 2;
            this.labAddress.Text = "Address: TPHCM";
            // 
            // labPhone
            // 
            this.labPhone.AutoSize = true;
            this.labPhone.Location = new System.Drawing.Point(262, 39);
            this.labPhone.Name = "labPhone";
            this.labPhone.Size = new System.Drawing.Size(142, 13);
            this.labPhone.TabIndex = 1;
            this.labPhone.Text = "Phone number: 0903146709";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(263, 21);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(160, 13);
            this.labName.TabIndex = 0;
            this.labName.Text = "Customer name: Đoàn Kim Bảng";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 373);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form4";
            this.Text = "Order detail";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labAddress;
        private System.Windows.Forms.Label labPhone;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label labDate;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.Label labAmount;
    }
}