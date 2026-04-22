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
    public partial class ucAccountManager : UserControl
    {
        UserBLL bll = new UserBLL();
        List<UserDTO> fullList = new List<UserDTO>();
        public ucAccountManager()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                fullList = bll.GetAll();
                dgvAccounts.DataSource = null;
                dgvAccounts.DataSource = fullList;
                FormatGrid();
                SetupAutoComplete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvAccounts.Columns.Count == 0) return;

            dgvAccounts.Columns["UserID"].Visible = false; // ẩn ID
            dgvAccounts.Columns["Password"].Visible = false; //ẩn password

            dgvAccounts.Columns["Username"].HeaderText = "Tên đăng nhập";
            dgvAccounts.Columns["Role"].HeaderText = "Vai trò";

            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupAutoComplete()
        {
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var col = new AutoCompleteStringCollection();
            foreach (var u in fullList)
            {
                if (!string.IsNullOrEmpty(u.Username)) col.Add(u.Username);
                if (!string.IsNullOrEmpty(u.Role) && !col.Contains(u.Role)) col.Add(u.Role);
            }
            txtSearch.AutoCompleteCustomSource = col;
        }

        private void ucAccountManager_Load(object sender, EventArgs e) 
        {
            if (Session.CurrentRole != "Admin")
            {
                btnAdd.Visible = false;
                btnEdits.Visible = false;
                btnDelete.Visible = false;
            }
            LoadData();
        }

        private UserDTO GetSelected()
        {
            if (dgvAccounts.CurrentRow == null) return null;
            return (UserDTO)dgvAccounts.CurrentRow.DataBoundItem;
        }

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            var frm = new frmEditAccount(new UserDTO(), true);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }
        private void btnEdits_Click(object sender, EventArgs e) 
        {
            var selected = GetSelected();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var frm = new frmEditAccount(selected, false);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }
        private void btnDelete_Click(object sender, EventArgs e) 
        {
            var selected = GetSelected();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(
                $"Xác nhận xóa tài khoản: {selected.Username} ({selected.Role})?",
                "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                try
                {
                    if (bll.Delete(selected))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Không thể xóa",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void btnXuat_Click(object sender, EventArgs e) 
        {
            var selected = GetSelected();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string info = $"--- THÔNG TIN TÀI KHOẢN ---\n\n" +
                          $"Mã:           {selected.UserID}\n" +
                          $"Tên đăng nhập:{selected.Username}\n" +
                          $"Vai trò:      {selected.Role}";
            MessageBox.Show(info, "Chi tiết tài khoản",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnOut_Click(object sender, EventArgs e) 
        {
            Form parent = this.FindForm();
            if (parent is frmMain main) main.ShowUc();
            else if (parent is frmGuest guest) guest.ShowUc();
        }
        private void btnClearSearch_Click(object sender, EventArgs e) 
        {
            txtSearch.Clear();
            dgvAccounts.DataSource = null;
            dgvAccounts.DataSource = fullList;
            FormatGrid();
            txtSearch.Focus();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) 
        {
            if (fullList == null) return;
            string key = txtSearch.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(key))
            {
                dgvAccounts.DataSource = fullList;
            }
            else
            {
                dgvAccounts.DataSource = fullList.Where(u =>
                    (u.Username?.ToLower().Contains(key) ?? false) ||
                    (u.Role?.ToLower().Contains(key) ?? false)
                ).ToList();
            }
            FormatGrid();
        }
        private void dgvAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) 
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvAccounts.Rows.Count) return;
            var user = (UserDTO)dgvAccounts.Rows[e.RowIndex].DataBoundItem;
            if (user == null) return;

            switch (user.Role)
            {
                case "Admin":
                    dgvAccounts.Rows[e.RowIndex].DefaultCellStyle.ForeColor
                        = System.Drawing.Color.DarkRed;
                    break;
                case "Manager":
                    dgvAccounts.Rows[e.RowIndex].DefaultCellStyle.ForeColor
                        = System.Drawing.Color.DarkBlue;
                    break;
                case "Receptionist":
                    dgvAccounts.Rows[e.RowIndex].DefaultCellStyle.ForeColor
                        = System.Drawing.Color.DarkGreen;
                    break;
            }

            if (user.Username == Session.CurrentUsername)
                dgvAccounts.Rows[e.RowIndex].DefaultCellStyle.Font =
                    new System.Drawing.Font(dgvAccounts.Font, System.Drawing.FontStyle.Bold);

        }
        private void dgvAccounts_SelectionChanged(object sender, EventArgs e) { }

    }
}
