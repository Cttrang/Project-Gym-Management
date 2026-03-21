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
        MemberDal dal = new MemberDal();
        MemberBLL bll = new MemberBLL();
        public ucMemberList()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvMembers.DataSource = bll.GetAllEveryone();
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
            SetupAutoComplete();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (this.FindForm() is frmMain mainForm)
            {
                // Quay lại Dashboard (Giả sử bạn đã kéo ucDashBoard vào frmMain)
                // Hoặc đơn giản là gọi lại hàm hiện Dashboard cũ
                mainForm.ShowDashboard();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim();
            dgvMembers.DataSource = bll.SearchData(key);
            txtSearch.Text = "";
            FormatDataGridView();
        }

        private void btnSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadData();
        }

        private void FormatDataGridView()
        {
            if (dgvMembers.Columns.Count > 0)
            {
                // Đổi tên cột IN HOA từ SQL sang Tiếng Việt có dấu
                dgvMembers.Columns["ID"].HeaderText = "Mã số";
                dgvMembers.Columns["FULLNAME"].HeaderText = "Họ và Tên";
                dgvMembers.Columns["TYPE"].HeaderText = "Vai trò";
                dgvMembers.Columns["PHONE"].HeaderText = "SĐT";
                dgvMembers.Columns["JOINDATE"].HeaderText = "Ngày tham gia";
                dgvMembers.Columns["REGID"].HeaderText = "Mã đăng kí";
                dgvMembers.Columns["REGDATE"].HeaderText = "Ngày đăng kí";
                dgvMembers.Columns["ENDDATE"].HeaderText = "Ngày hết hạn";
                dgvMembers.Columns["TOTALAMOUNT"].HeaderText = "Tổng tiền";
                dgvMembers.Columns["PAYMENTSTATUS"].HeaderText = "Thanh toán";

                // Định dạng ngày tháng
                dgvMembers.Columns["JOINDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvMembers.Columns["REGDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvMembers.Columns["ENDDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Định dạng tiền tệ (Ví dụ: 500.000)
                dgvMembers.Columns["TOTALAMOUNT"].DefaultCellStyle.Format = "N0";

                // Tự động dãn cột chiếm hết chiều ngang
                dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Tùy chọn: Ẩn bớt REGID nếu bạn thấy quá chật
                // dgvMembers.Columns["REGID"].Visible = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvMembers.DataSource = bll.SearchData(txtSearch.Text);
            FormatDataGridView();
        }

        private void dgvMembers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Kiểm tra hàng dữ liệu hợp lệ
            if (e.RowIndex < 0 || e.RowIndex >= dgvMembers.Rows.Count) return;

            // 2. Kiểm tra cột PAYMENTSTATUS (Tên cột phải khớp với SQL IN HOA bạn đã viết)
            if (dgvMembers.Columns[e.ColumnIndex].Name == "PAYMENTSTATUS")
            {
                var statusValue = dgvMembers.Rows[e.RowIndex].Cells["PAYMENTSTATUS"].Value;
                var typeValue = dgvMembers.Rows[e.RowIndex].Cells["TYPE"].Value;

                if (statusValue != null && typeValue != null)
                {
                    string status = statusValue.ToString().Trim();
                    string type = typeValue.ToString().Trim();

                    // 3. Chỉ xét những ai là 'Member' và trạng thái chưa thanh toán
                    // Dựa trên bảng REGISTRATIONS, nếu chưa nạp tiền thường là 'Unpaid' hoặc trống
                    if (type == "Member" && (status == "Unpaid" || status == "Chưa thanh toán" || string.IsNullOrEmpty(status)))
                    {
                        // TÔ MÀU CHỮ ĐỎ cho cả dòng
                        dgvMembers.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;

                        // Bạn có thể làm chữ đậm lên để dễ chú ý hơn
                        dgvMembers.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(dgvMembers.Font, FontStyle.Bold);
                    }
                    else if (status == "Paid" || status == "Completed")
                    {
                        // Với những dòng đã thanh toán, để chữ màu xanh đậm (DeepGreen) cho dễ phân biệt
                        dgvMembers.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                        dgvMembers.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(dgvMembers.Font, FontStyle.Regular);
                    }
                    else
                    {
                        // Reset về mặc định cho HLV hoặc Nhân viên (những người không có status thanh toán)
                        dgvMembers.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow == null) return;

            DataGridViewRow row = dgvMembers.CurrentRow;
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            string targetRole = row.Cells["TYPE"].Value.ToString();

            if (bll.HasPermission(Session.CurrentRole, targetRole, "Delete"))
            {
                var result = MessageBox.Show("Xóa dữ liệu này sẽ không thể khôi phục. Tiếp tục?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (dal.DeleteRecord(id, targetRole))
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Quyền hạn của bạn không đủ để thực hiện thao tác xóa này.");
            }
        }
    }
}
