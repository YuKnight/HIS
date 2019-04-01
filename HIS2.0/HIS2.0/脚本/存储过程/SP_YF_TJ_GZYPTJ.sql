IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TJ_GZYPTJ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TJ_GZYPTJ
GO
CREATE PROCEDURE SP_YF_TJ_GZYPTJ
 ( 
   @deptid int,
   @RQ1 varchar(30), 
   @RQ2 varchar(30),
   @yplx int,
   @type int
 )
as 
 DECLARE @stmt varchar(1000); --定义SQL文本

  create TABLE #temp
   (
      ID INTEGER not null IDENTITY (1,1),
	  cjid int,
      sk int,
   	  rksl decimal(15,1),
   	  cksl decimal(15,1)
   ) 


begin
  set @stmt='insert into #temp(cjid,cksl,sk,rksl)
 			 select b.cjid,sum(case when b.ywlx in(''003'',''014'',''019'',''017'',''018'',''020'',''021'',''022'',''023'',''025'',''026'') then dbo.FUN_Yf_DRT(b.ywlx,ypsl/ydwbl) else 0 end) cksl,0,
		 sum(case when b.ywlx in(''001'',''002'',''015'',''016'',''019'',''024'',''004'',''009'') then dbo.FUN_Yf_DRT(b.ywlx,ypsl/ydwbl) else 0 end) rksl 
  		 from vi_yf_dj A(nolock),vi_yf_djmx b(nolock),vi_yp_ypcd c(nolock) 
  		where a.id=b.djid and  b.cjid=c.cjid and shrq>='''+@rq1+''' and shrq<='''+@rq2+''' and shbz=1 and 
 		 b.ywlx in(select ywlx from yf_ywlx where ywzt=1)  '
   if @type=0 
     set @stmt=@stmt+' and gzyp=1 '
    if @type=1
     set @stmt=@stmt+' and  mzyp=1 '
    if @type=2
     set @stmt=@stmt+' and  djyp=1 '
    if @type=3
     set @stmt=@stmt+' and  psyp=1 '
    if @type=4
     set @stmt=@stmt+' and  jsyp=1 '
    if @type=5
     set @stmt=@stmt+' and  wyyp=1 '
    if @type=6
     set @stmt=@stmt+' and  cfyp=1 '
    if @type=7
     set @stmt=@stmt+' and  rsyp=1 '
    if @type=8
     set @stmt=@stmt+' and  gjjbyw=1 '
    if @type=9
     set @stmt=@stmt+' and  kssdjid>0 '
	if @type=10--全部
	 set @stmt=@stmt+' and (gzyp=1 or mzyp=1 or djyp=1 or psyp=1 or jsyp=1 or wyyp=1 or cfyp=1 or rsyp=1 or gjjbyw=1 or kssdjid>0) '
	


   if @deptid>0
     set @stmt=@stmt+'and b.deptid='+cast(@deptid as char(10))
   if @yplx>0
     set @stmt=@stmt+'and yplx='+cast(@yplx as char(10))
   set @stmt=@stmt+'  group by b.cjid  '
  print @stmt
  exec(@stmt)



  select 0 序号,yppm 品名,ypspm 商品名,ypgg 规格,s_sccj 厂家,lsj 零售价,s_ypdw 单位,cast(rksl as float) 入库数,-(cast(cksl as float)) 出库数,
   cast(round(kcl/dwbl,3) as float) 库存数 from #temp a inner join vi_yf_kcmx b on a.cjid=b.cjid and deptid=@deptid
end


--exec SP_YK_TJ_GZYPTJ 98,'2007-01-01 00:00:00','2008-01-01 23:59:59',0

