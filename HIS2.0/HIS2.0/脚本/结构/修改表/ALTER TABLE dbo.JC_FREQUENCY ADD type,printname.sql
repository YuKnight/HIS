----频率表增加使用类型和打印名称 Add by Tany 2014-09-10
IF NOT EXISTS(SELECT * from syscolumns WHERE ID IN(
select ID from sysobjects where id=object_id('JC_FREQUENCY')) AND NAME='type')
	ALTER TABLE dbo.JC_FREQUENCY ADD
	type smallint NOT NULL CONSTRAINT DF_JC_FREQUENCY_type DEFAULT 0
GO

IF NOT EXISTS(SELECT * from syscolumns WHERE ID IN(
select ID from sysobjects where id=object_id('JC_FREQUENCY')) AND NAME='printname')
	ALTER TABLE dbo.JC_FREQUENCY ADD
	printname varchar(50) NULL
GO

DECLARE @v sql_variant 
SET @v = N'0=全部 1=长嘱可用 2=临嘱可用'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'JC_FREQUENCY', N'COLUMN', N'type'
GO