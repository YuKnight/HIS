IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_YF_KCPH_UPDATEFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_YF_KCPH_UPDATEFOREVENTLOG]
GO
--Add By Tany 2015-01-19 禁用库存或启用库存的时候使用
CREATE TRIGGER [dbo].[TR_YF_KCPH_UPDATEFOREVENTLOG]
	ON [dbo].[YF_KCPH] 
	AFTER UPDATE
AS   
SET NOCOUNT ON

if(UPDATE(bdelete))
begin
	if exists(select 1 from inserted a inner join deleted b on a.id=b.id and a.bdelete<>b.bdelete)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'KCBH','YF_KCPH',ID from inserted
	end
end

if(UPDATE(ykbdelete))
begin
	if exists(select 1 from inserted a inner join deleted b on a.id=b.id and a.ykbdelete<>b.ykbdelete)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'KCBH','YF_KCPH',ID from inserted
	end
end
GO