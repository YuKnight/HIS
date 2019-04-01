IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_tj_PYRGZL' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_tj_PYRGZL
GO
CREATE PROCEDURE SP_YF_tj_PYRGZL
 ( @type int, --0 配药人工作 1发药人工作量
   @dtp1 varchar(30),
   @dtp2 varchar(30),
   @deptid int
 )  
as
BEGIN
 declare @count INT
 DECLARE @stmt varchar(1000); --定义SQL文本


 --声明临时表
create TABLE #temp
   (
      ID INTEGER IDENTITY (1,1),
   	  pyr int,
	  fyr int ,
	  cflx varchar(10),
	  cfts int,
	  zje decimal(15,2),
	  deptid int
   )
   
  
begin
     
	
	 set @stmt='insert into #temp(pyr,fyr,cflx,cfts,zje,deptid)select pyr,fyr,cflx,a.cfts ,sum(lsje),a.deptid from yf_fy a,yf_fymx b   '+
	          'where  a.id=b.fyid and fyrq>='''+ @dtp1+' 00:00:00'' and fyrq<='''+@dtp2+' 23:59:59''';
	 if @deptid<>0  
	 	set @stmt=@stmt+' and a.deptid='+cast(@deptid as char(8))+'';
	 set @stmt=@stmt+' group by  a.id,pyr,fyr,cflx,a.cfts ,a.deptid '
	exec(@stmt);

	 set @stmt='insert into #temp(pyr,fyr,cflx,cfts,zje,deptid)select pyr,fyr,cflx,a.cfts ,sum(lsje),a.deptid from yf_fy_h  a,yf_fymx_h b  '+
	          'where a.id=b.fyid and fyrq>='''+ @dtp1+' 00:00:00'' and fyrq<='''+@dtp2+' 23:59:59''';
	 if @deptid<>0  
	 	set @stmt=@stmt+' and a.deptid='+cast(@deptid as char(8))+'';
	 set @stmt=@stmt+' group by  a.id,pyr,fyr,cflx,a.cfts ,a.deptid'
	exec(@stmt);

	 if @type=0 
	 	 set @stmt='select dbo.fun_getdeptname(deptid) 药房,dbo.fun_getempname(pyr) 姓名,
			  count(pyr) 处方张数,
			  sum(case when cfts>1 then cfts else 0 end) 中药剂数,
			  sum(zje) 处方金额
			  from #temp group by deptid,pyr order by deptid';

	 if @type=1  
	 	 set @stmt='select dbo.fun_getdeptname(deptid) 药房,dbo.fun_getempname(fyr) 姓名,
			  count(*) 处方张数,
			  sum(case when cfts>1 then cfts else 0 end) 中药剂数,
			  sum(zje) 处方金额
			  from #temp group by deptid,fyr order by deptid';
	 
	exec(@stmt)
	 
  end 
 END;
 
 
 