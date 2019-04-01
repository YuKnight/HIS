
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_SELECT_TLMX' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_SELECT_TLMX
GO
CREATE PROCEDURE SP_YF_SELECT_TLMX   
 ( @apply_id UNIQUEIDENTIFIER, 
   @APPLY_date varchar(50),
   @dept_ly int,
   @FY_BIT SMALLINT,
   @DEPTID INT,
   @lyfscode varchar(10)
 ) 
as
BEGIN
  declare @stmt varchar(3000);

begin
declare @fk varchar(10)
declare @bmr varchar(10)
set @fk=(select top 1 zt from yk_config where bh=114 and deptid=@deptid)
set @bmr=(select top 1 zt from yk_config where bh=123 and deptid=@deptid)

--select 0 序号, cast( (case when (@fk='1' and @bmr='1') or bsel=0 then 0 else 1 end) as smallint) 选择, Modify BY Tany 2015-05-11 pivas默认勾上所有的，先写死
select 0 序号, cast( (case when (@fk='1' and @bmr='1') or (bsel=0 and @DEPTID not in (598)) then 0 else 1 end) as smallint) 选择,
coalesce(d.name,'其它') 类型,s_ypjx 剂型,  
yppm+isnull(ypspmbz,'') 品名,ypspm 商品名,ypgg 规格,s_sccj 厂家,cast(cost_price as float) 单价,
cast(round(b.KCL,2) as float) 库存数,cast(a.num*a.dosage as float) 数量,a.unit 单位,'缺药' 缺药,'转发' 转发, 
cast(sdvalue as float) 金额,isnull(shh,'') 货号,B.cjid,dbo.FUN_ZY_GETBEDNO(bed_id)  床号, 
c.name  姓名, c.inpatient_no  住院号,''  性别,''  年龄,a.dept_id,@apply_id as apply_id,@APPLY_date as apply_date,
charge_bit,@dept_ly as dept_ly,a.id zy_id,a.UNITRATE,
cast((a.num*a.dosage*B.DWBL/unitrate) as float) ypsl, --药品数量 按药房库存单位比例计算
b.zxdw,b.dwbl,
cast(round(b.pfj/b.dwbl,4) as float) 批发价, CAST((b.pfj*a.num*a.dosage/unitrate) AS FLOAT) 批发金额, --住院费用表中 UNITRATE 单位比例 num 数量 dosage 剂数
cast(CAST(f.NUM as float) as varchar(50))+isnull(f.UNIT,'') 用量,order_usage 用法,
frequency 频次,'' ryrq, isnull(hwmc,'') 货位号,@lyfscode lyflcode, 
cast( round(cost_price*unitrate/b.dwbl,4) as float) lsj,a.PRESC_DATE as 处方日期,
(case when MNGTYPE =0 then '长期医嘱' else '临时医嘱' end) 医嘱类型,


--以下是加的
a.kcid,b.ypywm 英文名,a.cz_id,a.DOSAGE 剂数,--4
f.num 剂量,a.CHARGE_DATE 收费日期,a.CHARGE_USER 收费员id,c.ZY_DOC 管床医生id,f.HOITEM_ID 医嘱序号,
a.PRESCRIPTION_ID 处方id,f.ORDER_CONTEXT 医嘱内容,f.EXEC_DEPT 执行科室id,f.DEPT_BR 病人科室id,f.DEPT_ID 开单科室id,
f.ORDER_DOC 开单医生id ,(select ID from yp_ypdw where DWMC=f.UNIT ) jlzxdw,dbo.fun_yp_ypdw(b.zxdw) ypdw ,c.INPATIENT_ID 住院id,a.BABY_ID 婴儿id,
'' 嘱托 ,0 组标志,f.unit 剂量单位   
from zy_fee_speci a(nolock) 
inner join vi_yf_kcmx b(nolock) on a.XMID=b.cjid AND A.XMLY=1 and deptid=@deptid 
and fy_bit=@FY_BIT and delete_bit=0 AND EXECDEPT_ID=@DEPTID
and apply_id=@apply_id
inner join VI_ZY_VINPATIENT c on a.inpatient_id=c.inpatient_id
left join yp_tlfl d on b.tlfl=d.code 
left join yp_hwsz e on b.ggid=e.ggid and e.deptid=@deptid
left join ZY_ORDERRECORD f on a.ORDER_ID=f.ORDER_ID
 order by  ylfl,s_ypjx,ypspm,cost_price;  
end 
 
END;


--select * from zy_orderrecord
