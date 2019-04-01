using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;

namespace ts_zyhs_classes
{
    public class OrderExecEntity : IComparable<OrderExecEntity>
    {
        public Guid ID;
        public Guid ORDER_ID;
        public DateTime BOOK_DATE;
        public DateTime EXECDATE;
        public long EXEUSER;
        public int ISANALYZED;
        public string PRESCRIPTION_ID;//(21,6)
        public Guid INPATIENT_ID;
        public long BABY_ID;
        public long JGBM;
        public int PVS_XH;

        public DateTime? REALEXECDATE;
        public long? REALEXEUSER;
        public long? REALEXEUSERDb;
        public DateTime? REALEXECDATE_double;

        public OrderExecEntity()
        {
        }

        public OrderExecEntity(DataRow dr)
        {
            ID = new Guid(dr["ID"].ToString());
            ORDER_ID = new Guid(dr["ORDER_ID"].ToString());

            BOOK_DATE = DateTime.Parse(dr["BOOK_DATE"].ToString());
            EXECDATE = DateTime.Parse(dr["EXECDATE"].ToString());
            EXEUSER = long.Parse(Convertor.IsNull(dr["EXEUSER"], "0"));

            ISANALYZED = int.Parse(Convertor.IsNull(dr["ISANALYZED"], "0"));
            PRESCRIPTION_ID = Convertor.IsNull(dr["PRESCRIPTION_ID"], "0");

            INPATIENT_ID = new Guid(dr["INPATIENT_ID"].ToString());
            BABY_ID = long.Parse(Convertor.IsNull(dr["BABY_ID"], "0"));
            JGBM = long.Parse(Convertor.IsNull(dr["JGBM"], "0"));
        }

        public int CompareTo(OrderExecEntity other)
        {
            if (other == null)
                return 1;

            int value = other.EXECDATE.CompareTo(this.EXECDATE);//优先执行时间从大到小

            return value;
        }

        public string AddExecInfo()
        {

            string ssql = string.Format(@"INSERT INTO ZY_ORDEREXEC 
                                        (ID,BOOK_DATE,ORDER_ID,EXEUSER,EXECDATE,ISANALYZED,
                                            PRESCRIPTION_ID,INPATIENT_ID,BABY_ID,JGBM,pvs_xh)
                                            values('{0}','{1}','{2}','{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}','{10}')",
                                 ID, BOOK_DATE, ORDER_ID, EXEUSER, EXECDATE, ISANALYZED,
                                            PRESCRIPTION_ID, INPATIENT_ID, BABY_ID, JGBM, PVS_XH);

            return ssql;
        }

        public string AddExecInfo(OrderExecEntity ettOrdExe)
        {

            string ssql = string.Format(@"INSERT INTO ZY_ORDEREXEC 
                                        (ID,BOOK_DATE,ORDER_ID,EXEUSER,EXECDATE,ISANALYZED,
                                            PRESCRIPTION_ID,INPATIENT_ID,BABY_ID,JGBM,pvs_xh)
                                            values('{0}','{1}','{2}','{3}','{4}','{5}',
                                                    '{6}','{7}','{8}','{9}','{10}')",
                                            ettOrdExe.ID, ettOrdExe.BOOK_DATE, ettOrdExe.ORDER_ID, ettOrdExe.EXEUSER, ettOrdExe.EXECDATE, ettOrdExe.ISANALYZED,
                                            ettOrdExe.PRESCRIPTION_ID, ettOrdExe.INPATIENT_ID, ettOrdExe.BABY_ID, ettOrdExe.JGBM, ettOrdExe.PVS_XH);

            return ssql;
        }
    }
}
