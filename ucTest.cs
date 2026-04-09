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
    public partial class ucTest : UserControl
    {
        public ucTest()
        {
            InitializeComponent();
        }

        private readonly List<string> timeLabels = new List<string> {
            "06:00", "07:00", "08:00", "09:00", "10:00", "11:00",
            "12:00", "13:00", "14:00", "15:00", "16:00", "17:00",
            "18:00", "19:00", "20:00", "21:00", "22:00"
        };

        private readonly string[] dayLabels = {
            "Giờ", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ Nhật"
        };

        // 1. Tạo các nhãn tiêu đề cho Thứ (tlpHeader)
        private void SetupGridHeaders()
        {
            //tlpHeader.Controls.Clear();
            for (int i = 0; i < dayLabels.Length; i++)
            {
                Label lbl = new Label
                {
                    Text = dayLabels[i],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    BackColor = Color.LightGray
                };
                //tlpHeader.Controls.Add(lbl, i, 0);
            }
        }

        // 2. Tạo các ô trống (FlowLayoutPanel) và cột Giờ cho tlpBody
        private void InitEmptySlots()
        {
            tlpBody.Controls.Clear();
            tlpBody.RowCount = timeLabels.Count;

            for (int row = 0; row < timeLabels.Count; row++)
            {
                // Thêm Label giờ vào cột 0
                Label lblTime = new Label
                {
                    Text = timeLabels[row],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.TopCenter,
                    Font = new Font("Segoe UI", 8, FontStyle.Regular),
                    Padding = new Padding(0, 5, 0, 0)
                };
                tlpBody.Controls.Add(lblTime, 0, row);

                // Thêm FlowLayoutPanel vào cột 1-7
                for (int col = 1; col <= 7; col++)
                {
                    FlowLayoutPanel flp = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.TopDown,
                        WrapContents = false,
                        AutoScroll = true, // Tự hiện cuộn nếu > 3 lớp
                        BackColor = Color.Transparent,
                        Tag = new { Day = col, Time = timeLabels[row] }
                    };

                    // Sự kiện Double Click vào ô trống để thêm lớp mới
                    flp.DoubleClick += OnCellDoubleClick;

                    tlpBody.Controls.Add(flp, col, row);
                }
            }
        }

        // 3. Event mẫu khi Double Click vào ô trống
        private void OnCellDoubleClick(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = (FlowLayoutPanel)sender;
            dynamic info = flp.Tag;

            // Huy gọi Form thêm mới lớp ở đây
            MessageBox.Show($"Thêm lớp mới vào: {dayLabels[info.Day]} lúc {info.Time}");
        }

        // 4. Hàm để Form ngoài gọi vào khi cần đổ dữ liệu
        public void ClearAllSlots()
        {
            foreach (Control ctrl in tlpBody.Controls)
            {
                if (ctrl is FlowLayoutPanel flp)
                {
                    flp.Controls.Clear();
                }
            }
        }
    }
}

