IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'FUN_YP_sccj' 
	   AND 	  type = 'FN')
  drop FUNCTION FUN_YP_sccj
go 
CREATE FUNCTION [FUN_YP_sccj] (@sccjid INT)  
RETURNS nvarchar(100) AS  
BEGIN 
 DECLARE  @mc varchar(100)
 set @mc=(select sccj  from  yp_sccj where id=@sccjid)
 RETURN(@mc)
END



