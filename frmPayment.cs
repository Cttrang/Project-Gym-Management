using desktopapp_GYM.BLL;
using desktopapp_GYM.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace desktopapp_GYM
{
    public partial class frmPayment : Form
    {
        private readonly RegistrationBLL regBll = new RegistrationBLL();
        private readonly RegistrationDTO _dto;
        private bool _isLoading = false;

        private readonly string BANK_ID = "MB"; // Ví dụ: MB, VCB, TCB...
        private readonly string ACCOUNT_NO = "0123456789";
        private readonly string ACCOUNT_NAME = "GYM MANAGEMENT";

        public frmPayment()
        {
            InitializeComponent();
        }

        public frmPayment(RegistrationDTO dto)
        {
            InitializeComponent();
            _dto = dto;
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            if (_dto == null)
            {
                MessageBox.Show("Không tìm thấy thông tin đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _isLoading = true;
            InitComboBox();
            FillRegistrationDetails();
            GenerateQRCode();
            _isLoading = false;
        }

        private void InitComboBox()
        {
            cboPaymentStatus.Items.Clear();
            cboPaymentStatus.Items.AddRange(new[] { "Unpaid", "Partial", "paid" });
        }

        private void FillRegistrationDetails()
        {
            txtMemberName.Text = _dto.MemberName;
            txtMemberPhone.Text = _dto.MemberPhone;
            txtPackageType.Text = _dto.PackageType;

            txtRegDate.Text = _dto.RegDate.ToString("dd/MM/yyyy");
            txtEndDate.Text = _dto.EndDate.ToString("dd/MM/yyyy");

            txtOriginalPrice.Text = _dto.OriginalPrice.ToString("N0") + " VNĐ";
            txtDiscount.Text = _dto.DiscountAmount.ToString("N0") + " VNĐ";
            txtTotalAmount.Text = _dto.TotalAmount.ToString("N0") + " VNĐ";

            if (!string.IsNullOrEmpty(_dto.PaymentStatus))
            {
                if (_dto.PaymentStatus == "Paid" || _dto.PaymentStatus == "Đã thanh toán")
                    cboPaymentStatus.SelectedIndex = 0;
                else if (_dto.PaymentStatus == "Partial" || _dto.PaymentStatus == "Thanh toán một phần")
                    cboPaymentStatus.SelectedIndex = 2;
                else
                    cboPaymentStatus.SelectedIndex = 1; 
            }
            else
            {
                cboPaymentStatus.SelectedIndex = 1; 
            }
        }

        private void GenerateQRCode()
        {
            try
            {
                if (_dto.TotalAmount <= 0)
                {
                    picQRCode.Image = null;
                    lblQRStatus.Text = "Không có hóa đơn cần thanh toán.";
                    return;
                }

                string addInfo = $"Thanh toan HD {_dto.RegID} {_dto.MemberName}";
                string encodedAddInfo = Uri.EscapeDataString(addInfo);
                string encodedAccountName = Uri.EscapeDataString(ACCOUNT_NAME);

                string qrUrl = $"https://img.vietqr.io/image/{BANK_ID}-{ACCOUNT_NO}-compact2.png?amount={_dto.TotalAmount}&addInfo={encodedAddInfo}&accountName={encodedAccountName}";

                picQRCode.LoadAsync(qrUrl);
                lblQRStatus.Text = "Quét mã để thanh toán";
            }
            catch (Exception ex)
            {
                lblQRStatus.Text = "Lỗi tải mã QR.";
                Console.WriteLine("QR Error: " + ex.Message);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPaymentStatus.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dto.PaymentStatus = cboPaymentStatus.Text;

                bool result = regBll.Save(_dto, false);

                if (result)
                {
                    MessageBox.Show("Cập nhật thanh toán thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại, vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}