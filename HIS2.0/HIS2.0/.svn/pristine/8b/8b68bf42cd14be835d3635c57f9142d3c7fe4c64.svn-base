IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_TJ_PJRXSLTJ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_TJ_PJRXSLTJ
GO
CREATE PROCEDURE SP_YK_TJ_PJRXSLTJ
 (
   @dtp1 varchar(30),
   @dtp2 varchar(30),
   @yplx int,
   @deptid int
 )

as
BEGIN
 declare @count INT 
 DECLARE @stmt varchar(6000); --定义SQL文本

 --声明临时表
   create table #TEMP
   (
          ID INTEGER  IDENTITY(1,1),
	  ypsl decimal(15,3),
	  ydwbl int,
   	  cjid int
   ) 
   
  
begin
     
	set @count=DATEDIFF(day,@dtp1,@dtp2)+1;

	 set @stmt='select 0  序号,c.s_yppm 品名,c.ypgg 规格,c.s_sccj 厂家,'+
	 'c.pfj 批发价,c.lsj 零售价,cast(round(sum(ypsl/ydwbl),2) as decimal(15,1)) 总销售量,'+cast(@count as varchar(10))+' 天数,'+
         ' dbo.getint(cast(round(sum(ypsl/ydwbl)/'+ cast(@count as char(10))+',3) as decimal(15,3)),1) 平均日销售量,'+
	 'c.s_ypdw 单位,c.cjid, '+
	 '1 ydwbl,c.ypdw nypdw,cast(1 as smallint) 更新 from vi_YK_dj a,vi_YK_djmx b,vi_yp_ypcd c  '+
	 'where a.id=b.djid and b.cjid=c.cjid  and a.deptid='+cast(@deptid as char(10))+' and '+
	 ' a.ywlx in(''003'',''004'',''014'',''017'',''018'',''020'',''022'',''030'') and a.shrq>='''+ @dtp1+''' and a.shrq<='''+@dtp2+''' and a.shbz=1 '
		   
    	 if @yplx>0  
	   set @stmt=@stmt+' and n_yplx='+cast(@yplx as char(8))+'';

 	   set @stmt=@stmt+' group by c.cjid,c.s_yppm,c.ypgg,c.s_sccj,c.pfj,c.lsj,c.s_ypdw,c.ypdw '

	 
         print @stmt
	 exec(@stmt)
	 
  end 
 END;
 


 