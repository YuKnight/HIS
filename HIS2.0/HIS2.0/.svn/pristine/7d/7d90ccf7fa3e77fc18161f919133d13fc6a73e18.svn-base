IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yp_ypzlx' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yp_ypzlx
go 
CREATE FUNCTION [fun_yp_ypzlx] (@ypzlx INT)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @mc=(select mc  from  yp_ypzlx where id=@ypzlx)
 RETURN(@mc)
END

