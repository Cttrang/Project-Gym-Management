using desktopapp_GYM.BLL;
using desktopapp_GYM.DAL;
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
    public partial class ucSchedules : UserControl
    {
        private ScheduleBLL _scheduleBll = new ScheduleBLL();
        private List<ScheduleViewDTO> _currentSource = new List<ScheduleViewDTO>();
        bool _suppressEvents = false;
        public ucSchedules()
        {
            InitializeComponent();
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            cboTrainer.SelectedIndexChanged += cboTrainer_SelectedIndexChanged;
            cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
            cboSlot.SelectedIndexChanged += cboSlot_SelectedIndexChanged;
        }

        public void LoadData()
        {
            if (_suppressEvents) return;
            DateTime date = dtpDate.Value.Date;
            int? trainerId = (cboTrainer.SelectedValue != null && Convert.ToInt32(cboTrainer.SelectedValue) > 0) ? Convert.ToInt32(cboTrainer.SelectedValue) : (int?)null;
            int? slotId = (cboSlot.SelectedValue != null && Convert.ToInt32(cboSlot.SelectedValue) > 0) ? Convert.ToInt32(cboSlot.SelectedValue) : (int?)null;
            string status = (cboStatus.SelectedIndex > 0) ? cboStatus.Text : null;

            try
            {
                _currentSource = _scheduleBll.GetSchedules(date, trainerId, status, null, slotId);
                lblDebug.Text = "Số hồ sơ lấy được: " + _currentSource.Count;

                // Reset Grid một cách sạch sẽ
                dgvSchedules.DataSource = null;
                //dgvSchedules.AutoGenerateColumns = true; // Tạm thời để true để kiểm tra data hiện lên không

                if (_currentSource != null && _currentSource.Count > 0)
                {
                    dgvSchedules.DataSource = _currentSource;
                    dgvSchedules.ClearSelection();
                    dgvSchedules.Rows[0].Selected = true;
                    var firstVisibleColumn = dgvSchedules.Columns.Cast<DataGridViewColumn>()
                             .FirstOrDefault(c => c.Visible);
                    if (firstVisibleColumn != null)
                    {
                        dgvSchedules.CurrentCell = dgvSchedules.Rows[0].Cells[firstVisibleColumn.Index];
                    }
                    UpdateDetailPanel(_currentSource[0]);

                }
                else
                {
                    // CHỈ gọi ClearDetail khi thực sự không có dữ liệu
                    ClearDetail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void SetupGridView()
        {
            dgvSchedules.AutoGenerateColumns = false;
            dgvSchedules.Columns.Clear();
            //ẩn
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ScheduleID", Visible = false });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SlotID", Visible = false });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RegID", Visible = false });
            //hiện
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MemberID_Display",
                HeaderText = "Mã HV",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StartTime",
                HeaderText = "Giờ",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Format = @"hh\:mm" }
            });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrainingDate", HeaderText = "Ngày tập", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MemberName", HeaderText = "Hội viên", Width = 150 });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SlotName", HeaderText = "Lớp/Slot", Width = 120 });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrainerName", HeaderText = "Trainer", Width = 150 });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng thái", Width = 100 });
            dgvSchedules.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "IsMakeup", HeaderText = "Bù?", Width = 50});
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OriginalDate", HeaderText = "Ngày gốc", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }});
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Notes", HeaderText = "Ghi chú", Width = 120 });
        }

        private void ucSchedules_Load(object sender, EventArgs e)
        {
            try
            {
                // Gọi hàm quét lịch quá hạn ngay khi mở app
                _scheduleBll.ProcessExpiredSchedules();
                _scheduleBll.RunMonthlyMaintenance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi cập nhật lịch: " + ex.Message);
            }
            SetupGridView();
            _suppressEvents = true;
            LoadComboboxData(); // Nạp dữ liệu vào các Filter
            dtpDate.Value = DateTime.Today; // Tự động load dữ liệu hôm nay
            _suppressEvents = false;
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearch.Text, out int memberId))
            {
                _currentSource = _scheduleBll.GetSchedules(dtpDate.Value, null, null, memberId);
                dgvSchedules.DataSource = _currentSource;
            }
            else { MessageBox.Show("Vui lòng nhập Member ID là số!"); }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            _suppressEvents = true;

            cboTrainer.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            cboSlot.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
            txtSearch.Clear();

            _suppressEvents = false;

            LoadData();
        }

        private void UpdateStatistics(int regId)
        {
            // Có thể viết thêm 1 hàm trong BLL để lấy thống kê nhanh
            var allSessions = _currentSource.ToList();
            lblTong.Text = allSessions.Count.ToString();
            lblAttended.Text = allSessions.Count(x => x.Status == "Attended").ToString();
            lblAbsent.Text = allSessions.Count(x => x.Status == "Absent").ToString();
        }

        private void ClearDetail()
        {
            lblMemberNameVal.Text = "---";
            lblClassVal.Text = "---";
            lblStatusVal.Text = "---";
            //lblStatTotal.Text = "label1";
            // ... clear các label khác
        }

        private void dgvSchedules_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSchedules.CurrentRow?.DataBoundItem == null) return;
            if (dgvSchedules.CurrentRow?.DataBoundItem is ScheduleViewDTO selected)
            {
                UpdateDetailPanel(selected);
            }
            else
            {               
                ClearDetail();
            }
        }

        private void UpdateDetailPanel(ScheduleViewDTO selected)
        {
            if (selected == null) return;
            lblMemberNameVal.Text = selected.MemberName;
            lblClassVal.Text = selected.SlotName;
            lblDateVal.Text = selected.TrainingDate.ToString("dd/MM/yyyy");
            lblTimeVal.Text = selected.StartTime?.ToString(@"hh\:mm") ?? "--:--";
            lblStatusVal.Text = selected.Status;
            lblMakeupVal.Text = selected.IsMakeup ? selected.OriginalDate?.ToString("dd/MM/yyyy") : "---";

            UpdateStatistics(selected.RegID);
        }

        private void UpdateScheduleStatus(string newStatus)
        {
            if (dgvSchedules.CurrentRow?.DataBoundItem is ScheduleViewDTO selected)
            {
                bool success = _scheduleBll.UpdateSessionStatus(selected.ScheduleID, newStatus, "Cập nhật từ GUI", selected.RegID);
                if (success)
                {
                    MessageBox.Show($"Đã đánh dấu: {newStatus}");
                    LoadData(); // Reload lại lưới
                }
            }
        }

        private void btnAttended_Click(object sender, EventArgs e)
        {
            UpdateScheduleStatus("Attended");
            LoadData();
        }

        private void btnAbsent_Click(object sender, EventArgs e)
        {
            UpdateScheduleStatus("Absent");
            LoadData();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadData();
        }

        private void LoadComboboxData()
        {
            try
            {
                // 1. Load Trainer
                DataTable dtTrainers = _scheduleBll.GetTrainerList();

                // Chèn dòng "Tất cả" vào vị trí đầu tiên (Index 0)
                DataRow drT = dtTrainers.NewRow();
                drT["TRAINERID"] = 0;
                drT["FULLNAME"] = "--- Tất cả Trainer ---";
                dtTrainers.Rows.InsertAt(drT, 0);

                cboTrainer.DataSource = dtTrainers;
                cboTrainer.DisplayMember = "FULLNAME";
                cboTrainer.ValueMember = "TRAINERID";

                // 2. Load Slot (Ca tập)
                // Giả sử bạn để hàm GetSlotsForCombobox ở ScheduleDAL hoặc một DAL tương ứng
                DataTable dtSlots = _scheduleBll.GetSlotList();

                DataRow drS = dtSlots.NewRow();
                drS["SLOTID"] = 0;
                drS["SLOTNAME"] = "--- Tất cả Lớp ---";
                dtSlots.Rows.InsertAt(drS, 0);

                cboSlot.DataSource = dtSlots;
                cboSlot.DisplayMember = "SLOTNAME";
                cboSlot.ValueMember = "SLOTID";

                // 3. Load Trạng thái (Hardcode mảng chuỗi)
                cboStatus.Items.Clear();
                cboStatus.Items.Add("--- Tất cả ---");
                cboStatus.Items.Add("Scheduled");
                cboStatus.Items.Add("Attended");
                cboStatus.Items.Add("Absent");
                cboStatus.Items.Add("Cancelled");
                cboStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách bộ lọc: " + ex.Message);
            }
        }

        private void cboTrainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressEvents) return;
            LoadData();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressEvents) return;
            LoadData();
        }

        private void cboSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressEvents) return;
            LoadData();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (_suppressEvents) return;
            LoadData();
        }

        private void btnAddMakeup_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một buổi tập vắng để đăng ký bù!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedSchedule = dgvSchedules.CurrentRow.DataBoundItem as ScheduleViewDTO;

            if (selectedSchedule == null) return;
            //if (selectedSchedule.Status != "Absent" || selectedSchedule.Status != "Cancel")
            string status = selectedSchedule.Status.Trim();
            string[] allowedStatuses = { "Absent", "Cancel" }; // Danh sách các trạng thái được phép bù

            // Kiểm tra xem status hiện tại có nằm trong danh sách cho phép không
            if (!allowedStatuses.Any(s => s.Equals(status, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Chỉ có thể đăng ký bù cho những buổi tập hội viên đã vắng (Absent) hoặc bị hủy (Cancel)!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (frmSchedules frm = new frmSchedules(selectedSchedule))
            {
                // Hiển thị form dưới dạng Dialog (buộc xử lý xong mới quay lại màn hình chính)
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Nếu lưu thành công (DialogResult.OK), nạp lại dữ liệu để cập nhật Grid
                    LoadData();
                    MessageBox.Show("Hệ thống đã cập nhật lịch tập bù mới.");
                }
            }

        }

        private void btnPostpone_Click(object sender, EventArgs e)
        {
            UpdateScheduleStatus("Cancel");
            LoadData();
        }
    }
}
