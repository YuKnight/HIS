USE [trasen]
GO

/****** Object:  StoredProcedure [dbo].[SP_YF_GETJH]    Script Date: 12/19/2011 14:00:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_YF_GETJH]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YF_GETJH]
GO

USE [trasen]
GO

/****** Object:  StoredProcedure [dbo].[SP_YF_GETJH]    Script Date: 12/19/2011 14:00:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[SP_YF_GETJH]      
(      
	@STIME VARCHAR(50),
	@ETIME VARCHAR(50),
	@BLH VARCHAR(50),
	@DEPT INT    
)      
AS      
BEGIN      
select FPID,FPH,ZJE,BRXM,DNLSH,BRXXID,XSBZ,[TIME],PDXH,BLH,LYCK,DEPT,DEPTNAME from YF_FYJH where XSBZ = 0
and [TIME] >= @STIME AND TIME <= @ETIME AND BLH = @BLH AND DEPT IN (@DEPT)
END 


GO


