using desktopapp_GYM.BLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace desktopapp_GYM
{
    public partial class frmRevenue : Form
    {
        // Biến lưu trữ dữ liệu gốc để lọc
        private DataTable dtRevenueData;

        public frmRevenue()
        {
            InitializeComponent();
        }

        private void frmRevenue_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            SetupComboBoxes();
            ApplyFilterAndDisplay();
        }

        // 1. Khởi tạo dữ liệu giả lập (Bạn thay bằng code gọi Database thật sau nhé)
        private void LoadDataFromDatabase()
        {
            var bll = new RegistrationBLL();
            dtRevenueData = bll.GetRevenueDetail();
        }

        // 2. Nạp dữ liệu vào các ComboBox
        private void SetupComboBoxes()
        {
            // Nạp Tháng
            cboMonth.Items.Clear();
            cboMonth.Items.Add("Tất cả tháng");
            for (int i = 1; i <= 12; i++)
                cboMonth.Items.Add("Tháng " + i);
            cboMonth.SelectedIndex = 0;

            if (dtRevenueData != null && dtRevenueData.Rows.Count > 0)
            {
                // Nạp Gói tập
                cboPackage.Items.Clear();
                cboPackage.Items.Add("Tất cả gói");
                var packages = dtRevenueData.AsEnumerable().Select(r => r.Field<string>("Gói Tập")).Distinct().ToArray();
                cboPackage.Items.AddRange(packages);
                cboPackage.SelectedIndex = 0;

                // Nạp Huấn luyện viên
                cboTrainer.Items.Clear();
                cboTrainer.Items.Add("Tất cả PT");
                var trainers = dtRevenueData.AsEnumerable().Select(r => r.Field<string>("Huấn Luyện Viên")).Distinct().ToArray();
                cboTrainer.Items.AddRange(trainers);
                cboTrainer.SelectedIndex = 0;
            }
        }

        // 3. Sự kiện nút Tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilterAndDisplay();
        }

        // 4. Sự kiện nút Làm mới
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboMonth.SelectedIndex = 0;
            cboPackage.SelectedIndex = 0;
            cboTrainer.SelectedIndex = 0;
            ApplyFilterAndDisplay();
        }

        // 5. Hàm thực thi việc lọc dữ liệu
        private void ApplyFilterAndDisplay()
        {
            if (dtRevenueData == null) return;

            DataView dv = dtRevenueData.DefaultView;
            string query = "1=1";

            // Lọc theo Tháng
            if (cboMonth.SelectedIndex > 0)
            {
                query += $" AND Tháng = {cboMonth.SelectedIndex}";
            }

            // Lọc theo Gói
            if (cboPackage.SelectedIndex > 0)
            {
                query += $" AND [Gói Tập] = '{cboPackage.SelectedItem.ToString()}'";
            }

            // Lọc theo PT
            if (cboTrainer.SelectedIndex > 0)
            {
                query += $" AND [Huấn Luyện Viên] = '{cboTrainer.SelectedItem.ToString()}'";
            }

            // Áp dụng bộ lọc
            dv.RowFilter = query;
            DataTable filteredTable = dv.ToTable();

            // Hiển thị lên lưới dgvRevenue
            dgvRevenue.DataSource = filteredTable;

            // Format cột tiền cho đẹp
            if (dgvRevenue.Columns["Doanh Thu"] != null)
            {
                dgvRevenue.Columns["Doanh Thu"].DefaultCellStyle.Format = "N0";
            }

            // Tính tổng doanh thu sau khi lọc
            decimal totalAmount = 0;
            if (filteredTable.Rows.Count > 0)
            {
                totalAmount = filteredTable.AsEnumerable().Sum(r => r.Field<decimal>("Doanh Thu"));
            }

            // --- TRUYỀN DỮ LIỆU SANG CARD VÀ CHART ---


            if (this.Controls.Find("ucRevenueCard1", true).FirstOrDefault() is ucRevenueCard myCard)
            {
                myCard.UpdateTotalRevenue(totalAmount);
            }

            if (this.Controls.Find("ucRevenueChart1", true).FirstOrDefault() is ucRevenueChart myChart)
            {
                myChart.UpdateChartData(filteredTable);
            }

        }
    }
}