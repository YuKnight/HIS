IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[SP_YJ_ZJXMMX]') AND TYPE IN (N'P', N'PC'))
DROP PROCEDURE [DBO].[SP_YJ_ZJXMMX]
GO

create PROCEDURE [dbo].[SP_YJ_ZJXMMX]  
 (  
  @ZXKS INT,--执行科室
  @jgbm bigint --机构编码
 )   
AS  
/*
  医技收费项目
  Modify By Daniel 2014-12-08 增加套餐项目
  Modify By Tany 2015-06-03 关联映射表，获取老系统的编码作为数字码
  Modify By tany 2015-06-29 增加tc_flag区别是否套餐项目
*/
 
BEGIN  
declare @i varchar(10)
set @i=(select config from jc_config where id=10003)  
select item_name, item_unit,COST_PRICE AS price, item_code, py_code, wb_code, ITEM_ID AS itemid,
       statitem_code,ISNULL(b.OLDID,'') d_code,'0' tc_flag
 from jc_hsitemdiction a
 left join (select * from DATAMAP where NEWTABLE='jc_hsitem') b on CONVERT(varchar,a.ITEM_ID)=b.NEWID
 where jgbm=@jgbm   and  delete_bit=0
      and (@i=0 or @i is null or 
      (item_id in(select hditem_id from jc_hoi_hdi a,jc_hoi_dept b where tc_flag=0 and a.hoitem_id=b.order_id
      and exec_dept=@zxks)  and @i=1 ))
--套餐收费项目
union all
select a.ITEM_NAME,max(a.ITEM_UNIT) as item_unit,max(a.PRICE) as price,max(a.CODE) as item_code,a.PY_CODE,a.WB_CODE,
       cast(a.ITEM_ID as varchar(20)) as itemid,max(d.STATITEM_CODE) as statitem_code,
       ISNULL(e.OLDID,'') d_code,'1' tc_flag
  from JC_TC a 
  left join JC_TC_MX b on a.ITEM_ID=b.MAINITEM_ID
  left join JC_TCPRICE c on a.ITEM_ID=c.TCID
  left join JC_HSITEM d on b.SUBITEM_ID=d.ITEM_ID
  left join (select * from DATAMAP where NEWTABLE='jc_tc_t') e on CONVERT(varchar,a.ITEM_ID)=e.NEWID
  where a.DELETE_BIT=0 and c.JGBM=@jgbm
  group by a.ITEM_ID,a.ITEM_NAME,a.PY_CODE,a.WB_CODE,e.OLDID
end 

GO