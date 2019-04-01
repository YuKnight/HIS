IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yp_ywy' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yp_ywy
go 
CREATE FUNCTION [fun_yp_ywy] (@ywy INT)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @mc=(select ywymc  from  yp_ywy where id=@ywy)
 RETURN(@mc)
END


