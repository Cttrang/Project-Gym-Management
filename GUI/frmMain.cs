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
