namespace desktopapp_GYM
{
    partial class frmRegistration
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cboOldMember = new System.Windows.Forms.ComboBox();
            this.rdoOldMember = new System.Windows.Forms.RadioButton();
            this.rdoNewMember = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPersonal = new System.Windows.Forms.GroupBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDate_New = new System.Windows.Forms.DateTimePicker();
            this.dtpRegDate_New = new System.Windows.Forms.DateTimePicker();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rdoPT = new System.Windows.Forms.RadioButton();
            this.rdoClass = new System.Windows.Forms.RadioButton();
            this.rdoFree = new System.Windows.Forms.RadioButton();
            this.grpPackage = new System.Windows.Forms.GroupBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtOriginalPrice = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtPTFee = new System.Windows.Forms.TextBox();
            this.txtSessionsTotal = new System.Windows.Forms.TextBox();
            this.txtSessionsPerWeek = new System.Windows.Forms.TextBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cboPackage = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grpSlot = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.lstSlots = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboTime = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboDayOfWeek = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cboTrainer = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.cboPayment = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.grpOption.SuspendLayout();
            this.grpPersonal.SuspendLayout();
            this.grpType.SuspendLayout();
            this.grpPackage.SuspendLayout();
            this.grpSlot.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cboOldMember);
            this.grpOption.Controls.Add(this.rdoOldMember);
            this.grpOption.Controls.Add(this.rdoNewMember);
            this.grpOption.Location = new System.Drawing.Point(23, 66);
            this.grpOption.Margin = new System.Windows.Forms.Padding(4);
            this.grpOption.Name = "grpOption";
            this.grpOption.Padding = new System.Windows.Forms.Padding(4);
            this.grpOption.Size = new System.Drawing.Size(321, 106);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "Option";
            // 
            // cboOldMember
            // 
            this.cboOldMember.FormattingEnabled = true;
            this.cboOldMember.Location = new System.Drawing.Point(123, 64);
            this.cboOldMember.Name = "cboOldMember";
            this.cboOldMember.Size = new System.Drawing.Size(184, 44);
            this.cboOldMember.TabIndex = 8;
            this.cboOldMember.SelectedIndexChanged += new System.EventHandler(this.cboOldMember_SelectedIndexChanged);
            // 
            // rdoOldMember
            // 
            this.rdoOldMember.AutoSize = true;
            this.rdoOldMember.Location = new System.Drawing.Point(12, 65);
            this.rdoOldMember.Name = "rdoOldMember";
            this.rdoOldMember.Size = new System.Drawing.Size(189, 40);
            this.rdoOldMember.TabIndex = 1;
            this.rdoOldMember.TabStop = true;
            this.rdoOldMember.Text = "Member cũ";
            this.rdoOldMember.UseVisualStyleBackColor = true;
            this.rdoOldMember.CheckedChanged += new System.EventHandler(this.rdoOldMember_CheckedChanged);
            // 
            // rdoNewMember
            // 
            this.rdoNewMember.AutoSize = true;
            this.rdoNewMember.Location = new System.Drawing.Point(12, 26);
            this.rdoNewMember.Name = "rdoNewMember";
            this.rdoNewMember.Size = new System.Drawing.Size(209, 40);
            this.rdoNewMember.TabIndex = 0;
            this.rdoNewMember.TabStop = true;
            this.rdoNewMember.Text = "Member mới";
            this.rdoNewMember.UseVisualStyleBackColor = true;
            this.rdoNewMember.CheckedChanged += new System.EventHandler(this.rdoNewMember_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đăng kí Member";
            // 
            // grpPersonal
            // 
            this.grpPersonal.Controls.Add(this.cboStatus);
            this.grpPersonal.Controls.Add(this.txtPhone);
            this.grpPersonal.Controls.Add(this.txtFullName);
            this.grpPersonal.Controls.Add(this.label5);
            this.grpPersonal.Controls.Add(this.label4);
            this.grpPersonal.Controls.Add(this.label3);
            this.grpPersonal.Controls.Add(this.label2);
            this.grpPersonal.Controls.Add(this.dtpStartDate_New);
            this.grpPersonal.Location = new System.Drawing.Point(23, 185);
            this.grpPersonal.Name = "grpPersonal";
            this.grpPersonal.Size = new System.Drawing.Size(321, 200);
            this.grpPersonal.TabIndex = 2;
            this.grpPersonal.TabStop = false;
            this.grpPersonal.Text = "Thông tin cá nhân";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(123, 151);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(121, 44);
            this.cboStatus.TabIndex = 7;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(123, 66);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(184, 44);
            this.txtPhone.TabIndex = 5;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(123, 27);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(184, 44);
            this.txtFullName.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 36);
            this.label5.TabIndex = 3;
            this.label5.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 36);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày đăng kí";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "SĐT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ tên";
            // 
            // dtpStartDate_New
            // 
            this.dtpStartDate_New.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate_New.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate_New.Location = new System.Drawing.Point(123, 104);
            this.dtpStartDate_New.Name = "dtpStartDate_New";
            this.dtpStartDate_New.Size = new System.Drawing.Size(184, 44);
            this.dtpStartDate_New.TabIndex = 15;
            // 
            // dtpRegDate_New
            // 
            this.dtpRegDate_New.CustomFormat = "dd/MM/yyyy";
            this.dtpRegDate_New.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRegDate_New.Location = new System.Drawing.Point(162, 58);
            this.dtpRegDate_New.Name = "dtpRegDate_New";
            this.dtpRegDate_New.Size = new System.Drawing.Size(134, 44);
            this.dtpRegDate_New.TabIndex = 6;
            this.dtpRegDate_New.ValueChanged += new System.EventHandler(this.dtpRegDate_New_ValueChanged);
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.label8);
            this.grpType.Controls.Add(this.label7);
            this.grpType.Controls.Add(this.label6);
            this.grpType.Controls.Add(this.rdoPT);
            this.grpType.Controls.Add(this.rdoClass);
            this.grpType.Controls.Add(this.rdoFree);
            this.grpType.Location = new System.Drawing.Point(367, 66);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(313, 140);
            this.grpType.TabIndex = 3;
            this.grpType.TabStop = false;
            this.grpType.Text = "Loại hình gói muốn đăng kí:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 36);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tập có PT riêng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 36);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tập theo lớp";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 36);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tập tự do";
            // 
            // rdoPT
            // 
            this.rdoPT.AutoSize = true;
            this.rdoPT.Location = new System.Drawing.Point(24, 101);
            this.rdoPT.Name = "rdoPT";
            this.rdoPT.Size = new System.Drawing.Size(83, 40);
            this.rdoPT.TabIndex = 3;
            this.rdoPT.TabStop = true;
            this.rdoPT.Text = "PT";
            this.rdoPT.UseVisualStyleBackColor = true;
            this.rdoPT.CheckedChanged += new System.EventHandler(this.rdoPT_CheckedChanged);
            // 
            // rdoClass
            // 
            this.rdoClass.AutoSize = true;
            this.rdoClass.Location = new System.Drawing.Point(24, 62);
            this.rdoClass.Name = "rdoClass";
            this.rdoClass.Size = new System.Drawing.Size(144, 40);
            this.rdoClass.TabIndex = 2;
            this.rdoClass.TabStop = true;
            this.rdoClass.Text = "CLASS";
            this.rdoClass.UseVisualStyleBackColor = true;
            this.rdoClass.CheckedChanged += new System.EventHandler(this.rdoClass_CheckedChanged);
            // 
            // rdoFree
            // 
            this.rdoFree.AutoSize = true;
            this.rdoFree.Location = new System.Drawing.Point(24, 26);
            this.rdoFree.Name = "rdoFree";
            this.rdoFree.Size = new System.Drawing.Size(103, 40);
            this.rdoFree.TabIndex = 1;
            this.rdoFree.TabStop = true;
            this.rdoFree.Text = "Free";
            this.rdoFree.UseVisualStyleBackColor = true;
            this.rdoFree.CheckedChanged += new System.EventHandler(this.rdoFree_CheckedChanged);
            // 
            // grpPackage
            // 
            this.grpPackage.Controls.Add(this.chkIsActive);
            this.grpPackage.Controls.Add(this.dtpRegDate_New);
            this.grpPackage.Controls.Add(this.label23);
            this.grpPackage.Controls.Add(this.txtOriginalPrice);
            this.grpPackage.Controls.Add(this.label22);
            this.grpPackage.Controls.Add(this.txtTotalAmount);
            this.grpPackage.Controls.Add(this.label19);
            this.grpPackage.Controls.Add(this.txtDiscount);
            this.grpPackage.Controls.Add(this.txtPTFee);
            this.grpPackage.Controls.Add(this.txtSessionsTotal);
            this.grpPackage.Controls.Add(this.txtSessionsPerWeek);
            this.grpPackage.Controls.Add(this.dtpEndDate);
            this.grpPackage.Controls.Add(this.cboPackage);
            this.grpPackage.Controls.Add(this.label16);
            this.grpPackage.Controls.Add(this.label15);
            this.grpPackage.Controls.Add(this.label14);
            this.grpPackage.Controls.Add(this.label13);
            this.grpPackage.Controls.Add(this.label12);
            this.grpPackage.Controls.Add(this.label10);
            this.grpPackage.Controls.Add(this.label9);
            this.grpPackage.Location = new System.Drawing.Point(367, 215);
            this.grpPackage.Name = "grpPackage";
            this.grpPackage.Size = new System.Drawing.Size(313, 392);
            this.grpPackage.TabIndex = 4;
            this.grpPackage.TabStop = false;
            this.grpPackage.Text = "Thông tin gói";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(162, 350);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(140, 40);
            this.chkIsActive.TabIndex = 26;
            this.chkIsActive.Text = "Yes/No";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(24, 351);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(228, 36);
            this.label23.TabIndex = 25;
            this.label23.Text = "Gói đang active?";
            // 
            // txtOriginalPrice
            // 
            this.txtOriginalPrice.Location = new System.Drawing.Point(162, 193);
            this.txtOriginalPrice.Name = "txtOriginalPrice";
            this.txtOriginalPrice.ReadOnly = true;
            this.txtOriginalPrice.Size = new System.Drawing.Size(134, 44);
            this.txtOriginalPrice.TabIndex = 24;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(24, 196);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(118, 36);
            this.label22.TabIndex = 23;
            this.label22.Text = "Giá gói:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(162, 310);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(134, 44);
            this.txtTotalAmount.TabIndex = 22;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 313);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(135, 36);
            this.label19.TabIndex = 21;
            this.label19.Text = "Tổng tiền";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(162, 272);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(134, 44);
            this.txtDiscount.TabIndex = 20;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // txtPTFee
            // 
            this.txtPTFee.Location = new System.Drawing.Point(162, 233);
            this.txtPTFee.Name = "txtPTFee";
            this.txtPTFee.Size = new System.Drawing.Size(134, 44);
            this.txtPTFee.TabIndex = 19;
            this.txtPTFee.TextChanged += new System.EventHandler(this.txtPTFee_TextChanged);
            // 
            // txtSessionsTotal
            // 
            this.txtSessionsTotal.Location = new System.Drawing.Point(162, 158);
            this.txtSessionsTotal.Name = "txtSessionsTotal";
            this.txtSessionsTotal.ReadOnly = true;
            this.txtSessionsTotal.Size = new System.Drawing.Size(134, 44);
            this.txtSessionsTotal.TabIndex = 18;
            // 
            // txtSessionsPerWeek
            // 
            this.txtSessionsPerWeek.Location = new System.Drawing.Point(162, 122);
            this.txtSessionsPerWeek.Name = "txtSessionsPerWeek";
            this.txtSessionsPerWeek.ReadOnly = true;
            this.txtSessionsPerWeek.Size = new System.Drawing.Size(134, 44);
            this.txtSessionsPerWeek.TabIndex = 17;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(162, 90);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(134, 44);
            this.dtpEndDate.TabIndex = 16;
            // 
            // cboPackage
            // 
            this.cboPackage.FormattingEnabled = true;
            this.cboPackage.Location = new System.Drawing.Point(162, 25);
            this.cboPackage.Name = "cboPackage";
            this.cboPackage.Size = new System.Drawing.Size(134, 44);
            this.cboPackage.TabIndex = 14;
            this.cboPackage.SelectedIndexChanged += new System.EventHandler(this.cboPackage_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(188, 36);
            this.label16.TabIndex = 12;
            this.label16.Text = "Tổng số buổi:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 275);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(251, 36);
            this.label15.TabIndex = 11;
            this.label15.Text = "Giảm giá (nếu có):";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 236);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 36);
            this.label14.TabIndex = 10;
            this.label14.Text = "Phí PT:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(257, 36);
            this.label13.TabIndex = 9;
            this.label13.Text = "Số buổi trong tuần:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(247, 36);
            this.label12.TabIndex = 8;
            this.label12.Text = "Ngày kết thúc gói:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(239, 36);
            this.label10.TabIndex = 6;
            this.label10.Text = "Ngày bắt đầu gói:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 36);
            this.label9.TabIndex = 5;
            this.label9.Text = "Gói";
            // 
            // grpSlot
            // 
            this.grpSlot.Controls.Add(this.label24);
            this.grpSlot.Controls.Add(this.lstSlots);
            this.grpSlot.Controls.Add(this.btnClear);
            this.grpSlot.Controls.Add(this.btnDelete);
            this.grpSlot.Controls.Add(this.btnAdd);
            this.grpSlot.Controls.Add(this.cboTime);
            this.grpSlot.Controls.Add(this.label18);
            this.grpSlot.Controls.Add(this.cboDayOfWeek);
            this.grpSlot.Controls.Add(this.label17);
            this.grpSlot.Controls.Add(this.cboTrainer);
            this.grpSlot.Controls.Add(this.label11);
            this.grpSlot.Location = new System.Drawing.Point(23, 391);
            this.grpSlot.Name = "grpSlot";
            this.grpSlot.Size = new System.Drawing.Size(321, 401);
            this.grpSlot.TabIndex = 5;
            this.grpSlot.TabStop = false;
            this.grpSlot.Text = "Chọn thời khóa biểu";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(26, 181);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(215, 36);
            this.label24.TabIndex = 21;
            this.label24.Text = "Buổi đã đăng kí";
            // 
            // lstSlots
            // 
            this.lstSlots.FormattingEnabled = true;
            this.lstSlots.ItemHeight = 36;
            this.lstSlots.Location = new System.Drawing.Point(28, 203);
            this.lstSlots.Name = "lstSlots";
            this.lstSlots.Size = new System.Drawing.Size(251, 112);
            this.lstSlots.TabIndex = 20;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(52, 352);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 36);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(179, 352);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 36);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(193, 165);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 32);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboTime
            // 
            this.cboTime.FormattingEnabled = true;
            this.cboTime.Location = new System.Drawing.Point(134, 117);
            this.cboTime.Name = "cboTime";
            this.cboTime.Size = new System.Drawing.Size(145, 44);
            this.cboTime.TabIndex = 13;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 120);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 36);
            this.label18.TabIndex = 12;
            this.label18.Text = "Thời gian";
            // 
            // cboDayOfWeek
            // 
            this.cboDayOfWeek.FormattingEnabled = true;
            this.cboDayOfWeek.Location = new System.Drawing.Point(134, 75);
            this.cboDayOfWeek.Name = "cboDayOfWeek";
            this.cboDayOfWeek.Size = new System.Drawing.Size(145, 44);
            this.cboDayOfWeek.TabIndex = 11;
            this.cboDayOfWeek.SelectedIndexChanged += new System.EventHandler(this.cboDayOfWeek_SelectedIndexChanged_1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 78);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(217, 36);
            this.label17.TabIndex = 10;
            this.label17.Text = "Ngày trong tuần";
            // 
            // cboTrainer
            // 
            this.cboTrainer.FormattingEnabled = true;
            this.cboTrainer.Location = new System.Drawing.Point(102, 34);
            this.cboTrainer.Name = "cboTrainer";
            this.cboTrainer.Size = new System.Drawing.Size(177, 44);
            this.cboTrainer.TabIndex = 9;
            this.cboTrainer.SelectedIndexChanged += new System.EventHandler(this.cboTrainer_SelectedIndexChanged_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 36);
            this.label11.TabIndex = 8;
            this.label11.Text = "Trainer";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(517, 694);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(86, 35);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "Reset All";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(368, 632);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(200, 36);
            this.label20.TabIndex = 22;
            this.label20.Text = "Payment status";
            // 
            // cboPayment
            // 
            this.cboPayment.FormattingEnabled = true;
            this.cboPayment.Location = new System.Drawing.Point(489, 629);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(174, 44);
            this.cboPayment.TabIndex = 23;
            this.cboPayment.SelectedIndexChanged += new System.EventHandler(this.cboPayment_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(419, 757);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 35);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(571, 757);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(92, 35);
            this.btnOut.TabIndex = 25;
            this.btnOut.Text = "Exit";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(387, 665);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 36);
            this.label21.TabIndex = 26;
            this.label21.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(489, 662);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(174, 44);
            this.txtNotes.TabIndex = 27;
            // 
            // frmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 804);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboPayment);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.grpSlot);
            this.Controls.Add(this.grpPackage);
            this.Controls.Add(this.grpType);
            this.Controls.Add(this.grpPersonal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpOption);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegistration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistration_FormClosing);
            this.Load += new System.EventHandler(this.frmRegistration_Load);
            this.Shown += new System.EventHandler(this.frmRegistration_Shown);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.grpPersonal.ResumeLayout(false);
            this.grpPersonal.PerformLayout();
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            this.grpPackage.ResumeLayout(false);
            this.grpPackage.PerformLayout();
            this.grpSlot.ResumeLayout(false);
            this.grpSlot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.RadioButton rdoOldMember;
        private System.Windows.Forms.RadioButton rdoNewMember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpPersonal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpRegDate_New;
        private System.Windows.Forms.ComboBox cboOldMember;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.GroupBox grpType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdoPT;
        private System.Windows.Forms.RadioButton rdoClass;
        private System.Windows.Forms.RadioButton rdoFree;
        private System.Windows.Forms.GroupBox grpPackage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grpSlot;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboTime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboDayOfWeek;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboTrainer;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtPTFee;
        private System.Windows.Forms.TextBox txtSessionsTotal;
        private System.Windows.Forms.TextBox txtSessionsPerWeek;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate_New;
        private System.Windows.Forms.ComboBox cboPackage;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboPayment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtOriginalPrice;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ListBox lstSlots;
        private System.Windows.Forms.Label label24;
    }
}