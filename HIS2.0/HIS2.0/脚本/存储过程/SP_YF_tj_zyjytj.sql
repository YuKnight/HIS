IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_tj_zyjytj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_tj_zyjytj
GO
CREATE PROCEDURE SP_YF_tj_zyjytj
 ( 
   @dtp1 varchar(30),
   @dtp2 varchar(30),
   @deptid int,
   @cjid int,
   @type int 
 )  
as
BEGIN
 declare @count INT 
 DECLARE @stmt varchar(6000); --定义SQL文本

 --声明临时表
CREATE TABLE #YP
   (
	  dept_ly int,
	  cjid int,
	  ypsl decimal(15,2),
	  lsje decimal(15,2) 
   ) 
   
begin



set @stmt='insert into #YP(dept_ly,cjid,ypsl,lsje)'+
'select dept_ly,cjid,(num*dosage)/unitrate,acvalue from zy_fee_speci'+
' where fy_date>='''+@dtp1+' 00:00:00'' and fy_date<='''+@dtp2+' 23:59:59'' and fy_bit=1 and py_user=-999'
if @cjid>0 
  set @stmt=@stmt+' and cjid='+cast(@cjid as varchar(10))
exec (@stmt)

set @stmt=@stmt+'insert into #YP(dept_ly,cjid,ypsl,lsje) select dept_ly,cjid,(num*dosage)/unitrate,acvalue from zy_fee_speci_h'+
' where fy_date>='''+@dtp1+' 00:00:00'' and fy_date<='''+@dtp2+' 23:59:59'' and fy_bit=1 and py_user=-999'
if @cjid>0 
  set @stmt=@stmt+' and cjid='+cast(@cjid as varchar(10))

exec (@stmt)



if @type=0
	select 0 序号,dbo.fun_getdeptname(dept_ly) 病区,shh 货号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,cast(sum(ypsl) as float) 数量,s_ypdw 单位,sum(lsje) 金额  from #YP a,
	yp_ypcjd b where a.cjid=b.cjid 
	group by dept_ly,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,s_ypdw order by dept_ly
else
	select 0 序号,dbo.fun_getdeptname(dept_ly) 病区,0 单据张数,sum(lsje) 金额  from #YP a,
	yp_ypcjd b where a.cjid=b.cjid 
	group by dept_ly
end 

END;
