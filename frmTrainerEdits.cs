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
    public partial class frmTrainerEdits : Form
    {
        TrainerBLL bll = new TrainerBLL();
        TrainerDTO _selectedTr = null;
        bool isAddMode = true;
        bool isDataChanged = false;

        public frmTrainerEdits()
        {
            InitializeComponent();
            isAddMode = true;
            this.Text = "Thêm huấn luyện viên mới";
        }

        public frmTrainerEdits(TrainerDTO trainer)
        {
            InitializeComponent();
            isAddMode = false;
            _selectedTr = trainer;
            this.Text = "Cập nhật thông tin huấn luyện viên";
        }

        private void MarkAsChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
        }

        private void ToggleEvents(bool active)
        {
            if (active)
            {
                txtHLV.TextChanged += MarkAsChanged;
                txtSDT.TextChanged += MarkAsChanged;
                txtNotes.TextChanged += MarkAsChanged;
                cboStatus.SelectedIndexChanged += MarkAsChanged; // thêm
            }
            else
            {
                txtHLV.TextChanged -= MarkAsChanged;
                txtSDT.TextChanged -= MarkAsChanged;
                txtNotes.TextChanged -= MarkAsChanged;
                cboStatus.SelectedIndexChanged -= MarkAsChanged; // thêm
            }
        }

        private void FillData()
        {
            ToggleEvents(false);
            txtHLV.Text = _selectedTr.FullName;
            txtSDT.Text = _selectedTr.Phone;
            txtNotes.Text = _selectedTr.Specialty;
            cboStatus.Text = _selectedTr.Status;  // thêm
            ToggleEvents(true);
            isDataChanged = false;
        }

        private void frmTrainerEdits_Load(object sender, EventArgs e)
        {
            cboStatus.Items.AddRange(new string[] { "Active", "Inactive" }); // thêm

            if (!isAddMode && _selectedTr != null)
                FillData();
            else
            {
                cboStatus.SelectedIndex = 0; // mặc định Active khi Add
                ToggleEvents(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHLV.Text))
            {
                MessageBox.Show("Vui lòng nhập tên Huấn luyện viên!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TrainerDTO dto = isAddMode ? new TrainerDTO() : _selectedTr;
            dto.FullName = txtHLV.Text.Trim();
            dto.Phone = txtSDT.Text.Trim();
            dto.Specialty = txtNotes.Text.Trim();
            dto.Status = cboStatus.Text;  // thêm — không hardcode "Active" nữa

            if (bll.SaveTrainer(dto, isAddMode))
            {
                MessageBox.Show("Lưu thành công!");
                isDataChanged = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lưu thất bại! Vui lòng kiểm tra lại.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (isAddMode)
            {
                ToggleEvents(false);
                txtHLV.Clear();
                txtSDT.Clear();
                txtNotes.Clear();
                cboStatus.SelectedIndex = 0; // thêm — reset về Active
                ToggleEvents(true);
            }
            else
                FillData();

            isDataChanged = false;
            txtHLV.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTrainerEdits_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDataChanged)
            {
                var result = MessageBox.Show(
                    "Dữ liệu đã thay đổi nhưng chưa lưu. Bạn có chắc muốn thoát?",
                    "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}
