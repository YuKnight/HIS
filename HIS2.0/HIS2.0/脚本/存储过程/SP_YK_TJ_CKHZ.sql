
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_TJ_CKHZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_TJ_CKHZ
GO
CREATE PROCEDURE SP_YK_TJ_CKHZ
 ( 
   @deptid int,
   @RQ1 datetime, 
   @RQ2 datetime,
   @yplx int,
   @year int,
   @month int,
   @lyks int,
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

if @year=0
begin
                             
	  select '0' 序号,rtrim(dbo.fun_yk_ywlx(a.YWLX)) 出库方式,
	(case a.ywlx when '003'  then dbo.fun_getdeptname(wldw)+'出库'
	            when '004' then dbo.fun_getdeptname(wldw)+'退库'
				when '014' then dbo.fun_getdeptname(wldw)+'其它领药'
				when '022' then dbo.fun_getdeptname(wldw)+'外用药领药'
				when '017' then '处方出库'
				when '018' then '门诊处方补录出库'
				when '020' then '住院处方补录出库'
				when '030' then dbo.fun_getdeptname(wldw)+'调出' 
				 when '032' then '原料消耗出库' 
				else '' end
	) 往来单位 ,
	  sum(sumjhje) 进货金额,sum(sumpfje) 批发金额,sum(sumlsje) 零售金额,
	  (sum(sumlsje)-sum(sumjhje)) 进零差额,
	(sum(sumlsje)-sum(sumpfje)) 批零差额,count(*) 单据张数 
	from 
	(
	   select yjid,wldw,ywlx,sumjhje,sumlsje,sumpfje from vi_yk_dj where shrq>=@rq1 and shrq<=@rq2 and shbz=1 and ywlx in('003','014','017','018','020','022','030','032') 
	   and (wldw=@lyks or (wldw<>0 and @lyks=0) ) and deptid in(select deptid from #deptid)
	   union all
	   select yjid,wldw,ywlx,-1*sumjhje,-1*sumlsje,-1*sumpfje from vi_yk_dj where shrq>=@rq1 and shrq<=@rq2 and shbz=1 and ywlx in('004') 
	   and (wldw=@lyks or (wldw<>0 and @lyks=0) ) and deptid in(select deptid from #deptid)
	)a
	  group by a.YWLX,WLDW order by a.ywlx,wldw

end
else
	begin
	    select '0' 序号,rtrim(dbo.fun_yk_ywlx(a.YWLX)) 出库方式,
	(case a.ywlx when '003'  then dbo.fun_getdeptname(wldw)+'出库'
	            when '004' then dbo.fun_getdeptname(wldw)+'退库'
				when '014' then dbo.fun_getdeptname(wldw)+'其它领药'
				when '022' then dbo.fun_getdeptname(wldw)+'外用药领药' 
				when '017' then '处方出库'
				when '018' then '门诊处方补录出库'
				when '020' then '住院处方补录出库'
				when '030' then dbo.fun_getdeptname(wldw)+'调出'  
				 when '032' then '原料消耗出库' 
				 else '' end
	) 往来单位 ,
	  sum(sumjhje) 进货金额,sum(sumpfje) 批发金额,sum(sumlsje) 零售金额,
	  (sum(sumlsje)-sum(sumjhje)) 进零差额,
	(sum(sumlsje)-sum(sumpfje)) 批零差额,count(*) 单据张数 
	from 
	(
	   select yjid,wldw,ywlx,sumjhje,sumlsje,sumpfje from vi_yk_dj where  shbz=1 and ywlx in('003','014','017','018','020','022','030','032')
	   and (wldw=@lyks or (wldw<>0 and @lyks=0) ) and deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)
	   union all
	   select yjid,wldw,ywlx,-1*sumjhje,-1*sumlsje,-1*sumpfje from vi_yk_dj where  shbz=1 and ywlx in('004') 
	   and (wldw=@lyks or (wldw<>0 and @lyks=0) ) and deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)
	)a
	group by a.YWLX,WLDW order by a.ywlx,wldw
end 

--exec SP_Yk_TJ_cKHZ 98,'2007-04-01 00:00:00','2007-04-29 23:59:59',0,0,0




