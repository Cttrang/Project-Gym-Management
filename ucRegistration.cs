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
    public partial class ucRegistration : UserControl
    {
        private readonly RegistrationBLL bll = new RegistrationBLL();
        private List<RegistrationDTO> fullList = new List<RegistrationDTO>();

        public ucRegistration()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            fullList = bll.GetAll();
            dgvRegistrations.DataSource = null;
            dgvRegistrations.DataSource = fullList;
            FormatGrid();
            SetupAutoComplete();
        }

        private void FormatGrid()
        {
            if (dgvRegistrations.Columns.Count == 0) return;

            // Ẩn cột không cần hiển thị trên grid
            var hideCols = new[]
            {
                "MemberID", "PackageID", "TrainerID",
                "SelectedSlotIDs",
                "OriginalPrice", "DiscountAmount",
                "SessionsTotal", "SessionsLeft",
                "Notes"
            };
            foreach (var col in hideCols)
                if (dgvRegistrations.Columns.Contains(col))
                    dgvRegistrations.Columns[col].Visible = false;

            var headers = new Dictionary<string, string>
            {
                ["RegID"] = "Mã ĐK",
                ["MemberName"] = "Hội viên",
                ["PackageName"] = "Gói tập",
                ["TrainerName"] = "Huấn luyện viên",
                ["RegDate"] = "Ngày đăng ký",
                ["EndDate"] = "Ngày hết hạn",
                ["TotalAmount"] = "Tổng tiền",
                ["PaymentStatus"] = "Thanh toán",
                ["IsActive"] = "Còn hiệu lực",
                ["SlotSummary"] = "Lịch học"
            };
            foreach (var kv in headers)
                if (dgvRegistrations.Columns.Contains(kv.Key))
                    dgvRegistrations.Columns[kv.Key].HeaderText = kv.Value;

            if (dgvRegistrations.Columns.Contains("TotalAmount"))
                dgvRegistrations.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";

            dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupAutoComplete()
        {
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var collection = new AutoCompleteStringCollection();
            if (fullList != null)
            {
                foreach (var reg in fullList)
                {
                    if (!string.IsNullOrEmpty(reg.MemberName))
                        collection.Add(reg.MemberName);
                    if (!string.IsNullOrEmpty(reg.PackageName) && !collection.Contains(reg.PackageName))
                        collection.Add(reg.PackageName);
                }
            }
            txtSearch.AutoCompleteCustomSource = collection;
        }

        private void ucRegistration_Load(object sender, EventArgs e)
        {
            LoadData();
            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            string role = Session.CurrentRole;

            if (role == "Receptionist")
            {
                btnAdd.Enabled = btnEdits.Enabled = btnDelete.Enabled = false;
            }
            else if (role == "Manager")
            {
                btnAdd.Enabled = btnEdits.Enabled = true;
                btnDelete.Enabled = false;
            }
            else // Admin
            {
                btnAdd.Enabled = btnEdits.Enabled = btnDelete.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmRegistration frm = new frmRegistration(/*new RegistrationDTO(), true*/);
            //if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }
        private void btnEdits_Click(object sender, EventArgs e)
        {
            //if (dgvRegistrations.CurrentRow == null) return;
            //var selected = (RegistrationDTO)dgvRegistrations.CurrentRow.DataBoundItem;
            //frmRegistration frm = new frmRegistration(selected, false);
            //if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.CurrentRow == null) return;
            var selected = (RegistrationDTO)dgvRegistrations.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Xác nhận xóa đăng ký của: {selected.MemberName}?",
                "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (bll.Delete(selected.RegID))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đăng ký trong danh sách!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var reg = (RegistrationDTO)dgvRegistrations.CurrentRow.DataBoundItem;
            string info = $"--- THÔNG TIN ĐĂNG KÝ ---\n\n" +
                          $"Mã đăng ký  : {reg.RegID}\n" +
                          $"Hội viên    : {reg.MemberName}\n" +
                          $"Gói tập     : {reg.PackageName}\n" +
                          $"HLV         : {(string.IsNullOrEmpty(reg.TrainerName) ? "Không có" : reg.TrainerName)}\n" +
                          $"Ngày ĐK     : {reg.RegDate:dd/MM/yyyy}\n" +
                          $"Hết hạn     : {reg.EndDate:dd/MM/yyyy}\n" +
                          $"Lịch học    : {reg.SlotSummary}\n" +
                          $"Giá gốc     : {reg.OriginalPrice:N0} VNĐ\n" +
                          $"Giảm giá    : {reg.DiscountAmount:N0} VNĐ\n" +
                          $"Tổng tiền   : {reg.TotalAmount:N0} VNĐ\n" +
                          $"Thanh toán  : {reg.PaymentStatus}\n" +
                          $"Số buổi     : {reg.SessionsLeft}/{reg.SessionsTotal}\n" +
                          $"Ghi chú     : {(string.IsNullOrEmpty(reg.Notes) ? "Không có" : reg.Notes)}\n" +
                          $"Trạng thái  : {(reg.IsActive ? "Đang hoạt động" : "Đã hết hạn")}";

            MessageBox.Show(info, "Chi tiết đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dgvRegistrations.DataSource = null;
            dgvRegistrations.DataSource = fullList;
            FormatGrid();
            txtSearch.Focus();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string key = txtSearch.Text.ToLower().Trim();
            dgvRegistrations.DataSource = fullList.Where(r =>
                r.MemberName.ToLower().Contains(key) ||
                r.PackageName.ToLower().Contains(key) ||
                (!string.IsNullOrEmpty(r.TrainerName) && r.TrainerName.ToLower().Contains(key)) ||
                (!string.IsNullOrEmpty(r.SlotSummary) && r.SlotSummary.ToLower().Contains(key))
            ).ToList();
        }

        private void dgvRegistration_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) 
        {
            
        }

        private void dgvRegistration_SelectionChanged(object sender, EventArgs e) { }

    }
}
