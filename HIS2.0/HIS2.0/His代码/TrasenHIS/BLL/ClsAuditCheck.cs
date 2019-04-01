using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.DatabaseAccess;
using System.Windows.Forms;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace TrasenHIS.BLL
{
    public class ClsAuditCheck
    {
        TrasenClasses.DatabaseAccess.RelationalDatabase Database;
        private static TrasenClasses.DatabaseAccess.RelationalDatabase InFomixDb;
        private static object lockob = new object();

        public ClsAuditCheck(TrasenClasses.DatabaseAccess.RelationalDatabase _Database)
        {
            Database = _Database;
        }

        /// <summary>
        /// 实例化老系统连接
        /// </summary>
        private static void InstanceOldHISDb()
        {
            if (InFomixDb == null)
            {
                lock (lockob)
                {
                    if (InFomixDb == null)
                        InFomixDb = TrasenHIS.DAL.BaseDal.GetDb_InFormix();
                }
            }
        }

        /// <summary>
        /// 初始化设置_bAuditCheck是否开启医保医保智审
        /// </summary>
        /// <returns></returns>
        public static bool CheckIsAuditCheck(string inpatient_id, RelationalDatabase db)
        {
            try
            {
                //所在科室是否实行医保智审
                //病人类型是否为医保
                //这个病人是否满足开启智审开关
                //                string strSql = string.Format(@"select count(1) as Num from VI_ZY_VINPATIENT_BED a 
                //                                                where  INPATIENT_ID='{0}' and YBLX=1 and exists(select 1 from V_JC_YBZNSH_USEDEPT b where a.DEPT_ID=b.dept_id) ", inpatient_id);

                SystemCfg cfg_6222 = new SystemCfg(6222);
                if (cfg_6222.Config.ToString().Equals("0"))
                    return false;
                
                string strSql = string.Format(@"select yblx,xzlx,DEPT_ID from VI_ZY_VINPATIENT_BED a  where  INPATIENT_ID='{0}'   ", inpatient_id);

                DataTable dtInp = db.GetDataTable(strSql);

                if (dtInp == null || dtInp.Rows.Count <= 0)
                    return false;

                string yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
                string ybzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
                string dept = dtInp.Rows[0]["DEPT_ID"].ToString().Trim();

                if (yblx.Equals("1"))
                {
                    return true;
                }

                if (yblx.Equals("3") && ybzlx.Equals("55"))
                {
                    //return false;
                    return true;//省直医保病人
                    ////如果该科室已经上线
                    //strSql = string.Format(@"select COUNT(1) as num from V_JC_YBZNSH_USEDEPTSYB where dept_id='{0}' ", dept);

                    //int iNum = int.Parse(db.GetDataResult(strSql).ToString());

                    //if (iNum > 0)
                    //{
                    //}
                }
                if (yblx.Equals("-1"))
                {
                    //return false;
                    return true;//自费病人
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化医保智审接口出错 \r\t " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取主单信息
        /// </summary>
        /// <param name="inpId"></param>
        /// <param name="impNo"></param>
        /// <param name="money"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataTable RetAfSetMainInfo(string inpId, string impNo, decimal money, RelationalDatabase db)
        {
            try
            {
                //获取主单信息
                DataTable dtMainBill = GetMainInfo(inpId, db);
                if (dtMainBill == null || dtMainBill.Rows.Count < 1 || dtMainBill.Rows.Count > 1)
                {
                    MessageBox.Show("医保智审主单信息获取失败,医保控费控制未能开启", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return null;
                }

                string yblx = Convertor.IsNull(dtMainBill.Rows[0]["yblx"], "-1");
                string ybzlx = Convertor.IsNull(dtMainBill.Rows[0]["xzlx"], "-1");


                dtMainBill = DoSetMainInfoByYzlx(inpId, impNo, yblx, ybzlx, dtMainBill, db);

                return dtMainBill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw new Exception(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取主单信息
        /// </summary>
        /// <param name="inpId"></param>
        /// <param name="impNo"></param>
        /// <param name="money"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataTable RetAfSetMainInfo(string inpId, string impNo, decimal money, bool isThrowExc, RelationalDatabase db)
        {
            try
            {
                //获取主单信息
                DataTable dtMainBill = GetMainInfo(inpId, db);
                if (dtMainBill == null || dtMainBill.Rows.Count < 1 || dtMainBill.Rows.Count > 1)
                {
                    MessageBox.Show("医保智审主单信息获取失败,医保控费控制未能开启", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return null;
                }

                string yblx = Convertor.IsNull(dtMainBill.Rows[0]["yblx"], "-1");
                string ybzlx = Convertor.IsNull(dtMainBill.Rows[0]["xzlx"], "-1");

                dtMainBill = DoSetMainInfoByYzlx(inpId, impNo, yblx, ybzlx, dtMainBill, db);

                return dtMainBill;
            }
            catch (Exception ex)
            {
                if (isThrowExc)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            }
        }

        /// <summary>
        /// 根据各 医保类型 设置 主单信息
        /// </summary>
        /// <param name="strYzlx"></param>
        /// <returns></returns>
        private static DataTable DoSetMainInfoByYzlx(string inpId, string impNo, string yblx, string ybzlx, DataTable dtMainBill, RelationalDatabase db)
        {

            string strSql = "";

            strSql = string.Format(@"select isnull(SUM(SDVALUE),1) from ZY_FEE_SPECI where INPATIENT_ID='{0}' and CHARGE_BIT=1 and DELETE_BIT=0 ", inpId);
            decimal money = decimal.Parse(db.GetDataResult(strSql).ToString());

            //武汉市医保
            if (yblx.Equals("1"))
            {
                #region"武汉市医保"

                //处理主单信息
                string strBENEFIT_GROUP_ID = "11";//人员类别 modify by jchl  暂时默认为职工


                string strBENEFIT_TYPE = "";//参保类型
                string strBMI_CONVERED_AMOUNT = money.ToString();//医保内金额
                string strDIAGNOSIS_TOTHER = "";//其他诊断
                string strMEDICAL_TYPE = "";//就医方式
                string strTOTAL_COST = money.ToString();//总金额

                string strDIAGNOSIS_OUT = "";//主要诊断  传医保诊断

                //多诊断处理
                strSql = string.Format(@"select YBJBBM as DISEASE_CODE,DISEASE_MARK from ZY_DISEASE_MANY where INPATIENT_ID='{0}' ", inpId);
                DataTable dtDia = db.GetDataTable(strSql);
                for (int j = 0; j < dtDia.Rows.Count; j++)
                {
                    DataRow drDia = dtDia.Rows[j];
                    if (!string.IsNullOrEmpty(drDia["DISEASE_CODE"].ToString().Trim()))
                    {
                        strDIAGNOSIS_TOTHER += drDia["DISEASE_CODE"].ToString().Trim() + "|";
                    }

                    if (drDia["DISEASE_MARK"].ToString().Trim().Equals("第1诊断"))
                    {
                        string mainDia = Convertor.IsNull(drDia["DISEASE_CODE"], "").Trim();

                        if (!string.IsNullOrEmpty(mainDia))
                        {
                            strDIAGNOSIS_OUT = drDia["DISEASE_CODE"].ToString().Trim();

                            dtMainBill.Rows[0]["DIAGNOSIS_OUT"] = strDIAGNOSIS_OUT;//如果有医保诊断  则主诊断使用医保诊断   
                        }
                    }

                }
                if (dtDia.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(strDIAGNOSIS_TOTHER))
                    {
                        strDIAGNOSIS_TOTHER = strDIAGNOSIS_TOTHER.Substring(0, strDIAGNOSIS_TOTHER.Length - 1);
                    }
                }

                //医保登记信息处理
                DataTable dtYbDjInfo = GetOldYbdjInfo(impNo, db);
                strMEDICAL_TYPE = dtYbDjInfo.Rows[0]["gwbm"] == null ? "" : dtYbDjInfo.Rows[0]["gwbm"].ToString();
                strBENEFIT_TYPE = dtYbDjInfo.Rows[0]["cb_id"] == null ? "" : dtYbDjInfo.Rows[0]["cb_id"].ToString();

                dtMainBill.Rows[0]["BENEFIT_GROUP_ID"] = strBENEFIT_GROUP_ID.Trim();
                dtMainBill.Rows[0]["BENEFIT_TYPE"] = strBENEFIT_TYPE.Trim();
                dtMainBill.Rows[0]["BMI_CONVERED_AMOUNT"] = strBMI_CONVERED_AMOUNT.Trim();
                dtMainBill.Rows[0]["DIAGNOSIS_TOTHER"] = strDIAGNOSIS_TOTHER.Trim();
                dtMainBill.Rows[0]["MEDICAL_TYPE"] = strMEDICAL_TYPE.Trim();
                dtMainBill.Rows[0]["TOTAL_COST"] = strTOTAL_COST.Trim();

                //写死   市医保：‘990002’
                dtMainBill.Rows[0]["HOSPITAL_ID"] = "990002";
                dtMainBill.Rows[0]["inAGENCIES_ID"] = "1";
                

                return dtMainBill;

                #endregion
            }

            //省医保
            if (yblx.Equals("3") && ybzlx.Equals("55"))
            {
                #region"省医保"

                string strID = "";//akc190：医保编号

                string strPatient_IDStr = "";//aac001：就诊记录号


                //处理主单信息
                string  strBENEFIT_GROUP_ID = "-1";//akc300：人群类别 


                string strBENEFIT_TYPE = "";//akc021：参保类型
                string strBMI_CONVERED_AMOUNT = money.ToString();//医保内金额
                string strDIAGNOSIS_TOTHER = "";//其他诊断
                string strMEDICAL_TYPE = "";//aka130：就医方式
                string strTOTAL_COST = money.ToString();//总金额

                string strDIAGNOSIS_OUT = "";//主要诊断  传医保诊断

                //多诊断处理
                strSql = string.Format(@"select DISEASE_CODE as DISEASE_CODE,DISEASE_MARK from ZY_DISEASE_MANY where INPATIENT_ID='{0}' ", inpId);
                DataTable dtDia = db.GetDataTable(strSql);
                for (int j = 0; j < dtDia.Rows.Count; j++)
                {
                    DataRow drDia = dtDia.Rows[j];
                    if (!string.IsNullOrEmpty(drDia["DISEASE_CODE"].ToString().Trim()))
                    {
                        strDIAGNOSIS_TOTHER += drDia["DISEASE_CODE"].ToString().Trim() + "|";
                    }

                    if (drDia["DISEASE_MARK"].ToString().Trim().Equals("第1诊断"))
                    {
                        string mainDia = Convertor.IsNull(drDia["DISEASE_CODE"], "").Trim();

                        if (!string.IsNullOrEmpty(mainDia))
                        {
                            strDIAGNOSIS_OUT = drDia["DISEASE_CODE"].ToString().Trim();

                            dtMainBill.Rows[0]["DIAGNOSIS_OUT"] = strDIAGNOSIS_OUT;//如果有医保诊断  则主诊断使用医保诊断   
                        }
                    }

                }
                if (dtDia.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(strDIAGNOSIS_TOTHER))
                    {
                        strDIAGNOSIS_TOTHER = strDIAGNOSIS_TOTHER.Substring(0, strDIAGNOSIS_TOTHER.Length - 1);
                    }
                }

                //医保登记信息处理
                DataTable dtYbDjInfo = GetOldYbdjInfo(impNo, yblx, ybzlx, db);
                strMEDICAL_TYPE = dtYbDjInfo.Rows[0]["aka130"] == null ? "" : dtYbDjInfo.Rows[0]["aka130"].ToString().Trim();

                strBENEFIT_TYPE = dtYbDjInfo.Rows[0]["akc021"] == null ? "" : dtYbDjInfo.Rows[0]["akc021"].ToString().Trim();

                strBENEFIT_GROUP_ID = dtYbDjInfo.Rows[0]["akc300"] == null ? "" : dtYbDjInfo.Rows[0]["akc300"].ToString().Trim();

                strID = dtYbDjInfo.Rows[0]["akc190"] == null ? "" : dtYbDjInfo.Rows[0]["akc190"].ToString().Trim();

                strPatient_IDStr = dtYbDjInfo.Rows[0]["aac001"] == null ? "" : dtYbDjInfo.Rows[0]["aac001"].ToString().Trim();

                dtMainBill.Rows[0]["ID"] = strID;
                dtMainBill.Rows[0]["BENEFIT_GROUP_ID"] = strBENEFIT_GROUP_ID;
                dtMainBill.Rows[0]["BENEFIT_TYPE"] = strBENEFIT_TYPE;
                dtMainBill.Rows[0]["BMI_CONVERED_AMOUNT"] = strBMI_CONVERED_AMOUNT;
                dtMainBill.Rows[0]["DIAGNOSIS_TOTHER"] = strDIAGNOSIS_TOTHER;
                dtMainBill.Rows[0]["MEDICAL_TYPE"] = strMEDICAL_TYPE;
                dtMainBill.Rows[0]["TOTAL_COST"] = strTOTAL_COST;

                //写死   省医保：‘990002’
                dtMainBill.Rows[0]["HOSPITAL_ID"] = "42010230001";
                dtMainBill.Rows[0]["inAGENCIES_ID"] = "2";

                return dtMainBill;

                #endregion
            }
            ////增加自费审核  add by  chenli  2017-01-26
            if (yblx.Equals("-1"))
            {
                #region"自费"

                string strID = "";//akc190：医保编号

                string strPatient_IDStr = "";//aac001：就诊记录号


                //处理主单信息
                string strBENEFIT_GROUP_ID = "-1";//akc300：人群类别 


                string strBENEFIT_TYPE = "";//akc021：参保类型
                string strBMI_CONVERED_AMOUNT = money.ToString();//医保内金额
                string strDIAGNOSIS_TOTHER = "";//其他诊断
                string strMEDICAL_TYPE = "";//aka130：就医方式
                string strTOTAL_COST = money.ToString();//总金额

                string strDIAGNOSIS_OUT = "";//主要诊断  传医保诊断

                //多诊断处理
                strSql = string.Format(@"select DISEASE_CODE as DISEASE_CODE,DISEASE_MARK from ZY_DISEASE_MANY where INPATIENT_ID='{0}' ", inpId);
                DataTable dtDia = db.GetDataTable(strSql);
                for (int j = 0; j < dtDia.Rows.Count; j++)
                {
                    DataRow drDia = dtDia.Rows[j];
                    if (!string.IsNullOrEmpty(drDia["DISEASE_CODE"].ToString().Trim()))
                    {
                        strDIAGNOSIS_TOTHER += drDia["DISEASE_CODE"].ToString().Trim() + "|";
                    }

                    if (drDia["DISEASE_MARK"].ToString().Trim().Equals("第1诊断"))
                    {
                        string mainDia = Convertor.IsNull(drDia["DISEASE_CODE"], "").Trim();

                        if (!string.IsNullOrEmpty(mainDia))
                        {
                            strDIAGNOSIS_OUT = drDia["DISEASE_CODE"].ToString().Trim();

                            dtMainBill.Rows[0]["DIAGNOSIS_OUT"] = strDIAGNOSIS_OUT;//如果有医保诊断  则主诊断使用医保诊断   
                        }
                    }

                }
                if (dtDia.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(strDIAGNOSIS_TOTHER))
                    {
                        strDIAGNOSIS_TOTHER = strDIAGNOSIS_TOTHER.Substring(0, strDIAGNOSIS_TOTHER.Length - 1);
                    }
                }

                //医保登记信息处理
                //DataTable dtYbDjInfo = GetOldYbdjInfo(impNo, yblx, ybzlx, db);自费病人不取医保数据
                //就医类型 0  门诊  1  住院
                strMEDICAL_TYPE = "1";// dtYbDjInfo.Rows[0]["aka130"] == null ? "" : dtYbDjInfo.Rows[0]["aka130"].ToString().Trim();
                //参保类型  0 自费  100  未知
                strBENEFIT_TYPE = "0";//dtYbDjInfo.Rows[0]["akc021"] == null ? "" : dtYbDjInfo.Rows[0]["akc021"].ToString().Trim();
                //人员类型
                strBENEFIT_GROUP_ID = "-1";//dtYbDjInfo.Rows[0]["akc300"] == null ? "" : dtYbDjInfo.Rows[0]["akc300"].ToString().Trim();

                //strID = dtYbDjInfo.Rows[0]["akc190"] == null ? "" : dtYbDjInfo.Rows[0]["akc190"].ToString().Trim();

                //strPatient_IDStr = dtYbDjInfo.Rows[0]["aac001"] == null ? "" : dtYbDjInfo.Rows[0]["aac001"].ToString().Trim();

                //dtMainBill.Rows[0]["ID"] = strID;
                dtMainBill.Rows[0]["BENEFIT_GROUP_ID"] = strBENEFIT_GROUP_ID;
                dtMainBill.Rows[0]["BENEFIT_TYPE"] = strBENEFIT_TYPE;
                dtMainBill.Rows[0]["BMI_CONVERED_AMOUNT"] = strBMI_CONVERED_AMOUNT;
                dtMainBill.Rows[0]["DIAGNOSIS_TOTHER"] = strDIAGNOSIS_TOTHER;
                dtMainBill.Rows[0]["MEDICAL_TYPE"] = strMEDICAL_TYPE;
                dtMainBill.Rows[0]["TOTAL_COST"] = strTOTAL_COST;

                //写死   自费：‘001’
                dtMainBill.Rows[0]["HOSPITAL_ID"] = "990002";//暂时传990002
                dtMainBill.Rows[0]["inAGENCIES_ID"] = "0";

                return dtMainBill;

                #endregion
            }

            return null;
        }

        public static DataTable GetMainInfo(string inpId, RelationalDatabase db)
        {
            try
            {
                string strSql = string.Format(@"select  
                                            '' as inAGENCIES_ID,
                                            '' as inHasUpdate4Claim,
                                            '0' as BENEFIT_GROUP_ID,--人员类别
                                            '0' as BENEFIT_TYPE,--参保类型
                                            '0' as BMI_CONVERED_AMOUNT,--医保内金额
                                            '' as CKC892,
                                            IN_DIAGNOSIS as DIAGNOSIS_IN,OUT_DIAGNOSIS as DIAGNOSIS_OUT,
                                            ''as DIAGNOSIS_TOTHER,--FOR 循环处理
                                            case SEX_NAME when '男' then '1' when '女' then '0' else '-1' end as GENDER,
                                            '990002' as HOSPITAL_ID,
                                            '3' as HOSPITAL_LEVEL,
                                            WARD_NAME as HS_AREA_CODE,
                                            '' as HS_DIAGNOSIS_IN_NAME,
                                            '' as HS_DIAGNOSIS_OUT_NAME,
                                            INPATIENT_BANO AS HS_IN_NUMBER,
                                            INPATIENT_NO as HS_NUMBER,
                                            NAME as HS_PATIENT_NAME,
                                            case when FLAG IN(2,6,10) then '1' else '0' end as HS_STATUS,
                                            '1' as HospitalType,
                                            cast(INPATIENT_ID as varchar(50)) as ID, 
                                            convert(varchar(10),IN_DATE,120) as IN_DATE,
                                            --convert(varchar(10),'2015-05-25',120) as IN_DATE,
                                            '0' as IsLactation,
                                            '0' as IsPregnant,
                                            '' as MEDICAL_TYPE,--就医方式
                                            case isnull(convert(varchar(10),OUT_DATE,120),'') when  '' then convert(varchar(10),GETDATE(),120) else convert(varchar(10),OUT_DATE,120) end as OUT_DATE,
                                            --convert(varchar(10),'2015-06-05',120) as OUT_DATE,
                                            convert(varchar(10),BIRTHDAY,120) as PATIENT_BIRTH,
                                            '-1' as PatientBenefitGroupCode,
                                            inpatient_bano as Patient_IDStr,
                                            --convert(varchar(10),GETDATE(),120) as SETTLE_DATE,
                                            case isnull(convert(varchar(10),OUT_DATE,120),'') when  '' then convert(varchar(10),GETDATE(),120) else convert(varchar(10),OUT_DATE,120) end as SETTLE_DATE,
                                            '0' as TOTAL_COST,--总金额
                                            '0' as UNUSUAL_FLAG,
                                            '0' as Z_AACT007,
                                            '0' as Z_AACT008,
                                            '0' as Z_BAC021,
                                            YBLX,XZLX
                                            from VI_ZY_VINPATIENT_all where INPATIENT_ID='{0}' and baby_id=0", inpId);

                DataTable dt = db.GetDataTable(strSql);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 依据传入的费用，输出为中公网形式的费用明细单
        /// </summary>
        /// <param name="dtFee"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public DataTable GetDetailFeeInfo(DataTable dtFee, string yblx, string ybzlx, out decimal sum)
        {
            sum = 0M;
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("AKF003", typeof(string));//饮片贴数 his转换为贴 （草药dosage）默认0不能为空
                dt.Columns.Add("AKF005", typeof(string));//出国带药标志
                dt.Columns.Add("ApprovalNumber", typeof(string));//备案审批号
                dt.Columns.Add("BKA609", typeof(string));//因公因战
                dt.Columns.Add("BKC227", typeof(string));//外院费用标志
                dt.Columns.Add("COSTS", typeof(string));//总费用（前台总费用）
                dt.Columns.Add("DEPTNAME", typeof(string));//科室名称（“科室|医生”）
                //dt.Columns.Add("DEPTNAME_SYB", typeof(string));//科室名称（“科室ID|科室名称；医生ID|医生名称”）
                dt.Columns.Add("ELIGIBLE_AMOUNT", typeof(string));//医保内金额  （前台总费用=医保总费用）
                dt.Columns.Add("FREQUENCY_INTERVAL", typeof(string));//使用频次
                dt.Columns.Add("ID", typeof(string));//id
                dt.Columns.Add("ITEM_DATE", typeof(string));//费用日期（处方日期）
                dt.Columns.Add("ITEM_ID", typeof(string));//项目编码
                dt.Columns.Add("ITEM_NAME", typeof(string));//项目名称
                dt.Columns.Add("ITEM_TYPE", typeof(string));//类型 1 药品  0 诊疗、服务设施、耗材
                dt.Columns.Add("NUMBERS", typeof(string));//数量  （his金额/医保单价）
                dt.Columns.Add("PRICE", typeof(string));//单价  （医保单价）
                dt.Columns.Add("PhysicianLevel", typeof(string));//医师级别
                dt.Columns.Add("Specification", typeof(string));//规格
                dt.Columns.Add("USAGE", typeof(string));//每次用量  （his金额/医保单价/频率（注意首末次））
                dt.Columns.Add("USAGE_DAYS", typeof(string));//用药天数   0
                dt.Columns.Add("USAGE_UNIT", typeof(string));//包装单位   医保单位
                dt.Columns.Add("ZZZ_Flag", typeof(string));//计费标记（-1未设置 0未计费 1已计费）：住院默认是已计费的  门诊治疗费默认是已计费   门诊其他费根据结算时标记已计费为准
                dt.Columns.Add("Z_PhysicianAP", typeof(string));//医师行政职务（默认''）

                for (int i = 0; i < dtFee.Rows.Count; i++)
                {
                    DataRow drDet = dtFee.Rows[i];

                    string xmly = drDet["xmly"].ToString().Trim();
                    string xmid = drDet["xmid"].ToString().Trim();
                    string zfbl = Convertor.IsNull(drDet["zfbl"], "-1").Trim();//对应医保自费：带z字的头

                    DataTable dtYbItem = ClsAuditCheck.GetOldYbItemInfo(xmly, xmid, yblx, ybzlx, "1", zfbl, FrmMdiMain.Database);// 医嘱：0   费用：1  
                    for (int j = 0; j < dtYbItem.Rows.Count; j++)
                    {
                        DataRow row = dtYbItem.Rows[j];

                        //审核上传明细
                        DataRow drMx = dt.NewRow();

                        drMx["AKF003"] = "0";//饮片贴数 
                        if (drDet["NTYPE"].ToString().Trim().Equals("3"))
                        {
                            //中草药处理
                            drMx["AKF003"] = drDet["剂数"].ToString(); ;//饮片贴数  wait to jchl
                        }

                        drMx["AKF005"] = "0";//出国带药标志 
                        drMx["ApprovalNumber"] = "";//备案审批号 
                        drMx["BKA609"] = "0";//因公因战 
                        drMx["BKC227"] = "0";//外院费用标志 

                        Department dept = new Department(long.Parse(drDet["DEPT_BR"].ToString().Trim()), FrmMdiMain.Database);

                        try
                        {
                            Doctor doctor = new Doctor(long.Parse(drDet["ORDER_DOC"].ToString().Trim()), FrmMdiMain.Database);
                            drMx["PhysicianLevel"] = ClsAuditCheck.GetDocType(doctor.TypeID.ToString());//医师级别
                        }
                        catch
                        {
                            drMx["PhysicianLevel"] = "255";//护士   暂时写死
                        }

                        drMx["FREQUENCY_INTERVAL"] = ClsAuditCheck.GetAuditFrq(drDet["频率"].ToString());//使用频次 wait to jchl

                        drMx["ID"] = drDet["ID"].ToString();//id
                        drMx["ITEM_DATE"] = drDet["PRESC_DATE"].ToString();//费用日期

                        drMx["ITEM_TYPE"] = row["XMLY"].ToString().Trim().Equals("1") ? "1" : "0";//类型 1 药品  0 诊疗、服务设施、耗材

                        //数量   临嘱：(his金额/医保单价)     长嘱：((his金额/医保单价)*频率)   频率：医嘱传首次,费用传频次
                        int iFir = int.Parse(drDet["ISANALYZED"].ToString().Trim());

                        drMx["Specification"] = drDet["规格"].ToString();//规格

                        drMx["USAGE_DAYS"] = "0";//规格
                        drMx["ZZZ_Flag"] = "1";//医嘱明细 0：未计费      费用明细 1：已计费
                        drMx["Z_PhysicianAP"] = "";//医师行政职务（默认''）

                        #region"武汉市医保"

                        if (yblx.Equals("1"))
                        {
                            //计算明细金额
                            decimal sdVal = 0M;
                            sdVal = decimal.Parse(drDet["SDVALUE"].ToString().Trim());//明细总费用
                            sum += sdVal;

                            drMx["DEPTNAME"] = dept.DeptName + "|" + drDet["下嘱医生"].ToString().Trim();//科室名称（“科室|医生”）

                            drMx["USAGE_UNIT"] = row["dw"].ToString();//医保单位

                            drMx["ITEM_ID"] = row["xmid"].ToString();//上传xmid
                            drMx["ITEM_NAME"] = row["xmmc"].ToString();//上传xmmc

                            decimal dj = decimal.Parse(row["dj"].ToString());
                            drMx["PRICE"] = dj;//单价

                            decimal num = sdVal / dj;
                            drMx["NUMBERS"] = num.ToString("0.0000");         //金额/单价

                            decimal usage = sdVal / (dj * iFir);//每次用量=金额/(单价*频次) 
                            if (drDet["NTYPE"].ToString().Trim().Equals("3"))
                            {
                                //中草药处理
                                usage = 0;//草药默认为0
                            }
                            drMx["USAGE"] = usage.ToString("0.0000");//每次用量  （his金额/医保单价/频率（注意首末次））  （总数量/总次数=单次用量）

                            drMx["COSTS"] = sdVal.ToString();           //医保费用
                            drMx["ELIGIBLE_AMOUNT"] = sdVal.ToString();//总费用
                        }

                        #endregion

                        #region"省医保"

                        if (yblx.Equals("3") && ybzlx.Equals("55"))
                        {

                            if (row["XMLY"].ToString().Trim().Equals("1"))
                            {
                                string sql = string.Format(@"select * from VI_YP_YPCD where cjid='{0}' ", row["ITEM_ID"].ToString());
                                DataTable dtYp = FrmMdiMain.Database.GetDataTable(sql);

                                drMx["PRICE"] = dtYp.Rows[0]["lsj"].ToString();//单价
                                drMx["USAGE_UNIT"] = dtYp.Rows[0]["s_ypdw"].ToString();//医保单位
                                drMx["ITEM_NAME"] = dtYp.Rows[0]["s_yppm"].ToString();//上传xmmc
                            }
                            else
                            {
                                //项目金额
                                string sql = string.Format(@"select * from JC_HSITEM where ITEM_ID='{0}' ", row["ITEM_ID"].ToString());
                                DataTable dtPrc = FrmMdiMain.Database.GetDataTable(sql);

                                drMx["PRICE"] = dtPrc.Rows[0]["RETAIL_PRICE"].ToString();//单价
                                drMx["USAGE_UNIT"] = dtPrc.Rows[0]["ITEM_UNIT"].ToString();//医保单位
                                drMx["ITEM_NAME"] = dtPrc.Rows[0]["ITEM_NAME"].ToString();//上传xmmc
                            }

                            //计算明细金额
                            decimal sdVal = 0M;
                            sdVal = decimal.Parse(drDet["SDVALUE"].ToString().Trim());//明细总费用
                            sum += sdVal;

                            drMx["DEPTNAME"] = dept.DeptId + "|" + dept.DeptName + ";" + Convertor.IsNull(drDet["ORDER_DOC"], "").Trim() + "|" + drDet["下嘱医生"].ToString().Trim();//“科室ID|科室名称；医生ID|医生名称“

                            drMx["ITEM_ID"] = row["xmid"].ToString();//上传xmid

                            //decimal dj = decimal.Parse(row["dj"].ToString());
                            //drMx["PRICE"] = dj;//单价
                            decimal feeNum = Convert.ToDecimal(drDet["NUM"].ToString().Trim());
                            decimal unitRate = Convert.ToDecimal(drDet["UNITRATE"].ToString().Trim());
                            decimal dosage = Convert.ToDecimal(drDet["DOSAGE"].ToString().Trim());

                            decimal dNum = feeNum / unitRate * dosage;

                            //decimal num = sdVal / dj;
                            drMx["NUMBERS"] = dNum.ToString("0.00").Trim(); //金额/单价

                            decimal usage = dNum / iFir;//每次用量=金额/(单价*频次) 
                            if (drDet["NTYPE"].ToString().Trim().Equals("3"))
                            {
                                //中草药处理
                                usage = 0;//草药默认为0
                            }
                            drMx["USAGE"] = usage.ToString("0.0000");//每次用量  （his金额/医保单价/频率（注意首末次））  （总数量/总次数=单次用量）

                            drMx["COSTS"] = sdVal.ToString();           //医保费用
                            drMx["ELIGIBLE_AMOUNT"] = sdVal.ToString();//总费用
                        }

                         #endregion

                        //add by  chenli
                        #region"自费"

                        if (yblx.Equals("-1"))
                        {

                            if (row["XMLY"].ToString().Trim().Equals("1"))
                            {
                                string sql = string.Format(@"select * from VI_YP_YPCD where cjid='{0}' ", row["ITEM_ID"].ToString());
                                DataTable dtYp = FrmMdiMain.Database.GetDataTable(sql);

                                drMx["PRICE"] = dtYp.Rows[0]["lsj"].ToString();//单价
                                drMx["USAGE_UNIT"] = dtYp.Rows[0]["s_ypdw"].ToString();//医保单位
                                drMx["ITEM_NAME"] = dtYp.Rows[0]["s_yppm"].ToString();//上传xmmc
                            }
                            else
                            {
                                //项目金额
                                string sql = string.Format(@"select * from JC_HSITEM where ITEM_ID='{0}' ", row["ITEM_ID"].ToString());
                                DataTable dtPrc = FrmMdiMain.Database.GetDataTable(sql);

                                drMx["PRICE"] = dtPrc.Rows[0]["RETAIL_PRICE"].ToString();//单价
                                drMx["USAGE_UNIT"] = dtPrc.Rows[0]["ITEM_UNIT"].ToString();//医保单位
                                drMx["ITEM_NAME"] = dtPrc.Rows[0]["ITEM_NAME"].ToString();//上传xmmc
                            }

                            //计算明细金额
                            decimal sdVal = 0M;
                            sdVal = decimal.Parse(drDet["SDVALUE"].ToString().Trim());//明细总费用
                            sum += sdVal;

                            drMx["DEPTNAME"] = dept.DeptId + "|" + dept.DeptName + ";" + Convertor.IsNull(drDet["ORDER_DOC"], "").Trim() + "|" + drDet["下嘱医生"].ToString().Trim();//“科室ID|科室名称；医生ID|医生名称“

                            drMx["ITEM_ID"] = row["xmid"].ToString();//上传xmid

                            //decimal dj = decimal.Parse(row["dj"].ToString());
                            //drMx["PRICE"] = dj;//单价
                            decimal feeNum = Convert.ToDecimal(drDet["NUM"].ToString().Trim());
                            decimal unitRate = Convert.ToDecimal(drDet["UNITRATE"].ToString().Trim());
                            decimal dosage = Convert.ToDecimal(drDet["DOSAGE"].ToString().Trim());

                            decimal dNum = feeNum / unitRate * dosage;

                            //decimal num = sdVal / dj;
                            drMx["NUMBERS"] = dNum.ToString("0.00").Trim(); //金额/单价

                            decimal usage = dNum / iFir;//每次用量=金额/(单价*频次) 
                            if (drDet["NTYPE"].ToString().Trim().Equals("3"))
                            {
                                //中草药处理
                                usage = 0;//草药默认为0
                            }
                            drMx["USAGE"] = usage.ToString("0.0000");//每次用量  （his金额/医保单价/频率（注意首末次））  （总数量/总次数=单次用量）

                            drMx["COSTS"] = sdVal.ToString();           //医保费用
                            drMx["ELIGIBLE_AMOUNT"] = sdVal.ToString();//总费用
                        }

                        #endregion  

                        dt.Rows.Add(drMx);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("智审出错：医嘱明细【GetDetailFeeInfo】 \r\t " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 依据传入的费用，输出为中公网形式的费用明细单
        /// </summary>
        /// <param name="dtFee"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public DataTable GetDetailFeeInfo(DataTable dtFee, string yblx, string ybzlx, bool isThrowExc, out decimal sum)
        {
            sum = 0M;
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("AKF003", typeof(string));//饮片贴数 his转换为贴 （草药dosage）默认0不能为空
                dt.Columns.Add("AKF005", typeof(string));//出国带药标志
                dt.Columns.Add("ApprovalNumber", typeof(string));//备案审批号
                dt.Columns.Add("BKA609", typeof(string));//因公因战
                dt.Columns.Add("BKC227", typeof(string));//外院费用标志
                dt.Columns.Add("COSTS", typeof(string));//总费用（前台总费用）
                dt.Columns.Add("DEPTNAME", typeof(string));//科室名称（“科室|医生”）
                //dt.Columns.Add("DEPTNAME_SYB", typeof(string));//科室名称（“科室ID|科室名称；医生ID|医生名称”）
                dt.Columns.Add("ELIGIBLE_AMOUNT", typeof(string));//医保内金额  （前台总费用=医保总费用）
                dt.Columns.Add("FREQUENCY_INTERVAL", typeof(string));//使用频次
                dt.Columns.Add("ID", typeof(string));//id
                dt.Columns.Add("ITEM_DATE", typeof(string));//费用日期（处方日期）
                dt.Columns.Add("ITEM_ID", typeof(string));//项目编码
                dt.Columns.Add("ITEM_NAME", typeof(string));//项目名称
                dt.Columns.Add("ITEM_TYPE", typeof(string));//类型 1 药品  0 诊疗、服务设施、耗材
                dt.Columns.Add("NUMBERS", typeof(string));//数量  （his金额/医保单价）
                dt.Columns.Add("PRICE", typeof(string));//单价  （医保单价）
                dt.Columns.Add("PhysicianLevel", typeof(string));//医师级别
                dt.Columns.Add("Specification", typeof(string));//规格
                dt.Columns.Add("USAGE", typeof(string));//每次用量  （his金额/医保单价/频率（注意首末次））
                dt.Columns.Add("USAGE_DAYS", typeof(string));//用药天数   0
                dt.Columns.Add("USAGE_UNIT", typeof(string));//包装单位   医保单位
                dt.Columns.Add("ZZZ_Flag", typeof(string));//计费标记（-1未设置 0未计费 1已计费）：住院默认是已计费的  门诊治疗费默认是已计费   门诊其他费根据结算时标记已计费为准
                dt.Columns.Add("Z_PhysicianAP", typeof(string));//医师行政职务（默认''）

                for (int i = 0; i < dtFee.Rows.Count; i++)
                {
                    DataRow drDet = dtFee.Rows[i];

                    string xmly = drDet["xmly"].ToString().Trim();
                    string xmid = drDet["xmid"].ToString().Trim();
                    string zfbl = Convertor.IsNull(drDet["zfbl"], "-1").Trim();//对应医保自费：带z字的头

                    DataTable dtYbItem = ClsAuditCheck.GetOldYbItemInfo(xmly, xmid, yblx, ybzlx, "1", zfbl, FrmMdiMain.Database);// 医嘱：0   费用：1  
                    for (int j = 0; j < dtYbItem.Rows.Count; j++)
                    {
                        DataRow row = dtYbItem.Rows[j];

                        //审核上传明细
                        DataRow drMx = dt.NewRow();

                        drMx["AKF003"] = "0";//饮片贴数 
                        if (drDet["NTYPE"].ToString().Trim().Equals("3"))
                        {
                            //中草药处理
                            drMx["AKF003"] = drDet["剂数"].ToString(); ;//饮片贴数  wait to jchl
                        }

                        drMx["AKF005"] = "0";//出国带药标志 
                        drMx["ApprovalNumber"] = "";//备案审批号 
                        drMx["BKA609"] = "0";//因公因战 
                        drMx["BKC227"] = "0";//外院费用标志 

                        Department dept = new Department(long.Parse(drDet["DEPT_BR"].ToString().Trim()), FrmMdiMain.Database);

                        try
                        {
                            Doctor doctor = new Doctor(long.Parse(drDet["ORDER_DOC"].ToString().Trim()), FrmMdiMain.Database);
                            drMx["PhysicianLevel"] = ClsAuditCheck.GetDocType(doctor.TypeID.ToString());//医师级别
                        }
                        catch
                        {
                            drMx["PhysicianLevel"] = "255";//护士   暂时写死
                        }

                        drMx["FREQUENCY_INTERVAL"] = ClsAuditCheck.GetAuditFrq(drDet["频率"].ToString());//使用频次 wait to jchl

                        drMx["ID"] = drDet["ID"].ToString();//id
                        drMx["ITEM_DATE"] = drDet["PRESC_DATE"].ToString();//费用日期

                        drMx["ITEM_TYPE"] = row["XMLY"].ToString().Trim().Equals("1") ? "1" : "0";//类型 1 药品  0 诊疗、服务设施、耗材

                        //数量   临嘱：(his金额/医保单价)     长嘱：((his金额/医保单价)*频率)   频率：医嘱传首次,费用传频次
                        int iFir = int.Parse(drDet["ISANALYZED"].ToString().Trim());

                        drMx["Specification"] = drDet["规格"].ToString();//规格

                        drMx["USAGE_DAYS"] = "0";//规格
                        drMx["ZZZ_Flag"] = "1";//医嘱明细 0：未计费      费用明细 1：已计费
                        drMx["Z_PhysicianAP"] = "";//医师行政职务（默认''）

                        #region"武汉市医保"

                        if (yblx.Equals("1"))
                        {
                            //计算明细金额
                            decimal sdVal = 0M;
                            sdVal = decimal.Parse(drDet["SDVALUE"].ToString().Trim());//明细总费用
                            sum += sdVal;

                            drMx["DEPTNAME"] = dept.DeptName + "|" + drDet["下嘱医生"].ToString().Trim();//科室名称（“科室|医生”）

                            drMx["USAGE_UNIT"] = row["dw"].ToString();//医保单位

                            drMx["ITEM_ID"] = row["xmid"].ToString();//上传xmid
                            drMx["ITEM_NAME"] = row["xmmc"].ToString();//上传xmmc

                            decimal dj = decimal.Parse(row["dj"].ToString());
                            drMx["PRICE"] = dj;//单价

                            decimal num = sdVal / dj;
                            drMx["NUMBERS"] = num.ToString("0.0000");         //金额/单价

                            decimal usage = sdVal / (dj * iFir);//每次用量=金额/(单价*频次) 
                            if (drDet["NTYPE"].ToString().Trim().Equals("3"))
                            {
                                //中草药处理
                                usage = 0;//草药默认为0
                            }
                            drMx["USAGE"] = usage.ToString("0.0000");//每次用量  （his金额/医保单价/频率（注意首末次））  （总数量/总次数=单次用量）

                            drMx["COSTS"] = sdVal.ToString();           //医保费用
                            drMx["ELIGIBLE_AMOUNT"] = sdVal.ToString();//总费用
                        }

                        #endregion

                        #region"省医保"

                        if (yblx.Equals("3") && ybzlx.Equals("55"))
                        {

                            if (row["XMLY"].ToString().Trim().Equals("1"))
                            {
                                string sql = string.Format(@"select * from VI_YP_YPCD where cjid='{0}' ", row["ITEM_ID"].ToString());
                                DataTable dtYp = FrmMdiMain.Database.GetDataTable(sql);

                                drMx["PRICE"] = dtYp.Rows[0]["lsj"].ToString();//单价
                                drMx["USAGE_UNIT"] = dtYp.Rows[0]["s_ypdw"].ToString();//医保单位
                                drMx["ITEM_NAME"] = dtYp.Rows[0]["s_yppm"].ToString();//上传xmmc
                            }
                            else
                            {
                                //项目金额
                                string sql = string.Format(@"select * from JC_HSITEM where ITEM_ID='{0}' ", row["ITEM_ID"].ToString());
                                DataTable dtPrc = FrmMdiMain.Database.GetDataTable(sql);

                                drMx["PRICE"] = dtPrc.Rows[0]["RETAIL_PRICE"].ToString();//单价
                                drMx["USAGE_UNIT"] = dtPrc.Rows[0]["ITEM_UNIT"].ToString();//医保单位
                                drMx["ITEM_NAME"] = dtPrc.Rows[0]["ITEM_NAME"].ToString();//上传xmmc
                            }

                            //计算明细金额
                            decimal sdVal = 0M;
                            sdVal = decimal.Parse(drDet["SDVALUE"].ToString().Trim());//明细总费用
                            sum += sdVal;

                            drMx["DEPTNAME"] = dept.DeptId + "|" + dept.DeptName + ";" + Convertor.IsNull(drDet["ORDER_DOC"], "").Trim() + "|" + drDet["下嘱医生"].ToString().Trim();//“科室ID|科室名称；医生ID|医生名称“

                            drMx["ITEM_ID"] = row["xmid"].ToString();//上传xmid

                            //decimal dj = decimal.Parse(row["dj"].ToString());
                            //drMx["PRICE"] = dj;//单价
                            decimal feeNum = Convert.ToDecimal(drDet["NUM"].ToString().Trim());
                            decimal unitRate = Convert.ToDecimal(drDet["UNITRATE"].ToString().Trim());
                            decimal dosage = Convert.ToDecimal(drDet["DOSAGE"].ToString().Trim());

                            decimal dNum = feeNum / unitRate * dosage;

                            //decimal num = sdVal / dj;
                            drMx["NUMBERS"] = dNum.ToString("0.00").Trim(); //金额/单价

                            decimal usage = dNum / iFir;//每次用量=金额/(单价*频次) 
                            if (drDet["NTYPE"].ToString().Trim().Equals("3"))
                            {
                                //中草药处理
                                usage = 0;//草药默认为0
                            }
                            drMx["USAGE"] = usage.ToString("0.0000");//每次用量  （his金额/医保单价/频率（注意首末次））  （总数量/总次数=单次用量）

                            drMx["COSTS"] = sdVal.ToString();           //医保费用
                            drMx["ELIGIBLE_AMOUNT"] = sdVal.ToString();//总费用
                        }

                        #endregion

                        dt.Rows.Add(drMx);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                if (isThrowExc)
                {
                    throw new Exception("【GetDetailFeeInfo】" + ex.Message);
                }
                else
                {
                    MessageBox.Show("智审出错：医嘱明细【GetDetailFeeInfo】 \r\t " + ex.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// 当天首次执行的医嘱   与开单时自动上传的未计费医嘱当天重复   需删除开单上传的费用
        /// </summary>
        /// <param name="myTb">选择的医嘱信息</param>
        /// <param name="MNGType">医嘱类型 0长期医嘱 1临时医嘱 2长期账单 4临时账单 9所有医嘱和账单</param>
        /// <param name="Kind">0所有 1选择 2不发送 3仅药品,(4 全部药品，5 仅口服药，6 非口服药  add by zouchihua 2012-01-13 )</param>
        /// <param name="BinID">病人inpatient_id</param>
        /// <param name="BabyID">baby_id</param>
        /// <returns></returns>
        public DataTable GetNoneFeeOrdInfo(DataTable myTb, int MNGType, int Kind, Guid BinID, long BabyID)
        {
            if (MNGType != 9 && Kind == 2)
                return null;

            DataTable dt = new DataTable();

            if (MNGType == 9 && Kind == 0)
            {
                string sql = string.Format(@"select ORDER_ID from ZY_ORDERRECORD a
                                                where a.INPATIENT_ID='{0}' and a.BABY_ID='{1}' and a.DELETE_BIT=0 and a.STATUS_FLAG>0 and a.STATUS_FLAG<5
                                               -- and not exists(select 1 from ZY_ORDEREXEC b where a.ORDER_ID=b.ORDER_ID) 
                                            ", BinID.ToString(), BabyID.ToString());

                dt = Database.GetDataTable(sql);
            }
            else if (MNGType != 9 && Kind == 1)
            {
                int iSel = 0;
                string strCnd = "(";
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    //if (myTb.Rows[i]["选"].ToString() == "False")
                    //    continue;

                    strCnd += "'" + myTb.Rows[i]["Order_ID"] + "',";
                    iSel++;
                }

                if (iSel > 0)
                {
                    strCnd = strCnd.Substring(0, strCnd.Length - 1);
                    strCnd += ")";
                }

                //Baby 费用不审核
                string sql = string.Format(@"select ORDER_ID from ZY_ORDERRECORD a
                                                where a.ORDER_ID in {0} and a.DELETE_BIT=0 and a.STATUS_FLAG>0 and a.STATUS_FLAG<=5 and a.BABY_ID=0
                                               -- and not exists(select 1 from ZY_ORDEREXEC b where a.ORDER_ID=b.ORDER_ID)
                                                ", strCnd);

                dt = Database.GetDataTable(sql);
            }

            return dt;
        }

        public bool UpdateScbz(DataTable myTb)
        {
            int iSel = 0;
            string strCnd = "(";
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                strCnd += "'" + myTb.Rows[i]["id"] + "',";
                iSel++;
            }

            if (iSel > 0)
            {
                strCnd = strCnd.Substring(0, strCnd.Length - 1);
                strCnd += ")";
            }

            try
            {
                Database.BeginTransaction();

                //for 循环 性能较差,可靠性强（可以记录未更新到的费用id）
                string sql = string.Format(@"update ZY_YBZNSH_Info set scbz=1 where id in {0}", strCnd);
                Database.DoCommand(sql);

                Database.CommitTransaction();
                return true;
            }
            catch
            {
                Database.RollbackTransaction();
                return false;
            }
        }

        /// <summary>
        /// 更新整个病人的费用
        /// </summary>
        /// <param name="inpID"></param>
        /// <param name="oprMan"></param>
        /// <returns></returns>
        public bool UpdateScbz(string inpID, string oprMan)
        {
            try
            {
                string sql = string.Format(@"update ZY_YBZNSH_Info set scbz=1,mod_man='{1}',mod_date=GETDATE() where inpatient_id='{0}' and baby_id=0 and del_bit=0", inpID, oprMan);
                Database.DoCommand(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取待上传的His明细费用（His待上传费用： 病人、医嘱、详细费用，此方法只获得 病人、医嘱 费用明细）
        /// </summary>
        /// <param name="myTb">选择的医嘱信息</param>
        /// <param name="MNGType">医嘱类型 0长期医嘱 1临时医嘱 2长期账单 4临时账单 9所有医嘱和账单</param>
        /// <param name="Kind">0所有 1选择 2不发送 3仅药品,(4 全部药品，5 仅口服药，6 非口服药  add by zouchihua 2012-01-13 )</param>
        /// <param name="BinID">病人inpatient_id</param>
        /// <param name="BabyID">baby_id</param>
        /// <returns></returns>
        public DataTable GetPostFeeInfo(DataTable myTb, int MNGType, int Kind, Guid BinID, long BabyID)
        {
            if (MNGType != 9 && Kind == 2)
                return null;

            DataTable dt = new DataTable();

            if (MNGType == 9 && Kind == 0)
            {
                string sql = string.Format(@"select a.XMLY,a.XMID,o.NTYPE,o.DEPT_BR,a.SDVALUE,o.ORDER_DOC,DBO.FUN_ZY_SEEKEMPLOYEENAME(o.ORDER_DOC) 下嘱医生,a.NUM,a.Unitrate,a.dosage,
                                                o.FREQUENCY 频率,a.ID,a.PRESC_DATE,o.MNGTYPE,o.FIRST_TIMES,o.TERMINAL_TIMES,o.ORDER_SPEC 规格,o.DOSAGE 剂数,e.ISANALYZED,a.zfbl
                                                 from ZY_FEE_SPECI a 
                                                inner join ZY_ORDERRECORD o on a.ORDER_ID=o.ORDER_ID and o.DELETE_BIT=0 
                                                inner join ZY_ORDEREXEC e on a.ORDEREXEC_ID=e.ID 
                                                where 
                                                exists
                                                (
                                                    select 1 from ZY_YBznsh_info b where b.INPATIENT_ID='{0}' and b.baby_id='{1}' and b.del_bit=0 and b.scbz=0 and a.ID=b.id
                                                ) and a.DELETE_BIT=0 ", BinID.ToString(), BabyID.ToString());

                dt = Database.GetDataTable(sql);
            }
            else if (MNGType != 9 && Kind == 1)
            {
                int iSel = 0;
                string strCnd = "(";
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    //if (myTb.Rows[i]["选"].ToString() == "False")
                    //    continue;

                    strCnd += "'" + myTb.Rows[i]["Order_ID"] + "',";
                    iSel++;
                }

                if (iSel > 0)
                {
                    strCnd = strCnd.Substring(0, strCnd.Length - 1);
                    strCnd += ")";
                }
                else
                {
                    return dt;
                }

                string sql = string.Format(@"select a.XMLY,a.XMID,o.NTYPE,o.DEPT_BR,a.SDVALUE,o.ORDER_DOC,DBO.FUN_ZY_SEEKEMPLOYEENAME(o.ORDER_DOC) 下嘱医生,a.NUM,a.Unitrate,a.dosage,
                                                o.FREQUENCY 频率,a.ID,a.PRESC_DATE,o.MNGTYPE,o.FIRST_TIMES,o.TERMINAL_TIMES,o.ORDER_SPEC 规格,o.DOSAGE 剂数,e.ISANALYZED,a.zfbl
                                                 from ZY_FEE_SPECI a 
                                                inner join ZY_ORDERRECORD o on a.ORDER_ID=o.ORDER_ID and o.DELETE_BIT=0 
                                                inner join ZY_ORDEREXEC e on a.ORDEREXEC_ID=e.ID 
                                                where 
                                                exists
                                                (
                                                   select 1 from ZY_YBznsh_info b where b.order_id in {0} and b.del_bit=0 and b.scbz=0 and a.ID=b.id
                                                ) and a.DELETE_BIT=0 and  a.baby_id=0
                                                ", strCnd);

                dt = Database.GetDataTable(sql);
            }

            return dt;
        }

        /// <summary>
        /// 获取待上传的His明细费用（His待上传费用： 病人、医嘱、详细费用，此方法只获得 详细费用 的明细）
        /// </summary>
        /// <param name="myTb">医嘱详细信息界面 的 数据源 </param>
        /// <returns></returns>
        public DataTable GetPostFeeInfo(DataTable myTb)
        {
            DataTable dt = new DataTable();
            int iSel = 0;
            string strCnd = "(";
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                //if (myTb.Rows[i]["ID"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                //{
                //    strCnd += "'" + myTb.Rows[i]["ID"].ToString() + "',";
                //    iSel++;
                //}
                strCnd += "'" + myTb.Rows[i]["ID"].ToString() + "',";
                iSel++;
            }

            if (iSel > 0)
            {
                strCnd = strCnd.Substring(0, strCnd.Length - 1);
                strCnd += ")";
            }
            else
            {
                return dt;
            }

            string sql = string.Format(@"select a.XMLY,a.XMID,o.NTYPE,o.DEPT_BR,a.SDVALUE,o.ORDER_DOC,DBO.FUN_ZY_SEEKEMPLOYEENAME(o.ORDER_DOC) 下嘱医生,a.NUM,a.Unitrate,a.dosage,
                                                o.FREQUENCY 频率,a.ID,a.PRESC_DATE,o.MNGTYPE,o.FIRST_TIMES,o.TERMINAL_TIMES,o.ORDER_SPEC 规格,o.DOSAGE 剂数,e.ISANALYZED,a.zfbl
                                                 from ZY_FEE_SPECI a 
                                                inner join ZY_ORDERRECORD o on a.ORDER_ID=o.ORDER_ID and o.DELETE_BIT=0 
                                                inner join ZY_ORDEREXEC e on a.ORDEREXEC_ID=e.ID 
                                                where a.CZ_ID in {0} and
                                                exists
                                                (
                                                   select 1 from ZY_YBznsh_info b where b.del_bit=0 and b.scbz=0 and a.ID=b.id
                                                ) and a.DELETE_BIT=0
                                                ", strCnd);

            dt = Database.GetDataTable(sql);

            return dt;
        }

        public static DataTable GetOldYbdjInfo(string zyh, RelationalDatabase db)
        {
            //Modify By Tany 2015-01-30 如果连接不是正式库，则不验证
            //string conn = db.ConnectionString;
            //string[] s = conn.Split(';');
            //if (s.Length > 0)
            //{
            //    for (int i = 0; i < s.Length; i++)
            //    {
            //        if (s[i].IndexOf("initial catalog=") >= 0)
            //        {
            //            if (s[i].Replace("initial catalog=", "").ToLower() != "trasen")
            //            {
            //                return null;
            //            }
            //        }
            //    }
            //}

            InstanceOldHISDb();

            string oldzyh = "";
            string sql = "";
            string msg = "";
            string xml = "";

            try
            {
                if (zyh.Trim() == "")
                {
                    throw new Exception("住院号为空，请检查！");
                }
                oldzyh = Convert.ToInt64(zyh).ToString();
                sql = @"select jzlb from yb_brxx where zyh='" + oldzyh + "'";

                DataTable oldPatTb = InFomixDb.GetDataTable(sql);
                if (oldPatTb == null || oldPatTb.Rows.Count == 0)
                {
                    throw new Exception("在老系统未找到住院号为【" + oldzyh + "】的病人信息！");
                }

                string jzlb = oldPatTb.Rows[0]["jzlb"].ToString();
                sql = @"select gwbm,cb_id from jc_jyfs where ybbm='" + jzlb + "'";
                DataTable dtJzlb = db.GetDataTable(sql);
                if (dtJzlb == null || dtJzlb.Rows.Count == 0)
                {
                    throw new Exception("在老系统未找到就诊编码为【" + jzlb + "】的相关信息！");
                }

                return dtJzlb;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetOldYbdjInfo(string zyh, string yblx, string ybzlx, RelationalDatabase db)
        {
            InstanceOldHISDb();

            string oldzyh = "";
            string sql = "";
            string msg = "";
            string xml = "";

            try
            {
                if (zyh.Trim() == "")
                {
                    throw new Exception("住院号为空，请检查！");
                }
                oldzyh = Convert.ToInt64(zyh).ToString();
                sql = @"select aac001,akc190,akc021,aka130,akc300 from sb_djxx where zyh='" + oldzyh + "'";

                DataTable oldPatTb = InFomixDb.GetDataTable(sql);
                if (oldPatTb == null || oldPatTb.Rows.Count == 0)
                {
                    throw new Exception("在老系统未找到住院号为【" + oldzyh + "】的病人省保登记信息信息！");
                }

                return oldPatTb;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable GetOldYbItemInfo(string xmly, string xmid, string yblx, string ybzlx, string itemType, string zfbl, RelationalDatabase db)
        {
            //Modify By Tany 2015-01-30 如果连接不是正式库，则不验证
            //string conn = db.ConnectionString;
            //string[] s = conn.Split(';');
            //if (s.Length > 0)
            //{
            //    for (int i = 0; i < s.Length; i++)
            //    {
            //        if (s[i].IndexOf("initial catalog=") >= 0)
            //        {
            //            if (s[i].Replace("initial catalog=", "").ToLower() != "trasen")
            //            {
            //                return null;
            //            }
            //        }
            //    }
            //}

            InstanceOldHISDb();

            string oldzyh = "";
            string sql = "";
            string msg = "";
            string xml = "";

            try
            {
                if (itemType.Equals("0"))
                {
                    sql = string.Format(@"select dbo.fun_getdatamap_old('JC_HSITEM',xmid) as xmid,xmid as ITEM_ID,'2' as xmly
                                        from
                                        (
                                        select 2 as xmly,SUBITEM_ID as xmid from JC_HOI_HDI t 
                                        inner join JC_TC a on t.TCID=a.ITEM_ID and TC_FLAG=1 and a.DELETE_BIT=0 
                                        inner join JC_TC_MX b on a.ITEM_ID=b.MAINITEM_ID 
                                        where t.HOITEM_ID='{0}' and '{1}'='2'
                                        union all
                                        select 2 as xmly,ITEM_ID as xmid from JC_HOI_HDI t 
                                        inner join JC_HSITEM a on t.HDITEM_ID=a.ITEM_ID and TC_FLAG=0 and a.DELETE_BIT=0
                                        where t.HOITEM_ID='{0}' and '{1}'='2' 
                                        )a
                                        union all
                                        select dbo.fun_getdatamap_old('yp_ypcjd','{0}') as xmid,'{0}' as ITEM_ID,'1' as xmly where '{1}'='1'", xmid, xmly);

                }
                else
                {
                    sql = string.Format(@"select dbo.fun_getdatamap_old('JC_HSITEM','{0}') as xmid,'{0}'  as ITEM_ID,'2' as xmly where '{1}'='2'
                                        union all
                                        select dbo.fun_getdatamap_old('yp_ypcjd','{0}') as xmid,'{0}' as ITEM_ID,'1' as xmly where '{1}'='1'", xmid, xmly);

                }

                DataTable oldSfmx = db.GetDataTable(sql);
                if (oldSfmx == null || oldSfmx.Rows.Count == 0)
                {
                    //没有对应关系   忽略该数据（客户要求不报错  wait  直连3.0医保对照表   modify by jchl 2017-03-01）
                    //throw new Exception(xmly == "1" ? "新his药品" : "新his项目收费编码" + "：" + xmid + ",因为收费项目未同步，datamap表中未找到对应老系统的项目,请检查！");
                    return new DataTable();//wait   待处理
                }

                DataTable dtYbItem = new DataTable();
                dtYbItem.Columns.Add("DJ", typeof(string));//单价
                dtYbItem.Columns.Add("DW", typeof(string));//单位
                dtYbItem.Columns.Add("XMMC", typeof(string));//上传xm名称
                dtYbItem.Columns.Add("XMID", typeof(string));//上传xmid

                dtYbItem.Columns.Add("XMLY", typeof(string));//上传xm名称
                dtYbItem.Columns.Add("ITEM_ID", typeof(string));//上传xmid

                #region

                string ls_bm = "";
                string nHisId = "";
                string nHisLy = "";

                decimal dZfbl = decimal.Parse(zfbl);
                decimal dBjZfbl = 1M;

                //循环取医保对应关系
                for (int i = 0; i < oldSfmx.Rows.Count; i++)
                {
                    nHisId = oldSfmx.Rows[i]["ITEM_ID"].ToString().Trim();
                    nHisLy = oldSfmx.Rows[i]["xmly"].ToString().Trim();
                    ls_bm = oldSfmx.Rows[i]["xmid"].ToString().Trim();


                    if (yblx.Equals("1"))
                    {
                        //if (nHisLy.Equals("1") && dZfbl == dBjZfbl)
                        if (dZfbl == dBjZfbl)
                        {
                            //判断医保对应是否取z字对应项目
                            string dybm = "z" + ls_bm;
                            //string ssql = "select count(*) from yb_bmdzb,yb_ybmlb where yb_bmdzb.xmbm = yb_ybmlb.ybxmbm and yb_bmdzb.yyxmbm = '" + dybm + "'";
                            string ssql = "select count(*)  li_xybcc from yb_bmdzb,yb_ybmlb where yb_bmdzb.xmbm = yb_ybmlb.ybxmbm and yb_bmdzb.yyxmbm = '" + dybm + "'";

                            DataTable ztb = InFomixDb.GetDataTable(ssql);
                            if (ztb.Rows.Count <= 0 || ztb.Rows[0]["li_xybcc"].ToString().Trim() == "0")
                            {
                                //没有找到自费z字对应项目   则默认传对应的统筹的xmid
                                ls_bm = ls_bm;
                            }
                            else
                            {
                                ls_bm = "z" + ls_bm;
                            }
                        }

                        sql = @"SELECT count(*)  li_xybcc FROM yb_bmdzb Where yyxmbm ='" + ls_bm + "'";
                        DataTable tb = InFomixDb.GetDataTable(sql);
                        if (tb.Rows.Count <= 0 || tb.Rows[0]["li_xybcc"].ToString().Trim() == "0")
                        {
                            throw new Exception("医院项目编码：" + ls_bm + ",未对应老系统项目,请检查！");
                        }
                        else
                        {
                            sql = string.Format(@" select jzjg as dj,
                                              dw,
                                              ybxmbm as xmid,
                                             zwmc as xmmc
                                             from v_yb_znsh_bmdzb2
                                             where yyxmbm='{0}' ", ls_bm);

                            DataTable yb_ybmlb = InFomixDb.GetDataTable(sql);
                            if (yb_ybmlb.Rows.Count <= 0)
                            {
                                throw new Exception("医院项目编码：" + ls_bm + ",该药品或项目没有做对应，请联系医保办！");
                            }
                            else
                            {
                                DataRow drOldYb = yb_ybmlb.Rows[0];

                                DataRow drYbItem = dtYbItem.NewRow();
                                drYbItem["dj"] = drOldYb["dj"] == null ? "" : drOldYb["dj"].ToString().Trim();
                                drYbItem["dw"] = drOldYb["dw"] == null ? "" : drOldYb["dw"].ToString().Trim();
                                drYbItem["xmid"] = drOldYb["xmid"] == null ? "" : drOldYb["xmid"].ToString().Trim();
                                drYbItem["xmmc"] = drOldYb["xmmc"] == null ? "" : drOldYb["xmmc"].ToString().Trim();

                                drYbItem["ITEM_ID"] = nHisId;
                                drYbItem["XMLY"] = nHisLy;

                                dtYbItem.Rows.Add(drYbItem);
                            }
                        }
                    }

                    if (yblx.Equals("3") && ybzlx.Equals("55") || yblx.Equals("-1"))//增加自费审核  add by  chenli  2017-01-26
                    {

                        DataRow drYbItem = dtYbItem.NewRow();
                        drYbItem["dj"] = "";
                        drYbItem["dw"] = "";
                        drYbItem["xmid"] = oldSfmx.Rows[i]["xmid"].ToString().Trim();
                        drYbItem["xmmc"] = "";

                        drYbItem["ITEM_ID"] = nHisId;
                        drYbItem["XMLY"] = nHisLy;

                        dtYbItem.Rows.Add(drYbItem);
                    }
                }

                #endregion

                return dtYbItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetAuditFrq(string frqName)
        {
            string ret = "";
            switch (frqName)
            {
                case "12n":
                case "4pm":
                case "qd":
                    ret = "11";
                    break;
                case "bid":
                    ret = "12";
                    break;
                case "tid":
                    ret = "13";
                    break;
                case "qid":
                    ret = "14";
                    break;
                case "Quingid":
                    ret = "15";
                    break;
                case "qw":
                    ret = "21";
                    break;
                case "biw":
                    ret = "22";
                    break;
                case "tiw":
                    ret = "23";
                    break;
                case "q1/2h":
                    ret = "30";
                    break;
                case "qh":
                    ret = "31";
                    break;
                case "q2h":
                    ret = "32";
                    break;
                case "q4h":
                    ret = "33";
                    break;
                case "q5h":
                    ret = "34";
                    break;
                case "q6h":
                    ret = "35";
                    break;
                case "q8h":
                    ret = "36";
                    break;
                case "q12h":
                    ret = "37";
                    break;
                case "q3h":
                    ret = "38";
                    break;

                case "qn":
                    ret = "41";
                    break;
                case "q2d":
                case "qon":
                case "双日":
                case "单日":
                case "qod":
                    ret = "42";
                    break;
                case "q5d":
                    ret = "43";
                    break;
                case "q10d":
                    ret = "44";
                    break;
                case "q3d":
                    ret = "45";
                    break;
                case "2W":
                    ret = "46";
                    break;
                case "12小时维持":
                    ret = "51";
                    break;
                case "24小时维持":
                    ret = "52";
                    break;
                case "st":
                    ret = "61";
                    break;
                case "prn":
                    ret = "62";
                    break;
                default:
                    ret = "-1";
                    break;
            }
            return ret;
        }

        //暂时未用
        public static string GetAuditFrq(string frqName, string ordBegDate, string ordExeDate, DataTable dtFreq, out string times)
        {
            times = "";
            string ret = "";

            FreQInfo freInfo = GetFreQInfo(frqName, dtFreq);
            if (freInfo == null)
            {
                throw new Exception("His不存在该频次：" + frqName + "，请联系管理员维护");
            }

            times = GetExeDateFrqTimes(ordBegDate, ordExeDate, freInfo);//末次待处理

            ret = GetAuditFrq(frqName);

            return ret;
        }

        public static string GetDocType(string typeId)
        {

            string ret = "";
            switch (typeId)
            {
                case "1":
                    ret = "231";
                    break;
                case "2":
                    ret = "232";
                    break;
                case "3":
                    ret = "233";
                    break;
                default:
                    ret = "234";
                    break;
            }
            return ret;
        }

        private static string GetExeDateFrqTimes(string ordBegDate, string ordExeDate, FreQInfo freqInfo)
        {
            try
            {
                TimeSpan tBeg = new TimeSpan(Convert.ToDateTime(ordBegDate).Ticks);
                TimeSpan tExe = new TimeSpan(Convert.ToDateTime(ordExeDate).Ticks);

                int iDays = tExe.Subtract(tBeg).Duration().Days;

                int iCyc = int.Parse(freqInfo.cyclecs);

                //时间差能整除周期数（即今天要执行医嘱）
                if (iDays % iCyc == 0)
                {
                    return freqInfo.exe_num;
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        private static FreQInfo GetFreQInfo(string frqName, DataTable dtFreq)
        {
            try
            {
                DataRow[] drs = dtFreq.Select("name='" + frqName + "'");
                if (drs.Length <= 0)
                {
                    return null;
                }

                FreQInfo freInfo = new FreQInfo();
                freInfo.name = drs[0]["name"].ToString();
                freInfo.exe_num = drs[0]["EXECNUM"].ToString();
                freInfo.cycle_day = drs[0]["CYCLEDAY"].ToString();
                freInfo.cyclecs = drs[0]["CYCLECS"].ToString();
                freInfo.cyc_num = drs[0]["CYCLENUM"].ToString();
                freInfo.zxr = drs[0]["ZXR"].ToString();
                freInfo.lx = drs[0]["LX"].ToString();
                return freInfo;
            }
            catch
            {
                return null;
            }
        }
    }

    class FreQInfo
    {
        public string name = "";
        public string exe_num = "0";
        public string cycle_day = "0";
        public string cyclecs = "0";
        public string cyc_num = "0";
        public string zxr = "";
        public string lx = "";

        public FreQInfo()
        {
        }
    }
}
