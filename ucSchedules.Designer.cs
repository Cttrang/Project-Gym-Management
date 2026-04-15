namespace desktopapp_GYM
{
    partial class ucSchedules
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblTrainer = new System.Windows.Forms.Label();
            this.cboTrainer = new System.Windows.Forms.ComboBox();
            this.lblSlot = new System.Windows.Forms.Label();
            this.cboSlot = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblMember = new System.Windows.Forms.Label();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblMemberNameLbl = new System.Windows.Forms.Label();
            this.lblMemberNameVal = new System.Windows.Forms.Label();
            this.lblClassLbl = new System.Windows.Forms.Label();
            this.lblClassVal = new System.Windows.Forms.Label();
            this.lblDateLbl = new System.Windows.Forms.Label();
            this.lblDateVal = new System.Windows.Forms.Label();
            this.lblTimeLbl = new System.Windows.Forms.Label();
            this.lblTimeVal = new System.Windows.Forms.Label();
            this.lblStatusLbl = new System.Windows.Forms.Label();
            this.lblStatusVal = new System.Windows.Forms.Label();
            this.lblMakeupLbl = new System.Windows.Forms.Label();
            this.lblMakeupVal = new System.Windows.Forms.Label();
            this.lblStatTotal = new System.Windows.Forms.Label();
            this.lblStatAttended = new System.Windows.Forms.Label();
            this.lblStatAbsent = new System.Windows.Forms.Label();
            this.btnAddMakeup = new System.Windows.Forms.Button();
            this.btnAttended = new System.Windows.Forms.Button();
            this.btnAbsent = new System.Windows.Forms.Button();
            this.btnPostpone = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1000, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Quản lý lịch tập";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 40);
            this.pnlHeader.TabIndex = 3;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlFilter);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.dgvSchedules);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 40);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1000, 560);
            this.pnlMain.TabIndex = 4;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.SystemColors.Window;
            this.pnlFilter.Controls.Add(this.button1);
            this.pnlFilter.Controls.Add(this.lblTrainer);
            this.pnlFilter.Controls.Add(this.cboTrainer);
            this.pnlFilter.Controls.Add(this.lblSlot);
            this.pnlFilter.Controls.Add(this.cboSlot);
            this.pnlFilter.Controls.Add(this.lblStatus);
            this.pnlFilter.Controls.Add(this.cboStatus);
            this.pnlFilter.Controls.Add(this.lblFromDate);
            this.pnlFilter.Controls.Add(this.dtpFromDate);
            this.pnlFilter.Controls.Add(this.lblMember);
            this.pnlFilter.Controls.Add(this.txtMember);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.btnClearFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlFilter.Size = new System.Drawing.Size(790, 80);
            this.pnlFilter.TabIndex = 3;
            // 
            // lblTrainer
            // 
            this.lblTrainer.AutoSize = true;
            this.lblTrainer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainer.Location = new System.Drawing.Point(32, 12);
            this.lblTrainer.Name = "lblTrainer";
            this.lblTrainer.Size = new System.Drawing.Size(54, 19);
            this.lblTrainer.TabIndex = 0;
            this.lblTrainer.Text = "Trainer:";
            // 
            // cboTrainer
            // 
            this.cboTrainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrainer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTrainer.Location = new System.Drawing.Point(91, 9);
            this.cboTrainer.Name = "cboTrainer";
            this.cboTrainer.Size = new System.Drawing.Size(150, 27);
            this.cboTrainer.TabIndex = 1;
            // 
            // lblSlot
            // 
            this.lblSlot.AutoSize = true;
            this.lblSlot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlot.Location = new System.Drawing.Point(13, 46);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Size = new System.Drawing.Size(73, 19);
            this.lblSlot.TabIndex = 2;
            this.lblSlot.Text = "Lớp / Slot:";
            // 
            // cboSlot
            // 
            this.cboSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSlot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSlot.Location = new System.Drawing.Point(91, 44);
            this.cboSlot.Name = "cboSlot";
            this.cboSlot.Size = new System.Drawing.Size(150, 27);
            this.cboSlot.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(263, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 19);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Trạng thái:";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.Items.AddRange(new object[] {
            "Tất cả",
            "Scheduled",
            "Attended",
            "Absent",
            "Makeup",
            "Postponed"});
            this.cboStatus.Location = new System.Drawing.Point(340, 9);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(108, 27);
            this.cboStatus.TabIndex = 5;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(289, 46);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(45, 19);
            this.lblFromDate.TabIndex = 6;
            this.lblFromDate.Text = "Ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(340, 41);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(108, 26);
            this.dtpFromDate.TabIndex = 7;
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMember.Location = new System.Drawing.Point(566, 12);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(64, 19);
            this.lblMember.TabIndex = 10;
            this.lblMember.Text = "Member:";
            // 
            // txtMember
            // 
            this.txtMember.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMember.Location = new System.Drawing.Point(627, 9);
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(150, 26);
            this.txtMember.TabIndex = 11;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(239)))), ((int)(((byte)(172)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.btnFilter.Location = new System.Drawing.Point(627, 40);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(65, 26);
            this.btnFilter.TabIndex = 12;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilter.Location = new System.Drawing.Point(699, 40);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(70, 26);
            this.btnClearFilter.TabIndex = 13;
            this.btnClearFilter.Text = "Xoá lọc";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.SystemColors.Window;
            this.pnlRight.Controls.Add(this.label3);
            this.pnlRight.Controls.Add(this.label2);
            this.pnlRight.Controls.Add(this.label1);
            this.pnlRight.Controls.Add(this.grpDetail);
            this.pnlRight.Controls.Add(this.lblStatTotal);
            this.pnlRight.Controls.Add(this.lblStatAttended);
            this.pnlRight.Controls.Add(this.lblStatAbsent);
            this.pnlRight.Controls.Add(this.btnAddMakeup);
            this.pnlRight.Controls.Add(this.btnAttended);
            this.pnlRight.Controls.Add(this.btnAbsent);
            this.pnlRight.Controls.Add(this.btnPostpone);
            this.pnlRight.Controls.Add(this.btnExport);
            this.pnlRight.Controls.Add(this.btnBack);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRight.Location = new System.Drawing.Point(790, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRight.Size = new System.Drawing.Size(210, 560);
            this.pnlRight.TabIndex = 2;
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.lblMemberNameLbl);
            this.grpDetail.Controls.Add(this.lblMemberNameVal);
            this.grpDetail.Controls.Add(this.lblClassLbl);
            this.grpDetail.Controls.Add(this.lblClassVal);
            this.grpDetail.Controls.Add(this.lblDateLbl);
            this.grpDetail.Controls.Add(this.lblDateVal);
            this.grpDetail.Controls.Add(this.lblTimeLbl);
            this.grpDetail.Controls.Add(this.lblTimeVal);
            this.grpDetail.Controls.Add(this.lblStatusLbl);
            this.grpDetail.Controls.Add(this.lblStatusVal);
            this.grpDetail.Controls.Add(this.lblMakeupLbl);
            this.grpDetail.Controls.Add(this.lblMakeupVal);
            this.grpDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetail.Location = new System.Drawing.Point(10, 10);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(188, 194);
            this.grpDetail.TabIndex = 0;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Chi tiết buổi tập";
            // 
            // lblMemberNameLbl
            // 
            this.lblMemberNameLbl.AutoSize = true;
            this.lblMemberNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberNameLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblMemberNameLbl.Location = new System.Drawing.Point(19, 23);
            this.lblMemberNameLbl.Name = "lblMemberNameLbl";
            this.lblMemberNameLbl.Size = new System.Drawing.Size(67, 20);
            this.lblMemberNameLbl.TabIndex = 0;
            this.lblMemberNameLbl.Text = "Member";
            // 
            // lblMemberNameVal
            // 
            this.lblMemberNameVal.AutoSize = true;
            this.lblMemberNameVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberNameVal.Location = new System.Drawing.Point(19, 42);
            this.lblMemberNameVal.Name = "lblMemberNameVal";
            this.lblMemberNameVal.Size = new System.Drawing.Size(23, 20);
            this.lblMemberNameVal.TabIndex = 1;
            this.lblMemberNameVal.Text = "—";
            // 
            // lblClassLbl
            // 
            this.lblClassLbl.AutoSize = true;
            this.lblClassLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblClassLbl.Location = new System.Drawing.Point(19, 73);
            this.lblClassLbl.Name = "lblClassLbl";
            this.lblClassLbl.Size = new System.Drawing.Size(36, 20);
            this.lblClassLbl.TabIndex = 2;
            this.lblClassLbl.Text = "Lớp";
            // 
            // lblClassVal
            // 
            this.lblClassVal.AutoSize = true;
            this.lblClassVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassVal.Location = new System.Drawing.Point(19, 93);
            this.lblClassVal.Name = "lblClassVal";
            this.lblClassVal.Size = new System.Drawing.Size(23, 20);
            this.lblClassVal.TabIndex = 3;
            this.lblClassVal.Text = "—";
            // 
            // lblDateLbl
            // 
            this.lblDateLbl.AutoSize = true;
            this.lblDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblDateLbl.Location = new System.Drawing.Point(100, 73);
            this.lblDateLbl.Name = "lblDateLbl";
            this.lblDateLbl.Size = new System.Drawing.Size(72, 20);
            this.lblDateLbl.TabIndex = 4;
            this.lblDateLbl.Text = "Ngày tập";
            // 
            // lblDateVal
            // 
            this.lblDateVal.AutoSize = true;
            this.lblDateVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateVal.Location = new System.Drawing.Point(100, 93);
            this.lblDateVal.Name = "lblDateVal";
            this.lblDateVal.Size = new System.Drawing.Size(23, 20);
            this.lblDateVal.TabIndex = 5;
            this.lblDateVal.Text = "—";
            // 
            // lblTimeLbl
            // 
            this.lblTimeLbl.AutoSize = true;
            this.lblTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTimeLbl.Location = new System.Drawing.Point(19, 113);
            this.lblTimeLbl.Name = "lblTimeLbl";
            this.lblTimeLbl.Size = new System.Drawing.Size(34, 20);
            this.lblTimeLbl.TabIndex = 6;
            this.lblTimeLbl.Text = "Giờ";
            // 
            // lblTimeVal
            // 
            this.lblTimeVal.AutoSize = true;
            this.lblTimeVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeVal.Location = new System.Drawing.Point(21, 133);
            this.lblTimeVal.Name = "lblTimeVal";
            this.lblTimeVal.Size = new System.Drawing.Size(23, 20);
            this.lblTimeVal.TabIndex = 7;
            this.lblTimeVal.Text = "—";
            // 
            // lblStatusLbl
            // 
            this.lblStatusLbl.AutoSize = true;
            this.lblStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStatusLbl.Location = new System.Drawing.Point(100, 23);
            this.lblStatusLbl.Name = "lblStatusLbl";
            this.lblStatusLbl.Size = new System.Drawing.Size(80, 20);
            this.lblStatusLbl.TabIndex = 8;
            this.lblStatusLbl.Text = "Trạng thái";
            // 
            // lblStatusVal
            // 
            this.lblStatusVal.AutoSize = true;
            this.lblStatusVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusVal.Location = new System.Drawing.Point(100, 41);
            this.lblStatusVal.Name = "lblStatusVal";
            this.lblStatusVal.Size = new System.Drawing.Size(23, 20);
            this.lblStatusVal.TabIndex = 9;
            this.lblStatusVal.Text = "—";
            // 
            // lblMakeupLbl
            // 
            this.lblMakeupLbl.AutoSize = true;
            this.lblMakeupLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMakeupLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblMakeupLbl.Location = new System.Drawing.Point(10, 162);
            this.lblMakeupLbl.Name = "lblMakeupLbl";
            this.lblMakeupLbl.Size = new System.Drawing.Size(93, 20);
            this.lblMakeupLbl.TabIndex = 10;
            this.lblMakeupLbl.Text = "Bù cho buổi";
            this.lblMakeupLbl.Visible = false;
            // 
            // lblMakeupVal
            // 
            this.lblMakeupVal.AutoSize = true;
            this.lblMakeupVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMakeupVal.Location = new System.Drawing.Point(119, 162);
            this.lblMakeupVal.Name = "lblMakeupVal";
            this.lblMakeupVal.Size = new System.Drawing.Size(23, 20);
            this.lblMakeupVal.TabIndex = 11;
            this.lblMakeupVal.Text = "—";
            this.lblMakeupVal.Visible = false;
            // 
            // lblStatTotal
            // 
            this.lblStatTotal.AutoSize = true;
            this.lblStatTotal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatTotal.Location = new System.Drawing.Point(17, 224);
            this.lblStatTotal.Name = "lblStatTotal";
            this.lblStatTotal.Size = new System.Drawing.Size(54, 21);
            this.lblStatTotal.TabIndex = 1;
            this.lblStatTotal.Text = "Tổng:";
            // 
            // lblStatAttended
            // 
            this.lblStatAttended.AutoSize = true;
            this.lblStatAttended.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatAttended.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.lblStatAttended.Location = new System.Drawing.Point(17, 244);
            this.lblStatAttended.Name = "lblStatAttended";
            this.lblStatAttended.Size = new System.Drawing.Size(82, 21);
            this.lblStatAttended.TabIndex = 2;
            this.lblStatAttended.Text = "Attended:";
            // 
            // lblStatAbsent
            // 
            this.lblStatAbsent.AutoSize = true;
            this.lblStatAbsent.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatAbsent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lblStatAbsent.Location = new System.Drawing.Point(17, 264);
            this.lblStatAbsent.Name = "lblStatAbsent";
            this.lblStatAbsent.Size = new System.Drawing.Size(67, 21);
            this.lblStatAbsent.TabIndex = 3;
            this.lblStatAbsent.Text = "Absent:";
            // 
            // btnAddMakeup
            // 
            this.btnAddMakeup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.btnAddMakeup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(239)))), ((int)(((byte)(172)))));
            this.btnAddMakeup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMakeup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMakeup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.btnAddMakeup.Location = new System.Drawing.Point(13, 300);
            this.btnAddMakeup.Name = "btnAddMakeup";
            this.btnAddMakeup.Size = new System.Drawing.Size(188, 30);
            this.btnAddMakeup.TabIndex = 4;
            this.btnAddMakeup.Text = "+ Tạo buổi bù";
            this.btnAddMakeup.UseVisualStyleBackColor = false;
            // 
            // btnAttended
            // 
            this.btnAttended.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnAttended.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(197)))), ((int)(((byte)(253)))));
            this.btnAttended.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttended.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttended.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.btnAttended.Location = new System.Drawing.Point(13, 336);
            this.btnAttended.Name = "btnAttended";
            this.btnAttended.Size = new System.Drawing.Size(188, 30);
            this.btnAttended.TabIndex = 5;
            this.btnAttended.Text = "Đánh dấu Attended";
            this.btnAttended.UseVisualStyleBackColor = false;
            // 
            // btnAbsent
            // 
            this.btnAbsent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnAbsent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnAbsent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbsent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbsent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnAbsent.Location = new System.Drawing.Point(13, 372);
            this.btnAbsent.Name = "btnAbsent";
            this.btnAbsent.Size = new System.Drawing.Size(188, 30);
            this.btnAbsent.TabIndex = 6;
            this.btnAbsent.Text = "Đánh dấu Absent";
            this.btnAbsent.UseVisualStyleBackColor = false;
            // 
            // btnPostpone
            // 
            this.btnPostpone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.btnPostpone.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(180)))), ((int)(((byte)(254)))));
            this.btnPostpone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPostpone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostpone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(33)))), ((int)(((byte)(168)))));
            this.btnPostpone.Location = new System.Drawing.Point(13, 408);
            this.btnPostpone.Name = "btnPostpone";
            this.btnPostpone.Size = new System.Drawing.Size(188, 30);
            this.btnPostpone.TabIndex = 7;
            this.btnPostpone.Text = "Hoãn lịch";
            this.btnPostpone.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(13, 471);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(188, 30);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Xuất dữ liệu";
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(13, 507);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(188, 30);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Quay lại";
            // 
            // dgvSchedules
            // 
            this.dgvSchedules.AllowUserToAddRows = false;
            this.dgvSchedules.AllowUserToDeleteRows = false;
            this.dgvSchedules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedules.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSchedules.ColumnHeadersHeight = 30;
            this.dgvSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedules.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvSchedules.Location = new System.Drawing.Point(0, 0);
            this.dgvSchedules.MultiSelect = false;
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.ReadOnly = true;
            this.dgvSchedules.RowHeadersVisible = false;
            this.dgvSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedules.Size = new System.Drawing.Size(1000, 560);
            this.dgvSchedules.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Salmon;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(239)))), ((int)(((byte)(172)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(454, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "label3";
            // 
            // ucSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucSchedules";
            this.Size = new System.Drawing.Size(1000, 600);
            this.pnlHeader.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTrainer;
        private System.Windows.Forms.ComboBox cboTrainer;
        private System.Windows.Forms.Label lblSlot;
        private System.Windows.Forms.ComboBox cboSlot;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.TextBox txtMember;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblMemberNameLbl;
        private System.Windows.Forms.Label lblMemberNameVal;
        private System.Windows.Forms.Label lblClassLbl;
        private System.Windows.Forms.Label lblClassVal;
        private System.Windows.Forms.Label lblDateLbl;
        private System.Windows.Forms.Label lblDateVal;
        private System.Windows.Forms.Label lblTimeLbl;
        private System.Windows.Forms.Label lblTimeVal;
        private System.Windows.Forms.Label lblStatusLbl;
        private System.Windows.Forms.Label lblStatusVal;
        private System.Windows.Forms.Label lblMakeupLbl;
        private System.Windows.Forms.Label lblMakeupVal;
        private System.Windows.Forms.Label lblStatTotal;
        private System.Windows.Forms.Label lblStatAttended;
        private System.Windows.Forms.Label lblStatAbsent;
        private System.Windows.Forms.Button btnAddMakeup;
        private System.Windows.Forms.Button btnAttended;
        private System.Windows.Forms.Button btnAbsent;
        private System.Windows.Forms.Button btnPostpone;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
