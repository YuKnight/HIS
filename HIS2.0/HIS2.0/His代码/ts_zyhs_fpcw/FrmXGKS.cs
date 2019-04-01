using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;

namespace ts_zyhs_fpcw
{
    public partial class FrmZk : Form
    {
        public FrmZk(Guid _inpatient_id,string _brname)
        {
            this.inpatient_id = _inpatient_id;
            this.brname = _brname;
            InitializeComponent();

        }
        public string deptid;
        public string deptname;


        private Guid inpatient_id = Guid.Empty;
        private string brname = "";
        private void FrmZk_Load(object sender, EventArgs e)
        {

            string sql = "select dbo.fun_getdeptname(dept_id) NAME,dept_id from JC_DEPT_PROPERTY where ZY_FLAG=1 and DELETED=0";
            DataTable tb;
            if (InstanceForm.BDatabase == null)
                tb = FrmMdiMain.Database.GetDataTable(sql);
            else
            {
                tb = InstanceForm.BDatabase.GetDataTable(sql);
            }
            this.comboBox1.DataSource = tb;
            this.comboBox1.DisplayMember = "NAME";
            this.comboBox1.ValueMember = "DEPT_ID";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将病人：" + brname + "\n转入：" + comboBox1.Text + "", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;

            }
            this.DialogResult = DialogResult.OK;
            deptid = comboBox1.SelectedValue.ToString().Trim();
            deptname = comboBox1.Text;

        }
    }
}