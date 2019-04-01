IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_YF_FYMX' 
	   AND 	  type = 'V')
  drop view VI_YF_FYMX
go 
create view VI_YF_FYMX as
select
  *
from
   YF_FYMX(nolock)
UNION ALL
select
  *
from
   YF_FYMX_H(nolock)
