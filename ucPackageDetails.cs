using desktopapp_GYM.BLL;
using desktopapp_GYM.DTO;
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
    public partial class ucPackageDetails : UserControl
    {
        PackageBLL bll = new PackageBLL();
        List<PackageDTO> fullList = new List<PackageDTO>();
        
        public ucPackageDetails()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            fullList = bll.GetData();
            dgvPackages.DataSource = null;
            dgvPackages.DataSource = fullList;
            FormatGrid();
            SetupAutoComplete();
        }

        private void SetupAutoComplete()
        {
            // 1. Cấu hình chế độ gợi ý cho TextBox Search
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            // 2. Lấy danh sách tên các gói tập từ fullList (đã load từ BLL)
            if (fullList != null && fullList.Count > 0)
            {
                foreach (var pkg in fullList)
                {
                    if (!string.IsNullOrEmpty(pkg.PackageName))
                    {
                        collection.Add(pkg.PackageName);
                    }
                }
            }

            // 3. Gán bộ sưu tập tên vào TextBox
            txtSearch.AutoCompleteCustomSource = collection;
        }

        private void ApplyRolePermissions()
        {
            // Lấy trực tiếp từ Session tĩnh của Huy
            string role = Session.CurrentRole;

            if (role == "Receptionist")
            {
                btnAdd.Enabled = btnEdits.Enabled = btnDelete.Enabled = false;
            }
            else if (role == "Manager")
            {
                btnAdd.Enabled = btnEdits.Enabled = true;
                btnDelete.Enabled = false; // Manager không được xóa
            }
            else // Admin
            {
                btnAdd.Enabled = btnEdits.Enabled = btnDelete.Enabled = true;
            }
        }

        private void FormatGrid()
        {
            if (dgvPackages.Columns.Count > 0)
            {
                dgvPackages.Columns["PackageID"].HeaderText = "Mã";
                dgvPackages.Columns["PackageName"].HeaderText = "Tên gói tập";
                dgvPackages.Columns["Type"].HeaderText = "Loại hình"; // Cột mới
                dgvPackages.Columns["DurationMonths"].HeaderText = "Tháng";
                dgvPackages.Columns["Price"].HeaderText = "Giá tiền";
                dgvPackages.Columns["PTSessionsPerWeek"].HeaderText = "Buổi/Tuần"; // Cột mới
                dgvPackages.Columns["TotalMembers"].HeaderText = "Số người dùng";
                dgvPackages.Columns["Status"].HeaderText = "Trạng thái";

                dgvPackages.Columns["Price"].DefaultCellStyle.Format = "N0";
                //dgvPackages.Columns["DurationMonths"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgvPackages.Columns["PTSessionsPerWeek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvPackages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void ucPackageDetails_Load(object sender, EventArgs e)
        {
            if (this.FindForm() is frmGuest guest)
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnEdits.Visible = false;
                btnXuat.Visible = false;
            }    
            LoadData();
            ApplyRolePermissions();
        }
        private void btnAdd_Click(object sender, EventArgs e) 
        {
            frmPackageChange frm = new frmPackageChange(new PackageDTO(), true);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
            

        }
        private void btnEdits_Click(object sender, EventArgs e) 
        {
            if (dgvPackages.CurrentRow != null)
            {
                var selected = (PackageDTO)dgvPackages.CurrentRow.DataBoundItem;
                frmPackageChange frm = new frmPackageChange(selected, false);
                if (frm.ShowDialog() == DialogResult.OK) LoadData();
                
            }
        }
        private void btnDelete_Click(object sender, EventArgs e) 
        {
            if (dgvPackages.CurrentRow != null)
            {
                var selected = (PackageDTO)dgvPackages.CurrentRow.DataBoundItem;
                if (MessageBox.Show($"Xác nhận xóa gói: {selected.PackageName}?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        if (bll.DeletePackage(selected))
                        {
                            MessageBox.Show("Xóa thành công!");
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }
        private void btnOut_Click(object sender, EventArgs e) 
        {
            if (this.FindForm() is frmMain main)
            {
                main.ShowUc();
            }
            if (this.FindForm() is frmGuest guest)
            {
                guest.ShowUc();
            }    
        }
        private void btnClearSearch_Click(object sender, EventArgs e) 
        {
            txtSearch.Clear();
            dgvPackages.DataSource = null;
            dgvPackages.DataSource = fullList;
            FormatGrid();
            txtSearch.Focus();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) 
        {
            string key = txtSearch.Text.ToLower().Trim();
            dgvPackages.DataSource = fullList.Where(p => p.PackageName.ToLower().Contains(key)).ToList();
        }
        private void dgvMembers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) { }
        private void dgvMembers_SelectionChanged(object sender, EventArgs e) { }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvPackages.CurrentRow != null)
            {
                var pkg = (PackageDTO)dgvPackages.CurrentRow.DataBoundItem;

                // Xử lý hiển thị số buổi PT nếu có
                string ptInfo = pkg.PTSessionsPerWeek.HasValue ? $"{pkg.PTSessionsPerWeek} buổi/tuần" : "N/A";

                string info = $"--- THÔNG TIN CHI TIẾT GÓI TẬP ---\n\n" +
                              $"Mã gói: {pkg.PackageID}\n" +
                              $"Tên gói: {pkg.PackageName}\n" +
                              $"Loại hình: {pkg.Type}\n" + // Thêm Type
                              $"Thời hạn: {pkg.DurationMonths} tháng\n" +
                              $"Giá tiền: {pkg.Price.ToString("N0")} VNĐ\n" +
                              $"Số buổi PT/Tuần: {ptInfo}\n" + // Thêm thông tin buổi
                              $"Trạng thái: {pkg.Status}\n" +
                              $"Số người đang dùng: {pkg.TotalMembers}";

                MessageBox.Show(info, "Chi tiết gói tập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một gói tập trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
