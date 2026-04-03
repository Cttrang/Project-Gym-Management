using desktopapp_GYM.BLL;
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
    public partial class ucTimeSlotRegis : UserControl
    {
        TimeslotBLL bll = new TimeslotBLL();
        List<TimeslotDTO> fullList = new List<TimeslotDTO>();
        public ucTimeSlotRegis()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            fullList = bll.GetAll();
            dgvTimeslots.DataSource = null;
            dgvTimeslots.DataSource = fullList;
            FormatGrid();
            SetupAutoComplete();
        }

        private void FormatGrid()
        {
            if (dgvTimeslots.Columns.Count == 0) return;

            // Ẩn các cột ID kỹ thuật
            dgvTimeslots.Columns["SlotID"].Visible = false;
            dgvTimeslots.Columns["TrainerID"].Visible = false;
            dgvTimeslots.Columns["PackageID"].Visible = false;

            dgvTimeslots.Columns["SlotName"].HeaderText = "Tên lớp";
            dgvTimeslots.Columns["TrainerName"].HeaderText = "Huấn luyện viên";
            dgvTimeslots.Columns["PackageName"].HeaderText = "Gói tập";
            dgvTimeslots.Columns["DayOfWeek"].HeaderText = "Thứ";
            dgvTimeslots.Columns["StartTime"].HeaderText = "Giờ bắt đầu";
            dgvTimeslots.Columns["EndTime"].HeaderText = "Giờ kết thúc";
            dgvTimeslots.Columns["MaxMembers"].HeaderText = "Tối đa";
            dgvTimeslots.Columns["CurrentCount"].HeaderText = "Đã đăng ký";
            dgvTimeslots.Columns["Status"].HeaderText = "Trạng thái";

            dgvTimeslots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupAutoComplete()
        {
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var col = new System.Windows.Forms.AutoCompleteStringCollection();
            foreach (var ts in fullList)
            {
                if (!string.IsNullOrEmpty(ts.SlotName)) col.Add(ts.SlotName);
                if (!string.IsNullOrEmpty(ts.TrainerName)) col.Add(ts.TrainerName);
                if (!string.IsNullOrEmpty(ts.PackageName)) col.Add(ts.PackageName);
            }
            txtSearch.AutoCompleteCustomSource = col;
        }

        private void ApplyRolePermissions()
        {
            string role = Session.CurrentRole;
            if (role == "Receptionist")
                btnAdd.Enabled = btnEdits.Enabled = btnDelete.Enabled = false;
            else if (role == "Manager")
            {
                btnAdd.Enabled = btnEdits.Enabled = true;
                btnDelete.Enabled = false;
            }
            else
                btnAdd.Enabled = btnEdits.Enabled = btnDelete.Enabled = true;
        }

        private void ucTimeslotRegis_Load(object sender, EventArgs e)
        {
            if (this.FindForm()?.Name == "frmGuest")
                btnAdd.Visible = btnEdits.Visible = btnDelete.Visible = false;
            LoadData();
            ApplyRolePermissions();
        }

        private TimeslotDTO GetSelected()
        {
            if (dgvTimeslots.CurrentRow == null) return null;
            return (TimeslotDTO)dgvTimeslots.CurrentRow.DataBoundItem;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //var frm = new frmTimeslotEdits(new TimeslotDTO(), true);
            //if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }
        private void btnEdits_Click(object sender, EventArgs e)
        {
            //var selected = GetSelected();
            //if (selected == null)
            //{
            //    MessageBox.Show("Vui lòng chọn một khung giờ!",
            //        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //var frm = new frmTimeslotEdits(selected, false);
            //if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = GetSelected();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một khung giờ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(
                $"Xác nhận xóa khung giờ: {selected.SlotName}?",
                "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                try
                {
                    if (bll.Delete(selected)) { MessageBox.Show("Xóa thành công!"); LoadData(); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Không thể xóa",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            var ts = GetSelected();
            if (ts == null) return;
            string info =
                $"--- THÔNG TIN KHUNG GIỜ ---\n\n" +
                $"Tên lớp:    {ts.SlotName}\n" +
                $"HLV:        {ts.TrainerName}\n" +
                $"Gói tập:    {ts.PackageName}\n" +
                $"Thứ:        {ts.DayOfWeek}\n" +
                $"Giờ:        {ts.StartTime} - {ts.EndTime}\n" +
                $"Tối đa:     {ts.MaxMembers} học viên\n" +
                $"Đã đăng ký: {ts.CurrentCount} học viên\n" +
                $"Trạng thái: {ts.Status}";
            MessageBox.Show(info, "Chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Form parent = this.FindForm();
            if (parent is frmMain main) main.ShowUc();
            else if (parent is frmGuest guest) guest.ShowUc();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dgvTimeslots.DataSource = null;
            dgvTimeslots.DataSource = fullList;
            FormatGrid();
            txtSearch.Focus();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string key = txtSearch.Text.ToLower().Trim();
            dgvTimeslots.DataSource = fullList.Where(ts =>
                ts.SlotName.ToLower().Contains(key) ||
                ts.TrainerName.ToLower().Contains(key) ||
                ts.PackageName.ToLower().Contains(key) ||
                ts.DayOfWeek.ToLower().Contains(key)
            ).ToList();
            FormatGrid();
        }

        private void dgvTimeslots_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) 
        {
            if (e.RowIndex < 0) return;
            var ts = (TimeslotDTO)dgvTimeslots.Rows[e.RowIndex].DataBoundItem;
            if (ts == null) return;

            if (ts.Status == "Inactive")
                dgvTimeslots.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
            else if (ts.CurrentCount >= ts.MaxMembers)
                dgvTimeslots.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            else
                dgvTimeslots.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkGreen;
        }

        private void dgvTimeslots_SelectionChanged(object sender, EventArgs e) { }

    }
}
