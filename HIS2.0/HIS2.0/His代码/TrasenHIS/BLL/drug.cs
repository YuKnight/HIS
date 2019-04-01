using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenHIS.BLL;
using TrasenFrame.Classes;

namespace TrasenHIS.BLL
{
    public class drug
    {
        /// <summary>
        /// 同步批号
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string SaveKcph(DataSet dset, RelationalDatabase db)
        {
            try
            {
                DataTable tb = dset.Tables[0];
                string ssql = "";

                List<System.String[]> listUpdate = new List<System.String[]>();
                List<System.String[]> listInsert = new List<System.String[]>();
                for (int nrow = 0; nrow <= tb.Rows.Count - 1; nrow++)
                {
                    #region 变量
                    DataRow row = tb.Rows[nrow];
                    ParameterEx[] parameters = new ParameterEx[13];
                    string _sdeptid = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, Convertor.IsNull(row["deptid"], ""), db);
                    if (_sdeptid == "") throw new Exception("没有找到科室匹配信息");
                    parameters[0].Text = "yfh";
                    parameters[0].DataType = System.Data.DbType.String;
                    parameters[0].Value = _sdeptid ;
                    string yppc = _sdeptid.ToString()+row["cjid"].ToString();
                   // yppm=left('0000000000',
                    string temp = "0000000000";
                    int N = yppc.Length;
                    if (N<10)
                         yppc= temp.Substring(0, 10 -N) + yppc;
                    yppc = "10" + yppc;
                    parameters[1].Text = "yppc";
                    parameters[1].DataType = System.Data.DbType.String;
                    parameters[1].Value = yppc;
                    string cjid = row["cjid"].ToString();
                    parameters[2].Text = "ypbm";
                    parameters[2].Value = row["cjid"];
                    parameters[3].Text = "ypmc";
                    parameters[3].DataType = System.Data.DbType.String;
                    parameters[3].Value = row["s_yppm"].ToString().Replace("'", "");
                    parameters[4].Text = "czgg";
                    parameters[4].DataType = System.Data.DbType.String;
                    parameters[4].Value = row["s_ypgg"].ToString().Replace("'","");
                    parameters[5].Text = "dw";
                    parameters[5].DataType = System.Data.DbType.String;
                    parameters[5].Value = Convertor.IsNull(row["s_zxdw"], ""); 
                    parameters[6].Text = "cjbm";
                    parameters[6].Value = row["sccj"].ToString();
                    parameters[7].Text = "grdj";
                    parameters[7].Value = row["grdj"].ToString();
                    parameters[8].Text = "pfj";
                    parameters[8].Value = row["pfj"].ToString();
                    parameters[9].Text = "lsj";
                    parameters[9].Value = row["lsj"].ToString();
                    parameters[10].Text = "ccrq";
                    parameters[10].DataType = System.Data.DbType.String;
                    parameters[10].Value = Convert.ToDateTime(row["djsj"]).ToString("yyyy-MM-dd HH:mm:ss");
                    parameters[11].Text = "sxrq";
                    parameters[11].DataType = System.Data.DbType.String;
                    parameters[11].Value = Convert.ToDateTime(row["ypxq"]).ToString("yyyy-MM-dd HH:mm:ss");
                    parameters[12].Text = "sl";
                    parameters[12].Value = Convertor.IsNull(row["kcl"], "");

                    #endregion

                    #region 插入语句
                    ssql = "insert into yk_kcb(";
                    for (int i = 0; i <= parameters.Length - 1; i++)
                        ssql = ssql + parameters[i].Text + ",";
                    ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                    ssql = ssql + "values(";
                    for (int i = 0; i <= parameters.Length - 1; i++)
                    {
                        if (parameters[i].DataType != null)
                            ssql = ssql + "'" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString()) + "',";//TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString())
                        else
                            ssql = ssql + parameters[i].Value + ",";
                    }
                    ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                    //用于记录生成的SQL语句，医嘱主键，操作类型。。在一面的事务中一次性处理
                    System.String[] str_insert = { row["id"].ToString(),_sdeptid,yppc,cjid, ssql, "add" };
                    listInsert.Add(str_insert);
                    #endregion

                    #region 更新语句
                    ssql = "update yk_kcb set ";
                    for (int i = 0; i <= parameters.Length - 1; i++)
                    {
                        if (parameters[i].DataType != null)
                            ssql = ssql + " "+parameters[i].Text+"= '" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString()) + "',";//TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString())
                        else
                            ssql =ssql + " "+parameters[i].Text+"= "+ parameters[i].Value + ",";
                    }
                    ssql = ssql.Substring(0, ssql.Length - 1) + "";
                    ssql=ssql+" where yfh='" + _sdeptid + "' and yppc='"+yppc+"' and ypbm="+cjid+"";
                    //用于记录生成的SQL语句，医嘱主键，操作类型。。在一面的事务中一次性处理
                    System.String[] str_update = { row["id"].ToString(), _sdeptid, yppc, cjid, ssql, "update" };
                    listUpdate.Add(str_update);
                    #endregion
                }

                #region 老HIS事务处理
                System.Data.Odbc.OdbcConnection connection = new System.Data.Odbc.OdbcConnection(DAL.BaseDal.oldhis_constr);
                System.Data.Odbc.OdbcTransaction tx = null;
                System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand();
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    tx = connection.BeginTransaction();
                    cmd.Transaction = tx;

                    for (int i = 0; i <= listInsert.Count - 1; i++)
                    {
                        //插入和更新老HIS
                        ssql = "select * from yk_kcb where yfh='" + listInsert[i][1].ToString() + "' and yppc='"+listInsert[i][2].ToString()+"' and ypbm="+listInsert[i][3].ToString()+"";
                        cmd.CommandText = ssql;
                        object o= cmd.ExecuteScalar();
                        if (o!=null)
                            cmd.CommandText = listUpdate[i][4];
                        else
                            cmd.CommandText = listInsert[i][4];
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                    cmd.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //事务回滚
                    tx.Rollback();
                    cmd.Dispose();
                    connection.Close();
                    tx.Dispose();
                    throw new Exception(ex.Message);
                }

                #endregion

                #region 回填新HIS记录
                for (int nrow = 0; nrow <= tb.Rows.Count - 1; nrow++)
                {
                    ssql = "update EVENTLOG set FINISH=1 ,FINISH_DATE='"+DateTime.Now.ToString()+"' where EVENT='KCBH' AND BIZID='"+tb.Rows[nrow]["ID"].ToString()+"'";
                    db.DoCommand(ssql);
                }
                #endregion

                System.String[] str = { "0", "保存成功" };
                return HisFunctions.GetResponseString("SaveKcph", str);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 发药状态更新到老HIS  住院状态
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string SaveFyzt(DataSet dset, RelationalDatabase db)
        {
            try
            {
                DataTable tb = dset.Tables[0];
                string ssql = "";
                DataRow row = tb.Rows[0];
                string BIZID = row["BIZID"].ToString();
                string FY_DATE = Convert.ToDateTime(row["FY_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                string FY_USER = row["FY_USER"].ToString();
                string PY_USER = row["PY_USER"].ToString();
                string ZYH = row["ZYH"].ToString();
                string YZXH = row["YZXH"].ToString();
                string YZZXH = row["YZZXH"].ToString();
                decimal num = Convert.ToDecimal(row["NUM"].ToString());

                FY_USER = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, FY_USER, db);
                PY_USER = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, PY_USER, db);

                #region 老HIS事务处理
                System.Data.Odbc.OdbcConnection connection = new System.Data.Odbc.OdbcConnection(DAL.BaseDal.oldhis_constr);
                System.Data.Odbc.OdbcTransaction tx = null;
                System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand();
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    tx = connection.BeginTransaction();
                    cmd.Transaction = tx;

                    if (num > 0)
                    {
                        cmd.CommandText = "update zy_yzlxd set zjfysj='" + FY_DATE + "' where zyh='" + ZYH + "' and xh=" + YZXH + " and zxh=" + YZZXH + "";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "update zy_cqlsyzd set sffy='Y' where zyh='" + ZYH + "' and xh=" + YZXH + " and zxh=" + YZZXH + "";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "update zy_yzlxd set sfty='Y' where zyh='" + ZYH + "' and xh=" + YZXH + " and zxh=" + YZZXH + "";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "update zy_cqlsyzd set sfty='Y' where zyh='" + ZYH + "' and xh=" + YZXH + " and zxh=" + YZZXH + "";
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                    cmd.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //事务回滚
                    tx.Rollback();
                    cmd.Dispose();
                    connection.Close();
                    tx.Dispose();
                    throw new Exception(ex.Message);
                }

                #endregion

                #region 回填新HIS记录
                for (int nrow = 0; nrow <= tb.Rows.Count - 1; nrow++)
                {
                    ssql = "update EVENTLOG set FINISH=1 ,FINISH_DATE='" + DateTime.Now.ToString() + "' where EVENT='FYZT' AND BIZID='" + BIZID + "'";
                    db.DoCommand(ssql);
                }
                #endregion

                System.String[] str = { "0", "保存成功" };
                return HisFunctions.GetResponseString("SaveKcph", str);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 发药状态更新到老HIS 门诊状态 
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string SaveMzFyzt(DataSet dset, RelationalDatabase db)
        {
            try
            {
                DataTable tb = dset.Tables[0];
                string ssql = "";
                DataRow row = tb.Rows[0];
                string BIZID = row["BIZID"].ToString();
                string FY_DATE = Convert.ToDateTime(row["FY_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                string FY_USER = row["FY_USER"].ToString();
                string PY_USER = row["PY_USER"].ToString();
                string DH = row["DH"].ToString();
                decimal ZJE = Convert.ToDecimal(row["zje"]);

                FY_USER = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, FY_USER, db);
                PY_USER = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, PY_USER, db);

                #region 老HIS事务处理
                System.Data.Odbc.OdbcConnection connection = new System.Data.Odbc.OdbcConnection(DAL.BaseDal.oldhis_constr);
                System.Data.Odbc.OdbcTransaction tx = null;
                System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand();
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    tx = connection.BeginTransaction();
                    cmd.Transaction = tx;

                    if (ZJE >= 0)
                    {
                        cmd.CommandText = "update MZ_CFD_ZB set sffy='Y',fyy='"+FY_USER+"', fysj='" + FY_DATE + "',pzr='"+PY_USER+"' where dh='" + DH + "'";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "update MZ_CFD_CB set sffy='Y',fyy='" + FY_USER + "'  where dh='" + DH + "'";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "update MZ_CFD_ZB set sfty='Y',qrty='" + FY_USER + "',tyr='" + FY_USER + "', tyrq='" + FY_DATE + "'  where dh='" + DH + "'";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "update MZ_CFD_CB set sfty='Y',qrty='" + FY_USER + "',tyr='" + FY_USER + "'  where dh='" + DH + "'";
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                    cmd.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //事务回滚
                    tx.Rollback();
                    cmd.Dispose();
                    connection.Close();
                    tx.Dispose();
                    throw new Exception(ex.Message);
                }

                #endregion

                #region 回填新HIS记录
                if (ZJE>0)
                    ssql = "update EVENTLOG set FINISH=1 ,FINISH_DATE='" + DateTime.Now.ToString() + "' where EVENT='MZFYZT' AND BIZID='" + BIZID + "'";
                else
                    ssql = "update EVENTLOG set FINISH=1 ,FINISH_DATE='" + DateTime.Now.ToString() + "' where EVENT='MZFYZTTY' AND BIZID='" + BIZID + "'";
                db.DoCommand(ssql);

                #endregion

                System.String[] str = { "0", "保存成功" };
                return HisFunctions.GetResponseString("SaveKcph", str);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        
        /// <summary>
        /// 取消门诊发药状态
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string SaveMzQxFyzt(DataSet dset, RelationalDatabase db)
        {
            try
            {
                DataTable tb = dset.Tables[0];
                string ssql = "";
                DataRow row = tb.Rows[0];
                string BIZID = row["BIZID"].ToString();
                string DH = row["DH"].ToString();

                #region 老HIS事务处理
                System.Data.Odbc.OdbcConnection connection = new System.Data.Odbc.OdbcConnection(DAL.BaseDal.oldhis_constr);
                System.Data.Odbc.OdbcTransaction tx = null;
                System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand();
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    tx = connection.BeginTransaction();
                    cmd.Transaction = tx;

                    cmd.CommandText = "update MZ_CFD_ZB set sfty='N',qrty='',tyr='', tyrq=null  where dh='" + DH + "' and sftf='N'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update MZ_CFD_CB set sfty='N',qrty='',tyr=''  where dh='" + DH + "'";
                    cmd.ExecuteNonQuery();

                    tx.Commit();
                    cmd.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //事务回滚
                    tx.Rollback();
                    cmd.Dispose();
                    connection.Close();
                    tx.Dispose();
                    throw new Exception(ex.Message);
                }

                #endregion

                #region 回填新HIS记录
                for (int nrow = 0; nrow <= tb.Rows.Count - 1; nrow++)
                {
                    ssql = "update EVENTLOG set FINISH=1 ,FINISH_DATE='" + DateTime.Now.ToString() + "' where EVENT='MZQXFYZT' AND BIZID='" + BIZID + "'";
                    db.DoCommand(ssql);
                }
                #endregion

                System.String[] str = { "0", "保存成功" };
                return HisFunctions.GetResponseString("SaveKcph", str);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
