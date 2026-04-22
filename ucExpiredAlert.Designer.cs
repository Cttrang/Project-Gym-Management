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
            this.btnPin.Location = new System.Drawing.Point(582, 6);
            this.btnPin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtExpired);
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Size = new System.Drawing.Size(274, 145);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.lblThongBao);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Size = new System.Drawing.Size(274, 80);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.lblThongBao, 0);
            // 
            // panelFooter
            // 
            this.panelFooter.Location = new System.Drawing.Point(0, 225);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelFooter.Size = new System.Drawing.Size(274, 35);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(174, 0);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // dtExpired
            // 
            this.dtExpired.AllowUserToAddRows = false;
            this.dtExpired.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtExpired.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtExpired.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtExpired.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtExpired.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtExpired.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtExpired.Location = new System.Drawing.Point(0, 0);
            this.dtExpired.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtExpired.Name = "dtExpired";
            this.dtExpired.ReadOnly = true;
            this.dtExpired.RowHeadersWidth = 82;
            this.dtExpired.RowTemplate.Height = 33;
            this.dtExpired.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtExpired.Size = new System.Drawing.Size(274, 145);
            this.dtExpired.TabIndex = 0;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblThongBao.Location = new System.Drawing.Point(30, 24);
            this.lblThongBao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(97, 36);
            this.lblThongBao.TabIndex = 1;
            this.lblThongBao.Text = "label1";
            // 
            // ucExpiredAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
