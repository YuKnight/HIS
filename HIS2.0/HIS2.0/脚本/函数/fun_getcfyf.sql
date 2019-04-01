IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_getcfyf' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_getcfyf
go 
CREATE FUNCTION fun_getcfyf (@pcdm INT)  
RETURNS nvarchar(100) AS  
BEGIN 
 DECLARE  @mc varchar(100)
 set @mc=(select RTRIM(cast(execnum as char(10)))+'´Î/'+RTRIM(cast(cycleday as char(10)))+'Ìì' from JC_FREQUENCY  WHERE  ID=@PCDM)
 RETURN(@mc)
END



