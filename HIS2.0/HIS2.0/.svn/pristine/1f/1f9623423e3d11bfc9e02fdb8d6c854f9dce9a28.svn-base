IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_TJ_RKHZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_TJ_RKHZ
GO
CREATE PROCEDURE SP_YK_TJ_RKHZ   --ncq 20140210 添加033(制剂加工成品入库)
 ( 
   @deptid int,
   @RQ1 datetime, 
   @RQ2 datetime,
   @yplx int,
   @year int,
   @month int,
   @deptid_ck int
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

declare @bywy int
set @bywy=(select top 1 zt from yk_config where bh=114 and deptid in(select deptid from #deptid))
if @bywy is null set @bywy=0

if @year=0 and @bywy=0
begin
  select '0' 序号,rtrim(dbo.fun_yk_ywlx(YWLX)) 入库方式,
   (case ywlx when '009'  then '期初入库' 
     when '033' then '制剂加工成品入库'  
    when '031' then dbo.fun_getdeptname(wldw)+'调入' else dbo.fun_yp_ghdw(wldw) end) 往来单位,
   sum(sumjhje) 进货金额,sum(sumpfje) 批发金额,sum(sumlsje) 零售金额,
   (sum(sumlsje)-sum(sumjhje)) 进零差额,(sum(sumlsje)-sum(sumpfje)) 批零差额,count(distinct aa.ID) 单据张数 from 
  (
	select a.id,a.ywlx,wldw,jhje as sumjhje,pfje sumpfje,lsje sumlsje from vi_yk_dj a inner join VI_YK_DJMX b on a.ID=b.djid
    where (
			(shbz=1 and a.ywlx in('016','009','031') and shrq>=@rq1 and shrq<=@rq2 ) 
			
			or (SHBZ =1 and a.YWLX ='033' and SHRQ>=@RQ1 and SHRQ<=@RQ2 )
			
			or (a.ywlx in('001') and djrq>=@rq1 and djrq<=@rq2 )
        )  and a.deptid in(select deptid from #deptid)
    union all 
	select a.id,'001',wldw,jhje*(-1), pfje*(-1), lsje*(-1) from vi_yk_dj   a inner join VI_YK_DJMX b on a.ID=b.djid
    where (
			( a.ywlx in('002') and djrq>=@rq1 and djrq<=@rq2 )
        ) and a.deptid in(select deptid from #deptid)
 ) aa
  group by ywlx,wldw  order by ywlx,dbo.fun_yp_ghdw(wldw) 
end

if @year>0 and @bywy=0
begin
    select '0' 序号,rtrim(dbo.fun_yk_ywlx(YWLX)) 入库方式,
	( case ywlx when '009'  then '期初入库'  
	  when '033' then '制剂加工成品入库' 
	 when '031' then dbo.fun_getdeptname(wldw)+'调入' else dbo.fun_yp_ghdw(wldw) end) 往来单位,
	sum(sumjhje) 进货金额,sum(sumpfje) 批发金额,sum(sumlsje) 零售金额,
   (sum(sumlsje)-sum(sumjhje)) 进零差额,(sum(sumlsje)-sum(sumpfje)) 批零差额,count(distinct aa.ID) 单据张数  from
(
		select a.id,a.ywlx,wldw,jhje sumjhje,pfje sumpfje,lsje sumlsje from vi_yk_dj  a inner join VI_YK_DJMX b on a.ID=b.djid
   		where a.deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)  and ((shbz=1 and a.ywlx in('016','009','031')) or ( a.ywlx in('001'))   
   		or (SHBZ =1 and a.YWLX ='033') ) 
		union all 
		select a.id,'001',wldw, jhje*(-1), pfje*(-1), lsje*(-1) from vi_yk_dj  a inner join VI_YK_DJMX b on a.ID=b.djid
   		where a.deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)  and ((shbz=1 and a.ywlx in('002')) or (shbz=0 and a.ywlx in('002'))) 
) aa
   group by ywlx,wldw  order by ywlx,dbo.fun_yp_ghdw(wldw)
end  


--------------区分业务员
if @year=0 and @bywy=1
begin
  select '0' 序号,rtrim(dbo.fun_yk_ywlx(YWLX)) 入库方式,
   (case ywlx when '009'  then '期初入库'   
      when '033' then '制剂加工成品入库'  
    when '031' then dbo.fun_getdeptname(wldw)+'调入' else 
   (case when jsr>0 then dbo.fun_yp_ghdw(wldw)+' ['+isnull(dbo.fun_yp_ywy(jsr),'')+']' else dbo.fun_yp_ghdw(wldw) end)
   end) 往来单位,
   sum(sumjhje) 进货金额,sum(sumpfje) 批发金额,sum(sumlsje) 零售金额,
   (sum(sumlsje)-sum(sumjhje)) 进零差额,(sum(sumlsje)-sum(sumpfje)) 批零差额,count(distinct aa.ID) 单据张数 from 
  (
	select a.id,a.ywlx,wldw,jhje sumjhje,pfje sumpfje,lsje sumlsje,jsr from vi_yk_dj  a inner join VI_YK_DJMX b on a.ID=b.djid
    where (
			(shbz=1 and a.ywlx in('016','009','031') and shrq>=@rq1 and shrq<=@rq2 ) 
			or (a.ywlx in('001') and djrq>=@rq1 and djrq<=@rq2 and SHBZ =1 ) 
			or  ( a.YWLX ='033' and SHRQ>=@RQ1 and SHRQ<=@RQ2 and SHBZ=1 )
        )  and a.deptid in(select deptid from #deptid)
    union all 
	select a.id,'001',wldw, jhje*(-1), pfje*(-1), lsje*(-1),jsr from vi_yk_dj  a inner join VI_YK_DJMX b on a.ID=b.djid
    where (
			( a.ywlx in('002') and djrq>=@rq1 and djrq<=@rq2 )
        ) and a.deptid in(select deptid from #deptid)
       
 ) aa
  group by ywlx,wldw,jsr  order by ywlx,dbo.fun_yp_ghdw(wldw),jsr
end

if @year>0 and @bywy=1
begin
    select '0' 序号,rtrim(dbo.fun_yk_ywlx(YWLX)) 入库方式,
	( case ywlx when '009'  then '期初入库' 
	    when '033' then '制剂加工成品入库'  
	  when '031' then dbo.fun_getdeptname(wldw)+'调入' else 
	(case when jsr>0 then dbo.fun_yp_ghdw(wldw)+' ['+isnull(dbo.fun_yp_ywy(jsr),'')+']' else dbo.fun_yp_ghdw(wldw) end)
	 end) 往来单位,
	sum(sumjhje) 进货金额,sum(sumpfje) 批发金额,sum(sumlsje) 零售金额,
   (sum(sumlsje)-sum(sumjhje)) 进零差额,(sum(sumlsje)-sum(sumpfje)) 批零差额,count(distinct aa.ID) 单据张数  from
(
		select a.id,a.ywlx,wldw,jhje sumjhje,pfje sumpfje,lsje sumlsje,jsr from vi_yk_dj  a inner join VI_YK_DJMX b on a.ID=b.djid
   		where a.deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)  and ((shbz=1 and a.ywlx in('016','009','031')) 
   		or ( a.ywlx in('001'))
   		or (shbz=1 and a.ywlx='033' )
   		) 
		union all 
		select a.id,'001',wldw, jhje*(-1),pfje*(-1), lsje*(-1),jsr from vi_yk_dj  a inner join VI_YK_DJMX b on a.ID=b.djid
   		where a.deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)  and ((shbz=1 and a.ywlx in('002')) or (shbz=0 and a.ywlx in('002'))) 
		
) aa
   group by ywlx,wldw,jsr  order by ywlx,dbo.fun_yp_ghdw(wldw),jsr

end 


