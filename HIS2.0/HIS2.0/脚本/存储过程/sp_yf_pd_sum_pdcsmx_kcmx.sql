 --exec sp_yf_pd_sum_pdcsmx_kcmx @deptid=214
 IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_pd_sum_pdcsmx_kcmx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_pd_sum_pdcsmx_kcmx
GO
CREATE PROCEDURE sp_yf_pd_sum_pdcsmx_kcmx
(
 	@deptid int
)
as

create table #temp(cjid int,kcid UNIQUEIDENTIFIER, pcsl decimal(15,3), pxxh int)

--汇总盘存数,并获得排序序号
insert into #temp(cjid,kcid,pcsl,pxxh)
select 
x.cjid,
x.kcid,
cast(sum(pcsl*coalesce(x.ydwbl,1)/ydwbl) as float) pcsl,
(select top 1 a.djh+pxxh from yf_pdcs a,YF_PDCSMX_KCMX b where a.id=b.djid and 
shbz=0 and bdelete=0 and b.kcid=x.kcid order by djrq,pxxh )  as pxxh
FROM YF_PDCSMX_KCMX x inner join yf_pdcs y on x.djid=y.id
left join yf_pdtemp z on x.kcid=z.kcid AND z.shbz=0 and z.deptid=@deptid 
where x.deptid=@deptid and y.shbz=0 and y.bdelete=0 
 group by x.cjid,x.kcid 


--结果集
select CAST(0 AS CHAR(12)) 序号,B.s_yppm 品名,b.s_ypspm 商品名,b.s_ypgg 规格,s_sccj 厂家,
cast(round(b.pfj/coalesce(c.dwbl,1),4) as decimal(15,4)) 批发价,
cast(round(b.pfj*coalesce(c.kcl,0)/coalesce(c.dwbl,1),2) as decimal(15,2)) 批发金额,
 cast(round(b.lsj/coalesce(c.dwbl,1),4) as decimal(15,4)) 零售价,
 '' 批号,'' 库位,
 cast(coalesce(c.kcl,0) as float) 帐面数量,
 cast(round(b.lsj*coalesce(c.kcl,0)/coalesce(c.dwbl,1),2) as decimal(15,2)) 帐面金额,
 pcsl 盘存数量, 
 coalesce(dbo.fun_yp_ypdw(coalesce(zxdw,0)),b.s_ypdw) 单位, 
 cast(round(b.lsj*cast(a.pcsl as decimal(15,3))/coalesce(c.dwbl,1),2) as decimal(15,2)) 盘存金额,
 (a.pcsl-coalesce(c.kcl,0)) 盈亏数量,
cast(round(b.lsj*(a.pcsl-coalesce(c.kcl,0))/coalesce(c.dwbl,1),2) as decimal(15,2)) 盈亏金额,
0 进价,
0 进货金额,
b.shh 货号, a.cjid,a.kcid,coalesce(c.dwbl,1) dwbl,0 kwid,dbo.FUN_GETEMPTYGUID() id 
 from 
 #temp A inner join YP_YPCJD B on a.cjid=b.cjid 
left join  yf_pdtemp_kcmx  C on a.kcid=c.kcid  and c.deptid=@deptid  and c.shbz=0 --and c.bdelete=0
left join yp_hwsz d on b.ggid=d.ggid and d.deptid=@deptid order by pxxh



