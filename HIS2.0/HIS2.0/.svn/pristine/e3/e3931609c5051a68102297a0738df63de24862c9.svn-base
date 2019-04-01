IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_ZY_FEE_SPECI_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_ZY_FEE_SPECI_INSERTFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
CREATE TRIGGER TR_ZY_FEE_SPECI_INSERTFOREVENTLOG
	ON ZY_FEE_SPECI 
	AFTER INSERT
AS   
SET NOCOUNT ON

--增加费用信息事件 Modify By Tany 2014-11-01
IF exists(select 1 from inserted where charge_bit=1)
begin
	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
	select 'n2oFyxx.HIS','ZY_FEE_SPECI',id from inserted 
	where charge_bit=1 and orderexec_id<>dbo.FUN_GETEMPTYGUID() 
	and (CHARINDEX('老系统记账',isnull(BZ,''))=0 and CHARINDEX('历史库转回',isnull(BZ,''))=0)--老系统过来的没有执行ID 如果备注包含老系统记账的话也不传输给老系统，主要用于老系统医技记账 Modify By Tany 2014-11-23
end

IF exists(select 1 from inserted where FY_BIT=1)
begin
	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
	select 'FYZT','ZY_FEE_SPECI',id from inserted where FY_BIT=1
end

--增加医保智能审核上传记录表 Modify By tany 2015-05-20
insert into ZY_YBZNSH_Info(id, order_id, inpatient_id, baby_id, group_id, mng_type, opr_date, opr_man)
select id, order_id, inpatient_id, baby_id, -1, -1, getdate(), book_user 
from inserted a
where id not in (select id from ZY_YBZNSH_Info where inpatient_id=a.inpatient_id)