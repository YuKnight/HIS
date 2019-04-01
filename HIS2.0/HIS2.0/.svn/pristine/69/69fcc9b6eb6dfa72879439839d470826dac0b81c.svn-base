IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'MedInfoTableHis' 
	   AND 	  type = 'V')
  drop view MedInfoTableHis
go 
create view MedInfoTableHis AS
select cjid as MedOnlyCode,yppm as MedName,ypspm as MedcommodityName,ypgg as MedUnit,
s_ypdw as MedUnitPack,bzsl as MedConvercof,
dbo.fun_yp_ypdw(bzdw) as MedPack,'' as MedPYCode,s_sccj as MedFactory from vi_yp_ypcd where bdelete=0 and yplx in(1,2);



