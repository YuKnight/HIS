using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;

namespace ts_HospData_Share
{
    class yp_cd
    {
        public static void returnSql(RelationalDatabase LocalDatabase, string Ymc, string Ylm, string Yzj, out string sql_insert, out string sql_update, out string sql_delete,out DataTable tb)
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
            string sql_insert="";
            string sql_update="";
            string sql_delete = "";
            DataTable tb = null;

            if (ts.Ymc != "yp_ypcjd") throw new Exception("源名称必须是yp_ypcjd");
            returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete,out  tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();

            int GGID = 0;
            if (tb.Rows.Count != 0)
                GGID = Convert.ToInt32(tb.Rows[0]["ggid"]);

            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));


                #region 厂家表

                if (tb.Rows.Count == 0)
                {
                    //删除厂家
                    int ggid = 0;
                    ssql = "select ggid from yp_ypcjd where cjid="+ts.Yzj+"";
                    DataTable tbcj = MB_DB.GetDataTable(ssql);
                    if (tbcj.Rows.Count != 0) ggid = Convert.ToInt32(tbcj.Rows[0]["ggid"].ToString());

                    ssql = "select * from yk_kcmx where CJID=" + ts.Yzj + "";
                    DataRow row = MB_DB.GetDataRow(ssql);
                    if (row != null) throw new Exception("该药品已有使用记录,不能删除");

                    ssql = "select * from yf_kcmx where CJID=" + ts.Yzj + "";
                    row = MB_DB.GetDataRow(ssql);
                    if (row != null) throw new Exception("该药品已有使用记录,不能删除");


                    ssql = "delete  from yp_ypcjd where CJID=" + ts.Yzj + "";
                    MB_DB.DoCommand(ssql);


                    ssql = "select * from yp_ypcjd where GGID=" + ggid + "";
                    row = MB_DB.GetDataRow(ssql);
                    if (row == null)
                    {
                        ssql = "delete  from yp_ypggd where GGID=" + ggid + "";
                        MB_DB.DoCommand(ssql);

                        ssql = "delete  from yp_ypbm where GGID=" + ggid + "";
                        MB_DB.DoCommand(ssql);

                    }


                }
                else
                {
                    ssql = "select * from " + ts.Ymc + " where " + ts.Ylm + "='" + ts.Yzj + "'";
                    DataTable tb_mb = MB_DB.GetDataTable(ssql);
                    if (tb_mb.Rows.Count == 0)
                    {
                        //插入厂家
                        MB_DB.DoCommand("SET IDENTITY_INSERT " + ts.Ymc + "  ON");
                        MB_DB.DoCommand(sql_insert);
                        MB_DB.DoCommand("SET IDENTITY_INSERT " + ts.Ymc + "  OFF");

                    }
                    else
                    {
                        //停用匹配关系
                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "@xmid";
                        parameters[0].Value = GGID;
                        parameters[1].Text = "@xmly";
                        parameters[1].Value = 1;
                        MB_DB.DoCommand("sp_yb_qxybppgx", parameters, 30);

                        //更新厂家
                        MB_DB.DoCommand(sql_update);

                    }

                }

                #endregion



                #region 规格表

                if (tb.Rows.Count == 0) 
                {
                    BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                    scope.Complete();
                    return;
                }

                tb = null;
                returnSql(LocalDatabase, "yp_ypggd", "ggid", GGID.ToString(), out sql_insert, out sql_update, out sql_delete, out  tb);

                if (tb.Rows.Count == 0)
                    MB_DB.DoCommand(sql_delete);
                else
                {
                    ssql = "select * from yp_ypggd where ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + "";
                    DataTable tb_mb = MB_DB.GetDataTable(ssql);
                    if (tb_mb.Rows.Count == 0)
                    {
                        MB_DB.DoCommand("SET IDENTITY_INSERT yp_ypggd  ON");
                        MB_DB.DoCommand(sql_insert);
                        MB_DB.DoCommand("SET IDENTITY_INSERT yp_ypggd  OFF");

                    }
                    else
                    {
                        MB_DB.DoCommand(sql_update);

                        ssql = @"update yp_ypcjd set n_yplx=" + Convert.ToInt32(tb.Rows[0]["yplx"]) + ",n_ypzlx=" + Convert.ToInt32(tb.Rows[0]["ypzlx"]) + ",s_ypjx=dbo.fun_yp_ypjx(" + Convert.ToString(tb.Rows[0]["ypjx"]) + "),s_yppm='" + Convert.ToString(tb.Rows[0]["yppm"]) + "',s_ypspm='" + Convert.ToString(tb.Rows[0]["ypspm"]) + "'," +
                         " s_ypgg='" + Convert.ToString(tb.Rows[0]["ypgg"]) + "',s_ypdw=dbo.fun_yp_ypdw(" + Convert.ToString(tb.Rows[0]["ypdw"]) + ") where ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + "";
                        MB_DB.DoCommand(ssql);


                        ssql = "select * from yp_ypggd where ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + "";
                        DataTable tb_bd_gg = BD_DB.GetDataTable(ssql);
                        if (tb_bd_gg.Rows.Count > 0)
                        {
                            int ypdwid = Convert.ToInt32(tb_bd_gg.Rows[0]["ypdw"]);
                            ssql = " update yf_kcmx set zxdw=" + ypdwid + " where ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " and dwbl=1";
                            MB_DB.DoCommand(ssql);
                            ssql = " update yf_kcph set zxdw=" + ypdwid + " where ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " and dwbl=1";
                            MB_DB.DoCommand(ssql);
                            ssql = " update yk_kcmx set zxdw=" + ypdwid + " where ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " and dwbl=1";
                            MB_DB.DoCommand(ssql);
                            ssql = " update yP_ypcl set zxdw=" + ypdwid + " where ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " and dwbl=1";
                            MB_DB.DoCommand(ssql);
                            ssql = " update yp_ypcl set ypdw=" + ypdwid + " where ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + "";
                            MB_DB.DoCommand(ssql);
                            ssql = " update yp_ypbm set ypbm='" + Convert.ToString(tb.Rows[0]["ypspm"]) + "',pym='" + Convert.ToString(tb_bd_gg.Rows[0]["pym"]) + "',wbm='" + Convert.ToString(tb_bd_gg.Rows[0]["wbm"]) + "' where ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " and spmbz=1";
                            MB_DB.DoCommand(ssql);
                        }
                        
                    }

                    //药品别名
                    tb = null;
                    returnSql(BD_DB, "yp_ypbm", "ggid", GGID.ToString(), out sql_insert, out sql_update, out sql_delete, out  tb);
                    ssql = "delete from yp_ypbm where ggid=" + GGID + "";
                    MB_DB.DoCommand(ssql);

                    MB_DB.DoCommand("SET IDENTITY_INSERT yp_ypbm  ON");
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        ssql="insert into yp_ypbm(id,ggid,ypbm,pym,wbm,spmbz) " +
                                "values("+Convert.ToInt32(tb.Rows[i]["id"])+", " + Convert.ToInt32(tb.Rows[i]["ggid"]) + ",'" + Convert.ToString(tb.Rows[i]["ypbm"]) + "','" + Convert.ToString(tb.Rows[i]["pym"]) + "','" + Convert.ToString(tb.Rows[i]["wbm"]) + "'," + Convert.ToInt16(tb.Rows[i]["spmbz"]) + ")";
                        MB_DB.DoCommand(ssql);
                    }
                    MB_DB.DoCommand("SET IDENTITY_INSERT yp_ypbm  OFF");

                }

                #endregion

                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='"+sDate+"',wcczy="+TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId+" where id='"+ts.Id+"' and bwcbz=0");
                scope.Complete();

            }
            



        }

        //合并药品
        public static void update_hb(ts_HospData_Share.ts_update_log ts, RelationalDatabase LocalDatabase)
        {
            string ssql = "";
            string sql_insert = "";
            string sql_update = "";
            string sql_delete = "";
            DataTable tb = null;

            returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();

            if (ts.Ymc.ToLower() != "yp_ypcjd") throw new Exception("源名称必须是yp_ypcjd");
            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));

                //厂家
                ssql = "update yp_ypcjd set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + ",s_ypspm='" + Convertor.IsNull(tb.Rows[0]["s_ypspm"], "") + "',s_yppm='" + Convertor.IsNull(tb.Rows[0]["s_yppm"], "") +
                    "',s_ypspmbz='" + Convertor.IsNull(tb.Rows[0]["s_ypspmbz"], "") + "',s_ypgg='" + Convertor.IsNull(tb.Rows[0]["s_ypgg"], "") + "',s_ypdw='" + Convertor.IsNull(tb.Rows[0]["s_ypdw"], "") + "' where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);

                //药房库存
                ssql = "update yf_kcmx set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药房批号
                ssql = "update yf_kcph set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药库库存
                ssql = "update yk_kcmx set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药库批号
                ssql = "update yk_kcph set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药房盘点表
                ssql = "update yf_pdtemp set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药库盘点表
                ssql = "update yk_kcph set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药品拆零表
                ssql = "update yp_ypcl set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);


                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                scope.Complete();

            }




        }

        //取消合并
        public static void update_qxhb(ts_HospData_Share.ts_update_log ts, RelationalDatabase LocalDatabase)
        {
            string ssql = "";
            string sql_insert = "";
            string sql_update = "";
            string sql_delete = "";
            DataTable tb = null;

            returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();

            if (ts.Ymc.ToLower() != "yp_ypcjd") throw new Exception("源名称必须是yp_ypcjd");
            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));

                //厂家
                ssql = "update yp_ypcjd set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + ",s_ypspm='" + Convertor.IsNull(tb.Rows[0]["s_ypspm"], "") + "',s_yppm='" + Convertor.IsNull(tb.Rows[0]["s_yppm"], "") +
                    "',s_ypspmbz='" + Convertor.IsNull(tb.Rows[0]["s_ypspmbz"], "") + "',s_ypgg='" + Convertor.IsNull(tb.Rows[0]["s_ypgg"], "") + "',s_ypdw='" + Convertor.IsNull(tb.Rows[0]["s_ypdw"], "") + "' where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);

                //药房库存
                ssql = "update yf_kcmx set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药房批号
                ssql = "update yf_kcph set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药库库存
                ssql = "update yk_kcmx set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药库批号
                ssql = "update yk_kcph set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药房盘点表
                ssql = "update yf_pdtemp set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药库盘点表
                ssql = "update yk_kcph set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);
                //药品拆零表
                ssql = "update yp_ypcl set ggid=" + Convert.ToInt32(tb.Rows[0]["ggid"]) + " where cjid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);

                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                scope.Complete();

            }




        } 

    }
}
