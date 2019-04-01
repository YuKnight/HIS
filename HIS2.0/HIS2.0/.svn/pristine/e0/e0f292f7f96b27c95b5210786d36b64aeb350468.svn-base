--exec sp_yk_dj_djmxcx @ywlx=N'001',@dtpdjsj1=N'2014-05-06',@dtpdjsj2=N'2014-05-06',@dtprq1=N'',@dtprq2=N'',@dtpshrq1=N'',@dtpshrq2=N'',@djh=0,@wldw=0,@shdh=N'',@fph=N'',@djbz=N'',@cjid=0,@tjwh=N'',@deptid=214,@sdjh=N'',@deptid_ck=214,@ywy=0

IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yk_dj_djmxcx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yk_dj_djmxcx
GO
CREATE PROCEDURE sp_yk_dj_djmxcx
(
 	@ywlx char(3),
	@dtpdjsj1 varchar(30),
	@dtpdjsj2 varchar(30),
	@dtprq1 varchar(30),
	@dtprq2 varchar(30),
	@dtpshrq1 varchar(30),
	@dtpshrq2 varchar(30),
	@djh bigint,
	@wldw int ,
	@shdh varchar(50),
	@fph varchar(50),
	@djbz varchar(200),
	@cjid int,
	@tjwh varchar(50),
	@deptid int  ,
	@sdjh varchar(50),
	@deptid_ck int,
    @ywy int
)
as

p1:begin

 declare @ssfun varchar(200);
 declare @ssql varchar(8000);


--一般业务临时表
 create TABLE #DJMX
   (
 		  ID UNIQUEIDENTIFIER  ,
		  DJH BIGINT default -1 not null,
		  DEPTID INTEGER default -1 not null,
		  YWLX CHAR(3) not null,
		  WLDW INTEGER default -1 not null,
		  JSR INTEGER DEFAULT 0,
		  RQ  varchar(30),
		  DJRQ varchar(40),
		  SHRQ varchar(30),
		  FPH VARCHAR(30),
		  FPRQ CHAR(10),
		  BZ VARCHAR(100),
   		  SHDH VARCHAR(50) ,
		  DJID UNIQUEIDENTIFIER  ,
		  CJID INTEGER default -1 not null,
		  YPPH VARCHAR(30) not null,
		  ypxq varchar(30),
		  YPKL DECIMAL(15,3) default 0 not null,
		  YPSL DECIMAL(15,3) default 0 not null,
		  YPDW VARCHAR(10) not null,
		  JHJ DECIMAL(15,4) default 0 not null,
		  PFJ DECIMAL(15,4) default 0 not null,
		  LSJ DECIMAL(15,4) default 0 not null,
		  JHJE DECIMAL(15,2) default 0 not null,
		  PFJE DECIMAL(15,3) default 0 not null,
		  LSJE DECIMAL(15,3) default 0 not null,
		  SDJH VARCHAR(50),
		  FKBL DECIMAL(15,4) default 1 not null, --付款比例
		  yppch varchar(100) ,
		  kcid uniqueidentifier ,
		  zbzt smallint
	) 

create table #deptid(deptid int)
--需要统计的科室
if (@deptid_ck>0)
  insert #deptid(deptid)values(@deptid_ck)
else 
  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID


if @ywlx='008' 
begin
	 set @ssql='select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,c.s_yppm 品名,c.s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,
	 yppch 批次号, b.kcid ,
	 YPpH 批号,b.lsj 零售价,b.ypdw 单位, '+
	 'zcs 帐存数,zclsje 帐存金额,pcs 盘存数,pclsje 盘存金额,(zcs-pcs) 盈亏数,(pclsje-zclsje) 盈亏金额,'+
	 'a.djh 单据号,rq 单据日期,djrq 审核日期,a.id,b.cjid '+ 
	 ' from yf_pd a,yf_pdmx b,yp_ypcjd c '+
	 'where a.id=b.djid and b.cjid=c.cjid'+
	 ' and a.deptid in(select deptid from #deptid) ';
	 if  rtrim(@dtpshrq1)<>'' or rtrim(@dtprq1)<>'' or RTRIM(@dtpdjsj1)<>'' 
	    set @ssql=@ssql+' and djrq>='''+ @dtpdjsj1 +' 00:00:01'' and  djrq<='''+@dtpdjsj2+' 23:59:59'''  ;

	 if @djh>0 
	    set @ssql=@ssql+' and a.djh='+cast(@djh as char(10))+'';

	 if  @djbz<>'' 
	    set @ssql=@ssql+' and a.bz like ''%'+@djbz+'%''';

	 if  @cjid>0 
	    set @ssql=@ssql+' and b.cjid='+cast(@cjid as char(10))+'';

	 exec(@ssql)
	 return;
end

if @ywlx='005' 
begin
	 set @ssql='select 0 序号,dbo.fun_getdeptname(a.deptid) 仓库名称,c.s_yppm 品名,c.s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,tjsl 数量,b.ypdw 单位, '+
	 'ypfj 原批发价,xpfj 现批发价,ylsj 原零售价,xlsj 现零售价,(xlsj-ylsj) 单位差价,tlsje 调价金额, '+
	 'a.djh 单据号,djrq 登记日期,zxrq 执行日期,tjwh 调价文号,dbo.fun_getempname(a.djy) 操作员,a.id,b.cjid  '+ 
	 ' from yf_tj a,yf_tjmx b,yp_ypcjd c '+
	 ' where a.id=b.djid and b.cjid=c.cjid'+
	 ' and a.deptid in(select deptid from #deptid) and a.wcbj=1  ';

	 if  RTRIM(@dtpdjsj1)<>'' or RTRIM(@dtprq1)<>'' 
	    set @ssql=@ssql+' and djrq>='''+ @dtpdjsj1 +' 00:00:01'' and  djrq<='''+@dtpdjsj2+' 23:59:59'''  ;

	 if  rtrim(@dtpshrq1)<>'' 
	    set @ssql=@ssql+' and wcbj=1 and zxrq>='''+ @dtpshrq1 +' 00:00:01'' and  zxrq<='''+@dtpshrq2+' 23:59:59'''  ;
	 
	 if @djh>0 
	    set @ssql=@ssql+' and a.djh='+cast(@djh as char(10))+'';

	 if  @djbz<>'' 
	    set @ssql=@ssql+' and a.bz like ''%'+@djbz+'%''';

	 if  @tjwh<>'' 
	    set @ssql=@ssql+' and a.tjwh like ''%'+@tjwh+'%''';

	 if  @cjid>0 
	    set @ssql=@ssql+' and b.cjid='+cast(@cjid as char(10))+'';

	 set @ssql=@ssql+' order by b.djh,b.id';
	 
	exec(@ssql)
	 return;
end 


--当前业务表。。除调价和盘点业务
	 set @ssql=' insert into #djmx(id,djh,deptid,ywlx,wldw,jsr,rq,djrq,shrq,fph,
	 fprq,bz,djid,cjid,ypph,ypxq,ypkl,ypsl,ypdw,jhj,pfj,lsj,jhje,pfje,lsje,shdh,sdjh,fkbl,yppch,kcid,zbzt ) '+
	 'select a.id,a.djh,a.deptid,a.ywlx,wldw,jsr,rq,djrq,shrq,fph,fprq,a.bz,djid,cjid,ypph,ypxq,
	 ypkl,ypsl,ypdw,jhj,pfj,lsj,jhje,pfje,lsje,b.shdh,sdjh,b.fkbl,b.yppch,b.kcid,b.zbzt   '+ 
	 ' from vi_yk_dj a,vi_yk_djmx b where a.id=b.djid and a.deptid in(select deptid from #deptid) ';

	 if (@ywlx='001' or @ywlx='002' ) and @ywy>0
        set @ssql=@ssql+' and a.jsr='+cast(@ywy as varchar(30))

	 if  @ywlx<>'000' 
	    set @ssql=@ssql+' and a.ywlx='''+@ywlx+'''';

	 if  RTRIM(@dtpdjsj1)<>'' 
	    set @ssql=@ssql+' and djrq>='''+ @dtpdjsj1 +''' and  djrq<='''+@dtpdjsj2+''''  ;

	 if  rtrim(@dtprq1)<>'' 
	    set @ssql=@ssql+' and rq>='''+ @dtprq1 +''' and  rq<='''+@dtprq2+''''  ;

	 if  rtrim(@dtpshrq1)<>'' 
	    set @ssql=@ssql+' and shrq>='''+ @dtpshrq1 +' 00:00:01'' and  shrq<='''+@dtpshrq2+' 23:59:59'''  ;

	 if @djh>0 
	    set @ssql=@ssql+' and a.djh='+cast(@djh as char(10))+'';

	 if @wldw>0 
	    set @ssql=@ssql+' and a.wldw='+cast(@wldw as char(10))+'';

	 if  @shdh<>'' 
	    set @ssql=@ssql+' and b.shdh='''+@shdh+'''';

	 if  @fph<>'' 
	    set @ssql=@ssql+' and a.fph like ''%'+@fph+'%''';

	 if  @djbz<>'' 
	    set @ssql=@ssql+' and a.bz like ''%'+@djbz+'%''';

	 if  @cjid>0 
	    set @ssql=@ssql+' and b.cjid='+cast(@cjid as char(10))+'';
	 if @sdjh<>'' 
	    set @ssql=@ssql+' and sdjh='''+rtrim(@sdjh) +''''
	 print @ssql
	 exec(@ssql)

	 if @ywlx='001' or @ywlx='002' or @ywlx='016' 
	 	 set @ssfun='dbo.fun_yp_ghdw(wldw) 往来单位';
	 else
	    set @ssfun='dbo.fun_getdeptname(wldw) 往来单位';
 
	 set @ssql='select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,rtrim(dbo.fun_yk_ywlx(ywlx)) 业务类型,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,'+
	 's_sccj 厂家,yppch 批次号,a.kcid, ypph 批号,rtrim(ypxq) 效期,a.ypkl 扣率,a.jhj 进价,a.lsj 零售价,cast(ypsl as float) 数量,a.ypdw 单位,jhje 进货金额,lsje 零售金额,'+
	 ' (lsje-jhje) 进零差额,djh 单据号,sdjh 月单据号,cast(rq as datetime)  单据日期,shdh 送货单号,'+@ssfun+',DBO.fun_yp_ywy(jsr) 业务员,fph 发票号,'+
	 'fprq 发票日期,dbo.Fun_GetDate(djrq) 登记日期,shrq  审核日期,txm 条形码,a.pfj 批发价,pfje 批发金额,a.id,b.cjid, cast(a.fkbl*100 as decimal(15,2)) 付款比例, 
	 cast(a.jhje*a.fkbl as decimal(15,3)) 付款金额,(case when a.zbzt=0 then ''否'' else ''是'' end) as 中标状态 from #djmx a,yp_ypcjd b where a.cjid=b.cjid order by id';
	exec(@ssql)
	 
end 

