
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_CGQK' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_CGQK
GO
-- exec SP_YK_CGQK '2010-03-08 00:00:00','2012-03-08 23:59:59',33
--本过程去某药房的 某区间的购进情况-结存情况-按药品显示
--加了本期购进数量>0的条件--是否需要，请考虑
--药品批发厂家及进货价，使用的最后一次的
CREATE PROCEDURE SP_YK_CGQK
 (@rq1 datetime, 
  @rq2 datetime, 
  @deptid int
 ) 
as
BEGIN
 declare @zy varchar(200);
 declare @count INT 
 declare @sqyear int;
 declare @sqmonth int;

 DECLARE @stmt varchar(6000); --定义SQL文本

 --声明临时表
   create table #TEMP
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
	  sqsl decimal(15,3),
	  sqje decimal(15,2),
	  bqsl decimal(15,3),
	  bqje decimal(15,2),
	  jcsl decimal(15,3),
	  jcje decimal(15,2),
      ypdw varchar(20),
	  ydwbl int,
	  cjid int,
	  bqsl_gj decimal(15,3), --本期购进数量

   ) 


declare @yjid UNIQUEIDENTIFIER --上月月结ID
declare @yjdjsj datetime --上月月结登记时间

select @count=count(*) from yp_kjqj where deptid=@deptid and jsrq<=@rq1 
if coalesce(@count,0)<1 
begin
  set @yjid=null
  set @yjdjsj='2001-01-01 00:00:00'
end
else
begin
	select top 1 @yjid=id,@yjdjsj=jsrq from  (
	select top 2 * from yp_kjqj where deptid=@deptid and jsrq<=@rq1  order by jsrq desc
	) a order by djsj desc
	IF @YJID IS NULL 
		set @yjid=null
end




--计算上期数
create TABLE #ymjc (ID int IDENTITY (1, 1) NOT NULL ,CJID INT,ydwbl int,sqsl DECIMAL(15,3),
sqje decimal(15,3),bqsl decimal(15,3),bqje decimal(15,3),jhj decimal(15,4), bqsl_gj decimal(15,3)) 

INSERT INTO #ymjc(CJID,sqsl,sqje,bqsl_gj,jhj)
SELECT c.cjid,
sum(case when a.ywlx='005' then 0 else dbo.fun_YK_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
sum(dbo.fun_YK_drt(a.ywlx,lsje)),0,B.JHJ
FROM VI_YK_DJ A (nolock),VI_YK_DJMX B (nolock),YK_kcmx c (nolock)
WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID  and 
--( shbz=1 and shrq>@yjdjsj and shrq<@rq1--原来的条件，好像不对，尤其是a.djsj 条件
((shbz=1 and a.ywlx not in('001','002') and shrq>@yjdjsj and shrq<@rq1 ) or 
( a.ywlx in('002','001') and dbo.Fun_GetDate(a.djrq)>=dbo.Fun_GetDate(@yjdjsj) and dbo.Fun_GetDate(a.djrq)<=dbo.Fun_GetDate(@rq1) 
and  convert(nvarchar,a.djsj,108)>convert(nvarchar,@yjdjsj,108) and
 convert(nvarchar,a.djsj,108)<convert(nvarchar,@rq1,108)  )
)
group by c.cjid,B.JHJ


insert into #ymjc(cjid,ydwbl,sqsl,sqje,bqsl_gj)
select b.cjid,ydwbl,round(jcsl*b.dwbl/ydwbl,3),jclsje,0 from YK_ymjc a (nolock),YK_kcmx b (nolock) 
where a.cjid=b.cjid and  b.deptid=@deptid and yjid=@yjid 


--本期数
INSERT INTO #ymjc(CJID,bqsl,bqje,bqsl_gj,jhj)
SELECT c.cjid,
sum(case when a.ywlx='005' then 0 else dbo.fun_YK_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
sum(dbo.fun_YK_drt(a.ywlx,lsje)),
sum(case when a.ywlx in ('001','002') then  dbo.fun_YK_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) else 0 end),
B.JHJ
FROM VI_YK_DJ A (nolock),VI_YK_DJMX B (nolock),YK_kcmx c (nolock)
WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID  and 
--( shbz=1 and shrq>=@rq1 and shrq<=@rq2 --原来的条件，好像不对，尤其是a.djsj 条件
((shbz=1 and a.ywlx not in('001','002') and shrq>=@rq1 and shrq<=@rq2 ) or 
( a.ywlx in('002','001') and dbo.Fun_GetDate(a.djrq)>=dbo.Fun_GetDate(@rq1) and dbo.Fun_GetDate(a.djrq)<=dbo.Fun_GetDate(@rq2) 
and  convert(nvarchar,a.djsj,108)>=convert(nvarchar,@rq1,108) and convert(nvarchar,a.djsj,108)<=convert(nvarchar,@rq2,108)  )
)  
group by c.cjid,B.YWLX,B.JHJ

insert into #temp(cjid,sqsl,sqje,bqsl,bqje,jcsl,jcje,ypdw,bqsl_gj)
select a.cjid,sum(sqsl),sum(sqje),sum(bqsl),sum(bqje),0,0,dbo.fun_yp_ypdw(zxdw),SUM(bqsl_gj) from #ymjc a,
YK_kcmx b
where a.cjid=b.cjid and b.deptid=@deptid group by a.cjid,b.zxdw


set @stmt='
select '''' 序号,b.s_ypspm 商品名,b.s_yppm 品名,b.s_ypgg 规格, bzsl 包装数量,a.ypdw 单位
,b.s_ypjx 药品剂型,dbo.fun_getUsageName(syff) 给药途径,sqsl 上期数量,bqsl_gj 本期购进
,(select top 1 jhj from #ymjc where cjid=a.cjid order by bqsl_gj desc ) 购进价
,b.s_sccj 生产厂家
,(select top 1 dbo.fun_yp_ghdw(t1.wldw) from YK_DJ t1,YK_DJMX t2 where t1.ID=t2.DJID and t2.cjid=a.cjid  and t1.deptid='+ cast(@deptid AS varchar) +' order by t1.shrq desc ) 药品批发单位
,(coalesce(sqsl,0)+coalesce(bqsl,0)) 结存数量
 from #temp a ,VI_YP_YPCD b
 where a.cjid=b.cjid and bqsl_gj>0 '


set @stmt=@stmt+
' union all 
select ''合计'',null 商品名,null 品名,null 规格,null 包装数量,null 单位,
null 药品剂型,null 给药途径,sum(sqsl)上期数量,sum(bqsl_gj) 本期购进,null 购进价 ,null 生产厂家,null 药品批发单位,(sum(sqsl)+sum(bqsl))  结存数
 from #temp a where bqsl_gj>0  '


print @stmt
exec(@stmt)
drop table #ymjc
drop table #temp
end




