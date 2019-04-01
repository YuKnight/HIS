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
    public class jc_mb
    {


        public static void SaveMb(Guid mbid, long jgbm, string mbmc, string pym, string wbm, string bz, int mbjb, int ksdm, int ysdm, int zxks, string djsj, int djy, string fid, out Guid NewMbid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[16];

                parameters[0].Text = "@mbid";
                parameters[0].Value = mbid;

                parameters[1].Text = "@jgbm";
                parameters[1].Value = jgbm;

                parameters[2].Text = "@mbmc";
                parameters[2].Value = mbmc;

                parameters[3].Text = "@pym";
                parameters[3].Value = pym;

                parameters[4].Text = "@wbm";
                parameters[4].Value = wbm;

                parameters[5].Text = "@bz";
                parameters[5].Value = bz;

                parameters[6].Text = "@mbjb";
                parameters[6].Value = mbjb;

                parameters[7].Text = "@ksdm";
                parameters[7].Value = ksdm;

                parameters[8].Text = "@ysdm";
                parameters[8].Value = ysdm;

                parameters[9].Text = "@zxks";
                parameters[9].Value = zxks;

                parameters[10].Text = "@djsj";
                parameters[10].Value = djsj;

                parameters[11].Text = "@djy";
                parameters[11].Value = djy;

                parameters[12].Text = "@fid";
                parameters[12].Value = fid;

                parameters[13].Text = "@NewMbid";
                parameters[13].ParaDirection = ParameterDirection.Output;
                parameters[13].DataType = System.Data.DbType.Guid;
                parameters[13].ParaSize = 100;

                parameters[14].Text = "@err_code";
                parameters[14].ParaDirection = ParameterDirection.Output;
                parameters[14].DataType = System.Data.DbType.Int32;
                parameters[14].ParaSize = 100;

                parameters[15].Text = "@err_text";
                parameters[15].ParaDirection = ParameterDirection.Output;
                parameters[15].ParaSize = 100;


                _DataBase.DoCommand("SP_JC_CFMB", parameters, 30);
                NewMbid = new Guid(Convertor.IsNull(parameters[13].Value, Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[14].Value);
                err_text = Convert.ToString(parameters[15].Value);

                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                string _bz = "";
                if (mbid == Guid.Empty)
                    _bz = Fun.SeekEmpName(djy, _DataBase) + " 新增模板 " + mbmc;
                else
                    _bz = Fun.SeekEmpName(djy, _DataBase) + " 修改模板 " + mbmc;

                ts.Save_log(ts_HospData_Share.czlx.jc_处方模板, _bz, "jc_cfmb", "mbxh", NewMbid.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, 0, -999, "", out log_djid, _DataBase);


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }



        }


        public static void SaveMbmx(Guid mbmxid, Guid mbid, long xmid, int xmly, decimal jl, string jldw, int jldwid, int dwlx, int yf, int pc, string zt, decimal ts, int fzxh, int pxxh, int bzby, int cjid, int js, out Guid NewMbmxid, out int err_code, out string err_text, Guid cfxh, int zxks, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[22];

                parameters[0].Text = "@mbmxid";
                parameters[0].Value = mbmxid;

                parameters[1].Text = "@mbid";
                parameters[1].Value = mbid;

                parameters[2].Text = "@xmid";
                parameters[2].Value = xmid;

                parameters[3].Text = "@xmly";
                parameters[3].Value = xmly;

                parameters[4].Text = "@jl";
                parameters[4].Value = jl;

                parameters[5].Text = "@jldw";
                parameters[5].Value = jldw;

                parameters[6].Text = "@jldwid";
                parameters[6].Value = jldwid;

                parameters[7].Text = "@dwlx";
                parameters[7].Value = dwlx;

                parameters[8].Text = "@yf";
                parameters[8].Value = yf;

                parameters[9].Text = "@pc";
                parameters[9].Value = pc;

                parameters[10].Text = "@zt";
                parameters[10].Value = zt;

                parameters[11].Text = "@ts";
                parameters[11].Value = ts;

                parameters[12].Text = "@fzxh";
                parameters[12].Value = fzxh;

                parameters[13].Text = "@pxxh";
                parameters[13].Value = pxxh;

                parameters[14].Text = "@bzby";
                parameters[14].Value = bzby;

                parameters[15].Text = "@cjid";
                parameters[15].Value = cjid;

                parameters[16].Text = "@js";
                parameters[16].Value = js;

                parameters[17].Text = "@NewMbmxid";
                parameters[17].ParaDirection = ParameterDirection.Output;
                parameters[17].DataType = System.Data.DbType.Guid;
                parameters[17].ParaSize = 100;

                parameters[18].Text = "@err_code";
                parameters[18].ParaDirection = ParameterDirection.Output;
                parameters[18].DataType = System.Data.DbType.Int32;
                parameters[18].ParaSize = 100;

                parameters[19].Text = "@err_text";
                parameters[19].ParaDirection = ParameterDirection.Output;
                parameters[19].ParaSize = 100;

                parameters[20].Text = "@cfxh";
                parameters[20].Value = cfxh;

                parameters[21].Text = "@zxks";
                parameters[21].Value = zxks;

                _DataBase.DoCommand("SP_JC_CFMB_MX", parameters, 30);
                NewMbmxid = new Guid(Convertor.IsNull(parameters[17].Value, Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[18].Value);
                err_text = Convert.ToString(parameters[19].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }



        }
        //保存模板明细 Add By zp 2013-12-06 新增 套餐标志列 1套餐0非套餐
        public static void SaveMbmxInfo(Guid mbmxid, Guid mbid, long xmid, int xmly, decimal jl, string jldw, int jldwid, int dwlx, int yf, int pc, string zt, decimal ts, int fzxh, int pxxh, int bzby, int cjid, int js, out Guid NewMbmxid, Guid cfxh, int zxks, int tcflag, decimal sl, string dw, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = string.Empty;
                NewMbmxid = mbmxid;
                if (mbmxid == Guid.Empty)//新增
                {
                    NewMbmxid = Guid.NewGuid();
                    sql = @"insert into jc_cfmb_mx(mbmxxh,mbxh,xmid,xmly,jl,jldw,jldwid,dwlx,yf,pc,zt,ts,fzxh,pxxh,bzby,cjid,cfxh,zxks,JS,TC_FLAG,sl,dw)
	                 values('" + NewMbmxid + "','" + mbid + "'," + xmid + "," + xmly + "," + jl + ",'" + jldw + "'," + jldwid + "," + dwlx + "," + yf + "," + pc + ",'" + zt + "'," + ts + "," + fzxh + "," + pxxh + "," + bzby + "," + cjid + ",'" + cfxh + "'," + zxks + "," + js + "," + tcflag + "," + sl + ",'" + dw + "')";
                }
                else
                {
                    sql = @"update jc_cfmb_mx set xmid=" + xmid + ",xmly=" + xmly + ",jl=" + jl + ",jldw='" + jldw + "',jldwid=" + jldwid + ",dwlx=" + dwlx + @",
		             yf=" + yf + ",pc=" + pc + ",zt='" + zt + "',ts=" + ts + ",fzxh=" + fzxh + ",pxxh=" + pxxh + ",bzby=" + bzby + ",cjid=" + cjid + " ,cfxh='" + cfxh + "',zxks=" + zxks + ",JS=" + js + ",sl=" + sl + ",dw ='" + dw + "'" + @"
		             where mbmxxh='" + mbmxid + "'";
                }
                _DataBase.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw new Exception("保存模板明细出现异常!" + ea.Message);
            }
        }
        //保存模板明细 Add By zp 2013-12-06 新增 套餐标志列 1套餐0非套餐
        public static void SaveMbmxInfo(Guid mbmxid, Guid mbid, long xmid, int xmly, decimal jl, string jldw, int jldwid, int dwlx, int yf, int pc, string zt, decimal ts, int fzxh, int pxxh, int bzby, int cjid, int js, out Guid NewMbmxid, Guid cfxh, int zxks, int tcflag, decimal sl, string dw, string xmmc, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = string.Empty;
                NewMbmxid = mbmxid;
                if (mbmxid == Guid.Empty)//新增
                {
                    NewMbmxid = Guid.NewGuid();
                    sql = @"insert into jc_cfmb_mx(mbmxxh,mbxh,xmid,xmly,jl,jldw,jldwid,dwlx,yf,pc,zt,ts,fzxh,pxxh,bzby,cjid,cfxh,zxks,JS,TC_FLAG,sl,dw,xmmc)
	                 values('" + NewMbmxid + "','" + mbid + "'," + xmid + "," + xmly + "," + jl + ",'" + jldw + "'," + jldwid + "," + dwlx + "," + yf + "," + pc + ",'" + zt + "'," + ts + "," + fzxh + "," + pxxh + "," + bzby + "," + cjid + ",'" + cfxh + "'," + zxks + "," + js + "," + tcflag + "," + sl + ",'" + dw + "','" + xmmc + "')";
                }
                else
                {
                    sql = @"update jc_cfmb_mx set xmid=" + xmid + ",xmly=" + xmly + ",jl=" + jl + ",jldw='" + jldw + "',jldwid=" + jldwid + ",dwlx=" + dwlx + @",
		             yf=" + yf + ",pc=" + pc + ",zt='" + zt + "',ts=" + ts + ",fzxh=" + fzxh + ",pxxh=" + pxxh + ",bzby=" + bzby + ",cjid=" + cjid + " ,cfxh='" + cfxh + "',zxks=" + zxks + ",JS=" + js + ",sl=" + sl + ",dw ='" + dw + "'" + ",xmmc ='" + xmmc + "'" + @"
		             where mbmxxh='" + mbmxid + "'";
                }
                _DataBase.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw new Exception("保存模板明细出现异常!" + ea.Message);
            }
        }

        //保存模板明细 Add By zp 2013-12-06 新增 套餐标志列 1套餐0非套餐
        public static void SaveMbmxInfo(Guid mbmxid, Guid mbid, long xmid, int xmly, decimal jl, string jldw, int jldwid, int dwlx, int yf, int pc, string zt, decimal ts, int fzxh, int pxxh, int bzby, int cjid, int js, out Guid NewMbmxid, Guid cfxh, int zxks, int tcflag, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = string.Empty;
                NewMbmxid = mbmxid;
                if (mbmxid == Guid.Empty)//新增
                {
                    NewMbmxid = Guid.NewGuid();
                    sql = @"insert into jc_cfmb_mx(mbmxxh,mbxh,xmid,xmly,jl,jldw,jldwid,dwlx,yf,pc,zt,ts,fzxh,pxxh,bzby,cjid,cfxh,zxks,JS,TC_FLAG)
	                 values('" + NewMbmxid + "','" + mbid + "'," + xmid + "," + xmly + "," + jl + ",'" + jldw + "'," + jldwid + "," + dwlx + "," + yf + "," + pc + ",'" + zt + "'," + ts + "," + fzxh + "," + pxxh + "," + bzby + "," + cjid + ",'" + cfxh + "'," + zxks + "," + js + "," + tcflag + ")";
                }
                else
                {
                    sql = @"update jc_cfmb_mx set xmid=" + xmid + ",xmly=" + xmly + ",jl=" + jl + ",jldw='" + jldw + "',jldwid=" + jldwid + ",dwlx=" + dwlx + @",
		             yf=" + yf + ",pc=" + pc + ",zt='" + zt + "',ts=" + ts + ",fzxh=" + fzxh + ",pxxh=" + pxxh + ",bzby=" + bzby + ",cjid=" + cjid + " ,cfxh='" + cfxh + "',zxks=" + zxks + ",JS=" + js + @"
		             where mbmxxh='" + mbmxid + "'";
                }
                _DataBase.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw new Exception("保存模板明细出现异常!" + ea.Message);
            }
        }

        //删除模板头
        public static void Delete_Mb(Guid mbid, RelationalDatabase _DataBase)
        {
            string ssql = "update JC_CFMB set bscbz=1 where mbxh='" + mbid + "' and bscbz=0 ";
            int i = _DataBase.DoCommand(ssql);
            if (i == 0) throw new Exception("删除模板时出错，可能该模板已删除，请刷新后重试");

            Guid log_djid = Guid.Empty;
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            string _bz = "删除模板: mbid='" + mbid + "'";
            ts.Save_log(ts_HospData_Share.czlx.jc_处方模板, _bz, "jc_cfmb", "mbxh", mbid.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, 0, -999, "", out log_djid, _DataBase);


            SystemLog systemLog = new SystemLog(-1, TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId, TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId, "删除模板", "删除模板 mbid=" + mbid.ToString() + "", DateManager.ServerDateTimeByDBType(_DataBase), 0, "主机名：" + System.Environment.MachineName, 3);
            bool bok = systemLog.Save();
            systemLog = null;

        }

        //删除模板明细
        public static void Delete(Guid mbid, RelationalDatabase _DataBase)
        {
            string ssql = "delete JC_CFMB_mx where mbxh='" + mbid + "'";
            int i = _DataBase.DoCommand(ssql);

        }

        public static void UpdateMbmc(Guid mbid, string NewMbmc, RelationalDatabase _DataBase)
        {
            string ssql = "update jc_cfmb set mbmc='" + NewMbmc + "' where mbxh='" + mbid + "'";
            int ii = _DataBase.DoCommand(ssql);
            if (ii == 0) throw new Exception("没有更新到处方模板");

            Guid log_djid = Guid.Empty;
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            string _bz = "修改模板名称为:" + NewMbmc + "  mbid='" + mbid + "'";
            ts.Save_log(ts_HospData_Share.czlx.jc_处方模板, _bz, "jc_cfmb", "mbxh", mbid.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, 0, -999, "", out log_djid, _DataBase);

        }

        public static DataTable SelectyMb(int mbjb, int ksdm, int ysdm, RelationalDatabase _DataBase)
        {

            string ssql = @"select  mbmc 模板名称,dbo.fun_getdeptname(zxks) 执行科室,(case mbjb when 0 then '院级'
                            when 1 then '科级' when 2 then '个人'  else '' end) 级别,mbid from JC_CFMB 
                           where  mbjb=" + mbjb + " and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and bscbz=0  ";
            if (mbjb == 1)
                ssql = ssql + " and ksdm=" + ksdm + "";
            if (mbjb == 2)
                ssql = ssql + " and ysdm=" + ysdm + "";
            ssql = ssql + " order by mbjb,mbmc";
            return _DataBase.GetDataTable(ssql);

        }

        //读取某个模板
        public static DataTable SelectyMbmx(Guid mbid, long jgbm, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "@mbid";
                parameters[0].Value = mbid;
                //add by wangzhi 2010-11-15 为解决模板明细执行科室问题，增加存储过程参数,
                //如果设置了本机构的执行科室，则取本机构的执行科室，否则取模板设置中的执行科室
                parameters[1].Text = "@jgbm";
                parameters[1].Value = jgbm;
                //end
                DataTable dt = _DataBase.GetDataTable("SP_JC_CFMB_SELECT", parameters, 30);
                return dt;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
        //Add by zp 2013-12-14 重载 新增当前开单科室id
        public static DataTable SelectyMbmx(Guid mbid, long jgbm, int deptid, RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable(); 
            try
            {
                if (_DataBase == null) throw new Exception("DB对象为空!");
                #region 已经屏蔽
//                string sql = @" SELECT * FROM (    
//                 select '' 序号,cast(0 as smallint) 选择 ,yppm+'  '+ypgg as 医嘱内容,cast(cast(jl as float) as varchar(30)) 剂量,  
//                 jldw 剂量单位,rtrim(dbo.Fun_getFreqName(pc)) 频次,dbo.fun_getUsageName(yf) 用法,ts 天数,b.zt 嘱托,  
//                 dbo.fun_getdeptname(zxks) 执行科室,lsj 单价,(case JS when 0 then '1' else cast(js as varchar(10) ) END)  剂数, 
//                 B.cfxh as cfxh,jldwid 剂量单位id,dwlx,cast(pc as varchar(20)) 频次id,cast(yf as varchar(20)) 用法ID,    
//                 xmid 项目ID,bzby 自备药,fzxh 处方分组序号,pxxh 排序序号,zxks 执行科室id,xmly 项目来源,b.CJID,
//                 c.STATITEM_CODE 统计大项目
//                 from jc_cfmb a  
//                 inner join jc_cfmb_mx b on a.mbxh=b.mbxh   
//                 inner join yp_ypggd c on b.xmid=c.ggid   
//                 left join yp_ypcjd d on b.cjid=d.cjid
//                 where a.mbxh='"+mbid+@"' and xmly=1 and zxks not in(select ZXKSID from JC_KDKSXZ where KDKSID="+deptid+@") 
//                 union all     
//                 select '' 序号,cast(0 as smallint) 选择, order_name as 医嘱内容,cast(cast(jl as float) as varchar(30)) 剂量,  
//                 jldw 剂量单位,rtrim(dbo.Fun_getFreqName(pc)) 频次,dbo.fun_getUsageName(yf) 用法,ts 天数,zt 嘱托,  
//                 dbo.fun_getdeptname(case when dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks) end) as 执行科室,  
//                 price 单价,(case JS when 0 then '1' else cast(js as varchar(10) ) END)  剂数, 
//                 B.cfxh as cfxh,jldwid 剂量单位id,dwlx,cast(pc as varchar(20)) 频次id,cast(yf as varchar(20)) 用法ID,    
//                 xmid 项目ID,bzby 自备药,fzxh 处方分组序号,pxxh 排序序号,(case when dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks) end ) as 执行科室id,
//                 xmly 项目来源,b.cjid,'' 统计大项目
//                 from jc_cfmb a  inner join jc_cfmb_mx b on a.mbxh=b.mbxh  
//                 inner join jc_hoitemdiction c on b.xmid=c.order_id  
//                 left join (select jgbm,hoitem_id,price from jc_hoi_hdi a inner join jc_hsitemprice b on a.hditem_id=b.hsitemid and tc_flag=0 
//                            union  all  
//                            select jgbm,hoitem_id,price from jc_hoi_hdi a inner join jc_tcprice b on a.hditem_id=b.tcid and tc_flag=1 
//                           ) d on c.order_id=d.hoitem_id and a.jgbm=d.jgbm    
//                 where  a.mbxh='"+mbid+@"' and xmly=2  and b.zxks not in(select ZXKSID from JC_KDKSXZ where KDKSID="+deptid+@")  
//                 union all 
//                 select '' 序号,cast(0 as smallint) 选择, b.xmmc as 医嘱内容,cast(cast(jl as float) as varchar(30)) 剂量,  
//                 jldw 剂量单位,rtrim(dbo.Fun_getFreqName(pc)) 频次,dbo.fun_getUsageName(yf) 用法,ts 天数,zt 嘱托,  
//                 dbo.fun_getdeptname(case when dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks) end) as 执行科室,  
//                 price 单价,cast(js as varchar(10)) 剂数,B.cfxh as cfxh,jldwid 剂量单位id,dwlx,cast(pc as varchar(20)) 频次id,
//                 cast(yf as varchar(20)) 用法ID,xmid 项目ID,bzby 自备药,fzxh 处方分组序号,pxxh 排序序号,    
//                 (case when dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks) end ) as 执行科室id,
//                 xmly 项目来源,b.cjid,'' 统计大项目
//                 from jc_cfmb a  
//                 inner join jc_cfmb_mx b on a.mbxh=b.mbxh  and b.XMID=-1
//                 left join jc_hoitemdiction c on b.xmid=c.order_id  
//                 left join (select jgbm,hoitem_id,price from jc_hoi_hdi a inner join jc_hsitemprice b on a.hditem_id=b.hsitemid and tc_flag=0 
//                            union all  
//                            select jgbm,hoitem_id,price from jc_hoi_hdi a inner join jc_tcprice b on a.hditem_id=b.tcid and tc_flag=1  
//                           )  d on c.order_id=d.hoitem_id and a.jgbm=d.jgbm 
//                 where  a.mbxh='"+mbid+@"' and xmly=2 and b.XMID=-1 and b.zxks not in(select ZXKSID from JC_KDKSXZ where KDKSID="+deptid+@")  
//                 ) A ORDER BY cfxh,排序序号 ";
                #endregion
                //只有xmly=2 是项目的才加了 科室限制条件
                string sql = @"select * from 
                (
              select '' 序号,cast(0 as smallint) 选择 ,yppm+'  '+ypgg as 医嘱内容,cast(cast(jl as float) as varchar(30)) 剂量,  
jldw 剂量单位,rtrim(dbo.Fun_getFreqName(pc)) 频次,dbo.fun_getUsageName(yf) 用法,ts 天数,b.zt 嘱托,  
  
lsj 单价,(case JS when 0 then '1' else cast(js as varchar(10) ) END)  剂数, 
sl 总量,DW 单位, dbo.fun_getdeptname(zxks) 执行科室, 
B.cfxh as cfxh,jldwid 剂量单位id,dwlx,    
 cast(pc as varchar(20)) 频次id,cast(yf as varchar(20)) 用法ID,    
xmid 项目ID,bzby 自备药,    
 fzxh 处方分组序号,pxxh 排序序号,    
 zxks 执行科室id,xmly 项目来源    
 ,b.cjid,c.STATITEM_CODE 统计大项目,a.bz 
  from jc_cfmb a  inner join jc_cfmb_mx b on a.mbxh=b.mbxh   
 inner join yp_ypggd c on b.xmid=c.ggid   left join yp_ypcjd d on b.cjid=d.cjid
 where  a.mbxh='" + mbid + @"' and xmly=1  
 union all     
  select '' 序号,cast(0 as smallint) 选择, order_name as 医嘱内容,cast(cast(jl as float) as varchar(30)) 剂量,  
jldw 剂量单位,rtrim(dbo.Fun_getFreqName(pc)) 频次,dbo.fun_getUsageName(yf) 用法,ts 天数,zt 嘱托,  
 
price 单价,(case JS when 0 then '1' else cast(js as varchar(10) ) END)  剂数, 
sl 总量,DW 单位, dbo.fun_getdeptname(case when dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks) end) as 执行科室, 
B.cfxh as cfxh,jldwid 剂量单位id,dwlx,    
 cast(pc as varchar(20)) 频次id,cast(yf as varchar(20)) 用法ID,    
xmid 项目ID,bzby 自备药,    
 fzxh 处方分组序号,pxxh 排序序号,    
(case when dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks) end ) as 执行科室id,
xmly 项目来源 ,    
b.cjid,'' 统计大项目 ,a.bz 
  from jc_cfmb a  inner join jc_cfmb_mx b on a.mbxh=b.mbxh  
 inner join jc_hoitemdiction c on b.xmid=c.order_id  
    left join (  
     select jgbm,hoitem_id,price from jc_hoi_hdi a inner join jc_hsitemprice b on a.hditem_id=b.hsitemid and tc_flag=0 union   
     all  
    select jgbm,hoitem_id,price from jc_hoi_hdi a inner join jc_tcprice b on a.hditem_id=b.tcid and tc_flag=1  
   )  d on c.order_id=d.hoitem_id and a.jgbm=d.jgbm    
 where  a.mbxh='" + mbid + @"' and xmly=2    and b.zxks not in(select ZXKSID from JC_KDKSXZ where KDKSID=" + deptid + @")  
 
 union all 
   select '' 序号,cast(0 as smallint) 选择, b.xmmc as 医嘱内容,cast(cast(jl as float) as varchar(30)) 剂量,  
jldw 剂量单位,rtrim(dbo.Fun_getFreqName(pc)) 频次,dbo.fun_getUsageName(yf) 用法,ts 天数,zt 嘱托,  
 
price 单价,cast(js as varchar(10)) 剂数,  
sl 总量,DW 单位,
dbo.fun_getdeptname(case when dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks) end) as 执行科室, 
B.cfxh as cfxh,jldwid 剂量单位id,dwlx,    
 cast(pc as varchar(20)) 频次id,cast(yf as varchar(20)) 用法ID,    
xmid 项目ID,bzby 自备药,    
 fzxh 处方分组序号,pxxh 排序序号,    
(case when dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks) end ) as 执行科室id,
xmly 项目来源 ,    
b.cjid,'' 统计大项目,a.bz   
  from jc_cfmb a  inner join jc_cfmb_mx b on a.mbxh=b.mbxh  and b.XMID=-1  and b.zxks not in(select ZXKSID from JC_KDKSXZ where KDKSID=" + deptid + @")  
 left join jc_hoitemdiction c on b.xmid=c.order_id  
    left join (  
     select jgbm,hoitem_id,price from jc_hoi_hdi a inner join jc_hsitemprice b on a.hditem_id=b.hsitemid and tc_flag=0 union   
     all  
    select jgbm,hoitem_id,price from jc_hoi_hdi a inner join jc_tcprice b on a.hditem_id=b.tcid and tc_flag=1  
   )  d on c.order_id=d.hoitem_id and a.jgbm=d.jgbm    
 where  a.mbxh='" + mbid + @"'  and xmly=2 and b.XMID=-1  and b.zxks not in(select ZXKSID from JC_KDKSXZ where KDKSID=" + deptid + @")  
 
 --增加外来药品
 union all
  select '' 序号,cast(0 as smallint) 选择, b.xmmc as 医嘱内容,cast(cast(jl as float) as varchar(30)) 剂量,  
jldw 剂量单位,rtrim(dbo.Fun_getFreqName(pc)) 频次,dbo.fun_getUsageName(yf) 用法,ts 天数,zt 嘱托,  
 
price 单价,cast(js as varchar(10)) 剂数, sl 总量,DW 单位, 
dbo.fun_getdeptname(case when dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks) end) as 执行科室, 
B.cfxh as cfxh,jldwid 剂量单位id,dwlx,    
 cast(pc as varchar(20)) 频次id,cast(yf as varchar(20)) 用法ID,    
xmid 项目ID,bzby 自备药,    
 fzxh 处方分组序号,pxxh 排序序号,    
(case when dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks) end ) as 执行科室id,
xmly 项目来源 ,    
b.cjid ,'' 统计大项目 ,a.bz 
  from jc_cfmb a  inner join jc_cfmb_mx b on a.mbxh=b.mbxh  and b.XMID=-1
 left join jc_hoitemdiction c on b.xmid=c.order_id  
    left join (  
     select jgbm,hoitem_id,price from jc_hoi_hdi a inner join jc_hsitemprice b on a.hditem_id=b.hsitemid and tc_flag=0 union   
     all  
    select jgbm,hoitem_id,price from jc_hoi_hdi a inner join jc_tcprice b on a.hditem_id=b.tcid and tc_flag=1  
   )  d on c.order_id=d.hoitem_id and a.jgbm=d.jgbm    
 where  a.mbxh='" + mbid + @"'  and xmly=1 and b.XMID=-1 and b.CJID=-1 and b.ZXKS=-1
                 ) h
                order by CFXH, h.排序序号    ";
                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }
        
        //获取单个收费项目模板 Add by zp 2013-11-19
        public static DataTable GetMzsfMbmx(Guid mbid,long jgbm, RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"select * from 
                (
                select '' 序号,cast(0 as smallint) 选择, c.S_YPPM as 医嘱内容,cast(cast(jl as float) as varchar(30)) 剂量,  
                jldw 剂量单位,rtrim(dbo.Fun_getFreqName(pc)) 频次,dbo.fun_getUsageName(yf) 用法,ts 天数,zt 嘱托, sl 总量,DW 单位, 
                dbo.fun_getdeptname(case when dbo.Fun_GetOrderExecDept(xmid,1000,b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid,1000,b.zxks) end) as 执行科室,  
                '' 单价,cast(js as varchar(10)) 剂数,  
                B.cfxh as cfxh,jldwid 剂量单位id,dwlx,    
                 cast(pc as varchar(20)) 频次id,cast(yf as varchar(20)) 用法ID,    
                xmid 项目ID,bzby 自备药,    
                 fzxh 处方分组序号,pxxh 排序序号,    
                (case when dbo.Fun_GetOrderExecDept(xmid,1000,b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid,1000,b.zxks) end ) as 执行科室id,
                xmly 项目来源 ,    
                b.cjid,'' 统计大项目,b.PXXH,tc_flag,a.bz
                from jc_cfmb a  
                inner join jc_cfmb_mx b on a.mbxh=b.mbxh  and isnull(b.tc_flag,0)=0
                left join YP_YPCJD c on b.XMID=c.CJID
                where a.mbxh='" + mbid + @"' and xmly in(1,2,3)
                union all
                 select '' 序号,cast(0 as smallint) 选择, c.ITEM_NAME as 医嘱内容,cast(cast(jl as float) as varchar(30)) 剂量,  
                jldw 剂量单位,rtrim(dbo.Fun_getFreqName(pc)) 频次,dbo.fun_getUsageName(yf) 用法,ts 天数,zt 嘱托, sl 总量,DW 单位, 
                dbo.fun_getdeptname(case when dbo.Fun_GetOrderExecDept(xmid," + jgbm + @",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks) end) as 执行科室,  
                '' 单价,cast(js as varchar(10)) 剂数,  
                B.cfxh as cfxh,jldwid 剂量单位id,dwlx,    
                 cast(pc as varchar(20)) 频次id,cast(yf as varchar(20)) 用法ID,    
                xmid 项目ID,bzby 自备药,    
                 fzxh 处方分组序号,pxxh 排序序号,    
                (case when dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid,"+jgbm+ @",b.zxks) end ) as 执行科室id,
                xmly 项目来源 ,    
                b.cjid,'' 统计大项目,b.PXXH,tc_flag,a.bz
                from jc_cfmb a  
                inner join jc_cfmb_mx b on a.mbxh=b.mbxh  and isnull(b.tc_flag,0)=0
                left join jc_hsitemdiction c on b.XMID=c.ITEM_ID
                where a.mbxh='" + mbid + @"'  and c.ITEM_ID is not null 
               union all
                select '' 序号,cast(0 as smallint) 选择, c.ITEM_NAME as 医嘱内容,cast(cast(jl as float) as varchar(30)) 剂量,  
                jldw 剂量单位,rtrim(dbo.Fun_getFreqName(pc)) 频次,dbo.fun_getUsageName(yf) 用法,ts 天数,zt 嘱托,sl 总量,DW 单位,  
                dbo.fun_getdeptname(case when dbo.Fun_GetOrderExecDept(xmid," + jgbm+",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks) end) as 执行科室,  
                '' 单价,cast(js as varchar(10)) 剂数,  
                B.cfxh as cfxh,jldwid 剂量单位id,dwlx,    
                 cast(pc as varchar(20)) 频次id,cast(yf as varchar(20)) 用法ID,    
                xmid 项目ID,bzby 自备药,    
                 fzxh 处方分组序号,pxxh 排序序号,    
                (case when dbo.Fun_GetOrderExecDept(xmid,"+jgbm+@",b.zxks)=0 then b.zxks else dbo.Fun_GetOrderExecDept(xmid,"+jgbm+ @",b.zxks) end ) as 执行科室id,
                xmly 项目来源 ,    
                b.cjid,'' 统计大项目,b.PXXH,tc_flag,a.bz
                from jc_cfmb a  
                inner join jc_cfmb_mx b on a.mbxh=b.mbxh and b.tc_flag<>0
                inner join JC_TC c on b.XMID=c.ITEM_ID
                 where a.mbxh='" + mbid+@"'
                 ) h
                order by CFXH, h.pxxh    ";
               
                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }
        
        /// <summary>
        /// 查询住院处方模板
        /// </summary>
        /// <param name="ysid"></param>
        /// <param name="ksid"></param>
        /// <param name="mbjb"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable SelectZyCfMb(int ysid, int ksid, int mbjb, RelationalDatabase _DataBase)
        {
            string sql = @"select  mbmc 模板名称,pym,(case mbjb when 0 then '院级'
                            when 1 then '科级' when 2 then '个人'  else '' end) 级别,mbid as mbid,fid,BTree,bz from JC_ZYCFMB 
                           where bscbz=0 ";
            return _DataBase.GetDataTable(sql);
        }
        /// <summary>
        /// 中药处方模板
        /// </summary>
        /// <param name="mbid"></param>
        /// <param name="jgbm"></param>
        /// <param name="mbmc"></param>
        /// <param name="pym"></param>
        /// <param name="wbm"></param>
        /// <param name="bz"></param>
        /// <param name="mbjb"></param>
        /// <param name="ksdm"></param>
        /// <param name="ysdm"></param>
        /// <param name="djsj"></param>
        /// <param name="djy"></param>
        /// <param name="fid"></param>
        /// <param name="NewMbid"></param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="_DataBase"></param>
        public static void SaveZyCfMb(Guid mbid, long jgbm, string mbmc, string pym, string wbm, string bz, int mbjb, int ksdm, int ysdm, string djsj, int djy, string fid, int Btree, ref Guid NewMbid, ref int err_code, ref string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[16];
                parameters[0].Text = "@mbid";
                parameters[0].Value = mbid;

                parameters[1].Text = "@jgbm";
                parameters[1].Value = jgbm;

                parameters[2].Text = "@mbmc";
                parameters[2].Value = mbmc;

                parameters[3].Text = "@pym";
                parameters[3].Value = pym;

                parameters[4].Text = "@wbm";
                parameters[4].Value = wbm;

                parameters[5].Text = "@bz";
                parameters[5].Value = bz;

                parameters[6].Text = "@mbjb";
                parameters[6].Value = mbjb;

                parameters[7].Text = "@ksdm";
                parameters[7].Value = ksdm;

                parameters[8].Text = "@ysdm";
                parameters[8].Value = ysdm;


                parameters[9].Text = "@djsj";
                parameters[9].Value = djsj;

                parameters[10].Text = "@djy";
                parameters[10].Value = djy;

                parameters[11].Text = "@fid";
                parameters[11].Value = fid;

                parameters[12].Text = "@BTree";
                parameters[12].Value = Btree;

                parameters[13].Text = "@NewMbid";
                parameters[13].ParaDirection = ParameterDirection.Output;
                parameters[13].DataType = System.Data.DbType.Guid;
                parameters[13].ParaSize = 100;

                parameters[14].Text = "@err_code";
                parameters[14].ParaDirection = ParameterDirection.Output;
                parameters[14].DataType = System.Data.DbType.Int32;
                parameters[14].ParaSize = 100;

                parameters[15].Text = "@err_text";
                parameters[15].ParaDirection = ParameterDirection.Output;
                parameters[15].ParaSize = 100;


                _DataBase.DoCommand("SP_JC_ZYCFMB", parameters, 30);
                NewMbid = new Guid(Convertor.IsNull(parameters[13].Value, Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[14].Value);
                err_text = Convert.ToString(parameters[15].Value);

            }
            catch (Exception ex)
            {
                throw new System.Exception("保存中药处方模板出错:原因:" + ex.Message);
            }
        }

        public static DataRow SelectZyMbBz(string mbid, RelationalDatabase _DataBase)
        {
            string sql = "select * from jc_zycfmb where MBID='" + mbid + "' and BSCBZ=0";
            return _DataBase.GetDataRow(sql);
        }


        public static void DeleteZyCfMb(string mbid, RelationalDatabase _DataBase)
        {
            string sql = "update jc_zycfmb set bscbz=1 where mbid='" + mbid + "' and BSCBZ=0";
            _DataBase.DoCommand(sql);
        }

        public static void UpdateZyCfMbMc(string mbid, string mbmc, RelationalDatabase _DataBase)
        {
            string sql = "update jc_zycfmb set mbmc='" + mbmc + "' where mbid='" + mbid + "'";
            _DataBase.DoCommand(sql);
        }
    }
}

