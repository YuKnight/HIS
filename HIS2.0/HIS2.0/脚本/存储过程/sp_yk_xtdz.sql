
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_XTDZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_XTDZ
GO

CREATE PROCEDURE SP_YK_XTDZ
 (@JSRQ datetime,
  @deptid integer
 )
as

BEGIN

declare @yjid UNIQUEIDENTIFIER 
declare @tx_deptid int 
create TABLE #DJMX( YPSL DECIMAL(15,3),jhje decimal(15,3),PFJE decimal(15,3), LSJE decimal(15,3),kcid uniqueidentifier ) 
create TABLE #YJB(YJID UNIQUEIDENTIFIER )  
create table #deptid(deptid int) 

--需要统计的科室  
insert #deptid(deptid) select dept_id from jc_dept_property  where dept_id=@deptid or dept_id in(select deptid from yp_yjks_gx where p_deptid=@deptid) 
--需要统计的上月YJID
declare tx cursor local for  select deptid from #deptid
open  tx
fetch next from tx into @tx_deptid
while @@FETCH_STATUS=0
begin
   insert into #YJB(YJID) select top 1 id  FROM YP_KJQJ WHERE DEPTID=@tx_deptid   order by djsj desc
fetch next from tx into @tx_deptid
end
 

--汇总本期单据的发生数量和金额    
INSERT INTO #DJMX(YPSL,jhje,PFJE,LSJE,kcid )    
SELECT    
sum(case when a.ywlx='005' then 0 else dbo.fun_YK_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,    
SUM(dbo.FUN_YK_DRT(a.ywlx,jhje)),  
sum(dbo.fun_YK_drt(a.ywlx,pfje)),    
sum(dbo.fun_YK_drt(a.ywlx,lsje))    
,isnull(b.kcid,dbo.FUN_GETEMPTYGUID())   
FROM YK_DJ A,YK_DJMX B,YK_KCPH c     
WHERE a.id=b.djid AND B.KCID=C.ID and A.DEPTID in(select DEPTID from #deptid)
and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null)     
and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002')))    
and b.kcid=c.ID     
group by  b.kcid     
  
--防止kcid处理意外 
if not EXISTS(select * from #DJMX where kcid not in(select kcid from YK_KCPH where DEPTID=@deptid))
		select 
		a.cjid,dbo.fun_getdeptname(deptid) 仓库名称,shh 货号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,ypdw 单位,  
		cast(jcsl as float) 上期数量, cast(jcjhje as decimal(15,3)) 上期进货金额,jcpfje 上期批发金额,jclsje 上期零售金额,    
		cast(bqsl as float) 发生数量,  bqjhje 发生进货金额,   bqpfje 发生批发金额,bqlsje 发生零售金额,
		cast(kcsl as float) 库存数量,  cast(kcjhje as decimal(15,3)) 库存进货金额, CAST( kcpfje as decimal(15,3)) 库存批发金额,cast(kclsje as decimal(15,3)) 库存零售金额,
		cast((jcsl+bqsl-kcsl) as float) 数量差值,
		cast((jcjhje+bqjhje-kcjhje)  as decimal(15,3)) 进货金额差值,
		cast((jcpfje+bqpfje-kcpfje)  as decimal(15,3)) 批发金额差值,
		cast((jclsje+bqlsje-kclsje)  as decimal(15,3)) 零售金额差值,
		dwbl,deptid,yppch 批次号,ypph 批号,kcid
		from (
			SELECT a.cjid,a.DEPTID,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,dbo.fun_yp_ypdw(zxdw) ypdw,a.yppch,a.ypph,a.ID as kcid,a.DWBL,
			
			coalesce((jcsl*dwbl)/ydwbl,0) as jcsl,
			coalesce(round(jcjhje,3),0) jcjhje,
			coalesce(round(jcpfje,3),0) JCPFJE,
			coalesce(round(jclsje,3),0) JCLSJE ,
			
			coalesce(C.YPSL,0) as bqsl,
			coalesce(C.jhje,0) as bqjhje,
			coalesce(C.PFJE,0) as bqpfje,
			coalesce(C.LSJE,0) as bqlsje,
			
			round(kcl,3) as kcsl,
			round(A.JHJ*kcl/a.dwbl,3) as kcjhje,
			round(d.pfj*kcl/a.dwbl,3) as kcpfje,
			round(d.lsj*kcl/a.dwbl,3) as kclsje
			
			FROM YK_KCPH A LEFT JOIN YK_YMJC B  ON A.ID=ISNULL(B.KCID,dbo.FUN_GETEMPTYGUID())  AND B.YJID IN(SELECT YJID FROM #YJB)
			LEFT JOIN #DJMX C ON A.ID=C.kcid
			inner join YP_YPCJD d on A.CJID=d.CJID
			WHERE   A.deptid IN(SELECT DEPTID FROM #deptid)
		) a   
		where (jcsl+bqsl-kcsl)<>0  or ABS(jclsje+bqlsje-kclsje)>=0.01   
		or abs(jcpfje+bqpfje-kcpfje)>0.01  or 
		abs(jcjhje+bqjhje-kcjhje) >=0.01   
else
		select 
		 '系统发生严重错误,请和管理人员联系' as 备注
		from  #DJMX  where kcid not in(select kcid from YK_KCPH where DEPTID in(select DEPTID from #deptid)) 
 
end
 
 

