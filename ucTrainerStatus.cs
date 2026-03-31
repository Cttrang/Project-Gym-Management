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
    public partial class ucTrainerStatus : ucBaseCard
    {
        TrainerDAL dal = new TrainerDAL();
        public ucTrainerStatus()
        {
            InitializeComponent();
        }

        private void LoadTopTrainers()
        {
            DataTable dt = dal.GetTopTrainers(5);
            dgvTopTrainers.DataSource = dt;

            // --- Cấu hình hiển thị "Phẳng" ---
            dgvTopTrainers.CellBorderStyle = DataGridViewCellBorderStyle.None; // Ẩn đường kẻ
            dgvTopTrainers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopTrainers.ColumnHeadersVisible = false;
            dgvTopTrainers.RowHeadersVisible = false;
            dgvTopTrainers.ReadOnly = true;
            dgvTopTrainers.BackgroundColor = Color.White;
            dgvTopTrainers.BorderStyle = BorderStyle.None;
            dgvTopTrainers.AllowUserToResizeRows = false; // Chặn người dùng kéo dãn dòng

            // --- Tỷ lệ và Khoảng cách ---
            dgvTopTrainers.RowTemplate.Height = 55;
            dgvTopTrainers.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);

            // Chèn cột Rank
            if (!dgvTopTrainers.Columns.Contains("Rank"))
            {
                DataGridViewTextBoxColumn rankCol = new DataGridViewTextBoxColumn();
                rankCol.Name = "Rank";
                dgvTopTrainers.Columns.Insert(0, rankCol);
            }

            // Đổ số thứ tự
            for (int i = 0; i < dgvTopTrainers.Rows.Count; i++)
            {
                dgvTopTrainers.Rows[i].Cells["Rank"].Value = (i + 1).ToString();
            }

            // Chia lại tỷ lệ 4 cột để không bị chật
            if (dgvTopTrainers.Columns.Count >= 4)
            {
                dgvTopTrainers.Columns["Rank"].FillWeight = 10;
                dgvTopTrainers.Columns[1].FillWeight = 40; // Họ tên
                dgvTopTrainers.Columns[2].FillWeight = 35; // Chuyên môn
                dgvTopTrainers.Columns[3].FillWeight = 15; // Số học viên

                // Căn lề
                dgvTopTrainers.Columns["Rank"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTopTrainers.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Font và Màu sắc
                dgvTopTrainers.Columns[1].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvTopTrainers.Columns[2].DefaultCellStyle.ForeColor = Color.DimGray;
                dgvTopTrainers.Columns["Rank"].DefaultCellStyle.ForeColor = Color.FromArgb(255, 128, 0); // Màu cam cho số hạng
            }
        
        }

        private void dgvTopTrainers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvTopTrainers.Rows[e.RowIndex].IsNewRow) return;

            try
            {
                // --- CỘT 0: SỐ HẠNG ---
                if (e.ColumnIndex == 0)
                {
                    e.Value = (e.RowIndex + 1).ToString();
                    e.CellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    // Top 1 cho màu xanh đậm hơn
                    if (e.RowIndex == 0) e.CellStyle.ForeColor = Color.BlueViolet;
                }

                // --- CỘT 1: HỌ TÊN HLV ---
                if (e.ColumnIndex == 1)
                {
                    e.CellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    e.CellStyle.ForeColor = Color.FromArgb(44, 62, 80);
                    if (e.RowIndex == 0) e.CellStyle.ForeColor = Color.BlueViolet;
                }

                // --- CỘT 2: SỐ HỌC VIÊN (Nổi bật nhất ở cuối) ---
                if (e.ColumnIndex == 2)
                {
                    string val = (e.Value != null && e.Value != DBNull.Value) ? e.Value.ToString() : "0";
                    e.Value = val + " Học viên";
                    e.FormattingApplied = true;

                    // Cấu hình Nổi bật đúng ý Huy
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    e.CellStyle.ForeColor = Color.MediumSeaGreen; // Màu xanh lá năng động
                    e.CellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }
            }
            catch { MessageBox.Show("có lỗi"); }
        }

        private void ucTrainerStatus_Load(object sender, EventArgs e)
        {
            LoadTopTrainers();
        }
    }
}
