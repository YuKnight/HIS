IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yp_yplx' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yp_yplx
go 
CREATE FUNCTION [fun_yp_yplx] (@yplx INT)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @mc=(select mc  from  yp_yplx where id=@yplx)
 RETURN(@mc)
END


