
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YP_KSSZB_ZYDDD' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YP_KSSZB_ZYDDD
GO
CREATE PROCEDURE [dbo].[SP_YP_KSSZB_ZYDDD]
	@rq1 varchar(30),	@rq2 varchar(30),
    @tjlx int, --0按药品 1 按科室 2按医生 
	@ksdm int,
	@ysdm int

AS

BEGIN
--EXEC SP_YP_KSSZB_ZYDDD '2011-08-01','2011-08-15',0,0,0


declare @sql varchar(8000)
declare @ljddd decimal(15,2) --累计DDD
declare @cyrs int --出院人数
declare @zyts int --平均住院天数
declare @tqszhzts int--同期收治忠者天数
declare @syqd decimal(15,2)--抗菌药物强度
declare @kjywcyzrs int --使用率

create table #temp(ksdm int,ysdm int,cjid int,rs int,ykdwsl decimal(15,3))
-----------------------------------------------------按药品统计
if @tjlx=0
begin
	--药品使用量
	insert into #temp(cjid,ykdwsl)
	SELECT xmid,sum(ypsl) from YP_KSS_RTJ_ZYYP a inner join vi_yp_ypcd b 
	on a.xmid=b.cjid inner join YP_KSS_RTJ_CYBR c on a.inpatient_id=c.inpatient_id
	where c.dept_id<>201  and kssdjid>0 and ddd>0 and 
	OUT_DATE between @rq1+' 00:00:00' and @rq2+' 23:59:59'
	and (@ksdm=0 or (@ksdm>0 and dept_id=@ksdm)) 
	--and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm))
	group by xmid

	set @ljddd=( select sum((ykdwsl*hlxs)/ddd) 每种累计ddd from #temp a,vi_yp_ypcd b where a.cjid=b.cjid and ddd>0)
	--出院人数
	set @cyrs=(select count(*) from YP_KSS_RTJ_CYBR  
	where dept_id<>201  and OUT_DATE between ''+@rq1+' 00:00:00' and ''+@rq2+' 23:59:59' 
	and (@ksdm=0 or (@ksdm>0 and dept_id=@ksdm)) 
	--and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm))
		)
	--平均住院天数
	set @zyts=(select cast(round(avg(datediff(day,in_DATE,OUT_DATE)),2)as float) from YP_KSS_RTJ_CYBR  
	where dept_id<>201 and OUT_DATE between ''+@rq1+' 00:00:00' and ''+@rq2+' 23:59:59'
		and (@ksdm=0 or (@ksdm>0 and dept_id=@ksdm)) 
	--and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm))  
	)
	--同期收治忠者天数
	set @tqszhzts=@zyts*@cyrs
	--抗菌药物强度
	if @tqszhzts>0
		set @syqd=(@ljddd/@tqszhzts)*100
	--使用率
		set @kjywcyzrs=(select count(*) from (select b.inpatient_id from 		YP_KSS_RTJ_ZYYP a inner join YP_KSS_RTJ_CYBR b on a.inpatient_id=b.inpatient_id		inner join vi_yp_ypcd c on a.xmid=c.cjid and kssdjid>0		where b.dept_id<>201 and OUT_DATE>=@rq1+' 00:00:00' and OUT_DATE<=@rq2+' 23:59:59' 		and (@ksdm=0 or (@ksdm>0 and dept_id=@ksdm)) 
		--and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm))		group by b.inpatient_id ) a)
	declare @ksssyl decimal(15,3)
	if @cyrs>0
		set @ksssyl=@kjywcyzrs/cast(@cyrs as float)
	else
		set @ksssyl=0;

select '' 序号,yppm 品名,ypspm 商品名,ypgg 规格,cast(ykdwsl as float) 数量, 
dbo.fun_yp_ypdw(bzdw) 单位,cast(ykdwsl*hlxs as float) 用量,
DDD ,cast(round((ykdwsl*hlxs)/ddd,3) as decimal(18,2)) 每种累计DDD值
from #temp a,vi_yp_ypcd b where a.cjid=b.cjid and ddd>0 order by yppm

select @ljddd 累计DDD数,@tqszhzts 同期收治患者人天数,@syqd 抗菌药物使用强度,
@kjywcyzrs 使用抗菌药物出院总人数,@cyrs 总出院人数,@zyts 平均住院天数,
cast(cast(@ksssyl*100 as float) as varchar(50))+'%' 抗菌药物使用率


end



--------------------------------------------------按科室统计----------------------
if @tjlx=1
BEGIN
	create table #temp_ks(ksdm int,ysdm int,ljddd decimal(15,2),tqszhzts int,kjywsyrs int,cyrs int,pjzyts int)
	insert into #temp_ks(ksdm,ysdm,ljddd,tqszhzts,kjywsyrs,cyrs)
	SELECT  c.dept_id,0,sum((ypsl*hlxs)/ddd),0,0,0 from YP_KSS_RTJ_ZYYP a inner join vi_yp_ypcd b 
	on a.xmid=b.cjid inner join YP_KSS_RTJ_CYBR c on a.inpatient_id=c.inpatient_id
	where  c.dept_id<>201 and   kssdjid>0 and ddd>0 and
	OUT_DATE  between @rq1+' 00:00:00' and @rq2+' 23:59:59'
	and (@ksdm=0 or (@ksdm>0 and c.dept_id=@ksdm)) 
	and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm))
	group by  c.dept_id

	--人均患者人天数 ,总出院人数
	insert into #temp_ks(ksdm,ysdm,ljddd,tqszhzts,kjywsyrs,cyrs,pjzyts)
	select dept_id,0 as ysdm,0 as ljddd,round(avg(datediff(day,in_DATE,OUT_DATE)),2)* count(*),
	0,count(*),round(avg(datediff(day,in_DATE,OUT_DATE)),2) from YP_KSS_RTJ_CYBR  
	where dept_id<>201  and OUT_DATE between ''+@rq1+' 00:00:00' and ''+@rq2+' 23:59:59' 
		and (@ksdm=0 or (@ksdm>0 and dept_id=@ksdm)) 
	and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm))   group by dept_id

	--使用抗菌药物人数
	insert into #temp_ks(ksdm,ysdm,ljddd,tqszhzts,kjywsyrs,cyrs)
	select dept_id,0,0,0,count(*),0 from (
	select b.dept_id,b.inpatient_id from 	YP_KSS_RTJ_ZYYP a inner join YP_KSS_RTJ_CYBR b on a.inpatient_id=b.inpatient_id	inner join vi_yp_ypcd c on a.xmid=c.cjid and kssdjid>0	where b.dept_id<>201 and OUT_DATE>=@rq1+' 00:00:00' and OUT_DATE<=@rq2+' 23:59:59'  	and (@ksdm=0 or (@ksdm>0 and dept_id=@ksdm)) 
	and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm))	group by b.dept_id,b.inpatient_id ) a group by dept_id

	
	select '序号' as 序号,dbo.fun_getdeptname(ksdm) 科室,round(sum(ljddd),2) 累计DDD数,sum(tqszhzts) 同期收治患者人天数,
	cast(round((sum(ljddd)/sum(tqszhzts))*100,2) as float) 抗菌药物使用强度,sum(kjywsyrs) 使用抗菌药物出院总人数,sum(cyrs) 总出院人数,sum(pjzyts) 平均住院天数,
	cast(cast(round(sum(kjywsyrs)/cast(sum(cyrs) as float),4) as float)*100 as varchar(50))+'%' 抗菌药物使用率 from #temp_ks 
	group by ksdm
	union all
	select '合计' as 序号, '' 科室,round(sum(ljddd),2) 累计DDD数,sum(tqszhzts) 同期收治患者人天数,
	cast(round((sum(ljddd)/sum(tqszhzts))*100,2) as float) 抗菌药物使用强度,sum(kjywsyrs) 使用抗菌药物出院总人数,sum(cyrs) 总出院人数,avg(pjzyts) 平均住院天数,
	cast(cast(round(sum(kjywsyrs)/cast(sum(cyrs) as float),4) as float)*100 as varchar(50))+'%' 抗菌药物使用率 from #temp_ks 
	 


END


if @tjlx=2
begin
	create table #temp_ys(ksdm int,ysdm int,ljddd decimal(15,2),tqszhzts int,kjywsyrs int,cyrs int,pjzyts int)
	insert into #temp_ys(ksdm,ysdm,ljddd,tqszhzts,kjywsyrs,cyrs)
	SELECT  c.dept_id,c.zy_doc,sum((ypsl*hlxs)/ddd),0,0,0 from YP_KSS_RTJ_ZYYP a inner join vi_yp_ypcd b 
	on a.xmid=b.cjid inner join YP_KSS_RTJ_CYBR c on a.inpatient_id=c.inpatient_id
	where  c.dept_id<>201 and   kssdjid>0 and ddd>0 and 
	OUT_DATE  between @rq1+' 00:00:00' and @rq2+' 23:59:59'
	and (@ksdm=0 or (@ksdm>0 and c.dept_id=@ksdm)) 
	and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm))
	group by  c.dept_id,c.zy_doc

	--人均患者人天数 ,总出院人数
	insert into #temp_ys(ksdm,ysdm,ljddd,tqszhzts,kjywsyrs,cyrs,pjzyts)
	select dept_id,zy_doc as ysdm,0 as ljddd,round(avg(datediff(day,in_DATE,OUT_DATE)),2)* count(*),
	0,count(*),round(avg(datediff(day,in_DATE,OUT_DATE)),2) from YP_KSS_RTJ_CYBR  
	where dept_id<>201  and OUT_DATE between ''+@rq1+' 00:00:00' and ''+@rq2+' 23:59:59' 
		and (@ksdm=0 or (@ksdm>0 and dept_id=@ksdm)) 
	and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm))  group by dept_id,zy_doc

	--使用抗菌药物人数
	insert into #temp_ys(ksdm,ysdm,ljddd,tqszhzts,kjywsyrs,cyrs)
	select dept_id,zy_doc,0,0,count(*),0 from (
	select b.dept_id,b.zy_doc,b.inpatient_id from 	YP_KSS_RTJ_ZYYP a inner join YP_KSS_RTJ_CYBR b on a.inpatient_id=b.inpatient_id	inner join  vi_yp_ypcd c on a.xmid=c.cjid 	where b.dept_id<>201 and OUT_DATE>=@rq1+' 00:00:00' and OUT_DATE<=@rq2+' 23:59:59' 		and (@ksdm=0 or (@ksdm>0 and dept_id=@ksdm)) 
	and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm)) and  kssdjid>0	group by b.dept_id,zy_doc,b.inpatient_id ) a group by dept_id,zy_doc


	select '' as 序号,dbo.fun_getdeptname(ksdm) 科室,dbo.fun_getempname(ysdm) 医生,round(sum(ljddd),2) 累计DDD数,sum(tqszhzts) 同期收治患者人天数,
	cast(round((sum(ljddd)/sum(tqszhzts))*100,2) as float) 抗菌药物使用强度,sum(kjywsyrs) 使用抗菌药物出院总人数,sum(cyrs) 总出院人数,sum(pjzyts) 平均住院天数,
	cast(cast(round(sum(kjywsyrs)/cast(sum(cyrs) as float),4) as float)*100 as varchar(50))+'%' 抗菌药物使用率 from #temp_ys 
	group by ksdm,ysdm
	union all
	select '合计' as 序号,'' 科室,'' 医生,round(sum(ljddd),2) 累计DDD数,sum(tqszhzts) 同期收治患者人天数,
	cast(round((sum(ljddd)/sum(tqszhzts))*100,2) as float) 抗菌药物使用强度,sum(kjywsyrs) 使用抗菌药物出院总人数,sum(cyrs) 总出院人数,avg(pjzyts) 平均住院天数,
	cast(cast(round(sum(kjywsyrs)/cast(sum(cyrs) as float),4) as float)*100 as varchar(50))+'%' 抗菌药物使用率 from #temp_ys 
end



END
GO

