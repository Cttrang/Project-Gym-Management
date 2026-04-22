namespace desktopapp_GYM
{
    partial class ucPackagePrice
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
            this.dgvTopPackages = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopPackages)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPin
            // 
            this.btnPin.Location = new System.Drawing.Point(1516, 6);
            this.btnPin.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.dgvTopPackages);
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panel2.Size = new System.Drawing.Size(522, 230);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panel1.Size = new System.Drawing.Size(522, 53);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelFooter.Location = new System.Drawing.Point(0, 283);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panelFooter.Size = new System.Drawing.Size(522, 34);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(422, 0);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnViewDetail.Size = new System.Drawing.Size(100, 34);
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // dgvTopPackages
            // 
            this.dgvTopPackages.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTopPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopPackages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopPackages.Location = new System.Drawing.Point(0, 0);
            this.dgvTopPackages.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvTopPackages.Name = "dgvTopPackages";
            this.dgvTopPackages.RowHeadersWidth = 51;
            this.dgvTopPackages.Size = new System.Drawing.Size(522, 230);
            this.dgvTopPackages.TabIndex = 0;
            this.dgvTopPackages.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTopPackages_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "GÓI TẬP LỰA CHỌN HÀNG ĐẦU";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ucPackagePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.Name = "ucPackagePrice";
            this.Size = new System.Drawing.Size(522, 317);
            this.Load += new System.EventHandler(this.ucPackagePrice_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopPackages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTopPackages;
        private System.Windows.Forms.Label label1;
    }
}
