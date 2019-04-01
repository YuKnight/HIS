IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yp_tj_dsyhz' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yp_tj_dsyhz
GO
CREATE PROCEDURE sp_yp_tj_dsyhz 
(
	@deptid int,
	@year  int,
	@month  int,
	@cjid int,
	@kssj datetime,
    @jssj datetime,
    @ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(250) output
)
as
 declare @sql varchar(8000)       

set @sql='select b.CJID as 编码,LTRIM(RTRIM(b.yppm)) as 品名,b.YPGG as 规格,b.YPDW as 单位,b.LSJ as 零售价,jhj as 进货价,0 as 用药数,YPSL as 领药数,
		dbo.fun_getdeptname(a.wldw) as 往来单位,b.YDWBL as 单位比例 ,lsje 领药零售金额,jhje 领药进货金额,0 as 用药零售金额,0 as 用药进货金额
		from  yf_dj  a inner join yf_djmx b on a.ID=b.DJID 
		and a.DEPTID in(566) and a.YWLX in(''014'') and a.SHBZ=1 inner join VI_YP_YPCD e on b.cjid=e.cjid  and e.tlfl=''03'' '
if isnull(@year,'0')=0
	set @sql=@sql+' and SHRQ>='''+CONVERT(varchar(10),@kssj,120)+''' and SHRQ<='''+CONVERT(varchar(10),@jssj)+''''
else
	set @sql=@sql+'and  DATEPART(yy,SHRQ)='+CAST(CAST(@year as varchar(10)) as varchar(10))+' and DATEPART(mm,SHRQ)='+cast(cast(@month as varchar(2)) as varchar(2))+''
if @deptid>0 
 set @sql=@sql+'and   a.wldw='+CAST(@deptid as varchar(50))+'   '
if @cjid>0 
 set @sql=@sql+'and   b.cjid='+CAST(@cjid as varchar(50))+'   '
 
set @sql=@sql+' union all '
set @sql=@sql +'select cjid as 编码,LTRIM(RTRIM(spmc)) as 品名,gg as 规格,dw as 单位,lsj as 零售价,jhj as 进货价,sl as 用药数,0 as 领药数,
				                dbo.fun_getdeptname(wldw) as 往来单位,YDWBL as 单位比例 ,0 领药零售金额,0 领药进货金额,lsje 用药零售金额,jhje 用药进货金额 from yp_tj_dsyyp  
				                where  (zylx=1 or bz=''门诊大输液'') '
if isnull(@year,'0')=0
	set @sql=@sql+' and fyrq>='''+CONVERT(varchar(10),@kssj,120)+''' and fyrq<='''+CONVERT(varchar(10),@jssj,120)+''''
else
	set @sql=@sql+' and DATEPART(yy,fyrq)='+CAST(@year as varchar(10))+' and DATEPART(mm,fyrq)='+cast(@month as varchar(2))+''
	
if @deptid>0 
 set @sql=@sql+'and   wldw='+CAST(@deptid as varchar(50))+'   '
if @cjid>0 
 set @sql=@sql+'and   cjid='+CAST(@cjid as varchar(50))+'   '
 
	
set @sql='select 编码,品名,规格,单位,零售价,进货价,sum(用药数) as 用药数,sum(用药进货金额) 用药进货金额,sum(用药零售金额) 用药零售金额 ,
		 sum(领药数) as 领药数,sum(领药进货金额) 领药进货金额,sum(领药零售金额) 领药零售金额,
		 sum(用药数)-sum(领药数) as 差数,sum(用药进货金额)-sum(领药进货金额) 进货金额差值,sum(用药零售金额)-sum(领药零售金额) 零售金额差值,
          (sum(用药数)-sum(领药数))*进货价 as 进货金额,(sum(用药数)-sum(领药数))*零售价 as 零售金额,
         往来单位,单位比例 from ('+@sql+') a group by 编码,品名,规格,单位,零售价,往来单位,进货价,单位比例 order by 往来单位,编码'
print(@sql)
exec (@sql)

set @ERR_CODE=0
set @ERR_TEXT='查询成功'  


