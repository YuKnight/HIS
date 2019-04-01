IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_YJ_SAVE_Fee]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YJ_SAVE_Fee]
GO
CREATE  PROCEDURE [dbo].[SP_YJ_SAVE_Fee]  
 (  
	@inpatient_id UNIQUEIDENTIFIER,
	@baby_id bigint,
    @order_id UNIQUEIDENTIFIER,
    @orderexec_id UNIQUEIDENTIFIER,
	@prescription_id UNIQUEIDENTIFIER,
	@presc_no decimal(21,6),
	@presc_date varchar(30),
	@book_date varchar(30),
	@book_user INT,
	@statitem_code varchar(20),
	@xmid bigint,
	@subcode varchar(30),
	@item_name varchar(100),
	@unit varchar(20),
	@cost_price decimal(15,4),
	@num decimal(15,2),
	@sdvalue decimal(15,3),
	@cz_id UNIQUEIDENTIFIER,
	@doc_id int,
	@dept_id int,
	@dept_br int,
	@execdept_id int,
	@dept_ly int,
	@jgbm bigint,
	@Newid UNIQUEIDENTIFIER OUTPUT,
	@err_code INT OUTPUT,
	@err_text varchar(50) OUTPUT
 )   
  
   
AS  
  
BEGIN  
set @err_code=-1
set @err_text='费用保存没有成功'

declare @cz_flag int
if @cz_id<>dbo.FUN_GETEMPTYGUID() and @cz_id is not null
set @cz_flag=2
else 
set @cz_flag=0

SET @Newid=dbo.FUN_GETGUID(newid(),getdate())

if @xmid<=0
begin
   set @err_text=@item_name+' 这个项目没有项目ID,系统不允许记帐!'
   return
end

if exists(select * from JC_CONFIG where ID=6021 and CONFIG='1')
begin
if exists(select * from ZY_INPATIENT a,JC_YBLX b where a.yblx=b.ID and INPATIENT_ID=@inpatient_id and ybjklx>0)
begin
  if not exists(select * from ZY_INPATIENT a,jc_yb_bl b where a.yblx=b.yblx and xmly=2 and xmid=@xmid and inpatient_id=@inpatient_id)
  begin
       set @err_text=@item_name+' 这个项目没有进行医保匹配,系统不允许记帐!'
	   return
  end
end
end

insert into zy_fee_speci(id,inpatient_id,baby_id,order_id,
orderexec_id,prescription_id,presc_no,presc_date,book_date,book_user,
statitem_code,xmid,xmly,subcode,item_name,unit,unitrate,cost_price,retail_price,
num,dosage,sdvalue,agio,acvalue,cz_flag,cz_id,--,charge_bit,charge_date,charge_user
doc_id,dept_id,dept_br,execdept_id,dept_ly,jgbm) 
values
(
@Newid,@inpatient_id,@baby_id,@order_id,
@orderexec_id,@prescription_id,@presc_no,@presc_date,@book_date,@book_user,
@statitem_code,@xmid,2,@subcode,@item_name,@unit,1,@cost_price,@cost_price,--,1,@book_date,@book_user
@num,1,@sdvalue,1,@sdvalue,@cz_flag,@cz_id,
@doc_id,@dept_id,@dept_br,@execdept_id,@dept_ly,@jgbm
)

if @cz_id<>dbo.FUN_GETEMPTYGUID() and @cz_id is not null
begin
	update zy_fee_speci set cz_flag=1 where id=@cz_id and cz_flag=0
    if @@rowcount<>1
	begin
      set @err_text='更新原费用状态时,没有影响到行,该费用可能已被冲正'
	  return
	end
end


--修改申请总金额
declare @zje decimal(15,2)
set @zje=(select sum(sdvalue) from zy_fee_speci where orderexec_id=@orderexec_id and type=1 and delete_bit=0)
update yj_zysq set je=@zje where zxid=@orderexec_id
if @@rowcount<>1
begin
      set @err_text='更新医技申请总金额时,没有影响到行,请核实'
	  return
end

set @err_code=0
set @err_text='费用保存成功'
	
END  
  
   
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
GO


