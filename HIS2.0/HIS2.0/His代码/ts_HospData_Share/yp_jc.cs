using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;

namespace ts_HospData_Share
{
    class yp_jc
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
                        sql_insert_values = sql_insert_values + "'" + tb.Rows[0][tbcol.Rows[i]["colname"].ToString()].ToString() + "')";
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
                        sql_update = sql_update + tbcol.Rows[i]["colname"].ToString() + "='" + tb.Rows[0][tbcol.Rows[i]["colname"].ToString()].ToString() + "' where " + Ylm + "='" + Yzj + "'";
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

            returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();

            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));

                if (ts.Ymc.ToLower() == "yp_yjks_gx")
                {
                    ssql = "delete from yp_yjks_gx where p_deptid=" + ts.Yzj + "";
                    MB_DB.DoCommand(ssql);
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        ssql = "insert into yp_yjks_gx(p_deptid,deptid,djsj,djy)values(" + tb.Rows[i]["p_deptid"] + "," + tb.Rows[i]["deptid"] + ",'" + tb.Rows[i]["djsj"] + "'," + tb.Rows[i]["djy"] + ")";
                        MB_DB.DoCommand(ssql);
                    }

                    tb = null;
                    ssql = "select * from yp_djh where deptid="+ts.Yzj+"";
                    tb = BD_DB.GetDataTable(ssql);
                    ssql = "delete from yp_djh where deptid=" + ts.Yzj + "";
                    MB_DB.DoCommand(ssql);
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        ssql = "insert into yp_djh(ywlx,djh,deptid)values('" + tb.Rows[i]["ywlx"] + "','" + tb.Rows[i]["djh"] + "'," + tb.Rows[i]["deptid"] + ")";
                        MB_DB.DoCommand(ssql);
                    }

                    BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                    scope.Complete();

                    return;
                }

                if (tb.Rows.Count > 1)
                {
                    if (ts.Ymc == "yp_lyks")
                        MB_DB.DoCommand("delete from yp_lyks where "+ts.Ylm+"="+ts.Yzj+"");
                    if (ts.Ymc == "yp_gllx")
                        MB_DB.DoCommand("delete from yp_gllx where " + ts.Ylm + "=" + ts.Yzj + "");

                }
                if (tb.Rows.Count == 0)
                {
                    if (ts.Ymc == "yp_ylfl")
                    {
                        ssql = "select * from yp_ylfl where id =" + ts.Yzj + "";
                        DataTable tb_fid = MB_DB.GetDataTable(ssql);
                        int FID = 0;
                        if (tb_fid.Rows.Count > 0) FID = Convert.ToInt32(tb_fid.Rows[0]["fid"]);

                        

                        ssql = "select * from yp_ylfl where fid =" + FID + "";
                        DataTable ftab = BD_DB.GetDataTable(ssql);
                        if (ftab.Rows.Count == 0)
                        {
                            ssql = "update yp_ylfl set yjdbz=1 where id=" + FID + "";
                            MB_DB.DoCommand(ssql);
                        }
                    }

                    MB_DB.DoCommand(sql_delete);

                }
                if (tb.Rows.Count == 1)
                {
                    ssql = "select * from " + ts.Ymc + " where " + ts.Ylm + "='" + ts.Yzj + "'";
                    DataTable tb_mb = MB_DB.GetDataTable(ssql);
                    if (tb_mb.Rows.Count == 0)
                    {
                        MB_DB.DoCommand("SET IDENTITY_INSERT " + ts.Ymc + "  ON");
                        MB_DB.DoCommand(sql_insert);
                    }
                    else
                        MB_DB.DoCommand(sql_update);

                    #region 药品别名修改时,同步修改规格表
                    if (ts.Ymc.ToLower() == "yp_ypbm")
                    {
                        if (tb.Rows[0]["spmbz"].ToString() == "1")
                        {
                            ssql = "update yp_ypggd set pym='" + Convertor.IsNull(tb.Rows[0]["pym"], "") + "',WBM='" + Convertor.IsNull(tb.Rows[0]["wbm"], "") + "' where ggid=" + Convertor.IsNull(tb.Rows[0]["ggid"], "") + "";
                            MB_DB.DoCommand(sql_update);
                        }
                    }

                    #endregion

                    #region 药理分类修改时,同步修改父节点不为叶节点
                    if (ts.Ymc.ToLower() == "yp_ylfl")
                    {
                        ssql = "select fid from yp_ylfl where id="+ts.Yzj+"";
                        DataTable tb_ylfl = BD_DB.GetDataTable(ssql);
                        if (tb_ylfl.Rows.Count>0)
                        {
                            ssql = "update yp_ylfl set yjdbz=0 where id=" + Convertor.IsNull(tb_ylfl.Rows[0][0],"") + "";
                            MB_DB.DoCommand(ssql);
                        }
                    }

                    #endregion


                }
                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='"+sDate+"',wcczy="+TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId+" where id='"+ts.Id+"' and bwcbz=0");
                scope.Complete();

            }
            



        }


    }
}
