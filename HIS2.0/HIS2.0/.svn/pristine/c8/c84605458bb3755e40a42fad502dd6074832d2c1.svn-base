IF EXISTS ( SELECT  name
            FROM    sysobjects
            WHERE   name = N'SP_YJ_SELECT_FEE'
                    AND TYPE IN (N'P', N'PC')) 
DROP PROCEDURE SP_YJ_SELECT_FEE
GO

CREATE  PROCEDURE [dbo].[SP_YJ_SELECT_FEE]    
 (    
   @ORDERID UNIQUEIDENTIFIER,  
   @ORDEREXECID UNIQUEIDENTIFIER,  
   @TYPE INT, -- 0 医技确认主页面查询时,1医技确认主页面查询时之修改  2已确认医技页面查询时 3 已确认医技修改时  
   @yjqrid UNIQUEIDENTIFIER --医技确认ID  
 )     
    
AS    
    
  
BEGIN    
if @type=0  
 SELECT '' 序号,ITEM_NAME,rtrim(UNIT) unit,COST_PRICE,cast(NUM as float) num ,ACVALUE,CHARGE_DATE,DBO.FUN_GETEMPNAME(CHARGE_USER) CHARGEUSER  
  FROM ZY_FEE_SPECI (nolock)  
 WHERE ORDER_ID=@ORDERID and ORDEREXEC_ID=@ORDEREXECID AND charge_bit=0 and delete_bit=0 and type=1  
if @type=2  
 SELECT '' 序号,ITEM_NAME,rtrim(UNIT) unit,COST_PRICE,cast(NUM as float) num ,ACVALUE,CHARGE_DATE,DBO.FUN_GETEMPNAME(CHARGE_USER) CHARGEUSER,bz  
  FROM ZY_FEE_SPECI aa (nolock)  
  inner join yj_zysq_qrmx bb  
 on aa.id=bb.ZYID WHERE yjqrid=@yjqrid   
if @type=1  
 SELECT aa.subcode AS code,aa.ITEM_NAME as name,AA.cost_PRICE as price,AA.UNIT as item_unit,AA.NUM,AA.ACVALUE as je,  
 CAST(charge_bit AS SMALLINT) as jz,statitem_code,xmid,cast(id as varchar(100)) as id,'' as cz_id,'' DELETE_BIT ,cz_id as y_cz_id,YBJS_BIT  
 FROM    
 ZY_FEE_SPECI aa (nolock)  
  WHERE ORDER_ID=@ORDERID and ORDEREXEC_ID=@ORDEREXECID and charge_bit=0  and delete_bit=0 and aa.type=1  
if @type=3   
 SELECT aa.subcode AS code,aa.ITEM_NAME as name,AA.cost_PRICE as price,AA.UNIT as item_unit,AA.NUM,AA.ACVALUE as je,  
 CAST(charge_bit AS SMALLINT) as jz,statitem_code,xmid,cast(id as varchar(100)) as id,'' as cz_id,'' DELETE_BIT ,cz_id as  y_cz_id,YBJS_BIT  
 FROM    
 ZY_FEE_SPECI aa (nolock) inner join yj_zysq_qrmx bb  
 on aa.id=bb.ZYID WHERE yjqrid=@yjqrid   
   
 END    
 