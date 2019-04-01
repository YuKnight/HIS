IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_MZ_GHXX_UPDATEFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_MZ_GHXX_UPDATEFOREVENTLOG]
GO
--Add By Tany 2015-08-31 取消挂号
CREATE TRIGGER [dbo].[TR_MZ_GHXX_UPDATEFOREVENTLOG]
	ON [dbo].[MZ_GHXX] 
	AFTER UPDATE
AS   
SET NOCOUNT ON

if(UPDATE(bqxghbz))
begin

	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
	--select 'n2oBrTh.HIS','MZ_GHXX',ghxxid 
	--from inserted
	--where bqxghbz=1
	--union all
	select 'GetMzTh.EMR','MZ_GHXX',ghxxid 
	from inserted
	where bqxghbz=1

end

if(UPDATE(sgbh))
begin

	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
	--select 'n2oBr.HIS','MZ_GHXX',ghxxid 
	--from inserted
	--where bqxghbz=0 and sgbh is not null and sgbh !=''
	--union all
	select 'GetMzGh.EMR','MZ_GHXX',ghxxid 
	from inserted
	where bqxghbz=0 and sgbh is not null and sgbh !=''

end

--Modify By Tany 2016-01-05
--如果更新了科室，表示换号了，首先EMR取消挂号，然后再EMR挂号，老HIS更新
--把这个事件放门诊平台
if(update(ghks) or update(ghys) or update(ghsj))
begin
	
	declare @oldks int
	declare @newks int
	declare @oldys int
	declare @newys int
	declare @oldsj datetime
	declare @newsj datetime
	
	select @oldks=ghks,@oldys=ghys,@oldsj=ghsj from deleted
	select @newks=ghks,@newys=ghys,@newsj=ghsj from inserted
	if @oldks<>@newks or (@oldys<>@newys and @newys<>-1) or @oldsj<>@newsj
	begin
		insert into EVENTLOG_MZ(EVENT,CATEGORY,BIZID) 
		select 'GetMzUpdateGh.EMR','MZ_GHXX',ghxxid 
		from inserted
		union all
		--insert into EVENTLOG_MZ(EVENT,CATEGORY,BIZID) 
		--select 'GetMzGh.EMR','MZ_GHXX',ghxxid 
		--from inserted
		--where bqxghbz=0 and sgbh is not null and sgbh !=''
		
		--insert into EVENTLOG_MZ(EVENT,CATEGORY,BIZID) 
		select 'n2oUpdateGhxx.HIS','MZ_GHXX',ghxxid 
		from inserted
	end
	
end

GO