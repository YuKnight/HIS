IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_ZY_JC_RECORD_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_ZY_JC_RECORD_INSERTFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
CREATE TRIGGER TR_ZY_JC_RECORD_INSERTFOREVENTLOG
	ON ZY_JC_RECORD 
	AFTER INSERT
AS   
SET NOCOUNT ON

declare @id uniqueidentifier
declare @jclxid bigint

select @id=a.ID,@jclxid=b.JCLXID 
from inserted a left join jc_jc_item b on a.HOITEM_ID=b.YZID

--JC_JCCLASSDICTION.ID 心电、脑电、肌电
if @jclxid in (10,11,81)
begin
	insert into EVENTLOG(EVENT,CATEGORY,BIZID)
	select 'NewCheckOrder.ECG','ZY_JC_RECORD',id from inserted
end
else
begin
	insert into EVENTLOG(EVENT,CATEGORY,BIZID)
	select 'NewCheckOrder.PACS','ZY_JC_RECORD',id from inserted
end

--增加对EMR的事件 Modify By Tany 2014-08-13
insert into EVENTLOG(EVENT,CATEGORY,BIZID)
select 'NewCheckOrder.EMR','ZY_JC_RECORD',id from inserted
union all
select 'NewCheckOrder.YYJC','ZY_JC_RECORD',id from inserted