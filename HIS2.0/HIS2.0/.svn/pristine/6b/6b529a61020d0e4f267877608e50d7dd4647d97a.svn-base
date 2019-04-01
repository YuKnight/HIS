/****** Object:  StoredProcedure [dbo].[SP_YF_FYJH]    Script Date: 12/19/2011 13:59:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_YF_FYJH]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YF_FYJH]
GO

CREATE PROC [dbo].[SP_YF_FYJH]      
(      
 @FPID uniqueidentifier,      
 @FPH varchar(30),      
 @ZJE decimal(18, 2),      
 @BRXM varchar(30),             
 @BLH VARCHAR(50),      
 @LYCK VARCHAR(50),  
 @LYCKMC VARCHAR(50),  
 @DEPTID INT,  
 @DEPTNAME VARCHAR(50)   ,
 @DJY    INT,
 @jhlx varchar(10)
)      
AS      
BEGIN        

DECLARE @PDXH INT
SET @PDXH=NULL

DECLARE @BDYBZ SMALLINT
IF @jhlx='print'
	set @BDYBZ=1
else
    set @BDYBZ=0

DECLARE @HJCS INT
SET @HJCS=0
IF @JHLX='CALL'
  SET @HJCS=1

declare @brxxid uniqueidentifier
set @brxxid=(select brxxid from mz_fpb where fpid=@fpid)

declare @bok smallint
set @bok=(SELECT top 1 1 FROM YF_FYJH WHERE FPID=@FPID AND BRXXID=@BRXXID)
IF  @bok=1 and @jhlx='call'
	UPDATE YF_FYJH SET HJCS=HJCS+1,lyck=@lyck,lyckmc=@lyckmc WHERE FPID=@FPID AND BRXXID=@BRXXID 
else if  @bok=1 and @jhlx='print'
	UPDATE YF_FYJH SET bdybz=1 WHERE FPID=@FPID AND BRXXID=@BRXXID 
ELSE 
BEGIN
	INSERT INTO YF_FYJH (FPID,FPH,ZJE,BRXM,BRXXID,PDXH,BLH,LYCK,LYCKMC,DEPTID,DEPTNAME,DJSJ,DJY,bdybz,HJCS)      
	VALUES (@FPID,@FPH,@ZJE,@BRXM,@BRXXID,@PDXH,@BLH,@LYCK,@LYCKMC,@DEPTID,@DEPTNAME,GETDATE(),@DJY,@bdybz,@HJCS)
END
end
  
GO


