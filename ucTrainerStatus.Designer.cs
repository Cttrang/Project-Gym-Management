namespace desktopapp_GYM
{
    partial class ucTrainerStatus
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
            this.dgvTopTrainers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopTrainers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPin
            // 
            this.btnPin.Location = new System.Drawing.Point(2554, 6);
            this.btnPin.Margin = new System.Windows.Forms.Padding(8);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvTopTrainers);
            this.panel2.Margin = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(570, 284);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Margin = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(570, 50);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            // 
            // panelFooter
            // 
            this.panelFooter.Location = new System.Drawing.Point(0, 334);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(8);
            this.panelFooter.Size = new System.Drawing.Size(570, 35);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(470, 0);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(8);
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // dgvTopTrainers
            // 
            this.dgvTopTrainers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopTrainers.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTopTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopTrainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopTrainers.Location = new System.Drawing.Point(0, 0);
            this.dgvTopTrainers.Margin = new System.Windows.Forms.Padding(6);
            this.dgvTopTrainers.Name = "dgvTopTrainers";
            this.dgvTopTrainers.RowHeadersWidth = 82;
            this.dgvTopTrainers.Size = new System.Drawing.Size(570, 284);
            this.dgvTopTrainers.TabIndex = 0;
            this.dgvTopTrainers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTopTrainers_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(15, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(639, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "HUẤN LUYỆN VIÊN LỰA CHỌN HÀNG ĐẦU";
            // 
            // ucTrainerStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "ucTrainerStatus";
            this.Size = new System.Drawing.Size(570, 369);
            this.Load += new System.EventHandler(this.ucTrainerStatus_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopTrainers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTopTrainers;
        private System.Windows.Forms.Label label1;
    }
}
