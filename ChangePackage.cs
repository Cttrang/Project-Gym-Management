using desktopapp_GYM.BLL;
using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace desktopapp_GYM
{
    public partial class frmPackageChange : Form
    {
        PackageDTO _selectedPkg = null;
        PackageBLL bll = new PackageBLL();
        bool isAddMode = true;
        bool isDataChanged = false;
        public frmPackageChange()
        {
            InitializeComponent();
            isAddMode = true;
            this.Text = "Thêm gói tập mới";
        }

        public frmPackageChange(PackageDTO pkg, bool isAdd)
        {
            InitializeComponent();
            this.isAddMode = isAdd;
            _selectedPkg = pkg;
            this.Text = isAdd ? "Thêm gói tập mới" : "Cập nhật thông tin gói tập";
        }

        private void MarkAsChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
        }

        private void ToggleEvents(bool active)
        {
            if (active)
            {
                txtTenGoi.TextChanged += MarkAsChanged;
                txtHanGoi.TextChanged += MarkAsChanged;
                txtGia.TextChanged += MarkAsChanged;
                cboStatus.SelectedIndexChanged += MarkAsChanged; // thêm
            }
            else
            {
                txtTenGoi.TextChanged -= MarkAsChanged;
                txtHanGoi.TextChanged -= MarkAsChanged;
                txtGia.TextChanged -= MarkAsChanged;
                cboStatus.SelectedIndexChanged -= MarkAsChanged; // thêm
            }
        }

        private void FillData()
        {
            ToggleEvents(false);
            txtTenGoi.Text = _selectedPkg.PackageName;
            txtHanGoi.Text = _selectedPkg.DurationMonths.ToString();
            txtGia.Text = _selectedPkg.Price.ToString("N0");
            cboStatus.Text = _selectedPkg.Status;  // thêm — bỏ comment cũ đi
            ToggleEvents(true);
            isDataChanged = false;
        }

        private void txtTenGoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenGoi.Text) || string.IsNullOrWhiteSpace(txtGia.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên và Giá!");
                    return;
                }

                PackageDTO dto = isAddMode ? new PackageDTO() : _selectedPkg;
                dto.PackageName = txtTenGoi.Text.Trim();
                dto.DurationMonths = int.TryParse(txtHanGoi.Text, out int m) ? m : 0;
                dto.Status = cboStatus.Text; // thêm

                string priceRaw = txtGia.Text.Replace(".", "").Replace(",", "");
                dto.Price = decimal.TryParse(priceRaw, out decimal p) ? p : 0;

                if (bll.SavePackage(dto, isAddMode))
                {
                    MessageBox.Show("Lưu thành công!");
                    isDataChanged = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void frmPackageChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDataChanged)
            {
                var result = MessageBox.Show("Dữ liệu đã thay đổi nhưng chưa lưu. Bạn có chắc muốn thoát?",
                                           "Xác nhận",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Ngăn đóng form
                }
            }
        }

        private void frmPackageChange_Load(object sender, EventArgs e)
        {

            cboStatus.Items.AddRange(new string[] { "Active", "Inactive" }); // thêm

            if (!isAddMode && _selectedPkg != null)
                FillData();
            else
            {
                cboStatus.SelectedIndex = 0; // mặc định Active khi Add
                ToggleEvents(true);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (isAddMode)
            {
                ToggleEvents(false);
                txtTenGoi.Clear();
                txtHanGoi.Clear();
                txtGia.Clear();
                cboStatus.SelectedIndex = 0; // thêm
                ToggleEvents(true);
            }
            else
                FillData();

            isDataChanged = false;
            txtTenGoi.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHanGoi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
