using desktopapp_GYM.BLL;
using desktopapp_GYM.DAL;
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
    public partial class ucMemberList : UserControl
    {
        
        MemberBLL bll = new MemberBLL();
        public ucMemberList()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTable dt = bll.GetAllEveryone();
            dgvMembers.DataSource = dt;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            FormatDataGridView();
        }

        private void RefreshDataIfExpirationsFound()
        {
            try
            {
                // 1. Gọi BLL quét Database để cập nhật trạng thái Inactive
                int count = bll.UpdateExpiredStatus();

                // 2. Nếu có ít nhất 1 người bị quá hạn
                if (count > 0)
                {
                    // Load lại dữ liệu mới để Grid hiển thị đúng chữ 'Inactive'
                    LoadData();

                    // Thông báo cho nhân viên biết
                    MessageBox.Show($"Hệ thống đã tự động chuyển {count} hội viên sang 'Inactive' do hết hạn tập!",
                                    "Thông báo định kỳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Tránh làm treo App nếu SQL có vấn đề, chỉ hiển thị lỗi nhẹ
                Console.WriteLine("Lỗi quét hết hạn: " + ex.Message);
            }
        }

        private void SetupAutoComplete()
        {
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            // Lấy toàn bộ tên hội viên để đưa vào danh sách gợi ý
            DataTable dt = bll.GetAllEveryone();
            foreach (DataRow row in dt.Rows)
            {
                // Lưu ý: SQL trả về FULLNAME (in hoa)
                if (row["FULLNAME"] != DBNull.Value)
                    collection.Add(row["FULLNAME"].ToString());
            }

            txtSearch.AutoCompleteCustomSource = collection;
        }



        private void ucMemberList_Load(object sender, EventArgs e)
        {
            LoadData();
            RefreshDataIfExpirationsFound();
            SetupAutoComplete();

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (this.FindForm() is frmMain main)
            {
                main.ShowUc();
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();

        }

        private void FormatDataGridView()
        {
            if (dgvMembers.Columns.Count > 0)
            {
                // Đổi tên cột
                dgvMembers.Columns["ID"].HeaderText = "Mã số";
                dgvMembers.Columns["FULLNAME"].HeaderText = "Họ và Tên";
                dgvMembers.Columns["TYPE"].HeaderText = "Vai trò";
                dgvMembers.Columns["PHONE"].HeaderText = "SĐT";
                dgvMembers.Columns["JOINDATE"].HeaderText = "Ngày tham gia";
                dgvMembers.Columns["REGDATE"].HeaderText = "Ngày đăng kí";
                dgvMembers.Columns["ENDDATE"].HeaderText = "Ngày hết hạn";
                dgvMembers.Columns["TOTALAMOUNT"].HeaderText = "Tổng tiền";
                dgvMembers.Columns["PAYMENTSTATUS"].HeaderText = "Thanh toán";
                dgvMembers.Columns["PACKAGEID"].HeaderText = "Gói đăng kí";
                dgvMembers.Columns["TRAINERID"].HeaderText = "Mã HLV";
                dgvMembers.Columns["STATUS"].HeaderText = "Trạng thái";
                dgvMembers.Columns["GHICHU"].HeaderText = "Ghi chú";

                // Ẩn TRAINERID và PACKAGEID vì đã có GHICHU thể hiện
                //dgvMembers.Columns["TRAINERID"].Visible = false;
                //dgvMembers.Columns["PACKAGEID"].Visible = false;

                // Định dạng ngày
                dgvMembers.Columns["JOINDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvMembers.Columns["REGDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvMembers.Columns["ENDDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Định dạng tiền
                dgvMembers.Columns["TOTALAMOUNT"].DefaultCellStyle.Format = "N0";

                // Tự dãn cột
                dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu trống thì nạp tất cả
                dgvMembers.DataSource = bll.GetAllEveryone();
            }
            else
            {
                // Nếu có chữ thì mới search
                dgvMembers.DataSource = bll.SearchData(keyword);
            }
            FormatDataGridView();
        }

        private void dgvMembers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Kiểm tra hàng dữ liệu hợp lệ
            if (e.RowIndex < 0 || e.RowIndex >= dgvMembers.Rows.Count) return;

            // 2. Kiểm tra cột PAYMENTSTATUS (Tên cột phải khớp với SQL IN HOA bạn đã viết)
            // Lấy dòng hiện tại để kiểm tra dữ liệu
            var row = dgvMembers.Rows[e.RowIndex];
            var typeValue = row.Cells["TYPE"].Value?.ToString().Trim();
            var statusValue = row.Cells["PAYMENTSTATUS"].Value?.ToString().Trim();
            var endDateValue = row.Cells["ENDDATE"].Value;

            if (typeValue == "Member")
            {
                bool isExpired = false;

                // 1. Kiểm tra hết hạn: So sánh ngày hiện tại với ENDDATE
                if (endDateValue != DBNull.Value && endDateValue != null)
                {
                    DateTime endDate = Convert.ToDateTime(endDateValue);
                    if (endDate.Date < DateTime.Now.Date) // Nếu ngày hết hạn nhỏ hơn ngày hôm nay
                    {
                        isExpired = true;
                    }
                }

                // 2. Kiểm tra chưa thanh toán
                bool isUnpaid = (statusValue == "Unpaid" || statusValue == "Chưa thanh toán" || string.IsNullOrEmpty(statusValue));

                // 3. Thực hiện tô màu: Nếu Hết hạn HOẶC Chưa thanh toán thì tô ĐỎ
                if (isExpired || isUnpaid)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.DefaultCellStyle.Font = new Font(dgvMembers.Font, FontStyle.Bold);

                    // (Tùy chọn) Nếu muốn biết lý do đỏ, Huy có thể gán vào ToolTip
                    row.Cells["ENDDATE"].ToolTipText = isExpired ? "Gói tập đã hết hạn!" : "";
                }
                else if (statusValue == "Paid" || statusValue == "Completed")
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    row.DefaultCellStyle.Font = new Font(dgvMembers.Font, FontStyle.Regular);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DataGridViewRow row = dgvMembers.CurrentRow;
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            string targetRole = row.Cells["TYPE"].Value.ToString();
            string name = row.Cells["FULLNAME"].Value.ToString();

            var result = MessageBox.Show($"Bạn có chắc muốn xóa {targetRole}: {name}?",
                                 "Xác nhận xóa",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Gọi BLL thực hiện xóa (BLL sẽ gọi DAL.DeleteRecord)
                if (bll.DeleteData(id, targetRole))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    SetupAutoComplete();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmChange Add = new frmChange();
            if (Add.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                RefreshDataIfExpirationsFound();
                SetupAutoComplete();
            }
        }

        private void btnEdits_Click(object sender, EventArgs e)
        {

            DataGridViewRow row = dgvMembers.CurrentRow;
            if (row == null) return;
            frmChange Edit = new frmChange(row);
            if (Edit.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                RefreshDataIfExpirationsFound();
            }
        }

        private void dgvMembers_SelectionChanged(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dòng nào đang được chọn không
            if (dgvMembers.CurrentRow != null)
            {
                // 2. Lấy Role của dòng đó (Huy thay "TYPE" bằng tên cột chứa Role trong Grid của Huy)
                string selectedRole = dgvMembers.CurrentRow.Cells["TYPE"].Value?.ToString();

                // 3. Danh sách các Role đặc biệt cần khóa nút
                string[] specialRoles = { "Admin", "Manager", "Receptionist" };

                // 4. Nếu Role nằm trong danh sách đặc biệt -> Khóa nút Edit/Delete
                if (specialRoles.Contains(selectedRole))
                {
                    btnAdd.Enabled = false;
                    btnEdits.Enabled = false;
                    btnDelete.Enabled = false;

                }
                else
                {
                    // Nếu là Member hoặc Trainer -> Mở nút
                    btnAdd.Enabled = true;
                    btnEdits.Enabled = true;
                    btnDelete.Enabled = true;

                }
            }
            else
            {
                // Nếu không chọn dòng nào (Grid trống) -> Tắt nút luôn cho an toàn
                btnEdits.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một người dùng trong danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = (DataRowView)dgvMembers.CurrentRow.DataBoundItem;
            string type = row["TYPE"].ToString();

            string info;

            if (type == "Member")
            {
                info = $"--- THÔNG TIN HỘI VIÊN ---\n\n" +
                       $"Mã số:         {row["ID"]}\n" +
                       $"Họ tên:        {row["FULLNAME"]}\n" +
                       $"SĐT:           {row["PHONE"]}\n" +
                       $"Trạng thái:    {row["STATUS"]}\n" +
                       $"Ngày tham gia: {(row["JOINDATE"] == DBNull.Value ? "—" : Convert.ToDateTime(row["JOINDATE"]).ToString("dd/MM/yyyy"))}\n" +
                       $"Gói đăng ký:   {(row["PACKAGEID"] == DBNull.Value ? "—" : row["PACKAGEID"].ToString())}\n" +
                       $"Ngày đăng ký:  {(row["REGDATE"] == DBNull.Value ? "—" : Convert.ToDateTime(row["REGDATE"]).ToString("dd/MM/yyyy"))}\n" +
                       $"Ngày hết hạn:  {(row["ENDDATE"] == DBNull.Value ? "—" : Convert.ToDateTime(row["ENDDATE"]).ToString("dd/MM/yyyy"))}\n" +
                       $"HLV phụ trách: {row["GHICHU"]}\n" +
                       $"Tổng tiền:     {Convert.ToDecimal(row["TOTALAMOUNT"]).ToString("N0")} VNĐ\n" +
                       $"Thanh toán:    {row["PAYMENTSTATUS"]}";
            }
            else if (type == "Trainer")
            {
                info = $"--- THÔNG TIN HUẤN LUYỆN VIÊN ---\n\n" +
                       $"Mã số:      {row["ID"]}\n" +
                       $"Họ tên:     {row["FULLNAME"]}\n" +
                       $"SĐT:        {row["PHONE"]}\n" +
                       $"Trạng thái: {row["STATUS"]}\n" +
                       $"Chuyên môn: {row["GHICHU"]}";
            }
            else
            {
                info = $"--- THÔNG TIN TÀI KHOẢN ---\n\n" +
                       $"Mã số:   {row["ID"]}\n" +
                       $"Tên đăng nhập: {row["FULLNAME"]}\n" +
                       $"Vai trò: {row["TYPE"]}";
            }

            MessageBox.Show(info, "Chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}