using desktopapp_GYM.BLL;
using desktopapp_GYM.DAL;
using desktopapp_GYM.DTO;
using desktopapp_GYM.GUI;
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
    public partial class ucTimeSlotReg : UserControl
    {
        private TimeslotBLL bll = new TimeslotBLL();
        private TrainerBLL trainerBll = new TrainerBLL();
        private PackageBLL packageBll = new PackageBLL();
        private TimeslotDTO currentSelectedSlot = null;
        private FlowLayoutPanel currentHighlightedCell = null;
        bool isAddMode = false;
        bool isDataChanged = false;
        private bool _isTracking = false;

        public ucTimeSlotReg()
        {
            InitializeComponent();
            try
            {
                cboDate.SelectedIndexChanged += OnDateTimeInputChanged;
                dtpStart.ValueChanged += OnDateTimeInputChanged;
                SetupTimeLimits();
                LoadComboBoxData();
                InitEmptySlots();
                ApplyRolePermissions();
                LoadDataToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo màn hình: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRolePermissions()
        {
            try
            {
                string role = Session.CurrentRole;

                if (role == "Receptionist")
                {
                    btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
                }
                else if (role == "Manager")
                {
                    btnAdd.Enabled = btnEdit.Enabled = true;
                    btnDelete.Enabled = false;
                }
                else // Admin
                {
                    btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi role: " + ex.Message);
            }
        }

        private void SetupTimeLimits()
        {
            try
            {
                // Lấy ngày hiện tại từ dtp để tránh làm thay đổi ngày khi giới hạn giờ
                DateTime today = dtpStart.Value.Date;
    
                // Giới hạn dtpStart: sớm nhất là 06:00 và muộn nhất là 21:00
                dtpStart.MinDate = today.AddHours(6);
                dtpStart.MaxDate = today.AddHours(21);
    
                // Tương tự cho dtpEnd (Kết thúc có thể là 22:00)
                dtpEnd.MinDate = today.AddHours(7);
                dtpEnd.MaxDate = today.AddHours(22);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Highlight error: " + ex.Message);
            }
        }

        private void MarkAsChanged(object sender, EventArgs e)
        {
            if (!_isTracking) return;
            isDataChanged = true;
        }

        private void ToggleEvents(bool active)
        {
            _isTracking = active;
            if (active)
            {
                txtClassName.TextChanged += MarkAsChanged;
                txtMaxMember.TextChanged += MarkAsChanged;
                cboTrainer.SelectedIndexChanged += MarkAsChanged;
                cboPackage.SelectedIndexChanged += MarkAsChanged;
                cboStatus.SelectedIndexChanged += MarkAsChanged;
                cboDate.SelectedIndexChanged += MarkAsChanged;
                dtpStart.ValueChanged += MarkAsChanged;
                dtpEnd.ValueChanged += MarkAsChanged;
            }
            else
            {
                txtClassName.TextChanged -= MarkAsChanged;
                txtMaxMember.TextChanged -= MarkAsChanged;
                cboTrainer.SelectedIndexChanged -= MarkAsChanged;
                cboPackage.SelectedIndexChanged -= MarkAsChanged;
                cboStatus.SelectedIndexChanged -= MarkAsChanged;
                cboDate.SelectedIndexChanged -= MarkAsChanged;
                dtpStart.ValueChanged -= MarkAsChanged;
                dtpEnd.ValueChanged -= MarkAsChanged;
            }
        }

        private bool TryLeaveCurrentEdit()
        {
            if (!isDataChanged) return true;

            var result = MessageBox.Show(
                "Bạn có thay đổi chưa lưu. Bạn có muốn lưu trước khi rời không?",
                "Chưa lưu",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                button4_Click(null, null); 
                return !isDataChanged;    
            }
            else if (result == DialogResult.No)
            {
                ToggleEvents(false);
                isDataChanged = false;
                return true;
            }
            else // Cancel
            {
                return false;
            }
        }

        private void OnDateTimeInputChanged(object sender, EventArgs e)
        {
            if (!isAddMode) return;
            if (cboDate.SelectedItem == null) return;

            string day = cboDate.SelectedItem.ToString();           
            string time = dtpStart.Value.ToString("HH:00");         
            string targetTag = day + "|" + time;


            if (currentHighlightedCell != null)
                currentHighlightedCell.BackColor = Color.Transparent;
            foreach (Control ctrl in tlpBody.Controls)
            {
                if (ctrl is FlowLayoutPanel flp && flp.Tag?.ToString() == targetTag)
                {
                    currentHighlightedCell = flp;
                    flp.BackColor = Color.FromArgb(200, 230, 255);
                    break;
                }
            }
        }

        private readonly List<string> timeLabels = new List<string> {
            "06:00", "07:00", "08:00", "09:00", "10:00", "11:00",
            "12:00", "13:00", "14:00", "15:00", "16:00", "17:00",
            "18:00", "19:00", "20:00", "21:00", "22:00"
        };

        private void cboPackage_SelectedIndexChanged(object sender, EventArgs e) { }

        private void cboTrainer_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboTrainer.SelectedValue != null && cboTrainer.SelectedValue is int trainerId)
            {
                try
                {
                    var filteredPackages = packageBll.GetPackagesByTrainer(trainerId);

                    cboPackage.DataSource = filteredPackages;
                    cboPackage.DisplayMember = "PackageName";
                    cboPackage.ValueMember = "PackageID";

                    if (isAddMode) cboPackage.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách gói tập: " + ex.Message);
                }
            }
        }

        private void LoadComboBoxData()
        {
            try
            {
                cboDate.Items.Clear();
                for (int i = 1; i < dayLabels.Length; i++)
                {
                    cboDate.Items.Add(dayLabels[i]);
                }

                var trainers = trainerBll.GetData();
                cboTrainer.DataSource = trainers;
                cboTrainer.DisplayMember = "FullName";
                cboTrainer.ValueMember = "TrainerID";
                cboTrainer.SelectedIndex = -1;

                cboStatus.Items.Clear();
                cboStatus.Items.Add("Active");
                cboStatus.Items.Add("Inactive");
                cboStatus.SelectedIndex = 0;

                cboPackage.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách: " + ex.Message);
            }
        }

        private void SetInputStatus(bool isEditing)
        {
            grpInfo.Enabled = isEditing;
            btnSave.Enabled = isEditing;
            btnClear.Enabled = isEditing;

            btnAdd.Enabled = !isEditing;
            btnEdit.Enabled = !isEditing;
        }

        private readonly string[] dayLabels = {
            "Giờ", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ Nhật"
        };

        private void InitEmptySlots()
        {
            tlpBody.Controls.Clear();
            tlpBody.RowCount = timeLabels.Count;

            tlpBody.AutoSize = true;
            tlpBody.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpBody.RowStyles.Clear();
            for (int i = 0; i < timeLabels.Count; i++)
            {
                tlpBody.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            for (int row = 0; row < timeLabels.Count; row++)
            {
                Label lblTime = new Label
                {
                    Text = timeLabels[row],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.TopCenter,
                    Font = new Font("Segoe UI", 8, FontStyle.Regular),
                    Padding = new Padding(0, 5, 0, 0)
                };
                tlpBody.Controls.Add(lblTime, 0, row);
                for (int col = 1; col <= 7; col++)
                {
                    FlowLayoutPanel flp = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.TopDown,
                        WrapContents = false,
                        AutoScroll = false,
                        AutoSize = true,
                        BackColor = Color.Transparent,
                        Tag = dayLabels[col] + "|" + timeLabels[row]
                    };

                    flp.DoubleClick += OnCellDoubleClick;
                    tlpBody.Controls.Add(flp, col, row);
                }
            }
        }

        private void ClearInputFields()
        {
            currentSelectedSlot = null;
            txtClassName.Clear();
            txtMaxMember.Clear();
            cboDate.SelectedIndex=-1;
            lblCurrentCount.Text = "0 /";
            lblCurrentCount.ForeColor = Color.Gray;

            cboPackage.DataSource = null;
            cboTrainer.SelectedIndex = -1;
        }


        private void OnCellDoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!TryLeaveCurrentEdit()) return;
                FlowLayoutPanel flp = (FlowLayoutPanel)sender;
                string[] info = flp.Tag.ToString().Split('|');

                ClearInputFields();
                isAddMode = true;      
                SetInputStatus(true);  

                cboDate.SelectedItem = info[0];
                if (DateTime.TryParse(info[1], out DateTime startTime))
                {
                    dtpStart.Value = DateTime.Today.Add(startTime.TimeOfDay);
                    dtpEnd.Value = DateTime.Today.Add(startTime.TimeOfDay).AddHours(1);
                }

                if (currentHighlightedCell != null)
                    currentHighlightedCell.BackColor = Color.Transparent;
                currentHighlightedCell = flp;
                flp.BackColor = Color.FromArgb(200, 230, 255);

                ToggleEvents(true);
                isDataChanged = false;
                txtClassName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn ô: " + ex.Message);
            }
        }

        public void ClearAllSlots()
        {
            foreach (Control ctrl in tlpBody.Controls)
            {
                if (ctrl is FlowLayoutPanel flp)
                {
                    flp.Controls.Clear();
                }
            }
        }

        private void DisplayDetail(TimeslotDTO slot)
        {
            try
            {
                currentSelectedSlot = slot;
                SetInputStatus(false);
                isAddMode = false;
                ToggleEvents(false);

                lblCurrentCount.Text = slot.CurrentCount.ToString() + " /";

                if (slot.CurrentCount >= slot.MaxMembers)
                {
                    lblCurrentCount.ForeColor = Color.Red; // Đầy lớp thì hiện màu đỏ
                }
                else if (slot.MaxMembers - slot.CurrentCount <= 3)
                {
                    lblCurrentCount.ForeColor = Color.Orange; // Sắp đầy (còn dưới 3 chỗ) thì màu cam
                }
                else
                {
                    lblCurrentCount.ForeColor = Color.DeepSkyBlue; // Còn nhiều chỗ thì màu xanh
                }

                txtClassName.Text = slot.SlotName;
                txtMaxMember.Text = slot.MaxMembers.ToString();
                cboDate.Text = slot.DayOfWeek;

                cboTrainer.SelectedValue = slot.TrainerID;

                var filteredPackages = packageBll.GetPackagesByTrainer(slot.TrainerID);
                cboPackage.DataSource = filteredPackages;
                cboPackage.DisplayMember = "PackageName";
                cboPackage.ValueMember = "PackageID";

                cboPackage.SelectedValue = slot.PackageID;

                if (DateTime.TryParse(slot.StartTime, out DateTime start)) dtpStart.Value = start;
                if (DateTime.TryParse(slot.EndTime, out DateTime end)) dtpEnd.Value = end;

                cboStatus.Text = slot.Status;

                bool hasRegistrations = slot.CurrentCount > 0;
                cboStatus.Enabled = true;

                if (hasRegistrations)
                {
                    cboPackage.Enabled = false;
                }
                else
                {
                    cboPackage.Enabled = true;
                }

                SetInputStatus(false);
                isDataChanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message);
            }
        }

        public void LoadDataToGrid()
        {
            ClearAllSlots();
            var list = bll.GetAll();

            foreach (var slot in list)
            {
                string startTimeFormatted = "";
                if (DateTime.TryParse(slot.StartTime, out DateTime dt))
                {
                    startTimeFormatted = dt.ToString("HH:00");
                }
                else
                {
                    continue;
                }

                string dayFromDb = slot.DayOfWeek?.Trim();
                string targetTag = dayFromDb + "|" + startTimeFormatted;

                bool foundCell = false;

                foreach (Control ctrl in tlpBody.Controls)
                {
                    if (ctrl is FlowLayoutPanel flp && flp.Tag != null)
                    {
                        // Dùng Equals và StringComparison để không phân biệt hoa thường/khoảng trắng
                        if (flp.Tag.ToString().Trim().Equals(targetTag, StringComparison.OrdinalIgnoreCase))
                        {
                            ucTimeSlot uc = new ucTimeSlot();
                            uc.UpdateData(slot);
                            uc.Visible = true;

                            uc.Click += (s, e) => {
                                if (!TryLeaveCurrentEdit()) return;
                                DisplayDetail(slot);
                            };

                            flp.Controls.Add(uc);
                            foundCell = true;
                            break;
                        }
                    }
                }

                if (!foundCell)
                {
                    Console.WriteLine($"Không tìm thấy ô cho: {targetTag}");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtClassName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên lớp!");
                    return;
                }

                if (cboTrainer.SelectedValue == null || cboPackage.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ HLV và Gói tập!");
                    return;
                }

                if (!int.TryParse(txtMaxMember.Text, out int maxMem))
                {
                    MessageBox.Show("Số lượng thành viên phải là số nguyên!");
                    return;
                }

                if (dtpStart.Value >= dtpEnd.Value)
                {
                    MessageBox.Show("Giờ kết thúc phải lớn hơn giờ bắt đầu!");
                    return;
                }
                TimeslotDTO ts = isAddMode ? new TimeslotDTO() : currentSelectedSlot;

                ts.SlotName = txtClassName.Text;
                ts.TrainerID = (int)cboTrainer.SelectedValue;
                ts.PackageID = (int)cboPackage.SelectedValue;
                ts.MaxMembers = int.Parse(txtMaxMember.Text);
                ts.StartTime = dtpStart.Value.ToString("HH:mm");
                ts.EndTime = dtpEnd.Value.ToString("HH:mm");
                ts.DayOfWeek = cboDate.Text;
                ts.Status = cboStatus.Text;

                if (!isAddMode && currentSelectedSlot.CurrentCount > 0)
                {
                    if (ts.PackageID != currentSelectedSlot.PackageID)
                    {
                        MessageBox.Show("Lớp đã có hội viên đăng ký, không được phép thay đổi Gói tập!", "Cảnh báo");
                        return;
                    }

                    if (ts.MaxMembers < currentSelectedSlot.CurrentCount)
                    {
                        MessageBox.Show($"Không thể giảm số lượng tối đa xuống {ts.MaxMembers} vì hiện đã có {currentSelectedSlot.CurrentCount} người đăng ký!");
                        return;
                    }
                }


                if (bll.Save(ts, isAddMode))
                {
                    ToggleEvents(false);   
                    isDataChanged = false;
                    MessageBox.Show(isAddMode ? "Thêm lớp mới thành công!" : "Cập nhật thành công!");

                    SetInputStatus(false); 
                    LoadDataToGrid();      
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            grpInfo.Enabled = true;
            if (currentSelectedSlot == null)
            {
                MessageBox.Show("Vui lòng chọn 1 lớp trên lịch để sửa!");
                return;
            }
            isAddMode = false;
            SetInputStatus(true);
            ToggleEvents(true);    
            isDataChanged = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!TryLeaveCurrentEdit()) return;
            isAddMode = true;
            currentSelectedSlot = null;
            ClearInputFields();
            SetInputStatus(true);
            ToggleEvents(true);
            isDataChanged = false;
            txtClassName.Focus();
            MessageBox.Show("Mời bạn chọn Thứ/Giờ trên lịch hoặc nhập trực tiếp bên phải.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!TryLeaveCurrentEdit()) return;

            ToggleEvents(false);
            isDataChanged = false;
            ClearInputFields();
            SetInputStatus(false);

            if (currentHighlightedCell != null)
            {
                currentHighlightedCell.BackColor = Color.Transparent;
                currentHighlightedCell = null;
            }
        }

        public bool CanClose()
        {
            return TryLeaveCurrentEdit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isDataChanged)
            {
                string modeMsg = isAddMode
                    ? "Bạn đang thêm lớp mới chưa lưu. Thoát sẽ mất toàn bộ thông tin vừa nhập."
                    : "Bạn đang chỉnh sửa chưa lưu. Thoát sẽ hoàn tác về dữ liệu cũ.";

                var result = MessageBox.Show(
                    modeMsg + "\nBạn có chắc muốn thoát không?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No) return;

                ToggleEvents(false);
                isDataChanged = false;

                if (isAddMode)
                {
                    ClearInputFields();
                }
                else
                {
                    if (currentSelectedSlot != null)
                        DisplayDetail(currentSelectedSlot);
                }

                SetInputStatus(false);

                if (currentHighlightedCell != null)
                {
                    currentHighlightedCell.BackColor = Color.Transparent;
                    currentHighlightedCell = null;
                }
            }

            Form parent = this.FindForm();
            if (parent is frmMain main) main.ShowUc();
            else if (parent is frmGuest guest) guest.ShowUc();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpEnd.Value = dtpStart.Value.AddHours(1);
                MarkAsChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi Ngày bắt đầu và kết thúc gói: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentSelectedSlot == null)
            {
                MessageBox.Show("Vui lòng chọn một lớp học trên lịch để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa lớp '{currentSelectedSlot.SlotName}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (bll.Delete(currentSelectedSlot))
                    {
                        MessageBox.Show("Xóa lớp học thành công!");

                        ClearInputFields();      
                        SetInputStatus(false);   
                        LoadDataToGrid();        

                        if (currentHighlightedCell != null)
                        {
                            currentHighlightedCell.BackColor = Color.Transparent;
                            currentHighlightedCell = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    ResetGridHighlight();
                    return;
                }

                if (int.TryParse(txtSearch.Text, out int memberId))
                {
                    List<int> registeredSlots = bll.GetSlotIdsByMember(memberId);

                    ResetGridHighlight(); 

                    foreach (Control ctrl in tlpBody.Controls)
                    {
                        if (ctrl is FlowLayoutPanel flp)
                        {
                            foreach (Control subCtrl in flp.Controls)
                            {
                                if (subCtrl is ucTimeSlot uc)
                                {
                                    if (registeredSlots.Contains(uc.CurrentSlotID))
                                    {
                                        uc.BackColor = Color.Gold; 
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Search error: " + ex.Message);
            }
        }

        private void ResetGridHighlight()
        {
            foreach (Control ctrl in tlpBody.Controls)
            {
                if (ctrl is FlowLayoutPanel flp)
                {
                    foreach (Control subCtrl in flp.Controls)
                    {
                        if (subCtrl is ucTimeSlot uc && uc.Data != null)
                            uc.UpdateData(uc.Data);
                    }
                }
            }
        }

        private void btnCLearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            ResetGridHighlight();
            txtSearch.Focus();
        }
    }
}

