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
    public partial class frmEditAccount : Form
    {

        UserBLL bll = new UserBLL();
        UserDTO _selected;
        bool isAddMode = true;
        bool isDataChanged = false;

        public frmEditAccount()
        {
            InitializeComponent();
        }

        public frmEditAccount(UserDTO user, bool isAdd)
        {
            InitializeComponent();
            _selected = user;
            isAddMode = isAdd;
            this.Text = isAdd ? "Thêm tài khoản mới" : "Cập nhật tài khoản";
        }

        private void ToggleEvents(bool active)
        {
            if (active)
            {
                txtUsername.TextChanged += MarkAsChanged;
                txtPassword.TextChanged += MarkAsChanged;
                txtNewPass.TextChanged += MarkAsChanged;
                cboRole.SelectedIndexChanged += MarkAsChanged;
            }
            else
            {
                txtUsername.TextChanged -= MarkAsChanged;
                txtPassword.TextChanged -= MarkAsChanged;
                txtNewPass.TextChanged -= MarkAsChanged;
                cboRole.SelectedIndexChanged -= MarkAsChanged;
            }
        }

        private void MarkAsChanged(object sender, EventArgs e) => isDataChanged = true;

        private void FillData()
        {
            ToggleEvents(false); // Dùng ToggleEvents cho giống bên Trainer
            txtUsername.Text = _selected.Username;
            cboRole.Text = _selected.Role;
            ToggleEvents(true);
            isDataChanged = false;
        }

        private void frmAccountEdits_Load(object sender, EventArgs e)
        {
            // 1. Khởi tạo Role
            cboRole.Items.Clear();
            if (Session.CurrentRole == "Admin")
                cboRole.Items.AddRange(new string[] { "Admin", "Manager", "Receptionist" });
            else if (Session.CurrentRole == "Manager")
                cboRole.Items.AddRange(new string[] { "Receptionist" });

            // 2. Thiết lập hiển thị theo kịch bản "ẩn để bảo vệ" của Huy
            if (isAddMode)
            {
                grpPassword.Visible = true;
                txtPassword.Visible = true;
                txtNewPass.Visible = false;
                lblNotice.Visible = false;
                btnEditPass.Visible = false;
            }
            else
            {
                grpPassword.Visible = false;
                btnEditPass.Visible = true;
                txtNewPass.Enabled = false;

                if (Session.CurrentRole != "Admin")
                {
                    cboRole.Enabled = false;
                    txtUsername.ReadOnly = true;
                }

                if (_selected != null) FillData();
            }

            if (isAddMode) ToggleEvents(true);
        }

        private void btnEditPass_Click(object sender, EventArgs e)
        {
            grpPassword.Visible = true;
            txtPassword.Visible = true;
            txtNewPass.Visible = true;
            lblNotice.Visible = true;
            lblNotice.Text = "Nhập mật khẩu cũ để xác thực";
            lblNotice.ForeColor = Color.Gray;
            txtPassword.Focus();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (isAddMode) return;

            string input = txtPassword.Text;
            if (string.IsNullOrEmpty(input)) return;

            if (bll.VerifyOldPassword(_selected.Username, input))
            {
                lblNotice.Text = "✔ Mật khẩu đúng";
                lblNotice.ForeColor = Color.Green;
                txtNewPass.Enabled = true;
            }
            else
            {
                lblNotice.Text = "✘ Mật khẩu cũ không đúng";
                lblNotice.ForeColor = Color.Red;
                txtNewPass.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản!");
                    return;
                }

                UserDTO dto = isAddMode ? new UserDTO() : _selected;
                dto.Username = txtUsername.Text.Trim();
                dto.Role = cboRole.Text;

                if (isAddMode)
                    dto.Password = txtPassword.Text;
                else if (txtNewPass.Visible && txtNewPass.Enabled)
                    dto.Password = txtNewPass.Text;

                if (bll.Save(dto, isAddMode))
                {
                    MessageBox.Show("Lưu thành công!");
                    isDataChanged = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (isAddMode)
            {
                ToggleEvents(false);
                txtUsername.Clear();
                txtPassword.Clear();
                cboRole.SelectedIndex = 0;
                ToggleEvents(true);
            }
            else FillData();

            isDataChanged = false;
            txtUsername.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDataChanged)
            {
                var r = MessageBox.Show("Dữ liệu chưa lưu. Thoát?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) e.Cancel = true;
            }
        }
    }
}
