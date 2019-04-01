IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_SELECT_ZYCF_MESSAGE' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_SELECT_ZYCF_MESSAGE
GO
CREATE PROCEDURE SP_YF_SELECT_ZYCF_MESSAGE
 ( @dept_ly int,
   @zxks int
 ) 
as

DECLARE @TS INT
SET @TS=(SELECT CONFIG FROM JC_CONFIG WHERE ID=8034)
IF @TS IS NULL OR RTRIM(@TS)='' SET @TS=0

declare @rq datetime
set @rq=GETDATE()-@TS
declare @bz varchar(100)
if @TS>0
begin
set @bz='自'+CAST(month(@rq) as varchar(10))+'月'+CAST(day(@rq) as varchar(10))+'后有'
select DEPT_LY,@bz+CAST(count(*) as varchar(30))+'个待发药记录' as bz from zy_fee_speci(NOLOCK) 
 where PRESC_DATE>=GETDATE()-@TS and xmly=1 and fy_bit=0   and TLFS in(3,5)
and DELETE_BIT=0 and EXECDEPT_ID=@zxks
group by DEPT_LY
end
else
 select 0 dept_ly ,'' bz 


/*
 EXEC SP_YF_SELECT_ZYCF_MESSAGE 0,21
*/