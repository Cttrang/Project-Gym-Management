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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlSidebarGuest = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnRegis = new System.Windows.Forms.Button();
            this.btnTrainer = new System.Windows.Forms.Button();
            this.btnPackage = new System.Windows.Forms.Button();
            this.btnClassRegis = new System.Windows.Forms.Button();
            this.btnSchedules = new System.Windows.Forms.Button();
            this.btnMember = new System.Windows.Forms.Button();
            this.btnEditAcc = new System.Windows.Forms.Button();
            this.btnManagerAcc = new System.Windows.Forms.Button();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pnlContentGuest = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ucRevenueChart1 = new desktopapp_GYM.ucRevenueChart();
            this.ucExpiredAlert1 = new desktopapp_GYM.ucExpiredAlert();
            this.ucMemberStats1 = new desktopapp_GYM.ucMemberStats();
            this.ucPackagePrice1 = new desktopapp_GYM.ucPackagePrice();
            this.ucRevenueCard1 = new desktopapp_GYM.ucRevenueCard();
            this.ucTimeslotToday1 = new desktopapp_GYM.ucTimeslotToday();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlSidebarGuest.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlContentGuest.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebarGuest
            // 
            this.pnlSidebarGuest.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlSidebarGuest.Controls.Add(this.flowLayoutPanel2);
            this.pnlSidebarGuest.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebarGuest.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebarGuest.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSidebarGuest.Name = "pnlSidebarGuest";
            this.pnlSidebarGuest.Size = new System.Drawing.Size(314, 981);
            this.pnlSidebarGuest.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel2.Controls.Add(this.btnDashboard);
            this.flowLayoutPanel2.Controls.Add(this.btnRegis);
            this.flowLayoutPanel2.Controls.Add(this.btnTrainer);
            this.flowLayoutPanel2.Controls.Add(this.btnPackage);
            this.flowLayoutPanel2.Controls.Add(this.btnClassRegis);
            this.flowLayoutPanel2.Controls.Add(this.btnSchedules);
            this.flowLayoutPanel2.Controls.Add(this.btnMember);
            this.flowLayoutPanel2.Controls.Add(this.btnEditAcc);
            this.flowLayoutPanel2.Controls.Add(this.btnManagerAcc);
            this.flowLayoutPanel2.Controls.Add(this.btnRevenue);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(314, 981);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 198);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Location = new System.Drawing.Point(4, 210);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(302, 54);
            this.btnDashboard.TabIndex = 4;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnRegis
            // 
            this.btnRegis.Location = new System.Drawing.Point(4, 272);
            this.btnRegis.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegis.Name = "btnRegis";
            this.btnRegis.Size = new System.Drawing.Size(302, 54);
            this.btnRegis.TabIndex = 10;
            this.btnRegis.Text = "Quản lý đăng kí gói";
            this.btnRegis.UseVisualStyleBackColor = true;
            this.btnRegis.Click += new System.EventHandler(this.btnRegis_Click);
            // 
            // btnTrainer
            // 
            this.btnTrainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrainer.Location = new System.Drawing.Point(4, 334);
            this.btnTrainer.Margin = new System.Windows.Forms.Padding(4);
            this.btnTrainer.Name = "btnTrainer";
            this.btnTrainer.Size = new System.Drawing.Size(302, 65);
            this.btnTrainer.TabIndex = 1;
            this.btnTrainer.Text = "Quản lý huấn luyện viên";
            this.btnTrainer.UseVisualStyleBackColor = true;
            this.btnTrainer.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPackage
            // 
            this.btnPackage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPackage.Location = new System.Drawing.Point(4, 407);
            this.btnPackage.Margin = new System.Windows.Forms.Padding(4);
            this.btnPackage.Name = "btnPackage";
            this.btnPackage.Size = new System.Drawing.Size(302, 54);
            this.btnPackage.TabIndex = 0;
            this.btnPackage.Text = "Quản lý gói tập";
            this.btnPackage.UseVisualStyleBackColor = true;
            this.btnPackage.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClassRegis
            // 
            this.btnClassRegis.Location = new System.Drawing.Point(4, 469);
            this.btnClassRegis.Margin = new System.Windows.Forms.Padding(4);
            this.btnClassRegis.Name = "btnClassRegis";
            this.btnClassRegis.Size = new System.Drawing.Size(302, 54);
            this.btnClassRegis.TabIndex = 7;
            this.btnClassRegis.Text = "Quản lý lịch";
            this.btnClassRegis.UseVisualStyleBackColor = true;
            this.btnClassRegis.Click += new System.EventHandler(this.btnClassRegis_Click);
            // 
            // btnSchedules
            // 
            this.btnSchedules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchedules.Location = new System.Drawing.Point(4, 531);
            this.btnSchedules.Margin = new System.Windows.Forms.Padding(4);
            this.btnSchedules.Name = "btnSchedules";
            this.btnSchedules.Size = new System.Drawing.Size(302, 54);
            this.btnSchedules.TabIndex = 11;
            this.btnSchedules.Text = "Quản lý điểm danh và bù";
            this.btnSchedules.UseVisualStyleBackColor = true;
            this.btnSchedules.Click += new System.EventHandler(this.btnSchedules_Click);
            // 
            // btnMember
            // 
            this.btnMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMember.Location = new System.Drawing.Point(4, 593);
            this.btnMember.Margin = new System.Windows.Forms.Padding(4);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(302, 54);
            this.btnMember.TabIndex = 5;
            this.btnMember.Text = "Quản lý hội viên";
            this.btnMember.UseVisualStyleBackColor = true;
            this.btnMember.Click += new System.EventHandler(this.txtMember_Click);
            // 
            // btnEditAcc
            // 
            this.btnEditAcc.Location = new System.Drawing.Point(4, 655);
            this.btnEditAcc.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditAcc.Name = "btnEditAcc";
            this.btnEditAcc.Size = new System.Drawing.Size(302, 54);
            this.btnEditAcc.TabIndex = 8;
            this.btnEditAcc.Text = "Chỉnh sửa tài khoản";
            this.btnEditAcc.UseVisualStyleBackColor = true;
            this.btnEditAcc.Click += new System.EventHandler(this.btnEditAcc_Click);
            // 
            // btnManagerAcc
            // 
            this.btnManagerAcc.Location = new System.Drawing.Point(4, 717);
            this.btnManagerAcc.Margin = new System.Windows.Forms.Padding(4);
            this.btnManagerAcc.Name = "btnManagerAcc";
            this.btnManagerAcc.Size = new System.Drawing.Size(302, 54);
            this.btnManagerAcc.TabIndex = 9;
            this.btnManagerAcc.Text = "Quản lý tài khoản";
            this.btnManagerAcc.UseVisualStyleBackColor = true;
            this.btnManagerAcc.Click += new System.EventHandler(this.btnManagerAcc_Click);
            // 
            // btnRevenue
            // 
            this.btnRevenue.Location = new System.Drawing.Point(4, 779);
            this.btnRevenue.Margin = new System.Windows.Forms.Padding(4);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(302, 54);
            this.btnRevenue.TabIndex = 13;
            this.btnRevenue.Text = "Giám sát doanh thu";
            this.btnRevenue.UseVisualStyleBackColor = true;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(1036, 12);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(164, 54);
            this.button6.TabIndex = 6;
            this.button6.Text = "Đăng Xuất";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // pnlContentGuest
            // 
            this.pnlContentGuest.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlContentGuest.Controls.Add(this.pnlContent);
            this.pnlContentGuest.Controls.Add(this.panel1);
            this.pnlContentGuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentGuest.Location = new System.Drawing.Point(314, 0);
            this.pnlContentGuest.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContentGuest.Name = "pnlContentGuest";
            this.pnlContentGuest.Size = new System.Drawing.Size(1214, 981);
            this.pnlContentGuest.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.flowLayoutPanel1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 202);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1214, 779);
            this.pnlContent.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.ucRevenueChart1);
            this.flowLayoutPanel1.Controls.Add(this.ucExpiredAlert1);
            this.flowLayoutPanel1.Controls.Add(this.ucMemberStats1);
            this.flowLayoutPanel1.Controls.Add(this.ucPackagePrice1);
            this.flowLayoutPanel1.Controls.Add(this.ucRevenueCard1);
            this.flowLayoutPanel1.Controls.Add(this.ucTimeslotToday1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1214, 779);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // ucRevenueChart1
            // 
            this.ucRevenueChart1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ucRevenueChart1.BorderRadius = 30;
            this.ucRevenueChart1.Location = new System.Drawing.Point(2, 2);
            this.ucRevenueChart1.Margin = new System.Windows.Forms.Padding(2);
            this.ucRevenueChart1.Name = "ucRevenueChart1";
            this.ucRevenueChart1.Size = new System.Drawing.Size(1280, 779);
            this.ucRevenueChart1.TabIndex = 1;
            // 
            // ucExpiredAlert1
            // 
            this.ucExpiredAlert1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ucExpiredAlert1.BorderRadius = 30;
            this.ucExpiredAlert1.Location = new System.Drawing.Point(2, 785);
            this.ucExpiredAlert1.Margin = new System.Windows.Forms.Padding(2);
            this.ucExpiredAlert1.Name = "ucExpiredAlert1";
            this.ucExpiredAlert1.Size = new System.Drawing.Size(880, 779);
            this.ucExpiredAlert1.TabIndex = 2;
            // 
            // ucMemberStats1
            // 
            this.ucMemberStats1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ucMemberStats1.BorderRadius = 30;
            this.ucMemberStats1.Location = new System.Drawing.Point(888, 787);
            this.ucMemberStats1.Margin = new System.Windows.Forms.Padding(4);
            this.ucMemberStats1.Name = "ucMemberStats1";
            this.ucMemberStats1.Size = new System.Drawing.Size(381, 256);
            this.ucMemberStats1.TabIndex = 0;
            // 
            // ucPackagePrice1
            // 
            this.ucPackagePrice1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ucPackagePrice1.BorderRadius = 30;
            this.ucPackagePrice1.Location = new System.Drawing.Point(4, 1570);
            this.ucPackagePrice1.Margin = new System.Windows.Forms.Padding(4);
            this.ucPackagePrice1.Name = "ucPackagePrice1";
            this.ucPackagePrice1.Size = new System.Drawing.Size(686, 292);
            this.ucPackagePrice1.TabIndex = 3;
            // 
            // ucRevenueCard1
            // 
            this.ucRevenueCard1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ucRevenueCard1.BorderRadius = 30;
            this.ucRevenueCard1.Location = new System.Drawing.Point(698, 1570);
            this.ucRevenueCard1.Margin = new System.Windows.Forms.Padding(4);
            this.ucRevenueCard1.Name = "ucRevenueCard1";
            this.ucRevenueCard1.Size = new System.Drawing.Size(400, 300);
            this.ucRevenueCard1.TabIndex = 4;
            // 
            // ucTimeslotToday1
            // 
            this.ucTimeslotToday1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ucTimeslotToday1.BorderRadius = 30;
            this.ucTimeslotToday1.Location = new System.Drawing.Point(4, 1878);
            this.ucTimeslotToday1.Margin = new System.Windows.Forms.Padding(4);
            this.ucTimeslotToday1.Name = "ucTimeslotToday1";
            this.ucTimeslotToday1.Size = new System.Drawing.Size(522, 317);
            this.ucTimeslotToday1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1214, 202);
            this.panel1.TabIndex = 3;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(256, 98);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(105, 42);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "label3";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hệ thống quản lý Gym Beauty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chào mừng: ";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 981);
            this.Controls.Add(this.pnlContentGuest);
            this.Controls.Add(this.pnlSidebarGuest);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlSidebarGuest.ResumeLayout(false);
            this.pnlSidebarGuest.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlContentGuest.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebarGuest;
        private System.Windows.Forms.Button btnTrainer;
        private System.Windows.Forms.Button btnPackage;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel pnlContentGuest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlContent;
        private ucMemberStats ucMemberStats1;
        private ucRevenueChart ucRevenueChart1;
        private ucExpiredAlert ucExpiredAlert1;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ucPackagePrice ucPackagePrice1;
        private System.Windows.Forms.Button btnClassRegis;
        private System.Windows.Forms.Button btnEditAcc;
        private System.Windows.Forms.Button btnManagerAcc;
        private ucRevenueCard ucRevenueCard1;
        private System.Windows.Forms.Button btnRegis;
        private ucTimeslotToday ucTimeslotToday1;
        private System.Windows.Forms.Button btnSchedules;
        private System.Windows.Forms.Button btnRevenue;
    }
}