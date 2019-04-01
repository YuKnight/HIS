using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenFrame.Forms;

namespace ts_zyhs_yzgl
{
    public class CzDataAccess
    {
        /// <summary>
        /// 获取科室信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetDeptInfo(string condition)
        {
            string sql = @"select -1 id,'全部' name union all  select  a.dept_id id,dbo.fun_getDeptname(a.DEPT_ID) name from JC_DEPT_TYPE_RELATION a join jc_dept_property b on a.dept_id=b.dept_id  where a.type_code='004' and b.zy_flag=1 ";
            if (!string.IsNullOrEmpty(condition))
                sql += condition;
            return FrmMdiMain.Database.GetDataTable(sql);
        }

        /// <summary>
        /// 病区科室是否存在
        /// </summary>
        /// <param name="detpid">科室ID</param>
        /// <returns></returns>
        public bool IsExistWardDept(string detpid)
        {
            string sql = @"select COUNT(1) AS num  from JC_WARDRDEPT  a  join jc_dept_property b on a.dept_id=b.dept_id where  b.zy_flag=1 and ward_id in(select ward_id from JC_WARDRDEPT where DEPT_ID=" + detpid + ")";
            return Convert.ToInt32(FrmMdiMain.Database.GetDataTable(sql).Rows[0]["num"].ToString()) > 0;
        }

        /// <summary>
        /// 获取冲正统计信息
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public DataTable GetCZStatistics(int deptid,string starttime,string endtime,bool showZdcz)
        {
            string sql = @"SELECT dbo.fun_getEmpName(a.BOOK_USER) 冲正人
                  ,SUM(a.ACVALUE) 冲正总金额
                  FROM ZY_FEE_SPECI a INNER JOIN ZY_ORDERRECORD b on a.ORDER_ID=b.ORDER_ID  
                              LEFT JOIN VI_ZY_VINPATIENT_ALL c on a.INPATIENT_ID=c.INPATIENT_ID and a.BABY_ID=c.BABY_ID
                                      WHERE CZ_FLAG in(2,3)  AND a.DELETE_BIT=0 ";//附加费用也要
           
            if (starttime != null)
                sql += " and  a.book_date >='" + starttime + " 00:00:00' ";
            if (endtime != null)
                sql += " and a.book_date<='" + endtime + " 23:59:59'" ;
            if (!showZdcz)
                sql += " and (BZ not like '%系统自动冲正%' OR BZ IS NULL) ";
            if (deptid > 0)
                sql += "  and b.DEPT_BR in (select dept_id  from JC_WARDRDEPT where ward_id in(select ward_id from JC_WARDRDEPT where DEPT_ID=" + deptid + ") )  ";
            sql+=" GROUP BY a.BOOK_USER ";
            return FrmMdiMain.Database.GetDataTable(sql,120);
        }
    }
}
