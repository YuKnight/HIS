using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;

namespace ts_HospData_Share
{
    public class yp_lysq
    {
        public static void returnSql(RelationalDatabase LocalDatabase, string Ymc, string Ylm, string Yzj, out string sql_insert, out string sql_update, out string sql_delete, out DataTable tb)
        {

            //修改的表结构
            string ssql = @"select sys.columns.name colname, sys.types.name coltype, sys.columns.max_length, sys.columns.is_nullable, 
                        (select count(*) from sys.identity_columns where sys.identity_columns.object_id = sys.columns.object_id and sys.columns.column_id = sys.identity_columns.column_id) as is_identity , 
                        (select value from sys.extended_properties where sys.extended_properties.major_id = sys.columns.object_id and sys.extended_properties.minor_id = sys.columns.column_id) as description 
                        from sys.columns, sys.tables, sys.types where sys.columns.object_id = sys.tables.object_id and sys.columns.system_type_id=sys.types.system_type_id and sys.tables.name='" + Ymc + "' AND sys.types.NAME<>'sysname' order by sys.columns.column_id ";
            DataTable tbcol = LocalDatabase.GetDataTable(ssql);

            //得到修改的主键数据
            ssql = "select * from " + Ymc + " where " + Ylm + "='" + Yzj + "'";
            tb = LocalDatabase.GetDataTable(ssql);

            sql_insert = "";
            sql_delete = "";
            sql_update = "";

            //删除语句
            if (tb.Rows.Count == 0)
                sql_delete = "delete from " + Ymc + " where " + Ylm + "='" + Yzj + "'";
            else
            {
                //组建insert语句
                sql_insert = "insert into " + Ymc + "(";
                string sql_insert_values = "values(";
                for (int i = 0; i <= tbcol.Rows.Count - 1; i++)
                {
                    if (i == tbcol.Rows.Count - 1)
                        sql_insert = sql_insert + tbcol.Rows[i]["colname"].ToString() + ")";
                    else
                        sql_insert = sql_insert + tbcol.Rows[i]["colname"].ToString() + ",";

                    if (i == tbcol.Rows.Count - 1)
                    {
                        if (tb.Rows[0][tbcol.Rows[i]["colname"].ToString()] == DBNull.Value)
                            sql_insert_values = sql_insert_values + "null)";
                        else
                            sql_insert_values = sql_insert_values + "'" + tb.Rows[0][tbcol.Rows[i]["colname"].ToString()].ToString() + "')";
                    }
                    else
                    {
                        if (tb.Rows[0][tbcol.Rows[i]["colname"].ToString()] == DBNull.Value)
                            sql_insert_values = sql_insert_values + "null,";
                        else
                            sql_insert_values = sql_insert_values + "'" + tb.Rows[0][tbcol.Rows[i]["colname"].ToString()].ToString() + "',";
                    }
                }
                sql_insert = sql_insert + sql_insert_values;

                //组建Update语句
                sql_update = "update " + Ymc + " set  ";
                for (int i = 0; i <= tbcol.Rows.Count - 1; i++)
                {
                    if (tbcol.Rows[i]["is_identity"].ToString() == "1") continue;
                    if (i == tbcol.Rows.Count - 1)
                    {
                        if (tb.Rows[0][tbcol.Rows[i]["colname"].ToString()] == DBNull.Value)
                            sql_update = sql_update + tbcol.Rows[i]["colname"].ToString() + "= null where " + Ylm + "='" + Yzj + "'";
                        else
                            sql_update = sql_update + tbcol.Rows[i]["colname"].ToString() + "='" + tb.Rows[0][tbcol.Rows[i]["colname"].ToString()].ToString() + "' where " + Ylm + "='" + Yzj + "'";
                    }
                    else
                    {
                        if (tb.Rows[0][tbcol.Rows[i]["colname"].ToString()] == DBNull.Value)
                            sql_update = sql_update + tbcol.Rows[i]["colname"].ToString() + "=null, ";
                        else
                            sql_update = sql_update + tbcol.Rows[i]["colname"].ToString() + "='" + tb.Rows[0][tbcol.Rows[i]["colname"].ToString()].ToString() + "', ";
                    }

                }
            }
        }
        public static void update(ts_HospData_Share.ts_update_log ts, RelationalDatabase LocalDatabase)
        {

            string ssql = "";
            string sql_insert = "";
            string sql_update = "";
            string sql_delete = "";
            DataTable tb = null;

            if (ts.Ymc.ToLower() != "yf_rksq") throw new Exception("源名称必须是YF_RKSQ");

            returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();

            ssql = "select * from YF_RKSQMX  where djid='" + ts.Yzj + "'";
            DataTable tbmx = LocalDatabase.GetDataTable(ssql);

            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));


                if (tb.Rows.Count == 0)
                {
                    int ncount = MB_DB.DoCommand(sql_delete + " and shbz=0 ");
                    if (ncount != 1) throw new Exception("不能删除该申请单,因为该单据已审核");
                }
                else
                {
                    ssql = "select * from YF_RKSQ where id='" + ts.Yzj + "'";
                    DataTable tb_mb = MB_DB.GetDataTable(ssql);
                    if (tb_mb.Rows.Count > 0)
                    {
                        int ncount = MB_DB.DoCommand(sql_update+" and shbz=0 ");
                        if (ncount != 1) throw new Exception("不能更新该申请单,因为该单据已审核");
                    }
                    else
                        MB_DB.DoCommand(sql_insert);
                }

                 MB_DB.DoCommand("DELETE YF_RKSQMX WHERE DJID='"+ts.Yzj+"'");
                for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                {
                    ssql = "insert into YF_RKSQMX(id,djid,djh,deptid,cjid,ypdw,ydwbl,ypsl,pfj,lsj,pfje,lsje)values(" +
                        "'" + tbmx.Rows[i]["id"].ToString() + "','" + tbmx.Rows[i]["djid"].ToString() + "'," + tbmx.Rows[i]["djh"].ToString() + "," +
                        tbmx.Rows[i]["deptid"].ToString() + "," + tbmx.Rows[i]["cjid"].ToString() + ",'" + tbmx.Rows[i]["ypdw"].ToString() + "','" +
                        tbmx.Rows[i]["ydwbl"].ToString() + "','" + tbmx.Rows[i]["ypsl"].ToString() + "','" + tbmx.Rows[i]["pfj"].ToString() + "','" +
                        tbmx.Rows[i]["lsj"].ToString() + "','" + tbmx.Rows[i]["pfje"].ToString() + "'," + tbmx.Rows[i]["lsje"].ToString()+ ")";
                    MB_DB.DoCommand(ssql);
                }


                

                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='"+sDate+"',wcczy="+TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId+" where id='"+ts.Id+"' and bwcbz=0");
                scope.Complete();

            }
            



        }

       /// <summary>
        /// 检索对方是否已审核单据 
       /// </summary>
       /// <param name="_ss"></param>
       /// <param name="LocalDatabase"></param>
       /// <param name="errtext"></param>
       /// <returns></returns>
        public static bool GetShzt(Guid djid,int  mbjgbm,out string errtext)
        {


            errtext = "";

            try
            {
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(mbjgbm);
                string ssql = "select * from yf_rksq where id='"+djid+"'";
                DataTable tb = MB_DB.GetDataTable(ssql);
                MB_DB.Close();
                MB_DB.Dispose();

                if (tb.Rows.Count > 0)
                {
                    if (tb.Rows[0]["shbz"].ToString() == "1")
                    {
                        errtext = "该单据对方科室已审核,您不能修改";
                        return true;  
                    }
                    else
                        return false;
                }
                else
                    return false;

            }
            catch (System.Exception err)
            {
                errtext = errtext + "在检索申请单是否审核时遇到错误\n" + err.Message.ToString();
                return false;
            }

        }


        /// <summary>
        /// 回写申请领药单
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="errtext"></param>
        public static void SH(ts_HospData_Share.ts_update_log ts)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));

                string sDate = DateManager.ServerDateTimeByDBType(MB_DB).ToString();

                string ssql = "update YF_RKSQ set shbz=1,shr=" + ts.Djy + ",shrq='" + ts.Djsj + "'  where id='" + ts.Yzj + "' and shbz=0";
                MB_DB.DoCommand(ssql);

                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                scope.Complete();
            }
        }
    }
}
