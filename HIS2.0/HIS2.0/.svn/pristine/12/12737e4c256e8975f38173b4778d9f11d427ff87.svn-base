IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TJ_GZL' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TJ_GZL
GO
CREATE PROCEDURE SP_YF_TJ_GZL  
 (   
   @deptid int,  
   @RQ1 datetime,   
   @RQ2 datetime,
   @tjfs int--0:发药人统计    1：配药人统计  
 )  
as   

begin


/*
exec SP_YF_TJ_GZL 399,'2014-10-01 00:00:00','2014-10-07 00:00:00',0
*/

  select 
  case when grouping(dbo.fun_getEmpName(EMPLOYEE_ID))=1 then '合计' else cast(dbo.fun_getEmpName(EMPLOYEE_ID) as varchar) end 工作人,--dbo.fun_getEmpName(EMPLOYEE_ID) 工作人,
				  sum(isnull(a.tlgzl,0)) 统领数,
				  sum(isnull(b.bygzl,0)) 摆药数,
				  sum(isnull(c.cfgzl,0)) 住院处方数
				  --isnull(a.tlgzl,0) 统领数,
				  --isnull(b.bygzl,0) 摆药数,
				  --isnull(c.cfgzl,0) 住院处方数
   from jc_emp_dept_role t
  left join 
  (
	  select gzid,
	  --gzr,
	--COUNT(1) as zl,SUM(ypsl) as zsl,
	(cast(round(COUNT(1)/CAST(10 as decimal(15,4)),4) as float)+cast(round(SUM(ypsl)/CAST(100 as decimal(15,4)),4) as float)) as tlgzl
	 from
	 (
	select --case when @tjfs=0 then   dbo.fun_getEmpName(a.FYR) else dbo.fun_getEmpName(a.PYR) end gzr,
		case when @tjfs=0 then   a.FYR else a.PYR end gzid,
		b.CJID,yppm ,ypspm,sum(ABS(ypsl)) as ypsl
	  from yf_tld a inner join yf_tldmx b on a.groupid=b.groupid 
	  left join yp_tlfl c  on b.tlfl=c.name 
	  left join  YP_YPCL e on b.CJID=e.CJID and e.DEPTID=a.DEPTID 
	  where a.FYRQ>=@RQ1 and  a.FYRQ<=@RQ2 and a.DEPTID=@deptid and LYLX=0
	  group by  case when @tjfs=0 then a.FYR else a.PYR end,a.GROUPID,b.CJID,yppm ,ypspm)a group by gzid
  )a on t.EMPLOYEE_ID=a.gzid
  left join 
  (
	select gzid,--gzr,
	COUNT(1) as bygzl
	 from
	 (
	   select --case when @tjfs=0 then   dbo.fun_getEmpName(a.FYR) else dbo.fun_getEmpName(a.PYR) end gzr,
		case when @tjfs=0 then   a.FYR else a.PYR end gzid,
		b.CJID,yppm ,ypspm,sum(ABS(ypsl)) as ypsl
	  from yf_tld a inner join yf_tldmx b on a.groupid=b.groupid 
	  left join yp_tlfl c  on b.tlfl=c.name 
	  left join  YP_YPCL e on b.CJID=e.CJID and e.DEPTID=a.DEPTID 
	  where a.FYRQ>=@RQ1 and  a.FYRQ<=@RQ2 and a.DEPTID=@deptid and LYLX=1
	  group by  case when @tjfs=0 then a.FYR else a.PYR end,a.GROUPID,b.CJID,yppm ,ypspm)a group by gzid
  )b on t.EMPLOYEE_ID=b.gzid
  left join 
  (
	select gzid,--gzr,
	COUNT(1) as cfgzl
	 from
	 (
	  select 
		case when @tjfs=0 then   FYR else PYR end gzid,
		--case when @tjfs=0 then   dbo.fun_getEmpName(FYR) else dbo.fun_getEmpName(PYR) end gzr,
		PATID,b.CJID,b.YPPM
	  from YF_FY a  inner join YF_FYMX b on a.ID=b.FYID
	  where  a.DEPTID=@deptid and a.JZCFBZ=1 and a.FYRQ>=@RQ1 and  a.FYRQ<=@RQ2
	  group by case when @tjfs=0 then FYR else PYR end,a.ID,PATID,b.CJID,b.YPPM)a group by gzid
  )c on t.EMPLOYEE_ID=c.gzid
  where DEPT_ID=@deptid and not exists(select 1 where isnull(a.tlgzl,0)=0 and isnull(b.bygzl,0)=0 and isnull(c.cfgzl,0)=0)
  --and  isnull(a.tlgzl,0)<>0
  --(isnull(a.tlgzl,0)<>0 and isnull(b.bygzl,0)<>0 and isnull(c.cfgzl,0)<>0)
  group by dbo.fun_getEmpName(EMPLOYEE_ID) 
  with rollup
  having GROUPING(dbo.fun_getEmpName(EMPLOYEE_ID))=1 or GROUPING(dbo.fun_getEmpName(EMPLOYEE_ID))=0
  --order by 统领数 desc
  

 
end

 