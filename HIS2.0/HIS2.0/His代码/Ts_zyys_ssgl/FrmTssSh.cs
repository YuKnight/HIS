using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace Ts_zyys_ssgl
{
    public partial class FrmTssSh : Form
    {
        public FrmTssSh()
        {
            InitializeComponent();
        }

        private void FrmTssSh_Load(object sender, EventArgs e)
        {
            string sql = " SELECT id,SNO,INPATIENT_ID,INPATIENT_NO,姓名, 性别 ,科室, CASE WHEN 术前诊断='' THEN SSFZ ELSE 术前诊断 END 术前诊断 ,拟施手术 ,    主刀,拟施麻醉, 麻醉师,拟施时间,手术同意书,麻醉同意书,申请医生,申请时间,SQDJCZY,审核人 ,床号,审核日期   "
                       + " FROM ( SELECT DISTINCT a.id,A.SNO,A.INPATIENT_NO, A.INPATIENT_ID, C.NAME 姓名, DBO.FUN_ZY_SEEKSEXNAME(CAST(C.SEXCODE AS CHAR(4))) 性别, DBO.FUN_ZY_SEEKDEPTNAME(A.DEPTID) AS 科室, "
                       + "  DBO.FUN_ZY_SEEKDISEASENAME(CAST(SSFZ AS CHAR(8))) 术前诊断, A.YSSS 拟施手术, DBO.FUN_ZY_SEEKEMPLOYEENAME(ZDYS) 主刀,    S.NAME AS 拟施麻醉, DBO.FUN_ZY_SEEKEMPLOYEENAME(MZYS) 麻醉师, YSSSRQ 拟施时间, CASE WHEN SSTYS = 1 THEN '√' END 手术同意书, "
                       + "  CASE WHEN MZTYS = 1 THEN '√' END 麻醉同意书, DBO.FUN_ZY_SEEKEMPLOYEENAME(SQDJCZY) 申请医生,SQDJCZY,A.SQDJRQ 申请时间,SSFZ  , DBO.FUN_ZY_SEEKEMPLOYEENAME(SHYS) 审核人  "
                       + "  ,(select BED_NO from ZY_BEDDICTION where BED_ID=C.bed_id) as 床号 ,SHRQ 审核日期  "
                       + " FROM SS_APPRECORD A LEFT JOIN SS_ANESTHESIACODE S ON A.YSMZ=CAST(S.ID AS CHAR(10)) INNER JOIN     "
                       + "   VI_ZY_VINPATIENT C ON A.INPATIENT_ID = C.INPATIENT_ID     "
                       + " WHERE SHBJ=2 and tsss_flag=1  and  (A.BDELETE = 0)  ) AA ";

            
            DataTable tb = InstanceForm._database.GetDataTable(sql);
            
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = tb;
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.CurrentCell != null)
                {
                    if (MessageBox.Show("您确认要审核当前选定的手术申请吗?", "手术审核", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int nrow = this.dataGridView1.CurrentCell.RowIndex;
                        DataTable tbtemp = (DataTable)this.dataGridView1.DataSource;
                        string id = tbtemp.DefaultView[nrow]["id"].ToString();
                        string sql = "update SS_APPRECORD set SHBJ=1 ,tsss_shr=" + InstanceForm._currentUser.EmployeeId + ",tsss_shsj=getdate() where id='" + id + "'";
                        InstanceForm._database.DoCommand(sql);
                    }
                }
                FrmTssSh_Load(null,null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bview_Click(object sender, EventArgs e)
        {
            string sql1 = " SELECT id,SNO,INPATIENT_ID,INPATIENT_NO,姓名, 性别 ,科室, CASE WHEN 术前诊断='' THEN SSFZ ELSE 术前诊断 END 术前诊断 ,拟施手术 ,    主刀,拟施麻醉, 麻醉师,拟施时间,手术同意书,麻醉同意书,申请医生,申请时间,SQDJCZY,审核人 ,床号,审核日期,上级审核人,上级审核时间  "
                       + " FROM ( SELECT DISTINCT A.id,DBO.FUN_ZY_SEEKEMPLOYEENAME(tsss_shr) 上级审核人,tsss_shsj 上级审核时间,A.SNO,A.INPATIENT_NO, A.INPATIENT_ID, C.NAME 姓名, DBO.FUN_ZY_SEEKSEXNAME(CAST(C.SEXCODE AS CHAR(4))) 性别, DBO.FUN_ZY_SEEKDEPTNAME(A.DEPTID) AS 科室, "
                       + "  DBO.FUN_ZY_SEEKDISEASENAME(CAST(SSFZ AS CHAR(8))) 术前诊断, A.YSSS 拟施手术, DBO.FUN_ZY_SEEKEMPLOYEENAME(ZDYS) 主刀,    S.NAME AS 拟施麻醉, DBO.FUN_ZY_SEEKEMPLOYEENAME(MZYS) 麻醉师, YSSSRQ 拟施时间, CASE WHEN SSTYS = 1 THEN '√' END 手术同意书, "
                       + "  CASE WHEN MZTYS = 1 THEN '√' END 麻醉同意书, DBO.FUN_ZY_SEEKEMPLOYEENAME(SQDJCZY) 申请医生,SQDJCZY,A.SQDJRQ 申请时间,SSFZ  , DBO.FUN_ZY_SEEKEMPLOYEENAME(SHYS) 审核人  "
                       + "  ,(select BED_NO from ZY_BEDDICTION where BED_ID=C.bed_id) as 床号 ,SHRQ 审核日期  "
                       + " FROM SS_APPRECORD A LEFT JOIN SS_ANESTHESIACODE S ON A.YSMZ=CAST(S.ID AS CHAR(10)) INNER JOIN     "
                       + "   VI_ZY_VINPATIENT C ON A.INPATIENT_ID = C.INPATIENT_ID     "
                       + " WHERE SHBJ=1 and tsss_flag=1 and  tsss_shsj is not null and  (A.BDELETE = 0) and tsss_shsj>='" + this.dtprq1.Value.ToShortDateString() + "' and tsss_shsj<='" + (this.dtprq2.Value.ToShortDateString() + " 23:59:59") + "'  ) AA ";
            DataTable tbysh = InstanceForm._database.GetDataTable(sql1);
            this.dataGridView2.DataSource = tbysh;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            FrmTssSh_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView2.CurrentCell != null)
                {
                    if (MessageBox.Show("您确认要取消审核当前选定的手术申请吗?", "取消手术审核", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int nrow = this.dataGridView2.CurrentCell.RowIndex;
                        DataTable tbtemp = (DataTable)this.dataGridView2.DataSource;
                        string id = tbtemp.DefaultView[nrow]["id"].ToString();
                        string sql = "update SS_APPRECORD set SHBJ=2 ,tsss_shr=null,tsss_shsj=null where id='" + id + "'";
                        InstanceForm._database.DoCommand(sql);
                    }
                }
                FrmTssSh_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bview_Click(null,null);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex<0)
                return;
            int nrow = e.RowIndex ;
            DataTable tbtemp = (DataTable)this.dataGridView1.DataSource;
            object[] communicateValue = new object[7];
            communicateValue[0] = new Guid(tbtemp.DefaultView[nrow]["INPATIENT_ID"].ToString());
            communicateValue[1] = "";
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] =1; 
            communicateValue[6] = tbtemp.DefaultView[nrow]["INPATIENT_NO"].ToString();
            GetForm("Ts_zyys_ssgl", "Fun_Ts_zyys_sssq_cx", "手术申请", InstanceForm._currentUser.UserID, InstanceForm._currentDept.DeptId, communicateValue, true);
        }
        private void GetForm(string dllName, string functionName, string chineseName, long userID, long deptID, object[] communicateValue, bool showType)
        {
            try
            {

                User _user = new User(Convert.ToInt32(userID), FrmMdiMain.Database);
                Department _dept = new Department(Convert.ToInt32(deptID), FrmMdiMain.Database);

                //获得DLL中窗体
                Form _dllform = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, _user, _dept, null, FrmMdiMain.Database, ref communicateValue);
                _dllform.StartPosition = FormStartPosition.CenterScreen;
                if (showType) _dllform.ShowDialog();
                else _dllform.Show();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace.ToString());
                Cursor = Cursors.Default;
                return;
            }
            finally
            {
                
            }
        }
    }
}