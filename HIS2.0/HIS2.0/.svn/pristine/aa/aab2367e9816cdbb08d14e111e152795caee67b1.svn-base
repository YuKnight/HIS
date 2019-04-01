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
 * 名称：医保退费登记数据库访问类
 * 描述：适用于医保退费登记中的数据库访问
 * 编写时间：2013-10
 * 作者：Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class MedicareRefundRegistDataBaseAccessClass
    {
        public static DataTable MrrLoadData(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT ID,0 AS ROWNO,(SELECT NAME FROM JC_YBLX WHERE ID = YBLX) YBLX,INPATIENT_NO,BILLNO,NAME,NFEE,DEPTFEE,SHOULDRECEDE,ACTUALRECEDE, ";
                        sSql = sSql + " BOOKDATE,BZ,DBO.FUN_GETEMPNAME(BOOKUSER) DJY,YBLX YBLXID FROM ZY_INSURERECORD ";
                        sSql = String.Format("{0} WHERE BOOKDATE >= '{1}' AND BOOKDATE <= '{2}' {3} ORDER BY ID ", sSql, arrList[0], arrList[1], (Convert.ToString(arrList[2]) != "-1" ? " AND BOOKUSER = " + arrList[2] : ""));
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
        public static DataTable MrrQueryInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT (SELECT NAME FROM JC_YBLX WHERE ID = YBLX) 病人类型,' ' + INPATIENT_NO AS 住院号,BILLNO 发票号,NAME AS 姓名 ";
                        sSql = sSql + " DEPTFEE AS 欠费,SHOULDRECEDE AS 应退金额,ACTUALRECEDE AS 实退金额,BOOKDATE AS 登记时间,DBO.FUN_ZY_SEEKEMPLOYEENAME(BOOKUSER) AS 登记人, ";
                        sSql = sSql + " BZ 备注 FROM ZY_INSURERECORD ";
                        sSql = String.Format("{0} WHERE BOOKDATE >= '{1}' AND BOOKDATE <= '{2}'{3} ORDER BY ID ", sSql, arrList[0], arrList[1], Convert.ToString(arrList[2] != "-1" ? " AND BOOKUSER = " + arrList[3] : ""));
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
        public static void MrrDelMedicalInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} DELETE FROM ZY_INSURERECORD WHERE BOOKUSER = {1} AND ID = {2} ", sSql, Convert.ToInt32(arrList[0]), arrList[1]);
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
        public static DataTable MrrInvoiceNumberSearch(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT INPATIENT_NO,NAME,B.YBLX,LACK_FEE 欠费 FROM ZY_DISCHARGE A INNER JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID AND BILLNO = '{1}' AND CZ_FLAG = 0 ", sSql, arrList[0]);
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
        public static DataTable MrrOutpatientNumberSearch(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT BLH,BRXM FROM MZ_GHXX A INNER JOIN YY_BRXX B WHERE A.BRXXID = B.BRXXID AND BLH = '{1}' ", sSql, arrList[0]);
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
        public static int MrrInsurerecordModify(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} UPDATE ZY_INSURERECORD SET INPATIENT_NO = '{1}',NAME = '{2}',DEPTFEE = {3}, ", sSql, arrList[0], arrList[1], arrList[2]);
                        sSql = String.Format("{0} SHOULDRECEDE = {1},ACTUALRECEDE = {2},YBLX = {3},BZ = '{4}' ", sSql, arrList[3], arrList[4], arrList[5], arrList[6]);
                        sSql = String.Format("{0} WHERE ID = {1} ", sSql, arrList[7]);
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
            return dataBase.DoCommand(sSql);
        }
        public static DataTable MrrInsurerecordQuery(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT * FROM ZY_INSURERECORD WHERE BILLNO = '{1}' AND YBLX = {2} ", sSql, arrList[0], arrList[1]);
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
        public static int MrrInsurerecordAdd(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " INSERT INTO ZY_INSURERECORD (INPATIENT_NO,NAME,NFEE,DEPTFEE,SHOULDRECEDE,ACTUALRECEDE,BOOKUSER,BOOKDATE,YBLX,BZ,BILLNO,JGBM) ";
                        sSql = String.Format("{0} VALUES ('{1}','{2}',0,{3},{4},{5},{6},GETDATE(),{7},'{8}','{9}',{10}) ", sSql, arrList[0], arrList[1], arrList[2], arrList[3], arrList[4], arrList[5], arrList[6], arrList[7], arrList[8], arrList[9]);
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
            return dataBase.DoCommand(sSql);
        }
        public static DataRow MrrGetFillPatientInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if ((bool)arrList[0] == true)  //出院病人
                        {
                            sSql = String.Format("{0} SELECT * FROM VI_ZY_VINPATIENT_ALL WHERE INPATIENT_NO = '{1}' AND BABY_ID = 0 AND FLAG IN (2,6) AND FLAG <> 0 ORDER BY OUT_DATE DESC ", sSql, arrList[1]);
                        }
                        else  //在院病人
                        {
                            sSql = String.Format("{0} SELECT * FROM VI_ZY_VINPATIENT_ALL WHERE INPATIENT_NO = '{1}' AND BABY_ID = 0 AND FLAG NOT IN (2,6,10)", sSql, arrList[1]);
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
            return dataBase.GetDataRow(sSql);
        }
        public static DataTable MrrGetInsureFeeInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if ((bool)arrList[0] == true)  //出院病人
                        {
                            sSql = String.Format("{0} SELECT * FROM ZY_YB_JSB WHERE INPATIENT_ID = '{1}' AND YBLX = {2} AND CZ_FLAG = 0 AND DELETE_BIT = 0 AND DISCHARGE_BIT = 1", sSql, arrList[1], Convert.ToInt32(arrList[2]));
                        }
                        else  //在院病人
                        {
                            sSql = String.Format("{0} SELECT * FROM ZY_YB_JSB WHERE INPATIENT_ID = '{1}' AND YBLX = {2} AND CZ_FLAG = 0 AND DELETE_BIT = 0 AND DISCHARGE_BIT = 0 ", sSql, arrList[1], Convert.ToInt32(arrList[2]));
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
            return dataBase.GetDataTable(sSql);
        }
        public static int MrrInsureFillSave(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            int resultCount = 0;
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " INSERT INTO ZY_INSUREFILL (INPATIENTID,INPATIENTNO,NAME,YBLX,HISFEE,YBFEE,TCFEE,ZHFEE,GRFEE,QTFEE,BSFEE,BOOKDATE,BOOKID,BOOKNAME,DELETEBIT) ";
                        sSql = String.Format("{0} VALUES ('{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},'{12}',{13},'{14}',0) ", sSql, arrList[0], arrList[1], arrList[2], arrList[3], arrList[4], arrList[5], arrList[6], arrList[7], arrList[8], arrList[9], arrList[10], arrList[11], arrList[12], arrList[13]);
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
            resultCount = dataBase.DoCommand(sSql);
            return resultCount;
        }
    }
}
