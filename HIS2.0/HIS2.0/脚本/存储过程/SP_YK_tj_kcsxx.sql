IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_tj_kcsxx' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_tj_kcsxx
GO
CREATE PROCEDURE SP_YK_tj_kcsxx
 (@type int, --1 高于上限 0低于下限
  @yplx INTEGER,--药品类型 
  @deptid int
 )  
as
BEGIN
declare @count INT 
declare @ss varchar(5000)

if @type=1
select 0 序号,yppm 品名,ypgg 规格,s_sccj 厂家,pfj 批发价,lsj 零售价,
 cast(kcxx*(dwbl/ydwbl) as decimal(10,3)) 下限,kcl 库存量,
((cast(kcxx*(dwbl/ydwbl) as decimal(10,3)))-kcl) 低于下限,dbo.fun_yp_ypdw(zxdw) 单位,shh 货号,a.cjid 
 from yp_kcsxx a,yk_kcmx b ,vi_yp_ypcd c
where a.cjid=b.cjid and a.deptid=b.deptid 
and b.cjid=c.cjid and b.deptid=@deptid and b.bdelete=0 and
 ((cast(kcxx*(dwbl/ydwbl) as decimal(10,3)))-kcl)> 0 and ((@yplx>0 and yplx=@yplx) or (@yplx=0) )

else
select 0 序号,yppm 品名,ypgg 规格,s_sccj 厂家,pfj 批发价,lsj 零售价,
 cast(kcsx*(dwbl/ydwbl) as decimal(10,3)) 上限,kcl 库存量,
(kcl-(cast(kcsx*(dwbl/ydwbl) as decimal(10,3)))) 高于上限,dbo.fun_yp_ypdw(zxdw) 单位,shh 货号,a.cjid 
from yp_kcsxx a,yk_kcmx b ,vi_yp_ypcd c
where a.cjid=b.cjid and a.deptid=b.deptid and b.cjid=c.cjid and
 b.deptid=@deptid and b.bdelete=0 and (kcl-(cast(kcsx*(dwbl/ydwbl) as decimal(10,3))))>0 
and ((@yplx>0 and yplx=@yplx) or (@yplx=0) )
				

end


 

 