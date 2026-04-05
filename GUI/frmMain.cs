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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace desktopapp_GYM.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string name = Session.CurrentUsername;
            string role = Session.CurrentRole;
            lblWelcome.Text = $"{name} ({role})";
            if (role == "Admin") lblWelcome.ForeColor = Color.Red;
            else if (role == "Manager") lblWelcome.ForeColor = Color.DarkBlue;
            else lblWelcome.ForeColor = Color.Green;
            ShowUc();
            
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
                if (ctrl is ucMemberStats ucMemberStats1)
                {
                    ucMemberStats1.RefreshData();
                }
                else if (ctrl is ucExpiredAlert ucExpiredAlert1)
                {
                    ucExpiredAlert1.RefreshData(); // Giả sử Huy có hàm RefreshData trong UC cảnh báo
                }
                else if (ctrl is ucRevenueChart ucRevenueChart1)
                {
                    ucRevenueChart1.RefreshData(); // Giả sử Huy có hàm RefreshData trong UC cảnh báo
                }
                else if (ctrl is ucPackagePrice ucPackagePrice1)
                {
                    ucPackagePrice1.RefreshData();
                }
            }
        }

        public void ShowDetail(UserControl uc)
        {
            // 1. Ẩn cái Dashboard đi cho khuất mắt
            flowLayoutPanel1.Visible = false;

            // 2. Dọn dẹp pnlContent trước khi thêm cái mới (tránh chồng chất)
            foreach (Control ctrl in pnlContent.Controls)
            {
                if (ctrl != flowLayoutPanel1)
                {
                    pnlContent.Controls.Remove(ctrl);
                }
            }

            // 3. Thêm UC chi tiết vào pnlContent
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            ShowUc();
            
        }

        
        public void DisplayControl(UserControl uc)
        {
            
        }

        private void txtMember_Click(object sender, EventArgs e)
        {
            ShowDetail(new ucMemberList());
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowDetail(new ucPackageDetails());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowDetail(new ucTrainerList());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClassRegis_Click(object sender, EventArgs e)
        {
            ShowDetail(new ucTimeSlotRegis());
        }

        private void btnManagerAcc_Click(object sender, EventArgs e)
        {
            string role = Session.CurrentRole;
            if (role != "Admin") this.Visible = false;
            ShowDetail(new ucAccountManager());
        }

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            frmEditAccount frm = new frmEditAccount(Session.CurrentUser, false);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Session.CurrentUsername = Session.CurrentUser.Username;
                lblWelcome.Text = Session.CurrentUsername;
            }
        }
    }

}
