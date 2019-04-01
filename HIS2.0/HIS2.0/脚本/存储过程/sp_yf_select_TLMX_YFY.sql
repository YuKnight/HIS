IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_select_TLMX_YFY' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_select_TLMX_YFY
GO
CREATE PROCEDURE sp_yf_select_TLMX_YFY
(
   @GROUPID UNIQUEIDENTIFIER
)  
as

declare @ss varchar(8000)
declare @ncount int

begin

select 0 序号,cast(1 as smallint) 选择,'' 类型,s_ypjx 剂型,
s_yppm+isnull(ypspmbz,'') 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,cast(cost_price as float) 单价,
 '' 库存数,cast(a.num as float) 数量,a.unit 单位,'' 缺药,'' 转发,cast(sdvalue as float) 金额,shh 货号,a.xmid as cjid,
dbo.FUN_ZY_GETBEDNO(bed_id) 床号,c.name 姓名,inpatient_no 住院号,sex_name  性别,''  年龄,a.dept_br as dept_id,'''' apply_id,'''' apply_date,charge_bit,'''' ward_id,
a.id zy_id,unitrate
,0 ypsl,0 zxdw,0 dwbl,0 批发价,0 批发金额, 
case when dwlx <>1 then
cast(e.num as float)  
else cast(e.num/b.hlxs as decimal(10,4))
end  mcyl,
(case when dwlx <>1 then e.unit else dbo.fun_yp_ypdw(bzdw) end ) mcdw,
cast(CAST(e.NUM as float) as varchar(50))+isnull(e.UNIT,'') 用量,order_usage 用法,
isnull(frequency,'')  频次,
CONVERT(varchar(100), in_date, 21) as  ryrq, '' lsj, --修改
 '' 货位号,'' lyflcode,
left('00',2-len(month(presc_date)))+cast(month(presc_date) as varchar(10))+
left('00',2-len(day(presc_date)))+cast(day(presc_date) as varchar(10)) presc_date,'' as dept_ly,'' as ypdw,
(case when mngtype in(1,5) then '' else exectime end)  gysj,PRESC_DATE 处方日期,
MNGTYPE,--修改MNGTYPE
--以下是加的  
a.kcid,b.ypywm 英文名,a.cz_id,a.DOSAGE 剂数,--4  
e.num 剂量,a.CHARGE_DATE 收费日期,a.CHARGE_USER 收费员id,c.ZY_DOC 管床医生id,e.HOITEM_ID 医嘱序号,  
a.PRESCRIPTION_ID 处方id,e.ORDER_CONTEXT 医嘱内容,e.EXEC_DEPT 执行科室id,e.DEPT_BR 病人科室id,e.DEPT_ID 开单科室id,  
e.ORDER_DOC 开单医生id ,(select ID from yp_ypdw where DWMC=e.UNIT ) jlzxdw,'' ypdw ,c.INPATIENT_ID 住院id,a.BABY_ID 婴儿id,  
'' 嘱托 ,0 组标志,e.unit 剂量单位  

 from zy_fee_speci a(nolock) inner join vi_yp_ypcd b(nolock) on a.xmid=b.cjid and a.xmly=1
  inner join VI_ZY_VINPATIENT_INFO c(nolock) on  a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id
 --inner join ZY_ORDEREXEC d(nolock) on A.ORDEREXEC_ID=d.ID 
 inner join zy_orderrecord e(nolock) on a.order_id=e.order_id
left join JC_FREQUENCY f on e.frequency=f.name
 where a.group_id=@groupid order by a.dept_br,a.inpatient_id,bed_id



END

--cast(CASE WHEN A.CZ_FLAG IN (2,3) THEN A.NUM ELSE A.NUM/ISANALYZED END as float) 
--exec sp_yf_select_TLMX_YFY 17
