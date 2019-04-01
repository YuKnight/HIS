IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_YF_TLD' 
	   AND 	  type = 'V')
  drop view VI_YF_TLD
go 
CREATE view VI_YF_TLD as
select
  *
from
   YF_TLD(nolock)
UNION ALL
select
  *
from
   YF_TLD_H(nolock)
