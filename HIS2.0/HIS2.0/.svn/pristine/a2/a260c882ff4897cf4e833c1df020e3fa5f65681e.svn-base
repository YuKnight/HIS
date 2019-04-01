using System;
using System.Collections.Generic;
using System.Text;

using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;

namespace ts_SCM_HIS
{
    /// <summary>
    /// ****************************************************************************
    /// 名称：SCMPurchasePlan.cs
    /// 说明:HIS在生成购计划完成审核后，从HIS中推数据到SCM系统中，调用SCM提供接口服务
    ///      增加采购计划，修改采购计划，删除采购计划
    /// 添加人：HuangYD
    /// 添加时间：2016-09-02
    /// 最后一次更新时间：
    /// 更新人：   
    /// ****************************************************************************
    /// </summary>
   public class SCMPurchasePlan
    {
       private string _GJBM;

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
         预留字段	        FREEUSE	string */


       private string _EBELN;    //采购单据号
       private string _EBELP;    //项目编号
       private string _LIFNR;    //供应商帐号
       private string _NAME;     //库存地点
       private string _MATNR;    //药品编号
       private string _TXZ01;    //药品名称
       private string _WERKS;    //院区ID
       private string _WERKST;   //院区描述
       private string _LGORT;    //库存送货地点(科室ID)
       private Decimal _MENGE;   //送货数量
       private string _MEINS;    //计量单位ID
       private string _MSEHT;    //计量单位描述
       private Decimal _NETPR;   //单价进货价
       private string _EINDT;    //交货日期
       private string _BEDAT;    //采购订单日期
       private string _COMMENTS; //备注
       private string _FREEUSE;  //预留字段

       /// <summary>
       /// 采购单据号
       /// </summary>
       public string EBELN
       {
           get { return _EBELN; }
           set { _EBELN = value; }
       }

       /// <summary>
       /// 项目编号
       /// </summary>
       public string EBELP
       {
           get { return _EBELP; }
           set { _EBELP = value; }
       }

       /// <summary>
       /// 供应商帐号
       /// </summary>
       public string LIFNR
       {
           get { return _LIFNR; }
           set { _LIFNR = value; }
       }

       /// <summary>
       /// 库存地点
       /// </summary>
       public string NAME
       {
           get { return _NAME; }
           set { _NAME = value; }
       }

       /// <summary>
       /// 药品编号
       /// </summary>
       public string MATNR
       {
           get { return _MATNR; }
           set { _MATNR = value; }
       }
/*
       药品名称	        TXZ01	string
        院区ID	            WERKS	string
        院区描述	        WERKST	string
        库存（送货）地点	LGORT	string
        送货数量	        MENGE	Decimal（17,4）
        计量单位ID	        MEINS	string
        计量单位描述	    MSEHT	string */

       /// <summary>
       /// 药品名称
       /// </summary>
       public string TXZ01
       {
           get { return _TXZ01; }
           set { _TXZ01 = value; }
       }

       /// <summary>
       /// 院区ID
       /// </summary>
       public string WERKS
       {
           get { return _WERKS; }
           set { _WERKS = value; }
       }

       /// <summary>
       /// 院区ID描述
       /// </summary>
       public string WERKST
       {
           get { return _WERKST; }
           set { _WERKST = value; }
       }


       /// <summary>
       /// 库存（送货）地点
       /// </summary>
       public string LGORT
       {
           get { return _LGORT; }
           set { _LGORT = value; }
       }

       /// <summary>
       /// 送货数量
       /// </summary>
       public Decimal MENGE
       {
           get { return _MENGE; }
           set { _MENGE = value; }
       }

       /// <summary>
       /// 计量单位ID
       /// </summary>
       public string MEINS
       {
           get { return _MEINS; }
           set { _MEINS = value; }
       }

       /// <summary>
       /// 送货单位描述
       /// </summary>
       public string MSEHT
       {
           get { return _MSEHT; }
           set { _MSEHT = value; }
       }

       /*private Decimal _NETPR;   //单价进货价
       private string _EINDT;    //交货日期
       private string _BEDAT;    //采购订单日期 */

       /// <summary>
       /// 单价进货价
       /// </summary>
       public Decimal NETPR
       {
           get { return _NETPR; }
           set { _NETPR = value; }
       }

       /// <summary>
       /// 交货日期
       /// </summary>
       public string EINDT
       {
           get { return _EINDT; }
           set { _EINDT = value; }
       }

       /// <summary>
       /// 采购订单日期
       /// </summary>
       public string BEDAT
       {
           get { return _BEDAT; }
           set { _BEDAT = value; }
       }


       /// <summary>
       /// 备注
       /// </summary>
       public string COMMENTS
       {
           get { return _COMMENTS; }
           set { _COMMENTS = value; }
       }



       /// <summary>
       /// 预留字段
       /// </summary>
       public string FREEUSE
       {
           get { return _FREEUSE; }
           set { _FREEUSE = value; }
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="CheasePlan"></param>
       /// <param name="ActionFlag"></param>
       /// <param name="err_Code"></param>
       /// <param name="SucFlag"></param>
       //public static void HisPushChasePlanToSCM( List<SCMPurchasePlan> CheasePlan, string ActionFlag, out bool err_Flag, out bool Suc_Flag)
       //{
       //    if (CheasePlan != null)
       //    {
       //        try
       //        {
       //            //WebReference SCMServer = new WebReference(); GetPucharseFromSap
       //            WebReference.SAPtoSCM ScmSer = new WebReference.SAPtoSCM();
       //            ScmSer.GetPucharseFromSap(CheasePlan, ActionFlag,out err_Flag, out Suc_Flag);                    
       //        }
       //        catch (System.Exception err)
       //        {
       //            throw new System.Exception(err.ToString());
       //        }
       //    }
       //}

    }
}
