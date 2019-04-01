IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_YK_KCPH_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_YK_KCPH_INSERTFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
CREATE TRIGGER [dbo].[TR_YK_KCPH_INSERTFOREVENTLOG]
	ON [dbo].[YK_KCPH] 
	AFTER UPDATE
AS   
SET NOCOUNT ON

if(UPDATE(kcl))
begin
	if not exists(select 1 from EVENTLOG where FINISH=0 and EVENT='YKKCBH' and BIZID in (select ID from inserted))
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'YKKCBH','YK_KCPH',ID from inserted
	end
	
	--Add By Tany 2015-03-03 智能药库需要的事件
	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
	select 'YK_KCPH_ZNYK','YK_KCPH',ID from inserted
end
GO


