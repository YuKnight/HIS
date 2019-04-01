
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_TJ_CG_RCQK' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_TJ_CG_RCQK
GO

CREATE PROCEDURE SP_YK_TJ_CG_RCQK
 (
  @shbz int, --0 未审核 1审核 2全部
  @rq1 varchar(30), 
  @rq2 varchar(30), 
  @ghdw int,
  @deptid int,
  @deptid_ck int
 ) 
as
BEGIN
 

 DECLARE @stmt varchar(6000); --定义SQL文本


  create table #DJMX
   (
	  ghdw int,
	  ywy int,
   	  CJID INT,
      rk_sl decimal(15,3),
	  rk_jhje decimal(15,3),
	  rk_pfje decimal(15,3),
	  rk_lsje decimal(15,3),
	  ck_sl DECIMAL(15,3),
	  ck_jhje decimal(15,3),
	  ck_pfje decimal(15,3),
	  ck_lsje decimal(15,3),
	  hj_sl decimal(15,3),
	  hj_jhje decimal(15,3),
	  hj_pfje decimal(15,3),
	  hj_lsje decimal(15,3),
	  hj_jlce decimal(15,3)
   ) 

create table #deptid(deptid int)
--需要统计的科室
if (@deptid_ck>0)
  insert #deptid(deptid)values(@deptid_ck)
else 
  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID
--是否区分业务员
declare @bywy int
set @bywy=(select top 1 zt from yk_config where bh=114 and deptid in(select deptid from #deptid))
if @bywy is null set @bywy=0

set @bywy=1
--入库
set @stmt='
INSERT INTO #DJMX(ghdw,ywy,cjid,rk_sl,rk_jhje,rk_pfje,rk_lsje)
SELECT wldw,case when '+cast(@bywy as varchar(10))+'=1 then jsr else 0 end,0 as cjid,sum((ypsl*c.dwbl)/b.ydwbl),
sum(jhje),sum(pfje),sum(lsje)
FROM VI_YK_DJ A (nolock),VI_YK_DJMX B (nolock),YK_kcmx c (nolock)
WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and
 a.deptid in(select deptid from #deptid) and a.ywlx in(''001'') '
if @shbz=0
	set @stmt=@stmt+' and shbz=0  and dbo.Fun_GetDate(a.djrq)+'' ''+convert(nvarchar,a.djsj,108)>='''+@rq1+'''  
	and dbo.Fun_GetDate(a.djrq)+'' ''+convert(nvarchar,a.djsj,108)<='''+@rq2+''''
if @shbz=1 
	set @stmt=@stmt+' and shbz=1 and shrq>='''+@rq1+''' and shrq<='''+@rq2+''''
if @shbz=2
	set @stmt=@stmt+' and (( shbz=0  and dbo.Fun_GetDate(a.djrq)+'' ''+convert(nvarchar,a.djsj,108)>='''+@rq1+'''  
	and dbo.Fun_GetDate(a.djrq)+'' ''+convert(nvarchar,a.djsj,108)<='''+@rq2+''')
	or (shbz=1 and shrq>='''+@rq1+''' and shrq<='''+@rq2+''') )'
if @ghdw>0
	set @stmt=@stmt+' and wldw='+cast(@ghdw as varchar(30))+' '
if @bywy =1
	set @stmt=@stmt+' group by wldw,jsr'
else
	set @stmt=@stmt+' group by wldw'
exec(@stmt)

--出库
set @stmt='
INSERT INTO #DJMX(ghdw,ywy,cjid,ck_sl,ck_jhje,ck_pfje,ck_lsje)
SELECT wldw,case when '+cast(@bywy as varchar(10))+'=1 then jsr else 0 end,0 as cjid,sum((ypsl*c.dwbl)/b.ydwbl),
sum(jhje),sum(pfje),sum(lsje)
FROM VI_YK_DJ A (nolock),VI_YK_DJMX B (nolock),YK_kcmx c (nolock)
WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and
 a.deptid in(select deptid from #deptid) and a.ywlx in(''002'') '
if @shbz=0
	set @stmt=@stmt+' and shbz=0  and dbo.Fun_GetDate(a.djrq)+'' ''+convert(nvarchar,a.djsj,108)>='''+@rq1+'''  
	and dbo.Fun_GetDate(a.djrq)+'' ''+convert(nvarchar,a.djsj,108)<='''+@rq2+''''
if @shbz=1 
	set @stmt=@stmt+' and shbz=1 and shrq>='''+@rq1+''' and shrq<='''+@rq2+''''
if @shbz=2
	set @stmt=@stmt+' and (( shbz=0  and dbo.Fun_GetDate(a.djrq)+'' ''+convert(nvarchar,a.djsj,108)>='''+@rq1+'''  
	and dbo.Fun_GetDate(a.djrq)+'' ''+convert(nvarchar,a.djsj,108)<='''+@rq2+''')
	or (shbz=1 and shrq>='''+@rq1+''' and shrq<='''+@rq2+''') )'
if @ghdw>0
	set @stmt=@stmt+' and wldw='+cast(@ghdw as varchar(30))+' '
if @bywy =1
	set @stmt=@stmt+' group by wldw,jsr'
else
	set @stmt=@stmt+' group by wldw'
exec(@stmt)



select '' 序号,供货单位,采购_进货金额,采购_批发金额,采购_零售金额,
 退货_进货金额,退货_批发金额,退货_零售金额,合计_进货金额,合计_批发金额,
 合计_零售金额, 合计_进零差额
 from (
select '' 序号,
(case when ywy>0 then dbo.fun_yp_ghdw(ghdw)+'['+isnull(dbo.fun_yp_ywy(ywy),'')+']' else dbo.fun_yp_ghdw(ghdw) end)  供货单位,sum(rk_jhje) 采购_进货金额,
sum(rk_pfje) 采购_批发金额,sum(rk_lsje) 采购_零售金额,
sum(ck_jhje) 退货_进货金额,
sum(ck_pfje) 退货_批发金额,sum(ck_lsje) 退货_零售金额,
coalesce(sum(rk_jhje),0)-coalesce(sum(ck_jhje),0) 合计_进货金额,
coalesce(sum(rk_pfje),0)-coalesce(sum(ck_pfje),0) 合计_批发金额,
coalesce(sum(rk_lsje),0)-coalesce(sum(ck_lsje),0) 合计_零售金额,
(coalesce(sum(rk_lsje),0)-coalesce(sum(ck_lsje),0))-
(coalesce(sum(rk_jhje),0)-coalesce(sum(ck_jhje),0)) 合计_进零差额,ghdw,ywy  from #djmx
 group by ghdw,ywy 
union all
select '' 序号,
'合计'  供货单位,sum(rk_jhje) 采购_进货金额,
sum(rk_pfje) 采购_批发金额,sum(rk_lsje) 采购_零售金额,
sum(ck_jhje) 退货_进货金额,
sum(ck_pfje) 退货_批发金额,sum(ck_lsje) 退货_零售金额,
coalesce(sum(rk_jhje),0)-coalesce(sum(ck_jhje),0) 合计_进货金额,
coalesce(sum(rk_pfje),0)-coalesce(sum(ck_pfje),0) 合计_批发金额,
coalesce(sum(rk_lsje),0)-coalesce(sum(ck_lsje),0) 合计_零售金额,
(coalesce(sum(rk_lsje),0)-coalesce(sum(ck_lsje),0))-
(coalesce(sum(rk_jhje),0)-coalesce(sum(ck_jhje),0)) 合计_进零差额,
9999999 ghdw,9999999 ywy  from #djmx
) a order by ghdw,ywy



end


-- exec SP_YK_TJ_CG_RCQK 2,'1900-07-24 23:59:59','2014-08-24 23:59:59',0,0,33




