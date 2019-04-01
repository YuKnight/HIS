IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_YF_TLDMX' 
	   AND 	  type = 'V')
  drop view VI_YF_TLDMX
go 
CREATE view VI_YF_TLDMX as
select
  *
from
   YF_TLDMX(nolock)
UNION ALL
select
  *
from
   YF_TLDMX_H(nolock)
