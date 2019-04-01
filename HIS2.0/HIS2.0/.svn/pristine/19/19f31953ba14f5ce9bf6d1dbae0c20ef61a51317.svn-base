using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;
using TrasenClasses.GeneralClasses;
using System.Collections;

namespace LED_RemotingServer
{
    public class CallAccess
    {
        public CallAccess(RelationalDatabase database)
        {
            this.database = database;
        }

        private RelationalDatabase database = null;

        /// <summary>
        /// 叫号列表
        /// </summary>
        /// <param name="deptid">科室</param>
        /// <returns></returns>
        public DataTable OrderArry(string deptid, string str,string countpe)
        {
            DataTable dt = null;
            string timenow = DateManager.ServerDateTimeByDBType(database).ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(timenow))
            {
                timenow = DateTime.Now.ToString("yyyy-MM-dd");
            }
            if (string.IsNullOrEmpty(countpe))
                countpe = "10";
            string sql = "select top " + countpe + @" a.BRXM 姓名
           ,A.fph 发票号
           ,A.zje 金额
           ,a.brxxid
           --,(case when b.bdybz is null then 0 else 1 end) 打印
           ,a.SFRQ
           ,a.fpid
           from mz_FPB a (nolock) LEFT JOIN YF_FYJH B(NOLOCK) 
              ON A.FPID=B.FPID  
              where a.JLZT=0 AND A.BSCBZ=0
            and b.bdybz=1
            and a.fpid in(select fpid  from MZ_CFB b(nolock) where B.XMLY=1 and B.BSCBZ=0 and b.ZXKS=" + deptid + @"
              AND BFYBZ=0 and SFRQ>='" + timenow + " 00:00:00' and SFRQ<='" + timenow + " 23:59:59' "
              + str + ") order by a.SFRQ";
            dt = database.GetDataTable(sql);
            return dt;
        }
    }
}
