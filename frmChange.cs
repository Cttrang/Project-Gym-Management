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

namespace desktopapp_GYM
{
    public partial class frmChange : Form
    {
        MemberBLL bll = new MemberBLL();
        bool isAddMode = true;
        DataGridViewRow selectedRow = null;
        bool isDataChanged = false;
        public frmChange()
        {
            InitializeComponent();
            isAddMode = true;
        }

        public frmChange(DataGridViewRow row)
        { // Dùng cho nút EDIT
            InitializeComponent();
            isAddMode = false;
            selectedRow = row;
            cboVaiTro.Enabled = false;
        }

        private void ToggleFormByRole(string role)
        {
            bool isMember = (role == "Member");
            bool isTrainer = (role == "Trainer");

            // Phần Đăng kí — chỉ Member dùng
            cboGoiTap.Enabled = isMember;
            dtpNgayDangKy.Enabled = isMember;
            dtpNgayHetHan.Enabled = isMember;
            cboHLV.Enabled = isMember;

            // Phần Thanh toán, gói tập — chỉ Member dùng
            txtTongTien.Enabled = isMember;
            cboThanhToan.Enabled = isMember;

            // Ghi chú — chỉ Trainer dùng (nhập Specialty)
            txtNotes.Enabled = isTrainer;

            // Status — cả 2 đều dùng
            cboStatus.Enabled = true;
        }

        private void MarkAsChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
        }

        private void ToggleEvents(bool active)
        {
            if (active)
            {
                txtHoTen.TextChanged += MarkAsChanged;
                txtSDT.TextChanged += MarkAsChanged;
                cboVaiTro.SelectedIndexChanged += MarkAsChanged;
                cboThanhToan.SelectedIndexChanged += MarkAsChanged;
                cboHLV.SelectedIndexChanged += MarkAsChanged;
                // cboGoiTap đã có hàm riêng nên không add ở đây
            }
            else
            {
                txtHoTen.TextChanged -= MarkAsChanged;
                txtSDT.TextChanged -= MarkAsChanged;
                cboVaiTro.SelectedIndexChanged -= MarkAsChanged;
                cboThanhToan.SelectedIndexChanged -= MarkAsChanged;
                cboHLV.SelectedIndexChanged -= MarkAsChanged;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleFormByRole(cboVaiTro.Text);
            isDataChanged = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FillData()
        {
            ToggleEvents(false);
            // 1. Điền thông tin cơ bản
            txtHoTen.Text = selectedRow.Cells["FULLNAME"].Value.ToString();
            txtSDT.Text = selectedRow.Cells["PHONE"].Value.ToString();
            cboVaiTro.Text = selectedRow.Cells["TYPE"].Value.ToString();
            cboStatus.Text = selectedRow.Cells["STATUS"].Value?.ToString();

            // 2. Điền thông tin gói tập (Dùng SelectedValue để khớp với ValueMember)
            string role = cboVaiTro.Text;
            ToggleFormByRole(role);

            if (role == "Member")
            {
                if (selectedRow.Cells["PACKAGEID"].Value != DBNull.Value)
                    cboGoiTap.SelectedValue = selectedRow.Cells["PACKAGEID"].Value;


                if (selectedRow.Cells["TRAINERID"].Value != DBNull.Value)
                    cboHLV.SelectedValue = selectedRow.Cells["TRAINERID"].Value;

                if (selectedRow.Cells["REGDATE"].Value != DBNull.Value)
                    dtpNgayDangKy.Value = Convert.ToDateTime(selectedRow.Cells["REGDATE"].Value);

                if (selectedRow.Cells["ENDDATE"].Value != DBNull.Value)
                    dtpNgayHetHan.Value = Convert.ToDateTime(selectedRow.Cells["ENDDATE"].Value);

                cboThanhToan.Text = selectedRow.Cells["PAYMENTSTATUS"].Value?.ToString();

                if (selectedRow.Cells["TOTALAMOUNT"].Value != DBNull.Value)
                    txtTongTien.Text = Convert.ToDecimal(
                        selectedRow.Cells["TOTALAMOUNT"].Value).ToString("N0");
            }
            else if (role == "Trainer")
            {
                // GHICHU của Trainer = Specialty
                txtNotes.Text = selectedRow.Cells["GHICHU"].Value?.ToString();
            }

            // Sau khi điền xong, reset lại biến check thay đổi để tránh hiện cảnh báo thoát khi chưa sửa gì
            ToggleEvents(true);
            isDataChanged = false;
        }

        private void cboGoiTap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGoiTap.SelectedValue is DataRowView) return;
            DataRowView row = (DataRowView)cboGoiTap.SelectedItem;

            dtpNgayHetHan.Value = dtpNgayDangKy.Value.AddMonths(Convert.ToInt32(row["DURATIONMONTHS"]));
            txtTongTien.Text = Convert.ToDecimal(row["PRICE"]).ToString("N0");
            isDataChanged = true;
        }

        

        private void frmChange_Load(object sender, EventArgs e)
        {
            cboVaiTro.Items.AddRange(new string[] { "Member", "Trainer" });
            cboStatus.Items.AddRange(new string[] { "Active", "Inactive" });

            cboGoiTap.DataSource = bll.GetPackages();
            cboGoiTap.DisplayMember = "PACKAGENAME";
            cboGoiTap.ValueMember = "PACKAGEID";

            cboHLV.DataSource = bll.GetTrainers();
            cboHLV.DisplayMember = "FULLNAME";
            cboHLV.ValueMember = "TRAINERID";

            ToggleEvents(true);

            if (!isAddMode && selectedRow != null)
            {
                FillData();
            }
            else
                ToggleFormByRole("Member");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberDTO dto = new MemberDTO
            {
                FullName = txtHoTen.Text,
                Phone = txtSDT.Text,
                Role = cboVaiTro.Text,
                PackageID = (int)cboGoiTap.SelectedValue,
                TrainerID = cboHLV.SelectedValue as int?,
                RegDate = dtpNgayDangKy.Value,
                EndDate = dtpNgayHetHan.Value,
                TotalAmount = decimal.Parse(txtTongTien.Text.Replace(".", "")),
                PaymentStatus = cboThanhToan.Text
            };
            if (!isAddMode) dto.ID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            if (bll.SaveData(dto, isAddMode))
            {
                MessageBox.Show("Thành công!");
                isDataChanged = false;
                this.DialogResult = DialogResult.OK; // Đóng và báo hiệu Load lại Grid
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ToggleEvents(false);
            txtHoTen.Clear();
            txtSDT.Clear();
            txtTongTien.Clear();
            if (cboVaiTro.Items.Count > 0) cboVaiTro.SelectedIndex = 0;
            if (cboGoiTap.Items.Count > 0) cboGoiTap.SelectedIndex = 0;
            if (cboHLV.Items.Count > 0) cboHLV.SelectedIndex = -1; // HLV có thể để trống
            cboThanhToan.SelectedIndex = -1;
            dtpNgayDangKy.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now;

            ToggleEvents(true);
            isDataChanged = false;
            txtHoTen.Focus();
        }

        private void frmChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDataChanged)
            {
                var result = MessageBox.Show("Dữ liệu đã thay đổi nhưng chưa lưu. Bạn có chắc muốn thoát?",
                                           "Xác nhận thoát",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Hủy lệnh đóng Form
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void cboHLV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
