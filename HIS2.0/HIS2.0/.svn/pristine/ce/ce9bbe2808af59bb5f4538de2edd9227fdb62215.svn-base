using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;
using TrasenFrame.Classes;

namespace ts_HospData_Share
{
    public class yp_ykck
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

            if (ts.Ymc.ToLower() != "yk_dj") throw new Exception("源名称必须是YK_DJ");

            returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();

            ssql = "select id,djid,cjid,kwid,shh,yppm,ypspm,ypgg,sccj,ypph,ypxq,ypkl,sqsl,ypsl,ypdw,nypdw,ydwbl,jhj,pfj,lsj,jhje,pfje,lsje,djh,deptid,ywlx,bz,shdh from yk_djmx  where djid='" + ts.Yzj + "'";
            DataTable tbmx = LocalDatabase.GetDataTable(ssql);

            int tojgbm = 0;
            if (tb.Rows.Count > 0)
            {
                DataTable tb_jgbm = LocalDatabase.GetDataTable("select * from yp_yjks where deptid=" + tb.Rows[0]["wldw"].ToString() + "");
                if (tb_jgbm.Rows.Count > 0) tojgbm = Convert.ToInt32(tb_jgbm.Rows[0]["szjgbm"]);
            }
            using (TransactionScope scope = new TransactionScope())
            {
                //目标服务器的链接
                RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                //本地服务器的链接
                RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));


                if (tb.Rows.Count == 0)
                    MB_DB.DoCommand(sql_delete);
                else
                {
                    ssql = "select * from yk_DJ where id='"+ts.Yzj+"'";
                    DataTable tb_mb = MB_DB.GetDataTable(ssql);
                    if (tb_mb.Rows.Count > 0)
                        MB_DB.DoCommand(sql_update);
                    else
                        MB_DB.DoCommand(sql_insert);
                }

                for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                {
                    ssql = "insert into YK_DJMX(id,djid,cjid,kwid,shh,yppm,ypspm,ypgg,sccj,ypph,ypxq,ypkl,sqsl,ypsl,ypdw,nypdw,ydwbl,"+
                        " jhj,pfj,lsj,jhje,pfje,lsje,djh,deptid,ywlx,bz,shdh)values(" +
                        "'"+tbmx.Rows[i]["id"].ToString()+"','"+tbmx.Rows[i]["djid"].ToString()+"',"+tbmx.Rows[i]["cjid"].ToString()+","+
                        tbmx.Rows[i]["kwid"].ToString() + ",'" + tbmx.Rows[i]["shh"].ToString() + "','" + tbmx.Rows[i]["yppm"].ToString() + "','" +
                        tbmx.Rows[i]["ypspm"].ToString() + "','" + tbmx.Rows[i]["ypgg"].ToString() + "','" + tbmx.Rows[i]["sccj"].ToString() + "','" +
                        tbmx.Rows[i]["ypph"].ToString() + "','" + tbmx.Rows[i]["ypxq"].ToString() + "'," + tbmx.Rows[i]["ypkl"].ToString() + "," +
                        tbmx.Rows[i]["sqsl"].ToString() + "," + tbmx.Rows[i]["ypsl"].ToString() + ",'" + tbmx.Rows[i]["ypdw"].ToString() + "'," +
                        tbmx.Rows[i]["nypdw"].ToString() + "," + Convertor.IsNull(tbmx.Rows[i]["ydwbl"], "") + "," + Convertor.IsNull(tbmx.Rows[i]["jhj"], "") +
                        "," + tbmx.Rows[i]["pfj"].ToString() + "," + tbmx.Rows[i]["lsj"].ToString() + "," + tbmx.Rows[i]["jhje"].ToString() +
                        "," + tbmx.Rows[i]["pfje"].ToString() + "," + tbmx.Rows[i]["lsje"].ToString() + ",'" + tbmx.Rows[i]["djh"].ToString() +
                        "'," + tbmx.Rows[i]["deptid"].ToString() + ",'" + tbmx.Rows[i]["ywlx"].ToString() + "','" + tbmx.Rows[i]["bz"].ToString() + "','" + tbmx.Rows[i]["shdh"].ToString() + "')";
                    MB_DB.DoCommand(ssql);
                }

                if (tb.Rows.Count > 0)
                {
                    ParameterEx[] parameters = new ParameterEx[10];
                    parameters[0].Text = "@djh";
                    parameters[0].Value = tb.Rows[0]["DJH"].ToString();

                    parameters[1].Text = "@deptid";
                    parameters[1].Value = tb.Rows[0]["deptid"].ToString();

                    parameters[2].Text = "@sqdh";
                    parameters[2].Value = tb.Rows[0]["sqdh"].ToString();

                    parameters[3].Text = "@sqks";
                    parameters[3].Value = tb.Rows[0]["WLDW"].ToString();

                    parameters[4].Text = "@ywlx";
                    parameters[4].Value = tb.Rows[0]["YWLX"].ToString();

                    parameters[5].Text = "@djid";
                    parameters[5].ParaDirection = ParameterDirection.Output;
                    parameters[5].DataType = System.Data.DbType.Guid;
                    parameters[5].ParaSize = 100;

                    parameters[6].Text = "@err_code";
                    parameters[6].ParaDirection = ParameterDirection.Output;
                    parameters[6].DataType = System.Data.DbType.Int32;
                    parameters[6].ParaSize = 100;

                    parameters[7].Text = "@err_text";
                    parameters[7].ParaDirection = ParameterDirection.Output;
                    parameters[7].ParaSize = 100;

                    parameters[8].Text = "@tojgbm";
                    parameters[8].Value = tojgbm;

                    parameters[9].Text = "@YDJID";
                    parameters[9].Value = ts.Yzj;

                    MB_DB.DoCommand("sp_Yk_Rksq_Insert_Djmx", parameters, 30);


                    Guid djid = new Guid(Convertor.IsNull(parameters[5].Value.ToString(), Guid.Empty.ToString()));
                    int err_code = Convert.ToInt32(parameters[6].Value);
                    string err_text = Convert.ToString(parameters[7].Value);

                    if (err_code != 0) throw new Exception(err_text);

                    MB_DB.DoCommand("delete from yk_dj where id='" + ts.Yzj + "'");
                    MB_DB.DoCommand("delete from yk_djmx where djid='" + ts.Yzj + "'");

                    if (new SystemCfg(8018,BD_DB).Config == "1")
                    {
                        #region 审核药房的出库单
                        ssql = "update yf_dj set shbz=1,shy=" + ts.Djy + ",shrq='" + ts.Djsj + "' where id='" + djid + "'  and shbz=0";
                        int nrow = (int)MB_DB.DoCommand(ssql, 30);
                        if (nrow != 1) throw new System.Exception("审核药房[药品出库单]错误，数据影响了多行或零行，请和管理员联系");


                        ParameterEx[] parameters1 = new ParameterEx[4];
                        parameters1[0].Text = "@djid";
                        parameters1[0].Value = djid;

                        parameters1[1].Text = "@err_code";
                        parameters1[1].ParaDirection = ParameterDirection.Output;
                        parameters1[1].DataType = System.Data.DbType.Int32;
                        parameters1[1].ParaSize = 100;

                        parameters1[2].Text = "@err_text";
                        parameters1[2].ParaDirection = ParameterDirection.Output;
                        parameters1[2].ParaSize = 100;

                        parameters1[3].Text = "@jgbm";
                        parameters1[3].Value = tojgbm;


                        MB_DB.DoCommand("sp_yf_updatekcmx", parameters1, 120);
                        err_code = Convert.ToInt32(parameters1[1].Value);
                        err_text = Convert.ToString(parameters1[2].Value);

                        if (err_code != 0) throw new Exception(err_text);
                        #endregion
                    }
                }

                BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='"+sDate+"',wcczy="+TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId+" where id='"+ts.Id+"' and bwcbz=0");
                scope.Complete();

            }
            



        }

       /// <summary>
        /// 检索在途单据 
       /// </summary>
       /// <param name="_ss"></param>
       /// <param name="LocalDatabase"></param>
       /// <param name="errtext"></param>
       /// <returns></returns>
        public static DataTable GetZtdj(string _ss,RelationalDatabase LocalDatabase,out string errtext,long jgbm)
        {


            errtext = "";
            string ssql = "select * from jc_jgbm where ipaddr is not null and len(ipaddr)>10 and jgbm<>" + jgbm + "  ";
            DataTable tbjg = LocalDatabase.GetDataTable(ssql);

            DataTable tb=LocalDatabase.GetDataTable(_ss);
            ts_update_type tstype = new ts_update_type((int)czlx.yp_药品调价, LocalDatabase);
            if (tstype.BscBz == 1) return tb;

            for (int i = 0; i <= tbjg.Rows.Count - 1; i++)
            {
                try
                {
                    RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(tbjg.Rows[i]["jgbm"]));
                    DataTable tb1 = MB_DB.GetDataTable(_ss);
                    for (int j = 0; j <= tb1.Rows.Count - 1; j++)
                        tb.ImportRow(tb1.Rows[j]);
                    MB_DB.Close();
                    MB_DB.Dispose();
                }
                catch (System.Exception err)
                {
                    errtext = errtext + "在检索【" + tbjg.Rows[i]["jgmc"].ToString() + "】[在途单据] 时遇到错误\n" + err.Message.ToString();
                }
            }
            return tb;
        }

    }
}
