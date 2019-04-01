IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yf_ywlx' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yf_ywlx
go 
CREATE FUNCTION [fun_yf_ywlx] (@ywlx char(3))  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @mc=(select ywmc  from  yf_ywlx where ywlx=@ywlx)
 RETURN(@mc)
END




