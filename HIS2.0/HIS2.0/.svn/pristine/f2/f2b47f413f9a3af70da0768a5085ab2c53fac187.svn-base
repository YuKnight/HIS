IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_YF_FY' 
	   AND 	  type = 'V')
  drop view VI_YF_FY
go 
CREATE view VI_YF_FY as
select
  *
from
   YF_FY(nolock)
UNION ALL
select
  *
from
   YF_FY_H(nolock)
