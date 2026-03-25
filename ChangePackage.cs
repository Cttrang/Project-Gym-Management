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
            isAddMode = false;
            _selectedPkg = pkg;
            this.Text = "Cập nhật thông tin gói tập";
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
            }
            else
            {
                txtTenGoi.TextChanged -= MarkAsChanged;
                txtHanGoi.TextChanged -= MarkAsChanged;
                txtGia.TextChanged -= MarkAsChanged;
            }
        }

        private void FillData()
        {
            // Tạm tắt sự kiện để không bị tính là người dùng thay đổi
            ToggleEvents(false);

            txtTenGoi.Text = _selectedPkg.PackageName;
            txtHanGoi.Text = _selectedPkg.DurationMonths.ToString();
            txtGia.Text = _selectedPkg.Price.ToString("N0"); // Định dạng số cho đẹp

            // Bật lại sự kiện và reset biến check
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
                // Kiểm tra nhập liệu cơ bản
                if (string.IsNullOrWhiteSpace(txtTenGoi.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên gói tập!");
                    return;
                }

                // Nếu đang ADD thì tạo mới DTO, nếu EDIT thì dùng lại đối tượng cũ
                PackageDTO dto = isAddMode ? new PackageDTO() : _selectedPkg;

                dto.PackageName = txtTenGoi.Text.Trim();
                dto.DurationMonths = int.Parse(txtHanGoi.Text);
                // Xử lý dấu phân cách nghìn nếu người dùng nhập 500.000
                dto.Price = decimal.Parse(txtGia.Text.Replace(".", "").Replace(",", ""));

                if (bll.SavePackage(dto, isAddMode))
                {
                    MessageBox.Show("Lưu thành công!");
                    isDataChanged = false; // Quan trọng để Exit không hỏi
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi dữ liệu: " + ex.Message);
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
            ToggleEvents(true);

            // Nếu là chế độ sửa, đổ dữ liệu vào các ô
            if (!isAddMode && _selectedPkg != null)
            {
                FillData();
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
                ToggleEvents(true);
            }
            else
            {
                FillData(); // Nếu sửa thì khôi phục lại lúc đầu
            }
            isDataChanged = false;
            txtTenGoi.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
