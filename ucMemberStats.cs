using desktopapp_GYM.DAL;
using desktopapp_GYM.GUI;
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
    public partial class ucMemberStats : ucBaseCard
    {
        MemberDal dalMember = new MemberDal();
        public ucMemberStats()
        {
            InitializeComponent();
        }
        public override void RefreshData()
        {
            // Nhấc máy gọi nhà máy DAL lấy số
            int count = dalMember.GetTotalMembers();
            // Đổ con số vào Label trên giao diện của thẻ này
            lblMemberCount.Text = count.ToString("N0");
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            Form parent = this.FindForm();
            if (parent is frmMain main) main.ShowDetail(new ucMemberList());
        }
    }
}
