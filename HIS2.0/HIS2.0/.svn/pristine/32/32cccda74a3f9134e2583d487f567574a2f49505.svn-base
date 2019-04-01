

IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_tj_tldhz_PFJE' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_tj_tldhz_PFJE
GO
CREATE PROCEDURE SP_YF_tj_tldhz_PFJE
 (
   @dtp1 varchar(30),
   @dtp2 varchar(30),
   @deptid int
 )  
as
BEGIN
 declare @count INT 
 DECLARE @stmt varchar(6000); --定义SQL文本

-- exec SP_YF_tj_tldhz_PFJE '2013-1-01 00:00:00','2013-8-01 00:00:00',21

CREATE  TABLE #JE
   (
   	  ward_ID int,
   	  ward_name varchar(30),
   	  DJZS DECIMAL(15,0),
	  pfje decimal(15,2),
	  LSJE decimal(15,2),
	  yplx varchar(50)
   ) 
   
begin

create table #tempkjxm(xmmc varchar(50))
insert into #tempkjxm
select  MC from yp_yplx where TJDXM in ('01','02','03') order by ID



--住院统领单按金额汇总
 set @stmt=' insert into #JE(ward_ID,ward_name,djzs,pfje,lsje,yplx) 
		select dept_ly wardid,dbo.fun_getdeptname(dept_ly) 病区,count(a.groupid) 单据张数,sum(pfje),sum(lsje) 金额,dbo.fun_yp_yplx(n_yplx)
		 from VI_yf_tld a inner join vi_yf_tldmx b   '+
 	 	  'on a.groupid=b.groupid inner join yp_ypcjd c on b.cjid=c.cjid  where fyrq>='''+@dtp1+''' and fyrq<='''+@dtp2+'''';
 if @deptid>0
	set @stmt=@stmt+' and deptid='+cast(@deptid as char(10));
 set @stmt=@stmt+' group by dept_ly,n_yplx  ';
 exec(@stmt)
	 

--住院处方发药按金额汇总
 set @stmt='insert into #JE(ward_id,ward_name,djzs,pfje,lsje,yplx)  select ksdm as ward_id,
			dbo.fun_getdeptname(ksdm) 病区,count(a.id) 单据张数,sum(pfje),sum(lsje) 金额,dbo.fun_yp_yplx(n_yplx)  
		  from vi_yf_fy a inner join vi_yf_fymx b  '+
 	 	  'on a.id=b.fyid  inner join yp_ypcjd c on b.cjid=c.cjid 
 	 	  where  a.ywlx=''020'' and fyrq>='''+@dtp1+''' and fyrq<='''+@dtp2+''''
 if @deptid>0
	set @stmt=@stmt+' and a.deptid='+cast(@deptid as char(10));
 set @stmt=@stmt+' group by  ksdm,n_yplx ';
 exec(@stmt)
 print @stmt



set @stmt='select ROW_NUMBER()OVER(getdate()) 序号,ward_name 病区,sum(djzs) 单据张数,sum(pfje) 批发金额,sum(lsje) 零售金额  from #JE'+
	' group by ward_id,ward_name order by ward_id';
	
	 set @stmt = 'select  cast(ROW_NUMBER()OVER(order by getdate())  序号,ward_name 病区,'  
 select @stmt =@stmt + 'sum(case a.yplx when '''+rtrim(xmmc)+'''  
 then pfje else null end) as '''+ rtrim(xmmc) +'进货金额'','  
 from (select   xmmc from #tempkjxm  ) as a  
 select @stmt = left(@stmt,len(@stmt)-1)   
 select @stmt = @stmt + ',sum(pfje) 合计进货金额,sum(lsje) 零售金额 into #result from #je a  '+  
 ' inner JOIN yp_yplx as b  '+  
 'ON a.yplx = B.MC   group by ward_id,ward_name   '  
 
 	 set @stmt = @stmt+' union all select  ''合计''  序号,null 病区,'  
 select @stmt =@stmt + 'sum(case a.yplx when '''+rtrim(xmmc)+'''  
 then pfje else null end) as '''+ rtrim(xmmc) +'进货金额'','  
 from (select   xmmc from #tempkjxm  ) as a  
 select @stmt = left(@stmt,len(@stmt)-1)   
 select @stmt = @stmt + ',sum(pfje) 合计进货金额,sum(lsje) 零售金额   from #je a  '+  
 ' inner JOIN yp_yplx as b  '+  
 'ON a.yplx = B.MC     '  
 
 exec(@stmt + '; 
 select * from #result a ;')  
 
  exec(@stmt)
-- exec SP_YF_tj_tldhz_PFJE '2013-1-01 00:00:00','2013-8-01 00:00:00',21
end 

END;
