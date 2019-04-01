if exists (select 1 from dbo.sysobjects where name='SP_ZYYS_DEL_KSS_SH' and type='P')
	drop PROCEDURE SP_ZYYS_DEL_KSS_SH
go
--select * from ZY_KSS_SH
create PROCEDURE [dbo].[SP_ZYYS_DEL_KSS_SH]
(
	@BINID UNIQUEIDENTIFIER, 
	@GROUPID BIGINT, 
	@ORDERID UNIQUEIDENTIFIER,
	@SIGN INT 
) 
AS
------------------------------------------------------------------------
-- SQL 存储过程[删除抗生素审核信息]
------------------------------------------------------------------------
BEGIN
	--|删除指定记录
	IF @SIGN=0 
		UPDATE ZY_KSS_SH SET DEL_BIT=1
		WHERE INPATIENT_ID = @BINID AND ORDER_ID =@ORDERID AND DEL_BIT=0

	--|删除指定医嘱组
	IF @SIGN=1
		UPDATE ZY_KSS_SH SET DEL_BIT=1
		WHERE INPATIENT_ID=@BINID AND GROUP_ID=@GROUPID AND DEL_BIT=0
END 