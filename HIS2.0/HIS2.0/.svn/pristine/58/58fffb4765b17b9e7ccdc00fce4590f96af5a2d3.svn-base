IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_yp_tj_jxchzb_hq]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_yp_tj_jxchzb_hq]
GO
CREATE PROCEDURE [dbo].[sp_yp_tj_jxchzb_hq]       
(      
 @yk int,      
 @jhjetj int,      
 @year int,      
 @month int,      
    @ERR_CODE INTEGER output,      
    @ERR_TEXT VARCHAR(250) output      
)      
as      
      
/*      
declare @err_code int      
declare @err_text varchar(300)      
exec sp_yp_tj_jxchzb_hq @yk=0,@jhjetj=1,@year=2014,@month=8,@err_code=@err_code output,@err_text=@err_text output      
select @err_code,@err_text      
      
*/      
begin      
      
      
create table #ywlx(ywlx varchar(30),ywmc varchar(50),ywzt varchar(10),ywfx varchar(10),ywjc varchar(30),tjlx varchar(50),ywlxpxfs int,wldwhz int,wldwlx int)      
      
--准备本月或本年月结记录ID       
create table #tempyjjl(yjid uniqueidentifier,kjnf int ,kjyf int,deptid int,qc smallint ,qm smallint)      
if @yk=1       
begin      
 insert into #tempyjjl(yjid,kjnf,kjyf,deptid)      
 select b.ID,KJNF,KJYF,a.DEPTID from YP_YJKS a left join YP_KJQJ b on a.DEPTID=b.DEPTID and KJNF=@year and ((KJYF=@month and @month>0) or @month=0) where a.KSLX='药库' and QYBZ=1      
 insert into #ywlx(ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx) select ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx from yk_ywlx      
end      
else      
begin      
 insert into #tempyjjl(yjid,kjnf,kjyf,deptid)      
 select b.ID,KJNF,KJYF,a.DEPTID from YP_YJKS a left join YP_KJQJ b on a.DEPTID=b.DEPTID and KJNF=@year and ((KJYF=@month and @month>0) or @month=0)  where a.KSLX='药房' and QYBZ=1      
 insert into #ywlx(ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx) select ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx from yf_ywlx      
end      
--如果统计年报表      
if @month=0      
begin      
  select deptid,min(kjyf) minyf,MAX(kjyf) maxyf into #temp_max from #tempyjjl group by deptid       
  update a set a.qc=1 from #tempyjjl a inner join #temp_max b on a.deptid=b.deptid and a.kjyf<>minyf        
  update a set a.qm=1 from #tempyjjl a inner join #temp_max b on a.deptid=b.deptid and a.kjyf<>maxyf      
end      
      
--业务发生      
create table #temp (deptid int,ywlx varchar(30),wldw int,jhje decimal(15,2),lsje decimal(15,2),qc int ,qm int ,wldwlx int ,tjlx varchar(30),tjlxpxfs int,ywlxpxfs int)      
insert into #temp(deptid,ywlx,wldw,jhje,lsje,qc,qm)      
select a.deptid,a.ywlx,A.WLDW,SUM(JHJE) JHJE,SUM(LSJE) LSJE,qc,qm from YP_TJ_YMJCMX a inner join #tempyjjl b on a.yjid=b.yjid       
 group by a.deptid,a.ywlx,WLDW,qc,qm      
if @month=0      
begin      
 delete  #temp where (qc=1 and ywlx in('000','999')) or (qc=0 and ywlx='999' )      
 delete  #temp where (qm=1 and ywlx in('000','999')) or (qm=0 and ywlx='000' )       
end      
      
update a set wldw=(case when wldwhz=1 then 0 else wldw end),a.wldwlx=b.wldwlx from #temp a inner join #ywlx b on a.ywlx=b.YWLX       
      
---准备药剂科室      
create table #yjks(ksmc varchar(100),deptid int)      
if @yk=1       
 insert into #yjks      
 select  rtrim(KSMC) as xmmc ,deptid from yp_yjks a inner join jc_dept_property b on a.DEPTID=b.DEPT_ID and kslx='药库' and (b.NAME like '%花桥%') order by  a.pxxh      
else      
 insert into #yjks      
 select  rtrim(KSMC) as xmmc ,DEPTID from yp_yjks a inner join jc_dept_property b on a.DEPTID=b.DEPT_ID and kslx='药房' and (b.NAME like '%花桥%') order by a.pxxh     
       
       
---------------------------------------------期初与结存----------------------------------------------------------------_      
create table #tempX (xmmc varchar(100),deptid int,jhje decimal(15,2),lsje decimal(15,2),pxfs varchar(30))      
insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
select (case when ywlx='000' then '一、期初结存' else '五、期未结存' end) xmmc ,deptid,SUM(jhje),SUM(lsje),      
(case when ywlx='000' then '0' else '999' end) from #temp where ywlx in('000','999')  group by ywlx,deptid      
if @@ROWCOUNT=0      
begin      
 insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
 select '一、期初结存' xmmc ,b.deptid,null,null,'0' from   #yjks  b       
 union all      
 select '五、期未结存' xmmc ,b.deptid,null,null,'999' from  #yjks  b        
end      
---------------------------------------------本期增加----------------------------------------------------------------_      
declare @i int      
set @i=0      
insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
select  '二、本期增加'  xmmc ,deptid,      
SUM(case when b.ywfx='-' then jhje*(-1) else jhje end),      
SUM(case when b.ywfx='-' then lsje*(-1) else lsje end),'2'      
from #temp a inner join #ywlx b on a.ywlx=b.YWLX  where b.tjlx='本期增加' group by deptid      
if @@ROWCOUNT=0      
 insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
 select  '二、本期增加'  xmmc ,deptid,null,null,'2'from #yjks         
      
      
insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
select        
--'    '+(case when b.wldwlx=1 then isnull(dbo.fun_yp_ghdw(wldw),'') else isnull(dbo.fun_getDeptname(wldw),'') end) +ywjc,deptid,      
--Modify By Tany 2015-08-10 不显示业务科室详细名称
'    '+ywjc,deptid,
(case when YWFX='-' then SUM(jhje)*(-1) else SUM(jhje) end) as jhje,      
(case when YWFX='-' then SUM(lsje)*(-1) else SUM(lsje) end) as lsje,'200'+cast(isnull(b.ywlxpxfs,0) as varchar(30))      
from #temp a inner join #ywlx b on a.ywlx=b.YWLX  where b.tjlx='本期增加' group by deptid,ywjc,wldw,b.ywlxpxfs,b.wldwlx,b.YWFX      
if @@ROWCOUNT=0      
begin      
 while( @i<2)      
 begin      
   set @i=@i+1      
   insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
   select top 6 '',deptid,null,null,'200'+cast(isnull(a.ywlxpxfs,0) as varchar(30)) from #ywlx a left join #yjks  b on 1=1 where tjlx='本期增加'      
 end      
end      
      
---------------------------------------------本期减少----------------------------------------------------------------_      
      
insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
select  '三、本期减少'  xmmc ,deptid,SUM((case when ywfx<>'-' then jhje*(-1) else jhje end)),  
SUM((case when ywfx<>'-' then lsje*(-1) else lsje end)),'3'      
from #temp a inner join #ywlx b on a.ywlx=b.YWLX  where b.tjlx='本期减少' group by deptid      
if @@ROWCOUNT=0      
 insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
 select  '三、本期减少'  xmmc ,deptid,null,null,'3'from #yjks         
   
   
insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
select        
--'    '+(case when b.wldwlx=1 then isnull(dbo.fun_yp_ghdw(wldw),'') else isnull(dbo.fun_getDeptname(wldw),'') end) +ywjc,deptid,      
--Modify By Tany 2015-08-10 不显示业务科室详细名称
'    '+ywjc,deptid,
(case when YWFX<>'-' then SUM(jhje)*(-1) else SUM(jhje) end) as jhje,      
(case when YWFX<>'-' then SUM(lsje)*(-1) else SUM(lsje) end) as lsje,'300'+cast(isnull(b.ywlxpxfs,0) as varchar(30))      
from #temp a inner join #ywlx b on a.ywlx=b.YWLX  where b.tjlx='本期减少' group by deptid,ywjc,wldw,b.ywlxpxfs,b.wldwlx,b.YWFX      
if @@ROWCOUNT=0      
begin      
 set @i=0      
 while( @i<2)      
 begin      
   set @i=@i+1      
   insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
   select  top 7 '',deptid,null,null,'300'+cast(isnull(a.ywlxpxfs,0) as varchar(30)) from #ywlx a left join #yjks  b on 1=1 where tjlx='本期减少'      
 end      
end      
---------------------------------------------本期其它----------------------------------------------------------------_      
      
insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
select  '四、本期其它'  xmmc ,deptid,SUM(case when ywfx='-' then jhje*(-1) else jhje end),    
SUM(case when ywfx='-' then lsje*(-1) else lsje end),'4'      
from #temp a inner join #ywlx b on a.ywlx=b.YWLX  where b.tjlx='本期其它' group by deptid      
if @@ROWCOUNT=0      
insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
select  '四、本期其它'  xmmc ,deptid,null,null,'4' from #yjks      
union select  '  '+ywjc  xmmc ,deptid,null,null,'400'+cast(isnull(a.ywlxpxfs,0) as varchar(30))      
from #ywlx a left join #yjks  b on 1=1 where tjlx='本期其它'      
      
insert into #tempX(xmmc,deptid,jhje,lsje,pxfs)       
select        
--'    '+(case when b.wldwlx=1 then isnull(dbo.fun_yp_ghdw(wldw),'') else isnull(dbo.fun_getDeptname(wldw),'') end) +ywjc,deptid,      
--Modify By Tany 2015-08-10 不显示业务科室详细名称
'    '+ywjc,deptid,
(case when YWFX='-' then SUM(jhje)*(-1) else SUM(jhje) end) as jhje,      
(case when YWFX='-' then SUM(lsje)*(-1) else SUM(lsje) end) as lsje,'400'+cast(isnull(b.ywlxpxfs,0) as varchar(30))      
from #temp a inner join #ywlx b on a.ywlx=b.YWLX  where b.tjlx='本期其它' group by deptid,ywjc,wldw,b.ywlxpxfs,b.wldwlx,b.YWFX      
      
--  select * from yf_ywlx    
-----------------------------------------输出      
      
      
declare @sql varchar(5000)      
declare @je varchar(30)      
set @je='jhje'      
if @jhjetj=0 set @je='lsje'      
      
 set @sql = 'select xmmc 项目,sum('+@je+') as 合计,'        
 select @sql = @sql + 'sum(case rtrim(ksmc) when '''+rtrim(ksmc)+'''        
 then '+@je+' else null end) as '''+ rtrim(ksmc) +''','        
 from (select   ksmc from #yjks  ) as a        
 select @sql = left(@sql,len(@sql)-1)         
 select @sql = @sql + ' into #result from #tempX a  '+        
 ' inner join  #yjks  b  '+        
 'ON a.deptid=b.deptid  group by a.xmmc,pxfs order by pxfs'        
 exec(@sql + ';       
 select * from #result a  ;')        
        
      
--select * from yk_ywlx      
--select * from #tempX      
set @ERR_CODE=0      
set @ERR_TEXT='保存成功'        
      
end 
GO


