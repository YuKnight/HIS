using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenHIS.BLL;
using TrasenFrame.Classes;
using TszyHIS;




namespace TrasenHIS.BLL
{
    class orders
    {
        public static string SaveOrder(DataSet dset, RelationalDatabase newdb)
        {
            //TrasenFrame.Forms.FrmMdiMain.Database = newdb;
            TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgmc = "";
            try
            {
                DataTable tb = dset.Tables[0];
                string ssql = "";

                List<System.String[]> listUpdate = new List<System.String[]>();
                List<System.String[]> listInsert = new List<System.String[]>();
                List<ParameterEx[]> listParameter = new List<ParameterEx[]>();

                for (int nrow = 0; nrow <= tb.Rows.Count - 1; nrow++)
                {
                    #region 变量
                    DataRow row = tb.Rows[nrow];

                    //说明医嘱跳过
                    if (row["ntype"].ToString() == "7")
                        continue;

                    //如果是草药，跳过
                    if (row["ntype"].ToString() == "3")
                        continue;

                    decimal dj = 0;
                    string dw = "";
                    decimal jl = 0;
                    decimal mrcs = Convert.ToDecimal(HisFunctions.GetPLCS(Convertor.IsNull(row["FREQUENCY"], ""), newdb));
                    decimal hj = 0;//合计金额

                    //如果不是说明医嘱
                    if (row["ntype"].ToString() != "7")
                    {
                        if (row["xmly"].ToString() == "1")
                        {
                            DataTable ypTb = HisFunctions.SP_FUN_DW_NUM(row["dwlx"].ToString(), Convert.ToDecimal(row["num"]), row["hoitem_id"].ToString(), row["exec_dept"].ToString(), newdb);
                            if (ypTb == null || ypTb.Rows.Count == 0)
                            {
                                throw new Exception("未找到该药品的信息！");
                            }
                            dj = Convert.ToDecimal(ypTb.Rows[0]["PRICE"]);
                            dw = Convertor.IsNull(ypTb.Rows[0]["UNIT"], "").ToLower();
                            jl = Convert.ToDecimal(Convertor.IsNull(ypTb.Rows[0]["YL"], "0"));

                            hj = dj * jl * mrcs * Convert.ToDecimal(Convertor.IsNull(row["dosage"], "0"));
                        }
                        else
                        {
                            dj = HisFunctions.GetNewHISPrice(row["xmly"].ToString(), row["hoitem_id"].ToString(), newdb);
                            dw = Convertor.IsNull(row["unit"], "").ToLower();
                            jl = Convert.ToDecimal(Convertor.IsNull(row["num"], "0"));

                            hj = dj * jl * mrcs;
                        }
                    }


                    ParameterEx[] parameters = new ParameterEx[27];
                    parameters[0].Text = "zyh";
                    parameters[0].Value = Convert.ToInt64(row["inpatient_no"]).ToString();

                    parameters[1].Text = "xh";
                    parameters[1].Value = Convert.ToInt32(row["group_id"]);

                    parameters[2].Text = "zxh";
                    parameters[2].Value = Convert.ToInt32(row["SERIAL_NO"]) + 1;

                    parameters[3].Text = "yzfl";////P：长期医嘱T：临时医嘱C：冲减医嘱B：病室治疗M：麻醉医嘱O：出院带药S：手术医嘱V：手术冲减W：麻醉冲减
                    parameters[3].DataType = System.Data.DbType.String;
                    parameters[3].Value = row["mngtype"].ToString() == "0" ? "P" : "T";

                    parameters[4].Text = "yzlb";
                    parameters[4].DataType = System.Data.DbType.String;
                    parameters[4].Value = Convert.ToInt32(row["SERIAL_NO"]) == 0 ? HisFunctions.GetOldHISYzlb(row["ntype"].ToString(), Convertor.IsNull(row["order_context"], "")) : "";//Z：中药M：西药X：项目O：其它0：未知5：会诊7：转科医嘱8：手术申请单9：出院

                    parameters[5].Text = "yz";
                    parameters[5].DataType = System.Data.DbType.String;
                    parameters[5].Value = Convertor.IsNull(row["order_context"], "");//医嘱内容

                    string bm = HisFunctions.GetOldHISXmYpBM(row["xmly"].ToString(), row["hoitem_id"].ToString(), newdb);
                    parameters[6].Text = "bm";
                    parameters[6].DataType = System.Data.DbType.String;
                    parameters[6].Value = bm;//药品项目编码

                    parameters[7].Text = "dw";
                    parameters[7].DataType = System.Data.DbType.String;
                    parameters[7].Value = dw;//单位

                    parameters[8].Text = "gg";
                    parameters[8].DataType = System.Data.DbType.String;
                    parameters[8].Value = Convertor.IsNull(row["order_spec"], "");//规格

                    parameters[9].Text = "jl";
                    parameters[9].Value = jl;//每日剂量

                    parameters[10].Text = "gyfs";
                    parameters[10].DataType = System.Data.DbType.String;
                    parameters[10].Value = Convertor.IsNull(row["order_usage"], "");//给药方式

                    parameters[11].Text = "pl";
                    parameters[11].DataType = System.Data.DbType.String;
                    parameters[11].Value = Convertor.IsNull(row["FREQUENCY"], "").ToLower();//频次

                    /*还未完善，需要补充完善逻辑**/
                    decimal zfje = hj;//自费金额
                    decimal gfje = 0;//公费金额
                    //Judgeorder jo = new Judgeorder(newdb);
                    //ReturnInfo rInfo = jo.GetBl(row["inpatient_no"].ToString(), row["xmly"].ToString(), row["hoitem_id"].ToString());
                    decimal zfbl = Convert.ToDecimal(Convertor.IsNull(row["zfbl"], "1"));
                    //if (rInfo.ReturnCode >= 0)
                    if (zfbl < 1)
                    {
                        zfje = zfbl * hj;//Convert.ToDecimal(rInfo.ReturnValue) * hj;
                        gfje = hj - zfje;
                    }
                    else
                    {
                        zfje = hj;
                        gfje = 0;
                        //throw new Exception(rInfo.ReurnShowInfo);
                    }

                    parameters[12].Text = "zfje";
                    parameters[12].Value = zfje;//自费金额

                    parameters[13].Text = "gfje";
                    parameters[13].Value = gfje;//公费金额

                    parameters[14].Text = "hj";
                    parameters[14].Value = hj;//合计金额
                    /***/

                    parameters[15].Text = "rq";
                    parameters[15].DataType = System.Data.DbType.String;
                    parameters[15].Value = Convert.ToDateTime(Convertor.IsNull(row["book_date"], "")).ToString("yyyy-MM-dd HH:mm:ss");//录入日期

                    //string tzrq = null;//停止日期
                    //string tzhs = "";//停止护士
                    //string tzys = "";//停止医生

                    parameters[16].Text = "hdbz";
                    parameters[16].DataType = System.Data.DbType.String;
                    parameters[16].Value = "N";//Y：已经审核 N：未审核

                    parameters[17].Text = "czy";
                    parameters[17].DataType = System.Data.DbType.String;
                    parameters[17].Value = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, Convertor.IsNull(row["OPERATOR"], ""), newdb);//操作员

                    parameters[18].Text = "ksrq";
                    parameters[18].DataType = System.Data.DbType.String;
                    parameters[18].Value = Convert.ToDateTime(Convertor.IsNull(row["ORDER_BDATE"], "")).ToString("yyyy-MM-dd HH:mm:ss");// Convertor.IsNull(row["ORDER_BDATE"], "");//开始日期

                    //string kshs = "";//开始护士

                    parameters[19].Text = "ksys";
                    parameters[19].DataType = System.Data.DbType.String;
                    parameters[19].Value = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, Convertor.IsNull(row["ORDER_DOC"], ""), newdb);//开始医师

                    //string shr = "";//录入审核人
                    //string sfsc = "";//是否删除

                    parameters[20].Text = "sfzx";
                    parameters[20].DataType = System.Data.DbType.String;
                    parameters[20].Value = "N";//是否执行完成 Y：已经执行完成 N：未执行完成。当已经执行完成（即已经记完帐，对长期医嘱而言，已经停嘱，并记帐完成，成为历史医嘱）时，打“Y”标志

                    /***/
                    parameters[21].Text = "dj";
                    parameters[21].Value = dj;//单价
                    /***/

                    parameters[22].Text = "mrcs";
                    parameters[22].Value = mrcs;//每日次数

                    parameters[23].Text = "bz";
                    parameters[23].DataType = System.Data.DbType.String;
                    parameters[23].Value = Convert.ToInt32(row["SERIAL_NO"]) == 0 ? HisFunctions.GetOldHISYzlbmc(row["ntype"].ToString(), Convertor.IsNull(row["order_context"], "")) : "";//Z：中药M：西药X：项目O：其它0：未知5：会诊7：转科医嘱8：手术申请单9：出院

                    //是否删除
                    parameters[24].Text = "sfsc";
                    parameters[24].DataType = System.Data.DbType.String;
                    parameters[24].Value = "N";

                    //是否删除
                    parameters[25].Text = "bcbz";
                    parameters[25].DataType = System.Data.DbType.String;
                    parameters[25].Value = "Y";

                    //是否冲减
                    parameters[26].Text = "sfcj";
                    parameters[26].DataType = System.Data.DbType.String;
                    parameters[26].Value = "N";

                    //string ypgfpzr = "";//药品公费批准人
                    //string shrq = null;//审核日期
                    //string tjrq = null;//提交日期
                    //string yzxh_cis = "";//CIS医嘱序号

                    listParameter.Add(parameters);
                    #endregion

                    #region 插入语句
                    ssql = "insert into ZY_CQLSYZD(";
                    for (int i = 0; i <= parameters.Length - 1; i++)
                        ssql = ssql + parameters[i].Text + ",";
                    ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                    ssql = ssql + " values (";
                    for (int i = 0; i <= parameters.Length - 1; i++)
                    {
                        if (parameters[i].DataType != null)
                            ssql = ssql + "'" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString()) + "',";//TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString())
                        else
                            ssql = ssql + parameters[i].Value + ",";
                    }
                    ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                    //用于记录生成的SQL语句，医嘱主键，操作类型。。在一面的事务中一次性处理
                    System.String[] str_insert = { row["order_id"].ToString(), ssql, "add" };
                    listInsert.Add(str_insert);
                    #endregion

                    #region 更新语句
                    ssql = "update ZY_CQLSYZD set ";
                    for (int i = 0; i <= parameters.Length - 1; i++)
                    {
                        if (parameters[i].DataType != null)
                            ssql = ssql + " " + parameters[i].Text + "= '" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString()) + "',";//TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString())
                        else
                            ssql = ssql + " " + parameters[i].Text + "= " + parameters[i].Value + ",";
                    }
                    ssql = ssql.Substring(0, ssql.Length - 1) + "";
                    ssql = ssql + " where order_id='" + row["order_id"].ToString() + "'";
                    //用于记录生成的SQL语句，医嘱主键，操作类型。。在一面的事务中一次性处理
                    System.String[] str_update = { row["order_id"].ToString(), ssql, "update" };
                    listUpdate.Add(str_update);
                    #endregion
                }

                #region 事务处理
                System.Data.Odbc.OdbcConnection connection = new System.Data.Odbc.OdbcConnection(DAL.BaseDal.oldhis_constr);
                System.Data.Odbc.OdbcTransaction tx = null;
                System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand();
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    tx = connection.BeginTransaction();
                    cmd.Transaction = tx;
                    System.Data.Odbc.OdbcDataAdapter adapter = new System.Data.Odbc.OdbcDataAdapter();

                    DataTable dt = new DataTable();

                    for (int i = 0; i < listInsert.Count; i++)
                    {
                        //插入时，查询对方是否存在，如果在。。回填我们的事件表，成功
                        ssql = "select * from zy_cqlsyzd where zyh='" + listParameter[i][0].Value.ToString() + "' and xh=" + listParameter[i][1].Value.ToString() + " and zxh=" + listParameter[i][2].Value.ToString();
                        try
                        {
                            cmd.CommandText = ssql;
                            adapter.SelectCommand = cmd;
                            adapter.Fill(dt);
                        }
                        catch (Exception err)
                        {
                            throw new Exception(err.Message);
                        }

                        if (dt == null || dt.Rows.Count == 0)
                        {
                            cmd.CommandText = listInsert[i][1].ToString();
                            int ii = cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            //向zy_cqlsyzd_newhis保存对应关系

                            //回填HIS事件表
                        }
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
                    throw new Exception(ex.Message);
                }

                #endregion


                System.String[] str = { "0", "保存成功" };
                return HisFunctions.GetResponseString("SaveOrder", str);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

        /// <summary>
        /// 保存中草药处方
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="newdb"></param>
        /// <returns></returns>
        public static string SaveZCYCF(DataSet dset, RelationalDatabase newdb)
        {
            //TrasenFrame.Forms.FrmMdiMain.Database = newdb;
            TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgmc = "";
            try
            {
                DataTable tb = dset.Tables[0];
                string ssql = "";

                //List<System.String[]> listUpdate = new List<System.String[]>();
                //List<System.String[]> listInsert = new List<System.String[]>();
                List<ParameterEx[]> listParameter = new List<ParameterEx[]>();

                //草药处方明细
                for (int nrow = 0; nrow <= tb.Rows.Count - 1; nrow++)
                {
                    #region 变量
                    DataRow row = tb.Rows[nrow];

                    //说明医嘱跳过
                    if (row["ntype"].ToString() == "7")
                        continue;

                    decimal dj = 0;
                    string dw = "";
                    decimal jl = 0;
                    decimal mrcs = Convert.ToDecimal(HisFunctions.GetPLCS(Convertor.IsNull(row["FREQUENCY"], ""), newdb));
                    decimal hj = 0;//合计金额

                    //如果不是说明医嘱
                    if (row["ntype"].ToString() != "7")
                    {
                        if (row["xmly"].ToString() == "1")
                        {
                            DataTable ypTb = HisFunctions.SP_FUN_DW_NUM(row["dwlx"].ToString(), Convert.ToDecimal(row["num"]), row["hoitem_id"].ToString(), row["exec_dept"].ToString(), newdb);
                            if (ypTb == null || ypTb.Rows.Count == 0)
                            {
                                throw new Exception("未找到该药品的信息！");
                            }
                            dj = Convert.ToDecimal(ypTb.Rows[0]["PRICE"]);
                            dw = Convertor.IsNull(ypTb.Rows[0]["UNIT"], "").ToLower();
                            jl = Convert.ToDecimal(Convertor.IsNull(ypTb.Rows[0]["YL"], "0"));

                            hj = dj * jl * mrcs * Convert.ToDecimal(Convertor.IsNull(row["dosage"], "0"));
                        }
                        else
                        {
                            dj = HisFunctions.GetNewHISPrice(row["xmly"].ToString(), row["hoitem_id"].ToString(), newdb);
                            dw = Convertor.IsNull(row["unit"], "").ToLower();
                            jl = Convert.ToDecimal(Convertor.IsNull(row["num"], "0"));

                            hj = dj * jl * mrcs;
                        }
                    }

                    //dh,ypbm,ypmc,gg,dw,sl,gfje,zfje,sffy(N),sfty(N),sfhj(Y),je,xh,cs,tysl
                    ParameterEx[] parameters = new ParameterEx[16];
                    parameters[0].Text = "dh";
                    parameters[0].DataType = System.Data.DbType.String;
                    parameters[0].Value = "";//单号到后面执行的时候统一更新

                    string bm = HisFunctions.GetOldHISXmYpBM(row["xmly"].ToString(), row["hoitem_id"].ToString(), newdb);
                    parameters[1].Text = "ypbm";
                    parameters[1].DataType = System.Data.DbType.String;
                    parameters[1].Value = bm;//药品项目编码

                    parameters[2].Text = "ypmc";
                    parameters[2].DataType = System.Data.DbType.String;
                    parameters[2].Value = Convertor.IsNull(row["order_context"], "");//医嘱内容

                    parameters[3].Text = "gg";
                    parameters[3].DataType = System.Data.DbType.String;
                    parameters[3].Value = Convertor.IsNull(row["order_spec"], "");//规格

                    parameters[4].Text = "dw";
                    parameters[4].DataType = System.Data.DbType.String;
                    parameters[4].Value = dw;//单位

                    parameters[5].Text = "sl";
                    parameters[5].Value = jl;//每日剂量

                    /***/
                    decimal zfje = hj;//自费金额
                    decimal gfje = 0;//公费金额
                    //Judgeorder jo = new Judgeorder(newdb);
                    //ReturnInfo rInfo = jo.GetBl(row["inpatient_no"].ToString(), row["xmly"].ToString(), row["hoitem_id"].ToString());
                    decimal zfbl = Convert.ToDecimal(Convertor.IsNull(row["zfbl"], "1"));
                    //if (rInfo.ReturnCode >= 0)
                    if (zfbl < 1)
                    {
                        zfje = zfbl * hj;//Convert.ToDecimal(rInfo.ReturnValue) * hj;
                        gfje = hj - zfje;
                    }
                    else
                    {
                        zfje = hj;
                        gfje = 0;
                        //throw new Exception(rInfo.ReurnShowInfo);
                    }

                    parameters[6].Text = "gfje";
                    parameters[6].Value = gfje;//公费金额

                    parameters[7].Text = "zfje";
                    parameters[7].Value = zfje;//自费金额
                    /***/

                    parameters[8].Text = "sffy";
                    parameters[8].DataType = System.Data.DbType.String;
                    parameters[8].Value = "N";

                    parameters[9].Text = "sfty";
                    parameters[9].DataType = System.Data.DbType.String;
                    parameters[9].Value = "N";

                    parameters[10].Text = "sfhj";
                    parameters[10].DataType = System.Data.DbType.String;
                    parameters[10].Value = "Y";

                    parameters[11].Text = "je";
                    parameters[11].Value = hj;//合计金额

                    parameters[12].Text = "xh";
                    parameters[12].Value = Convert.ToInt32(row["SERIAL_NO"]) + 1;

                    parameters[13].Text = "cs";
                    parameters[13].Value = Convert.ToDecimal(Convertor.IsNull(row["dosage"], "1"));

                    parameters[14].Text = "tysl";
                    parameters[14].Value = Convert.ToDecimal(Convertor.IsNull(row["dosage"], "1")) * jl;

                    parameters[15].Text = "bz";
                    parameters[15].DataType = System.Data.DbType.String;
                    parameters[15].Value = row["order_id"].ToString();
                    /*****/

                    listParameter.Add(parameters);
                    #endregion
                }

                #region 事务处理
                System.Data.Odbc.OdbcConnection connection = new System.Data.Odbc.OdbcConnection(DAL.BaseDal.oldhis_constr);
                System.Data.Odbc.OdbcTransaction tx = null;
                System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand();
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    tx = connection.BeginTransaction();
                    cmd.Transaction = tx;
                    System.Data.Odbc.OdbcDataAdapter adapter = new System.Data.Odbc.OdbcDataAdapter();

                    //获取最新的dh
                    DataTable dt = new DataTable();
                    string czy = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, Convertor.IsNull(tb.Rows[0]["OPERATOR"], ""), newdb);//操作员
                    if (czy == "")
                    {
                        throw new Exception("未找到老HIS系统中该操作员");
                    }
                    string dh = czy.Substring(czy.Length - 4, 4) + "0000000001";
                    //插入时，查询对方是否存在，如果在。。回填我们的事件表，成功
                    ssql = "SELECT czy,dh FROM mz_curr_dh Where czy = '" + czy + "' AND lb = 'cfdh'";
                    try
                    {
                        cmd.CommandText = ssql;
                        adapter.SelectCommand = cmd;
                        adapter.Fill(dt);
                    }
                    catch (Exception err)
                    {
                        throw new Exception(err.Message);
                    }

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        ssql = "INSERT INTO mz_curr_dh(czy,dh,lb) Values ('" + czy + "','" + dh + "','cfdh')";
                    }
                    else
                    {
                        dh = czy.Substring(czy.Length - 4, 4) + (Convert.ToInt64(dt.Rows[0]["dh"].ToString().Substring(dt.Rows[0]["dh"].ToString().Length - 10, 10)) + 1).ToString("0000000000");
                        ssql = "UPDATE mz_curr_dh Set dh = '" + dh + "' Where czy = '" + czy + "' AND lb = 'cfdh'";
                    }
                    cmd.CommandText = ssql;
                    cmd.ExecuteNonQuery();

                    decimal hj_gfje = 0;
                    decimal hj_zfje = 0;
                    decimal hj_je = 0;
                    //插入明细表
                    for (int i = 0; i < listParameter.Count; i++)
                    {
                        hj_gfje += Convert.ToDecimal(listParameter[i][6].Value);
                        hj_zfje += Convert.ToDecimal(listParameter[i][7].Value);
                        hj_je += Convert.ToDecimal(listParameter[i][11].Value);

                        listParameter[i][0].Value = dh;
                        #region 插入语句
                        ssql = "insert into zy_cfd_cb(";
                        for (int j = 0; j <= listParameter[i].Length - 1; j++)
                            ssql = ssql + listParameter[i][j].Text + ",";
                        ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                        ssql = ssql + " values (";
                        for (int j = 0; j <= listParameter[i].Length - 1; j++)
                        {
                            if (listParameter[i][j].DataType != null)
                                ssql = ssql + "'" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(listParameter[i][j].Value.ToString()) + "',";//TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString())
                            else
                                ssql = ssql + listParameter[i][j].Value + ",";
                        }
                        ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                        //用于记录生成的SQL语句，医嘱主键，操作类型。。在一面的事务中一次性处理
                        //System.String[] str_insert = { "", ssql, "add" };
                        //listInsert.Add(str_insert);
                        #endregion

                        cmd.CommandText = ssql;
                        cmd.ExecuteNonQuery();
                    }

                    //插入主表
                    //dh,kjks,kjys,czy,kjsj,zyh,sfhj(Y),sfsf(N),sffy(N),cflb,gfje,zfje,sfty(N),je,sftf(N),fs,sfsh(N)
                    ssql = "insert into zy_cfd_zb(dh,kjks,kjys,czy,kjsj,zyh,sfhj,sfsf,sffy,cflb,gfje,zfje,sfty,je,sftf,fs,sfsh) values (";
                    ssql += "'" + dh + "','" + HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, Convertor.IsNull(tb.Rows[0]["dept_id"], ""), newdb) + "',";
                    ssql += "'" + HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, Convertor.IsNull(tb.Rows[0]["ORDER_DOC"], ""), newdb) + "',";
                    ssql += "'" + czy + "','" + Convert.ToDateTime(Convertor.IsNull(tb.Rows[0]["book_date"], "")).ToString("yyyy-MM-dd HH:mm:ss") + "',";
                    ssql += "'" + Convert.ToInt64(tb.Rows[0]["inpatient_no"]).ToString() + "','Y','N','N','" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix("草药") + "',";
                    ssql += "" + hj_gfje + "," + hj_zfje + ",'N'," + hj_je + ",'N'," + Convertor.IsNull(tb.Rows[0]["dosage"], "1") + ",'N')";

                    cmd.CommandText = ssql;
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
                    throw new Exception(ex.Message);
                }

                #endregion


                System.String[] str = { "0", "保存成功" };
                return HisFunctions.GetResponseString("SaveOrder", str);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

        /// <summary>
        /// 停止医嘱
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="newdb"></param>
        /// <returns></returns>
        public static string StopOrder(DataSet dset, RelationalDatabase newdb)
        {
            //TrasenFrame.Forms.FrmMdiMain.Database = newdb;
            TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgmc = "";
            try
            {
                DataTable tb = dset.Tables[0];
                string ssql = "";

                List<System.String[]> listUpdate = new List<System.String[]>();
                List<System.String[]> listInsert = new List<System.String[]>();
                List<ParameterEx[]> listParameter = new List<ParameterEx[]>();

                for (int nrow = 0; nrow <= tb.Rows.Count - 1; nrow++)
                {
                    #region 变量
                    DataRow row = tb.Rows[nrow];

                    //如果是草药，跳过
                    if (row["ntype"].ToString() == "3")
                        continue;

                    ParameterEx[] parameters = new ParameterEx[5];
                    parameters[0].Text = "zyh";
                    parameters[0].Value = Convert.ToInt64(row["inpatient_no"]).ToString();

                    parameters[1].Text = "xh";
                    parameters[1].Value = Convert.ToInt32(row["group_id"]);

                    parameters[2].Text = "zxh";
                    parameters[2].Value = Convert.ToInt32(row["SERIAL_NO"]) + 1;

                    //string tzrq = null;//停止日期
                    //string tzhs = "";//停止护士
                    //string tzys = "";//停止医生

                    parameters[3].Text = "tzrq";
                    parameters[3].DataType = System.Data.DbType.String;
                    parameters[3].Value = Convert.ToDateTime(Convertor.IsNull(row["order_edate"], DateTime.Now.ToLongDateString())).ToString("yyyy-MM-dd HH:mm:ss");//停止日期

                    parameters[4].Text = "tzys";
                    parameters[4].DataType = System.Data.DbType.String;
                    parameters[4].Value = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, Convertor.IsNull(row["order_edoc"], "0"), newdb);//停止医生
                    //string tzrq = null;//停止日期
                    //string tzhs = "";//停止护士
                    //string tzys = "";//停止医生


                    listParameter.Add(parameters);
                    #endregion

                    #region 插入语句
                    ssql = "insert into ZY_CQLSYZD(";
                    for (int i = 0; i <= parameters.Length - 1; i++)
                        ssql = ssql + parameters[i].Text + ",";
                    ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                    ssql = ssql + " values (";
                    for (int i = 0; i <= parameters.Length - 1; i++)
                    {
                        if (parameters[i].DataType != null)
                            ssql = ssql + "'" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString()) + "',";//TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString())
                        else
                            ssql = ssql + parameters[i].Value + ",";
                    }
                    ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                    //用于记录生成的SQL语句，医嘱主键，操作类型。。在一面的事务中一次性处理
                    System.String[] str_insert = { row["order_id"].ToString(), ssql, "add" };
                    listInsert.Add(str_insert);
                    #endregion

                    #region 更新语句
                    ssql = "update ZY_CQLSYZD set ";
                    for (int i = 3; i <= parameters.Length - 1; i++)
                    {
                        if (parameters[i].DataType != null)
                            ssql = ssql + " " + parameters[i].Text + "= '" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString()) + "',";//TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString())
                        else
                            ssql = ssql + " " + parameters[i].Text + "= " + parameters[i].Value + ",";
                    }
                    ssql = ssql.Substring(0, ssql.Length - 1) + "";
                    ssql = ssql + " where zyh='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[0].Value.ToString()) + "' and xh=" + parameters[1].Value;//Modify By Tany 2014-5-23 停就停一组 +" and zxh=" + parameters[2].Value;
                    //用于记录生成的SQL语句，医嘱主键，操作类型。。在一面的事务中一次性处理
                    System.String[] str_update = { row["order_id"].ToString(), ssql, "update" };
                    listUpdate.Add(str_update);

                    ssql = "update zy_yzhj set ";
                    ssql = ssql + " zzrq='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[3].Value.ToString()) + "' ";
                    ssql = ssql + " ,tzys='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[4].Value.ToString()) + "' ";
                    ssql = ssql + " where zyh='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[0].Value.ToString()) + "' and yzxh=" + parameters[1].Value;// +" and xmbm='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(HisFunctions.GetOldHISXmYpBM(row["xmly"].ToString(), row["hoitem_id"].ToString(), newdb)) + "'";

                    System.String[] str_update1 = { row["order_id"].ToString(), ssql, "update" };
                    listUpdate.Add(str_update1);

                    ssql = "update zy_yzlxd set ";
                    ssql = ssql + " zzsj='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[3].Value.ToString()) + "' ";
                    //ssql = ssql + " tzys='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[4].Value.ToString()) + "' ";
                    ssql = ssql + " where zyh='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[0].Value.ToString()) + "' and xh=" + parameters[1].Value;// +" and zxh=" + parameters[2].Value;

                    System.String[] str_update2 = { row["order_id"].ToString(), ssql, "update" };
                    listUpdate.Add(str_update2);

                    #endregion
                }

                #region 事务处理
                System.Data.Odbc.OdbcConnection connection = new System.Data.Odbc.OdbcConnection(DAL.BaseDal.oldhis_constr);
                System.Data.Odbc.OdbcTransaction tx = null;
                System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand();
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    tx = connection.BeginTransaction();
                    cmd.Transaction = tx;
                    System.Data.Odbc.OdbcDataAdapter adapter = new System.Data.Odbc.OdbcDataAdapter();

                    for (int i = 0; i < listUpdate.Count; i++)
                    {
                        cmd.CommandText = listUpdate[i][1].ToString();
                        int ii = cmd.ExecuteNonQuery();
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
                    throw new Exception(ex.Message);
                }

                #endregion


                System.String[] str = { "0", "保存成功" };
                return HisFunctions.GetResponseString("StopOrder", str);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

        /// <summary>
        /// 取消医嘱
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="newdb"></param>
        /// <returns></returns>
        public static string CancelOrder(DataSet dset, RelationalDatabase newdb)
        {
            //TrasenFrame.Forms.FrmMdiMain.Database = newdb;
            TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgmc = "";
            try
            {
                DataTable tb = dset.Tables[0];
                string ssql = "";

                //List<System.String[]> listUpdate = new List<System.String[]>();
                //List<System.String[]> listInsert = new List<System.String[]>();
                List<System.String[]> listDelete = new List<System.String[]>();
                List<System.String[]> listDelete1 = new List<System.String[]>();
                List<System.String[]> listDelete2 = new List<System.String[]>();
                List<ParameterEx[]> listParameter = new List<ParameterEx[]>();

                for (int nrow = 0; nrow <= tb.Rows.Count - 1; nrow++)
                {
                    #region 变量
                    DataRow row = tb.Rows[nrow];

                    //如果是草药，跳过
                    if (row["ntype"].ToString() == "3")
                        continue;

                    ParameterEx[] parameters = new ParameterEx[3];
                    parameters[0].Text = "zyh";
                    parameters[0].Value = Convert.ToInt64(row["inpatient_no"]).ToString();

                    parameters[1].Text = "xh";
                    parameters[1].Value = Convert.ToInt32(row["group_id"]);

                    parameters[2].Text = "zxh";
                    parameters[2].Value = Convert.ToInt32(row["SERIAL_NO"]) + 1;

                    //string tzrq = null;//停止日期
                    //string tzhs = "";//停止护士
                    //string tzys = "";//停止医生

                    //parameters[3].Text = "tzrq";
                    //parameters[3].DataType = System.Data.DbType.String;
                    //parameters[3].Value = Convert.ToDateTime(Convertor.IsNull(row["order_edate"], DateTime.Now.ToLongDateString())).ToString("yyyy-MM-dd HH:mm:ss");//停止日期

                    //parameters[4].Text = "tzys";
                    //parameters[4].DataType = System.Data.DbType.String;
                    //parameters[4].Value = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, Convertor.IsNull(row["order_edoc"], "0"), newdb);//停止医生
                    //string tzrq = null;//停止日期
                    //string tzhs = "";//停止护士
                    //string tzys = "";//停止医生


                    listParameter.Add(parameters);
                    #endregion

                    #region 插入语句
                    //ssql = "insert into ZY_CQLSYZD(";
                    //for (int i = 0; i <= parameters.Length - 1; i++)
                    //    ssql = ssql + parameters[i].Text + ",";
                    //ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                    //ssql = ssql + " values (";
                    //for (int i = 0; i <= parameters.Length - 1; i++)
                    //{
                    //    if (parameters[i].DataType != null)
                    //        ssql = ssql + "'" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString()) + "',";//TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString())
                    //    else
                    //        ssql = ssql + parameters[i].Value + ",";
                    //}
                    //ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                    ////用于记录生成的SQL语句，医嘱主键，操作类型。。在一面的事务中一次性处理
                    //System.String[] str_insert = { row["order_id"].ToString(), ssql, "add" };
                    //listInsert.Add(str_insert);
                    #endregion

                    #region 更新语句
                    //ssql = "update ZY_CQLSYZD set ";
                    //for (int i = 3; i <= parameters.Length - 1; i++)
                    //{
                    //    if (parameters[i].DataType != null)
                    //        ssql = ssql + " " + parameters[i].Text + "= '" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString()) + "',";//TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString())
                    //    else
                    //        ssql = ssql + " " + parameters[i].Text + "= " + parameters[i].Value + ",";
                    //}
                    //ssql = ssql.Substring(0, ssql.Length - 1) + "";
                    //ssql = ssql + " where zyh='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[0].Value.ToString()) + "' and xh=" + parameters[1].Value + " and zxh=" + parameters[2].Value;
                    ////用于记录生成的SQL语句，医嘱主键，操作类型。。在一面的事务中一次性处理
                    //System.String[] str_update = { row["order_id"].ToString(), ssql, "update" };
                    //listUpdate.Add(str_update);

                    //ssql = "update zy_yzhj set ";
                    //ssql = ssql + " zzrq='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[3].Value.ToString()) + "' ";
                    //ssql = ssql + " ,tzys='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[4].Value.ToString()) + "' ";
                    //ssql = ssql + " where zyh='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[0].Value.ToString()) + "' and yzxh=" + parameters[1].Value + " and xmbm='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(HisFunctions.GetOldHISXmYpBM(row["xmly"].ToString(), row["hoitem_id"].ToString(), newdb)) + "'";

                    //System.String[] str_update1 = { row["order_id"].ToString(), ssql, "update" };
                    //listUpdate.Add(str_update1);

                    //ssql = "update zy_yzlxd set ";
                    //ssql = ssql + " zzsj='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[3].Value.ToString()) + "' ";
                    ////ssql = ssql + " tzys='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[4].Value.ToString()) + "' ";
                    //ssql = ssql + " where zyh='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[0].Value.ToString()) + "' and xh=" + parameters[1].Value + " and zxh=" + parameters[2].Value;

                    //System.String[] str_update2 = { row["order_id"].ToString(), ssql, "update" };
                    //listUpdate.Add(str_update2);

                    #endregion

                    #region 删除语句
                    ssql = "delete from ZY_CQLSYZD ";
                    ssql = ssql + " where ((yzfl='P' and jzsj is null) or (yzfl in ('T','C') and sfzx='N')) and ";
                    ssql = ssql + " zyh='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[0].Value.ToString()) + "' and xh=" + parameters[1].Value + " and zxh=" + parameters[2].Value;
                    //用于记录生成的SQL语句，医嘱主键，操作类型。。在一面的事务中一次性处理
                    System.String[] str_update = { row["order_id"].ToString(), ssql, "delete" };
                    listDelete.Add(str_update);

                    ssql = "delete from zy_yzhj ";
                    ssql = ssql + " where zyh='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[0].Value.ToString()) + "' and yzxh=" + parameters[1].Value + " and xmbm='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(HisFunctions.GetOldHISXmYpBM(row["xmly"].ToString(), row["hoitem_id"].ToString(), newdb)) + "'";

                    System.String[] str_update1 = { row["order_id"].ToString(), ssql, "delete" };
                    listDelete1.Add(str_update1);

                    ssql = "delete from zy_yzlxd ";
                    ssql = ssql + " where zyh='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[0].Value.ToString()) + "' and xh=" + parameters[1].Value + " and zxh=" + parameters[2].Value;

                    System.String[] str_update2 = { row["order_id"].ToString(), ssql, "delete" };
                    listDelete2.Add(str_update2);
                    #endregion
                }

                #region 事务处理
                System.Data.Odbc.OdbcConnection connection = new System.Data.Odbc.OdbcConnection(DAL.BaseDal.oldhis_constr);
                System.Data.Odbc.OdbcTransaction tx = null;
                System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand();
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    tx = connection.BeginTransaction();
                    cmd.Transaction = tx;
                    System.Data.Odbc.OdbcDataAdapter adapter = new System.Data.Odbc.OdbcDataAdapter();

                    for (int i = 0; i < listDelete.Count; i++)
                    {
                        cmd.CommandText = listDelete[i][1].ToString();
                        int ii = cmd.ExecuteNonQuery();
                        //只有医嘱表删除成功，才执行后面的
                        if (ii > 0)
                        {
                            cmd.CommandText = listDelete1[i][1].ToString();
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = listDelete2[i][1].ToString();
                            cmd.ExecuteNonQuery();
                        }
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
                    throw new Exception(ex.Message);
                }

                #endregion


                System.String[] str = { "0", "保存成功" };
                return HisFunctions.GetResponseString("CancelOrder", str);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

        public static string OrderExec(DataSet ds, int iType, RelationalDatabase database)
        {
            //TrasenFrame.Forms.FrmMdiMain.Database = database;
            //TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
            //TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
            //TrasenFrame.Forms.FrmMdiMain.Jgmc = "";

            DataTable tb = ds.Tables[0];
            string strMsg = "";
            if (tb.Rows.Count == 0)
            {
                throw new Exception("信息格式未初始化");
            }

            #region 验证医嘱ID
            if (!tb.Columns.Contains("yzid"))
            {
                throw new Exception("医嘱执行消息中不包含医嘱编号");
            }
            #endregion

            try
            {
                database.BeginTransaction();
                switch (iType)
                {
                    case 1:
                        #region  医嘱转抄
                        for (int i = 0; i < tb.Rows.Count; i++)
                        {
                            //yzlx 1长期医嘱 2临时医嘱
                            if (Convertor.IsNull(tb.Rows[i]["yzid"], "") != ""
                                && Convertor.IsNull(tb.Rows[i]["zchsid"], "") != ""
                                && Convertor.IsNull(tb.Rows[i]["zcsj"], "") != "")
                            {
                                StringBuilder strAppend = new StringBuilder();
                                strAppend.Append("update zy_orderrecord set  status_flag=2, Auditing_User='" + tb.Rows[i]["zchsid"].ToString().Trim() + "',Auditing_Date='" + DateTime.ParseExact(tb.Rows[i]["zcsj"].ToString(), "yyyy-MM-dd HH:mm:ss", null) + "'");
                                strAppend.Append(" where delete_bit=0  and order_id='" + tb.Rows[i]["yzid"].ToString().Trim() + "'  and status_flag in (1,3)");
                                database.DoCommand(strAppend.ToString());
                            }
                            else
                            {
                                database.RollbackTransaction();
                                return HisFunctions.GetResponseString("OrderExec", new string[] { "-1",
                                "医嘱转抄:zchsid="+Convertor.IsNull(tb.Rows[i]["zchsid"], "")+";zcsj="+Convertor.IsNull(tb.Rows[i]["zcsj"], ""),
                                 Convertor.IsNull(tb.Rows[i]["yzid"],"")});
                            }
                        }
                        strMsg = "医嘱转抄";
                        break;
                        #endregion
                    case 2:
                        #region 取消转抄
                        for (int j = 0; j < tb.Rows.Count; j++)
                        {
                            if (Convertor.IsNull(tb.Rows[j]["yzid"], "") != ""
                                && Convertor.IsNull(tb.Rows[j]["tzzchsid"], "") != ""
                                && Convertor.IsNull(tb.Rows[j]["tzzcsj"], "") != "")
                            {
                                StringBuilder strAppend = new StringBuilder();
                                strAppend.Append("update zy_orderrecord set status_flag=4, ORDER_EUSER='" + tb.Rows[j]["tzzchsid"].ToString().Trim() + "',ORDER_EUDATE='" + DateTime.ParseExact(tb.Rows[j]["tzzcsj"].ToString(), "yyyy-MM-dd HH:mm:ss", null) + "' ");
                                strAppend.Append(" where delete_bit=0  and order_id='" + tb.Rows[j]["yzid"].ToString().Trim() + "'  and status_flag in (1,3)");
                                database.DoCommand(strAppend.ToString());

                            }
                            else
                            {
                                database.RollbackTransaction();
                                return HisFunctions.GetResponseString("OrderExec", new string[] { "1",
                               "取消转抄:tzzchsid="+Convertor.IsNull(tb.Rows[j]["tzzchsid"], "")+";zcsj="+Convertor.IsNull(tb.Rows[j]["tzzcsj"], ""),
                                 Convertor.IsNull(tb.Rows[j]["yzid"],"")});
                            }
                        }
                        strMsg = "取消转抄";
                        break;
                        #endregion
                    case 3:
                        #region 医嘱记账
                        for (int k = 0; k < tb.Rows.Count; k++)
                        {
                            if (Convertor.IsNull(tb.Rows[k]["yzid"], "") != ""
                                && Convertor.IsNull(tb.Rows[k]["yzlx"], "") != ""
                                && Convertor.IsNull(tb.Rows[k]["zhzxsj"], "") != ""
                                && Convertor.IsNull(tb.Rows[k]["zhzxid"], "") != "")
                            {
                                try
                                {
                                    StringBuilder strAppend = new StringBuilder();
                                    strAppend.Append(" update zy_orderrecord set lastexecuser='" + tb.Rows[k]["zhzxid"] + "',lastexecdate='" + DateTime.ParseExact(tb.Rows[k]["zhzxsj"].ToString(), "yyyy-MM-dd HH:mm:ss", null) + "'");
                                    if (Convert.ToInt32(tb.Rows[k]["yzlx"]) == 2)
                                    {
                                        strAppend.Append(" ,status_flag=5,order_edate=GETDATE() ");
                                        strAppend.Append("  where delete_bit=0 and order_id='" + tb.Rows[k]["yzid"].ToString().Trim() + "' and  status_flag=2");
                                    }
                                    else
                                    {
                                        strAppend.Append(",status_flag=case status_flag when 4 then 5 else status_flag end  ");
                                        strAppend.Append(" where delete_bit=0 and order_id='" + tb.Rows[k]["yzid"].ToString().Trim() + "' and status_flag in(2,4)");
                                    }
                                    database.DoCommand(strAppend.ToString());
                                }
                                catch (Exception err)
                                {
                                    database.RollbackTransaction();
                                    throw new Exception(err.Message);
                                }
                            }
                            else
                            {
                                database.RollbackTransaction();
                                return HisFunctions.GetResponseString("OrderExec", new string[] { "1",
                               "医嘱记账:yzlx="+Convertor.IsNull(tb.Rows[k]["yzlx"], "")+";zhzxsj="+Convertor.IsNull(tb.Rows[k]["zhzxsj"], "")+";zhzxid="+Convertor.IsNull(tb.Rows[k]["zhzxid"],""),
                                 Convertor.IsNull(tb.Rows[k]["yzid"],"")});
                            }
                        }
                        strMsg = "医嘱记账";
                        break;
                        #endregion

                    default:
                        database.RollbackTransaction();
                        throw new Exception("医嘱执行消息中传入的类型不存储在");
                }
                database.CommitTransaction();

                return HisFunctions.GetResponseString("OrderExec", new string[] { "0", strMsg + "执行成功", "" });
            }
            catch (Exception err)
            {
                database.RollbackTransaction();
                throw err;
            }

        }

        /// <summary>
        /// 手术申请
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string OperationApply(DataTable tb, RelationalDatabase db)
        {
            //TrasenFrame.Forms.FrmMdiMain.Database = db;
            TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgmc = "";
            try
            {
                //科室转化
                string strDeptId = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, tb.Rows[0]["dqks"].ToString(), db);
                string strWardId = TrasenClasses.GeneralClasses.Convertor.IsNull(db.GetDataTable("select ward_id from JC_WARDRDEPT where dept_id='" + strDeptId + "'").Rows[0][0], "");
                //住院号
                string strInPatientNo = patient.FormatZyh(Convertor.IsNull(tb.Rows[0]["zyh"], ""), db);
                string strInPatientId = db.GetDataTable("select inpatient_id from ZY_INPATIENT where inpatient_no='" + strInPatientNo + "'").Rows[0][0].ToString();
                string sql = "";
                //手术状态 N－新申请手术G－手术麻醉系统已提取M－手术信息变化C－手术取消－手术结束
                if (tb.Rows[0]["sszt"].ToString().Trim() == "N")
                {
                    //判断手术申请是否存在
                    sql = "select order_id from ZY_ORDERRECORD where  DELETE_BIT=0  and inpatient_id='" + strInPatientId + "' and memo='手术申请' and memo1='" + tb.Rows[0]["sssqdh"].ToString().Trim() + "'";
                    string strOrderId = "";
                    DataTable tb1 = db.GetDataTable(sql);
                    if (tb1.Rows.Count > 0)
                    {
                        strOrderId = tb1.Rows[0]["order_id"].ToString().Trim();
                    }

                    //医嘱名称
                    string strContext = "拟在" + Convert.ToDateTime(tb.Rows[0]["sssj"]).ToString("yyyy年MM月dd日 HH:mm") + tb.Rows[0]["mzfs"].ToString() + "下行" + tb.Rows[0]["ssmc"].ToString().Trim();
                    if (strOrderId.Trim().Length > 0)
                    {
                        sql = "update ZY_ORDERRECORD set Order_Doc='" + tb.Rows[0]["sssqz"] + "',Order_context='" + strContext + "' where order_id='" + strOrderId + "'";
                    }
                    else
                    {
                        //产生临时医嘱id
                        Guid order_id = PubStaticFun.NewGuid();
                        //获取最大组号
                        long groupid = 0;
                        sql = "select max(group_id)+1 from ZY_ORDERRECORD where inpatient_id='" + strInPatientId + "' and baby_id=0 ";
                        groupid = Convert.ToInt64(Convertor.IsNull(db.GetDataResult(sql), "0"));

                        //插入一条手术申请记录到临时医嘱中去
                        sql = "INSERT INTO ZY_ORDERRECORD(order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,Order_Doc,HOItem_ID,xmly,Item_Code,Order_context," +
                                      "book_date,Order_bDate,Operator," +
                                      "baby_id,dept_br,ps_flag,dwlx,ntype,num,EXEC_DEPT,jgbm,memo,memo1,STATUS_FLAG)" +
                                      "VALUES('" + order_id + "'," + groupid + ",'" + strInPatientId + "'," + strDeptId + ",'" + strWardId + "',1," + tb.Rows[0]["sssqz"] + ",-1,2,'','" + strContext + "',GetDate(),'" + tb.Rows[0]["sssqsj"] + "'," +
                                      "" + tb.Rows[0]["sssqz"] + ",0," + strDeptId + ",-1,1,7,0," + strDeptId + "," + TrasenFrame.Forms.FrmMdiMain.Jgbm + ",'手术申请','" + tb.Rows[0]["sssqdh"].ToString().Trim() + "',0)";

                    }
                    db.DoCommand(sql);
                }
                if (tb.Rows[0]["sszt"].ToString().Trim() == "C")
                {
                    //取消手术医嘱
                    sql = " update  ZY_ORDERRECORD set  DELETE_BIT=1 where inpatient_id='" + strInPatientId + "' and memo='手术申请' and memo1='" + tb.Rows[0]["sssqdh"].ToString().Trim() + "'";
                    db.DoCommand(sql);
                }
                System.String[] str = { "0", "保存成功", tb.Rows[0]["sssqdh"].ToString().Trim() };

                return HisFunctions.GetResponseString("SaveOperationApplye", str);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

    }
}
