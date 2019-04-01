IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_YK_DJMX_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_YK_DJMX_INSERTFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
CREATE TRIGGER [dbo].[TR_YK_DJMX_INSERTFOREVENTLOG]
	ON [dbo].[YK_DJMX] 
	AFTER INSERT
AS   
SET NOCOUNT ON

declare @ywlx varchar(3)

select @ywlx=ywlx from inserted

if(@ywlx = '005')
begin
	
	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
	select 'YKKCBH','YK_DJMX',ID from YK_KCPH where CJID in (select CJID from inserted)

end


