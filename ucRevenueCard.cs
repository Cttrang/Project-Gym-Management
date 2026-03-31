using desktopapp_GYM.DAL;
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
    public partial class ucRevenueCard : ucBaseCard
    {
        RegistrationDAL dalReg = new RegistrationDAL();
        public ucRevenueCard()
        {
            InitializeComponent();
        }
        public override void RefreshData()
        {
            decimal money = dalReg.GetMonthlyRevenue();
            lblRevenue.Text = money.ToString("C0"); // Tự thêm ký hiệu tiền tệ
        }
    }
}
