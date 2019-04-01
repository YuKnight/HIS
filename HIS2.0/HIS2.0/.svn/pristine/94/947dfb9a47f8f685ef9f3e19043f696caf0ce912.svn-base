using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
namespace ts_zyhs_kqqr
{
    public partial class Frmkyqqr : Form
    {
        private BaseFunc myFunc;
        /// <summary>
        /// 
        /// </summary>
        private int _sign = 0;
        public Frmkyqqr()
        {
            InitializeComponent();
            this.DgvTszlqr.AutoGenerateColumns = false;
            this.DgvZkqr.AutoGenerateColumns = false;
            this.DgvCancelZk.AutoGenerateColumns = false;
            this.DgvCancelTs.AutoGenerateColumns = false;
            this.groupBox2.Visible = false;
            myFunc = new BaseFunc();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Caption"></param>
        /// <param name="sign">0护士站审核，1=医保审核,2=欠费审核</param>
        public Frmkyqqr(string Caption,int sign)
        {
            InitializeComponent();
            this.Text = Caption;
            this.DgvTszlqr.AutoGenerateColumns = false;
            this.DgvZkqr.AutoGenerateColumns = false;
            this.DgvCancelZk.AutoGenerateColumns = false;
            this.DgvCancelTs.AutoGenerateColumns = false;
            this.groupBox2.Visible = false;
            this.tabControl1.TabPages.Remove(this.tabPage1);
            this.tabControl1.TabPages.Remove(this.tpCelTszl);
            this.tabControl1.TabPages.Remove(this.tpCelZk);
            if(this._sign==1)
               this.tabPage2.Text = "跨院转科医保确认";
            if(this._sign==2)
                this.tabPage2.Text = "跨院转科欠费确认";
            this._sign = sign;
            myFunc = new BaseFunc();
        }
        private void Frmkyqqr_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;
            Cursor.Current = PubStaticFun.WaitCursor();
            string sSql = "";
            if (_sign == 0)
            {
                this.DgvZkqr.Columns[0].Visible = false;
                #region 获得特殊治疗信息
                sSql = " select dbo.fun_getdate(APPLY_DATE) 申请日期,convert(char,APPLY_DATE,108) 申请时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,a.SEX_NAME 性别,a.DISCHARGETYPE,"
                      + "dbo.FUN_ZY_SEEKDEPTNAME(d.Dept_id) 源科室,dbo.FUN_ZY_SEEKDEPTNAME(d.TS_DEPT) 目标科室,dbo.FUN_ZY_SEEKJGBMMC(d.TS_DEPT) 目标院区,dbo.FUN_ZY_SEEKEMPLOYEENAME(d.APPLY_DOC) 申请医生,dbo.fun_getdate(book_date) 登记日期,a.inpatient_id,a.baby_id,"
                      + "b.isMYTS,d.dept_br,d.Dept_id,d.sh_user,d.TS_DEPT,d.id,d.jgbm, d.APPLY_DATE from ZY_TS_APPLY d left join ZY_BEDDICTION b on d.inpatient_id=b.inpatient_id,vi_zy_vinpatient_bed a "
                     + "where a.inpatient_id=d.inpatient_id and a.baby_id=d.baby_id  and d.DELETE_BIT=0 and d.status_flag<2 "
                     + " and d.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')"
                     + "   and  cast(d.id as varchar(36)) not  in (select YZJ from ts_update_log where  BSCBZ=0 and  CZLX in(501,502,401) ) "
                     + "and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=TS_DEPT)!= " + FrmMdiMain.Jgbm;//跨远区申请都需要护士站审核
                DataTable tb = FrmMdiMain.Database.GetDataTable(sSql);
                DgvTszlqr.DataSource = tb;
                #endregion
                #region 获得转科信息
                sSql = "select dbo.fun_getdate(Transfer_date) 转科日期,convert(char,Transfer_date,108) 转科时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,a.SEX_NAME 性别,dbo.FUN_ZY_SEEKDEPTNAME(d.s_Dept_id) 源科室,dbo.FUN_ZY_SEEKJGBMMC(d.d_Dept_id) 目标院区,dbo.FUN_ZY_SEEKDEPTNAME(d.d_Dept_id) 目标科室,dbo.FUN_ZY_SEEKEMPLOYEENAME(d.operator) 医生,dbo.fun_getdate(book_date) 登记日期,a.inpatient_id,a.baby_id,b.isMYTS,d.d_Dept_id,d.s_Dept_id,d.order_id,d.id,d.yb_bit,d.qf_bit,a.DISCHARGETYPE " +
                      "  from ZY_TRANSFER_dept d left join ZY_BEDDICTION b on d.inpatient_id=b.inpatient_id,vi_zy_vinpatient_bed a " + //and d.baby_id=b.baby_id Modify by tany 2011-03-07 婴儿和母亲同一张床
                      "	where a.inpatient_id=d.inpatient_id and a.baby_id=d.baby_id " +
                      "         and d.s_Dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') and d.finish_bit=0 and d.cancel_bit=0"//and d.finish_bit=0
                       + "   and cast(d.id as varchar(36)) not  in (select YZJ from ts_update_log where  BSCBZ=0 and  CZLX in(501,502,401) ) "
                        + "and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=d_Dept_id)!= " + FrmMdiMain.Jgbm;
                DataTable tb_Tsdept = FrmMdiMain.Database.GetDataTable(sSql);
                this.DgvZkqr.DataSource = tb_Tsdept;
                #endregion
                #region 取消转科(转科标记为【1】完成) ，已产生日志，且没有执行完成
                sSql = "select dbo.fun_getdate(Transfer_date) 转科日期,convert(char,Transfer_date,108) 转科时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,a.SEX_NAME 性别,dbo.FUN_ZY_SEEKDEPTNAME(d.s_Dept_id) 源科室,dbo.FUN_ZY_SEEKJGBMMC(d.d_Dept_id) 目标院区,dbo.FUN_ZY_SEEKDEPTNAME(d.d_Dept_id) 目标科室,dbo.FUN_ZY_SEEKEMPLOYEENAME(d.operator) 医生,dbo.fun_getdate(book_date) 登记日期,a.inpatient_id,a.baby_id,b.isMYTS,d.d_Dept_id,d.s_Dept_id,d.order_id,d.id,a.DISCHARGETYPE " +
                     "  from ZY_TRANSFER_dept d left join ZY_BEDDICTION b on d.inpatient_id=b.inpatient_id,vi_zy_vinpatient_all a " + //and d.baby_id=b.baby_id Modify by tany 2011-03-07 婴儿和母亲同一张床
                     "	where a.inpatient_id=d.inpatient_id and a.baby_id=d.baby_id " +
                     "         and d.s_Dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') and d.finish_bit=1 and d.cancel_bit=0"
                     + " and  cast(d.id as varchar(36)) in (select YZJ from ts_update_log where BWCBZ=0 and BSCBZ=0  and  CZLX in(501,502,401)) "
                     + "and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=d_Dept_id)!= " + FrmMdiMain.Jgbm;//跨远区申请都需要护士站审核
                DataTable CelTranstb = FrmMdiMain.Database.GetDataTable(sSql);
                this.DgvCancelZk.DataSource = CelTranstb;
                #endregion
                #region 取消特殊治疗 产生日志，且为完成
                sSql = " select dbo.fun_getdate(APPLY_DATE) 申请日期,convert(char,APPLY_DATE,108) 申请时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,a.SEX_NAME 性别,"
                      + "dbo.FUN_ZY_SEEKDEPTNAME(d.Dept_id) 源科室,dbo.FUN_ZY_SEEKDEPTNAME(d.TS_DEPT) 目标科室,dbo.FUN_ZY_SEEKJGBMMC(d.TS_DEPT) 目标院区,dbo.FUN_ZY_SEEKEMPLOYEENAME(d.APPLY_DOC) 申请医生,dbo.fun_getdate(book_date) 登记日期,a.inpatient_id,a.baby_id,a.DISCHARGETYPE,"
                      + "b.isMYTS,d.Dept_id,d.TS_DEPT,d.id  from ZY_TS_APPLY d left join ZY_BEDDICTION b on d.inpatient_id=b.inpatient_id,vi_zy_vinpatient_bed a "
                     + "where a.inpatient_id=d.inpatient_id and a.baby_id=d.baby_id  and d.DELETE_BIT=0 and d.status_flag<2 "
                     + " and d.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')"
                     + "  and  cast(d.id as varchar(36)) in (select YZJ from ts_update_log where BWCBZ=0 and BSCBZ=0 and  CZLX in(501,502,401) ) "
                     + "and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=TS_DEPT)!= " + FrmMdiMain.Jgbm;//跨远区申请都需要护士站审核
                DataTable CancelTstb = FrmMdiMain.Database.GetDataTable(sSql);
                this.DgvCancelTs.DataSource = CancelTstb;
                #endregion
                //add by zouchihua 2014-4-20 增加跨院取消
                #region 已经跨院的特殊治疗取消列表获取
                sSql = " select dbo.fun_getdate(APPLY_DATE) 申请日期,convert(char,APPLY_DATE,108) 申请时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,a.SEX_NAME 性别,"
                   + "dbo.FUN_ZY_SEEKDEPTNAME(d.Dept_id) 源科室,dbo.FUN_ZY_SEEKDEPTNAME(d.TS_DEPT) 目标科室,dbo.FUN_ZY_SEEKJGBMMC(d.TS_DEPT) 目标院区,dbo.FUN_ZY_SEEKEMPLOYEENAME(d.APPLY_DOC) 申请医生,dbo.fun_getdate(book_date) 登记日期,a.inpatient_id,a.baby_id,a.DISCHARGETYPE,"

                   + "b.isMYTS,d.Dept_id,d.TS_DEPT,d.id, (select top 1 MBJGBM from ts_update_log where  YZJ=cast(d.id as varchar(36)) and BWCBZ=1 and BSCBZ=0 )  MBJGBM "
                   +"  from ZY_TS_APPLY d left join ZY_BEDDICTION b on d.inpatient_id=b.inpatient_id,vi_zy_vinpatient_bed a "
                  + "where a.inpatient_id=d.inpatient_id and a.baby_id=d.baby_id  and d.DELETE_BIT=0 and d.status_flag<2 "
                  + " and d.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')"
                  + "  and  cast(d.id as varchar(36)) in (select YZJ from ts_update_log where BWCBZ=1 and BSCBZ=0 and  CZLX in(501,502,401) ) "
                  + "and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=TS_DEPT)!= " + FrmMdiMain.Jgbm;//跨远区申请都需要护士站审核
                DataTable CancelTskytb= FrmMdiMain.Database.GetDataTable(sSql);
                this.dataGridView1.DataSource = CancelTskytb;
                #endregion
                #region 已经跨院的转科取消列表获取
                sSql = "select dbo.fun_getdate(Transfer_date) 转科日期,convert(char,Transfer_date,108) 转科时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,a.SEX_NAME 性别,dbo.FUN_ZY_SEEKDEPTNAME(d.s_Dept_id) 源科室,dbo.FUN_ZY_SEEKJGBMMC(d.d_Dept_id) 目标院区,dbo.FUN_ZY_SEEKDEPTNAME(d.d_Dept_id) 目标科室,dbo.FUN_ZY_SEEKEMPLOYEENAME(d.operator) 医生,dbo.fun_getdate(book_date) 登记日期,a.inpatient_id,a.baby_id,b.isMYTS,d.d_Dept_id,d.s_Dept_id,d.order_id,d.id,a.DISCHARGETYPE " +
                     " , (select top 1 MBJGBM from ts_update_log where  YZJ=cast(d.id as varchar(36)) and BWCBZ=1 and BSCBZ=0 )  MBJGBM " +
                   "  from ZY_TRANSFER_dept d left join ZY_BEDDICTION b on d.inpatient_id=b.inpatient_id,vi_zy_vinpatient_all a " + //and d.baby_id=b.baby_id Modify by tany 2011-03-07 婴儿和母亲同一张床
                   "	where a.inpatient_id=d.inpatient_id and a.baby_id=d.baby_id " +
                   "         and d.s_Dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') and d.finish_bit=1 and d.cancel_bit=0"
                   + " and  cast(d.id as varchar(36)) in (select YZJ from ts_update_log where BWCBZ=1 and BSCBZ=0  and  CZLX in(501,502,401)) "
                   + "and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=d_Dept_id)!= " + FrmMdiMain.Jgbm;//跨远区申请都需要护士站审核
                DataTable CelTranskytb = FrmMdiMain.Database.GetDataTable(sSql);
                this.dataGridView2.DataSource = CelTranskytb;
                #endregion
            }
            else
                if (_sign == 1)//医保科确认
                {
                    this.DgvZkqr.Columns[0].Visible = true;
                     
                    #region 获得转科信息
                    sSql = "select dbo.fun_getdate(Transfer_date) 转科日期,convert(char,Transfer_date,108) 转科时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,a.SEX_NAME 性别,dbo.FUN_ZY_SEEKDEPTNAME(d.s_Dept_id) 源科室,dbo.FUN_ZY_SEEKJGBMMC(d.d_Dept_id) 目标院区,dbo.FUN_ZY_SEEKDEPTNAME(d.d_Dept_id) 目标科室,dbo.FUN_ZY_SEEKEMPLOYEENAME(d.operator) 医生,dbo.fun_getdate(book_date) 登记日期,a.inpatient_id,a.baby_id,b.isMYTS,d.d_Dept_id,d.s_Dept_id,d.order_id,d.id,a.DISCHARGETYPE " +
                         " , case when yb_bit=0  then '不允许' else '允许' end as 确认标记  " +
                        "  from ZY_TRANSFER_dept d left join ZY_BEDDICTION b on d.inpatient_id=b.inpatient_id,vi_zy_vinpatient_bed a " + //and d.baby_id=b.baby_id Modify by tany 2011-03-07 婴儿和母亲同一张床
                          "	where a.inpatient_id=d.inpatient_id and a.baby_id=d.baby_id and a.DISCHARGETYPE=1 " +//医保病人
                          "       and d.finish_bit=0 and d.cancel_bit=0 "//and d.finish_bit=0
                          + "   and cast(d.id as varchar(36))   not  in (select YZJ from ts_update_log where  BSCBZ=0 and  CZLX in(501,502,401) ) "
                            + " and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=d_Dept_id)!= " + FrmMdiMain.Jgbm;
                    DataTable tb_Tsdept = FrmMdiMain.Database.GetDataTable(sSql);
                    this.DgvZkqr.DataSource = tb_Tsdept;
                    #endregion
                   
                }
                else
                    if(_sign==2)//欠费审核
                    {
                        this.DgvZkqr.Columns[0].Visible = true;
                        this.DgvZkqr.Columns["费用余额1"].CellTemplate.Style.BackColor = Color.Pink;
                        this.DgvZkqr.Columns["费用余额1"].Visible = true;
                        #region 获得转科信息
                        sSql = "select dbo.fun_getdate(Transfer_date) 转科日期,convert(char,Transfer_date,108) 转科时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,a.SEX_NAME 性别,dbo.FUN_ZY_SEEKDEPTNAME(d.s_Dept_id) 源科室,dbo.FUN_ZY_SEEKJGBMMC(d.d_Dept_id) 目标院区,dbo.FUN_ZY_SEEKDEPTNAME(d.d_Dept_id) 目标科室,dbo.FUN_ZY_SEEKEMPLOYEENAME(d.operator) 医生,dbo.fun_getdate(book_date) 登记日期,a.inpatient_id,a.baby_id,b.isMYTS,d.d_Dept_id,d.s_Dept_id,d.order_id,d.id,a.DISCHARGETYPE " +
                             " , case when Qf_bit=0  then '不允许' else '允许' end as 确认标记 ,dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id,a.baby_id) 费用余额" +
                            "  from ZY_TRANSFER_dept d left join ZY_BEDDICTION b on d.inpatient_id=b.inpatient_id,vi_zy_vinpatient_bed a " + //and d.baby_id=b.baby_id Modify by tany 2011-03-07 婴儿和母亲同一张床
                              "	where a.inpatient_id=d.inpatient_id and a.baby_id=d.baby_id  " +
                              "       and d.finish_bit=0 and d.cancel_bit=0  and isnull(dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id,a.baby_id),0)<0 "//and d.finish_bit=0
                              + "   and  cast(d.id as varchar(36)) not  in (select YZJ from ts_update_log where  BSCBZ=0 and  CZLX in(501,502,401) ) "
                                + " and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=d_Dept_id)!= " + FrmMdiMain.Jgbm;
                        DataTable tb_Tsdept = FrmMdiMain.Database.GetDataTable(sSql);
                        this.DgvZkqr.DataSource = tb_Tsdept;
                        #endregion
                    }
            Cursor.Current =Cursors.Default;
        }
        //护士转科判断
        private bool Transdeptcheck()
        {
            DataTable myTb = (DataTable)this.DgvZkqr.DataSource;
            if (myTb == null || myTb.Rows.Count == 0) return false;
            int nrow = this.DgvZkqr.CurrentCell.RowIndex;
            string sBinID = myTb.Rows[nrow]["inpatient_id"].ToString().Trim();
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();
            long nSDeptID = Convert.ToInt64(myTb.Rows[nrow]["s_Dept_id"]);
            long nDDeptID = Convert.ToInt64(myTb.Rows[nrow]["d_Dept_id"]);
            string sOrderId = myTb.Rows[nrow]["order_id"].ToString().Trim();

            int isMYTS = 0;
            if (myTb.Rows[nrow]["isMYTS"].ToString().Trim() != "")
            {
                isMYTS = Convert.ToInt32(myTb.Rows[nrow]["isMYTS"]);
            }

            //判断是否是婴儿先转科
            if (isMYTS != 0 && Convert.ToInt32(sBabyID) == 0)
            {
                MessageBox.Show(this, "对不起，请先将婴儿转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            string sMsg = "";
            string sSql = "";
            DataTable tempTb = new DataTable();
            bool isBTYZ = false;//是否不停医嘱
            try
            {

                #region//判断是否有未停止的医嘱、判断是否有未记帐的费用
                sSql = " select sum(id1) as id1,sum(id2) as id2 from ( " +
                        " select count(a.order_id) id1,0 id2 " +
                        "  from zy_orderrecord a " +
                        "  where a.status_flag<5 and a.delete_bit=0 " +
                        "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID +
                                            " union all" +
                                            " select 0 id1,count(b.id) id2 " +
                                            "  from zy_fee_speci b " +
                                            "  where b.charge_bit=0 and b.delete_bit=0 " +
                                            "  and b.inpatient_id='" + sBinID + "' and b.baby_id=" + sBabyID + //Modify By Tany 2004-12-22 转科可以不判断费用
                        " ) tmp";
                    tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
                    {
                        sMsg = "有未停止的医嘱";
                    }
                    if (Convert.ToInt32(tempTb.Rows[0]["id2"]) > 0)
                    {
                        sMsg += sMsg == "" ? "有" : "和";
                        sMsg = "未记帐的费用";
                    }
                    if (sMsg != "")
                    {
                        MessageBox.Show(this, "对不起，该病人" + sMsg + "，不允许转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnWzx_Click(null, null);
                        return false;
                    }
                #endregion
                #region //需增加是否领药判断 Modify by Zouchihua 2011-10-12
                 sSql = "select id from ZY_FEE_SPECI where FY_BIT=0 and XMLY=1 " + " and inpatient_id='" + sBinID + "' and DELETE_BIT=0";
                 tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                 if (tempTb.Rows.Count > 0)
                 {
                     MessageBox.Show(this, "对不起，该病人有未领取的药品 ，不允许转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     FrmWclXm fr = new FrmWclXm();
                     fr.inpatient_id = sBinID;
                     fr.baby_id = sBabyID;
                     fr.ShowDialog();
                     return false;
                 }
                #endregion
                #region //医嘱必须要转操
                sSql = "select count(a.order_id) id1" +
                    "  from zy_orderrecord a " +
                    "  where a.status_flag<2 and a.delete_bit=0 " +
                    "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID;
                tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
                {
                    MessageBox.Show(this, "对不起，该病人有未转抄的医嘱，不允许转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                #endregion
                #region//临时医嘱必须发送后才能转科
                sSql = "select count(a.order_id) id1" +
                    "  from zy_orderrecord a " +
                    "  where a.status_flag<5 and a.delete_bit=0 and mngtype in (1,5)" +
                    "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID;
                tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
                {
                    MessageBox.Show(this, "对不起，该病人有未执行的临时医嘱，不允许转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                #endregion
                #region //包床病人必须取消包床
                sSql = "Select 1 from zy_BedDiction where inpatient_id='" + sBinID + "' and isbf=1";
                tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (tempTb.Rows.Count > 0)
                {
                    MessageBox.Show(this, "对不起，该病人有包床，请取消包床后再转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                #endregion
                #region//Modify By zouchihua 2011-10-12 如果有特殊治疗申请没有完成，提示
                sSql = "Select *,dbo.fun_getdeptname(ts_dept) tsdept_name from ZY_TS_APPLY where inpatient_id='" + sBinID + "' and status_flag=1 and delete_bit=0";
                tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (tempTb.Rows.Count > 0)
                {
                    string ss = "";
                    for (int i = 0; i < tempTb.Rows.Count; i++)
                    {
                        ss += "申请时间：" + tempTb.Rows[i]["apply_date"].ToString() + "   科室：" + tempTb.Rows[i]["tsdept_name"].ToString() + "   内容：" + tempTb.Rows[i]["content"].ToString() + "\r\n";
                    }
                    MessageBox.Show(this, "对不起，该病人存在有特殊治疗未完成"+"\n 【"+ss+"】", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                #endregion
                #region --如果开启了交账模式，则判断结算和预交金是否交账
                if(new SystemCfg(5019).Config.ToString().Trim()=="1")
                {
                    string ss = " select * from zy_deposits where turn_bit=0  and  CANCEL_BIT=0 and inpatient_id='" + sBinID + "'";
                  DataTable tb1=FrmMdiMain.Database.GetDataTable(ss);
                  if (tb1.Rows.Count>0)
                  {
                      MessageBox.Show(this, "对不起，该病人存在预交金未交帐", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      return false;
                  }
                  ss = "select * from zy_discharge where turn_bit=0 and inpatient_id='" + sBinID + "' and CANCEL_BIT=0";
                  DataTable tb2 = FrmMdiMain.Database.GetDataTable(ss);
                  if (tb2.Rows.Count > 0)
                  {
                      MessageBox.Show(this, "对不起，该病人存在结算未交帐", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      return false;
                  }
                }
                #endregion
                
                #region //医技是否确认
                string yjqr = "select * from YJ_ZYSQ  where BJSBZ=0 and inpatient_id='" + sBinID + "' and bscbz=0";
                DataTable tbYj = FrmMdiMain.Database.GetDataTable(yjqr);
                if(tbYj.Rows.Count>0)
                {
                    MessageBox.Show(this, "对不起，该病人存在未确认的医技项目", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                #endregion
                //重新检索数据库获得欠费和医保控制标记
                string Kzsql = "  select * from ZY_TRANSFER_DEPT WHERE cast(ID as varchar(36))='" + myTb.Rows[nrow]["id"].ToString().Trim() + "' and CANCEL_BIT=0";
                DataTable tbKz = FrmMdiMain.Database.GetDataTable(Kzsql);
                if (tbKz == null || tbKz.Rows.Count == 0)
                {
                    MessageBox.Show(this, "对不起，该条记录不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                #region  欠费控制
                if (new SystemCfg(19003).Config == "1" && myTb.Rows[nrow]["DISCHARGETYPE"].ToString().Trim() == "0")
                {
                  
                    DataTable yjk = FrmMdiMain.Database.GetDataTable("select isnull(sum(YJK),0) yjk  from ( SELECT 0 WJSZFY,  CASE ARRIVE_BIT   WHEN 1   THEN NVALUES  ELSE 0   END YJK  FROM ZY_DEPOSITS  WHERE CANCEL_BIT<>1  "
                           +" AND DISCHARGE_BIT<>1 "
                          + " AND INPATIENT_ID='" + sBinID + "') fee ");
                    DataTable wjszfy = FrmMdiMain.Database.GetDataTable("select isnull(sum(WJSZFY),0) WJSZFY from (   SELECT   CASE DISCHARGE_BIT  WHEN 0  THEN ACVALUE  ELSE 0   END WJSZFY,0 YJK    FROM ZY_FEE_SPECI  "
                                       +" WHERE CHARGE_BIT=1  "
                                      +"  AND DELETE_BIT=0   "
                                     + "  AND INPATIENT_ID='" + sBinID + "' ) fee ");
                    decimal _yjk=decimal.Parse(yjk.Rows[0]["yjk"].ToString());
                    decimal _wjszfy=decimal.Parse(wjszfy.Rows[0]["WJSZFY"].ToString());

                    decimal _fye = 0;
                     
                    if (myTb.Rows[nrow]["DISCHARGETYPE"].ToString().Trim() == "1")//医保病人
                    {
                        //首先判断费用比例是不是小于1，如果等于1，则不需要计算
                        decimal bl = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select b.yjj_bl from zy_inpatient a left join jc_yblx b on a.yblx=b.id where a.dischargetype=1 and a.inpatient_id='" + ClassStatic.Current_BinID + "'"), "1"));
                        //Modify By Tany 2010-08-07 比例=0的时候相当于不控制欠费
                        if (bl>= 0 && bl < 1)
                        {
                            _wjszfy = _wjszfy * bl;
                        }
                    }
                    _fye = _yjk - _wjszfy;
                    //判断病人的余额
                    if (_fye > myFunc.GetPatMinExecYE(new Guid(sBinID)))
                    {
                        //正常范围
                    }
                    else
                    {
                        if ( tbKz.Rows[0]["qf_bit"].ToString().Trim() == "0")
                        {
                            MessageBox.Show(this, "对不起，该病人欠费不能跨院转科！ \n需要进行审核！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                #endregion
                 
                #region  医保控制
                if (new SystemCfg(19002).Config == "1" && myTb.Rows[nrow]["DISCHARGETYPE"].ToString().Trim() == "1")
                {
                    if (tbKz.Rows[0]["yb_bit"].ToString().Trim() == "0")
                    {
                        MessageBox.Show(this, "对不起，该病人医保科还未审核！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                #endregion
                #region--查看病人是否还有未到账的预交款
                string ssl = "select * from zy_deposits where arrive_bit=0 and inpatient_id='" + sBinID + "' and CANCEL_BIT=0";
                DataTable tb22 = FrmMdiMain.Database.GetDataTable(ssl);
                if (tb22.Rows.Count > 0)
                {
                    MessageBox.Show(this, "对不起，该病人存在未到账的预交款", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                #endregion
                 
                //转科
                if (MessageBox.Show(this, "确认“" + myTb.Rows[nrow]["姓名"].ToString().Trim() + "”转到“" + "【" + myTb.Rows[nrow]["目标院区"].ToString().Trim() + "】" + myTb.Rows[nrow]["目标科室"].ToString().Trim() + "”吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return false;

                string _outmsg = "";
                if (myFunc.isMYTSBaby(isMYTS, Convert.ToInt32(sBabyID)))
                {
                    //减少母亲的母婴同室数量
                    _outmsg = myFunc.TransfeDept("", 2, new Guid(sBinID), Convert.ToInt64(sBabyID), nSDeptID, nDDeptID, InstanceForm.BCurrentUser.EmployeeId, Convert.ToDateTime(myTb.Rows[nrow]["登记日期"]), new Guid(myTb.Rows[nrow]["id"].ToString()));
                }
                else
                {
                    _outmsg = myFunc.TransfeDept("", 1, new Guid(sBinID), Convert.ToInt64(sBabyID), nSDeptID, nDDeptID, InstanceForm.BCurrentUser.EmployeeId, Convert.ToDateTime(myTb.Rows[nrow]["登记日期"]), new Guid(myTb.Rows[nrow]["id"].ToString()));
                }

                if (_outmsg.Trim() != "")
                {
                    MessageBox.Show(_outmsg);
                }
                //如果非正常转科删除转科医嘱
                string ssss = "select order_id from  ZY_TRANSFER_DEPT where id='" + myTb.Rows[nrow]["id"].ToString() + "' and Trans_type=1";
                DataTable dtb = FrmMdiMain.Database.GetDataTable(ssss);
                if (dtb != null & dtb.Rows.Count > 0)
                {
                    FrmMdiMain.Database.DoCommand("update ZY_ORDERRECORD set DELETE_BIT=1 where ORDER_ID='" + dtb .Rows[0]["order_id"]+ "'");
                }
                Department msgDept = new Department(nDDeptID, FrmMdiMain.Database);
                string msg_wardid = msgDept.WardId;
                long msg_deptid = 0;
                long msg_empid = 0;
                string msg_sender = FrmMdiMain.CurrentDept.WardName + "：" + FrmMdiMain.CurrentUser.Name;
                string msg_msg = "有转科病人！\r\n住院号：" + myTb.Rows[nrow]["住院号"].ToString().Trim() + "\r\n姓名：" + myTb.Rows[nrow]["姓名"].ToString().Trim();
                TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.住院护士站, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);

                //写日志
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "转科", _outmsg + "将“" + myTb.Rows[nrow]["姓名"].ToString().Trim() + " " + sBinID + " " + sBabyID + "”转到“" + myTb.Rows[nrow]["目标科室"].ToString().Trim() + "”", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;
                return true;
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
                return false;
            }
        }
        /// <summary>
        /// 未执行查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWzx_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.DgvZkqr.DataSource;
            if (myTb == null || myTb.Rows.Count == 0) return;
            int nrow = this.DgvZkqr.CurrentCell.RowIndex;
            string sBinID = myTb.Rows[nrow]["inpatient_id"].ToString().Trim();
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();

            object[] _communicates = new object[2];
            _communicates[0] = sBinID;
            _communicates[1] = sBabyID;
            WorkStaticFun.InstanceFormEx("ts_zyhs_wclxmcx", "Fun_ts_zyhs_wclxmcx", "未处理项目查询", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase, ref _communicates);
        }
        //申请确认
        private void button1_Click(object sender, EventArgs e)
        {
            //
            if (this.tabControl1.SelectedTab == this.tabPage1)//特殊治疗
            {
               
                
                DataTable tb = (DataTable)this.DgvTszlqr.DataSource;
                if (tb.Rows.Count < 1)
                    return;
                int curindex = 0;
                if (this.DgvTszlqr.CurrentCell != null)
                    curindex = this.DgvTszlqr.CurrentCell.RowIndex;
                else
                    return;
                Guid guid = Guid.Empty;
                string sBinID = tb.Rows[curindex]["inpatient_id"].ToString().Trim();
                string sBabyID = tb.Rows[curindex]["baby_id"].ToString().Trim();
                #region//判断是否有未停止的医嘱、判断是否有未记帐的费用
               //string  sSql = " select sum(id1) as id1,sum(id2) as id2 from ( " +
               //         " select count(a.order_id) id1,0 id2 " +
               //         "  from zy_orderrecord a " +
               //         "  where a.status_flag<5 and a.delete_bit=0 " +
               //         "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID +
               //                             " union all" +
               //                             " select 0 id1,count(b.id) id2 " +
               //                             "  from zy_fee_speci b " +
               //                             "  where b.charge_bit=0 and b.delete_bit=0 " +
               //                             "  and b.inpatient_id='" + sBinID + "' and b.baby_id=" + sBabyID + //Modify By Tany 2004-12-22 转科可以不判断费用
               //         " ) tmp";
               //DataTable   tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
               //string sMsg = "";
               // if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
               // {
               //     sMsg = "有未停止的医嘱";
               // }
               // if (Convert.ToInt32(tempTb.Rows[0]["id2"]) > 0)
               // {
               //     sMsg += sMsg == "" ? "有" : "和";
               //     sMsg = "未记帐的费用";
               // }
                //Modify by zouchihua 2013-1-9 不需要控制
                //if (sMsg != "")
                //{
                //    MessageBox.Show(this, "对不起，该病人" + sMsg + "，不允许特殊治疗完成！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    btnWzx_Click(null, null);
                //    return ;
                //}
                #endregion
                #region//Modify By zouchihua 2011-10-12 如果有转科申请没有完成，提示
                string sSql1 = "Select *,dbo.fun_getdeptname(d_dept_id)  dept_name from ZY_TRANSFER_DEPT where inpatient_id='" + sBinID + "' and FINISH_BIT=0 and CANCEL_BIT=0";
                DataTable  tempTb1 = InstanceForm.BDatabase.GetDataTable(sSql1);
                if (tempTb1.Rows.Count > 0)
                {
                    string ss = "";
                    for (int i = 0; i < tempTb1.Rows.Count; i++)
                    {
                        ss += "申请时间：" + tempTb1.Rows[i]["TRANSFER_DATE"].ToString() + "   转到科室：" + tempTb1.Rows[i]["dept_name"].ToString() + "\r\n";
                    }
                    MessageBox.Show(this, "对不起，该病人存在有转科未完成" + "\n 【" + ss + "】", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ;
                }
                #endregion
                #region //Modify By zouchihua 2014-5-12  判断状态，如果是2,4,5,6那么就不能删除
                sSql1 = "select * from ZY_INPATIENT where FLAG in(2,4,5,6) and inpatient_id='" + sBinID + "'  ";
                tempTb1 = InstanceForm.BDatabase.GetDataTable(sSql1);
                if (tempTb1.Rows.Count > 0)
                {
                    MessageBox.Show(this, "对不起，该病人已经出区或者出院", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion
                //#region//Modify By zouchihua 2011-10-12 如果有其它特殊治疗申请没有完成，提示
                //sSql = "Select *,dbo.fun_getdeptname(ts_dept) tsdept_name from ZY_TS_APPLY where inpatient_id='" + sBinID + "' and status_flag=1 and delete_bit=0  and id!='" + tb.Rows[curindex]["id"].ToString() + "'";
                //tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                //if (tempTb.Rows.Count > 0)
                //{
                //    string ss = "";
                //    for (int i = 0; i < tempTb.Rows.Count; i++)
                //    {
                //        ss += "申请时间：" + tempTb.Rows[i]["apply_date"].ToString() + "   科室：" + tempTb.Rows[i]["tsdept_name"].ToString() + "   内容：" + tempTb.Rows[i]["content"].ToString() + "\r\n";
                //    }
                //    MessageBox.Show(this, "对不起，该病人存在有特殊治疗未完成" + "\n 【" + ss + "】", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return ;
                //}
                //#endregion
                FrmMdiMain.Database.BeginTransaction();
                try
                {
                    //生成操作日志
                    ts_HospData_Share.ts_update_log ts_share = new ts_HospData_Share.ts_update_log();
                    ts_share.Save_log(ts_HospData_Share.czlx.zy_特殊治疗申请, "特殊治疗申请【复制病人相关数据】", "ZY_TS_APPLY", "id", tb.Rows[curindex]["id"].ToString(), FrmMdiMain.Jgbm, int.Parse(tb.Rows[curindex]["TS_DEPT"].ToString()), "", out guid, FrmMdiMain.Database);
                    //冻结人员信息  FREEZE_FLAG 0=正常 1=临时 2=永久
                    //string FREEZE_FLAG = "update zy_inpatient set FREEZE_FLAG=1 where inpatient_id='" + tb.Rows[curindex]["inpatient_id"].ToString() + "'";
                   
                    //FrmMdiMain.Database.DoCommand(FREEZE_FLAG);
                    SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "特殊治疗", "将“" + tb.Rows[curindex]["姓名"].ToString().Trim() + " " + sBinID + " " + sBabyID + "”转到“" + tb.Rows[curindex]["目标科室"].ToString().Trim() + "”", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                     _systemLog.Save();
                     _systemLog = null;
                     //删除内存表数据
                     this.DgvTszlqr.Rows.RemoveAt(curindex);
                     FrmMdiMain.Database.CommitTransaction();
                }
                catch (Exception ex)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);     
                }
            }
            else//跨院专科
                if (this.tabControl1.SelectedTab == this.tabPage2)
            {
                DataTable tb = (DataTable)this.DgvZkqr.DataSource;
                if (tb.Rows.Count < 1)
                    return;
                int curindex = 0;
                if (this.DgvZkqr.CurrentCell != null)
                    curindex = this.DgvZkqr.CurrentCell.RowIndex;
                else
                    return;
                Guid guid = Guid.Empty;
                    if(this._sign==0)
                    {
                        #region 护士站审核
                        if (Transdeptcheck() == true)
                        {
                            FrmMdiMain.Database.BeginTransaction();
                            try
                            {
                                //生成操作日志
                                ts_HospData_Share.ts_update_log ts_share = new ts_HospData_Share.ts_update_log();
                                ts_share.Save_log(ts_HospData_Share.czlx.zk_转科申请, "转科申请【复制病人相关数据】", "ZY_TRANSFER_DEPT", "id", tb.Rows[curindex]["id"].ToString(), FrmMdiMain.Jgbm, int.Parse(tb.Rows[curindex]["D_DEPT_id"].ToString()), "", out guid, FrmMdiMain.Database);
                                //临时冻结人员信息 
                                string FREEZE_FLAG1 = "update zy_inpatient set FREEZE_FLAG=1 where inpatient_id='" + tb.Rows[curindex]["inpatient_id"].ToString() + "'";
                                //删除内存表数据
                                this.DgvZkqr.Rows.RemoveAt(curindex);
                                FrmMdiMain.Database.DoCommand(FREEZE_FLAG1);
                                FrmMdiMain.Database.CommitTransaction();
                            }
                            catch (Exception ex)
                            {
                                FrmMdiMain.Database.RollbackTransaction();
                                MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                        #endregion
                    }
                    else
                    if (this._sign == 1)
                    {
                        #region//医保科审核
                        //改变标记
                        string ssql = "update ZY_TRANSFER_DEPT set Yb_bit=1 where ID= '" + tb.Rows[curindex]["id"].ToString() + "'";
                        FrmMdiMain.Database.DoCommand(ssql);
                        //改变内存表数据
                        this.DgvZkqr.Rows[curindex].Cells["确认标记"].Value = "允许";
                        MessageBox.Show(this, "确认成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #endregion
                    }
                    else
                        if (this._sign == 2)
                        {
                            #region//欠费审核
                            //改变标记
                            string ssql = "update ZY_TRANSFER_DEPT set Qf_bit=1 where ID= '" + tb.Rows[curindex]["id"].ToString() + "'";
                            FrmMdiMain.Database.DoCommand(ssql);
                            //改变内存表数据
                            this.DgvZkqr.Rows[curindex].Cells["确认标记"].Value = "允许";
                            MessageBox.Show(this, "确认成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            #endregion
                        }
            }
          //this.Frmkyqqr_Load(null, null);
       
        }
        /// <summary>
        /// 取消转科
        /// </summary>
        /// <returns></returns>
        private bool CancelZk()
        {
            DataTable myTb = (DataTable)this.DgvZkqr.DataSource;

            if (myTb == null || myTb.Rows.Count == 0) return false;

            string sSql = "";
            if(this.DgvZkqr.CurrentCell==null)
                MessageBox.Show("请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            int nrow = this.DgvZkqr.CurrentCell.RowIndex;
            Guid sBinID = new Guid(myTb.Rows[nrow]["inpatient_id"].ToString().Trim());
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();
            string sBedNo = myTb.Rows[nrow]["床号"].ToString().Trim();
            string sName = myTb.Rows[nrow]["姓名"].ToString().Trim();
            string sSDept = myTb.Rows[nrow]["源科室"].ToString().Trim();
            string sDDept = myTb.Rows[nrow]["目标科室"].ToString().Trim();
            long nSDeptID = Convert.ToInt64(myTb.Rows[nrow]["s_Dept_id"]);
            long nDDeptID = Convert.ToInt64(myTb.Rows[nrow]["d_Dept_id"]);
            Guid sId = new Guid(myTb.Rows[nrow]["id"].ToString().Trim());
            Guid sOrderId = new Guid(myTb.Rows[nrow]["order_id"].ToString().Trim());
            bool IsExistOrder = false;

            if (sOrderId == Guid.Empty)
            {
                if (MessageBox.Show("没有找到该条转科信息的转科医嘱，取消该转科信息将不能同时取消转科医嘱，是否继续？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return false;
            }
            else
            {
                IsExistOrder = true;
            }
            string sMsg = IsExistOrder ? "\n同时将取消转科医嘱！" : "";
            if (MessageBox.Show("是否确定取消 " + sBedNo + " 床病人 " + sName + " 从 " + sSDept + " 到 " +"【"+ myTb.Rows[nrow]["目标院区"].ToString().Trim() +"】"+ sDDept + " 的转科信息？" + sMsg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return false;

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                bool isHSZ = f1.isHSZ;
                if (f1.isLogin == false) return false;
            }

            try
            {
                string[] sqls = new string[2];
                //sqls[0] = "update ZY_TRANSFER_Dept set cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId +
                //    " where id='" + sId + "'";

                //Modify by tany 2011-03-07 取消所有该病人包括婴儿的转科记录
                sqls[0] = "update ZY_TRANSFER_Dept set cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId +
                    " where finish_bit=0 and inpatient_id='" + sBinID + "' and s_dept_id=" + nSDeptID;

                if (IsExistOrder)
                {
                    sqls[1] = "update zy_orderrecord set delete_bit=1 where order_id='" + sOrderId + "'";
                }
                InstanceForm.BDatabase.DoCommand(null, null, null, sqls);
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "取消转科错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source + "\n\n数据已经回滚，请检查后重新执行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MessageBox.Show("取消转科操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //写日志 Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "取消转科", "取消 " + sBedNo + " 床病人 " + sName + " 从 " + sSDept + " 到 " + sDDept + " 的转科信息", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;
            //删除内存表
            this.DgvZkqr.Rows.RemoveAt(this.DgvZkqr.CurrentCell.RowIndex);
            return true;
        }
        private bool CancelTszl()
        {
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                bool isHSZ = f1.isHSZ;
                if (f1.isLogin == false) return false;
            }
            DataTable myTb = (DataTable)this.DgvTszlqr.DataSource;
            if (this.DgvTszlqr.CurrentCell == null)
                throw  new Exception ("请选择一个病人！！");
            int nrow = this.DgvTszlqr.CurrentCell.RowIndex;
            Guid sBinID = new Guid(myTb.Rows[nrow]["inpatient_id"].ToString().Trim());
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();
            string sBedNo = myTb.Rows[nrow]["床号"].ToString().Trim();
            string sName = myTb.Rows[nrow]["姓名"].ToString().Trim();
            string sSDept = myTb.Rows[nrow]["源科室"].ToString().Trim();
            string sDDept = myTb.Rows[nrow]["目标科室"].ToString().Trim();
            long DeptID = Convert.ToInt64(myTb.Rows[nrow]["Dept_id"]);
            long DEPT_BR = Convert.ToInt64(myTb.Rows[nrow]["dept_br"]);
            string str = "";
            ParameterEx[] parameters = new ParameterEx[13];
            parameters[0].Text = "@SIGN";
            parameters[0].Value = 2;
            parameters[1].Text = "@BIN_ID";
            parameters[1].Value = sBinID;
            parameters[2].Text = "@BABY_ID";
            parameters[2].Value = sBabyID;
            parameters[3].Text = "@WARD_ID";
            parameters[3].Value = InstanceForm.BCurrentDept.WardId;
            parameters[4].Text = "@DEPT_BR";
            parameters[4].Value = DEPT_BR;
            parameters[5].Text = "@DEPT_ID";
            parameters[5].Value = DeptID;
            parameters[6].Text = "@APPLY_DOC";
            parameters[6].Value = 1; //int.Parse(myTb.Rows[nrow]["申请医生"].ToString());
            parameters[7].Text = "@APPLY_DATE";
            parameters[7].Value =Convert.ToDateTime( myTb.Rows[nrow]["APPLY_DATE"].ToString());
            parameters[8].Text = "@CONTENT";
            parameters[8].Value = "";//可以为空
            parameters[9].Text = "@TS_DEPT";
            parameters[9].Value =int.Parse( myTb.Rows[nrow]["TS_DEPT"].ToString());
            parameters[10].Text = "@SH_USER";
            parameters[10].Value = int.Parse(myTb.Rows[nrow]["SH_USER"].ToString());
            parameters[11].Text = "@ID";
            parameters[11].Value = myTb.Rows[nrow]["id"].ToString();
            parameters[12].Text = "@JGBM";
            parameters[12].Value =Int64.Parse( myTb.Rows[nrow]["JGBM"].ToString());
            try
            {
                switch (2)
                {
                    case 0://新增
                        str = "申请";
                        break;
                    case 1://修改
                        str = "修改";
                        break;
                    case 2://取消
                        str = "取消";
                        break;
                    case 3://审核
                        str = "审核";
                        break;
                    case 4://取消审核
                        str = "取消审核";
                        break;
                }
                FrmMdiMain.Database.DoCommand("SP_ZYYS_SAVE_TSZL", parameters, 20);
                //删除临时医嘱
                #region//Modiby by zouchihua 2011-10-14  删除相应的医嘱
                string delsql = " update   ZY_ORDERRECORD set  DELETE_BIT=1 where ORDER_ID in (select ORDER_ID from ZY_TS_APPLY where ID ='" + myTb.Rows[nrow]["id"].ToString() + "')";
                FrmMdiMain.Database.DoCommand(delsql);
                #endregion
                //删除内存表
                this.DgvTszlqr.Rows.RemoveAt(this.DgvTszlqr.CurrentCell.RowIndex);
                return true; 
            }
            catch (Exception err)
            {
                MessageBox.Show(str + "错误!\n" + err.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
     
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab == this.tabPage1)//特殊治疗
            {
                try
                {
                    if (CancelTszl() == true)
                        MessageBox.Show("取消操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                if (this.tabControl1.SelectedTab == this.tabPage2)//转科
                {
                    if (this._sign == 0)
                    {
                        CancelZk();
                    }
                    else
                        if(this._sign==1)
                        {
                            DataTable myTb = (DataTable)this.DgvZkqr.DataSource;

                            if (myTb == null || myTb.Rows.Count == 0) return ;

                            string sSql = "";
                            if (this.DgvZkqr.CurrentCell == null)
                                MessageBox.Show("请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            int nrow = this.DgvZkqr.CurrentCell.RowIndex;
                            Guid sBinID = new Guid(myTb.Rows[nrow]["inpatient_id"].ToString().Trim());
                            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();
                            #region 医保科审核
                            //改变标记
                            string ssql = "update ZY_TRANSFER_DEPT set Yb_bit=0 where ID= '" + myTb.Rows[nrow]["id"].ToString() + "'";
                            FrmMdiMain.Database.DoCommand(ssql);
                            //改变内存表数据
                            this.DgvZkqr.Rows[nrow].Cells["确认标记"].Value = "不允许";
                            MessageBox.Show(this, "取消操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            #endregion
                        }
                        else
                            if(this._sign==2)
                            {
                                DataTable myTb = (DataTable)this.DgvZkqr.DataSource;

                                if (myTb == null || myTb.Rows.Count == 0) return;

                                string sSql = "";
                                if (this.DgvZkqr.CurrentCell == null)
                                    MessageBox.Show("请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                int nrow = this.DgvZkqr.CurrentCell.RowIndex;
                                Guid sBinID = new Guid(myTb.Rows[nrow]["inpatient_id"].ToString().Trim());
                                string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();
                                #region 欠费审核
                                //改变标记
                                string ssql = "update ZY_TRANSFER_DEPT set Qf_bit=0 where ID= '" + myTb.Rows[nrow]["id"].ToString() + "'";
                                FrmMdiMain.Database.DoCommand(ssql);
                                //改变内存表数据
                                this.DgvZkqr.Rows[nrow].Cells["确认标记"].Value = "不允许";
                                MessageBox.Show(this, "取消操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                #endregion
                            }
                }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Frmkyqqr_Load(null, null);
            if (tabControl1.SelectedTab == this.tabPage1 || tabControl1.SelectedTab ==this.tabPage2)
            {
                this.groupBox2.Visible = false;
                this.groupBox1.Visible = true;
            }
            if (tabControl1.SelectedTab == this.tpCelTszl || tabControl1.SelectedTab == this.tpCelZk)
            {
                this.groupBox2.Visible = true;
                this.groupBox1.Visible = false;
            }
            if (tabControl1.SelectedTab == this.tpCelKytszl || tabControl1.SelectedTab == this.tpcelkyzk)
            {
                groupBox4.Visible = true;
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = false;
            }
            else
            {
                groupBox4.Visible = false;
                //this.groupBox1.Visible = tr
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.Frmkyqqr_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelQr_Click(object sender, EventArgs e)
        {
            int curindex=0;
            if (this.tabControl1.SelectedTab == this.tpCelZk)//取消转科
            {
                DataTable temp=(DataTable )this.DgvCancelZk.DataSource;
                if(temp.Rows.Count==0)
                    return;
                if(this.DgvCancelZk.CurrentCell!=null)
                  curindex =this.DgvCancelZk.CurrentCell.RowIndex;
              //重新检索数据库增加判断
              DataTable temp_tb = FrmMdiMain.Database.GetDataTable("select * from ts_update_log  where (BSCBZ=0 and BWCBZ=0) and YZJ='"+temp.Rows[curindex]["id"].ToString()+"'");
              if (temp_tb.Rows.Count == 0)
              {
                  MessageBox.Show("对不起，没有找到病人信息或病人已经转科，不能进行操作", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  Frmkyqqr_Load(null,null);
                  return;
              }
                //还原转科科
              string[] sqls = new string[5];
              sqls[0] = "update zy_inpatient set dept_id=" + temp.Rows[curindex]["s_dept_id"].ToString() + " where dept_id=" +temp.Rows[curindex]["d_dept_id"].ToString()  + " and inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "'";
              sqls[1] = "update a set a.dept_id=" +temp.Rows[curindex]["s_dept_id"].ToString() + ",a.flag=b.flag,a.bed_id=b.bed_id from zy_inpatient_baby a inner join zy_inpatient b on a.inpatient_id=b.inpatient_id where a.dept_id=" + temp.Rows[curindex]["d_dept_id"].ToString()  + " and a.inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString()  + "'";
              sqls[2] = "update zy_beddiction set ismyts=isnull((select count(1) from zy_inpatient_baby where inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "'),0) where inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "'";
             //改变完成为0 即未完成
              sqls[3] = "update ZY_TRANSFER_Dept set  cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId + 
                  " where inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "' and s_dept_id=" + temp.Rows[curindex]["s_dept_id"].ToString();
              //删除医嘱
              Guid sOrderId = new Guid(temp.Rows[curindex]["order_id"].ToString().Trim());
              if (sOrderId != Guid.Empty)
              sqls[4] = "update zy_orderrecord set delete_bit=1 where order_id='" + sOrderId + "'";
              InstanceForm.BDatabase.DoCommand(null, null, null, sqls);
               //删除三院操作日志
              string Update_log = "update ts_update_log set  BSCBZ=1 where BWCBZ=0 and BSCBZ=0 and yzj='" + temp.Rows[curindex]["id"].ToString() + "'";
              FrmMdiMain.Database.DoCommand(Update_log);
              //解冻人员信息
              string jdxx = "update zy_inpatient set FREEZE_FLAG=0 where inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "'";
              FrmMdiMain.Database.DoCommand(jdxx);
              MessageBox.Show("取消操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
              SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "取消转科", "将“" + temp.Rows[curindex]["姓名"].ToString().Trim() + " " + temp.Rows[curindex]["inpatient_id"].ToString() + " " + temp.Rows[curindex]["baby_id"].ToString() + "”取消转科", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
              _systemLog.Save();
              _systemLog = null;
              this.Frmkyqqr_Load(null, null);
            }
            else
                if (this.tabControl1.SelectedTab == this.tpCelTszl) //取消特殊治疗
                {
                    DataTable temp = (DataTable)this.DgvCancelTs.DataSource;
                    if (temp.Rows.Count == 0)
                        return;
                    if (this.DgvCancelTs.CurrentCell != null)
                        curindex = this.DgvCancelTs.CurrentCell.RowIndex;
                    //重新检索数据库增加判断
                    DataTable temp1 = FrmMdiMain.Database.GetDataTable("select * from ts_update_log  where (BSCBZ=0 and BWCBZ=0) and YZJ='" + temp.Rows[curindex]["id"].ToString() + "'");
                    if (temp1.Rows.Count== 0)
                    {
                        MessageBox.Show("对不起，没有找到病人信息，不能进行操作", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Frmkyqqr_Load(null, null);
                        return;
                    }
                    //删除日志
                    string Update_log = "update ts_update_log set  BSCBZ=1 where  BSCBZ=0 and yzj='" + temp.Rows[curindex]["id"].ToString() + "' and BWCBZ=0";
                    FrmMdiMain.Database.DoCommand(Update_log);
                    string jdxx = "update zy_inpatient set FREEZE_FLAG=0 where inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "'";
                    FrmMdiMain.Database.DoCommand(jdxx);
                    MessageBox.Show("取消操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Frmkyqqr_Load(null, null);
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int curindex = 0;
            if (this.tabControl1.SelectedTab == this.tpCelKytszl)
            {
                if (this.dataGridView1.CurrentCell == null)
                    return;
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                curindex = this.dataGridView1.CurrentCell.RowIndex;
                //如果是跨院特殊治疗 1.首先判断是否产生了费用
                RelationalDatabase Mb_db = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(tb.Rows[curindex]["MBJGBM"].ToString()));
                string sql = @"   select * from ZY_TS_APPLY a where a.id='" + tb.Rows[curindex]["id"].ToString() + @"'  (STATUS_FLAG=2 
                  or ( select COUNT(*) from ZY_ORDERRECORD where DELETE_BIT=0 and TsApply_id=a.id )>0 )";
                DataTable temp = Mb_db.GetDataTable(sql);
                if (temp.Rows.Count > 0)
                {
                    MessageBox.Show("对不起,该跨院特殊治疗在对方院区已经发生了业务，您不能取消！！");
                    return;
                }
                else
                {
                    //删除日志
                    string Update_log = "update ts_update_log set  BSCBZ=1 where  BSCBZ=0 and yzj='" + tb.Rows[curindex]["id"].ToString() + "' and BWCBZ=1";
                    FrmMdiMain.Database.DoCommand(Update_log);
                    string jdxx = "update zy_inpatient set FREEZE_FLAG=0 where inpatient_id='" + tb.Rows[curindex]["inpatient_id"].ToString() + "'";
                    FrmMdiMain.Database.DoCommand(jdxx);
                    //目标院区要冻结
                    Mb_db.DoCommand("update zy_inpatient set FREEZE_FLAG=1 where inpatient_id='" + tb.Rows[curindex]["inpatient_id"].ToString() + "'");
                    MessageBox.Show("取消操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "特殊治疗", "将“" + temp.Rows[curindex]["姓名"].ToString().Trim() + " " + temp.Rows[curindex]["inpatient_id"].ToString() + " " + temp.Rows[curindex]["baby_id"].ToString() + "”特殊治疗", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemLog.Save();
                    _systemLog = null;
                    this.Frmkyqqr_Load(null, null);
                }
            }
            else
            {
                #region 转科
                if (this.dataGridView2.CurrentCell == null || this.tabControl1.SelectedTab != tpcelkyzk)
                    return;
                DataTable temp = (DataTable)this.dataGridView2.DataSource;
                curindex = this.dataGridView2.CurrentCell.RowIndex;
                //如果是跨院转科 1.首先判断是否分配了床位
                RelationalDatabase Mb_db = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(temp.Rows[curindex]["MBJGBM"].ToString()));
                DataTable fpcw_tb = Mb_db.GetDataTable("select * from zy_inpatient where inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "' and (bed_id is not null and bed_id!=dbo.FUN_GETEMPTYGUID())");
                if (fpcw_tb.Rows.Count > 0)
                {
                    MessageBox.Show("对不起,该跨院转科在对方院区已经发生了业务，您不能取消！！");
                    return;
                }
                //还原转科科
                string[] sqls = new string[5];
                sqls[0] = "update zy_inpatient set dept_id=" + temp.Rows[curindex]["s_dept_id"].ToString() + " where dept_id=" + temp.Rows[curindex]["d_dept_id"].ToString() + " and inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "'";
                sqls[1] = "update a set a.dept_id=" + temp.Rows[curindex]["s_dept_id"].ToString() + ",a.flag=b.flag,a.bed_id=b.bed_id from zy_inpatient_baby a inner join zy_inpatient b on a.inpatient_id=b.inpatient_id where a.dept_id=" + temp.Rows[curindex]["d_dept_id"].ToString() + " and a.inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "'";
                sqls[2] = "update zy_beddiction set ismyts=isnull((select count(1) from zy_inpatient_baby where inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "'),0) where inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "'";
                //改变完成为0 即未完成
                sqls[3] = "update ZY_TRANSFER_Dept set  cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId +
                    " where inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "' and s_dept_id=" + temp.Rows[curindex]["s_dept_id"].ToString();
                //删除医嘱
                Guid sOrderId = new Guid(temp.Rows[curindex]["order_id"].ToString().Trim());
                if (sOrderId != Guid.Empty)
                    sqls[4] = "update zy_orderrecord set delete_bit=1 where order_id='" + sOrderId + "'";
                InstanceForm.BDatabase.DoCommand(null, null, null, sqls);
                //删除三院操作日志
                string Update_log = "update ts_update_log set  BSCBZ=1 where BWCBZ=1 and BSCBZ=0 and yzj='" + temp.Rows[curindex]["id"].ToString() + "'";
                FrmMdiMain.Database.DoCommand(Update_log);
                //解冻人员信息
                string jdxx = "update zy_inpatient set FREEZE_FLAG=0 where inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "'";
                FrmMdiMain.Database.DoCommand(jdxx);
                //更改目标科室状态
                Mb_db.DoCommand("update zy_inpatient set FREEZE_FLAG=1 where inpatient_id='" + temp.Rows[curindex]["inpatient_id"].ToString() + "'");

                MessageBox.Show("取消操作成功,请重新为该病人分配床位！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Frmkyqqr_Load(null, null);
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "取消转科", "将“" + temp.Rows[curindex]["姓名"].ToString().Trim() + " " + temp.Rows[curindex]["inpatient_id"].ToString() + " " + temp.Rows[curindex]["baby_id"].ToString() + "”取消转科", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;
                #endregion
            }
        }
    }
}