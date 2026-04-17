using desktopapp_GYM.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopapp_GYM.GUI
{
    public partial class frmGuest : Form
    {
        UserBLL userBLL = new UserBLL();
        public frmGuest()
        {
            InitializeComponent();
        }


        private void btnLoginGuest_Click(object sender, EventArgs e)
        {
            using (frmLogin loginForm = new frmLogin())
            {
                // Hiển thị Form Login lên và chờ người dùng thao tác
                // Nếu người dùng đăng nhập thành công (trả về DialogResult.OK ở Bước 1)
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // 1. Ẩn trang Guest hiện tại đi
                    this.Hide();

                    // 2. Khởi tạo trang chính (frmMain) dành cho nhân viên/admin
                    frmMain mainForm = new frmMain();

                    // 3. Hiển thị trang chính
                    mainForm.ShowDialog();

                    // 4. Khi người dùng tắt trang chính (Đăng xuất), hiện lại trang Guest
                    this.Show();
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ShowUc()
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel1.BringToFront();
            flowLayoutPanel1.Dock = DockStyle.Fill;

            // 2. Quét qua tất cả các UC con nằm trong flowLayoutPanel để bắt chúng cập nhật
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                // Kiểm tra xem nó có phải là UC thống kê của Huy không
                if (ctrl is ucPackagePrice ucPackagePrice1)
                {
                    ucPackagePrice1.RefreshData();
                }
                else if (ctrl is ucTrainerStatus ucTrainerStatus1)
                {
                    ucTrainerStatus1.RefreshData(); // Giả sử Huy có hàm RefreshData trong UC cảnh báo
                }
                else if (ctrl is ucRevenueChart ucRevenueChart1)
                {
                    ucRevenueChart1.RefreshData(); // Giả sử Huy có hàm RefreshData trong UC cảnh báo
                }
            }
        }

        public void ShowDetail(UserControl uc)
        {
            // 1. Ẩn cái Dashboard đi cho khuất mắt
            flowLayoutPanel1.Visible = false;

            // 2. Dọn dẹp pnlContent trước khi thêm cái mới (tránh chồng chất)
            foreach (Control ctrl in panelContent.Controls)
            {
                if (ctrl != flowLayoutPanel1)
                {
                    panelContent.Controls.Remove(ctrl);
                }
            }

            // 3. Thêm UC chi tiết vào pnlContent
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowDetail(new ucPackageDetails());
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            ShowUc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowDetail(new ucTrainerList());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ShowDetail(new ucSchedules());
        }
    }
}
