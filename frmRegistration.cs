using desktopapp_GYM.BLL;
using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopapp_GYM
{
    public partial class frmRegistration : Form
    {
        private readonly RegistrationBLL regBll = new RegistrationBLL();
        private readonly MemberBLL memberBll = new MemberBLL();
        private readonly PackageBLL pkgBll = new PackageBLL();
        private readonly TrainerBLL trainerBll = new TrainerBLL();
        private readonly TimeslotBLL slotBll = new TimeslotBLL();

        private readonly RegistrationDTO _dto;
        private readonly bool _isAdd;
        private int _resolvedMemberID = 0; // MemberID cuối cùng dùng để lưu
        bool isDataChanged = false;

        // Lưu các slot đã Add vào listbox
        private List<TimeslotDTO> _selectedSlots = new List<TimeslotDTO>();
        
        public frmRegistration()
        {
            InitializeComponent();
        }

        public frmRegistration(RegistrationDTO dto, bool isAdd)
        {
            InitializeComponent();
            _dto = dto;
            _isAdd = isAdd;
            if (_isAdd) 
                _dto = new RegistrationDTO();
            }

        private void ApplyEditPermissions(string paymentStatus)
        {
            bool isPaid = paymentStatus == "Paid";

            // Paid → khóa hầu hết, chỉ cho sửa Notes + PaymentStatus + IsActive
            // Unpaid/Partial → mở toàn bộ như Add

            // Phần Member — luôn khóa khi edit
            grpOption.Enabled = false;
            grpPersonal.Enabled = false;

            // Phần loại gói
            grpType.Enabled = !isPaid;

            // Phần thông tin gói
            grpPackage.Enabled = !isPaid;

            // Phần slot
            grpSlot.Visible = !isPaid && (_dto.PackageType != "FREE");
            btnAdd.Enabled = !isPaid;
            btnDelete.Enabled = !isPaid;
            btnClear.Enabled = !isPaid;

            // Phần luôn cho sửa dù Paid hay không
            cboPayment.Enabled = true;
            chkIsActive.Enabled = true;
            txtNotes.Enabled = true;
            txtDiscount.Enabled = !isPaid; // Giảm giá chỉ cho sửa khi chưa paid
        }

        private void FillForm()
        {
            txtFullName.Text = _dto.MemberName;
            txtPhone.Text = _dto.MemberPhone; ;   // Không có trong DTO, chỉ hiển thị tên
            dtpRegDate_New.Value = _dto.RegDate;
            //dtpStartDate_New.Value = DateTime.Today;
            dtpEndDate.Value = _dto.EndDate;

            // Tick đúng loại gói
            switch (_dto.PackageType)
            {
                case "FREE": rdoFree.Checked = true; break;
                case "CLASS": rdoClass.Checked = true; break;
                case "PT": rdoPT.Checked = true; break;
            }

            cboPackage.SelectedValue = _dto.PackageID;
            LoadTrainersByPackage(_dto.PackageID);
            cboTrainer.SelectedValue = _dto.TrainerID ?? (object)DBNull.Value;

            txtOriginalPrice.Text = _dto.OriginalPrice.ToString("N0");
            txtDiscount.Text = _dto.DiscountAmount.ToString("N0");
            txtTotalAmount.Text = _dto.TotalAmount.ToString("N0");
            txtSessionsPerWeek.Text = _dto.SessionsPerWeek.ToString();
            txtSessionsTotal.Text = _dto.SessionsTotal.ToString();
            txtPTFee.Text = "0";

            cboPayment.Text = _dto.PaymentStatus;
            chkIsActive.Checked = _dto.IsActive;
            txtNotes.Text = _dto.Notes;

            // Load slots đã đăng ký vào listbox
            var registeredSlots = regBll.GetSlotsByReg(_dto.RegID);
            _selectedSlots = registeredSlots.Select(s => new TimeslotDTO
            {
                SlotID = s.SlotID,
                SlotName = s.SlotName,
                DayOfWeek = s.DayOfWeek,
                StartTime = s.StartTime,
                EndTime = s.EndTime
            }).ToList();
            RefreshSlotListBox();

            _resolvedMemberID = _dto.MemberID;
            ApplyEditPermissions(_dto.PaymentStatus);
        }

        private void MarkAsChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
        }

        private void ToggleEvents(bool active)
        {
            if (active)
            {
                txtFullName.TextChanged += MarkAsChanged;
                txtPhone.TextChanged += MarkAsChanged;
                cboOldMember.SelectedIndexChanged += MarkAsChanged;
                rdoNewMember.CheckedChanged += MarkAsChanged;
                rdoOldMember.CheckedChanged += MarkAsChanged;
                rdoFree.CheckedChanged += MarkAsChanged;
                rdoClass.CheckedChanged += MarkAsChanged;
                rdoPT.CheckedChanged += MarkAsChanged;
                cboPackage.SelectedIndexChanged += MarkAsChanged;
                cboTrainer.SelectedIndexChanged += MarkAsChanged;
                cboDayOfWeek.SelectedIndexChanged += MarkAsChanged;
                txtDiscount.TextChanged += MarkAsChanged;
                txtPTFee.TextChanged += MarkAsChanged;
                txtNotes.TextChanged += MarkAsChanged;
                cboPayment.SelectedIndexChanged += MarkAsChanged;
                chkIsActive.CheckedChanged += MarkAsChanged;
                dtpEndDate.ValueChanged += MarkAsChanged;
            }
            else
            {
                txtFullName.TextChanged -= MarkAsChanged;
                txtPhone.TextChanged -= MarkAsChanged;
                cboOldMember.SelectedIndexChanged -= MarkAsChanged;
                rdoNewMember.CheckedChanged -= MarkAsChanged;
                rdoOldMember.CheckedChanged -= MarkAsChanged;
                rdoFree.CheckedChanged -= MarkAsChanged;
                rdoClass.CheckedChanged -= MarkAsChanged;
                rdoPT.CheckedChanged -= MarkAsChanged;
                cboPackage.SelectedIndexChanged -= MarkAsChanged;
                cboTrainer.SelectedIndexChanged -= MarkAsChanged;
                cboDayOfWeek.SelectedIndexChanged -= MarkAsChanged;
                txtDiscount.TextChanged -= MarkAsChanged;
                txtPTFee.TextChanged -= MarkAsChanged;
                txtNotes.TextChanged -= MarkAsChanged;
                cboPayment.SelectedIndexChanged -= MarkAsChanged;
                chkIsActive.CheckedChanged -= MarkAsChanged;
                dtpEndDate.ValueChanged -= MarkAsChanged;
            }
        }

        private void SetMemberInputEnabled(bool enabled)
        {
            txtFullName.Enabled = enabled;
            txtPhone.Enabled = enabled;
            cboStatus.Enabled = enabled;
            // dtpRegDate luôn readonly
        }

        private void ClearMemberFields()
        {
            txtFullName.Text = "";
            txtPhone.Text = "";
            cboStatus.SelectedIndex = 0;
        }

        private void SetSlotSectionVisible(bool visible)
        {
            grpSlot.Visible = visible; // GroupBox "Chọn thời khóa biểu"
        }

        private void SetPTFeeVisible(bool visible)
        {
            //lblPTFee.Visible = visible;
            txtPTFee.Visible = visible;
        }

        private void SetPackageSection(object _)
        {
            cboPackage.SelectedIndex = -1;
        }

        private void InitStaticComboBoxes()
        {
            // Member cũ
            var members = memberBll.GetData();
            cboOldMember.DataSource = members;
            cboOldMember.DisplayMember = "FullName";
            cboOldMember.ValueMember = "MemberID";
            cboOldMember.SelectedIndex = -1;

            // Status member
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new[] { "Active", "Inactive" });
            cboStatus.SelectedIndex = 0;

            // Trainer
            var trainers = trainerBll.GetData();
            cboTrainer.DataSource = trainers;
            cboTrainer.DisplayMember = "FullName";
            cboTrainer.ValueMember = "TrainerID";
            cboTrainer.SelectedIndex = -1;

            // Ngày trong tuần
            cboDayOfWeek.Items.Clear();
            cboDayOfWeek.Items.AddRange(new[] {
                "Thứ 2","Thứ 3","Thứ 4","Thứ 5","Thứ 6","Thứ 7","Chủ Nhật"
            });
            cboDayOfWeek.SelectedIndex = -1;

            // Payment
            cboPayment.Items.Clear();
            cboPayment.Items.AddRange(new[] { "Paid", "Unpaid", "Partial" });
            cboPayment.SelectedIndex = 0;
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            InitStaticComboBoxes();

            if (_isAdd)
            {
                // Mặc định chế độ thêm mới
                dtpStartDate_New.Value = DateTime.Today;
                dtpStartDate_New.Enabled = false; // REGDATE = hôm nay, không cho sửa
                dtpRegDate_New.Value = DateTime.Today;
                dtpRegDate_New.Enabled = true;
                dtpEndDate.Value = dtpRegDate_New.Value.AddMonths(1);
                chkIsActive.Checked = true;
                cboPayment.SelectedIndex = 0;

                // Ẩn combobox member cũ, disable input member mới
                cboOldMember.Visible = false;
                SetMemberInputEnabled(false);
                SetPackageSection(null); // Ẩn phần slot ban đầu
                grpPackage.Enabled = false; // Chờ user chọn loại gói trước
                grpSlot.Visible = false;
            }
            else
            {
                // Edit mode — disable chọn member
                grpOption.Enabled = false;
                grpPersonal.Enabled = false;
                FillForm();
            }

            ToggleEvents(true);
            isDataChanged = false;

        }

        private void rdoNewMember_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoNewMember.Checked) return;
            cboOldMember.Visible = false;
            cboOldMember.SelectedIndex = -1;
            SetMemberInputEnabled(true);
            ClearMemberFields();
            _resolvedMemberID = 0;
        }

        private void rdoOldMember_CheckedChanged(object sender, EventArgs e)
        {
            if(!rdoOldMember.Checked) return;
            cboOldMember.Visible = true;
            SetMemberInputEnabled(false);
            ClearMemberFields();
            _resolvedMemberID = 0;
        }

        private void cboOldMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOldMember.SelectedValue is int mid && mid > 0)
            {
                var m = memberBll.GetById(mid);
                if (m == null) return;
                txtFullName.Text = m.FullName;
                txtPhone.Text = m.Phone;
                cboStatus.Text = m.Status;
                _resolvedMemberID = mid;
            }
        }

        private void rdoFree_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoFree.Checked) return;
            grpPackage.Enabled = true;
            LoadPackagesByType("FREE");
            SetSlotSectionVisible(false);
            SetPTFeeVisible(false);
        }

        private void rdoClass_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoClass.Checked) return;
            grpPackage.Enabled = true;
            LoadPackagesByType("CLASS");
            SetSlotSectionVisible(true);
            SetPTFeeVisible(false);
        }

        private void rdoPT_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoPT.Checked) return;
            grpPackage.Enabled = true;
            LoadPackagesByType("PT");
            SetSlotSectionVisible(true);
            SetPTFeeVisible(true);
        }

        private void LoadPackagesByType(string type)
        {
            var packages = pkgBll.GetByType(type); // Cần thêm hàm này vào BLL
            cboPackage.DataSource = packages;
            cboPackage.DisplayMember = "PackageName";
            cboPackage.ValueMember = "PackageID";
            cboPackage.SelectedIndex = -1;
        }

        private void RefreshTimeSlots()
        {
            cboTime.DataSource = null;
            cboTime.Items.Clear();

            // Lấy TrainerID — xử lý cả DataRowView (khi source là DataTable)
            int tid = 0;
            if (cboTrainer.SelectedValue is int tInt)
                tid = tInt;
            else if (cboTrainer.SelectedValue != null &&
                     int.TryParse(cboTrainer.SelectedValue.ToString(), out int tParsed))
                tid = tParsed;

            // Lấy PackageID — source là List<PackageDTO> nên SelectedValue là int
            int pid = 0;
            if (cboPackage.SelectedValue is int pInt)
                pid = pInt;

            string day = cboDayOfWeek.SelectedItem?.ToString();

            if (tid <= 0 || pid <= 0 || string.IsNullOrEmpty(day)) return;

            var slots = slotBll.GetByTrainerPackageDay(tid, pid, day);

            if (slots == null || slots.Count == 0)
            {
                MessageBox.Show("Không có khung giờ nào phù hợp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var availableSlots = slots.Where(s => s.CurrentCount < s.MaxMembers).ToList();

            if (availableSlots.Count == 0)
            {
                MessageBox.Show("Tất cả khung giờ trong ngày này đã đầy chỗ!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTime.DataSource = null;
                return;
            }

            cboTime.DataSource = availableSlots;
            cboTime.DisplayMember = "DisplayTime";
            cboTime.ValueMember = "SlotID";
            cboTime.SelectedIndex = -1;
        }

        private void LoadTrainersByPackage(int packageId)
        {
            // Dùng TimeslotDAL.GetTrainersByPackage đã có sẵn
            var dt = slotBll.GetTrainersByPackage(packageId);
            cboTrainer.DataSource = dt;
            cboTrainer.DisplayMember = "FULLNAME";
            cboTrainer.ValueMember = "TRAINERID";
            cboTrainer.SelectedIndex = -1;
        }

        private void cboPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cboPackage.SelectedValue is int pkgId) || pkgId <= 0) return;

            var pkg = pkgBll.GetById(pkgId);
            if (pkg == null) return;

            // Tự fill thông tin gói
            dtpEndDate.Value = dtpRegDate_New.Value.AddMonths(pkg.DurationMonths);
            txtOriginalPrice.Text = pkg.Price.ToString("N0");
            txtDiscount.Text = "0";
            RecalcTotal();

            if (pkg.PTSessionsPerWeek.HasValue && pkg.PTSessionsPerWeek > 0)
            {
                int weeks = pkg.DurationMonths * 4;
                int total = pkg.PTSessionsPerWeek.Value * weeks;
                txtSessionsPerWeek.Text = pkg.PTSessionsPerWeek.Value.ToString();
                txtSessionsTotal.Text = total.ToString();
            }
            else
            {
                txtSessionsPerWeek.Text = "0";
                txtSessionsTotal.Text = "0";
            }

            LoadTrainersByPackage(pkgId);

            // Reset các bước sau
            cboDayOfWeek.SelectedIndex = -1;
            cboTime.DataSource = null;
            cboTime.Items.Clear();

            RefreshTimeSlots();
        }

        private void cboTrainer_SelectedIndexChanged(object sender, EventArgs e) => RefreshTimeSlots();
        private void cboDayOfWeek_SelectedIndexChanged(object sender, EventArgs e) => RefreshTimeSlots();

        private void RefreshSlotListBox()
        {
            lstSlots.Items.Clear();
            foreach (var s in _selectedSlots)
                lstSlots.Items.Add($"{s.DayOfWeek}  {s.StartTime}-{s.EndTime}  [{s.SlotName}]");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!(cboTime.SelectedValue is int slotId))
            {
                MessageBox.Show("Vui lòng chọn khung giờ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng
            if (_selectedSlots.Any(s => s.SlotID == slotId))
            {
                MessageBox.Show("Khung giờ này đã được thêm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var slot = (TimeslotDTO)cboTime.SelectedItem;
            if (slot == null) return;
            if (slot.CurrentCount >= slot.MaxMembers)
            {
                MessageBox.Show($"Lớp {slot.SlotName} đã vừa đủ {slot.MaxMembers} người. Vui lòng chọn giờ khác!",
                                "Lớp đầy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshTimeSlots(); // Load lại combo để cập nhật danh sách mới nhất
                return;
            }

            _selectedSlots.Add(slot);
            RefreshSlotListBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstSlots.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn buổi muốn xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu index trước khi xóa
            int indexToRemove = lstSlots.SelectedIndex;

            // Xóa khỏi list data
            _selectedSlots.RemoveAt(indexToRemove);

            // Vẽ lại listbox
            RefreshSlotListBox();

            // Giữ selection hợp lý sau khi xóa
            if (lstSlots.Items.Count > 0)
                lstSlots.SelectedIndex = Math.Min(indexToRemove, lstSlots.Items.Count - 1);
        }

        private void RecalcTotal()
        {
            decimal.TryParse(txtOriginalPrice.Text.Replace(",", ""), out decimal original);
            decimal.TryParse(txtDiscount.Text.Replace(",", ""), out decimal discount);
            decimal.TryParse(txtPTFee.Text.Replace(",", ""), out decimal ptFee);
            txtTotalAmount.Text = Math.Max(0, original + ptFee - discount).ToString("N0");
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e) => RecalcTotal();
        private void txtPTFee_TextChanged(object sender, EventArgs e) => RecalcTotal();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Xử lý Member
                if (_isAdd)
                {
                    
                    if (rdoNewMember.Checked)
                    {
                        // Validate
                        if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                            string.IsNullOrWhiteSpace(txtPhone.Text))
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và SĐT!",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Tạo member mới → lấy ID
                        var newMember = new MemberDTO
                        {
                            FullName = txtFullName.Text.Trim(),
                            Phone = txtPhone.Text.Trim(),
                            JoinDate = dtpStartDate_New.Value.Date,
                            Status = cboStatus.Text
                        };
                        _resolvedMemberID = memberBll.AddAndGetID(newMember);
                        if (_resolvedMemberID <= 0)
                        {
                            MessageBox.Show("Tạo hội viên mới thất bại!");
                            return;
                        }
                        var members = memberBll.GetData();

                        cboOldMember.SelectedIndexChanged -= cboOldMember_SelectedIndexChanged;
                        cboOldMember.DataSource = members;
                        cboOldMember.DisplayMember = "FullName";
                        cboOldMember.ValueMember = "MemberID";
                        cboOldMember.SelectedIndex = -1;
                        cboOldMember.SelectedIndexChanged += cboOldMember_SelectedIndexChanged;
                    }
                    else // Member cũ
                    {
                        if (_resolvedMemberID <= 0)
                        {
                            MessageBox.Show("Vui lòng chọn hội viên!",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // 2. Validate gói
                if (!(cboPackage.SelectedValue is int pkgId) || pkgId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn gói tập!",
                        "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2.5. Validate số buổi vs số slot đã chọn
                int sessionsPerWeek = int.TryParse(txtSessionsPerWeek.Text, out int spw) ? spw : 0;
                if (sessionsPerWeek > 0)
                {
                    int selectedCount = _selectedSlots.Count;
                    if (selectedCount == 0)
                    {
                        MessageBox.Show($"Gói này yêu cầu {sessionsPerWeek} buổi/tuần.\nVui lòng chọn đủ khung giờ!",
                            "Thiếu lịch học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (selectedCount != sessionsPerWeek)
                    {
                        MessageBox.Show(
                            $"Gói này yêu cầu {sessionsPerWeek} buổi/tuần.\n" +
                            $"Bạn mới chọn {selectedCount} buổi.\n" +
                            $"Vui lòng chọn {sessionsPerWeek - selectedCount} buổi nữa!",
                            "Chưa đủ lịch học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra không được chọn trùng thứ
                    var duplicateDays = _selectedSlots
                        .GroupBy(s => s.DayOfWeek)
                        .Where(g => g.Count() > 1)
                        .Select(g => g.Key)
                        .ToList();

                    if (duplicateDays.Any())
                    {
                        MessageBox.Show(
                            $"Không thể chọn 2 buổi cùng thứ:\n{string.Join(", ", duplicateDays)}",
                            "Trùng lịch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 3. Build DTO
                var reg = _isAdd ? new RegistrationDTO() : _dto;

                reg.MemberID = _resolvedMemberID;
                reg.PackageID = pkgId;
                reg.TrainerID = cboTrainer.SelectedValue is int tid && tid > 0
                                    ? tid : (int?)null;
                reg.EndDate = dtpEndDate.Value.Date;
                reg.RegDate = dtpRegDate_New.Value.Date;
                reg.OriginalPrice = decimal.TryParse(
                    txtOriginalPrice.Text.Replace(",", ""), out decimal orig) ? orig : 0;
                reg.DiscountAmount = decimal.TryParse(
                    txtDiscount.Text.Replace(",", ""), out decimal disc) ? disc : 0;
                reg.TotalAmount = decimal.TryParse(
                    txtTotalAmount.Text.Replace(",", ""), out decimal total) ? total : 0;

                reg.SessionsTotal = int.TryParse(txtSessionsTotal.Text, out int st) ? st : 0;
                reg.SessionsLeft = reg.SessionsTotal; // Lúc mới đăng ký = còn đủ buổi
                reg.PaymentStatus = cboPayment.Text;
                reg.IsActive = chkIsActive.Checked;
                reg.Notes = txtNotes.Text.Trim();

                reg.SelectedSlotIDs = _selectedSlots.Select(s => s.SlotID).ToList();

                // 4. Lưu
                if (regBll.Save(reg, _isAdd))
                {
                    MessageBox.Show(_isAdd ? "Đăng ký thành công!" : "Cập nhật thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (_isAdd)
            {
                // Add mode → clear hết như cũ
                ToggleEvents(false);

                rdoNewMember.Checked = false;
                rdoOldMember.Checked = false;
                rdoFree.Checked = false;
                rdoClass.Checked = false;
                rdoPT.Checked = false;
                ClearMemberFields();
                cboPackage.SelectedIndex = -1;
                cboTrainer.SelectedIndex = -1;
                cboDayOfWeek.SelectedIndex = -1;
                cboTime.DataSource = null;
                cboTime.Items.Clear();
                _selectedSlots.Clear();
                RefreshSlotListBox();
                txtDiscount.Text = "0";
                txtOriginalPrice.Text = "";
                txtTotalAmount.Text = "";
                txtSessionsTotal.Text = "";
                txtSessionsPerWeek.Text = "";
                txtPTFee.Text = "0";
                txtNotes.Text = "";
                chkIsActive.Checked = true;
                _resolvedMemberID = 0;
                grpPackage.Enabled = false;
                grpSlot.Visible = false;

                ToggleEvents(true);
                isDataChanged = false;
            }
            else
            {
                // Edit mode → hoàn tác về dữ liệu cũ
                if (MessageBox.Show("Hoàn tác toàn bộ thay đổi về dữ liệu ban đầu?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ToggleEvents(false);
                    FillForm();           // Đổ lại dữ liệu gốc từ _dto
                    ToggleEvents(true);
                    isDataChanged = false;
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_selectedSlots.Count == 0) return;

            if (MessageBox.Show("Xóa toàn bộ lịch đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _selectedSlots.Clear();
                RefreshSlotListBox();
            }
        }

        private void LoadDaysByTrainerPackage()
        {
            int? tid = cboTrainer.SelectedValue is int t && t > 0 ? t : (int?)null;
            int? pid = cboPackage.SelectedValue is int p && p > 0 ? p : (int?)null;
            if (tid == null || pid == null) return;

            // Lấy danh sách thứ có timeslot của trainer + package này
            var days = slotBll.GetDaysByTrainerPackage(tid.Value, pid.Value);
            cboDayOfWeek.DataSource = days; // List<string>
            cboDayOfWeek.SelectedIndex = -1;
        }

        private void cboTrainer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cboDayOfWeek.SelectedIndex = -1;
            cboTime.DataSource = null;
            cboTime.Items.Clear();
            LoadDaysByTrainerPackage();
        }



        private void cboDayOfWeek_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cboTime.DataSource = null;
            cboTime.Items.Clear();
            RefreshTimeSlots();
        }

        private void frmRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK) return;

            if (isDataChanged)
            {
                var result = MessageBox.Show(
                    "Bạn có thay đổi chưa lưu. Bạn có chắc muốn thoát không?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.No)
                    e.Cancel = true; // Ngăn đóng form
            }
        }

        private void cboPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isAdd) return;
            ApplyEditPermissions(cboPayment.Text);
            MarkAsChanged(sender, e);
        }

        private void UpdateEndDate()
        {
            // 1. Kiểm tra xem đã chọn gói tập chưa
            if (cboPackage.SelectedValue is int pkgId && pkgId > 0)
            {
                var pkg = pkgBll.GetById(pkgId);
                if (pkg != null)
                {
                    // EndDate = RegDate + số tháng thời hạn của gói
                    dtpEndDate.Value = dtpRegDate_New.Value.Date.AddMonths(pkg.DurationMonths);
                }
            }
        }

        private void dtpRegDate_New_ValueChanged(object sender, EventArgs e)
        {
            UpdateEndDate();
            MarkAsChanged(sender, e);
        }
    }
}
