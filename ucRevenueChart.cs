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
using System.Windows.Forms.DataVisualization.Charting;

namespace desktopapp_GYM
{
    public partial class ucRevenueChart : ucBaseCard
    {
        RegistrationDAL dalReg = new RegistrationDAL();
        public ucRevenueChart()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
            DataTable dt = dalReg.GetRevenueData();
            chartRevenue.Series.Clear();
            chartRevenue.ChartAreas[0].AxisX.Interval = 1;

            Series series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Column;

            // Áp dụng Style "Luxury"
            series.Color = Color.FromArgb(255, 128, 0);
            series["PointWidth"] = "0.5";
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "N0";

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["MonthYear"].ToString(), row["Total"]);
                }

            }
            chartRevenue.Series.Add(series);

            chartRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartRevenue.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
        }
        public override void StartEffects()
        {
            base.StartEffects();
            this.PerformLayout();
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            frmRevenue reve = new frmRevenue();
            reve.ShowDialog();
        }
        public void UpdateChartData(System.Data.DataTable dtFiltered)
        {
            chartRevenue.Series.Clear(); // Xóa dữ liệu cũ

            if (dtFiltered != null && dtFiltered.Rows.Count > 0)
            {
                chartRevenue.ChartAreas[0].AxisX.Interval = 1;

                System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh thu lọc");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                series.Color = System.Drawing.Color.FromArgb(255, 128, 0);
                series["PointWidth"] = "0.5";
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "N0";

                foreach (System.Data.DataRow row in dtFiltered.Rows)
                {
                    // Lấy cột "Mã Giao Dịch" làm trục X, "Doanh Thu" làm trục Y (theo dữ liệu mẫu ở frmRevenue)
                    // Nếu bạn muốn trục X hiện Tháng/Ngày thì đổi chữ "Mã Giao Dịch" thành "Tháng" hoặc "Ngày" nhé
                    series.Points.AddXY(row["Mã Giao Dịch"].ToString(), row["Doanh Thu"]);
                }

                chartRevenue.Series.Add(series);

                chartRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartRevenue.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(230, 230, 230);
            }
        }
    }
}
