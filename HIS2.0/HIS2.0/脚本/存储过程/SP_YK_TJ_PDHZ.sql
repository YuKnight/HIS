IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_TJ_PDHZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_TJ_PDHZ
GO
CREATE PROCEDURE SP_YK_TJ_PDHZ
 ( 
   @deptid int,
   @RQ1 datetime, 
   @RQ2 datetime,
   @yplx int,
   @year int,
   @month int,
   @deptid_ck int
 )
as 
declare @bpcgl int =0 --是否进行批次管理
select @bpcgl = zt from yk_config where deptid =@deptid_ck and bh =999--暂时设定为999

declare @pdfs varchar(10) ='1'  --启用批次管理时盘点方式 0-盘明细 1-盘批次
select @pdfs=CONFIG from JC_CONFIG where ID=8052 


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
	if @bpcgl=0
	  select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,ypph 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
	  pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,pclsje-zclsje 盈亏金额,
	  jhj 进价,cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) 进货金额盈亏,shh 货号,a.djh 单据号,rq 盘点日期  from yf_pd a,yf_pdmx b,yp_ypcjd c
	  where a.id=b.djid and b.cjid=c.cjid and a.djrq>=@rq1 and a.djrq<=@rq2   and pcs-zcs<>0 and a.deptid in(select deptid from #deptid) 
	else
		begin
			if @pdfs = '1'
				begin
				  select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,ypph 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
				  pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,pclsje-zclsje 盈亏金额,
				  jhj 进价,cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) 进货金额盈亏,shh 货号,a.djh 单据号,rq 盘点日期  from yf_pd a,yf_pdmx b,yp_ypcjd c
				 where a.id=b.djid and b.cjid=c.cjid and a.djrq>=@rq1 and a.djrq<=@rq2   and pcs-zcs<>0 and a.deptid in(select deptid from #deptid) 
				 print '1'
				end
			else
				begin
				  select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,'' 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
				  pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,
				  pclsje-zclsje 盈亏金额,
				  cast(0 as decimal(15,2)) 进价,cast(0 as decimal(15,2)) 进货金额盈亏,shh 货号,a.djh 单据号,
				  rq 盘点日期  from yf_pd a,YF_PDMX_KCMX b,yp_ypcjd c
				 where a.id=b.djid and b.cjid=c.cjid and a.djrq>=@rq1 and a.djrq<=@rq2   and pcs-zcs<>0 and a.deptid in(select deptid from #deptid) 
				 
				 
				 --  select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,'' 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
				 -- pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,
				 -- pclsje-zclsje 盈亏金额,
				 -- cast(0 as decimal(15,2)) 进价,cast(0 as decimal(15,2)) 进货金额盈亏,shh 货号,a.djh 单据号,
				 -- rq 盘点日期  from yf_pd a,YF_PDMX_KCMX b,yp_ypcjd c
				 --where a.id=b.djid and b.cjid=c.cjid and a.djrq>=@rq1 and a.djrq<=@rq2   and pcs-zcs<>0 and a.deptid in(select deptid from #deptid) 
				 
				 
				 print '2'
				 end
			end	 
end
else
begin
	if @bpcgl=0
		begin
			  select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,ypph 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
			  pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,pclsje-zclsje 盈亏金额,jhj 进价,cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) 进货金额盈亏,shh 货号,a.djh  单据号,rq 盘点日期  from yf_pd a,yf_pdmx b,yp_ypcjd c
			  where a.id=b.djid and b.cjid=c.cjid  and pcs-zcs<>0 and djh 
			  in(select djh from vi_yk_dj where deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid) and ywlx='008')
			  and   a.deptid in(select deptid from #deptid)
			  
			
		end
	else
		begin
			if @pdfs='1'
			begin
				 select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,ypph 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
				  pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,pclsje-zclsje 盈亏金额,
				  jhj 进价,
				  cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) 进货金额盈亏,shh 货号,a.djh  单据号,rq 盘点日期  from yf_pd a,yf_pdmx b,yp_ypcjd c
				  where a.id=b.djid and b.cjid=c.cjid  and pcs-zcs<>0 and djh 
				  in(select djh from vi_yk_dj where deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid) and ywlx='008')
				  and   a.deptid in(select deptid from #deptid)
				    print '3'
			end
			 else
			 begin
				 select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,'' 批号,
				  b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
				  pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,
				  pclsje-zclsje 盈亏金额,
				  cast(0 as decimal(15,2)) 进价,cast(0 as decimal(15,2)) 进货金额盈亏,
				  shh 货号,a.djh  单据号,rq 盘点日期  from yf_pd a,YF_PDMX_KCMX b,yp_ypcjd c
				  where a.id=b.djid and b.cjid=c.cjid  and pcs-zcs<>0 and djh 
				  in(select djh from vi_yk_dj where deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid) and ywlx='008')
				  and   a.deptid in(select deptid from #deptid)
				  
				  
				    print '4'
			end
		end
end 

