
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_YPTZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_YPTZ
GO

CREATE PROCEDURE SP_YF_YPTZ
 (@rq1 datetime, 
  @rq2 datetime, 
  @cjid int,
  @deptid int,
  @yplx int,
  @ypzlx int
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
	  cjid int
   ) 
   
  create table #DJMX
   (
   	  CJID INT,
	  YPSL DECIMAL(15,3),
	  lsje DECIMAL(15,3)
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
	select top 2 * from yp_kjqj where deptid=@deptid and jsrq<=@rq1  order by djsj desc
	) a order by djsj desc
	IF @YJID IS NULL 
		set @yjid=null
end




--计算上期数
create TABLE #ymjc (ID int IDENTITY (1, 1) NOT NULL ,CJID INT,ydwbl int,sqsl DECIMAL(15,3),sqje decimal(15,3),bqsl decimal(15,3),bqje decimal(15,3)) 

INSERT INTO #ymjc(CJID,sqsl,sqje)
SELECT c.cjid,
sum(case when a.ywlx='005' then 0 else dbo.fun_YF_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
sum(dbo.fun_YF_drt(a.ywlx,lsje))
FROM VI_YF_DJ A (nolock),VI_YF_DJMX B (nolock),YF_kcmx c (nolock)
WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID  and 
( (shbz=1 and a.ywlx not in('001','002') and shrq>@yjdjsj and shrq<@rq1 ) or 
( a.ywlx in('002','001') and dbo.Fun_GetDate(a.djrq)>=@yjdjsj and dbo.Fun_GetDate(a.djrq)<=@rq1 
and  convert(nvarchar,a.djsj,108)>convert(nvarchar,@yjdjsj,108) and
 convert(nvarchar,a.djsj,108)<convert(nvarchar,@rq1,108)  )
)  
group by c.cjid

insert into #ymjc(cjid,ydwbl,sqsl,sqje)
select b.cjid,ydwbl,round(jcsl*b.dwbl/ydwbl,3),jclsje from yf_ymjc a (nolock),yf_kcmx b (nolock) 
where a.cjid=b.cjid and  b.deptid=@deptid and yjid=@yjid 


--本期数
INSERT INTO #ymjc(CJID,bqsl,bqje)
SELECT c.cjid,
sum(case when a.ywlx='005' then 0 else dbo.fun_YF_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
sum(dbo.fun_YF_drt(a.ywlx,lsje))
FROM VI_YF_DJ A (nolock),VI_YF_DJMX B (nolock),YF_kcmx c (nolock)
WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID  and 
( (shbz=1 and a.ywlx not in('001','002') and shrq>=@rq1 and shrq<=@rq2 ) or 
( a.ywlx in('002','001') and djrq+convert(nvarchar,a.djsj,108)>=@rq1 and djrq+convert(nvarchar,a.djsj,108)<=@rq2 
and  convert(nvarchar,a.djsj,108)>=convert(nvarchar,@rq1,108) and convert(nvarchar,a.djsj,108)<=convert(nvarchar,@rq2,108)  )
)  
group by c.cjid

insert into #temp(cjid,sqsl,sqje,bqsl,bqje,jcsl,jcje,ypdw)
select a.cjid,sum(sqsl),sum(sqje),sum(bqsl),sum(bqje),0,0,dbo.fun_yp_ypdw(zxdw) from #ymjc a,
yf_kcmx b
where a.cjid=b.cjid and b.deptid=@deptid group by a.cjid,b.zxdw

set @stmt='
select '''' 序号,shh 货号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,lsj 零售价,a.ypdw 单位,
sqsl 上期数量,sqje 上期金额,bqsl 本期数量,bqje 本期金额,
(coalesce(sqsl,0)+coalesce(bqsl,0)) 结存数量,(coalesce(sqje,0)+coalesce(bqje,0)) 结存金额
 from #temp a,yp_ypcjd b where a.cjid=b.cjid '
if @cjid>0
  set @stmt=@stmt+' and a.cjid='+cast(@cjid as varchar(30))+' '
if @yplx>0
  set @stmt=@stmt+' and n_yplx='+cast(@yplx as varchar(30))+' '
if @ypzlx>0
  set @stmt=@stmt+' and n_ypzlx='+cast(@ypzlx as varchar(30))+' '
set @stmt=@stmt+
' union all 
select ''合计'',null 货号,null 品名,null 商品名,null 规格,null 厂家,null 零售价,null 单位,
null 上期数量,sum(sqje) 上期金额,null 本期数量,sum(bqje) 本期金额,null 结存数量,(sum(sqje)+sum(bqje)) 结存金额
 from #temp a  ,yp_ypcjd b where a.cjid=b.cjid '
if @cjid>0
  set @stmt=@stmt+' and a.cjid='+cast(@cjid as varchar(30))+' '
if @yplx>0
  set @stmt=@stmt+' and n_yplx='+cast(@yplx as varchar(30))+' '
if @ypzlx>0
  set @stmt=@stmt+' and n_ypzlx='+cast(@ypzlx as varchar(30))+' '

print @stmt
exec(@stmt)

end


-- exec SP_YF_YPTZ '2011-07-24 23:59:59','2014-08-24 23:59:59',0,35,0,0
--exec SP_YF_YPTZ '2011-08-24 23:59:59','2011-09-29 23:59:59',0,35,0,0
--exec SP_YF_YPTZ '2011-01-25 23:59:59','2011-02-24 23:59:59',0,35,1,0
