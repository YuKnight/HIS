IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yk_select_FKDJCX' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yk_select_FKDJCX
GO
CREATE PROCEDURE sp_yk_select_FKDJCX --付款未付款单据查询    
(    
 @fkzt int,    
 @wldw int ,    
 @fph varchar(50),    
 @shdh varchar(50),    
 @djh bigint,    
 @dtpfprq1 varchar(30),    
 @dtpfprq2 varchar(30),    
 @dtpdjsj1 varchar(30),    
 @dtpdjsj2 varchar(30),    
 @deptid int ,    
 @ywy int,    
    @deptid_ck int,    
    @bmx smallint, --是否统计明细    
 @cjid int,    
    @dtpfkrq1 varchar(30),    
    @dtpfkrq2 varchar(30)    
)     
as    
    
 declare @ssql varchar(8000)    
 declare @table varchar(30)    
 declare @table_mx varchar(30)    
 declare @kslx varchar(4)    
 select top 1 @kslx=kslx from yp_yjks where (deptid=@deptid or deptid in(select deptid from yp_yjks_gx where p_deptid=@deptid))    
if @kslx='药库'     
begin    
 set @table='vi_yk_dj '    
 set @table_mx='vi_yk_djmx'    
end    
else    
begin    
 set @table ='vi_yf_dj'    
    set @table_mx='vi_yf_djmx'    
end    
    
if @bmx=0    
  set @ssql=' select 0 序号,dbo.fun_getdeptname(deptid) 仓库名称,CAST(FKZT AS SMALLINT) 付款,djh 单据号 ,RQ 单据日期,    
  (case when ywlx=''001'' then ''入库'' else ''退货'' end) 单据类别,    
  (case when ywlx=''001'' then sumjhje else (-1)*sumjhje end) 进货金额,    
  fph 发票号,fprq 发票日期,dbo.FUN_YP_GHDW(wldw) 供货单位,dbo.FUN_YP_YWY(jsr) 业务员,shdh 送货单号,fkrq 付款日期,    
  cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(djy) 登记员,id from '+@table+'  a    
  where (ywlx=''001'' or ywlx=''002'')'     
--if @bmx=1    
--  set @ssql=' select 0 序号,dbo.fun_getdeptname(a.deptid) 仓库名称,a.djh 单据号 ,ypspm 商品名,yppm 品名,    
--ypgg 规格,sccj 厂家,cast(jhj as float) 进价,cast(ypsl as float) 数量,ypdw 单位,RQ 单据日期,    
--  (case when a.ywlx=''001'' then ''入库'' else ''退货'' end) 单据类别,    
--  (case when a.ywlx=''001'' then sumjhje else (-1)*sumjhje end) 进货金额,    
--  fph 发票号,fprq 发票日期,dbo.FUN_YP_GHDW(wldw) 供货单位,dbo.FUN_YP_YWY(jsr) 业务员,a.shdh 送货单号,fkrq 付款日期,    
--  cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(djy) 登记员     
-- from '+@table+'  a ,'+@table_mx+' b    
--  where a.id=b.djid and (a.ywlx=''001'' or a.ywlx=''002'')'    
    
  if @bmx=1    
  set @ssql=' select 0 序号,dbo.fun_getdeptname(a.deptid) 仓库名称,a.djh 单据号 ,ypspm 商品名,yppm 品名,    
ypgg 规格,sccj 厂家,cast(jhj as float) 进价,cast(ypsl as float) 数量,ypdw 单位,RQ 单据日期,    
  (case when a.ywlx=''001'' then ''入库'' else ''退货'' end) 单据类别,    
    (case when a.ywlx=''001'' then cast(jhj*ypsl as float) else cast((-1)*jhj*ypsl as float) end) 进货金额,   
  fph 发票号,fprq 发票日期,dbo.FUN_YP_GHDW(wldw) 供货单位,dbo.FUN_YP_YWY(jsr) 业务员,a.shdh 送货单号,fkrq 付款日期,    
  cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as 登记时间,dbo.Fun_getempname(djy) 登记员     
 from '+@table+'  a ,'+@table_mx+' b    
  where a.id=b.djid and (a.ywlx=''001'' or a.ywlx=''002'')'    
if @bmx=2    
  set @ssql=' select dbo.FUN_YP_GHDW(wldw) 供货单位,sum(dbo.fun_yk_drt(a.ywlx,jhje)) 进货金额 ,wldw as ghdwid    
 from '+@table+'  a ,'+@table_mx+' b    
  where a.id=b.djid and (a.ywlx=''001'' or a.ywlx=''002'')'     
    
 if @deptid_ck>0    
   set @ssql=@ssql+' and a.deptid='+cast(@deptid_ck as char(10))     
 else    
   set @ssql=@ssql+' and a.deptid in( select deptid from yp_yjks_gx where (p_deptid='+cast(@deptid as varchar(20))+' or deptid='+cast(@deptid as varchar(20))+' ) ) '    
    
    
 if @FKZT<>2     
begin    
     set @ssql=@ssql+' and FKZT='+cast(@FKZT as char(10))     
 end     
    
 if @wldw>0     
begin    
     set @ssql=@ssql+' and wldw='+cast(@wldw as char(10))     
 end     
     
 if @dtpdjsj1<>''     
begin    
     set @ssql=@ssql+' and djrq>='''+ @dtpdjsj1 +''' and  djrq<='''+@dtpdjsj2+''''      
 end     
     
 if @dtpfprq1<>''     
begin    
     set @ssql=@ssql+' and fprq>='''+ @dtpfprq1 +''' and  fprq<='''+@dtpfprq2+''''      
 end     
    
 if @dtpfkrq1<>''     
begin    
     set @ssql=@ssql+' and fkzt=1 and fkrq>='''+ @dtpfkrq1 +' 00:00:00'' and  fkrq<='''+@dtpfkrq2+' 23:59:59'''      
 end     
     
  if @djh<>0     
begin    
     set @ssql=@ssql+' and a.djh='+ cast(@djh as char(50))     
 end     
     
  if @fph<>''   
begin    
     set @ssql=@ssql+' and a.fph='''+ cast(@fph as varchar(50))+''''     
 end     
     
  if @shdh<>''     
begin    
     set @ssql=@ssql+' and a.shdh='''+ cast(@shdh as varchar(50))+''''     
 end     
     
  if @ywy>0    
begin    
     set @ssql=@ssql+' and jsr='''+ cast(@ywy as varchar(50))+''''     
 end     
    
if @cjid>0    
begin    
 set @ssql=@ssql+' and a.id in(select djid from '+@table_mx+' where cjid='+cast(@cjid as varchar(30))+') '    
end    
    
if @bmx=2    
  set @ssql=@ssql+' group by wldw '    
if @bmx<>2     
  set @ssql=@ssql+' order by a.djh'    
exec(@ssql)    
    
    
    
     


 
 
 