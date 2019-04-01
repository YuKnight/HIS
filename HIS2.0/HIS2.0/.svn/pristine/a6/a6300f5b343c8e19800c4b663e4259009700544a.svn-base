IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_ZY_BED_ASSIGN_UPDATEFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_ZY_BED_ASSIGN_UPDATEFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
CREATE TRIGGER TR_ZY_BED_ASSIGN_UPDATEFOREVENTLOG
	ON ZY_BED_ASSIGN 
	AFTER UPDATE
AS   
SET NOCOUNT ON

--取消分配床位 Modify By Tany 2014-11-21
IF(UPDATE(stop_flag))
BEGIN
	IF exists(select 1 from inserted where stop_flag=8)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'n2oQxfpcw.HIS','ZY_BED_ASSIGN',inpatient_id 
		from inserted 
		where stop_flag=8 and dept_id in (select deptid from vi_zy_newhishsz)
	end
END