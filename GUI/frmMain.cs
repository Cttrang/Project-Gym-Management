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
            //ucRevenueChart1.RefreshData();
            //ucExpiredAlert1.RefreshData();
            
            //ShowDashboard();
        }

        public void ShowMemberList()
        {
            // 1. Khởi tạo đối tượng
            ucMemberList uc = new ucMemberList();

            // 2. Xóa các control đang hiện hữu trong Panel nội dung (pnlContent)
            pnlContent.Controls.Clear();
            flowLayoutPanel1.Visible = false;

            // 3. Thiết lập Dock = Fill để tràn màn hình
            uc.Dock = DockStyle.Fill;

            // 4. Thêm vào Panel và hiển thị
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
            DisplayControl(new ucDashBoard());
        }

        private ucDashBoard _ucDashBoard;
        public void ShowDashboard()
        {
            //// 1. Kiểm tra nếu Dashboard chưa được tạo hoặc đã bị xóa
            //if (_ucDashBoard == null || _ucDashBoard.IsDisposed)
            //{
            //    _ucDashBoard = new ucDashBoard();
            //}

            //// 2. Xóa sạch các Control cũ đang hiển thị trong vùng nội dung (pnlContent)
            //pnlContent.Controls.Clear();

            //// 3. Thiết lập Dashboard để nó lấp đầy vùng nội dung
            //_ucDashBoard.Dock = DockStyle.Fill;

            //// 4. Thêm Dashboard vào Panel và đưa lên trên cùng
            //pnlContent.Controls.Add(_ucDashBoard);
            //_ucDashBoard.BringToFront();

            //// 5. Kích hoạt các hiệu ứng (Timer, Nút Pin) cho các Card con bên trong
            //ActivateCardsInDashboard(_ucDashBoard);
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
            //// 1. Xóa sạch control cũ để giải phóng bộ nhớ
            //pnlContent.Controls.Clear();

            //// 2. Thiết lập UC mới
            //uc.Dock = DockStyle.Fill;

            //// 3. Thêm vào Panel chính
            //pnlContent.Controls.Add(uc);
            //uc.BringToFront();

            //// 4. Nếu UC này là Dashboard, ta gọi lệnh kích hoạt Card
            //if (uc is ucDashBoard db)
            //{
            //    // Bạn có thể gọi hàm Init hoặc Activate đã viết ở ucDashBoard
            //    ActivateCardsInDashboard(db);
            //}
        }

        private void txtMember_Click(object sender, EventArgs e)
        {
            ShowMemberList();
        }
    }

}
