IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_ZY_ORDERRECORD_UPDATEFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_ZY_ORDERRECORD_UPDATEFOREVENTLOG]
GO
--Add By Tany 2014-04-16 状态变更插入事件表
CREATE TRIGGER TR_ZY_ORDERRECORD_UPDATEFOREVENTLOG
	ON ZY_ORDERRECORD 
	AFTER INSERT,UPDATE
AS   
SET NOCOUNT ON

declare @order_id uniqueidentifier
DECLARE @STATUS_FLAG INT
DECLARE @OLDSTATUS_FLAG INT
DECLARE @MNGTYPE INT
DECLARE @delete_bit smallint
declare @ntype int
declare @inpatient_id uniqueidentifier
declare @group_id bigint
declare @exec_dept bigint
declare @xmly int
declare @wzx_flag int --20140816 WXZ DC医嘱的时候同步取消
declare @hoitem_id bigint --20140825 处理自备和外来药
declare @exec_deptid bigint--20140825 处理自备和外来药
declare @dept_br bigint --20141119 记录病人科室，用于区分上了护士站的科室

--医嘱第一次被执行的时候，写一个医嘱审核的事件
IF (UPDATE(lastexecdate))  
BEGIN

	if exists(select 1 from inserted where order_id in (select order_id from deleted where lastexecdate is null))
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'n2oYzsh.HIS','zy_orderrecord',order_id 
		from inserted a where a.ntype not in (0,7) and a.order_id in (select order_id from deleted where lastexecdate is null)
			and a.order_id in (select b.order_id from zy_orderexec b where b.order_id=a.order_id)--Add By Tany 2014-11-26 只有新系统执行的才写事件
			and (a.dept_br in (select deptid from vi_zy_newhishsz) or a.dept_id in (select deptid from ss_dept))--Modify By Tany 2015-01-07 还包括手麻开单
		
		--如果有医技项目
		--Modify By Tany 2015-03-13 LIS审核暂时不用
		--if exists(select 1 from inserted where ntype=5)
		--begin
		--	insert into EVENTLOG(EVENT,CATEGORY,BIZID) --values('CancelNewOrder','zy_orderrecord',@order_id)
		--	select 'n2oYzsh.LIS','zy_jy_print',b.apply_no 
		--	from inserted a inner join zy_jy_print b on a.order_id=b.order_id
		--	where a.order_id in (select order_id from deleted where lastexecdate is null)
		--		and ISNULL(b.apply_no,'')<>''
		--		and a.order_id in (select c.order_id from zy_orderexec c where c.order_id=a.order_id)--Add By Tany 2014-11-26 只有新系统执行的才写事件
		--		and (a.dept_br in (select deptid from vi_zy_newhishsz) or a.dept_id in (select deptid from ss_dept))--Modify By Tany 2015-01-07 还包括手麻开单
		--end
	end

END

IF (UPDATE(delete_bit) or UPDATE(wzx_flag))  
BEGIN

	select top 1 @order_id=ORDER_ID,
		@STATUS_FLAG=STATUS_FLAG,
		@MNGTYPE=MNGTYPE,
		@delete_bit=DELETE_BIT,
		@ntype=NTYPE,
		@wzx_flag=wzx_flag --20140816 WXZ DC医嘱的时候同步取消
	from inserted

	--医嘱被删除了则插入取消事件  20140816 WXZ DC医嘱的时候同步取消
	IF (@delete_bit=1 and @STATUS_FLAG<>0 and @ntype not in (0,7)) or @wzx_flag>0 --20140816 WXZ DC医嘱的时候同步取消
	begin
		if @ntype=3
		begin
			insert into EVENTLOG(EVENT,CATEGORY,BIZID) --values('CancelNewOrder','zy_orderrecord',@order_id)
			select 'CancelNewOrder.HIS.ZCY','zy_orderrecord',order_id from inserted
		end
		else
		begin
			insert into EVENTLOG(EVENT,CATEGORY,BIZID) --values('CancelNewOrder','zy_orderrecord',@order_id)
			select 'CancelNewOrder.HIS','zy_orderrecord',order_id from inserted
		end
		
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'CancelNewOrder.EMR','zy_orderrecord',order_id from inserted
		return
	end

END

IF(UPDATE(STATUS_FLAG))
BEGIN

	select top 1 @order_id=ORDER_ID,
		@STATUS_FLAG=STATUS_FLAG,
		@MNGTYPE=MNGTYPE,
		@ntype=NTYPE,
		@group_id=GROUP_ID,
		@inpatient_id=INPATIENT_ID,
		@exec_dept=EXEC_DEPT,
		@xmly=XMLY,
		@wzx_flag=wzx_flag, --20140916 Modify By Tany DC医嘱的时候不写入事件
		@dept_br=dept_br
	from inserted
	
	if @wzx_flag>0
	begin
		return
	end

	select top 1 @OLDSTATUS_FLAG=isnull(status_flag,0) from deleted

	if (@STATUS_FLAG=1 and @MNGTYPE in (0,1,5) and @OLDSTATUS_FLAG<>2  --医嘱和账单都传递过去
		or @STATUS_FLAG=2 and @MNGTYPE in (0,1,5) and @OLDSTATUS_FLAG=0) --手麻保存的医嘱状态是从0变2
	begin
		--如果是草药，则只插入一条记录，并且时间名称不同
		if @ntype=3
		begin
			if not exists(select 1 from EVENTLOG where EVENT='NewOrder.HIS.ZCY' and BIZID=CONVERT(varchar(50),@inpatient_id)+'|'+CONVERT(varchar,@group_id))
			begin
				insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
				values('NewOrder.HIS.ZCY','zy_orderrecord',CONVERT(varchar(50),@inpatient_id)+'|'+CONVERT(varchar,@group_id))
			end
		end
		else
		begin
			insert into EVENTLOG(EVENT,CATEGORY,BIZID) --values('NewOrder','zy_orderrecord',@order_id)
			select 'NewOrder.HIS','zy_orderrecord',order_id from inserted where ntype not in (0,7) and delete_bit=0
		end

		--不管是否草药，EMR都需要
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'NewOrder.EMR','zy_orderrecord',order_id from inserted
		
		--Modify By Tany 2014-11-19 如果病人科室上了护士站，不需要这步操作
		if (@ntype=7 or (@xmly=1 and @exec_dept=-1)) and @dept_br not in (select deptid from vi_zy_newhishsz)
		begin
			--把状态直接改成5,停医嘱直接停掉，不需要转抄
			update zy_orderrecord set STATUS_FLAG=2 where order_id in (select ORDER_ID from inserted)
		end
		return
	end

	--如果是停止状态并且是长期医嘱，则插入停止事件
	--增加停账单
	if ((@STATUS_FLAG=3 and @MNGTYPE=0 and @OLDSTATUS_FLAG<>4) or (@STATUS_FLAG=4 and @MNGTYPE=2))
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) --values('StopOrder','zy_orderrecord',@order_id)
		select 'StopOrder.HIS','zy_orderrecord',order_id from inserted where ntype not in (0,7)
		union all
		select 'StopOrder.EMR','zy_orderrecord',order_id from inserted

		--把状态直接改成2,不需要转抄
		--Modify By Tany 2014-11-19 如果病人科室上了护士站，不需要这步操作
		if (@dept_br not in (select deptid from vi_zy_newhishsz))
		begin
			update zy_orderrecord set STATUS_FLAG=5 where order_id in (select ORDER_ID from inserted)
		end

		return
	end	

	--如果是从3转成2，则插入取消停
	if @STATUS_FLAG=2 and @MNGTYPE=0 and @OLDSTATUS_FLAG=3
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) --values('UNStopOrder','zy_orderrecord',@order_id)
		select 'UNStopOrder.HIS','zy_orderrecord',order_id from inserted where ntype not in (0,7)
		union all
		select 'UNStopOrder.EMR','zy_orderrecord',order_id from inserted
		return
	end	

	--如果是从1转成0，则插入删除
	if (@STATUS_FLAG=0 and @OLDSTATUS_FLAG=1) --or (@STATUS_FLAG=1 and @OLDSTATUS_FLAG=2)
	begin
		if @ntype=3
		begin
			insert into EVENTLOG(EVENT,CATEGORY,BIZID) --values('CancelNewOrder','zy_orderrecord',@order_id)
			select 'CancelNewOrder.HIS.ZCY','zy_orderrecord',order_id from inserted
		end
		else
		begin
			insert into EVENTLOG(EVENT,CATEGORY,BIZID) --values('CancelNewOrder','zy_orderrecord',@order_id)
			select 'CancelNewOrder.HIS','zy_orderrecord',order_id from inserted where ntype not in (0,7)
		end
		
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'CancelNewOrder.EMR','zy_orderrecord',order_id from inserted
		return
	end

END

--插入触发，用于直接插状态为1和2的医嘱
if not exists(select 1 from deleted)
begin
	select top 1 @order_id=ORDER_ID,
		@STATUS_FLAG=STATUS_FLAG,
		@MNGTYPE=MNGTYPE,
		@ntype=NTYPE,
		@group_id=GROUP_ID,
		@inpatient_id=INPATIENT_ID,
		@hoitem_id=hoitem_id,
		@exec_dept=exec_dept,
		@xmly=xmly
	from inserted

	if (@STATUS_FLAG=1 and @MNGTYPE in (0,1,5)  and ((@xmly=1 and @exec_dept>0) or @xmly=2)   ) or (@STATUS_FLAG=2 and @MNGTYPE in (2,3))
	begin
		--如果是草药，则只插入一条记录，并且时间名称不同
		if @ntype=3
		begin
			if not exists(select 1 from EVENTLOG where EVENT='NewOrder.HIS.ZCY' and BIZID=CONVERT(varchar(50),@inpatient_id)+'|'+CONVERT(varchar,@group_id))
			begin
				insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
				values('NewOrder.HIS.ZCY','zy_orderrecord',CONVERT(varchar(50),@inpatient_id)+'|'+CONVERT(varchar,@group_id))
			end
		end
		else
		begin
			insert into EVENTLOG(EVENT,CATEGORY,BIZID) --values('NewOrder','zy_orderrecord',@order_id)
			select 'NewOrder.HIS','zy_orderrecord',order_id from inserted where ntype not in (0,7) and delete_bit=0
		end

		--不管是否草药，EMR都需要
		insert into EVENTLOG(EVENT,CATEGORY,BIZID)
		select 'NewOrder.EMR','zy_orderrecord',order_id from inserted
		return
	end
end