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
            this.btnPin.Location = new System.Drawing.Point(354, 3);
            this.btnPin.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtExpired);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel2.Size = new System.Drawing.Size(137, 99);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblThongBao);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel1.Size = new System.Drawing.Size(137, 18);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.lblThongBao, 0);
            // 
            // panelFooter
            // 
            this.panelFooter.Location = new System.Drawing.Point(0, 117);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panelFooter.Size = new System.Drawing.Size(137, 18);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(87, 0);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
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
            this.dtExpired.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtExpired.Name = "dtExpired";
            this.dtExpired.ReadOnly = true;
            this.dtExpired.RowHeadersWidth = 82;
            this.dtExpired.RowTemplate.Height = 33;
            this.dtExpired.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtExpired.Size = new System.Drawing.Size(137, 99);
            this.dtExpired.TabIndex = 0;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Location = new System.Drawing.Point(16, 3);
            this.lblThongBao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(35, 13);
            this.lblThongBao.TabIndex = 1;
            this.lblThongBao.Text = "label1";
            // 
            // ucExpiredAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "ucExpiredAlert";
            this.Size = new System.Drawing.Size(137, 135);
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
