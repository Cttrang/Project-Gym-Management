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
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopTrainers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPin
            // 
            this.btnPin.Location = new System.Drawing.Point(452, 3);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvTopTrainers);
            this.panel2.Size = new System.Drawing.Size(285, 148);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(285, 26);
            // 
            // panelFooter
            // 
            this.panelFooter.Location = new System.Drawing.Point(0, 174);
            this.panelFooter.Size = new System.Drawing.Size(285, 18);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(235, 0);
            // 
            // dgvTopTrainers
            // 
            this.dgvTopTrainers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopTrainers.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTopTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopTrainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopTrainers.Location = new System.Drawing.Point(0, 0);
            this.dgvTopTrainers.Name = "dgvTopTrainers";
            this.dgvTopTrainers.Size = new System.Drawing.Size(285, 148);
            this.dgvTopTrainers.TabIndex = 0;
            this.dgvTopTrainers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTopTrainers_CellFormatting);
            // 
            // ucTrainerStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucTrainerStatus";
            this.Size = new System.Drawing.Size(285, 192);
            this.Load += new System.EventHandler(this.ucTrainerStatus_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopTrainers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTopTrainers;
    }
}
