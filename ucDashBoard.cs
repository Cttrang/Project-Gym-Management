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
    public partial class ucDashBoard : UserControl
    {
        public ucDashBoard()
        {
            InitializeComponent();
        }
        public void InitDashboard(string role)
        {
            // 1. Phân quyền hiển thị Card ngay tại đây
            // Giả sử: Lễ tân không được xem biểu đồ doanh thu
            if (role == "Receptionist")
            {
                ucRevenueChart1.Visible = false;
            }
            else
            {
                ucRevenueChart1.Visible = true;
            }

            // 2. Duyệt qua tất cả các Card nằm trong FlowLayoutPanel
            foreach (Control c in flpDashBoard.Controls)
            {
                if (c is ucBaseCard card)
                {
                    // Chỉ kích hoạt nếu Card đang hiển thị
                    if (card.Visible)
                    {
                        card.StartEffects(); // Bật Timer hiện nút Pin
                        card.RefreshData();  // Nạp dữ liệu mới từ DB
                    }
                }
            }

            // 3. Ép FlowLayoutPanel sắp xếp lại các nút (Tránh lỗ hổng khi ẩn Card)
            flpDashBoard.ResumeLayout();
        }

        private void ucRevenueChart1_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpDashBoard.Controls)
            {
                if (ctrl is UserControl uc)
                {
                    uc.Width = flpDashBoard.ClientSize.Width - 25;
                }
            }
        }

        private void ucDashBoard_Resize(object sender, EventArgs e)
        {
        
        }

        private void flpDashBoard_Resize(object sender, EventArgs e)
        {
            // Tạm dừng vẽ để tránh giật lag khi resize
            flpDashBoard.SuspendLayout();

            foreach (Control card in flpDashBoard.Controls)
            {
                if (card is UserControl)
                {
                    // Ép chiều ngang của Card bằng chiều ngang của Panel (trừ đi khoảng hở thanh cuộn)
                    // Nếu bạn muốn 2 Card trên 1 hàng thì chia 2, nhưng ở đây nên để 1 Card/1 hàng cho chắc chắn
                    card.Width = flpDashBoard.ClientSize.Width - 25;

                    // Ép các control bên trong Card (Chart/Grid) phải tính toán lại
                    card.PerformLayout();
                }
            }

            flpDashBoard.ResumeLayout();
        }
    }
    
    
}
