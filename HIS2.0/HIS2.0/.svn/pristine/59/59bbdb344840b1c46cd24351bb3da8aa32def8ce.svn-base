IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'Vi_Zy_Byjypxx' 
	   AND 	  type = 'V')
  drop view Vi_Zy_Byjypxx
go 
create view Vi_Zy_Byjypxx  as
select cjid as 药品编码,yppm as 药品通用名,ypgg as 产品规格,ypspm as 药品商品名,
(case when (ypgg is not null and ypgg<>'' ) then SUBSTRING(ypgg,1,CHARINDEX('*',ypgg)-1) else ypgg end ) as 成分含量,
s_ypjx as 药品种类,dbo.fun_yp_ghdw(bzdw) as 药品单位,s_sccj as 药品制造商,
PYM 拼音码,
WBM  五笔码
from vi_yp_ypcd where s_ypjx in('胶囊剂','片剂');
