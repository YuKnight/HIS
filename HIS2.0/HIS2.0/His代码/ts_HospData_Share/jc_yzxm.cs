using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;

namespace ts_HospData_Share
{
    class jc_yzxm
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

            if (ts.Ymc.ToLower() != "jc_hoitemdiction") throw new Exception("源名称必须是jc_hoitemdiction");

            returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete,out  tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();
            

            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));

                #region 业务操作
               
                //医嘱项目表
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
                }


                //医嘱执行科室
                tb = null;
                ssql = "select * from jc_hoi_dept where order_id=" + ts.Yzj + " ";
                tb = BD_DB.GetDataTable(ssql);
                ssql = "delete from jc_hoi_dept where order_id=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);

                MB_DB.DoCommand("SET IDENTITY_INSERT jc_hoi_dept  ON");
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    MB_DB.DoCommand("insert into jc_hoi_dept(id,order_id,exec_dept,default_bit) " +
                            "values( " + Convert.ToInt32(tb.Rows[i]["id"]) + "," + Convert.ToInt32(tb.Rows[i]["order_id"]) + "," + Convert.ToInt32(tb.Rows[i]["exec_dept"]) + "," + Convert.ToInt16(tb.Rows[i]["default_bit"]) + ")");
                }
                MB_DB.DoCommand("SET IDENTITY_INSERT jc_hoi_dept  OFF");


                //与收费项目对应
                tb = null;
                returnSql(BD_DB, "jc_hoi_hdi", "hoitem_id", ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);
                ssql = "delete from jc_hoi_hdi where hoitem_id=" + ts.Yzj + "";
                MB_DB.DoCommand(ssql);

                MB_DB.DoCommand("SET IDENTITY_INSERT jc_hoi_hdi  ON");
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    MB_DB.DoCommand("insert into jc_hoi_hdi(id,hoitem_id,hditem_id,num,tc_flag,tcid) " +
                            "values( " + Convert.ToInt32(tb.Rows[i]["id"]) + "," + Convert.ToInt32(tb.Rows[i]["hoitem_id"]) + "," + Convert.ToInt32(tb.Rows[i]["hditem_id"]) + "," + Convert.ToDecimal(tb.Rows[i]["num"]) + ",'" + Convert.ToInt16(tb.Rows[i]["tc_flag"]) + "'," + Convert.ToInt32(tb.Rows[i]["tcid"]) + ")");
                }
                MB_DB.DoCommand("SET IDENTITY_INSERT jc_hoi_hdi  OFF");




                //同步更新检查
                tb = null;
                ssql = "select * from jc_jc_item where yzid=" + ts.Yzj + " ";
                tb = BD_DB.GetDataTable(ssql);
                ssql = "delete from jc_jc_item where yzid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);

                MB_DB.DoCommand("SET IDENTITY_INSERT jc_jc_item  ON");
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    MB_DB.DoCommand("insert into jc_jc_item(id,yzid,jclxid) " +
                            "values( " + Convert.ToInt32(tb.Rows[i]["id"]) + "," + Convert.ToInt32(tb.Rows[i]["yzid"]) + "," + Convert.ToInt32(tb.Rows[i]["jclxid"]) + ")");
                }
                MB_DB.DoCommand("SET IDENTITY_INSERT jc_jc_item  OFF");

                //同步更新化验
                tb = null;
                ssql = "select * from jc_assay where yzid=" + ts.Yzj + " ";
                tb = BD_DB.GetDataTable(ssql);
                ssql = "delete from jc_assay where yzid=" + ts.Yzj + " ";
                MB_DB.DoCommand(ssql);

                MB_DB.DoCommand("SET IDENTITY_INSERT jc_assay  ON");
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    MB_DB.DoCommand("insert into jc_assay(id,yzid,bbid,hylxid) " +
                            "values( " + Convert.ToInt32(tb.Rows[i]["id"]) + "," + Convert.ToInt32(tb.Rows[i]["yzid"]) + "," + Convert.ToInt32(tb.Rows[i]["bbid"]) + "," + Convert.ToInt32(tb.Rows[i]["hylxid"]) + ")");
                }
                MB_DB.DoCommand("SET IDENTITY_INSERT jc_assay  OFF");

 
                #endregion



                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='"+sDate+"',wcczy="+TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId+" where id='"+ts.Id+"' and bwcbz=0");
                scope.Complete();

            }
            



        }



    }
}
