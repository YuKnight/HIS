using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;

namespace Ts_ss_brcx
{
    public partial class FrmShow : Form
    {
        public FrmShow()
        {
            InitializeComponent();
        }

        public Guid INPATIENT_ID = Guid.Empty;
        private void FrmShow_Load(object sender, EventArgs e)
        {
            ComBindS();
        }

        private void ComBindS()
        {
            string sql = "select t.YSSS,t1.DEPTID from SS_ARRRECORD t right join ss_apprecord t1 on t.SNO=t1.SNO where t.INPATIENT_ID='201776F8-F258-4501-86ED-A3330099BB26' and t.bdelete=0 and t1.BDELETE=0";

            DataTable dt = FrmMdiMain.Database.GetDataTable(sql); ;
            DataRow dr = dt.NewRow();
            this.comboxss.DataSource = dt;
            this.comboxss.DisplayMember = "YSSS";
            this.comboxss.ValueMember = "DEPTID";
            this.comboxss.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBrcx frm = (frmBrcx)this.Owner;
            frm.StrValue =this.comboxss.SelectedValue.ToString();
            this.Close();
        }

        private void FrmShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmBrcx frm = (frmBrcx)this.Owner;
            frm.StrValue = this.comboxss.SelectedValue.ToString();
        }
    }
}