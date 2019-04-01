IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TJ_RKHZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TJ_RKHZ
GO
CREATE PROCEDURE SP_YF_TJ_RKHZ
 ( 
   @deptid int,
   @RQ1 datetime, 
   @RQ2 datetime,
   @yplx int,
   @year int,
   @month int
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
  select '0' 序号,rtrim(dbo.fun_yf_ywlx(a.YWLX)) 入库方式,
(case a.ywlx when '004'  then dbo.fun_getdeptname(wldw)+'退库'
            when '015' then dbo.fun_getdeptname(wldw)+'调入'
			when '016' then dbo.fun_getdeptname(wldw)+'出库'
			when '019' then dbo.fun_yp_ghdw(wldw)+'其它入库'
			when '024' then dbo.fun_getdeptname(wldw)+'' else dbo.fun_yp_ghdw(wldw) end
) 往来单位 ,
sum(sumjhje) 进货金额,sum(sumpfje) 批发金额,sum(sumlsje) 零售金额,
  (sum(sumlsje)-sum(sumjhje)) 进零差额,(sum(sumlsje)-sum(sumpfje)) 批零差额,count(*) 单据张数 
from 
(
  select ywlx,wldw,sumjhje,sumpfje,sumlsje from vi_yf_dj  where shrq>=@rq1 and shrq<=@rq2 and shbz=1 and ywlx in('015','016','019','024') and deptid=@deptid
  union all 
  select ywlx,wldw,-1*sumjhje,-1*sumpfje,-1*sumlsje from vi_yf_dj  where shrq>=@rq1 and shrq<=@rq2 and shbz=1 and ywlx in('004') and deptid=@deptid
  union all
  select ywlx,wldw,sumjhje,sumpfje,sumlsje from vi_yf_dj  where  djrq>=@rq1 and djrq<=@rq2  and ywlx in('001') and deptid=@deptid
   union all
  select ywlx,wldw,-1*sumjhje,-1*sumpfje,-1*sumlsje from vi_yf_dj  where  djrq>=@rq1 and djrq<=@rq2  and ywlx in( '002') and deptid=@deptid
) a
  group by a.YWLX,WLDW order by a.ywlx,wldw
end
else
begin
    select '0' 序号,rtrim(dbo.fun_yf_ywlx(a.YWLX)) 入库方式,
(case a.ywlx when '004'  then dbo.fun_getdeptname(wldw)+'退库'
            when '015' then dbo.fun_getdeptname(wldw)+'调入'
			when '016' then dbo.fun_getdeptname(wldw)+'出库'
			when '019' then dbo.fun_yp_ghdw(wldw)+'其它入库'
			when '024' then dbo.fun_getdeptname(wldw)+'' else '' end
) 往来单位 ,
sum(sumjhje) 进货金额,sum(sumpfje) 批发金额,sum(sumlsje) 零售金额,
   (sum(sumlsje)-sum(sumjhje)) 进零差额,(sum(sumlsje)-sum(sumpfje)) 批零差额,count(*) 单据张数 
from 
(
  select ywlx,wldw,sumjhje,sumpfje,sumlsje from vi_yf_dj  where isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid and shbz=1 and ywlx in('001','015','016','019','024') and deptid=@deptid
  union all 
  select ywlx,wldw,-1*sumjhje,-1*sumpfje,-1*sumlsje from vi_yf_dj  where isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid and shbz=1 and ywlx in('004','002') and deptid=@deptid
) a
   group by a.YWLX,WLDW order by a.ywlx,wldw
end 


--exec SP_YF_TJ_RKHZ 97,'2007-04-01 00:00:00','2007-04-29 23:59:59',0,0,0

