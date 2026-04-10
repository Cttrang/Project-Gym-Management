namespace desktopapp_GYM
{
    partial class ucTimeSlot
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
            this.lblClassName = new System.Windows.Forms.Label();
            this.lblTrainerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblClassName
            // 
            this.lblClassName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblClassName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.ForeColor = System.Drawing.Color.Black;
            this.lblClassName.Location = new System.Drawing.Point(5, 5);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(110, 40);
            this.lblClassName.TabIndex = 0;
            this.lblClassName.Text = "Tên Lớp Học";
            this.lblClassName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrainerName
            // 
            this.lblTrainerName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTrainerName.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainerName.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTrainerName.Location = new System.Drawing.Point(5, 55);
            this.lblTrainerName.Name = "lblTrainerName";
            this.lblTrainerName.Size = new System.Drawing.Size(110, 20);
            this.lblTrainerName.TabIndex = 1;
            this.lblTrainerName.Text = "HLV: Nguyễn Văn A";
            this.lblTrainerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucTimeSlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(this.lblTrainerName);
            this.Controls.Add(this.lblClassName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucTimeSlot";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(120, 80);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblClassName;
        public System.Windows.Forms.Label lblTrainerName;
    }
}
