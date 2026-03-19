namespace desktopapp_GYM
{
    partial class ucExpiredAlert
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
            this.dtExpired = new System.Windows.Forms.DataGridView();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtExpired)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPin
            // 
            this.btnPin.Location = new System.Drawing.Point(460, 6);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtExpired);
            this.panel2.Size = new System.Drawing.Size(274, 192);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblThongBao);
            this.panel1.Size = new System.Drawing.Size(274, 34);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.lblThongBao, 0);
            // 
            // panelFooter
            // 
            this.panelFooter.Location = new System.Drawing.Point(0, 226);
            this.panelFooter.Size = new System.Drawing.Size(274, 34);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(174, 0);
            // 
            // dtExpired
            // 
            this.dtExpired.AllowUserToAddRows = false;
            this.dtExpired.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtExpired.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtExpired.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtExpired.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtExpired.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtExpired.Location = new System.Drawing.Point(0, 0);
            this.dtExpired.Name = "dtExpired";
            this.dtExpired.ReadOnly = true;
            this.dtExpired.RowHeadersWidth = 82;
            this.dtExpired.RowTemplate.Height = 33;
            this.dtExpired.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtExpired.Size = new System.Drawing.Size(274, 192);
            this.dtExpired.TabIndex = 0;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Location = new System.Drawing.Point(32, 6);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(70, 25);
            this.lblThongBao.TabIndex = 1;
            this.lblThongBao.Text = "label1";
            // 
            // ucExpiredAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucExpiredAlert";
            this.Size = new System.Drawing.Size(274, 260);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtExpired)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtExpired;
        private System.Windows.Forms.Label lblThongBao;
    }
}
