using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;

namespace ts_HospData_Share
{
    class jc_employ
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

            returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete,out  tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();
            

            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));

                #region 业务操作
               
                //人员表
                if (tb.Rows.Count == 0)
                {
                    MB_DB.DoCommand(sql_delete);

                }
               for( int i=0;i<=tb.Rows.Count-1;i++)
               {
                    ssql = "select * from " + ts.Ymc + " where " + ts.Ylm + "='" + ts.Yzj + "'";
                    DataTable tb_mb = MB_DB.GetDataTable(ssql);
                    if (tb_mb.Rows.Count == 0)
                    {
                        MB_DB.DoCommand("SET IDENTITY_INSERT " + ts.Ymc + "  ON");
                        MB_DB.DoCommand(sql_insert);
                        MB_DB.DoCommand("SET IDENTITY_INSERT " + ts.Ymc + "  OFF");
                    }
                    else
                        MB_DB.DoCommand(sql_update);
                    if (tb.Rows[i]["delete_bit"].ToString() == "1")
                    {
                        ssql = "delete from pub_group_user where user_id in(select id from  pub_user where employee_id=" + ts.Yzj + ")";
                        MB_DB.DoCommand(ssql);

                        ssql = "delete from pub_user where employee_id=" + ts.Yzj;
                        MB_DB.DoCommand(ssql);

                    }
                }
                //护士表
                tb = null;
                returnSql(BD_DB, "jc_role_nurse", "employee_id", ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);
                ssql = "delete from jc_role_nurse where employee_id=" + ts.Yzj + "";
                MB_DB.DoCommand(ssql);

                MB_DB.DoCommand("SET IDENTITY_INSERT jc_role_nurse  ON");
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    MB_DB.DoCommand("insert into jc_role_nurse(nurse_id,dept_id,employee_id,password,type) " +
                            "values( " + Convert.ToInt32(tb.Rows[i]["nurse_id"]) + "," + Convert.ToInt32(tb.Rows[i]["dept_id"]) + "," + Convert.ToInt32(tb.Rows[i]["employee_id"]) + ",'" + Convert.ToString(tb.Rows[i]["password"]) + "'," + Convert.ToInt32(tb.Rows[i]["type"]) + ")");
                }
                MB_DB.DoCommand("SET IDENTITY_INSERT jc_role_nurse  OFF");

                //医生表
                tb = null;
                returnSql(BD_DB, "jc_role_doctor", "employee_id", ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);
                ssql = "delete from jc_role_doctor where employee_id=" + ts.Yzj + "";
                MB_DB.DoCommand(ssql);

                MB_DB.DoCommand("SET IDENTITY_INSERT jc_role_doctor  ON");
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    MB_DB.DoCommand("insert into jc_role_doctor(doc_id,employee_id,ys_code,cf_right,mz_right,dm_right,ys_typeid) " +
                        "values( " + Convert.ToInt32(tb.Rows[i]["doc_id"]) + "," + Convert.ToInt32(tb.Rows[i]["employee_id"]) + ",'"
                        + Convertor.IsNull(tb.Rows[i]["ys_code"],"") + "'," + Convert.ToString(tb.Rows[i]["cf_right"]) + "," +
                        Convert.ToString(tb.Rows[i]["mz_right"]) + "," + Convert.ToInt16(tb.Rows[i]["dm_right"]) + "," + Convert.ToInt16(tb.Rows[i]["ys_typeid"]) + ")");
                }
                MB_DB.DoCommand("SET IDENTITY_INSERT jc_role_doctor  OFF");

                //人员科室关系
                tb = null;
                returnSql(BD_DB, "jc_emp_dept_role", "employee_id", ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);
                ssql = "delete from jc_emp_dept_role where employee_id=" + ts.Yzj + "";
                MB_DB.DoCommand(ssql);

                MB_DB.DoCommand("SET IDENTITY_INSERT jc_emp_dept_role  ON");
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    MB_DB.DoCommand("insert into jc_emp_dept_role(id,employee_id,[default], dept_id,xtbh) " +
                        "values( " + Convert.ToInt32(tb.Rows[i]["ID"]) + "," + Convert.ToInt32(tb.Rows[i]["employee_id"]) + ",'"
                        + Convert.ToString(tb.Rows[i]["default"]) + "'," + Convert.ToInt32(tb.Rows[i]["dept_id"]) + "," + Convert.ToInt16(tb.Rows[i]["xtbh"]) + ")");
                }
                MB_DB.DoCommand("SET IDENTITY_INSERT jc_emp_dept_role  OFF");

                #endregion



                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='"+sDate+"',wcczy="+TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId+" where id='"+ts.Id+"' and bwcbz=0");
                scope.Complete();

            }
            



        }



    }
}
