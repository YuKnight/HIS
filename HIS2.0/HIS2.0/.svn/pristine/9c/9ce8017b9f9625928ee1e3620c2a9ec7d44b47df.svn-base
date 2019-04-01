USE [trasen]
GO

/****** Object:  StoredProcedure [dbo].[SP_YF_UPDATEJH]    Script Date: 12/19/2011 14:01:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_YF_UPDATEJH]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YF_UPDATEJH]
GO

USE [trasen]
GO

/****** Object:  StoredProcedure [dbo].[SP_YF_UPDATEJH]    Script Date: 12/19/2011 14:01:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_YF_UPDATEJH]      
(      
	@FPH VARCHAR(50),
	@BLH VARCHAR(50)
)      
AS      
BEGIN      
	UPDATE YF_FYJH SET XSBZ = 1 WHERE FPH = @FPH AND BLH = @BLH
END 
GO


