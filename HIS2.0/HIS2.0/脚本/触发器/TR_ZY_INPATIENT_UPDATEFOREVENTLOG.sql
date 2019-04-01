IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_ZY_INPATIENT_UPDATEFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_ZY_INPATIENT_UPDATEFOREVENTLOG]
GO
--Add By Tany 2014-10-29 状态变更插入事件表
CREATE TRIGGER TR_ZY_INPATIENT_UPDATEFOREVENTLOG
	ON ZY_INPATIENT 
	AFTER UPDATE
AS   
SET NOCOUNT ON

declare @bed_id uniqueidentifier
declare @oldbed_id uniqueidentifier
declare @zy_doc bigint
declare @flag bigint
declare @oldflag bigint
declare @out_date datetime --Add By Tany 2015-04-07
declare @oldout_date datetime --Add By Tany 2015-04-07

--触发的事件是需要按照先后排序的，不能乱顺序 Modify By Tany 2014-11-01
IF(UPDATE(flag))
BEGIN
	select @flag=flag
	from inserted
	
	select @oldflag=flag
	from deleted

	--当病人状态变成5并且不是从2,6变成的5，则表示这个病人出区了
	IF @flag=5 and @oldflag not in (2,6)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'n2oCq.HIS','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
		union all
		select 'n2oCq.LIS','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
		union all
		select 'n2oCq.EMR','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
	end	
	--如果病人原来的状态是5但是现在的状态不是2,6，则表示病人取消出区了
	if @oldflag=5 and @flag not in (2,6)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'n2oQxcq.HIS','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
	end
END

IF(UPDATE(bed_id))
BEGIN
	select @bed_id=bed_id
	from inserted
	
	select @oldbed_id=bed_id
	from deleted


	--老床号为空就是分配床位
	IF isnull(@bed_id,dbo.FUN_GETEMPTYGUID())<>dbo.FUN_GETEMPTYGUID() and isnull(@oldbed_id,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'n2oFpcw.HIS','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
		union all
		select 'n2oFpcw.EMR','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
	end
	--老床号不为空就是转床
	else if isnull(@bed_id,dbo.FUN_GETEMPTYGUID())<>dbo.FUN_GETEMPTYGUID() and isnull(@oldbed_id,dbo.FUN_GETEMPTYGUID())<>dbo.FUN_GETEMPTYGUID()
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'n2oZc.HIS','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
		union all
		select 'n2oZc.EMR','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
	end
END

IF(UPDATE(zy_doc))
BEGIN
	select @zy_doc=zy_doc
	from inserted

	IF isnull(@zy_doc,0)>0
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'n2oFpgcxx.HIS','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
		union all --Add By Tany 2015-07-28 增加iCall的管床医生事件
		select 'GetICallGcysInfo','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
	end
END

--Add By Tany 2015-04-07 出院日期变化事件
IF(UPDATE(out_date))
BEGIN
	select @out_date=out_date
	from inserted
	
	select @oldout_date=out_date
	from deleted


	--出院日期原来为空，现在不为空，则是出院事件
	IF @out_date is not null and @oldout_date is null
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'n2oCysj.HIS','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
	end
	--出院日期为空，原来不为空，则是取消出院事件
	else if @out_date is null and @oldout_date is not null
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'n2oQxcysj.HIS','ZY_INPATIENT',inpatient_id from inserted where dept_id in (select deptid from vi_zy_newhishsz)
	end
END