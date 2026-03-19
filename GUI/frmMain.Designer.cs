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
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlContentGuest = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ucExpiredAlert1 = new desktopapp_GYM.ucExpiredAlert();
            this.ucRevenueChart1 = new desktopapp_GYM.ucRevenueChart();
            this.pnlSidebarGuest.SuspendLayout();
            this.pnlContentGuest.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebarGuest
            // 
            this.pnlSidebarGuest.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlSidebarGuest.Controls.Add(this.flowLayoutPanel2);
            this.pnlSidebarGuest.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebarGuest.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebarGuest.Name = "pnlSidebarGuest";
            this.pnlSidebarGuest.Size = new System.Drawing.Size(218, 1028);
            this.pnlSidebarGuest.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.Location = new System.Drawing.Point(620, 105);
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
            this.button5.Location = new System.Drawing.Point(3, 460);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(215, 54);
            this.button5.TabIndex = 5;
            this.button5.Text = "Hội viên";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 208);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(215, 54);
            this.button4.TabIndex = 4;
            this.button4.Text = "Dashboard";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(3, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(215, 54);
            this.button3.TabIndex = 2;
            this.button3.Text = "Về chúng tôi";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(3, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(215, 66);
            this.button2.TabIndex = 1;
            this.button2.Text = "Xem huấn luyện viên";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(3, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 54);
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
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.ucExpiredAlert1);
            this.flowLayoutPanel1.Controls.Add(this.ucRevenueChart1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 171);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1311, 857);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1311, 171);
            this.panel1.TabIndex = 3;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(230, 111);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(97, 36);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 28);
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
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel2.Controls.Add(this.button4);
            this.flowLayoutPanel2.Controls.Add(this.button2);
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Controls.Add(this.button3);
            this.flowLayoutPanel2.Controls.Add(this.button5);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(218, 1028);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // ucExpiredAlert1
            // 
            this.ucExpiredAlert1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ucExpiredAlert1.BorderRadius = 30;
            this.ucExpiredAlert1.Location = new System.Drawing.Point(3, 3);
            this.ucExpiredAlert1.Name = "ucExpiredAlert1";
            this.ucExpiredAlert1.Size = new System.Drawing.Size(879, 387);
            this.ucExpiredAlert1.TabIndex = 4;
            // 
            // ucRevenueChart1
            // 
            this.ucRevenueChart1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ucRevenueChart1.BorderRadius = 30;
            this.ucRevenueChart1.Location = new System.Drawing.Point(3, 396);
            this.ucRevenueChart1.Name = "ucRevenueChart1";
            this.ucRevenueChart1.Size = new System.Drawing.Size(1131, 479);
            this.ucRevenueChart1.TabIndex = 3;
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
            this.pnlSidebarGuest.PerformLayout();
            this.pnlContentGuest.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label lblWelcome;
        private ucRevenueChart ucRevenueChart1;
        private ucExpiredAlert ucExpiredAlert1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}