using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;
namespace ts_HospData_Share
{
    class pub_systemupdate
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
        /// 修改升级文件
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
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    //ssql = "select 1 from pub_systemupdate where id=" + tb.Rows[i]["id"].ToString();
                    //DataTable tb_mb = MB_DB.GetDataTable(ssql);
                    //首先给File_Value插入一个null值，然后再更新
                    //if (tb_mb.Rows.Count == 0)
                    //{
                    //Modify By Tany 2010-02-22 不管目标服务器上是否有这个更新文件信息，全部重新插入，并且不要求ID同步
                    ssql = "update pub_systemupdate set delete_bit=1 where name='" + tb.Rows[i]["Name"].ToString() + "'";
                    MB_DB.DoCommand(ssql);

                    sql_insert = "insert into pub_systemupdate(Type, Name, Update_Time, Version, File_Value, Delete_bit, DelLocalReport)" +//Id, 
                        " values (" + tb.Rows[i]["Type"].ToString() + "," + //" + tb.Rows[i]["id"].ToString() + ",
                        " '" + tb.Rows[i]["Name"].ToString() + "','" + tb.Rows[i]["Update_Time"].ToString() + "', " +
                        " '" + tb.Rows[i]["Version"].ToString() + "',null," + tb.Rows[i]["Delete_Bit"].ToString() + ", " +
                        " " + tb.Rows[i]["DelLocalReport"].ToString() + " )";
                    //MB_DB.DoCommand("SET IDENTITY_INSERT pub_systemupdate  ON");
                    object id;
                    MB_DB.InsertRecord(sql_insert, out id);
                    //MB_DB.DoCommand("SET IDENTITY_INSERT pub_systemupdate  OFF");
                    //}
                    //else
                    //{
                    //    sql_update = "update pub_systemupdate set " +
                    //        " Type=" + Convert.ToInt32(tb.Rows[i]["Type"]) + "," +
                    //        " Name='" + Convert.ToString(tb.Rows[i]["Name"]) + "'," +
                    //        " Update_Time='" + Convert.ToString(tb.Rows[i]["Update_Time"]) + "'," +
                    //        " Version='" + Convert.ToString(tb.Rows[i]["Version"]) + "'," +
                    //        " Delete_bit=" + Convert.ToInt32(tb.Rows[i]["Delete_Bit"]) + "," +
                    //        " DelLocalReport=" + Convert.ToInt32(tb.Rows[i]["DelLocalReport"]) +
                    //        " where id=" + tb.Rows[i]["id"].ToString();
                    //    MB_DB.DoCommand(sql_update);
                    //}
                    if (!Convert.IsDBNull(tb.Rows[i]["File_Value"]) && Convert.ToInt32(tb.Rows[i]["Delete_Bit"]) == 0)
                    {
                        string sql = "update pub_systemupdate set File_Value=@file where id=@id";
                        IDbCommand cmd = MB_DB.GetCommand();
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;

                        IDataParameter parameter;
                        parameter = cmd.CreateParameter();
                        parameter.ParameterName = "@file";
                        parameter.Value = (byte[])tb.Rows[i]["File_Value"];
                        cmd.Parameters.Add(parameter);

                        parameter = cmd.CreateParameter();
                        parameter.ParameterName = "@id";
                        parameter.Value = id.ToString();
                        cmd.Parameters.Add(parameter);

                        cmd.ExecuteNonQuery();
                    }
                }
                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                scope.Complete();
            }
        }

        /// <summary>
        /// 删除升级文件
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="LocalDatabase"></param>
        public static void delete(ts_HospData_Share.ts_update_log ts, RelationalDatabase LocalDatabase)
        {
            string ssql = "";
            string sql_insert = "";
            string sql_update = "";
            string sql_delete = "";
            DataTable tb = null;

            //returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete, out tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();

            //Modify By Tany 2010-02-22 找到本地的版本和名称信息，更新目标服务器时不用ID来判断，用版本和名称来判断
            tb = LocalDatabase.GetDataTable("select Id, Type, Name, Update_Time, Version, Delete_bit, DelLocalReport from pub_systemupdate where id = " + ts.Yzj);

            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));

                #region 业务操作
                ssql = "update pub_systemupdate set delete_bit=1 where Version = '" + tb.Rows[0]["Version"].ToString() + "' and Name='" + tb.Rows[0]["Name"].ToString() + "'";
                MB_DB.DoCommand(ssql);
                #endregion

                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                scope.Complete();
            }
        }
    }
}
