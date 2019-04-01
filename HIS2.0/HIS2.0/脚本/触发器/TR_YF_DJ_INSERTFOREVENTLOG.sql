IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_YF_DJ_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_YF_DJ_INSERTFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
CREATE TRIGGER [dbo].[TR_YF_DJ_INSERTFOREVENTLOG]
	ON [dbo].[YF_DJ] 
	AFTER INSERT,UPDATE
AS   
SET NOCOUNT ON

declare @shbz int
declare @ywlx varchar(3)

select @shbz=shbz,@ywlx=ywlx from inserted

if(UPDATE(shbz))
begin
	if(@ywlx in ('001','002') and @shbz=0)
	begin
	
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'YF_DJ','YF_DJ',ID from inserted

	end
	--else if(@ywlx not in ('001','002') and @shbz=1)
	else if(@ywlx not in ('001','002','009','005','012') and @shbz=1)
	begin
	
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'YF_DJ','YF_DJ',ID from inserted

	end
end


