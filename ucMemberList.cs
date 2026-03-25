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
            DataTable dt = bll.GetAllEveryone();
            dgvMembers.DataSource = dt;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            FormatDataGridView();
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
                dgvMembers.Columns["PACKAGEID"].HeaderText = "Gói đăng kí";
                dgvMembers.Columns["TRAINERID"].HeaderText = "Mã HLV";

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
                SetupAutoComplete();
            }
        }

        private void btnEdits_Click(object sender, EventArgs e)
        {
            
            DataGridViewRow row = dgvMembers.CurrentRow;
            frmChange Edit = new frmChange(row);
            if (Edit.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                
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
                    btnEdits.Enabled = false;
                    btnDelete.Enabled = false;
                    
                }
                else
                {
                    // Nếu là Member hoặc Trainer -> Mở nút
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
            // 1. Kiểm tra xem có dòng nào đang được chọn không
            if (dgvMembers.CurrentRow != null)
            {
                // 2. Lấy dữ liệu từ dòng đang chọn (Vì dgvMembers dùng DataTable nên ép về DataRowView)
                var row = (DataRowView)dgvMembers.CurrentRow.DataBoundItem;

                // 3. Chuẩn bị nội dung hiển thị (Lấy đúng tên cột trong SQL/DataTable của Huy)
                string info = $"--- THÔNG TIN CHI TIẾT ---\n\n" +
                              $"Mã số: {row["ID"]}\n" +
                              $"Họ tên: {row["FULLNAME"]}\n" +
                              $"Vai trò: {row["TYPE"]}\n" +
                              $"SĐT: {row["PHONE"]}\n" +
                              $"Ngày tham gia: {Convert.ToDateTime(row["JOINDATE"]):dd/MM/yyyy}\n" +
                              $"Gói đăng ký: {row["PACKAGEID"]}\n" +
                              $"Tổng tiền: {Convert.ToDecimal(row["TOTALAMOUNT"]).ToString("N0")} VNĐ\n" +
                              $"Thanh toán: {row["PAYMENTSTATUS"]}";

                // 4. Hiển thị lên MessageBox
                MessageBox.Show(info, "Chi tiết hội viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một người dùng trong danh sách để xem chi tiết!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
