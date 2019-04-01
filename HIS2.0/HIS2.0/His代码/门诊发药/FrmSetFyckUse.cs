using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;

namespace ts_yf_mzfy
{
    public partial class FrmSetFyckUse : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        public FrmSetFyckUse()
        {
            InitializeComponent();
        }

        public FrmSetFyckUse(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = chineseName;
        }

        private void FrmSetFyckUse_Load(object sender, EventArgs e)
        {

            DataTable dt = DoBindCmb();
            Addcmb(cmbDept, dt, "DEPTID", "ksmc");

            cmbDept.SelectedValue = InstanceForm.BCurrentDept.DeptId;

            cmbDept.Enabled = false;

            DoQuery();

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DoQuery();
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgr = this.dataGridView1.CurrentRow;

            if (dgr == null)
            {
                return;
            }

            string code = dgr.Cells["code"].Value.ToString();

            string yfdm = dgr.Cells["yfdm"].Value.ToString();

            int flag = 1;

            bool bSuc=DoSetQyBit(code, flag, yfdm);

            if (bSuc)
            {
                DoQuery();
                MessageBox.Show("操作成功");
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgr = this.dataGridView1.CurrentRow;

            if (dgr == null)
            {
                return;
            }

            string code = dgr.Cells["code"].Value.ToString();

            string yfdm = dgr.Cells["yfdm"].Value.ToString();

            int flag = 0;

            bool bSuc = DoSetQyBit(code, flag, yfdm);

            if (bSuc)
            {
                DoQuery();
                MessageBox.Show("操作成功");
            }
        }

        private bool DoSetQyBit(string code, int flag, string yfdm)
        {
            InstanceForm.BDatabase.BeginTransaction();
            try
            {
                string ssql = "";

                //启用或禁用 该 窗口
                ssql = string.Format(@"update JC_FYCK set BZYBZ='{0}' where code='{1}' and YFDM='{2}'", flag, code, yfdm);
                int iret = InstanceForm.BDatabase.DoCommand(ssql);

                if (iret <= 0)
                {
                    throw new Exception("未更新到窗口编码：" + code + "的窗口");
                }

                ssql = string.Format(@"update JC_FYCK set fpzs=0 where YFDM='{1}'", flag, yfdm);
                InstanceForm.BDatabase.DoCommand(ssql);

                InstanceForm.BDatabase.CommitTransaction();

                return true;
            }
            catch (Exception ex)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void DoQuery()
        {
            string deptid = cmbDept.SelectedValue.ToString();

            DataTable dt = DoGetFyck(deptid);

            DoBindData(dt, dataGridView1);

        }

        private void DoBindData(DataTable dtSrc, DataGridView grdDes)
        {
            if (dtSrc != null)
            {
                grdDes.DataSource = dtSrc;
                (grdDes.DataSource as DataTable).AcceptChanges();
            }
        }

        private DataTable DoBindCmb()
        {
            string strSql = "select ksmc ,DEPTID from yp_yjks where szjgbm=1000  and kslx='药房'";

            DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql);

            return dt;
        }

        private DataTable DoGetFyck(string deptid)
        {
            string strSql = string.Format(@"select CODE,NAME,case BZYBZ when 1 then '启用' when 0 then '停用' end as BZYBZ,FPZS,dbo.fun_getDeptname(YFDM) as YFDMMC,YFDM 
                                                from JC_FYCK where YFDM='{0}'", deptid);

            DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql);

            return dt;
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }
    }
}