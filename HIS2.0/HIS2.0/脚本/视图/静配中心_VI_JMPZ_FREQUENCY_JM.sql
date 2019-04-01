--∆µ¥Œ”√“©±Ì
IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_JMPZ_FREQUENCY' 
	   AND 	  type = 'V')
  drop view VI_JMPZ_FREQUENCY
go 
CREATE VIEW VI_JMPZ_FREQUENCY AS
select * from jc_frequency;


