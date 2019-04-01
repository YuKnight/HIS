IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_ZY_TRANSFER_DEPT_UPDATEFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_ZY_TRANSFER_DEPT_UPDATEFOREVENTLOG]
GO
--Add By Tany 2014-10-29 状态变更插入事件表
CREATE TRIGGER TR_ZY_TRANSFER_DEPT_UPDATEFOREVENTLOG
	ON ZY_TRANSFER_DEPT 
	AFTER UPDATE
AS   
SET NOCOUNT ON

declare @finish_bit bigint

IF(UPDATE(finish_bit))
BEGIN
	select @finish_bit=finish_bit
	from inserted

	IF @finish_bit=1
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'n2oZk.HIS','ZY_TRANSFER_DEPT',id from inserted where s_dept_id in (select deptid from vi_zy_newhishsz)
		union all
		select 'n2oZk.LIS','ZY_TRANSFER_DEPT',id from inserted where s_dept_id in (select deptid from vi_zy_newhishsz)
		union all
		select 'n2oZk.EMR','ZY_TRANSFER_DEPT',id from inserted where s_dept_id in (select deptid from vi_zy_newhishsz)
	end
END

--取消转科事件，只有完成了的专科取消才有取消转科的事件 Modify By Tany 2014-11-21
IF(UPDATE(cancel_bit))
BEGIN
	IF exists(select 1 from inserted where finish_bit=1 and cancel_bit=1)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'n2oQxzk.HIS','ZY_TRANSFER_DEPT',id from inserted where finish_bit=1 and cancel_bit=1 and s_dept_id in (select deptid from vi_zy_newhishsz)
	end
END