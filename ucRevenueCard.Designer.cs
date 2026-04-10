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
            this.btnPin.Location = new System.Drawing.Point(1364, 6);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblRevenueSubText);
            this.panel2.Controls.Add(this.lblRevenue);
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Size = new System.Drawing.Size(400, 223);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalRevenue);
            this.panel1.Size = new System.Drawing.Size(400, 43);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.lblTotalRevenue, 0);
            // 
            // panelFooter
            // 
            this.panelFooter.Location = new System.Drawing.Point(0, 266);
            this.panelFooter.Size = new System.Drawing.Size(400, 34);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(300, 0);
            this.btnViewDetail.Size = new System.Drawing.Size(100, 34);
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Location = new System.Drawing.Point(44, 8);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(212, 25);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "Doanh thu tháng này";
            // 
            // lblRevenue
            // 
            this.lblRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.Location = new System.Drawing.Point(105, 78);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(152, 55);
            this.lblRevenue.TabIndex = 0;
            this.lblRevenue.Text = "label1";
            // 
            // lblRevenueSubText
            // 
            this.lblRevenueSubText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRevenueSubText.AutoSize = true;
            this.lblRevenueSubText.Location = new System.Drawing.Point(136, 163);
            this.lblRevenueSubText.Name = "lblRevenueSubText";
            this.lblRevenueSubText.Size = new System.Drawing.Size(70, 25);
            this.lblRevenueSubText.TabIndex = 1;
            this.lblRevenueSubText.Text = "label1";
            // 
            // ucRevenueCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Name = "ucRevenueCard";
            this.Size = new System.Drawing.Size(400, 300);
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
