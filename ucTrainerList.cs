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
    public partial class ucTrainerList : UserControl
    {
        TrainerBLL bll = new TrainerBLL();
        List<TrainerDTO> fullList = new List<TrainerDTO>();
        public ucTrainerList()
        {
            InitializeComponent();
        }

        private void SetupAutoComplete()
        {
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            if (fullList != null && fullList.Count > 0)
            {
                foreach (var tr in fullList)
                {
                    if (!string.IsNullOrEmpty(tr.FullName))
                        collection.Add(tr.FullName);

                    // Gợi ý thêm cả chuyên môn cho tiện tìm kiếm
                    if (!string.IsNullOrEmpty(tr.Specialty) && !collection.Contains(tr.Specialty))
                        collection.Add(tr.Specialty);
                }
            }
            txtSearch.AutoCompleteCustomSource = collection;
        }

        private void FormatGrid()
        {
            if (dgvTrainers.Columns.Count > 0)
            {
                dgvTrainers.Columns["TrainerID"].HeaderText = "Mã HLV";
                dgvTrainers.Columns["FullName"].HeaderText = "Họ và Tên";
                dgvTrainers.Columns["Phone"].HeaderText = "Số điện thoại";
                dgvTrainers.Columns["Specialty"].HeaderText = "Chuyên môn";
                dgvTrainers.Columns["Status"].HeaderText = "Trạng thái"; // thêm
                dgvTrainers.Columns["TotalStudents"].HeaderText = "Số học viên";
                dgvTrainers.Columns["AssignedPackages"].HeaderText = "Gói dạy";

                dgvTrainers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadData()
        {
            fullList = bll.GetData();
            dgvTrainers.DataSource = null;
            dgvTrainers.DataSource = fullList;
            FormatGrid();
            SetupAutoComplete();
        }

        private void ApplyRolePermissions()
        {
            string role = Session.CurrentRole;

            if (role == "Receptionist")
            {
                btnAdd.Enabled = btnEdits.Enabled = btnDelete.Enabled = false;
            }
            else if (role == "Manager")
            {
                btnAdd.Enabled = btnEdits.Enabled = true;
                btnDelete.Enabled = false;
            }
            else // Admin
            {
                btnAdd.Enabled = btnEdits.Enabled = btnDelete.Enabled = true;
            }
        }

        private void ucTrainerList_Load(object sender, EventArgs e) 
        {
            if (this.FindForm()?.Name == "frmGuest")
            {
                btnAdd.Visible = btnDelete.Visible = btnEdits.Visible = btnXuat.Visible = false;
            }
            LoadData();
            ApplyRolePermissions();
        }
        private void btnAdd_Click(object sender, EventArgs e) 
        {
            frmTrainerEdits frm = new frmTrainerEdits(new TrainerDTO(), true);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }
        private void btnEdits_Click(object sender, EventArgs e) 
        {
            if (dgvTrainers.CurrentRow != null)
            {
                var selected = (TrainerDTO)dgvTrainers.CurrentRow.DataBoundItem;
                frmTrainerEdits frm = new frmTrainerEdits(selected, false);
                if (frm.ShowDialog() == DialogResult.OK) LoadData();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e) 
        {
            if (dgvTrainers.CurrentRow != null)
            {
                var selected = (TrainerDTO)dgvTrainers.CurrentRow.DataBoundItem;
                if (MessageBox.Show($"Xác nhận xóa Huấn luyện viên: {selected.FullName}?", "Cảnh báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        if (bll.DeleteTrainer(selected))
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
        private void btnXuat_Click(object sender, EventArgs e) 
        {
            if (dgvTrainers.CurrentRow != null)
            {
                var tr = (TrainerDTO)dgvTrainers.CurrentRow.DataBoundItem;
                string info = $"--- THÔNG TIN HUẤN LUYỆN VIÊN ---\n\n" +
                              $"Mã HLV: {tr.TrainerID}\n" +
                              $"Họ tên: {tr.FullName}\n" +
                              $"Chuyên môn: {tr.Specialty}\n" +
                              $"Liên hệ: {tr.Phone}\n" +
                              $"Số học viên đang dạy: {tr.TotalStudents}";

                MessageBox.Show(info, "Chi tiết HLV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            dgvTrainers.DataSource = null;
            dgvTrainers.DataSource = fullList;
            FormatGrid();
            txtSearch.Focus();

        }
        private void txtSearch_TextChanged(object sender, EventArgs e) 
        {
            string key = txtSearch.Text.ToLower().Trim();
            // Tìm theo tên hoặc chuyên môn
            dgvTrainers.DataSource = fullList.Where(t =>
                t.FullName.ToLower().Contains(key) ||
                t.Specialty.ToLower().Contains(key)
            ).ToList();
        }
        private void dgvTrainers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) { }
        private void dgvTrainers_SelectionChanged(object sender, EventArgs e) { }
    }
}
