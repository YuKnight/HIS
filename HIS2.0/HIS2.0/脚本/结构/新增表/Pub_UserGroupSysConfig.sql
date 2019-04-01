if exists(SELECT 1 FROM dbo.sysobjects where name ='Pub_UserGroupSysConfig' and type = 'U')
	DROP table Pub_UserGroupSysConfig
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pub_UserGroupSysConfig]( 
	id [uniqueidentifier] NOT NULL,
	userGroupId int NOT NULL,	 
	configId   INT  NOT	NULL				 
	 
) 

GO