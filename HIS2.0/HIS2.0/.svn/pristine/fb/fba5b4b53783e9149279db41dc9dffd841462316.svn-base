IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yp_ypjxdl' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yp_ypjxdl
go 
CREATE FUNCTION [fun_yp_ypjxdl] (@ypjx INT)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @mc=(select (select top 1 jxmc from yp_ypjxdl where jxbm=jxdl)  from  yp_ypjx where id=@ypjx)
 RETURN(@mc)
END
