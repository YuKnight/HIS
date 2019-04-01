IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TJ_PDRate' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TJ_PDRate
GO
CREATE PROCEDURE SP_YF_TJ_PDRate  
 (   
   @deptid int,  
   @RQ1 datetime,   
   @RQ2 datetime
 )  
as   

begin


/*
exec SP_YF_TJ_PDRate 142,'2014-01-01 00:00:00','2014-10-01 00:00:00'
*/

select 
    a.DEPTID,b.cjid,
	TLFL,
    SUM(pcs) pcs,
    SUM(zcs) zcs into #temp
	from yf_pd a,  
    yf_pdmx b,  
    VI_YP_YPCD c  
    where a.id=b.djid and b.cjid=c.cjid and a.DJRQ >=@RQ1 and a.djrq<=@RQ2 and
    ( (a.DEPTID=@deptid and @deptid>0) or (@deptid=0) )
    group by a.DEPTID,b.cjid,TLFL
    

select  isnull(dbo.fun_getDeptname(b.deptid),'合计') 科室,
	 isnull( (case when TLFL in('01') then '口服' else '非口服' end),'小计') as 药品分类,
	 cast(cast(round(COUNT( case when b.PCS>b.ZCS then 1 end ) /cast(COUNT(1) as decimal(15,4)),4)*100 as float) as varchar(100))+'%'  as 盘盈率,
	 cast(cast(round(COUNT( case when b.PCS<b.ZCS then 1 end ) /cast(COUNT(1) as decimal(15,4)),4)*100 as float) as varchar(100))+'%' as 盘亏率,
	cast(cast(round(COUNT( case when b.PCS<>b.ZCS then 1 end ) /cast(COUNT(1) as decimal(15,4)),4)*100 as float) as varchar(100))+'%' as 不符合率    
	from  #temp b --inner join YP_YJKS c on b.deptid=c.DEPTID
	group by b.deptid ,(case when TLFL in('01') then '口服' else '非口服' end)    with rollup 
	order by b.deptid desc

 
end

 