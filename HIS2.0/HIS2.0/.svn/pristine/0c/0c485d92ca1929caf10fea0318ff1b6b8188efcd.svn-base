IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'FUN_YP_yyyy' 
	   AND 	  type = 'FN')
  drop FUNCTION FUN_YP_yyyy
go 
CREATE FUNCTION [FUN_YP_yyyy] (@yyid INT)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @MC = (SELECT MC FROM YP_yyyy WHERE ID=@yyid);
 RETURN(@mc)
END




