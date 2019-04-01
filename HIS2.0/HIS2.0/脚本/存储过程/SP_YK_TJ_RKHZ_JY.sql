--exec SP_YK_TJ_RKHZ_JY 206 ,'2014-02-12 00:00:00', '2014-02-13 23:59:59',0,0,0,206
if exists (select * from sysobjects 
           where name = N'SP_YK_TJ_RKHZ_JY'
           and type = 'P')
   drop proc SP_YK_TJ_RKHZ_JY
go
create  PROCEDURE [dbo].[SP_YK_TJ_RKHZ_JY]
 ( 
   @deptid int,--药剂科室
   @RQ1 datetime, --统计日期1
   @RQ2 datetime,
   @yplx int,--药品类型
   @year int,--统计年份
   @month int,--统计月份
   @deptid_ck int--统计仓库
 )
as 

create table #tempYjid(yjid UNIQUEIDENTIFIER)
create table #deptid(deptid int)

--需要统计的科室
if (@deptid_ck>0)
  insert #deptid(deptid)values(@deptid_ck)
else 
  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID
--需要统计的会计月
if @year>0
begin
    insert into #tempYjid(yjid) 
	select id from yp_kjqj where kjnf=@year and kjyf=@month and deptid in(select deptid from #deptid)
	if @@rowcount=0
      insert into #tempYjid(yjid)values(dbo.FUN_GETEMPTYGUID()) 
end

declare @bywy int--入库汇总统计区分业务员 0不区分 1区分 
set @bywy=(select top 1 zt from yk_config where bh=114 and deptid in(select deptid from #deptid))
if @bywy is null set @bywy=0

if @year=0  and @bywy=0-- 按日期统计 不区分业务员
begin
select cast(ROW_NUMBER() over(order by cjid) as varchar) 序号, yppm 品名,YPGG 规格, SCCJ 厂家,
cast(PFJ as varchar) 批发价,cast(LSJ as varchar)零售价,SUM(YPSL) 数量,SUM(PFJE) 批发金额,SUM(LSJE) 零售金额,dbo.fun_yp_ghdw(WLDW) 送货单位,
SHH 货号 from
(
	select b.CJID,b.YPPM yppm,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,a.WLDW,b.SHH  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID
	inner join VI_YP_YPCD c on b.CJID=c.cjid
    where c.gjjbyw=1 and(
			(a.shbz=1 and a.ywlx in('016','009','031','033') and shrq>=@rq1 and shrq<=@rq2 )
			or (a.ywlx in('001') and djrq>=@rq1 and djrq<=@rq2 )
        )  and a.deptid in(select deptid from #deptid)
      union all -----药品退货
    select b.CJID,b.YPPM yppm,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,a.WLDW,b.SHH from vi_yk_dj a  inner join
    VI_YK_DJMX b on a.ID=b.DJID inner join VI_YP_YPCD c on b.CJID=c.cjid
    where c.gjjbyw=1 and(             
			( a.ywlx in('002') and djrq>=@rq1 and djrq<=@rq2 )
        ) and a.deptid in(select deptid from #deptid)  
) aa 
group by  CJID,YPPM,YPGG,SCCJ,PFJ,LSJ,SHH,WLDW
order by YPPM
end

if @year>0 and @bywy=0 --按月份统计 不区分业务员
begin
select cast(ROW_NUMBER() over(order by cjid) as varchar) 序号, yppm 品名,YPGG 规格, SCCJ 厂家,
cast(PFJ as varchar) 批发价,cast(LSJ as varchar)零售价,SUM(YPSL) 数量,SUM(PFJE) 批发金额,SUM(LSJE) 零售金额,dbo.fun_yp_ghdw(WLDW) 送货单位,
SHH 货号 from
(
	select b.cjid,b.YPPM,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,b.SHH,a.WLDW  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID
	inner join VI_YP_YPCD c on b.CJID=c.cjid
   		where  c.gjjbyw=1  and a.deptid in(select deptid from #deptid) and 
   		isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)   		 
   		and ((shbz=1 and a.YWLX in('016','009','031','033')) or ( a.ywlx in('001')))
   		union all 
		select b.cjid,b.YPPM,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,b.SHH,a.WLDW  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID inner join VI_YP_YPCD c on b.CJID=c.cjid
   		where
   		 c.gjjbyw=1  and
   		 a.deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)  and ((shbz=1 and a.ywlx in('002'))
   		 or (shbz=0 and a.ywlx in('002'))) 
  ) aa 
group by CJID,YPPM,YPGG,SCCJ,PFJ,LSJ,SHH,WLDW
order by YPPM
end


----------------------------------------------区分业务员
if @year=0  and @bywy=1-- 按日期统计 区分业务员
begin
select cast(ROW_NUMBER() over(order by cjid) as varchar) 序号, yppm 品名,YPGG 规格, SCCJ 厂家,
cast(PFJ as varchar) 批发价,cast(LSJ as varchar)零售价,SUM(YPSL) 数量,SUM(PFJE) 批发金额,
SUM(LSJE) 零售金额, 
(case when jsr>0 then dbo.fun_yp_ghdw(WLDW)+' ['+isnull(dbo.fun_yp_ywy(jsr),'')+']' else dbo.fun_yp_ghdw(WLDW) end) 送货单位 ,
SHH 货号 from
(
	select b.CJID,b.YPPM yppm,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,a.WLDW,b.SHH,a.JSR  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID
	inner join VI_YP_YPCD c on b.CJID=c.cjid
    where c.gjjbyw=1 and (
			(a.shbz=1 and a.ywlx in('016','009','031','033') and shrq>=@rq1 and shrq<=@rq2 ) 
			or (a.ywlx in('001') and djrq>=@rq1 and djrq<=@rq2 )
        )and a.deptid in(select deptid from #deptid)
      union all -----药品退货
    select b.CJID,b.YPPM yppm,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,a.WLDW,b.SHH from vi_yk_dj a  inner join
    VI_YK_DJMX b on a.ID=b.DJID inner join VI_YP_YPCD c on b.CJID=c.cjid
    where  c.gjjbyw=1 and(
			( a.ywlx in('002') and djrq>=@rq1 and djrq<=@rq2 )
        ) and a.deptid in(select deptid from #deptid)  
) aa 
group by  CJID,YPPM,YPGG,SCCJ,PFJ,LSJ,SHH,WLDW,JSR
order by YPPM
end


if @year>0 and @bywy=1
begin
select cast(ROW_NUMBER() over(order by cjid) as varchar) 序号, yppm 品名,YPGG 规格, SCCJ 厂家,
cast(PFJ as varchar) 批发价,cast(LSJ as varchar)零售价,SUM(YPSL) 数量,SUM(PFJE) 批发金额,
SUM(LSJE) 零售金额,
(case when jsr>0 then dbo.fun_yp_ghdw(WLDW)+' ['+isnull(dbo.fun_yp_ywy(jsr),'')+']' else dbo.fun_yp_ghdw(WLDW) end) 送货单位 ,
SHH 货号 from
(
	select b.cjid,b.YPPM,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,b.SHH,a.WLDW,a.JSR  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID
	inner join VI_YP_YPCD c on b.CJID=c.cjid
   		where c.gjjbyw=1  and  a.deptid in(select deptid from #deptid) and 
   		isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)  
   		and ((shbz=1 and a.YWLX in('016','009','031','033')) or ( a.ywlx in('001'))) 
   		union all 
		select b.cjid,b.YPPM,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,b.SHH,a.WLDW  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID
	inner join VI_YP_YPCD c on b.CJID=c.cjid
   		where c.gjjbyw=1 and a.deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)  and ((shbz=1 and a.ywlx in('002'))
   		 or (shbz=0 and a.ywlx in('002'))) 
  ) aa 
group by CJID,YPPM,YPGG,SCCJ,PFJ,LSJ,SHH,WLDW,JSR
order by YPPM

end 







