namespace desktopapp_GYM.GUI
{
    partial class frmGuest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuest));
            this.pnlSidebarGuest = new System.Windows.Forms.Panel();
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoginGuest = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ucPackagePrice1 = new desktopapp_GYM.ucPackagePrice();
            this.ucTrainerStatus1 = new desktopapp_GYM.ucTrainerStatus();
            this.pnlSidebarGuest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebarGuest
            // 
            this.pnlSidebarGuest.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlSidebarGuest.Controls.Add(this.btnDashBoard);
            this.pnlSidebarGuest.Controls.Add(this.pictureBox1);
            this.pnlSidebarGuest.Controls.Add(this.btnLoginGuest);
            this.pnlSidebarGuest.Controls.Add(this.button3);
            this.pnlSidebarGuest.Controls.Add(this.button2);
            this.pnlSidebarGuest.Controls.Add(this.button1);
            this.pnlSidebarGuest.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebarGuest.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebarGuest.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSidebarGuest.Name = "pnlSidebarGuest";
            this.pnlSidebarGuest.Size = new System.Drawing.Size(172, 510);
            this.pnlSidebarGuest.TabIndex = 0;
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDashBoard.Location = new System.Drawing.Point(19, 136);
            this.btnDashBoard.Margin = new System.Windows.Forms.Padding(2);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(130, 44);
            this.btnDashBoard.TabIndex = 5;
            this.btnDashBoard.Text = "DashBoard";
            this.btnDashBoard.UseVisualStyleBackColor = true;
            this.btnDashBoard.Click += new System.EventHandler(this.btnDashBoard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoginGuest
            // 
            this.btnLoginGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoginGuest.Location = new System.Drawing.Point(12, 453);
            this.btnLoginGuest.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoginGuest.Name = "btnLoginGuest";
            this.btnLoginGuest.Size = new System.Drawing.Size(151, 39);
            this.btnLoginGuest.TabIndex = 3;
            this.btnLoginGuest.Text = "Login";
            this.btnLoginGuest.UseVisualStyleBackColor = true;
            this.btnLoginGuest.Click += new System.EventHandler(this.btnLoginGuest_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(19, 286);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 45);
            this.button3.TabIndex = 2;
            this.button3.Text = "Về chúng tôi";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(19, 184);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "Xem huấn luyện viên";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(19, 238);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "Xem Gói Tập";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(172, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 116);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ở đây chúng tôi có:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chào mừng đến với Gym Beauty";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelContent.Controls.Add(this.flowLayoutPanel1);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(172, 116);
            this.panelContent.Margin = new System.Windows.Forms.Padding(2);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(630, 394);
            this.panelContent.TabIndex = 2;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ucPackagePrice1);
            this.flowLayoutPanel1.Controls.Add(this.ucTrainerStatus1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(630, 394);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ucPackagePrice1
            // 
            this.ucPackagePrice1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ucPackagePrice1.BorderRadius = 30;
            this.ucPackagePrice1.Location = new System.Drawing.Point(2, 2);
            this.ucPackagePrice1.Margin = new System.Windows.Forms.Padding(2);
            this.ucPackagePrice1.Name = "ucPackagePrice1";
            this.ucPackagePrice1.Size = new System.Drawing.Size(363, 199);
            this.ucPackagePrice1.TabIndex = 0;
            // 
            // ucTrainerStatus1
            // 
            this.ucTrainerStatus1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ucTrainerStatus1.BorderRadius = 30;
            this.ucTrainerStatus1.Location = new System.Drawing.Point(2, 205);
            this.ucTrainerStatus1.Margin = new System.Windows.Forms.Padding(2);
            this.ucTrainerStatus1.Name = "ucTrainerStatus1";
            this.ucTrainerStatus1.Size = new System.Drawing.Size(425, 192);
            this.ucTrainerStatus1.TabIndex = 1;
            // 
            // frmGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 510);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlSidebarGuest);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmGuest";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGuest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebarGuest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebarGuest;
        private System.Windows.Forms.Button btnLoginGuest;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ucPackagePrice ucPackagePrice1;
        private System.Windows.Forms.Button btnDashBoard;
        private ucTrainerStatus ucTrainerStatus1;
    }
}