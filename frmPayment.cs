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

        // Thông tin cấu hình VietQR (Thay đổi theo tài khoản của chủ Gym)
        private readonly string BANK_ID = "MB"; // Ví dụ: MB, VCB, TCB...
        private readonly string ACCOUNT_NO = "0123456789";
        private readonly string ACCOUNT_NAME = "GYM MANAGEMENT";

        // Constructor mặc định
        public frmPayment()
        {
            InitializeComponent();
        }

        // Constructor nhận DTO từ form Registration hoặc form Danh sách chuyển sang
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
            // Dùng tiếng Việt cho đồng bộ với giao diện
            cboPaymentStatus.Items.AddRange(new[] { "Unpaid", "Partial", "paid" });
        }

        private void FillRegistrationDetails()
        {
            // Hiển thị tất cả thông tin quan trọng dưới dạng ReadOnly
            txtMemberName.Text = _dto.MemberName;
            txtMemberPhone.Text = _dto.MemberPhone;
            txtPackageType.Text = _dto.PackageType;

            // Xử lý hiển thị ngày tháng
            txtRegDate.Text = _dto.RegDate.ToString("dd/MM/yyyy");
            txtEndDate.Text = _dto.EndDate.ToString("dd/MM/yyyy");

            // Xử lý tiền tệ
            txtOriginalPrice.Text = _dto.OriginalPrice.ToString("N0") + " VNĐ";
            txtDiscount.Text = _dto.DiscountAmount.ToString("N0") + " VNĐ";
            txtTotalAmount.Text = _dto.TotalAmount.ToString("N0") + " VNĐ";

            // Map trạng thái hiện tại vào ComboBox
            if (!string.IsNullOrEmpty(_dto.PaymentStatus))
            {
                if (_dto.PaymentStatus == "Paid" || _dto.PaymentStatus == "Đã thanh toán")
                    cboPaymentStatus.SelectedIndex = 0;
                else if (_dto.PaymentStatus == "Partial" || _dto.PaymentStatus == "Thanh toán một phần")
                    cboPaymentStatus.SelectedIndex = 2;
                else
                    cboPaymentStatus.SelectedIndex = 1; // Chưa thanh toán
            }
            else
            {
                cboPaymentStatus.SelectedIndex = 1; // Default "Chưa thanh toán"
            }
        }

        private void GenerateQRCode()
        {
            try
            {
                // Nếu TotalAmount <= 0 thì không cần hiện mã QR
                if (_dto.TotalAmount <= 0)
                {
                    picQRCode.Image = null;
                    lblQRStatus.Text = "Không có hóa đơn cần thanh toán.";
                    return;
                }

                // Cú pháp nội dung CK: "Thanh toan HD [RegID] [TenHoiVien]"
                string addInfo = $"Thanh toan HD {_dto.RegID} {_dto.MemberName}";

                // Dùng Uri.EscapeDataString để xử lý an toàn các ký tự có dấu, khoảng trắng trên URL
                string encodedAddInfo = Uri.EscapeDataString(addInfo);
                string encodedAccountName = Uri.EscapeDataString(ACCOUNT_NAME);

                // URL gọi API tạo mã QR của VietQR 
                string qrUrl = $"https://img.vietqr.io/image/{BANK_ID}-{ACCOUNT_NO}-compact2.png?amount={_dto.TotalAmount}&addInfo={encodedAddInfo}&accountName={encodedAccountName}";

                // Load ảnh bất đồng bộ để form không bị đơ
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

                // Cập nhật trạng thái vào DTO
                _dto.PaymentStatus = cboPaymentStatus.Text;

                // Gọi hàm Save của BLL
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