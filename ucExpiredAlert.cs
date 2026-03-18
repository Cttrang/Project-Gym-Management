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
            try
            {
                MemberDal dal = new MemberDal();
                DataTable dt = dal.GetExpiringMembers();

                // 1. Gán dữ liệu (Reset trước để tránh lỗi render giao diện)
                dtExpired.DataSource = null;
                dtExpired.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                {
                    // 2. Định dạng tiêu đề và kích thước cột
                    if (dtExpired.Columns.Contains("FullName"))
                    {
                        dtExpired.Columns["FullName"].HeaderText = "Hội Viên";
                        dtExpired.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    if (dtExpired.Columns.Contains("EndDate"))
                    {
                        dtExpired.Columns["EndDate"].HeaderText = "Ngày Hết Hạn";
                        dtExpired.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dtExpired.Columns["EndDate"].Width = 120;
                    }

                    // 3. Xử lý logic thông báo và tô màu từng dòng
                    foreach (DataGridViewRow row in dtExpired.Rows)
                    {
                        if (row.Cells["EndDate"].Value != null)
                        {
                            DateTime expiryDate = Convert.ToDateTime(row.Cells["EndDate"].Value);
                            TimeSpan logicTime = expiryDate.Date - DateTime.Now.Date;
                            int daysLeft = logicTime.Days;

                            // Tô màu đỏ cho những ai đã hết hạn hoặc hết hạn hôm nay (daysLeft <= 0)
                            if (daysLeft <= 0)
                            {
                                row.DefaultCellStyle.ForeColor = Color.Red;
                                row.DefaultCellStyle.SelectionForeColor = Color.Red;
                                row.DefaultCellStyle.Font = new Font(dtExpired.Font, FontStyle.Bold);

                                // Hiển thị Tooltip khi rê chuột vào để báo chính xác
                                row.Cells["EndDate"].ToolTipText = daysLeft == 0 ? "Hết hạn hôm nay!" : $"Đã quá hạn {Math.Abs(daysLeft)} ngày!";
                            }
                            else
                            {
                                row.Cells["EndDate"].ToolTipText = $"Còn {daysLeft} ngày nữa là hết hạn.";
                            }
                        }
                    }
                }

                // 4. Cập nhật nhãn tiêu đề (nếu bạn có Label phía trên bảng)
                // lblTitle.Text = $"DANH SÁCH CẢNH BÁO ({dt.Rows.Count} hội viên)";

                dtExpired.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
