IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yp_ypdw' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yp_ypdw
go 
CREATE FUNCTION [fun_yp_ypdw] (@ypdw INT)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @mc=(select dwmc  from  yp_ypdw where id=@ypdw)
 RETURN(@mc)
END


