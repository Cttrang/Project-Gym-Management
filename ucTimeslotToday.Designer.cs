namespace desktopapp_GYM
{
    partial class ucTimeslotToday
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.dgvTimeslotToday = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeslotToday)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPin
            // 
            this.btnPin.Location = new System.Drawing.Point(1482, 6);
            this.btnPin.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.dgvTimeslotToday);
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panel2.Size = new System.Drawing.Size(522, 228);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panel1.Size = new System.Drawing.Size(522, 54);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelFooter.Location = new System.Drawing.Point(0, 282);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panelFooter.Size = new System.Drawing.Size(522, 35);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(422, 0);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // dgvTimeslotToday
            // 
            this.dgvTimeslotToday.AllowUserToAddRows = false;
            this.dgvTimeslotToday.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTimeslotToday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeslotToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTimeslotToday.Location = new System.Drawing.Point(0, 0);
            this.dgvTimeslotToday.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvTimeslotToday.Name = "dgvTimeslotToday";
            this.dgvTimeslotToday.ReadOnly = true;
            this.dgvTimeslotToday.RowHeadersVisible = false;
            this.dgvTimeslotToday.RowHeadersWidth = 82;
            this.dgvTimeslotToday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimeslotToday.Size = new System.Drawing.Size(522, 228);
            this.dgvTimeslotToday.TabIndex = 0;
            this.dgvTimeslotToday.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTimeslotToday_CellFormatting);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTitle.Location = new System.Drawing.Point(30, 12);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(254, 36);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Lớp học hôm nay";
            // 
            // ucTimeslotToday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Name = "ucTimeslotToday";
            this.Size = new System.Drawing.Size(522, 317);
            this.Load += new System.EventHandler(this.ucTimeslotToday_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeslotToday)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimeslotToday;
        private System.Windows.Forms.Label lblTitle;
    }
}