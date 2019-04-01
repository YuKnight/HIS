using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;

namespace ts_mzys_blcflr
{
    public partial class Frmzjqr : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private SystemCfg cg;
        public int ReturnZsID;
        private SystemCfg cfg3035 = new SystemCfg(3035);//Add By Zj 2012-08-27
        /// <summary>
        /// 门诊医生站是否允许医生强制占用诊间,如果强制则原医生的占用记录会被更新 0允许强制占用 1不允许强制占用 默认0
        /// Add By Zp 2014-08-22 
        /// </summary>
        private SystemCfg cfg3141 = new SystemCfg(3141);

        /// <summary>
        /// true数据源从外部传入  
        /// </summary>
        private bool is_bind;

        public Frmzjqr(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            this.Text = chineseName;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }
        /// <summary>
        ///  add by zp 2013-06 
        /// </summary>
        /// <param name="menuTag"></param>
        /// <param name="chineseName"></param>
        /// <param name="mdiParent"></param>
        /// <param name="dt"></param>
        public Frmzjqr(MenuTag menuTag, string chineseName, Form mdiParent, DataTable dt)
        {
            InitializeComponent();
            this.Text = chineseName;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            if (dt != null && dt.Rows.Count > 0)
            {
                is_bind = true;
               
                this.cmbzj.DataSource = dt;
                //Modify by zp 2014-01-09 显示科室名称
                //this.label7.Visible = false;
                //this.cmbks.Visible = false;
                this.cmbks.SelectedValue = dt.Rows[0]["KSDM"];
            }
        } 
        private void butsave_Click(object sender, EventArgs e)
        {
            string ssql;
            string jzid = Convertor.IsNull(cmbzj.SelectedValue, "0");
            DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);


            ssql = "select * from jc_zjsz where zjid=" + jzid + "";
            DataTable tbjz = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tbjz.Rows.Count == 0) return;
            if (tbjz.Rows[0]["BDLBZ"].ToString() == "1")
            {
                if (cfg3141.Config.Trim() == "0") //如果允许强制占用则只给提示 Add by zp 2014-08-22
                {
                    if (tbjz.Rows[0]["wkdz"].ToString() != PubStaticFun.GetMacAddress())
                    {
                        if (MessageBox.Show(this, "该诊室已被其它电脑占用,您确定要强制占用该诊间吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    }
                }
                else  //否则,限制不允许占用已登陆的诊间 Add by zp 2014-08-22
                {
                    if (tbjz.Rows[0]["wkdz"].ToString() != PubStaticFun.GetMacAddress())
                    {
                        MessageBox.Show(this, "该诊室已被其它电脑占用!系统部允许强制占用已被其他医生占用的诊间!如果异议请联系管理员!,", "确认"); return;
                    }
                } //End Modify by zp 2014-08-22
            }

            if (Convert.ToInt16(cg.Config) == 0)
                ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ", wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' where zjid=" + jzid + " ";
            else
                ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ",wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' , ksdm=" + Convertor.IsNull(cmbks.SelectedValue, "0") + " where zjid=" + jzid + " ";
            InstanceForm.BDatabase.DoCommand(ssql);

            if (new SystemCfg(3103).Config == "1")
            {
                string strSql = string.Format(@"update mzhs_fzjl set zsid= {0} where fzys ={1} and BJZBZ in (1,2,4)", jzid, InstanceForm.BCurrentUser.EmployeeId.ToString());
                InstanceForm.BDatabase.DoCommand(strSql); 
            }
            ReturnZsID = Convert.ToInt32(jzid);
            this.Hide();

            if (this.Text != "重新确认诊间")
            {
                Frmblcf Frmhjsf = new Frmblcf(_menuTag, _chineseName, _mdiParent, Convert.ToInt32(jzid));
                if (_mdiParent != null)
                {
                    Frmhjsf.MdiParent = _mdiParent;
                }
                Frmhjsf.Show();
            }

        }

        private void cmbks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ssql = "";
            int ksdm = Convert.ToInt32(Convertor.IsNull(cmbks.SelectedValue, "0"));
            if (Convert.ToInt16(cg.Config) == 0)
                ssql = "select zjid,zjmc+ '['+isnull(bz,'')+']' as zjmc from jc_zjsz where ksdm=" + ksdm + " and bscbz=0 ";
            else
                ssql = "select zjid,zjmc+ '['+isnull(bz,'')+']' as zjmc from jc_zjsz where  bscbz=0 ";
            if (cfg3035.Config != "0")//Add By Zj 2012-08-27
                ssql += " and ZJID_QC<>0 ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            cmbzj.DataSource = tb;
            cmbzj.ValueMember = "zjid";
            cmbzj.DisplayMember = "zjmc";


        }

        private void Frmzjqr_Load(object sender, EventArgs e)
        {
            cg = new SystemCfg(3001);
        }

        private void Frmzjqr_Activated(object sender, EventArgs e)
        {
            string ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where deleted=0 " +
            " and dept_id in (select dept_id from jc_dept_type_relation where type_code in('001','002','003','004'))";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            tb.TableName = "tb";
            cmbks.ValueMember = "DEPT_ID";
            cmbks.DisplayMember = "NAME";
            cmbks.DataSource = tb;

            cmbks.SelectedValue = InstanceForm.BCurrentDept.DeptId.ToString();
            if (Convert.ToInt16(cg.Config) == 0)
                cmbks.Enabled = false;


        }

        private void butquit_Click(object sender, EventArgs e)
        {
            ReturnZsID = -1;
            this.Close();
        }


    }
}