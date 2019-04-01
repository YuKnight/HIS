using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;

namespace ts_HospData_Share
{
    public class br_brxx
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

            if (ts.Ymc.ToLower() != "yy_brxx") throw new Exception("源名称必须是yy_brxx");

            returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();


            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));


                if (tb.Rows.Count == 0)
                {
                    int ncount = MB_DB.DoCommand(sql_delete + " ");
                }
                else
                {
                    MB_DB.DoCommand("DELETE yy_brxx WHERE brxxid='" + ts.Yzj + "'");
                    //MB_DB.DoCommand("DELETE yy_kdjb WHERE brxxid='" + ts.Yzj + "'");
                    MB_DB.DoCommand("DELETE yy_kdjb_je WHERE kdjid in(select kdjid from yy_kdjb where brxxid='" + ts.Yzj + "')");
                    MB_DB.DoCommand("DELETE yy_jhk WHERE brxxid='" + ts.Yzj + "'");

                    MB_DB.DoCommand(sql_insert);

                    ssql = "select * from yy_kdjb where brxxid='" + ts.Yzj + "'";
                    DataTable tbkdjb = BD_DB.GetDataTable(ssql);
                    //for (int i = 0; i <= tbkdjb.Rows.Count - 1; i++)
                    //{
                    //    ssql = "insert into yy_kdjb(kdjid,brxxid,klx,kh,ckrxm,djsj,djy,zfbz,zfsj,zfdjy,zfyy,ljcrje,ljxfje,kye,jkid,jksj,jky,jkid_e,jksj_e,jky_e,sdbz,kmm)values('" +
                    //        tbkdjb.Rows[i]["kdjid"].ToString() + "','" + tbkdjb.Rows[i]["brxxid"].ToString() + "','" + tbkdjb.Rows[i]["klx"].ToString() + "','" +
                    //        tbkdjb.Rows[i]["kh"].ToString() + "','" + tbkdjb.Rows[i]["ckrxm"].ToString() + "','" + tbkdjb.Rows[i]["djsj"].ToString() + "','" +
                    //        tbkdjb.Rows[i]["djy"].ToString() + "','" + tbkdjb.Rows[i]["zfbz"].ToString() + "','" + tbkdjb.Rows[i]["zfsj"].ToString() + "','" +
                    //        tbkdjb.Rows[i]["zfdjy"].ToString() + "','" + tbkdjb.Rows[i]["zfyy"].ToString() + "','" + tbkdjb.Rows[i]["ljcrje"].ToString() + "','" +
                    //        tbkdjb.Rows[i]["ljxfje"].ToString() + "','" + tbkdjb.Rows[i]["kye"].ToString() + "','" + tbkdjb.Rows[i]["jkid"].ToString() + "','" +
                    //        tbkdjb.Rows[i]["jksj"].ToString() + "','" + tbkdjb.Rows[i]["jky"].ToString() + "','" + tbkdjb.Rows[i]["jkid_e"].ToString() +"','"+
                    //        tbkdjb.Rows[i]["jksj_e"].ToString() + "','" + tbkdjb.Rows[i]["jky_e"].ToString() + "','" + tbkdjb.Rows[i]["sdbz"].ToString() +"','"+
                    //        tbkdjb.Rows[i]["kmm"].ToString()+"')";
                    //    MB_DB.DoCommand(ssql);
                    //}

                    for (int i = 0; i <= tbkdjb.Rows.Count - 1; i++)
                    {
                        ssql = "select * from yy_kdjb where kdjid='" + tbkdjb.Rows[i]["kdjid"].ToString() + "'";
                        DataTable tb_n = MB_DB.GetDataTable(ssql);
                        if (tb_n.Rows.Count == 0)
                        {
                            ssql = "insert into yy_kdjb(kdjid,brxxid,klx,kh,ckrxm,djsj,djy,zfbz,zfsj,zfdjy,zfyy,ljcrje,ljxfje,kye,jkid,jksj,jky,jkid_e,jksj_e,jky_e,sdbz,kmm)values('" +
                                tbkdjb.Rows[i]["kdjid"].ToString() + "','" + tbkdjb.Rows[i]["brxxid"].ToString() + "','" + tbkdjb.Rows[i]["klx"].ToString() + "','" +
                                tbkdjb.Rows[i]["kh"].ToString() + "','" + tbkdjb.Rows[i]["ckrxm"].ToString() + "','" + tbkdjb.Rows[i]["djsj"].ToString() + "','" +
                                tbkdjb.Rows[i]["djy"].ToString() + "','" + tbkdjb.Rows[i]["zfbz"].ToString() + "','" + tbkdjb.Rows[i]["zfsj"].ToString() + "','" +
                                tbkdjb.Rows[i]["zfdjy"].ToString() + "','" + tbkdjb.Rows[i]["zfyy"].ToString() + "',0,0,0,'" + tbkdjb.Rows[i]["jkid"].ToString() + "','" +
                                tbkdjb.Rows[i]["jksj"].ToString() + "','" + tbkdjb.Rows[i]["jky"].ToString() + "','" + tbkdjb.Rows[i]["jkid_e"].ToString() + "','" +
                                tbkdjb.Rows[i]["jksj_e"].ToString() + "','" + tbkdjb.Rows[i]["jky_e"].ToString() + "','" + tbkdjb.Rows[i]["sdbz"].ToString() + "','" +
                                tbkdjb.Rows[i]["kmm"].ToString() + "')";
                            MB_DB.DoCommand(ssql);
                        }
                    }

                    //ssql = "select * from yy_kdjb_je WHERE kdjid in(select kdjid from yy_kdjb where brxxid='" + ts.Yzj + "')";
                    //DataTable tbkje = BD_DB.GetDataTable(ssql);
                    //for (int i = 0; i <= tbkje.Rows.Count - 1; i++)
                    //{
                    //    ssql = "insert into yy_kdjb_je(kjeid,kdjid,fkfs,pjh,crje,djsj,djy,bdzbz,dzrq,dzy,zph,khdw,khyh,bzfbz,zfrq,zfy,bz,jkid)values('" +
                    //         tbkje.Rows[i]["kjeid"].ToString() + "','" + tbkje.Rows[i]["kdjid"].ToString() + "','" + tbkje.Rows[i]["fkfs"].ToString() + "','" +
                    //        tbkje.Rows[i]["pjh"].ToString() + "','" + tbkje.Rows[i]["crje"].ToString() + "','" + tbkje.Rows[i]["djsj"].ToString() + "','" +
                    //        tbkje.Rows[i]["djy"].ToString() + "','" + tbkje.Rows[i]["bdzbz"].ToString() + "','" + tbkje.Rows[i]["dzrq"].ToString() + "','" +
                    //        tbkje.Rows[i]["dzy"].ToString() + "','" + tbkje.Rows[i]["zph"].ToString() + "','" + tbkje.Rows[i]["khdw"].ToString() + "','" +
                    //        tbkje.Rows[i]["khyh"].ToString() + "','" + tbkje.Rows[i]["bzfbz"].ToString() + "','" + tbkje.Rows[i]["zfrq"].ToString() + "','" +
                    //        tbkje.Rows[i]["zfy"].ToString() + "','" + tbkje.Rows[i]["bz"].ToString() + "','" + Convertor.IsNull(tbkje.Rows[i]["jkid"],Guid.Empty.ToString()) + "')";
                    //    MB_DB.DoCommand(ssql);
                    //}

                    ssql = "select jhkid,jgbm,brxxid,brxm,klx,ykh,xkh,djsj,djy,lx,yj,hksj,hkdjy,bz from yy_jhk WHERE  brxxid='" + ts.Yzj + "'";
                    DataTable tbjhk = BD_DB.GetDataTable(ssql);
                    for (int i = 0; i <= tbjhk.Rows.Count - 1; i++)
                    {
                        ssql = "insert into yy_jhk(jhkid,jgbm,brxxid,brxm,klx,ykh,xkh,djsj,djy,lx,yj,hksj,hkdjy,bz)values('" +
                            tbjhk.Rows[i]["jhkid"].ToString() + "','" + tbjhk.Rows[i]["jgbm"].ToString() + "','" + tbjhk.Rows[i]["brxxid"].ToString() + "','" +
                            tbjhk.Rows[i]["brxm"].ToString() + "','" + tbjhk.Rows[i]["klx"].ToString() + "','" + tbjhk.Rows[i]["ykh"].ToString() + "','" +
                            tbjhk.Rows[i]["xkh"].ToString() + "','" + tbjhk.Rows[i]["djsj"].ToString() + "','" + tbjhk.Rows[i]["djy"].ToString() + "','" +
                            tbjhk.Rows[i]["lx"].ToString() + "','" + tbjhk.Rows[i]["yj"].ToString() + "','" + tbjhk.Rows[i]["hksj"].ToString() + "','" +
                            tbjhk.Rows[i]["hkdjy"].ToString() + "','" + tbjhk.Rows[i]["bz"].ToString() + "')";
                        MB_DB.DoCommand(ssql);
                    }

                }




                

                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='"+sDate+"',wcczy="+TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId+" where id='"+ts.Id+"' and bwcbz=0");
                scope.Complete();

            }
            



        }


    }
}
