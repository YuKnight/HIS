 IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_pd_sum_pdcsmx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_pd_sum_pdcsmx
GO
CREATE PROCEDURE sp_yf_pd_sum_pdcsmx
(  
  @deptid int  
)  
as  
  
create table #temp(cjid int,kcid UNIQUEIDENTIFIER, pcsl decimal(15,3), pxxh int,yppch varchar(50),ypxq datetime,sskcsl decimal(15,3))  
--盘存方式  
declare @pcfs varchar(10)  
set @pcfs=(select ZT from YK_CONFIG where DEPTID=@deptid and BH='998')  
if @pcfs is null set @pcfs='0'  
  
--汇总盘存数,并获得排序序号  
if @pcfs='0'  
 insert into #temp(cjid,kcid,pcsl,pxxh)  
 select x.cjid,x.kcid,cast(sum(pcsl*coalesce(z.dwbl,1)/ydwbl) as float) pcsl,  
 (select top 1 a.djh+pxxh from yf_pdcs a,yf_pdcsmx b where a.id=b.djid and shbz=0 and bdelete=0 and b.kcid=x.kcid order by djrq,pxxh )  as pxxh  
 FROM yf_pdcsmx x inner join yf_pdcs y on x.djid=y.id  
 left join yf_pdtemp z on x.kcid=z.kcid AND z.shbz=0    
 where y.deptid=@deptid and y.shbz=0 and y.bdelete=0   
  group by x.cjid,x.kcid   
else  
begin  
--得出盈亏数据  
create table #tempyks(cjid int,zcsl decimal(15,3), pcsl decimal(15,3), yksl decimal(15,3))  
insert into #tempyks  
select a.CJID,zcsl,pcsl,(pcsl-coalesce(zcsl,0)) from   
(select b.CJID,cast(sum(pcsl*coalesce(c.dwbl,1)/ydwbl) as float) pcsl     
 FROM yf_pdcs  a inner join YF_PDCSMX_KCMX b on a.ID=b.DJID and a.DEPTID=@deptid and SHBZ=0 and BDELETE=0   
 left join (select cjid ,dwbl from yf_pdtemp  where DEPTID=@DEPTID AND shbz=0 group by CJID,DWBL ) c on  b.CJID=c.CJID   
 group by b.CJID,c.DWBL ) a   
 left join   
 (select cjid,sum(kcl) zcsl from yf_pdtemp where DEPTID=@deptid and SHBZ=0 and BDELETE=0 group by cjid) b   
 on a.CJID=b.CJID  where a.pcsl<>b.zcsl  
  
--准备批次盘存数据 
if EXISTS(select * from yp_yjks where deptid=@deptid and KSLX='药房' )
	insert into #temp(cjid,kcid,pcsl,pxxh,yppch,ypxq,sskcsl)  
	select coalesce(b.CJID,a.cjid),coalesce(b.kcid,dbo.FUN_GETEMPTYGUID()) as kcid,coalesce(b.kcl,a.pcsl) as pcsl,  
	(select top 1 x.djh+pxxh from yf_pdcs x,YF_PDCSMX_KCMX y where x.id=y.djid and x.DEPTID=@deptid and shbz=0 and bdelete=0 and y.CJID=b.CJID order by djrq,pxxh )  
	,b.yppch,b.ypxq,c.KCL from  
	(select y.CJID,SUM(pcsl) pcsl  FROM yf_pdcs  x inner join YF_PDCSMX_KCMX y on x.ID=y.DJID and x.DEPTID=@deptid and SHBZ=0 and BDELETE=0 group by y.CJID ) a   
	 left join yf_pdtemp b  
	on a.CJID=b.CJID    
	and  b.DEPTID=@deptid and b.SHBZ=0  and (BDELETE=0 or KCL<>0)  
	inner join YF_KCPH c on b.KCID=c.ID  
else
	insert into #temp(cjid,kcid,pcsl,pxxh,yppch,ypxq,sskcsl)  
	select coalesce(b.CJID,a.cjid),coalesce(b.kcid,dbo.FUN_GETEMPTYGUID()) as kcid,coalesce(b.kcl,a.pcsl) as pcsl,  
	(select top 1 x.djh+pxxh from yf_pdcs x,YF_PDCSMX_KCMX y where x.id=y.djid and x.DEPTID=@deptid and shbz=0 and bdelete=0 and y.CJID=b.CJID order by djrq,pxxh )  
	,b.yppch,b.ypxq,c.KCL from  
	(select y.CJID,SUM(pcsl) pcsl  FROM yf_pdcs  x inner join YF_PDCSMX_KCMX y on x.ID=y.DJID and x.DEPTID=@deptid and SHBZ=0 and BDELETE=0 group by y.CJID ) a   
	 left join yf_pdtemp b  
	on a.CJID=b.CJID    
	and  b.DEPTID=@deptid and b.SHBZ=0  and (BDELETE=0 or KCL<>0)  
	inner join YK_KCPH c on b.KCID=c.ID  
  
--将盈亏数据按照先出先出或近效期先出的原则进行分配.  
--批次管理原则  
declare @pcglyz varchar(10)  
set @pcglyz=(select config from JC_CONFIG where ID=8051)  
if @pcglyz is null set @pcglyz='0'  
  
create table #temp_r(ID INTEGER IDENTITY (1, 1) NOT NULL,cjid int,kcid UNIQUEIDENTIFIER, pcsl decimal(15,3),sskcsl decimal(15,3) )  


--最近的KCID 用于处理无法分解完批次的记录  
declare @zj_kcid UNIQUEIDENTIFIER  
declare @t1_cjid int  
declare @t1_yksl decimal(15,3)  
declare @t2_kcl decimal(15,3)  
declare @t2_kcid UNIQUEIDENTIFIER  
declare @t2_sskcl decimal(15,3)  
declare t1 cursor local for  select cjid,yksl  from #tempyks   
open t1  
fetch next from t1 into  @t1_cjid,@t1_yksl  
while @@FETCH_STATUS=0  
begin   
    delete from #temp_r  
 if @pcglyz='0'   
  insert into #temp_r(pcsl,kcid,sskcsl) select pcsl,kcid ,sskcsl from #temp where cjid=@t1_cjid and pcsl<>0 order by yppch   
 else  
  insert into #temp_r(pcsl,kcid,sskcsl) select pcsl,kcid,sskcsl from #temp where cjid=@t1_cjid and pcsl<>0 order by ypxq  
  
 --拆分批次    
    declare t2 cursor local for  select pcsl,kcid,sskcsl from #temp_r order by id  
 open t2  
 fetch next from t2 into  @t2_kcl,@t2_kcid,@t2_sskcl  
 while @@FETCH_STATUS=0  
 begin  
  if @t1_yksl>0 or (@t1_yksl+@t2_kcl>=0   and @t1_yksl+@t2_sskcl>=0)  
  begin  
   update #temp set pcsl=pcsl+@t1_yksl where kcid=@t2_kcid  
   set @t1_yksl=0  
   fetch next from t2 into  @t2_kcl,@t2_kcid,@t2_sskcl  
   continue  
  end   
  else  
  begin  
     update #temp set pcsl=(case when @t2_sskcl<@t2_kcl then @t2_kcl-@t2_sskcl else 0  end )  where kcid=@t2_kcid      
       
     set @t1_yksl=(case when @t2_sskcl<@t2_kcl then @t1_yksl+@t2_sskcl else @t1_yksl+@t2_kcl end )   -- @t1_yksl+@t2_kcl  
  end  
 fetch next from t2 into  @t2_kcl,@t2_kcid,@t2_sskcl  
 end  
 CLOSE t2  
 DEALLOCATE t2  
 
 --当还有无法拆分的批次时,均放在最近的一个批次上  
 if @t1_yksl<>0  
 begin  
  if @pcglyz='0'   
    set @zj_kcid=(select top 1 kcid from #temp where cjid=@t1_cjid order by yppch desc )  
  else  
    set @zj_kcid=(select top 1 kcid from #temp where cjid=@t1_cjid order by ypxq desc )  
    update #temp set pcsl=pcsl+@t1_yksl where kcid=@zj_kcid  
 
 end  
fetch next from t1 into  @t1_cjid,@t1_yksl  
end  
  
end  
  
 
  
--结果集  
if @pcfs='0'  
select CAST(0 AS CHAR(12)) 序号,B.s_yppm 品名,b.s_ypspm 商品名,b.s_ypgg 规格,s_sccj 厂家,  
coalesce(cast(round(c.jhj/coalesce(c.dwbl,1),4) as decimal(15,4)),0) 进价,  
cast(round(b.pfj/coalesce(c.dwbl,1),4) as decimal(15,4)) 批发价,  
cast(round(b.pfj*coalesce(c.kcl,0)/coalesce(c.dwbl,1),2) as decimal(15,2)) 批发金额,  
 cast(round(b.lsj/coalesce(c.dwbl,1),4) as decimal(15,4)) 零售价,  
 coalesce(c.ypph,'无批号') 批号,d.hwmc 库位,  
 cast(coalesce(c.kcl,0) as float) 帐面数量,  
 cast(round(b.lsj*coalesce(c.kcl,0)/coalesce(c.dwbl,1),2) as decimal(15,2)) 帐面金额,  
 cast(pcsl as float) 盘存数量,   
 coalesce(dbo.fun_yp_ypdw(coalesce(zxdw,0)),b.s_ypdw) 单位,   
 cast(round(b.lsj*cast(a.pcsl as decimal(15,3))/coalesce(c.dwbl,1),2) as decimal(15,2)) 盘存金额,  
( case when (a.pcsl-coalesce(c.kcl,0)) <>0 then (a.pcsl-coalesce(c.kcl,0)) else null end) 盈亏数量,  
(case when cast(round(b.lsj*(a.pcsl-coalesce(c.kcl,0))/coalesce(c.dwbl,1),2) as decimal(15,2))<>0 then cast(round(b.lsj*(a.pcsl-coalesce(c.kcl,0))/coalesce(c.dwbl,1),2) as decimal(15,2)) else null end)  盈亏金额,  
coalesce(cast(round(c.jhj*kcl/coalesce(c.dwbl,1),4) as decimal(15,2)),0) 帐存进货金额,  
coalesce(cast(round(c.jhj*pcsl/coalesce(c.dwbl,1),4) as decimal(15,2)),0) 盘存进货金额,  
cast(round(c.jhj*(a.pcsl-coalesce(c.kcl,0))/coalesce(c.dwbl,1),2) as decimal(15,2)) 盈亏进货金额,  
b.shh 货号, a.cjid,a.kcid,coalesce(c.dwbl,1) dwbl,coalesce(c.kwid,0) kwid,dbo.FUN_GETEMPTYGUID() id   
,c.YPXQ 效期 ,c.YPPCH 批次号 ,dbo.fun_yp_yplx(n_yplx) 药品类型,S_YPJX 剂型  
 from   
 #temp A inner join YP_YPCJD B on a.cjid=b.cjid   
left join  yf_pdtemp  C on a.kcid=c.kcid  and c.deptid=@deptid  and c.shbz=0 --and c.bdelete=0  
left join yp_hwsz d on b.ggid=d.ggid and d.deptid=@deptid   order by pxxh  
else  
select CAST(0 AS CHAR(12)) 序号,B.s_yppm 品名,b.s_ypspm 商品名,b.s_ypgg 规格,s_sccj 厂家,  
coalesce(cast(round(c.jhj/coalesce(c.dwbl,1),4) as decimal(15,4)),0) 进价,  
cast(round(b.pfj/coalesce(c.dwbl,1),4) as decimal(15,4)) 批发价,  
cast(round(b.pfj*coalesce(c.kcl,0)/coalesce(c.dwbl,1),2) as decimal(15,2)) 批发金额,  
 cast(round(b.lsj/coalesce(c.dwbl,1),4) as decimal(15,4)) 零售价,  
 coalesce(c.ypph,'无批号') 批号,d.hwmc 库位,  
 cast(coalesce(c.kcl,0) as float) 帐面数量,  
 cast(round(b.lsj*coalesce(c.kcl,0)/coalesce(c.dwbl,1),2) as decimal(15,2)) 帐面金额,  
 cast(pcsl as float) 盘存数量,   
 coalesce(dbo.fun_yp_ypdw(coalesce(zxdw,0)),b.s_ypdw) 单位,   
 cast(round(b.lsj*cast(a.pcsl as decimal(15,3))/coalesce(c.dwbl,1),2) as decimal(15,2)) 盘存金额,  
( case when (a.pcsl-coalesce(c.kcl,0)) <>0 then (a.pcsl-coalesce(c.kcl,0)) else null end) 盈亏数量,  
(case when cast(round(b.lsj*(a.pcsl-coalesce(c.kcl,0))/coalesce(c.dwbl,1),2) as decimal(15,2))<>0 then cast(round(b.lsj*(a.pcsl-coalesce(c.kcl,0))/coalesce(c.dwbl,1),2) as decimal(15,2)) else null end)  盈亏金额,  
coalesce(cast(round(c.jhj*kcl/coalesce(c.dwbl,1),4) as decimal(15,2)),0) 帐存进货金额,  
coalesce(cast(round(c.jhj*pcsl/coalesce(c.dwbl,1),4) as decimal(15,2)),0) 盘存进货金额,  
cast(round(c.jhj*(a.pcsl-coalesce(c.kcl,0))/coalesce(c.dwbl,1),2) as decimal(15,2)) 盈亏进货金额,  
b.shh 货号, a.cjid,a.kcid,coalesce(c.dwbl,1) dwbl,coalesce(c.kwid,0) kwid,dbo.FUN_GETEMPTYGUID() id   
,c.YPXQ 效期 ,c.YPPCH 批次号 ,dbo.fun_yp_yplx(n_yplx) 药品类型,S_YPJX 剂型  
 from   
 #temp A inner join YP_YPCJD B on a.cjid=b.cjid   
left join  yf_pdtemp  C on a.kcid=c.kcid  and c.deptid=@deptid  and c.shbz=0 --and c.bdelete=0  
left join yp_hwsz d on b.ggid=d.ggid and d.deptid=@deptid where c.kcl<>0 or pcsl<>0  order by pxxh  
  
  


