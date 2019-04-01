using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Text;


namespace ts_SCM_HIS
{
    /// <summary>
    /// ************************************************************
    /// 说明：在HIS中传递交采购计划到SCM,增加采购计划，修改采购计划,
    ///       在药品字典中增加药品，修改药品，删除药品字典，
    ///       把药品字典信息发送到SCM系统，所用到的方法
    /// 名称：ScmHisSer.cs
    /// 添加人：HuangYD
    /// 添加时间：2016-09-03
    /// 最后一次修改时间：
    /// 最后一次修改人：     
    /// 
    /// ***********************************************************
    /// </summary>
    public class ScmHisSer
    {
        /// <summary>
        /// 把HIS中采购计划信息送到SCM系统所调用SCM接口中方法
        /// </summary>
        /// <param name="CheasePlan">采购计划对象</param>
        /// <param name="ActionFlag">增加删除操作字符</param>
        /// <param name="Suc_Flag">成功与否标识</param>
        /// <param name="err_Flag">默认传true</param>
        public static void HisPushChasePlanToSCM(List<SCMPurchasePlan> CheasePlan, string ActionFlag, out bool Suc_Flag,out bool err_Flag)
        {
            Suc_Flag = false;
            err_Flag = false;

            if (CheasePlan.Count>0)
            {
                try
                {

                    /*采购凭证号	        EBELN	string
                   项目编号	        EBELP	string
                   供应商账户	        LIFNR	string
                   库存地点	        NAME	string
                   药品编号	        MATNR	string
                   药品名称	        TXZ01	string
                   院区ID	            WERKS	string
                   院区描述	        WERKST	string
                   库存（送货）地点	LGORT	string
                   送货数量	        MENGE	Decimal（17,4）
                   计量单位ID	        MEINS	string
                   计量单位描述	    MSEHT	string
                   单价（进货价）	    NETPR	Decimal（14,4）
                   交货日期	        EINDT	string
                   采购订单日期	    BEDAT	string 
                   备注	            COMMENTS	string
                   预留字段	        FREEUSE	    string  */

                    WebReference.SAPtoSCM ScmSer = new WebReference.SAPtoSCM();
                    List<ts_SCM_HIS.WebReference.Sap_PurchasePlan> ScmHisinfoAll = new List<ts_SCM_HIS.WebReference.Sap_PurchasePlan>();

                    foreach (SCMPurchasePlan infomx in CheasePlan)
                    {
                        ts_SCM_HIS.WebReference.Sap_PurchasePlan SCMinfo = new ts_SCM_HIS.WebReference.Sap_PurchasePlan();
                        SCMinfo.EBELN = infomx.EBELN;
                        SCMinfo.EBELP = infomx.EBELP;
                        SCMinfo.LIFNR = infomx.LIFNR;
                        SCMinfo.NAME = infomx.NAME;
                        SCMinfo.MATNR = infomx.MATNR;
                        SCMinfo.TXZ01 = infomx.TXZ01;
                        SCMinfo.WERKS = infomx.WERKS;
                        SCMinfo.WERKST = infomx.WERKST;
                        SCMinfo.LGORT = infomx.LGORT;
                        SCMinfo.MENGE = infomx.MENGE.ToString();
                        SCMinfo.MEINS = infomx.MEINS;
                        SCMinfo.MSEHT = infomx.MSEHT.ToString();
                        SCMinfo.NETPR = infomx.NETPR.ToString();
                        SCMinfo.EINDT = infomx.EINDT;
                        SCMinfo.BEDAT = infomx.BEDAT;
                        SCMinfo.COMMENTS = infomx.COMMENTS;
                        SCMinfo.FREEUSE = infomx.FREEUSE;

                        ScmHisinfoAll.Add(SCMinfo);
                    }
                    
                    ScmSer.GetPucharseFromSap(ScmHisinfoAll.ToArray(), ActionFlag, out Suc_Flag, out err_Flag);


                }
                catch (System.Exception err)
                {                    
                    throw new System.Exception(err.ToString());
                }
            }
        }



        /// <summary>
        /// 把HIS中药品字典传到SCM系统所用到的方法
        /// </summary>
        /// <param name="DrugItem">药品字典对象</param>
        /// <param name="ActFlag">增加删除操作字符</param>
        /// <param name="Suc_Flag">成功与否标识</param>
        /// <param name="err_Flag">默认传true</param>
        public static void HisPushDrugItemToSCM(List<SCMHisDrugItem> DrugItem, string ActFlag,out bool Suc_Flag,out bool err_Flag)
        {
            Suc_Flag = false;
            err_Flag = false;
            if (DrugItem.Count>0)
            {
                try
                {                    
                  
                    WebReference.SAPtoSCM ScmSer = new WebReference.SAPtoSCM();
                    List<ts_SCM_HIS.WebReference.HIS_DRUG> HISDrugAll = new List<ts_SCM_HIS.WebReference.HIS_DRUG>();

                    foreach(SCMHisDrugItem druginfo in DrugItem)
                    {
                          /*    药品名称	NAME	string
                                药品编码	CODE	string
                                药品规格	SPEC	string
                                生产厂家	FACTORY	string
                                药品进价	MRJJ	Decimal（14，4） */
                        ts_SCM_HIS.WebReference.HIS_DRUG ScmDrug = new ts_SCM_HIS.WebReference.HIS_DRUG();
                        ScmDrug.NAME = druginfo.NAME;
                        ScmDrug.CODE = druginfo.CODE;
                        ScmDrug.SPEC = druginfo.SPEC;
                        ScmDrug.FACTORY = druginfo.FACTORY;
                        ScmDrug.MRJJ = druginfo.MRJJ.ToString();
                        HISDrugAll.Add(ScmDrug);
                    }
                    ScmSer.GetDrugFromHIS(HISDrugAll.ToArray(), ActFlag,out Suc_Flag,out err_Flag);

                }
                catch (System.Exception err)
                {
                    throw new System.Exception(err.ToString());
                }
            }
        }


        /// <summary>
        /// 通过采购计划审核后得到SCM接口要求的信息传到SCM
        /// </summary>
        /// <param name="strDeptID">登录人所在的科室</param>
        /// <param name="strDjh">单据号</param>
        /// <param name="ZbID">主表ID</param>
        /// <param name="db">数据库连接</param>
        /// <returns>数据表</returns>
        public static DataTable GetCgmxByDeptAndId(string strDeptID, string strDjh, string ZbID,RelationalDatabase db)
        {
            string strSQL = " SELECT A.DJH AS EBELN ,B.ID AS EBELP,(10000000+B.WLDW) AS LIFNR,C.NAME AS NAME ,B.CJID AS MATNR,D.S_YPPM AS TXZ01," +
                            " C.YQID AS WERKS,C.YQMC AS WERKST,A.DEPTID AS LGORT,B.JHS AS MENGE,E.ID AS MEINS,B.YPDW AS MSEHT,B.CKJJ AS NETPR,A.JHCGRQ AS EINDT, " +
                            " A.JHCGRQ AS BEDAT  " +
                            " FROM YF_CG AS A LEFT JOIN YF_CGMX AS B ON A.ID=B.DJID LEFT JOIN JC_DEPT_PROPERTY AS C ON A.DEPTID=C.DEPT_ID " +
                            " LEFT JOIN YP_YPCJD AS D ON B.CJID=D.CJID LEFT JOIN YP_YPDW AS E ON B.YPDW=E.DWMC " +
                            " WHERE  A.SHBZ='1' And A.DJH='" + strDjh + "' and A.DEPTID='" + strDeptID + "' ";
                            // " where  A.SHBZ='1' And A.DJH='" + strDjh + "' and A.DEPTID='" + strDeptID + "' and A.ID='" + ZbID + "'";
            DataTable tab = db.GetDataTable(strSQL);
            return tab;
        }

        /// <summary>
        /// 通过CJID得到药品信息
        /// </summary>
        /// <param name="strCjID">药品ID</param>
        /// <param name="db">数据库连接</param>
        /// <returns>数据表</returns>
        public static DataTable GetDrugInfoByCjid(string strCjID, RelationalDatabase db)
        {
            string strSQL = " SELECT S_YPPM AS NAME,CJID AS CODE,S_YPGG AS SPEC,S_SCCJ AS FACTORY,PFJ AS MRJJ FROM YP_YPCJD " +
                            " WHERE  CJID='" + strCjID + "' ";
            DataTable tab = db.GetDataTable(strSQL);
            return tab;
        }


        
    }
}
