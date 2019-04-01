
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TJ_CKHZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TJ_CKHZ
GO
CREATE PROCEDURE SP_YF_TJ_CKHZ
 ( 
   @deptid int,
   @RQ1 datetime, 
   @RQ2 datetime,
   @yplx int,
   @year int,
   @month int,
   @qfy int
 )
as 

--如果是按月份统计先得到月结ID
declare @yjid UNIQUEIDENTIFIER
if @year>0
begin
  set @yjid=(select id from yp_kjqj where kjnf=@year and kjyf=@month and deptid=@deptid );
  if @yjid is null  
    set @yjid=dbo.FUN_GETEMPTYGUID()
end


if @year=0
begin
	  select '0' 序号,rtrim(dbo.fun_yf_ywlx(a.YWLX)) 出库方式,
	(case a.ywlx when '003'  then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'调出'
	            when '014' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'其它领药'
				--when '019' then dbo.fun_yp_ghdw(wldw)+'其它入库'
				when '017' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'门诊处方发药'
				when '018' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'门诊处方补录'
				when '020' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'住院处方发药'
				when '021' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'住院处方补录'
				when '022' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'外用药领药'
				when '023' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+rtrim(dbo.fun_yf_ywlx(a.YWLX))
				when '025' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'保健处方记帐'
				when '026' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'财务科记帐' else '' end
	) 往来单位 ,
	sum(jhje) 进货金额,sum(pfje) 批发金额,sum(lsje) 零售金额,
	(sum(lsje)-sum(jhje)) 进零差额,(sum(lsje)-sum(pfje)) 批零差额,count(distinct a.id) 单据张数 
	from vi_yF_dj a,vi_yf_djmx b 
	  where a.id=b.djid and shrq>=@rq1 and shrq<=@rq2 and shbz=1 
	and ((a.ywlx in('003','014','017','018','020','021','022','023','025','026') and @qfy=0) or (a.ywlx in('017','018','020','021') and @qfy=1) )and ((a.deptid=@deptid and @deptid>0) or @deptid=0)
	  group by a.deptid,a.YWLX,WLDW order by a.deptid,a.ywlx,wldw
end
else
begin
    select '0' 序号,rtrim(dbo.fun_yf_ywlx(a.YWLX)) 出库方式,
			(case a.ywlx when '003'  then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'调出'
            when '014' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'其它领药'
			--when '019' then dbo.fun_yp_ghdw(wldw)+'其它入库'
			when '017' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'门诊处方发药'
			when '018' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'门诊处方补录'
			when '020' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'住院处方发药'
			when '021' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'住院处方补录'
			when '022' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'外用药领药'
			when '023' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+rtrim(dbo.fun_yf_ywlx(a.YWLX))
			when '025' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'保健处方记帐'
			when '026' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'财务科记帐' else '' end
			) 往来单位 ,
		sum(jhje) 进货金额,sum(pfje) 批发金额,sum(lsje) 零售金额,
  	 (sum(lsje)-sum(jhje)) 进零差额,(sum(lsje)-sum(pfje)) 批零差额,count(distinct a.id) 单据张数 
	from vi_yF_dj a,vi_yf_djmx b 
   	where a.id=b.djid and isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid and shbz=1 and 
	((a.ywlx in('003','014','017','018','020','021','022','023','025','026')  and @qfy=0) or (a.ywlx in('017','018','020','021') and @qfy=1) )
	and ((a.deptid=@deptid and @deptid>0) or @deptid=0)
   	group by a.deptid,a.YWLX,WLDW order by a.deptid,a.ywlx,wldw
end 
--exec SP_YF_TJ_cKHZ 35,'2009-04-01 00:00:00','2011-04-29 23:59:59',0,0,0,0




