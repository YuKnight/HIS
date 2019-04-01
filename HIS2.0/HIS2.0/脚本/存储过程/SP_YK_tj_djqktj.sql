IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_tj_djqktj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_tj_djqktj
GO
CREATE PROCEDURE SP_YK_tj_djqktj
 (
  @TYPE INT,
  @ywlx char(3), 
  @yplx INTEGER,
  @ypzlx integer,
  @ghdw integer,
  @CJID INTEGER,
  @dtp1 varchar(30),
  @dtp2 varchar(30),
  @deptid int,
  @deptid_ck int
 )  
as
BEGIN 
 declare @ss varchar(5000);
 declare @count INT

 --声明临时表
   create TABLE #TEMP
   (
	ID BIGINT IDENTITY (1, 1) NOT NULL ,
	CJID INTEGER default -1 not null,
	YPKL DECIMAL(15,3) default 0 not null,
	YPSL DECIMAL(15,3) default 0 not null,
	YDWBL INTEGER,
	JHJE DECIMAL(15,3) default 0 not null,
	PFJE DECIMAL(15,3) default 0 not null,
	LSJE DECIMAL(15,3) default 0 not null,
	wldw int,
	yydm int
   ) 
  
	create table #deptid(deptid int)
	--需要统计的科室
	if (@deptid_ck>0)
	  insert #deptid(deptid)values(@deptid_ck)
	else 
	  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID


  p1:begin

--第一步提取业务数据到临时表
     set @ss='insert into #temp(cjid,ypkl,ypsl,ydwbl,jhje,pfje,lsje,wldw,yydm) '+
	  'select cjid,ypkl,ypsl,ydwbl,'+
	  'jhje,pfje,'+
	  'lsje,wldw,yydm from vi_yk_dj a,vi_yk_djmx b '+ 
	  'where a.id=b.djid and a.ywlx='''+@ywlx+''' and a.deptid in(select deptid from #deptid) ';
	 if @ywlx<>'001' and @ywlx<>'002' 
	   set @ss=@ss+' and shbz=1 and ' +' a.shrq>='''+@dtp1+''' and a.shrq<='''+@dtp2+'''';
     else 
       set @ss=@ss+' and ' +'cast(dbo.Fun_GetDate(djrq)+'' ''+CONVERT(varchar,djsj,108) as datetime)>='''+@dtp1+''' and cast(dbo.Fun_GetDate(djrq)+'' ''+CONVERT(varchar,djsj,108) as datetime)<='''+@dtp2+'''';
     
  	 if @ghdw>0 
	 begin
	   set @ss=@ss+' and wldw='+cast(@ghdw as char(10)) +'';
	 end 
	 
	 if @cjid>0 
	 begin		
	   set @ss=@ss+' and cjid='+cast(@cjid as char(10)) +'';
	 end
  	 print(@ss)
	 exec(@ss)
	  
 end 
	  set @ss='';
	  
	  
	  
--第二步在临时表中统计报表
p2:begin

  	 if @yplx<>0 
	 begin
	     begin
		   set @ss=' and yplx='+cast(@yplx as char(10)) +'';
		 end ;
	 end 
	 if @ypzlx<>0 
	 begin
	     begin
		   set @ss=@ss+' and ypzlx='+cast(@ypzlx as char(10))+'';
		 end;
	 end 
		 

  if @ywlx='001' OR @YWLX='002' or @ywlx='016' 
  begin
  	 --0 按供货商查询 
     if @type=0 
     begin 
	     set @ss='select ''0'' 序号,dbo.fun_yp_ghdw(wldw) 供货单位,sum(jhje) 进货金额,sum(pfje) 批发金额,'+
		 'sum(lsje) 零售金额,(sum(lsje)-sum(jhje)) 进零差额,(sum(lsje)-sum(pfje)) 批零差额 '+ 
		 'from #temp a,vi_yp_ypcd b where a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by a.wldw'; 
    end
	 --1 按药品查询
    if @type=1 
    begin 
  	     set @ss='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(jhje) 进货金额,sum(pfje) 批发金额,sum(lsje) 零售金额,(sum(lsje)-sum(jhje)) 进零差额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,b.cjid,txm 条形码  from #temp a ,vi_yp_ypcd b '+
	          'where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm'; 
    end
  end 
  
  --出库
  if @ywlx='003' 
  begin
     --0 按供货商查询 
     if @type=0 
      begin 
	   begin
	 	set @ss='select ''0'' 序号,dbo.fun_getdeptname(wldw) 领药单位,sum(jhje) 进货金额 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额,wldw as 往来单位ID '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' group by wldw';
	   end ;
      end
	 --1 按药品查询
     if @type=1 
     begin 
	    begin
	 	set @ss='select ''0'' 序号,dbo.fun_getdeptname(wldw) 往来单位,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,sum(jhje) 进货金额,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额,b.cjid ,txm 条形码 from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by wldw,b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
	    end; 
     end
  end 

  
  --药房退库
  if @ywlx='004' or @ywlx='030' or @ywlx='031'
  begin
     --0 按供货商查询 
     if @type=0 
     begin 
	   begin
	 	set @ss='select ''0'' 序号,dbo.fun_getdeptname(wldw) 往来单位 ,sum(jhje) 进货金额,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额,wldw as 往来单位ID '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' group by wldw';
	   end ;
     end 
	 --1 按药品查询
    if @type=1 
    begin 
	    begin
	 	set @ss='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,sum(jhje) 进货金额,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额,b.cjid,txm 条形码  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
		end; 
    end
  end 
  
  
  --调价
  if @ywlx='005' 
  begin
     --0 
     if @type=0 
     begin 
	   begin
	 	set @ss='select ''0'' 序号,''调价金额'' 科目 ,coalesce(sum(pfje),0) 批发金额,'+
		'coalesce(sum(lsje),0) 零售金额 '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' ';
	   end ;
     end
	 --1 按药品查询
    if @type=1 
    begin 
	begin
	 	set @ss='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 调价数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  'b.cjid,txm 条形码  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
	end; 
    end
  end 
  
  
  --报损
  if @ywlx='006' 
  begin
     --0 按供原因查询 
     if @type=0 
     begin 
	   begin
	 	set @ss='select ''0'' 序号,dbo.fun_yp_bsyy(yydm) 报损原因 ,sum(jhje) 进货金额,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额 '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' group by yydm';
	   end ;
     end
	 --1 按药品查询
    if @type=1 
    begin 
	  begin
	 	set @ss='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,sum(jhje) 进货金额,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额,b.cjid,txm 条形码  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
          end; 
    end
  end
  
  --报溢
if @ywlx='007' 
begin
     --0 按供原因查询 
     if @type=0 
     begin 
	   begin
	 	set @ss='select ''0'' 序号,dbo.fun_yp_bsyy(yydm) 报溢原因,sum(jhje) 进货金额 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额 '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' group by yydm';
	   end ;
     end
	 --1 按药品查询
     if @type=1 
     begin 
	    begin
	 	set @ss='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,sum(jhje) 进货金额,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额,b.cjid,txm 条形码  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
		end; 
     end
end
  
  
  --药品盘点
if @ywlx='008' 
begin
     --0 
     if @type=0 
     begin
	   begin
	 	set @ss='select ''0'' 序号,''盈亏金额'' 科目 ,coalesce(sum(jhje),0) 进货金额,coalesce(sum(pfje),0) 批发金额,'+
		'coalesce(sum(lsje),0) 零售金额 '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' ';
	   end ;
     end
	 --1 按药品查询
     if @type=1
     begin
	    begin
	 	set @ss='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 盈亏数量,dbo.fun_yp_ypdw(b.ypdw) 单位,coalesce(sum(jhje),0) 进货金额,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  'b.cjid,txm 条形码  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
	    end; 
    end
end
  
  
if @ywlx='012' 
begin 
     --0 
     if @type=0
     begin
	   begin
	 	set @ss='select  ''0'' 序号, ''账务调整'' 科目 ,coalesce(sum(jhje),0) 进货金额,coalesce(sum(pfje),0) 批发金额,'+
		'coalesce(sum(lsje),0) 零售金额 '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + '';
	   end ;
     end
	 --1 按药品查询
     if @type=1 
     begin
	    begin
	 	set @ss='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,'+
		      'sum(jhje) 进货金额,sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  'b.cjid,txm 条形码  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
	    end; 
     end
end
  
  
    --其初录入
if @ywlx='009' 
begin
     --0 按供货商查询 
     if @type=0 
     begin
	   begin
	 	set @ss='select ''0'' 序号,''期初入库'' 科目 ,sum(jhje) 进货金额,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额 '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' group by wldw';
	   end ;
    end
	 --1 按药品查询
     if @type=1
     begin
	    begin
	 	set @ss='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,sum(jhje) 进货金额,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额,b.cjid,txm 条形码  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
	    end; 
     end
end
  
    --其它领药单
if @ywlx='014'
begin
     --0 按供货商查询 
     if @type=0 
     begin
	   begin
	 	set @ss='select ''0'' 序号,dbo.fun_getdeptname(wldw) 领药单位 ,sum(jhje) 进货金额,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额,wldw as 往来单位ID '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' group by wldw';
	   end ;
     end
	 --1 按药品查询
     if @type=1 
     begin
	    begin
	 	set @ss='select ''0'' 序号,dbo.fun_getdeptname(wldw) 往来单位,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,sum(jhje) 进货金额,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额,b.cjid,txm 条形码  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by wldw,b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
	    end; 
     end
end

    --处方出库
if @ywlx='017'  or @ywlx='022'
begin
     --0 按供货商查询 
     if @type=0 
     begin
	   begin
	 	set @ss='select ''0'' 序号,''处方出库'' 科目,sum(jhje) 进货金额 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额 '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' group by wldw';
	   end ;
     end
	 --1 按药品查询
     if @type=1 
     begin
	    begin
	 	set @ss='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,sum(jhje) 进货金额,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额 ,b.cjid,txm 条形码  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
	   end; 
    end
end
  
      --门诊记帐处方补录出库
 if @ywlx='018' 
 begin
     --0 按供货商查询 
     if @type=0 
     begin
	   begin
	 	set @ss='select ''0'' 序号,''门诊记帐处方补录出库'' 科目,sum(jhje) 进货金额 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额  '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' group by wldw';
	   end ;
     end
	 --1 按药品查询
     if @type=1 
     begin
	    begin
	 	set @ss='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,dbo.fun_yp_ypdw(b.ypdw) 单位,sum(jhje) 进货金额,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额,b.cjid,txm 条形码  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
	    end; 
     end
end
  
    --处方补录出库
if @ywlx='020' 
begin
     --0 按供货商查询 
     if @type=0 
     begin
	   begin
	 	set @ss='select ''0'' 序号,''处方补录出库'' 科目,sum(jhje) 进货金额 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额 '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' group by wldw';
	   end ;
     end
	 --1 按药品查询
     if @type=1 
     begin
	    begin
	 	set @ss='select ''0'' 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家 ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,
	 	dbo.fun_yp_ypdw(b.ypdw) 单位,sum(jhje) 进货金额,'+
		      'sum(pfje) 批发金额,sum(lsje) 零售金额,'+
			  '(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额,b.cjid,txm 条形码  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid'+(case when rtrim(@ss)<>'' then @ss else '' end)+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm';
	    end; 
     end
end

--原料消耗出库 032 ncq 20140210
if @ywlx='032'
begin
	--0 按供货商查询
	if @TYPE=0
	begin
		set @ss='select ''0'' 序号,''原料消耗出库'' 科目,sum(jhje) 进货金额 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额 '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' group by wldw';
	end
	--1 按药品查询
	if @TYPE=1
	begin
		set @ss=' select ''0'' 序号, ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家, cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,
				 dbo.fun_yp_ypdw(b.ypdw) 单位,sum(jhje) 进货金额, ' +
				 ' sum(pfje) 批发金额,sum(lsje) 零售金额 , ' +
				 ' (sum(lsje)-sum(pfje) ) 批零差额,(sum(lsje) -sum(jhje) ) 进货金额,b.cjid,txm 条形码 from #temp a,vi_yp_ypcd b ' +
				 ' where a.cjid=b.cjid ' + (case when RTRIM(@ss)<>'' then @ss else '' end )+ ' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm ' ;
	end
end


--制剂加工成品入库 033 ncq 20140210
if @ywlx='033'
begin
	--0 按供货商查询
	if @TYPE=0
	begin
			set @ss='select ''0'' 序号,''制剂加工成品入库'' 科目,sum(jhje) 进货金额 ,sum(pfje) 批发金额,'+
		'sum(lsje) 零售金额,(sum(lsje)-sum(pfje)) 批零差额,(sum(lsje)-sum(jhje)) 进零差额 '+
		'from #temp a ,vi_yp_ypcd b where  a.cjid=b.cjid '+(case when rtrim(@ss)<>'' then @ss else '' end) + ' group by wldw';
	end
	--1 按药品查询
	if @TYPE=1
	begin
		set @ss=' select ''0'' 序号, ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家, cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) 数量,
				 dbo.fun_yp_ypdw(b.ypdw) 单位,sum(jhje) 进货金额, ' +
				 ' sum(pfje) 批发金额,sum(lsje) 零售金额 , ' +
				 ' (sum(lsje)-sum(pfje) ) 批零差额,(sum(lsje) -sum(jhje) ) 进货金额,b.cjid,txm 条形码 from #temp a,vi_yp_ypcd b ' +
				 ' where a.cjid=b.cjid ' + (case when RTRIM(@ss)<>'' then @ss else '' end )+ ' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,txm ' ;
	end
end
  

exec(@ss)
end 

 END;