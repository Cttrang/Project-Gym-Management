namespace desktopapp_GYM
{
    partial class ucDashBoard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpDashBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.ucRevenueChart1 = new desktopapp_GYM.ucRevenueChart();
            this.ucRevenueChart2 = new desktopapp_GYM.ucRevenueChart();
            this.flpDashBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 57);
            this.panel1.TabIndex = 0;
            // 
            // flpDashBoard
            // 
            this.flpDashBoard.AutoScroll = true;
            this.flpDashBoard.Controls.Add(this.ucRevenueChart1);
            this.flpDashBoard.Controls.Add(this.ucRevenueChart2);
            this.flpDashBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDashBoard.Location = new System.Drawing.Point(0, 57);
            this.flpDashBoard.Name = "flpDashBoard";
            this.flpDashBoard.Size = new System.Drawing.Size(567, 416);
            this.flpDashBoard.TabIndex = 1;
            // 
            // ucRevenueChart1
            // 
            this.ucRevenueChart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucRevenueChart1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ucRevenueChart1.BorderRadius = 30;
            this.ucRevenueChart1.Location = new System.Drawing.Point(3, 3);
            this.ucRevenueChart1.Name = "ucRevenueChart1";
            this.ucRevenueChart1.Size = new System.Drawing.Size(246, 238);
            this.ucRevenueChart1.TabIndex = 0;
            // 
            // ucRevenueChart2
            // 
            this.ucRevenueChart2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ucRevenueChart2.BorderRadius = 30;
            this.ucRevenueChart2.Location = new System.Drawing.Point(255, 3);
            this.ucRevenueChart2.Name = "ucRevenueChart2";
            this.ucRevenueChart2.Size = new System.Drawing.Size(300, 350);
            this.ucRevenueChart2.TabIndex = 1;
            // 
            // ucDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpDashBoard);
            this.Controls.Add(this.panel1);
            this.Name = "ucDashBoard";
            this.Size = new System.Drawing.Size(567, 473);
            this.flpDashBoard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpDashBoard;
        private ucRevenueChart ucRevenueChart1;
        private ucRevenueChart ucRevenueChart2;
    }
}
