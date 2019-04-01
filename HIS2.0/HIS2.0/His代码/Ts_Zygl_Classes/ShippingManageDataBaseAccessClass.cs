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
 * 名称：住院优惠管理数据库访问类
 * 描述：适用于住院优惠管理中的数据库访问
 * 编写时间：2013-10
 * 作者：Kevin
 * **/


namespace Ts_Zygl_Classes
{
    public class ShippingManageDataBaseAccessClass
    {
        public static DataTable SpmBindShipingCardType(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        //注释 BY TCK 
                        //sSql = sSql + " SELECT ID AS ID,KLXMC NAME,CSJE,ISYCX FROM JC_KLX WHERE MZORZY = 2  ORDER BY ID ";
                        sSql = sSql + " SELECT ID AS ID,KLXMC NAME,CSJE,ISYCX FROM JC_KLX ORDER BY ID ";
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
        public static DataRow SpmQueryShipingCardType(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT CSJE,ISYCX FROM JC_KLX WHERE ID = {1} ", sSql, Convert.ToInt32(arrList[0]));
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
        public static DataTable SpmQueryShipingInfoSingle(int i, ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (i == 1)
                        {
                            sSql = String.Format("{0} SELECT * FROM ZY_YH_YHWH WHERE SFZH = '{1}' AND DELETE_BIT = 0 AND JGBM = {2} ", sSql, arrList[0], Convert.ToInt32(arrList[1]));
                        }
                        if (i == 2)
                        {
                            sSql = String.Format("{0} SELECT * FROM ZY_YH_YHWH WHERE ID = '{1}' AND DELETE_BIT = 0 AND JGBM {2} ", sSql, arrList[0], Convert.ToInt32(arrList[1]));
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
        public static void SpmAddShipingInfoSingle(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} INSERT INTO ZY_YH_YHWH (ID,YHLX,SFZH,BRXM,DHHM,SEX,AGE,CSJE,YE,JGBM,DJSJ,XGSJ,JBBM,JBMC,YHZZ,CZY) VALUES ('{1}',{2},'{3}','{4}','{5}',{6},{7},'{8:0.00}','{9:0.00}',{10},GETDATE(),GETDATE(),'{11}','{12}','{13}',{14}) ", sSql, arrList[0], Convert.ToInt32(arrList[1]), arrList[2], Convertor.IsNull(arrList[3], ""), Convertor.IsNull(arrList[4], ""), Convert.ToInt32(arrList[5]), Convert.ToInt32(arrList[6]), Convert.ToDecimal(Convertor.IsNull(arrList[7], "0")), Convert.ToDecimal(Convertor.IsNull(arrList[8], "0")), Convert.ToInt32(arrList[9]), Convertor.IsNull(arrList[10].ToString(), "-1"), Convertor.IsNull(arrList[11], ""), Convertor.IsNull(arrList[12], ""), Convert.ToInt32(arrList[13]));
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
        public static DataTable SpmQueryPatientShipingInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        string sWhere = "";
                        if (Convert.ToInt32(arrList[0]) != -1)
                            sWhere = String.Format("{0} AND YHLX = {1} ", sWhere, Convert.ToInt32(arrList[0]));
                        if (Convert.ToString(arrList[1]) != "")
                            sWhere = String.Format("{0} AND SFZH = '{1}' ", sWhere, arrList[1]);
                        if (Convert.ToString(arrList[2]) != "")
                            sWhere = String.Format("{0} AND A.BRXM = '{1}' ", sWhere, arrList[2]);
                        if (Convert.ToString(arrList[3]) == "0")
                            sWhere = sWhere + " ORDER BY A.DJSJ DESC ";
                        else
                            sWhere = sWhere + " ORDER BY A.XGSJ DESC ";

                        sSql = sSql + " SELECT '' 序号,B.KLXMC 优惠类型,A.SFZH 身份证号,A.BRXM 病人姓名,ISNULL(C.YBLX_NAME,'自费') 病人类型,A.DHHM 电话号码, ";
                        sSql = sSql + " (CASE A.SEX WHEN '1' THEN '男' WHEN '2' THEN '女' ELSE '其他' END) 性别, ";
                        sSql = sSql + " A.AGE 年龄, A.CSJE 金额,A.YE 余额,DBO.FUN_GETDISEASENAME(A.JBBM,C.YBLX) 疾病名称, ";
                        sSql = sSql + " A.YHZZ 相关证明,DBO.FUN_GETEMPNAME(A.CZY) 维护人,A.ID,A.YHLX,A.JBBM,C.YBLX BRLXID, ";
                        sSql = sSql + " C.YBJKLX FROM ZY_YH_YHWH A ";
                        sSql = sSql + " INNER JOIN JC_KLX B ON A.YHLX = B.ID LEFT JOIN VI_ZY_VINPATIENT_ALL C ON A.SFZH = C.SOCIAL_NO AND DISCHARGE_DATE IS NULL ";
                        sSql = String.Format("{0} WHERE A.DELETE_BIT = 0 AND A.JGBM = {1} {2}", sSql, Convert.ToInt32(arrList[4]), sWhere);
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
        public static void SpmDelPatientShipingInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} UPDATE ZY_YH_YHWH SET DELETE_BIT = 1 WHERE ID = '{1}' AND DELETE_BIT = 0 AND JGBM = {2} ", sSql, arrList[0], Convert.ToString(arrList[1]));
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
        public static void SpmModifyShipingInfoSingle(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} UPDATE ZY_YH_YHWH SET CSJE = '{1}',YE =  '{2}', YHLX = {3} ,XGSJ = GETDATE(),JBBM = '{4}',JBMC = '{5}',YHZZ = '{6}',CZY = {7},DHHM = '{8}',AGE = {9},BRXM = '{10}'  WHERE ID = '{11}' AND DELETE_BIT = 0 AND JGBM = {12} ", sSql, Convert.ToDecimal(arrList[0]), Convert.ToDecimal(arrList[1]), Convert.ToInt32(arrList[2]), arrList[3], arrList[4], arrList[5], Convert.ToInt32(arrList[6]), arrList[7], Convert.ToInt32(arrList[8]), arrList[9], arrList[10], Convert.ToInt32(arrList[11]));
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
        public static DataTable SpmQueryPatientShipingInfoNumber(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT A.NAME,A.HOME_TEL,A.SEX_NAME,A.BIRTHDAY,A.IN_DIAGNOSIS,A.RYZD,A.YBLX,A.YBLX_NAME,A.YBJKLX FROM VI_ZY_VINPATIENT_ALL A  WHERE A.SOCIAL_NO = '{1}' AND A.BABY_ID = 0 ORDER BY A.IN_DATE DESC ", sSql, arrList[0]);
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
        //public static DataTable SpmShipingExcelQuery(ArrayList arrList, RelationalDatabase dataBase)
        //{
        //    string sSql = "";
        //    switch (dataBase.ConnectionType)
        //    {
        //        case ConnectType.SQLSERVER:
        //            {
        //                sSql = String.Format("{0} SELECT ID FROM ZY_YH_YHWH WHERE SFZH = '{1}' AND DELETE_BIT = 0 AND JGBM = {2} ", sSql, arrList[0], Convert.ToInt32(arrList[1]));

        //            }
        //            break;
        //        case ConnectType.ORACLE:
        //            {
        //            }
        //            break;
        //        case ConnectType.IBMDB2:
        //            {
        //            }
        //            break;
        //        case ConnectType.MSACCESS:
        //            {
        //            }
        //            break;
        //        case ConnectType.OTHER:
        //            {
        //            }
        //            break;
        //    }
        //    DataTable daTable = dataBase.GetDataTable(sSql);
        //    return daTable;
        //}
        public static void SpmShipingExcelModify(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} UPDATE ZY_YH_YHWH SET YE = '{1:0.00}',XGSJ = GETDATE(),CZY = {2} WHERE ID = '{3}' AND JGBM = {4} ", sSql, Convert.ToDecimal(arrList[0]), Convert.ToInt32(arrList[1]), arrList[2], Convert.ToInt32(arrList[3]));
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
        public static void SpmShipingExcelAdd(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} INSERT INTO ZY_YH_YHWH (ID,YHLX,SFZH,BRXM,DHHM,SEX,CSJE,YE,JGBM,DJSJ,XGSJ,YHZZ,CZY) VALUES (DBO.FUN_GETGUID(NEWID(),GETDATE()),{1},'{2}','{3}','{4}',{5},'{6:0.00}','{7:0.00}',{8},GETDATE(),GETDATE(),'{9}',{10}) ", sSql, Convert.ToInt32(arrList[0]), arrList[1], arrList[2], arrList[3], Convert.ToInt32(arrList[4]), Convert.ToDecimal(arrList[5]), Convert.ToDecimal(arrList[6]), Convert.ToInt32(arrList[7]), arrList[8], Convert.ToInt32(arrList[9]));
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
        public static DataTable SpmGetLastTurnDate(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {

                        sSql = String.Format("{0} SELECT TOP 1 * FROM ZY_YH_YHJK WHERE TURN_USERID = {1} AND JGBM = {2} ORDER BY TURN_DATE DESC ", sSql, Convert.ToInt32(arrList[0]), Convert.ToInt32(arrList[1]));
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
        public static DataTable SpmShipingPayQuery(int i, ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (i == 1)
                        {
                            sSql = String.Format("{0} SELECT '' AS '序号',INPATIENT_NO AS '住院号',BRXM AS '病人姓名',JE AS '金额',KLXMC AS '优惠类型',SFZH AS '身份证号',DBO.FUN_GETEMPNAME(BOOK_USER) AS '操作员',BOOK_DATE AS '统计时间' FROM ZY_YH_DJXX A LEFT JOIN JC_KLX B ON B.ID = A.DISTYPE WHERE  DELETE_BIT = 0 AND (BOOK_USER = {1} OR {1} = -1 ) AND BOOK_DATE >= '{2}' AND BOOK_DATE <= '{3}' AND JGBM = {4} AND DISTYPE = {5} AND TRUN_BIT = 0 UNION ALL SELECT '999999' AS '序号', '合计'  AS '住院号',NULL  AS '病人姓名',SUM(JE) AS '金额',NULL  AS '优惠类型',NULL  AS '身份证号',NULL AS '操作员', NULL  AS '统计时间' FROM ZY_YH_DJXX WHERE  DELETE_BIT = 0 AND (BOOK_USER = {1} OR {1} = -1 ) AND BOOK_DATE >= '{2}' AND BOOK_DATE <= '{3}' AND JGBM = {4} AND DISTYPE = {5} AND TRUN_BIT = 0 ", sSql, Convert.ToInt32(arrList[0]), arrList[1], arrList[2], Convert.ToInt32(arrList[3]), Convert.ToInt32(arrList[4]));

                        }
                        else if (i == 2)
                        {
                            sSql = String.Format("{0} SELECT '' 序号,TURN_ID AS TURN_ID,TURN_DATE AS '交款时间',TURN_BDATE AS '开始时间', TURN_EDATE AS '结束时间',DBO.FUN_GETEMPNAME(TURN_USERID) AS '交款人',TURN_FEE AS '交款总额',BOOK_DATE AS '操作时间',DBO.FUN_GETEMPNAME(BOOK_USER) AS '操作人' FROM ZY_YH_YHJK WHERE TURN_DATE >= '{1}' AND TURN_DATE <= '{2}' AND (TURN_USERID = {3} OR {3} = -1) AND YHLX = {4} AND JGBM = {5} UNION ALL SELECT '合计' 序号,NULL AS 'TURN_ID',NULL AS '交款时间',NULL AS '开始时间',NULL AS '结束时间',NULL AS '交款人', SUM(TURN_FEE) AS '交款总额',NULL AS '操作时间', NULL AS '操作人' FROM ZY_YH_YHJK WHERE TURN_DATE >= '{1}' AND TURN_DATE <= '{2}' AND (TURN_USERID = {3} OR {3} = -1) AND YHLX = {4} AND JGBM = {5} ", sSql, arrList[1], arrList[2], Convert.ToInt32(arrList[0]), Convert.ToInt32(arrList[4]), Convert.ToInt32(arrList[3]));
                        }
                        else if (i == 3)
                        {
                            sSql = String.Format("{0} SELECT '' AS '序号',INPATIENT_NO AS '住院号',BRXM AS '病人姓名',JE AS '金额',KLXMC AS '优惠类型',SFZH AS '身份证号',DBO.FUN_GETEMPNAME(BOOK_USER) AS '操作员',BOOK_DATE AS '统计时间',TRUN_ID AS 'TURN_ID' FROM ZY_YH_DJXX A LEFT JOIN JC_KLX B ON B.ID = A.DISTYPE WHERE  DELETE_BIT = 0 AND TRUN_ID = '{1}' AND JGBM = {2} AND TRUN_BIT = 1 UNION ALL SELECT '合计' AS '序号', NULL  AS '住院号',NULL  AS '病人姓名',SUM(JE) AS '金额',NULL  AS '优惠类型',NULL  AS '身份证号',NULL AS '操作员', NULL AS '统计时间',NULL AS 'TURN_ID' FROM ZY_YH_DJXX WHERE  DELETE_BIT = 0 AND TRUN_ID = '{1}' AND JGBM = {2} AND TRUN_BIT = 1  ", sSql, arrList[0], Convert.ToInt32(arrList[1]));
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
        public static void SpmShipingPayment(ArrayList arrList, RelationalDatabase dataBase)
        {
            string[] sSql = new string[2];
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql[0] = String.Format("{0} INSERT INTO ZY_YH_YHJK (TURN_ID,TURN_DATE,TURN_BDATE,TURN_EDATE,TURN_USERID,TURN_FEE,BOOK_DATE,BOOK_USER,YHLX,JGBM) VALUES ('{1}','{2}','{3}','{2}',{4},'{5}',GETDATE(),{6},{7},{8}) ", sSql[0], arrList[0], arrList[1], arrList[2], arrList[3], Convert.ToDecimal(arrList[4]), Convert.ToInt32(arrList[5]), Convert.ToInt32(arrList[6]), Convert.ToInt32(arrList[7]));

                        sSql[1] = String.Format("{0} UPDATE ZY_YH_DJXX SET TRUN_BIT = 1, TRUN_ID = '{1}' WHERE (BOOK_USER = {2} OR {2} = -1) AND TRUN_BIT = 0 AND BOOK_DATE >= '{3}' AND BOOK_DATE <= '{4}' AND JGBM = {5} AND DISTYPE = {6} ", sSql[1], arrList[0], arrList[3], arrList[2], arrList[1], Convert.ToInt32(arrList[7]), Convert.ToInt32(arrList[6]));
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
        public static DataTable SpmCheckPaymentInfoAll(int i, ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (i == 1)
                        {
                            sSql = String.Format("{0} SELECT TURN_ID,TURN_DATE,TURN_BDATE,TURN_EDATE,DBO.FUN_GETEMPNAME(TURN_USERID) AS TURN_USERID,TURN_FEE,BOOK_DATE,DBO.FUN_GETEMPNAME(BOOK_USER) AS BOOK_USER,KLXMC,JGBM FROM ZY_YH_YHJK A LEFT JOIN JC_KLX B ON B.ID = A.YHLX WHERE TURN_ID = '{1}' AND JGBM = {2} ", sSql, arrList[0], Convert.ToInt32(arrList[1]));
                        }
                        else if (i == 2)
                        {
                            sSql = String.Format("{0} SELECT '' 序号,A.INPATIENT_NO 住院号,A.BRXM 病人姓名,A.JE 金额,B.KLXMC 优惠类型,A.SFZH 身份证号,DBO.FUN_GETEMPNAME(A.BOOK_USER) 操作员,A.BOOK_DATE 统计时间 FROM ZY_YH_DJXX A INNER JOIN JC_KLX B ON B.ID = A.DISTYPE WHERE TRUN_BIT = 1 AND TRUN_ID = '{1}' AND DELETE_BIT = 0 AND JGBM = {2} ", sSql, arrList[0], Convert.ToInt32(arrList[1]));
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
        public static DataTable SpmShipingInfoStat(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            string sWhere = "";
            switch (dataBase.ConnectionType)
            {

                case ConnectType.SQLSERVER:
                    {
                        if ((bool)arrList[0] == true)
                            sWhere = sWhere + " AND TRUN_BIT = 1 ";
                        if ((bool)arrList[1] == true)
                            sWhere = sWhere + " AND TRUN_BIT = 2 ";

                        if (Convert.ToInt32(arrList[2]) != -1)
                        {
                            if ((bool)arrList[3] == true)
                                sWhere = String.Format("{0} AND TURN_USERID = {1} ", sWhere, Convert.ToInt32(arrList[2]));
                            else
                                sWhere = String.Format("{0} AND BOOK_USER = {1} ", sWhere, Convert.ToInt32(arrList[2]));
                        }

                        if (Convert.ToInt32(arrList[4]) != -1)
                        {
                            if ((bool)arrList[5] == true)
                                sWhere = String.Format("{0} AND YHLX = {1} ", sWhere, Convert.ToInt32(arrList[4]));
                            else
                                sWhere = String.Format("{0} AND DISTYPE = {1} ", sWhere, Convert.ToInt32(arrList[4]));
                        }

                        if ((bool)arrList[6] == true)
                        {
                            if ((bool)arrList[3] == true)
                                sWhere = String.Format("{0} AND TURN_DATE >= '{1}' AND TURN_DATE <= '{2}' ", sWhere, arrList[7], arrList[8]);
                            else
                                sWhere = String.Format("{0} AND BOOK_DATE >= '{1}' AND BOOK_DATE <= '{2}' ", sWhere, arrList[7], arrList[8]);
                        }

                        if ((bool)arrList[3] == true)
                        {
                            sSql = String.Format("{0} SELECT '' 序号,DBO.FUN_GETEMPNAME(TURN_USERID) AS '交款人',TURN_ID,TURN_DATE AS '交款时间',TURN_BDATE AS '开始时间', TURN_EDATE AS '结束时间',TURN_FEE AS '交款总额',BOOK_DATE AS '操作时间',DBO.FUN_GETEMPNAME(BOOK_USER) AS '操作人' FROM ZY_YH_YHJK WHERE JGBM = {1} {2} UNION ALL SELECT '99999 AS '序号,'合计' AS '交款人', NULL AS 'TURN_ID',NULL AS '交款时间',NULL AS '开始时间',NULL AS '结束时间',SUM(TURN_FEE) AS '交款总额',NULL AS '操作时间', NULL AS '操作人' FROM ZY_YH_YHJK WHERE JGBM = {1}{2} ORDER BY TURN_DATE DESC ", sSql, Convert.ToInt32(arrList[9]), sWhere);
                        }
                        else
                        {
                            sSql = String.Format("{0} SELECT '' AS '序号',INPATIENT_NO AS '住院号',BRXM AS '病人姓名',JE AS '金额',KLXMC AS '优惠类型',SFZH AS '身份证号',DBO.FUN_GETEMPNAME(BOOK_USER) AS '操作员',BOOK_DATE AS '统计时间' FROM ZY_YH_DJXX A LEFT JOIN JC_KLX B ON B.ID = A.DISTYPE WHERE  DELETE_BIT = 0 AND JGBM = {1} {2}  UNION ALL SELECT '99999' AS '序号', '合计'  AS '住院号',NULL  AS '病人姓名',SUM(JE) AS '金额',NULL  AS '优惠类型',NULL  AS '身份证号',NULL AS '操作员', NULL AS '统计时间' FROM ZY_YH_DJXX  WHERE  DELETE_BIT = 0 AND JGBM = {1} {2} ORDER BY BOOK_DATE DESC ", sSql, Convert.ToInt32(arrList[9]), sWhere);
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
        public static DataTable SpmShipingSpecialOffer(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT * FROM ZY_YH_DJXX WHERE INPATIENT_ID = '{1}' AND DELETE_BIT = 0 AND ISYH = 1 AND DISTYPE = '{2}'  AND CZ_FLAG = 0 AND JGBM = {3} ", sSql, arrList[0], arrList[1], Convert.ToInt32(arrList[2]));
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
        public static void SpmShipingSpecialOfferAdd(ArrayList arrList, RelationalDatabase dataBase)
        {
            string[] sSql = new string[3];
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql[0] = String.Format("{0} UPDATE ZY_YH_YHWH SET YE = '{1}' WHERE ID = '{2}' AND DELETE_BIT = 0 AND JGBM = {3} ", sSql[0], Convert.ToDecimal(arrList[0]), arrList[1], Convert.ToInt32(arrList[2]));
                        sSql[1] = String.Format("{0} INSERT INTO ZY_YH_DJXX(ID,INPATIENT_ID,INPATIENT_NO,BRXM,JE,DISTYPE,SFZH,PATIENT_ID,BOOK_USER,BOOK_DATE,JGBM,YHWH_ID) VALUES  ('{1}','{2}','{3}','{4}', '{5:0.00}','{6}','{7}', '{8}',{9},'{10}',{11},'{12}') ", sSql[1], arrList[3], arrList[4], arrList[5], arrList[6], Convert.ToDecimal(arrList[7]), Convert.ToInt32(arrList[8]), arrList[9], arrList[10], Convert.ToInt32(arrList[11]), arrList[12], Convert.ToInt32(arrList[2]), arrList[13]);
                        sSql[2] = String.Format("{0} UPDATE ZY_YH_DJXX SET PJH = '{1}' WHERE ID = '{2}' AND DELETE_BIT = 0 AND CZ_FLAG = 0 AND JGBM = {3} ", sSql[2], arrList[14], arrList[3], Convert.ToInt32(arrList[2]));
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
        public static void SpmShipingSpecialOfferModify(ArrayList arrList, RelationalDatabase dataBase)
        {
            string[] sSql = new string[5];
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql[0] = String.Format("{0} UPDATE ZY_YH_YHWH SET YE = '{1}' WHERE ID = '{2}' AND DELETE_BIT = 0 AND JGBM = {3} ", sSql[0], Convert.ToDecimal(arrList[2]), arrList[0], Convert.ToInt32(arrList[1]));
                        sSql[1] = String.Format("{0} UPDATE ZY_YH_YHWH SET YE = '{1}' WHERE ID = '{2}' AND DELETE_BIT = 0 AND JGBM = {3} ", sSql[1], Convert.ToDecimal(arrList[3]), arrList[0], Convert.ToInt32(arrList[1]));
                        sSql[2] = String.Format("{0} UPDATE ZY_YH_DJXX SET CZ_FALG = 1 WHERE ID = '{1}' AND JGBM = {2} ", sSql[2], arrList[4], Convert.ToInt32(arrList[1]));
                        sSql[3] = String.Format("{0} INSERT INTO ZY_YH_DJXX(ID,INPATIENT_ID,INPATIENT_NO,BRXM,JE,DISTYPE,SFZH,PATIENT_ID,BOOK_USER,BOOK_DATE,JGBM,YHWH_ID,ISYH,CZ_FLAG,CZ_ID)  SELECT DBO.FUN_GETGUID(NEWID(),GETDATE(),INPATIENT_ID,INPATIENT_NO,BRXM,(-1) * JE,DISTYPE,SFZH,PATIENT_ID,BOOK_USER,BOOK_DATE,JGBM,YHWH_ID,ISYH,2,'{1}') WHERE ID = '{1}' AND JGBM = {2} ", sSql[3], arrList[4], Convert.ToInt32(arrList[1]));
                        sSql[4] = String.Format("{0} INSERT INTO ZY_YH_DJXX(ID,INPATIENT_ID,INPATIENT_NO,BRXM,JE,DISTYPE,SFZH,PATIENT_ID,BOOK_USER,BOOK_DATE,JGBM,YHWH_ID)  SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),INPATIENT_ID,INPATIENT_NO,BRXM,'{1:0.00}',  DISTYPE,SFZH,PATIENT_ID,{2},GETDATE(),JGBM,'{3}' WHERE ID = '{4}' AND JGBM = {5} ", sSql[4], Convert.ToDecimal(arrList[5]), Convert.ToInt32(arrList[6]), arrList[7], arrList[4], Convert.ToInt32(arrList[1]));
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
        public static void SpmShipingSpecialOfferDel(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} UPDATE ZY_YH_DJXX SET DELETE_BIT = 1 WHERE ID = '{1}' AND JGBM = {2} ", sSql, arrList[0], Convert.ToInt32(arrList[1]));
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
        public static DataTable SpmShipingSpecialOfferQuery(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            string sWhere = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) != 0)
                            sWhere = String.Format("{0} AND A.DISTYPE = {1} ", sWhere, Convert.ToInt32(arrList[0]));
                        if (arrList[1] != "" && Convert.ToInt32(arrList[1]) != 0)
                            sWhere = String.Format("{0} AND A.INPATIENT_NO = '{1}' ", sWhere, arrList[1]);

                        sSql = String.Format("{0} SELECT '' 序号,B.KLXMC 优惠类型,A.INPATIENT_NO 住院号,A.BRXM 病人姓名,A.SFZH 身份证号,C.SEX_NAME 性别,C.AGE 年龄,DBO.FUN_GETDEPTNAME(C.DEPT_ID) 科室,A.JE 金额,DBO.FUN_GETEMPNAME(BOOK_USER) 操作员,BOOK_DATE 操作时间,A.ID ID,A.DISTYPE KLX,A.YHWH_ID PERFERID FROM ZY_YH_DJXX A LEFT JOIN JC_KLX B ON A.DISTYPE = B.ID LEFT JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID = C.INPATIENT_ID WHERE (BOOK_USER = {1} OR {1} = -1) AND A.JGBM = {2} AND DELETE_BIT = 0 AND BABY_ID = 0 AND A.CZ_FLAG = 0 {3}ORDER BY A.ID DESC ", sSql, Convert.ToInt32(arrList[2]), Convert.ToInt32(arrList[3]), sWhere);
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
        public static DataTable SpmShipingLoadView(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT A.INPATIENT_ID,A.BABY_ID,LTRIM(RTRIM(A.INPATIENT_NO)) AS INPATIENT_NO,A.PATIENT_ID, ";
                        sSql = sSql + " CASE WHEN A.FLAG < 4 AND A.FLAG <> 2 THEN '' WHEN A.FLAG = 4 THEN '○' WHEN A.FLAG = 5 THEN '●' WHEN A.FLAG = 2 THEN '☆' ELSE '★' END + LTRIM(RTRIM(A.NAME)) AS NAME,A.FLAG,SEX_NAME AS SEX,CUR_DEPT_NAME AS DEPT, ";
                        sSql = sSql + " A.SOCIAL_NO,A.HOME_STREET,A.BED_NO,CASE WHEN A.DISCHARGETYPE = 1 THEN YBLX_NAME ELSE JSFS_NAME END AS DISCHARGETYPE, ";
                        sSql = sSql + " A.XZLX_NAME,A.DYLX_NAME,BRLX_NAME AS PATIENTTYPE,DBO.FUN_GETDATE(A.IN_DATE) AS INDATE,DBO.FUN_GETDATE(A.OUT_DATE) AS OUTDATE ";
                        sSql = sSql + " FROM VI_ZY_VINPATIENT_ALL A INNER JOIN ZY_YH_YHWH B ON B.SFZH = A.SOCIAL_NO ";
                        sSql = String.Format("{0} AND B.YHLX = {1} AND DELETE_BIT = 0 ", sSql, Convert.ToInt32(arrList[0]));
                        sSql = String.Format("{0} WHERE A.FLAG <> 10 AND (A.INPATIENT_NO = '{1}') AND A.FLAG IN (2,6) ORDER BY IN_DATE DESC ", sSql, arrList[1]);
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
        public static DataTable SpmGetDischargeSelfFee(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT SELF_FEE FROM ZY_DISCHARGE A INNER JOIN VI_ZY_VINPATIENT_ALL B ON A.INPATIENT_ID = B.INPATIENT_ID WHERE B.INPATIENT_NO = '{1}' AND A.CANCEL_BIT = 0 AND A.CZ_FLAG = 0 AND BABY_ID = 0 ORDER BY IN_DATE DESC ", sSql, arrList[0]);
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
        public static DataTable SpmGetSpecialOfeerFee(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT ID,YE FROM ZY_YH_YHWH A INNER JOIN VI_ZY_VINPATIENT_ALL B ON A.SFZH = B.SOCIAL_NO WHERE B.INPATIENT_NO = '{1}' AND BABY_ID = 0 AND YHLX = {2} ORDER BY IN_DATE DESC ", sSql, arrList[0], Convert.ToInt32(arrList[1]));
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
        public static DataTable SpmShipingPaymenyCheck(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT * FROM ZY_YH_DJXX WHERE ID = '{1}' AND DELETE_BIT = 0 AND CZ_FLAG = 0 AND ISYH = 1 AND TRUN_BIT = 1 AND JGBM = {2} ", sSql, arrList[0], Convert.ToInt32(arrList[1]));
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