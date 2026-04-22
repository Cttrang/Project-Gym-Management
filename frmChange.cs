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
        { 
            InitializeComponent();
            isAddMode = false;
            selectedRow = row;
            cboVaiTro.Enabled = false;
        }

        private void ToggleFormByRole(string role)
        {
            bool isMember = (role == "Member");
            bool isTrainer = (role == "Trainer");

            cboGoiTap.Enabled = isMember;
            dtpNgayDangKy.Enabled = isMember;
            dtpNgayHetHan.Enabled = isMember;
            cboHLV.Enabled = isMember;
            txtTongTien.Enabled = isMember;
            cboThanhToan.Enabled = isMember;

            txtNotes.Enabled = isTrainer;

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
                txtNotes.TextChanged += MarkAsChanged;
            }
            else
            {
                txtHoTen.TextChanged -= MarkAsChanged;
                txtSDT.TextChanged -= MarkAsChanged;
                cboVaiTro.SelectedIndexChanged -= MarkAsChanged;
                cboThanhToan.SelectedIndexChanged -= MarkAsChanged;
                cboHLV.SelectedIndexChanged -= MarkAsChanged;
                txtNotes.TextChanged -= MarkAsChanged;
            }
        }

        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
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
            
            txtHoTen.Text = selectedRow.Cells["FULLNAME"].Value.ToString();
            txtSDT.Text = selectedRow.Cells["PHONE"].Value.ToString();
            cboVaiTro.Text = selectedRow.Cells["TYPE"].Value.ToString();
            cboStatus.Text = selectedRow.Cells["STATUS"].Value?.ToString();

            string role = cboVaiTro.Text;
            ToggleFormByRole(role);

            if (role == "Member")
            {
                string paymentStatus = selectedRow.Cells["PAYMENTSTATUS"].Value?.ToString();

                if (selectedRow.Cells["PACKAGEID"].Value != DBNull.Value)
                {
                    cboGoiTap.SelectedValue = selectedRow.Cells["PACKAGEID"].Value;

                    if (cboGoiTap.SelectedItem is DataRowView row)
                    {
                        string packageType = row["TYPE"]?.ToString();
                        if (packageType == "Class")
                        {
                            cboHLV.Enabled = false;
                            cboHLV.SelectedIndex = -1;
                        }
                    }
                }

                if (selectedRow.Cells["TRAINERID"].Value != DBNull.Value)
                    cboHLV.SelectedValue = selectedRow.Cells["TRAINERID"].Value;
                else
                {
                    cboHLV.SelectedIndex = -1;
                    cboHLV.Enabled=false;
                }    
                    
                if (selectedRow.Cells["REGDATE"].Value != DBNull.Value)
                    dtpNgayDangKy.Value = Convert.ToDateTime(selectedRow.Cells["REGDATE"].Value);

                if (selectedRow.Cells["ENDDATE"].Value != DBNull.Value)
                    dtpNgayHetHan.Value = Convert.ToDateTime(selectedRow.Cells["ENDDATE"].Value);

                cboThanhToan.Text = selectedRow.Cells["PAYMENTSTATUS"].Value?.ToString();

                if (selectedRow.Cells["TOTALAMOUNT"].Value != DBNull.Value)
                    txtTongTien.Text = Convert.ToDecimal(
                        selectedRow.Cells["TOTALAMOUNT"].Value).ToString("N0");
                if (paymentStatus == "Paid")
                {
                    cboGoiTap.Enabled = false;
                    cboThanhToan.Enabled = false;
                    dtpNgayDangKy.Enabled = false;
                    dtpNgayHetHan.Enabled = false;
                    cboHLV.Enabled = false; 
                    txtTongTien.BackColor = Color.LightGray;
                    MessageBox.Show("Gói tập đã thanh toán, chỉ có thể sửa thông tin cá nhân.");
                    //lblThongBao.ForeColor = Color.Red;
                }
            }
            else if (role == "Trainer")
            {
                // GHICHU của Trainer = Specialty
                txtNotes.Text = selectedRow.Cells["GHICHU"].Value?.ToString();
            }

            ToggleEvents(true);
            isDataChanged = false;
        }

        private void cboGoiTap_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboGoiTap.SelectedItem == null) return;
                if (!(cboGoiTap.SelectedItem is DataRowView)) return;

                DataRowView row = (DataRowView)cboGoiTap.SelectedItem;

                int months = Convert.ToInt32(row["DURATIONMONTHS"]);
                dtpNgayHetHan.Value = dtpNgayDangKy.Value.AddMonths(months);
                txtTongTien.Text = Convert.ToDecimal(row["PRICE"]).ToString("N0");

                string packageType = row["TYPE"]?.ToString();
                if (packageType == "Class") 
                {
                    cboHLV.Enabled = false;
                    cboHLV.SelectedIndex = -1; 
                }
                else
                {
                    cboHLV.Enabled = true;
                }
                isDataChanged = true;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi thầm lặng hoặc báo nhẹ cho người dùng
                Console.WriteLine("Lỗi tính toán gói tập: " + ex.Message);
            }
        }

        private void frmChange_Load(object sender, EventArgs e)
        {
            try
            {
                cboVaiTro.Items.AddRange(new string[] { "Member", "Trainer" });
                cboStatus.Items.AddRange(new string[] { "Active", "Inactive" });

                cboGoiTap.DataSource = bll.GetPackages();
                cboGoiTap.DisplayMember = "PACKAGENAME";
                cboGoiTap.ValueMember = "PACKAGEID";

                cboHLV.DataSource = bll.GetTrainers();
                cboHLV.DisplayMember = "FULLNAME";
                cboHLV.ValueMember = "TRAINERID";
                cboHLV.SelectedIndex = -1;

                if (!isAddMode && selectedRow != null)
                {
                    FillData();
                }
                else
                {
                    ToggleFormByRole("Member");
                    ToggleEvents(true);
                    isDataChanged = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu danh mục: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form luôn vì không có dữ liệu gói tập thì không làm gì được
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               string role = cboVaiTro.Text;

               if (string.IsNullOrEmpty(role))
               {
                   MessageBox.Show("Vui lòng chọn Vai trò!", "Thông báo",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return;
               }

               MemberDTO dto = new MemberDTO
               {
                   FullName = txtHoTen.Text,
                   Phone = txtSDT.Text,
                   Role = role,
                   Status = cboStatus.Text
               };

               if (!isAddMode)
                   dto.ID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

               if (role == "Member")
               {
                   dto.PackageID = (int)cboGoiTap.SelectedValue;
                   dto.TrainerID = cboHLV.SelectedValue as int?;
                   dto.RegDate = dtpNgayDangKy.Value;
                   dto.EndDate = dtpNgayHetHan.Value;
                   dto.TotalAmount = decimal.Parse(txtTongTien.Text.Replace(".", ""));
                   dto.PaymentStatus = cboThanhToan.Text;
               }
               else if (role == "Trainer")
               {
                   dto.GhiChu = txtNotes.Text; // Specialty của Trainer
               }

               if (bll.SaveData(dto, isAddMode))
               {
                   MessageBox.Show("Thành công!");
                   isDataChanged = false;
                   this.DialogResult = DialogResult.OK;
               }
               else
               {
                   MessageBox.Show("Lưu thất bại! Vui lòng kiểm tra lại thông tin.",
                                   "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (isAddMode)
            {
                ToggleEvents(false);
                txtHoTen.Clear();
                txtSDT.Clear();
                txtTongTien.Clear();
                txtNotes.Clear();
                cboStatus.SelectedIndex = -1;

                if (cboVaiTro.Items.Count > 0) cboVaiTro.SelectedIndex = 0;
                if (cboGoiTap.Items.Count > 0) cboGoiTap.SelectedIndex = 0;
                if (cboHLV.Items.Count > 0) cboHLV.SelectedIndex = -1;

                cboThanhToan.SelectedIndex = -1;
                dtpNgayDangKy.Value = DateTime.Now;
                dtpNgayHetHan.Value = DateTime.Now;

                cboGoiTap.Enabled = true;
                cboThanhToan.Enabled = true;
                dtpNgayDangKy.Enabled = true;
                dtpNgayHetHan.Enabled = true;
                txtTongTien.BackColor = Color.White;
                // lblThongBao.Text = "";

                ToggleEvents(true);
                isDataChanged = false;
                txtHoTen.Focus();
            }
            else
            {
                // TRƯỜNG HỢP EDIT: Nạp lại dữ liệu cũ từ Grid
                if (selectedRow != null)
                {
                    FillData(); 
                }
            }
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
                    e.Cancel = true;
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void cboHLV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayDangKy_ValueChanged(object sender, EventArgs e)
        {
            if (cboGoiTap.SelectedItem == null) return;
            if (!(cboGoiTap.SelectedItem is DataRowView)) return;

            DataRowView row = (DataRowView)cboGoiTap.SelectedItem;
            int months = Convert.ToInt32(row["DURATIONMONTHS"]);
            dtpNgayHetHan.Value = dtpNgayDangKy.Value.AddMonths(months);

            isDataChanged = true;
        }
    }
}
