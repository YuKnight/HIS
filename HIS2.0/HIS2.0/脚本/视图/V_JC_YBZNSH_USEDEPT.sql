
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_JC_YBZNSH_USEDEPT]'))
DROP VIEW [dbo].[V_JC_YBZNSH_USEDEPT]
GO

create view [dbo].[V_JC_YBZNSH_USEDEPT]
AS
select -100 as dept_id
union all
--肾病内科、肾病内科监护室、风湿免疫科病房、肝胆胰外科一病区、肝胆胰外科二病区
select 138 as dept_id
union all
select 329 as dept_id
union all
select 467 as dept_id
union all
select 288 as dept_id
union all
select 510 as dept_id
-------------------------------------------------------------------------------
