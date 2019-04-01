using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Runtime.InteropServices;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using Microsoft.Win32;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace ts_zyhs_fyxx
{
    public partial class FrmZfxmQd : Form
    {
        public FrmZfxmQd()
        {
            InitializeComponent();
        }

        private void FrmZfxmQd_Load(object sender, EventArgs e)
        {
            this.dataGridView2.AutoGenerateColumns = false;
            //获得病人信息 
//            string sql = @"select NAME,BED_NO,INPATIENT_NO,inpatient_id,baby_id,flag,IN_DATE,OUT_DATE,RYZD,CUR_DEPT_NAME from vi_zy_vinpatient_all 
//                           where  flag in(1,3,4,5) and DISCHARGETYPE=1 and  dept_id  in (select dept_id from JC_WARDRDEPT where 
//                           ward_id in (select ward_id from JC_WARDRDEPT where dept_id=" + FrmMdiMain.CurrentDept.DeptId + ") ) order by CHARINDEX('+',bed_no) ASC,ISNUMERIC(bed_no) DESC,CAST(substring(bed_no,PATindex('%[1234567890]%',bed_no),len(bed_no) - patindex('%[1234567890]%',bed_no) + 1) as INT)";
            string sql = @"select NAME,BED_NO,INPATIENT_NO,inpatient_id,baby_id,flag,IN_DATE,OUT_DATE,RYZD,CUR_DEPT_NAME from vi_zy_vinpatient_all 
                           where  flag in(1,3,4,5) and DISCHARGETYPE=1 and  dept_id  in (select dept_id from JC_WARDRDEPT where 
                           ward_id in (select ward_id from JC_WARDRDEPT where dept_id=" + FrmMdiMain.CurrentDept.DeptId + ") ) order by CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no";
           DataTable brinfo = FrmMdiMain.Database.GetDataTable(sql);
           this.dataGridView2.DataSource = brinfo;
            
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.crystalReportViewer1.ShowFirstPage();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.crystalReportViewer1.ShowPreviousPage();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            this.crystalReportViewer1.ShowNextPage();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            this.crystalReportViewer1.ShowLastPage();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            try
            {
                string inpatient_id = ((DataTable)this.dataGridView2.DataSource).Rows[this.dataGridView2.CurrentCell.RowIndex]["inpatient_id"].ToString();
                string baby_id = ((DataTable)this.dataGridView2.DataSource).Rows[this.dataGridView2.CurrentCell.RowIndex]["baby_id"].ToString();
                //获得费用
                string ss = "select cast( row_number() over(order by a.xmid ) as varchar) xh,ITEM_NAME zfxmmc,sum(NUM) sl,min(COST_PRICE) dj, isnull(b.ZFBL,1) zfbl,isnull(b.ZFBL,1)*sum(SDVALUE) zfje "
                    + ",'' jsqm,c.name  bz1,(select config from jc_config where id=2) bz2,CUR_DEPT_NAME bz3,ryzd bz4,'' bz5,'' bz6,'' bz7  "
                    + "  from ZY_FEE_SPECI a  left join JC_YB_BL b on a.XMID=b.XMID and a.XMLY=b.XMLY  "
                    + "  left join  vi_zy_vinpatient_all c on a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id   "
                            + "    where a.CHARGE_BIT=1 and a.DELETE_BIT=0 and DISCHARGE_BIT=0   and SDVALUE!=0 and isnull(b.ZFBL,1)<>0 "
                            + " and a.inpatient_id='" + inpatient_id + "'and a.baby_id=" + baby_id + " group by a.XMID ,a.XMLY,a.ITEM_NAME,b.ZFBL,c.name,c.CUR_DEPT_NAME,c.ryzd  ";
                DataTable tbfee = FrmMdiMain.Database.GetDataTable(ss);
                ts_zyhs_fyxx.DataSet1.tabZfxmqdDataTable tbzfxm = new DataSet1.tabZfxmqdDataTable();
                //for(int i=0;i<tbfee.Rows.Count;)
                ParameterEx[] pa = new ParameterEx[4];
                pa[0].Text = "hzxm";
                pa[0].Value = ((DataTable)this.dataGridView2.DataSource).Rows[this.dataGridView2.CurrentCell.RowIndex]["name"].ToString();
                pa[1].Text = "yymc";
                pa[1].Value = TrasenFrame.Classes.Constant.HospitalName;

                pa[2].Text = "ksmc";
                pa[2].Value = ((DataTable)this.dataGridView2.DataSource).Rows[this.dataGridView2.CurrentCell.RowIndex]["CUR_DEPT_NAME"].ToString();

                pa[3].Text = "ryzd";
                pa[3].Value = ((DataTable)this.dataGridView2.DataSource).Rows[this.dataGridView2.CurrentCell.RowIndex]["ryzd"].ToString();



                ReportDocument rptdoc = new ReportDocument();
                string ss1 = Constant.CustomDirectory;
                try
                {
                    rptdoc.Load(Constant.CustomDirectory + "\\Report\\zyhs_医保自费项目同意签字单.rpt");
                }
                catch
                {
                    rptdoc.Load(Constant.ApplicationDirectory + "\\Report\\zyhs_医保自费项目同意签字单.rpt");
                }
                //for (int i = 0; i < pa.Length; i++)
                //{
                //    rptdoc.SetParameterValue(pa[i].Text, pa[i].Value.ToString());
                //}
                rptdoc.SetDataSource(tbfee);
                // rptdoc.PrintOptions.PrinterName = prtdoc.PrinterSettings.PrinterName;

                // DataTable tb=ts_zyhs_fyxx.tabZfxm
                this.crystalReportViewer1.ReportSource = rptdoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }
    }
}