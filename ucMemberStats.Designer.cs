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
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMemberSubText);
            this.panel2.Controls.Add(this.lblMemberCount);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalMembers);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.lblTotalMembers, 0);
            // 
            // lblTotalMembers
            // 
            this.lblTotalMembers.AutoSize = true;
            this.lblTotalMembers.Location = new System.Drawing.Point(35, 8);
            this.lblTotalMembers.Name = "lblTotalMembers";
            this.lblTotalMembers.Size = new System.Drawing.Size(142, 25);
            this.lblTotalMembers.TabIndex = 1;
            this.lblTotalMembers.Text = "Tổng hội viên";
            // 
            // lblMemberCount
            // 
            this.lblMemberCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMemberCount.AutoSize = true;
            this.lblMemberCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberCount.Location = new System.Drawing.Point(53, 39);
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
            this.lblMemberSubText.Location = new System.Drawing.Point(107, 79);
            this.lblMemberSubText.Name = "lblMemberSubText";
            this.lblMemberSubText.Size = new System.Drawing.Size(70, 25);
            this.lblMemberSubText.TabIndex = 2;
            this.lblMemberSubText.Text = "label1";
            // 
            // ucMemberStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Name = "ucMemberStats";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTotalMembers;
        private System.Windows.Forms.Label lblMemberCount;
        private System.Windows.Forms.Label lblMemberSubText;
    }
}
