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
            chartRevenue.ChartAreas[0].AxisX.Interval = 1; // Hiện đủ các tháng

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

            // Tinh chỉnh trục tọa độ
            chartRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartRevenue.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
        }
        public override void StartEffects()
        {
            base.StartEffects(); // Chạy logic hiện nút Pin của cha

            // Logic riêng cho biểu đồ (nếu có)
            this.PerformLayout();
        }
    }
}
