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
 * 名称：冲账管理数据库访问类
 * 描述：适用于冲账管理中的数据库访问
 * 编写时间：2013-10
 * 作者：Kevin
 * **/


namespace Ts_Zygl_Classes
{
    public class ComManageDataBaseAccessClass
    {
        /// <summary>
        /// 住院病人冲账管理--住院冲账审核
        /// </summary>
        /// <param name="feeId">费用ID</param>
        /// <param name="employeeId">人员ID</param>
        /// <param name="dlgInputBox">标志</param>
        /// <param name="isUseTransaction">是否使用事务</param>
        public static void ZyHedgeAudit(ArrayList arrList, RelationalDatabase dataBase, bool isUseTransaction)  //Modify By Tany 2015-05-12
        {
            string[] sSql = new string[2];
            //RelationalDatabase dataBase = null;
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql[0] = String.Format("DELETE FROM ZY_CZSH WHERE FEEID = '{0}'", arrList[0]);
                        sSql[1] = String.Format("INSERT INTO ZY_CZSH(FEEID,SHBZ,SHR,SHRQ,BZ) VALUES ('{0}',1,{1},GETDATE(),'{2}')", arrList[0], arrList[1], arrList[2]);
                    }
                    break;
                case ConnectType.ORACLE:
                    {
                        //sSql[0] = String.Format("DELETE FROM ZY_CZSH WHERE FEEID = '{0}';", feeId);
                        //sSql[1] = String.Format("INSERT INTO ZY_CZSH(FEEID,SHBZ,SHR,SHRQ,BZ) VALUES ('{0}',1,{1},SYSDATE(),'{2}');", feeId, employeeId, dlgInputBox);
                    }
                    break;
                case ConnectType.IBMDB2:
                    {
                        //sSql[0] = String.Format("DELETE FROM ZY_CZSH WHERE FEEID = '{0}'", feeId);
                        //sSql[1] = String.Format("INSERT INTO ZY_CZSH(FEEID,SHBZ,SHR,SHRQ,BZ) VALUES ('{0}',1,{1},CURRENT TIMESTAMP,'{2}')", feeId, employeeId, dlgInputBox);
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

            //Modify By Tany 2015-05-12
            if (isUseTransaction)
            {
                dataBase.DoCommand(null, null, null, sSql);
            }
            else
            {
                for (int i = 0; i < sSql.Length; i++)
                {
                    dataBase.DoCommand(sSql[i]);
                }
            }
        }
        /// <summary>
        /// 住院病人冲账管理--住院冲账确认
        /// </summary>
        /// <param name="feeId">费用ID</param>
        /// <param name="employeeId">人员ID</param>
        /// <param name="isSh">是否审核</param>
        public static void ZyConfirmAudit(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            string sWhere;
            //RelationalDatabase dataBase = null;
            if ((bool)arrList[2] == true)
                sWhere = " INNER JOIN ZY_CZSH B ON A.ID = B.FEEID AND B.SHBZ = 1";
            else
                sWhere = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("UPDATE A SET A.CHARGE_BIT=1,A.CHARGE_DATE = GETDATE(),A.CHARGE_USER = {0} FROM ZY_FEE_SPECI A {1} WHERE A.ID = '{2}' AND A.CHARGE_BIT = 0 AND A.DELETE_BIT = 0", arrList[1], sWhere, arrList[0]);
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
        /// 住院病人冲账管理--住院冲账拒绝申请
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <param name="isUseTransaction">是否使用事务</param>
        public static void ZyRefuseAudit(ArrayList arrList, RelationalDatabase dataBase, bool isUseTransaction)  //Modify By Tany 2015-05-12
        {
            string[] sSql = new string[3];
            //RelationalDatabase dataBase = null;
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql[0] = String.Format("DELETE FROM ZY_CZSH WHERE FEEID = '{0}'", arrList[0]);
                        sSql[1] = String.Format("INSERT INTO ZY_CZSH(FEEID,SHBZ,SHR,SHRQ,BZ) VALUES ('{0}',0,{1},GETDATE(),'{2}')", arrList[0], arrList[1], arrList[2]);
                        sSql[2] = String.Format("UPDATE ZY_FEE_SPECI SET DELETE_BIT = 1,BZ ='申请被拒绝：{0}' WHERE ID = '{1}' AND CHARGE_BIT = 0 AND DELETE_BIT =0", arrList[2], arrList[0]);
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

            //Modify By Tany 2015-05-12
            if (isUseTransaction)
            {
                dataBase.DoCommand(null, null, null, sSql);
            }
            else
            {
                for (int i = 0; i < sSql.Length; i++)
                {
                    dataBase.DoCommand(sSql[i]);
                }
            }
        }
        /// <summary>
        /// 住院病人冲账管理--住院病人冲账查询
        /// 存储过程--SP_ZY_CZGL_SELECT
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="wardId">病区ID</param>
        /// <param name="czrqBit"></param>
        /// <param name="czrqStart"></param>
        /// <param name="czrqEnd"></param>
        /// <param name="jzrqBit"></param>
        /// <param name="jzrqStart"></param>
        /// <param name="jzrqEnd"></param>
        /// <param name="isType"></param>
        /// <param name="isCx"></param>
        /// <returns></returns>
        public static DataTable ZyInquiryAuditPatient(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sWhere = "";
            string sSql = "";
            //RelationalDatabase dataBase = null;
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {

                        if (new Guid(arrList[0].ToString()) != Guid.Empty)
                            sWhere = sWhere + String.Format("{0} AND A.INPATIENT_ID = '{1}'", "", arrList[0]);
                        else if (arrList[1].ToString() != "-1")
                            sWhere = String.Format("{0} AND A.DEPT_BR IN (SELECT DEPT_ID FROM JC_WARDRDEPT WHERE WARD_ID = '{1}')", sWhere, arrList[1]);
                        if (Convert.ToInt32(arrList[2]) == 1)
                            sWhere = String.Format("{0} AND A.BOOK_DATE BETWEEN '{1} 00:00:00' AND '{2} 23:59:59'", sWhere, Convert.ToDateTime(arrList[3]).ToShortDateString(), Convert.ToDateTime(arrList[4]).ToShortDateString());
                        if (Convert.ToInt32(arrList[5]) == 1)
                            sWhere = String.Format("{0} AND A.CHARGE_DATE BETWEEN '{1} 00:00:00' AND '{2} 23:59:59'", sWhere, Convert.ToDateTime(arrList[6]).ToShortDateString(), Convert.ToDateTime(arrList[7]).ToShortDateString());
                        if (Convert.ToInt32(arrList[8]) == 0)
                            sWhere = sWhere + " AND A.CHARGE_BIT = 0";
                        else if (Convert.ToInt32(arrList[8]) == 1)
                            sWhere = sWhere + " AND A.CHARGE_BIT = 1";
                        if (Convert.ToInt32(arrList[8]) == 0 && Convert.ToInt32(arrList[9]) == 0 && arrList[10].ToString() == "0")
                            sWhere = sWhere + " AND A.XMLY <> 1";

                        sSql = sSql + " SELECT 0 序号,B.NAME 姓名,B.SEX_NAME 性别,B.INPATIENT_NO 住院号,B.BED_NO 床号,";
                        sSql = sSql + " CASE DISCHARGETYPE WHEN 1 THEN YBLX_NAME ELSE JSFS_NAME END 费别,";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(A.DEPT_BR) 病人科室,A.BOOK_DATE 操作日期,DBO.FUN_GETEMPNAME(A.BOOK_USER) 操作人,";
                        sSql = sSql + " A.ITEM_NAME+ISNULL(A.BZ,'') 费用内容,A.ACVALUE 金额,CAST(0 AS SMALLINT) 选择,CASE ISNULL(C.SHBZ,0) WHEN 1 THEN '√' ELSE 'X' END 审核状态,";
                        sSql = sSql + " ISNULL(C.SHBZ,0) 审核标志,DBO.FUN_GETEMPNAME(C.SHR) 审核人,C.SHRQ 审核日期,C.BZ 审核说明,A.ID FEEID,";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(A.CHARGE_USER) 确认人,A.CHARGE_DATE 确认日期 ";
                        sSql = sSql + " FROM ZY_FEE_SPECI A INNER JOIN VI_ZY_VINPATIENT_ALL B ON A.INPATIENT_ID=B.INPATIENT_ID AND A.BABY_ID=B.BABY_ID ";
                        if (Convert.ToInt32(arrList[8]) == 0 && Convert.ToInt32(arrList[9]) == 0 && arrList[11].ToString() == "0")
                        {
                            sSql = sSql + " INNER JOIN ZY_ORDERRECORD D ON A.ORDER_ID=D.ORDER_ID AND D.NTYPE<>5 ";
                        }
                        sSql = sSql + " INNER JOIN ZY_CZFEE E ON A.ID=E.FEEID ";//Modify By Tany 2015-05-27 只有需要控制的费用才显示
                        sSql = sSql + " LEFT JOIN ZY_CZSH C ON A.ID=C.FEEID ";
                        sSql = sSql + " WHERE A.DELETE_BIT=0 AND A.CZ_FLAG=2 ";
                        sWhere = sWhere + " ORDER BY A.DEPT_BR,B.INPATIENT_NO,A.BOOK_DATE ";
                        sSql = sSql + sWhere;
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
