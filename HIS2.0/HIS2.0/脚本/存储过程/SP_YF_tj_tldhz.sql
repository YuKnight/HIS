

IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_tj_tldhz' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_tj_tldhz
GO
CREATE PROCEDURE SP_YF_tj_tldhz
 ( @type int, 
   @dept_ly int,
   @tlfl varchar(20),
   @dtp1 varchar(30),
   @dtp2 varchar(30),
   @deptid int,
   @cjid int,
   @lb varchar(30)
 )  
as
BEGIN
 declare @count INT 
 DECLARE @stmt varchar(6000); --定义SQL文本

 --声明临时表
CREATE TABLE #YP
   (
   	  ward_ID int,
   	  ward_name varchar(30),
	  cjid int,
   	  shh varchar(20),
	  s_yppm varchar(100),
	  s_ypspm varchar(100),
	  s_ypgg varchar(100),
	  s_sccj varchar(100),
	  ypsl decimal(15,1),
	  s_ypdw varchar(10),
	  pfje decimal(15,2),
	  lsje decimal(15,2) 
   ) 
   
CREATE  TABLE #JE
   (
   	  ward_ID int,
   	  ward_name varchar(30),
   	  DJZS DECIMAL(15,0),
	  pfje decimal(15,2),
	  LSJE decimal(15,2)
   ) 
   
begin
--住院统领单按药品汇总
if @type=0 and (@tlfl='住院统领' or @tlfl='全部')
begin
	 set @stmt=' insert into #YP(ward_ID,ward_name,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,ypsl,s_ypdw,pfje,lsje)'+
	 	 	  'select dept_ly,dbo.fun_getdeptname(dept_ly) 病区,shh 货号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,cast(ypsl as float) 数量,s_ypdw 单位,pfje,lsje 金额  from (select dept_ly,cjid,sum(ypsl/ydwbl) ypsl,sum(pfje) pfje,sum(lsje) lsje from VI_yf_tld a,VI_yf_tldmx b  '+
	 	 	  'where a.groupid=b.groupid  and fyrq>='''+@dtp1+''' and fyrq<='''+@dtp2+''''
	 if @dept_ly>0
			  set @stmt=@stmt+' and dept_ly='+cast(@dept_ly as varchar(20))+'';
     if @cjid>0 
             set @stmt=@stmt+' and cjid='+cast(@cjid as varchar(10))
	 if @deptid>0
		set @stmt=@stmt+' and deptid='+cast(@deptid as char(10));
	 if rtrim(@lb)<>'全部' 
             set @stmt=@stmt+' and tlfl='''+@lb+'''';

	 set @stmt=@stmt+' group by dept_ly,cjid) a,yp_ypcjd b where a.cjid=b.cjid ';
	 exec(@stmt)
	 PRINT @STMT
	 
end 

--住院统领单按金额汇总
if @type=1 and (@tlfl='住院统领'  or @tlfl='全部')
begin
	 set @stmt=' insert into #JE(ward_ID,ward_name,djzs,pfje,lsje) select dept_ly wardid,dbo.fun_getdeptname(dept_ly) 病区,count(a.groupid) 单据张数,sum(pfje),sum(lsje) 金额 from VI_yf_tld a inner join vi_yf_tldmx b   '+
	 	 	  'on a.groupid=b.groupid   where fyrq>='''+@dtp1+''' and fyrq<='''+@dtp2+'''';
	 if @dept_ly>0 
			  set @stmt=@stmt+' and dept_ly='+cast(@dept_ly as varchar(20))+'';
	 if @deptid>0
		set @stmt=@stmt+' and deptid='+cast(@deptid as char(10));
	 if rtrim(@lb)<>'全部' 
             set @stmt=@stmt+' and tlfl='''+@lb+'''';

	 set @stmt=@stmt+' group by dept_ly  ';
	 exec(@stmt)
	 
end


--住院处方发药按药品汇总
if @type=0 and (@tlfl='住院处方发药'  or @tlfl='全部')
begin
	 set @stmt='insert into #YP(ward_id,ward_name,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,ypsl,s_ypdw,pfje,lsje)'+
	 	 	  'select ksdm  ward_id,dbo.fun_getdeptname(ksdm) 病区,shh 货号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,cast(sum(ypsl) as float) 数量,s_ypdw 单位,sum(pfje),sum(lsje) 金额  from ('+
			  ' select ksdm,cjid,sum(ypsl*b.cfts/ydwbl) ypsl,sum(pfje) pfje,sum(lsje) lsje from VI_yf_fy a,VI_yf_fymx b where a.ywlx in(''020'') and a.id=b.fyid and '+
			  '  fyrq>='''+@dtp1+''' and fyrq<='''+@dtp2+'''';
	 if @dept_ly>0
			  set @stmt=rtrim(@stmt)+' and ksdm='+cast(@dept_ly as varchar(20))+'';
	 if @deptid>0
		set @stmt=@stmt+' and a.deptid='+cast(@deptid as char(10));
         if @cjid>0 
             set @stmt=@stmt+' and cjid='+cast(@cjid as varchar(10))

	 set @stmt=rtrim(@stmt)+' group by ksdm,cjid) a,yp_ypcjd b where a.cjid=b.cjid group by ksdm,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,s_ypdw';
	 exec(@stmt)
	  print @stmt
end 

--住院处方发药按金额汇总
if @type=1 and (@tlfl='住院处方发药'  or @tlfl='全部')
begin
	 set @stmt='insert into #JE(ward_id,ward_name,djzs,pfje,lsje)  select ksdm as ward_id,
				dbo.fun_getdeptname(ksdm) 病区,count(a.id) 单据张数,sum(pfje),sum(lsje) 金额  
			  from vi_yf_fy a inner join vi_yf_fymx b  '+
	 	 	  'on a.id=b.fyid  where  a.ywlx=''020'' and fyrq>='''+@dtp1+''' and fyrq<='''+@dtp2+''''
	 if @dept_ly>0
			  set @stmt=@stmt+' and ksdm='+cast(@dept_ly as varchar(20))+'';
	 if @deptid>0
		set @stmt=@stmt+' and a.deptid='+cast(@deptid as char(10));
	 set @stmt=@stmt+' group by  ksdm ';
	 exec(@stmt)
	 print @stmt
end





if @type=0 
begin
   	set @stmt='select 0 序号,ward_name 病区,shh 货号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,cast(sum(ypsl) as float) 数量,s_ypdw 单位,sum(pfje) 批发金额,sum(lsje) 零售金额  from #YP'+
   	   		' group by ward_id,ward_name,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,s_ypdw order by ward_id,shh';
	 exec(@stmt)
end
if @type=1 
begin
    	set @stmt='select 0 序号,ward_name 病区,sum(djzs) 单据张数,sum(pfje) 批发金额,sum(lsje) 零售金额  from #JE'+
   	   		' group by ward_id,ward_name order by ward_id';
	 exec(@stmt)

end 

end 

END;
