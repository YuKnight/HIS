--药品资源表
IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_JMPZ_YPCD' 
	   AND 	  type = 'V')
  drop view VI_JMPZ_YPCD
go 
create view VI_JMPZ_YPCD AS
select cjid as spid,yppm spmch,'' as pym,ypgg shpgg,s_ypjx as jixing,s_sccj as shengccj,
hlxs as bzjl,dbo.fun_yp_ypdw(hldw) as usedw,
dbo.fun_yp_ypdw(bzdw) as dw,'' leibie,bz beizhu from vi_yp_ypcd where bdelete=0;