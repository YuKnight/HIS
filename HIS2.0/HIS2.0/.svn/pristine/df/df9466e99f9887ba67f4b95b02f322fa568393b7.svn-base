using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FrmKssVerifySure : Form
    {
        private DataTable _dtNotNeed;
        private int _iConfig;

        private bool _isOk = false;
        public bool IsOk
        {
            get { return _isOk; }
            //set 
            //{
            //    _isOk = value;
            //}
        }

        private int shr = -1;
        public int SHR
        {
            get { return shr; }
            //set 
            //{
            //    _isOk = value;
            //}
        }

        private DateTime shsj = DateTime.Now;
        public DateTime SHSJ
        {
            get { return shsj; }
            //set 
            //{
            //    _isOk = value;
            //}
        }

        private string mima = "";
        public string Mima
        {
            get { return mima; }
            //set 
            //{
            //    _isOk = value;
            //}
        }

        public FrmKssVerifySure()
        {
            InitializeComponent();
        }

        public FrmKssVerifySure(DataTable dtNotNeed, int iConfig)
        {
            InitializeComponent();

            _dtNotNeed = dtNotNeed;
            _iConfig = iConfig;
        }

        private void FrmKssVerifySure_Load(object sender, EventArgs e)
        {
            txtMima.Text = "";
            chkMima.Checked = true;
            pnlIsHide.Visible = !(_iConfig == 0);

            DoShowLableInfo();

            DoQueryVerifyInfo();
        }

        /// <summary>
        /// 查询绑定审核人相关信息
        /// </summary>
        public void DoQueryVerifyInfo()
        {

            string mysql = string.Format(@"select t1.EMPLOYEE_ID,t1.dept_id,NAME from JC_KSSHR t1 inner join JC_EMPLOYEE_PROPERTY t2 on t1.Employee_Id =t2.EMPLOYEE_ID where t1.dept_id='{0}'", InstanceForm._currentDept.DeptId);
            DataTable valDt = InstanceForm._database.GetDataTable(mysql);

            cmbVerify.DataSource = valDt;
            cmbVerify.DisplayMember = "NAME";
            cmbVerify.ValueMember = "EMPLOYEE_ID";
            cmbVerify.SelectedIndex = -1;
        }

        //提示信息
        public void DoShowLableInfo()
        {
            int S = 0;
            string strShow = "";
            for (int i = 0; i <= _dtNotNeed.Rows.Count - 1; i++)
            {
                if (_dtNotNeed.Rows[i]["开始时间"].ToString() != "")
                {
                    S++;
                    strShow += "\n(" + S.ToString() + ")" + _dtNotNeed.Rows[i]["医嘱内容"].ToString().Trim() + "  " + _dtNotNeed.Rows[i]["剂量"].ToString().Trim() + _dtNotNeed.Rows[i]["单位"].ToString().Trim() + "  " + _dtNotNeed.Rows[i]["用法"].ToString().Trim() + " " + _dtNotNeed.Rows[i]["频率"].ToString().Trim();
                }
                else
                {
                    strShow += "\n   " + _dtNotNeed.Rows[i]["医嘱内容"].ToString().Trim() + "  " + _dtNotNeed.Rows[i]["剂量"].ToString().Trim() + _dtNotNeed.Rows[i]["单位"].ToString().Trim();
                }
            }

            lblText.Text = strShow;
            lblText.ForeColor = Color.Red;
            lblText.Font = new Font("宋体", 12f);
            this.Height += _dtNotNeed.Rows.Count * 18;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {


            if (_iConfig==0)
            {
                if (cmbVerify.SelectedValue == null)
                {
                    _isOk = false;
                    MessageBox.Show("请选择一名审批人，在进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVerify.Select();
                    return;
                }
            }

            if (chkMima.Checked && _iConfig == 1)
            {
                if (cmbVerify.SelectedValue == null)
                {
                    _isOk = false;
                    MessageBox.Show("请选择一名审批人，在进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVerify.Select();
                    return;
                }
            }

            _isOk = true;
            if (cmbVerify.SelectedValue == null)
            {
                shr = -1;
            }
            else
            {
                shr = Convert.ToInt32(cmbVerify.SelectedValue.ToString());
            }
            shsj = DateTime.Now;
            mima = txtMima.Text;
            this.Close();

            //if (cmbVerify.SelectedValue == null)
            //{
            //    _isOk = false;
            //    MessageBox.Show("请选择一名审批人，在进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            ////事务回收
            ////FrmMdiMain.Database.CommitTransaction();

            //_isOk = true;
            //MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCanser_Click(object sender, EventArgs e)
        {
            _isOk = false;
            this.Close();
        }
    }
}