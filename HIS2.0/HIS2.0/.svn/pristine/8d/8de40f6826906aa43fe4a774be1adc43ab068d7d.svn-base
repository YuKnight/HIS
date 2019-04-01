using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;

namespace ts_mzys_class 
{
    public class mzys_yjsq
    {
        //Modify By zp 2013-08-21 新增划价明细id参数 套餐时为null值
        public static void Save(Guid yjsqid, long jgbm, Guid brxxid, Guid ghxxid, Guid jzid, string blh, int djlx,
            string sqrq, int sqr, int sqks, string sqnr, decimal dj, decimal sl, string dw, decimal je, string pcmc,
            string bsjc, string lczd, int zxks, string bbmc, string zysx,
            int bjjbz, Guid yzid, long yzxmid,object hjmxid, out Guid NewYjsqid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[28];

                parameters[0].Text = "@yjsqid";
                parameters[0].Value = yjsqid;

                parameters[1].Text = "@jgbm";
                parameters[1].Value = jgbm;

                parameters[2].Text = "@brxxid";
                parameters[2].Value = brxxid;

                parameters[3].Text = "@ghxxid";
                parameters[3].Value = ghxxid;

                parameters[4].Text = "@jzid";
                parameters[4].Value = jzid;

                parameters[5].Text = "@blh";
                parameters[5].Value = blh;

                parameters[6].Text = "@djlx";
                parameters[6].Value = djlx;

                parameters[7].Text = "@sqrq";
                parameters[7].Value = sqrq;

                parameters[8].Text = "@sqr";
                parameters[8].Value = sqr;

                parameters[9].Text = "@sqks";
                parameters[9].Value = sqks;

                parameters[10].Text = "@sqnr";
                parameters[10].Value = sqnr;

                parameters[11].Text = "@lczd";
                parameters[11].Value = lczd;

                parameters[12].Text = "@zxks";
                parameters[12].Value = zxks;

                parameters[13].Text = "@bbmc";
                parameters[13].Value = bbmc.Trim();

                parameters[14].Text = "@zysx";
                parameters[14].Value = zysx;

                parameters[15].Text = "@bjjbz";
                parameters[15].Value = bjjbz;

                parameters[16].Text = "@yzid";
                parameters[16].Value = yzid;

                parameters[17].Text = "@dj";
                parameters[17].Value = dj;

                parameters[18].Text = "@sl";
                parameters[18].Value = sl;

                parameters[19].Text = "@dw";
                parameters[19].Value = dw;

                parameters[20].Text = "@je";
                parameters[20].Value = je;

                parameters[21].Text = "@pcmc";
                parameters[21].Value = pcmc;

                parameters[22].Text = "@yzxmid";
                parameters[22].Value = yzxmid;

                parameters[23].Text = "@bsjc";
                parameters[23].Value = bsjc;

                parameters[24].Text = "@NewYjsqid";
                parameters[24].ParaDirection = ParameterDirection.Output;
                parameters[24].DataType = System.Data.DbType.Guid;
                parameters[24].ParaSize = 100;

                parameters[25].Text = "@err_code";
                parameters[25].ParaDirection = ParameterDirection.Output;
                parameters[25].DataType = System.Data.DbType.Int32;
                parameters[25].ParaSize = 100;

                parameters[26].Text = "@err_text";
                parameters[26].ParaDirection = ParameterDirection.Output;
                parameters[26].ParaSize = 100;

                parameters[27].Text = "@hjmxid";
                parameters[27].Value = hjmxid == null ? DBNull.Value : hjmxid;

                _DataBase.DoCommand("SP_MZYS_YJSQ", parameters, 30);
                if (parameters[24].Value != DBNull.Value)
                    NewYjsqid = new Guid(parameters[24].Value.ToString());
                else
                    NewYjsqid = Guid.Empty;
                err_code = Convert.ToInt32(parameters[25].Value);
                err_text = Convert.ToString(parameters[26].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        public static DataTable Select(Guid yjsqid, RelationalDatabase _DataBase)
        {
            string ssql = "select sqnr 名称,yzxmid 医嘱项目id,dj 单价,sl 数量,dw 单位,je 金额 ,tcid 套餐id,pcmc 频次 from YJ_MZSQ a,jc_hoi_hdi b  where a.yzxmid=b.hoitem_id and  yjsqid='" + yjsqid + "'";
            return _DataBase.GetDataTable(ssql);
        }
        //Modify by zp 2013-10-25 关联到套餐表获取是否为套餐 
        public static DataTable Select_E(Guid yjsqid, RelationalDatabase _DataBase)
        {
            string ssql = @"select c.TC_FLAG,c.TCID,a.* from YJ_MZSQ as a
             inner join JC_HOITEMDICTION as b on a.YZXMID=b.ORDER_ID
             left join JC_HOI_HDI as c on b.ORDER_ID=c.HOITEM_ID 
             where a.yjsqid='" + yjsqid + "'";
            return _DataBase.GetDataTable(ssql);
        }
        //删除医技申请记录 Modify By zp 2013-10-09
        public static int DeleteDj(Guid yjsqid, Guid yzid,Guid hjmxid,string bbmc,string orderid, RelationalDatabase _DataBase)
        {
            if (yjsqid == Guid.Empty && yzid == Guid.Empty && hjmxid==Guid.Empty && (!string.IsNullOrEmpty(orderid)))
                throw new Exception("清除医技申请项目,医技申请id与医嘱id、医嘱明细id、医嘱项目id不能同时为空!");

            string ssql = "";
            ssql = "delete from YJ_MZSQ where bsfbz=0 ";
           
            if (yjsqid != Guid.Empty)
                ssql += " and yjsqid='" + yjsqid + "'";
            if(yzid!=Guid.Empty)
                ssql += " and yzid='" + yzid + "'";
            if (hjmxid != Guid.Empty)
                ssql += " and hjmxid='" + hjmxid + "'";
            if (!string.IsNullOrEmpty(bbmc))
                ssql += " and BBMC='" + bbmc + "'";
            if (!string.IsNullOrEmpty(orderid))
                ssql += " and yzxmid='" + orderid + "'";
            int i = _DataBase.DoCommand(ssql);
            return i;
            //if (i == 0) throw new Exception("删除申请单据时,影响到数据零行,请刷新后重试");  
        }


        //Modify By zp 2013-10-11
        //public static void DeleteDj(Guid yjsqid, Guid yzid,Guid hjmxid, RelationalDatabase _DataBase)
        //{
        //    string ssql = "";
        //    ssql = "delete from YJ_MZSQ where bsfbz=0 ";

        //    if (yjsqid != Guid.Empty)
        //        ssql += "and yjsqid='" + yjsqid + "'";
        //    if (yzid != Guid.Empty)
        //        ssql += "and yzid='" + yzid + "'";
        //    if(hjmxid)
        //    if (yjsqid == Guid.Empty && yzid == Guid.Empty)
        //        throw new Exception("清除医技申请id或医嘱id不能为空!");
        //    int i = _DataBase.DoCommand(ssql);
        //    //if (i == 0) throw new Exception("删除申请单据时,影响到数据零行,请刷新后重试");  
        //}

        public static DataTable GetYjsqID(Guid hjid,Guid hjmxid, long yzxmid, RelationalDatabase _DataBase)
        {
            string ssql = "select * from YJ_MZSQ(nolock) where yzid='" + hjid + "' and bscbz=0";
            if (yzxmid > 0)
                ssql += "  and yzxmid=" + yzxmid + "";
            if (hjmxid != Guid.Empty)
                ssql += " and hjmxid='" + hjmxid + "'";
            DataTable tb = _DataBase.GetDataTable(ssql);
            return tb;
        }

        public static int UpdateSfbz(string hjid, string sdate, RelationalDatabase _DataBase)
        {
            string ssql = " update YJ_MZSQ set bsfbz=1,sfrq='" + sdate + "' where yzid in " + hjid + " and bsfbz=0 and bscbz=0 ";
            return _DataBase.DoCommand(ssql);
        }
        public static int UpdateSfbz_QX(string hjid, string sdate, RelationalDatabase _DataBase)
        {
            string ssql = " update YJ_MZSQ set bqxsfbz=1,qxsfrq='" + sdate + "' where yzid in " + hjid + " and bsfbz=1 and bscbz=0 ";
            return _DataBase.DoCommand(ssql);
        }

        //通过医技申请id获取医技申请记录 Add By zp 2013-10-09
        public static DataTable GetYjsqInfo(Guid yjsqid, RelationalDatabase db)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Format( @"select sqnr as 名称,yzxmid as 医嘱项目id,dj as 单价,sl as 数量,dw as 单位,je as 金额 ,tcid as 套餐id,pcmc as  频次
                                 ,a.ZXKS 执行科室,dbo.fun_getDeptname(a.ZXKS) AS 执行科室名称,d.SAMP_CODE as 标本ID,d.SAMP_NAME as 标本名称,e.bz as 备注
                                 FROM YJ_MZSQ a inner join  jc_hoi_hdi b  on a.YZXMID=b.HOITEM_ID
                                 inner  join JC_ASSAY  c on c.YZID=b.HOITEM_ID
                                 left join LS_AS_SAMPLE d on d.SAMP_NAME=a.BBMC
                                 inner join MZ_HJB e on a.YZID=e.HJID
                                 where a.YJSQID = '{0}'", yjsqid.ToString());
                dt = db.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }
        //通过划价id、划价明细id、医嘱项目id、标本名称获取指定的医技申请记录 Add By zp 2013-10-10 因为医技申请表套餐项无法和划价明细关联
        public static DataTable GetYjsqInfo(Guid yzid, string yzxmid,Guid hjmxid,string bbmc, RelationalDatabase db)
        {
            DataTable dt = new DataTable();
            try
            {
                if (yzid == Guid.Empty && hjmxid == Guid.Empty) return dt;
                string sql =" SELECT * FROM YJ_MZSQ(nolock) WHERE 1=1  ";
                if (yzid != Guid.Empty)
                    sql += " and YZID='" + yzid + "'";
                if (hjmxid != Guid.Empty)
                     sql += " AND HJMXID='" + hjmxid + "'";
                if (!string.IsNullOrEmpty(yzxmid))
                    sql += " and YZXMID='" + yzxmid + "'";
                if (!string.IsNullOrEmpty(bbmc))
                    sql += " and BBMC='" + bbmc + "'";
                dt = db.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }


        //删除医技 Add by zp 2013-10-17
        public static void DelteQtYj(Guid hjmxid, Guid hjid, string yznr, long order_id, long tcid, long cjid, string bbmc, ref string yj_fjsm,RelationalDatabase db)
        {
            try
            {
                if (hjmxid != Guid.Empty)
                {
                    #region //删除非套餐的医技申请项目
                    //if (_cfg3077.Config.Trim() == "1")
                    if (DeleteDj(Guid.Empty, hjid, hjmxid, "", "", db) > 0)
                        return;
                    else
                    {
                        DataTable dt = mzys_yjsq.GetYjsqID(hjid, Guid.Empty, order_id, db);
                        if (dt.Rows.Count == 1)
                            mzys_yjsq.DeleteDj(Guid.Empty, hjid, Guid.Empty, "", order_id.ToString(), db);
                        else
                        {
                            /*通过划价明细id精确到记录*/
                            bool is_del = false;
                            for (int y = 0; y < dt.Rows.Count; y++)
                            {
                                if (Convertor.IsNull(dt.Rows[y]["HJMXID"], "").Trim() == hjmxid.ToString().Trim())
                                {
                                    mzys_yjsq.DeleteDj(Guid.Empty, hjid, hjmxid, "", order_id.ToString(), db);
                                    is_del = true;
                                    break;
                                }
                            }
                            if (!is_del)
                                mzys_yjsq.DeleteDj(Guid.Empty, hjid, Guid.Empty, "", order_id.ToString(), db);
                        }
                    }
                    #endregion
                }
                else //删除套餐医技申请项目
                {
                    //if (_cfg3077.Config.Trim() == "1")
                    //{
                    #region 启用医技申请单模式
                    string xmid = cjid.ToString();
                    if (order_id <= 0)
                    {
                        DataTable dt_order = mz_sf.GetFeeItemToOrder(xmid, tcid.ToString(), db);
                        if (dt_order.Rows.Count > 0)
                            xmid = dt_order.Rows[0]["HOITEM_ID"].ToString();
                    }
                    else
                        xmid = order_id.ToString();
                    bool is_yjdel = false;
                    Guid yjid = Guid.Empty;
                    DataTable dtb = mzys_yjsq.GetYjsqInfo(hjid, xmid, Guid.Empty, bbmc, db); //先获取所有医技申请项目 通过名称和标本名称精确到一条
                    if (dtb.Rows.Count > 0)
                    {
                        if (dtb.Rows.Count == 1)
                        {
                            yjid = new Guid(dtb.Rows[0]["YJSQID"].ToString());
                            mzys_yjsq.DeleteDj(yjid, hjid, Guid.Empty, bbmc, "", db);
                            is_yjdel = true;
                        }
                        else //还需要通过划价明细的MEMO字段值区分 具体医技项目
                        {
                            string sql = @"SELECT MEMO,YZMC+'  '+'['+MEMO+']' as 医嘱内容,HJMXID FROM MZ_HJB_MX WHERE HJID='" + hjid + "' AND GG='" + bbmc + @"'";
                            DataTable dt = db.GetDataTable(sql);

                            for (int k = 0; k < dt.Rows.Count; k++)
                            {
                                if (Convertor.IsNull(dt.Rows[k]["医嘱内容"], "").Trim() == yznr)//tb.Rows[nrow]["医嘱内容"].ToString().Trim())
                                {
                                    yj_fjsm = Convertor.IsNull(dt.Rows[k]["MEMO"], "").Trim();
                                    //获取明确的医技申请id
                                    for (int j = 0; j < dtb.Rows.Count; j++)
                                    {
                                        if (Convertor.IsNull(dtb.Rows[j]["HJMXID"], "").Trim() == dt.Rows[k]["HJMXID"].ToString().Trim())
                                        {
                                            yjid = new Guid(dtb.Rows[j]["YJSQID"].ToString());
                                            break;
                                        }
                                    }
                                }
                            }
                            mzys_yjsq.DeleteDj(yjid, hjid, Guid.Empty, bbmc, "", db);
                            is_yjdel = true;
                        }
                    }
                    if (!is_yjdel)
                        mzys_yjsq.DeleteDj(Guid.Empty, hjid, Guid.Empty, bbmc, "", db);
                    #endregion
                    //}
                    //else
                    //{
                    //    /*删除掉套餐 直接 ？？？*/

                    //}

                }
            }
            catch (Exception ea)
            {
                throw new Exception("删除医技申请出现异常!原因:" + ea.Message);
            }
        }
        //通过医嘱id获取其对应的套餐id  检验申请框用 Add By zp 2013-10-17
        public static DataTable GetYjTcId(string orderid,RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Format(@"SELECT COALESCE(c.tcid,0) AS TCID from jc_HOITEMDICTION AS A  
                   INNER JOIN jc_HOI_HDI AS B ON A.ORDER_ID=B.HOITEM_ID and a.delete_bit=0  
                   INNER JOIN  VI_jc_ITEMS AS C  ON B.HDITEM_ID=C.ITEMID AND B.TCID=C.TCID  
                   where A.ORDER_ID= '{0}'", orderid);
                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }

        //通过划价id和处方内存表得到 医技申请表需要删除的记录 Modify By zp 2013-10-10 
        //public static DataTable GetUnYjInfo(Guid hjid, DataRow[] rows, RelationalDatabase db)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
                
        //        string sql = @"SELECT * FROM YJ_MZSQ WHERE YZID='" + hjid + "'";
        //        DataTable dt_yj = db.GetDataTable(sql);
           
        //        for (int k = 0; k < dt_yj.Rows.Count; k++)
        //        {
        //            for (int j = 0; j < rows.Length; j++)
        //            {
        //                int r_sl = Convert.ToInt32(rows[j]["剂量"]);
        //                int d_sl = Convert.ToInt32(dt_yj.Rows[k]["SL"]);
        //                if (dt_yj.Rows[k]["YZXMID"].ToString().Trim()== rows[j]["yzid"].ToString().Trim() && 
        //                d_sl==r_sl)
        //                {
        //                    dt_yj.Rows.RemoveAt(k);
        //                    k--;
        //                    break;
        //                }
        //            }
        //        }
        //        /*得到最后的是医技表有的记录,处方表没有的 即需要删除医技的申请项目*/
        //        dt = dt_yj.Copy();  
        //    }
        //    catch (Exception ea)
        //    {
        //        throw ea;
        //    }
        //    return dt;
        //}
        //通过老的挂号id 更新医技申请表、划价表的挂号id为新的挂号id 用于门诊收费时收费员先产生医技处方记录后产生挂号记录
        public static bool UpdateYjGhxxId(Guid UnGhid,Guid NewJzid, Guid NewGhid, RelationalDatabase db)
        {
            try
            {
                string sql = string.Format(@"UPDATE YJ_MZSQ GHXXID='{0}',JZID='{1}' WHERE GHXXID='{2}'", NewGhid,NewJzid, UnGhid);
                db.BeginTransaction();
                db.DoCommand(sql);
                sql = string.Format(@"UPDATE MZ_HJB SET GHXXID='{0}',JZID='{1}' WHERE GHXXID='{2}'", NewGhid, NewJzid, UnGhid);
                db.DoCommand(sql);
                db.CommitTransaction();
            }
            catch (Exception ea)
            {
                db.RollbackTransaction();
                throw ea;
            }
            return true;
        }
    }
}
