using desktopapp_GYM.BLL;
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
    public partial class ucTimeslotToday : ucBaseCard
    {
        TimeslotBLL _bll = new TimeslotBLL();
        public ucTimeslotToday()
        {
            InitializeComponent();
        }

        private void LoadTodayGrid()
        {
            DataTable dt = _bll.GetTimeslotsToday();
            dgvTimeslotToday.DataSource = dt;


            dgvTimeslotToday.Dock = DockStyle.Fill;
            dgvTimeslotToday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTimeslotToday.BackgroundColor = Color.White;
            dgvTimeslotToday.BorderStyle = BorderStyle.None;
            dgvTimeslotToday.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvTimeslotToday.ColumnHeadersVisible = false;
            dgvTimeslotToday.RowHeadersVisible = false;
            dgvTimeslotToday.RowTemplate.Height = 45;
            dgvTimeslotToday.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTimeslotToday.ReadOnly = true;

            if (dt != null && dt.Columns.Count >= 3)
            {
                dgvTimeslotToday.Columns[0].FillWeight = 45; 
                dgvTimeslotToday.Columns[1].FillWeight = 30; 
                dgvTimeslotToday.Columns[2].FillWeight = 25; 
            }
        }

        private void ucTimeslotToday_Load(object sender, EventArgs e)
        {
            LoadTodayGrid();
        }

        private void dgvTimeslotToday_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            e.CellStyle.ForeColor = Color.FromArgb(64, 64, 64);

            // Cột Giờ (Cột 1)
            if (e.ColumnIndex == 1)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.ForeColor = Color.DimGray;
            }

            // Cột Sĩ số (Cột 2)
            if (e.ColumnIndex == 2)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                string attendance = e.Value?.ToString();
                if (!string.IsNullOrEmpty(attendance) && attendance.Contains("/"))
                {
                    string[] parts = attendance.Split('/');
                    if (parts.Length == 2 && parts[0] == parts[1])
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.SeaGreen;
                    }
                }
            }

            if (e.ColumnIndex == 0)
            {
                e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            Form parent = this.FindForm();
            if (parent is frmMain main) main.ShowDetail(new ucTimeSlotReg());
        }
    }
}
