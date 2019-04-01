using System;
using System.Collections.Generic;
using System.Text;

namespace ts_zyhs_classes
{
    public class OrderFeeEntity
    {
        public Guid ID;
        public Guid INPATIENT_ID;
        public long BABY_ID;
        public Guid ORDER_ID;
        public Guid ORDEREXEC_ID;
        public Guid PRESCRIPTION_ID;
        public string PRESC_NO;//decimal(21,6)
        public DateTime PRESC_DATE;
        public DateTime BOOK_DATE;
        public long BOOK_USER;
        public string STATITEM_CODE;
        public long XMID;
        public int XMLY;
        public string ITEM_NAME;
        public string SUBCODE;
        public string UNIT;
        public int UNITRATE;
        public decimal COST_PRICE;
        public decimal RETAIL_PRICE;
        public decimal NUM;
        public int DOSAGE;
        public decimal SDVALUE;
        public int AGIO;
        public decimal ACVALUE;
        public int CHARGE_BIT;
        public DateTime? CHARGE_DATE;
        public long? CHARGE_USER;
        public int DELETE_BIT;
        public int CZ_FLAG;
        public int DISCHARGE_BIT;

        public long TCID;
        public int TC_FLAG;
        public Guid CZ_ID;
        public int TYPE;

        public long DOC_ID;
        public long DEPT_ID;
        public long DEPT_BR;
        public long EXECDEPT_ID;

        public int TLFS;
        public long DEPT_LY;
        public long JGBM;

        public string GG;
        //public string BZ;
        public string CJ;
        public long GCYS;
        public string ZFBL;//是否武汉BZ
        public string BZ;

        public int FY_BIT;//是否武汉
        public int pvs_xh;//是否武汉


        public string AddFeeInfo(int iXmly,int iType)
        {
            string ssql = "";

            if (iType == 0)
            {
                #region"正费用"

                if (XMLY == 1)
                {
                    if (CHARGE_BIT == 1)
                    {
                        ssql = string.Format(@"
	                                        INSERT INTO ZY_FEE_SPECI
		                                    (	ID,INPATIENT_ID,BABY_ID,
			                                    ORDER_ID,ORDEREXEC_ID,PRESCRIPTION_ID,
			                                    PRESC_NO,PRESC_DATE,BOOK_DATE,BOOK_USER,
			                                    STATITEM_CODE,XMID,XMLY,
			                                    ITEM_NAME,SUBCODE,UNIT,UNITRATE,
			                                    COST_PRICE,RETAIL_PRICE,
			                                    NUM,DOSAGE,
			                                    SDVALUE,AGIO,ACVALUE,
			                                    CHARGE_BIT,CHARGE_DATE,CHARGE_USER,
			                                    DELETE_BIT,CZ_FLAG,DISCHARGE_BIT,
			                                    DOC_ID,DEPT_ID,DEPT_BR,EXECDEPT_ID,
			                                    DEPT_LY,JGBM,GCYS,ZFBL,
			                                    TLFS,GG,CJ,FY_BIT, pvs_xh
		                                    )
                                            values('{0}','{1}','{2}',
                                                    '{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}',
                                                    '{10}','{11}','{12}',
                                                    '{13}','{14}','{15}','{16}',
                                                    '{17}','{18}',
                                                    '{19}','{20}',
                                                    '{21}','{22}','{23}',
                                                    '{24}','{25}','{26}',
                                                    '{27}','{28}','{29}',
                                                    '{30}','{31}','{32}','{33}',
                                                    '{34}','{35}','{36}','{37}',
                                                    '{38}','{39}','{40}','{41}','{42}'
                                                    )",
                                            ID, INPATIENT_ID, BABY_ID,
                                                    ORDER_ID, ORDEREXEC_ID, PRESCRIPTION_ID,
                                                    PRESC_NO, PRESC_DATE, BOOK_DATE, BOOK_USER,
                                                    STATITEM_CODE, XMID, XMLY,
                                                    ITEM_NAME, SUBCODE, UNIT, UNITRATE,
                                                    COST_PRICE, RETAIL_PRICE,
                                                    NUM, DOSAGE,
                                                    SDVALUE, AGIO, ACVALUE,
                                                    CHARGE_BIT, CHARGE_DATE, CHARGE_USER,
                                                    DELETE_BIT, CZ_FLAG, DISCHARGE_BIT,
                                                    DOC_ID, DEPT_ID, DEPT_BR, EXECDEPT_ID,
                                                    DEPT_LY, JGBM, GCYS, ZFBL,
                                                    TLFS, GG, CJ, FY_BIT, pvs_xh);
                    }
                    else
                    {
                        ssql = string.Format(@"
	                                        INSERT INTO ZY_FEE_SPECI
		                                    (	ID,INPATIENT_ID,BABY_ID,
			                                    ORDER_ID,ORDEREXEC_ID,PRESCRIPTION_ID,
			                                    PRESC_NO,PRESC_DATE,BOOK_DATE,BOOK_USER,
			                                    STATITEM_CODE,XMID,XMLY,
			                                    ITEM_NAME,SUBCODE,UNIT,UNITRATE,
			                                    COST_PRICE,RETAIL_PRICE,
			                                    NUM,DOSAGE,
			                                    SDVALUE,AGIO,ACVALUE,
			                                    DELETE_BIT,CZ_FLAG,DISCHARGE_BIT,
			                                    DOC_ID,DEPT_ID,DEPT_BR,EXECDEPT_ID,
			                                    DEPT_LY,JGBM,GCYS,ZFBL,
			                                    TLFS,GG,CJ,FY_BIT, pvs_xh
			                                    ,CHARGE_BIT
		                                    )
                                            values('{0}','{1}','{2}',
                                                    '{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}',
                                                    '{10}','{11}','{12}',
                                                    '{13}','{14}','{15}','{16}',
                                                    '{17}','{18}',
                                                    '{19}','{20}',
                                                    '{21}','{22}','{23}',
                                                    '{24}','{25}','{26}',
                                                    '{27}','{28}','{29}','{30}',
                                                    '{31}','{32}','{33}','{34}',
                                                    '{35}','{36}','{37}','{38}','{39}'
                                                    ,'{40}'
                                                    )",
                                            ID, INPATIENT_ID, BABY_ID,
                                                    ORDER_ID, ORDEREXEC_ID, PRESCRIPTION_ID,
                                                    PRESC_NO, PRESC_DATE, BOOK_DATE, BOOK_USER,
                                                    STATITEM_CODE, XMID, XMLY,
                                                    ITEM_NAME, SUBCODE, UNIT, UNITRATE,
                                                    COST_PRICE, RETAIL_PRICE,
                                                    NUM, DOSAGE,
                                                    SDVALUE, AGIO, ACVALUE,
                                                    DELETE_BIT, CZ_FLAG, DISCHARGE_BIT,
                                                    DOC_ID, DEPT_ID, DEPT_BR, EXECDEPT_ID,
                                                    DEPT_LY, JGBM, GCYS, ZFBL,
                                                    TLFS, GG, CJ, FY_BIT, pvs_xh
                                                    , CHARGE_BIT);
                    }
                }
                else if (XMLY == 2)
                {
                    if (CHARGE_BIT == 1)
                    {
                        ssql = string.Format(@"
	                                        INSERT INTO ZY_FEE_SPECI
			                                 (  ID,INPATIENT_ID,BABY_ID,
				                                ORDER_ID,ORDEREXEC_ID,PRESCRIPTION_ID,
				                                PRESC_NO,PRESC_DATE,BOOK_DATE,BOOK_USER,
				                                STATITEM_CODE,XMID,XMLY,
				                                ITEM_NAME,SUBCODE,UNIT,UNITRATE,
				                                COST_PRICE,RETAIL_PRICE,
				                                NUM,DOSAGE,
				                                SDVALUE,AGIO,ACVALUE,
				                                CHARGE_BIT,CHARGE_DATE,CHARGE_USER,
				                                DELETE_BIT,CZ_FLAG,DISCHARGE_BIT,
				                                DOC_ID,DEPT_ID,DEPT_BR,EXECDEPT_ID,
                                                DEPT_LY,JGBM,GCYS,ZFBL
				                                ,TCID,TC_FLAG
			                                 )
                                            values('{0}','{1}','{2}',
                                                    '{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}',
                                                    '{10}','{11}','{12}',
                                                    '{13}','{14}','{15}','{16}',
                                                    '{17}','{18}',
                                                    '{19}','{20}',
                                                    '{21}','{22}','{23}',
                                                    '{24}','{25}','{26}',
                                                    '{27}','{28}','{29}',
                                                    '{30}','{31}','{32}','{33}',
                                                    '{34}','{35}','{36}','{37}',
                                                    '{38}','{39}'
                                                    )",
                                            ID, INPATIENT_ID, BABY_ID,
                                                    ORDER_ID, ORDEREXEC_ID, PRESCRIPTION_ID,
                                                    PRESC_NO, PRESC_DATE, BOOK_DATE, BOOK_USER,
                                                    STATITEM_CODE, XMID, XMLY,
                                                    ITEM_NAME, SUBCODE, UNIT, UNITRATE,
                                                    COST_PRICE, RETAIL_PRICE,
                                                    NUM, DOSAGE,
                                                    SDVALUE, AGIO, ACVALUE,
                                                    CHARGE_BIT, CHARGE_DATE, CHARGE_USER,
                                                    DELETE_BIT, CZ_FLAG, DISCHARGE_BIT,
                                                    DOC_ID, DEPT_ID, DEPT_BR, EXECDEPT_ID,
                                                    DEPT_LY, JGBM, GCYS, ZFBL
                                                    , TCID, TC_FLAG);
                    }
                    else
                    {
                        ssql = string.Format(@"
	                                        INSERT INTO ZY_FEE_SPECI
			                                 (  ID,INPATIENT_ID,BABY_ID,
				                                ORDER_ID,ORDEREXEC_ID,PRESCRIPTION_ID,
				                                PRESC_NO,PRESC_DATE,BOOK_DATE,BOOK_USER,
				                                STATITEM_CODE,XMID,XMLY,
				                                ITEM_NAME,SUBCODE,UNIT,UNITRATE,
				                                COST_PRICE,RETAIL_PRICE,
				                                NUM,DOSAGE,
				                                SDVALUE,AGIO,ACVALUE,
				                                DELETE_BIT,CZ_FLAG,DISCHARGE_BIT,
				                                DOC_ID,DEPT_ID,DEPT_BR,EXECDEPT_ID,
                                                DEPT_LY,JGBM,GCYS,ZFBL
				                                ,TCID,TC_FLAG,CHARGE_BIT
			                                 )
                                            values('{0}','{1}','{2}',
                                                    '{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}',
                                                    '{10}','{11}','{12}',
                                                    '{13}','{14}','{15}','{16}',
                                                    '{17}','{18}',
                                                    '{19}','{20}',
                                                    '{21}','{22}','{23}',
                                                    '{24}','{25}','{26}',
                                                    '{27}','{28}','{29}','{30}',
                                                    '{31}','{32}','{33}','{34}',
                                                    '{35}','{36}','{37}'
                                                    )",
                                            ID, INPATIENT_ID, BABY_ID,
                                                    ORDER_ID, ORDEREXEC_ID, PRESCRIPTION_ID,
                                                    PRESC_NO, PRESC_DATE, BOOK_DATE, BOOK_USER,
                                                    STATITEM_CODE, XMID, XMLY,
                                                    ITEM_NAME, SUBCODE, UNIT, UNITRATE,
                                                    COST_PRICE, RETAIL_PRICE,
                                                    NUM, DOSAGE,
                                                    SDVALUE, AGIO, ACVALUE,
                                                    DELETE_BIT, CZ_FLAG, DISCHARGE_BIT,
                                                    DOC_ID, DEPT_ID, DEPT_BR, EXECDEPT_ID,
                                                    DEPT_LY, JGBM, GCYS, ZFBL
                                                    , TCID, TC_FLAG, CHARGE_BIT);
                    }

                }

                #endregion
            }
            else if (iType == 1)
            {
                #region"负费用"

                if (CHARGE_BIT == 1)
                {
                    ssql = string.Format(@"
                            INSERT INTO ZY_FEE_SPECI
                            (	
                                ID,ORDER_ID,PRESCRIPTION_ID,ORDEREXEC_ID,PRESC_DATE,BOOK_DATE,BOOK_USER,
		   	   	                PRESC_NO,STATITEM_CODE,XMID,TCID,TC_FLAG,INPATIENT_ID,BABY_ID,
		   	   	                ITEM_NAME,SUBCODE,XMLY,UNIT,UNITRATE,DOSAGE,COST_PRICE, RETAIL_PRICE, 
		   	   	                AGIO, EXECDEPT_ID,DEPT_ID,DEPT_BR,DEPT_LY,DOC_ID,CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT,
		   	   	                NUM,
					            SDVALUE,
					            ACVALUE,
					            TYPE,TLFS,
					            CHARGE_BIT,CHARGE_USER,CHARGE_DATE,BZ,JGBM,GG,CJ,GCYS,FY_BIT,pvs_xh,ZFBL
                            )
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',
                                    '{7}','{8}','{9}','{10}','{11}','{12}','{13}',
                                    '{14}','{15}','{16}','{17}','{18}', '{19}','{20}','{21}',
                                    '{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}',
                                    '{32}',
                                    '{33}',
                                    '{34}',
                                    '{35}','{36}',
                                    '{37}',
                                    '{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}')",
                            ID, ORDER_ID, PRESCRIPTION_ID, ORDEREXEC_ID, PRESC_DATE, BOOK_DATE, BOOK_USER,
                                PRESC_NO, STATITEM_CODE, XMID, TCID, TC_FLAG, INPATIENT_ID, BABY_ID,
                                ITEM_NAME, SUBCODE, XMLY, UNIT, UNITRATE, DOSAGE, COST_PRICE, RETAIL_PRICE,
                                AGIO, EXECDEPT_ID, DEPT_ID, DEPT_BR, DEPT_LY, DOC_ID, CZ_FLAG, CZ_ID, DELETE_BIT, DISCHARGE_BIT,
                                NUM,
                                SDVALUE,
                                ACVALUE,
                                TYPE, TLFS,
                                CHARGE_BIT, CHARGE_USER, CHARGE_DATE, BZ, JGBM, GG, CJ, GCYS, FY_BIT, pvs_xh, ZFBL);

                }
                else
                {
                    ssql = string.Format(@"
                            INSERT INTO ZY_FEE_SPECI
                            (	
                                ID,ORDER_ID,PRESCRIPTION_ID,ORDEREXEC_ID,PRESC_DATE,BOOK_DATE,BOOK_USER,
		   	   	                PRESC_NO,STATITEM_CODE,XMID,TCID,TC_FLAG,INPATIENT_ID,BABY_ID,
		   	   	                ITEM_NAME,SUBCODE,XMLY,UNIT,UNITRATE,DOSAGE,COST_PRICE, RETAIL_PRICE, 
		   	   	                AGIO, EXECDEPT_ID,DEPT_ID,DEPT_BR,DEPT_LY,DOC_ID,CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT,
		   	   	                NUM,
					            SDVALUE,
					            ACVALUE,
					            TYPE,TLFS,
					            CHARGE_BIT,BZ,JGBM,GG,CJ,GCYS,FY_BIT,pvs_xh,ZFBL
                            )
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',
                                    '{7}','{8}','{9}','{10}','{11}','{12}','{13}',
                                    '{14}','{15}','{16}','{17}','{18}', '{19}','{20}','{21}',
                                    '{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}',
                                    '{32}',
                                    '{33}',
                                    '{34}',
                                    '{35}','{36}',
                                    '{37}',
                                    '{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}')",
                            ID, ORDER_ID, PRESCRIPTION_ID, ORDEREXEC_ID, PRESC_DATE, BOOK_DATE, BOOK_USER,
                                PRESC_NO, STATITEM_CODE, XMID, TCID, TC_FLAG, INPATIENT_ID, BABY_ID,
                                ITEM_NAME, SUBCODE, XMLY, UNIT, UNITRATE, DOSAGE, COST_PRICE, RETAIL_PRICE,
                                AGIO, EXECDEPT_ID, DEPT_ID, DEPT_BR, DEPT_LY, DOC_ID, CZ_FLAG, CZ_ID, DELETE_BIT, DISCHARGE_BIT,
                                NUM,
                                SDVALUE,
                                ACVALUE,
                                TYPE, TLFS,
                                CHARGE_BIT, BZ, JGBM, GG, CJ, GCYS, FY_BIT, pvs_xh, ZFBL);
                }

                #endregion
            }
            else if (iType == 2)
            {
                #region"附加费用"
                #endregion
            }


            return ssql;
        }

        public string AddFeeInfo(int iXmly, int iType, OrderFeeEntity ettOrdFee)
        {
            string ssql = "";

            if (iType == 0)
            {
                #region"正费用"

                if (XMLY == 1)
                {
                    if (ettOrdFee.CHARGE_BIT == 1)
                    {
                        ssql = string.Format(@"
	                                        INSERT INTO ZY_FEE_SPECI
		                                    (	ID,INPATIENT_ID,BABY_ID,
			                                    ORDER_ID,ORDEREXEC_ID,PRESCRIPTION_ID,
			                                    PRESC_NO,PRESC_DATE,BOOK_DATE,BOOK_USER,
			                                    STATITEM_CODE,XMID,XMLY,
			                                    ITEM_NAME,SUBCODE,UNIT,UNITRATE,
			                                    COST_PRICE,RETAIL_PRICE,
			                                    NUM,DOSAGE,
			                                    SDVALUE,AGIO,ACVALUE,
			                                    CHARGE_BIT,CHARGE_DATE,CHARGE_USER,
			                                    DELETE_BIT,CZ_FLAG,DISCHARGE_BIT,
			                                    DOC_ID,DEPT_ID,DEPT_BR,EXECDEPT_ID,
			                                    DEPT_LY,JGBM,GCYS,ZFBL,
			                                    TLFS,GG,CJ,FY_BIT, pvs_xh
		                                    )
                                            values('{0}','{1}','{2}',
                                                    '{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}',
                                                    '{10}','{11}','{12}',
                                                    '{13}','{14}','{15}','{16}',
                                                    '{17}','{18}',
                                                    '{19}','{20}',
                                                    '{21}','{22}','{23}',
                                                    '{24}','{25}','{26}',
                                                    '{27}','{28}','{29}',
                                                    '{30}','{31}','{32}','{33}',
                                                    '{34}','{35}','{36}','{37}',
                                                    '{38}','{39}','{40}','{41}','{42}'
                                                    )",
                                            ettOrdFee.ID, ettOrdFee.INPATIENT_ID, ettOrdFee.BABY_ID,
                                            ettOrdFee.ORDER_ID, ettOrdFee.ORDEREXEC_ID, ettOrdFee.PRESCRIPTION_ID,
                                            ettOrdFee.PRESC_NO, ettOrdFee.PRESC_DATE, ettOrdFee.BOOK_DATE, ettOrdFee.BOOK_USER,
                                            ettOrdFee.STATITEM_CODE, ettOrdFee.XMID, ettOrdFee.XMLY,
                                            ettOrdFee.ITEM_NAME, ettOrdFee.SUBCODE, ettOrdFee.UNIT, ettOrdFee.UNITRATE,
                                            ettOrdFee.COST_PRICE, ettOrdFee.RETAIL_PRICE,
                                            ettOrdFee.NUM, ettOrdFee.DOSAGE,
                                            ettOrdFee.SDVALUE, ettOrdFee.AGIO, ettOrdFee.ACVALUE,
                                            ettOrdFee.CHARGE_BIT, ettOrdFee.CHARGE_DATE, ettOrdFee.CHARGE_USER,
                                            ettOrdFee.DELETE_BIT, ettOrdFee.CZ_FLAG, ettOrdFee.DISCHARGE_BIT,
                                            ettOrdFee.DOC_ID, ettOrdFee.DEPT_ID, ettOrdFee.DEPT_BR, ettOrdFee.EXECDEPT_ID,
                                            ettOrdFee.DEPT_LY, ettOrdFee.JGBM, ettOrdFee.GCYS, ettOrdFee.ZFBL,
                                            ettOrdFee.TLFS, ettOrdFee.GG, ettOrdFee.CJ, ettOrdFee.FY_BIT, ettOrdFee.pvs_xh);
                    }
                    else
                    {
                        ssql = string.Format(@"
	                                        INSERT INTO ZY_FEE_SPECI
		                                    (	ID,INPATIENT_ID,BABY_ID,
			                                    ORDER_ID,ORDEREXEC_ID,PRESCRIPTION_ID,
			                                    PRESC_NO,PRESC_DATE,BOOK_DATE,BOOK_USER,
			                                    STATITEM_CODE,XMID,XMLY,
			                                    ITEM_NAME,SUBCODE,UNIT,UNITRATE,
			                                    COST_PRICE,RETAIL_PRICE,
			                                    NUM,DOSAGE,
			                                    SDVALUE,AGIO,ACVALUE,
			                                    DELETE_BIT,CZ_FLAG,DISCHARGE_BIT,
			                                    DOC_ID,DEPT_ID,DEPT_BR,EXECDEPT_ID,
			                                    DEPT_LY,JGBM,GCYS,ZFBL,
			                                    TLFS,GG,CJ,FY_BIT, pvs_xh
			                                    ,CHARGE_BIT
		                                    )
                                            values('{0}','{1}','{2}',
                                                    '{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}',
                                                    '{10}','{11}','{12}',
                                                    '{13}','{14}','{15}','{16}',
                                                    '{17}','{18}',
                                                    '{19}','{20}',
                                                    '{21}','{22}','{23}',
                                                    '{24}','{25}','{26}',
                                                    '{27}','{28}','{29}','{30}',
                                                    '{31}','{32}','{33}','{34}',
                                                    '{35}','{36}','{37}','{38}','{39}'
                                                    ,'{40}'
                                                    )",
                                            ettOrdFee.ID, ettOrdFee.INPATIENT_ID, ettOrdFee.BABY_ID,
                                            ettOrdFee.ORDER_ID, ettOrdFee.ORDEREXEC_ID, ettOrdFee.PRESCRIPTION_ID,
                                            ettOrdFee.PRESC_NO, ettOrdFee.PRESC_DATE, ettOrdFee.BOOK_DATE, ettOrdFee.BOOK_USER,
                                            ettOrdFee.STATITEM_CODE, ettOrdFee.XMID, ettOrdFee.XMLY,
                                            ettOrdFee.ITEM_NAME, ettOrdFee.SUBCODE, ettOrdFee.UNIT, ettOrdFee.UNITRATE,
                                            ettOrdFee.COST_PRICE, ettOrdFee.RETAIL_PRICE,
                                            ettOrdFee.NUM, ettOrdFee.DOSAGE,
                                            ettOrdFee.SDVALUE, ettOrdFee.AGIO, ettOrdFee.ACVALUE,
                                            ettOrdFee.DELETE_BIT, ettOrdFee.CZ_FLAG, ettOrdFee.DISCHARGE_BIT,
                                            ettOrdFee.DOC_ID, ettOrdFee.DEPT_ID, ettOrdFee.DEPT_BR, ettOrdFee.EXECDEPT_ID,
                                            ettOrdFee.DEPT_LY, ettOrdFee.JGBM, ettOrdFee.GCYS, ettOrdFee.ZFBL,
                                            ettOrdFee.TLFS, ettOrdFee.GG, ettOrdFee.CJ, ettOrdFee.FY_BIT, ettOrdFee.pvs_xh
                                            , ettOrdFee.CHARGE_BIT);
                    }
                }
                else if (XMLY == 2)
                {
                    if (ettOrdFee.CHARGE_BIT == 1)
                    {
                        ssql = string.Format(@"
	                                        INSERT INTO ZY_FEE_SPECI
			                                 (  ID,INPATIENT_ID,BABY_ID,
				                                ORDER_ID,ORDEREXEC_ID,PRESCRIPTION_ID,
				                                PRESC_NO,PRESC_DATE,BOOK_DATE,BOOK_USER,
				                                STATITEM_CODE,XMID,XMLY,
				                                ITEM_NAME,SUBCODE,UNIT,UNITRATE,
				                                COST_PRICE,RETAIL_PRICE,
				                                NUM,DOSAGE,
				                                SDVALUE,AGIO,ACVALUE,
				                                CHARGE_BIT,CHARGE_DATE,CHARGE_USER,
				                                DELETE_BIT,CZ_FLAG,DISCHARGE_BIT,
				                                DOC_ID,DEPT_ID,DEPT_BR,EXECDEPT_ID,
                                                DEPT_LY,JGBM,GCYS,ZFBL
				                                ,TCID,TC_FLAG
			                                 )
                                            values('{0}','{1}','{2}',
                                                    '{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}',
                                                    '{10}','{11}','{12}',
                                                    '{13}','{14}','{15}','{16}',
                                                    '{17}','{18}',
                                                    '{19}','{20}',
                                                    '{21}','{22}','{23}',
                                                    '{24}','{25}','{26}',
                                                    '{27}','{28}','{29}',
                                                    '{30}','{31}','{32}','{33}',
                                                    '{34}','{35}','{36}','{37}',
                                                    '{38}','{39}'
                                                    )",
                                            ettOrdFee.ID, ettOrdFee.INPATIENT_ID, ettOrdFee.BABY_ID,
                                            ettOrdFee.ORDER_ID, ettOrdFee.ORDEREXEC_ID, ettOrdFee.PRESCRIPTION_ID,
                                            ettOrdFee.PRESC_NO, ettOrdFee.PRESC_DATE, ettOrdFee.BOOK_DATE, ettOrdFee.BOOK_USER,
                                            ettOrdFee.STATITEM_CODE, ettOrdFee.XMID, ettOrdFee.XMLY,
                                            ettOrdFee.ITEM_NAME, ettOrdFee.SUBCODE, ettOrdFee.UNIT, ettOrdFee.UNITRATE,
                                            ettOrdFee.COST_PRICE, ettOrdFee.RETAIL_PRICE,
                                            ettOrdFee.NUM, ettOrdFee.DOSAGE,
                                            ettOrdFee.SDVALUE, ettOrdFee.AGIO, ettOrdFee.ACVALUE,
                                            ettOrdFee.CHARGE_BIT, ettOrdFee.CHARGE_DATE, ettOrdFee.CHARGE_USER,
                                            ettOrdFee.DELETE_BIT, ettOrdFee.CZ_FLAG, ettOrdFee.DISCHARGE_BIT,
                                            ettOrdFee.DOC_ID, ettOrdFee.DEPT_ID, ettOrdFee.DEPT_BR, ettOrdFee.EXECDEPT_ID,
                                            ettOrdFee.DEPT_LY, ettOrdFee.JGBM, ettOrdFee.GCYS, ettOrdFee.ZFBL,
                                            ettOrdFee.TCID, ettOrdFee.TC_FLAG);
                    }
                    else
                    {
                        ssql = string.Format(@"
	                                        INSERT INTO ZY_FEE_SPECI
			                                 (  ID,INPATIENT_ID,BABY_ID,
				                                ORDER_ID,ORDEREXEC_ID,PRESCRIPTION_ID,
				                                PRESC_NO,PRESC_DATE,BOOK_DATE,BOOK_USER,
				                                STATITEM_CODE,XMID,XMLY,
				                                ITEM_NAME,SUBCODE,UNIT,UNITRATE,
				                                COST_PRICE,RETAIL_PRICE,
				                                NUM,DOSAGE,
				                                SDVALUE,AGIO,ACVALUE,
				                                DELETE_BIT,CZ_FLAG,DISCHARGE_BIT,
				                                DOC_ID,DEPT_ID,DEPT_BR,EXECDEPT_ID,
                                                DEPT_LY,JGBM,GCYS,ZFBL
				                                ,TCID,TC_FLAG,CHARGE_BIT
			                                 )
                                            values('{0}','{1}','{2}',
                                                    '{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}',
                                                    '{10}','{11}','{12}',
                                                    '{13}','{14}','{15}','{16}',
                                                    '{17}','{18}',
                                                    '{19}','{20}',
                                                    '{21}','{22}','{23}',
                                                    '{24}','{25}','{26}',
                                                    '{27}','{28}','{29}','{30}',
                                                    '{31}','{32}','{33}','{34}',
                                                    '{35}','{36}','{37}'
                                                    )",
                                            ettOrdFee.ID, ettOrdFee.INPATIENT_ID, ettOrdFee.BABY_ID,
                                            ettOrdFee.ORDER_ID, ettOrdFee.ORDEREXEC_ID, ettOrdFee.PRESCRIPTION_ID,
                                            ettOrdFee.PRESC_NO, ettOrdFee.PRESC_DATE, ettOrdFee.BOOK_DATE, ettOrdFee.BOOK_USER,
                                            ettOrdFee.STATITEM_CODE, ettOrdFee.XMID, ettOrdFee.XMLY,
                                            ettOrdFee.ITEM_NAME, ettOrdFee.SUBCODE, ettOrdFee.UNIT, ettOrdFee.UNITRATE,
                                            ettOrdFee.COST_PRICE, ettOrdFee.RETAIL_PRICE,
                                            ettOrdFee.NUM, ettOrdFee.DOSAGE,
                                            ettOrdFee.SDVALUE, ettOrdFee.AGIO, ettOrdFee.ACVALUE,
                                            ettOrdFee.DELETE_BIT, ettOrdFee.CZ_FLAG, ettOrdFee.DISCHARGE_BIT,
                                            ettOrdFee.DOC_ID, ettOrdFee.DEPT_ID, ettOrdFee.DEPT_BR, ettOrdFee.EXECDEPT_ID,
                                            ettOrdFee.DEPT_LY, ettOrdFee.JGBM, ettOrdFee.GCYS, ettOrdFee.ZFBL,
                                            ettOrdFee.TCID, ettOrdFee.TC_FLAG, ettOrdFee.CHARGE_BIT);
                    }

                }

                #endregion
            }
            else if (iType == 1)
            {
                #region"负费用"

                if (ettOrdFee.CHARGE_BIT == 1)
                {
                    ssql = string.Format(@"
                            INSERT INTO ZY_FEE_SPECI
                            (	
                                ID,ORDER_ID,PRESCRIPTION_ID,ORDEREXEC_ID,PRESC_DATE,BOOK_DATE,BOOK_USER,
		   	   	                PRESC_NO,STATITEM_CODE,XMID,TCID,TC_FLAG,INPATIENT_ID,BABY_ID,
		   	   	                ITEM_NAME,SUBCODE,XMLY,UNIT,UNITRATE,DOSAGE,COST_PRICE, RETAIL_PRICE, 
		   	   	                AGIO, EXECDEPT_ID,DEPT_ID,DEPT_BR,DEPT_LY,DOC_ID,CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT,
		   	   	                NUM,
					            SDVALUE,
					            ACVALUE,
					            TYPE,TLFS,
					            CHARGE_BIT,CHARGE_USER,CHARGE_DATE,BZ,JGBM,GG,CJ,GCYS,FY_BIT,pvs_xh,ZFBL
                            )
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',
                                    '{7}','{8}','{9}','{10}','{11}','{12}','{13}',
                                    '{14}','{15}','{16}','{17}','{18}', '{19}','{20}','{21}',
                                    '{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}',
                                    '{32}',
                                    '{33}',
                                    '{34}',
                                    '{35}','{36}',
                                    '{37}',
                                    '{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}')",
                            ettOrdFee.ID, ettOrdFee.ORDER_ID, ettOrdFee.PRESCRIPTION_ID, ettOrdFee.ORDEREXEC_ID, ettOrdFee.PRESC_DATE, ettOrdFee.BOOK_DATE, ettOrdFee.BOOK_USER,
                            ettOrdFee.PRESC_NO, ettOrdFee.STATITEM_CODE, ettOrdFee.XMID, ettOrdFee.TCID, ettOrdFee.TC_FLAG, ettOrdFee.INPATIENT_ID, ettOrdFee.BABY_ID,
                            ettOrdFee.ITEM_NAME, ettOrdFee.SUBCODE, ettOrdFee.XMLY, ettOrdFee.UNIT, ettOrdFee.UNITRATE, ettOrdFee.DOSAGE, ettOrdFee.COST_PRICE, ettOrdFee.RETAIL_PRICE,
                            ettOrdFee.AGIO, ettOrdFee.EXECDEPT_ID, ettOrdFee.DEPT_ID, ettOrdFee.DEPT_BR, ettOrdFee.DEPT_LY, ettOrdFee.DOC_ID, ettOrdFee.CZ_FLAG, ettOrdFee.CZ_ID, ettOrdFee.DELETE_BIT, ettOrdFee.DISCHARGE_BIT,
                            ettOrdFee.NUM,
                            ettOrdFee.SDVALUE,
                            ettOrdFee.ACVALUE,
                            ettOrdFee.TYPE, ettOrdFee.TLFS,
                            ettOrdFee.CHARGE_BIT, ettOrdFee.CHARGE_USER, ettOrdFee.CHARGE_DATE, ettOrdFee.BZ, ettOrdFee.JGBM, ettOrdFee.GG, ettOrdFee.CJ, ettOrdFee.GCYS, ettOrdFee.FY_BIT, ettOrdFee.pvs_xh, ettOrdFee.ZFBL);

                }
                else
                {
                    ssql = string.Format(@"
                            INSERT INTO ZY_FEE_SPECI
                            (	
                                ID,ORDER_ID,PRESCRIPTION_ID,ORDEREXEC_ID,PRESC_DATE,BOOK_DATE,BOOK_USER,
		   	   	                PRESC_NO,STATITEM_CODE,XMID,TCID,TC_FLAG,INPATIENT_ID,BABY_ID,
		   	   	                ITEM_NAME,SUBCODE,XMLY,UNIT,UNITRATE,DOSAGE,COST_PRICE, RETAIL_PRICE, 
		   	   	                AGIO, EXECDEPT_ID,DEPT_ID,DEPT_BR,DEPT_LY,DOC_ID,CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT,
		   	   	                NUM,
					            SDVALUE,
					            ACVALUE,
					            TYPE,TLFS,
					            CHARGE_BIT,BZ,JGBM,GG,CJ,GCYS,FY_BIT,pvs_xh,ZFBL
                            )
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',
                                    '{7}','{8}','{9}','{10}','{11}','{12}','{13}',
                                    '{14}','{15}','{16}','{17}','{18}', '{19}','{20}','{21}',
                                    '{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}',
                                    '{32}',
                                    '{33}',
                                    '{34}',
                                    '{35}','{36}',
                                    '{37}',
                                    '{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}')",
                            ettOrdFee.ID, ettOrdFee.ORDER_ID, ettOrdFee.PRESCRIPTION_ID, ettOrdFee.ORDEREXEC_ID, ettOrdFee.PRESC_DATE, ettOrdFee.BOOK_DATE, ettOrdFee.BOOK_USER,
                            ettOrdFee.PRESC_NO, ettOrdFee.STATITEM_CODE, ettOrdFee.XMID, ettOrdFee.TCID, ettOrdFee.TC_FLAG, ettOrdFee.INPATIENT_ID, ettOrdFee.BABY_ID,
                            ettOrdFee.ITEM_NAME, ettOrdFee.SUBCODE, ettOrdFee.XMLY, ettOrdFee.UNIT, ettOrdFee.UNITRATE, ettOrdFee.DOSAGE, ettOrdFee.COST_PRICE, ettOrdFee.RETAIL_PRICE,
                            ettOrdFee.AGIO, ettOrdFee.EXECDEPT_ID, ettOrdFee.DEPT_ID, ettOrdFee.DEPT_BR, ettOrdFee.DEPT_LY, ettOrdFee.DOC_ID, ettOrdFee.CZ_FLAG, ettOrdFee.CZ_ID, ettOrdFee.DELETE_BIT, ettOrdFee.DISCHARGE_BIT,
                            ettOrdFee.NUM,
                            ettOrdFee.SDVALUE,
                            ettOrdFee.ACVALUE,
                            ettOrdFee.TYPE, ettOrdFee.TLFS,
                            ettOrdFee.CHARGE_BIT, ettOrdFee.BZ, ettOrdFee.JGBM, ettOrdFee.GG, ettOrdFee.CJ, ettOrdFee.GCYS, ettOrdFee.FY_BIT, ettOrdFee.pvs_xh, ettOrdFee.ZFBL);

                }

                #endregion
            }
            else if (iType == 2)
            {
                #region"附加费用"
                #endregion
            }

            return ssql;
        }

    }
}
