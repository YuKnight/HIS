

IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_tj_ypxhtj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_tj_ypxhtj
GO
CREATE PROCEDURE SP_YF_tj_ypxhtj  
 ( @type int,   
   @dtp1 varchar(30),  
   @dtp2 varchar(30),  
   @deptid int,  
   @cjid int,  
   @mbid int,
   @bk int  
 )    
as  
-- exec SP_YF_tj_ypxhtj 0,'2001-01-01 00:00:00','2012-08-01 23:59:59',0,0,3  
BEGIN  
 declare @count INT   
 DECLARE @stmt varchar(6000); --定义SQL文本  
 DECLARE @WHERE VARCHAR(100)  

declare @table_fy varchar(50)
declare @table_fymx varchar(50)
declare @table_tld varchar(50)
declare @table_tldmx varchar(50)
set @table_fy='yf_fy '
set @table_fymx='yf_fymx '
set @table_tld='yf_tld '
set @table_tldmx='yf_tldmx '
if @bk=1
begin
set @table_fy='yf_fy_h '
set @table_fymx='yf_fymx_h '
set @table_tld='yf_tld_h '
set @table_tldmx='yf_tldmx_h '
end 
if @bk=2
begin
set @table_fy='vi_yf_fy '
set @table_fymx='vi_yf_fymx '
set @table_tld='vi_yf_tld '
set @table_tldmx='vi_yf_tldmx '
end 

 --声明临时表  
CREATE TABLE #YP  
   (  
   yplx int,  
   s_ypjx varchar(50),  
   cjid int,  
   shh varchar(20),  
   s_yppm varchar(100),  
   s_ypspm varchar(100),  
   s_ypgg varchar(100),  
   s_sccj varchar(100),  
   ypsl decimal(15,3),  
   s_ypdw varchar(10),  
   pfje decimal(15,2),  
   lsje decimal(15,2),
   cglsh varchar(100)   
   )   
  
CREATE TABLE #kc  
   (  
   cjid int,  
   kcl decimal(15,3),  
   kcpfje decimal(15,2) ,  
   kclsje decimal(15,2)   
   )   
begin  
  
SET @WHERE=''  
IF @TYPE=1   
 SET @WHERE=' AND JZCFBZ=0 '  
IF @TYPE=2  
 SET @WHERE=' AND JZCFBZ=1 '  
  
--门诊或全部  
 set @stmt='insert into #YP(cglsh,yplx,s_ypjx,cjid,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,ypsl,s_ypdw,pfje,lsje)'+  
      'select cglsh,n_yplx,s_ypjx,a.cjid,shh 货号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,cast(ypsl as float) 数量,s_ypdw 单位,pfje,lsje 金额  from ('+  
    ' select cjid,sum(ypsl*b.cfts/ydwbl) ypsl,sum(pfje) pfje,sum(lsje) lsje
	 from '+@table_fy+' a(nolock),'+@table_fymx+' b(nolock) where  a.id=b.fyid and '+  
    '  fyrq>='''+@dtp1+''' and fyrq<='''+@dtp2+''''+@WHERE;  
 if @deptid>0  
 set @stmt=@stmt+' and a.deptid='+cast(@deptid as char(10));  
 if @cjid>0   
         set @stmt=@stmt+' and cjid='+cast(@cjid as varchar(10))  
 if @mbid>0
		 set @stmt=@stmt+' and cjid in(select cjid from yp_yptjmbmx where mbid='+cast(@mbid as varchar(30))+') '
 set @stmt=rtrim(@stmt)+' group by cjid) a,yp_ypcjd b where a.cjid=b.cjid ';  
 exec(@stmt)  
  print @stmt  
  
--住院或全部  
if @type=0 or @type=2  
begin  
  set @stmt=' insert into #YP(cglsh,yplx,s_ypjx,CJID,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,ypsl,s_ypdw,pfje,lsje)'+  
       'select cglsh,n_yplx,s_ypjx,a.CJID,shh 货号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,cast(ypsl as float) 数量,s_ypdw 单位,pfje,lsje 金额    
    from (select cjid,sum(ypsl/ydwbl) ypsl,sum(pfje) pfje,sum(lsje) lsje 
  from '+@table_tld+' a(nolock),'+@table_tldmx+' b(nolock)  '+  
       'where a.groupid=b.groupid  and fyrq>='''+@dtp1+''' and fyrq<='''+@dtp2+''''  
  if @cjid>0   
        set @stmt=@stmt+' and cjid='+cast(@cjid as varchar(10))  
  if @deptid>0  
		set @stmt=@stmt+' and deptid='+cast(@deptid as char(10));  
  if @mbid>0
		set @stmt=@stmt+' and cjid in(select cjid from yp_yptjmbmx where mbid='+cast(@mbid as varchar(30))+') '

  set @stmt=@stmt+' group by cjid) a,yp_ypcjd b where a.cjid=b.cjid ';  
  exec(@stmt)  
  PRINT @STMT  
    
end   
  
--库存  
insert into #kc(cjid,kcl,kcpfje,kclsje)  
select a.cjid,sum(round(kcl/dwbl,3)),sum(round(kcl/dwbl,3)*pfj),  
sum(round(kcl/dwbl,3)*lsj) from 
(select kcl,dwbl,cjid,deptid from yf_kcmx union all 
select kcl,dwbl,cjid,deptid from yk_kcmx) a,yp_ypcjd b   
where a.cjid=b.cjid and ( (@deptid>0 and deptid=@deptid) or @deptid=0)   group by  a.cjid  
  
  
if @mbid=0
select '' 序号,a.shh 货号,cglsh 采购流水号,rtrim(s_yppm) 品名,rtrim(s_ypspm) 商品名,rtrim(s_ypgg) 规格,rtrim(s_sccj) 厂家,cast(sum(ypsl) as float) 数量,  
rtrim(s_ypdw) 单位,sum(pfje) 批发金额,sum(lsje) 零售金额,sum(lsje)-sum(pfje) 批零差额,  
kcl 当前库存,kcpfje 库存批发金额,kclsje 库存零售金额,dbo.fun_yp_yplx(yplx) 药品类型,rtrim(s_ypjx) 剂型  
 from #YP a inner join #kc b on a.cjid=b.cjid   
 group by shh,s_yppm,s_ypspm,s_ypgg,s_sccj,s_ypdw,kcl,kcpfje,kclsje,yplx,s_ypjx,cglsh
  order by yplx,s_ypjx,s_yppm  
else
select '' 序号,a.shh 货号,cglsh 采购流水号,rtrim(s_yppm) 品名,rtrim(s_ypspm) 商品名,rtrim(s_ypgg) 规格,rtrim(s_sccj) 厂家,cast(sum(ypsl) as float) 数量,  
rtrim(s_ypdw) 单位,sum(pfje) 批发金额,sum(lsje) 零售金额,sum(lsje)-sum(pfje) 批零差额,  
kcl 当前库存,kcpfje 库存批发金额,kclsje 库存零售金额,dbo.fun_yp_yplx(yplx) 药品类型,rtrim(s_ypjx) 剂型 
 from #YP a inner join #kc b on a.cjid=b.cjid  left join yp_yptjmbmx c on a.cjid=c.cjid and mbid=@mbid
 group by shh,s_yppm,s_ypspm,s_ypgg,s_sccj,s_ypdw,kcl,kcpfje,kclsje,yplx,s_ypjx,c.id,cglsh
order by c.id 

  
  
  
  
end   
  
END;  
