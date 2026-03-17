namespace desktopapp_GYM.GUI
{
    partial class frmMain
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
            this.pnlSidebarGuest = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlContentGuest = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ucRevenueCard1 = new desktopapp_GYM.ucRevenueCard();
            this.ucMemberStats1 = new desktopapp_GYM.ucMemberStats();
            this.ucMemberStats2 = new desktopapp_GYM.ucMemberStats();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlSidebarGuest.SuspendLayout();
            this.pnlContentGuest.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebarGuest
            // 
            this.pnlSidebarGuest.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlSidebarGuest.Controls.Add(this.button6);
            this.pnlSidebarGuest.Controls.Add(this.button5);
            this.pnlSidebarGuest.Controls.Add(this.button4);
            this.pnlSidebarGuest.Controls.Add(this.button3);
            this.pnlSidebarGuest.Controls.Add(this.button2);
            this.pnlSidebarGuest.Controls.Add(this.button1);
            this.pnlSidebarGuest.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebarGuest.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebarGuest.Name = "pnlSidebarGuest";
            this.pnlSidebarGuest.Size = new System.Drawing.Size(218, 1028);
            this.pnlSidebarGuest.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.Location = new System.Drawing.Point(27, 958);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(165, 54);
            this.button6.TabIndex = 6;
            this.button6.Text = "Đăng Xuất";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(23, 309);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 54);
            this.button5.TabIndex = 5;
            this.button5.Text = "Hội viên";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(23, 117);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 54);
            this.button4.TabIndex = 4;
            this.button4.Text = "Dashboard";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(23, 369);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 54);
            this.button3.TabIndex = 2;
            this.button3.Text = "Về chúng tôi";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(23, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 66);
            this.button2.TabIndex = 1;
            this.button2.Text = "Xem huấn luyện viên";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(23, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Xem Gói Tập";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnlContentGuest
            // 
            this.pnlContentGuest.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlContentGuest.Controls.Add(this.flowLayoutPanel1);
            this.pnlContentGuest.Controls.Add(this.panel1);
            this.pnlContentGuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentGuest.Location = new System.Drawing.Point(218, 0);
            this.pnlContentGuest.Name = "pnlContentGuest";
            this.pnlContentGuest.Size = new System.Drawing.Size(1311, 1028);
            this.pnlContentGuest.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ucRevenueCard1);
            this.flowLayoutPanel1.Controls.Add(this.ucMemberStats1);
            this.flowLayoutPanel1.Controls.Add(this.ucMemberStats2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 171);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1311, 857);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // ucRevenueCard1
            // 
            this.ucRevenueCard1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ucRevenueCard1.BorderRadius = 30;
            this.ucRevenueCard1.Location = new System.Drawing.Point(3, 3);
            this.ucRevenueCard1.Name = "ucRevenueCard1";
            this.ucRevenueCard1.Size = new System.Drawing.Size(496, 266);
            this.ucRevenueCard1.TabIndex = 0;
            // 
            // ucMemberStats1
            // 
            this.ucMemberStats1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ucMemberStats1.BorderRadius = 30;
            this.ucMemberStats1.Location = new System.Drawing.Point(505, 3);
            this.ucMemberStats1.Name = "ucMemberStats1";
            this.ucMemberStats1.Size = new System.Drawing.Size(283, 266);
            this.ucMemberStats1.TabIndex = 1;
            // 
            // ucMemberStats2
            // 
            this.ucMemberStats2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ucMemberStats2.BorderRadius = 30;
            this.ucMemberStats2.Location = new System.Drawing.Point(794, 3);
            this.ucMemberStats2.Name = "ucMemberStats2";
            this.ucMemberStats2.Size = new System.Drawing.Size(200, 150);
            this.ucMemberStats2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1311, 171);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hệ thống quản lý Gym Beauty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chào mừng: ";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(234, 110);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(70, 25);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "label3";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 1028);
            this.Controls.Add(this.pnlContentGuest);
            this.Controls.Add(this.pnlSidebarGuest);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlSidebarGuest.ResumeLayout(false);
            this.pnlContentGuest.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebarGuest;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel pnlContentGuest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ucRevenueCard ucRevenueCard1;
        private ucMemberStats ucMemberStats1;
        private ucMemberStats ucMemberStats2;
        private System.Windows.Forms.Label lblWelcome;
    }
}