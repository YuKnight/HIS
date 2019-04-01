IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'FUN_YP_bsyy' 
	   AND 	  type = 'FN')
  drop FUNCTION FUN_YP_bsyy
go 
CREATE FUNCTION [FUN_YP_bsyy] (@yyid INT)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 set @MC = (SELECT MC FROM YP_bsyy WHERE ID=@yyid);
 RETURN(@mc)
END




