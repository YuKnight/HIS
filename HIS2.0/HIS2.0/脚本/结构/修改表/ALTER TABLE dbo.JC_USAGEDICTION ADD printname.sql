----用法表增加打印名称 Add by Tany 2014-09-11
IF NOT EXISTS(SELECT * from syscolumns WHERE ID IN(
select ID from sysobjects where id=object_id('JC_USAGEDICTION')) AND NAME='printname')
	ALTER TABLE dbo.JC_USAGEDICTION ADD
	printname varchar(50) NULL
GO