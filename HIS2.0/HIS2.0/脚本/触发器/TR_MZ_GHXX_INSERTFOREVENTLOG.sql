IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_MZ_GHXX_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_MZ_GHXX_INSERTFOREVENTLOG]
GO
--Add By Tany 2015-08-31 新增挂号信息
--CREATE TRIGGER [dbo].[TR_MZ_GHXX_INSERTFOREVENTLOG]
--	ON [dbo].[MZ_GHXX] 
--	AFTER INSERT
--AS   
--SET NOCOUNT ON

--	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
--	--select 'n2oBrGhxx.HIS','MZ_GHXX',ghxxid 
--	--from inserted
--	--where bqxghbz=0
--	--union all
--	select 'GetMzGh.EMR','MZ_GHXX',ghxxid 
--	from inserted
--	where bqxghbz=0 and isnull(sgbh,'')<>''

--GO


