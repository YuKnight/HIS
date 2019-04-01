IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'Vi_Zy_Byjbqxx' 
	   AND 	  type = 'V')
  drop view Vi_Zy_Byjbqxx
go 
create view  Vi_Zy_Byjbqxx as
select dept_id,dbo.fun_getDeptname(dept_id) dept_name,ward_id from JC_WARDRDEPT  ;

