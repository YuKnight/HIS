using System;
using System.Collections.Generic;
using System.Text;
using Ts_zyys_public;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using System.IO;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using TrasenClasses.DatabaseAccess;
using System.Data;
namespace Ts_HisVsLis_interface
{
    public class Function
    {
        
         /// <summary>
        /// 产生医嘱并确费
         /// </summary>
         /// <param name="inpatient_no">住院号</param>
         /// <param name="yzid">医嘱项目id</param>
         /// <param name="xyl">剂量</param>
         /// <param name="app_docid">申请医生id</param>
         /// <param name="app_deptid">申请科室id</param>
         /// <param name="_database">数据库连接对象</param>
         /// <param name="baby_id">婴儿id，大人为0</param>
         /// <param name="bb">标本id</param>
         /// <param name="jgbm">机构编码</param>
         /// <param name="bz">备注</param>
         public static void  CommitOrder(string inpatient_no,long  yzid,Decimal xyl,long app_docid,long app_deptid,RelationalDatabase _database,long baby_id,string bb,long jgbm,string bz)
         {
             string sql = "select * from zy_inpatient where inpatient_no='" + inpatient_no + "' and flag in(1,3,4)";
             DataTable tb = _database.GetDataTable(sql);
             bz = "";
             if (tb.Rows.Count == 0)
             {
                 throw new Exception("没有找到住院号为【" + inpatient_no + "】的病人信息！！");
             }
             else
             {
                 _database.BeginTransaction();
                 try
                 {
                     Ts_zyys_public.DbQuery dbquery = new DbQuery(_database);
                     sql = "select *,CASE WHEN  b.EXEC_DEPT>0 THEN b.EXEC_DEPT ELSE A.DEFAULT_DEPT END zkxsid   "
                          +" from JC_HOITEMDICTION a left join JC_HOI_DEPT b  on a.ORDER_ID=b.ORDER_ID "
                         + "  left join JC_DEPT_PROPERTY c on c.DEPT_ID=b.EXEC_DEPT  where a.ORDER_ID=" + yzid + "  and  c.jgbm=" + jgbm;
                     DataTable hoitemtb = _database.GetDataTable(sql);
                     if (hoitemtb.Rows.Count == 0)
                         throw new Exception("获取医嘱项目失败！！");
                     long zxksid = long.Parse(hoitemtb.Rows[0]["zkxsid"].ToString());
                     string ward_id = Convert.ToString(_database.GetDataResult("select ward_id from JC_WARDRDEPT where dept_id='" + tb.Rows[0]["dept_id"].ToString() + "'"));
                     Guid inpatient_id = new Guid(tb.Rows[0]["inpatient_id"].ToString());
                     long yzNum = dbquery.GetYzNum(_database, inpatient_id)+1;
                     Guid order_id= PubStaticFun.NewGuid();
                     string commandtext = string.Concat(new object[] { 
                                    "INSERT INTO ZY_ORDERRECORD(order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,nType,Order_Doc,HOItem_ID,xmly,Order_context,Num,Dosage,Unit,book_date,Order_bDate,First_times,Order_Usage,frequency,Operator,Delete_Bit,status_flag,baby_id,dept_br,exec_dept,dwlx,MEMO,MEMO1,jgbm,zsl,jz_flag) "
                                   +" VALUES('",order_id, "',", yzNum.ToString(), ",'", inpatient_id.ToString(), "',", app_deptid, ",'",ward_id, "',1,5,",FrmMdiMain.CurrentUser.EmployeeId, ",", yzid, ",2,'","", 
                                    hoitemtb.Rows[0]["ORDER_NAME"].ToString()+bz, "',", xyl.ToString(), ",1,'", hoitemtb.Rows[0]["ORDER_UNIT"].ToString(), "',GetDate(),GetDate(),0,'", "", "','',", app_docid, ",0,2,", baby_id.ToString(), ",",tb.Rows[0]["dept_id"], ",", zxksid.ToString(), ",", 
                                    bb.ToString(), ",'",  "", "★", "", "','", "", "',", jgbm, ","+xyl.ToString()+",1)"
                                 });
                     _database.DoCommand(commandtext);
                    
                     dbquery.insertJY(_database, inpatient_id,baby_id, order_id);
                     ts_zyhs_classes.BaseFunc bfucn = new ts_zyhs_classes.BaseFunc(_database);
                     bfucn.ExecOrders("",inpatient_id,baby_id,yzNum,1 , DateManager.ServerDateTimeByDBType(_database),DateManager.ServerDateTimeByDBType(_database),app_docid, (int)jgbm);
                     _database.CommitTransaction();
                 }
                 catch (Exception ex)
                 {
                     _database.RollbackTransaction();
                     throw ex;
                 }

             }
         }


         /// <summary>
         /// 产生医嘱不产生费用
         /// </summary>
         /// <param name="inpatient_no">住院号</param>
         /// <param name="yzid">医嘱项目id</param>
         /// <param name="xyl">剂量</param>
         /// <param name="app_docid">申请医生id</param>
         /// <param name="app_deptid">申请科室id</param>
         /// <param name="_database">数据库连接对象</param>
         /// <param name="baby_id">婴儿id，大人为0</param>
         /// <param name="bb">标本id</param>
         /// <param name="jgbm">机构编码</param>
         /// <param name="bz">备注</param>
         public static void CommitOrder_notexe(string inpatient_no, long yzid, Decimal xyl, long app_docid, long app_deptid, RelationalDatabase _database, long baby_id, string bb, long jgbm, string bz)
         {
             string sql = "select * from zy_inpatient where inpatient_no='" + inpatient_no + "' and flag in(1,3,4)";
             DataTable tb = _database.GetDataTable(sql);
             bz = "";
             if (tb.Rows.Count == 0)
             {
                 throw new Exception("没有找到住院号为【" + inpatient_no + "】的病人信息！！");
             }
             else
             {
                 _database.BeginTransaction();
                 try
                 {
                     Ts_zyys_public.DbQuery dbquery = new DbQuery(_database);
                     sql = "select *,CASE WHEN  b.EXEC_DEPT>0 THEN b.EXEC_DEPT ELSE A.DEFAULT_DEPT END zkxsid   "
                          + " from JC_HOITEMDICTION a left join JC_HOI_DEPT b  on a.ORDER_ID=b.ORDER_ID "
                         + "  left join JC_DEPT_PROPERTY c on c.DEPT_ID=b.EXEC_DEPT  where a.ORDER_ID=" + yzid + "  and  c.jgbm=" + jgbm;
                     DataTable hoitemtb = _database.GetDataTable(sql);
                     if (hoitemtb.Rows.Count == 0)
                         throw new Exception("获取医嘱项目失败！！");
                     long zxksid = long.Parse(hoitemtb.Rows[0]["zkxsid"].ToString());
                     string ward_id = Convert.ToString(_database.GetDataResult("select ward_id from JC_WARDRDEPT where dept_id='" + tb.Rows[0]["dept_id"].ToString() + "'"));
                     Guid inpatient_id = new Guid(tb.Rows[0]["inpatient_id"].ToString());
                     long yzNum = dbquery.GetYzNum(_database, inpatient_id) + 1;
                     Guid order_id = PubStaticFun.NewGuid();
                     string commandtext = string.Concat(new object[] { 
                                    "INSERT INTO ZY_ORDERRECORD(order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,nType,Order_Doc,HOItem_ID,xmly,Order_context,Num,Dosage,Unit,book_date,Order_bDate,First_times,Order_Usage,frequency,Operator,Delete_Bit,status_flag,baby_id,dept_br,exec_dept,dwlx,MEMO,MEMO1,jgbm,zsl,jz_flag) "
                                   +" VALUES('",order_id, "',", yzNum.ToString(), ",'", inpatient_id.ToString(), "',", app_deptid, ",'",ward_id, "',1,5,",FrmMdiMain.CurrentUser.EmployeeId, ",", yzid, ",2,'","", 
                                    hoitemtb.Rows[0]["ORDER_NAME"].ToString()+bz, "',", xyl.ToString(), ",1,'", hoitemtb.Rows[0]["ORDER_UNIT"].ToString(), "',GetDate(),GetDate(),0,'", "", "','',", app_docid, ",0,0,", baby_id.ToString(), ",",tb.Rows[0]["dept_id"], ",", zxksid.ToString(), ",", 
                                    bb.ToString(), ",'",  "", "★", "", "','", "", "',", jgbm, ","+xyl.ToString()+",0)"
                                 });
                     _database.DoCommand(commandtext);

                     dbquery.insertJY(_database, inpatient_id, baby_id, order_id);
                    // ts_zyhs_classes.BaseFunc bfucn = new ts_zyhs_classes.BaseFunc(_database);
                     //bfucn.ExecOrders("", inpatient_id, baby_id, yzNum, 1, DateManager.ServerDateTimeByDBType(_database), DateManager.ServerDateTimeByDBType(_database), app_docid, (int)jgbm);
                     _database.CommitTransaction();
                 }
                 catch (Exception ex)
                 {
                     _database.RollbackTransaction();
                     throw ex;
                 }

             }
         }
        
    }
}
