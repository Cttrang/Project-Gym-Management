using desktopapp_GYM.BLL;
using desktopapp_GYM.DAL;
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
    public partial class frmSchedules : Form
    {
        ScheduleBLL _scheduleBll = new ScheduleBLL();
        RegistrationBLL _regBll = new RegistrationBLL();
        ScheduleViewDTO _originalSchedule = null;
        TimeslotBLL timeslotBll = new TimeslotBLL();
        bool _isDataChanged = false;
        public frmSchedules()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public frmSchedules(ScheduleViewDTO selectedSchedule)
        {
            InitializeComponent();
            _originalSchedule = selectedSchedule;
            this.Text = "Đăng ký lịch tập bù";
        }

        private void LoadDataToLabels()
        {
            // Đổ dữ liệu từ buổi tập gốc vào các Label (phía bên trái form)
            lblMemberID.Text = _originalSchedule.MemberID_Display;
            lblMemberName.Text = _originalSchedule.MemberName;
            lblSlot.Text = _originalSchedule.SlotName;
            lblDate.Text = _originalSchedule.TrainingDate.ToShortDateString();
            lblStatus.Text = _originalSchedule.Status;
            lblRegID.Text = _originalSchedule.RegID.ToString();
            lblScheduleID.Text = _originalSchedule.ScheduleID.ToString();
            lblOldTrainer.Text = _originalSchedule.TrainerName;
        }

        private void LoadSlotsForMember()
        {
            try
            {
                // Lấy danh sách các Slot (ca tập) mà Member này đã đăng ký trong gói (RegID)
                // Giúp khách bù đúng vào các ca mà gói tập đó cho phép
                var allSlotsOfPackage = _scheduleBll.GetAvailableSlotsByPackage(_originalSchedule.PackageID);
                cboNewSlot.SelectedIndexChanged -= cboNewSlot_SelectedIndexChanged;

                cboNewSlot.DataSource = allSlotsOfPackage;
                cboNewSlot.DisplayMember = "SlotName"; // Hoặc SlotName tùy BLL của Huy
                cboNewSlot.ValueMember = "SlotID";

                cboNewSlot.SelectedIndexChanged += cboNewSlot_SelectedIndexChanged;

                if (allSlotsOfPackage.Count > 0)
                {
                    cboNewSlot.SelectedIndex = 0;
                    // Gọi thủ công lần đầu để cập nhật label Trainer/Time ngay lập tức
                    UpdateSlotLabels((TimeslotDTO)cboNewSlot.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách ca tập: " + ex.Message);
            }
        }

        private void frmSchedules_Load(object sender, EventArgs e)
        {
            timeslotBll.RefreshAllAttendance();
            if (_originalSchedule == null) return;

            LoadDataToLabels();
            LoadSlotsForMember();

            // Thiết lập mặc định cho buổi bù
            dtpNewDate.Value = DateTime.Today;
            dtpNewDate.MinDate = DateTime.Today.AddDays(1);
            chkMakeUp.Checked = true;
            chkMakeUp.Enabled = false; // Luôn là tập bù trong form này

            _isDataChanged = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra tính hợp lệ
            if (cboNewSlot.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn ca tập bù!");
                return;
            }

            if (cboNewSlot.SelectedItem is TimeslotDTO selectedSlot)
            {
                if (selectedSlot.CurrentCount >= selectedSlot.MaxMembers)
                {
                    MessageBox.Show("Ca tập này đã đủ học viên, vui lòng chọn ca khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 2. Tạo DTO mới cho buổi tập bù
            ScheduleDTO makeupDto = new ScheduleDTO
            {
                RegID = _originalSchedule.RegID,
                SlotID = (int)cboNewSlot.SelectedValue,
                TrainingDate = dtpNewDate.Value,
                Status = "Scheduled", // Buổi bù mới tạo ở trạng thái chờ tập
                Notes = "Tập bù cho ngày " + lblDate.Text,
                IsMakeup = true,
                OriginalDate = _originalSchedule.TrainingDate,
                Reason = txtReasons.Text.Trim(),
                MakeupForScheduleID = _originalSchedule.ScheduleID // Lưu vết bù cho buổi nào
            };

            // 3. Gọi BLL để lưu
            if (_scheduleBll.Insert(makeupDto))
            {
                MessageBox.Show("Đăng ký lịch bù thành công!", "Thông báo");
                _isDataChanged = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lưu thất bại. Có thể lịch đã tồn tại hoặc lỗi hệ thống.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReasons.Clear();
            dtpNewDate.Value = DateTime.Today.AddDays(1);
            if (cboNewSlot.Items.Count > 0) cboNewSlot.SelectedIndex = 0;
            _isDataChanged = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MarkAsChanged(object sender, EventArgs e) => _isDataChanged = true;

        private void frmSchedules_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDataChanged)
            {
                var result = MessageBox.Show("Dữ liệu chưa lưu sẽ bị mất. Bạn muốn thoát?",
                             "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) e.Cancel = true;
            }
        }

        private void UpdateSlotLabels(TimeslotDTO selectedSlot)
        {
            if (selectedSlot == null) return;

            lblNewTrainer.Text = selectedSlot.TrainerName;
            lblTime.Text = selectedSlot.StartTime;
            lblStatusMember.Text = $"{selectedSlot.CurrentCount}/{selectedSlot.MaxMembers}";

            // Cảnh báo màu đỏ nếu lớp đầy
            lblStatusMember.ForeColor = (selectedSlot.CurrentCount >= selectedSlot.MaxMembers)
                                        ? Color.Red : Color.Black;
        }

        private void cboNewSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNewSlot.SelectedItem is TimeslotDTO selectedSlot)
            {
                UpdateSlotLabels(selectedSlot);
                _isDataChanged = true;
            }
        }
    }
}
