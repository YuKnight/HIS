using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;

namespace ts_HospData_Share
{
    class jc_sfxm
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
                        if ( tb.Rows[0][tbcol.Rows[i]["colname"].ToString()] ==DBNull.Value)
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



                //收费项目或套餐表
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
                    {
                        //停用匹配关系
                        if (ts.Ymc.ToLower() == "jc_hsitem")
                        {
                            ParameterEx[] parameters = new ParameterEx[2];
                            parameters[0].Text = "@xmid";
                            parameters[0].Value = ts.Yzj;
                            parameters[1].Text = "@xmly";
                            parameters[1].Value = 2;
                            MB_DB.DoCommand("sp_yb_qxybppgx", parameters, 30);
                        }

                        MB_DB.DoCommand(sql_update);
                    }
                }


                if (ts.Ymc.ToLower() == "jc_tc_t")
                {
                    #region 套餐
                    //套餐明细
                    tb = null;
                    returnSql(BD_DB, "jc_tc_mx", "mainitem_id", ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);
                    ssql = "delete from jc_tc_mx where mainitem_id=" + ts.Yzj + "";
                    MB_DB.DoCommand(ssql);

                    MB_DB.DoCommand("SET IDENTITY_INSERT jc_tc_mx  ON");
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        MB_DB.DoCommand("insert into jc_tc_mx(id,mainitem_id,mainitem_code,subitem_id,subitem_code,num) " +
                                "values( " + Convert.ToInt32(tb.Rows[i]["id"]) + "," + Convert.ToInt32(tb.Rows[i]["mainitem_id"]) + ",'" + Convert.ToString(tb.Rows[i]["mainitem_code"]) + "'," + Convert.ToInt32(tb.Rows[i]["subitem_id"]) + ",'" + Convert.ToString(tb.Rows[i]["subitem_code"]) + "'," + Convert.ToDecimal(tb.Rows[i]["num"]) + ")");
                    }
                    MB_DB.DoCommand("SET IDENTITY_INSERT jc_tc_mx  OFF");

                    //套餐价格
                    tb = null;
                    returnSql(BD_DB, "jc_tcprice", "tcid", ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);
                    ssql = "delete from jc_tcprice where tcid=" + ts.Yzj + "";
                    MB_DB.DoCommand(ssql);

                    MB_DB.DoCommand("SET IDENTITY_INSERT jc_tcprice  ON");
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        MB_DB.DoCommand("insert into jc_tcprice(id,tcid,price,jgbm,jgmc,bdelete) " +
                                "values( " + Convert.ToInt32(tb.Rows[i]["id"]) + "," + Convert.ToInt32(tb.Rows[i]["tcid"]) + "," + Convert.ToDecimal(tb.Rows[i]["price"]) + "," + Convert.ToInt32(tb.Rows[i]["jgbm"]) + ",'" + Convert.ToString(tb.Rows[i]["jgmc"]) + "'," + Convert.ToInt16(tb.Rows[i]["bdelete"]) + ")");
                    }
                    MB_DB.DoCommand("SET IDENTITY_INSERT jc_tcprice  OFF");

                    //套餐执行科室
                    tb = null;
                    ssql = "select * from jc_hsitem_dept where tcid=" + ts.Yzj + "";
                    tb = BD_DB.GetDataTable(ssql);
                    ssql = "delete from jc_hsitem_dept where tcid=" + ts.Yzj + "";
                    MB_DB.DoCommand(ssql);

                    MB_DB.DoCommand("SET IDENTITY_INSERT jc_hsitem_dept  ON");
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        MB_DB.DoCommand("insert into jc_hsitem_dept(id,hsitem_id,exec_dept_id,comments,dept_type,tcid,default_bit) " +
                                "values( " + Convert.ToInt32(tb.Rows[i]["id"]) + "," + Convert.ToInt32(tb.Rows[i]["hsitem_id"]) + "," + Convert.ToInt32(tb.Rows[i]["exec_dept_id"]) + ",'" + Convert.ToString(tb.Rows[i]["comments"]) + "','" + Convert.ToString(tb.Rows[i]["dept_type"]) + "'," + Convert.ToInt32(tb.Rows[i]["tcid"]) + "," + Convert.ToInt16(tb.Rows[i]["default_bit"]) + ")");
                    }
                    MB_DB.DoCommand("SET IDENTITY_INSERT jc_hsitem_dept  OFF");

                    #endregion
                }
                else
                {
                    //项目价格
                    tb = null;
                    returnSql(BD_DB, "jc_hsitemprice", "hsitemid", ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);
                    ssql = "delete from jc_hsitemprice where hsitemid=" + ts.Yzj + "";
                    MB_DB.DoCommand(ssql);

                    MB_DB.DoCommand("SET IDENTITY_INSERT jc_hsitemprice  ON");
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        MB_DB.DoCommand("insert into jc_hsitemprice(id,hsitemid,price,jgbm,jgmc,bdelete) " +
                                "values( " + Convert.ToInt32(tb.Rows[i]["id"]) + "," + Convert.ToInt32(tb.Rows[i]["hsitemid"]) + "," + Convert.ToDecimal(tb.Rows[i]["price"]) + "," + Convert.ToInt32(tb.Rows[i]["jgbm"]) + ",'" + Convert.ToString(tb.Rows[i]["jgmc"]) + "'," + Convert.ToInt16(tb.Rows[i]["bdelete"]) + ")");
                    }
                    MB_DB.DoCommand("SET IDENTITY_INSERT jc_hsitemprice  OFF");


                    //项目执行科室
                    tb = null;
                    ssql = "select * from jc_hsitem_dept where hsitem_id=" + ts.Yzj + " and tcid<=0";
                    tb = BD_DB.GetDataTable(ssql);
                    ssql = "delete from jc_hsitem_dept where hsitem_id=" + ts.Yzj + " and tcid<=0";
                    MB_DB.DoCommand(ssql);

                    MB_DB.DoCommand("SET IDENTITY_INSERT jc_hsitem_dept  ON");
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        MB_DB.DoCommand("insert into jc_hsitem_dept(id,hsitem_id,exec_dept_id,comments,dept_type,tcid,default_bit) " +
                                "values( " + Convert.ToInt32(tb.Rows[i]["id"]) + "," + Convert.ToInt32(tb.Rows[i]["hsitem_id"]) + "," + Convert.ToInt32(tb.Rows[i]["exec_dept_id"]) + ",'" + Convertor.IsNull(tb.Rows[i]["comments"],"") + "','" + Convert.ToString(tb.Rows[i]["dept_type"]) + "'," + Convert.ToInt32(tb.Rows[i]["tcid"]) + "," + Convert.ToInt16(tb.Rows[i]["default_bit"]) + ")");
                    }
                    MB_DB.DoCommand("SET IDENTITY_INSERT jc_hsitem_dept  OFF");

                    //套餐价格
                    tb = null;
                    ssql = @"select mainitem_id,jgbm,sum(price*num) price from jc_tc_mx a inner join jc_hsitemprice b on a.subitem_id=b.hsitemid
                            and mainitem_id in(
                            select mainitem_id from jc_tc_mx a 
                              where subitem_id in( select item_id from jc_hsitem where item_id="+ts.Yzj+@") group by mainitem_id 
                            ) group by mainitem_id,jgbm order by mainitem_id ";
                    tb = BD_DB.GetDataTable(ssql);
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        MB_DB.DoCommand("update jc_tcprice set price=" + tb.Rows[i]["price"] + " where tcid=" + Convert.ToInt32(tb.Rows[i]["mainitem_id"]) + " and jgbm=" + Convert.ToInt32(tb.Rows[i]["jgbm"])+" ");
                    }

                }

                #endregion



                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='"+sDate+"',wcczy="+TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId+" where id='"+ts.Id+"' and bwcbz=0");
                scope.Complete();

            }
            



        }



    }
}
