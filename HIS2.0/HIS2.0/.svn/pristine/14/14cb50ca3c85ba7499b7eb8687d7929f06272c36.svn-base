using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;

namespace ts_zyhs_classes
{
    public class OrderEntity : IComparable<OrderEntity>
    {
        public Guid ORDER_ID;
        public Guid INPATIENT_ID;
        public Guid? PS_ORDERID;
        public Guid? TsApply_id;
        public Guid? ppcl_yzid;
        public Guid? MBXH;

        public decimal PRICE;//decimal(18,2)
        public decimal? zsl;//decimal(18,3)
        public decimal? zfbl;//decimal(18,3)

        public long BABY_ID;
        public long DEPT_BR;
        public long DEPT_ID;
        public long ORDER_DOC;
        public long HOITEM_ID;
        public long EXEC_DEPT;
        public long? ORDER_EDOC;
        public long? ORDER_EUSER;
        public long JGBM;
        public long? LASTEXECUSER;

        public long? AUDITING_USER;
        public long? AUDITING_USER1;
        public long? AUDITING_USER2;
        public long? ORDER_EUSER1;
        public long? ORDER_EUSER2;
        public long OPERATOR;
        public long? PS_USER;
        public long WZX_FLAG;
        public long check_user;

        public DateTime BOOK_DATE;
        public DateTime ORDER_BDATE;
        public DateTime? ORDER_EDATE;
        public DateTime? LASTEXECDATE;

        public DateTime? AUDITING_DATE;
        public DateTime? AUDITING_DATE1;
        public DateTime? AUDITING_DATE2;
        public DateTime? ORDER_EUDATE;
        public DateTime? ORDER_EUDATE1;
        public DateTime? ORDER_EUDATE2;
        public DateTime? check_date;
        public DateTime? Inspection_time;

        public int MNGTYPE;
        public int NTYPE;
        public int GROUP_ID;
        public int SERIAL_NO;
        public int XMLY;
        public decimal NUM;
        public int DOSAGE;
        public int DWLX;
        public int FIRST_TIMES;
        public int? TERMINAL_TIMES;
        public int STATUS_FLAG;
        public int DELETE_BIT;
        public int JZ_FLAG;
        public int ISKDKSLY;
        public int Apply_type;
        public int ts;
        public int ZHBJ;
        public int is_PvsChk;//武汉版本
        public int isGCP;

        public int tkxs;
        public int ssmz_print;
        public int DEL_PRINT;
        public int IsprintYPGG;
        public int jsd;
        public int KJYWZY;
        public int DC_FLAG;
        public int CZ_STATE;
        public int highprice_passbit;
        public int antibiotics_ts;
        public int ExpandType;
        public int IS_DECOCT;
        public int IsprintCF;
        public int ResultsConfirm;
        public int MedicalResults;
        public int OrderSortNo;
        public int PS_FLAG;

        public string WARD_ID;
        public string ITEM_CODE;
        public string ORDER_CONTEXT;
        public string UNIT;
        public string ORDER_SPEC;
        public string ORDER_USAGE;
        public string FREQUENCY;
        public string DROPSPER;
        public string MEMO;
        public string MEMO1;
        public string zsldw;
        public string jldwlx;

        public string MEMO2;
        public string BTSSHBZ;
        public string Use_antibiotics;
        public string IS_consultation;
        public string IS_inspection;
        public string zcshr;
        public string zcshsj;
        public string zctzshr;
        public string zctzshsj;
        public string AuditState;

        public OrderEntity()
        {
        }

        public OrderEntity(DataRow dr)
        {

            ORDER_ID = new Guid(dr["ORDER_ID"].ToString());
            INPATIENT_ID = new Guid(dr["INPATIENT_ID"].ToString());

            PRICE = decimal.Parse(Convertor.IsNull(dr["PRICE"], "0"));
            NUM = decimal.Parse(Convertor.IsNull(dr["NUM"], "0"));
            if (Convertor.IsNull(dr["zsl"], "-1").Equals("-1"))
            {
                zsl = null;
            }
            else
            {
                zsl = decimal.Parse(dr["zsl"].ToString());
            }

            if (Convertor.IsNull(dr["zfbl"], "-1").Equals("-1"))
            {
                zfbl = null;
            }
            else
            {
                zfbl = decimal.Parse(dr["zfbl"].ToString());
            }

            BABY_ID = long.Parse(Convertor.IsNull(dr["BABY_ID"], "0"));
            DEPT_BR = long.Parse(Convertor.IsNull(dr["DEPT_BR"], "0"));
            DEPT_ID = long.Parse(Convertor.IsNull(dr["DEPT_ID"], "0"));
            ORDER_DOC = long.Parse(Convertor.IsNull(dr["ORDER_DOC"], "0"));
            HOITEM_ID = long.Parse(Convertor.IsNull(dr["HOITEM_ID"], "0"));
            EXEC_DEPT = long.Parse(Convertor.IsNull(dr["EXEC_DEPT"], "0"));
            JGBM = long.Parse(Convertor.IsNull(dr["JGBM"], "0"));

            if (Convertor.IsNull(dr["ORDER_EDOC"], "-1").Equals("-1"))
            {
                ORDER_EDOC = null;
            }
            else
            {
                ORDER_EDOC = long.Parse(dr["ORDER_EDOC"].ToString());
            }

            if (Convertor.IsNull(dr["ORDER_EUSER"], "-1").Equals("-1"))
            {
                ORDER_EUSER = null;
            }
            else
            {
                ORDER_EUSER = long.Parse(dr["ORDER_EUSER"].ToString());
            }

            if (Convertor.IsNull(dr["LASTEXECUSER"], "-1").Equals("-1"))
            {
                LASTEXECUSER = null;
            }
            else
            {
                LASTEXECUSER = long.Parse(dr["LASTEXECUSER"].ToString());
            }

            BOOK_DATE = DateTime.Parse(dr["BOOK_DATE"].ToString());
            ORDER_BDATE = DateTime.Parse(dr["ORDER_BDATE"].ToString());

            if (Convertor.IsNull(dr["ORDER_EDATE"], "-1").Equals("-1"))
            {
                ORDER_EDATE = null;
            }
            else
            {
                ORDER_EDATE = DateTime.Parse(dr["ORDER_EDATE"].ToString());
            }

            if (Convertor.IsNull(dr["LASTEXECDATE"], "-1").Equals("-1"))
            {
                LASTEXECDATE = null;
            }
            else
            {
                LASTEXECDATE = DateTime.Parse(dr["LASTEXECDATE"].ToString());
            }

            MNGTYPE = int.Parse(Convertor.IsNull(dr["MNGTYPE"], "0"));
            NTYPE = int.Parse(Convertor.IsNull(dr["NTYPE"], "0"));
            GROUP_ID = int.Parse(Convertor.IsNull(dr["GROUP_ID"], "0"));
            SERIAL_NO = int.Parse(Convertor.IsNull(dr["SERIAL_NO"], "0"));
            XMLY = int.Parse(Convertor.IsNull(dr["XMLY"], "0"));
            STATUS_FLAG = int.Parse(Convertor.IsNull(dr["STATUS_FLAG"], "0"));
            DELETE_BIT = int.Parse(Convertor.IsNull(dr["DELETE_BIT"], "0"));

            FIRST_TIMES = int.Parse(Convertor.IsNull(dr["FIRST_TIMES"], "0"));
            DOSAGE = int.Parse(Convertor.IsNull(dr["DOSAGE"], "0"));
            DWLX = int.Parse(Convertor.IsNull(dr["DWLX"], "0"));

            if (Convertor.IsNull(dr["TERMINAL_TIMES"], "-1").Equals("-1"))
            {
                TERMINAL_TIMES = null;
            }
            else
            {
                TERMINAL_TIMES = int.Parse(dr["TERMINAL_TIMES"].ToString());
            }

            JZ_FLAG = int.Parse(Convertor.IsNull(dr["JZ_FLAG"], "0"));
            ISKDKSLY = int.Parse(Convertor.IsNull(dr["ISKDKSLY"], "0"));

            Apply_type = int.Parse(Convertor.IsNull(dr["Apply_type"], "0"));
            ts = int.Parse(Convertor.IsNull(dr["ts"], "0"));
            ZHBJ = int.Parse(Convertor.IsNull(dr["ZHBJ"], "0"));
            is_PvsChk = int.Parse(Convertor.IsNull(dr["is_PvsChk"], "0"));//武汉版本
            //isGCP = int.Parse(Convertor.IsNull(dr["isGCP"], "0"));//武汉没有

            WARD_ID = Convertor.IsNull(dr["WARD_ID"], "");
            ITEM_CODE = Convertor.IsNull(dr["ITEM_CODE"], "");
            ORDER_CONTEXT = Convertor.IsNull(dr["ORDER_CONTEXT"], "");
            UNIT = Convertor.IsNull(dr["UNIT"], "");
            ORDER_SPEC = Convertor.IsNull(dr["ORDER_SPEC"], "");
            ORDER_USAGE = Convertor.IsNull(dr["ORDER_USAGE"], "");
            FREQUENCY = Convertor.IsNull(dr["FREQUENCY"], "");
            DROPSPER = Convertor.IsNull(dr["DROPSPER"], "");
            MEMO = Convertor.IsNull(dr["MEMO"], "");
            MEMO1 = Convertor.IsNull(dr["MEMO1"], "");
            zsldw = Convertor.IsNull(dr["zsldw"], "");
            jldwlx = Convertor.IsNull(dr["jldwlx"], "");

            //ORDER_ID = Guid.NewGuid(Convertor.IsNull(dr["ORDER_ID"], Guid.Empty));
            //INPATIENT_ID = Guid.NewGuid(Convertor.IsNull(dr["ORDER_ID"], Guid.Empty));
            //BABY_ID = long.Parse(Convertor.IsNull(dr["BABY_ID"], "0"));
            //WARD_ID = Convertor.IsNull(dr[""], "");
            //DEPT_BR = Convertor.IsNull(dr[""], "");
            //DEPT_ID = Convertor.IsNull(dr[""], "");
            //MNGTYPE = Convertor.IsNull(dr[""], "");
            //ORDER_DOC = Convertor.IsNull(dr[""], "");
            //ORDER_BDATE = Convertor.IsNull(dr[""], "");
            //NTYPE = Convertor.IsNull(dr[""], "");
            //GROUP_ID = Convertor.IsNull(dr[""], "");
            //SERIAL_NO = Convertor.IsNull(dr[""], "");
            //HOITEM_ID = Convertor.IsNull(dr[""], "");
            //XMLY = Convertor.IsNull(dr[""], "");
            //ITEM_CODE = Convertor.IsNull(dr[""], "");
            //ORDER_CONTEXT = Convertor.IsNull(dr[""], "");
            //NUM = Convertor.IsNull(dr[""], "");
            //DOSAGE = Convertor.IsNull(dr[""], "");
            //UNIT = Convertor.IsNull(dr[""], "");
            //DWLX = Convertor.IsNull(dr[""], "");
            //ORDER_SPEC = Convertor.IsNull(dr[""], "");
            //ORDER_USAGE = Convertor.IsNull(dr[""], "");
            //FREQUENCY = Convertor.IsNull(dr[""], "");
            //DROPSPER = Convertor.IsNull(dr[""], "");
            //EXEC_DEPT = Convertor.IsNull(dr[""], "");
            //FIRST_TIMES = Convertor.IsNull(dr[""], "");
            //TERMINAL_TIMES = Convertor.IsNull(dr[""], "");
            //AUDITING_USER = Convertor.IsNull(dr[""], "");
            //AUDITING_DATE = Convertor.IsNull(dr[""], "");
            //AUDITING_USER1 = Convertor.IsNull(dr[""], "");
            //AUDITING_DATE1 = Convertor.IsNull(dr[""], "");
            //AUDITING_USER2 = Convertor.IsNull(dr[""], "");
            //AUDITING_DATE2 = Convertor.IsNull(dr[""], "");
            //ORDER_EDATE = Convertor.IsNull(dr[""], "");
            //ORDER_EDOC = Convertor.IsNull(dr[""], "");
            //ORDER_EUSER = Convertor.IsNull(dr[""], "");
            //ORDER_EUDATE = Convertor.IsNull(dr[""], "");
            //ORDER_EUSER1 = Convertor.IsNull(dr[""], "");
            //ORDER_EUDATE1 = Convertor.IsNull(dr[""], "");
            //ORDER_EUSER2 = Convertor.IsNull(dr[""], "");
            //ORDER_EUDATE2 = Convertor.IsNull(dr[""], "");
            //STATUS_FLAG = Convertor.IsNull(dr[""], "");
            //OPERATOR = Convertor.IsNull(dr[""], "");
            //BOOK_DATE = Convertor.IsNull(dr[""], "");
            //DELETE_BIT = Convertor.IsNull(dr[""], "");
            //PS_FLAG = Convertor.IsNull(dr[""], "");
            //PS_ORDERID = Convertor.IsNull(dr[""], "");
            //PS_USER = Convertor.IsNull(dr[""], "");
            //WZX_FLAG = Convertor.IsNull(dr[""], "");
            //JZ_FLAG = Convertor.IsNull(dr[""], "");
            //PRICE = Convertor.IsNull(dr[""], "");
            //MEMO = Convertor.IsNull(dr[""], "");
            //MEMO1 = Convertor.IsNull(dr[""], "");
            //ssmz_print = Convertor.IsNull(dr[""], "");
            //JGBM = Convertor.IsNull(dr[""], "");
            //ISKDKSLY = Convertor.IsNull(dr[""], "");
            //LASTEXECDATE = Convertor.IsNull(dr[""], "");
            //LASTEXECUSER = Convertor.IsNull(dr[""], "");
            //DEL_PRINT = Convertor.IsNull(dr[""], "");
            //TsApply_id = Convertor.IsNull(dr[""], "");
            //Apply_type = Convertor.IsNull(dr[""], "");
            //IsprintYPGG = Convertor.IsNull(dr[""], "");
            //jsd = Convertor.IsNull(dr[""], "");
            //ts = Convertor.IsNull(dr[""], "");
            //zsl = Convertor.IsNull(dr[""], "");
            //zsldw = Convertor.IsNull(dr[""], "");
            //jldwlx = Convertor.IsNull(dr[""], "");
            //MEMO2 = Convertor.IsNull(dr[""], "");
            //ZHBJ = Convertor.IsNull(dr[""], "");
            //KJYWZY = Convertor.IsNull(dr[""], "");
            //zfbl = Convertor.IsNull(dr[""], "");
            //tkxs = Convertor.IsNull(dr[""], "");
            //ppcl_yzid = Convertor.IsNull(dr[""], "");
            //MBXH = Convertor.IsNull(dr[""], "");
            //DC_FLAG = Convertor.IsNull(dr[""], "");
            //BTSSHBZ = Convertor.IsNull(dr[""], "");
            //CZ_STATE = Convertor.IsNull(dr[""], "");
            //highprice_passbit = Convertor.IsNull(dr[""], "");
            //isGCP = Convertor.IsNull(dr[""], "");
            //check_user = Convertor.IsNull(dr[""], "");
            //check_date = Convertor.IsNull(dr[""], "");
            //Inspection_time = Convertor.IsNull(dr[""], "");
            //Use_antibiotics = Convertor.IsNull(dr[""], "");
            //IS_consultation = Convertor.IsNull(dr[""], "");
            //IS_inspection = Convertor.IsNull(dr[""], "");
            //antibiotics_ts = Convertor.IsNull(dr[""], "");
            //ExpandType = Convertor.IsNull(dr[""], "");
            //zcshr = Convertor.IsNull(dr[""], "");
            //zcshsj = Convertor.IsNull(dr[""], "");
            //IS_DECOCT = Convertor.IsNull(dr[""], "");
            //IsprintCF = Convertor.IsNull(dr[""], "");
            //zctzshr = Convertor.IsNull(dr[""], "");
            //zctzshsj = Convertor.IsNull(dr[""], "");
            //AuditState = Convertor.IsNull(dr[""], "");
            //ResultsConfirm = Convertor.IsNull(dr[""], "");
            //MedicalResults = Convertor.IsNull(dr[""], "");
            //OrderSortNo = Convertor.IsNull(dr[""], "");
            //is_PvsChk = Convertor.IsNull(dr[""], "");
        }

        public int CompareTo(OrderEntity other)
        {
            if (other == null)
                return 1;

            int value = other.EXEC_DEPT.CompareTo(this.EXEC_DEPT);//优先执行科室排序从大到小

            if (value == 0)
                value = this.SERIAL_NO - other.SERIAL_NO;//执行科室相同则SERIAL_NO 从小到大

            return value;
        }
    }
}
