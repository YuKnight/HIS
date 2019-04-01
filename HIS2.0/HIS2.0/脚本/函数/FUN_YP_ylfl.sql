IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'FUN_YP_ylfl' 
	   AND 	  type = 'FN')
  drop FUNCTION FUN_YP_ylfl
go 
CREATE FUNCTION FUN_YP_ylfl(@flid bigint) 
    RETURNS varchar(50) 
 BEGIN 
    declare @MC varchar(50); 
    set @MC = (SELECT flmc FROM yp_ylfl WHERE ID=@flid);
  RETURN @MC; 
END



