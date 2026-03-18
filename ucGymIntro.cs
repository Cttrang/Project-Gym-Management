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
    public partial class ucGymIntro : ucBaseCard
    {
        public ucGymIntro()
        {
            InitializeComponent();
        }
        protected override void OnViewDetailClick()
        {
            btnViewDetail.Visible = false;
        }
    }
}
