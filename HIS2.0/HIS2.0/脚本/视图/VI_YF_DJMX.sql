IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_YF_DJMX' 
	   AND 	  type = 'V')
  drop view VI_YF_DJMX
go 
CREATE view VI_YF_DJMX as
select
  *
from
   YF_DJMX(nolock)
UNION ALL
select
  *
from
   YF_DJMX_H(nolock)






