IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_YK_DJMX' 
	   AND 	  type = 'V')
  drop view VI_YK_DJMX
go 
CREATE view VI_YK_DJMX as
select
  *
from
   YK_DJMX(nolock)
UNION ALL
select
  *
from
   YK_DJMX_H(nolock)






