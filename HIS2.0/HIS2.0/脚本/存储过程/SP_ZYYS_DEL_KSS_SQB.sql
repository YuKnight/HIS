if exists (select 1 from dbo.sysobjects where name='SP_ZYYS_DEL_KSS_SQB' and type='P')
	drop PROCEDURE SP_ZYYS_DEL_KSS_SQB
go

create PROCEDURE SP_ZYYS_DEL_KSS_SQB
(
	@GROUPID BIGINT, 
	@BINID UNIQUEIDENTIFIER, 
	@ORDERID UNIQUEIDENTIFIER
) 
AS
------------------------------------------------------------------------
-- SQL 存储过程[删除特殊抗菌物申请信息] add by : jchl_0717
------------------------------------------------------------------------
begin
		UPDATE zy_kss_sqb SET DEL_BIT='1'
		WHERE INPATIENT_ID = @BINID AND order_id =@ORDERID AND DEL_BIT=0
end