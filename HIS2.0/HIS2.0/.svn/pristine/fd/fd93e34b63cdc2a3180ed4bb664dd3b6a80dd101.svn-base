using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using Ts_zyys_public;

namespace Ts_zyys_hzgl
{
    public partial class FrmHzddy : Form
    {
        public DataTable Tb;
        public FrmHzddy()
        {
            InitializeComponent();
            this.dgvPat.AutoGenerateColumns = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"select 0 选择 ,b.INPATIENT_NO 住院号,BED_NO 床号 ,b.NAME  病人姓名,dbo.fun_getDeptname(DEPT_BR) 科室 ,dbo.fun_getEmpName(APPLY_DOC) 申请医生,APPLY_DATE 申请日期, "
                    + " AGE 年龄,WARD_NAME 病区,  SEX_NAME 性别,        "
                    + " a.CONTENT 病史及检查,INTENT 会诊目的,b.INPATIENT_ID,0 baby_id,isnull(isprint,0) isprint,id from ZY_CONSULTATION a left join VI_ZY_VINPATIENT_ALL b "
                    + "   on a.INPATIENT_ID=b.INPATIENT_ID and a.baby_id=b.baby_id  "
                    + "   where a.BABY_ID=0  and b.FLAG in(1,3,4) and DEPT_BR in (select dept_id  from JC_WARDRDEPT where ward_id in(select ward_id from JC_WARDRDEPT where DEPT_ID=" + FrmMdiMain.CurrentDept.DeptId + ") ) "
                    + "   union all   "
                    + "    select 1 选择 ,b.INPATIENT_NO 住院号,BED_NO 床号 ,b.NAME  病人姓名,dbo.fun_getDeptname(DEPT_BR) 科室 ,dbo.fun_getEmpName(APPLY_DOC) 申请医生,APPLY_DATE 申请日期,   "
                    + " AGE 年龄,WARD_NAME 病区,    SEX_NAME 性别,         "
                    + "   a.CONTENT 病史及检查,INTENT 会诊目的,b.INPATIENT_ID ,b.BABY_ID,isnull(isprint,0) isprint,id  from ZY_CONSULTATION a left join VI_ZY_VINPATIENT_ALL b on a.INPATIENT_ID=b.INPATIENT_ID and a.BABY_ID=b.BABY_ID  "
                    + "  where a.BABY_ID>0  and b.FLAG in(1,3,4) and DEPT_BR in (select dept_id  from JC_WARDRDEPT where ward_id in(select ward_id from JC_WARDRDEPT where DEPT_ID=" + FrmMdiMain.CurrentDept.DeptId + ") ) ";
            Tb = FrmMdiMain.Database.GetDataTable(sql);
            radioydy_Click(null,null);
        }

        private void radioydy_Click(object sender, EventArgs e)
        {
            if (Tb == null)
                return;
            string tj = " 1=1 ";
            if (this.radiowdy.Checked)
            {
                tj += " and isprint=0 ";
            }
            else
                tj += " and isprint=1 ";
            if(this.txtzyh.Text.Trim()!="")
                tj+=" and 住院号='"+this.txtzyh.Text.Trim()+"'";
            if(this.txtcwh.Text.Trim()!="")
                tj += " and 床号='" + this.txtcwh.Text.Trim() + "'";
            Tb.DefaultView.RowFilter = tj;
            this.dgvPat.DataSource = Tb;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnqx_Click(object sender, EventArgs e)
        {
            DataView view = Tb.DefaultView;
            for (int i = 0; i < view.Count; i++)
            {
                view[i]["选择"] = 1;
            }
        }

        private void btnfx_Click(object sender, EventArgs e)
        {
            DataView view = Tb.DefaultView;
            for (int i = 0; i < view.Count; i++)
            {
                if (view[i]["选择"].ToString().Trim() == "0")
                    view[i]["选择"] = 1;
                else
                    view[i]["选择"] = 0;
            }
        }

        private void FrmHzddy_Load(object sender, EventArgs e)
        {
            string sql = @"select 0 选择 ,b.INPATIENT_NO 住院号,BED_NO 床号 ,b.NAME  病人姓名,dbo.fun_getDeptname(DEPT_BR) 科室 ,dbo.fun_getEmpName(APPLY_DOC) 申请医生,APPLY_DATE 申请日期, "
                      + " AGE 年龄,WARD_NAME 病区,  SEX_NAME 性别,        "
                      + " a.CONTENT 病史及检查,INTENT 会诊目的,b.INPATIENT_ID,0 baby_id,isnull(isprint,0) isprint,id from ZY_CONSULTATION a left join VI_ZY_VINPATIENT_ALL b "
                      + "   on a.INPATIENT_ID=b.INPATIENT_ID and a.baby_id=b.baby_id  "
                      + "   where a.BABY_ID=0  and b.FLAG in(1,3,4) and DEPT_BR in (select dept_id  from JC_WARDRDEPT where ward_id in(select ward_id from JC_WARDRDEPT where DEPT_ID=" + FrmMdiMain.CurrentDept.DeptId + ") ) "
                      + "   union all   "
                      + "    select 1 选择 ,b.INPATIENT_NO 住院号,BED_NO 床号 ,b.NAME  病人姓名,dbo.fun_getDeptname(DEPT_BR) 科室 ,dbo.fun_getEmpName(APPLY_DOC) 申请医生,APPLY_DATE 申请日期,   "
                      + " AGE 年龄,WARD_NAME 病区,    SEX_NAME 性别,         "
                      + "   a.CONTENT 病史及检查,INTENT 会诊目的,b.INPATIENT_ID ,b.BABY_ID,isnull(isprint,0) isprint,id  from ZY_CONSULTATION a left join VI_ZY_VINPATIENT_ALL b on a.INPATIENT_ID=b.INPATIENT_ID and a.BABY_ID=b.BABY_ID  "
                      + "  where a.BABY_ID>0  and b.FLAG in(1,3,4) and DEPT_BR in (select dept_id  from JC_WARDRDEPT where ward_id in(select ward_id from JC_WARDRDEPT where DEPT_ID=" + FrmMdiMain.CurrentDept.DeptId + ") ) ";
            Tb = FrmMdiMain.Database.GetDataTable(sql);
            Tb.DefaultView.RowFilter = " isprint=0";
            this.dgvPat.DataSource = Tb;
        }

        private void buttondy_Click(object sender, EventArgs e)
        {
            DataView view = Tb.DefaultView;

            //view.RowFilter = "床号='01'";
            ParameterEx[] pa = new ParameterEx[1];
            pa[0].Text = "报表名称";
            if(radiowdy.Checked)
              pa[0].Value = "会诊申请单";
            else
              pa[0].Value = "会诊申请单(补打)";
            for (int i = 0; i < view.Count; i++)
            {
                if (view[i]["选择"].ToString().Trim() == "1")
                {
                    DataSet1.HzdDataTable hzdtb = new DataSet1.HzdDataTable(); 
                     
                    DataTable tbdy = hzdtb;
                    string sql = "select dbo.fun_getDeptname(CON_DEPT) 被邀科室,CON_DATE,dbo.fun_getEmpName(CON_DOC) 会诊医师,ACCEPT_DATE,CONTENT from ZY_CON_MX where P_ID='" + view[i]["id"] + "'";
                    DataTable tbcommx = FrmMdiMain.Database.GetDataTable(sql);
                    if (tbcommx.Rows.Count == 0)
                    {
                        DataRow dr = tbdy.NewRow();
                        dr["姓名"] = view[i]["病人姓名"];
                        dr["床号"] = view[i]["床号"];
                        dr["住院号"] = view[i]["住院号"];
                        dr["病区"] = view[i]["病区"];
                        dr["科室"] = view[i]["科室"];
                        dr["年龄"] = view[i]["年龄"];
                        dr["性别"] = view[i]["性别"];
                        dr["简要病史及检查"] = view[i]["病史及检查"];
                        dr["会诊目的"] = view[i]["会诊目的"];
                        dr["申请医师"] = view[i]["申请医生"];
                        dr["申请日期"] = view[i]["申请日期"];
                        tbdy.Rows.Add(dr);
                    }
                    else
                    {

                        for (int j = 0; j < tbcommx.Rows.Count; j++)
                        {
                            DataRow dr = tbdy.NewRow();
                            dr["姓名"] = view[i]["病人姓名"];
                            dr["床号"] = view[i]["床号"];
                            dr["住院号"] = view[i]["住院号"];
                            dr["病区"] = view[i]["病区"];
                            dr["科室"] = view[i]["科室"];
                            dr["年龄"] = view[i]["年龄"];
                            dr["性别"] = view[i]["性别"];
                            dr["简要病史及检查"] = view[i]["病史及检查"];
                            dr["会诊目的"] = view[i]["会诊目的"];
                            dr["申请医师"] = view[i]["申请医生"];
                            dr["申请日期"] = view[i]["申请日期"];

                            dr["会诊意见"] = tbcommx.Rows[j]["CONTENT"].ToString();
                            dr["会诊医师"] = tbcommx.Rows[j]["会诊医师"].ToString();
                            dr["会诊日期"] = tbcommx.Rows[j]["ACCEPT_DATE"].ToString();
                            dr["被邀科室"] = tbcommx.Rows[j]["被邀科室"].ToString();
                            for (int x = 1; x <= 7; x++)
                            {
                                dr["bz" + x.ToString()] = "";
                            }
                                tbdy.Rows.Add(dr);
                        }
                    }
                     
                    bool bview=this.checkBox1.Checked?false:true;
                    string[] sqls =new string[1]; 
                    sqls[0]=" update  ZY_CONSULTATION set isprint=1 where ID='"+view[i]["id"]+"'";
                    //打印
                    TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(tbdy, Constant.ApplicationDirectory + "\\report\\zyys_会诊单打印.rpt",pa,bview);//sqls[0]);
                    f._sqlStr = sqls;
                    if (f.LoadReportSuccess) f.Show(); else f.Dispose();
                }
            }
            this.button1_Click(null,null);
        }

        private void txtzyh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\r')
                radioydy_Click(null, null);
        }
    }
}