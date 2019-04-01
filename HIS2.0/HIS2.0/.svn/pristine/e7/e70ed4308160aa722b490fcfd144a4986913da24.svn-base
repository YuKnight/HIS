IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ZY_UNTRANSDATA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ZY_UNTRANSDATA]
GO

CREATE PROCEDURE [dbo].[SP_ZY_UNTRANSDATA]
(
	@INPATIENT_ID UNIQUEIDENTIFIER,
	@ERROR nvarchar(50)
) 
 AS
  /*--------------------------------------------------------------------------
作者：Tany 2010-10-22
说明：住院部分数据转移回当前表
--------------------------------------------------------------------------*/
BEGIN
	declare @oldrowcount bigint 
	declare @newrowcount bigint 

	set @ERROR='执行成功'
	----------------------------
	begin tran

	--转移费用表
	insert into zy_fee_speci(ID, INPATIENT_ID, BABY_ID, ORDER_ID, ORDEREXEC_ID, PRESCRIPTION_ID, PRESC_NO, PRESC_DATE, BOOK_DATE, BOOK_USER, STATITEM_CODE, TCID, TC_FLAG, XMID, XMLY, SUBCODE, ITEM_NAME, GG, CJ, UNIT, UNITRATE, COST_PRICE, RETAIL_PRICE, NUM, DOSAGE, SDVALUE, AGIO, ACVALUE, QDRQ, CHARGE_BIT, CHARGE_DATE, CHARGE_USER, DELETE_BIT, CZ_FLAG, CZ_ID, TYPE, DISCHARGE_BIT, DISCHARGE_ID, SCBZ, DOC_ID, DEPT_ID, DEPT_BR, EXECDEPT_ID, DEPT_LY, GROUP_ID, TLFS, APPLY_ID, FY_BIT, FY_DATE, FY_USER, PY_USER, BZ, JGBM, GCYS, ZFBL, YBJS_BIT, YBJS_ID, KCID, is_PvsScn, pvs_xh, pvs_zdb)
	select ID, INPATIENT_ID, BABY_ID, ORDER_ID, ORDEREXEC_ID, PRESCRIPTION_ID, PRESC_NO, PRESC_DATE, BOOK_DATE, BOOK_USER, STATITEM_CODE, TCID, TC_FLAG, XMID, XMLY, SUBCODE, ITEM_NAME, GG, CJ, UNIT, UNITRATE, COST_PRICE, RETAIL_PRICE, NUM, DOSAGE, SDVALUE, AGIO, ACVALUE, QDRQ, CHARGE_BIT, CHARGE_DATE, CHARGE_USER, DELETE_BIT, CZ_FLAG, CZ_ID, TYPE, DISCHARGE_BIT, DISCHARGE_ID, SCBZ, DOC_ID, DEPT_ID, DEPT_BR, EXECDEPT_ID, DEPT_LY, GROUP_ID, TLFS, APPLY_ID, FY_BIT, FY_DATE, FY_USER, PY_USER, '历史库转回', JGBM, GCYS, ZFBL, YBJS_BIT, YBJS_ID, KCID, is_PvsScn, pvs_xh, pvs_zdb
	from zy_fee_speci_h
	where inpatient_id=@INPATIENT_ID
	set @oldrowcount = @@rowcount
	--删除费用表
	delete zy_fee_speci_h where inpatient_id=@INPATIENT_ID
	set @newrowcount = @@rowcount
	--核对转移记录数
	if(@oldrowcount <> @newrowcount)
	begin
		rollback
		set @ERROR='转移费用表失败'
		return
	end
----------------------------------------------------------------

	--转移处方表
	insert into zy_prescription--(ID, SOURCE_ID, INPATIENT_ID, PRESC_NO, DEPT_ID, EXECDEPT_ID, XMLY, HDITEM_ID, STATITEM_CODE, TCID, TC_FLAG, PRESC_DATE, PRESC_DOC, STANDARD, UNIT, UNITRATE, PRICE, AGIO, NUM, DOSAGE, BABY_ID, SUBCODE, CHARGE_BIT, BOOK_DATE, BOOK_USER, TYPE, ORDER_ID, JGBM)
	select *--ID, SOURCE_ID, INPATIENT_ID, PRESC_NO, DEPT_ID, EXECDEPT_ID, XMLY, HDITEM_ID, STATITEM_CODE, TCID, TC_FLAG, PRESC_DATE, PRESC_DOC, STANDARD, UNIT, UNITRATE, PRICE, AGIO, NUM, DOSAGE, BABY_ID, SUBCODE, CHARGE_BIT, BOOK_DATE, BOOK_USER, TYPE, ORDER_ID, JGBM 
	from zy_prescription_h
	where inpatient_id=@INPATIENT_ID
	SET @oldrowcount = @@rowcount
	--删除处方表
	delete zy_prescription_h where inpatient_id=@INPATIENT_ID
	SET @newrowcount = @@rowcount
	--核对转移记录数
	if(@oldrowcount <> @newrowcount)
	begin
		rollback
		set @ERROR='转移处方表失败'
		return
	end
----------------------------------------------------------------

	--转移医嘱表
	insert into zy_orderrecord--(ORDER_ID, INPATIENT_ID, BABY_ID, WARD_ID, DEPT_BR, DEPT_ID, MNGTYPE, ORDER_DOC, ORDER_BDATE, NTYPE, GROUP_ID, SERIAL_NO, HOITEM_ID, XMLY, ITEM_CODE, ORDER_CONTEXT, NUM, DOSAGE, UNIT, DWLX, ORDER_SPEC, ORDER_USAGE, FREQUENCY, DROPSPER, EXEC_DEPT, FIRST_TIMES, TERMINAL_TIMES, AUDITING_USER, AUDITING_DATE, AUDITING_USER1, AUDITING_DATE1, AUDITING_USER2, AUDITING_DATE2, ORDER_EDATE, ORDER_EDOC, ORDER_EUSER, ORDER_EUDATE, ORDER_EUSER1, ORDER_EUDATE1, ORDER_EUSER2, ORDER_EUDATE2, STATUS_FLAG, OPERATOR, BOOK_DATE, DELETE_BIT, PS_FLAG, PS_ORDERID, PS_USER, WZX_FLAG, JZ_FLAG, PRICE, MEMO, MEMO1, ssmz_print, JGBM, ISKDKSLY, LASTEXECDATE, LASTEXECUSER, DEL_PRINT)
	select *--ORDER_ID, INPATIENT_ID, BABY_ID, WARD_ID, DEPT_BR, DEPT_ID, MNGTYPE, ORDER_DOC, ORDER_BDATE, NTYPE, GROUP_ID, SERIAL_NO, HOITEM_ID, XMLY, ITEM_CODE, ORDER_CONTEXT, NUM, DOSAGE, UNIT, DWLX, ORDER_SPEC, ORDER_USAGE, FREQUENCY, DROPSPER, EXEC_DEPT, FIRST_TIMES, TERMINAL_TIMES, AUDITING_USER, AUDITING_DATE, AUDITING_USER1, AUDITING_DATE1, AUDITING_USER2, AUDITING_DATE2, ORDER_EDATE, ORDER_EDOC, ORDER_EUSER, ORDER_EUDATE, ORDER_EUSER1, ORDER_EUDATE1, ORDER_EUSER2, ORDER_EUDATE2, STATUS_FLAG, OPERATOR, BOOK_DATE, DELETE_BIT, PS_FLAG, PS_ORDERID, PS_USER, WZX_FLAG, JZ_FLAG, PRICE, MEMO, MEMO1, ssmz_print, JGBM, ISKDKSLY, LASTEXECDATE, LASTEXECUSER, DEL_PRINT 
	from zy_orderrecord_h
	where inpatient_id=@INPATIENT_ID
	SET @oldrowcount = @@rowcount

	--删除医嘱表
	delete zy_orderrecord_h where inpatient_id=@INPATIENT_ID
	SET @newrowcount = @@rowcount
	--核对转移记录数
	if(@oldrowcount <> @newrowcount)
	begin
		rollback
		set @ERROR='转移医嘱表失败'
		return
	end
----------------------------------------------------------------

	--转移医嘱执行表
	insert into zy_orderexec--(ID, ORDER_ID, BOOK_DATE, EXECDATE, EXEUSER, ISANALYZED, PRESCRIPTION_ID, INPATIENT_ID, BABY_ID, REALEXECDATE, REALEXEUSER, JGBM)
	select *--ID, ORDER_ID, BOOK_DATE, EXECDATE, EXEUSER, ISANALYZED, PRESCRIPTION_ID, INPATIENT_ID, BABY_ID, REALEXECDATE, REALEXEUSER, JGBM 
	from zy_orderexec_h 
	where inpatient_id=@INPATIENT_ID
	SET @oldrowcount = @@rowcount
	--删除医嘱执行表
	delete zy_orderexec_h where inpatient_id=@INPATIENT_ID
	SET @newrowcount = @@rowcount
	--核对转移记录数
	if(@oldrowcount <> @newrowcount)
	begin
		rollback
		set @ERROR='转移医嘱执行表失败'
		return
	end		
----------------------------------------------------------------
	--更新已经转历史表的记录的结算表状态
	update zy_discharge set nstatus=0 where inpatient_id=@INPATIENT_ID and nstatus=1

	commit
	
END






GO


