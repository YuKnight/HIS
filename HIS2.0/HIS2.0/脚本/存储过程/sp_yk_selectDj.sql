IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_yk_selectDj]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_yk_selectDj]
GO
CREATE PROCEDURE [dbo].[sp_yk_selectDj]
(
 	@ywlx char(3),
	@wldw int ,
	@dtp1 varchar(30),
	@dtp2 varchar(30),
	@djh bigint,
	@fph varchar(50),
	@shdh varchar(50),
	@shbz int,
	@deptid int,
	@functionname varchar(30),
	@P_deptid int
)
as



 declare @ss varchar(8000);


 --药品入库或退货
 if @functionname='Fun_ts_yk_cgrk' or @functionname='Fun_ts_yk_cgrk_th' 
  or @functionname='Fun_ts_yk_cgrk_yf' or @functionname='Fun_ts_yk_cgrk_th_yf'
  or @functionname='Fun_ts_yk_cgrk_cx' or @functionname='Fun_ts_yk_cgrk_th_cx' 
  or @functionname='Fun_ts_yk_cgrk_yf_cx' or @functionname='Fun_ts_yk_cgrk_th_yf_cx'
 set @ss='select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,RQ 单据日期,dbo.FUN_YP_GHDW(wldw) 供货单位,dbo.FUN_YP_YWY(jsr) 业务员,
        shdh 送货单号,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,fph 发票号,fprq 发票日期, cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,'+
	'dbo.fun_getempname(djy) 登记员,shrq as 审核时间,dbo.fun_getempname(SHy) 审核员,bz 备注,id 
	 
	,( select cast(sum(jhje*fkbl) as decimal(15,3)) from yk_djmx where djid= a.id ) 付款金额
	from VI_YK_DJ a where ywlx='+@ywlx+'  and shbz='+cast(@shbz as char(10))


--药库采购入库（审核入库） 
if @functionname='Fun_ts_yk_cgrk_h' or @functionname='Fun_ts_yk_cgrk_th_h' 
begin 
	if @shbz =0
	 set @ss='select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,RQ 单据日期,dbo.FUN_YP_GHDW(wldw) 供货单位,dbo.FUN_YP_YWY(jsr) 业务员,
        shdh 送货单号,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,fph 发票号,fprq 发票日期, cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,'+
		'dbo.fun_getempname(djy) 登记员,shrq as 审核时间,dbo.fun_getempname(SHy) 审核员,bz 备注,id 
		,( select cast(sum(jhje*fkbl) as decimal(15,3)) from yk_djmx where djid= a.id ) 付款金额
		from yk_dj_temp a where ywlx='+@ywlx+'  and shbz='+cast(@shbz as char(10))
	else
		 set @ss='select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,RQ 单据日期,dbo.FUN_YP_GHDW(wldw) 供货单位,dbo.FUN_YP_YWY(jsr) 业务员,
        shdh 送货单号,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,fph 发票号,fprq 发票日期, cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,'+
		'dbo.fun_getempname(djy) 登记员,shrq as 审核时间,dbo.fun_getempname(SHy) 审核员,bz 备注,id 
		,( select cast(sum(jhje*fkbl) as decimal(15,3)) from yk_djmx where djid= a.id ) 付款金额
		from VI_YK_DJ a where ywlx='+@ywlx+'  and shbz='+cast(@shbz as char(10))
end 

 --药房退库或期初录入或其他入库
 if   @functionname='Fun_ts_yk_ypptrk_qc'  or  @functionname='Fun_ts_yk_ypptrk_qc_cx' 
        set @ss=' select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,RQ 单据日期,'''' 药房名称,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(djy) 登记员,shrq as 审核时间,dbo.Fun_getempname(SHy) 审核员,bz 备注,id from VI_YK_DJ a
		where  shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''  ';

 if @functionname='Fun_ts_yk_ypptrk_tk' or  @functionname='Fun_ts_yk_ypptrk_tk_cx' 
or @functionname='Fun_ts_yk_ypptrk_drk' or @functionname='Fun_ts_yk_ypptrk_drk_cx'
         set @ss=' select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,RQ 单据日期,dbo.Fun_getdeptname(wldw) 药房名称,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(djy) 登记员,shrq as 审核时间,dbo.Fun_getempname(SHy) 审核员,bz 备注,id from VI_YK_DJ a
		where shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''  ';

 if   @functionname='Fun_ts_yk_ypptrk_qtrk'   or @functionname='Fun_ts_yk_ypptrk_qtrk_cx' 
        set @ss='select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,RQ 单据日期,dbo.fun_yp_ghdw(wldw) 药房名称,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(djy) 登记员,shrq as 审核时间,dbo.Fun_getempname(SHy) 审核员,bz 备注,id from VI_YK_DJ  a
		where shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''  ';

 
-- if @ywlx='003'  then
--        set @ss=' select 0 序号,djh 单据号 ,,,dbo.Fun_getdeptname(wldw) 目的科室,djRQ 请领日期,dbo.Fun_getempname(djy) 请领人,
--		shrq as 审核时间,dbo.Fun_getempname(SHr) 审核员,ckdh 审核单据号,bz 备注,id from yk_rksq
--		where deptid='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';
-- end if ;	
 
 --药品申领单
 if (@functionname='Fun_ts_yk_ypck' or @functionname='Fun_ts_yk_ypck_cx') and @shbz=0  
 begin
        set @ss=' select 0 序号,dbo.fun_getdeptname(wldw) 仓库名称,djh 申领单号,dbo.Fun_getdeptname(deptid) 申领科室,djRQ 申领时间,dbo.Fun_getempname(djy) 申领人,
		bz 备注,id,djh 单据号,deptid from yF_rksq a
		where  shbz='+cast(@shbz as char(10)) + ' ';
	if @wldw<>0 
		set @ss=@ss+' and deptid='+cast(@wldw as char(10))
	if @deptid>0
		set @ss=@ss+' and wldw='+cast(@deptid as char(10))
	else 
	   set @ss=@ss+' and wldw in( select deptid from yp_yjks_gx where (p_deptid='+cast(@p_deptid as varchar(20))+' or deptid='+cast(@p_deptid as varchar(20))+' ) ) '

	 exec(@ss)
	 print @ss
	return
 end
 --药品出库单
 if (@functionname='Fun_ts_yk_ypck' or @functionname='Fun_ts_yk_ypck_cx') and @shbz=1 
        set @ss=' select 0 序号,dbo.fun_getdeptname(a.deptid) 仓库名称,(case when a.bprint=1 then ''√'' else '''' end) 打印,a.djh 单据号,a.RQ 单据日期,dbo.Fun_getdeptname(a.wldw) 领药科室,a.sumjhje 进货金额,a.sumpfje 批发金额,a.sumlsje 零售金额,
		cast((cast(a.djrq AS char(10))+'' ''+convert(nvarchar,a.djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(a.djy) 登记员,a.shrq as 审核时间,dbo.Fun_getempname(a.SHy) 审核员,a.bz 备注,a.id,a.sqdh 申领单号,
		(case when b.shbz=1 then dbo.fun_getempname(b.shy)+ (dbo.Fun_GetDate(b.shrq)+'' ''+convert(nvarchar,b.shrq,108)) +''审核''  else ''未审核'' end)  接收状态 from VI_YK_DJ a 
		left join vi_yf_dj b  on a.id=b.ydjid
		where    a.shbz='+cast(@shbz as char(10)) + ' and a.ywlx='''+ @ywlx+''' ';
--出库调用采购入库单
 if (@functionname='Fun_ts_yk_ypck') and @shbz=2  
        set @ss=' select 0 序号,dbo.fun_getdeptname(a.deptid) 仓库名称,(case when a.bprint=1 then ''√'' else '''' end) 打印,a.djh 单据号,a.RQ 单据日期,dbo.fun_yp_ghdw(a.wldw) 供货单位,dbo.fun_yp_ywy(jsr) 业务员,a.sumjhje 进货金额,a.sumpfje 批发金额,a.sumlsje 零售金额,
		cast((cast(a.djrq AS char(10))+'' ''+convert(nvarchar,a.djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(a.djy) 登记员,a.shrq as 审核时间,dbo.Fun_getempname(a.SHy) 审核员,a.bz 备注,deptid,id from VI_YK_DJ a 
		where a.ywlx=''001'' ';
		
 --药品出库单临时保存 Add By Tany 2015-12-23
 if (@functionname='Fun_ts_yk_ypck' or @functionname='Fun_ts_yk_ypck_cx') and @shbz=3
        set @ss=' select 0 序号,dbo.fun_getdeptname(a.deptid) 仓库名称,(case when a.bprint=1 then ''√'' else '''' end) 打印,a.djh 单据号,a.RQ 单据日期,dbo.Fun_getdeptname(a.wldw) 领药科室,a.sumjhje 进货金额,a.sumpfje 批发金额,a.sumlsje 零售金额,
		cast((cast(a.djrq AS char(10))+'' ''+convert(nvarchar,a.djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(a.djy) 登记员,a.shrq as 审核时间,dbo.Fun_getempname(a.SHy) 审核员,a.bz 备注,a.id,a.sqdh 申领单号,
		''未审核'' 接收状态 from yk_dj_temp a 
		where    a.shbz=0 and a.ywlx='''+ @ywlx+''' ';
 
  --药品其他领药单
 if (@functionname='Fun_ts_yk_ypck_qtly' or @functionname='Fun_ts_yk_ypck_wyylyd' 
		or @functionname='Fun_ts_yk_ypck_qtly_cx' or @functionname='Fun_ts_yk_ypck_wyylyd_cx' ) and @shbz=1 
        set @ss=' select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,RQ 单据日期,dbo.Fun_getdeptname(wldw) 领药科室,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(djy) 登记员,shrq as 审核时间,dbo.Fun_getempname(SHy) 审核员,bz 备注,id,sqdh 申领单号 from VI_YK_DJ a
		where   shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';

--同级库存调出
if @functionname='Fun_ts_yk_ypck_dck'  or @functionname='Fun_ts_yk_ypck_dck_cx' 
        set @ss=' select 0 序号,dbo.fun_getdeptname(a.deptid) 仓库名称,(case when a.bprint=1 then ''√'' else '''' end) 打印,a.djh 单据号,a.RQ 单据日期,dbo.Fun_getdeptname(a.wldw) 领药科室,a.sumjhje 进货金额,a.sumpfje 批发金额,a.sumlsje 零售金额,
		cast((cast(a.djrq AS char(10))+'' ''+convert(nvarchar,a.djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(a.djy) 登记员,a.shrq as 审核时间,dbo.Fun_getempname(a.SHy) 审核员,a.bz 备注,a.id,a.sqdh 申领单号,
		(case when b.shbz=1 then dbo.fun_getempname(b.shy)+ (dbo.Fun_GetDate(b.shrq)+'' ''+convert(nvarchar,b.shrq,108)) +''审核''  else ''未审核'' end)  接收状态 from VI_YK_DJ a 
		left join vi_yk_dj b  on a.id=b.ydjid
		where    a.shbz='+cast(@shbz as char(10)) + ' and a.ywlx='''+ @ywlx+''' ';

 
   --门诊记账处方出库
 if @functionname='Fun_ts_yk_ypck_jzcfck'  or @functionname='Fun_ts_yk_ypck_jzcfck_cx'  
        set @ss=' select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,RQ 单据日期,dbo.Fun_getdeptname(wldw) 领药科室,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(djy) 登记员,shrq as 审核时间,dbo.Fun_getempname(SHy) 审核员,bz 备注,id,sqdh 申领单号 from VI_YK_DJ a
		where   shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';

 --发药处方补录
  if @functionname='Fun_ts_yk_ypck_cfbl' or @functionname='Fun_ts_yk_ypck_cfbl_cx' 
        set @ss='select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,RQ 单据日期,dbo.Fun_getdeptname(wldw) 领药科室,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(djy) 登记员,shrq as 审核时间,dbo.Fun_getempname(SHy) 审核员,bz 备注,id,sqdh 申领单号 from VI_YK_DJ  a
		where    shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';

 
 --药品调价单
  if @functionname='Fun_ts_yp_tj' or @functionname='Fun_ts_yp_tj_cx' 
  begin
        set @ss=' select 0 序号,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,ZXRQ 执行日期,TJWH 调价文号,
		DJRQ as 登记时间,dbo.Fun_getempname(djy) 登记员,bz 备注,id from yf_Tj  a
		where   WCBJ='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';
		if @shdh<>'' 
		  set @ss=@ss+' and tjwh like ''%'+rtrim(cast(@shdh as char(30)))+'%''';
		
  end

 
 --药品报损
 if @functionname='Fun_ts_yk_ypbs'  or @functionname='Fun_ts_yk_ypbs_cx' 
        set @ss=' select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,RQ 单据日期,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(djy) 登记员,dbo.fun_yp_bsyy(yydm) 原因,bz 备注,id from VI_YK_DJ a
		where   shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';

 	
 --药品报溢
 if @functionname='Fun_ts_yk_ypby' or @functionname='Fun_ts_yk_ypby_cx' 
        set @ss=' select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号,RQ 单据日期,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(djy) 登记员,dbo.fun_yp_yyyy(yydm) 原因,bz 备注,id from VI_YK_DJ  a
		where   shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';

 
 --盘点录入
 if @functionname='Fun_ts_yp_pdlr' or @functionname='Fun_ts_yp_pdlr_yf'
        set @ss=' select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,djh 单据号,DJRQ as 登记时间,dbo.Fun_getempname(djy) 登记员,
		shrq as 审核时间,dbo.Fun_getempname(SHy) 审核员,shdjh 审核单据号,bz 备注,id from yf_pdcs a
		where  shbz='+cast(@shbz as char(10)) + '  and bdelete=0 ';

 --盘点单
  if @functionname='Fun_ts_yp_pd' or @functionname='Fun_ts_yp_pd_yf' or
	 @functionname='Fun_ts_yp_pd_cx' or @functionname='Fun_ts_yp_pd_yf_cx'
        set @ss=' select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,djh 单据号,DJRQ as 审核时间,dbo.Fun_getempname(DJY) 审核员,id from yf_pd a where bdelete=0 ';


 if @deptid>0
   set @ss=@ss+' and a.deptid='+cast(@deptid as char(10)) 
 else
   set @ss=@ss+' and a.deptid in( select deptid from yp_yjks_gx where (p_deptid='+cast(@p_deptid as varchar(20))+' or deptid='+cast(@p_deptid as varchar(20))+' ) ) '

 if @wldw<>0  set @ss=@ss+' and a.wldw='+cast(@wldw as char(10))+' '   
 if rtrim(@dtp1)<>''  
     begin
		if @ywlx<>'005'
			set @ss=@ss+' and a.djrq>='''+@dtp1+' 00:00:00'' and a.djrq<='''+@dtp2+' 23:59:59'''
		else
			begin
				if @shbz=0
					set @ss=@ss+' and a.djrq>='''+@dtp1+' 00:00:00'' and a.djrq<='''+@dtp2+' 23:59:59'''
				else
					set @ss=@ss+' and a.zxrq>='''+@dtp1+' 00:00:00'' and a.zxrq<='''+@dtp2+' 23:59:59'''
			end
	 end
 if @djh<>0  set @ss=@ss+' and a.djh='+cast(@djh as char(20))+' '   
if rtrim(@fph)<>''  set @ss=@ss+' and a.fph='''+@fph+''' '   
 if rtrim(@shdh)<>''   and  @functionname<>'Fun_ts_yp_tj'  set @ss=@ss+' and shdh='''+@shdh+''' '   
-- if @shbz=1 
--   begin 
--	set @ss=@ss+' and shbz=1 '
--   end
-- else
--   begin
--        set @ss=@ss+' and shbz=0'
--   end
 --if @deptid<>0 and @functionname<>'Fun_ts_yk_ypck' and @shbz<>0   set @ss=@ss+' and deptid='+cast(@deptid as char(20))+' '        
 --  print @ss
 set @ss=@ss+' order by 单据号'
exec( @ss)





GO


