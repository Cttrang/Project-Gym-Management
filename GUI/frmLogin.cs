using desktopapp_GYM.BLL;
using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace desktopapp_GYM.GUI
{
    public partial class frmLogin : Form
    {
        
        UserBLL userBLL = new UserBLL();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserDTO userLogin = userBLL.Login(txtUserName.Text, txtPassword.Text);

            if (userLogin != null)
            {
                // Nạp đầy đủ "vũ khí" vào Session
                Session.CurrentUserID = userLogin.UserID;      // Cực kỳ quan trọng để Update
                Session.CurrentUsername = userLogin.Username;  // Hiện tên Dashboard
                Session.CurrentRole = userLogin.Role;          // Phân quyền menu
                Session.CurrentUser = userLogin;               // Dùng để truyền vào Form Edit Profile
                Session.LoginTime = DateTime.Now;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
