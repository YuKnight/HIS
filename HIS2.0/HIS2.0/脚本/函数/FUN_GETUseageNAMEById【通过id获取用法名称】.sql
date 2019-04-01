if exists (select 1 from dbo.sysobjects where type='FN' and name ='FUN_GETUsageNAMEById')
	drop function FUN_GETUsageNAMEById
go
create FUNCTION [dbo].[FUN_GETUsageNAMEById](  
@UseageID int  
)  
RETURNS varchar(30)  
AS
/*
通过id获取用法名称 
*/  
begin  
 declare @name varchar(30)  
 set @name = ( select NAME from JC_USAGEDICTION where ID = @UseageID )  
 return rtrim(@name)   
end  