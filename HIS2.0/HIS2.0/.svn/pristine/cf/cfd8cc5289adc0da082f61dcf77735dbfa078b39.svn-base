IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yp_kwmc' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yp_kwmc
go 
CREATE FUNCTION [fun_yp_kwmc] (@kwid INT,@deptid int)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @mc=(select top 1 hwmc from yp_hwsz where ggid=@kwid and deptid=@deptid)
 RETURN(@mc)
END




