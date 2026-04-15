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
        public ucSchedules()
        {
            InitializeComponent();
            dtpDate.ValueChanged += (s, e) => LoadData();
            cboTrainer.SelectedIndexChanged += (s, e) => LoadData();
            cboStatus.SelectedIndexChanged += (s, e) => LoadData();
            cboSlot.SelectedIndexChanged += (s, e) => LoadData();
        }

        public void LoadData()
        {
            DateTime date = dtpDate.Value;
            int? trainerId = (cboTrainer.SelectedValue is int tid) ? tid : (int?)null;
            string status = (cboStatus.SelectedIndex > 0) ? cboStatus.Text : null;
            int? slotId = (cboSlot.SelectedValue is int sid) ? sid : (int?)null;

            // Gọi BLL lấy dữ liệu
            _currentSource = _scheduleBll.GetSchedules(date, trainerId, status);

            // Nếu bạn muốn lọc thêm Slot ở GUI (nếu DAL chưa làm)
            var displayList = _currentSource;
            if (slotId.HasValue) displayList = displayList.Where(x => x.SlotID == slotId).ToList();

            dgvSchedules.DataSource = null;
            dgvSchedules.DataSource = displayList;

            ClearDetail();
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
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ScheduleID", Visible = false });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrainingDate", HeaderText = "Ngày tập", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MemberName", HeaderText = "Hội viên", Width = 150 });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SlotName", HeaderText = "Lớp/Slot", Width = 120 });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrainerName", HeaderText = "Trainer", Width = 150 });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng thái", Width = 100 });
        }

        private void ucSchedules_Load(object sender, EventArgs e)
        {
            SetupGridView();
            LoadComboboxData(); // Nạp dữ liệu vào các Filter
            dtpDate.Value = DateTime.Today; // Tự động load dữ liệu hôm nay
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
            cboTrainer.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            cboSlot.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
            txtSearch.Clear();
            LoadData();
        }

        private void UpdateStatistics(int regId)
        {
            // Có thể viết thêm 1 hàm trong BLL để lấy thống kê nhanh
            var allSessions = _currentSource.Where(x => x.RegID == regId).ToList();
            lblStatTotal.Text = allSessions.Count.ToString();
            lblStatAttended.Text = allSessions.Count(x => x.Status == "Completed").ToString();
            lblStatAbsent.Text = allSessions.Count(x => x.Status == "Absent").ToString();
        }

        private void ClearDetail()
        {
            lblMemberNameVal.Text = "---";
            lblClassVal.Text = "---";
            lblStatusVal.Text = "---";
            lblStatTotal.Text = "label1";
            // ... clear các label khác
        }

        private void dgvSchedules_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSchedules.CurrentRow?.DataBoundItem is ScheduleViewDTO selected)
            {
                lblMemberNameVal.Text = selected.MemberName;
                lblClassVal.Text = selected.SlotName;
                lblDateVal.Text = selected.TrainingDate.ToString("dd/MM/yyyy");
                lblTimeVal.Text = selected.StartTime?.ToString(@"hh\:mm") ?? "--:--";
                lblStatusVal.Text = selected.Status;
                lblMakeupVal.Text = selected.IsMakeup ? selected.OriginalDate?.ToString("dd/MM/yyyy") : "---";

                // Cập nhật thống kê dựa trên RegID của dòng đang chọn
                UpdateStatistics(selected.RegID);
            }
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
            UpdateScheduleStatus("Completed");
        }

        private void btnAbsent_Click(object sender, EventArgs e)
        {
            UpdateScheduleStatus("Absent");
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
                TrainerDAL trainerDal = new TrainerDAL();
                DataTable dtTrainers = trainerDal.GetTrainersForCombobox();

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
                DataTable dtSlots = new ScheduleDAL().GetSlotsForCombobox();

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
                cboStatus.Items.Add("Completed");
                cboStatus.Items.Add("Absent");
                cboStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách bộ lọc: " + ex.Message);
            }
        }
    }
}
