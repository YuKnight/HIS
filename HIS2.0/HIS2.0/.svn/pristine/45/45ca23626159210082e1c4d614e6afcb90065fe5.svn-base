IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[SP_YJ_SAVE_QRJL]') AND TYPE IN (N'P', N'PC'))
DROP PROCEDURE [DBO].[SP_YJ_SAVE_QRJL]
GO

CREATE  PROCEDURE [dbo].[SP_YJ_SAVE_QRJL]    
 (    
  @orderid UNIQUEIDENTIFIER, --医嘱执行ID  
  @yjsqid UNIQUEIDENTIFIER, --医技申请ID  
  @JE DECIMAL(15,2), --金额  
  @QRKS INT,--确认科室  
  @QRSJ VARCHAR(30),--确认时间  
  @QRR INT, --确认人  
  @BSCQRBZ INT, --首次确认标志  PACSS 填1   
  @jcrq varchar(30), --检查日期  
  @jcys int,--检查医生  
  @JGWZ varchar(200), --结果位置或结果内容  
  @NewYjqrid UNIQUEIDENTIFIER OUTPUT,   
  @err_code INT OUTPUT,  
  @err_text varchar(50) OUTPUT,  
  @orderexecid UNIQUEIDENTIFIER,  
  @bjlzt smallint  --PACSS 填0  
 )     
    
     
AS    
    
BEGIN    
set @err_code=-1  
set @err_text='确认没有成功'  
  
  
declare @qrje decimal(15,2)  
  
SET @NewYjqrid=dbo.FUN_GETEMPTYGUID()  
SET @NewYjqrid=dbo.FUN_GETGUID(newid(),getdate())  
--本次确费明细  
select id,xmid as itemid,a.tcid,unit as dw,cost_price as dj,num as sl,  
acvalue as je,cz_id into #temp   
 from zy_fee_speci a left join yj_zysq_qrmx b   
on a.id=b.zyid where order_id=@orderid  and   
ORDEREXEC_ID=@orderexecid and delete_bit=0 and a.type=1 and zyid is null  
  
set @qrje=(select sum(je) from #temp)  
set @qrje=coalesce(@qrje,0)  
  
  
  
--插入确认记录  
insert into yj_zysq_qrjl(yjqrid,yjsqid,je,qrks,qrsj,qrr,bscqrbz,bjlzt)  
values(@NewYjqrid,@yjsqid,@qrje,@qrks,@qrsj,@qrr,@bscqrbz,@bjlzt)  
  
--更新首次确认标志及退费标志  
if @BSCQRBZ=1  
 update yj_zysq set bjsbz=1 ,JSKS=@qrks,jssj=@qrsj,jsr=@qrr,  
 jcrq=@jcrq,jcys=@jcys,JGWZ=@JGWZ,btfbz=0,tfje=0,je=@qrje  
 where bjsbz=0 and yjsqid=@yjsqid and bscbz=0  
else   
begin
 --增加长沙市第八医院护士冲正医技医嘱，医技科室拒绝后，yj_zysq表的金额不会更新为0
 --Modify By LCY 2014-12-10
 declare @hospit_name  varchar(40)
 set @hospit_name=(select CONFIG from JC_CONFIG where ID=2)
 if @hospit_name='长沙市第八医院'
     update yj_zysq set btfbz=0,tfje=0,je=@qrje
     where bjsbz=1 and yjsqid=@yjsqid and bscbz=0  
 else 
     update yj_zysq set btfbz=0,tfje=0,je=je+(@qrje)  
     where bjsbz=1 and yjsqid=@yjsqid and bscbz=0  
end
  
  
--产生本次确费明细  
if @qrje<>@je  
begin  
 set @err_text='确认明细金额'+cast(@qrje as varchar(30))+',页面金额'+cast(@je as varchar(30))+'请核实'  
 return;  
end  
insert into yj_zysq_qrmx  
(yjqrmxid,yjsqid,yjqrid,itemid,tcid,dw,dj,sl,je,qrks,qrsj,qrr,zyid)  
select dbo.FUN_GETGUID(newid(),getdate()),  
@yjsqid,@NewYjqrid,itemid,tcid,dw,dj,sl,je,@qrks,@qrsj,@qrr,id from  #temp  
  
--更新费用表计算标志  
if @bjlzt=1 --拒绝  
begin  
 update a set delete_bit=1,bz='医技科室拒绝('+dbo.fun_getempname(@qrr)+')'  
 from zy_fee_speci a ,#temp b where a.id=b.id and a.charge_bit=0  
      
   --更新原正记录冲帐标志  
    update a set cz_flag=0    
 from zy_fee_speci a ,#temp b where a.id=b.cz_id and abs(a.num)=abs(b.sl)  
end  
else   
    update a set charge_bit=1,charge_date=@qrsj,charge_user=@qrr   
 from zy_fee_speci a ,#temp b where a.id=b.id and a.charge_bit=0  
  
  
--if @@rowcount<>1  
--begin  
 --set @err_text='确认时更新到'+cast(@@rowcount as varchar(30))+'行记录,请刷新后重试'  
 --return;  
--end   
  
  
set @err_code=0  
set @err_text='确认成功'  
   
END  