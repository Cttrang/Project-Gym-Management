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
    public partial class ucTimeSlotRegis : UserControl
    {
        public ucTimeSlotRegis()
        {
            InitializeComponent();
        }

        private void ucTimeslotRegis_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
        private void btnEdits_Click(object sender, EventArgs e)
        {
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Form parent = this.FindForm();
            if (parent is frmMain main) main.ShowUc();
            else if (parent is frmGuest guest) guest.ShowUc();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void dgvTimeslots_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) { }
        private void dgvTimeslots_SelectionChanged(object sender, EventArgs e) { }

    }
}
