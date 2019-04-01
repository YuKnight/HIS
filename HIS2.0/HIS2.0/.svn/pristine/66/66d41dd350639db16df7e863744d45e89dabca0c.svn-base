IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_Yf_tj_yszzyptj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_Yf_tj_yszzyptj
GO
CREATE PROCEDURE SP_Yf_tj_yszzyptj
 (@type int, --0 表示门诊 1表示住院 2 全部
  @cjid INTEGER,--cjid
  @dtp1 varchar(30),
  @dtp2 varchar(30),
  @bks int --区分开单科室？ 1区分
 )  
as

declare @count INT 
declare @ss varchar(5000)
 --声明临时表
   create TABLE #TEMP
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
   	  cjid int,
	  ksdm int,
	  ysdm int,
	  lsj decimal(15,3),
	  ypsl decimal(15,2)
   ) 
   
  

	if @type=0 or @type=2
	begin
		 set @ss='insert into #temp(cjid,ksdm,ysdm,lsj,ypsl)select cjid,ksdm,ysdm,lsj*ydwbl,sum(ypsl/ydwbl) ypsl from vi_yf_fy a(nolock),vi_yf_fymx b(nolock) '+
		 'where a.id=b.fyid and fyrq>='''+@dtp1+' 00:00:00'' and fyrq<='''+@dtp2+' 23:59:59'' and jzcfbz=0 and cjid in(select cjid from yp_ypcjd(nolock) where n_ypzlx in(2,4,6)) '
		 if @cjid>0
		   set @ss=@ss+' and cjid='+cast(@cjid as varchar(20))
		 set @ss=@ss+' group by cjid,ksdm,ysdm,lsj*ydwbl'
		 exec(@ss)
         print @ss
	end
     
	if @type=1  or @type=2
	begin
		 set @ss='insert into #temp(cjid,ksdm,ysdm,lsj,ypsl)select xmid,dept_id,doc_id,cost_price*unitrate,sum(num/unitrate) ypsl from '+
				 ' zy_fee_speci(nolock) where xmly=1 and fy_bit=1 and fy_date>='''+@dtp1+' 00:00:00'' and fy_date<='''+@dtp2+' 23:59:59'' and xmid in(select cjid from yp_ypcjd where n_ypzlx in(2,4,6)) '
		 if @cjid>0
		   set @ss=@ss+' and xmid='+cast(@cjid as varchar(20))
		 set @ss=@ss+' group by xmid,dept_id,doc_id,cost_price*unitrate'
		 exec(@ss)

		 set @ss='insert into #temp(cjid,ksdm,ysdm,lsj,ypsl)select xmid,dept_id,doc_id,cost_price*unitrate,sum(num/unitrate) ypsl from '+
				 ' zy_fee_speci_h(nolock) where xmly=1 and  fy_bit=1 and fy_date>='''+@dtp1+' 00:00:00'' and fy_date<='''+@dtp2+' 23:59:59'' and xmid in(select cjid from yp_ypcjd where n_ypzlx in(2,4,6)) '
		 if @cjid>0
		   set @ss=@ss+' and xmid='+cast(@cjid as varchar(20))
		 set @ss=@ss+' group by xmid,dept_id,doc_id,cost_price*unitrate'
		 exec(@ss)

	end
	 
if @bks=0
  update #temp set ksdm=0


 set @ss='select 0 序号,s_yppm 品名,s_ypgg 规格,s_sccj 厂家,'+
 'cast(a.lsj as float) 单价,dbo.fun_getdeptname(ksdm) 科室,dbo.fun_getempname(ysdm) 医生,cast(ypsl as float) 数量,s_ypdw 单位,cast(lsje as float) 金额 from '+
 '(select cjid,ksdm,ysdm,lsj,sum(ypsl) ypsl,sum(ypsl*lsj) lsje from #temp group by cjid,ksdm,ysdm,lsj ) a,'+
 'yp_ypcjd b where n_yplx in(1,2) and a.cjid=b.cjid order by a.cjid,ksdm,ysdm'
exec(@ss)
	 
	 


 
 --exec SP_Yf_tj_yszzyptj 2,0,'2001-1-01','2010-01-01',1

 