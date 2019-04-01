IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_YP_YPCJD_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_YP_YPCJD_INSERTFOREVENTLOG]
GO
CREATE TRIGGER [dbo].[TR_YP_YPCJD_INSERTFOREVENTLOG]
	ON [dbo].[YP_YPCJD] 
	AFTER INSERT,UPDATE
AS   
SET NOCOUNT ON
	
	--如果1分钟内有未完成的事件，则不产生新的事件
	if not exists(select 1 from EVENTLOG where FINISH=0 and EVENT='YP_YPCJD' and TS>=DATEADD(mi,-1,getdate()) and BIZID in (select CJID from inserted))
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'YP_YPCJD','YP_YPCJD',CJID from inserted
		union all
		select 'YP_YPCJD_KF','YP_YPCJD',CJID from inserted
		union all
		select 'YP_YPCJD_PIVAS','YP_YPCJD',CJID from inserted where n_yplx in (1,2) --PIVAS Add By Tany 2014-11-03
	end

GO


