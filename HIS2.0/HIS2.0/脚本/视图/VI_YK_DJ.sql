IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_YK_DJ' 
	   AND 	  type = 'V')
  drop view VI_YK_DJ
go 
CREATE view VI_YK_DJ as
select
  *
from
   YK_DJ(nolock)
UNION ALL
select
  *
from
   YK_DJ_H(nolock)




