IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_TJ_BSBYHZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_TJ_BSBYHZ
GO
CREATE PROCEDURE SP_YK_TJ_BSBYHZ
 ( 
   @deptid int,
   @RQ1 datetime, 
   @RQ2 datetime,
   @yplx int,
   @year int,
   @month int,
   @YWLX char(3),
   @deptid_ck int
 )
as 
--exec SP_YK_TJ_PDHZ 95,'','',0,2007,4
--如果是按月份统计先得到月结ID

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
  select  '0' 序号,yppm 品名,ypspm 商品名,ypgg 规格,sccj 厂家,b.jhj 进价,b.pfj 批发价,b.lsj 零售价,ypsl 数量, ypdw 单位,jhje 进货金额,pfje 批发金额,
   lsje 零售金额,b.yppch 批次号,ypph 批号,ypxq 效期,shh 货号,a.djh 单据号,rq 登记日期 , 
  a.bz 备注 from vi_yk_dj a,vi_yk_djmx b
  where a.id=b.djid and a.shrq>=@rq1 and a.shrq<=@rq2   and a.ywlx=@ywlx and a.deptid in(select deptid from #deptid)
end
else
begin
  select  '0' 序号,yppm 品名,ypspm 商品名,ypgg 规格,sccj 厂家,b.jhj 进价,b.pfj 批发价,b.lsj 零售价,ypsl 数量, ypdw 单位,jhje 进货金额,pfje 批发金额,
   lsje 零售金额,b.yppch 批次号,ypph 批号,ypxq 效期,shh 货号,a.djh 单据号,rq 登记日期 , 
  a.bz 备注 from vi_yk_dj a,vi_yk_djmx b
  where a.id=b.djid  and a.ywlx=@ywlx and a.deptid in(select deptid from #deptid)  and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)
end 



