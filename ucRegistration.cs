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
    public partial class ucRegistration : UserControl
    {
        
        public ucRegistration()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            
        }

        private void FormatGrid()
        {
            
        }

        private void SetupAutoComplete()
        {
            
        }

        private void ucRegistration_Load(object sender, EventArgs e)
        {
        
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

        private void dgvTimeslots_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) 
        {
            
        }

        private void dgvTimeslots_SelectionChanged(object sender, EventArgs e) { }

    }
}
