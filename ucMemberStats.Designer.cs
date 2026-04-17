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
            this.btnPin.Location = new System.Drawing.Point(238, 3);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMemberSubText);
            this.panel2.Controls.Add(this.lblMemberCount);
            this.panel2.Size = new System.Drawing.Size(178, 94);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalMembers);
            this.panel1.Size = new System.Drawing.Size(178, 26);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.lblTotalMembers, 0);
            // 
            // panelFooter
            // 
            this.panelFooter.Location = new System.Drawing.Point(0, 120);
            this.panelFooter.Size = new System.Drawing.Size(178, 18);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(128, 0);
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // lblTotalMembers
            // 
            this.lblTotalMembers.AutoSize = true;
            this.lblTotalMembers.Location = new System.Drawing.Point(18, 4);
            this.lblTotalMembers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalMembers.Name = "lblTotalMembers";
            this.lblTotalMembers.Size = new System.Drawing.Size(72, 13);
            this.lblTotalMembers.TabIndex = 1;
            this.lblTotalMembers.Text = "Tổng hội viên";
            // 
            // lblMemberCount
            // 
            this.lblMemberCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMemberCount.AutoSize = true;
            this.lblMemberCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberCount.Location = new System.Drawing.Point(35, 48);
            this.lblMemberCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMemberCount.Name = "lblMemberCount";
            this.lblMemberCount.Size = new System.Drawing.Size(20, 24);
            this.lblMemberCount.TabIndex = 0;
            this.lblMemberCount.Text = "0";
            // 
            // lblMemberSubText
            // 
            this.lblMemberSubText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMemberSubText.AutoSize = true;
            this.lblMemberSubText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberSubText.Location = new System.Drawing.Point(2, 13);
            this.lblMemberSubText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMemberSubText.Name = "lblMemberSubText";
            this.lblMemberSubText.Size = new System.Drawing.Size(142, 19);
            this.lblMemberSubText.TabIndex = 2;
            this.lblMemberSubText.Text = "Chúc mừng gym!!!!!";
            // 
            // ucMemberStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ucMemberStats";
            this.Size = new System.Drawing.Size(178, 138);
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
