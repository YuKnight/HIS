IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_JC_ROLE_DOCTOR_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_JC_ROLE_DOCTOR_INSERTFOREVENTLOG]
GO
--Add By Tany 2015-12-3 医生级别
CREATE TRIGGER [dbo].[TR_JC_ROLE_DOCTOR_INSERTFOREVENTLOG]
	ON [dbo].[JC_ROLE_DOCTOR] 
	AFTER INSERT
AS   
SET NOCOUNT ON

begin

	insert into EVENTLOG_MZ(EVENT,CATEGORY,BIZID) 
	select 'n2oDocType.HIS','JC_ROLE_DOCTOR',employee_id 
	from inserted
	union all
	select 'n2oDocType.EMR','JC_ROLE_DOCTOR',employee_id 
	from inserted

	--注意两个事件写的表不一样
	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
	select 'n2oDocType.ZYEMR','JC_ROLE_DOCTOR',employee_id 
	from inserted

end
GO