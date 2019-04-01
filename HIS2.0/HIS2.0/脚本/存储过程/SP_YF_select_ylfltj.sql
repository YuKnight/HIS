
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_select_ylfltj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_select_ylfltj
GO
create PROCEDURE [dbo].[SP_YF_select_ylfltj]    
 (    
    @deptid integer,    
    @dtp1 datetime,    
    @dtp2 datetime,    
    @fid bigint,--统计的节点    
    @functionname varchar(100) --采购入库分类统计 1 出库单分类统计    
 )     
as    
  /*
  jianqg 2013-6-14 优化过程
  */
--exec SP_Yf_select_ylfltj 95,'2006-01-01','2008-01-01',1,'Fun_ts_yf_tjbb_ylfltj_rk'    
--select * from dbo.fun_tlfl_child(1)    
SET @dtp1=@dtp1+' 00:00:00'   SET @dtp2=@dtp2+' 23:59:59'    
    
begin    
declare @ss varchar(4000)    
declare @sumje decimal(15,2)   --整个统计其间的金额    
declare @sumflje decimal(15,2)--药理分类总金额    
    
set @sumje=0    
--统计分类包含的药品    
--select b.ylfl,b.cjid,b.s_ypspm,b.s_yppm,b.s_ypgg,s_ypdw,b.s_sccj,b.lsj -- into #ypcd 
--from dbo.fun_tlfl_child(@fid) a,vi_yp_ypcd b where a.id=b.ylfl  
--jianqg 2013-6-14 修改
create table #ypcd (ylfl bigint,cjid int,s_ypspm varchar(100),s_yppm varchar(100)
,s_ypgg varchar(50),s_ypdw varchar(10),s_sccj varchar(100),lsj numeric(10,2))
if (  @fid=0)
    insert into  #ypcd 
	select b.ylfl,b.cjid,b.s_ypspm,b.s_yppm,b.s_ypgg,s_ypdw,b.s_sccj,b.lsj 
	from vi_yp_ypcd b where YLFL>0
else 
	insert into  #ypcd 
	select b.ylfl,b.cjid,b.s_ypspm,b.s_yppm,b.s_ypgg,s_ypdw,b.s_sccj,b.lsj 
	from dbo.fun_tlfl_child(@fid) a,vi_yp_ypcd b where a.id=b.ylfl     
create table #temp(cjid int,ypsl decimal(15,2) ,lsje decimal(15,2))     
    
if @functionname='Fun_ts_yf_tjbb_ylfltj_rk'    
begin    
 
 set @sumje=(select sum(dbo.FUN_Yf_DRT(a.ywlx,lsje)) 
 from vi_yf_dj a,vi_yf_djmx b where   
 a.id=b.djid and  (@deptid=0 or a.deptid=@deptid) 
 	and (
	(djrq>=@dtp1 and djrq<=@dtp2 and a.ywlx in('001','002') ) or 
	(dbo.Fun_GetDate(shrq)>=@dtp1 and dbo.Fun_GetDate(shrq)<=@dtp2 and a.YWLX in('004','015','016','019','024'))
	) 
 ) --总金额    

          
 --jianqg 2013-6-14 修改   
 --单个药品数量、金额 
  insert into #temp(cjid,ypsl,lsje)    
  select cjid,sum(dbo.FUN_Yf_DRT(ywlx,ypsl)/ydwbl) ypsl,sum(dbo.FUN_Yf_DRT(ywlx,lsje)) lsje from
  ( 
  select b.cjid,sum(ypsl) ypsl,ydwbl,sum(lsje) lsje,a.ywlx
  from vi_yf_dj a,vi_yf_djmx b,#ypcd c where
  a.id=b.djid and b.cjid=c.cjid and (@deptid=0 or a.deptid=@deptid) 
and (
(djrq>=@dtp1 and djrq<=@dtp2 and a.ywlx in('001','002') ) or 
(dbo.Fun_GetDate(shrq)>=@dtp1 and dbo.Fun_GetDate(shrq)<=@dtp2 and a.YWLX in('004','015','016','019','024'))
) 
  group by b.cjid,a.ywlx,ydwbl
  ) aa
  group by cjid  
  --jianqg 2013-6-14 修改
 --总金额  
 --select @sumje=SUM(lsje) from #temp
end     
    
  
if @functionname='Fun_ts_yf_tjbb_ylfltj_ck'    
begin    
  
 set @sumje=(select sum(dbo.FUN_Yf_DRT(a.ywlx,lsje)) from vi_yf_dj a,vi_yf_djmx b 
 where  a.id=b.djid and shrq>=@dtp1 and shrq<=@dtp2 and   (@deptid=0 or a.deptid=@deptid)  and
 a.ywlx in('014','017','018','020','021','022','023','025','026') ) --总金额    



--jianqg 2013-6-14 修改
--单个药品数量、金额 
 insert into #temp(cjid,ypsl,lsje)    
 select cjid,sum(dbo.FUN_Yf_DRT(ywlx,ypsl)/ydwbl) ypsl,sum(dbo.FUN_Yf_DRT(ywlx,lsje)) lsje from 
 (select b.cjid,sum(ypsl) ypsl,ydwbl,sum(lsje) lsje,a.YWLX
 from vi_yf_dj a,vi_yf_djmx b,#ypcd c where shrq>=@dtp1 and shrq<=@dtp2 and    
 a.id=b.djid and b.cjid=c.cjid and a.ywlx in('014','017','018','020','021','022','023','025','026') 
 and (@deptid=0 or a.deptid=@deptid)  and shbz=1    
  group by b.cjid,a.ywlx,ydwbl
  ) aa
 group by cjid  
  --jianqg 2013-6-14 修改
 --总金额  
 --select @sumje=SUM(lsje) from #temp
  

end     
    
set @sumflje=(select sum(lsje) from #temp)    
    

-- --输出明细结果   
if @functionname='Fun_ts_yf_tjbb_ylfltj_rk'   
	select b.cjid,s_ypspm 品名,s_ypgg 规格 ,s_sccj 厂家 ,b.lsj 零售价,cast(ypsl as float) 数量 
	,s_ypdw 单位, cast(lsje as float) 金额
	,cast(cast(case  when round(lsje/@sumflje,4)*100<0 then round(lsje/@sumflje,4)*100  
	 else round(lsje/@sumflje,4)*100 end  as float) as varchar(100))+'%' 百分比
	 ,@sumje 总金额 from #temp a,#ypcd b where a.cjid=b.cjid  order by    round(lsje/@sumflje,4)  desc
else
	select b.cjid,s_ypspm 品名,s_ypgg 规格 ,s_sccj 厂家 ,b.lsj 零售价,cast(ypsl*(-1) as float) 数量 
	,s_ypdw 单位, cast(lsje*(-1) as float) 金额
	,cast(cast(case  when round(lsje/@sumflje,4)*100<0 then round(lsje/@sumflje,4)*100  
	 else round(lsje/@sumflje,4)*100 end  as float) as varchar(100))+'%' 百分比
	 ,@sumje 总金额 from #temp a,#ypcd b where a.cjid=b.cjid   order by   round(lsje/@sumflje,4)  desc
    
--输出汇总结果      
 create table #ok(id bigint,name varchar(100),lsje decimal(15,2),bfbl varchar(100))     
    
declare @lsje decimal(15,2)    
declare @id bigint    
declare @name varchar(100)    
declare t1 cursor for select id,flmc from yp_ylfl where fid=@fid or id=@fid --select ylfl,sum(lsje) lsje from #temp a,#ypcd b where a.cjid=b.cjid group by ylfl      
open t1    
fetch next from t1 into @id,@name    
while @@FETCH_STATUS=0    
begin    
       
    set @lsje=(select sum(lsje) lsje from dbo.fun_tlfl_child(@id) a,#ypcd b,#temp c where a.id=b.ylfl and b.cjid=c.cjid )    
    insert into #ok(id,name,lsje,bfbl)values(@id,@name,@lsje,0) 
    --jianqg  2013-6-14 测试 部分数据，不在分类中   
    --insert into #ok(id,name,lsje,bfbl)
    -- select c.cjid ,b.s_yppm,c.lsje,b.ylfl 
    --from dbo.fun_tlfl_child(@id) a,#ypcd b,#temp c where a.id=b.ylfl and b.cjid=c.cjid 
    
fetch next from t1 into @id,@name    
end    
CLOSE t1    
DEALLOCATE t1    
   
--select * from #ok order by id


insert into #ok(name,lsje,bfbl) select '合计',sum(case when id=@fid or @fid=0 then lsje else 0 end) ,'100%' from #ok -- jianqg  2013-6-14 修改 #temp    
    --
declare @ncount int
select @ncount=COUNT(*) from #ok
if @ncount<>2
begin
  delete #ok where id=@fid
end

select name 名称,case  when lsje<0 then -1*lsje  else lsje end  金额
,cast(cast(case when round(lsje/@sumflje,4)*100<0 then round(lsje/@sumflje,4)*-100 
else round(lsje/@sumflje,4)*100 end  as float) as varchar(100))+'%' 百分比
,case  when @sumje<0 then -1*@sumje  
  
else @sumje end  总金额,id from #ok    
    
  
drop table  #ok  
drop table  #ypcd  
drop table  #temp   
    
    
end