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

namespace ts_mz_class
{
    public class mz_cf
    {

        /// <summary>
        /// 保存处方头
        /// </summary>
        /// <param name="cfid">处方ID</param>
        /// <param name="brxxid">病人信息ID</param>
        /// <param name="ghxxid">挂号信息ID</param>
        /// <param name="blh">病历号</param>
        /// <param name="sfck">收费窗口</param>
        /// <param name="zje">总金额</param>
        /// <param name="hjrq">划价日期</param>
        /// <param name="hjy">划价员</param>
        /// <param name="hjyxm">划价员姓名</param>
        /// <param name="hjck">划价窗口</param>
        /// <param name="hjid">划价处方库ID</param>
        /// <param name="ksdm">科室</param>
        /// <param name="ksmc">科室名称</param>
        /// <param name="ysdm">医生</param>
        /// <param name="ysxm">医生姓名</param>
        /// <param name="zyksdm">属于住院科室</param>
        /// <param name="zxks">执行科室</param>
        /// <param name="zxksmc">执行科室名称</param>
        /// <param name="bghpbz">挂号票标志</param>
        /// <param name="tcid">套餐ID</param>
        /// <param name="xmly">项目来源</param>
        /// <param name="djy">机构编码</param>
        /// <param name="NewCfid">返回新处方ID 只有 cfid=0 时有值</param>
        /// <param name="err_code">返回错误号 0 正常</param>
        /// <param name="err_text">返回错误文件</param>
        public static void SaveCf(Guid cfid, Guid brxxid, Guid ghxxid, string blh, string sfck, decimal zje, string hjrq, int hjy, string hjyxm, string hjck, Guid hjid, int ksdm, string ksmc, int ysdm, string ysxm, int zyksdm, int zxks, string zxksmc, int bghpbz, long tcid, int xmly, int bscbz, int cfjs, long jgbm, out Guid NewCfid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[27];

                parameters[0].Text = "@cfid";
                parameters[0].Value = cfid;

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;

                parameters[2].Text = "@ghxxid";
                parameters[2].Value = ghxxid;

                parameters[3].Text = "@blh";
                parameters[3].Value = blh;

                parameters[4].Text = "@sfck";
                parameters[4].Value = sfck;

                parameters[5].Text = "@zje";
                parameters[5].Value = zje;

                parameters[6].Text = "@hjrq";
                parameters[6].Value = hjrq;

                parameters[7].Text = "@hjy";
                parameters[7].Value = hjy;

                parameters[8].Text = "@hjyxm";
                parameters[8].Value = hjyxm;

                parameters[9].Text = "@hjck";
                parameters[9].Value = hjck;

                parameters[10].Text = "@hjid";
                parameters[10].Value = hjid;

                parameters[11].Text = "@ksdm";
                parameters[11].Value = ksdm;

                parameters[12].Text = "@ksmc";
                parameters[12].Value = ksmc;

                parameters[13].Text = "@ysdm";
                parameters[13].Value = ysdm;

                parameters[14].Text = "@ysxm";
                parameters[14].Value = ysxm;

                parameters[15].Text = "@zyksdm";
                parameters[15].Value = zyksdm;

                parameters[16].Text = "@zxks";
                parameters[16].Value = zxks;

                parameters[17].Text = "@zxksmc";
                parameters[17].Value = zxksmc;

                parameters[18].Text = "@bghpbz";
                parameters[18].Value = bghpbz;

                parameters[19].Text = "@tcid";
                parameters[19].Value = tcid;

                parameters[20].Text = "@xmly";
                parameters[20].Value = xmly;

                parameters[21].Text = "@cfjs";
                parameters[21].Value = cfjs;

                parameters[22].Text = "@bscbz";
                parameters[22].Value = bscbz;

                parameters[23].Text = "@jgbm";
                parameters[23].Value = jgbm;


                parameters[24].Text = "@NewCfid";
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


                _DataBase.DoCommand("SP_MZSF_CF", parameters, 30);
                NewCfid = new Guid(parameters[24].Value.ToString());
                err_code = Convert.ToInt32(parameters[25].Value);
                err_text = Convert.ToString(parameters[26].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }



        }

        /// <summary>
        /// 保存处方明细
        /// </summary>
        /// <param name="cfmxid">处方明细ID</param>
        /// <param name="cfid">处方头ID</param>
        /// <param name="pym">拼音码</param>
        /// <param name="bm">编码</param>
        /// <param name="pm">品名</param>
        /// <param name="spm">商品名</param>
        /// <param name="gg">规格</param>
        /// <param name="cj">厂家</param>
        /// <param name="dj">单价</param>
        /// <param name="sl">数量</param>
        /// <param name="dw">单位</param>
        /// <param name="ydwbl">原单位比例</param>
        /// <param name="js">剂数</param>
        /// <param name="je">金额</param>
        /// <param name="tjdxmdm">统计大项目编码</param>
        /// <param name="xmid">项目ID</param>
        /// <param name="hjmxid">划价明细ID</param>
        /// <param name="gjbm">国家编码</param>
        /// <param name="bpsyybz">皮试用药标志</param>
        /// <param name="bpsbz">皮试标志</param>
        /// <param name="bmsbz">免费标志</param>
        /// <param name="syff">使用方法</param>
        /// <param name="zt">嘱托</param>
        /// <param name="fzxh">分组序号</param>
        /// <param name="pxxh">排队序号</param>
        /// <param name="tyid">退原ID</param>
        /// <param name="pxxh">批发价</param>
        /// <param name="tyid">批发金额</param>
        /// <param name="NewCfmxid">返回新的处方明细ID 只有当cfmxid=0 时才有值</param>
        /// <param name="err_code">返回错误号 0 为正常</param>
        /// <param name="err_text">返回错误文件</param>
        public static void SaveCfmx(Guid cfmxid, Guid cfid, string pym, string bm, string pm, string spm, string gg, string cj, decimal dj, decimal sl, string dw, int ydwbl, int js, decimal je, string tjdxmdm, long xmid, Guid hjmxid, string gjbm, int bzby, int bpsbz, Guid pshjmxid, decimal yl, string yldw, string yfmc, int pcid, decimal ts, string zt, int fzxh, int pxxh, Guid tyid, decimal pfj, decimal pfje, int tcid, out Guid NewCfmxid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[36];

                parameters[0].Text = "@cfmxid";
                parameters[0].Value = cfmxid;

                parameters[1].Text = "@cfid";
                parameters[1].Value = cfid;

                parameters[2].Text = "@pym";
                parameters[2].Value = pym;

                parameters[3].Text = "@bm";
                parameters[3].Value = bm;

                parameters[4].Text = "@pm";
                parameters[4].Value = pm;

                parameters[5].Text = "@spm";
                parameters[5].Value = spm;

                parameters[6].Text = "@gg";
                parameters[6].Value = gg;

                parameters[7].Text = "@cj";
                parameters[7].Value = cj;

                parameters[8].Text = "@dj";
                parameters[8].Value = dj;

                parameters[9].Text = "@sl";
                parameters[9].Value = sl;

                parameters[10].Text = "@dw";
                parameters[10].Value = dw;

                parameters[11].Text = "@ydwbl";
                parameters[11].Value = ydwbl;

                parameters[12].Text = "@js";
                parameters[12].Value = js;

                parameters[13].Text = "@je";
                parameters[13].Value = je;

                parameters[14].Text = "@tjdxmdm";
                parameters[14].Value = tjdxmdm;

                parameters[15].Text = "@xmid";
                parameters[15].Value = xmid;

                parameters[16].Text = "@hjmxid";
                parameters[16].Value = hjmxid;

                parameters[17].Text = "@gjbm";
                parameters[17].Value = gjbm;

                parameters[18].Text = "@bzby";
                parameters[18].Value = bzby;

                parameters[19].Text = "@bpsbz";
                parameters[19].Value = bpsbz;

                parameters[20].Text = "@pshjmxid";
                parameters[20].Value = pshjmxid;

                parameters[21].Text = "@yl";
                parameters[21].Value = yl;

                parameters[22].Text = "@yldw";
                parameters[22].Value = yldw;

                parameters[23].Text = "@yfmc";
                parameters[23].Value = yfmc;

                parameters[24].Text = "@pcid";
                parameters[24].Value = pcid;

                parameters[25].Text = "@ts";
                parameters[25].Value = ts;

                parameters[26].Text = "@zt";
                parameters[26].Value = zt;

                parameters[27].Text = "@fzxh";
                parameters[27].Value = fzxh;

                parameters[28].Text = "@pxxh";
                parameters[28].Value = pxxh;

                parameters[29].Text = "@tyid";
                parameters[29].Value = tyid;

                parameters[30].Text = "@pfj";
                parameters[30].Value = pfj;

                parameters[31].Text = "@pfje";
                parameters[31].Value = pfje;

                parameters[32].Text = "@tcid";
                parameters[32].Value = tcid;

                parameters[33].Text = "@NewCfmxid";
                parameters[33].ParaDirection = ParameterDirection.Output;
                parameters[33].DataType = System.Data.DbType.Guid;
                parameters[33].ParaSize = 100;

                parameters[34].Text = "@err_code";
                parameters[34].ParaDirection = ParameterDirection.Output;
                parameters[34].DataType = System.Data.DbType.Int32;
                parameters[34].ParaSize = 100;

                parameters[35].Text = "@err_text";
                parameters[35].ParaDirection = ParameterDirection.Output;
                parameters[35].ParaSize = 100; 

                _DataBase.DoCommand("SP_MZSF_CFMX", parameters, 30);
                NewCfmxid = new Guid(parameters[33].Value.ToString());
                err_code = Convert.ToInt32(parameters[34].Value);
                err_text = Convert.ToString(parameters[35].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }  
        }
        //保存处方明细 Add by zp 2013-12-13  NewCfmxid从外部传入进来 创智医保需求 
        public static void SaveCfmx(Guid cfmxid, Guid cfid, string pym, string bm, string pm, string spm, string gg, string cj, decimal dj, decimal sl, string dw, int ydwbl, int js, decimal je, string tjdxmdm, long xmid, Guid hjmxid, string gjbm, int bzby, int bpsbz, Guid pshjmxid, decimal yl, string yldw, string yfmc, int pcid, decimal ts, string zt, int fzxh, int pxxh, Guid tyid, decimal pfj, decimal pfje, int tcid, ref Guid NewCfmxid, out int err_code, out string err_text,bool IsAdd, RelationalDatabase _DataBase)
        {
            try
            {
                err_code = -1;
               
                Guid yhjmxid=hjmxid;
                Guid ytyid = tyid; 
                decimal ysl = 0;
                int yjs = 0;
                decimal ytsl = 0;
                int ytjs = 0;
                decimal ktsl = 0;
                int ktjs = 0;
                int qrbz = 0;
                int tfbz = 0;
                string sql = "";
               
                #region 退药
                if (tyid != Guid.Empty) //退药
                {
                    NewCfmxid = Guid.Empty;
                    sql = @"select (sl*js) ysl,js yjs,bqrbz bqrbz,qrsj,qrks,qrdjy,btfbz 
                    from mz_cfb_mx where cfmxid='" + tyid + @"' and bscbz=0  ";
                    DataTable dt_ty = _DataBase.GetDataTable(sql);
                    if (dt_ty.Rows.Count == 0)
                    {
                        err_text = "数据已转移到历史库,不能办理退费,请咨询管理员！";
                        return;
                    }
                    qrbz = Convert.ToInt32(dt_ty.Rows[0]["bqrbz"]);
                    tfbz = Convert.ToInt32(dt_ty.Rows[0]["btfbz"]);
                    ysl = Convert.ToInt32(Convertor.IsNull(dt_ty.Rows[0]["ysl"], "0"));
                    yjs = Convert.ToInt32(Convertor.IsNull(dt_ty.Rows[0]["js"], "0"));

                    if (tjdxmdm != "01" && tjdxmdm != "02" && tjdxmdm != "03")
                    {
                        if (qrbz == 1 && tfbz == 0 && (new SystemCfg(3013, _DataBase)).Config.Trim() == "1")
                        {
                            err_text = "该费用已被科室确认,需经科室同意才可退费！";
                            return;
                        }
                    }
                    //--已退数量 已退剂数  
                    sql = @"select coalesce(sum(sl*js),0) ytsl,coalesce(sum(js),0) ytjs  
                            from mz_cfb_mx where tyid='" + tyid + "' and bscbz=0 ";
                    dt_ty = _DataBase.GetDataTable(sql);
                    ytsl = Convert.ToInt32(Convertor.IsNull(dt_ty.Rows[0]["ytsl"], "0"));
                    ytjs = Convert.ToInt32(Convertor.IsNull(dt_ty.Rows[0]["ytjs"], "0"));
                    ktsl = ysl + ytsl;//可退数量  
                    ktjs = yjs + ytjs;//可退剂数 
                    if ((ktsl + sl) < 0)
                    {
                        //cast(cast(coalesce(@ysl,0) as float) as varchar(20))+@dw
                        //cast(cast(coalesce(@ytsl,0) as float) as varchar(20))+@dw
                        //cast(cast(coalesce(@ktsl,0) as float) as varchar(20))+@dw
                        //cast((@ysl*@yjs) as varchar(30))
                        //cast((@ytsl*@ytjs) as varchar(30))
                        //cast((@ktsl*@ktjs) as varchar(30))
                        err_text = "退数量输入不正确。 [" + pm + "] 原数量为" + Convert.ToDecimal(ysl).ToString() + dw + @",
                         已退" + Convert.ToDecimal(ytsl).ToString() + dw + @",可退" + Convert.ToDecimal(ktsl).ToString() + dw + @" 
                         原总量" + (ysl * yjs).ToString() + @" 已退总量" + (ytsl * ytjs).ToString() + @" 
                         可退总量" + (ktsl * ktjs).ToString() + "";
                        return;
                    }
                    if (ktjs + (-1) * js < 0 && tjdxmdm == "03")
                    {
                        //cast(cast(coalesce(@yjs,0) as float) as varchar(20))
                        //cast(cast(coalesce(@ytjs,0) as float) as varchar(20))
                        //cast(cast(coalesce(@ktjs,0) as float) as varchar(20))
                        err_text = "'退剂数输入不正确。[" + pm + "]   原剂数为 " + Convert.ToDecimal(yjs).ToString() + "'剂,  已退 " + Convert.ToDecimal(ytjs).ToString() + @"剂, 
                        可退 " + Convert.ToDecimal(ktjs).ToString() + "剂";
                        return;
                    }
                    if ((ktjs + (-1) * js) < 0 && tjdxmdm != "03")
                    {
                        if (tcid > 0)
                        {
                            //cast(cast(coalesce(@yjs,0) as float) as varchar(20))
                            //cast(cast(coalesce(@ytjs,0) as float) as varchar(20))
                            //cast(cast(coalesce(@ktjs,0) as float) as varchar(20))+'
                             err_text = "退套餐次数输入不正确。原套餐数为" + Convert.ToDecimal(yjs) + @"次,
                             已退" + Convert.ToDecimal(ytjs) + "次, 可退" + Convert.ToDecimal(ktjs).ToString() + "次";
                             return;
                        }
                    }

                }
                #endregion
                if (IsAdd) //NewCfmxid从外部传入进来
                {
                    int bqrbz = 0;
                    object qrsj = DBNull.Value;
                    int qrks = 0;
                    int qrdjy = 0;
                    if (tjdxmdm != "01" && tjdxmdm != "02" && tjdxmdm != "03" && ytyid == Guid.Empty && yhjmxid != Guid.Empty)
                    {
                        sql = @"select bsdbz,sdsj,sdks,sddjy from mz_hjb_mx where hjmxid='" + hjmxid + "'";
                        DataTable dt = _DataBase.GetDataTable(sql);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //if (NewCfmxid == Guid.Empty) NewCfmxid = new Guid();
                            bqrbz = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["bsdbz"], "0"));
                            if (dt.Rows[0]["sdsj"] != null)
                                qrsj = dt.Rows[0]["sdsj"].ToString();
                            qrks = int.Parse(Convertor.IsNull(dt.Rows[0]["sdks"], "0"));
                            qrdjy = int.Parse(Convertor.IsNull(dt.Rows[0]["sddjy"], "0"));
                        }
                    }
                    sql = @" insert into mz_cfb_mx(cfmxid,cfid,pym,bm,pm,spm,gg,cj,dj,sl,dw,ydwbl,js,je,tjdxmdm,xmid,hjmxid,  
                               gjbm,bzby,bpsbz,pshjmxid,YL,YLDW,YFMC,PCID,TS,zt,fzxh,pxxh,tyid,pfj,pfje,TCID,bqrbz,qrsj,qrks,qrdjy)  
                             values('" + NewCfmxid + "','" + cfid + "','" + pym + "','" + bm + "','" + pm + "','" + spm + "','" + gg + "','" + cj + "','" + dj + "','" + sl + "','" + dw + @"',
                             " + ydwbl + "," + js + ",round(" + je + ",2),'" + tjdxmdm + "'," + xmid + ",'" + hjmxid + "','" + gjbm + "','" + bzby + "','" + bpsbz + "','" + pshjmxid + @"',
                             " + yl + ",'" + yldw + "','" + yfmc + "','" + pcid + "'," + ts + ",'" + zt + "','" + fzxh + "'," + pxxh + ",'" + tyid + @"',
                             " + pfj + "," + pfje + "," + tcid + "," + bqrbz + ",'" + qrsj + "'," + qrks + "," + qrdjy + ")  ";
                    _DataBase.DoCommand(sql);
                }
                else
                {
                    sql = @"update mz_cfb_mx set cfid='"+cfid+"',pym='"+pym+"',bm='"+bm+"',pm='"+pm+"',spm='"+spm+@"',
                    gg='"+gg+"',cj='"+cj+"',dj="+dj+",sl="+sl+",dw='"+dw+"',ydwbl='"+ydwbl+"',js="+js+",je="+je+",tjdxmdm='"+tjdxmdm+@"',
                    xmid="+xmid+",hjmxid='"+hjmxid+"',gjbm='"+gjbm+"',bzby="+bzby+",bpsbz="+bpsbz+@",
                    pshjmxid='"+pshjmxid+"',YL="+yl+",YLDW='"+yldw+"',YFMC='"+yfmc+"',PCID="+pcid+@",  
                    TS="+ts+",zt='"+zt+"',fzxh="+fzxh+",pxxh="+pxxh+",tyid='"+tyid+"',pfj="+pfj+",pfje="+pfje+@",
                    TCID="+tcid+" where cfmxid='"+cfmxid+"'";
                    _DataBase.DoCommand(sql);
                }
            }
            catch (Exception ea)
            {
                throw ea;
            }
            err_code = 0;
            err_text = "保存处方明细表成功";
        }


        /// <summary>
        /// 根据退药信息更新处方表相关信息  条件是CFID 
        /// </summary>
        /// <param name="cfid">处方ID</param>
        /// <param name="yfdm">药房代码</param>
        /// <param name="fyrq">发药日期</param>
        /// <param name="fyr">发药人</param>
        /// <param name="fyck">发药窗口</param>
        /// <param name="pyr">配药人</param>
        /// <param name="pyck">配药窗口</param>
        /// <param name="Nrows">更新行数</param>
        /// <param name="err_code">错误号</param>
        /// <param name="err_text">错误文本</param>
        public static void UpdateCfFyzt(Guid cfid, int yfdm, string yfmc, string fyrq, int fyr, string fyck, int pyr, string pyck, out int Nrows, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "update mz_cfb set bfybz=1,zxks=" + yfdm + ",zxksmc='" + yfmc + "',fyrq='" + fyrq + "',fyr=" + fyr + ",fyrxm='" + Fun.SeekEmpName(fyr, _DataBase) + "',fyck='" + fyck + "',pyr=" + pyr + ",pyrxm='" + Fun.SeekEmpName(pyr, _DataBase) + "',pyck='" + pyck + "' where cfid='" + cfid + "' and bfybz=0 ";
                Nrows = _DataBase.DoCommand(ssql);
                err_code = 0;
                err_text = "更新成功";

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
        /// <summary>
        /// 根据CFID更新处方表的收费状态  退费时用
        /// </summary>
        /// <param name="cfid">处方ID字符串 格式为(1,2,3)</param>
        /// <param name="sky">收费员</param>
        /// <param name="skyxm">收费员姓名</param>
        /// <param name="skrq">收费日期</param>
        /// <param name="sfck">收费窗口</param>
        /// <param name="dnlsh">电脑流水号</param>
        /// <param name="fph">发票号</param>
        /// <param name="Fpid">发票ID</param>
        /// <param name="Nrows">影响的行数</param>
        /// <param name="err_code">错误号</param>
        /// <param name="err_text">错误文本</param>
        public static void UpdateCfsfzt(string cfid, int sky, string skyxm, string skrq, string sfck, long dnlsh, string fph, Guid Fpid, out int Nrows, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "update mz_cfb set bsfbz=1,sfy=" + sky + ",sfyxm='" + skyxm + "',sfrq='" + skrq + "',sfck='" + sfck + "',dnlsh=" + dnlsh + ",fph='" + fph + "',fpid='" + Fpid + "' where cfid in " + cfid + " and bsfbz=0";
                Nrows = _DataBase.DoCommand(ssql);
                err_code = 0;
                err_text = "更新成功";

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        public static void UpdateCfsfzt(Guid cfid, int sky, string skyxm, string skrq, string sfck, long dnlsh, string fph, out int Nrows, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "update mz_cfb set fph='" + fph + "',bsfbz=1,sfy=" + sky + ", sfyxm='" + skyxm + "',sfrq='" + skrq + "',sfck='" + sfck + "',dnlsh=" + dnlsh + " where cfid = '" + cfid + "' and bsfbz=0";
                Nrows = _DataBase.DoCommand(ssql);
                err_code = 0;
                err_text = "更新成功";

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }


        /// <summary>
        /// 根据 HJID和收费标志 更新处方表的收费状态   收费时用
        /// </summary>
        /// <param name="cfid">处方ID字符串 格式为(1,2,3)</param>
        /// <param name="sky">收费员</param>
        /// <param name="skyxm">收费员姓名</param>
        /// <param name="skrq">收费日期</param>
        /// <param name="sfck">收费窗口</param>
        /// <param name="dnlsh">电脑流水号</param>
        /// <param name="fph">发票号</param>
        /// <param name="Fpid">发票ID</param>
        /// <param name="Nrows">影响的行数</param>
        /// <param name="err_code">错误号</param>
        /// <param name="err_text">错误文本</param>
        public static void  UpdateCfsfzt_E(string hjid, int sky, string skyxm, string skrq, string sfck, long dnlsh, string fph, Guid Fpid, out int Nrows, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "update mz_cfb set bsfbz=1,sfy=" + sky + ",sfyxm='" + Fun.SeekEmpName(sky, _DataBase) + "', sfrq='" + skrq + "',sfck='" + sfck + "',dnlsh=" + dnlsh + ",fph='" + fph + "',fpid='" + Fpid + "' where hjid in " + hjid + " and bsfbz=0";
                Nrows = _DataBase.DoCommand(ssql);
                err_code = 0;
                err_text = "";

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
      
        /// <summary>
        ///  根据原发票ID 将原处方更新为补收发票的发票信息。所有处方头改成当前发票号、发票ID 其它发费信息不变  退费时用
        /// </summary>
        /// <param name="hjid">划价id</param>
        /// <param name="dnlsh">电脑流水号</param>
        /// <param name="fph">发票号</param>
        /// <param name="Fpid">新发票ID</param>
        /// <param name="YFpid">原发票ID</param>
        /// <param name="Nrows">影响的行数</param>
        /// <param name="err_code">错误号</param>
        /// <param name="err_text">错误文本</param>
        public static void UpdateCfsfzt_Old_New(string hjid, long dnlsh, string fph, Guid Fpid, string Yfph, out int Nrows, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "update mz_cfb set dnlsh=" + dnlsh + ",fph='" + fph + "',fpid='" + Fpid + "',bscbz=0 where hjid in " + hjid + " and  fph='" + Yfph + "' and bscbz<>1";
                Nrows = _DataBase.DoCommand(ssql);
                err_code = 0;
                err_text = "";

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        //查询是否收过卡费
        public static DataTable SelectCardFee(Guid ghxxid, string fph, long sfxmid, RelationalDatabase _DataBase)
        {
            string ssql = "select XMID from mz_cfb a,mz_cfb_mx b where a.cfid=b.cfid and a.ghxxid='" + ghxxid + "' and fph='" + fph + "' and bsfbz=1 and xmid=" + sfxmid + " and ghxxid='" + ghxxid + "'";
            return _DataBase.GetDataTable(ssql);
        }
        //退挂号票
        public static void Tghp(Guid ghxxid, string fph, string sfck, string sdate, Guid NewFpid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            string ssql = "select * from mz_cfb a   where ghxxid='" + ghxxid + "' and a.fph='" + fph + "' and bghpbz=1  ";
            DataTable tbcf = _DataBase.GetDataTable(ssql);
            if (tbcf.Rows.Count > 1)
            {
                err_code = -1;
                err_text = "找到多行处方信息,请和管理员联系";
                return;
            }
            if (tbcf.Rows.Count == 0)
            {
                err_code = -1;
                err_text = "没有找到处方信息,数据可能已转移";
                return;
            }

            Guid Newcfid = Guid.Empty;
            mz_cf.SaveCf(Guid.Empty, new Guid(tbcf.Rows[0]["brxxid"].ToString()), new Guid(tbcf.Rows[0]["ghxxid"].ToString()), Convertor.IsNull(tbcf.Rows[0]["blh"], ""), sfck,
                Convert.ToDecimal(tbcf.Rows[0]["zje"]) * (-1), sdate, TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId,
                TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name, Convertor.IsNull(tbcf.Rows[0]["hjck"], ""), Guid.Empty, Convert.ToInt32(tbcf.Rows[0]["ksdm"]),
                Convertor.IsNull(tbcf.Rows[0]["ksmc"], ""), Convert.ToInt32(tbcf.Rows[0]["ysdm"]), Convertor.IsNull(tbcf.Rows[0]["ysxm"], ""),
                Convert.ToInt32(tbcf.Rows[0]["zyksdm"]), Convert.ToInt32(tbcf.Rows[0]["zxks"]), Convertor.IsNull(tbcf.Rows[0]["zxksmc"], ""),
                Convert.ToInt16(tbcf.Rows[0]["bghpbz"]), 0, Convert.ToInt32(tbcf.Rows[0]["xmly"]), 0,
                Convert.ToInt32(tbcf.Rows[0]["cfjs"]), TrasenFrame.Forms.FrmMdiMain.Jgbm, out Newcfid, out err_code, out err_text, _DataBase);
            if (Newcfid == Guid.Empty || err_code != 0) throw new Exception(err_text);

            Guid NewCfmxid = Guid.Empty;
            ssql = "select * from mz_cfb_mx(nolock) where cfid='" + new Guid(tbcf.Rows[0]["cfid"].ToString()) + "' and bscbz=0 ";
            DataTable tbmx = _DataBase.GetDataTable(ssql);
            if (tbmx.Rows.Count == 0) throw new Exception("没有找到该处方的明细");
            for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
            {
                mz_cf.SaveCfmx(Guid.Empty, Newcfid, Convertor.IsNull(tbmx.Rows[i]["pym"], ""), Convertor.IsNull(tbmx.Rows[i]["bm"], ""),
                    Convertor.IsNull(tbmx.Rows[i]["pm"], ""), Convertor.IsNull(tbmx.Rows[i]["spm"], ""), Convertor.IsNull(tbmx.Rows[i]["gg"], ""),
                    Convertor.IsNull(tbmx.Rows[i]["cj"], ""), Convert.ToDecimal(tbmx.Rows[i]["dj"]), Convert.ToDecimal(tbmx.Rows[i]["sl"]) * (-1),
                    Convertor.IsNull(tbmx.Rows[i]["dw"], ""), Convert.ToInt32(tbmx.Rows[i]["ydwbl"]), Convert.ToInt32(tbmx.Rows[i]["js"]), Convert.ToDecimal(tbmx.Rows[i]["je"]) * (-1),
                    Convertor.IsNull(tbmx.Rows[i]["tjdxmdm"], ""), Convert.ToInt64(tbmx.Rows[i]["xmid"]), new Guid(Convertor.IsNull(tbmx.Rows[i]["hjmxid"], Guid.Empty.ToString())),
                    Convertor.IsNull(tbmx.Rows[i]["gjbm"], ""), Convert.ToInt32(tbmx.Rows[i]["bzby"]), Convert.ToInt16(tbmx.Rows[i]["bpsbz"]), new Guid(Convertor.IsNull(tbmx.Rows[i]["pshjmxid"], Guid.Empty.ToString())),
                    Convert.ToDecimal(tbmx.Rows[i]["yl"]) * (-1), Convertor.IsNull(tbmx.Rows[i]["yldw"], ""), "", 0, 1, "", 0, 0, new Guid(tbmx.Rows[i]["cfmxid"].ToString()),
                    Convert.ToDecimal(tbmx.Rows[i]["pfj"]), Convert.ToDecimal(tbmx.Rows[i]["pfje"]) * (-1), 0, out NewCfmxid, out err_code, out err_text, _DataBase);
                if (NewCfmxid == Guid.Empty || err_code != 0) throw new Exception(err_text);
            }

            //更新收费状态
            int Nrows = 0;
            mz_cf.UpdateCfsfzt("('" + Newcfid.ToString() + "')", Convert.ToInt32(TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId.ToString()), TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name, sdate, sfck, 0, fph, NewFpid, out Nrows, out err_code, out err_text, _DataBase);
            if (Nrows != 1) throw new Exception("在更新退费处方的收费状态时,没有更新到处方头表,请和管理员联系");

        }
       
        /// <summary>
        /// 修改处方备注
        /// </summary>
        /// <param name="hjid"></param>
        /// <param name="_DataBase"></param>
        public static void UpdateCfZyBz(string hjid, string BZ, RelationalDatabase _DataBase)
        {
            string ssql = "update mz_hjb set BZ='" + BZ + "' where hjid='" + hjid + "' and BSCBZ=0 and BSFBZ=0";
            _DataBase.DoCommand(ssql);
        }


        public static DataRow GetCfxx(string hjid, RelationalDatabase _DataBase)
        {
            string sql = "select * from mz_hjb where hjid='" + hjid + "' and BSCBZ=0";
            return _DataBase.GetDataRow(sql);
        }
    }
}
