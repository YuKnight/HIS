
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YP_KSSZB_TJ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YP_KSSZB_TJ
GO
create PROCEDURE [dbo].[SP_YP_KSSZB_TJ]
    @rq1 datetime,
    @rq2 datetime,
	@ksdm INT,
	@ysdm int,
	@tjlx int, --0 全部  1 门诊 2住院
    @bz varchar(200) output
AS

--exec SP_YP_KSSZB_TJ '2011-01-01','2011-07-31',0,0,2,''

BEGIN

--日统计表生成日期
--declare @tj1 datetime
--declare @tj2 datetime
--set @tj1=(select top 1 rq from YP_KSS_RTJ where rq>=@rq1 and rq<=@rq2 order by rq)
--set @tj2=(select top 1 rq from YP_KSS_RTJ where rq>=@rq1 and rq<=@rq2 order by rq desc)
--if dbo.Fun_GetDate(@tj1)<>dbo.Fun_GetDate(@rq1) or dbo.Fun_GetDate(@tj2)<>dbo.Fun_GetDate(@rq2)
--	set @bz='抗生素统计数据只汇总到了 '+convert(nvarchar,@tj1,111)+' 到 '+convert(nvarchar,@tj2,111)+',您目前只能统计该范围内的数据'
--if @tj1 is null or @tj2 is null
--	set @bz='系统没有生成当前时间范围内的统计指示,请重新选择时间范围'


create table #temp(ksdm int,ysdm int,zbdm varchar(30),zbmc varchar(500),zbjg decimal(15,2),je decimal(15,2))
create table #temp_jg(mc varchar(100),jg varchar(100),syl varchar(100),bz varchar(100))---------------------------------------------------门诊-------------------------------------------------------------------------------------------------门诊----------------------------------------------if @tjlx=1 or @tjlx=0begin--计算同期就诊总人次insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0 as jsksdm,0 as jsysdm,'mz_jzzrc','接诊总人次',count(*) from (select ghxxid from MZYS_JZJL where jssj>=@rq1+' 00:00:00' and jssj<=@rq2+' 23:59:59' and (@ksdm=0 or (@ksdm>0 and jsksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and jsysdm=@ysdm)) and bscbz=0 group by ghxxid) a  --计算同期就诊总金额insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0,0,'mz_zje','就诊总金额',sum(je) from vi_MZ_CFB a inner join vi_MZ_CFB_MX b on a.cfid=b.cfid where XMLY=1 and sfrq>=@RQ1+' 00:00:00' and sfrq<=@rq2+' 23:59:59'and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) --就诊用药总品种数insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg,je)select 0,0,'mz_ypzs','就诊用药总品种数',count(*),sum(je)from (select xmid,sum(je) as je  from YP_KSS_RTJ_MZYP where  rq>=@rq1 and rq<=@rq2 and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) group by xmid ) a	--就诊用药人均累计品种数insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0,0,'mz_ljljypzs','就诊用药人均累计品种数',COUNT(*) from (select ghxxid ,xmid   from YP_KSS_RTJ_MZYP where  rq>=@rq1 and rq<=@rq2 and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) group by ghxxid,xmid) a  --使用抗菌药物人次 金额insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg,je)select 0,0,'mz_kjywrc','使用抗菌药物人次',count(*),sum(je) from(select ghxxid ,sum(je) je from YP_KSS_RTJ_MZYP a  ,vi_yp_ypcd bwhere  a.xmid=b.cjid and rq>=@rq1 and rq<=@rq2  and kssdjid>0and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) group by ghxxid ) a --使用抗菌药物品种数insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0,0,'mz_kjywpzs','使用抗菌药物品种数',COUNT(*) from (select  XMID from YP_KSS_RTJ_MZYP a  ,vi_yp_ypcd bwhere   a.xmid=b.cjid and rq>=@rq1 and rq<=@rq2 and kssdjid>0and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) group by ghxxid ,xmid) a  --使用注射药物人次 金额insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg,je)select 0,0,'mz_zsywrc','使用注射药物人次',count(*),sum(je) from(select ghxxid ,sum(je) je from YP_KSS_RTJ_MZYP a  ,vi_yp_ypcd bwhere  a.xmid=b.cjid and rq>=@rq1 and rq<=@rq2   and tlfl in('02','03') and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) group by ghxxid ) a  --使用注射药物品种数insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0,0,'mz_zsywpzs','使用注射药物品种数',COUNT(*) from (select  XMID  from YP_KSS_RTJ_MZYP a  ,vi_yp_ypcd bwhere  a.xmid=b.cjid and rq>=@rq1 and rq<=@rq2  and tlfl in('02','03')  and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) group by ghxxid,xmid) a  --使用基本药物人次 金额insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg,je)select 0,0,'mz_jbywrc','使用基本药物人次',count(*),sum(je) from(select ghxxid ,sum(je) je from YP_KSS_RTJ_MZYP a  ,vi_yp_ypcd bwhere  a.xmid=b.cjid and rq>=@rq1 and rq<=@rq2  and gjjbYW>0and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) group by ghxxid) a --使用基本药物品种数insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0,0,'mz_jbywpzs','使用基本药物品种数',COUNT(*) from (select  XMID  from YP_KSS_RTJ_MZYP  a  ,vi_yp_ypcd bwhere  a.xmid=b.cjid and rq>=@rq1 and rq<=@rq2 and gjjbYW>0 and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) group by ghxxid ,xmid) a  --使用西药药物人次 金额insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg,je)select 0,0,'mz_xyrc','使用西药药物人次',count(*),sum(je) from(select ghxxid ,sum(je) je from YP_KSS_RTJ_MZYP a  ,vi_yp_ypcd bwhere  a.xmid=b.cjid and rq>=@rq1 and rq<=@rq2  and statitem_code='01'and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) group by ghxxid ) a  --使用中成药药物人次 金额insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg,je)select 0,0,'mz_cyrc','使用中成药药物人次',count(*),sum(je) from(select ghxxid ,sum(je) je from YP_KSS_RTJ_MZYP a  ,vi_yp_ypcd bwhere  a.xmid=b.cjid and rq>=@rq1 and rq<=@rq2  and statitem_code='02'and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) group by ghxxid ) a --使用中草药药物人次 金额insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg,je)select 0,0,'mz_zyrc','使用中草药药物人次',count(*),sum(je) from(select ghxxid ,sum(je) je from YP_KSS_RTJ_MZYP a  ,vi_yp_ypcd bwhere  a.xmid=b.cjid and rq>=@rq1 and rq<=@rq2  and statitem_code='03'and (@ksdm=0 or (@ksdm>0 and ksdm=@ksdm)) and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) group by ghxxid,ksdm,ysdm) a  declare @mz_jzzrc floatset @mz_jzzrc=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_jzzrc'),0)declare @mz_ljljypzs floatset @mz_ljljypzs=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_ljljypzs'),0)declare @mz_kjywrc floatset @mz_kjywrc=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_kjywrc'),0)declare @mz_kjywje floatset @mz_kjywje=coalesce((select sum(je) 结果 from #temp where zbdm='mz_kjywje'),0)declare @mz_kjywpzs floatset @mz_kjywpzs=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_kjywpzs'),0)declare @mz_zsywrc floatset @mz_zsywrc=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_zsywrc'),0)declare @mz_zsywje floatset @mz_zsywje=coalesce((select sum(je) 结果 from #temp where zbdm='mz_zsywje'),0)declare @mz_zsywpzs floatset @mz_zsywpzs=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_zsywpzs'),0)declare @mz_jbywrc floatset @mz_jbywrc=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_jbywrc'),0)declare @mz_jbywje floatset @mz_jbywje=coalesce((select sum(je) 结果 from #temp where zbdm='mz_jbywje'),0)declare @mz_jbywpzs floatset @mz_jbywpzs=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_jbywpzs'),0)declare @mz_ypzs floatset @mz_ypzs=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_ypzs'),0)declare @mz_ypje floatset @mz_ypje=coalesce((select sum(je) 结果 from #temp where zbdm='mz_ypzs'),0)declare @mz_zje floatset @mz_zje=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_zje'),0)declare @mz_xyrc floatset @mz_xyrc=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_xyrc'),0)declare @mz_xyje floatset @mz_xyje=coalesce((select sum(je) 结果 from #temp where zbdm='mz_xyrc'),0)declare @mz_cyrc floatset @mz_cyrc=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_cyrc'),0)declare @mz_cyje floatset @mz_cyje=coalesce((select sum(je) 结果 from #temp where zbdm='mz_cyrc'),0)declare @mz_zyrc floatset @mz_zyrc=coalesce((select sum(zbjg) 结果 from #temp where zbdm='mz_zyrc'),0)declare @mz_zyje floatset @mz_zyje=coalesce((select sum(je) 结果 from #temp where zbdm='mz_zyrc'),0)insert into #temp_jg(mc,jg,syl,bz)select '同期就诊人次' 统计指标,(case when @mz_jzzrc>0 then cast( cast(@mz_jzzrc as float) as varchar(50)) else null end) 结果,'' 使用率,'' bz union allselect '每次就诊人均用药品种数',(case when @mz_jzzrc>0 then cast( cast(round(@mz_ljljypzs/@mz_jzzrc ,2) as float) as varchar(50)) else null end) 结果,'' 使用率,'门诊病人用药累计总品种数／同期就诊人次'union allselect '每次就诊人均费用',(case when @mz_jzzrc>0 then cast( cast(round(@mz_zje/@mz_jzzrc,2) as float) as varchar(50)) else null end) 结果,'' 使用率,'门诊用药总金额／同期就诊人次'union allselect '门诊抗菌药物使用百分率',null,(case when @mz_jzzrc>0 then cast(cast(round(@mz_kjywrc/@mz_jzzrc,4)*100 as float) as varchar(30))+'%' else '' end) 使用率,'(门诊使用抗菌药物的人次／同期就诊人次)*100%'union allselect '门诊注射药物使用百分率',null,(case when @mz_jzzrc>0 then cast(cast(round(@mz_zsywrc/@mz_jzzrc,4)*100 as float) as varchar(30))+'%' else '' end) 使用率,'(门诊使用注射药物人次／同期就诊人次)*100%'union allselect '门诊使用基药物品种数',(case when @mz_jbywpzs>0 then cast( cast(@mz_jbywpzs as float) as varchar(50)) else null end),
(case when @mz_ypzs>0 then cast(cast(round(@mz_jbywpzs/@mz_ypzs,4)*100 as float) as varchar(30))+'%' else '' end),'门诊使用基药物品种数/门诊用药总品种数*100%'union allselect '门诊使用基药物的金额',(case when @mz_jbywje>0 then cast( cast(@mz_jbywje as float) as varchar(50)) else null end),
(case when @mz_zje>0 then cast(cast(round(@mz_jbywje/@mz_zje,4)*100 as float) as varchar(30))+'%' else '' end),'门诊使用基药物的金额/门诊药物总费用*100%'union allselect '基本药物占处方用药的百分率',null,(case when @mz_jbywpzs>0 then cast(cast(round(@mz_jbywpzs/@mz_ljljypzs,4)*100 as float) as varchar(30))+'%' else '' end)  使用率,'(门诊病人用基本药物累计品种数／门诊病人用药累计总品种数)*100%'union allselect '门诊用药总品种数' 统计内容,(case when @mz_ypzs>0 then cast( cast(@mz_ypzs as float) as varchar(50)) else '' end) 结果,'' 使用率,'门诊用药总品种数' 备注
union all 
select '门诊药物总费用',(case when @mz_ypje>0 then convert(varchar(50),cast(@mz_ypje as decimal(15,2))) else '' end),'' 使用率,''
union all 
select '门诊使用西药人次',(case when @mz_xyrc>0 then cast( cast(@mz_xyrc as float) as varchar(50)) else '' end),
(case when @mz_jzzrc>0 then cast(cast(round(@mz_xyrc/@mz_jzzrc,4)*100 as float) as varchar(30))+'%' else '' end),'门诊使用西药人次/同期就诊人次*100%'
union all 
select '门诊使用西药金额',(case when @mz_xyje>0 then cast( cast(@mz_xyje as decimal(15,2)) as varchar(50)) else '' end),
(case when @mz_ypje>0 then cast(cast(round(@mz_xyje/@mz_ypje,4)*100 as float) as varchar(30))+'%' else '' end),'门诊使用西药金额/门诊药物总费用*100%'
union all 
select '门诊使用中成药人次',(case when @mz_cyrc>0 then cast( cast(@mz_cyrc as float) as varchar(50)) else '' end),
(case when @mz_jzzrc>0 then cast(cast(round(@mz_cyrc/@mz_jzzrc,4)*100 as float) as varchar(30))+'%' else '' end),'门诊使用中成药人次/同期就诊人次*100%'
union all 
select '门诊使用中成药金额',(case when @mz_cyje>0 then cast( cast(@mz_cyje as decimal(15,2)) as varchar(50)) else '' end),
(case when @mz_ypje>0 then cast(cast(round(@mz_cyje/@mz_ypje,4)*100 as float) as varchar(30))+'%' else '' end),'门诊使用中成药金额/门诊药物总费用*100%'
union all 
select '门诊使用中草药人次',(case when @mz_zyrc>0 then cast( cast(@mz_zyrc as float) as varchar(50)) else '' end),
(case when @mz_jzzrc>0 then cast(cast(round(@mz_zyrc/@mz_jzzrc,4)*100 as float) as varchar(30))+'%' else '' end),'门诊使用中草药人次/同期就诊人次*100%'
union all 
select '门诊使用中草药金额',(case when @mz_zyje>0 then cast( cast(@mz_zyje as decimal(15,2)) as varchar(50)) else '' end),
(case when @mz_ypje>0 then cast(cast(round(@mz_zyje/@mz_ypje,4)*100 as float) as varchar(30))+'%' else '' end),'门诊使用中草药金额/门诊药物总费用*100%'end----------------------------------------------------------------住院--------------------------------------------------------------------------------------住院------------------------if @tjlx=2 or @tjlx=0begin--出院患者用药总品种数 金额insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg,je)select 0,0,'zyhzyypzs','出院患者用药总品种数',count(*),sum(je)from (select xmid,sum(je) as je  from YP_KSS_RTJ_ZYYP a inner join YP_KSS_RTJ_CYBR bon  a.inpatient_id=b.inpatient_id where rq>=@rq1 and rq<=@rq2  and b.dept_id<>201and (@ksdm=0 or (@ksdm>0 and b.dept_id=@ksdm)) and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm)) group by xmid ) a

declare @zyhzyypzs floatset @zyhzyypzs=coalesce((select sum(zbjg) 结果 from #temp where zbdm='zyhzyypzs'),0)
declare @zyhzywzfy floatset @zyhzywzfy=coalesce((select sum(je) 结果 from #temp where zbdm='zyhzyypzs'),0)


--出院患者人均累计用药总品种数insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0,0,'zyhzyyrjljpzs','出院患者人均累计用药总品种数',COUNT(*) from (select b.inpatient_id,xmid from YP_KSS_RTJ_ZYYP a inner join YP_KSS_RTJ_CYBR bon a.inpatient_id=b.inpatient_idwhere  rq>=@rq1 and rq<=@rq2  and b.dept_id<>201and (@ksdm=0 or (@ksdm>0 and b.dept_id=@ksdm)) and (@ysdm=0 or (@ysdm>0 and b.zy_doc=@ysdm)) group by b.inpatient_id,xmid
) a  
declare @zyhzyyrjljpzs floatset @zyhzyyrjljpzs=coalesce((select sum(je) 结果 from #temp where zbdm='zyhzyyrjljpzs'),0)

--使用抗菌药物品种数、总费用insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg,je)select 0,0,'kjywzpzs','使用抗菌药物品种数',COUNT(*),sum(je) from (select  XMID,sum(je) je from YP_KSS_RTJ_ZYYP a  ,vi_yp_ypcd b, YP_KSS_RTJ_CYBR cwhere   a.xmid=b.cjid and a.inpatient_id=c.inpatient_id and rq>=@rq1 and rq<=@rq2 and kssdjid>0and (@ksdm=0 or (@ksdm>0 and c.dept_id=@ksdm)) and (@ysdm=0 or (@ysdm>0 and c.zy_doc=@ysdm)) group by xmid) a  
declare @kjywzpzs floatset @kjywzpzs=coalesce((select sum(ZBJG) 结果 from #temp where zbdm='kjywzpzs'),0)

declare @kjywzfy decimal(15,2)
set @kjywzfy=coalesce((select sum(JE) from #temp where zbdm='kjywzpzs' ),0)

--出院患者抗菌药物人均累计总品种数insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg,je)select 0,0,'kjywzrjljpzs','出院患者抗菌药物人均累计总品种数',COUNT(*),sum(je) from (select  XMID,sum(je) je from YP_KSS_RTJ_ZYYP a  ,vi_yp_ypcd b, YP_KSS_RTJ_CYBR cwhere   a.xmid=b.cjid and a.inpatient_id=c.inpatient_id and rq>=@rq1 and rq<=@rq2 and kssdjid>0 and c.dept_id<>201and (@ksdm=0 or (@ksdm>0 and c.dept_id=@ksdm)) and (@ysdm=0 or (@ysdm>0 and c.zy_doc=@ysdm)) group by c.inpatient_id ,xmid) a  
declare @kjywzrjljpzs floatset @kjywzrjljpzs=coalesce((select sum(ZBJG) 结果 from #temp where zbdm='kjywzrjljpzs'),0)


--抗菌药物出院总人数insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0,0,'kjywcyzrs','抗菌药物出院总人数',COUNT(*)  from (select  c.inpatient_id from YP_KSS_RTJ_ZYYP a  ,vi_yp_ypcd b, YP_KSS_RTJ_CYBR cwhere   a.xmid=b.cjid and a.inpatient_id=c.inpatient_id and  rq>=@rq1 and rq<=@rq2 and kssdjid>0 and c.dept_id<>201and (@ksdm=0 or (@ksdm>0 and c.dept_id=@ksdm)) and (@ysdm=0 or (@ysdm>0 and c.zy_doc=@ysdm)) group by c.inpatient_id ) a  
declare @kjywcyzrs decimal(15,2)--抗菌药物出院总人数
set @kjywcyzrs=coalesce((select sum(zbjg) from #temp where zbdm='kjywcyzrs' ),0)

--出院病人抗菌药物累计DDD值insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0,0,'kjywljddd','出院病人抗菌药物累计DDD值',sum(round(sl*hlxs/ddd,3)) from (select xmid,sum(ypsl) sl from YP_KSS_RTJ_ZYYP a, YP_KSS_RTJ_CYBR bwhere a.inpatient_id=b.inpatient_id and rq>=@rq1 and rq<=@rq2  and b.dept_id<>201and (@ksdm=0 or (@ksdm>0 and b.dept_id=@ksdm)) and (@ysdm=0 or (@ysdm>0 and b.zy_doc=@ysdm))group by xmid )a,vi_yp_ypcd b where a.xmid=b.cjid and b.kssdjid>0 and b.ddd>0declare @kjywljddd decimal(15,2)--出院病人抗菌药物累计DDD值
set @kjywljddd=coalesce((select sum(zbjg) from #temp where zbdm='kjywljddd' ),0)



--特殊抗菌药物累计DDD值
insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0,0,'kjywtsljddd','特殊抗菌药物累计DDD值',sum(round(sl*hlxs/ddd,3)) from (select xmid,sum(ypsl) sl from YP_KSS_RTJ_ZYYP a,vi_yp_ypcd b , YP_KSS_RTJ_CYBR cwhere a.xmid=b.cjid and  a.inpatient_id=c.inpatient_id and rq>=@rq1 and rq<=@rq2  and c.dept_id<>201and (@ksdm=0 or (@ksdm>0 and c.dept_id=@ksdm)) and (@ysdm=0 or (@ysdm>0 and c.zy_doc=@ysdm))group by xmid )a,vi_yp_ypcd b where a.xmid=b.cjid and b.kssdjid=3 and b.ddd>0declare @kjywtsljddd decimal(15,2)--特殊抗菌药物累计DDD值
set @kjywtsljddd=coalesce((select sum(zbjg) from #temp where zbdm='kjywtsljddd' ),0)


--出院患者使用基本药物品种数insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg,je)select 0,0,'zyhzjbywpzs','出院患者使用基本药物品种数',COUNT(*),sum(je) from (select  XMID,sum(je) je from YP_KSS_RTJ_ZYYP a  ,vi_yp_ypcd b, YP_KSS_RTJ_CYBR cwhere   a.xmid=b.cjid and a.inpatient_id=c.inpatient_id and rq>=@rq1 and rq<=@rq2 and gjjbyw>0 and c.dept_id<>201and (@ksdm=0 or (@ksdm>0 and c.dept_id=@ksdm)) and (@ysdm=0 or (@ysdm>0 and c.zy_doc=@ysdm)) group by c.inpatient_id ,xmid) a  
declare @zyhzjbywpzs decimal(15,2)--出院患者使用基本药物品种数
set @zyhzjbywpzs=coalesce((select sum(zbjg) from #temp where zbdm='zyhzjbywpzs' ),0)

declare @zyhzjbywje decimal(15,2)--出院患者使用基本药物金额
set @zyhzjbywje=coalesce((select sum(je) from #temp where zbdm='zyhzjbywpzs' ),0)


--总出院人数
insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0,0,'tqzcyrs','总出院人数', COUNT(*) from YP_KSS_RTJ_CYBR where out_date>=@rq1+' 00:00:00' and out_date<=@rq2+' 23:59:59' and dept_id<>201and (@ksdm=0 or (@ksdm>0 and dept_id=@ksdm)) and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm))declare @tqzcyrs decimal(15,2)--总出院人数
set @tqzcyrs=coalesce((select sum(zbjg) from #temp where zbdm='tqzcyrs' ),0)


--出院病人累计住院天数(同期收治患者人天数) 
insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)
select 0,0,'tqszhzts','同期收治患者人天数', cast(round(avg(datediff(day,in_DATE,OUT_DATE)),2)as float)*COUNT(*) 
from YP_KSS_RTJ_CYBR where  out_date>=@rq1+' 00:00:00' and out_date<=@rq2+' 23:59:59' and dept_id<>201
and (@ksdm=0 or (@ksdm>0 and dept_id=@ksdm)) and (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm))

declare @tqszhzts decimal(15,2) 
set @tqszhzts=coalesce((select sum(zbjg) from #temp where zbdm='tqszhzts' ),0)
--抗菌药物患者病原学检查人数insert into #temp(ksdm,ysdm,zbdm,zbmc,zbjg)select 0,0,'byxjcrs','抗菌药物患者病原学检查人数',nulldeclare @byxjcrs decimal(15,2)--抗菌药物患者病原学检查人数
set @byxjcrs=coalesce((select sum(zbjg) from #temp where zbdm='byxjcrs' ),0)
insert into #temp_jg(mc,jg,syl,bz)
select '总出院人数' 统计指标,(case when @tqzcyrs>0   then cast( cast(@tqzcyrs as float) as VARCHAR(100)) else null end) 结果,'' 使用率,'' 备注
union all
select '出院患者人均使用抗菌药物品种数' 统计指标,(case when @kjywzrjljpzs>0 and @kjywcyzrs>0 then cast( cast(round(@kjywzrjljpzs/@kjywcyzrs ,2) as float) as VARCHAR(100)) else null end) 结果,'' 使用率,'出院患者抗菌药物人均累计总品种数／抗菌药物出院总人数' 备注union allselect '出院患者人均使用抗菌药物费用',(case when @kjywzfy>0 and @kjywcyzrs>0 then cast( cast(round(@kjywzfy/@kjywcyzrs ,2) as float) as varchar(50)) else null end) 结果,'' 使用率,'出院患者抗菌药物总费用／抗菌药物出院总人数'union allselect '出院患者使用抗菌药物的百分率',cast(cast(@kjywcyzrs as float) as varchar(30))+'／'+cast(cast(@tqzcyrs as float) as varchar(30)),(case when @tqzcyrs>0 and @kjywcyzrs>0 then cast( cast(round(@kjywcyzrs/@tqzcyrs,4)*100 as float) as varchar(50))+'%' else '' end) 使用率,'抗菌药物出院总人数／总出院人数*100%'union allselect '出院病人抗菌药物累计DDD值',cast(@kjywljddd as varchar(50))  结果,'' 使用率,''union allselect '出院患者人天数',cast(@tqszhzts as varchar(50))  结果,'' 使用率,'出院病人平均住院天数*出院人数'union allselect '抗菌药物使用强度',(case when @kjywljddd>0 and @tqszhzts>0  then cast(cast(round(@kjywljddd*100/@tqszhzts,2) as float) as varchar(30)) else null end)  结果,'' 使用率,'出院病人抗菌药物累计DDD值*100／同期收治患者人天数'union allselect '抗菌药物费用占药费总额的百分率',@kjywzfy,(case when @kjywzfy>0 and @zyhzywzfy>0 then cast(cast(round(@kjywzfy/@zyhzywzfy,4)*100 as float) as varchar(30))+'%' else '' end) 使用率,'出院患者使用抗菌药物总费用／使用药品总费用*100%'union allselect '抗菌药物特殊品种使用量占抗菌药物使用量百分率',@kjywtsljddd,(case when @kjywtsljddd>0 and @kjywljddd>0 then cast(cast(round(@kjywtsljddd/@kjywljddd,4)*100 as float) as varchar(30))+'%' else '' end) 使用率,'特殊抗菌药物累计DDD值／出院病人抗菌药物累计DDD值*100%'union allselect '出院用抗菌药物患者病原学检查百分率',null,(case when @byxjcrs>0 and @kjywcyzrs>0 then cast(cast(round(@byxjcrs/@kjywcyzrs,4)*100 as float) as varchar(30))+'%' else '' end) 使用率,'抗菌药物患者病原学检查人数／抗菌药物出院总人数*100%'
union all 
select '出院患者用药总品种数',(case when @zyhzyypzs>0 then cast( cast(@zyhzyypzs as float) as varchar(50)) else null end),'','出院患者用药总品种数'
union all 
select '出院患者药物总费用',(case when @zyhzywzfy>0 then cast(cast(@zyhzywzfy as decimal(18,2)) as varchar(100)) else null end),'',''
union all 
select '出院患者使用基药物品种数',(case when @zyhzjbywpzs>0 then cast( cast(@zyhzjbywpzs as float) as varchar(50)) else null end),
(case when @zyhzyypzs>0 then cast(cast(round(@zyhzjbywpzs/@zyhzyypzs,4)*100 as float) as varchar(30))+'%' else '' end),'出院患者使用基药物品种数/出院患者用药总品种数*100%'
union all 
select '出院患者使用基药物品金额',(case when @zyhzjbywje>0 then cast( cast(@zyhzjbywje as float) as varchar(50)) else null end),
(case when @zyhzywzfy>0 then cast(cast(round(@zyhzjbywje/@zyhzywzfy,4)*100 as float) as varchar(30))+'%' else '' end),'出院患者使用基药物品金额/出院患者药物总费用*100%'
end

END


select mc 指标名称,jg 结果,syl 百分率,bz 备注 from #temp_jg


--exec SP_YP_KSSZB_TJ '<>2011-08-01','<>2011-08-03',0

--select * from yp_ypggd statitem_code

--select * from YP_KSS_RTJ