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
    public partial class ucPackagePrice : ucBaseCard
    {
        PackageDAL dal = new PackageDAL();
        public ucPackagePrice()
        {
            InitializeComponent();
        }

        private void LoadTopGrid()
        {
            DataTable dt = dal.GetTopPackages(5);
            dgvTopPackages.DataSource = dt;

            // Thiết lập cơ bản
            dgvTopPackages.Dock = DockStyle.Fill;
            dgvTopPackages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopPackages.BackgroundColor = Color.White;
            dgvTopPackages.BorderStyle = BorderStyle.None;
            dgvTopPackages.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvTopPackages.ColumnHeadersVisible = false;
            dgvTopPackages.RowHeadersVisible = false;
            dgvTopPackages.RowTemplate.Height = 55;
            dgvTopPackages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopPackages.ReadOnly = true;

            // QUAN TRỌNG: Chèn cột Rank vào đầu nếu chưa có
            if (!dgvTopPackages.Columns.Contains("RankCol"))
            {
                DataGridViewTextBoxColumn rankCol = new DataGridViewTextBoxColumn();
                rankCol.Name = "RankCol";
                dgvTopPackages.Columns.Insert(0, rankCol);
            }

            // Chia tỷ lệ độ rộng (Tổng = 100)
            dgvTopPackages.Columns[0].FillWeight = 15; // Cột Rank
            dgvTopPackages.Columns[1].FillWeight = 60; // Tên gói (Giả sử SQL cột 0 cũ giờ thành 1)
            dgvTopPackages.Columns[2].FillWeight = 25; // Số người (Giả sử SQL cột 1 cũ giờ thành 2)
        }

        private void ucTopPackageItem1_Load(object sender, EventArgs e)
        {

        }

        private void ucPackagePrice_Load(object sender, EventArgs e)
        {
            LoadTopGrid();
        }

        private void dgvTopPackages_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvTopPackages.Rows[e.RowIndex].IsNewRow)
                return;

            try
            {
                // --- CỘT 0: SỐ HẠNG (RankCol) ---
                if (dgvTopPackages.Columns[e.ColumnIndex].Name == "RankCol")
                {
                    e.Value = (e.RowIndex + 1).ToString();
                    e.CellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    if (e.RowIndex == 0) e.CellStyle.ForeColor = Color.OrangeRed; // Top 1 màu đỏ cam
                }

                // --- CỘT 1: TÊN GÓI (Dữ liệu từ SQL) ---
                else if (e.ColumnIndex == 1)
                {
                    e.CellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    if (e.RowIndex == 0) e.CellStyle.ForeColor = Color.OrangeRed;
                    else
                        e.CellStyle.ForeColor = Color.FromArgb(44, 62, 80);
                }

                // --- CỘT 2: SỐ NGƯỜI (Nổi bật nhất ở cuối) ---
                else if (e.ColumnIndex == 2)
                {
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        // Thêm chữ "Hội viên" vào sau con số
                        e.Value = e.Value.ToString() + " Hội viên";
                        e.FormattingApplied = true; // Báo hiệu đã xử lý xong để tránh lỗi ép kiểu
                    }

                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    e.CellStyle.ForeColor = Color.RoyalBlue; // Màu xanh nổi bật
                    e.CellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lấy dữ liệu để tạo bảng Toppackage.");
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            Form parent = this.FindForm();
            if (parent is frmMain main) main.ShowDetail(new ucPackageDetails());
            else if (parent is frmGuest guest) guest.ShowDetail(new ucPackageDetails());
        }
    }
}
