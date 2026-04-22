namespace desktopapp_GYM
{
    partial class ucMemberStats
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
            this.lblTotalMembers = new System.Windows.Forms.Label();
            this.lblMemberCount = new System.Windows.Forms.Label();
            this.lblMemberSubText = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPin
            // 
            this.btnPin.Location = new System.Drawing.Point(1582, 6);
            this.btnPin.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.Controls.Add(this.lblMemberSubText);
            this.panel2.Controls.Add(this.lblMemberCount);
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panel2.Size = new System.Drawing.Size(412, 186);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.lblTotalMembers);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panel1.Size = new System.Drawing.Size(412, 72);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.lblTotalMembers, 0);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelFooter.Location = new System.Drawing.Point(0, 258);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panelFooter.Size = new System.Drawing.Size(412, 34);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(312, 0);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnViewDetail.Size = new System.Drawing.Size(100, 34);
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // lblTotalMembers
            // 
            this.lblTotalMembers.AutoSize = true;
            this.lblTotalMembers.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTotalMembers.Location = new System.Drawing.Point(30, 14);
            this.lblTotalMembers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalMembers.Name = "lblTotalMembers";
            this.lblTotalMembers.Size = new System.Drawing.Size(308, 42);
            this.lblTotalMembers.TabIndex = 1;
            this.lblTotalMembers.Text = "TỔNG HỘI VIÊN";
            // 
            // lblMemberCount
            // 
            this.lblMemberCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMemberCount.AutoSize = true;
            this.lblMemberCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberCount.Location = new System.Drawing.Point(108, 87);
            this.lblMemberCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberCount.Name = "lblMemberCount";
            this.lblMemberCount.Size = new System.Drawing.Size(39, 42);
            this.lblMemberCount.TabIndex = 0;
            this.lblMemberCount.Text = "0";
            // 
            // lblMemberSubText
            // 
            this.lblMemberSubText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMemberSubText.AutoSize = true;
            this.lblMemberSubText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMemberSubText.Location = new System.Drawing.Point(16, 39);
            this.lblMemberSubText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberSubText.Name = "lblMemberSubText";
            this.lblMemberSubText.Size = new System.Drawing.Size(374, 32);
            this.lblMemberSubText.TabIndex = 2;
            this.lblMemberSubText.Text = "CHÚC MỪNG GYM ĐÃ CÓ:";
            this.lblMemberSubText.Click += new System.EventHandler(this.lblMemberSubText_Click);
            // 
            // ucMemberStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucMemberStats";
            this.Size = new System.Drawing.Size(412, 292);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTotalMembers;
        private System.Windows.Forms.Label lblMemberCount;
        private System.Windows.Forms.Label lblMemberSubText;
    }
}
