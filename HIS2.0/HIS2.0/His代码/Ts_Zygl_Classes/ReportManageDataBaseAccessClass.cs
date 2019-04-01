using System;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;
using System.Collections;

/*
 * 名称：住院管理报告数据库访问类（ts_zygl_report）
 * 描述：适用于住院管理报告中的数据库访问
 * 编写时间：2013-10
 * 作者：Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class ReportManageDataBaseAccessClass
    {
        public static DataTable RmPatientWasDischargedStatisticsDivision(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT 出院科室,住院号,姓名,类型,入院日期,出院日期,发票号,结算日期,SUM(CASE 科目 WHEN '+ITEM_NAME+' THEN 金额 END)['+RTRIM(CAST(ITEM_NAME AS VARCHAR(100)))+'] FROM (SELECT DISTINCT ITEM_NAME FROM JC_STAT_ITEM) AS A, ";
                        sSql = sSql + " 医保支付,总费用,预交,自付,补退,SUM(CASE WHEN CODE IN ('01','02','03') THEN 金额 END) AS 药品合计, ";
                        sSql = sSql + " SUM(CASE WHEN CODE NOT IN ('01','02','03') THEN 金额 END) AS 医疗合计,SUM(金额) AS 合计 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT A.INPATIENT_NO AS 住院号,A.NAME AS 姓名,A.BRLX_NAME AS 类型,A.IN_DATE AS 入院日期,A.OUT_DATE AS 出院日期, ";
                        sSql = sSql + " A.CUR_DEPT_NAME AS 出院科室,A.BILLNO AS 发票号,B.DISCHARGE_DATE AS 结算日期,C.ITEM_NAME AS 科目, ";
                        sSql = sSql + " ACVALUE AS 金额,B.YB_FEE AS 医保支付,B.NFEE AS 总费用,B.DEPTOSITS AS 预交,B.SELF_FEE AS 自付, ";
                        sSql = sSql + " B.PATCH_FEE AS 补退,C.CODE ";
                        sSql = sSql + " FROM VI_ZY_VINPATIENT_ALL A  ";
                        sSql = sSql + " INNER JOIN ZY_DISCHARGE B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                        sSql = sSql + " INNER JOIN ZY_FEE_SPECI E ON A.INPATIENT_ID = E.INPATIENT_ID ";
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM C ON C.CODE = E.STATITEM_CODE ";
                        sSql = sSql + " WHERE E.DELETE_BIT = 0 AND E.CHARGE_BIT = 1 AND B.CANCEL_BIT = 0 ";
                        sSql = String.Format("{0} AND B.DISCHARGE_DATE >= '{1}' AND B.DISCHARGE_DATE < '{2}' ", sSql, arrList[0], arrList[1]);
                        sSql = sSql + " ) AA ";
                        sSql = sSql + " GROUP BY 出院科室,住院号,姓名,类型,入院日期,出院日期,发票号,结算日期,医保支付,总费用,预交,自付,补退 ";
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT '' AS 出院科室,'合计' AS 住院号,'' AS 姓名,'' AS 类型,NULL AS 入院日期,NULL AS 出院日期,NULL AS 发票号, ";
                        sSql = sSql + " NULL AS 结算日期,SUM(CASE 科目 WHEN '+ITEM_NAME+' THEN 金额 END)['+RTRIM(CAST(ITEM_NAME AS VARCHAR(100)))+'] FROM (SELECT DISTINCT ITEM_NAME FROM JC_STAT_ITEM) AS A, ";
                        sSql = sSql + " SUM(CASE WHEN 医保支付 IS NULL THEN 0 ELSE 医保支付 END) AS 医保支付, ";
                        sSql = sSql + " SUM(CASE WHEN 总费用 IS NULL THEN 0 ELSE 总费用 END) AS 总费用, ";
                        sSql = sSql + " SUM(CASE WHEN 预交 IS NULL THEN 0 ELSE 预交 END) AS 预交, ";
                        sSql = sSql + " SUM(CASE WHEN 自付 IS NULL THEN 0 ELSE 自付 END) AS 自付, ";
                        sSql = sSql + " SUM(CASE WHEN 补退 IS NULL THEN 0 ELSE 补退 END) AS 补退, ";
                        sSql = sSql + " SUM(CASE WHEN CODE IN ('01','02','03') THEN 金额 END) AS 药品合计, ";
                        sSql = sSql + " SUM(CASE WHEN CODE NOT IN ('01','02','03') THEN 金额 END) AS 医疗合计, ";
                        sSql = sSql + " SUM(金额) AS 合计 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT A.INPATIENT_NO AS 住院号,A.NAME AS 姓名,A.BRLX_NAME AS 类型,A.IN_DATE AS 入院日期,A.OUT_DATE AS 出院日期, ";
                        sSql = sSql + " A.CUR_DEPT_NAME AS 出院科室,A.BILLNO AS 发票号,B.DISCHARGE_DATE AS 结算日期,C.ITEM_NAME AS 科目, ";
                        sSql = sSql + " ACVALUE AS 金额,B.YB_FEE AS 医保支付,B.NFEE AS 总费用,B.DEPTOSITS AS 预交,B.SELF_FEE AS 自付, ";
                        sSql = sSql + " B.PATCH_FEE AS 补退,C.CODE ";
                        sSql = sSql + " FROM VI_ZY_VINPATIENT_ALL A  ";
                        sSql = sSql + " INNER JOIN ZY_DISCHARGE B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                        sSql = sSql + " INNER JOIN ZY_FEE_SPECI E ON A.INPATIENT_ID = E.INPATIENT_ID ";
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM C ON C.CODE = E.STATITEM_CODE ";
                        sSql = sSql + " WHERE E.DELETE_BIT = 0 AND E.CHARGE_BIT = 1 AND B.CANCEL_BIT = 0 ";
                        sSql = String.Format("{0} AND B.DISCHARGE_DATE >= '{1}' AND B.DISCHARGE_DATE < '{2}' ", sSql, arrList[0], arrList[1]);
                        sSql = sSql + " ) BB ";

                    }
                    break;
                case ConnectType.ORACLE:
                    {
                    }
                    break;
                case ConnectType.IBMDB2:
                    {
                    }
                    break;
                case ConnectType.MSACCESS:
                    {
                    }
                    break;
                case ConnectType.OTHER:
                    {
                    }
                    break;
            }
            DataTable daTable = dataBase.GetDataTable(sSql);
            return daTable;
        }
        public static DataTable RmProjectCostsAreBasedOnStatisticsOfThePatient(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT * FROM ( ";
                        sSql = sSql + " SELECT '合计' 序号,'' 医保类型,'' 姓名,'' 住院号,'' 结算日期,'' 发票号,SUM(YB_FEE) 医保支付,SUM(LACK_FEE) 欠费,'' 操作员 ";
                        sSql = sSql + " FROM YY_BRXX A INNER JOIN ZY_INPATIENT B ON A.BRXXID = B.PATIENT_ID INNER JOIN ZY_DISCHARGE C ON B.INPATIENT_ID = C.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE ((B.YBLX = {1} AND {1} > 0) OR (B.YBLX > 0 AND {1} = 0 )) ", sSql, arrList[2]);
                        sSql = String.Format("{0} AND C.DISCHARGE_DATE >= '{1}' AND C.DISCHARGE_DATE <= '{2}' ", sSql, arrList[0], arrList[1]);
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT '' 序号,(SELECT AA.NAME FROM JC_YBLX AA WHERE ID = B.YBLX) 医保类型,A.BRXM 姓名,INPATIENT_NO 住院号, ";
                        sSql = sSql + " DBO.FUN_GETDATE(C.DISCHARGE_DATE ) 结算日期,CAST(BILLNO AS VARCHAR(50)) 发票号,YB_FEE 医保支付,LACK_FEE 欠费, ";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(USERID) 操作员 ";
                        sSql = sSql + " FROM YY_BRXX A INNER JOIN ZY_INPATIENT B ON A.BRXXID = B.PATIENT_ID ";
                        sSql = sSql + " INNER JOIN ZY_DISCHARGE C ON B.INPATIENT_ID = C.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE ((B.YBLX = {1} AND {1} > 0) OR (B.YBLX > 0 AND {1} = 0 )) ", sSql, arrList[2]);
                        sSql = String.Format("{0} AND C.DISCHARGE_DATE >= '{1}' AND C.DISCHARGE_DATE <= '{2}' ", sSql, arrList[0], arrList[1]);
                        sSql = sSql + " ) A ORDER BY 序号,医保类型,结算日期 ";
                    }
                    break;
                case ConnectType.ORACLE:
                    {
                    }
                    break;
                case ConnectType.IBMDB2:
                    {
                    }
                    break;
                case ConnectType.MSACCESS:
                    {
                    }
                    break;
                case ConnectType.OTHER:
                    {
                    }
                    break;
            }
            DataTable daTable = dataBase.GetDataTable(sSql);
            return daTable;
        }
        public static DataTable RmPatientsDischargedFromTheHospitalAndClassifiedByProject(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            DataTable tempTable = null;
            string tempSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 0)
                        {
                            tempSql = tempSql + " SELECT 0,B.DEPT_ID,A.INPATIENT_ID,STATITEM_CODE,SUN(SDVALUE) FROM ZY_FEE_SPECI A ";
                            tempSql = tempSql + " INNER JOIN ZY_INPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                            tempSql = String.Format("{0} WHERE FLAG NOT IN (2,6) AND CHARGE_DATE >= '{1}' AND CHARGE_DATE <= '{2}' ", tempSql, arrList[1], arrList[2]);
                            tempSql = tempSql + " AND CHARGE_BIT = 1 AND DELETE_BIT = 0 AND DISCHARGE_BIT = 0 ";
                            tempSql = String.Format("{0} (({1} > 0 AND B.DEPT_ID = {1}) OR ({1} = 0)) ", tempSql, Convert.ToInt32(arrList[3]));
                            tempSql = tempSql + " GROUP BY B.DEPT_ID,A.INPATIENT_ID,STATITEM_CODE ";
                        }
                        else
                        {
                            tempSql = tempSql + " SELECT A.ID,A.DEPT_ID,A.INPATIENT_ID,STATITEM_CODE,SUM(ITEMVALUES) FROM ZY_DISCHARGE A ";
                            tempSql = tempSql + " INNER JOIN ZY_DISCHARGELIST B ON A.ID = B.DISCHARGE_ID ";
                            tempSql = String.Format("{0} WHERE DISCHARGE_DATE >= '{1}' AND DISCHARGE_DATE <= '{2}' ", tempSql, arrList[1], arrList[2]);
                            tempSql = String.Format("{0} AND (({1} > 0 AND B.DEPT_ID = {1} = 0)) ", tempSql, Convert.ToInt32(arrList[3]));
                            tempSql = tempSql + " GROUP BY A.ID,A.DEPT_ID,A.INPATIENT_ID,STATITEM_CODE ";
                        }
                    }
                    break;
            }

            DataTable daTable = dataBase.GetDataTable(sSql);
            return daTable;
        }
    }
}