IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_YF_RKSQ_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_YF_RKSQ_INSERTFOREVENTLOG]
GO
--Add By Tany 2014-03-04 状态变更插入事件表
CREATE TRIGGER [dbo].[TR_YF_RKSQ_INSERTFOREVENTLOG]
	ON [dbo].[YF_RKSQ] 
	AFTER INSERT,UPDATE
AS   
SET NOCOUNT ON

declare @shbz int
declare @ywlx varchar(3)

select @shbz=shbz,@ywlx=ywlx from inserted

if(@ywlx in ('013') and @shbz=0)
begin
	 
	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
	select 'YP_QLD_ZNYK','YF_RKSQ',ID from inserted

end



