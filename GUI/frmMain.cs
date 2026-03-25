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
            //ucRevenueChart1.Visible = !ucRevenueChart1.Visible;
            //ucExpiredAlert1.Visible = !ucExpiredAlert1.Visible;
            //if (ucRevenueChart1.Visible)
            //{
            //    // Khi hiện lại, ép nó gọi StartEffects để xem Timer có "sống" lại không
            //    ucRevenueChart1.StartEffects();
            //    ucRevenueChart1.BringToFront();
            //    ucExpiredAlert1.StartEffects();
            //    ucExpiredAlert1.BringToFront();
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            ShowUc();
            
        }

        
        

        private void ActivateCardsInDashboard(ucDashBoard db)
        {
            // Tìm FlowLayoutPanel bên trong Dashboard (giả sử tên là flpDashboard)
            // Chúng ta duyệt qua các Control để tìm các Card con
            foreach (Control c in db.Controls)
            {
                if (c is FlowLayoutPanel flp)
                {
                    foreach (Control card in flp.Controls)
                    {
                        // Nếu Card đó kế thừa từ ucBaseCard, ta gọi StartEffects
                        if (card is ucBaseCard baseCard)
                        {
                            baseCard.StartEffects();
                        }
                    }
                }
            }
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
    }

}
