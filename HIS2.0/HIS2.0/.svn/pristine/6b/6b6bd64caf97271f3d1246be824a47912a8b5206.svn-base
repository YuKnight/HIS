using System;
using System.Collections.Generic;
using System.Text;

namespace ts_zyhs_classes
{
    public class OrderPrescEntity
    {
        public Guid ID;
        public Guid INPATIENT_ID;
        public long BABY_ID;
        public DateTime BOOK_DATE;
        public long BOOK_USER;
        public string PRESC_NO;//decimal(21,6)
        public DateTime PRESC_DATE;
        public Guid SOURCE_ID;
        public Guid ORDER_ID;
        public int TYPE;
        public long DEPT_ID;
        public long EXECDEPT_ID;
        public long PRESC_DOC;
        public long HDITEM_ID;
        public int XMLY;
        public string STATITEM_CODE;
        public string SUBCODE;
        public string STANDARD;
        public int DOSAGE;
        public string UNIT;
        public int UNITRATE;
        public decimal PRICE;
        public int AGIO;
        public decimal NUM;
        public int CHARGE_BIT;
        public long JGBM;
        public long TCID;
        public int TC_FLAG;


        public string AddPrescInfo(int iXmly)
        {
            string ssql = "";

            if (iXmly == 1)
            {
                ssql = string.Format(@"INSERT INTO ZY_PRESCRIPTION
			                                (ID,INPATIENT_ID,BABY_ID,BOOK_DATE,BOOK_USER,PRESC_NO,
                                                PRESC_DATE, SOURCE_ID,ORDER_ID,TYPE,DEPT_ID,
                                                EXECDEPT_ID,PRESC_DOC,HDITEM_ID,XMLY,STATITEM_CODE,
                                                SUBCODE,STANDARD,DOSAGE,   UNIT,UNITRATE,
                                                PRICE,AGIO,NUM,CHARGE_BIT,JGBM)
                                            values('{0}','{1}','{2}','{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}','{10}',
                                                    '{11}','{12}','{13}','{14}','{15}',
                                                    '{16}','{17}','{18}','{19}','{20}',
                                                    '{21}','{22}','{23}','{24}','{25}')",
                                    ID, INPATIENT_ID, BABY_ID, BOOK_DATE, BOOK_USER, PRESC_NO,
                                                PRESC_DATE, SOURCE_ID, ORDER_ID, TYPE, DEPT_ID,
                                                EXECDEPT_ID, PRESC_DOC, HDITEM_ID, XMLY, STATITEM_CODE,
                                                SUBCODE, STANDARD, DOSAGE, UNIT, UNITRATE,
                                                PRICE, AGIO, NUM, CHARGE_BIT, JGBM);
            }
            else if (iXmly == 2)
            {
                ssql = string.Format(@"INSERT INTO ZY_PRESCRIPTION
			                                (ID,SOURCE_ID,INPATIENT_ID,PRESC_NO,DEPT_ID,EXECDEPT_ID,
                                                HDITEM_ID,XMLY,STATITEM_CODE,TCID,TC_FLAG,
                                                PRESC_DATE,PRESC_DOC,UNIT,UNITRATE,PRICE,
                                                AGIO,NUM,DOSAGE,BABY_ID,SUBCODE,
                                                CHARGE_BIT,BOOK_DATE,BOOK_USER,ORDER_ID,TYPE,
                                                STANDARD,JGBM)
                                            values('{0}','{1}','{2}','{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}','{10}',
                                                    '{11}','{12}','{13}','{14}','{15}',
                                                    '{16}','{17}','{18}','{19}','{20}',
                                                    '{21}','{22}','{23}','{24}','{25}'
                                                    ,'{26}','{27}')",
                                    ID, SOURCE_ID, INPATIENT_ID, PRESC_NO, DEPT_ID, EXECDEPT_ID,
                                                HDITEM_ID, XMLY, STATITEM_CODE, TCID, TC_FLAG,
                                                PRESC_DATE, PRESC_DOC, UNIT, UNITRATE, PRICE,
                                                AGIO, NUM, DOSAGE, BABY_ID, SUBCODE,
                                                CHARGE_BIT, BOOK_DATE, BOOK_USER, ORDER_ID, TYPE,
                                                STANDARD, JGBM);
            }

            return ssql;
        }
    }
}
