IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TJ_PDHZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TJ_PDHZ
GO
CREATE PROCEDURE SP_YF_TJ_PDHZ
 ( 
   @deptid int,
   @RQ1 datetime, 
   @RQ2 datetime,
   @yplx int,
   @year int,
   @month int
 )
as 

declare @bpcgl int =0 --是否进行批次管理
select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--暂时设定为999

declare @pdfs varchar(10) ='1'  --启用批次管理时盘点方式 0-盘明细 1-盘批次
select @pdfs=CONFIG from JC_CONFIG where ID=8052 


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
	if @bpcgl=0 --不进行批次管理
		begin
		  select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,ypph 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
		  pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,jhj 进价,cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) 进货金额盈亏,pclsje-zclsje 盈亏金额,shh 货号,a.djh 单据号,rq 盘点日期  
		  from yf_pd a,
		  yf_pdmx b,
		  yp_ypcjd c
		  where a.id=b.djid and b.cjid=c.cjid and a.djrq>=@rq1 and a.djrq<=@rq2  and a.deptid=@deptid and pcs-zcs<>0
		end
	else        --进行批次管理
		begin
			if @pdfs=1  --盘批次库存
				begin
					   select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,ypph 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
						pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,jhj 进价,cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) 进货金额盈亏,pclsje-zclsje 盈亏金额,shh 货号,a.djh 单据号,rq 盘点日期  
						from yf_pd a,
						yf_pdmx b,
						yp_ypcjd c
						 where a.id=b.djid and b.cjid=c.cjid and a.djrq>=@rq1 and a.djrq<=@rq2  and a.deptid=@deptid and pcs-zcs<>0
				end
			else		--盘明细库存
				begin
						  select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,'' 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
						 pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,
						 CAST(0 as decimal(15,3)) 进价,cast(0 as decimal(15,2)) 进货金额盈亏,
						 pclsje-zclsje 盈亏金额,shh 货号,a.djh 单据号,rq 盘点日期  
						 from yf_pd a,
						 yf_pdmx b,
						 yp_ypcjd c
						 where a.id=b.djid and b.cjid=c.cjid and a.djrq>=@rq1 and a.djrq<=@rq2  and a.deptid=@deptid and pcs-zcs<>0
				end
		end
end
else
begin
	if @bpcgl =0	--不进行批次管理
		begin
			  select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,ypph 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
			  pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,pclsje-zclsje 盈亏金额,jhj 进价,cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) 进货金额盈亏,shh 货号,a.djh  单据号,rq 盘点日期  
			  from yf_pd a,
			  yf_pdmx b,
			  yp_ypcjd c
			  where a.id=b.djid and b.cjid=c.cjid and a.deptid=@deptid and pcs-zcs<>0 and djh 
			  in(select djh from vi_yf_dj where isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid and ywlx='008')
		end
	else			--进行批次管理
		begin
			if @pdfs=0	--盘批次库存
				begin
					 select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,ypph 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
					  pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,pclsje-zclsje 盈亏金额,jhj 进价,cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) 进货金额盈亏,shh 货号,a.djh  单据号,rq 盘点日期  
					  from yf_pd a,
					  yf_pdmx b,
					  yp_ypcjd c
					  where a.id=b.djid and b.cjid=c.cjid and a.deptid=@deptid and pcs-zcs<>0 and djh 
					  in(select djh from vi_yf_dj where isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid and ywlx='008')
				end
			else	   --盘明细库存
				begin
					 select  '0' 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,'' 批号,b.pfj 批发价,b.lsj 零售价,zcs 帐存数量,zclsje 帐存金额,
					  pcs 盘存数量,ypdw 单位,pclsje 盘存金额,pcs-zcs 盈亏数量,pclsje-zclsje 盈亏金额,
					  CAST(0 as decimal(15,3)) 进价,cast(0 as decimal(15,2)) 进货金额盈亏,
					  shh 货号,a.djh  单据号,rq 盘点日期
					    from yf_pd a,
					    YF_PDMX_KCMX b,
					    yp_ypcjd c
					  where a.id=b.djid and b.cjid=c.cjid and a.deptid=@deptid and pcs-zcs<>0 and djh 
					  in(select djh from vi_yf_dj where isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid and ywlx='008')
				end
		end
end 

