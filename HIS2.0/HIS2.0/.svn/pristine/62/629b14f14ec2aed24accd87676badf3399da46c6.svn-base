USE [trasen]
GO

/****** Object:  StoredProcedure [dbo].[SP_YF_FYJH]    Script Date: 12/19/2011 13:59:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_YF_FYJH]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YF_FYJH]
GO

USE [trasen]
GO

/****** Object:  StoredProcedure [dbo].[SP_YF_FYJH]    Script Date: 12/19/2011 13:59:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_YF_FYJH]      
(      
 @FPID uniqueidentifier,      
 @FPH varchar(30),      
 @ZJE decimal(18, 2),      
 @BRXM varchar(30),      
 @DNLSH bigint,      
 @BRXXID uniqueidentifier,      
 @XSBZ int,      
 @TIME VARCHAR(50),      
 @PDXH VARCHAR(16),      
 @BLH VARCHAR(50),      
 @LYCK VARCHAR(50),    
 @DEPT INT,  
 @DEPTNAME VARCHAR(50)      
)      
AS      
BEGIN      
--DECLARE @DATE DATETIME         
--SET @DATE = GETDATE()   --获取当前时间,用于是否需要重新生成排队序号      
--SET @YYYY = DATEPART(YYYY,@DATE)      
--SET @MM = DATEPART(MM,@DATE)      
--SET @DD = DATEPART(DD,@DATE)      
SET @PDXH = NULL      
      
--取出当前日期最大值      
--SELECT TOP 1 @PDXH = PDXH FROM YF_FYJH WHERE [TIME] LIKE       
--@TIME + '%' ORDER BY PDXH DESC 

DECLARE @T varchar(50);
set @T = SUBSTRING(@TIME,0,11)

SELECT TOP 1 @PDXH = PDXH FROM YF_FYJH WHERE SUBSTRING([TIME],0,11) LIKE       
@T ORDER BY PDXH DESC         
IF @PDXH IS NULL      
SET @PDXH = '00001'      
ELSE      
BEGIN      
DECLARE @NUM VARCHAR(5)      
--最大编号+1      
SET @NUM = CONVERT(VARCHAR,(CONVERT(INT,RIGHT(@PDXH,5)) + 1))      
      
--补高位丢失      
SET @NUM = REPLICATE('0',5-LEN(@NUM)) + @NUM      
      
SET @PDXH = @NUM      
END      
INSERT INTO YF_FYJH (FPID,FPH,ZJE,BRXM,DNLSH,BRXXID,XSBZ,[TIME],PDXH,BLH,LYCK,DEPT,DEPTNAME)      
VALUES (@FPID,@FPH,@ZJE,@BRXM,@DNLSH,@BRXXID,@XSBZ,@TIME,@PDXH,@BLH,@LYCK,@DEPT,@DEPTNAME)      
END   
  
GO


