using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using YpClass;
using ts_mzys_class;
using System.Net.Sockets;
using System.Threading;
using System.Media;
using System.Text;
using System.Net;
using System.Diagnostics;
using DotNetSpeech;
using ts_mzmr_OperateClass;

namespace ts_mzys_blcflr
{
   
    public partial class FrmYszGhSelect : Form
    {
        public int ysjb = 0;
        /// <summary>
        /// 获得收费项目item_id
        /// </summary>
        public string ItemidArray = "";
        /// <summary>
        /// 是否可以选择级别
        /// </summary>
        public bool Ifkyxzjb = false;

        public FrmYszGhSelect(string xm,string kh , string ye, string ks, string xb,string nl)
        {
            InitializeComponent();
            this.comboBox1.DisplayMember = "级别名称";
            this.comboBox1.ValueMember = "挂号级别";
            this.txtkh.Text=kh;
            this.txtkye.Text=ye;
            this.txtdeptname.Text=ks;
            this.txtage.Text=nl;
            this.txtname.Text = xm;
            this.txtxb.Text = xb;
        }

        private void FrmYszGhSelect_Load(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView2.AutoGenerateColumns = false;
                int ghlx = 1;//挂号类型
                string tj = "=";
                if (Ifkyxzjb)
                    tj = ">=";
                string ssql = "";
                string jb = "";
                DateTime time1 = Convert.ToDateTime("0:00:00");
                DateTime time2 = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase));
                TimeSpan TS = new TimeSpan(time2.Ticks - time1.Ticks);
                int Time = (int)TS.TotalHours;
                string pblx = "1";
                if (Time <= 12)
                    pblx = "1";
                else
                    pblx = "2";
                if (new SystemCfg(3100).Config == "1")
                {
                    jb = "select TYPE_ID 挂号级别,TYPE_NAME 级别名称  from JC_DOCTOR_TYPE  where zcjb" + tj + "( select top 1 YS_TYPEID from JC_ROLE_DOCTOR where EMPLOYEE_ID=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + " )";
                }
                else
                {
                    jb = "select TYPE_ID 挂号级别,TYPE_NAME 级别名称  from JC_DOCTOR_TYPE  where  type_id<>4 and  zcjb" + tj + "( select top 1 YS_TYPEID from JC_ROLE_DOCTOR where EMPLOYEE_ID=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + " ) and zcjb in(1,2,3) ";
                }
                    //Add By zch 2013-04-11 急诊则使用急诊费用
                if (InstanceForm.BCurrentDept.Jz_Flag == 0)
                {
                    ssql = "select cast(GHF_ID as varchar(50))+','+cast(ZCF_ID as varchar(50))+','+cast(JCF_ID as varchar(50))+','+cast(FZF_ID as varchar(50)) as item_id,GHF_ID,ZCF_ID,JCF_ID,FZF_ID,TYPE_ID from JC_DOCTOR_TYPE where zcjb in( select YS_TYPEID from JC_ROLE_DOCTOR where EMPLOYEE_ID=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + " ) and zcjb in(1,2,3)";
                    ghlx = 1;
                    //add by zouchihua 普通门诊按照排班来设置级别 如果没有排班按照默认医生的级别 
                    #region

                    string pbxx = " select * from JC_MZ_YSPB where PBKSID=" + InstanceForm.BCurrentDept.DeptId + " and  ysid='" + InstanceForm.BCurrentUser.UserID + "' and pblx=" + pblx + " and  pbsj='" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + "'";
                    DataTable pbxxtb = InstanceForm.BDatabase.GetDataTable(pbxx);
                    if (pbxxtb.Rows.Count > 0)
                    {
                        ssql = "select cast(GHF_ID as varchar(50))+','+cast(ZCF_ID as varchar(50))+','+cast(JCF_ID as varchar(50))+','+cast(FZF_ID as varchar(50)) as item_id,GHF_ID,ZCF_ID,JCF_ID,FZF_ID,TYPE_ID from JC_DOCTOR_TYPE where TYPE_ID=" + pbxxtb.Rows[0]["ZZJBID"].ToString() + " and zcjb in(1,2,3)";
                        //获得一下 过滤知名专家
                        jb = "  select TYPE_ID 挂号级别,TYPE_NAME 级别名称  from JC_DOCTOR_TYPE  where  ((4!=" + pbxxtb.Rows[0]["ZZJBID"].ToString() + " and type_id!=4) or 1=1)   and  zcjb " + tj + "(select zcjb  from JC_DOCTOR_TYPE where TYPE_ID=" + pbxxtb.Rows[0]["ZZJBID"].ToString() + ") and zcjb in(1,2,3) ";
                    }

                    #endregion
                }
                else
                {
                    ghlx = 2;
                    ssql = "select cast(JGHF_ID as varchar(50))+','+cast(JZCF_ID as varchar(50))+','+cast(JJCF_ID as varchar(50))+','+cast(JFZF_ID as varchar(50)) as item_id,JGHF_ID,JZCF_ID,JJCF_ID,JFZF_ID,TYPE_ID  from JC_DOCTOR_TYPE where zcjb in( select YS_TYPEID from JC_ROLE_DOCTOR where EMPLOYEE_ID=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + " ) and zcjb in(1,2,3)";
                    string pbxx = " select * from JC_MZ_YSPB where PBKSID=" + InstanceForm.BCurrentDept.DeptId + " and  ysid='" + InstanceForm.BCurrentUser.UserID + "' and pblx=" + pblx + " and  pbsj='" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + "'";
                    DataTable pbxxtb = InstanceForm.BDatabase.GetDataTable(pbxx);
                    if (pbxxtb.Rows.Count > 0)
                    {
                        ssql = "select cast(JGHF_ID as varchar(50))+','+cast(JZCF_ID as varchar(50))+','+cast(JJCF_ID as varchar(50))+','+cast(JFZF_ID as varchar(50)) as item_id,JGHF_ID,JZCF_ID,JJCF_ID,JFZF_ID,TYPE_ID  from JC_DOCTOR_TYPE where TYPE_ID=" + pbxxtb.Rows[0]["ZZJBID"].ToString() + " and zcjb in(1,2,3)";
                        jb = "  select TYPE_ID 挂号级别,TYPE_NAME 级别名称  from JC_DOCTOR_TYPE  where  ((4!=" + pbxxtb.Rows[0]["ZZJBID"].ToString() + " and type_id!=4) or 1=1)     and  zcjb " + tj + "(select zcjb  from JC_DOCTOR_TYPE where TYPE_ID=" + pbxxtb.Rows[0]["ZZJBID"].ToString() + ") and zcjb in(1,2,3) ";
                    }
                }
                DataTable tbjb = FrmMdiMain.Database.GetDataTable(jb);
                // this.dataGridView1.DataSource = tbjb;

                this.comboBox1.DataSource = tbjb;

                //获得挂号费
                DataRow dr = InstanceForm.BDatabase.GetDataRow(ssql);
                if (dr != null)
                    ysjb = Convert.ToInt32(dr["TYPE_ID"]);
                else
                {
                    //MessageBox.Show("没有找到该医生对应的级别！\r\n对应sql语句：" + ssql);
                   // this.DialogResult = DialogResult.No;
                  //  this.Close();
                    ysjb = 1;//没有找到默认为1，
                    //return;
                }

                getdefaulType(ysjb);
                int err_code = -1;
                string err_text = "";
                //获得挂号结果集  blb 默认为空
                 DataSet dset=null;
                 SystemCfg cfg3089 = new SystemCfg(3089);//Add by cc 2014-03-18
                if (cfg3089.Config == "1")
                {
                    string strSql = string.Format(@"SELECT TOP 1 a.YHLXID FROM dbo.JC_KYHLXSZ a INNER JOIN dbo.JC_YHLX b ON a.YHLXID = b.ID INNER JOIN 
                                                                    YY_KDJB c ON a.KDJID = c.KDJID 
                                                                    WHERE  KH='{0}'
                                                                    AND b.YHMC ='院内职工免挂号费和治疗费'", this.txtkh.Text.Trim());
                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt.Rows.Count > 0)
                    {
                        dset = mz_ghxx.mzgh_get_sfmx(ghlx, 0, 0, FrmMdiMain.CurrentDept.DeptId, ysjb, FrmMdiMain.CurrentUser.EmployeeId, "", 0, 0, new Guid(dt.Rows[0][0].ToString()), FrmMdiMain.Jgbm, out err_code, out err_text, "", InstanceForm.BDatabase);
                    }
                    else
                    {
                        dset = mz_ghxx.mzgh_get_sfmx(ghlx, 0, 0, FrmMdiMain.CurrentDept.DeptId, ysjb, FrmMdiMain.CurrentUser.EmployeeId, "", 0, 0, Guid.Empty, FrmMdiMain.Jgbm, out err_code, out err_text, "", InstanceForm.BDatabase);
                    }
                }
                else
                {
                    dset = mz_ghxx.mzgh_get_sfmx(ghlx, 0, 0, FrmMdiMain.CurrentDept.DeptId, ysjb, FrmMdiMain.CurrentUser.EmployeeId, "", 0, 0, Guid.Empty, FrmMdiMain.Jgbm, out err_code, out err_text, "", InstanceForm.BDatabase);
                }
                DataTable ghftb = dset.Tables[4];
                for (int i = 0; i <= ghftb.Rows.Count-1; i++)
                {
                    ghftb.Rows[i]["je"] =Convert.ToString( Convert.ToDecimal(ghftb.Rows[i]["je"]) -Convert.ToDecimal(ghftb.Rows[i]["yhje"]));
                }
                // End add by cc 2014-03-18
                decimal hj = decimal.Parse(dset.Tables[4].Compute("sum(je)", "").ToString());
                DataRow row = dset.Tables[4].NewRow();
                row["item_name"] = "合计";
                row["je"] = hj;
                row["item_id"] = -999;
                dset.Tables[4].Rows.Add(row);
                this.dataGridView2.DataSource = ghftb;
                //查找默认的级别
                // this.dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);
                // this.dataGridView1.Focus();

                this.comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
                ChangeSytle();
                this.ActiveControl = this.comboBox1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ssql = "";
            string jb = "";
            int ghlx = 1;//挂号类型
            ysjb = Convert.ToInt32(this.comboBox1.SelectedValue.ToString());
            if (InstanceForm.BCurrentDept.Jz_Flag == 0)
            {

                ssql = "select cast(GHF_ID as varchar(50))+','+cast(ZCF_ID as varchar(50))+','+cast(JCF_ID as varchar(50))+','+cast(FZF_ID as varchar(50)) as item_id,GHF_ID,ZCF_ID,JCF_ID,FZF_ID,TYPE_ID from JC_DOCTOR_TYPE where TYPE_ID=" + ysjb.ToString() + " and zcjb in(1,2,3)";
                //获得一下
                //jb = "  select TYPE_ID 挂号级别,TYPE_NAME 级别名称 from JC_DOCTOR_TYPE  where zcjb >=(select zcjb  from JC_DOCTOR_TYPE where TYPE_ID=" + ysjb.ToString() + ") and zcjb in(1,2,3) ";
                ghlx = 1;//门诊

            }
            else
            {
                ghlx = 2;//急诊
                ssql = "select cast(JGHF_ID as varchar(50))+','+cast(JZCF_ID as varchar(50))+','+cast(JJCF_ID as varchar(50))+','+cast(JFZF_ID as varchar(50)) as item_id,JGHF_ID,JZCF_ID,JJCF_ID,JFZF_ID,TYPE_ID  from JC_DOCTOR_TYPE where TYPE_ID=" + ysjb.ToString() + " and zcjb in(1,2,3)";
                //jb = "  select TYPE_ID 挂号级别,TYPE_NAME 级别名称 from JC_DOCTOR_TYPE  where zcjb >=(select zcjb  from JC_DOCTOR_TYPE where TYPE_ID=" + ysjb.ToString() + ") and zcjb in(1,2,3) ";
            } 

            //ysjb = Convert.ToInt32(dr["TYPE_ID"]);
            //获得挂号结果集  blb 默认为空
            int err_code = -1;
            string err_text = "";
            DataSet dset = mz_ghxx.mzgh_get_sfmx(ghlx, 0, 0, FrmMdiMain.CurrentDept.DeptId, ysjb, FrmMdiMain.CurrentUser.EmployeeId, "", 0, 0, Guid.Empty, FrmMdiMain.Jgbm, out err_code, out err_text, "", InstanceForm.BDatabase);

            DataTable ghftb = dset.Tables[4];
            decimal hj = decimal.Parse(dset.Tables[4].Compute("sum(je)", "").ToString());
            DataRow row = dset.Tables[4].NewRow();
            row["item_name"] = "合计";
            row["je"] = hj;
            row["item_id"] = -999;
            dset.Tables[4].Rows.Add(row);
            this.dataGridView2.DataSource = ghftb;
            ChangeSytle();
        }

        /// <summary>
        /// 改变样式
        /// </summary>
        private void ChangeSytle()
        {
            string je="";
            for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
            {
                if (this.dataGridView2.Rows[i].Cells[0].Value.ToString().Trim() == "合计")
                {
                    this.dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    this.dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    je=  this.dataGridView2.Rows[i].Cells[1].Value.ToString();
                }
                else
                {
                    this.dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    this.dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.White ;
                }
            }
            this.richTextBox1.Text = this.txtname.Text + " 将要挂号 【" + this.comboBox1.Text+"】    ! 挂号总金额【"+je.Trim()+"】"; 
        }

        private void getdefaulType(int typeid)
        { 
            this.comboBox1.SelectedValue = typeid;
        } 

        int flag = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            flag = 1;
            ItemidArray=" ";
            DataTable tb = (DataTable)this.dataGridView2.DataSource;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["item_id"].ToString() != "-999" && tb.Rows[i]["je"].ToString() != "0.00")//Add by cc 2014-03-18
                    ItemidArray += tb.Rows[i]["item_id"].ToString() + ",";
            }
            ItemidArray = ItemidArray.Substring(0, ItemidArray.Length - 1) + "";
                this.DialogResult = DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No ;
        }

        private void FrmYszGhSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(flag==0)
            this.DialogResult = DialogResult.No; 
        }

        private void FrmYszGhSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.F5)
            {
                button1_Click(null,null);
            }
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                button2_Click(null,null);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    button1_Click(null, null);
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.button1.Focus();
            }
        }
    }
}