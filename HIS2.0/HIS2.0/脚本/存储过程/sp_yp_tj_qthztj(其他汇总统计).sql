IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yp_tj_qthztj' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yp_tj_qthztj
GO
CREATE PROCEDURE sp_yp_tj_qthztj 
(
	@deptid int,
	@yk int,
	@jhjetj int,
	@year int,
	@month int,
    @ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(250) output
)
as

/*
declare @err_code int
declare @err_text varchar(300)
exec sp_yp_tj_qthztj @deptid=94,@yk=1,@jhjetj=0,@year=2014,@month=6,@err_code=@err_code output,@err_text=@err_text output
select @err_code,@err_text

declare @err_code int
declare @err_text varchar(300)
exec sp_yp_tj_qthztj @deptid=142,@yk=0,@jhjetj=0,@year=2014,@month=7,@err_code=@err_code output,@err_text=@err_text output
select @err_code,@err_text

*/
begin

create table #ywlx(ywlx varchar(30),ywmc varchar(50),ywzt varchar(10),ywfx varchar(10),ywjc varchar(30),tjlx varchar(50),ywlxpxfs int,wldwhz int,wldwlx int)


--准备本月或本年月结记录ID 
create table #tempyjjl(yjid uniqueidentifier,kjnf int ,kjyf int,deptid int,qc smallint ,qm smallint)
if @yk=1 
begin
	insert into #tempyjjl(yjid,kjnf,kjyf,deptid)
	select b.ID,KJNF,KJYF,a.DEPTID from YP_YJKS a left join YP_KJQJ b 
	on a.DEPTID=b.DEPTID and KJNF=@year and ((KJYF=@month and @month>0) or @month=0) where a.KSLX='药库' and a.DEPTID =@deptid and QYBZ=1
	insert into #ywlx(ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx) select ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx from yk_ywlx
end
else
begin
	insert into #tempyjjl(yjid,kjnf,kjyf,deptid)
	select b.ID,KJNF,KJYF,a.DEPTID from YP_YJKS a left join YP_KJQJ b 
	on a.DEPTID=b.DEPTID and KJNF=@year and ((KJYF=@month and @month>0) or @month=0)  where a.KSLX='药房' and a.DEPTID =@deptid and QYBZ=1
	insert into #ywlx(ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx) select ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx from yf_ywlx
end

 

if @jhjetj=0
	select ywjc as 业务类型,	 
	case when ywjc = '调整减少' then  0 else sum(JHJE) end 增加金额,		 
	case when ywjc = '调整减少' then  sum(JHJE) else sum(thje)*(-1) end 减少金额,		 
	case when ywjc = '调整减少' then  -sum(JHJE) else sum(JHJE)+sum(thje) end 实际金额 
	
	from (
	select  a.YWLX as ywlx,ywjc,(case when LSJE>=0 then LSJE else 0 end) as JHJE,(case when LSJE<0 then LSJE else 0 end) as thje 
	from  YP_TJ_YMJCMX a  inner join #tempyjjl b on a.yjid=b.yjid inner join #ywlx c on a.YWLX=c.ywlx  
	inner join yp_ypcjd D on a.CJID=d.CJID where  tjlx='本期其它'  
	) a
	group by ywlx ,ywjc order by ywlx
else
	select ywjc as 业务类型,
	--sum(JHJE) 增加金额,
	--sum(thje)*(-1)  减少金额,
	--sum(JHJE)+sum(thje) as 实际金额 
	case when ywjc = '调整减少' then  0 else sum(JHJE) end 增加金额,
	case when ywjc = '调整减少' then  sum(JHJE) else sum(thje)*(-1) end 减少金额,	
	case when ywjc = '调整减少' then  -sum(JHJE) else sum(JHJE)+sum(thje) end 实际金额 
	
	from (
	select  a.YWLX as ywlx,ywjc,(case when JHJE>=0 then JHJE else 0 end) as JHJE,(case when JHJE<0 then JHJE else 0 end) as thje 
	from  YP_TJ_YMJCMX a  inner join #tempyjjl b on a.yjid=b.yjid inner join #ywlx c on a.YWLX=c.ywlx  
	inner join yp_ypcjd D on a.CJID=d.CJID where  tjlx='本期其它'  
	) a
	group by ywlx,ywjc order by ywlx



set @ERR_CODE=0
set @ERR_TEXT='保存成功'  

end 

