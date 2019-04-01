IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[SP_YJ_INTERFACE_YJQF]') AND TYPE IN (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YJ_INTERFACE_YJQF]
go
/*
Create By Tany 2015-06-08 外部调用住院医技确费
*/
create PROCEDURE [dbo].[SP_YJ_INTERFACE_YJQF]
 (
  @inpatient_id varchar(50),--病人ID
  @txm varchar(50), --检查号
  @type int,--类型 0=检验 1=检查
  @EXEUSERName  varchar(50),--确认人,
  @ReturnChar varchar(200) output
 ) 
AS
set nocount on

DECLARE @YJ_EXEC_ID UNIQUEIDENTIFIER --执行医嘱id
DECLARE @YJ_ORDER_ID UNIQUEIDENTIFIER --医嘱id
DECLARE @YJ_JE DECIMAL(18,2)--医技金额
DECLARE @DEPTID int --执行科室
declare @QrDATE DATETIME --确认日期
declare @OUTCODE INT  
declare  @OUTMSG VARCHAR(200)
declare @EXEUSER int  
declare @yjsqid as UNIQUEIDENTIFIER
declare @cs_txm as UNIQUEIDENTIFIER
set @QrDATE=GETDATE()
set @OUTCODE=0
set @OUTMSG=''
 
set @ReturnChar='不成功'
if(CHARINDEX('{',@txm)>=0)
	set @txm=REPLACE(@txm,'{','')
if(CHARINDEX('}',@txm)>=0)
	set @txm=REPLACE(@txm,'}','')

--获得确认人姓名
if ISNUMERIC(@EXEUSERName)=1
begin
	set @EXEUSER=@EXEUSERName
end
else
begin
	set @EXEUSER= isnull( ( select top 1 EMPLOYEE_ID from JC_EMPLOYEE_PROPERTY  where  NAME=@EXEUSERName),-1)
end

declare @qrrq datetime
set @qrrq=GETDATE()

--获得确认人姓名
set @EXEUSER= isnull( ( select top 1 EMPLOYEE_ID from JC_EMPLOYEE_PROPERTY  where  NAME=@EXEUSERName),-1)

DECLARE @NEWYJSQID UNIQUEIDENTIFIER
DECLARE @ERRCODE INT
DECLARE @ERRTEXT VARCHAR(50)

if @type=0
begin
	DECLARE T0 CURSOR FOR  
	select yjsqid 
	from YJ_ZYSQ aa 
	left join dbo.ZY_ORDERRECORD AS rr ON aa.YZID = rr.ORDER_ID 
	inner join dbo.ZY_JY_PRINT ww on rr.INPATIENT_ID=ww.INPATIENT_ID and ww.ORDER_ID=rr.ORDER_ID 
	where cast(ww.apply_no as varchar(50))=@txm
	and (@inpatient_id='' or aa.INPATIENT_ID=@inpatient_id)

	open T0
	FETCH NEXT FROM T0  into @yjsqid
	if @@FETCH_STATUS=-1
	begin
		set @ReturnChar='未找到有效的医技申请信息，请确认病区已经执行该病人医嘱！'
		CLOSE T0  
		DEALLOCATE T0 
		return 
	end
	WHILE @@FETCH_STATUS = 0 
	begin
		select  @DEPTID=ZXKS , @YJ_EXEC_ID=ZXID,@YJ_ORDER_ID=YZID,@YJ_JE=JE 
		from YJ_ZYSQ a  where yjsqid=@yjsqid

		--如果没有记账了才需要确认医技
		IF (SELECT TOP 1 CHARGE_BIT FROM ZY_FEE_SPECI WHERE ORDER_ID=@YJ_ORDER_ID AND ORDEREXEC_ID=@YJ_EXEC_ID AND [TYPE]=1)=0
		BEGIN
			SET @NEWYJSQID = DBO.FUN_GETEMPTYGUID()
			SET @ERRCODE = -1
			SET @ERRTEXT = ''
			EXEC SP_YJ_SAVE_QRJL @YJ_ORDER_ID,@yjsqid,@YJ_JE,@DEPTID,@QrDATE,@EXEUSER,1,@QrDATE,0,'',@NEWYJSQID OUTPUT,@ERRCODE OUTPUT,@ERRTEXT OUTPUT,@YJ_EXEC_ID,0
			if @ERRCODE=0
				set @ReturnChar='成功'
			else 
			begin
				set @ReturnChar=@ERRTEXT
				CLOSE T0  
				DEALLOCATE T0 
				return 
			end
		END
		else 
			set @ReturnChar='成功'

		FETCH NEXT FROM T0  into @yjsqid
	end
	CLOSE T0  
	DEALLOCATE T0 
end

if @type=1
begin
	DECLARE T1 CURSOR FOR  
	select yjsqid 
	from YJ_ZYSQ aa left join dbo.ZY_ORDERRECORD AS rr ON aa.YZID = rr.ORDER_ID 
		inner join dbo.ZY_JC_RECORD ww on rr.INPATIENT_ID=ww.INPATIENT_ID and ww.HOITEM_ID=rr.HOITEM_ID and ww.GROUP_ID=rr.GROUP_ID 
	where cast(ww.jc_no as varchar(50))= @txm
	and (@inpatient_id='' or aa.INPATIENT_ID=@inpatient_id)

	open T1
	FETCH NEXT FROM T1  into @yjsqid
	if @@FETCH_STATUS=-1
	begin
		set @ReturnChar='未找到有效的医技申请信息，请确认病区已经执行该病人医嘱！'
		CLOSE T1  
		DEALLOCATE T1 
		return 
	end
	WHILE @@FETCH_STATUS = 0 
	begin
		select  @DEPTID=ZXKS , @YJ_EXEC_ID=ZXID,@YJ_ORDER_ID=YZID,@YJ_JE=JE 
		from YJ_ZYSQ a  where yjsqid=@yjsqid

		--如果没有记账了才需要确认医技
		IF (SELECT TOP 1 CHARGE_BIT FROM ZY_FEE_SPECI WHERE ORDER_ID=@YJ_ORDER_ID AND ORDEREXEC_ID=@YJ_EXEC_ID AND [TYPE]=1)=0
		BEGIN
			SET @NEWYJSQID = DBO.FUN_GETEMPTYGUID()
			SET @ERRCODE = -1
			SET @ERRTEXT = ''
			EXEC SP_YJ_SAVE_QRJL @YJ_ORDER_ID,@yjsqid,@YJ_JE,@DEPTID,@QrDATE,@EXEUSER,1,@QrDATE,0,'',@NEWYJSQID OUTPUT,@ERRCODE OUTPUT,@ERRTEXT OUTPUT,@YJ_EXEC_ID,0
			if @ERRCODE=0
				set @ReturnChar='成功'
			else 
			begin
				set @ReturnChar=@ERRTEXT
				CLOSE T1  
				DEALLOCATE T1 
				return 
			end
		END
		else 
			set @ReturnChar='成功'

		FETCH NEXT FROM T1  into @yjsqid
	end
	CLOSE T1  
	DEALLOCATE T1 
end