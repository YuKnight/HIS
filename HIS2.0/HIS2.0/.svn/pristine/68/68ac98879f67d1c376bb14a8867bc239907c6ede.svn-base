IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_mz_datasynclog_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_mz_datasynclog_INSERTFOREVENTLOG]
GO
--Add By Tany 2015-11-12 新增数据同步时出错的，走平台事件
CREATE TRIGGER [dbo].[TR_mz_datasynclog_INSERTFOREVENTLOG]
	ON [dbo].[mz_datasynclog] 
	AFTER INSERT
AS   
SET NOCOUNT ON

	if exists(select 1 from inserted where charindex('Could not do a physical-order read to fetch next row',errorInfo)>0)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select syncType,'mz_datasynclog',InputVal
		from inserted
	end

GO


