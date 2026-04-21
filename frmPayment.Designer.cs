namespace desktopapp_GYM
{
    partial class frmPayment
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpRegInfo = new System.Windows.Forms.GroupBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtOriginalPrice = new System.Windows.Forms.TextBox();
            this.lblOriginalPrice = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.txtRegDate = new System.Windows.Forms.TextBox();
            this.lblRegDate = new System.Windows.Forms.Label();
            this.txtPackageType = new System.Windows.Forms.TextBox();
            this.lblPackageType = new System.Windows.Forms.Label();
            this.txtMemberPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.lblQRStatus = new System.Windows.Forms.Label();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.cboPaymentStatus = new System.Windows.Forms.ComboBox();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpRegInfo.SuspendLayout();
            this.grpPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRegInfo
            // 
            this.grpRegInfo.Controls.Add(this.txtTotalAmount);
            this.grpRegInfo.Controls.Add(this.lblTotalAmount);
            this.grpRegInfo.Controls.Add(this.txtDiscount);
            this.grpRegInfo.Controls.Add(this.lblDiscount);
            this.grpRegInfo.Controls.Add(this.txtOriginalPrice);
            this.grpRegInfo.Controls.Add(this.lblOriginalPrice);
            this.grpRegInfo.Controls.Add(this.txtEndDate);
            this.grpRegInfo.Controls.Add(this.lblEndDate);
            this.grpRegInfo.Controls.Add(this.txtRegDate);
            this.grpRegInfo.Controls.Add(this.lblRegDate);
            this.grpRegInfo.Controls.Add(this.txtPackageType);
            this.grpRegInfo.Controls.Add(this.lblPackageType);
            this.grpRegInfo.Controls.Add(this.txtMemberPhone);
            this.grpRegInfo.Controls.Add(this.lblPhone);
            this.grpRegInfo.Controls.Add(this.txtMemberName);
            this.grpRegInfo.Controls.Add(this.lblMemberName);
            this.grpRegInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRegInfo.Location = new System.Drawing.Point(21, 22);
            this.grpRegInfo.Name = "grpRegInfo";
            this.grpRegInfo.Size = new System.Drawing.Size(350, 390);
            this.grpRegInfo.TabIndex = 0;
            this.grpRegInfo.TabStop = false;
            this.grpRegInfo.Text = "Thông tin đăng ký";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.ForeColor = System.Drawing.Color.Red;
            this.txtTotalAmount.Location = new System.Drawing.Point(130, 315);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(199, 29);
            this.txtTotalAmount.TabIndex = 15;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 318);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(92, 23);
            this.lblTotalAmount.TabIndex = 14;
            this.lblTotalAmount.Text = "Tổng tiền:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(130, 275);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(199, 29);
            this.txtDiscount.TabIndex = 13;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(20, 278);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(82, 23);
            this.lblDiscount.TabIndex = 12;
            this.lblDiscount.Text = "Giảm giá:";
            // 
            // txtOriginalPrice
            // 
            this.txtOriginalPrice.Location = new System.Drawing.Point(130, 235);
            this.txtOriginalPrice.Name = "txtOriginalPrice";
            this.txtOriginalPrice.ReadOnly = true;
            this.txtOriginalPrice.Size = new System.Drawing.Size(199, 29);
            this.txtOriginalPrice.TabIndex = 11;
            // 
            // lblOriginalPrice
            // 
            this.lblOriginalPrice.AutoSize = true;
            this.lblOriginalPrice.Location = new System.Drawing.Point(20, 238);
            this.lblOriginalPrice.Name = "lblOriginalPrice";
            this.lblOriginalPrice.Size = new System.Drawing.Size(72, 23);
            this.lblOriginalPrice.TabIndex = 10;
            this.lblOriginalPrice.Text = "Giá gốc:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(130, 195);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.Size = new System.Drawing.Size(199, 29);
            this.txtEndDate.TabIndex = 9;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(20, 198);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(118, 23);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "Ngày hết hạn:";
            // 
            // txtRegDate
            // 
            this.txtRegDate.Location = new System.Drawing.Point(130, 155);
            this.txtRegDate.Name = "txtRegDate";
            this.txtRegDate.ReadOnly = true;
            this.txtRegDate.Size = new System.Drawing.Size(199, 29);
            this.txtRegDate.TabIndex = 7;
            // 
            // lblRegDate
            // 
            this.lblRegDate.AutoSize = true;
            this.lblRegDate.Location = new System.Drawing.Point(20, 158);
            this.lblRegDate.Name = "lblRegDate";
            this.lblRegDate.Size = new System.Drawing.Size(119, 23);
            this.lblRegDate.TabIndex = 6;
            this.lblRegDate.Text = "Ngày đăng ký:";
            // 
            // txtPackageType
            // 
            this.txtPackageType.Location = new System.Drawing.Point(130, 115);
            this.txtPackageType.Name = "txtPackageType";
            this.txtPackageType.ReadOnly = true;
            this.txtPackageType.Size = new System.Drawing.Size(199, 29);
            this.txtPackageType.TabIndex = 5;
            // 
            // lblPackageType
            // 
            this.lblPackageType.AutoSize = true;
            this.lblPackageType.Location = new System.Drawing.Point(20, 118);
            this.lblPackageType.Name = "lblPackageType";
            this.lblPackageType.Size = new System.Drawing.Size(74, 23);
            this.lblPackageType.TabIndex = 4;
            this.lblPackageType.Text = "Loại gói:";
            // 
            // txtMemberPhone
            // 
            this.txtMemberPhone.Location = new System.Drawing.Point(130, 75);
            this.txtMemberPhone.Name = "txtMemberPhone";
            this.txtMemberPhone.ReadOnly = true;
            this.txtMemberPhone.Size = new System.Drawing.Size(199, 29);
            this.txtMemberPhone.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 78);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(115, 23);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(130, 35);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.ReadOnly = true;
            this.txtMemberName.Size = new System.Drawing.Size(199, 29);
            this.txtMemberName.TabIndex = 1;
            // 
            // lblMemberName
            // 
            this.lblMemberName.AutoSize = true;
            this.lblMemberName.Location = new System.Drawing.Point(20, 38);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(95, 23);
            this.lblMemberName.TabIndex = 0;
            this.lblMemberName.Text = "Họ Tên HV:";
            // 
            // grpPayment
            // 
            this.grpPayment.Controls.Add(this.lblQRStatus);
            this.grpPayment.Controls.Add(this.picQRCode);
            this.grpPayment.Controls.Add(this.cboPaymentStatus);
            this.grpPayment.Controls.Add(this.lblPaymentStatus);
            this.grpPayment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPayment.Location = new System.Drawing.Point(389, 22);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(312, 320);
            this.grpPayment.TabIndex = 1;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "Thanh toán";
            // 
            // lblQRStatus
            // 
            this.lblQRStatus.AutoSize = true;
            this.lblQRStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblQRStatus.Location = new System.Drawing.Point(83, 283);
            this.lblQRStatus.Name = "lblQRStatus";
            this.lblQRStatus.Size = new System.Drawing.Size(150, 23);
            this.lblQRStatus.TabIndex = 3;
            this.lblQRStatus.Text = "Đang tạo mã QR...";
            this.lblQRStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picQRCode
            // 
            this.picQRCode.BackColor = System.Drawing.Color.White;
            this.picQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQRCode.Location = new System.Drawing.Point(40, 80);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(242, 200);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQRCode.TabIndex = 2;
            this.picQRCode.TabStop = false;
            // 
            // cboPaymentStatus
            // 
            this.cboPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentStatus.FormattingEnabled = true;
            this.cboPaymentStatus.Location = new System.Drawing.Point(112, 32);
            this.cboPaymentStatus.Name = "cboPaymentStatus";
            this.cboPaymentStatus.Size = new System.Drawing.Size(170, 29);
            this.cboPaymentStatus.TabIndex = 1;
            this.cboPaymentStatus.SelectedIndexChanged += new System.EventHandler(this.cboPaymentStatus_SelectedIndexChanged);
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Location = new System.Drawing.Point(15, 38);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(91, 23);
            this.lblPaymentStatus.TabIndex = 0;
            this.lblPaymentStatus.Text = "Trạng thái:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(389, 362);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(130, 40);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "LƯU";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(571, 362);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "HỦY / ĐÓNG";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 448);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.grpPayment);
            this.Controls.Add(this.grpRegInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán dịch vụ Gym";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.grpRegInfo.ResumeLayout(false);
            this.grpRegInfo.PerformLayout();
            this.grpPayment.ResumeLayout(false);
            this.grpPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRegInfo;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtOriginalPrice;
        private System.Windows.Forms.Label lblOriginalPrice;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.TextBox txtRegDate;
        private System.Windows.Forms.Label lblRegDate;
        private System.Windows.Forms.TextBox txtPackageType;
        private System.Windows.Forms.Label lblPackageType;
        private System.Windows.Forms.TextBox txtMemberPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.GroupBox grpPayment;
        private System.Windows.Forms.Label lblQRStatus;
        private System.Windows.Forms.PictureBox picQRCode;
        private System.Windows.Forms.ComboBox cboPaymentStatus;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}