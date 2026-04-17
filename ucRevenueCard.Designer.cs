namespace desktopapp_GYM
{
    partial class ucRevenueCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblRevenueSubText = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPin
            // 
            this.btnPin.Location = new System.Drawing.Point(1032, 3);
            this.btnPin.Margin = new System.Windows.Forms.Padding(1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblRevenueSubText);
            this.panel2.Controls.Add(this.lblRevenue);
            this.panel2.Location = new System.Drawing.Point(0, 22);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Size = new System.Drawing.Size(200, 116);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalRevenue);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(200, 22);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.lblTotalRevenue, 0);
            // 
            // panelFooter
            // 
            this.panelFooter.Location = new System.Drawing.Point(0, 138);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(1);
            this.panelFooter.Size = new System.Drawing.Size(200, 18);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(150, 0);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(1);
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Location = new System.Drawing.Point(22, 4);
            this.lblTotalRevenue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(107, 13);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "Doanh thu tháng này";
            // 
            // lblRevenue
            // 
            this.lblRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.Location = new System.Drawing.Point(52, 41);
            this.lblRevenue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(79, 29);
            this.lblRevenue.TabIndex = 0;
            this.lblRevenue.Text = "label1";
            // 
            // lblRevenueSubText
            // 
            this.lblRevenueSubText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRevenueSubText.AutoSize = true;
            this.lblRevenueSubText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueSubText.Location = new System.Drawing.Point(22, 15);
            this.lblRevenueSubText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRevenueSubText.Name = "lblRevenueSubText";
            this.lblRevenueSubText.Size = new System.Drawing.Size(79, 19);
            this.lblRevenueSubText.TabIndex = 1;
            this.lblRevenueSubText.Text = "Đã đạt!!!!!";
            // 
            // ucRevenueCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ucRevenueCard";
            this.Size = new System.Drawing.Size(200, 156);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblRevenueSubText;
        private System.Windows.Forms.Label lblRevenue;
    }
}
