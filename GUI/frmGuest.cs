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
    }
}
