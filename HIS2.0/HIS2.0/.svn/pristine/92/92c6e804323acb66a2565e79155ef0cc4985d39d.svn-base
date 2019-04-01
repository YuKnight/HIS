using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using System.Transactions;

namespace ts_HospData_Share
{
   public  class yp_tj
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

            if (ts.Ymc.ToLower() != "yf_tj") throw new Exception("源名称必须是yt_tj");

            returnSql(LocalDatabase, ts.Ymc, ts.Ylm, ts.Yzj, out sql_insert, out sql_update, out sql_delete, out  tb);

            string sDate = DateManager.ServerDateTimeByDBType(LocalDatabase).ToString();

            ssql = "select id,djid,cjid,tjsl,ypdw,ydwbl,ypfj,xpfj,tpfje,ylsj,xlsj,tlsje,deptid,djh,mrjhj,scjhj,scghdw  from yf_tjmx where djid='" + ts.Yzj + "'";
            DataTable tbmx = LocalDatabase.GetDataTable(ssql);

            if (ts.Bz == "仅更新中心药品字典")
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    //目标服务器的链接
                    RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.MbjgbM));
                    //本地服务器的链接
                    RelationalDatabase BD_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(ts.Djjgbm));

                    for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                    {
                        ssql = "update  yp_ypcjd set pfj="+tbmx.Rows[i]["xpfj"].ToString()+",lsj="+tbmx.Rows[i]["xlsj"].ToString()+" where cjid="+tbmx.Rows[i]["cjid"].ToString()+"";
                        MB_DB.DoCommand(ssql);
                    }

                    BD_DB.DoCommand("UPDATE ts_update_log set bwcbz=1,wcsj='" + sDate + "',wcczy=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " where id='" + ts.Id + "' and bwcbz=0");
                    scope.Complete();

                }
                return;
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
                    ssql = "select * from yf_tj where id='"+ts.Yzj+"'";
                    DataTable tb_mb = MB_DB.GetDataTable(ssql);
                    if (tb_mb.Rows.Count > 0)
                        MB_DB.DoCommand(sql_update);
                    else
                        MB_DB.DoCommand(sql_insert);
                }

                string Sscjid = "0";
                for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                {
                    ssql = "insert into yf_tjmx(id,djid,cjid,tjsl,ypdw,ydwbl,ypfj,xpfj,tpfje,ylsj,xlsj,tlsje,deptid,djh,mrjhj,scjhj,scghdw)values("+
                        "'"+tbmx.Rows[i]["id"].ToString()+"','"+tbmx.Rows[i]["djid"].ToString()+"',"+tbmx.Rows[i]["cjid"].ToString()+","+
                        tbmx.Rows[i]["tjsl"].ToString()+",'"+tbmx.Rows[i]["ypdw"].ToString()+"',"+tbmx.Rows[i]["ydwbl"].ToString()+","+
                        tbmx.Rows[i]["ypfj"].ToString() + "," + tbmx.Rows[i]["xpfj"].ToString() + "," + tbmx.Rows[i]["tpfje"].ToString()+","+
                        tbmx.Rows[i]["ylsj"].ToString() + "," + tbmx.Rows[i]["xlsj"].ToString() + "," + tbmx.Rows[i]["tlsje"].ToString()+","+
                        tbmx.Rows[i]["deptid"].ToString() + ",'" + tbmx.Rows[i]["djh"].ToString() + "'," + tbmx.Rows[i]["mrjhj"].ToString()+","+
                        tbmx.Rows[i]["scjhj"].ToString() + ",'" +Convertor.IsNull(tbmx.Rows[i]["scghdw"],"")+"')";
                    MB_DB.DoCommand(ssql);
                    Sscjid = Sscjid + "," + tbmx.Rows[i]["cjid"].ToString();
                }

                //System.IO.Ports.SerialPort sp = new System.IO.Ports.SerialPort("COM3");
                
                
                ssql = "select dbo.fun_getdeptname(a.deptid) 部门,dbo.fun_yK_ywlx(a.ywlx) 业务类型,a.djh 单据号 from yk_dj a  where  shbz=0 and id in(select djid from yk_djmx where a.ywlx not in('001','002') and cjid in(" + Sscjid + "))  union all " +
                "select dbo.fun_getdeptname(a.deptid) 部门,dbo.fun_yF_ywlx(a.ywlx) 业务类型,a.djh 单据号 from yf_dj a where shbz=0  and id in(select djid from yf_djmx where a.ywlx not in('001','002') and cjid in(" + Sscjid + "))";
                DataTable tb_zt = MB_DB.GetDataTable(ssql);
                string zt_msg="";
                for(int i=0;i<=tb_zt.Rows.Count-1;i++)
                    zt_msg=zt_msg+tb_zt.Rows[i]["部门"].ToString()+"有[在途单据] 业务类型:"+tb_zt.Rows[i]["业务类型"].ToString()+" 单据号:"+tb_zt.Rows[i]["单据号"].ToString()+"\n";

                if (zt_msg != "") throw new Exception(zt_msg);
                //执行调价单
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@djID";
                parameters[0].Value = ts.Yzj;

                parameters[1].Text = "@deptid";
                parameters[1].Value = ts.Czks;

                parameters[2].Text = "@sdjh";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 20;

                parameters[3].Text = "@err_code";
                parameters[3].ParaDirection = ParameterDirection.Output;
                parameters[3].DataType = System.Data.DbType.Int32;
                parameters[3].ParaSize = 100;

                parameters[4].Text = "@err_text";
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[4].ParaSize = 100;

                parameters[5].Text = "@jgbm";
                parameters[5].Value = ts.MbjgbM;


                MB_DB.DoCommand("SP_YK_TJ_EXEC", parameters, 30);
                string  sdjh = Convert.ToString(parameters[2].Value);
                int err_code = Convert.ToInt32(parameters[3].Value);
                string err_text = Convert.ToString(parameters[4].Value);

                if (err_code != 0) throw new Exception(err_text);


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
