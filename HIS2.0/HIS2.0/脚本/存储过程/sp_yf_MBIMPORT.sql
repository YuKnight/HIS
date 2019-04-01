IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_MBIMPORT' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_MBIMPORT
GO
CREATE PROCEDURE sp_yf_MBIMPORT
(
  @mbid int,
  @deptid int,
  @bpcgl bit, --是否进行批次管理
  @pcfs varchar(10) --盘存方式  0-盘明细库存 1-盘批次库存 
)
as

 --基本的SQL语名
declare @kslx varchar(10)
set @kslx=(select kslx from yp_yjks where deptid=@deptid)
if @kslx is null or rtrim(@kslx)=''  
 return
--8030当一个药品在多个盘点模板中存在时,A模板保存后录入数据后,B模板仍能提取数据 1是 0否
if EXISTS(select * from jc_config where id=8030 and config='0')
	begin
		if ( @bpcgl=0 or (@pcfs='1' and @bpcgl='1')) --不进行批次管理 或者进行批次管理且盘批次库存
			begin
				select a.id 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,
 			  coalesce(cast(round(pfj/coalesce(c.dwbl,1),4) as decimal(15,4)),pfj) 批发价,
			  0.00 批发金额,
			  coalesce(cast(round(c.jhj/coalesce(c.dwbl,1),4) as decimal(15,4)),0) 进价,
			  coalesce(cast(round(lsj/coalesce(c.dwbl,1),4) as decimal(15,4)),lsj) 零售价,
			  coalesce(c.ypph,'无批号') 批号,
			  coalesce(dbo.fun_yp_kwmc(kwid,c.DEPTID),'') 库位,
			  coalesce(c.kcl,0) 帐面数量,
			  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) 帐面金额,coalesce(c.kcl,0) 盘存数量,
			  coalesce(dbo.fun_yp_ypdw(c.ZXDW),s_ypdw) 单位,
			  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) 盘存金额,
			  0.00 盈亏数量,0.00 盈亏金额,shh 货号,b.cjid,
			  isnull(c.kcid,dbo.FUN_GETEMPTYGUID())  as kcid,
			  coalesce(coalesce(c.dwbl,1),1) dwbl,
			  coalesce(c.kwid,0) kwid,
			  dbo.FUN_GETEMPTYGUID() id,a.bz 描述 
			  ,YPXQ 效期,YPPCH 批次号    
			  from yp_pdmbmx a inner join yp_ypcjd b 
			  on a.cjid=b.cjid and mbid=@mbid left join 
			 (select * from yf_pdtemp where deptid=@deptid and shbz=0 and  (bdelete=0 or (bdelete=1 and kcl<>0) ) ) c 
			  on a.deptid=c.deptid and a.cjid=c.cjid    --left join (select * from yp_ypcl where deptid=@deptid) d
			 --on a.cjid=d.cjid
			  where  a.mbid=@mbid and c.kcid not in(
				select kcid from yf_pdcs a,yf_pdcsmx b where a.id=b.djid and  a.bdelete=0 and shbz=0
				   )   order by a.id,b.cjid,c.ypph
			end
		else --盘明细库存
			begin
				select a.id 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,
 			  coalesce(cast(round(pfj/coalesce(c.dwbl,1),4) as decimal(15,4)),pfj) 批发价,
			  0.00 批发金额,
			  0 进价,
			  coalesce(cast(round(lsj/coalesce(c.dwbl,1),4) as decimal(15,4)),lsj) 零售价,
			  null 批号,
			  '' 库位,
			  coalesce(c.kcl,0) 帐面数量,
			  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) 帐面金额,coalesce(c.kcl,0) 盘存数量,
			  coalesce(dbo.fun_yp_ypdw(c.ZXDW),s_ypdw) 单位,
			  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) 盘存金额,
			  0.00 盈亏数量,0.00 盈亏金额,shh 货号,b.cjid,
			  isnull(c.kcid,dbo.FUN_GETEMPTYGUID())  as kcid,
			  coalesce(coalesce(c.dwbl,1),1) dwbl,
			  0 kwid,
			  dbo.FUN_GETEMPTYGUID() id,a.bz 描述 from yp_pdmbmx a inner join yp_ypcjd b 
			  on a.cjid=b.cjid and mbid=@mbid left join 
			 (select * from YF_PDTEMP_KCMX where deptid=@deptid and shbz=0 and  (bdelete=0 or (bdelete=1 and kcl<>0) ) ) c 
			  on a.deptid=c.deptid and a.cjid=c.cjid    --left join (select * from yp_ypcl where deptid=@deptid) d
			 --on a.cjid=d.cjid
			  where  a.mbid=@mbid and c.kcid not in(
				select kcid from yf_pdcs a,YF_PDCSMX_KCMX b where a.id=b.djid and  a.bdelete=0 and shbz=0
				   )   order by a.id,b.cjid
			end
	end
else
	begin
		if ( @bpcgl=0 or (@pcfs='1' and @bpcgl='1')) --不进行批次管理 或者进行批次管理且盘批次库存
				begin
					 select a.id 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,
 					  coalesce(cast(round(pfj/coalesce(c.dwbl,1),4) as decimal(15,4)),pfj) 批发价,
					  0.00 批发金额,
					  coalesce(cast(round(c.jhj/coalesce(c.dwbl,1),4) as decimal(15,4)),0) 进价,
					  coalesce(cast(round(lsj/coalesce(c.dwbl,1),4) as decimal(15,4)),lsj) 零售价,
					  coalesce(c.ypph,'无批号') 批号,
					  coalesce(dbo.fun_yp_kwmc(kwid,c.DEPTID),'') 库位,
					  coalesce(c.kcl,0) 帐面数量,
					  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) 帐面金额,coalesce(c.kcl,0) 盘存数量,
					  coalesce(dbo.fun_yp_ypdw(c.ZXDW),s_ypdw) 单位,
					  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) 盘存金额,
					  0.00 盈亏数量,0.00 盈亏金额,shh 货号,b.cjid,
					  isnull(c.kcid,dbo.FUN_GETEMPTYGUID())  as kcid,
					  coalesce(coalesce(c.dwbl,1),1) dwbl,
					  coalesce(c.kwid,0) kwid,
					  dbo.FUN_GETEMPTYGUID() id,a.bz 描述
					  ,YPXQ,YPPCH   from yp_pdmbmx a inner join yp_ypcjd b 
					 on a.cjid=b.cjid and mbid=@mbid left join 
					 (select * from yf_pdtemp where deptid=@deptid and shbz=0 and  (bdelete=0 or (bdelete=1 and kcl<>0) ) ) c 
					on a.deptid=c.deptid and a.cjid=c.cjid    --left join (select * from yp_ypcl where deptid=@deptid) d
					--on a.cjid=d.cjid
					 where  a.mbid=@mbid  order by a.id,b.cjid,c.ypph
				 end 
		 else
				begin
					 select a.id 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,
 					  coalesce(cast(round(pfj/coalesce(c.dwbl,1),4) as decimal(15,4)),pfj) 批发价,
					  0.00 批发金额,
					  0 进价,
					  coalesce(cast(round(lsj/coalesce(c.dwbl,1),4) as decimal(15,4)),lsj) 零售价,
					  null 批号,
					  '' 库位,
					  coalesce(c.kcl,0) 帐面数量,
					  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) 帐面金额,coalesce(c.kcl,0) 盘存数量,
					  coalesce(dbo.fun_yp_ypdw(c.ZXDW),s_ypdw) 单位,
					  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) 盘存金额,
					  0.00 盈亏数量,0.00 盈亏金额,shh 货号,b.cjid,
					  isnull(c.kcid,dbo.FUN_GETEMPTYGUID())  as kcid,
					  coalesce(coalesce(c.dwbl,1),1) dwbl,
					  0 kwid,
					  dbo.FUN_GETEMPTYGUID() id,a.bz 描述
					  ,YPXQ,YPPCH   from yp_pdmbmx a inner join yp_ypcjd b 
					 on a.cjid=b.cjid and mbid=@mbid left join 
					 (select * from yf_pdtemp where deptid=@deptid and shbz=0 and  (bdelete=0 or (bdelete=1 and kcl<>0) ) ) c 
					on a.deptid=c.deptid and a.cjid=c.cjid    --left join (select * from yp_ypcl where deptid=@deptid) d
					--on a.cjid=d.cjid
					 where  a.mbid=@mbid  order by a.id,b.cjid,c.ypph
				end
	 end





