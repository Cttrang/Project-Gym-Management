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
    public partial class frmRegistration : Form
    {
        private readonly RegistrationBLL regBll = new RegistrationBLL();
        private readonly MemberBLL memberBll = new MemberBLL();
        private readonly PackageBLL pkgBll = new PackageBLL();
        private readonly TrainerBLL trainerBll = new TrainerBLL();
        private readonly TimeslotBLL slotBll = new TimeslotBLL();

        private readonly RegistrationDTO _dto;
        private readonly bool _isAdd;
        private int _resolvedMemberID = 0; // MemberID cuối cùng dùng để lưu

        // Lưu các slot đã Add vào listbox
        private List<TimeslotDTO> _selectedSlots = new List<TimeslotDTO>();
        
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void InitStaticComboBoxes()
        {
            // Member cũ
            var members = memberBll.GetData();
            cboOldMember.DataSource = members;
            cboOldMember.DisplayMember = "FullName";
            cboOldMember.ValueMember = "MemberID";
            cboOldMember.SelectedIndex = -1;

            // Status member
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new[] { "Active", "Inactive" });
            cboStatus.SelectedIndex = 0;

            // Trainer
            var trainers = trainerBll.GetData();
            cboTrainer.DataSource = trainers;
            cboTrainer.DisplayMember = "FullName";
            cboTrainer.ValueMember = "TrainerID";
            cboTrainer.SelectedIndex = -1;

            // Ngày trong tuần
            cboDayOfWeek.Items.Clear();
            cboDayOfWeek.Items.AddRange(new[] {
                "Thứ 2","Thứ 3","Thứ 4","Thứ 5","Thứ 6","Thứ 7","Chủ Nhật"
            });
            cboDayOfWeek.SelectedIndex = -1;

            // Payment
            cboPayment.Items.Clear();
            cboPayment.Items.AddRange(new[] { "Paid", "Unpaid", "Partial" });
            cboPayment.SelectedIndex = 0;
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            InitStaticComboBoxes();

            if (_isAdd)
            {
                // Mặc định chế độ thêm mới
                dtpRegDate.Value = DateTime.Today;
                dtpRegDate.Enabled = false; // REGDATE = hôm nay, không cho sửa
                dtpRegDate.Value = DateTime.Today;
                dtpRegDate.Enabled = false;
                dtpEndDate.Value = DateTime.Today.AddMonths(1);
                chkIsActive.Checked = true;
                cboPayment.SelectedIndex = 0;

                // Ẩn combobox member cũ, disable input member mới
                cboOldMember.Visible = false;
                SetMemberInputEnabled(false);
                SetPackageSection(null); // Ẩn phần slot ban đầu
            }
            else
            {
                // Edit mode — disable chọn member
                grpOption.Enabled = false;
                grpPersonal.Enabled = false;
                FillForm();
            }
        }

        public frmRegistration(RegistrationDTO dto, bool isAdd)
        {
            
        }

    }
}
