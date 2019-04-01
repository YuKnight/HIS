IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_YF_TLD_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_YF_TLD_INSERTFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
--CREATE TRIGGER [dbo].[TR_YF_TLD_INSERTFOREVENTLOG]
--	ON [dbo].[YF_TLD] 
--	AFTER INSERT
--AS   
--SET NOCOUNT ON

--declare @lylx int
--declare @deptid int

--select @lylx=LYLX,@deptid=DEPTID from inserted


--if(@lylx=1 and @deptid=359)
--begin
	
--	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
--	select 'yf_tld_tsbyj','YF_TLD',GROUPID from inserted

--end


