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
 * 名称：票据管理数据库访问类
 * 描述：适用于票据管理中的数据库访问
 * 编写时间：2013-10
 * 作者：Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class BillManageDataBaseAccessClass
    {
        /// <summary>
        /// 显示收费员各种票据类型
        /// </summary>
        /// <param name="arrList">5095 参数， 收费员ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static void GetBillSpan(ref DataSet daSet, ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        //多种正式发票
                        if (Convert.ToInt32(arrList[0]) == 0) //不支持
                        {
                            sSql = sSql + " SELECT ID,NTYPE,CASE NTYPE WHEN 1 THEN '预交收据' WHEN 2 THEN '结算发票' WHEN 3 THEN '退款单据' WHEN 4 THEN '押金单据' ELSE '未知类型' END AS BILLTYPE,BEGINNO,ENDNO,DBO.FUN_GETDATE(FETCHDATE) AS FETCHDATE, ";
                            sSql = String.Format("{0} EMPLOYEE_ID,OPERATOR,STATUS,CASE STATUS WHEN 1 THEN '使用中' WHEN 2 THEN '使用完' WHEN 3 THEN '已核销' ELSE '未使用' END AS BILLNSTATUS,CANCEL_BIT,(CASE WHEN EMPLOYEE_ID <> -1 THEN DBO.FUN_ZY_SEEKEMPLOYEENAME(EMPLOYEE_ID) WHEN EMPLOYEE_ID = -1 THEN '全班' ELSE '未知' END) AS EMPLOYEE FROM ZY_FETCHBILL WHERE CANCEL_BIT <> 1 AND EMPLOYEE_ID = {1} ORDER BY ID DESC ", sSql, Convert.ToInt32(arrList[1]));
                        }
                        else  //支持
                        {
                            sSql = sSql + " SELECT ID,NTYPE,CASE NTYPE WHEN 1 THEN '预交收据' WHEN 2 THEN '结算发票' WHEN 3 THEN '退款单据' WHEN 4 THEN '押金单据' WHEN 5 THEN '正式发票(税务)' WHEN 6 THEN '正式发票(自制)' ELSE '未知类型' END AS BILLTYPE, ";
                            sSql = sSql + " BEGINNO,ENDNO,DBO.FUN_GETDATE(FETCHDATE) AS FETCHDATE,EMPLOYEE_ID,OPERATOR, ";
                            sSql = String.Format("{0} STATUS,CASE STATUS WHEN 1 THEN '使用中' WHEN 2 THEN '使用完' WHEN 3 THEN '已核销' ELSE '未使用' END AS BILLNSTATUS,CANCEL_BIT,(CASE WHEN EMPLOYEE_ID <> -1 THEN DBO.FUN_ZY_SEEKEMPLOYEENAME(EMPLOYEE_ID) WHEN EMPLOYEE_ID = -1 THEN '全班' ELSE '未知' END) AS EMPLOYEE FROM ZY_FETCHBILL WHERE CANCEL_BIT <> 1 AND EMPLOYEE_ID = {1} ORDER BY ID DESC ", sSql, Convert.ToInt32(arrList[1]));
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

            dataBase.AdapterFillDataSet(sSql, daSet, "billSpan", 30);
        }
        /// <summary>
        /// 发票领用控制
        /// </summary>
        /// <param name="arrList">收费员ID，发票类型</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static int TheInvoiceControl(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            int contrilCount = 0;

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT COUNT(*) FROM ZY_FETCHBILL WHERE STATUS = 1 AND EMPLOYEE_ID = '{1}' ", sSql, arrList[0]);
                        sSql = String.Format("{0} AND NTYPE = {1} ", sSql, Convert.ToInt32(arrList[1]));
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

            contrilCount = Convert.ToInt32(Convertor.IsNull(dataBase.GetDataResult(sSql), "0"));
            return contrilCount;
        }
        /// <summary>
        /// 票据领用
        /// </summary>
        /// <param name="arrList">票据类型，收费员ID，唯一ID</param>
        /// <param name="dataBase">数据库连接</param>
        public static void TheBillInvoice(ArrayList arrList, RelationalDatabase dataBase)
        {
            string[] sSql = new string[2];
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        //首先取消本人本类型票据的正在使用标记
                        sSql[0] = sSql[0] + " UPDATE ZY_FETCHBILL SET STATUS = 0 WHERE CANCEL_BIT <> 1 AND STATUS NOT IN (2,3) ";
                        sSql[0] = String.Format("{0} AND NTYPE = {1} AND EMPLOYEE_ID = {2} ", sSql[0], arrList[0], Convert.ToInt32(arrList[1]));
                        //设置用户选择的记录为当前使用标记
                        sSql[1] = sSql[1] + " UPDATE ZY_FETCHBILL SET STATUS = 1 WHERE CANCEL_BIT <> 1 AND STATUS NOT IN (2,3) ";
                        sSql[1] = String.Format("{0} AND ID = '{1}' AND NTYPE = {2} AND EMPLOYEE_ID = {3} ", sSql[1], arrList[2], arrList[0], Convert.ToInt32(arrList[1]));


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
            dataBase.DoCommand(null, null, null, sSql);
        }
        /// <summary>
        /// 加载领用信息
        /// </summary>
        /// <param name="arrList">收费员ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable LoadReceiveInfo(int i, ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            DataTable daTable = null;

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (i == 1)
                        {
                            sSql = String.Format("{0} SELECT B.NAME,BEGINNO,ENDNO,(CASE STATUS WHEN 1 THEN '使用中' ELSE '未使用' END) AS STATUS,ID FROM ZY_FETCHBILL A INNER JOIN JC_BILLDICT B ON A.NTYPE = B.CODE WHERE EMPLOYEE_ID = {1} ", sSql, Convert.ToInt32(arrList[0]));
                        }
                        if (i == 2)
                        {
                            sSql = String.Format("{0} SELECT B.NAME,BEGINNO,ENDNO,(CASE STATUS WHEN 1 THEN '使用中' ELSE '未使用' END) AS STATUS,ID,A.FETCHDATE,(CASE WHEN STATUS = 3 THEN '已核销' ELSE '未核销' END ) AS [CHECK] FROM ZY_FETCHBILL A INNER JOIN JC_BILLDICT B ON A.NTYPE = B.CODE WHERE EMPLOYEE_ID = {1} ", sSql, Convert.ToInt32(arrList[0]));
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
        /// 发票明细
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable GetBillList(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (new SystemCfg(5144).Config == "0")
                        {
                            sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名,A.NVALUES AS 票据金额, ";
                            sSql = sSql + " A.USED_DATE AS 使用时间,DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员, ";
                            sSql = String.Format("{0} (CASE NSTATUS WHEN 1 THEN CASE WHEN CANCEL_USERID IS NOT NULL THEN '跳票' ELSE '有效' END WHEN 2 THEN '作废' ELSE '未知' END ) AS 状态 FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID WHERE NBATCH = '{1}' AND NSTATUS <> 0 ORDER BY A.BILLNO ASC ", sSql, arrList[0]);
                        }
                        else
                        {
                            sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名,CASE WHEN A.NTYPE =2 THEN C.SELF_FEE ELSE A.NVALUES END AS 票据金额, ";
                            sSql = sSql + " A.USED_DATE AS 使用时间,DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员, ";
                            sSql = String.Format(@"{0} (CASE A.NSTATUS WHEN 1 THEN CASE WHEN A.CANCEL_USERID IS NOT NULL THEN '跳票' ELSE '有效' END WHEN 2 THEN '作废' ELSE '未知' END ) AS 状态
               FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID 
               LEFT JOIN ZY_DISCHARGE C ON A.SOURCE_ID=C.ID WHERE NBATCH = '{1}' AND A.NSTATUS <> 0 ORDER BY A.BILLNO ASC ", sSql, arrList[0]);
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
        /// 退费票
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable GetRefundTicket(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (new SystemCfg(5144).Config == "0")
                        {
                            sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名,A.NVALUES AS 票据金额 ";
                            sSql = sSql + " A.USED_DATE AS 使用时间,DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员 ";
                            sSql = sSql + " FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                            sSql = String.Format("{0} WHERE NBATCH = '{1}' AND A.NVALUES < 0 AND NSTATUS = 1 ORDER BY A.BILLNO ASC ", sSql, arrList[0]);
                        }
                        else
                        {
                            sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名,CASE WHEN A.NTYPE =2 THEN C.SELF_FEE ELSE A.NVALUES END AS 票据金额,  ";
                            sSql = sSql + " A.USED_DATE AS 使用时间,DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员  ";
                            sSql = sSql + @" FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID 
                                    LEFT JOIN ZY_DISCHARGE C ON A.SOURCE_ID=C.ID ";
                            sSql = String.Format("{0} WHERE A.NBATCH = '{1}' AND A.NVALUES < 0 AND A.NSTATUS = 1 ORDER BY A.BILLNO ASC ", sSql, arrList[0]);
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
        /// 作废票
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable GetAsInvalid(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (new SystemCfg(5144).Config == "0")
                        {
                            sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名 ";
                            sSql = sSql + " A.NVALUES AS 票据金额,A.USED_DATE AS 使用时间, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员 ";
                            sSql = sSql + " FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                            sSql = String.Format("{0} WHERE NBATCH = '{1}' AND (NSTATUS = 2 OR (NSTATUS = 1 AND CANCEL_USERID IS NOT NULL)) ORDER BY A.BILLNO ASC ", sSql, arrList[0]);
                        }
                        else
                        {
                            sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名 ";
                            sSql = sSql + " CASE WHEN A.NTYPE =2 THEN C.SELF_FEE ELSE A.NVALUES END AS 票据金额,A.USED_DATE AS 使用时间, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员 ";
                            sSql = sSql + @" FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID 
                                  LEFT JOIN ZY_DISCHARGE C ON A.SOURCE_ID=C.ID ";
                            sSql = String.Format("{0} WHERE A.NBATCH = '{1}' AND (A.NSTATUS = 2 OR (A.NSTATUS = 1 AND CANCEL_USERID IS NOT NULL)) ORDER BY A.BILLNO ASC ", sSql, arrList[0]);
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
        /// 自定义--发票明细
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable GetCustomBillList(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    if (new SystemCfg(5144).Config == "0")
                    {
                        sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名, ";
                        sSql = sSql + " A.NVALUES AS 票据金额, A.USED_DATE AS 使用时间, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员, ";
                        sSql = sSql + " (CASE A.NSTATUS WHEN 1 THEN CASE WHEN A.CANCEL_USERID IS NOT NULL THEN '跳票' ELSE '有效' END WHEN 2 THEN '作废' ELSE '未知' END) AS 状态 ";
                        sSql = sSql + " FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE A.BILLNO >= {1} AND A.BILLNO <= {2} AND A.NSTATUS <> 0 AND A.NTYPE = {3} ORDER BY A.BILLNO ASC ", sSql, Convert.ToInt64(arrList[0]), Convert.ToInt64(arrList[1]), Convert.ToInt32(arrList[2]));
                    }
                    else
                    {
                        sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名, ";
                        sSql = sSql + " CASE WHEN A.NTYPE =2 THEN C.SELF_FEE ELSE A.NVALUES END AS 票据金额, A.USED_DATE AS 使用时间, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员, ";
                        sSql = sSql + " (CASE A.NSTATUS WHEN 1 THEN CASE WHEN A.CANCEL_USERID IS NOT NULL THEN '跳票' ELSE '有效' END WHEN 2 THEN '作废' ELSE '未知' END) AS 状态 ";
                        sSql = sSql + @" FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID 
                              LEFT JOIN ZY_DISCHARGE C ON A.SOURCE_ID=C.ID ";
                        sSql = String.Format("{0} WHERE A.BILLNO >= {1} AND A.BILLNO <= {2} AND A.NSTATUS <> 0 AND A.NTYPE = {3} ORDER BY A.BILLNO ASC ", sSql, Convert.ToInt64(arrList[0]), Convert.ToInt64(arrList[1]), Convert.ToInt32(arrList[2]));

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
        /// 自定义--退发票
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable GetCustomRefundTicket(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (new SystemCfg(5144).Config == "0")
                        {
                            sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名, ";
                            sSql = sSql + " A.NVALUES AS 票据金额,A.USED_DATE AS 使用时间, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员 ";
                            sSql = sSql + " FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                            sSql = String.Format("{0} WHERE BILLNO >= {1} AND BILLNO <= {2} AND A.NVALUES < 0 AND NSTATUS = 1 AND NTYPE = {3} ORDER BY A.BILLNO ASC ", sSql, Convert.ToInt64(arrList[0]), Convert.ToInt64(arrList[1]), Convert.ToInt32(arrList[2]));

                        }
                        else
                        {
                            sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名, ";
                            sSql = sSql + " CASE WHEN A.NTYPE =2 THEN C.SELF_FEE ELSE A.NVALUES END AS 票据金额,A.USED_DATE AS 使用时间, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员 ";
                            sSql = sSql + @" FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID
                                         LEFT JOIN ZY_DISCHARGE C ON A.SOURCE_ID=C.ID ";
                            sSql = String.Format("{0} WHERE A.BILLNO >= {1} AND A.BILLNO <= {2} AND A.NVALUES < 0 AND A.NSTATUS = 1 AND A.NTYPE = {3} ORDER BY A.BILLNO ASC ", sSql, Convert.ToInt64(arrList[0]), Convert.ToInt64(arrList[1]), Convert.ToInt32(arrList[2]));

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
        /// 自定义--作废票
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable GetCustomAsInvalid(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    if (new SystemCfg(5144).Config == "0")
                    {
                        sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名,A.NVALUES AS 票据金额, ";
                        sSql = sSql + " A.USED_DATE AS 使用时间,DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员 ";
                        sSql = sSql + " FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A. INPATIENT_ID = B.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE BILLNO >= {1} AND BILLNO <= {2} AND (NSTATUS = 2 OR (NSTATUS = 1 AND CANCEL_USERID IS NOT NULL)) AND NTYPE = {3} ORDER BY A.BILLNO ASC ", sSql, Convert.ToInt64(arrList[0]), Convert.ToInt64(arrList[1]), Convert.ToInt32(arrList[2]));

                    }
                    else
                    {
                        sSql = sSql + " SELECT A.BILLNO AS 票据号,B.INPATIENT_NO AS 住院号,B.NAME AS 姓名,CASE WHEN A.NTYPE =2 THEN C.SELF_FEE ELSE A.NVALUES END AS 票据金额, ";
                        sSql = sSql + " A.USED_DATE AS 使用时间,DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 操作员 ";
                        sSql = sSql + @" FROM ZY_BILLLIST A LEFT JOIN VI_ZY_VINPATIENT B ON A. INPATIENT_ID = B.INPATIENT_ID 
                                 LEFT JOIN ZY_DISCHARGE C ON A.SOURCE_ID=C.ID ";
                        sSql = String.Format("{0} WHERE A.BILLNO >= {1} AND A.BILLNO <= {2} AND (A.NSTATUS = 2 OR (A.NSTATUS = 1 AND A.CANCEL_USERID IS NOT NULL)) AND A.NTYPE = {3} ORDER BY A.BILLNO ASC ", sSql, Convert.ToInt64(arrList[0]), Convert.ToInt64(arrList[1]), Convert.ToInt32(arrList[2]));

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
        /// 获取领药明细
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable GetUseDetails(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 0)
                        {
                            sSql = sSql + " SELECT ID AS 领用批次,CASE NTYPE WHEN 1 THEN '预交收据' WHEN 2 THEN '正式发票' WHEN 3 THEN '退款单据' ELSE '未知票据类型' END AS 票据类型, ";
                            sSql = sSql + " BEGINNO AS 起始号,ENDNO AS 终止号,DBO.FUN_GETDATE(FETCHDATE) AS 领用日期, ";
                            sSql = sSql + " (CASE WHEN EMPLOYEE_ID <> -1 THEN DBO.FUN_ZY_SEEKEMPLOYEENAME(EMPLOYEE_ID) WHEN EMPLOYEE_ID = -1 THEN '全班' ELSE '未知' END ) AS 领用人, ";
                            sSql = sSql + " (CASE STATUS WHEN 0 THEN '未使用' WHEN 1 THEN '使用中' WHEN 2 THEN '使用完' WHEN 3 THEN '已核销' ELSE '未知状态' END ) AS 使用状态,";
                            //modify by tck 2014-04-24
                            sSql = sSql + " (CASE WHEN STATUS=1 THEN (SELECT MIN(BILLNO) FROM ZY_BILLLIST A WHERE A.NBATCH=B.ID AND NSTATUS=0) ELSE NULL END) AS 当前票据号 FROM ZY_FETCHBILL B WHERE 1 = 1 ";    
                        }
                        else
                        {
                            sSql = sSql + " SELECT ID AS 领用批次,CASE NTYPE WHEN 1 THEN '预交收据' WHEN 2 THEN '正式发票' WHEN 3 THEN '退款单据' WHEN 5 THEN '正式发票(税务)' WHEN 6 THEN '正式发票(自制)' ELSE '未知票据类型' END AS 票据类型, ";
                            sSql = sSql + " BEGINNO AS 起始号,ENDNO AS 终止号,DBO.FUN_GETDATE(FETCHDATE) AS 领用日期, ";
                            sSql = sSql + " (CASE WHEN EMPLOYEE_ID <> -1 THEN DBO.FUN_ZY_SEEKEMPLOYEENAME(EMPLOYEE_ID) WHEN EMPLOYEE_ID = -1 THEN '全班' ELSE '未知' END) AS 领用人, ";
                            sSql = sSql + " (CASE STATUS WHEN 0 THEN '未使用' WHEN 1 THEN '使用中' WHEN 2 THEN '使用完' WHEN 3 THEN '已核销' ELSE '未知状态' END ) AS 使用状态, ";
                            //modify by tck 2014-04-24
                            sSql = sSql + " (CASE WHEN STATUS=1 THEN (SELECT MIN(BILLNO) FROM ZY_BILLLIST A WHERE A.NBATCH=B.ID AND NSTATUS=0) ELSE NULL END) AS 当前票据号 FROM ZY_FETCHBILL B WHERE 1 = 1 ";    

                        }

                        if ((bool)arrList[1] == true)
                        {
                            sSql = String.Format("{0} AND FETCHDATE BETWEEN '{1}' AND '{2}' ", sSql, arrList[2], arrList[3]);
                        }
                        if (Convert.ToInt32(arrList[4]) > 0)
                        {
                            sSql = String.Format("{0} AND EMPLOYEE_ID = {1} ", sSql, Convert.ToInt32(arrList[4]));
                        }
                        if (Convert.ToInt32(arrList[5]) > 0)
                        {
                            sSql = String.Format("{0} AND NTYPE = {1} ", sSql, Convert.ToInt32(arrList[5]));
                        }
                        if (Convert.ToInt32(arrList[6]) > -1)
                        {
                            sSql = String.Format("{0} AND STATUS = {1} ", sSql, Convert.ToInt32(arrList[6]));
                        }
                        sSql = sSql + " ORDER BY NTYPE ASC,FETCHDATE ASC ";
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
        /// 相交检查
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static int IntersectionCheck(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            int checkCount = 0;

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT COUNT(*) AS NUM FROM ZY_FETCHBILL WHERE NTYPE = {1} ", sSql, Convert.ToInt32(arrList[0]));
                        sSql = String.Format("{0} AND (BEGINNO <= {1} AND ENDNO >= {1} OR BEGINNO <= {2} AND ENDNO >= {2})", sSql, arrList[1], arrList[2]);
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

            checkCount = Convert.ToInt32(Convertor.IsNull(dataBase.GetDataResult(sSql), "0"));
            return checkCount;
        }
        /// <summary>
        /// 状态检查
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static int StateExamination(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            int stateCount = 0;

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT COUNT(*) AS NUM FROM ZY_FETCHBILL WHERE NTYPE = {1} ", sSql, Convert.ToInt32(arrList[0]));
                        sSql = String.Format("{0} AND BEGINNO >= {1} AND ENDNO <= {2} ", sSql, Convert.ToInt64(arrList[1]), Convert.ToInt64(arrList[2]));
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

            stateCount = Convert.ToInt32(Convertor.IsNull(dataBase.GetDataResult(sSql), "0"));
            return stateCount;
        }
        /// <summary>
        /// 领用记录
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataTable GetARecord(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT ID AS 批号,NTYPE AS 票据类型,BEGINNO AS 起始票号,ENDNO AS 终止票号,FETCHDATE AS 领用日期, STATUS AS 使用状态 FROM ZY_FETCHBILL WHERE CANCEL_BIT = 0 AND NTYPE = {1} AND EMPLOYEE_ID = {2} ORDER BY BEGINNO ", sSql, Convert.ToInt32(arrList[0]), Convert.ToInt32(arrList[1]));
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
        /// 明细记录
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataTable GetDetailRecord(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT NBATCH AS 批号,A.NTYPE AS 票据类型,A.OLDBILLNO AS 原票据号, ";
                        sSql = sSql + " A.BILLNO AS 票据号,A.NVALUES AS 票据金额,A.NSTATUS AS 使用状态, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(A.USERID) AS 用户,A.INPATIENT_ID AS 病人, ";
                        sSql = sSql + " A.CANCEL_DATE 作废日期,A.CANCEL_REASON AS 注释 ";
                        sSql = sSql + " FROM ZY_BILLLIST AS A INNER JOIN ZY_FETCHBILL AS B ON A.NBATCH = B.ID ";
                        sSql = String.Format("{0} WHERE B.EMPLOYEE_ID = {1} ", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND A.NTYPE = {1} ", sSql, Convert.ToInt32(arrList[0]));
                        sSql = sSql + " ORDER BY A.NBATCH,A.BILLNO ";
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
        /// 查找批次
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataRow FindTheBatch(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT * FROM ZY_FETCHBILL WHERE ID = '{1}' ", sSql, arrList[0]);
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
            DataRow daRow = dataBase.GetDataRow(sSql);
            return daRow;

        }
        /// <summary>
        /// 安全检查
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static DataTable SafetyInspection(int i, ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (i == 1)
                        {
                            sSql = String.Format("{0} SELECT * FROM ZY_BILLLIST WHERE NBATCH = '{1}' AND NSTATUS = 1 ", sSql, arrList[0]);
                        }
                        if (i == 2)
                        {
                            sSql = String.Format("{0} SELECT * FROM ZY_BILLLIST WHERE NBATCH = '{1}' AND NSTATUS = 0 ", sSql, arrList[0]);
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
        /// 取消领用
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        public static void CancelUse(ArrayList arrList, RelationalDatabase dataBase)
        {
            string[] sSql = new string[2];

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql[0] = String.Format("{0} DELETE ZY_FETCHBILL WHERE ID = '{1}' ", sSql[0], arrList[0]);
                        sSql[1] = String.Format("{0} DELETE ZY_BILLLIST WHERE NBATCH = '{1}' ", sSql[1], arrList[0]);
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
            dataBase.DoCommand(null, null, null, sSql);
        }
        /// <summary>
        /// 作废票据
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        public static int TheBill(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            int i = 0;
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if ((bool)arrList[0] == true)
                        {
                            sSql = String.Format("{0} UPDATE ZY_BILLLIST SET NSTATUS = 2,CANCEL_DATE = GETDATE(),CANCEL_USERID = {1},CANCEL_REASON = '{2}' WHERE NTYPE = {3} AND USERID = {4} AND (NSTATUS = 0 OR NSTATUS = 2) AND OLDBILLNO = {5} ", sSql, Convert.ToInt32(arrList[1]), arrList[2], Convert.ToInt32(arrList[3]), Convert.ToInt32(arrList[4]), Convert.ToInt64(arrList[5]));
                        }
                        else
                        {
                            sSql = String.Format("{0} UPDATE ZY_BILLLIST SET NSTATUS = 2,CANCEL_DATE = GETDATE() + 1,CANCEL_USERID = {1},CANCEL_REASON = '{2}' WHERE NTYPE = {3} AND USERID = {4} AND (NSTATUS = 0 OR NSTATUS = 2) AND OLDBILLNO = {5} ", sSql, Convert.ToInt32(arrList[1]), arrList[2], Convert.ToInt32(arrList[3]), Convert.ToInt32(arrList[4]), Convert.ToInt64(arrList[5]));
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
            i = dataBase.DoCommand(sSql);
            return i;
        }
        public static string GetOldBillNo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT BILLNO FROM ZY_BILLLIST WHERE OLDBILLNO = {1} AND NTYPE = {2} ", sSql, Convert.ToInt64(arrList[0]), Convert.ToInt32(arrList[1]));
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
            string billNo = Convertor.IsNull(dataBase.GetDataResult(sSql), "");
            return billNo;
        }
        public static DataRow GetReceipt(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT ID FROM ZY_FETCHBILL WHERE NTYPE = {2} AND STATUS = 1 AND EMPLOYEE_ID = {1} ", sSql, Convert.ToInt32(arrList[0]), Convert.ToInt32(arrList[1]));

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

            DataRow daRow = dataBase.GetDataRow(sSql);
            return daRow;
        }
        public static DataRow SetReceipt(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT COUNT(1) FROM ZY_BILLLIST WHERE NSTATUS = 0 AND NBATCH = '{1}' ", sSql, arrList[0]);
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

            DataRow daRow = dataBase.GetDataRow(sSql);
            return daRow;
        }
        public static DataTable TheBiggestBanks(int i, ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (i == 1)
                        {
                            sSql = String.Format("{0} SELECT MAX(BILLNO) MAXBILL FROM ZY_BILLLIST WHERE NSTATUS <> 0 AND NBATCH = '{1}' ", sSql, arrList[0]);
                        }
                        if (i == 2)
                        {
                            sSql = String.Format("{0} SELECT MIN(BILLNO) FROM ZY_BILLLIST WHERE NSTATUS = 0 AND NTYPE = {1} AND NBATCH = '{2}' AND USERID = {3} ", sSql, Convert.ToInt32(arrList[0]), arrList[1], Convert.ToInt32(arrList[2]));
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
        public static void EndNotes(ArrayList arrList, RelationalDatabase dataBase)
        {
            string[] sSql = new string[2];
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql[0] = String.Format("{0} UPDATE ZY_FETCHBILL SET STATUS = 2,ENDNO = {1} WHERE ID = '{2}' ", sSql[0], Convert.ToInt32(arrList[1]), arrList[0]);
                        sSql[1] = String.Format("{0} DELETE FROM ZY_BILLLIST WHERE NBATCH = '{1}' AND BILLNO > {2} AND NSTATUS = 0 ", sSql[1], arrList[0], Convert.ToInt64(arrList[1]));
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
            dataBase.DoCommand(null, null, null, sSql);
        }
        public static DataRow SetTheStartTimeOfTermination(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT MIN(USED_DATE) AS USED_DATE FROM ZY_BILLLIST WHERE NBATCH = '{1}' ", sSql, arrList[0]);
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

            DataRow daRow = dataBase.GetDataRow(sSql);
            return daRow;
        }
        public static DataTable SelectRecipientsBatch(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT '{1}' AS 起始时间,'{2}' AS 终止时间,MIN(BILLNO) AS 起始号, ", sSql, arrList[1], arrList[2]);
                        sSql = sSql + " MAX(BILLNO) AS 终止号,SUM(1) AS 份数,SUM(CASE WHEN NSTATUS = 1 THEN NVALUES ELSE 0 END) AS 面额, ";
                        sSql = sSql + " SUM(CASE WHEN NSTATUS = 2 THEN 1 ELSE 0 END) AS 作废票, ";
                        sSql = sSql + " SUM(CASE WHEN (NVALUES < 0 AND NSTATUS = 1 ) THEN 1 ELSE 0 END ) AS 退费票, ";
                        sSql = sSql + " SUM(CASE WHEN (NVALUES < 0 AND NSTATUS = 1) THEN NVALUES ELSE 0 END ) AS 退费 ";
                        sSql = String.Format("{0} FROM ZY_BILLLIST WHERE USED_DATE >= '{1}' ", sSql, arrList[1]);
                        sSql = String.Format("{0} AND USED_DATE <= '{1}' AND NBATCH = '{2}' ", sSql, arrList[2], arrList[0]);
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
        public static DataRow SelectRecipientsBatchRow(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT '{1}' AS 起始时间,'{2}' AS 终止时间,MIN(BILLNO) AS 起始号, ", sSql, arrList[1], arrList[2]);
                        sSql = sSql + " MAX(BILLNO) AS 终止号,SUM(1) AS 份数,SUM(CASE WHEN NSTATUS = 1 THEN NVALUES ELSE 0 END) AS 面额, ";
                        sSql = sSql + " SUM(CASE WHEN NSTATUS = 2 THEN 1 ELSE 0 END) AS 作废票, ";
                        sSql = sSql + " SUM(CASE WHEN (NVALUES < 0 AND NSTATUS = 1 ) THEN 1 ELSE 0 END ) AS 退费票, ";
                        sSql = sSql + " SUM(CASE WHEN (NVALUES < 0 AND NSTATUS = 1) THEN NVALUES ELSE 0 END ) AS 退费 ";
                        sSql = String.Format("{0} FROM ZY_BILLLIST WHERE USED_DATE >= '{1}' ", sSql, arrList[1]);
                        sSql = String.Format("{0} AND USED_DATE <= '{1}' AND NBATCH = '{2}' ", sSql, arrList[2], arrList[0]);
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
            DataRow daRow = dataBase.GetDataRow(sSql);
            return daRow;

        }
        public static void VerificationAndCancellationVerification(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} UPDATE ZY_FETCHBILL SET STATUS = {1} WHERE ID = '{2}' ", sSql, Convert.ToInt32(arrList[0]), arrList[1]);
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
        public static DataTable NoteTheUseOfInformationLoad(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT * FROM ZY_FETCHBILL WHERE CANCEL_BIT = 0 AND STATUS = 1 ";
                        sSql = String.Format("{0} AND NTYPE = {1} AND EMPLOYEE_ID = {2} ", sSql, Convert.ToInt32(arrList[0]), Convert.ToInt32(arrList[1]));
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
        public static void AdjustTicketNumber(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} UPDATE ZY_BILLLIST SET NSTATUS = 1,CANCEL_DATE = GETDATE(),CANCEL_USERID = {1},CANCEL_REASON = '调整票据号' WHERE NSTATUS = 0 AND NTYPE = {2} AND NBATCH = '{3}' AND USERID = {4} AND BILLNO < {5} ", sSql, Convert.ToInt32(arrList[0]), Convert.ToInt32(arrList[1]), arrList[2], Convert.ToInt32(arrList[3]), Convert.ToInt64(arrList[4]));

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
    }
}