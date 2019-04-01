IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_ZY_JY_PRINT_UPDATEFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_ZY_JY_PRINT_UPDATEFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
CREATE TRIGGER TR_ZY_JY_PRINT_UPDATEFOREVENTLOG
	ON ZY_JY_PRINT 
	AFTER UPDATE
AS   
SET NOCOUNT ON

declare @id bigint
DECLARE @delete_bit smallint

IF(UPDATE(delete_bit))
BEGIN
	select @id=id,
		@delete_bit=DELETE_BIT
	from inserted

	--医嘱被删除了则插入取消事件
	IF @delete_bit=1
	begin
		--因为检验做了直接接口，所以这里的事件只给EMR使用 Modify By Tany 2014-08-13
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'CancelNewExamOrder.EMR','ZY_JY_PRINT',convert(varchar(50),id) from inserted
		union all 
		select 'n2oLisDelSq.LIS','ZY_JY_PRINT',convert(varchar(50),order_id) from inserted --怕直接接口删除不成功，增加一次事件来完成检验的删除 Modify By Tany 2015-03-24
		return
	end

END
