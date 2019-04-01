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
 * 名称：各数据库公共访问类
 * 描述：适用于各类库的公共访问
 * 编写时间：2013-10
 * 作者：Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class PublicDataBaseAccessClass
    {
        /// <summary>
        /// 绑定病区
        /// </summary>
        /// <param name="isJgbm">机构编码</param>
        /// <returns></returns>
        public static DataTable BindWard(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            //RelationalDatabase dataBase = null;
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 1)
                        {
                            sSql = String.Format("SELECT WARD_ID,WARD_NAME FROM JC_WARD WHERE JGBM={0} ORDER BY WARD_ID", arrList[1]);
                        }
                        else if (Convert.ToInt32(arrList[0]) == 2)
                        {
                            sSql = String.Format("{0} SELECT B.* FROM JC_WARDRDEPT A INNER JOIN JC_WARD B ON A.WARD_ID = B.WARD_ID WHERE A.DEPT_ID = {1} AND A.JGBM = {2} ", sSql, arrList[1], arrList[2]);
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
        /// 绑定病区科室
        /// </summary>
        /// <param name="isJgbm">机构编码</param>
        /// <returns></returns>
        public static DataTable BindWardDept(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            //RelationalDatabase dataBase = TrasenFrame.Forms.FrmMdiMain.Database.GetCopy();
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT 0 AS ROWNO, DEPT_ID,NAME,PY_CODE AS PY_CODE,TYPE_CODE,WB_CODE AS WB_CODE,' ' AS D_CODE,DEPTADDR FROM JC_DEPT_PROPERTY WHERE ZY_FLAG = 1 AND JGBM = {1} AND DELETED = 0 AND DEPT_ID IN (SELECT DEPT_ID FROM JC_DEPT_TYPE_RELATION WHERE TYPE_CODE = '004') ORDER BY SORT_ID ASC ", sSql, arrList[0]);
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
        /// 获取费用方法
        /// 1. 所有未结算费用
        /// 2. 指定时间未结算费用
        /// 3. 所有已结算费用
        /// 存储过程--SP_ZY_GET_FEECLASSLIST
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="isType">；类型</param>
        /// <param name="dischargeId">结算ID</param>
        /// <param name="beginDateTime">开始时间</param>
        /// <param name="endDateTime">结算时间</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyGetFeeClassList(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[1]) == 0)  //所有未结算费用
                        {
                            sSql = sSql + " SELECT A1.ACVALUE,CAST((CASE WHEN A1.BABY_BIT IS NULL THEN 0 ELSE A1.BABY_BIT END) AS SMALLINT) AS BABY_BIT,";
                            sSql = sSql + " A1.ITEM_CODE,RTRIM(A1.ITEM_NAME) AS ITEM_NAME,A2.DISCOUNT,A2.AGIO_NAME,";
                            sSql = sSql + " COALESCE(A1.ACVALUE,0)-COALESCE(A2.DISCOUNT,0) AS LEFTVALUE,A1.SORT_ID";
                            sSql = sSql + " FROM ( ";
                            sSql = sSql + " SELECT ITEM_CODE,ITEM_NAME,BABY_BIT,SUM(ACVALUE) AS ACVALUE,SORT_ID";
                            sSql = sSql + " FROM ( ";
                            sSql = sSql + " SELECT B3.SORT_ID,B3.ITEM_CODE,B3.ITEM_NAME,COALESCE(B1.BABY_BIT,0) AS BABY_BIT,SUM(ACVALUE) AS ACVALUE";
                            sSql = sSql + " FROM ( ";
                            sSql = sSql + "  SELECT INPATIENT_ID,STATITEM_CODE,ACVALUE,(CASE WHEN BABY_ID<=0 THEN 0 ELSE 1 END) AS BABY_BIT FROM ZY_FEE_SPECI";
                            sSql = String.Format("{0} WHERE DISCHARGE_BIT = 0 AND CHARGE_BIT = 1 AND DELETE_BIT = 0 AND INPATIENT_ID= '{1}' ) AS B1", sSql, arrList[0]);
                            sSql = sSql + " RIGHT JOIN ( ";
                            sSql = sSql + " SELECT AA.CODE AS ITEM_CODE,AA.ITEM_NAME,BB.CODE AS STATITEM_CODE,SORT_ID FROM  JC_ZYFP_XM AS AA ";
                            sSql = sSql + " LEFT JOIN JC_STAT_ITEM AS BB ON AA.CODE=BB.ZYFP_CODE ) AS B3";
                            sSql = sSql + " ON B1.STATITEM_CODE=B3.STATITEM_CODE GROUP BY B3.ITEM_CODE,B3.ITEM_NAME,B1.BABY_BIT,B3.SORT_ID ) AS A";
                            sSql = sSql + " GROUP BY A.ITEM_CODE,A.ITEM_NAME,A.BABY_BIT,A.SORT_ID ) AS A1";
                            sSql = sSql + " LEFT JOIN ( ";
                            sSql = sSql + " SELECT AGIO_NAME,ITEM_CODE,ITEM_VALUE AS DISCOUNT,BABY_BIT FROM ZY_AGIO_LIST";
                            sSql = String.Format("{0} WHERE DELETE_BIT=0 AND DISCHARGE_BIT<>1 AND  INPATIENT_ID= '{1}' ) AS A2", sSql, arrList[0]);
                            sSql = sSql + " ON A1.ITEM_CODE=A2.ITEM_CODE AND A1.BABY_BIT = A2.BABY_BIT ORDER BY A1.SORT_ID";
                        }
                        else if (Convert.ToInt32(arrList[1]) == 1)  //指定时间未结算费用
                        {
                            sSql = sSql + " SELECT A1.ACVALUE,CAST((CASE WHEN A1.BABY_BIT IS NULL THEN 0 ELSE A1.BABY_BIT END) AS SMALLINT) AS BABY_BIT,";
                            sSql = sSql + " A1.ITEM_CODE,A1.ITEM_NAME,A2.DISCOUNT,A2.AGIO_NAME,";
                            sSql = sSql + " COALESCE(A1.ACVALUE,0)-COALESCE(A2.DISCOUNT,0) AS LEFTVALUE,A1.SORT_ID";
                            sSql = sSql + " FROM ( ";
                            sSql = sSql + "  SELECT ITEM_CODE,ITEM_NAME,BABY_BIT,SUM(ACVALUE) AS ACVALUE,SORT_ID";
                            sSql = sSql + " FROM ( ";
                            sSql = sSql + " SELECT B3.SORT_ID,B3.ITEM_CODE,B3.ITEM_NAME,COALESCE(B1.BABY_BIT,0) AS BABY_BIT,SUM(ACVALUE) AS ACVALUE";
                            sSql = sSql + " FROM ( ";
                            sSql = sSql + " SELECT INPATIENT_ID,STATITEM_CODE,ACVALUE,(CASE WHEN BABY_ID<=0 THEN 0 ELSE 1 END) AS BABY_BIT FROM ZY_FEE_SPECI";
                            sSql = String.Format("{0} WHERE DISCHARGE_BIT=0 AND CHARGE_BIT=1 AND DELETE_BIT=0 AND INPATIENT_ID= '{1}'", sSql, arrList[0]);
                            sSql = String.Format("{0} AND CHARAGE_DATE <= '{1}' ) AS B1 ", sSql, arrList[4]);
                            sSql = sSql + " RIGHT JOIN ( ";
                            sSql = sSql + " SELECT AA.CODE AS ITEM_CODE,AA.ITEM_NAME,BB.CODE AS STATITEM_CODE,SORT_ID FROM  JC_ZYFP_XM AS AA";
                            sSql = sSql + " LEFT JOIN JC_STAT_ITEM AS BB ON AA.CODE=BB.ZYFP_CODE ) AS B3";
                            sSql = sSql + " ON B1.STATITEM_CODE=B3.STATITEM_CODE  GROUP BY B3.ITEM_CODE,B3.ITEM_NAME,B1.BABY_BIT,B3.SORT_ID ) AS A";
                            sSql = sSql + " GROUP BY A.ITEM_CODE,A.ITEM_NAME,A.BABY_BIT,A.SORT_ID ) AS A1";
                            sSql = sSql + " LEFT JOIN ( ";
                            sSql = sSql + "  SELECT AGIO_NAME,ITEM_CODE,ITEM_VALUE AS DISCOUNT,BABY_BIT FROM ZY_AGIO_LIST";
                            sSql = String.Format("{0} WHERE DELETE_BIT=0 AND DISCHARGE_BIT<>1 AND  INPATIENT_ID= '{1}' ) AS A2 ", sSql, arrList[0]);
                            sSql = sSql + " ON A1.ITEM_CODE=A2.ITEM_CODE AND A1.BABY_BIT=A2.BABY_BIT ORDER BY A1.SORT_ID ";
                        }
                        else //所有已结算费用
                        {
                            sSql = sSql + " SELECT A1.ACVALUE,A1.ITEM_CODE,A1.ITEM_NAME,A2.DISCOUNT,A2.AGIO_NAME,";
                            sSql = sSql + " COALESCE(A1.ACVALUE,0)-COALESCE(A2.DISCOUNT,0) AS LEFTVALUE,A1.SORT_ID,";
                            sSql = sSql + " CAST((CASE WHEN A1.BABY_BIT IS NULL THEN 0 ELSE A1.BABY_BIT END) AS SMALLINT) AS BABY_BIT";
                            sSql = sSql + " FROM ( ";
                            sSql = sSql + " SELECT ITEM_CODE,ITEM_NAME,SUM(ACVALUE) AS ACVALUE,SORT_ID,BABY_BIT";
                            sSql = sSql + " FROM ( ";
                            sSql = sSql + " SELECT B3.SORT_ID,B3.ITEM_CODE,B3.ITEM_NAME,SUM(ACVALUE) AS ACVALUE,BABY_BIT";
                            sSql = sSql + " FROM ( ";
                            sSql = sSql + " SELECT INPATIENT_ID,ITEMCODE,ITEMVALUES AS ACVALUE,BABY_BIT FROM ZY_DISCHARGELIST";
                            sSql = String.Format("{0} WHERE INPATIENT_ID = '{1}' AND DISCHARGE_ID = '{2}' ) AS B1", sSql, arrList[0], arrList[2]);
                            sSql = sSql + " RIGHT_JOIN ( ";
                            sSql = sSql + " SELECT CODE AS ITEM_CODE,ITEM_NAME,SORT_ID FROM JC_ZYFP_XM";
                            sSql = sSql + " ) AS B3 ";
                            sSql = sSql + " ON B1.ITEMCODE=B3.ITEM_CODE GROUP BY B3.ITEM_CODE,B3.ITEM_NAME,B3.SORT_ID,BABY_BIT ) AS A";
                            sSql = sSql + " GROUP BY A.ITEM_CODE,A.ITEM_NAME,A.SORT_ID,BABY_BIT ) AS A1 ";
                            sSql = sSql + " LEFT JOIN ( ";
                            sSql = sSql + " SELECT AGIO_NAME,ITEM_CODE,ITEM_VALUE AS DISCOUNT FROM ZY_AGIO_LIST";
                            sSql = String.Format("{0} WHERE DELETE_BIT=0 AND DISCHARGE_BIT=1 AND  INPATIENT_ID= '{1}' AND DISCHARGE_ID= '{2}' ) AS A2", sSql, arrList[0], arrList[2]);
                            sSql = sSql + " ON A1.ITEM_CODE=A2.ITEM_CODE ORDER BY A1.SORT_ID ASC";
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
        /// 绑定医保类型
        /// </summary>
        /// <param name="frmType">界面枚举</param>
        /// <param name="arrList">数据字段容器</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable BindMedicalType(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 1)
                        {
                            sSql = sSql + " SELECT NAME,ID,INSURECENTRAL,DEFAULTS FROM JC_YBLX WHERE DELETE_BIT = 0 ";
                            sSql = sSql + " UNION ALL ";
                            sSql = sSql + " SELECT '非医保' NAME,0 ID,'' INSURECENTRAL,-1 DEFAULTS ";
                            sSql = sSql + " UNION ALL ";
                            sSql = sSql + " SELECT '全部' NAME,-1 ID, '' INSURECENTRAL,-2 DEFAULTS ";
                            sSql = sSql + " ORDER BY DEFAULTS ASC ";
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
        /// 病人基本信息
        /// </summary>
        /// <param name="frmType">界面枚举</param>
        /// <param name="arrList">数据字段容器</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable PatientBasicInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 1)
                        {
                            //arrList[1]  == 住院ID
                            //arrList[2]  == 婴儿ID
                            sSql = sSql + " SELECT A.OUT_DATE,A.SOCIAL_NO,A.DIAGNOSE_DATE,C.NAME,A.CLINIC_DIAGNOSIS,A.OUT_DIAGNOSIS,A.CYZD,A.UNIT_NAME, ";
                            sSql = sSql + " A.HOME_TEL,A.HOME_STREET,A.RELATION_NAME,A.RELATION_TEL,A.RELATION,A.RELATION_STREET,A.WARRANTOR DBR,A.WARRANTAMOUNT AS DBJE ";
                            sSql = sSql + " FROM VI_ZY_VINPATIENT_ALL A LEFT JOIN JC_EMPLOYEE_PROPERTY C ON A.CLINIC_DOC = C.EMPLOYEE_ID ";
                            sSql = String.Format("{0} WHERE A.BABY_ID = {1} AND A.INPATIENT_ID = '{2}'", sSql, arrList[2], arrList[1]);
                        }
                        else if (Convert.ToInt32(arrList[0]) == 2)
                        {
                            sSql = String.Format("{0} SELECT IS_YBJS FROM ZY_INPATIENT WHERE INPATIENT_ID = '{1}'", sSql, arrList[1]);
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
        /// 获取医保类型名称
        /// </summary>
        /// <param name="medicalType">医保类型</param>
        /// <param name="dataBase">数据库名称</param>
        /// <returns></returns>
        public static string GetMedicalTypeName(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT NAME FROM JC_YBLX WHERE ID = {1} ", sSql, arrList[0]);
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

            DataTable tbName = dataBase.GetDataTable(sSql);
            string medicalName = "";
            if (tbName.Rows.Count > 0)
            {
                medicalName = Convertor.IsNull(tbName.Rows[0]["NAME"].ToString(), "");
            }
            //string medicalName = Convertor.IsNull(dataBase.GetDataResult(sSql).ToString(), "");
            return medicalName;
        }

        public static DataTable GetPatientYbzfje(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 1)
                        {
                            //arrList[1]  == 住院ID
                            //arrList[2]  == 婴儿ID
                            sSql = sSql + "SELECT isnull(SUM(TCZF+ZHZF+QTZF),0) as ybzf FROM ZY_YB_JSB a ";
                            sSql = String.Format("{0} WHERE A.CZ_FLAG=0 AND A.INPATIENT_ID = '{1}' AND DELETE_BIT=0", sSql, arrList[1]);
                        }
                        else if (Convert.ToInt32(arrList[0]) == 2)
                        {
                            sSql = String.Format("{0} SELECT isnull(SUM(TCZF+ZHZF+QTZF),0) as ybzf FROM ZY_YB_JSB_RJJL WHERE INPATIENT_ID = '{1}' AND DELETE_BIT=0", sSql, arrList[1]);
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
        /// 绑定医生
        /// </summary>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable BindDoctor(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT A.EMPLOYEE_ID AS ITEMCODE,NAME AS ITEMNAME,PY_CODE AS PY_CODE,WB_CODE AS WB_CODE,B.CODE AS D_CODE ";
                        sSql = sSql + " FROM VI_ZY_VDOCTOR AS A LEFT JOIN (SELECT EMPLOYEE_ID,CODE FROM PUB_USER) B ";
                        sSql = sSql + " ON A.EMPLOYEE_ID = B.EMPLOYEE_ID ";
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
        /// 绑定收费员
        /// </summary>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataTable BindEmployee(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        //sSql = sSql + " SELECT EMPLOYEE_ID,NAME FROM JC_EMPLOYEE_PROPERTY WHERE RYLX = 3 ";

                        //sSql = sSql + " SELECT A.EMPLOYEE_ID,A.NAME FROM JC_EMPLOYEE_PROPERTY A INNER JOIN PUB_USER B ON A.EMPLOYEE_ID = B.EMPLOYEE_ID WHERE A.RYLX = 3 ";

                        sSql = sSql + " SELECT 0 AS ROWNO,A.EMPLOYEE_ID,RTRIM(A.NAME) AS NAME,A.PY_CODE,A.WB_CODE,B.CODE AS D_CODE FROM JC_EMPLOYEE_PROPERTY A INNER JOIN PUB_USER B ON A.EMPLOYEE_ID = B.EMPLOYEE_ID WHERE A.DELETE_BIT = 0 AND A.RYLX = 3 ";
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
        /// 绑定COMBOX
        /// </summary>
        /// <param name="frmType">界面枚举</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable BindCombox(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 1)
                        {
                            sSql = sSql + @" SELECT '2' CODE,'全部' NAME UNION SELECT '0' CODE,'未确认' NAME UNION SELECT '1' CODE,'已确认' NAME ";
                        }
                        else if (Convert.ToInt32(arrList[0]) == 2)
                        {
                            sSql = sSql + " SELECT -1 CODE,'全部' NAME UNION ALL SELECT 0 CODE,'未使用' NAME UNION ALL SELECT 1 CODE,'使用中' NAME UNION ALL SELECT 2 CODE,'使用完' NAME UNION ALL SELECT 3 CODE,'已核销' NAME ";
                        }
                        else if (Convert.ToInt32(arrList[0]) == 3)
                        {
                            sSql = sSql + @" SELECT '1' CODE,'男' NAME 
                                    UNION SELECT '2' CODE,'女' NAME ";
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
        /// 获取住院口径项目
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataTable BoreProjectLength(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT * FROM JC_ZYKJ_XM ORDER BY SORT_ID ";
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
        /// 绑定发票字典
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataTable BindBillDict(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT NAME,CODE FROM JC_BILLDICT ";
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
        ///  绑定疾病
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataTable BindDisease(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT 0 AS ROWNO,CODING AS ITEMCODE,NAME AS ITEMNAME,PY_CODE,WB_CODE,'' AS D_CODE,YBJKLX,LEN(PY_CODE) PY_LEN,LEN(WB_CODE) WB_LEN FROM JC_DISEASE WHERE BSCBZ = 0 ";
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
        /// 产生GUID
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataTable ProduceGuid(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()) AS 'GUID' ";
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
        /// 绑定付款方式
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataTable BindPaymentMethods(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT NAME,CODE FROM JC_FKFS ";
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
        /// 验证病人状态
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static int VerifyPatientStatus(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT FLAG FROM ZY_INPATIENT WHERE INPATIENT_ID = '{1}'", sSql, arrList[0]);
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
            return Convert.ToInt32(Convertor.IsNull(dataBase.GetDataResult(sSql), "10"));
        }
        /// <summary>
        /// 绑定银行
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataTable BindBank(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT NAME,ID FROM JC_BANK "; 
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
        /// 写入日志
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        public static void AllInpatientLogAdd(ArrayList arrList,RelationalDatabase dataBase)
        {
            string sSql = "";
            switch(dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " INSERT INTO ZY_ALLINPATIENT_LOG(INPATIENT_ID, OLD_STR, NEW_STR, TYPE, BOOK_DATE, BOOK_USER, IP, PCNAME) ";
                        sSql = String.Format("{0} VALUES ('{1}','{2}','{3}',{4},GETDATE(),{5},'{6}','{7}') ", sSql, arrList[0], arrList[1], arrList[2], Convert.ToInt32(arrList[3]), Convert.ToInt32(arrList[4]), arrList[5], arrList[6]);
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
        /// 绑定医保类型
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataTable BindMedicalTypeAll(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT ID,NAME FROM JC_YBLX ORDER BY NAME ";
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
