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
                cboStatus.SelectedIndexChanged += MarkAsChanged;
                cboType.SelectedIndexChanged += MarkAsChanged; 
                cboSession.SelectedIndexChanged += MarkAsChanged; 
            }
            else
            {
                txtTenGoi.TextChanged -= MarkAsChanged;
                txtHanGoi.TextChanged -= MarkAsChanged;
                txtGia.TextChanged -= MarkAsChanged;
                cboStatus.SelectedIndexChanged -= MarkAsChanged;
                cboType.SelectedIndexChanged -= MarkAsChanged;
                cboSession.SelectedIndexChanged -= MarkAsChanged; 
            }
        }

        private void UpdateSessionComboBoxState()
        {
            if (cboType.Text == "FREE")
            {
                cboSession.SelectedIndex = -1;
                cboSession.Enabled = false;
            }
            else
            {
                cboSession.Enabled = true;
                if (cboSession.SelectedIndex == -1) cboSession.SelectedIndex = 0;
            }
        }

        private void FillData()
        {
            ToggleEvents(false);
            txtTenGoi.Text = _selectedPkg.PackageName;
            txtHanGoi.Text = _selectedPkg.DurationMonths.ToString();
            txtGia.Text = _selectedPkg.Price.ToString("N0");
            cboStatus.Text = _selectedPkg.Status;
            cboType.Text = _selectedPkg.Type;

            if (_selectedPkg.PTSessionsPerWeek.HasValue)
                cboSession.Text = _selectedPkg.PTSessionsPerWeek.Value.ToString();
            else
                cboSession.SelectedIndex = -1;

            UpdateSessionComboBoxState(); 
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
                dto.Type = cboType.Text;
                dto.DurationMonths = int.TryParse(txtHanGoi.Text, out int m) ? m : 0;
                if (dto.DurationMonths <= 0)
                {
                    MessageBox.Show("Thời hạn gói tập đang nhập sai!", "Thông báo");
                    txtHanGoi.Focus();
                    return;
                }

                dto.Status = cboStatus.Text; 

                string priceRaw = txtGia.Text.Replace(".", "").Replace(",", "");
                dto.Price = decimal.TryParse(priceRaw, out decimal p) ? p : 0;
                if (dto.Price <= 0)
                {
                    MessageBox.Show("Giá tiền đang nhập sai!", "Thông báo");
                    txtGia.Focus();
                    return;
                }

                if (dto.Type == "FREE")
                {
                    dto.PTSessionsPerWeek = null;
                }
                else
                {
                    if (int.TryParse(cboSession.Text, out int s))
                        dto.PTSessionsPerWeek = s;
                    else
                        throw new Exception("Vui lòng chọn số buổi mỗi tuần!");
                }

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
                    e.Cancel = true;
                }
            }
        }

        private void frmPackageChange_Load(object sender, EventArgs e)
        {
            if (!isAddMode && _selectedPkg.TotalMembers > 0)
            {
                txtHanGoi.Enabled = false;
                cboType.Enabled = false;
                txtGia.Enabled = false;
                cboType.Enabled = false;
            }

            cboStatus.Items.AddRange(new string[] { "Active", "Inactive" });
            cboType.Items.AddRange(new string[] { "FREE", "PT", "CLASS" });
            cboSession.Items.AddRange(new object[] { 3, 4, 5 });

            if (!isAddMode && _selectedPkg != null)
            {
                FillData();
            }
            else
            {
                cboStatus.SelectedIndex = 0; 
                cboType.SelectedIndex = 0;   
                cboSession.Enabled = false;  
                ToggleEvents(true);
                isDataChanged = false;
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
                cboType.SelectedIndex = 0;
                cboStatus.SelectedIndex = 0;
                cboSession.SelectedIndex = -1;
                cboSession.Enabled = false; 
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

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSessionComboBoxState();
            isDataChanged = true;
        }

        private void txtHanGoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
