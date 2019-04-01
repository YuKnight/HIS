IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_tj_jhpmtj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_tj_jhpmtj
GO
CREATE PROCEDURE SP_YF_tj_jhpmtj
 ( @type int, 
   @yplx INTEGER,
   @dtp1 varchar(30),
   @dtp2 varchar(30),
   @MC int,
   @deptid int
 )  
as
BEGIN
 declare @count INT
 DECLARE @stmt varchar(1000); --定义SQL文本

 --声明临时表
   create table #TEMP
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
   	  cjid int,
	  sl decimal(15,3),
	  jhje decimal(15,2),
	  pfje decimal(15,2),
	  lsje decimal(15,2)
   ) 
   
     create table #TEMP1
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
   	  cjid int,
	  sl decimal(15,3),
	  jhje decimal(15,2),
	  pfje decimal(15,2),
	  lsje decimal(15,2)
   ) 
   
begin
     
	  --当前表
	 set @stmt='insert into #temp(cjid,sl,pfje,lsje)select c.cjid,sum(ypsl),sum(pfje),sum(lsje) from YF_dj a,YF_djmx b ,vi_yp_ypcd c '+
	          'where a.id=b.djid  and b.cjid=c.cjid  and a.deptid='+cast(@deptid as char(10))+' and '+
			  ' a.ywlx=''016'' and a.shrq>='''+ @dtp1+' 00:00:00'' and a.shrq<='''+@dtp2+' 23:59:59'' and a.shbz=1 ';
		 if @yplx<>0
		     set @stmt=@stmt+' and yplx='+cast(@yplx as char(10))+''
		set @stmt=@stmt+' group by c.cjid ';

	exec(@stmt);
	  --备份表
	 set @stmt='insert into #temp(cjid,sl,pfje,lsje)select c.cjid,sum(ypsl),sum(pfje),sum(lsje) from YF_dj_h a,YF_djmx_h b ,vi_yp_ypcd c '+
	          'where a.id=b.djid  and b.cjid=c.cjid  and a.deptid='+cast(@deptid as char(10))+' and '+
			  ' a.ywlx=''016'' and a.shrq>='''+ @dtp1+' 00:00:00'' and a.shrq<='''+@dtp2+' 23:59:59'' and a.shbz=1 ';
		 if @yplx<>0
		     set @stmt=@stmt+' and yplx='+cast(@yplx as char(10))+'';
		set @stmt=@stmt+' group by c.cjid ';

	exec(@stmt);
	 
	  set @stmt='insert into #temp1(cjid,sl,jhje,pfje,lsje)select top '+cast(@mc as char(10)) +' cjid,sum(sl),sum(jhje),sum(pfje),sum(lsje)'+
	  ' from #temp group by cjid ';
	 if @type=0
		   set @stmt=@stmt+' order by sum(sl) desc ';
		 
	 if @type=1
		   set @stmt=@stmt+' order by sum(lsje) desc ';
	  
	exec(@stmt);
	 
	 
	 set @stmt='select a.id 排名,s_ypspm 品名,s_ypgg 规格,s_sccj 厂家,'+
	 'pfj 批发价,lsj 零售价,sl 数量,s_ypdw 单位,pfje 批发金额,'+
	 ' lsje 零售金额,shh 货号 from #temp1 a,yp_ypcjd b where a.cjid=b.cjid order by a.id';
	 exec(@stmt)
	 
  end 
 END;
 
 
 