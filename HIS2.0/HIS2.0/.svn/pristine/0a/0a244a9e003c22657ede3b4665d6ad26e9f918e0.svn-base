using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;

namespace ts_HospData_Share
{
    class pub_menu
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

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="LocalDatabase"></param>
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

                if (tb.Rows.Count == 0)
                {
                    MB_DB.DoCommand(sql_delete);
                }
                if (tb.Rows.Count == 1)
                {
                    ssql = "select * from " + ts.Ymc + " where " + ts.Ylm + "='" + ts.Yzj + "'";
                    DataTable tb_mb = MB_DB.GetDataTable(ssql);
                    //首先给Icon插入一个null值，然后再更新
                    if (tb_mb.Rows.Count == 0)
                    {
                        //菜单需要自己组合入参，主要是因为Icon列是image格式 Modify By Tany 2010-01-29
                        sql_insert = "insert into pub_menu(Menu_Id, Name, Dll_Name, Function_Name, Icon, Delete_Bit, Function_Tag, ShowToolBar, JGBM)"+
                            " values ( " + ts.Yzj + ",'" + tb.Rows[0]["Name"].ToString() + "'," +
                            " '" + tb.Rows[0]["Dll_Name"].ToString() + "','" + tb.Rows[0]["Function_Name"].ToString() + "', " +
                            " null," + tb.Rows[0]["Delete_Bit"].ToString() + ", " +
                            " '" + tb.Rows[0]["Function_Tag"].ToString() + "'," + tb.Rows[0]["ShowToolBar"].ToString() + "," + tb.Rows[0]["JGBM"].ToString() + " )";
                        MB_DB.DoCommand("SET IDENTITY_INSERT " + ts.Ymc + "  ON");
                        MB_DB.DoCommand(sql_insert);
                        MB_DB.DoCommand("SET IDENTITY_INSERT " + ts.Ymc + "  OFF");
                    }
                    else
                    {
                        //菜单需要自己组合入参，主要是因为Icon列是image格式 Modify By Tany 2010-01-29
                        sql_update = "update pub_menu set Name='" + tb.Rows[0]["Name"].ToString() + "'," +
                            " Dll_Name='" + tb.Rows[0]["Dll_Name"].ToString() + "'," +
                            " Function_Name='" + tb.Rows[0]["Function_Name"].ToString() + "'," +
                            " Icon=null," +
                            " Delete_Bit=" + tb.Rows[0]["Delete_Bit"].ToString() + "," +
                            " Function_Tag='" + tb.Rows[0]["Function_Tag"].ToString() + "'," +
                            " ShowToolBar=" + tb.Rows[0]["ShowToolBar"].ToString() + "," +
                            " JGBM=" + tb.Rows[0]["JGBM"].ToString() + " where Menu_Id =" + ts.Yzj;
                        MB_DB.DoCommand(sql_update);
                    }
                    if(!Convert.IsDBNull(tb.Rows[0]["Icon"]))
                    {
                        string sql = "update pub_menu set icon=@Ico where menu_id=@menuId";
                        IDbCommand cmd = MB_DB.GetCommand();
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;

                        IDataParameter parameter;
                        parameter = cmd.CreateParameter();
                        parameter.ParameterName = "@Ico";
                        parameter.Value = (byte[])tb.Rows[0]["Icon"];
                        cmd.Parameters.Add(parameter);

                        parameter = cmd.CreateParameter();
                        parameter.ParameterName = "@menuId";
                        parameter.Value = ts.Yzj;
                        cmd.Parameters.Add(parameter);

                        cmd.ExecuteNonQuery();
                    }
                }
                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                scope.Complete();
            }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="LocalDatabase"></param>
        public static void delete_menu(ts_HospData_Share.ts_update_log ts, RelationalDatabase LocalDatabase)
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
                if (tb.Rows.Count == 0)
                {
                    ssql = "Delete From pub_group_menu where system_menu_id in ( select sys_menu_id from pub_system_menu where menu_id=" + ts.Yzj + ")";
                    MB_DB.DoCommand(ssql);
                    ssql = "Delete From pub_system_menu where menu_id = " + ts.Yzj + "";
                    MB_DB.DoCommand(ssql);
                    //ssql = "Delete From pub_menu where menu_Id=" + ts.Yzj + "";
                    //MB_DB.DoCommand(ssql);
                    MB_DB.DoCommand(sql_delete);
                }
                #endregion

                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                scope.Complete();
            }
        }

        /// <summary>
        /// 修改系统菜单
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="LocalDatabase"></param>
        public static void update_systemmenu(ts_HospData_Share.ts_update_log ts, RelationalDatabase LocalDatabase)
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
                ssql = "delete from pub_system_menu where system_Id=" + ts.Yzj + "";
                MB_DB.DoCommand(ssql);
  
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    //如果目标机器没有这个菜单，则新增一个
                    ssql = "select * from pub_menu where menu_Id=" + tb.Rows[i]["Menu_Id"].ToString();
                    DataTable tb_mb = MB_DB.GetDataTable(ssql);
                    if (tb_mb.Rows.Count == 0)
                    {
                        DataTable tb_bd = BD_DB.GetDataTable(ssql);
                        //菜单需要自己组合入参，主要是因为Icon列是image格式 Modify By Tany 2010-01-29
                        sql_insert = "insert into pub_menu(Menu_Id, Name, Dll_Name, Function_Name, Icon, Delete_Bit, Function_Tag, ShowToolBar, JGBM)" +
                            " values ( " + tb_bd.Rows[0]["Menu_Id"].ToString() + ",'" + tb_bd.Rows[0]["Name"].ToString() + "'," +
                            " '" + tb_bd.Rows[0]["Dll_Name"].ToString() + "','" + tb_bd.Rows[0]["Function_Name"].ToString() + "', " +
                            " null," + tb_bd.Rows[0]["Delete_Bit"].ToString() + ", " +
                            " '" + tb_bd.Rows[0]["Function_Tag"].ToString() + "'," + tb_bd.Rows[0]["ShowToolBar"].ToString() + "," + tb_bd.Rows[0]["JGBM"].ToString() + " )";
                        MB_DB.DoCommand("SET IDENTITY_INSERT pub_menu  ON");
                        MB_DB.DoCommand(sql_insert);
                        MB_DB.DoCommand("SET IDENTITY_INSERT pub_menu  OFF");
                    }

                    MB_DB.DoCommand("SET IDENTITY_INSERT pub_system_menu ON");
                    MB_DB.DoCommand("insert into pub_system_menu(Sys_Menu_Id, System_Id, Menu_Id, Parent_id, Sort_Id, Delete_Bit) " +
                        "values( " + Convert.ToInt32(tb.Rows[i]["Sys_Menu_Id"]) + "," + Convert.ToInt32(tb.Rows[i]["System_Id"]) + ","
                        + Convert.ToInt32(tb.Rows[i]["Menu_Id"]) + "," + Convert.ToInt32(tb.Rows[i]["Parent_id"]) + ","
                        + Convert.ToInt32(tb.Rows[i]["Sort_Id"]) + "," + Convert.ToInt32(tb.Rows[i]["Delete_Bit"]) + ")");
                    MB_DB.DoCommand("SET IDENTITY_INSERT pub_system_menu OFF");
                }
                #endregion

                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                scope.Complete();
            }
        }
    }
}
