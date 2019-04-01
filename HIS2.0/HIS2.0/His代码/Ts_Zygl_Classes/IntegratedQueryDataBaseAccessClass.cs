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
 * 名称：住院综合查询数据库访问类
 * 描述：适用于住院综合查询中的数据库访问
 * 编写时间：2013-10
 * 作者：Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class IntegratedQueryDataBaseAccessClass
    {
        /// <summary>
        /// 住院综合查询--费用大项
        /// 存储过程--SP_ZY_ZHCX_FYDX
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="babyId">婴儿ID 婴儿的单独判断</param>
        /// <param name="beginDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="isType">统计类型 0=不按日期1=按日期</param>
        /// <param name="tableTmp">临时表</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryMajorItems(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        #region SQL

                        const string tableName = "VI_ZY_FEE_SPECI";  //主表

                        sSql = sSql + " SELECT 序号,代码,发票项目,金额,自付金额,结算标志 ";
                        sSql = sSql + " FROM ( ";
                        /*****************开始****************/
                        sSql = sSql + " SELECT 0 序号,代码,发票项目,金额,自付金额,结算标志 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT C.CODE 代码,C.ITEM_NAME 发票项目,SUM(ACVALUE) 金额,SUM(CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END) 自付金额, ";
                        sSql = sSql + " CASE WHEN DISCHARGE_BIT=0 THEN '' ELSE '√' END 结算标志,C.SORT_ID ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD F ON F.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YBLX G ON D.YBLX=G.ID ";
                        sSql = sSql + " LEFT JOIN JC_YBJKLX H ON G.YBJKLX=H.YBJKLX ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND ((CASE WHEN A.XMLY=1 THEN ISNULL(H.YPBM,'YP') ELSE ISNULL(H.XMBM,'XM') END)+CONVERT(VARCHAR,(CASE WHEN A.XMLY=1 THEN F.GGID ELSE A.XMID END)))=E.HSBM ";
                        sSql = String.Format("{0} WHERE A.CHARGE_BIT=1 AND A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}'", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}'))", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = sSql + " GROUP BY C.CODE,C.ITEM_NAME,C.SORT_ID,A.DISCHARGE_BIT ) A WHERE 结算标志 = '' ";
                        /***********第一段完成************/
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 2 序号,代码,发票项目,金额,自付金额,结算标志 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT C.CODE 代码,C.ITEM_NAME 发票项目,SUM(ACVALUE) 金额,SUM(CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END) 自付金额, ";
                        sSql = sSql + " CASE WHEN DISCHARGE_BIT=0 THEN '' ELSE '√' END 结算标志,C.SORT_ID ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD F ON F.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YBLX G ON D.YBLX=G.ID ";
                        sSql = sSql + " LEFT JOIN JC_YBJKLX H ON G.YBJKLX=H.YBJKLX ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND ((CASE WHEN A.XMLY=1 THEN ISNULL(H.YPBM,'YP') ELSE ISNULL(H.XMBM,'XM') END)+CONVERT(VARCHAR,(CASE WHEN A.XMLY=1 THEN F.GGID ELSE A.XMID END)))=E.HSBM ";
                        sSql = String.Format("{0} WHERE A.CHARGE_BIT=1 AND A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}'", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}'))", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = sSql + " GROUP BY C.CODE,C.ITEM_NAME,C.SORT_ID,A.DISCHARGE_BIT ) B WHERE 结算标志 = '√' ";
                        /***********第二段完成************/
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 1 序号,'' 代码,'*** 未结算小计 ***' 发票项目,SUM(金额) 金额,SUM(自付金额) 自付金额,'' 结算标志 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT C.CODE 代码,C.ITEM_NAME 发票项目,SUM(ACVALUE) 金额,SUM(CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END) 自付金额, ";
                        sSql = sSql + " CASE WHEN DISCHARGE_BIT=0 THEN '' ELSE '√' END 结算标志,C.SORT_ID ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD F ON F.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YBLX G ON D.YBLX=G.ID ";
                        sSql = sSql + " LEFT JOIN JC_YBJKLX H ON G.YBJKLX=H.YBJKLX ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND ((CASE WHEN A.XMLY=1 THEN ISNULL(H.YPBM,'YP') ELSE ISNULL(H.XMBM,'XM') END)+CONVERT(VARCHAR,(CASE WHEN A.XMLY=1 THEN F.GGID ELSE A.XMID END)))=E.HSBM ";
                        sSql = String.Format("{0} WHERE A.CHARGE_BIT=1 AND A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}'", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}'))", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = sSql + " GROUP BY C.CODE,C.ITEM_NAME,C.SORT_ID,A.DISCHARGE_BIT  ) C WHERE 结算标志 = '' ";  //ORDER BY C.SORT_ID
                        /***********第三段完成************/
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 3 序号,'' 代码,'*** 结算小计 ***' 发票项目,SUM(金额) 金额,SUM(自付金额) 自付金额,'√' 结算标志 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT C.CODE 代码,C.ITEM_NAME 发票项目,SUM(ACVALUE) 金额,SUM(CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END) 自付金额, ";
                        sSql = sSql + " CASE WHEN DISCHARGE_BIT=0 THEN '' ELSE '√' END 结算标志,C.SORT_ID ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD F ON F.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YBLX G ON D.YBLX=G.ID ";
                        sSql = sSql + " LEFT JOIN JC_YBJKLX H ON G.YBJKLX=H.YBJKLX ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND ((CASE WHEN A.XMLY=1 THEN ISNULL(H.YPBM,'YP') ELSE ISNULL(H.XMBM,'XM') END)+CONVERT(VARCHAR,(CASE WHEN A.XMLY=1 THEN F.GGID ELSE A.XMID END)))=E.HSBM ";
                        sSql = String.Format("{0} WHERE A.CHARGE_BIT=1 AND A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}'", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}'))", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = sSql + " GROUP BY C.CODE,C.ITEM_NAME,C.SORT_ID,A.DISCHARGE_BIT ) D WHERE 结算标志 = '√' ";
                        /***********第四段完成************/
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 4 序号,'' 代码,'合计' 发票项目,SUM(金额) 金额,SUM(自付金额) 自付金额,NULL 结算标志 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT C.CODE 代码,C.ITEM_NAME 发票项目,SUM(ACVALUE) 金额,SUM(CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END) 自付金额, ";
                        sSql = sSql + " CASE WHEN DISCHARGE_BIT=0 THEN '' ELSE '√' END 结算标志,C.SORT_ID ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD F ON F.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YBLX G ON D.YBLX=G.ID ";
                        sSql = sSql + " LEFT JOIN JC_YBJKLX H ON G.YBJKLX=H.YBJKLX ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND ((CASE WHEN A.XMLY=1 THEN ISNULL(H.YPBM,'YP') ELSE ISNULL(H.XMBM,'XM') END)+CONVERT(VARCHAR,(CASE WHEN A.XMLY=1 THEN F.GGID ELSE A.XMID END)))=E.HSBM ";
                        sSql = String.Format("{0} WHERE A.CHARGE_BIT=1 AND A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}'", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}'))", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = sSql + " GROUP BY C.CODE,C.ITEM_NAME,C.SORT_ID,A.DISCHARGE_BIT ) E  ";
                        /**************第五段完成******************/
                        sSql = sSql + " ) F ORDER BY 序号 ";

                        #endregion
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
        /// 住院综合查询--费用汇总
        /// 存储过程--SP_ZY_ZHCX_FYHZ
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="babyId">婴儿ID 婴儿的单独判断</param>
        /// <param name="beginDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="isType">统计类型 0=不按日期1=按日期</param>
        /// <param name="classCode">分类代码，如果为空则是全部，不为空就根据医院要求来传输代码，一般为发票项目代码</param>
        /// <param name="tableTmp">临时表</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryFeePool(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        #region SQL

                        const string tableName = "VI_ZY_FEE_SPECI";  //主表

                        //自付比例的计算还要比对最高限价，最高限价针对单价

                        sSql = sSql + " SELECT 序号,代码,项目名称,规格,厂家,单位,数量,金额,自付比例,自付金额,发票代码,发票项目,XMID,XMLY,医保编码 ";
                        sSql = sSql + " FROM ( ";
                        /********************开始********************/
                        sSql = sSql + " SELECT 0 序号,代码,项目名称,规格,厂家,单位,数量,金额,自付比例,自付金额,发票代码,发票项目,XMID,XMLY,医保编码 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT SUBCODE 代码,A.ITEM_NAME 项目名称,GG 规格,CJ 厂家,UNIT 单位,SUM(NUM) 数量,SUM(ACVALUE) 金额,CONVERT(VARCHAR,ISNULL(E.ZFBL,1)*100)+'%' 自付比例, ";
                        sSql = sSql + " SUM(CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END) 自付金额, ";
                        sSql = sSql + " C.CODE 发票代码,C.ITEM_NAME 发票项目,A.XMID,A.XMLY,HSBM 医保编码 ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD F ON F.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YBLX G ON D.YBLX=G.ID ";
                        sSql = sSql + " LEFT JOIN JC_YBJKLX H ON G.YBJKLX=H.YBJKLX ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND ((CASE WHEN A.XMLY=1 THEN ISNULL(H.YPBM,'YP') ELSE ISNULL(H.XMBM,'XM') END)+CONVERT(VARCHAR,(CASE WHEN A.XMLY=1 THEN F.GGID ELSE A.XMID END)))=E.HSBM ";
                        sSql = sSql + " WHERE A.CHARGE_BIT=1 AND A.DELETE_BIT=0 ";
                        sSql = String.Format("{0} AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}'", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}'))", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = String.Format("{0} AND ('{1}'='' OR C.CODE='{1}') ", sSql, arrList[5]);
                        sSql = sSql + " GROUP BY SUBCODE,A.ITEM_NAME,GG,CJ,UNIT,C.CODE,C.ITEM_NAME,A.XMID,A.XMLY,E.ZFBL,HSBM ) A ";
                        /********************第一段完成********************/
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 1 序号,'' 代码,'*** '+发票项目+'小计 ***' 项目名称,'' 规格,'' 厂家,'' 单位,NULL 数量,SUM(金额) 金额,'',SUM(自付金额),发票代码,发票项目,NULL XMID,NULL XMLY,'' 医保编码 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT SUBCODE 代码,A.ITEM_NAME 项目名称,GG 规格,CJ 厂家,UNIT 单位,SUM(NUM) 数量,SUM(ACVALUE) 金额,CONVERT(VARCHAR,ISNULL(E.ZFBL,1)*100)+'%' 自付比例, ";
                        sSql = sSql + " SUM(CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END) 自付金额, ";
                        sSql = sSql + " C.CODE 发票代码,C.ITEM_NAME 发票项目,A.XMID,A.XMLY,HSBM 医保编码 ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD F ON F.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YBLX G ON D.YBLX=G.ID ";
                        sSql = sSql + " LEFT JOIN JC_YBJKLX H ON G.YBJKLX=H.YBJKLX ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND ((CASE WHEN A.XMLY=1 THEN ISNULL(H.YPBM,'YP') ELSE ISNULL(H.XMBM,'XM') END)+CONVERT(VARCHAR,(CASE WHEN A.XMLY=1 THEN F.GGID ELSE A.XMID END)))=E.HSBM ";
                        sSql = sSql + " WHERE A.CHARGE_BIT=1 AND A.DELETE_BIT=0 ";
                        sSql = String.Format("{0} AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}'", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}'))", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = String.Format("{0} AND ('{1}'='' OR C.CODE='{1}') ", sSql, arrList[5]);
                        sSql = sSql + " GROUP BY SUBCODE,A.ITEM_NAME,GG,CJ,UNIT,C.CODE,C.ITEM_NAME,A.XMID,A.XMLY,E.ZFBL,HSBM ) B GROUP BY 发票代码,发票项目 ";
                        /********************第二段完成********************/
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 2 序号,'' 代码,'合计' 项目名称,'' 规格,'' 厂家,'' 单位,NULL 数量,SUM(金额) 金额,'',SUM(自付金额),'zz' 发票代码,'' 发票项目,NULL XMID,NULL XMLY,'' 医保编码 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT SUBCODE 代码,A.ITEM_NAME 项目名称,GG 规格,CJ 厂家,UNIT 单位,SUM(NUM) 数量,SUM(ACVALUE) 金额,CONVERT(VARCHAR,ISNULL(E.ZFBL,1)*100)+'%' 自付比例, ";
                        sSql = sSql + " SUM(CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END) 自付金额, ";
                        sSql = sSql + " C.CODE 发票代码,C.ITEM_NAME 发票项目,A.XMID,A.XMLY,HSBM 医保编码 ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD F ON F.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YBLX G ON D.YBLX=G.ID ";
                        sSql = sSql + " LEFT JOIN JC_YBJKLX H ON G.YBJKLX=H.YBJKLX ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND ((CASE WHEN A.XMLY=1 THEN ISNULL(H.YPBM,'YP') ELSE ISNULL(H.XMBM,'XM') END)+CONVERT(VARCHAR,(CASE WHEN A.XMLY=1 THEN F.GGID ELSE A.XMID END)))=E.HSBM ";
                        sSql = sSql + " WHERE A.CHARGE_BIT=1 AND A.DELETE_BIT=0 ";
                        sSql = String.Format("{0} AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}'", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}'))", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = String.Format("{0} AND ('{1}'='' OR C.CODE='{1}') ", sSql, arrList[5]);
                        sSql = sSql + " GROUP BY SUBCODE,A.ITEM_NAME,GG,CJ,UNIT,C.CODE,C.ITEM_NAME,A.XMID,A.XMLY,E.ZFBL,HSBM ) C ";
                        /********************第三段完成********************/
                        sSql = sSql + " ) D ORDER BY 发票代码,序号 ";

                        #endregion

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
        /// 住院综合查询--费用明细
        /// 存储过程--SP_ZY_ZHCX_FYMX
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="babyId">婴儿ID</param>
        /// <param name="beginDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="isType">统计类型 0=不按日期1=按日期</param>
        /// <param name="classCode">分类代码，如果为空则是全部，不为空就根据医院要求来传输代码，一般为发票项目代码</param>
        /// <param name="itemId">项目ID</param>
        /// <param name="itemSource">项目来源</param>
        /// <param name="orderId"></param>
        /// <param name="tableTmp">临时表</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryFeeDetail(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        #region SQL

                        const string tableName = "VI_ZY_FEE_SPECI";  //主表
                        //Add By Tany 2015-05-12 增加ORDER_ID
                        sSql = sSql + " SELECT 序号,处方日期,代码,项目名称,规格,厂家,单位,单价,数量,剂数,金额,记账日期,记账员, 状态,上传标志,下嘱医生,管床医生,";
                        sSql = sSql + " 开单科室,病人科室,执行科室,领药科室,统领方式,发药标志,发药日期,发药单号,发药人,操作时间,操作员,自付比例,自付金额,";
                        sSql = sSql + " 发票代码,发票项目, XMID,XMLY,医保编码,ORDER_ID  ";
                        sSql = sSql + " FROM ( ";
                        /**************开始**************/
                        sSql = sSql + " SELECT 0 序号,处方日期,代码,项目名称,规格,厂家,单位,单价,数量,剂数,金额,记账日期,记账员, 状态,上传标志,下嘱医生,管床医生,";
                        sSql = sSql + " 开单科室,病人科室,执行科室,领药科室,统领方式,发药标志,发药日期,发药单号,发药人,操作时间,操作员,自付比例,自付金额,";
                        sSql = sSql + " 发票代码,发票项目, XMID,XMLY,医保编码,ORDER_ID   ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT DBO.FUN_GETDATE(A.PRESC_DATE) 处方日期,A.SUBCODE 代码,A.ITEM_NAME 项目名称,GG 规格,CJ 厂家,UNIT 单位,A.RETAIL_PRICE 单价,";
                        sSql = sSql + " NUM 数量,A.DOSAGE 剂数,ACVALUE 金额,CHARGE_DATE 记账日期,DBO.FUN_GETEMPNAME(CHARGE_USER) 记账员,";
                        sSql = sSql + " CASE CZ_FLAG WHEN 0 THEN '正常' WHEN 1 THEN '被冲正' WHEN 2 THEN '冲正' WHEN 3 THEN '取消冲正' ELSE '' END 状态,";
                        sSql = sSql + " CASE A.SCBZ WHEN 1 THEN '√' ELSE '' END 上传标志,DBO.FUN_GETEMPNAME(DOC_ID) 下嘱医生,DBO.FUN_GETEMPNAME(GCYS) 管床医生,";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(A.DEPT_ID) 开单科室,DBO.FUN_GETDEPTNAME(DEPT_BR) 病人科室,";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(EXECDEPT_ID) 执行科室,DBO.FUN_GETDEPTNAME(A.DEPT_LY) 领药科室,";
                        sSql = sSql + " CASE TLFS WHEN 0 THEN '统领' WHEN 1 THEN '缺药' WHEN 3 THEN '出院带药' WHEN 5 THEN '处方领药' ELSE '其他' END 统领方式,";
                        sSql = sSql + " CASE FY_BIT WHEN 1 THEN '√' ELSE '' END 发药标志,FY_DATE 发药日期,F.DJH 发药单号,";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(FY_USER) 发药人,A.BOOK_DATE 操作时间,DBO.FUN_GETEMPNAME(BOOK_USER) 操作员,";
                        sSql = sSql + " CONVERT(VARCHAR,ISNULL(E.ZFBL,1)*100)+'%' 自付比例,";
                        sSql = sSql + " CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END 自付金额,";
                        sSql = sSql + " C.CODE 发票代码,C.ITEM_NAME 发票项目,A.XMID,A.XMLY,HSBM 医保编码,ORDER_ID  ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD G ON G.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YBLX I ON D.YBLX=I.ID ";
                        sSql = sSql + " LEFT JOIN JC_YBJKLX H ON I.YBJKLX=H.YBJKLX ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND ((CASE WHEN A.XMLY=1 THEN ISNULL(H.YPBM,'YP') ELSE ISNULL(H.XMBM,'XM') END)+CONVERT(VARCHAR,(CASE WHEN A.XMLY=1 THEN G.GGID ELSE A.XMID END)))=E.HSBM ";
                        sSql = sSql + " LEFT JOIN YF_TLD F ON A.GROUP_ID=F.GROUPID ";
                        sSql = sSql + " WHERE A.CHARGE_BIT=1 AND A.DELETE_BIT=0 ";
                        sSql = String.Format("{0} AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}' ", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}'))", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = String.Format("{0} AND ('{1}'='' OR C.CODE='{1}')", sSql, arrList[5]);
                        sSql = String.Format("{0} AND ({1} in (-1,0) OR (A.XMID={1} AND A.XMLY={2}))", sSql, Convert.ToInt32(arrList[6]), Convert.ToInt32(arrList[7]));
                        sSql = String.Format("{0} AND ('{1}'=DBO.FUN_GETEMPTYGUID() OR A.ORDER_ID='{1}')", sSql, arrList[8]);
                        sSql = sSql + "  ) A ";
                        /**************第一段完成**************/
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 1 序号,NULL 处方日期,NULL 代码,'*** '+发票项目+'小计 ***' 项目名称, NULL 规格,NULL 厂家,NULL 单位,NULL 单价,";
                        sSql = sSql + " SUM(数量),NULL 剂数,SUM(金额),NULL 记账日期,NULL 记账员,NULL 状态,NULL 上传标志,NULL 下嘱医生,NULL 管床医生,";
                        sSql = sSql + " NULL 开单科室,NULL 病人科室,NULL 执行科室,NULL 领药科室,NULL 统领方式,NULL 发药标志,NULL 发药日期,NULL 发药单号,";
                        sSql = sSql + " NULL 发药人,NULL 操作时间,NULL 操作员,NULL 自付比例,SUM(自付金额),发票代码,发票项目, NULL XMID,NULL XMLY,'' 医保编码,NULL ORDER_ID ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT DBO.FUN_GETDATE(A.PRESC_DATE) 处方日期,A.SUBCODE 代码,A.ITEM_NAME 项目名称,GG 规格,CJ 厂家,UNIT 单位,A.RETAIL_PRICE 单价,";
                        sSql = sSql + " NUM 数量,A.DOSAGE 剂数,ACVALUE 金额,CHARGE_DATE 记账日期,DBO.FUN_GETEMPNAME(CHARGE_USER) 记账员,";
                        sSql = sSql + " CASE CZ_FLAG WHEN 0 THEN '正常' WHEN 1 THEN '被冲正' WHEN 2 THEN '冲正' WHEN 3 THEN '取消冲正' ELSE '' END 状态,";
                        sSql = sSql + " CASE A.SCBZ WHEN 1 THEN '√' ELSE '' END 上传标志,DBO.FUN_GETEMPNAME(DOC_ID) 下嘱医生,DBO.FUN_GETEMPNAME(GCYS) 管床医生,";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(A.DEPT_ID) 开单科室,DBO.FUN_GETDEPTNAME(DEPT_BR) 病人科室,";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(EXECDEPT_ID) 执行科室,DBO.FUN_GETDEPTNAME(A.DEPT_LY) 领药科室,";
                        sSql = sSql + " CASE TLFS WHEN 0 THEN '统领' WHEN 1 THEN '缺药' WHEN 3 THEN '出院带药' WHEN 5 THEN '处方领药' ELSE '其他' END 统领方式,";
                        sSql = sSql + " CASE FY_BIT WHEN 1 THEN '√' ELSE '' END 发药标志,FY_DATE 发药日期,F.DJH 发药单号,";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(FY_USER) 发药人,A.BOOK_DATE 操作时间,DBO.FUN_GETEMPNAME(BOOK_USER) 操作员,";
                        sSql = sSql + " CONVERT(VARCHAR,ISNULL(E.ZFBL,1)*100)+'%' 自付比例,";
                        sSql = sSql + " CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END 自付金额,";
                        sSql = sSql + " C.CODE 发票代码,C.ITEM_NAME 发票项目,A.XMID,A.XMLY,HSBM 医保编码 ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD G ON G.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YBLX I ON D.YBLX=I.ID ";
                        sSql = sSql + " LEFT JOIN JC_YBJKLX H ON I.YBJKLX=H.YBJKLX ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + "  AND ((CASE WHEN A.XMLY=1 THEN ISNULL(H.YPBM,'YP') ELSE ISNULL(H.XMBM,'XM') END)+CONVERT(VARCHAR,(CASE WHEN A.XMLY=1 THEN G.GGID ELSE A.XMID END)))=E.HSBM ";
                        sSql = sSql + " LEFT JOIN YF_TLD F ON A.GROUP_ID=F.GROUPID ";
                        sSql = sSql + " WHERE A.CHARGE_BIT=1 AND A.DELETE_BIT=0 ";
                        sSql = String.Format("{0} AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}' ", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}'))", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = String.Format("{0} AND ('{1}'='' OR C.CODE='{1}')", sSql, arrList[5]);
                        sSql = String.Format("{0} AND ({1} in (-1,0) OR (A.XMID={1} AND A.XMLY={2}))", sSql, Convert.ToInt32(arrList[6]), Convert.ToInt32(arrList[7]));
                        sSql = String.Format("{0} AND ('{1}'=DBO.FUN_GETEMPTYGUID() OR A.ORDER_ID='{1}')", sSql, arrList[8]);
                        sSql = sSql + ") B GROUP BY 发票代码,发票项目 ";
                        /**************第二段完成**************/
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 2 序号,NULL 处方日期,NULL 代码,'合计' 项目名称,NULL 规格,NULL 厂家,NULL 单位,NULL 单价,NULL 数量,NULL 剂数,SUM(金额),";
                        sSql = sSql + " NULL 记账日期,NULL 记账员,NULL 状态,NULL 上传标志,NULL 下嘱医生,NULL 管床医生, NULL 开单科室,NULL 病人科室,NULL 执行科室,NULL 领药科室,";
                        sSql = sSql + " NULL 统领方式,NULL 发药标志,NULL 发药日期,NULL 发药单号,NULL 发药人,NULL 操作时间,NULL 操作员,NULL 自付比例,SUM(自付金额),";
                        sSql = sSql + " 'zz' 发票代码,NULL 发票项目, NULL XMID,NULL XMLY,'' 医保编码,NULL ORDER_ID ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT DBO.FUN_GETDATE(A.PRESC_DATE) 处方日期,A.SUBCODE 代码,A.ITEM_NAME 项目名称,GG 规格,CJ 厂家,UNIT 单位,A.RETAIL_PRICE 单价,";
                        sSql = sSql + " NUM 数量,A.DOSAGE 剂数,ACVALUE 金额,CHARGE_DATE 记账日期,DBO.FUN_GETEMPNAME(CHARGE_USER) 记账员,";
                        sSql = sSql + " CASE CZ_FLAG WHEN 0 THEN '正常' WHEN 1 THEN '被冲正' WHEN 2 THEN '冲正' WHEN 3 THEN '取消冲正' ELSE '' END 状态,";
                        sSql = sSql + " CASE A.SCBZ WHEN 1 THEN '√' ELSE '' END 上传标志,DBO.FUN_GETEMPNAME(DOC_ID) 下嘱医生,DBO.FUN_GETEMPNAME(GCYS) 管床医生,";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(A.DEPT_ID) 开单科室,DBO.FUN_GETDEPTNAME(DEPT_BR) 病人科室,";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(EXECDEPT_ID) 执行科室,DBO.FUN_GETDEPTNAME(A.DEPT_LY) 领药科室,";
                        sSql = sSql + " CASE TLFS WHEN 0 THEN '统领' WHEN 1 THEN '缺药' WHEN 3 THEN '出院带药' WHEN 5 THEN '处方领药' ELSE '其他' END 统领方式,";
                        sSql = sSql + " CASE FY_BIT WHEN 1 THEN '√' ELSE '' END 发药标志,FY_DATE 发药日期,F.DJH 发药单号,";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(FY_USER) 发药人,A.BOOK_DATE 操作时间,DBO.FUN_GETEMPNAME(BOOK_USER) 操作员,";
                        sSql = sSql + " CONVERT(VARCHAR,ISNULL(E.ZFBL,1)*100)+'%' 自付比例,";
                        sSql = sSql + " CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END 自付金额,";
                        sSql = sSql + " C.CODE 发票代码,C.ITEM_NAME 发票项目,A.XMID,A.XMLY,HSBM 医保编码 ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD G ON G.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YBLX I ON D.YBLX=I.ID ";
                        sSql = sSql + " LEFT JOIN JC_YBJKLX H ON I.YBJKLX=H.YBJKLX ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND ((CASE WHEN A.XMLY=1 THEN ISNULL(H.YPBM,'YP') ELSE ISNULL(H.XMBM,'XM') END)+CONVERT(VARCHAR,(CASE WHEN A.XMLY=1 THEN G.GGID ELSE A.XMID END)))=E.HSBM ";
                        sSql = sSql + " LEFT JOIN YF_TLD F ON A.GROUP_ID=F.GROUPID ";
                        sSql = sSql + " WHERE A.CHARGE_BIT=1 AND A.DELETE_BIT=0 ";
                        sSql = String.Format("{0} AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}' ", sSql, arrList[1]);
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}'))", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = String.Format("{0} AND ('{1}'='' OR C.CODE='{1}')", sSql, arrList[5]);
                        sSql = String.Format("{0} AND ({1} in (-1,0) OR (A.XMID={1} AND A.XMLY={2}))", sSql, Convert.ToInt32(arrList[6]), Convert.ToInt32(arrList[7]));
                        sSql = String.Format("{0} AND ('{1}'=DBO.FUN_GETEMPTYGUID() OR A.ORDER_ID='{1}')", sSql, arrList[8]);
                        sSql = sSql + "  ) C  ";  //ORDER BY A.PRESC_DATE,A.ORDER_ID,A.TYPE
                        /**************第三段完成**************/
                        sSql = sSql + " ) D ORDER BY 发票代码,序号,XMID,XMLY,处方日期 ";

                        #endregion
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
        /// 住院综合查询--医嘱费用
        /// 存储过程--SP_ZY_ZHCX_YZFY
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="babyId">婴儿ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryDoctorsFee(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        string tableName = "ZY_ORDERRECORD";
                        int nStatus = 0;
                        nStatus = Convert.ToInt32(Convertor.IsNull(dataBase.GetDataResult(String.Format("SELECT TOP 1 NSTATUS FROM ZY_DISCHARGE WHERE CANCEL_BIT=0 AND CZ_FLAG=0 AND NTYPE<>0 AND INPATIENT_ID='{0}'", arrList[0])), "0"));
                        if (nStatus != 0)
                            tableName = "ZY_ORDERRECORD_H";

                        sSql = sSql + " SELECT CASE MNGTYPE WHEN 0 THEN 0 WHEN 1 THEN 1 WHEN 5 THEN 1 WHEN 2 THEN 2 WHEN 3 THEN 3 ELSE '99' END 序号, ";
                        sSql = sSql + " CASE MNGTYPE WHEN 0 THEN '长嘱' WHEN 1 THEN '临嘱' WHEN 5 THEN '临嘱' WHEN 2 THEN '长账' WHEN 3 THEN '临账' ELSE '' END 类别, ";
                        sSql = sSql + " (SELECT NAME FROM JC_ORDERTYPE WHERE CODE = A.NTYPE) 类型, ";
                        sSql = sSql + " A.ORDER_BDATE 开始时间,A.ORDER_CONTEXT 医嘱内容,A.ORDER_SPEC 规格, ";
                        sSql = sSql + " DATEDIFF(DAY,A.ORDER_BDATE,ISNULL(A.LASTEXECDATE,GETDATE())) + 1 执行天数, ";
                        sSql = sSql + " DBO.FUN_ZY_GETORDERFEE(A.ORDER_ID) 费用, ";
                        sSql = sSql + " A.NUM 剂量,A.UNIT 单位,A.ORDER_USAGE 用法,A.FREQUENCY 频率,A.DROPSPER 滴量,A.DOSAGE 剂数, ";
                        sSql = sSql + " FIRST_TIMES 首次,TERMINAL_TIMES 末次,A.ORDER_EDATE 停嘱时间, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(A.ORDER_DOC) 下嘱医生, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(A.ORDER_DOC) 停嘱医生, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(A.AUDITING_USER) 开嘱转抄, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(ORDER_EUSER) 停嘱转抄, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(A.DEPT_ID) 开单科室, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(A.EXEC_DEPT) 执行科室, ";
                        sSql = sSql + " A.ORDER_ID ID,A.GROUP_ID 嘱号 ";
                        sSql = String.Format("{0} FROM {1} A", sSql, tableName);
                        sSql = String.Format("{0} WHERE (A.INPATIENT_ID = '{1}')", sSql, arrList[0]);
                        sSql = String.Format("{0} AND (A.BABY_ID = '{1}')", sSql, Convert.ToInt32(arrList[1]));
                        //Add By Tany 2015-05-12
                        if (arrList[2].ToString().Trim() != "")
                        {
                            sSql = String.Format("{0} AND (A.GROUP_ID IN (SELECT GROUP_ID FROM {2} WHERE ORDER_ID='{1}'))", sSql, arrList[2], tableName);
                        }
                        sSql = sSql + " AND (A.DELETE_BIT = 0) ";
                        sSql = sSql + " AND (A.STATUS_FLAG >= 2 AND A.STATUS_FLAG <= 5) ";
                        sSql = sSql + " ORDER BY 序号,A.ORDER_BDATE,嘱号,SERIAL_NO ";
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
        /// 住院综合查询--转科信息
        /// 存储过程--SP_ZY_ZHCX_ZKXX
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="babyId">婴儿ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryTransferInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT 0 序号,TRANSFER_DATE 转科时间,DBO.FUN_ZY_SEEKDEPTNAME(D.S_DEPT_ID) 源科室, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKDEPTNAME(D.D_DEPT_ID) 目标科室,BOOK_DATE 登记时间, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(D.OPERATOR) 操作员 ";
                        sSql = sSql + " FROM ZY_TRANSFER_DEPT D ";
                        sSql = String.Format("{0} WHERE INPATIENT_ID='{1}' AND BABY_ID={2} AND FINISH_BIT=1 AND CANCEL_BIT=0", sSql, arrList[0], Convert.ToInt32(arrList[1]));
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
        /// 住院综合查询--预交信息
        /// 存储过程--SP_ZY_ZHCX_YJXX
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryDepositsInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT 序号,操作,方式,金额,票据号,到帐时间,操作员,担保人,担保单位 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT 0 序号,CASE WHEN NTRANS = 10 THEN '预交' WHEN NTRANS = 20 THEN '退款' ELSE '未知' END AS 操作, ";
                        //sSql = sSql + " CASE NMODE WHEN 1 THEN '现金' WHEN 2 THEN '转账' WHEN 3 THEN 'POS' ELSE '' END 方式, ";
                        sSql = sSql + " DBO.FUN_ZY_GETFKFSNAME(NMODE) AS 方式,NVALUES AS 金额, BILLNO AS 票据号, ARRIVE_DATE AS 到帐时间, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(ARRIVE_USERID) AS 操作员,'' 担保人,'' 担保单位 ";
                        sSql = String.Format("{0} FROM ZY_DEPOSITS WHERE CANCEL_BIT = 0 AND NTRANS IN (10,20) AND INPATIENT_ID = '{1}'", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 1 序号,'预交合计' AS 操作,'' 方式,SUM(金额) 金额, NULL AS 票据号, NULL AS 到帐时间,'' AS 操作员,'' 担保人,'' 担保单位 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT 0 序号,CASE WHEN NTRANS = 10 THEN '预交' WHEN NTRANS = 20 THEN '退款' ELSE '未知' END AS 操作, ";
                        //sSql = sSql + " CASE NMODE WHEN 1 THEN '现金' WHEN 2 THEN '转账' WHEN 3 THEN 'POS' ELSE '' END 方式, ";
                        sSql = sSql + " DBO.FUN_ZY_GETFKFSNAME(NMODE) AS 方式,NVALUES AS 金额, BILLNO AS 票据号, ARRIVE_DATE AS 到帐时间, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(ARRIVE_USERID) AS 操作员,'' 担保人,'' 担保单位 ";
                        sSql = String.Format("{0} FROM ZY_DEPOSITS WHERE CANCEL_BIT = 0 AND NTRANS IN (10,20) AND INPATIENT_ID = '{1}' ) A ", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 2 序号,'担保' 操作,'' 方式,VOUCHVALUE AS 金额,'' 票据号,OPERATEDATE AS 到帐时间, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(OPERATEUSER) AS 操作员,VOUCHPERSON 担保人,VOUCHUNIT 担保单位 ";
                        sSql = String.Format("{0} FROM ZY_VOUCH WHERE INPATIENT_ID = '{1}'", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 3 序号,'担保合计' AS 操作,'' 方式,SUM(金额) 金额, NULL AS 票据号, NULL AS 到帐时间,'' AS 操作员,'' 担保人,'' 担保单位 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT 2 序号,'担保' 操作,'' 方式,VOUCHVALUE AS 金额,'' 票据号,OPERATEDATE AS 到帐时间, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(OPERATEUSER) AS 操作员,VOUCHPERSON 担保人,VOUCHUNIT 担保单位 ";
                        sSql = String.Format("{0} FROM ZY_VOUCH WHERE INPATIENT_ID = '{1}' ) B ", sSql, arrList[0]);
                        sSql = sSql + " ) C ";
                        sSql = sSql + " ORDER BY 序号,到帐时间 ";
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
        /// 住院综合查询--结算信息
        /// 存储过程--SP_ZY_ZHCX_JSXX
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryDischargeInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT 0 序号,DBO.FUN_ZY_SEEKJSMODENAME(NTYPE) AS 结算方式,DISCHARGE_DATE 结算日期,BILLNO 发票号,NFEE 总费用, ";
                        sSql = sSql + " DEPTOSITS 预交金,YB_FEE 医保支付,SELF_FEE 自付,PATCH_FEE 补收,RECEDE_FEE 退款,SAVE_FEE 暂存,LACK_FEE 欠费, ";
                        sSql = sSql + " AGIO_FEE 优惠,AGIONAME 优惠类型,DISCHARGE_BDATE 结算开始日期,DISCHARGE_EDATE 结算结束日期, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(CAST(USERID AS BIGINT)) AS 操作员,CASE CZ_FLAG WHEN 0 THEN '正常' WHEN 1 THEN '被取消' WHEN 2 THEN '取消' END 状态 ";
                        sSql = String.Format("{0} FROM ZY_DISCHARGE WHERE CANCEL_BIT = 0 AND INPATIENT_ID = '{1}' ORDER BY DISCHARGE_DATE ", sSql, arrList[0]);
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
        /// 住院综合查询--未记账费用明细
        /// 存储过程--SP_ZY_ZHCX_WJZFYMX
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="babyId">婴儿ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryNotAccountInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        const string tableName = "VI_ZY_FEE_SPECI";  //主表

                        sSql = sSql + " SELECT 序号,处方日期,代码,项目名称,规格,厂家,单位,单价,数量,剂数,金额,记账日期,记账员,状态,上传标志,下嘱医生,管床医生,开单科室,病人科室, ";
                        sSql = sSql + " 执行科室,领药科室,统领方式,发药标志,发药日期,发药单号,发药人,操作时间,操作员,自付比例,自付金额,发票代码,发票项目,XMID,XMLY ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT 0 序号,处方日期,代码,项目名称,规格,厂家,单位,单价,数量,剂数,金额,记账日期,记账员,状态,上传标志,下嘱医生,管床医生,开单科室,病人科室, ";
                        sSql = sSql + " 执行科室,领药科室,统领方式,发药标志,发药日期,发药单号,发药人,操作时间,操作员,自付比例,自付金额,发票代码,发票项目,XMID,XMLY ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT DBO.FUN_GETDATE(A.PRESC_DATE) 处方日期,A.SUBCODE 代码,A.ITEM_NAME 项目名称,GG 规格,CJ 厂家,UNIT 单位,A.RETAIL_PRICE 单价, ";
                        sSql = sSql + " NUM 数量,A.DOSAGE 剂数,ACVALUE 金额,CHARGE_DATE 记账日期,DBO.FUN_GETEMPNAME(CHARGE_USER) 记账员, ";
                        sSql = sSql + " CASE CZ_FLAG WHEN 0 THEN '正常' WHEN 1 THEN '被冲正' WHEN 2 THEN '冲正' WHEN 3 THEN '取消冲正' ELSE '' END 状态, ";
                        sSql = sSql + " CASE A.SCBZ WHEN 1 THEN '√' ELSE '' END 上传标志, ";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(DOC_ID) 下嘱医生,DBO.FUN_GETEMPNAME(GCYS) 管床医生, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(A.DEPT_ID) 开单科室,DBO.FUN_GETDEPTNAME(DEPT_BR) 病人科室, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(EXECDEPT_ID) 执行科室,DBO.FUN_GETDEPTNAME(A.DEPT_LY) 领药科室, ";
                        sSql = sSql + " CASE TLFS WHEN 0 THEN '统领' WHEN 1 THEN '缺药' WHEN 3 THEN '出院带药' WHEN 5 THEN '处方领药' ELSE '其他' END 统领方式, ";
                        sSql = sSql + " CASE FY_BIT WHEN 1 THEN '√' ELSE '' END 发药标志,FY_DATE 发药日期,F.DJH 发药单号, ";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(FY_USER) 发药人,A.BOOK_DATE 操作时间,DBO.FUN_GETEMPNAME(BOOK_USER) 操作员, ";
                        sSql = sSql + " CONVERT(VARCHAR,ISNULL(E.ZFBL,1)*100)+'%' 自付比例, ";
                        sSql = sSql + " CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) 自付金额, ";
                        sSql = sSql + " C.CODE 发票代码,C.ITEM_NAME 发票项目, ";
                        sSql = sSql + " A.XMID,A.XMLY ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND (CASE WHEN A.XMLY=1 THEN (SELECT GGID FROM YP_YPCJD WHERE CJID=A.XMID) ELSE A.XMID END)=E.XMID ";
                        sSql = sSql + " LEFT JOIN YF_TLD F ON A.GROUP_ID=F.GROUPID ";
                        sSql = sSql + " WHERE CHARGE_BIT=0 AND DELETE_BIT=0 ";
                        sSql = String.Format("{0} AND A.INPATIENT_ID= '{1}' ", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}' ", sSql, Convert.ToInt32(arrList[1]));
                        //sSql = sSql + " ORDER BY A.PRESC_DATE,A.ORDER_ID,A.TYPE ";
                        sSql = sSql + " ) A ";
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 1 序号,NULL 处方日期,NULL 代码,'*** '+发票项目+'小计 ***' 项目名称,NULL 规格,NULL 厂家,NULL 单位,NULL 单价,SUM(数量),NULL 剂数,SUM(金额), ";
                        sSql = sSql + " NULL 记账日期,NULL 记账员,NULL 状态,NULL 上传标志,NULL 下嘱医生,NULL 管床医生,NULL 开单科室,NULL 病人科室,NULL 执行科室,NULL 领药科室, ";
                        sSql = sSql + " NULL 统领方式,NULL 发药标志,NULL 发药日期,NULL 发药单号,NULL 发药人,NULL 操作时间,NULL 操作员,NULL 自付比例,SUM(自付金额), ";
                        sSql = sSql + " 发票代码,发票项目,NULL XMID,NULL XMLY ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT DBO.FUN_GETDATE(A.PRESC_DATE) 处方日期,A.SUBCODE 代码,A.ITEM_NAME 项目名称,GG 规格,CJ 厂家,UNIT 单位,A.RETAIL_PRICE 单价, ";
                        sSql = sSql + " NUM 数量,A.DOSAGE 剂数,ACVALUE 金额,CHARGE_DATE 记账日期,DBO.FUN_GETEMPNAME(CHARGE_USER) 记账员, ";
                        sSql = sSql + " CASE CZ_FLAG WHEN 0 THEN '正常' WHEN 1 THEN '被冲正' WHEN 2 THEN '冲正' WHEN 3 THEN '取消冲正' ELSE '' END 状态, ";
                        sSql = sSql + " CASE A.SCBZ WHEN 1 THEN '√' ELSE '' END 上传标志, ";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(DOC_ID) 下嘱医生,DBO.FUN_GETEMPNAME(GCYS) 管床医生, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(A.DEPT_ID) 开单科室,DBO.FUN_GETDEPTNAME(DEPT_BR) 病人科室, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(EXECDEPT_ID) 执行科室,DBO.FUN_GETDEPTNAME(A.DEPT_LY) 领药科室, ";
                        sSql = sSql + " CASE TLFS WHEN 0 THEN '统领' WHEN 1 THEN '缺药' WHEN 3 THEN '出院带药' WHEN 5 THEN '处方领药' ELSE '其他' END 统领方式, ";
                        sSql = sSql + " CASE FY_BIT WHEN 1 THEN '√' ELSE '' END 发药标志,FY_DATE 发药日期,F.DJH 发药单号, ";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(FY_USER) 发药人,A.BOOK_DATE 操作时间,DBO.FUN_GETEMPNAME(BOOK_USER) 操作员, ";
                        sSql = sSql + " CONVERT(VARCHAR,ISNULL(E.ZFBL,1)*100)+'%' 自付比例, ";
                        sSql = sSql + " CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) 自付金额, ";
                        sSql = sSql + " C.CODE 发票代码,C.ITEM_NAME 发票项目, ";
                        sSql = sSql + " A.XMID,A.XMLY ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND (CASE WHEN A.XMLY=1 THEN (SELECT GGID FROM YP_YPCJD WHERE CJID=A.XMID) ELSE A.XMID END)=E.XMID ";
                        sSql = sSql + " LEFT JOIN YF_TLD F ON A.GROUP_ID=F.GROUPID ";
                        sSql = sSql + " WHERE CHARGE_BIT=0 AND DELETE_BIT=0 ";
                        sSql = String.Format("{0} AND A.INPATIENT_ID= '{1}' ", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}' ", sSql, Convert.ToInt32(arrList[1]));
                        //sSql = sSql + " ORDER BY A.PRESC_DATE,A.ORDER_ID,A.TYPE ";
                        sSql = sSql + " ) B GROUP BY 发票代码,发票项目 ";
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 2 序号,NULL 处方日期,NULL 代码,'合计' 项目名称,NULL 规格,NULL 厂家,NULL 单位,NULL 单价,NULL 数量,NULL 剂数,SUM(金额), ";
                        sSql = sSql + " NULL 记账日期,NULL 记账员,NULL 状态,NULL 上传标志,NULL 下嘱医生,NULL 管床医生,NULL 开单科室,NULL 病人科室,NULL 执行科室,NULL 领药科室, ";
                        sSql = sSql + " NULL 统领方式,NULL 发药标志,NULL 发药日期,NULL 发药单号,NULL 发药人,NULL 操作时间,NULL 操作员,NULL 自付比例,SUM(自付金额), ";
                        sSql = sSql + " 'zz' 发票代码,NULL 发票项目,NULL XMID,NULL XMLY ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT DBO.FUN_GETDATE(A.PRESC_DATE) 处方日期,A.SUBCODE 代码,A.ITEM_NAME 项目名称,GG 规格,CJ 厂家,UNIT 单位,A.RETAIL_PRICE 单价, ";
                        sSql = sSql + " NUM 数量,A.DOSAGE 剂数,ACVALUE 金额,CHARGE_DATE 记账日期,DBO.FUN_GETEMPNAME(CHARGE_USER) 记账员, ";
                        sSql = sSql + " CASE CZ_FLAG WHEN 0 THEN '正常' WHEN 1 THEN '被冲正' WHEN 2 THEN '冲正' WHEN 3 THEN '取消冲正' ELSE '' END 状态, ";
                        sSql = sSql + " CASE A.SCBZ WHEN 1 THEN '√' ELSE '' END 上传标志, ";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(DOC_ID) 下嘱医生,DBO.FUN_GETEMPNAME(GCYS) 管床医生, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(A.DEPT_ID) 开单科室,DBO.FUN_GETDEPTNAME(DEPT_BR) 病人科室, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(EXECDEPT_ID) 执行科室,DBO.FUN_GETDEPTNAME(A.DEPT_LY) 领药科室, ";
                        sSql = sSql + " CASE TLFS WHEN 0 THEN '统领' WHEN 1 THEN '缺药' WHEN 3 THEN '出院带药' WHEN 5 THEN '处方领药' ELSE '其他' END 统领方式, ";
                        sSql = sSql + " CASE FY_BIT WHEN 1 THEN '√' ELSE '' END 发药标志,FY_DATE 发药日期,F.DJH 发药单号, ";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(FY_USER) 发药人,A.BOOK_DATE 操作时间,DBO.FUN_GETEMPNAME(BOOK_USER) 操作员, ";
                        sSql = sSql + " CONVERT(VARCHAR,ISNULL(E.ZFBL,1)*100)+'%' 自付比例, ";
                        sSql = sSql + " CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) 自付金额, ";
                        sSql = sSql + " C.CODE 发票代码,C.ITEM_NAME 发票项目, ";
                        sSql = sSql + " A.XMID,A.XMLY ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX ";
                        sSql = sSql + " AND E.ZYBZ=1 AND A.XMLY=E.XMLY ";
                        sSql = sSql + " AND (CASE WHEN A.XMLY=1 THEN (SELECT GGID FROM YP_YPCJD WHERE CJID=A.XMID) ELSE A.XMID END)=E.XMID ";
                        sSql = sSql + " LEFT JOIN YF_TLD F ON A.GROUP_ID=F.GROUPID ";
                        sSql = sSql + " WHERE CHARGE_BIT=0 AND DELETE_BIT=0 ";
                        sSql = String.Format("{0} AND A.INPATIENT_ID= '{1}' ", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}' ", sSql, Convert.ToInt32(arrList[1]));
                        //sSql = sSql + " ORDER BY A.PRESC_DATE,A.ORDER_ID,A.TYPE ";
                        sSql = sSql + " ) C ";
                        sSql = sSql + " ) D ORDER BY 发票代码,序号,XMID,XMLY,处方日期 ";
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
        /// 住院综合查询--手术信息
        /// 存储过程--SP_ZY_ZHCX_SSXX
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryOperationInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {

                        sSql = sSql + " SELECT  序号,类型, 住院号,姓名, 性别 ,科室,术前诊断 ,拟施手术 , ";
                        sSql = sSql + " 主刀,拟施麻醉, 麻醉师,拟施时间,手术同意书,麻醉同意书,申请医生,申请时间,手术间,安排时间,完成时间,审核人 ";
                        sSql = sSql + " FROM ( ";
                        //未审核手术
                        sSql = sSql + " SELECT 0 序号,'未审核' 类型,INPATIENT_NO 住院号,姓名, 性别 ,科室, CASE WHEN 术前诊断='' THEN SSFZ ELSE 术前诊断 END 术前诊断 ,拟施手术 , ";
                        sSql = sSql + " 主刀,拟施麻醉, 麻醉师,拟施时间,手术同意书,麻醉同意书,申请医生,申请时间,NULL 手术间,NULL 安排时间,NULL 完成时间,审核人 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT DISTINCT A.SNO,A.INPATIENT_NO, A.INPATIENT_ID, C.NAME 姓名, DBO.FUN_ZY_SEEKSEXNAME(CAST(C.SEXCODE AS CHAR(4))) 性别, DBO.FUN_ZY_SEEKDEPTNAME(A.DEPTID) AS 科室, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKDISEASENAME(CAST(SSFZ AS CHAR(8))) 术前诊断, A.YSSS 拟施手术, DBO.FUN_ZY_SEEKEMPLOYEENAME(ZDYS) 主刀, ";
                        sSql = sSql + " S.NAME AS 拟施麻醉, DBO.FUN_ZY_SEEKEMPLOYEENAME(MZYS) 麻醉师, YSSSRQ 拟施时间, CASE WHEN SSTYS = 1 THEN '√' END 手术同意书, ";
                        sSql = sSql + " CASE WHEN MZTYS = 1 THEN '√' END 麻醉同意书, DBO.FUN_ZY_SEEKEMPLOYEENAME(SQDJCZY) 申请医生,SQDJCZY,A.SQDJRQ 申请时间,'' 手术间,'' 安排时间, DBO.FUN_ZY_SEEKEMPLOYEENAME(SHYS) 审核人,SSFZ ";
                        sSql = sSql + " FROM SS_APPRECORD A LEFT JOIN SS_ANESTHESIACODE S ON A.YSMZ=CAST(S.ID AS CHAR(10)) INNER JOIN ";
                        sSql = sSql + " VI_ZY_VINPATIENT C ON A.INPATIENT_ID = C.INPATIENT_ID ";
                        sSql = String.Format("{0}  WHERE (A.BDELETE = 0)  AND (A.INPATIENT_ID = '{1}') AND (A.APBJ = 0) AND SHBJ=0 AND JZSS=0) AA ", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        //已审核手术
                        sSql = sSql + " SELECT DISTINCT 1 序号,'已审核' 类型,INPATIENT_NO 住院号,姓名, 性别 ,科室, CASE WHEN 术前诊断='' THEN SSFZ ELSE 术前诊断 END 术前诊断 ,拟施手术 , ";
                        sSql = sSql + " 主刀,拟施麻醉, 麻醉师,拟施时间,手术同意书,麻醉同意书,申请医生,申请时间  ,NULL 手术间,NULL 安排时间,NULL 完成时间,审核人 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT A.SNO, A.INPATIENT_ID,A.INPATIENT_NO, C.NAME 姓名, DBO.FUN_ZY_SEEKSEXNAME(CAST(C.SEXCODE AS CHAR(4))) 性别, DBO.FUN_ZY_SEEKDEPTNAME(A.DEPTID) AS 科室, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKDISEASENAME(CAST(SSFZ AS CHAR(8))) 术前诊断, A.YSSS 拟施手术, DBO.FUN_ZY_SEEKEMPLOYEENAME(ZDYS) 主刀, ";
                        sSql = sSql + " S.NAME AS 拟施麻醉, DBO.FUN_ZY_SEEKEMPLOYEENAME(MZYS) 麻醉师, YSSSRQ 拟施时间, CASE WHEN SSTYS = 1 THEN '√' END 手术同意书, ";
                        sSql = sSql + " CASE WHEN MZTYS = 1 THEN '√' END 麻醉同意书, DBO.FUN_ZY_SEEKEMPLOYEENAME(SQDJCZY) 申请医生,A.SQDJRQ 申请时间,SSFZ  , DBO.FUN_ZY_SEEKEMPLOYEENAME(SHYS) 审核人 ";
                        sSql = sSql + " FROM SS_APPRECORD A LEFT JOIN SS_ANESTHESIACODE S ON A.YSMZ=CAST(S.ID AS CHAR(10)) INNER JOIN ";
                        sSql = sSql + " VI_ZY_VINPATIENT C ON A.INPATIENT_ID = C.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE (A.BDELETE = 0)  AND (A.INPATIENT_ID = '{1}') AND (A.APBJ = 0) AND SHBJ=1) AA ", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        //急诊手术
                        sSql = sSql + " SELECT DISTINCT 2 序号,'急诊' 类型,INPATIENT_NO 住院号,姓名, 性别 ,科室, CASE WHEN 术前诊断='' THEN SSFZ ELSE 术前诊断 END 术前诊断 ,拟施手术 , ";
                        sSql = sSql + " 主刀,拟施麻醉, 麻醉师,拟施时间,手术同意书,麻醉同意书,申请医生,申请时间,NULL 手术间,NULL 安排时间,NULL 完成时间,'' 审核人 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT A.SNO, A.INPATIENT_ID,A.INPATIENT_NO, C.NAME 姓名, DBO.FUN_ZY_SEEKSEXNAME(CAST(C.SEXCODE AS CHAR(4))) 性别, DBO.FUN_ZY_SEEKDEPTNAME(A.DEPTID) AS 科室, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKDISEASENAME(CAST(SSFZ AS CHAR(8))) 术前诊断, A.YSSS 拟施手术, DBO.FUN_ZY_SEEKEMPLOYEENAME(ZDYS) 主刀, ";
                        sSql = sSql + " S.NAME AS 拟施麻醉, DBO.FUN_ZY_SEEKEMPLOYEENAME(MZYS) 麻醉师, YSSSRQ 拟施时间, CASE WHEN SSTYS = 1 THEN '√' END 手术同意书, ";
                        sSql = sSql + " CASE WHEN MZTYS = 1 THEN '√' END 麻醉同意书, DBO.FUN_ZY_SEEKEMPLOYEENAME(SQDJCZY) 申请医生,SQDJCZY,A.SQDJRQ 申请时间,SSFZ ";
                        sSql = sSql + " FROM SS_APPRECORD A LEFT JOIN SS_ANESTHESIACODE S ON A.YSMZ=CAST(S.ID AS CHAR(10)) INNER JOIN ";
                        sSql = sSql + " VI_ZY_VINPATIENT C ON A.INPATIENT_ID = C.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE (A.BDELETE = 0)  AND (A.INPATIENT_ID = '{1}') AND (A.APBJ = 0) AND JZSS=1) AA ", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        //已安排手术
                        sSql = sSql + " SELECT DISTINCT 3 序号,'已安排' 类型,INPATIENT_NO 住院号,姓名, 性别 ,科室, CASE WHEN 术前诊断='' THEN SSFZ ELSE 术前诊断 END 术前诊断 ,拟施手术 , ";
                        sSql = sSql + " 主刀,拟施麻醉, 麻醉师,拟施时间,手术同意书,麻醉同意书,申请医生,申请时间,手术间,安排时间,NULL 完成时间,审核人 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT A.SNO, A.INPATIENT_ID,A.INPATIENT_NO, C.NAME 姓名, DBO.FUN_ZY_SEEKSEXNAME(CAST(C.SEXCODE AS CHAR(4))) 性别, DBO.FUN_ZY_SEEKDEPTNAME(A.DEPTID) AS 科室, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKDISEASENAME(CAST(SSFZ AS CHAR(8))) 术前诊断,A.YSSS 拟施手术, DBO.FUN_ZY_SEEKEMPLOYEENAME(ZDYS) 主刀, ";
                        sSql = sSql + " S.NAME AS 拟施麻醉, DBO.FUN_ZY_SEEKEMPLOYEENAME(MZYS) 麻醉师, YSSSRQ 拟施时间, CASE WHEN SSTYS = 1 THEN '√' END 手术同意书, ";
                        sSql = sSql + " CASE WHEN MZTYS = 1 THEN '√' END 麻醉同意书, DBO.FUN_ZY_SEEKEMPLOYEENAME(SQDJCZY) 申请医生,A.SQDJRQ 申请时间, E.NAME+D.NAME 手术间,  YXSSRQ 安排时间,SSFZ  , DBO.FUN_ZY_SEEKEMPLOYEENAME(SHYS) 审核人 ";
                        sSql = sSql + " FROM SS_APPRECORD A LEFT JOIN SS_ANESTHESIACODE S ON A.YSMZ=CAST(S.ID AS CHAR(10)) INNER JOIN ";
                        sSql = sSql + " SS_ARRRECORD B ON A.SNO = B.SNO INNER JOIN ";
                        sSql = sSql + " VI_ZY_VINPATIENT C ON A.INPATIENT_ID = C.INPATIENT_ID   LEFT JOIN ";
                        sSql = sSql + " SS_ROOMTC D ON B.SSTC=D.ID LEFT JOIN ";
                        sSql = sSql + " SS_ROOM E ON E.ID=D.ROOMID ";
                        sSql = String.Format("{0} WHERE (A.BDELETE = 0) AND (B.BDELETE = 0) AND (A.INPATIENT_ID = '{1}') AND (A.APBJ = 1) AND (B.WCBJ = 0)) AA ", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        //已取消手术
                        sSql = sSql + " SELECT DISTINCT 4 序号,'已取消' 类型,INPATIENT_NO 住院号,姓名, 性别 ,科室, CASE WHEN 术前诊断='' THEN SSFZ ELSE 术前诊断 END 术前诊断 ,拟施手术 , ";
                        sSql = sSql + " 主刀,拟施麻醉, 麻醉师,拟施时间,手术同意书,麻醉同意书,申请医生,申请时间,NULL 手术间,安排时间,完成时间,NULL 审核人 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT A.SNO, A.INPATIENT_ID,A.INPATIENT_NO, C.NAME 姓名, DBO.FUN_ZY_SEEKSEXNAME(CAST(C.SEXCODE AS CHAR(4))) 性别, DBO.FUN_ZY_SEEKDEPTNAME(A.DEPTID) AS 科室, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKDISEASENAME(CAST(SSFZ AS CHAR(8))) 术前诊断,A.YSSS 拟施手术, DBO.FUN_ZY_SEEKEMPLOYEENAME(ZDYS) 主刀, ";
                        sSql = sSql + " S.NAME AS 拟施麻醉, DBO.FUN_ZY_SEEKEMPLOYEENAME(MZYS) 麻醉师, YSSSRQ 拟施时间, CASE WHEN SSTYS = 1 THEN '√' END 手术同意书, ";
                        sSql = sSql + " CASE WHEN MZTYS = 1 THEN '√' END 麻醉同意书, DBO.FUN_ZY_SEEKEMPLOYEENAME(SQDJCZY) 申请医生,A.SQDJRQ 申请时间, YXSSRQ 安排时间, SSENDRQ 完成时间,SSFZ ";
                        sSql = sSql + " FROM SS_APPRECORD A LEFT JOIN SS_ANESTHESIACODE S ON A.YSMZ=CAST(S.ID AS CHAR(10)) INNER JOIN ";
                        sSql = sSql + " SS_ARRRECORD B ON A.SNO = B.SNO INNER JOIN ";
                        sSql = sSql + "  VI_ZY_VINPATIENT C ON A.INPATIENT_ID = C.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE (B.BDELETE = 1) AND (A.INPATIENT_ID = '{1}')) AA ", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        //已完成手术
                        sSql = sSql + " SELECT DISTINCT 5 序号,'已完成' 类型,INPATIENT_NO 住院号,姓名, 性别 ,科室, CASE WHEN 术前诊断='' THEN SSFZ ELSE 术前诊断 END 术前诊断 ,拟施手术 , ";
                        sSql = sSql + " 主刀,拟施麻醉, 麻醉师,拟施时间,手术同意书,麻醉同意书,申请医生,申请时间,手术间,安排时间,完成时间,审核人 ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + "SELECT A.SNO, A.INPATIENT_ID,A.INPATIENT_NO, C.NAME 姓名, DBO.FUN_ZY_SEEKSEXNAME(CAST(C.SEXCODE AS CHAR(4))) 性别, DBO.FUN_ZY_SEEKDEPTNAME(A.DEPTID) AS 科室, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKDISEASENAME(CAST(SSFZ AS CHAR(8))) 术前诊断,A.YSSS 拟施手术, DBO.FUN_ZY_SEEKEMPLOYEENAME(ZDYS) 主刀, ";
                        sSql = sSql + " S.NAME AS 拟施麻醉, DBO.FUN_ZY_SEEKEMPLOYEENAME(MZYS) 麻醉师, YSSSRQ 拟施时间, CASE WHEN SSTYS = 1 THEN '√' END 手术同意书, ";
                        sSql = sSql + " CASE WHEN MZTYS = 1 THEN '√' END 麻醉同意书, DBO.FUN_ZY_SEEKEMPLOYEENAME(SQDJCZY) 申请医生,A.SQDJRQ 申请时间, E.NAME+D.NAME 手术间,  YXSSRQ 安排时间,SSENDRQ 完成时间 ,SSFZ  , DBO.FUN_ZY_SEEKEMPLOYEENAME(SHYS) 审核人 ";
                        sSql = sSql + " FROM SS_APPRECORD A LEFT JOIN SS_ANESTHESIACODE S ON A.YSMZ=CAST(S.ID AS CHAR(10)) INNER JOIN ";
                        sSql = sSql + " SS_ARRRECORD B ON A.SNO = B.SNO INNER JOIN ";
                        sSql = sSql + " VI_ZY_VINPATIENT C ON A.INPATIENT_ID = C.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN ";
                        sSql = sSql + " SS_ROOMTC D ON B.SSTC=D.ID LEFT JOIN ";
                        sSql = sSql + " SS_ROOM E ON E.ID=D.ROOMID ";
                        sSql = String.Format("{0} WHERE (A.BDELETE = 0) AND (B.BDELETE = 0) AND (A.INPATIENT_ID = '{1}') AND (B.WCBJ = 1)) AA ", sSql, arrList[0]);
                        sSql = sSql + " ) A ORDER BY 序号,申请时间 ";

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
        /// 住院综合查询--医保试算
        /// 存储过程--SP_ZY_ZHCX_YBSS
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryMedicalTrial(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            DataTable daTable = null;

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {

                        int medicalInterfaceType = Convert.ToInt32(Convertor.IsNull(dataBase.GetDataResult(String.Format("SELECT YBJKLX FROM VI_ZY_VINPATIENT_ALL WHERE INPATIENT_ID='{0}' AND BABY_ID=0 AND FLAG<>10", arrList[0])), "0"));
                        if (medicalInterfaceType <= 0)
                            return daTable;

                        if (medicalInterfaceType == 7 || medicalInterfaceType == 9)  //创智铁路
                        {

                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,TOTAL_COST 本次计算总费用, XJ_QFX 起付线自付, XJ_MK 门槛自付, ";
                            sSql = sSql + " XJ_ZCZF 政策自付, XJ_BLZF 比例自付, XJ_QT 其他自付, B.TCZF 统筹支付, ";
                            sSql = sSql + " GRZHZF 个人帐户支付, GWYZF 公务员基金支付, DBZF 大病支付, LXZF 离休基金支付, ";
                            sSql = sSql + " BCZF 补充基金支付, B.QTZF 其他基金支付, B.XJZF 个人现金支付, JSZF 家属基金支付, ";
                            sSql = sSql + " HOSPITAL_PAY 平均费用时医院支付 ";
                            sSql = sSql + " ZY_YB_JSB_RJJL A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_CZTL_RJJL B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 4 || medicalInterfaceType == 11 || medicalInterfaceType == 13 || medicalInterfaceType == 17) //创智
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,TCJJ 医疗保险统筹基金, GRZH 医疗保险个人帐户, DBBZJJ 医疗保险大病救助基金, ";
                            sSql = sSql + " LXJJ 医疗保险离休基金, GWYBCJJ 公务员补充基金, SYBXJJ 生育保险基金,YLDFSYJJ 医疗垫付生育基金, YYZF 医院支付, B.XJZF 现金支付, QTJJ 其他基金 ";
                            sSql = sSql + " FROM ZY_YB_JSB_RJJL A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_CZSYB_RJJL B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 8 || medicalInterfaceType == 14)
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,YLFY 本次医疗费用, B.TCZF 本次统筹支出, DBZF 本次大病支出, B.ZHZF 本次帐户支出, ";
                            sSql = sSql + " B.XJZF 本次现金支出, GWYBZZF 本次公务员补助支出, GWYQFXBZ 本次公务员起伏线补助,GWYZLBZ 本次公务员自理补助, TCJSJE 本次进入统筹计算金额合计 ";
                            sSql = sSql + " FROM ZY_YB_JSB_RJJL A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_DRSYB_RJJL B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 1 || medicalInterfaceType == 12)  //长信
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,BCZFY 本次总费用, TSBZFY 特殊病种费用,BCBNZHZF 本次本年帐户支付, ";
                            sSql = sSql + " BCLNZHZF 本次历年帐户支付,LJFDZF 累计分段自付,TCJZF 统筹金支付,QFDZF 起付段支付,DWZF 单位支付,ZFFY 自费费用,TJXZF 特检先自付, ";
                            sSql = sSql + " TZXZF 特治先自付,TJFY 特检费用,TZFY 特治费用,BCYLBXZF 补充医疗保险支付, ";
                            sSql = sSql + " BCTCJRLJ 本次统筹记入累计,BCYLJRLJ 补充医疗记入累计,MZTCJRLJ 门诊统筹记入累计, ";
                            sSql = sSql + " WBXFY 未报销费用,YBZF 医保支付,GRXJZF 个人现金支付 ";
                            sSql = sSql + " FROM ZY_YB_JSB_RJJL A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_CXYB_RJJL B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID= '{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 10 || medicalInterfaceType == 16)  //长信新
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,FYZE 费用总额, FHBXFY 符合报销费用, QFDJE 起付段金额, FDZFJE 分段自付金额, ";
                            sSql = sSql + " FDJSTCJZF 分段计算统筹金支付, TJTZTCZFJE 特检特治统筹支付金额, ZHZFJE 账户支付金额, ";
                            sSql = sSql + " TCZFJE 统筹支付金额, GRZFJE 个人支付总额, CFDXZFJE 超封顶线自付金额, YJJZE 预缴金总额,QQLJ 前期累计 ";
                            sSql = sSql + " FROM ZY_YB_JSB_RJJL A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_CXXYB_RJJL B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 15)  //泰阳
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型, C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,TOTALCOSTS 住院总费用,ENABLEMONEY 保内费用,STARTMONEY 起付线,REDEEMMONEY 实际补偿金额, ";
                            sSql = sSql + " TOTALREDEEMMONEY 本年度累计住院补偿金额,TOTALREDEEMCOUNT 本年度累计住院补偿次数,FAMILYACCOUNTPAYMONEY 家庭账户支付金额, ";
                            sSql = sSql + " FROM ZY_YB_JSB_RJJL A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_TYXNH_RJJL B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";

                        }
                        else if (medicalInterfaceType == 18)  //桑达老
                        {

                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,B.DJH 单据号, B.GRZH 账户支付, B.TCJJ 统筹基金, B.GRZF 个人自付, B.GRZFZF 个人自费, B.HJFX 合计付现, B.DBHZ 大病互助 ";
                            sSql = sSql + " FROM ZY_YB_JSB_RJJL A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_SDLYB_RJJL B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 2)  //桑达南昌铁路医保
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,B.JBYBTCZF 基本医保统筹支付, B.BCYBTCZF 补充医保统筹支付, B.SYYBTCZF 商业医保统筹支付, ";
                            sSql = sSql + " B.DBHZTCZF 大病互助统筹支付, B.GRZHZF 个人帐户支付, B.GRZFJE 个人自付, B.GRZF 个人自费, ";
                            sSql = sSql + " B.QFJE 起付金额, B.CFDXZF 超封顶线自付, B.XJZF 现金支付 ";
                            sSql = sSql + " FROM ZY_YB_JSB_RJJL A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_SDYB_RJJL B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 20) //网通兴城职
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保结算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,B.ZFY 本次总费用,B.CWFY 除外费用,B.HSJE 核算金额,B.BCJE 补偿金额,B.BCGRZHZF 本次个人帐户支付, ";
                            sSql = sSql + " B.BCTCZF 本次统筹支付,B.BCDBZF 本次大病支付,B.GRXJZF 个人现金支付,B.GRZHYE 个人帐户余额, ";
                            sSql = sSql + " B.SYQQYE 使用前期余额,B.BCYYFD 本次医院负担,B.SYBXZFBZ 生育保险支付标准,B.SYZF 生育支付, ";
                            sSql = sSql + " B.QFXZFJE 起付线自付金额,B.BLDZFJE 比例段自付金额 ";
                            sSql = sSql + " FROM ZY_YB_JSB_RJJL A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_WTXYB_RJJL B ON A.YBJSID = B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID = C.INPATIENT_ID AND BABY_ID = 0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT = 0 AND A.INPATIENT_ID = '{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else  //其他
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付 ";
                            sSql = sSql + " FROM ZY_YB_JSB_RJJL A ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
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
        /// 住院综合查询--医保结算
        /// 存储过程--SP_ZY_ZHCX_YBJS
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryMedicalDischarge(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            DataTable daTable = null;

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        int medicalInterfaceType = Convert.ToInt32(Convertor.IsNull(dataBase.GetDataResult(String.Format("SELECT YBJKLX FROM VI_ZY_VINPATIENT_ALL WHERE INPATIENT_ID='{0}' AND BABY_ID=0 AND FLAG<>10", arrList[0])), "0"));
                        if (medicalInterfaceType <= 0)
                            return daTable;

                        if (medicalInterfaceType == 7 || medicalInterfaceType == 9)  //创智铁路
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保结算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,DBO.FUN_GETEMPNAME(A.YBJS_USER) 医保结算操作员, ";
                            sSql = sSql + " TOTAL_COST 本次计算总费用, XJ_QFX 起付线自付, XJ_MK 门槛自付,XJ_ZCZF 政策自付, XJ_BLZF 比例自付, XJ_QT 其他自付, B.TCZF 统筹支付, ";
                            sSql = sSql + " GRZHZF 个人帐户支付, GWYZF 公务员基金支付, DBZF 大病支付, LXZF 离休基金支付, ";
                            sSql = sSql + " BCZF 补充基金支付, B.QTZF 其他基金支付, B.XJZF 个人现金支付, JSZF 家属基金支付,HOSPITAL_PAY 平均费用时医院支付 ";
                            sSql = sSql + " FROM ZY_YB_JSB A  ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_CZTL B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 4 || medicalInterfaceType == 11 || medicalInterfaceType == 13 || medicalInterfaceType == 17) //创智
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保结算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,DBO.FUN_GETEMPNAME(A.YBJS_USER) 医保结算操作员, ";
                            sSql = sSql + " TCJJ 医疗保险统筹基金, GRZH 医疗保险个人帐户, DBBZJJ 医疗保险大病救助基金, ";
                            sSql = sSql + " LXJJ 医疗保险离休基金, GWYBCJJ 公务员补充基金, SYBXJJ 生育保险基金, ";
                            sSql = sSql + " YLDFSYJJ 医疗垫付生育基金, YYZF 医院支付, B.XJZF 现金支付, QTJJ 其他基金 ";
                            sSql = sSql + " FROM ZY_YB_JSB A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_CZSYB B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 8 || medicalInterfaceType == 14) //东软
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保结算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,DBO.FUN_GETEMPNAME(A.YBJS_USER) 医保结算操作员, ";
                            sSql = sSql + " YLFY 本次医疗费用, B.TCZF 本次统筹支出, DBZF 本次大病支出, B.ZHZF 本次帐户支出, ";
                            sSql = sSql + " B.XJZF 本次现金支出, GWYBZZF 本次公务员补助支出, GWYQFXBZ 本次公务员起伏线补助, ";
                            sSql = sSql + " GWYZLBZ 本次公务员自理补助, TCJSJE 本次进入统筹计算金额合计 ";
                            sSql = sSql + " FROM ZY_YB_JSB A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_DRSYB B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 1 || medicalInterfaceType == 12) //长信
                        {

                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型,";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保结算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,DBO.FUN_GETEMPNAME(A.YBJS_USER) 医保结算操作员, ";
                            sSql = sSql + " BCZFY 本次总费用, TSBZFY 特殊病种费用,BCBNZHZF 本次本年帐户支付,BCLNZHZF 本次历年帐户支付,LJFDZF 累计分段自付,TCJZF 统筹金支付, ";
                            sSql = sSql + " QFDZF 起付段支付,DWZF 单位支付,ZFFY 自费费用,TJXZF 特检先自付,TZXZF 特治先自付,TJFY 特检费用,TZFY 特治费用,BCYLBXZF 补充医疗保险支付, ";
                            sSql = sSql + " BCTCJRLJ 本次统筹记入累计,BCYLJRLJ 补充医疗记入累计,MZTCJRLJ 门诊统筹记入累计,WBXFY 未报销费用,YBZF 医保支付,GRXJZF 个人现金支付 ";
                            sSql = sSql + " FROM ZY_YB_JSB A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_CXYB B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 10 || medicalInterfaceType == 16) //长信新
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保结算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,FYZE 费用总额, FHBXFY 符合报销费用, QFDJE 起付段金额, FDZFJE 分段自付金额, ";
                            sSql = sSql + " FDJSTCJZF 分段计算统筹金支付, TJTZTCZFJE 特检特治统筹支付金额, ZHZFJE 账户支付金额, ";
                            sSql = sSql + " TCZFJE 统筹支付金额, GRZFJE 个人支付总额, CFDXZFJE 超封顶线自付金额, YJJZE 预缴金总额,QQLJ 前期累计 ";
                            sSql = sSql + " FROM ZY_YB_JSB A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_CXXYB B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 15) //泰阳
                        {

                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型, C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,TOTALCOSTS 住院总费用,ENABLEMONEY 保内费用,STARTMONEY 起付线,REDEEMMONEY 实际补偿金额, ";
                            sSql = sSql + " TOTALREDEEMMONEY 本年度累计住院补偿金额,TOTALREDEEMCOUNT 本年度累计住院补偿次数,FAMILYACCOUNTPAYMONEY 家庭账户支付金额, ";
                            sSql = sSql + " FROM ZY_YB_JSB A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_TYXNH B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 18)  //桑达
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,B.DJH 单据号, B.GRZH 账户支付, B.TCJJ 统筹基金, B.GRZF 个人自付, B.GRZFZF 个人自费, B.HJFX 合计付现, B.DBHZ 大病互助 ";
                            sSql = sSql + " FROM ZY_YB_JSB A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_SDLYB B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}'", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 2)  //桑达南昌铁路
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,B.JBYBTCZF 基本医保统筹支付, B.BCYBTCZF 补充医保统筹支付, B.SYYBTCZF 商业医保统筹支付, ";
                            sSql = sSql + " B.DBHZTCZF 大病互助统筹支付, B.GRZHZF 个人帐户支付, B.GRZFJE 个人自付, B.GRZF 个人自费, ";
                            sSql = sSql + " B.QFJE 起付金额, B.CFDXZF 超封顶线自付, B.XJZF 现金支付 ";
                            sSql = sSql + " FROM ZY_YB_JSB A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_SDYB B ON A.YBJSID=B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else if (medicalInterfaceType == 20) //网通兴城职
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保结算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付,B.ZFY 本次总费用,B.CWFY 除外费用,B.HSJE 核算金额,B.BCJE 补偿金额,B.BCGRZHZF 本次个人帐户支付, ";
                            sSql = sSql + " B.BCTCZF 本次统筹支付,B.BCDBZF 本次大病支付,B.GRXJZF 个人现金支付,B.GRZHYE 个人帐户余额, ";
                            sSql = sSql + " B.SYQQYE 使用前期余额,B.BCYYFD 本次医院负担,B.SYBXZFBZ 生育保险支付标准,B.SYZF 生育支付, ";
                            sSql = sSql + " B.QFXZFJE 起付线自付金额,B.BLDZFJE 比例段自付金额 ";
                            sSql = sSql + " FROM ZY_YB_JSB A ";
                            sSql = sSql + " LEFT JOIN ZY_YB_JSB_WTXYB B ON A.YBJSID = B.YBJSID ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID = C.INPATIENT_ID AND BABY_ID = 0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT = 0 AND A.INPATIENT_ID = '{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
                        }
                        else  //其他
                        {
                            sSql = sSql + " SELECT 0 序号,C.INPATIENT_NO 住院号,C.NAME 姓名,C.YBLX_NAME 医保类型,C.XZLX_NAME 险种类型,C.DYLX_NAME 待遇类型, ";
                            sSql = sSql + " C.RYZD 入院诊断,C.CYZD 出院诊断,YBJS_DATE 医保试算日期,YBJSH 医保结算号,A.ZFY 总费用,A.TCZF 统筹支付,A.ZHZF 账户支付, ";
                            sSql = sSql + " A.XJZF 现金支付,A.QTZF 其他支付 ";
                            sSql = sSql + " FROM ZY_YB_JSB A ";
                            sSql = sSql + " INNER JOIN VI_ZY_VINPATIENT_ALL C ON A.INPATIENT_ID=C.INPATIENT_ID AND BABY_ID=0 ";
                            sSql = String.Format("{0} WHERE A.DELETE_BIT=0 AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY YBJS_DATE DESC ";
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
        /// 住院综合查询--病人信息
        /// 存储过程--SP_ZY_ZHCX_BRXX
        /// </summary>
        /// <param name="inpatientId">住院ID</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryPatientInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        int medicalType = 0;
                        string medicalTypeName = "";
                        int medicalTypeLog = 0;
                        string medicalTypeNameLog = "";
                        medicalType = Convert.ToInt32(Convertor.IsNull(dataBase.GetDataResult(String.Format("SELECT YBLX FROM VI_ZY_VINPATIENT WHERE INPATIENT_ID='{0}'", arrList[0])), "0"));
                        //Modify By Kevin 2013-11-21 取医保日志表找住院号的第一条原始记录是否是自费
                        medicalTypeLog = Convert.ToInt32(Convertor.IsNull(dataBase.GetDataResult(String.Format("SELECT TOP 1 OLD_YBLX FROM ZY_YBINPATIENT_LOG WHERE INPATIENT_ID = '{0}'", arrList[0])), "0"));
                        if (medicalType <= 0)
                            medicalTypeName = "自费";
                        else
                            medicalTypeName = Convertor.IsNull(dataBase.GetDataResult(String.Format("SELECT NAME FROM JC_YBLX WHERE ID = {0}", medicalType)), "");
                        //Modify By Kevin 2013-11-21 如果第一条记录为<=0就改成自费
                        if (medicalTypeLog <= 0)
                            medicalTypeNameLog = "自费";
                        else
                            medicalTypeNameLog = Convertor.IsNull(dataBase.GetDataResult(String.Format("SELECT NAME FROM JC_YBLX WHERE ID = {0}", medicalTypeLog)), "");

                        sSql = sSql + " SELECT 序号,类型,住院号,姓名,操作日期,操作员 FROM ( ";
                        sSql = String.Format("{0} SELECT '0' 序号,'入院登记' + '({1})' 类型,INPATIENT_NO 住院号,NAME 姓名,BOOK_DATE 操作日期, ", sSql, medicalTypeNameLog);
                        sSql = String.Format("{0} DBO.FUN_GETEMPNAME(BOOK_OPER) 操作员 FROM VI_ZY_VINPATIENT A WHERE INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT '1' 序号,'分娩' 类型,INPATIENT_NO 住院号,BABYNAME 姓名,BOOK_DATE 操作日期,DBO.FUN_GETEMPNAME(BOOK_OPER) 操作员 ";
                        sSql = String.Format("{0} FROM ZY_INPATIENT_BABY WHERE INPATIENT_ID='{1}'", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT '2' 序号,CASE A.TYPE WHEN 0 THEN '转医保' + '(' + (SELECT NAME FROM JC_YBLX WHERE ID = A.NEW_YBLX) +')' ";
                        sSql = sSql + " WHEN 1 THEN '转非医保' + '(自费)' ELSE '' END 类型, ";
                        sSql = sSql + " B.INPATIENT_NO 住院号,B.NAME 姓名,A.BOOK_DATE 操作日期,DBO.FUN_GETEMPNAME(A.BOOK_USER) 操作员 ";
                        sSql = sSql + " FROM ZY_YBINPATIENT_LOG A INNER JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID=B.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE B.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        sSql = String.Format("{0} SELECT '3' 序号,'医保入院' + '({1})' 类型, ", sSql, medicalTypeName);
                        sSql = sSql + " CASE RYSH WHEN 0 THEN '未审核' WHEN 1 THEN '审核通过' ELSE '审核不通过' END 住院号, ";
                        sSql = sSql + " RYSH_BZ 姓名,RYXG_DATE 操作日期,DBO.FUN_GETEMPNAME(RYXG_USER) 操作员 ";
                        sSql = String.Format("{0} FROM ZY_YB_SHXX WHERE INPATIENT_ID='{1}' ", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        sSql = String.Format("{0} SELECT '4' 序号,'医保出院' + '({1})' 类型, ", sSql, medicalTypeName);
                        sSql = sSql + " CASE CYSH WHEN 0 THEN '未审核' WHEN 1 THEN '审核通过' ELSE '审核不通过' END 住院号, ";
                        sSql = sSql + " CYSH_BZ 姓名,CYXG_DATE 操作日期,DBO.FUN_GETEMPNAME(CYXG_USER) 操作员 ";
                        sSql = String.Format("{0} FROM ZY_YB_SHXX WHERE INPATIENT_ID='{1}' ", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        sSql = String.Format("{0} SELECT '5' 序号,'修改疾病' + '(' + '原疾病:' + dbo.fun_getdiseasename(A.OLD_STR,{1}) + ',现疾病:'+ dbo.fun_getdiseasename(A.NEW_STR,{1}) + ')' 类型, ", sSql, medicalType);
                        sSql = sSql + " INPATIENT_NO 住院号,B.NAME 姓名,A.BOOK_DATE 操作日期,DBO.FUN_GETEMPNAME(A.BOOK_USER) 操作员 ";
                        sSql = sSql + " FROM ZY_ALLINPATIENT_LOG A INNER JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID=B.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE B.INPATIENT_ID='{1}' AND A.TYPE = 0 ", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT '6' 序号,'修改年龄' + '(' + '原年龄:' + A.OLD_STR + ',现年龄:' + A.NEW_STR + ')' 类型, ";
                        sSql = sSql + " INPATIENT_NO 住院号,B.NAME 姓名,A.BOOK_DATE 操作日期,DBO.FUN_GETEMPNAME(A.BOOK_USER) 操作员 ";
                        sSql = sSql + " FROM ZY_ALLINPATIENT_LOG A INNER JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID=B.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE B.INPATIENT_ID='{1}' AND A.TYPE = 1  ", sSql, arrList[0]);
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + "  SELECT '7' 序号,'修改性别' + '(' + '原性别:' + CASE A.OLD_STR WHEN '1' THEN '男' WHEN '2' THEN '女' ELSE '未知' END + ',现性别:' + CASE A.NEW_STR WHEN '1' THEN '男' WHEN '2' THEN '女' ELSE '未知' END + ')' 类型, ";
                        sSql = sSql + " INPATIENT_NO 住院号,B.NAME 姓名,A.BOOK_DATE 操作日期,DBO.FUN_GETEMPNAME(A.BOOK_USER) 操作员 ";
                        sSql = sSql + " FROM ZY_ALLINPATIENT_LOG A INNER JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID=B.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE B.INPATIENT_ID='{1}' AND A.TYPE = 2 ", sSql, arrList[0]);
                        sSql = sSql + " ) A ORDER BY 序号,操作日期";
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
        /// 住院综合查询--药品信息
        /// 存储过程--SP_ZY_ZHCX_YPXX
        /// </summary>
        /// <param name="inpatientId">住院号ID</param>
        /// <param name="babyId">婴儿ID</param>
        /// <param name="beginDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="isType">统计类型</param>
        /// <param name="outBit">发药标志</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexQueryDrugInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        const string tableName = "VI_ZY_FEE_SPECI";  //主表

                        sSql = sSql + " SELECT 0 序号,DBO.FUN_GETDATE(A.PRESC_DATE) 处方日期,A.XMID 代码,A.ITEM_NAME 项目名称,GG 规格,CJ 厂家,UNIT 单位,A.RETAIL_PRICE 单价, ";
                        sSql = sSql + " NUM 数量,A.DOSAGE 剂数,ACVALUE 金额, ";
                        sSql = sSql + " CASE TLFS WHEN 0 THEN '统领' WHEN 1 THEN '缺药' WHEN 3 THEN '出院带药' WHEN 5 THEN '处方领药' ELSE '其他' END 统领方式, ";
                        sSql = sSql + " CASE FY_BIT WHEN 1 THEN '√' ELSE '' END 发药标志,FY_DATE 发药日期,F.DJH 发药单号, ";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(FY_USER) 发药人,DBO.FUN_GETDEPTNAME(EXECDEPT_ID) 执行科室, ";
                        sSql = sSql + " CHARGE_DATE 记账日期,DBO.FUN_GETEMPNAME(CHARGE_USER) 记账员, ";
                        sSql = sSql + " CASE CZ_FLAG WHEN 0 THEN '正常' WHEN 1 THEN '被冲正' WHEN 2 THEN '冲正' WHEN 3 THEN '取消冲正' ELSE '' END 状态, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(A.DEPT_LY) 领药科室,DBO.FUN_GETDEPTNAME(A.DEPT_ID) 开单科室,DBO.FUN_GETDEPTNAME(DEPT_BR) 病人科室, ";
                        sSql = sSql + " A.BOOK_DATE 操作时间,DBO.FUN_GETEMPNAME(BOOK_USER) 操作员,CONVERT(VARCHAR,ISNULL(E.ZFBL,1)*100)+'%' 自付比例, ";
                        sSql = sSql + " CASE WHEN CONVERT(DECIMAL(18,2),RETAIL_PRICE*(1-ISNULL(E.ZFBL,1)))>ISNULL(E.ZGXJ,999999.99) THEN CONVERT(DECIMAL(18,2),(RETAIL_PRICE-ISNULL(E.ZGXJ,999999.99))*A.NUM*(CASE WHEN A.DOSAGE>0 THEN A.DOSAGE ELSE 1 END)) ELSE CONVERT(DECIMAL(18,2),ACVALUE*ISNULL(E.ZFBL,1)) END 自付金额, ";
                        sSql = sSql + " C.CODE 发票代码,C.ITEM_NAME 发票项目,HSBM 医保编码 ";
                        sSql = String.Format("{0} FROM {1} A ", sSql, tableName);
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM B ON A.STATITEM_CODE=B.CODE ";
                        sSql = sSql + " INNER JOIN JC_ZYFP_XM C ON B.ZYFP_CODE=C.CODE ";
                        sSql = sSql + " INNER JOIN ZY_INPATIENT D ON A.INPATIENT_ID=D.INPATIENT_ID ";
                        sSql = sSql + " LEFT JOIN YP_YPCJD G ON G.CJID=A.XMID AND A.XMLY=1 ";
                        sSql = sSql + " LEFT JOIN JC_YB_BL E ON D.YBLX=E.YBLX AND E.ZYBZ=1 AND A.XMLY=E.XMLY AND (CASE WHEN A.XMLY=1 THEN G.GGID ELSE A.XMID END)=E.XMID ";
                        sSql = sSql + " LEFT JOIN YF_TLD F ON A.GROUP_ID=F.GROUPID ";
                        sSql = sSql + " WHERE CHARGE_BIT=1 AND DELETE_BIT=0 AND A.XMLY=1 ";
                        sSql = String.Format("{0} AND A.INPATIENT_ID='{1}' ", sSql, arrList[0]);
                        sSql = String.Format("{0} AND A.BABY_ID='{1}' ", sSql, Convert.ToInt32(arrList[1]));
                        sSql = String.Format("{0} AND ({1}=0 OR ({1}=1 AND CHARGE_DATE BETWEEN '{2:yyyy-MM-dd HH:mm:ss}' AND '{3:yyyy-MM-dd HH:mm:ss}')) ", sSql, Convert.ToInt32(arrList[4]), Convert.ToDateTime(arrList[2]), Convert.ToDateTime(arrList[3]));
                        sSql = String.Format("{0} AND ({1}=-1 OR FY_BIT={1}) ", sSql, Convert.ToInt32(arrList[5]));
                        sSql = sSql + " ORDER BY A.STATITEM_CODE,A.XMID,A.PRESC_DATE,A.ORDER_ID,A.TYPE ";
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
        /// 住院综合查询--初始化树结构
        /// </summary>
        /// <param name="outTime">出院日期</param>
        /// <param name="isShowAllWard">是否显示全部病区</param>
        /// <param name="medicalType">医保类型</param>
        /// <param name="beginDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="wardId">病区</param>
        /// <param name="dataBase">数据库连接</param>
        /// <returns></returns>
        public static DataTable ZyPatientComplexInitTreeView(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if ((bool)arrList[0] == true)
                        {
                            sSql = sSql + " SELECT * FROM VI_ZY_VINPATIENT_ALL WHERE FLAG IN (2,6) AND FREEZE_FLAG = 0 ";
                            sSql += String.Format(" AND OUT_DATE >= '{0}' AND OUT_DATE <= '{1}' ", arrList[3], arrList[4]);
                        }
                        else
                            sSql = sSql + " SELECT * FROM VI_ZY_VINPATIENT_ALL WHERE FLAG IN (1,3,4,5) AND FREEZE_FLAG = 0 ";
                        if ((bool)arrList[1] == true)
                            sSql = String.Format("{0} AND WARD_ID = '{1}'", sSql, arrList[5]);
                        if (Convert.ToInt32(arrList[2]) == 0)
                            sSql = sSql + " AND DISCHARGETYPE <> 1 ";
                        else if (Convert.ToInt32(arrList[2]) > 0)
                            sSql = String.Format("{0} AND DISCHARGETYPE = 1 AND YBLX = {1}", sSql, Convert.ToInt32(arrList[2]));
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
