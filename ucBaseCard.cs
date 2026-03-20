using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace desktopapp_GYM
{
    public partial class ucBaseCard : UserControl
    {
        public ucBaseCard()
        {
            InitializeComponent();
        }
        public int BorderRadius { get; set; } = 30;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, BorderRadius, BorderRadius, 180, 90);
            path.AddArc(rect.Width - BorderRadius, rect.Y, BorderRadius, BorderRadius, 270, 90);
            path.AddArc(rect.Width - BorderRadius, rect.Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
            path.AddArc(rect.X, rect.Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);

            using (Pen pen = new Pen(Color.LightGray, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void btnPin_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Lấy tọa độ chuột hiện tại và chuyển về tọa độ của thẻ Dashboard
            System.Drawing.Point mousePos = this.PointToClient(Control.MousePosition);

            // Kiểm tra xem chuột có nằm trong diện tích của thẻ không
            if (this.ClientRectangle.Contains(mousePos))
            {
                btnPin.Visible = true; // Hiện nút
            }
            else
            {
                btnPin.Visible = false; // Ẩn nút
            }
        }

        public virtual void RefreshData()
        {
            // Không viết gì ở đây
        }
        protected virtual void OnViewDetailClick()
        {
            // Mặc định không làm gì hoặc hiện thông báo chung
        }
        public virtual void StartEffects()
        {
            if (timer1 != null)
            {
                timer1.Stop();
                timer1.Enabled = true;
                timer1.Start();
            }

            // Đảm bảo nút Pin luôn nổi lên trên cùng
            if (btnPin != null) btnPin.BringToFront();

            // Vẽ lại giao diện
            this.Invalidate();
        }
    }
}
