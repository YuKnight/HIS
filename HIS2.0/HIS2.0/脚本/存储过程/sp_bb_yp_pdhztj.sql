create proc sp_bb_yp_pdhztj
 ( 

   @RQ1 datetime, 

   @RQ2 datetime

 )

as 
select dbo.fun_getDeptname(DEPTID) 科室,sum(zcjhje) 帐存进货金额,sum(zclsje) 帐存零售金额,

sum(pcjhje) 盘存进货金额,sum(pclsje) 盘存零售金额,

sum(pcjhje-zcjhje) 进货盈亏金额,
sum(pclsje-zclsje) 零售盈亏金额

from yf_pd a,

yf_pdmx b

where a.id=b.djid and a.djrq>=@RQ1 and a.djrq<=@RQ2

group by DEPTID 

order by DEPTID