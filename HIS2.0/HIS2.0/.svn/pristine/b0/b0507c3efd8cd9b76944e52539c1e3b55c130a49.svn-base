IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yk_ywlx' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yk_ywlx
go 
CREATE FUNCTION [fun_yk_ywlx] (@ywlx char(3))  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @mc=(select ywmc  from  yk_ywlx where ywlx=@ywlx)
 RETURN(@mc)
END


