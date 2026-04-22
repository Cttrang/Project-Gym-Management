using desktopapp_GYM.DTO;
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
    public partial class ucTimeSlot : UserControl
    {
        public TimeslotDTO Data { get; private set; }
        public int CurrentSlotID { get; set; }
        public ucTimeSlot()
        {
            InitializeComponent();
            lblClassName.Click += (s, e) => this.OnClick(e);
            lblTrainerName.Click += (s, e) => this.OnClick(e);
        }

        public void UpdateData(TimeslotDTO dto)
        {
            this.Data = dto;
            this.CurrentSlotID = dto.SlotID;

            lblClassName.Text = dto.SlotName;
            lblTrainerName.Text = $"HLV: {dto.TrainerName}";

            // Tự động đổi màu dựa trên trạng thái hoặc số lượng học viên
            if (dto.Status == "Maintenance")
            {
                this.BackColor = Color.FromArgb(149, 165, 166); // Màu xám (Bảo trì)
                lblClassName.Text += " (Tạm nghỉ)";
            }
            else if (dto.CurrentCount >= dto.MaxMembers)
            {
                this.BackColor = Color.FromArgb(231, 76, 60); // Màu đỏ (Đã đầy)
            }
            else
            {
                // Màu xanh dương modern nếu còn chỗ
                this.BackColor = Color.FromArgb(52, 152, 219);

                // Nếu lớp còn ít chỗ (ví dụ còn dưới 3 chỗ), có thể đổi màu vàng để cảnh báo
                if (dto.MaxMembers - dto.CurrentCount <= 2 && dto.MaxMembers > 1)
                {
                    this.BackColor = Color.Orange; // Màu cam/vàng
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            base.OnPaint(e);
            int borderRadius = 10;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(Width - borderRadius, Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, Height - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);
            }
        }

        private void ucTimeSlot_MouseEnter(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = ControlPaint.Light(this.BackColor);
        }


        private void ucTimeSlot_MouseLeave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
            if (Data != null) UpdateData(Data);
        }


    }
}
