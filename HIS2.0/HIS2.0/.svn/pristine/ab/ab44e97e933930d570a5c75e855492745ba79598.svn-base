IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yp_ypjx' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yp_ypjx
go 
CREATE FUNCTION [fun_yp_ypjx] (@ypjx INT)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @mc=(select mc  from  yp_ypjx where id=@ypjx)
 RETURN(@mc)
END

