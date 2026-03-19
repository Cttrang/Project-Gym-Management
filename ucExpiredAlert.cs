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
    public partial class ucExpiredAlert : ucBaseCard
    {
        MemberDal dalMember = new MemberDal();
        public ucExpiredAlert()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
            //try
            //{
            MemberDal dal = new MemberDal();
            DataTable dt = dal.GetExpiringMembers();

            // Xóa sạch nguồn cũ trước khi nạp mới
            dtExpired.DataSource = null;
            dtExpired.DataSource = dt;

            // Label thông báo đơn giản
            lblThongBao.Text = "Có " + dt.Rows.Count + " hội viên cần lưu ý";
            lblThongBao.ForeColor = Color.Red;

            //    if (dt.Rows.Count > 0)
            //    {
            //        dtExpired.Columns["FullName"].HeaderText = "Hội Viên";
            //        dtExpired.Columns["EndDate"].HeaderText = "Ngày Hết Hạn";
            //        dtExpired.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //        dtExpired.Columns["DaysStatus"].HeaderText = "Tình Trạng";

            //        foreach (DataGridViewRow row in dtExpired.Rows)
            //        {
            //            if (row.IsNewRow || row.Cells["DaysStatus"].Value == null) continue;

            //            // Vì SQL đã trả về chuỗi, ta chỉ cần parse để kiểm tra màu
            //            int days = int.Parse(row.Cells["DaysStatus"].Value.ToString());

            //            if (days < 0)
            //            {
            //                row.Cells["DaysStatus"].Value = "Quá hạn " + Math.Abs(days) + " ngày";
            //                row.DefaultCellStyle.ForeColor = Color.Red;
            //            }
            //            else if (days == 0)
            //            {
            //                row.Cells["DaysStatus"].Value = "Hết hạn hôm nay";
            //                row.DefaultCellStyle.ForeColor = Color.OrangeRed;
            //            }
            //            else
            //            {
            //                row.Cells["DaysStatus"].Value = "Còn " + days + " ngày";
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Nếu vẫn lỗi, nó sẽ hiện thông báo ở đây thay vì văng app
            //    MessageBox.Show("Lỗi hiển thị: " + ex.Message);
            //}
            dtExpired.Columns["FullName"].HeaderText = "Hội Viên";
            dtExpired.Columns["RegDate"].HeaderText = "Ngày Đăng Ký";
            dtExpired.Columns["EndDate"].HeaderText = "Ngày Hết Hạn";

            // Định dạng hiển thị ngày tháng
            dtExpired.Columns["RegDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtExpired.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // 4. So sánh ngày để tô đỏ (Logic chính của bài tập)
            foreach (DataGridViewRow row in dtExpired.Rows)
            {
                // Bỏ qua dòng trống cuối cùng
                if (row.IsNewRow || row.Cells["EndDate"].Value == null) continue;

                // Lấy ngày hết hạn từ ô ra để so sánh
                DateTime ngayHetHan = Convert.ToDateTime(row.Cells["EndDate"].Value);

                // Nếu ngày hết hạn nhỏ hơn ngày hiện tại (đã hết hạn)
                if (ngayHetHan.Date < DateTime.Now.Date)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;   // Nền đỏ
                    row.DefaultCellStyle.ForeColor = Color.White; // Chữ trắng cho dễ đọc
                }
            }
        }
    }
}
