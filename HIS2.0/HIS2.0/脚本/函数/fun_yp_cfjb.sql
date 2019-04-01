IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yp_cfjb' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yp_cfjb
go 
CREATE FUNCTION [fun_yp_cfjb] (@cfjb INT)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 if @cfjb=1
   set @mc='正主任医师'
 if @cfjb=2
   set @mc='副正主任医师'
 if @cfjb=3
   set @mc='主治医师'
 if @cfjb=4
   set @mc='经治医师'
 RETURN(@mc)
END


