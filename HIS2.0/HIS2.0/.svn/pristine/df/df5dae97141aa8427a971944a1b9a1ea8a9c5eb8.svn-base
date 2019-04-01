IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yp_ghdw' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yp_ghdw
go 
CREATE FUNCTION [fun_yp_ghdw] (@ghdw INT)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @mc=(select ghdwmc  from  yp_ghdw where id=@ghdw)
 RETURN rtrim(@mc)
END


