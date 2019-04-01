IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_ZY_JC_RECORD_UPDATEFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_ZY_JC_RECORD_UPDATEFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
CREATE TRIGGER TR_ZY_JC_RECORD_UPDATEFOREVENTLOG
	ON ZY_JC_RECORD 
	AFTER UPDATE
AS   
SET NOCOUNT ON

declare @id uniqueidentifier
declare @jclxid bigint
DECLARE @delete_bit smallint

IF(UPDATE(delete_bit))
BEGIN
	select @id=a.id,
		@jclxid=b.JCLXID,
		@delete_bit=a.DELETE_BIT
	from inserted a left join jc_jc_item b on a.HOITEM_ID=b.YZID

	--医嘱被删除了则插入取消事件
	IF @delete_bit=1
	begin
		--JC_JCCLASSDICTION.ID 心电、脑电、肌电
		if @jclxid in (10,11,81)
		begin
			insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
			select 'CancelNewCheckOrder.ECG','ZY_JC_RECORD',id from inserted
		end
		else
		begin
			insert into EVENTLOG(EVENT,CATEGORY,BIZID)
			select 'CancelNewCheckOrder.PACS','ZY_JC_RECORD',id from inserted
		end
		--增加对EMR的事件 Modify By Tany 2014-08-13
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'CancelNewCheckOrder.EMR','ZY_JC_RECORD',id from inserted
		union all
		select 'CancelNewCheckOrder.YYJC','ZY_JC_RECORD',id from inserted
	end

END
