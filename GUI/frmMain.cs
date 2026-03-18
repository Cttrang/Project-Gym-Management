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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //lblWelcome.Text = "Xin chào, " + Session.CurrentUsername;

            //if (Session.CurrentRole == "Receptionist")
            //{
            //    // Lễ tân thì ẩn nút xóa hoặc ẩn menu Dashboard của Manager
            //    btnDeleteMember.Visible = false;
            //    btnRevenueStats.Enabled = false;
            //}
            //ucMemberStats1.RefreshData();
            //ucRevenueCard1.RefreshData();
            ucRevenueChart1.RefreshData();
            ucExpiredAlert1.RefreshData();
        }

            //research
            //foreach (Control ctrl in flowLayoutPanel1.Controls)
            //{
            //    if (ctrl is ucBaseCard card) 
            //    {
            //        card.RefreshData(); // Tất cả các thẻ tự động chạy đi lấy dữ liệu mới nhất
            //    }
            //}
           
    }

}
