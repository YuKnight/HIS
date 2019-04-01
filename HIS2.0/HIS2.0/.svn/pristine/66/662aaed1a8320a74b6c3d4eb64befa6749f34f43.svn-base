IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TJ_BSBYHZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TJ_BSBYHZ
GO
CREATE PROCEDURE SP_YF_TJ_BSBYHZ
 ( 
   @deptid int,
   @RQ1 datetime, 
   @RQ2 datetime,
   @yplx int,
   @year int,
   @month int,
   @YWLX char(3)
 )
as 
--exec SP_YK_TJ_PDHZ 95,'','',0,2007,4
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
  select  '0' 序号,yppm 品名,ypspm 商品名,ypgg 规格,sccj 厂家,b.jhj 进价,b.pfj 批发价,b.lsj 零售价,ypsl 数量, ypdw 单位,jhje 进货金额,pfje 批发金额,
   lsje 零售金额,ypph 批号,ypxq 效期,shh 货号,a.djh 单据号,rq 登记日期 , 
  a.bz 备注 from vi_yf_dj a,vi_yf_djmx b
  where a.id=b.djid and a.shrq>=@rq1 and a.shrq<=@rq2  and a.deptid=@deptid and a.ywlx=@ywlx
end
else
begin
  select  '0' 序号,yppm 品名,ypspm 商品名,ypgg 规格,sccj 厂家,b.jhj 进价,b.pfj 批发价,b.lsj 零售价,ypsl 数量, ypdw 单位,jhje 进货金额,pfje 批发金额,
   lsje 零售金额,ypph 批号,ypxq 效期,shh 货号,a.djh 单据号,rq 登记日期 , 
  a.bz 备注 from vi_yf_dj a,vi_yf_djmx b
  where a.id=b.djid and isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid  and a.deptid=@deptid and a.ywlx=@ywlx 
end 



