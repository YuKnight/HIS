
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_XHQK' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_XHQK
GO
-- exec SP_YF_XHQK '2011-07-24 00:00:00','2011-07-24 23:59:59',35
--本过程去某药房的 某区间的消耗情况-按药品显示
--原来的时间条件好像不对
--按门诊或住院，cjid,零售价

CREATE PROCEDURE SP_YF_XHQK
 (@rq1 datetime, 
  @rq2 datetime, 
  @deptid int
 ) 
as
BEGIN

 DECLARE @stmt varchar(6000); --定义SQL文本

 --声明临时表
   create table #TEMP
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
	  bqsl decimal(15,3),
	  bqje decimal(15,2),
      ypdw varchar(20),
	  ydwbl int,
	  cjid int,
	  lsj decimal(15,4), --单价
	  lx varchar(20) --类型 门诊或住院

   ) 

create TABLE #bqxh (ID int IDENTITY (1, 1) NOT NULL ,CJID INT,
bqsl decimal(15,3),bqje decimal(15,3),lsj decimal(15,4),lx varchar(20)) 




--本期数
INSERT INTO #bqxh(CJID,bqsl,bqje,lsj,lx)
SELECT c.cjid,
sum(case when a.ywlx='005' then 0 else dbo.fun_YF_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) * -1 ,
sum(dbo.fun_YF_drt(a.ywlx,lsje)) * -1 ,b.LSJ,
(case when a.ywlx in ('017','018') then '门诊'  when a.ywlx in ('020','021') then '住院' else '' end) lx

FROM VI_YF_DJ A (nolock),VI_YF_DJMX B (nolock),YF_kcmx c (nolock)
WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID  and 
a.YWLX in ('017','018','020','021') and --017,018 门诊，020,021住院
--( shbz=1 and shrq>=@rq1 and shrq<=@rq2 --原来的条件，好像不对，尤其是a.djsj 条件
((shbz=1 and a.ywlx not in('001','002') and shrq>=@rq1 and shrq<=@rq2 ) or 
( a.ywlx in('002','001') and dbo.Fun_GetDate(a.djrq)>=dbo.Fun_GetDate(@rq1) and dbo.Fun_GetDate(a.djrq)<=dbo.Fun_GetDate(@rq2) 
and  convert(nvarchar,a.djsj,108)>=convert(nvarchar,@rq1,108) and convert(nvarchar,a.djsj,108)<=convert(nvarchar,@rq2,108)  )
) 
group by c.cjid,b.lsj,a.YWLX 


insert into #temp(cjid,bqsl,bqje,ypdw,lsj,lx)
select a.cjid,sum(bqsl)  ,sum(bqje) ,dbo.fun_yp_ypdw(zxdw),a.lsj,a.lx from #bqxh a,
YF_kcmx b
where a.cjid=b.cjid and b.deptid=@deptid group by a.cjid,b.zxdw,a.lx,a.lsj



set @stmt=' select * from (  
select '''' 序号,a.lx 门诊或住院,a.cjid 药品内码,b.s_ypspm 商品名,b.s_yppm 品名,b.s_sccj 生产厂家  
,b.s_ypgg 规格, bzsl 包装数量,a.ypdw 单位,bqsl 使用数量,a.lsj 单价,bqje 金额  
  
 from #temp a ,VI_YP_YPCD b  
 where a.cjid=b.cjid'  
  
  
set @stmt=@stmt+  
' union all   
select ''合计'',null 门诊或住院,null 药品内码,null 商品名,null 品名,null 生产厂家,  
null 规格,null 包装数量,null 单位,sum(bqsl) 使用数量,null 单价,sum(bqje) 金额  
 from #temp a ) aa order by 序号,门诊或住院'  
  


print @stmt
exec(@stmt)
drop table #bqxh
drop table #temp
end




