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
 * 名称：住院处方管理数据库访问类
 * 描述：适用于住院处方管理中的数据库访问
 * 编写时间：2013-10
 * 作者：Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class PrescManageDataBaseAccessClass
    {
        /// <summary>
        /// 查询是否有药品
        /// </summary>
        /// <param name="deptId">科室ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static int ApplyDrugLeadingDrug(int isPosition,ArrayList arrList, RelationalDatabase dataBase)  
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (isPosition == 1)
                        {
                            sSql = String.Format("{0} SELECT COUNT(1) FROM ZY_FEE_SPECI WHERE STATITEM_CODE IN ('01','02') AND CHARGE_BIT = 1 AND FY_BIT = 0 AND (APPLY_ID IS NULL OR APPLY_ID = '{1}') ", sSql, Guid.Empty);
                            sSql = String.Format("{0} AND DEPT_ID = {1}", sSql, arrList[0]);
                        }
                        else if (isPosition == 2)
                        {
                            sSql = sSql + " SELECT COUNT(1) FROM ZY_FEE_SPECI WHERE CZ_FLAG != 2 AND STATITEM_CODE IN ('01','02') AND CHARGE_BIT = 1 AND FY_BIT = 0 ";
                            sSql = String.Format("{0} AND EXECDEPT_ID = {1} AND (APPLY_ID IS NULL OR APPLY_ID = '{3}') AND DEPT_ID = {2} ", sSql, arrList[1], arrList[0], Guid.Empty);
                        }
                        else if (isPosition == 3)
                        {
                            sSql = sSql + " SELECT COUNT(1) FROM ZY_FEE_SPECI WHERE CZ_FLAG = 2 AND STATITEM_CODE IN ('01','02') AND CHARGE_BIT = 1 AND FY_BIT = 0 ";
                            sSql = String.Format("{0} AND EXECDEPT_ID = {1} AND (APPLY_ID IS NULL OR APPLY_ID = '{3}') AND DEPT_ID = {2} ", sSql, arrList[1], arrList[0], Guid.Empty);
                        }
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

            return Convert.ToInt32(dataBase.GetDataRow(sSql)[0]);
        }
        /// <summary>
        /// 获取执行科室
        /// </summary>
        /// <param name="dataBase">数据连接</param>
        /// <returns></returns>
        public static DataTable ApplyDrugGetDept(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT DEPTID,KSMC FROM YP_YJKS WHERE KSLX = '药房' ";
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
        /// <summary>
        /// 生成退药统领单/生成退药统领单
        /// </summary>
        /// <param name="applyTime">生成时间</param>
        /// <param name="employeeId">人员ID</param>
        /// <param name="wardId">病区ID</param>
        /// <param name="deptId">科室ID</param>
        /// <param name="msgType">类型</param>
        /// <param name="dataBase">数据库连接</param>
        public static void ApplyDrugGenerationSingleMedicatinGuideOfWithdrawal(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string[] sSql = new string[2];

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql[0] = sSql[0] + " INSERT INTO ZY_APPLY_DRUG (APPLY_DATE,APPLY_NURSE,APPLY_WARD,EXECDEPT_ID,MSG_TYPE) ";
                        sSql[0] = String.Format("{0} VALUES ('{1}',{2},'{3}',{4},{5}) ", sSql[0], Convert.ToDateTime(arrList[0]), Convert.ToInt32(arrList[1]), arrList[2], Convert.ToInt32(arrList[3]), Convert.ToInt32(arrList[4]));


                        sSql[1] = String.Format("{0} UPDATE ZY_FEE_SPECI SET TLFS = 0,APPLY_ID = SELECT IDENT_CURRENT('ZY_APPLY_DRUG'),APPLY_DATE = '{1}', ", sSql[1], Convert.ToDateTime(arrList[0]));
                        sSql[1] = String.Format("{0} DEPT_LY = {1} WHERE APPLY_ID = 0 AND STATITEM_CODE IN ('01','02') AND CZ_FLAG != 2 ", sSql[1], Convert.ToInt32(arrList[3]));
                        sSql[1] = String.Format("{0} AND FY_BIT = 0 AND DELETE_BIT = 0 AND CHARGE_BIT = 1 AND DEPT_ID = {1} ", sSql[1], Convert.ToInt32(arrList[3]));

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

            dataBase.DoCommand(null,null,null,sSql);
        }
        /// <summary>
        /// 统领信息查询
        /// </summary>
        /// <param name="arrList">参数集合</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ApplyDrugQuery(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            DataTable daTable = null;

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if ((bool)arrList[0] == true && (bool)arrList[2] == true)//已发药 领药
                        {
                            sSql = sSql + " SELECT RTRIM(B.ITEM_NAME) AS 药品名称,RTRIM(UNIT) AS 单位,SUM(NUM) AS 数量,RETAIL_PRICE AS 单价,SUM(ACVALUE) AS 金额, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(DOC_ID) AS 开药医生,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS 记帐人, ";
                            sSql = sSql + " DBO.FUN_GETDATE(CHARGE_DATE) AS 记帐时间,DBO.FUN_ZY_SEEKDEPTNAME(A.EXECDEPT_ID) AS 执行科室, ";
                            sSql = sSql + " (CASE FY_BIT WHEN 1 THEN '已发' WHEN 0 THEN '未发' ELSE '未知' END) AS 是否发药 ";
                            sSql = sSql + " FROM ZY_APPLY_DRUG A INNER JOIN ZY_FEE_SPECI B ON A.APPLY_ID = B.APPLY_ID ";
                            sSql = String.Format("{0} WHERE B.FY_BIT = 1 AND B.CZ_FLAG != 2 AND CAST ( DBO.FUN_GETDATE(A.APPLY_DATE)As datetime) = cast('{1}' as datetime)", sSql, arrList[4]);
                            sSql = String.Format("{0} AND DEPT_ID = {1} ", sSql, Convert.ToInt32(arrList[5]));
                            sSql = sSql + " GROUP BY B.ITEM_NAME,B.UNIT,RETAIL_PRICE,DOC_ID,CHARGE_USER,DBO.FUN_GETDATE(CHARGE_DATE),A.EXECDEPT_ID,FY_BIT ";
                        }
                        else if ((bool)arrList[0] == true && (bool)arrList[3] == true)  //已发药 退药
                        {
                            sSql = sSql + " SELECT RTRIM(B.ITEM_NAME) AS 药品名称,RTRIM(UNIT) AS 单位,SUM(NUM) AS 数量,RETAIL_PRICE AS 单价,SUM(ACVALUE) AS 金额, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(DOC_ID) AS 开药医生,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS 记帐人, ";
                            sSql = sSql + " DBO.FUN_GETDATE(CHARGE_DATE) AS 记帐时间,DBO.FUN_ZY_SEEKDEPTNAME(A.EXECDEPT_ID) AS 执行科室, ";
                            sSql = sSql + " (CASE FY_BIT WHEN 1 THEN '已发' WHEN 0 THEN '未发' ELSE '未知' END) AS 是否发药 ";
                            sSql = sSql + " FROM ZY_APPLY_DRUG A INNER JOIN ZY_FEE_SPECI B ON A.APPLY_ID = B.APPLY_ID ";
                            sSql = String.Format("{0} WHERE B.FY_BIT = 1 AND B.CZ_FLAG = 2 AND CAST ( DBO.FUN_GETDATE(A.APPLY_DATE)As datetime) = cast('{1}' as datetime) ", sSql, arrList[4]);
                            sSql = String.Format("{0} AND DEPT_ID = {1} ", sSql, Convert.ToInt32(arrList[5]));
                            sSql = sSql + " GROUP BY B.ITEM_NAME,B.UNIT,RETAIL_PRICE,DOC_ID,CHARGE_USER,DBO.FUN_GETDATE(CHARGE_DATE),A.EXECDEPT_ID,FY_BIT ";
                        }
                        else if ((bool)arrList[1] == true && (bool)arrList[2] == true) //未发药 领药
                        {
                            sSql = sSql + " SELECT RTRIM(B.ITEM_NAME) AS 药品名称,RTRIM(UNIT) AS 单位,SUM(NUM) AS 数量,RETAIL_PRICE AS 单价,SUM(ACVALUE) AS 金额, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(DOC_ID) AS 开药医生,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS 记帐人, ";
                            sSql = sSql + " DBO.FUN_GETDATE(CHARGE_DATE) AS 记帐时间,DBO.FUN_ZY_SEEKDEPTNAME(A.EXECDEPT_ID) AS 执行科室, ";
                            sSql = sSql + " (CASE FY_BIT WHEN 1 THEN '已发' WHEN 0 THEN '未发' ELSE '未知' END) AS 是否发药 ";
                            sSql = sSql + " FROM ZY_APPLY_DRUG A INNER JOIN ZY_FEE_SPECI B ON A.APPLY_ID = B.APPLY_ID ";
                            sSql = String.Format("{0} WHERE B.FY_BIT = 0 AND B.CZ_FLAG != 2 AND CAST ( DBO.FUN_GETDATE(A.APPLY_DATE)As datetime) = cast('{1}' as datetime) ", sSql, arrList[4].ToString());
                            sSql = String.Format("{0} AND DEPT_ID = {1} ", sSql, Convert.ToInt32(arrList[5]));
                            sSql = sSql + " GROUP BY B.ITEM_NAME,B.UNIT,RETAIL_PRICE,DOC_ID,CHARGE_USER,DBO.FUN_GETDATE(CHARGE_DATE),A.EXECDEPT_ID,FY_BIT ";

                        }
                        else if ((bool)arrList[1] == true && (bool)arrList[3] == true) //未服药 退药
                        {

                            sSql = sSql + " SELECT RTRIM(B.ITEM_NAME) AS 药品名称,RTRIM(UNIT) AS 单位,SUM(NUM) AS 数量,RETAIL_PRICE AS 单价,SUM(ACVALUE) AS 金额, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(DOC_ID) AS 开药医生,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS 记帐人, ";
                            sSql = sSql + " DBO.FUN_GETDATE(CHARGE_DATE) AS 记帐时间,DBO.FUN_ZY_SEEKDEPTNAME(A.EXECDEPT_ID) AS 执行科室, ";
                            sSql = sSql + " (CASE FY_BIT WHEN 1 THEN '已发' WHEN 0 THEN '未发' ELSE '未知' END) AS 是否发药 ";
                            sSql = sSql + " FROM ZY_APPLY_DRUG A INNER JOIN ZY_FEE_SPECI B ON A.APPLY_ID = B.APPLY_ID ";
                            sSql = String.Format("{0} WHERE B.FY_BIT = 0 AND B.CZ_FLAG = 2 AND CAST ( DBO.FUN_GETDATE(A.APPLY_DATE)As datetime) = cast('{1}' as datetime) ", sSql, arrList[4]);
                            sSql = String.Format("{0} AND DEPT_ID = {1} ", sSql, Convert.ToInt32(arrList[5]));
                            sSql = sSql + " GROUP BY B.ITEM_NAME,B.UNIT,RETAIL_PRICE,DOC_ID,CHARGE_USER,DBO.FUN_GETDATE(CHARGE_DATE),A.EXECDEPT_ID,FY_BIT ";
                        }
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

            daTable = dataBase.GetDataTable(sSql);
            return daTable;
        }
        /// <summary>
        /// 冲账费用信息
        /// </summary>
        /// <param name="arrList">参数集合</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable PrescManageCancelFeeCreate(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT 0 序号,CAST(0 AS SMALLINT) 选,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) 处方号,ITEM_NAME 项目名称,UNIT 单位, ";
                        sSql = sSql + " CAST(NUM AS FLOAT) 数量,CAST(COST_PRICE AS FLOAT) 单价,CAST(SDVALUE AS FLOAT) 金额,CHARGE_DATE 记帐时间, ";
                        sSql = sSql + " BOOK_DATE,DBO.FUN_GETEMPNAME(CHARGE_USER) 记帐员,FY_DATE 发药时间,DBO.FUN_GETEMPNAME(FY_USER) 发药员, ";
                        sSql = sSql + " INPATIENT_ID,ID,PRESCRIPTION_ID PRESCID,CZ_FLAG,DEPT_BR,DOSAGE 剂量,DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS 执行科室, ";
                        sSql = sSql + " DEPT_ID FROM ZY_FEE_SPECI ";
                        sSql = String.Format("{0} WHERE INPATIENT_ID = '{1}' AND DELETE_BIT = 0 ", sSql, arrList[0]);
                        if ((bool)arrList[1] == true)
                            sSql = sSql + " AND CZ_FLAG = 2 ";
                        if ((bool)arrList[4] == true)
                            sSql = String.Format("{0} AND CHARGE_DATE >= '{1}' AND CHARGE_DATE <= '{2}' AND XMLY = 1 AND CHARGE_BIT = 1 ", sSql, arrList[2], arrList[3]);
                        if ((bool)arrList[5] == true)
                            sSql = String.Format("{0} AND CHARGE_DATE >= '{1}' AND CHARGE_DATE <= '{2}' AND XMLY = 2 AND CHARGE_BIT = 1 ", sSql, arrList[2], arrList[3]);
                        if ((bool)arrList[6] == true)
                        {
                            sSql = "";
                            sSql = sSql + " SELECT 0 序号,CAST(0 AS SMALLINT) 选,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) 处方号,S_YPPM 项目名称,UNIT 单位, ";
                            sSql = sSql + " CAST(NUM AS FLOAT) 数量,CAST(LSJ/UNITRATE AS FLOAT) 单价,CAST((LSJ/UNITRATE*NUM*DOSAGE) AS FLOAT) 金额,'' 记帐时间, ";
                            sSql = sSql + " '' 记帐员,BOOK_DATE,'' 发药时间,'' 发药员,INPATIENT_ID,0,ID,ID PRESCID,0 CZ_FLAG,DEPT_ID,DOSAGE 剂量, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS 执行科室,DEPT_ID FROM ZY_PRESCRIPTION A,YP_YPCJD B ";
                            sSql = String.Format("{0} WHERE A.HDITEM_ID = B.CJID AND INPATIENT_ID = '{1}' AND CHARGE_BIT <> 1 AND XMLY = 1 ", sSql, arrList[0]);
                        }
                        if (arrList[7].ToString() != "" && (bool)arrList[6] == false)
                            sSql = String.Format("{0} AND SDVALUE = {1}", sSql, arrList[7]);
                        sSql = sSql + " ORDER BY PRESC_DATE,ORDER_ID,TYPE ASC ";
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
        /// <summary>
        /// 获取费用明细
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable HccsGetFeeClass(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT B.ITEM_NAME,SUM(ACVALUE) AS ACVALUE FROM ZY_FEE_SPECI AS A ";
                        sSql = sSql + " LEFT JOIN (SELECT * FROM JC_STAT_ITEM) AS B ON A.STATITEM_CODE = B.CODE ";
                        sSql = String.Format("{0} WHERE A.DISCHARGE_BIT = 0 AND A.CHARGE_BIT = 1 AND A.DELETE_BIT = 0 AND A.INPATIENT_ID = '{1}' ", sSql, arrList[0]);
                        sSql = sSql + " GROUP BY B.ITEM_NAME ";
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
        /// <summary>
        /// 加载词典
        /// 存储过程--SP_ZY_ITEM_SELECT
        /// </summary>
        /// <param name="isJgbm">机构编码</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable HccsZyItemSelect(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT D_CODE AS ITEMCODE,ITEMNAME,STANDARD,UNIT,PRICE,PY_CODE,WB_CODE,D_CODE, ";
                        sSql = sSql + " EXECDEPTID, EXECDEPT,'' AS SELFRATE ,'' AS INSURETYPE, ITEMID,TCID,BIGITEMCODE,1 AS ZFBL, '' AS S_SCCJ, 1 DWBL, 2 XMLY ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT 0 ROWNO,B.STD_CODE AS ITEMCODE,B.ITEM_NAME AS ITEMNAME,'' AS STANDARD, B.ITEM_UNIT AS UNIT,1 AS DWBL, ";
                        sSql = sSql + " B.RETAIL_PRICE AS PRICE,B.PY_CODE,B.ITEM_CODE AS D_CODE,B.WB_CODE,  ";
                        sSql = sSql + " CASE WHEN D.EXEC_DEPT_ID>0 THEN D.EXEC_DEPT_ID ELSE B.ZXDD_ID END AS EXECDEPTID, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(CASE WHEN D.EXEC_DEPT_ID>0 THEN D.EXEC_DEPT_ID ELSE B.ZXDD_ID END) AS EXECDEPT,'' AS PROD_AREA, B.ITEM_ID AS ITEMID, ";
                        sSql = sSql + " -1 AS UNIT_ID, B.RETAIL_PRICE AS ITEMPFJ,B.RETAIL_PRICE AS ITEMYHJ, B.STATITEM_CODE AS BIGITEMCODE ,-1 AS TCID,C.CFLX_CODE AS PRESCTYPE,B.JGBM ";
                        sSql = sSql + " FROM JC_HSITEMDICTION AS B ";
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM AS C ON B.STATITEM_CODE=C.CODE ";
                        sSql = sSql + " LEFT JOIN JC_HSITEM_DEPT D ON B.ITEM_ID=D.HSITEM_ID AND D.TCID<=0 ";
                        sSql = String.Format("{0} LEFT JOIN JC_DEPT_PROPERTY E ON D.EXEC_DEPT_ID=E.DEPT_ID AND E.JGBM={1} AND", sSql, Convert.ToInt32(arrList[0]));
                        sSql = String.Format("{0} B.DELETE_BIT=0 AND B.JGBM={1} ", sSql, Convert.ToInt32(arrList[0]));
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 0 ROWNO,'' AS ITEMCODE,B.ITEM_NAME AS ITEMNAME,'' AS STANDARD,B.ITEM_UNIT AS UNIT,1 AS DWBL,TCPRICE AS PRICE,B.PY_CODE,B.CODE AS D_CODE, ";
                        sSql = sSql + " B.WB_CODE,CASE WHEN D.EXEC_DEPT_ID>0 THEN D.EXEC_DEPT_ID ELSE B.EXEC_DEPT END AS EXECDEPTID, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(CASE WHEN D.EXEC_DEPT_ID>0 THEN D.EXEC_DEPT_ID ELSE B.EXEC_DEPT END) AS EXECDEPT, ";
                        sSql = sSql + " '' AS PROD_AREA,B.ITEM_ID AS ITEMID,-1 AS UNIT_ID,TCPRICE AS ITEMPFJ,TCPRICE AS ITEMYHJ, '0' AS BIGITEMCODE , ";
                        sSql = sSql + " B.ITEM_ID AS TCID,'-1' AS PRESCTYPE,B.JGBM ";
                        sSql = sSql + " FROM ( ";
                        sSql = String.Format("{0} SELECT A.*,PRICE AS TCPRICE FROM JC_TC AS A WHERE JGBM='{1}' ", sSql, Convert.ToInt32(arrList[0]));
                        sSql = sSql + " ) AS B ";
                        sSql = sSql + " LEFT JOIN JC_HSITEM_DEPT D ON B.ITEM_ID=D.HSITEM_ID AND B.ITEM_ID=D.TCID ";
                        sSql = String.Format("{0} LEFT JOIN JC_DEPT_PROPERTY E ON D.EXEC_DEPT_ID=E.DEPT_ID AND E.JGBM={1} ", sSql, Convert.ToInt32(arrList[0]));
                        sSql = sSql + " WHERE B.DELETE_BIT=0 ";
                        sSql = sSql + " ) A ";
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
        /// <summary>
        /// 加载药品
        /// 存储过程--SP_ZY_DRUGITEM_SELECT
        /// </summary>
        /// <param name="deptId">科室ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable HccsZyDrugitemSelect(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT A.STATITEM_CODE AS ITEMID, ";
                        sSql = sSql + " (RTRIM(A.YPPM)+( CASE WHEN A.YPPM=A.YPSPM THEN '' ELSE '('+A.YPSPM+')'  END )+ RTRIM((CASE WHEN A.YPSPMBZ IS NULL THEN '' ELSE A.YPSPMBZ END)))AS ITEMNAME, ";
                        sSql = sSql + " A.YPGG AS STANDARD, DBO.FUN_YP_YPDW(A.ZXDW) AS UNIT, A.LSJ/A.DWBL AS PRICE, ";
                        sSql = sSql + " B.PYM AS PY_CODE , B.WBM AS WB_CODE, A.SHH AS ITEMCODE, A.DEPTID AS EXECDEPTID, ";
                        sSql = sSql + " DBO.FUN_JC_DEPTNAME(A.DEPTID) AS EXECDEPT, A.ZFBL, A.YBLX AS INSURETYPE, ";
                        sSql = sSql + " A.MZYP AS ISMZ, A.DJYP AS ISDJ, A.SYXL AS YP_LIMIT, -1 AS XDCFID, -1 AS TCID, ";
                        sSql = sSql + " A.STATITEM_CODE AS BIGITEMCODE, A.CJID, A.S_SCCJ, A.DWBL, KCL, 1 XMLY ";
                        sSql = sSql + " FROM VI_YF_KCMX A ";
                        sSql = sSql + " INNER JOIN YP_YPBM AS B ON A.GGID = B.GGID ";
                        sSql = String.Format("{0} WHERE BDELETE_KC=0 AND DEPTID = {1} AND KCL>0 ORDER BY B.PYM ", sSql, Convert.ToInt32(arrList[0]));

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
        /// <summary>
        /// ID转NAME
        /// </summary>
        /// <param name="isConvert">科室OR医生</param>
        /// <param name="deptId">ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable HccsIdConvertName(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 1)  //科室
                            sSql = String.Format("{0} SELECT DBO.FUN_GETDEPTNAME('{1}') AS 执行科室 ", sSql, Convertor.IsNull(arrList[1], "0"));
                        else if (Convert.ToInt32(arrList[0]) == 2)  //医生
                            sSql = String.Format("{0} SELECT DBO.FUN_GETEMPNAME('{1}') AS 医生 ", sSql, Convertor.IsNull(arrList[1], "0"));
                        else if (Convert.ToInt32(arrList[0]) == 3) //统计大项目
                            sSql = String.Format("{0}SELECT ITEM_CODE FROM JC_HSITEMDICTION WHERE DELETE_BIT = 0 AND ITEM_ID = '{1}' ", sSql, arrList[1]);
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
        /// <summary>
        /// 获取处方
        /// 存储过程--SP_ZY_GET_PRESCCOLL_EX
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="isType">类型</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable HccsZyGetPresccoll(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[1]) == 0)  //未记帐的项目
                        {
                            sSql = sSql + " SELECT ID AS PROSECID,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) AS PRESC_NO,CAST(HDITEM_ID AS VARCHAR(50)) AS ITEMCODE, ";
                            sSql = sSql + " (CASE WHEN (SELECT ITEM_NAME FROM JC_HSITEMDICTION WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID AND TCID <= 0 AND JGBM=ZY_PRESCRIPTION.JGBM) IS NULL THEN (SELECT ITEM_NAME FROM JC_TC  WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID AND JGBM=ZY_PRESCRIPTION.JGBM) ELSE (SELECT ITEM_NAME FROM JC_HSITEMDICTION WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID AND JGBM=ZY_PRESCRIPTION.JGBM) END) AS ITEMNAME, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS EXECDEPT,CAST(STANDARD AS VARCHAR(50)) AS STANDARD,CAST(UNIT AS VARCHAR(50)) AS UNIT,  ";
                            sSql = sSql + " CAST(PRICE AS FLOAT)  AS PRICE, CAST(NUM AS VARCHAR(10)) AS NUM,CAST(AGIO AS VARCHAR(50)) AS AGIO, CAST(DOSAGE AS VARCHAR(50)) AS DOSAGE, ";
                            sSql = sSql + " CAST(PRICE*NUM*DOSAGE AS FLOAT) AS [VALUES],DBO.FUN_ZY_SEEKEMPLOYEENAME(PRESC_DOC) AS PREDOC,PRESC_DATE AS PREDATE, HDITEM_ID AS HSITEMID, EXECDEPT_ID AS EXECDEPTID, ";
                            sSql = sSql + " CAST(PRESC_DOC AS VARCHAR(50)) AS PREDOCID,CAST(TCID AS VARCHAR(50)) AS TCID, 'YPHH' AS YPHH, 'LIMIT'  AS LIMIT,CAST(UNITRATE AS VARCHAR(50)) AS UNITRATE, ";
                            sSql = sSql + " STATITEM_CODE  AS BIGITEMCODE,  CAST(CHARGE_BIT AS SMALLINT) AS CHARGE_BIT,XMLY ";
                            sSql = sSql + " FROM ZY_PRESCRIPTION ";
                            sSql = String.Format("{0} WHERE (ORDER_ID=DBO.FUN_GETEMPTYGUID() OR ORDER_ID IS NULL)  AND CHARGE_BIT<>1 AND INPATIENT_ID = '{1}' ", sSql, arrList[0]);
                            sSql = sSql + " AND XMLY=2 ORDER BY PRESC_NO DESC ";
                        }
                        else if (Convert.ToInt32(arrList[1]) == 1)  //未记帐的药品
                        {

                            sSql = sSql + " SELECT ID AS PROSECID,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) AS PRESC_NO,CAST(HDITEM_ID AS VARCHAR(50)) AS ITEMCODE, ";
                            sSql = sSql + " (SELECT YPPM FROM VI_YP_YPCD WHERE CJID = ZY_PRESCRIPTION.HDITEM_ID) AS ITEMNAME,DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS EXECDEPT, ";
                            sSql = sSql + " CAST(STANDARD AS VARCHAR(50)) AS STANDARD, CAST(UNIT AS VARCHAR(50)) AS UNIT,CAST(PRICE AS FLOAT) AS PRICE,CAST(NUM AS VARCHAR(10)) AS NUM, ";
                            sSql = sSql + " CAST(AGIO AS VARCHAR(50)) AS AGIO,CAST(DOSAGE AS VARCHAR(50)) AS DOSAGE,CAST(PRICE*NUM*DOSAGE AS FLOAT) AS [VALUES], ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(PRESC_DOC) AS PREDOC,PRESC_DATE AS PREDATE,HDITEM_ID AS HSITEMID,EXECDEPT_ID AS EXECDEPTID, ";
                            sSql = sSql + " CAST(PRESC_DOC AS VARCHAR(50)) AS PREDOCID,CAST(TCID AS VARCHAR(50)) AS TCID,SUBCODE AS YPHH,'LIMIT'  AS LIMIT, ";
                            sSql = sSql + " CAST(UNITRATE AS VARCHAR(50)) AS UNITRATE,STATITEM_CODE AS BIGITEMCODE, CAST(CHARGE_BIT AS SMALLINT) AS CHARGE_BIT,XMLY ";
                            sSql = sSql + " FROM ZY_PRESCRIPTION ";
                            sSql = String.Format("{0} WHERE (ORDER_ID=DBO.FUN_GETEMPTYGUID() OR ORDER_ID IS NULL) AND CHARGE_BIT<>1 AND INPATIENT_ID = '{1}' ", sSql, arrList[0]);
                            sSql = sSql + " AND XMLY=1 ORDER BY PRESC_NO DESC ";
                        }
                        else if (Convert.ToInt32(arrList[1]) == 2)  //已记帐的项目
                        {
                            sSql = sSql + " SELECT ID AS PROSECID,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) AS PRESC_NO,CAST(HDITEM_ID AS VARCHAR(50)) AS ITEMCODE, ";
                            sSql = sSql + " (CASE WHEN (SELECT ITEM_NAME FROM JC_HSITEMDICTION WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID AND TCID <= 0) IS NULL THEN (SELECT ITEM_NAME FROM JC_TC  WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID) ELSE (SELECT ITEM_NAME FROM JC_HSITEMDICTION WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID) END) AS ITEMNAME, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS EXECDEPT,CAST(STANDARD AS VARCHAR(50)) AS STANDARD,CAST(UNIT AS VARCHAR(50)) AS UNIT, ";
                            sSql = sSql + " CAST(PRICE AS FLOAT)  AS PRICE, CAST(NUM AS VARCHAR(10)) AS NUM, CAST(AGIO AS VARCHAR(50)) AS AGIO, CAST(DOSAGE AS VARCHAR(50)) AS DOSAGE, ";
                            sSql = sSql + " CAST(PRICE*NUM*DOSAGE AS FLOAT) AS [VALUES],DBO.FUN_ZY_SEEKEMPLOYEENAME(PRESC_DOC) AS PREDOC, ";
                            sSql = sSql + " PRESC_DATE AS PREDATE, HDITEM_ID AS HSITEMID, EXECDEPT_ID AS EXECDEPTID,CAST(PRESC_DOC AS VARCHAR(50)) AS PREDOCID, ";
                            sSql = sSql + " CAST(TCID AS VARCHAR(50)) AS TCID, 'YPHH' AS YPHH, 'LIMIT'  AS LIMIT,CAST(UNITRATE AS VARCHAR(50)) AS UNITRATE,  ";
                            sSql = sSql + " STATITEM_CODE  AS BIGITEMCODE,  CAST(CHARGE_BIT AS SMALLINT) AS CHARGE_BIT,XMLY ";
                            sSql = sSql + " FROM ZY_PRESCRIPTION ";
                            sSql = String.Format("{0} WHERE CHARGE_BIT=1 AND INPATIENT_ID = '{1}' AND XMLY=2 ORDER BY PRESC_NO DESC ", sSql, arrList[0]);
                        }
                        else if (Convert.ToInt32(arrList[1]) == 3)  //已记帐的药品
                        {
                            sSql = sSql + " SELECT ID AS PROSECID,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) AS PRESC_NO,CAST(HDITEM_ID AS VARCHAR(50)) AS ITEMCODE, ";
                            sSql = sSql + " (SELECT YPPM FROM VI_YP_YPCD WHERE CJID = ZY_PRESCRIPTION.HDITEM_ID) AS ITEMNAME,DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS EXECDEPT, ";
                            sSql = sSql + " CAST(STANDARD AS VARCHAR(50)) AS STANDARD, CAST(UNIT AS VARCHAR(50)) AS UNIT,CAST(PRICE AS FLOAT) AS PRICE,CAST(NUM AS VARCHAR(10)) AS NUM, ";
                            sSql = sSql + " CAST(AGIO AS VARCHAR(50)) AS AGIO,CAST(DOSAGE AS VARCHAR(50)) AS DOSAGE,CAST(PRICE*NUM*DOSAGE AS FLOAT) AS [VALUES], ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(PRESC_DOC) AS PREDOC,PRESC_DATE AS PREDATE,HDITEM_ID AS HSITEMID,EXECDEPT_ID AS EXECDEPTID, ";
                            sSql = sSql + " CAST(PRESC_DOC AS VARCHAR(50)) AS PREDOCID,CAST(TCID AS VARCHAR(50)) AS TCID,SUBCODE AS YPHH,'LIMIT'  AS LIMIT, ";
                            sSql = sSql + " CAST(UNITRATE AS VARCHAR(50)) AS UNITRATE,STATITEM_CODE AS BIGITEMCODE, CAST(CHARGE_BIT AS SMALLINT) AS CHARGE_BIT,XMLY ";
                            sSql = sSql + " FROM ZY_PRESCRIPTION ";
                            sSql = String.Format("{0} WHERE CHARGE_BIT=1  AND INPATIENT_ID = '{1}' AND XMLY=1 ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY PRESC_NO DESC ";
                        }
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
        /// <summary>
        /// 删除处方记录
        /// </summary>
        /// <param name="prosecId">处方ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static void HccsZyPrescriptionDelete(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} DELETE ZY_PRESCRIPTION WHERE ID = '{1}'", sSql, arrList[0]);
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

            dataBase.DoCommand(sSql);
        }
        /// <summary>
        /// 初始化处方号
        /// </summary>
        /// <param name="dataBase">数据库连接</param>
        public static void HccsInitPresNo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " USE TRASEN DBCC CHECKIDENT (ZY_PRESCNO,RESEED,0) DELETE FROM ZY_PRESCNO ";
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
            dataBase.DoCommand(sSql);
        }
        /// <summary>
        /// 门诊已收费处方查询
        /// Modify by tck 2014-04-27 如果以医保病人，检查是否匹配医保
        /// </summary>
        /// <param name="isOutpatient">门诊号</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable HccsChargeHaveBeenQuery(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 0)
                        {
                            //sSql = sSql + " SELECT * FROM ( ";
                            //sSql = sSql + " SELECT '' 序号,1 选择,ISNULL(A.FPH,'') 发票号,A.BLH 门诊号,BRXM 姓名,BM 编码,RTRIM(PM) 项目名称,SPM 商品名,GG 规格, ";
                            //sSql = sSql + " CJ 厂家, DJ 单价, SL 数量, RTRIM(DW) 单位,JS 剂数,JE 金额, ";
                            //sSql = sSql + " (CASE WHEN BPSBZ = -1 THEN '免试' WHEN BPSBZ = 0 THEN '皮试' ELSE '' END) 皮试, ";
                            //sSql = sSql + " C.YFMC 用法,ZT 嘱托,B.KSDM 科室,B.YSDM 医生,B.ZXKS 执行科室,TCID 套餐ID,HJRQ 划价日期,HJYXM 划价员,A.SFRQ 收费日期, ";
                            //sSql = sSql + " SFYXM 收费员,FYRQ 发药日期,C.XMID 项目ID,FYRXM 发药员,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID, ";
                            //sSql = sSql + " PXXH,HJMXID,CFMXID,XMLY 项目来源,TJDXMDM 统计大项目,YDWBL,1 CHARGE_BIT ";
                            //sSql = sSql + " FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID ";
                            //sSql = sSql + " INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID ";
                            //sSql = String.Format("{0} WHERE A.BSCBZ = 0 AND A.BLH = '{1}' ", sSql, arrList[1]);
                            //sSql = sSql + " ) A ORDER BY 发票号,划价日期,PXXH,CFMXID ";
                            sSql = @" SELECT * FROM ( 
                              SELECT '' 序号,1 选择,ISNULL(A.FPH,'') 发票号,A.BLH 门诊号,BRXM 姓名,BM 编码,RTRIM(PM) 项目名称,SPM 商品名,GG 规格,CJ 厂家,DJ 单价
                              ,SL+(SELECT ISNULL(SUM(SL),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) 数量, RTRIM(DW) 单位
                              ,JS+(SELECT ISNULL(SUM(JS),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) 剂数
                              ,JE+(SELECT ISNULL(SUM(JE),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) 金额,
                             (CASE WHEN BPSBZ = -1 THEN '免试' WHEN BPSBZ = 0 THEN '皮试' ELSE '' END) 皮试, 
                              C.YFMC 用法,ZT 嘱托,B.KSDM 科室,B.YSDM 医生,B.ZXKS 执行科室,TCID 套餐ID,HJRQ 划价日期,HJYXM 划价员,A.SFRQ 收费日期,
                              SFYXM 收费员,FYRQ 发药日期,C.XMID 项目ID,FYRXM 发药员,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID,
                              PXXH,HJMXID,CFMXID,XMLY 项目来源,TJDXMDM 统计大项目,YDWBL,1 CHARGE_BIT
                              FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID
                                INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID ";
                            sSql = String.Format("{0} WHERE A.BSCBZ = 0 AND TYID IS NULL AND A.BLH = '{1}' ", sSql, arrList[1]);
                            sSql = sSql + " ) A WHERE 金额>0 ORDER BY 发票号,划价日期,PXXH,CFMXID ";
                        }
                        else if (Convert.ToInt32(arrList[0]) == 1)
                        {
//                            sSql = @"SELECT * FROM (SELECT '' 序号,1 选择,ISNULL(A.FPH,'') 发票号,A.BLH 门诊号,BRXM 姓名,BM 编码,RTRIM(PM) 项目名称
//                                    ,SPM 商品名,GG 规格,CJ 厂家, DJ 单价, SL 数量, RTRIM(DW) 单位,JS 剂数,JE 金额, 
//                                    (CASE WHEN BPSBZ = -1 THEN '免试' WHEN BPSBZ = 0 THEN '皮试' ELSE '' END) 皮试, 
//                                    C.YFMC 用法,ZT 嘱托,B.KSDM 科室,B.YSDM 医生,B.ZXKS 执行科室,TCID 套餐ID,HJRQ 划价日期,HJYXM 划价员,A.SFRQ 收费日期,
//                                    SFYXM 收费员,FYRQ 发药日期,C.XMID 项目ID,FYRXM 发药员,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID, 
//                                    PXXH,HJMXID,CFMXID,b.XMLY 项目来源,TJDXMDM 统计大项目,C.YDWBL,
//                                    CASE WHEN(D.XMID IS NULL) THEN 0 
//                                    ELSE 1 END CHARGE_BIT,b.XMLY
//                                    FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID 
//                                    INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID LEFT JOIN JC_YB_BL D ON C.XMID=D.XMID and B.XMLY=D.XMLY AND D.YBLX='" + arrList[2] + @"'
//                                    WHERE B.XMLY=2 AND A.BSCBZ = 0 AND A.BLH = '" + arrList[1] + @"'
//                                    UNION ALL
//                                    SELECT '' 序号,1 选择,ISNULL(A.FPH,'') 发票号,A.BLH 门诊号,BRXM 姓名,BM 编码,RTRIM(PM) 项目名称
//                                    ,SPM 商品名,GG 规格,CJ 厂家, DJ 单价, SL 数量, RTRIM(DW) 单位,JS 剂数,JE 金额, 
//                                    (CASE WHEN BPSBZ = -1 THEN '免试' WHEN BPSBZ = 0 THEN '皮试' ELSE '' END) 皮试, 
//                                    C.YFMC 用法,ZT 嘱托,B.KSDM 科室,B.YSDM 医生,B.ZXKS 执行科室,TCID 套餐ID,HJRQ 划价日期,HJYXM 划价员,A.SFRQ 收费日期,
//                                    SFYXM 收费员,FYRQ 发药日期,C.XMID 项目ID,FYRXM 发药员,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID, 
//                                    PXXH,HJMXID,CFMXID,b.XMLY 项目来源,TJDXMDM 统计大项目,C.YDWBL,
//                                    CASE WHEN(D.XMID IS NULL) THEN 0 
//                                    ELSE 1 END CHARGE_BIT,b.XMLY
//                                    FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID 
//                                    INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID  
//                                    LEFT JOIN yp_ypcjd YP ON C.XMID=YP.CJID AND B.XMLY=1
//                                    LEFT JOIN JC_YB_BL D ON YP.GGID=D.XMID and B.XMLY=D.XMLY AND D.YBLX='" + arrList[2] + @"'
//                                    WHERE B.XMLY=1 AND A.BSCBZ = 0 AND A.BLH = '" + arrList[1] + @"'
//                                    ) A ORDER BY 发票号,划价日期,PXXH,CFMXID";
                            sSql = @"SELECT * FROM (SELECT '' 序号,1 选择,ISNULL(A.FPH,'') 发票号,A.BLH 门诊号,BRXM 姓名,BM 编码,RTRIM(PM) 项目名称
                                        ,SPM 商品名,GG 规格,CJ 厂家,DJ 单价
                                        ,SL+(SELECT ISNULL(SUM(SL),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) 数量, RTRIM(DW) 单位
                                        ,JS+(SELECT ISNULL(SUM(JS),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) 剂数
                                        ,JE+(SELECT ISNULL(SUM(JE),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) 金额, 
                                        (CASE WHEN BPSBZ = -1 THEN '免试' WHEN BPSBZ = 0 THEN '皮试' ELSE '' END) 皮试, 
                                        C.YFMC 用法,ZT 嘱托,B.KSDM 科室,B.YSDM 医生,B.ZXKS 执行科室,TCID 套餐ID,HJRQ 划价日期,HJYXM 划价员,A.SFRQ 收费日期,
                                        SFYXM 收费员,FYRQ 发药日期,C.XMID 项目ID,FYRXM 发药员,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID, 
                                        PXXH,HJMXID,CFMXID,b.XMLY 项目来源,TJDXMDM 统计大项目,C.YDWBL,
                                        CASE WHEN(D.XMID IS NULL) THEN 0 
                                        ELSE 1 END CHARGE_BIT,b.XMLY
                                            FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID 
                                              INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID LEFT JOIN JC_YB_BL D ON C.XMID=D.XMID and B.XMLY=D.XMLY AND D.YBLX='" + arrList[2] + @"'
                                                WHERE B.XMLY=2 AND A.BSCBZ = 0 AND A.BLH = '" + arrList[1] + @"'
                                    UNION ALL
                                    SELECT '' 序号,1 选择,ISNULL(A.FPH,'') 发票号,A.BLH 门诊号,BRXM 姓名,BM 编码,RTRIM(PM) 项目名称
                                        ,SPM 商品名,GG 规格,CJ 厂家 ,DJ 单价
                                        ,SL+(SELECT ISNULL(SUM(SL),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) 数量, RTRIM(DW) 单位
                                        ,JS+(SELECT ISNULL(SUM(JS),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) 剂数
                                        ,JE+(SELECT ISNULL(SUM(JE),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) 金额,
                                        (CASE WHEN BPSBZ = -1 THEN '免试' WHEN BPSBZ = 0 THEN '皮试' ELSE '' END) 皮试, 
                                        C.YFMC 用法,ZT 嘱托,B.KSDM 科室,B.YSDM 医生,B.ZXKS 执行科室,TCID 套餐ID,HJRQ 划价日期,HJYXM 划价员,A.SFRQ 收费日期,
                                        SFYXM 收费员,FYRQ 发药日期,C.XMID 项目ID,FYRXM 发药员,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID, 
                                        PXXH,HJMXID,CFMXID,b.XMLY 项目来源,TJDXMDM 统计大项目,C.YDWBL,
                                        CASE WHEN(D.XMID IS NULL) THEN 0 
                                        ELSE 1 END CHARGE_BIT,b.XMLY
                                           FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID 
                                              INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID  
                                                 LEFT JOIN yp_ypcjd YP ON C.XMID=YP.CJID AND B.XMLY=1
                                                    LEFT JOIN JC_YB_BL D ON YP.GGID=D.XMID and B.XMLY=D.XMLY AND D.YBLX='" + arrList[2] + @"'
                                                       WHERE B.XMLY=1 AND A.BSCBZ = 0 AND A.BLH = '" + arrList[1] + @"'
                                                         ) A WHERE 金额>0 ORDER BY 发票号,划价日期,PXXH,CFMXID";
                        }
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

        /// <summary>
        /// 是否医保匹配
        /// ADD BY TCK 2014-04-27
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static bool IsYbHccsChargeHaveBeenQuery(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (arrList[0].ToString() == "1")
                        {
                            sSql = String.Format("select HSBM from JC_YB_BL WHERE XMLY={0} AND YBLX={1} AND XMID=(SELECT TOP 1 GGID FROM yp_ypcjd WHERE CJID='{2}') ", arrList[0], arrList[1], arrList[2]);
                        }
                        else
                        {
                            sSql = String.Format("select HSBM from JC_YB_BL WHERE XMLY={0} AND YBLX={1} AND XMID={2}", arrList[0], arrList[1], arrList[2]);
                        }
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
            if (daTable.Rows.Count > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 申请病人查询
        /// </summary>
        /// <param name="applyTime">申请日期</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ApplyThePatientQuery(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT B.INPATIENT_NO AS 住院号,B.NAME 姓名,DBO.FUN_ZY_SEEKDEPTNAME(B.DEPT_ID) AS 所在科室,A.YSSS AS 手术名称, ";
                        sSql = sSql + " DBO.FUN_GETDATE(YSSSRQ) AS 手术日期 FROM SS_APPRECORD A INNER JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE DBO.FUN_GETDATE(YSSSRQ) = '{1}'", sSql, arrList[0]);
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
        /// <summary>
        /// 更新手术安排标志
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="dataBase">数据库连接</param>
        public static void OaacUpdateOperationMarks(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} UPDATE SS APPRECORD SET APBJ = 1 WHERE INPATIENT_ID = '{1}'", sSql, arrList[0]);
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
            dataBase.DoCommand(sSql);
        }
        /// <summary>
        /// 加载词典
        /// </summary>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable OaacLoadItemDiction(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT D_CODE AS ITEMCODE,ITEMNAME,STANDARD,UNIT,PRICE,PY_CODE,WB_CODE,D_CODE, EXECDEPTID, EXECDEPT,'' AS SELFRATE ,'' AS INSURETYPE, ITEMID,TCID,BIGITEMCODE, 1 AS ZFBL, '' AS S_SCCJ, 1 DWBL FROM  VI_JC_ITEMS ";
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
    }
}
