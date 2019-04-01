
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_tj_jhpmtj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_tj_jhpmtj
GO
CREATE PROCEDURE SP_YK_tj_jhpmtj
 (@type int, --0 表示数量 1表示金额
  @yplx INTEGER,--药品类型 
  @dtp1 varchar(30),
  @dtp2 varchar(30),
  @MC int, --名次
  @deptid int,
  @deptid_ck int
 )  
as
BEGIN
declare @count INT 
declare @ss varchar(5000)
 --声明临时表
   create TABLE #TEMP
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
   	  cjid int,
	  sl decimal(15,3),
	  jhje decimal(15,2),
	  pfje decimal(15,2),
	  lsje decimal(15,2)
   ) 
   
   create TABLE  #TEMP1
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
   	  cjid int,
	  sl decimal(15,3),
	  jhje decimal(15,2),
	  pfje decimal(15,2),
	  lsje decimal(15,2)
   ) 
   
create table #deptid(deptid int)
--需要统计的科室
if (@deptid_ck>0)
  insert #deptid(deptid)values(@deptid_ck)
else 
  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID

  p2:begin
     
	--当前表
	 set @ss='insert into #temp(cjid,sl,jhje,pfje,lsje)select c.cjid,sum(dbo.fun_yk_drt(a.ywlx,ypsl)),sum(dbo.fun_yk_drt(a.ywlx,jhje)),sum(dbo.fun_yk_drt(a.ywlx,pfje)),sum(dbo.fun_yk_drt(a.ywlx,lsje)) from yk_dj a(nolock),yk_djmx b(nolock) ,vi_yp_ypcd c(nolock) '+
	          'where a.id=b.djid and b.cjid=c.cjid  and a.deptid in(select deptid from #deptid)  and '+
			  ' a.ywlx in(''001'',''002'') and a.djrq>='''+ @dtp1+''' and a.djrq<='''+@dtp2+'''';
		 if @yplx<>0 
		 begin
		     set @ss=@ss+' and yplx='+cast(@yplx as char(10))+'';
		 end 
		 	 set @ss=@ss+' group by c.cjid ';
		 
	exec(@ss)
	 
	 --备份表
	 set @ss='insert into #temp(cjid,sl,jhje,pfje,lsje)select c.cjid,sum(dbo.fun_yk_drt(a.ywlx,ypsl)),sum(dbo.fun_yk_drt(a.ywlx,jhje)),sum(dbo.fun_yk_drt(a.ywlx,pfje)),sum(dbo.fun_yk_drt(a.ywlx,lsje)) from yk_dj_h a (nolock),yk_djmx_h b(nolock) ,vi_yp_ypcd c '+
	          'where a.id=b.djid and b.cjid=c.cjid  and a.deptid in(select deptid from #deptid) and '+
			  ' a.ywlx in(''001'',''002'') and a.djrq>='''+ @dtp1+''' and a.djrq<='''+@dtp2+'''';
		 if @yplx<>0 
                 begin
		     set @ss=@ss+' and yplx='+cast(@yplx as char(10))+'';
                 end
		 	 set @ss=@ss+' group by c.cjid ';
		 
	 exec(@ss)
	 
	 
	 set @ss='insert into #temp1(cjid,sl,jhje,pfje,lsje)select top '+cast(@mc as char(10)) +' cjid,sum(sl),sum(jhje),sum(pfje),sum(lsje)'+
	  ' from #temp group by cjid ';
	 if @type=0 
         begin
		   set @ss=@ss+' order by sum(sl) desc '
	 end
		 
	 if @type=1 
         begin
		   set @ss=@ss+' order by sum(lsje) desc '
	 end 
	 
	 if @type=2 
         begin
	       set @ss=@ss+' order by sum(jhje) desc '
         end
	  
	 exec(@ss)
	 
	 
	 set @ss='select id 排名,s_ypspm 品名,s_ypgg 规格,s_sccj 厂家,'+
	 'pfj 批发价,lsj 零售价,sl 数量,s_ypdw 单位,jhje 进货金额,pfje 批发金额,'+
	 ' lsje 零售金额,(lsje-jhje) 进零差额,shh 货号 from #temp1 a,yp_ypcjd b where a.cjid=b.cjid order by a.id';
	exec(@ss)
	 
	 
  end 
 END;
 
 
 