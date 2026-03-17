namespace desktopapp_GYM
{
    partial class ucGymIntro
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
            this.lblGymIntro = new System.Windows.Forms.Label();
            this.lblIntro = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblIntro);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblGymIntro);
            this.panel1.Controls.SetChildIndex(this.btnPin, 0);
            this.panel1.Controls.SetChildIndex(this.lblGymIntro, 0);
            // 
            // lblGymIntro
            // 
            this.lblGymIntro.AutoSize = true;
            this.lblGymIntro.Location = new System.Drawing.Point(29, 5);
            this.lblGymIntro.Name = "lblGymIntro";
            this.lblGymIntro.Size = new System.Drawing.Size(104, 25);
            this.lblGymIntro.TabIndex = 2;
            this.lblGymIntro.Text = "Gym intro";
            // 
            // lblIntro
            // 
            this.lblIntro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIntro.AutoSize = true;
            this.lblIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.Location = new System.Drawing.Point(81, 37);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(39, 42);
            this.lblIntro.TabIndex = 1;
            this.lblIntro.Text = "0";
            // 
            // ucGymIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucGymIntro";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGymIntro;
        private System.Windows.Forms.Label lblIntro;
    }
}
