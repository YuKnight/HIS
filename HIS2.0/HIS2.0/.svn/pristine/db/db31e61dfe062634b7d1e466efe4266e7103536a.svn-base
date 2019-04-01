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
 * 名称：住院交账管理数据库访问类
 * 描述：适用于住院交账管理中的数据库访问
 * 编写时间：2013-10
 * 作者：Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class PayManageDataBaseAccessClass
    {
        /*
         * 交账管理有存储过程未改造
         */


        /// <summary>
        /// 住院交款查询
        /// 存储过程--SP_ZY_CX_JKJL
        /// </summary>
        /// <param name="beginDateTime">开始日期</param>
        /// <param name="endDateTime">结束日期</param>
        /// <param name="employeeId">收费员ID</param>
        /// <param name="isType">状态条件</param>
        /// <param name="isConfirm">是否确认</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZpqZyPaymentQuery(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[3]) == 2)  //全部
                        {
                            sSql = sSql + " SELECT * FROM  ";
                            sSql = sSql + " ( ";
                            sSql = sSql + " SELECT '0' 序号,CASE WHEN TURN_USERID=-1 THEN '全班' ELSE DBO.FUN_GETEMPNAME(TURN_USERID) END 收费员,TURN_BDATE 开始时间, ";
                            sSql = sSql + " TURN_EDATE 结束时间,TURN_DATE 缴款时间,DEPOSITS 收预交金,POS POS, [CHECK] 支票,ISNULL([BATCH],0) 批条,ISNULL(FCCACCOUNT,0) 财务记账,PATCHFEE 结算补款, RECEDEFEE 结算退款, INSUREFEE 医保支付, ";
                            //Modify By Kevin 2014-05-20 增加减免金额
                            sSql = sSql + " CXDEPOSITS 冲销预交,DEBTFEE 欠费,BLANCE 结存, NFEE 结算总费用,INCOME 收入, CASHTOTAL 现金合计,ISNULL(DERATEFEE,0) 减免金额, ";
                            sSql = sSql + " (CASE WHEN A.ISJK = 0 THEN '未确认' WHEN A.ISJK = 1 THEN '已确认' ELSE '' END) 确认标志, ";
                            sSql = sSql + " DBO.FUN_GETEMPNAME(A.AFFUSER) 确认人,A.AFFDATE 确认时间,TURN_USERID,A.TURN_ID,PAYNUMBER,PAYFLAG ";
                            sSql = sSql + " FROM ZY_TURNACCOUNT A ";
                            sSql = String.Format("{0} WHERE A.TURN_DATE BETWEEN '{1}' AND '{2}' AND (TURN_USERID={3} OR {3}=-1) ", sSql, arrList[0], arrList[1], Convert.ToInt32(arrList[2]));
                            sSql = sSql + " UNION ALL ";
                            sSql = sSql + " SELECT '99999' 序号,NULL 收费员,NULL 开始时间,NULL 结束时间,NULL 缴款时间,SUM(DEPOSITS) 收预交金, SUM(POS) POS, SUM([CHECK]) 支票,ISNULL(SUM([BATCH]),0) 批条,ISNULL(SUM(FCCACCOUNT),0) 财务记账, SUM(PATCHFEE) 结算补款, ";
                            sSql = sSql + " SUM(RECEDEFEE) 结算退款, SUM(INSUREFEE) 医保支付, SUM(CXDEPOSITS) 冲销预交, SUM(DEBTFEE) 欠费,SUM(BLANCE) 结存, ";
                            //Modify By Kevin 2014-05-20 增加减免金额
                            sSql = sSql + " SUM(NFEE) 结算总费用, SUM(INCOME) 收入, SUM(CASHTOTAL) 现金合计,ISNULL(SUM(DERATEFEE),0) 减免金额,NULL 确认标志,NULL 确认人,NULL 确认时间,NULL TURN_USERID,NULL,NULL PAYNUMBER,NULL PAYFLAG ";
                            sSql = sSql + " FROM ZY_TURNACCOUNT A ";
                            sSql = String.Format("{0} WHERE A.TURN_DATE BETWEEN '{1}' AND '{2}' AND (TURN_USERID={3} OR {3}=-1) ", sSql, arrList[0], arrList[1], Convert.ToInt32(arrList[2]));
                            sSql = sSql + " ) A ";
                            sSql = sSql + " ORDER BY 序号,缴款时间 ";
                        }
                        else
                        {
                            sSql = sSql + " SELECT * FROM ";
                            sSql = sSql + " ( ";
                            sSql = sSql + " SELECT '0' 序号,CASE WHEN TURN_USERID=-1 THEN '全班' ELSE DBO.FUN_GETEMPNAME(TURN_USERID) END 收费员,TURN_BDATE 开始时间, ";
                            sSql = sSql + " TURN_EDATE 结束时间,TURN_DATE 缴款时间,DEPOSITS 收预交金,POS POS, [CHECK] 支票,ISNULL([BATCH],0) 批条,ISNULL(FCCACCOUNT,0) 财务记账,PATCHFEE 结算补款, RECEDEFEE 结算退款, INSUREFEE 医保支付, ";
                            //Modify By Kevin 2014-05-20 增加减免金额
                            sSql = sSql + " CXDEPOSITS 冲销预交,DEBTFEE 欠费,BLANCE 结存, NFEE 结算总费用,INCOME 收入, CASHTOTAL 现金合计,ISNULL(DERATEFEE,0) 减免金额, ";
                            sSql = sSql + " (CASE WHEN A.ISJK = 0 THEN '未确认' WHEN A.ISJK = 1 THEN '已确认' ELSE '' END) 确认标志, ";
                            sSql = sSql + " DBO.FUN_GETEMPNAME(A.AFFUSER) 确认人,A.AFFDATE 确认时间,TURN_USERID,A.TURN_ID,PAYNUMBER,PAYFLAG ";
                            sSql = sSql + " FROM ZY_TURNACCOUNT A ";
                            sSql = String.Format("{0} WHERE A.ISJK = {1} AND A.TURN_DATE BETWEEN '{2}' AND '{3}' AND (TURN_USERID={4} OR {4}=-1) ", sSql, Convert.ToInt32(arrList[4]), arrList[0], arrList[1], Convert.ToInt32(arrList[2]));
                            sSql = sSql + " UNION ALL ";
                            sSql = sSql + " SELECT '99999' 序号,NULL 收费员,NULL 开始时间,NULL 结束时间,NULL 缴款时间,SUM(DEPOSITS) 收预交金, SUM(POS) POS, SUM([CHECK]) 支票, ISNULL(SUM([BATCH]),0) 批条,ISNULL(SUM(FCCACCOUNT),0) 财务记账,SUM(PATCHFEE) 结算补款, ";
                            sSql = sSql + " SUM(RECEDEFEE) 结算退款, SUM(INSUREFEE) 医保支付, SUM(CXDEPOSITS) 冲销预交, SUM(DEBTFEE) 欠费,SUM(BLANCE) 结存, ";
                            //Modify By Kevin 2014-05-20 增加减免金额
                            sSql = sSql + " SUM(NFEE) 结算总费用, SUM(INCOME) 收入, SUM(CASHTOTAL) 现金合计,ISNULL(SUM(DERATEFEE),0) 减免金额,NULL 确认标志,NULL 确认人,NULL 确认时间,NULL TURN_USERID,NULL TURN_ID ,NULL PAYNUMBER,NULL PAYFLAG ";
                            sSql = sSql + " FROM ZY_TURNACCOUNT A ";
                            sSql = String.Format("{0} WHERE A.ISJK = {1} AND A.TURN_DATE BETWEEN '{2}' AND '{3}' AND (TURN_USERID={4} OR {4}=-1) ", sSql, Convert.ToInt32(arrList[4]), arrList[0], arrList[1], Convert.ToInt32(arrList[2]));
                            sSql = sSql + " ) A ";
                            sSql = sSql + " ORDER BY 序号,缴款时间 ";
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
        /// 更新确认信息
        /// </summary>
        /// <param name="employeeId">确认人员</param>
        /// <param name="confirmTime">确认时间</param>
        /// <param name="paymentId">交款ID</param>
        /// <param name="dataBase">数据库连接</param>
        public static void ZpqModifyConfirmBit(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0}UPDATE ZY_TURNACCOUNT SET ISJK = 1,AFFUSER = {1},AFFDATE = '{2:yyyy-MM-dd HH:mm:ss}' WHERE TURN_ID = '{3}'", sSql, Convert.ToInt32(arrList[0]), arrList[1], arrList[2]);
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
        /// 获取最大和最小的结算发票号
        /// </summary>
        /// <param name="beginDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="nType">发票类型</param>
        /// <param name="employeeId">人员ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZpqGetMaxAndMinBillNo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT MIN(BILLNO) AS MINBILLNO,MAX(BILLNO) AS MAXBILLNO FROM ZY_BILLLIST ";
                        sSql = String.Format("{0} WHERE NTYPE = {1} AND USED_DATE >= '{2}' ", sSql, Convert.ToInt32(arrList[2]), arrList[0]);
                        sSql = String.Format("{0} AND USED_DATE <= '{1}' ", sSql, arrList[1]);
                        if (Convert.ToInt32(arrList[3]) != -1)
                            sSql = String.Format("{0} AND USERID = {1} GROUP BY NBATCH ", sSql, Convert.ToInt32(arrList[3]));
                        else
                            sSql = sSql + " GROUP BY NBATCH ";
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
        /// 获取医保费用集合
        /// </summary>
        /// <param name="arrList">交账ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZpqGetMedicalAssemble(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT SUM(ZHZF) GRZHZF,SUM(TCZF) + SUM(QTZF) YBJJZF FROM ZY_YB_JSB ";
                        sSql = String.Format("{0} WHERE DISCHARGE_BIT = 1 AND DELETE_BIT = 0 AND DISCHARGE_ID IN (SELECT ID FROM ZY_DISCHARGE WHERE CZ_FLAG = 0 AND TURN_BIT = 1 AND TURN_ID = '{1}') ", sSql, arrList[0]);
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
        public static DateTime ZpqGetLastTurnDate(ArrayList arrList, RelationalDatabase dataBase)
        {
            DateTime minDate = new DateTime();
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        string turnCountSql = String.Format(" SELECT TOP 1 * FROM ZY_TURNACCOUNT WHERE TURN_USERID = {0} ORDER BY TURN_DATE DESC ", Convert.ToInt32(arrList[0]));
                        DataTable tb = dataBase.GetDataTable(turnCountSql);
                        if (tb.Rows.Count == 0)
                        {
                            DateTime disDate = Convert.ToDateTime(Convertor.IsNull(dataBase.GetDataResult(String.Format("SELECT MIN(DISCHARGE_DATE) FROM ZY_DISCHARGE WHERE USERID = {0} AND TURN_BIT = 0", Convert.ToInt32(arrList[0]))), "1900-01-01 00:00:00"));
                            DateTime depDate = Convert.ToDateTime(Convertor.IsNull(dataBase.GetDataResult(String.Format("SELECT MIN(ARRIVE_DATE) FROM ZY_DEPOSITS WHERE ARRIVE_USERID = {0} AND TURN_BIT = 0", Convert.ToInt32(arrList[0]))), "1900-01-01 00:00:00"));
                            minDate = disDate;
                            if (disDate == Convert.ToDateTime("1900-01-01 00:00:00"))
                            {
                                minDate = depDate;
                            }
                            else if (depDate == Convert.ToDateTime("1900-01-01 00:00:00"))
                            {
                                minDate = disDate;
                            }
                            else if (disDate > depDate)
                            {
                                minDate = depDate;
                            }
                            else
                            {
                                minDate = disDate;
                            }
                            //return minDate;//Convert.ToDateTime("1900-01-01 00:00:00");
                        }
                        else
                        {
                            minDate = Convert.ToDateTime(tb.Rows[0]["turn_edate"]);
                            //return Convert.ToDateTime(tb.Rows[0]["turn_edate"]);
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
            return minDate;
        }
    }
}