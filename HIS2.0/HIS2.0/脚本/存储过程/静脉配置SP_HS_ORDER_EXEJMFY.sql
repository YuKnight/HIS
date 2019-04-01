
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_HS_ORDER_EXEJMFY' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_HS_ORDER_EXEJMFY
GO
--静脉配置中心调用用于 计费和冲正
CREATE PROCEDURE SP_HS_ORDER_EXEJMFY
  @V_INPATIENTID uniqueidentifier, --病人ID (visitid)
  @V_BABYID BIGINT, -- 0
  @V_ORDERID uniqueidentifier, --医嘱ID yzxh
  @V_EXECDEPT_ID BIGINT, --药房ID execdept_id (yfid)
  @V_HOITEM_ID BIGINT, ---医嘱项目ID(收费项目ID XM)------------------
  @V_EXEUSER BIGINT, --
  @V_NUM decimal(18, 4), ---数量 shl  INTEGER
  @V_CZ_FLAG INTEGER, --
  @V_CZ_FEEID uniqueidentifier, --BIGINT  被冲正的费用ID
  @V_BARCODE VARCHAR(50), --条形码
  @V_NEW_FEEID uniqueidentifier output, --费用ID
  @ERR_CODE INTEGER output, 
  @ERR_TEXT VARCHAR(100)output
as
	  
    declare @v_HSITEM_ID bigint;--收费项目ID
	DECLARE @SQLCODE INT 
	declare @V_STATITEM_CODE varchar(12)--大项目代码 
	declare @V_TCID smallint--套餐ID
	declare @V_TC_FLAG smallint--是否套餐
	declare @V_PRICE decimal(18,4)--单价
	declare @V_ITEM_NAME VARCHAR(100)--项目名称
	declare @V_SUBCODE VARCHAR(20)--项目代码
	declare @v_unit VARCHAR(50)	--单位
	declare @v_cost_price decimal(18,4)--零售价
	declare @v_retail_Price decimal(18,4)--实际零售价
	declare @v_sdValue decimal(18,2)--应付金额
	declare @v_acValue decimal(18,2)--实际金额
	declare @v_presc_no decimal(21,6)--处方号
	declare @v_newfeeid uniqueidentifier --新增的当前费用ID
		--set @v_newfeeid=dbo.FUN_GETEMPTYGUID()
	declare @V_CZFLAG_SAVE int;--要插入费用表的冲正标志
	declare @v_CZ_ID_SAVE uniqueidentifier;--要插入费用表的被冲正ID
	declare @v_yczcs int--已冲正次数
	declare @v_kczcs int--可冲正次数
	declare @v_barcodecount int ---当前条码的费用记录数
	declare @v_barFeeID uniqueidentifier --已存在的条码表的FeeID
	declare @v_odocid bigint--下嘱医生
    declare @v_odeptid bigint--开单科室
    declare @v_wdeptid bigint--病区
	declare @v_dept_br bigint--病人科室

 	set @v_HSITEM_ID=0;--收费项目ID
	set @v_presc_no=0
	set @V_STATITEM_CODE=''--大项目
	set @V_TCID=0--套餐ID
	set @V_TC_FLAG=0--是否套餐
	set @V_PRICE=0
	set @V_ITEM_NAME=''
	set @V_SUBCODE=''
	set @v_unit=''
	set @v_cost_price=0
	set @v_retail_Price=0
	set @v_sdValue=0
	set @v_acValue=0
	set @v_kczcs=0
	set @v_yczcs=0
	set @v_barFeeID=dbo.FUN_GETEMPTYGUID()
	set @v_barcodecount=0
		
set @err_code=-1
---已出区出院的病人不能再传费用，或His已结算，或医保已结算
if not exists(select * from zy_inpatient where inpatient_id=@v_InpatientID and flag not in (2,5,6) and is_ybjs=0) 
begin 
 set @Err_Code=1
 set @err_text='该病人已出区或出院或医保已结算，不能进行费用增加和冲正操作'
 return
end

-----冲正判断------
if @v_cz_flag>0  AND @V_NUM>=0
BEGIN
	set @err_text='冲正的数量应该为小于零';
	return;
END
 
if @v_cz_FeeID<>dbo.FUN_GETEMPTYGUID() --正常的冲正入参，做冲正操作
begin 	 
	 if not exists(select * from zy_fee_speci where inpatient_id=@v_InpatientID and id=@v_cz_FeeID and delete_bit=0) 
	 begin 
	    set @err_text='冲正的原费用ID不存在';
		return;
	 end 
	 
	 
	 set @v_yczcs=(select sum(num) from zy_fee_speci where inpatient_id=@v_InpatientID and cz_id=@v_cz_FeeID and delete_bit=0);--已冲正次数
	 set @v_kczcs=(select sum(num) from zy_fee_speci where inpatient_id=@v_InpatientID and id=@v_cz_FeeID and delete_bit=0);--可冲正次数	
	 					 				 
	 --已冲正数量+本次数量>可冲正数量，则不可冲正
	 if (@v_yczcs+@v_num)*-1>@v_kczcs 
	 begin
	    set @err_text='已冲正次数已达到可冲正次数';
		return;
	 end  
	 
  	 set @V_CZFLAG_SAVE=2;
	 set @v_CZ_ID_SAVE=@v_cz_FeeID;
end 
else
begin
	set @V_CZFLAG_SAVE=0;
	set @v_CZ_ID_SAVE=null
end

		  
		  
--获取项目表的相关信息		  
SELECT  top 1 
@v_HSITEM_ID=hditem_id, @V_STATITEM_CODE=h.bigitemcode,@V_ITEM_NAME=H.ITEMNAME,@V_SUBCODE=H.ITEMCODE,
@V_TCID=r.tcid,@V_TC_FLAG=r.tc_flag,@v_unit=unit,@v_cost_price=h.price,@v_retail_Price=h.price,
@v_sdValue=h.price*@v_num,@v_acValue=round(h.price*@v_num,2) 
FROM JC_HOI_HDI r inner join VI_JC_ITEMS h
on h.itemid=r.hditem_id and h.tcid=r.tcid and r.hoitem_id =@V_HOITEM_ID  and JGBM=1001

--新插入的费用的ID 用于zy_fee_speci
set @V_NEW_FEEID=dbo.FUN_GETGUID(newid(),getdate())
	
--查询该条码是否已记过费					   
select top 1 @v_barcodecount=1,@v_barFeeID=a.ID from zy_fee_speci a inner join
zy_fy_jmpz b on a.ID=b.fyid 
WHERE b.txm=@v_barcode and @v_cz_flag=0 

--如果是记正数且zy_fy_jmpz表没有记录 或者是记负数费用
if ((@v_barcodecount=0 or @v_barcodecount is null ) and @V_CZ_FLAG=0)  or @V_CZ_FLAG=2
begin
	--获取原医嘱相关信息
	select @v_odocid=order_doc,@v_odeptid=dept_id,@v_dept_br=dept_br,
	@v_wdeptid=(select dept_id from jc_ward where ward_id=zy_orderrecord.ward_id) 
	FROM zy_orderrecord where inpatient_id=@v_InpatientID and order_id=@v_orderid	 
	
	INSERT INTO ZY_Fee_speci
				(   ID,
					Inpatient_ID,baby_id,
					Order_id,orderexec_id,prescription_id,
					presc_no,presc_date,
					book_date,book_user,
					STATITEM_CODE,--hditem_id
					XMID,Item_Name,subcode,unit,unitrate,--HSItem_ID
					cost_price,retail_Price,
					num,dosage,
					sdValue,agio,acValue,
					charge_bit,charge_date,charge_user,
					DELETE_BIT,DISCHARGE_BIT,
					CZ_FLAG,CZ_ID,
					doc_id,dept_id,dept_br,execdept_id,type,dept_ly,XMLY,JGBM--C1
				)		
  			values(
  				@V_NEW_FEEID, 
  				@v_InpatientID,@v_BabyID,
  				@v_orderid,dbo.FUN_GETEMPTYGUID(),dbo.FUN_GETEMPTYGUID(),
  				@v_presc_no,GETDATE(),--(current timestamp)
				GETDATE(),@V_EXEUSER,
  				@V_STATITEM_CODE,--@v_HOITEM_ID,
  				@v_HSITEM_ID,@V_ITEM_NAME,@V_SUBCODE,@v_unit,1,
  				@v_cost_price,@v_retail_Price,
  				@v_num,1,
  				@v_sdValue,1,@v_acValue, 
  				1,GETDATE(),@v_exeUser,
  				0,0,
				@V_CZFLAG_SAVE,@v_CZ_ID_SAVE,
  				@v_odocid,@v_odeptid,@v_dept_br,@v_execdept_id,1,@v_wdeptid ,2,'1001' )--@v_barcode

	if @V_NEW_FEEID=dbo.FUN_GETEMPTYGUID() or @V_NEW_FEEID is null
	begin
	   set @err_text='没有返回正确的费用表的ID';
	   return;
	end 
         			
	--记帐时插入到条码表	
	if @V_CZ_FLAG=0	
		insert into zy_fy_jmpz(fyid,txm,RQ) values(@V_NEW_FEEID,@V_BARCODE,GETDATE())	
		
	--置原记录的冲正状态为 1
	if @V_CZ_FLAG<>0
   	   update ZY_Fee_speci set CZ_FLAG=1 where inpatient_id=@v_InpatientID and id=@v_cz_FeeID;

END

ELSE
BEGIN
	--如果是正常记费且在条码表存在相关记录,则返回条码表的费用ID级静配中心(当发生单边业务时,可能我们已记帐但静配中心重复发送记费申请)
	if @V_CZ_FLAG=0	AND @v_barcodecount>0
   	   set @v_new_FeeID=@v_barFeeID;
END
		
SET @ERR_TEXT='保存成功'
SET @ERR_CODE=0


