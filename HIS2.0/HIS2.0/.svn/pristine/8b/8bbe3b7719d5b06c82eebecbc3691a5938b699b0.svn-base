IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_YF_KCPH_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_YF_KCPH_INSERTFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
--CREATE TRIGGER [dbo].[TR_YF_KCPH_INSERTFOREVENTLOG]
--	ON [dbo].[YF_KCPH] 
--	AFTER INSERT,UPDATE
--AS   
--SET NOCOUNT ON

----上一个加一个药房的deptid
--if not exists(select 1 from inserted where DEPTID in (399,566,567,142,418,424,417,378,359,207,570))--142,399,424,418,417,359,207,378
--	return;

--if(UPDATE(kcl))
--begin
--	if not exists(select 1 from EVENTLOG where FINISH=0 and EVENT='KCBH' and TS>=DATEADD(mi,-1,getdate()) and BIZID in (select ID from inserted))
--	begin
--		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
--		select 'KCBH','YF_KCPH',ID from inserted
--	end
--end
--GO


