using desktopapp_GYM.BLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace desktopapp_GYM
{
    public partial class frmRevenue : Form
    {
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

        private void LoadDataFromDatabase()
        {
            var bll = new RegistrationBLL();
            dtRevenueData = bll.GetRevenueDetail();
        }

        private void SetupComboBoxes()
        {
            cboMonth.Items.Clear();
            cboMonth.Items.Add("Tất cả tháng");
            for (int i = 1; i <= 12; i++)
                cboMonth.Items.Add("Tháng " + i);
            cboMonth.SelectedIndex = 0;

            if (dtRevenueData != null && dtRevenueData.Rows.Count > 0)
            {
                cboPackage.Items.Clear();
                cboPackage.Items.Add("Tất cả gói");
                var packages = dtRevenueData.AsEnumerable().Select(r => r.Field<string>("Gói Tập")).Distinct().ToArray();
                cboPackage.Items.AddRange(packages);
                cboPackage.SelectedIndex = 0;

                cboTrainer.Items.Clear();
                cboTrainer.Items.Add("Tất cả PT");
                var trainers = dtRevenueData.AsEnumerable().Select(r => r.Field<string>("Huấn Luyện Viên")).Distinct().ToArray();
                cboTrainer.Items.AddRange(trainers);
                cboTrainer.SelectedIndex = 0;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilterAndDisplay();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboMonth.SelectedIndex = 0;
            cboPackage.SelectedIndex = 0;
            cboTrainer.SelectedIndex = 0;
            ApplyFilterAndDisplay();
        }

        private void ApplyFilterAndDisplay()
        {
            if (dtRevenueData == null) return;

            DataView dv = dtRevenueData.DefaultView;
            string query = "1=1";

            if (cboMonth.SelectedIndex > 0)
            {
                query += $" AND Tháng = {cboMonth.SelectedIndex}";
            }

            if (cboPackage.SelectedIndex > 0)
            {
                query += $" AND [Gói Tập] = '{cboPackage.SelectedItem.ToString()}'";
            }

            if (cboTrainer.SelectedIndex > 0)
            {
                query += $" AND [Huấn Luyện Viên] = '{cboTrainer.SelectedItem.ToString()}'";
            }

            dv.RowFilter = query;
            DataTable filteredTable = dv.ToTable();

            dgvRevenue.DataSource = filteredTable;

            if (dgvRevenue.Columns["Doanh Thu"] != null)
            {
                dgvRevenue.Columns["Doanh Thu"].DefaultCellStyle.Format = "N0";
            }

            decimal totalAmount = 0;
            if (filteredTable.Rows.Count > 0)
            {
                totalAmount = filteredTable.AsEnumerable().Sum(r => r.Field<decimal>("Doanh Thu"));
            }

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