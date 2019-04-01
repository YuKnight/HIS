using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;

namespace ts_HospData_Share
{
    class pub_user
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
                        sql_insert_values = sql_insert_values + "'" + tb.Rows[0][tbcol.Rows[i]["colname"].ToString()].ToString() + "',";
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
                        sql_update = sql_update + tbcol.Rows[i]["colname"].ToString() + "='" + tb.Rows[0][tbcol.Rows[i]["colname"].ToString()].ToString() + "', ";

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

            returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete, out tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();

            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));

                #region 业务操作
                //用户表
                if (tb.Rows.Count == 0)
                {
                    MB_DB.DoCommand(sql_delete);
                }
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    ssql = "select * from " + ts.Ymc + " where " + ts.Ylm + "='" + ts.Yzj + "'";
                    DataTable tb_mb = MB_DB.GetDataTable(ssql);
                    //Modify By Tany 2010-01-25 pub_user表不能完全使用所有字段，登录信息不需要插入和修改，所以不能使用自动生成的语句
                    if (tb_mb.Rows.Count == 0)
                    {
                        MB_DB.DoCommand("SET IDENTITY_INSERT " + ts.Ymc + "  ON");
                        sql_insert = "insert into pub_user(Id, Employee_Id, Code, Password, Locked_Bit, Delete_Bit, JKY_BIT, Login_Bit)" +
                            " values (" + Convert.ToInt32(tb.Rows[i]["ID"]) + "," + Convert.ToInt32(tb.Rows[i]["Employee_Id"]) + "," +
                            " '" + Convert.ToString(tb.Rows[i]["Code"]) + "','" + Convert.ToString(tb.Rows[i]["Password"]) + "'," +
                            " " + Convert.ToInt32(tb.Rows[i]["Locked_Bit"]) + "," + Convert.ToInt32(tb.Rows[i]["Delete_Bit"]) + "," +
                            " " + Convert.ToInt32(tb.Rows[i]["JKY_BIT"]) + ",0)";
                        MB_DB.DoCommand(sql_insert);
                        MB_DB.DoCommand("SET IDENTITY_INSERT " + ts.Ymc + "  OFF");
                    }
                    else
                    {
                        sql_update = "update pub_user set "+
                            " Employee_Id=" + Convert.ToInt32(tb.Rows[i]["Employee_Id"]) + "," +
                            " Code='" + Convert.ToString(tb.Rows[i]["Code"]) + "'," +
                            " Password='" + Convert.ToString(tb.Rows[i]["Password"]) + "'," +
                            " Locked_Bit=" + Convert.ToInt32(tb.Rows[i]["Locked_Bit"]) + "," +
                            " Delete_Bit=" + Convert.ToInt32(tb.Rows[i]["Delete_Bit"]) + "," +
                            " JKY_BIT=" + Convert.ToInt32(tb.Rows[i]["JKY_BIT"]) +
                            " where " + ts.Ylm + "='" + ts.Yzj + "'";
                        MB_DB.DoCommand(sql_update);
                    }
                }
                //用户组
                tb = null;
                returnSql(BD_DB, "pub_group_user", "user_id", ts.Yzj, out sql_insert, out sql_update, out sql_delete, out tb);
                ssql = "delete from pub_group_user where user_id=" + ts.Yzj + "";
                MB_DB.DoCommand(ssql);

                MB_DB.DoCommand("SET IDENTITY_INSERT pub_group_user ON");
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    MB_DB.DoCommand("insert into pub_group_user(id,group_id,user_id,delete_bit) " +
                        "values( " + Convert.ToInt32(tb.Rows[i]["ID"]) + "," + Convert.ToInt32(tb.Rows[i]["group_id"]) + ","
                        + Convert.ToInt32(tb.Rows[i]["user_id"]) + "," + Convert.ToInt32(tb.Rows[i]["delete_bit"]) + ")");
                }
                MB_DB.DoCommand("SET IDENTITY_INSERT pub_group_user OFF");
                #endregion

                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                scope.Complete();
            }
        }

        //test
        public static void update1(ts_HospData_Share.ts_update_log ts, RelationalDatabase LocalDatabase)
        {
            //string ssql = "";
            //string sql_insert = "";
            //string sql_update = "";
            //string sql_delete = "";
            //DataTable tb = null;

            //returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete, out tb);

            //string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();

            //using (CommittableTransaction ct = new CommittableTransaction())
            //{
            //    //目标服务器的链接
            //    RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
            //    //本地服务器的链接
            //    RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));

            //    MB_DB.setCommittableTransaction(ct);
            //    BD_DB.setCommittableTransaction(ct);

            //    try
            //    {
            //        #region 业务操作
            //        //用户表
            //        if (tb.Rows.Count == 0)
            //        {
            //            MB_DB.DoCommand(sql_delete);
            //        }
            //        for (int i = 0; i <= tb.Rows.Count - 1; i++)
            //        {
            //            ssql = "select * from " + ts.Ymc + " where " + ts.Ylm + "='" + ts.Yzj + "'";
            //            DataTable tb_mb = MB_DB.GetDataTable(ssql);
            //            //Modify By Tany 2010-01-25 pub_user表不能完全使用所有字段，登录信息不需要插入和修改，所以不能使用自动生成的语句
            //            if (tb_mb.Rows.Count == 0)
            //            {
            //                MB_DB.DoCommand("SET IDENTITY_INSERT " + ts.Ymc + "  ON");
            //                sql_insert = "insert into pub_user(Id, Employee_Id, Code, Password, Locked_Bit, Delete_Bit, JKY_BIT, Login_Bit)" +
            //                    " values (" + Convert.ToInt32(tb.Rows[i]["ID"]) + "," + Convert.ToInt32(tb.Rows[i]["Employee_Id"]) + "," +
            //                    " '" + Convert.ToString(tb.Rows[i]["Code"]) + "','" + Convert.ToString(tb.Rows[i]["Password"]) + "'," +
            //                    " " + Convert.ToInt32(tb.Rows[i]["Locked_Bit"]) + "," + Convert.ToInt32(tb.Rows[i]["Delete_Bit"]) + "," +
            //                    " " + Convert.ToInt32(tb.Rows[i]["JKY_BIT"]) + ",0)";
            //                MB_DB.DoCommand(sql_insert);
            //                MB_DB.DoCommand("SET IDENTITY_INSERT " + ts.Ymc + "  OFF");
            //            }
            //            else
            //            {
            //                sql_update = "update pub_user set " +
            //                    " Employee_Id=" + Convert.ToInt32(tb.Rows[i]["Employee_Id"]) + "," +
            //                    " Code='" + Convert.ToString(tb.Rows[i]["Code"]) + "'," +
            //                    " Password='" + Convert.ToString(tb.Rows[i]["Password"]) + "'," +
            //                    " Locked_Bit=" + Convert.ToInt32(tb.Rows[i]["Locked_Bit"]) + "," +
            //                    " Delete_Bit=" + Convert.ToInt32(tb.Rows[i]["Delete_Bit"]) + "," +
            //                    " JKY_BIT=" + Convert.ToInt32(tb.Rows[i]["JKY_BIT"]) +
            //                    " where " + ts.Ylm + "='" + ts.Yzj + "'";
            //                MB_DB.DoCommand(sql_update);
            //            }
            //        }
            //        //用户组
            //        tb = null;
            //        returnSql(BD_DB, "pub_group_user", "user_id", ts.Yzj, out sql_insert, out sql_update, out sql_delete, out tb);
            //        ssql = "delete from pub_group_user where user_id=" + ts.Yzj + "";
            //        MB_DB.DoCommand(ssql);

            //        MB_DB.DoCommand("SET IDENTITY_INSERT pub_group_user ON");
            //        for (int i = 0; i <= tb.Rows.Count - 1; i++)
            //        {
            //            MB_DB.DoCommand("insert into pub_group_user(id,group_id,user_id,delete_bit) " +
            //                "values( " + Convert.ToInt32(tb.Rows[i]["ID"]) + "," + Convert.ToInt32(tb.Rows[i]["group_id"]) + ","
            //                + Convert.ToInt32(tb.Rows[i]["user_id"]) + "," + Convert.ToInt32(tb.Rows[i]["delete_bit"]) + ")");
            //        }
            //        MB_DB.DoCommand("SET IDENTITY_INSERT pub_group_user OFF");
            //        #endregion

            //        BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
            //        ct.Commit();
            //    }
            //    catch (Exception err)
            //    {
            //        ct.Rollback();
            //        throw err;
            //    }
            //    finally
            //    {
            //        MB_DB.Dispose();
            //        BD_DB.Dispose();
            //    }
            //}




        }


    }
}
