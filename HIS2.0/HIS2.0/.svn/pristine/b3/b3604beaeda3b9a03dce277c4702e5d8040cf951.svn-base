IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_Yf_tj_ysyytj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_Yf_tj_ysyytj
GO
CREATE PROCEDURE SP_Yf_tj_ysyytj
 (@type int, --0 表示门诊 1表示住院
--  @yplx int ,--药品类型
  @cjid INTEGER,--cjid
  @dtp1 varchar(30),
  @dtp2 varchar(30)
 )  
as
BEGIN
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
   
  
  p2:begin
	if @type=0
	begin
		 set @ss='insert into #temp(cjid,ksdm,ysdm,lsj,ypsl)select cjid,0,ysdm,lsj/ydwbl,sum(ypsl/ydwbl) ypsl from vi_yf_fy a,vi_yf_fymx b '+
		 'where a.id=b.fyid and fyrq>='''+@dtp1+' 00:00:00'' and fyrq<='''+@dtp2+' 23:59:59'' and jzcfbz=0 '
		 if @cjid>0
		   set @ss=@ss+' and cjid='+cast(@cjid as varchar(20))
		 set @ss=@ss+' group by cjid,ysdm,lsj/ydwbl'
		 exec(@ss)
	end
     
	if @type=1
	begin
		 set @ss='insert into #temp(cjid,ksdm,ysdm,lsj,ypsl)select xmid,dept_id,doc_id,cost_price*unitrate,sum(num/unitrate) ypsl from '+
				 ' zy_fee_speci where xmly=1 and fy_bit=1 and fy_date>='''+@dtp1+' 00:00:00'' and fy_date<='''+@dtp2+' 23:59:59'' '
		 if @cjid>0
		   set @ss=@ss+' and xmid='+cast(@cjid as varchar(20))
		 set @ss=@ss+' group by xmid,dept_id,doc_id,cost_price*unitrate'
         --print @ss
		 exec(@ss)
		 
		 set @ss='insert into #temp(cjid,ksdm,ysdm,lsj,ypsl)select xmid,dept_id,doc_id,cost_price*unitrate,sum(num/unitrate) ypsl from '+
				 ' zy_fee_speci_h where xmly=1 and  fy_bit=1 and fy_date>='''+@dtp1+' 00:00:00'' and fy_date<='''+@dtp2+' 23:59:59'' '
		 if @cjid>0
		   set @ss=@ss+' and xmid='+cast(@cjid as varchar(20))
		 set @ss=@ss+' group by xmid,dept_id,doc_id,cost_price*unitrate'
		 exec(@ss)
	end
	 



	 set @ss='select 0 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,'+
	 'cast(a.lsj as float) 单价,dbo.fun_getdeptname(ksdm) 科室,dbo.fun_getempname(ysdm) 医生,cast(ypsl as float) 数量,s_ypdw 单位,cast(lsje as float) 金额 from '+
	 '(select cjid,ksdm,ysdm,lsj,sum(ypsl) ypsl,sum(ypsl*lsj) lsje from #temp group by cjid,ksdm,ysdm,lsj ) a,'+
	 'yp_ypcjd b where n_yplx in(1,2) and a.cjid=b.cjid order by a.cjid'
	exec(@ss)
	 
	 
  end 
 END;
 
 --exec SP_Yf_tj_ysyytj 1,0,'2010-12-28','2010-12-28'

 