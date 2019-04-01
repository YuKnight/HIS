
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_selectDj' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_selectDj
GO
CREATE PROCEDURE sp_yf_selectDj
(
 	@ywlx char(3),
	@wldw int ,
	@dtp1 varchar(30),
	@dtp2 varchar(30),
	@djh bigint,
	@fph varchar(50),
	@shdh varchar(50),
	@shbz smallint,
	@deptid int,
	@functionname varchar(30),
	@P_deptid int
)
as
begin
 declare @ssql varchar(1000);

 --基本的SQL语名

 --药品入库或退货
 if @functionname='Fun_ts_yk_cgrk' or @functionname='Fun_ts_yk_cgrk_th'  or @functionname='Fun_ts_yk_cgrk_yf' or @functionname='Fun_ts_yk_cgrk_th_yf'
 set @ssql='select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,(case when bprint=1 then ''√'' else '''' end) 打印,djh 单据号 ,RQ 单据日期,dbo.FUN_YP_GHDW(wldw) 供货单位,dbo.FUN_YP_YWY(jsr) 业务员,
        shdh 送货单号,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,
        fph 发票号,fprq 发票日期,cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,'+
	'dbo.fun_getempname(djy) 登记员,shrq as 审核时间,dbo.fun_getempname(SHy) 审核员,bz 备注,id  
	
	        ,( select cast(sum(jhje*fkbl) as decimal(15,3)) from yf_djmx where djid= a.id ) 付款金额 
	        
	from VI_YF_DJ a where ywlx='+@ywlx+' and deptid='+cast(@deptid as char(10))+'  and shbz='+cast(@shbz as char(10))


 --药品入库或退货
----- if @functionname='Fun_ts_yf_yprk' or @functionname='Fun_ts_yf_yprk_th'  
-----        set @ssql=' select 0  序号,djh 单据号 ,RQ 单据日期,dbo.fun_yp_ghdw(wldw) 供货单位,FUN_YP_YWY(jsr) 业务员,
------        shdh 送货单号,fph 发票号,fprq 发票日期,(cast(djrq AS char(11)) + cast(djsj AS char(8))) as 登记时间,dbo.fun_getempname(djy) 登记员,shrq as 审核时间,dbo.fun_getempname(SHY) 审核员,bz 备注,id,ywlx from vi_yf_dj 
-----		where deptid='+cast(@deptid as char(10)) +' and shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';

 --药品采购单据审核
  if @functionname='Fun_ts_yf_yprk_sh'   
        set @ssql=' select 0  序号,(case when ywlx=''001'' then ''入库'' else ''退货'' end) 单据类型, djh 单据号 ,RQ 单据日期,dbo.fun_yp_ghdw(wldw) 供货单位,FUN_YP_YWY(jsr) 业务员,
        shdh 送货单号,fph 发票号,fprq 发票日期,(cast(djrq AS char(11)) + cast(djsj AS char(8))) as 登记时间,dbo.fun_getempname(djy) 登记员,
        shrq as 审核时间,dbo.fun_getempname(SHY) 审核员,bz 备注,id,ywlx 
        ,( select cast(sum(jhje*fkbl) as decimal(15,3)) from yf_djmx where djid= a.id ) 付款金额 
        from vi_yf_dj a
		where deptid='+cast(@deptid as char(10)) +' and shbz='+cast(@shbz as char(10)) + ' and ywlx in(''001'',''002'')';

 
  --药房入库单、期初录入、调入单、小药柜审核入库
 if @functionname='Fun_ts_yf_ypptrk_sh' or @functionname='Fun_ts_yf_ypptrk_drd'  or @functionname='Fun_ts_yf_ypptrk_xygrk' or @functionname='Fun_ts_yf_ypptrk_qc'  or @functionname='Fun_ts_yf_ypptrk_xygqcrk' 
        set @ssql=' select 0  序号,djh 单据号 ,RQ 单据日期,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,dbo.fun_getdeptname(wldw) 供货单位,
		(djrq+djsj) as 登记时间,dbo.fun_getempname(djy) 登记员,shrq as 审核时间,dbo.fun_getempname(SHY) 审核员,bz 备注,id from vi_yf_dj 
		where deptid='+cast(@deptid as char(10)) +' and shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';
 --其他入库
 if  @functionname='Fun_ts_yf_ypptrk_qtrk' 
        set @ssql=' select 0  序号,djh 单据号 ,RQ 单据日期,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,dbo.fun_yp_ghdw(wldw) 供货单位,
		(djrq+djsj) as 登记时间,dbo.fun_getempname(djy) 登记员,shrq as 审核时间,dbo.fun_getempname(SHY) 审核员,bz 备注,id from vi_yf_dj 
		where deptid='+cast(@deptid as char(10)) +' and shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';


 
 if @functionname='Fun_ts_yf_ypqlrk' or @functionname='Fun_ts_yf_ypqlrk_xyg'  
        set @ssql=' select 0  序号,djh 单据号 ,dbo.fun_getdeptname(wldw) 目的科室,djRQ 请领日期,dbo.fun_getempname(djy) 请领人,
		shrq as 审核时间,dbo.fun_getempname(SHR) 审核员,ckdh 审核单据号,bz 备注,id from YF_rksq
		where deptid='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';

 
 
 --药品调出单 、药品退库单\记账处方出库、发药处方补录
 if (@functionname='Fun_ts_yf_ypck' or @functionname='Fun_ts_yf_ypck_tk' or @functionname='Fun_ts_yf_ypck_qtly' or  @functionname='Fun_ts_yf_ypck_cfbl' or @functionname='Fun_ts_yf_ypck_xygck' or @functionname='Fun_ts_yf_ypck_wyylyd') and @shbz=1 
        set @ssql=' select 0  序号,djh 单据号 ,RQ 单据日期,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,dbo.fun_getdeptname(wldw) 往来科室,
		(djrq+djsj) as 登记时间,dbo.fun_getempname(djy) 登记员,a.shrq as 审核时间,dbo.fun_getempname(a.SHY) 审核员,bz 备注,id,'''' 申领单号 ,
		(case b.shbz when  1 then dbo.fun_getempname(b.shy)+ (dbo.Fun_GetDate(b.shrq)+'' ''+convert(nvarchar,b.shrq,108)) +''审核''  when 0 then ''未审核'' else '''' end)  接收状态
		from vi_yf_dj a
		left join (select shbz,shy,shrq,ydjid from vi_yf_dj union all select shbz,shy,shrq,ydjid from vi_yk_dj) b 
		on a.id=b.ydjid
		where  deptid='+cast(@deptid as char(10)) +' and  a.shbz='+cast(@shbz as char(10)) + ' and a.ywlx='''+ @ywlx+'''';


 
 --药品出库中的未审枋小药柜申请单
 if @functionname='Fun_ts_yf_ypck_xygck' and @shbz=0 
 begin
        set @ssql=' select 0  序号,djh 申领单号 ,dbo.fun_getdeptname(deptid) 申领科室,djRQ 申领时间,dbo.fun_getempname(djy) 申领人,
		bz 备注,A.id,djh 单据号,deptid from yF_rksq A  
		where WLDW='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and ywlx=''027'' ';
	if @wldw<>0 
	 set @ssql=@ssql+' and deptid='+cast(@wldw as char(10))
	 exec(@ssql)
	 return
 end
 
 --药品调价单
  if @functionname='Fun_ts_yf_yptj' 
  begin
        set @ssql=' select 0  序号,djh 单据号 ,ZXRQ 执行日期,TJWH 调价文号,
		djrq as 登记时间,dbo.fun_getempname(djy) 登记员,bz 备注,id from YF_Tj 
		where deptid='+cast(@deptid as char(10)) +' and  WCBJ='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';
		if @shdh<>'' 
		  set @ssql=@ssql+' and tjwh like ''%'+rtrim(cast(@shdh as char(30)))+'%''';
  end
 
 --药品报损
 if @functionname='Fun_ts_yf_ypbs' 
        set @ssql=' select 0  序号,djh 单据号 ,RQ 单据日期,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,
		(djrq+djsj) as 登记时间,dbo.fun_getempname(djy) 登记员,dbo.fun_yp_bsyy(yydm) 原因,bz 备注,id from vi_yf_dj 
		where deptid='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';

 	
 --药品报溢
 if @functionname='Fun_ts_yf_ypby' 
        set @ssql=' select 0  序号,djh 单据号,sumjhje 进货金额,sumpfje 批发金额,sumlsje 零售金额,
		(djrq+djsj) as 登记时间,dbo.fun_getempname(djy) 登记员,dbo.fun_yp_yyyy(yydm) 原因,bz 备注,id from vi_yf_dj 
		where deptid='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';

 
 --盘点录入
 if @functionname='Fun_ts_yf_pdlr' 
        set @ssql=' select 0  序号,djh 单据号,DJRQ as 登记时间,dbo.fun_getempname(djy) 登记员,
		shrq as 审核时间,dbo.fun_getempname(SHY) 审核员,shdjh 审核单据号,bz 备注,id from YF_pdcs
		where deptid='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and bdelete=0';

 
 --盘点单
  if @functionname='Fun_ts_yf_pdsh' 
        set @ssql=' select 0  序号,djh 单据号,DJRQ as 审核时间,dbo.fun_getempname(DJY) 审核员,id from YF_pd where deptid='+cast(@deptid as char(10)) +'';

 if @functionname='Fun_ts_yf_xygpd' 
        set @ssql=' select 0  序号,djh 单据号,DJRQ as 录入日期,dbo.fun_getempname(DJY) 录入员,shdjh 审核单据号,shrq 审核日期,dbo.fun_getempname(SHY) 审核员,id from YF_pdcs where deptid='+cast(@deptid as char(10)) + ' and  shbz='+cast(@shbz as char(10)) + '';

 
 if @wldw>0 
     set @ssql=@ssql+' and wldw='+cast(@wldw as char(10)) ;

 
 if @dtp1<>'' 
     set @ssql=@ssql+' and djrq>='''+ @dtp1 +' 00:00:00'' and  djrq<='''+@dtp2+' 23:59:59'''  ;

 
  if @djh<>0 
     set @ssql=@ssql+' and djh='+ cast(@djh as char(50)) ;

 
  if @fph<>'' 
     set @ssql=@ssql+' and fph='''+ cast(@fph as varchar(50))+'''' ;

 
 if rtrim(@shdh)<>''   and  @functionname<>'Fun_ts_yp_tj' 
     set @ssql=@ssql+' and shdh='''+@shdh+''' '   

 
     set @ssql=@ssql+' order by djh'
 exec(@ssql)
 
 end 