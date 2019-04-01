
if exists (select * from sysobjects 
           where name = N'sp_yf_tj_xstjbyks'
           and type = 'P')
   drop proc sp_yf_tj_xstjbyks
go
--------------------2
create proc sp_yf_tj_xstjbyks
@rq1 varchar(30),
@rq2 varchar(30),
@yplx INTEGER,--药品类型
@deptid int,--药剂科室
@ypsx int,--药品属性
@ksname varchar(100)--科室
as

		set @rq1=@rq1+' 00:00:00'
		set @rq2=@rq2+' 23:59:59'
		declare @where varchar(2000)
		declare @ssql varchar(2000)
		declare @ksname1 varchar(500)
		declare @ksname2 varchar(500)
		declare @ksname3 varchar(500)
		set @ksname1=''
		set @ksname2=''
		set @ksname3=''
		set @where=''
				create table #temp(ksdm int,xsjeAll decimal(15,3),gjjbyw bit)--xsjeAll 药品销售金额   gjjbyw 基药
				if @yplx<>0 
				 set @where=@where+' and yplx='+cast(@yplx as char(10))+'';
				if @deptid<>0 
				 set @where=@where+' and a.deptid='+cast(@deptid as char(10))+'';
				if @ypsx=0 
				 set @where=@where+' and gzyp=1 '
				if @ypsx=1
				 set @where=@where+' and  mzyp=1 '
				if @ypsx=2
				 set @where=@where+' and  djyp=1 '
				if @ypsx=3
				 set @where=@where+' and  psyp=1 '
				if @ypsx=4
				 set @where=@where+' and  jsyp=1 '
				if @ypsx=5
				 set @where=@where+' and  wyyp=1 '
				if @ypsx=6
				 set @where=@where+' and  cfyp=1 '
				if @ypsx=7
				 set @where=@where+' and  rsyp=1 '
				if @ypsx=8
				 set @where=@where+' and  gjjbyw=1 '
				if @ypsx=9
				 set @where=@where+' and  kssdjid>0 and ddd>0'
				if @ksname<>''
				 begin
					set @ksname1=' and a.KSDM in ('+@ksname+') '
					set @ksname2=' and a.dept_ly in('+@ksname+') '
					set @ksname3=' and a.DEPTID in('+@ksname+')'
				 set 
				 end
				 set @ksname1=@where+@ksname1;
				 set @ksname2=@where+@ksname2;
				 set @ksname3=@where+@ksname3;	
				 --住院处方发药和门诊发药
				set @ssql='select  a.KSDM ,SUM(LSJE) LSJE,gjjbyw from VI_YF_FY a , 
				VI_YF_FYMX b,VI_YP_YPCD c where a.ID=b.FYID  and b.CJID=c.cjid
				and a.YWLX  in(''017'',''020'')  and a.FYRQ between '''+@rq1+''' and '''+@rq2+''' '+@ksname1+' 	
				 group by a.KSDM,c.gjjbyw'
				insert  into #temp(ksdm ,xsjeAll,gjjbyw)--------住院处方发药和门诊发药 --,'018'
				exec (@ssql)	
					
				 --住院统领和摆药
				set @ssql='select a.dept_ly ksdm,SUM(LSJE) as lsje,gjjbyw 
						   from VI_yf_tld a, vi_yf_tldmx b ,VI_YP_YPCD c
						   where a.groupid=b.groupid   and b.cjid = c.cjid and a.YWLX in(''020'')
						   and a.FYRQ between '''+@rq1+''' and '''+@rq2+''' '+@ksname2+'				   
						   group by a.dept_ly,c.gjjbyw'
				insert  into #temp(ksdm ,xsjeAll,gjjbyw)
				exec(@ssql)
			
				
				
				 --处方补录发药--,'022'
				set @ssql=' select a.DEPTID ksname,sum(b.LSJE) as lsjeAll,
							case when gjjbyw=1 then SUM(b.LSJE) else 0 end lsjeJY
							from vi_YF_dj a,vi_YF_djmx b ,vi_yp_ypcd c 
							where a.id=b.djid and b.cjid=c.cjid   
							and  a.ywlx in(''018'',''021'')
							and a.shrq between '''+@rq1+''' and '''+@rq2+''' '+@ksname3+'
							and a.shbz=1  
							group by a.DEPTID,gjjbyw'
				insert into #temp(ksdm,xsjeAll,gjjbyw)		
				exec(@ssql)	
				--print(@ssql)														    
	select convert(varchar(10),ROW_NUMBER() over (order by ksdm)) 序号, CAST( dbo.fun_getdeptname(ksdm) as varchar(100)) 科室,
	CAST( sum(xsjeAll) as varchar(100)) 药品销售金额, sum(case when gjjbyw=1 then xsjeAll else 0 end ) 基药销售金额,
	 case when  sum(xsjeAll)<>0 then cast(Convert(decimal(18,2),
	 (sum(case when gjjbyw=1 then xsjeAll else 0 end ) /SUM(xsjeAll)
	 )*100) AS varchar)  else '0' end  基药销售占比
	 from #temp
	group by ksdm
	order by ksdm
	drop table #temp

go

