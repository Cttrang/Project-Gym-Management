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
            int count = dalMember.GetTotalMembers();
            lblMemberCount.Text = count.ToString("N0");
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            Form parent = this.FindForm();
            if (parent is frmMain main) main.ShowDetail(new ucMemberList());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblMemberSubText_Click(object sender, EventArgs e)
        {

        }
    }
}
