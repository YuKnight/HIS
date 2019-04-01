using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
namespace ts_yj_qf
{
    public  class GetOrderItemInfo
    {
        public static DataTable GetItem(string mydept,string d_code)
        {
            SystemCfg cfg29378 = new SystemCfg(29378);

            string sql = "";
            DataTable dt = new DataTable();
//            sql = string.Format(@"SELECT DISTINCT  A.ORDER_ID, A.ORDER_NAME, A.DEFAULT_DEPT,(select NAME from JC_DEPT_PROPERTY where JC_DEPT_PROPERTY.DEPT_ID=A.DEFAULT_DEPT)  as DeptName,A.JCLXID,(select name from jc_jcclassdiction where jc_jcclassdiction.ID=A.JCLXID)
//                                  as JCLXNaMe,  A.ORDER_UNIT,           
//                                  A.DEFAULT_USAGE,LOWER(A.PY_CODE) PY_CODE,A.D_CODE,A.WB_CODE, A.BOOKING_BIT ,TCID,PRICE--, SEEKHOITEMPRICE(A.ORDER_ID) PRICE          
//                                  FROM           
//                                  (          
//                                  SELECT BB.ORDER_ID, 0 BOOKING_BIT, CASE WHEN (BZ IS NULL OR BZ='') THEN ORDER_NAME ELSE (ORDER_NAME) END ORDER_NAME,          
//                                  isnull(CC.EXEC_DEPT,BB.DEFAULT_DEPT) AS DEFAULT_DEPT,AA.JCLXID as JCLXID, ORDER_UNIT,PY_CODE,DEFAULT_USAGE,D_CODE,WB_CODE,BB.PRICE           
//                                  FROM (SELECT YZID,JCLXID          
//                                  FROM JC_JC_ITEM  WHERE JCLXID = '{0}'        
//                                  ) AA,            
//                                 (SELECT ORDER_ID, ORDER_NAME, DEFAULT_DEPT, ORDER_UNIT, PY_CODE,D_CODE,WB_CODE,BZ ,DEFAULT_USAGE,dbo.FUN_BASE_HOIPRICE(ORDER_ID) as PRICE          
//                                  FROM JC_HOITEMDICTION WHERE DELETE_BIT = 0--WHERE DEFAULT_DEPT=@DEPTID          
//                                  ) BB left join          
//                                  JC_HOI_DEPT CC on BB.ORDER_ID=CC.ORDER_ID AND CC.EXEC_DEPT='{1}'    
//                                  and dbo.fun_getFirstLevelDeptId(CC.EXEC_DEPT)=dbo.fun_getFirstLevelDeptId('{2}') --Modify By Tany 2015-06-05       
//                                  WHERE AA.YZID = BB.ORDER_ID  
//                                 ) A join JC_HOI_hdi b on a.ORDER_ID=b.hoitem_ID ", itemclass,execdept,mydept);
                                string[] deptarr_qx = cfg29378.Config.Split(',');
                                bool qx_all=false;
                                foreach (string i in deptarr_qx)
                                {
                                    if (InstanceForm._currentDept.DeptId.ToString() == i.ToString())
                                    {
                                        qx_all = true;
                                    }

                                }

                                if (!qx_all)
                                {

                                    sql = string.Format(@"SELECT DISTINCT  A.ORDER_ID, A.ORDER_NAME, A.DEFAULT_DEPT,(select NAME from JC_DEPT_PROPERTY where JC_DEPT_PROPERTY.DEPT_ID=A.DEFAULT_DEPT)  as DeptName,'1' as JCLXID,'0'
                                    as JCLXNaMe,  A.ORDER_UNIT,           
                                    A.DEFAULT_USAGE,LOWER(A.PY_CODE) PY_CODE,A.D_CODE,A.WB_CODE, '0' as BOOKING_BIT ,'0' as TCID ,dbo.FUN_BASE_HOIPRICE(A.ORDER_ID) as PRICE --, SEEKHOITEMPRICE(A.ORDER_ID) PRICE    
                                    from (select * from JC_HOITEMDICTION where DELETE_BIT=0) A
                                    inner join JC_YZQXMX t2 on A.ORDER_ID=t2.ORDER_ID 
                                    left join jc_yzqx_ks t3 on t2.QXID=t3.QXID
                                    where A.ORDER_TYPE in ('4','5','6','7','8','9') and A.DELETE_BIT=0 and t3.DEPTID='{0}' and a.d_code like '%{1}%' order by ORDER_ID ", mydept, d_code);
                                }
                                else
                                {
                                    sql = string.Format(@"SELECT top 10  A.ORDER_ID, A.ORDER_NAME, A.DEFAULT_DEPT,(select NAME from JC_DEPT_PROPERTY where JC_DEPT_PROPERTY.DEPT_ID=A.DEFAULT_DEPT)  as DeptName,'1' as JCLXID,'0'
                                    as JCLXNaMe,  A.ORDER_UNIT,           
                                    A.DEFAULT_USAGE,LOWER(A.PY_CODE) PY_CODE,A.D_CODE,A.WB_CODE, '0' as BOOKING_BIT ,'0' as TCID ,dbo.FUN_BASE_HOIPRICE(A.ORDER_ID) as PRICE --, SEEKHOITEMPRICE(A.ORDER_ID) PRICE    
                                    from  JC_HOITEMDICTION  A
                                    where A.DELETE_BIT=0 and A.ORDER_TYPE in ('4','5','6','7','8','9')  and a.d_code like '%{1}%' order by ORDER_ID ", mydept, d_code);

                                }
            dt = InstanceForm._database.GetDataTable(sql);
            return dt;
        }
    }
}
