using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;

namespace ts_SCM_HIS
{
    /// <summary>
    /// SCM药品字典说明
    /// </summary>
    public class SCMHisDrugItem
    {

      /*    药品名称	NAME	string
            药品编码	CODE	string
            药品规格	SPEC	string
            生产厂家	FACTORY	string
            药品进价	MRJJ	Decimal（14，4） */

        private string _NAME;	   //药品名称
        private string _CODE;	   //药品编码
        private string _SPEC;     //药品规格
        private string _FACTORY;  //生产厂家
        private Decimal _MRJJ;     //药品进价


        /// <summary>
        /// 药品名称
        /// </summary>
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }

        /// <summary>
        /// 药品代码
        /// </summary>
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }

        /// <summary>
        /// 药品规格
        /// </summary>
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
        }

        /// <summary>
        /// 药品生产厂家
        /// </summary>
        public string FACTORY
        {
            get { return _FACTORY; }
            set { _FACTORY = value; }
        }

        /// <summary>
        /// 药品进货价
        /// </summary>
        public Decimal MRJJ
        {
            get { return _MRJJ; }
            set { _MRJJ = value; }
        }



       // public static void HisPushDrugItemToSCM(IList<SCMHisDrugItem> DrugItem, string ActFlag, out bool err_Flag, out bool Suc_Flag)
        //public static void HisPushDrugItemToSCM( List<SCMHisDrugItem> DrugItem, string ActFlag)
        //{
        //    if (DrugItem != null)
        //    {
        //        try
        //        {
        //            //WebReference SCMServer = new WebReference(); GetPucharseFromSap,GetDrugFromHIS
        //            WebReference.SAPtoSCM ScmSer = new WebReference.SAPtoSCM();
                     
        //           // ScmSer.GetDrugFromHIS(DrugItem, ActFlag, err_Flag, Suc_Flag);//此处没有对应的方法
                    
        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new System.Exception(err.ToString());
        //        }
        //    }
        //}
    }                  	
}                      	
