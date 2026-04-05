namespace desktopapp_GYM
{
    partial class frmEditAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpPassword = new System.Windows.Forms.GroupBox();
            this.lblNotice = new System.Windows.Forms.Label();
            this.btnEditPass = new System.Windows.Forms.Button();
            this.grpPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên tài khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu mới";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 36);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật khẩu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 36);
            this.label5.TabIndex = 4;
            this.label5.Text = "Vai trò";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(277, 173);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(569, 44);
            this.txtUsername.TabIndex = 5;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(238, 192);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(569, 44);
            this.txtNewPass.TabIndex = 6;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(241, 63);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(569, 44);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // cboRole
            // 
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(277, 259);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(304, 44);
            this.cboRole.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(80, 693);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(199, 51);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(316, 693);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(199, 51);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExit.Location = new System.Drawing.Point(706, 684);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(215, 69);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // grpPassword
            // 
            this.grpPassword.Controls.Add(this.lblNotice);
            this.grpPassword.Controls.Add(this.label4);
            this.grpPassword.Controls.Add(this.txtPassword);
            this.grpPassword.Controls.Add(this.label3);
            this.grpPassword.Controls.Add(this.txtNewPass);
            this.grpPassword.Location = new System.Drawing.Point(39, 380);
            this.grpPassword.Name = "grpPassword";
            this.grpPassword.Size = new System.Drawing.Size(857, 272);
            this.grpPassword.TabIndex = 12;
            this.grpPassword.TabStop = false;
            this.grpPassword.Text = "Mật khẩu";
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotice.ForeColor = System.Drawing.Color.Red;
            this.lblNotice.Location = new System.Drawing.Point(271, 130);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(85, 31);
            this.lblNotice.TabIndex = 8;
            this.lblNotice.Text = "label6";
            // 
            // btnEditPass
            // 
            this.btnEditPass.Location = new System.Drawing.Point(665, 259);
            this.btnEditPass.Name = "btnEditPass";
            this.btnEditPass.Size = new System.Drawing.Size(181, 92);
            this.btnEditPass.TabIndex = 13;
            this.btnEditPass.Text = "Điều chỉnh Password";
            this.btnEditPass.UseVisualStyleBackColor = true;
            this.btnEditPass.Click += new System.EventHandler(this.btnEditPass_Click);
            // 
            // frmEditAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 805);
            this.Controls.Add(this.btnEditPass);
            this.Controls.Add(this.grpPassword);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmEditAccount";
            this.Text = "frmEditAccount";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditAccount_FormClosing);
            this.grpPassword.ResumeLayout(false);
            this.grpPassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox grpPassword;
        private System.Windows.Forms.Button btnEditPass;
        private System.Windows.Forms.Label lblNotice;
    }
}