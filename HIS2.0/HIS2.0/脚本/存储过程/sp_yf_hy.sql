IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_hy' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_hy
GO

  
  
CREATE PROCEDURE [dbo].[sp_yf_hy]  
(  
  @zy_id UNIQUEIDENTIFIER ,  
  @new_cjid int,  
  @new_price decimal(15,4),  
  @new_je decimal(15,2),  
  @ERR_CODE INTEGER output,  
     @ERR_TEXT VARCHAR(100) output  ,  
  @sccj varchar(100),  
  @djy varchar(30),  
  @kcl varchar(50)  
)  
as  
 declare @statitemcode varchar(10)  
  
 SET @ERR_CODE=-1  
 SET @ERR_TEXT='换药失败'  
  
begin   
  
  
   declare @order_id UNIQUEIDENTIFIER  
   declare @charge_bit smallint  
   declare @charge_date datetime  
   declare @prescription_id UNIQUEIDENTIFIER  
   declare @old_price decimal(15,4)  
   select @old_price=cost_price,@order_id=order_id,@charge_bit=charge_bit,@charge_date=charge_date,@prescription_id=prescription_id from zy_fee_speci where id=@zy_id  
  
   if @charge_bit=1  
   begin  
   if convert(nvarchar,@charge_date,112)<convert(nvarchar,getdate(),112)  and @old_price<>@new_price  
   begin  
     set @err_text='该药品已记费,记费时间是'+convert(nvarchar,@charge_date,112)+',且替换的药品价格与原来的药品价格不同，不能替换'  
     return  
   end  
   end  
         

  update zy_fee_speci set XMID=@new_cjid ,cost_price=@new_price,retail_price=@new_price,  
  sdvalue=@new_je,acvalue=@new_je,cj=@sccj,bz=convert(nvarchar,getdate(),112) +'换成新厂家:'+@sccj+' 操作员:'+@djy+'当时库存:'+@kcl where id=@zy_id   
  if @@rowcount=0  
  begin  
    set @err_text='没有更新到费用记录,请核实'  
    return  
  end  
  
  update zy_prescription set price=@new_price,hditem_id=@new_cjid where id=@prescription_id  
  
  if  @order_id<>dbo.FUN_GETEMPTYGUID()   
      begin  
            update zy_orderrecord set hoitem_id=@new_cjid where order_id=@order_id  
            if @@rowcount=0  
            begin  
                set @err_text='没有更新到医嘱记录,请核实'  
                return  
            end  
      end  
end    
  
SET @ERR_CODE=0  
SET @ERR_TEXT=''  
  
  
  
  