IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_ZY_FEE_SPECI_UPDATEFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_ZY_FEE_SPECI_UPDATEFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
CREATE TRIGGER TR_ZY_FEE_SPECI_UPDATEFOREVENTLOG
	ON ZY_FEE_SPECI 
	AFTER UPDATE
AS   
SET NOCOUNT ON

--增加费用信息事件 Modify By Tany 2014-11-01
IF(UPDATE(charge_bit))
BEGIN
	IF exists(select 1 from inserted where charge_bit=1)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'n2oFyxx.HIS','ZY_FEE_SPECI',id from inserted 
		where charge_bit=1 
		and (CHARINDEX('老系统记账',isnull(BZ,''))=0 and CHARINDEX('历史库转回',isnull(BZ,''))=0)--如果备注包含老系统记账的话也不传输给老系统，主要用于老系统医技记账 Modify By Tany 2014-11-23
	end
END

IF(UPDATE(fy_bit))
BEGIN
	IF exists(select 1 from inserted where FY_BIT=1)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'FYZT','ZY_FEE_SPECI',id from inserted 
		where fy_bit=1
	end
END

--增加删除费用事件，主要给医保智能审核用 Modify By Tany 2015-06-02
IF(UPDATE(delete_bit))
BEGIN
	IF exists(select 1 from inserted where delete_bit=1)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'DEL_DETAILFEE','ZY_FEE_SPECI',id from inserted 
		where delete_bit=1
	end
END