using desktopapp_GYM.BLL;
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
            string role = userBLL.Login(txtUserName.Text, txtPassword.Text);

            if (role != null)
            {
                Session.CurrentRole = role;
                Session.CurrentUsername = txtUserName.Text;

                this.DialogResult= DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
