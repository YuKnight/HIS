using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Diagnostics;
using ts_mzys_class;
using ts_mz_class;

namespace ts_mzys_fzgl
{
    public partial class FrmKzqzz : Form
    {
        public FrmKzqzz()
        {
            InitializeComponent();
        }
        private string blh;
        private Fz_Zq _CurrentZq;


        public FrmKzqzz(string _blh , Fz_Zq _zq)
        {
            InitializeComponent();
            blh = _blh;
            _CurrentZq = _zq;
        }

        private void FrmKzqzz_Load(object sender, EventArgs e)
        {
            cmbDept.DataSource = _CurrentZq.GetZqDeptInfo(_CurrentZq.Zqid, InstanceForm.BDatabase); //Fun.GetGhks(false, InstanceForm.BDatabase); ;
            cmbDept.ValueMember = "ø∆ “id";
            cmbDept.DisplayMember = "ø∆ “√˚≥∆";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           bool bReturn=  MZHS_FZJL.KzzZz(Convert.ToInt32(_CurrentZq.Zqid),Convert.ToInt32(this.cmbDept.SelectedValue), blh, InstanceForm.BDatabase);
           if (bReturn)
           {
               this.DialogResult = DialogResult.OK;
               this.Close();
           }
           else
           {
               this.DialogResult = DialogResult.No;
               this.Close();
           }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}   