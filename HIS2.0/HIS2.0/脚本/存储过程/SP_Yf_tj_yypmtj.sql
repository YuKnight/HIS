IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_Yf_tj_yypmtj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_Yf_tj_yypmtj
GO
CREATE PROCEDURE SP_Yf_tj_yypmtj  
 (@type int, --0 表示门诊 1表示住院  
  @ksdm int ,--科室代码
  @cjid INTEGER,--cjid  
  @dtp1 varchar(30),  
  @dtp2 varchar(30),
  @pm int   
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
   set @ss='insert into #temp(cjid,ksdm,ysdm,lsj,ypsl)select cjid,ksdm,ysdm,lsj/ydwbl,sum(ypsl/ydwbl) ypsl from vi_yf_fy a,vi_yf_fymx b '+  
   'where a.id=b.fyid and fyrq>='''+@dtp1+' 00:00:00'' and fyrq<='''+@dtp2+' 23:59:59'' and jzcfbz=0 '  
   if @cjid>0  
     set @ss=@ss+' and cjid='+cast(@cjid as varchar(20))  
   if @ksdm>0  
     set @ss=@ss+' and ksdm='+cast(@ksdm as varchar(20))  

   set @ss=@ss+' group by cjid,ksdm,ysdm,lsj/ydwbl'  
   exec(@ss)  
 end  
       
 if @type=1  
 begin  
   set @ss='insert into #temp(cjid,ksdm,ysdm,lsj,ypsl)select cjid,dept_id,doc_id,cost_price*unitrate,sum(num/unitrate) ypsl from '+  
     ' zy_fee_speci where fy_bit=1 and fy_date>='''+@dtp1+' 00:00:00'' and fy_date<='''+@dtp2+' 23:59:59'' '  
   if @cjid>0  
     set @ss=@ss+' and cjid='+cast(@cjid as varchar(20))  
   if @ksdm>0  
     set @ss=@ss+' and dept_id='+cast(@ksdm as varchar(20)) 

   set @ss=@ss+' group by cjid,dept_id,doc_id,cost_price*unitrate'  
   exec(@ss)  
  
   set @ss='insert into #temp(cjid,ksdm,ysdm,lsj,ypsl)select cjid,dept_id,doc_id,cost_price*unitrate,sum(num/unitrate) ypsl from '+  
     ' zy_fee_speci_h where fy_bit=1 and fy_date>='''+@dtp1+' 00:00:00'' and fy_date<='''+@dtp2+' 23:59:59'' '  
   if @cjid>0  
     set @ss=@ss+' and cjid='+cast(@cjid as varchar(20))  
   if @ksdm>0  
     set @ss=@ss+' and dept_id='+cast(@ksdm as varchar(20)) 
   set @ss=@ss+' group by cjid,dept_id,doc_id,cost_price*unitrate'  
   exec(@ss)  
 end  

  set @ss='select top '+cast(@pm as varchar(10))+' 0 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,'+  
  'cast(a.lsj as float) 单价,dbo.fun_getdeptname(ksdm) 科室,dbo.fun_getempname(ysdm) 医生,cast(ypsl as float) 数量,s_ypdw 单位,cast(lsje as float) 金额 from '+  
  '(select cjid,ksdm,ysdm,lsj,sum(ypsl) ypsl,sum(ypsl*lsj) lsje from #temp group by cjid,ksdm,ysdm,lsj ) a,'+  
  'yp_ypcjd b where n_yplx in(1,2) and a.cjid=b.cjid order by ypsl desc'  
 exec(@ss)  
    
    
  end   
 END;  
