IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_YF_TJ_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_YF_TJ_INSERTFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
CREATE TRIGGER [dbo].[TR_YF_TJ_INSERTFOREVENTLOG]
	ON [dbo].[YF_TJ] 
	AFTER INSERT,UPDATE
AS   
SET NOCOUNT ON

declare @wcbj int

select @wcbj=wcbj from inserted
if(@wcbj=1)
begin
	
	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
	select 'YPTJ','YF_TJ',ID from inserted where deptid in (select deptid from YP_YJKS where KSLX='药库')

end


