--ø∆ “◊ ¡œ
IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_JMPZ_DEPT' 
	   AND 	  type = 'V')
  drop view VI_JMPZ_DEPT
go 
CREATE VIEW VI_JMPZ_DEPT AS
select dept_id as bmid,ward_name as bmname,py_code as pym from jc_ward  ;