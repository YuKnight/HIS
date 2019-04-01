IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_YF_DJ' 
	   AND 	  type = 'V')
  drop view VI_YF_DJ
go 
CREATE view VI_YF_DJ as
select
  *
from
   Yf_DJ(nolock)
UNION ALL
select
  *
from
   Yf_DJ_H(nolock)
