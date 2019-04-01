IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_YF_tj_djqktj]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YF_tj_djqktj]
GO
CREATE PROCEDURE [dbo].[SP_YF_tj_djqktj]
 (
   @TYPE INT,
   @ywlx char(3), 
   @yplx INTEGER,
   @ypzlx integer,
   @ghdw integer,
   @CJID INTEGER,
   @dtp1 varchar(30),
   @dtp2 varchar(30),
   @deptid int
 )  
 as
BEGIN 
 declare @ss varchar(500);
 declare @count int
 DECLARE @stmt varchar(5000); --定义SQL文本


 --声明临时表
   create TABLE #TEMP
   (
	ID BIGINT IDENTITY (1, 1) NOT NULL ,
	CJID INTEGER default -1 not null,
	YPKL DECIMAL(15,3) default 0 not null,
	YPSL DECIMAL(15,3) default 0 not null,
	ypdw varchar(10),
	YDWBL INTEGER,
	JHJE DECIMAL(15,3) default 0 not null,
	PFJE DECIMAL(15,3) default 0 not null,
	LSJE DECIMAL(15,3) default 0 not null,
	wldw varchar(100),
	yydm int,
	djh bigint,
	djrq datetime,
	djy int,
	bz varchar(100),
	pxxh int
   ) 
  
begin

 --第一步提取业务数据到临时表
  if @ywlx not in('017','020')
  begin
     set @stmt='insert into #temp(cjid,ypkl,ypsl,ypdw,ydwbl,jhje,pfje,lsje,wldw,yydm,djh,djrq,djy,pxxh) '+
	  'select C.cjid,ypkl,ypsl,b.ypdw,ydwbl,'+
	  'b.jhje,pfje,'+
	  'lsje,wldw,yydm,a.djh,
	  (case when a.ywlx in(''001'',''002'') then cast(dbo.Fun_GetDate(djrq)+'' ''+CONVERT(varchar,a.djsj,108) as datetime) else a.shrq end),
	   a.djy,b.pxxh from vi_YF_dj a,vi_YF_djmx b,yp_ypcjd c '+ 
	  'where a.id=b.djid and b.cjid=c.cjid and a.ywlx='''+@ywlx+''' and a.deptid='+cast(@deptid as char(10))

	 if @ywlx<>'001' and @ywlx<>'002' 
	   set @stmt=@stmt+' and shbz=1 and ' +' a.shrq>='''+@dtp1+''' and a.shrq<='''+@dtp2+'''';
     else 
       set @stmt=@stmt+' and ' +'cast(dbo.Fun_GetDate(djrq)+'' ''+CONVERT(varchar,a.djsj,108) as datetime)>='''+@dtp1+''' and cast(dbo.Fun_GetDate(djrq)+'' ''+CONVERT(varchar,a.djsj,108) as datetime)<='''+@dtp2+'''';
     
     
  	 if @ghdw>0 
	   set @stmt=@stmt+' and wldw='+cast(@ghdw as char(10)) +'';

	 
	 if @cjid>0 
	   set @stmt=@stmt+' and C.cjid='+cast(@cjid as char(10)) +'';

	 
  	 if @yplx<>0 
	 begin
		   set @stmt=@stmt+' and n_yplx='+cast(@yplx as char(10)) +'';
	 end ;

	 if @ypzlx<>0 
	     begin
		   set @stmt=@stmt+' and n_ypzlx='+cast(@ypzlx as char(10))+'';
		 end;

	 print @stmt
  	 exec(@stmt)
  end
	  
--发药业务
  if @ywlx  in('017','020')
  begin
     set @stmt='insert into #temp(cjid,ypsl,ypdw,ydwbl,jhje,pfje,lsje,wldw,djrq,djy,bz,pxxh) '+
	  'select C.cjid,ypsl*b.cfts,b.ypdw,ydwbl,'+
	  'b.jhje,pfje,'+
	  'lsje,null,
	  a.fyrq,
	   a.fyr,
	  (case when a.ywlx=''017'' then ''门诊发票号:''+cast(a.fph as varchar(50)) else ''住院号:''+patientno end),pxxh
	   from VI_YF_FY a,VI_YF_FYMX b,yp_ypcjd c '+ 
	  'where a.id=b.FYID and b.cjid=c.cjid and a.ywlx='''+@ywlx+''' and a.deptid='+cast(@deptid as char(10))
	   set @stmt=@stmt+' and ' +' a.fyrq>='''+@dtp1+''' and a.fyrq<='''+@dtp2+'''';

	 if @cjid>0 
	   set @stmt=@stmt+' and C.cjid='+cast(@cjid as char(10)) +'';

  	 if @yplx<>0 
	 begin
		   set @stmt=@stmt+' and n_yplx='+cast(@yplx as char(10)) +'';
	 end ;

	 if @ypzlx<>0 
	     begin
		   set @stmt=@stmt+' and n_ypzlx='+cast(@ypzlx as char(10))+'';
		 end;

	 print @stmt
  	 exec(@stmt)
  end
  

 
 --发药业务
 if @ywlx  in('020')
  begin
     set @stmt='insert into #temp(cjid,ypsl,ypdw,ydwbl,jhje,pfje,lsje,wldw,djrq,djy,bz) '+
	  'select C.cjid,ypsl,b.ypdw,ydwbl,'+
	  'b.jhje,pfje,'+
	  'lsje,null,
	  a.fyrq,
	   a.fyr,
	  ''统领发药单号:''+cast(djh as varchar(50)) 
	    from VI_YF_TLD a,VI_YF_TLDMX b,yp_ypcjd c '+ 
	  'where a.GROUPID=b.GROUPID and b.cjid=c.cjid and a.ywlx='''+@ywlx+''' and a.deptid='+cast(@deptid as char(10))
	   set @stmt=@stmt+' and ' +' a.fyrq>='''+@dtp1+''' and a.fyrq<='''+@dtp2+'''';

	 if @cjid>0 
	   set @stmt=@stmt+' and C.cjid='+cast(@cjid as char(10)) +'';

  	 if @yplx<>0 
	 begin
		   set @stmt=@stmt+' and n_yplx='+cast(@yplx as char(10)) +'';
	 end ;

	 if @ypzlx<>0 
	     begin
		   set @stmt=@stmt+' and n_ypzlx='+cast(@ypzlx as char(10))+'';
		 end;

	 print @stmt
  	 exec(@stmt)
  end
  
 end
 
 
	  
--第二步在临时表中统计报表
begin

  if @ywlx='001' OR @YWLX='002' 
begin
     if @type=0  
	   BEGIN
	     set @stmt='select ''0'' 序号,dbo.fun_yp_ghdw(wldw) 供货单位,sum(jhje) 进货金额,sum(pfje) 批发金额,'+
		 'sum(lsje) 零售金额,(sum(lsje)-sum(jhje)) 进零差额,(sum(lsje)-sum(pfje)) 批零差额 '+ 
		 'from #temp a  group by a.wldw';
	   END; 
	 else
  	     set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(jhje) 进货金额,sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(jhje)) 进零差额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a ,vi_yp_ypcd b '+
	          'where  a.cjid=b.cjid  group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw'; 
end
  
  --药品调出
  if @ywlx='003' 
begin
     if @type=0 
	 	set @stmt='select ''0'' 序号,dbo.fun_getdeptname(wldw) 领药单位 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,wldw as 往来单位ID '+
		'from #temp a  group by wldw';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end

  
  --药房退库
  if @ywlx='004' 
begin
     if @type=0 
	 	set @stmt='select ''0'' 序号,dbo.fun_getdeptname(wldw) 往来单位 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,wldw as 往来单位ID '+
		'from #temp a  group by wldw';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
  --调价
  if @ywlx='005' 
begin
     --0 
     if @type=0  
	 	set @stmt='select ''0'' 序号,''调价金额'' 科目 ,coalesce(sum(pfje),0) 批发金额,'+
		'coalesce(sum(lsje),0) 零售金额 '+
		'from #temp a ';
     else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 调价数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
  --报损
 if @ywlx='006' 
begin
         if @type=0  
	 	set @stmt='select ''0'' 序号,coalesce(dbo.fun_yp_bsyy(yydm),''未写原因'') 报损原因 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额 '+
		'from #temp a group by yydm';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  --报溢
  if @ywlx='007' 
begin
     --0 按供原因查询 
    	 if @type=0  
	 	set @stmt='select ''0'' 序号,coalesce(dbo.fun_yp_yyyy(yydm),''未写原因'') 报溢原因 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额 '+
		'from #temp a  group by yydm';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
  --药品盘点
  if @ywlx='008' 
begin
   	 if @type=0  
	 	set @stmt='select ''0'' 序号,''盈亏金额'' 科目 ,coalesce(sum(pfje),0) 批发金额,coalesce(sum(lsje),0) 零售金额 from #temp a';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 盈亏数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
      --期初录入
  if @ywlx='009' 
begin
      if @type=0 
	 	set @stmt='select ''0'' 序号,''期初入库'' 科目 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额 from #temp a group by wldw';
      else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
  if @ywlx='012' 
begin
        if @type=0 
	 	set @stmt='select ''0'' 序号,''账务调整'' 科目 ,coalesce(sum(jhje),0) 进货金额,coalesce(sum(pfje),0) 批发金额,'+
		'coalesce(sum(lsje),0) 零售金额 from #temp a where lsje<>0 or pfje<>0 ';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(jhje) 进货金额,sum(pfje) 批发金额,sum(lsje) 零售金额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid and (lsje<>0 or pfje<>0) group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
    --其它领药单
  if @ywlx='014' 
begin
     	if @type=0 
	 	set @stmt='select ''0'' 序号,dbo.fun_getdeptname(wldw) 领药单位 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,wldw as 往来单位ID from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  --药品调入单
  if @ywlx='015' or @ywlx='016' 
begin
     	if @type=0  
	 	set @stmt='select ''0'' 序号,dbo.fun_getdeptname(wldw) 往来单位 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,wldw as 往来单位ID from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  --门诊处方出库
if @ywlx='017' or @ywlx='020' 
begin
     	if @type=0 
	 	set @stmt='select ''0'' 序号,''处方出库'' 科目 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额 from #temp a  group by wldw';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,
	 			dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(kcl/dwbl,2) as float) 现有库存, 
	 			cast(round(sum(ypsl/ydwbl),3) as float) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a inner join vi_yp_ypcd b '+
	          'on a.cjid=b.cjid inner join yf_kcmx c on b.cjid=c.cjid where c.deptid='+cast(@deptid as varchar(50))+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,kcl,dwbl';
end
  
    --门诊记帐处方补录出库
 if @ywlx='018' or @ywlx='021' 
begin
    	 if @type=0  
	 	set @stmt='select ''0'' 序号,''处方补录出库'' 科目 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额 from #temp a  group by wldw';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end

      --其它入库
  if @ywlx='019' 
begin
     if @type=0  
	 	set @stmt='select ''0'' 序号, dbo.fun_yp_ghdw(wldw) 供货单位 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额 from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
      --外用药领药
  if @ywlx='022' 
begin
   	  if @type=0  
	 	set @stmt='select ''0'' 序号, dbo.fun_getdeptname(wldw) 供货单位 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,wldw as 往来单位ID from #temp a group by wldw';
	  else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
   --小药柜药品(含大输液)请领单出库
  if @ywlx='023' or @ywlx='024' 
begin
     if @type=0  
	 	set @stmt='select ''0'' 序号, dbo.fun_getdeptname(wldw) 往来单位 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,wldw as 往来单位ID from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
    --保健处方记帐
  if @ywlx='025'
begin
    	 if @type=0  
	 	set @stmt='select ''0'' 序号,''保健处方记帐'' 科目,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额 from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
      --财务科记帐
  if @ywlx='026'
begin
   	  if @type=0  
	 	set @stmt='select ''0'' 序号,''财务科记帐'' 科目 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额 from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end

 exec(@stmt)
 
select '0' 序号 ,SHH 货号,S_YPPM 品名,S_YPSPM 商品名,S_YPGG 规格,b.s_sccj 厂家,a.YPSL 数量,a.ypdw 单位,
a.pfje 批发金额,a.LSJE 零售金额,a.djh 单据号,a.djrq 日期,
(case when @ywlx IN('001','002','019') then dbo.fun_yp_ghdw(wldw) else  dbo.fun_getDeptname(a.wldw)  end) 往来单位,a.BZ 备注
from #TEMP a,YP_YPCJD b where a.CJID=b.CJID
union all
select '合计' 序号 ,'' 货号,'合计' 品名,'' 商品名,'' 规格,'' 厂家,null 数量,'' 单位,
sum(a.pfje) 批发金额,sum(a.LSJE) 零售金额,null 单据号,GETDATE() 日期,
null  往来单位,null 备注
from #TEMP a 
 order by 日期,备注
  

end 

 END;
GO


