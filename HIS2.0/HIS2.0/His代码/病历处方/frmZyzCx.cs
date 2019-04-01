using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mzys_class;
using ts_mz_class;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_mzys_blcflr
{
    public partial class frmZyzCx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public frmZyzCx()
        {
            InitializeComponent();
        }
        public frmZyzCx(MenuTag menuTag, string chineseName, Form mdiParent)
        {

            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            
        }
        private void butref_Click(object sender, EventArgs e)
        {
            try
            {
                string rq1 = chkrq.Checked == true ? dtp1.Value.ToShortDateString() : "";
                string rq2 = chkrq.Checked == true ? dtp2.Value.ToShortDateString() : "";

                DataTable tb = mzys_zyz.GetRecord(rq1, rq2, InstanceForm.BCurrentUser.EmployeeId, -1,
                    Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh1.Text.Trim(), txtbrxm.Text.Trim(), Guid.Empty, InstanceForm.BDatabase);
                dataGridView1.DataSource = tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butclose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkrq_CheckedChanged(object sender, EventArgs e)
        {
            dtp1.Enabled = chkrq.Checked == true ? true : false;
            dtp2.Enabled = chkrq.Checked == true ? true : false;
        }

        private void txtkh1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtkh1.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh1.Text.Trim(), InstanceForm.BDatabase);
                butref_Click(sender, e);
            }
        }

        private void txtbrxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                butref_Click(sender, e);
        }

        private void frmZyzCx_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);  
        }
    }
}